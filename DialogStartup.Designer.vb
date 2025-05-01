<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogStartup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogStartup))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.YES_Button = New System.Windows.Forms.Button()
        Me.NO_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.13462!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.86538!))
        Me.TableLayoutPanel1.Controls.Add(Me.YES_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.NO_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(197, 70)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(208, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'YES_Button
        '
        Me.YES_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.YES_Button.Location = New System.Drawing.Point(4, 3)
        Me.YES_Button.Name = "YES_Button"
        Me.YES_Button.Size = New System.Drawing.Size(114, 23)
        Me.YES_Button.TabIndex = 0
        Me.YES_Button.Text = "Yes, run as admin"
        '
        'NO_Button
        '
        Me.NO_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.NO_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.NO_Button.Location = New System.Drawing.Point(132, 3)
        Me.NO_Button.Name = "NO_Button"
        Me.NO_Button.Size = New System.Drawing.Size(67, 23)
        Me.NO_Button.TabIndex = 1
        Me.NO_Button.Text = "No, exit"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(395, 52)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'DialogStartup
        '
        Me.AcceptButton = Me.YES_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.CancelButton = Me.NO_Button
        Me.ClientSize = New System.Drawing.Size(417, 111)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogStartup"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Privilege Required"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents YES_Button As System.Windows.Forms.Button
    Friend WithEvents NO_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As Label
End Class
