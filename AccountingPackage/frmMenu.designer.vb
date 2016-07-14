<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.imgFolderFile = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.txtLookup = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.chkParents = New System.Windows.Forms.CheckBox()
        Me.chkChilds = New System.Windows.Forms.CheckBox()
        Me.btnRootNode = New System.Windows.Forms.Button()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.chkUseExistingDB = New System.Windows.Forms.CheckBox()
        Me.btnLoadDirTree = New System.Windows.Forms.Button()
        Me.chkSubTree = New System.Windows.Forms.CheckBox()
        Me.statusStrip = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.btnMove = New System.Windows.Forms.Button()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.btnSetDebitAccount = New System.Windows.Forms.Button()
        Me.btnSetCreditAccount = New System.Windows.Forms.Button()
        Me.lblDebitAccount = New System.Windows.Forms.Label()
        Me.lblCreditAccount = New System.Windows.Forms.Label()
        Me.txtDebitAccount = New System.Windows.Forms.TextBox()
        Me.txtCreditAccount = New System.Windows.Forms.TextBox()
        Me.btnSaveData = New System.Windows.Forms.Button()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.DGVEntries = New System.Windows.Forms.DataGridView()
        Me.statusStrip.SuspendLayout()
        CType(Me.DGVEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.imgFolderFile
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(278, 245)
        Me.TreeView1.TabIndex = 0
        '
        'imgFolderFile
        '
        Me.imgFolderFile.ImageStream = CType(resources.GetObject("imgFolderFile.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgFolderFile.TransparentColor = System.Drawing.Color.Transparent
        Me.imgFolderFile.Images.SetKeyName(0, "Pie Chart.png")
        Me.imgFolderFile.Images.SetKeyName(1, "File New.png")
        Me.imgFolderFile.Images.SetKeyName(2, "Folder Close.png")
        Me.imgFolderFile.Images.SetKeyName(3, "Folder Open.png")
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(12, 251)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add Node"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(99, 251)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete Node"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(12, 315)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save Tree"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(99, 315)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnLoad.TabIndex = 4
        Me.btnLoad.Text = "Load Tree"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'txtLookup
        '
        Me.txtLookup.Location = New System.Drawing.Point(12, 354)
        Me.txtLookup.Name = "txtLookup"
        Me.txtLookup.Size = New System.Drawing.Size(74, 20)
        Me.txtLookup.TabIndex = 5
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(186, 351)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(99, 354)
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.Size = New System.Drawing.Size(74, 20)
        Me.txtOutput.TabIndex = 7
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(186, 251)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 8
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'chkParents
        '
        Me.chkParents.AutoSize = True
        Me.chkParents.Location = New System.Drawing.Point(186, 307)
        Me.chkParents.Name = "chkParents"
        Me.chkParents.Size = New System.Drawing.Size(63, 17)
        Me.chkParents.TabIndex = 9
        Me.chkParents.Text = "Parent?"
        Me.chkParents.UseVisualStyleBackColor = True
        '
        'chkChilds
        '
        Me.chkChilds.AutoSize = True
        Me.chkChilds.Location = New System.Drawing.Point(186, 331)
        Me.chkChilds.Name = "chkChilds"
        Me.chkChilds.Size = New System.Drawing.Size(55, 17)
        Me.chkChilds.TabIndex = 10
        Me.chkChilds.Text = "Child?"
        Me.chkChilds.UseVisualStyleBackColor = True
        '
        'btnRootNode
        '
        Me.btnRootNode.Location = New System.Drawing.Point(12, 280)
        Me.btnRootNode.Name = "btnRootNode"
        Me.btnRootNode.Size = New System.Drawing.Size(75, 23)
        Me.btnRootNode.TabIndex = 11
        Me.btnRootNode.Text = "Add Root Node"
        Me.btnRootNode.UseVisualStyleBackColor = True
        '
        'btnReport
        '
        Me.btnReport.Location = New System.Drawing.Point(99, 280)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(75, 23)
        Me.btnReport.TabIndex = 12
        Me.btnReport.Text = "Report"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'chkUseExistingDB
        '
        Me.chkUseExistingDB.AutoSize = True
        Me.chkUseExistingDB.Location = New System.Drawing.Point(186, 284)
        Me.chkUseExistingDB.Name = "chkUseExistingDB"
        Me.chkUseExistingDB.Size = New System.Drawing.Size(68, 17)
        Me.chkUseExistingDB.TabIndex = 13
        Me.chkUseExistingDB.Text = "Existing?"
        Me.chkUseExistingDB.UseVisualStyleBackColor = True
        '
        'btnLoadDirTree
        '
        Me.btnLoadDirTree.Location = New System.Drawing.Point(12, 380)
        Me.btnLoadDirTree.Name = "btnLoadDirTree"
        Me.btnLoadDirTree.Size = New System.Drawing.Size(161, 23)
        Me.btnLoadDirTree.TabIndex = 14
        Me.btnLoadDirTree.Text = "Load Directory Tree"
        Me.btnLoadDirTree.UseVisualStyleBackColor = True
        '
        'chkSubTree
        '
        Me.chkSubTree.AutoSize = True
        Me.chkSubTree.Location = New System.Drawing.Point(186, 384)
        Me.chkSubTree.Name = "chkSubTree"
        Me.chkSubTree.Size = New System.Drawing.Size(54, 17)
        Me.chkSubTree.TabIndex = 15
        Me.chkSubTree.Text = "Add ?"
        Me.chkSubTree.UseVisualStyleBackColor = True
        '
        'statusStrip
        '
        Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.statusStrip.Location = New System.Drawing.Point(0, 439)
        Me.statusStrip.Name = "statusStrip"
        Me.statusStrip.Size = New System.Drawing.Size(632, 22)
        Me.statusStrip.TabIndex = 16
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(617, 17)
        Me.lblStatus.Spring = True
        Me.lblStatus.Text = "Status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(12, 409)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(75, 23)
        Me.btnCopy.TabIndex = 17
        Me.btnCopy.Text = "Copy"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'btnMove
        '
        Me.btnMove.Location = New System.Drawing.Point(99, 409)
        Me.btnMove.Name = "btnMove"
        Me.btnMove.Size = New System.Drawing.Size(75, 23)
        Me.btnMove.TabIndex = 18
        Me.btnMove.Text = "Move"
        Me.btnMove.UseVisualStyleBackColor = True
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(186, 409)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(75, 23)
        Me.btnCreate.TabIndex = 19
        Me.btnCreate.Text = "Create"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'btnSetDebitAccount
        '
        Me.btnSetDebitAccount.Location = New System.Drawing.Point(284, 12)
        Me.btnSetDebitAccount.Name = "btnSetDebitAccount"
        Me.btnSetDebitAccount.Size = New System.Drawing.Size(86, 23)
        Me.btnSetDebitAccount.TabIndex = 20
        Me.btnSetDebitAccount.Text = "Debit Account"
        Me.btnSetDebitAccount.UseVisualStyleBackColor = True
        '
        'btnSetCreditAccount
        '
        Me.btnSetCreditAccount.Location = New System.Drawing.Point(284, 64)
        Me.btnSetCreditAccount.Name = "btnSetCreditAccount"
        Me.btnSetCreditAccount.Size = New System.Drawing.Size(86, 23)
        Me.btnSetCreditAccount.TabIndex = 21
        Me.btnSetCreditAccount.Text = "Credit Account"
        Me.btnSetCreditAccount.UseVisualStyleBackColor = True
        '
        'lblDebitAccount
        '
        Me.lblDebitAccount.AutoSize = True
        Me.lblDebitAccount.Location = New System.Drawing.Point(285, 38)
        Me.lblDebitAccount.Name = "lblDebitAccount"
        Me.lblDebitAccount.Size = New System.Drawing.Size(106, 13)
        Me.lblDebitAccount.TabIndex = 22
        Me.lblDebitAccount.Text = "No account selected"
        '
        'lblCreditAccount
        '
        Me.lblCreditAccount.AutoSize = True
        Me.lblCreditAccount.Location = New System.Drawing.Point(285, 90)
        Me.lblCreditAccount.Name = "lblCreditAccount"
        Me.lblCreditAccount.Size = New System.Drawing.Size(106, 13)
        Me.lblCreditAccount.TabIndex = 23
        Me.lblCreditAccount.Text = "No account selected"
        '
        'txtDebitAccount
        '
        Me.txtDebitAccount.Location = New System.Drawing.Point(376, 14)
        Me.txtDebitAccount.Name = "txtDebitAccount"
        Me.txtDebitAccount.ReadOnly = True
        Me.txtDebitAccount.Size = New System.Drawing.Size(244, 20)
        Me.txtDebitAccount.TabIndex = 24
        '
        'txtCreditAccount
        '
        Me.txtCreditAccount.Location = New System.Drawing.Point(376, 66)
        Me.txtCreditAccount.Name = "txtCreditAccount"
        Me.txtCreditAccount.ReadOnly = True
        Me.txtCreditAccount.Size = New System.Drawing.Size(244, 20)
        Me.txtCreditAccount.TabIndex = 25
        '
        'btnSaveData
        '
        Me.btnSaveData.Location = New System.Drawing.Point(544, 107)
        Me.btnSaveData.Name = "btnSaveData"
        Me.btnSaveData.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveData.TabIndex = 26
        Me.btnSaveData.Text = "Save Entry"
        Me.btnSaveData.UseVisualStyleBackColor = True
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(464, 109)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(74, 20)
        Me.txtAmount.TabIndex = 27
        '
        'DGVEntries
        '
        Me.DGVEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVEntries.Location = New System.Drawing.Point(288, 138)
        Me.DGVEntries.Name = "DGVEntries"
        Me.DGVEntries.Size = New System.Drawing.Size(332, 294)
        Me.DGVEntries.TabIndex = 29
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 461)
        Me.Controls.Add(Me.DGVEntries)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.btnSaveData)
        Me.Controls.Add(Me.txtCreditAccount)
        Me.Controls.Add(Me.txtDebitAccount)
        Me.Controls.Add(Me.lblCreditAccount)
        Me.Controls.Add(Me.lblDebitAccount)
        Me.Controls.Add(Me.btnSetCreditAccount)
        Me.Controls.Add(Me.btnSetDebitAccount)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.btnMove)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.statusStrip)
        Me.Controls.Add(Me.chkSubTree)
        Me.Controls.Add(Me.btnLoadDirTree)
        Me.Controls.Add(Me.chkUseExistingDB)
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.btnRootNode)
        Me.Controls.Add(Me.chkChilds)
        Me.Controls.Add(Me.chkParents)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtLookup)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.TreeView1)
        Me.MaximizeBox = False
        Me.Name = "frmMenu"
        Me.Text = "Menu"
        Me.statusStrip.ResumeLayout(False)
        Me.statusStrip.PerformLayout()
        CType(Me.DGVEntries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnLoad As Button
    Friend WithEvents txtLookup As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtOutput As TextBox
    Friend WithEvents btnEdit As Button
    Friend WithEvents chkParents As CheckBox
    Friend WithEvents chkChilds As CheckBox
    Friend WithEvents btnRootNode As Button
    Friend WithEvents btnReport As Button
    Friend WithEvents chkUseExistingDB As CheckBox
    Friend WithEvents btnLoadDirTree As Button
    Friend WithEvents chkSubTree As CheckBox
    Friend WithEvents imgFolderFile As ImageList
    Friend WithEvents statusStrip As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents btnCopy As Button
    Friend WithEvents btnMove As Button
    Friend WithEvents btnCreate As Button
    Friend WithEvents btnSetDebitAccount As Button
    Friend WithEvents btnSetCreditAccount As Button
    Friend WithEvents lblDebitAccount As Label
    Friend WithEvents lblCreditAccount As Label
    Friend WithEvents txtDebitAccount As TextBox
    Friend WithEvents txtCreditAccount As TextBox
    Friend WithEvents btnSaveData As Button
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents DGVEntries As DataGridView
End Class
