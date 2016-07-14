Imports System.Data
Imports System.IO

Public Class frmMenu
    Private conn As Data.OleDb.OleDbConnection
    Private CurrentDatabaseName As String = "C:\db\Accounting.mdb"
    Private bAddRootNode As Boolean
    Private nNode1, nNode2 As TreeNode
    Private Sub TreeView1_DoubleClick(sender As Object, e As EventArgs) Handles TreeView1.DoubleClick
        If TreeView1.SelectedNode IsNot Nothing Then
            If TreeView1.SelectedNode.IsExpanded Then
                TreeView1.SelectedNode.Collapse()
            Else
                TreeView1.SelectedNode.Expand()
            End If
            ShowForm(TreeView1.SelectedNode, chkChilds.Checked, chkParents.Checked)
        End If
    End Sub

    Private Sub ShowForm(nNode As TreeNode, bShowChilds As Boolean, bShowParents As Boolean)
        Dim sMsg As String
        Dim obj As Object
        Dim nChild As TreeNode
        If nNode.Tag Is Nothing Then

            sMsg = "You have clicked " + nNode.Text
            Try
                obj = Activator.CreateInstance(Type.GetType(System.Reflection.Assembly.GetExecutingAssembly.GetName().Name + "." + nNode.Name))
                obj.setLabel(sMsg)
                obj.Show()
            Catch
                MsgBox("Error loading form ! (" + nNode.Text + ": " + nNode.Name + ")")
            End Try
            If bShowChilds Then
                If nNode.Nodes.Count > 0 Then
                    For Each nChild In nNode.Nodes
                        ShowForm(nChild, True, False)
                    Next
                End If
            End If
            If bShowParents Then
                If nNode.Parent IsNot Nothing Then
                    ShowForm(nNode.Parent, False, True)
                End If
            End If
        Else
            Try
                Process.Start(nNode.Tag)
            Catch ex As Exception
                MsgBox("Error executing program to open this file!")
            End Try

        End If
    End Sub

    Private Sub frmMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
        nNode1 = Nothing
        nNode2 = Nothing
        InitializeGrid()
        LoadTree(CurrentDatabaseName)
    End Sub

    Private Sub InitializeGrid()
        Dim col1 As DataGridViewTextBoxColumn
        With DGVEntries
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .Columns.Clear()
            col1 = New DataGridViewTextBoxColumn()
            col1.Name = "EntryId"
            col1.HeaderText = "EntryId"
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            col1.ReadOnly = True
            .Columns.Add(col1)

            col1 = New DataGridViewTextBoxColumn()
            col1.Name = "DebitAccount"
            col1.HeaderText = "Debit Account"
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            col1.ReadOnly = True
            .Columns.Add(col1)

            col1 = New DataGridViewTextBoxColumn()
            col1.Name = "CreditAccount"
            col1.HeaderText = "Credit Account"
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            col1.ReadOnly = True
            .Columns.Add(col1)

            col1 = New DataGridViewTextBoxColumn()
            col1.Name = "Amount"
            col1.HeaderText = "Account"
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            col1.ReadOnly = True
            .Columns.Add(col1)

        End With
    End Sub

    Private Sub LoadTree(sDBName As String)
        If sDBName = "" Then
            sDBName = InputBox("Enter the database to load: ", "Database Name", "TreeView.mdb")
        End If
        TreeView1.Nodes.Clear()
        If OpenConn(sDBName) Then
            CreateChildNodes(TreeView1)
            lblStatus.Text = sDBName
        Else
            MsgBox("Cannot connect to the database...")
        End If
    End Sub

    Private Sub CreateChildNodes(ByVal treeControl As TreeView, Optional ByVal parentNode As TreeNode = Nothing)
        Dim cmd As Data.OleDb.OleDbCommand
        Dim rs As Data.OleDb.OleDbDataReader
        Dim sSQL As String
        Dim currentNode As TreeNode

        If parentNode Is Nothing Then
            sSQL = "SELECT MenuName, MenuDesc, HasSubFolder, SubFolderPath From ChartOfAccounts WHERE ParentMenu is NULL ORDER BY MenuOrder, HasSubFolder, MenuDesc"
        Else
            sSQL = "SELECT MenuName, MenuDesc, HasSubFolder, SubFolderPath From ChartOfAccounts WHERE ParentMenu = '" & parentNode.Text & "' ORDER BY MenuOrder, HasSubFolder, MenuDesc"
        End If
        cmd = conn.CreateCommand()
        cmd.CommandText = sSQL
        Try
            rs = cmd.ExecuteReader()
        Catch ex As Exception
            MsgBox("Error selecting records!" & vbCrLf & ex.Message)
            Exit Sub
        End Try

        While rs.Read()
            If parentNode Is Nothing Then
                currentNode = treeControl.Nodes.Add(rs.GetString(0))
            Else
                currentNode = parentNode.Nodes.Add(rs.GetString(0))
            End If
            With currentNode
                .Name = rs.GetString(0)
                .Text = rs.GetString(1)
                If rs.GetString(2) = "Y" Then
                    .Tag = rs.GetString(3)
                    LoadFolderTree(rs.GetString(3), True, currentNode)
                End If
            End With
            CreateChildNodes(treeControl, currentNode)
        End While
        rs.Close()
    End Sub

    Private Function OpenConn(sDBName As String) As Boolean
        Dim sConn As String
        Dim bNewDB As Boolean
        'Microsoft.Jet.OLEDB.4.0
        'Microsoft.ACE.OLEDB.12.0
        bNewDB = False
        If sDBName <> "" And CurrentDatabaseName <> sDBName Then
            CurrentDatabaseName = sDBName
            bNewDB = True
        End If
        sConn = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source=" & CurrentDatabaseName & ";Persist Security Info=False;User Id=Admin;"
        If conn Is Nothing Then
            conn = New OleDb.OleDbConnection(sConn)
        Else
            If conn.State = 1 Then
                conn.Close()
                conn.ConnectionString = sConn
                Try
                    conn.Open()
                    OpenConn = True
                    Exit Function
                Catch
                    CurrentDatabaseName = ""
                    OpenConn = False
                    Exit Function
                End Try
            ElseIf conn.State = 0 Then
                conn.ConnectionString = sConn
                Try
                    conn.Open()
                    OpenConn = True
                    Exit Function
                Catch
                    CurrentDatabaseName = ""
                    OpenConn = False
                    Exit Function
                End Try
            Else
                conn.Close()
            End If
        End If
        Try
            OpenConn = True
            conn.Open()
        Catch
            OpenConn = False
        End Try
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim fAddNode As New frmAddNode
        bAddRootNode = False
        fAddNode.initForm(True, Nothing)
        fAddNode.ShowDialog()
        SaveTree(Nothing, 1, "")
    End Sub

    Friend Sub SaveNode(ByVal sMenuName As String, ByVal sFormName As String)
        If TreeView1.SelectedNode Is Nothing Or bAddRootNode Then
            With TreeView1.Nodes.Add(sFormName)
                .Name = sFormName
                .Text = sMenuName
            End With
        Else
            With TreeView1.SelectedNode.Nodes.Add(sFormName)
                .Name = sFormName
                .Text = sMenuName
            End With
        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not (TreeView1.SelectedNode Is Nothing) Then
            TreeView1.Nodes.Remove(TreeView1.SelectedNode)
        End If
        SaveTree(Nothing, 1, "")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim sDBName As String
        Dim oFlDlg As New SaveFileDialog
        Dim iResult As Integer
        oFlDlg.Title = "New Database"
        oFlDlg.CheckFileExists = False
        oFlDlg.CheckPathExists = True
        oFlDlg.CreatePrompt = False
        oFlDlg.Filter = "Access Database|*.mdb"
        oFlDlg.OverwritePrompt = True
        oFlDlg.SupportMultiDottedExtensions = True
        oFlDlg.DefaultExt = "mdb"
        If oFlDlg.ShowDialog() = DialogResult.OK Then
            sDBName = oFlDlg.FileName
        Else
            Exit Sub
        End If
        iResult = CreateNewDatabase(sDBName)
        If iResult = 0 Then
            SaveTree(Nothing, 1, sDBName)
            MsgBox("Save Complete!")
        ElseIf iResult = 1 Then
            MsgBox("Database already exists!")
        Else
            MsgBox("Error creating database!")
        End If
    End Sub

    Private Sub SaveTree(ByVal nNode As TreeNode, ByVal iSortOrder As Integer, sDBName As String)
        Dim cmd As Data.OleDb.OleDbCommand
        Dim nd As TreeNode
        Dim sSQL As String
        If OpenConn(sDBName) Then
            cmd = conn.CreateCommand()
            If nNode Is Nothing Then
                cmd.CommandText = "DELETE FROM ChartOfAccounts"
                cmd.ExecuteNonQuery()
                For Each nd In TreeView1.Nodes
                    sSQL = "INSERT INTO ChartOfAccounts(MenuDesc, MenuName, ParentMenu, HasSubFolder, SubFolderPath, MenuOrder) VALUES('" & nd.Text & "','" & nd.Name & "'"
                    sSQL = sSQL & ",NULL,"
                    If nd.Tag Is Nothing Then
                        sSQL = sSQL & "'N',NULL,"
                    Else
                        sSQL = sSQL & "'Y','" & nd.Tag.ToString() & "',"
                    End If
                    sSQL = sSQL & iSortOrder.ToString() & ")"
                    cmd.CommandText = sSQL
                    cmd.ExecuteNonQuery()
                    If nd.Nodes.Count > 0 And nd.Tag Is Nothing Then
                        SaveTree(nd, iSortOrder, sDBName)
                    End If
                    iSortOrder = iSortOrder + 1
                Next
            Else
                For Each nd In nNode.Nodes
                    sSQL = "INSERT INTO ChartOfAccounts(MenuDesc, MenuName, ParentMenu, HasSubFolder, SubFolderPath, MenuOrder) VALUES('" & nd.Text & "','" & nd.Name & "'"
                    sSQL = sSQL & ",'" & nd.Parent.Text & "',"
                    If nd.Tag Is Nothing Then
                        sSQL = sSQL & "'N',NULL,"
                    Else
                        sSQL = sSQL & "'Y','" & nd.Tag.ToString() & "',"
                    End If
                    sSQL = sSQL & iSortOrder.ToString() & ")"
                    cmd.CommandText = sSQL
                    cmd.ExecuteNonQuery()
                    If nd.Nodes.Count > 0 And nd.Tag Is Nothing Then
                        SaveTree(nd, iSortOrder, sDBName)
                    End If
                Next
            End If
        Else
            MsgBox("Cannot connect to the database")
        End If
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim sDBName As String
        Dim oFlDlg As New OpenFileDialog
        oFlDlg.CheckFileExists = True
        oFlDlg.Filter = "Access Database|*.mdb"
        oFlDlg.Multiselect = False
        oFlDlg.Title = "Open database to load"
        If oFlDlg.ShowDialog() = DialogResult.OK Then
            sDBName = oFlDlg.FileName
            LoadTree(sDBName)
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim nNode As TreeNode
        If txtLookup.Text <> "" Then
            nNode = FindNode(txtLookup.Text, Nothing)
            If nNode Is Nothing Then
                txtOutput.Text = ""
                MsgBox("Not found")
            Else
                txtOutput.Text = nNode.Name
                TreeView1.SelectedNode = nNode
                TreeView1.Select()

            End If
        End If
    End Sub

    Private Function FindNode(ByVal sSearchText As String, ByVal nNode As TreeNode) As TreeNode
        Dim nChildNode As TreeNode
        Dim nFoundNode As TreeNode
        Dim nCollection As TreeNodeCollection
        Dim sCompareString As String
        If nNode Is Nothing Then
            nCollection = TreeView1.Nodes
        Else
            nCollection = nNode.Nodes
        End If
        For Each nChildNode In nCollection
            If nChildNode.Text.Length > sSearchText.Length Then
                sCompareString = UCase(nChildNode.Text).Substring(0, Len(sSearchText))
            Else
                sCompareString = UCase(nChildNode.Text)
            End If
            If UCase(sSearchText) = sCompareString Then
                FindNode = nChildNode
                Exit Function
            End If
            If nChildNode.Nodes.Count > 0 Then
                nFoundNode = FindNode(sSearchText, nChildNode)
                If nFoundNode IsNot Nothing Then
                    FindNode = nFoundNode
                    Exit Function
                End If
            End If
        Next
        FindNode = Nothing
    End Function

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim fAddNode As New frmAddNode
        If TreeView1.SelectedNode IsNot Nothing Then
            fAddNode.initForm(False, TreeView1.SelectedNode)
            fAddNode.ShowDialog()
            SaveTree(Nothing, 1, "")
        End If
    End Sub

    Private Sub btnRootNode_Click(sender As Object, e As EventArgs) Handles btnRootNode.Click
        Dim fAddNode As New frmAddNode
        bAddRootNode = True
        fAddNode.initForm(True, Nothing)
        fAddNode.ShowDialog()
        SaveTree(Nothing, 1, "")
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Dim rpt As frmReportForm
        Dim nRpt As New TreeViewReport
        Dim oFlDlg As New OpenFileDialog
        rpt = New frmReportForm
        btnReport.Enabled = False
        rpt.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        If chkUseExistingDB.Checked Then
            nRpt.DataSourceConnections.Item(0).SetConnection(CurrentDatabaseName, CurrentDatabaseName, "", "")
        Else
            oFlDlg.CheckFileExists = True
            oFlDlg.Filter = "Access Database|*.mdb"
            oFlDlg.Multiselect = False
            oFlDlg.Title = "Open database to load"
            If oFlDlg.ShowDialog() = DialogResult.OK Then
                nRpt.DataSourceConnections.Item(0).SetConnection(oFlDlg.FileName, oFlDlg.FileName, "", "")
            End If
        End If
        rpt.CrystalReportViewer1.ReportSource = nRpt
        rpt.ShowDialog()
        btnReport.Enabled = True
    End Sub

    Private Function CreateNewDatabase(sDBName As String) As Integer
        Dim oCat As Object
        Dim oTable As Object
        Dim oConn As Object
        If My.Computer.FileSystem.FileExists(sDBName) Then
            CreateNewDatabase = 1
        Else
            Try
                oTable = CreateObject("ADOX.Table")
                oTable.Name = "TreeViewMenu"

                oTable.Columns.Append("MenuDesc", 202)
                oTable.Columns.Append("MenuName", 202)
                oTable.Columns.Append("ParentMenu", 202)
                oTable.Columns.Item("ParentMenu").Attributes = 2
                oTable.Columns.Append("HasSubFolder", 202)
                oTable.Columns.Item("HasSubFolder").Attributes = 2
                oTable.Columns.Append("SubFolderPath", 202)
                oTable.Columns.Item("SubFolderPath").Attributes = 2
                oTable.Columns.Append("MenuOrder", 3)


                oCat = CreateObject("ADOX.Catalog")
                oCat.Create("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & sDBName & "; Jet OLEDB:Engine Type=5")

                oCat.Tables.Append(oTable)
                oCat.Tables.Refresh()
                oCat.ActiveConnection.Close()
                oCat = Nothing
                oConn = Nothing
                CreateNewDatabase = 0
            Catch
                CreateNewDatabase = 2
            End Try
        End If
    End Function

    Private Sub btnLoadDirTree_Click(sender As Object, e As EventArgs) Handles btnLoadDirTree.Click
        Dim oFolder As New FolderBrowserDialog()
        If chkSubTree.Checked Then
            If TreeView1.SelectedNode Is Nothing Then
                MsgBox("Select a node in tree to add the directory tree!")
                Exit Sub
            Else
                If oFolder.ShowDialog() = DialogResult.OK Then
                    LoadFolderTree(oFolder.SelectedPath(), True, TreeView1.SelectedNode)
                    SaveTree(Nothing, 1, "")
                End If
            End If
        Else
            If oFolder.ShowDialog() = DialogResult.OK Then
                LoadFolderTree(oFolder.SelectedPath(), False, Nothing)
                SaveTree(Nothing, 1, "")
            End If
        End If
    End Sub

    Sub LoadFolderTree(sDirectory As String, bSubTree As Boolean, Optional pNode As TreeNode = Nothing)
        Dim nNode As TreeNode
        Dim dirInfo As DirectoryInfo
        dirInfo = New DirectoryInfo(sDirectory)
        nNode = New TreeNode(dirInfo.Name)
        nNode.Text = dirInfo.Name
        If dirInfo.Attributes = FileAttributes.Directory Then
            nNode.ImageIndex = 2
            nNode.SelectedImageIndex = 3
            nNode.Tag = sDirectory
            If bSubTree Then
                If pNode IsNot Nothing Then
                    pNode.Nodes.Add(nNode)
                    pNode.Tag = sDirectory
                Else
                    MsgBox("Select a node in tree to add the directory tree!")
                    Exit Sub
                End If
            Else
                TreeView1.Nodes.Clear()
                TreeView1.Nodes.Add(nNode)
            End If
            LoadFolder(nNode, dirInfo)
        End If
    End Sub

    Sub LoadFolder(pNode As TreeNode, pDirInfo As DirectoryInfo)
        Dim fl As FileInfo
        Dim fld As DirectoryInfo
        Dim nNode As TreeNode
        If pDirInfo.Attributes = FileAttributes.Directory Then
            For Each fld In pDirInfo.GetDirectories()
                nNode = New TreeNode(fld.Name)
                nNode.Text = fld.Name
                nNode.Tag = fld.FullName
                nNode.ImageIndex = 2
                nNode.SelectedImageIndex = 3
                pNode.Nodes.Add(nNode)
                LoadFolder(nNode, fld)
            Next
            For Each fl In pDirInfo.GetFiles()
                nNode = New TreeNode(fl.Name)
                nNode.Text = fl.Name
                nNode.Tag = fl.FullName
                nNode.ImageIndex = 1
                nNode.SelectedImageIndex = 1
                pNode.Nodes.Add(nNode)
            Next
        End If
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        Dim destFolder As FolderBrowserDialog
        Dim sSource As String
        If TreeView1.SelectedNode IsNot Nothing Then
            If TreeView1.SelectedNode.Parent IsNot Nothing Then
                If TreeView1.SelectedNode.Parent.Tag IsNot Nothing Then
                    If TreeView1.SelectedNode.Tag IsNot Nothing Then
                        sSource = TreeView1.SelectedNode.Tag
                        destFolder = New FolderBrowserDialog()
                        If destFolder.ShowDialog() = DialogResult.OK Then
                            If My.Computer.FileSystem.DirectoryExists(sSource) Then
                                Try
                                    My.Computer.FileSystem.CopyDirectory(sSource, destFolder.SelectedPath & "\" & My.Computer.FileSystem.GetFileInfo(sSource).Name, FileIO.UIOption.AllDialogs)
                                    MsgBox("Folder copied successfully!")
                                    LoadTree(CurrentDatabaseName)
                                Catch ex As Exception
                                    MsgBox("Error copying folder...." & vbCrLf & ex.Message)
                                End Try

                            ElseIf My.Computer.FileSystem.FileExists(sSource) Then
                                Try
                                    My.Computer.FileSystem.CopyFile(sSource, destFolder.SelectedPath & "\" & My.Computer.FileSystem.GetFileInfo(sSource).Name, FileIO.UIOption.AllDialogs)
                                    MsgBox("Folder copied successfully!")
                                    LoadTree(CurrentDatabaseName)
                                Catch ex As Exception
                                    MsgBox("Error copying file...." & vbCrLf & ex.Message)
                                End Try
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnMove_Click(sender As Object, e As EventArgs) Handles btnMove.Click
        Dim destFolder As FolderBrowserDialog
        Dim sSource As String
        If TreeView1.SelectedNode IsNot Nothing Then
            If TreeView1.SelectedNode.Parent IsNot Nothing Then
                If TreeView1.SelectedNode.Parent.Tag IsNot Nothing Then
                    If TreeView1.SelectedNode.Tag IsNot Nothing Then
                        sSource = TreeView1.SelectedNode.Tag
                        destFolder = New FolderBrowserDialog()
                        If destFolder.ShowDialog() = DialogResult.OK Then
                            If My.Computer.FileSystem.DirectoryExists(sSource) Then
                                Try

                                    My.Computer.FileSystem.MoveDirectory(sSource, destFolder.SelectedPath & "\" & My.Computer.FileSystem.GetDirectoryInfo(sSource).Name, FileIO.UIOption.AllDialogs)
                                    MsgBox("Folder moved successfully!" & vbCrLf & "Source: " & sSource & vbCrLf & "Destination: " & destFolder.SelectedPath.ToString())
                                    LoadTree(CurrentDatabaseName)
                                Catch ex As Exception
                                    MsgBox("Error moving folder...." & vbCrLf & ex.Message)
                                End Try

                            ElseIf My.Computer.FileSystem.FileExists(sSource) Then
                                Try
                                    My.Computer.FileSystem.MoveFile(sSource, destFolder.SelectedPath & "\" & My.Computer.FileSystem.GetFileInfo(sSource).Name, FileIO.UIOption.AllDialogs)
                                    MsgBox("Folder moved successfully!")
                                    LoadTree(CurrentDatabaseName)
                                Catch ex As Exception
                                    MsgBox("Error moving file...." & vbCrLf & ex.Message)
                                End Try
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnSetDebitAccount_Click(sender As Object, e As EventArgs) Handles btnSetDebitAccount.Click
        If TreeView1.SelectedNode Is Nothing Then
            MsgBox("Select a node to set as Debit Account")
        ElseIf nNode2 IsNot Nothing Then
            If TreeView1.SelectedNode.FullPath = nNode2.FullPath Then
                MsgBox("This node is already selected as Credit Account")
            Else
                nNode1 = TreeView1.SelectedNode
                lblDebitAccount.Text = nNode1.Text
                txtDebitAccount.Text = nNode1.FullPath
            End If
        Else
            nNode1 = TreeView1.SelectedNode
            lblDebitAccount.Text = nNode1.Text
            txtDebitAccount.Text = nNode1.FullPath
        End If
    End Sub

    Private Sub btnSetCreditAccount_Click(sender As Object, e As EventArgs) Handles btnSetCreditAccount.Click
        If TreeView1.SelectedNode Is Nothing Then
            MsgBox("Select a node to set as Credit Account")
        ElseIf nNode1 IsNot Nothing Then
            If nNode1.FullPath = TreeView1.SelectedNode.FullPath Then
                MsgBox("This node is already selected as Debit Account")
            Else
                nNode2 = TreeView1.SelectedNode
                lblCreditAccount.Text = nNode2.Text
                txtCreditAccount.Text = nNode2.FullPath
            End If
        Else
            nNode2 = TreeView1.SelectedNode
            lblCreditAccount.Text = nNode2.Text
            txtCreditAccount.Text = nNode2.FullPath
        End If
    End Sub

    Private Sub btnSaveData_Click(sender As Object, e As EventArgs) Handles btnSaveData.Click
        Dim dAmount As Boolean
        Dim iNewRow As Integer
        Dim rw As DataGridViewRow
        If nNode1 IsNot Nothing And nNode2 IsNot Nothing And Double.TryParse(txtAmount.Text, dAmount) Then
            iNewRow = DGVEntries.Rows.Add()
            rw = DGVEntries.Rows(iNewRow)
            rw.Cells("EntryId").Value = "NEW"
            rw.Cells("DebitAccount").Value = nNode1.Text
            rw.Cells("CreditAccount").Value = nNode2.Text
            rw.Cells("Amount").Value = txtAmount.Text
        Else
            MsgBox("Select a debit account, a credit account and amount for the entry!")
        End If
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click

        Dim destFolder As String
        Dim sSource As String
        If TreeView1.SelectedNode IsNot Nothing Then
            If TreeView1.SelectedNode.Parent IsNot Nothing Then
                If TreeView1.SelectedNode.Parent.Tag IsNot Nothing Then
                    If TreeView1.SelectedNode.Tag IsNot Nothing Then
                        sSource = TreeView1.SelectedNode.Tag
                        destFolder = InputBox("Enter the directory name to create...")
                        If destFolder <> "" Then
                            If My.Computer.FileSystem.DirectoryExists(sSource) Then
                                Try
                                    My.Computer.FileSystem.CreateDirectory(sSource & "\" & destFolder)
                                    MsgBox("Folder created successfully!")
                                    LoadTree(CurrentDatabaseName)
                                Catch ex As Exception
                                    MsgBox("Error creating folder...." & vbCrLf & ex.Message)
                                End Try
                            Else
                                sSource = TreeView1.SelectedNode.Parent.Tag
                                If My.Computer.FileSystem.DirectoryExists(sSource) Then
                                    Try
                                        My.Computer.FileSystem.CreateDirectory(sSource & "\" & destFolder)
                                        MsgBox("Folder created successfully!")
                                        LoadTree(CurrentDatabaseName)
                                    Catch ex As Exception
                                        MsgBox("Error creating folder...." & vbCrLf & ex.Message)
                                    End Try
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub
End Class
