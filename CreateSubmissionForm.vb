Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports Newtonsoft.Json

Public Class CreateSubmissionForm
    Private stopwatchRunning As Boolean = False
    Private stopwatchStartTime As DateTime
    Private stopwatchElapsedTime As TimeSpan = TimeSpan.Zero

    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Create a new submission object
        Dim newSubmission As New Submission(
            TextBox1.Text,
            TextBox2.Text,
            TextBox3.Text,
            TextBox4.Text,
            Label6.Text
        )

        ' Submit the form data to the backend
        Await SubmitForm(newSubmission)
    End Sub

    Private Async Function SubmitForm(submission As Submission) As Task
        Dim httpClient As New HttpClient()

        Try
            Dim json As String = JsonConvert.SerializeObject(submission)
            Dim content As New StringContent(json, Encoding.UTF8, "application/json")

            Dim response As HttpResponseMessage = Await httpClient.PostAsync("http://localhost:3000/submit", content)
            response.EnsureSuccessStatusCode()

            MessageBox.Show("Submission successful!")
        Catch ex As Exception
            MessageBox.Show("Error submitting form: " & ex.Message)
        End Try
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Toggle stopwatch
        If stopwatchRunning Then
            ' Pause the stopwatch
            stopwatchElapsedTime += DateTime.Now - stopwatchStartTime
            Timer1.Stop()
        Else
            ' Start or resume the stopwatch
            stopwatchStartTime = DateTime.Now
            Timer1.Start()
        End If

        stopwatchRunning = Not stopwatchRunning
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Update the stopwatch time display
        Dim elapsed As TimeSpan = stopwatchElapsedTime + (DateTime.Now - stopwatchStartTime)
        Label6.Text = elapsed.ToString("hh\:mm\:ss")
    End Sub

    Private Sub CreateSubmissionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize Timer control
        Timer1.Interval = 1000 ' 1 second
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        ' Handle shortcut keys
        If keyData = (Keys.Control Or Keys.T) Then
            Button1.PerformClick() ' Toggle stopwatch
            Return True
        ElseIf keyData = (Keys.Control Or Keys.S) Then
            Button2.PerformClick() ' Submit form
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function



End Class
