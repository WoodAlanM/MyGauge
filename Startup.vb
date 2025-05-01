Imports System.Security.Principal
Imports System.Windows.Forms

Module Startup
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        If IsRunAsAdmin() Then
            Application.Run(New Form1)
        Else
            Dim startupForm As New DialogStartup()
            Application.Run(startupForm)
        End If
    End Sub

    Private Function IsRunAsAdmin() As Boolean
        Dim wi = WindowsIdentity.GetCurrent()
        Dim wp = New WindowsPrincipal(wi)
        Return wp.IsInRole(WindowsBuiltInRole.Administrator)
    End Function
End Module
