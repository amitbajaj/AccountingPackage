Public Class frmAddNode
    Dim bMode As Boolean
    Dim nNode As TreeNode
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If bMode Then
            frmMenu.SaveNode(txtName.Text, txtFormName.Text)
        Else
            nNode.Text = txtName.Text
            nNode.Name = txtFormName.Text
        End If
        Me.Close()
    End Sub

    Friend Sub initForm(ByVal bFormMode As Boolean, ByRef nTreeNode As TreeNode)
        bMode = bFormMode
        nNode = nTreeNode
    End Sub

    Private Sub frmAddNode_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bMode Then
            btnSave.Text = "Add Node"
        Else
            btnSave.Text = "Update Node"
            txtName.Text = nNode.Text
            txtFormName.Text = nNode.Name
        End If
    End Sub
End Class