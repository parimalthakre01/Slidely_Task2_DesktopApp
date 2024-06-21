Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Additional initialization if necessary
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Open View Submissions Form
        Dim viewForm As New ViewSubmissionsForm()
        viewForm.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Open Create New Submission Form
        Dim createForm As New CreateSubmissionForm()
        createForm.Show()
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        ' Check for Ctrl + V shortcut
        If keyData = (Keys.Control Or Keys.V) Then
            Button1.PerformClick()
            Return True
        End If

        ' Check for Ctrl + N shortcut
        If keyData = (Keys.Control Or Keys.N) Then
            Button2.PerformClick()
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class
