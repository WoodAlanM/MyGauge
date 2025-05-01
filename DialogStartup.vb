Imports System.Windows.Forms

Public Class DialogStartup

    Private Sub YES_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YES_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub NO_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NO_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
