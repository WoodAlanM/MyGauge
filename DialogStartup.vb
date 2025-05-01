Imports System.Windows.Forms
Imports System.Security.Principal
Imports System.Diagnostics

Public Class DialogStartup

    Public Function IsRunAsAdmin() As Boolean
        Dim wi As WindowsIdentity = WindowsIdentity.GetCurrent()
        Dim wp As WindowsPrincipal = New WindowsPrincipal(wi)
        Return wp.IsInRole(WindowsBuiltInRole.Administrator)
    End Function

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

    Private Sub DialogStartup_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsRunAsAdmin() Then
            Dim mainForm As New Form1()
            mainForm.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub YES_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YES_Button.Click
        RelaunchAsAdmin()
    End Sub

    Private Sub NO_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NO_Button.Click
        Application.Exit()
    End Sub
End Class
