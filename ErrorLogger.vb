Imports System.IO

Public Class ErrorLogger
    ' Use the application's startup directory
    Private Shared logFilePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error_log.txt")

    Public Shared Sub LogError(ByVal ex As Exception)
        Try
            Using sw As StreamWriter = File.AppendText(logFilePath)
                sw.WriteLine("----- ERROR -----")
                sw.WriteLine("Date: " & DateTime.Now.ToString())
                sw.WriteLine("Message: " & ex.Message)
                sw.WriteLine("Source: " & ex.Source)
                sw.WriteLine("StackTrace: " & ex.StackTrace)
                sw.WriteLine()
            End Using
        Catch fileEx As Exception
        End Try
    End Sub
End Class
