Imports System.Net.Http
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class ViewSubmissionsForm
    Private submissions As List(Of Submission)
    Private currentIndex As Integer = 0
    Private httpClient As New HttpClient()

    Private Async Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load submissions from backend
        Await LoadSubmissions()
        ' Display the first submission by default
        If submissions IsNot Nothing AndAlso submissions.Count > 0 Then
            DisplaySubmission(submissions(currentIndex))
        End If
    End Sub

    Private Async Function LoadSubmissions() As Task
        Try
            Dim response As HttpResponseMessage = Await httpClient.GetAsync("http://localhost:3000/read")
            response.EnsureSuccessStatusCode()

            Dim jsonResponse As String = Await response.Content.ReadAsStringAsync()
            Dim submissionsArray As JArray = JArray.Parse(jsonResponse)

            submissions = submissionsArray.ToObject(Of List(Of Submission))()

        Catch ex As Exception
            MessageBox.Show("Error loading submissions: " & ex.Message)
        End Try
    End Function

    Private Sub DisplaySubmission(submission As Submission)
        TextBox1.Text = submission.Name
        TextBox2.Text = submission.Email
        TextBox3.Text = submission.PhoneNumber
        TextBox4.Text = submission.GitHubLink
        TextBox5.Text = submission.StopwatchTime
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Show previous submission
        If currentIndex > 0 Then
            currentIndex -= 1
            DisplaySubmission(submissions(currentIndex))
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Show next submission
        If currentIndex < submissions.Count - 1 Then
            currentIndex += 1
            DisplaySubmission(submissions(currentIndex))
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        ' Check for Ctrl + P shortcut
        If keyData = (Keys.Control Or Keys.P) Then
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

Public Class Submission
    Public Property Name As String
    Public Property Email As String
    Public Property PhoneNumber As String
    Public Property GitHubLink As String
    Public Property StopwatchTime As String

    Public Sub New(name As String, email As String, phoneNumber As String, gitHubLink As String, stopwatchTime As String)
        Me.Name = name
        Me.Email = email
        Me.PhoneNumber = phoneNumber
        Me.GitHubLink = gitHubLink
        Me.StopwatchTime = stopwatchTime
    End Sub
End Class
