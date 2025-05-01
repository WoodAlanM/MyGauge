Public Class DialogStartup
    Public Sub RelaunchAsAdmin()
        Dim proc As New ProcessStartInfo()
        proc.UseShellExecute = True
        proc.WorkingDirectory = Environment.CurrentDirectory
        proc.FileName = Application.ExecutablePath
        proc.Verb = "runas"

        Try
            Process.Start(proc)
        Catch ex As Exception
            MessageBox.Show("Failed to restart as administrator: " & ex.Message)
        End Try

        Application.Exit()
    End Sub

    Private Sub YES_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YES_Button.Click
        RelaunchAsAdmin()
    End Sub

    Private Sub NO_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NO_Button.Click
        Application.Exit()
    End Sub
End Class
