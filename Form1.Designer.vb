<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.grpBoxGauge1 = New System.Windows.Forms.GroupBox()
        Me.txtBoxGauge1Label = New System.Windows.Forms.TextBox()
        Me.lblGauge1Label = New System.Windows.Forms.Label()
        Me.cmbBoxGauge1 = New System.Windows.Forms.ComboBox()
        Me.lblGauge1 = New System.Windows.Forms.Label()
        Me.lblGauge1Sensor = New System.Windows.Forms.Label()
        Me.btnControlServer = New System.Windows.Forms.Button()
        Me.updateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.grpBoxGauge2 = New System.Windows.Forms.GroupBox()
        Me.txtBoxGauge2Label = New System.Windows.Forms.TextBox()
        Me.lblGauge2Label = New System.Windows.Forms.Label()
        Me.cmbBoxGauge2 = New System.Windows.Forms.ComboBox()
        Me.lblGauge2 = New System.Windows.Forms.Label()
        Me.lblGauge2Sensor = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetGaugeHostnameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestHostnameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.statStrip = New System.Windows.Forms.StatusStrip()
        Me.statLabelHost = New System.Windows.Forms.ToolStripStatusLabel()
        Me.grpBoxGauge1.SuspendLayout()
        Me.grpBoxGauge2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.statStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpBoxGauge1
        '
        Me.grpBoxGauge1.Controls.Add(Me.txtBoxGauge1Label)
        Me.grpBoxGauge1.Controls.Add(Me.lblGauge1Label)
        Me.grpBoxGauge1.Controls.Add(Me.cmbBoxGauge1)
        Me.grpBoxGauge1.Controls.Add(Me.lblGauge1)
        Me.grpBoxGauge1.Controls.Add(Me.lblGauge1Sensor)
        Me.grpBoxGauge1.Location = New System.Drawing.Point(12, 28)
        Me.grpBoxGauge1.Name = "grpBoxGauge1"
        Me.grpBoxGauge1.Size = New System.Drawing.Size(191, 185)
        Me.grpBoxGauge1.TabIndex = 0
        Me.grpBoxGauge1.TabStop = False
        Me.grpBoxGauge1.Text = "Gauge 1:"
        '
        'txtBoxGauge1Label
        '
        Me.txtBoxGauge1Label.Location = New System.Drawing.Point(6, 115)
        Me.txtBoxGauge1Label.Name = "txtBoxGauge1Label"
        Me.txtBoxGauge1Label.Size = New System.Drawing.Size(177, 20)
        Me.txtBoxGauge1Label.TabIndex = 1
        Me.txtBoxGauge1Label.Text = "Gauge 1"
        '
        'lblGauge1Label
        '
        Me.lblGauge1Label.AutoSize = True
        Me.lblGauge1Label.Location = New System.Drawing.Point(6, 99)
        Me.lblGauge1Label.Name = "lblGauge1Label"
        Me.lblGauge1Label.Size = New System.Drawing.Size(80, 13)
        Me.lblGauge1Label.TabIndex = 3
        Me.lblGauge1Label.Text = "Gauge 1 Label:"
        '
        'cmbBoxGauge1
        '
        Me.cmbBoxGauge1.FormattingEnabled = True
        Me.cmbBoxGauge1.Location = New System.Drawing.Point(6, 158)
        Me.cmbBoxGauge1.Name = "cmbBoxGauge1"
        Me.cmbBoxGauge1.Size = New System.Drawing.Size(177, 21)
        Me.cmbBoxGauge1.TabIndex = 3
        '
        'lblGauge1
        '
        Me.lblGauge1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblGauge1.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGauge1.Location = New System.Drawing.Point(8, 19)
        Me.lblGauge1.Name = "lblGauge1"
        Me.lblGauge1.Size = New System.Drawing.Size(175, 73)
        Me.lblGauge1.TabIndex = 1
        Me.lblGauge1.Text = "50"
        Me.lblGauge1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGauge1Sensor
        '
        Me.lblGauge1Sensor.AutoSize = True
        Me.lblGauge1Sensor.Location = New System.Drawing.Point(6, 142)
        Me.lblGauge1Sensor.Name = "lblGauge1Sensor"
        Me.lblGauge1Sensor.Size = New System.Drawing.Size(76, 13)
        Me.lblGauge1Sensor.TabIndex = 1
        Me.lblGauge1Sensor.Text = "Select Sensor:"
        '
        'btnControlServer
        '
        Me.btnControlServer.Enabled = False
        Me.btnControlServer.Location = New System.Drawing.Point(12, 215)
        Me.btnControlServer.Name = "btnControlServer"
        Me.btnControlServer.Size = New System.Drawing.Size(388, 34)
        Me.btnControlServer.TabIndex = 5
        Me.btnControlServer.Text = "Start Temp Server"
        Me.btnControlServer.UseVisualStyleBackColor = True
        '
        'updateTimer
        '
        '
        'grpBoxGauge2
        '
        Me.grpBoxGauge2.Controls.Add(Me.txtBoxGauge2Label)
        Me.grpBoxGauge2.Controls.Add(Me.lblGauge2Label)
        Me.grpBoxGauge2.Controls.Add(Me.cmbBoxGauge2)
        Me.grpBoxGauge2.Controls.Add(Me.lblGauge2)
        Me.grpBoxGauge2.Controls.Add(Me.lblGauge2Sensor)
        Me.grpBoxGauge2.Location = New System.Drawing.Point(209, 28)
        Me.grpBoxGauge2.Name = "grpBoxGauge2"
        Me.grpBoxGauge2.Size = New System.Drawing.Size(191, 185)
        Me.grpBoxGauge2.TabIndex = 5
        Me.grpBoxGauge2.TabStop = False
        Me.grpBoxGauge2.Text = "Gauge 2:"
        '
        'txtBoxGauge2Label
        '
        Me.txtBoxGauge2Label.Location = New System.Drawing.Point(6, 115)
        Me.txtBoxGauge2Label.Name = "txtBoxGauge2Label"
        Me.txtBoxGauge2Label.Size = New System.Drawing.Size(177, 20)
        Me.txtBoxGauge2Label.TabIndex = 2
        Me.txtBoxGauge2Label.Text = "Gauge 2"
        '
        'lblGauge2Label
        '
        Me.lblGauge2Label.AutoSize = True
        Me.lblGauge2Label.Location = New System.Drawing.Point(6, 99)
        Me.lblGauge2Label.Name = "lblGauge2Label"
        Me.lblGauge2Label.Size = New System.Drawing.Size(80, 13)
        Me.lblGauge2Label.TabIndex = 3
        Me.lblGauge2Label.Text = "Gauge 1 Label:"
        '
        'cmbBoxGauge2
        '
        Me.cmbBoxGauge2.FormattingEnabled = True
        Me.cmbBoxGauge2.Location = New System.Drawing.Point(6, 158)
        Me.cmbBoxGauge2.Name = "cmbBoxGauge2"
        Me.cmbBoxGauge2.Size = New System.Drawing.Size(177, 21)
        Me.cmbBoxGauge2.TabIndex = 4
        '
        'lblGauge2
        '
        Me.lblGauge2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblGauge2.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGauge2.Location = New System.Drawing.Point(8, 19)
        Me.lblGauge2.Name = "lblGauge2"
        Me.lblGauge2.Size = New System.Drawing.Size(175, 73)
        Me.lblGauge2.TabIndex = 1
        Me.lblGauge2.Text = "50"
        Me.lblGauge2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGauge2Sensor
        '
        Me.lblGauge2Sensor.AutoSize = True
        Me.lblGauge2Sensor.Location = New System.Drawing.Point(6, 142)
        Me.lblGauge2Sensor.Name = "lblGauge2Sensor"
        Me.lblGauge2Sensor.Size = New System.Drawing.Size(76, 13)
        Me.lblGauge2Sensor.TabIndex = 1
        Me.lblGauge2Sensor.Text = "Select Sensor:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(409, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetGaugeHostnameToolStripMenuItem, Me.TestHostnameToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SetGaugeHostnameToolStripMenuItem
        '
        Me.SetGaugeHostnameToolStripMenuItem.Name = "SetGaugeHostnameToolStripMenuItem"
        Me.SetGaugeHostnameToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.SetGaugeHostnameToolStripMenuItem.Text = "Set Gauge Hostname"
        '
        'TestHostnameToolStripMenuItem
        '
        Me.TestHostnameToolStripMenuItem.Name = "TestHostnameToolStripMenuItem"
        Me.TestHostnameToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.TestHostnameToolStripMenuItem.Text = "Test Hostname Resolution"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'statStrip
        '
        Me.statStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statLabelHost})
        Me.statStrip.Location = New System.Drawing.Point(0, 258)
        Me.statStrip.Name = "statStrip"
        Me.statStrip.Size = New System.Drawing.Size(409, 22)
        Me.statStrip.TabIndex = 7
        Me.statStrip.Text = "StatusStrip1"
        '
        'statLabelHost
        '
        Me.statLabelHost.Name = "statLabelHost"
        Me.statLabelHost.Size = New System.Drawing.Size(35, 17)
        Me.statLabelHost.Text = "Host:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 280)
        Me.Controls.Add(Me.statStrip)
        Me.Controls.Add(Me.grpBoxGauge2)
        Me.Controls.Add(Me.btnControlServer)
        Me.Controls.Add(Me.grpBoxGauge1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MyGauge"
        Me.grpBoxGauge1.ResumeLayout(False)
        Me.grpBoxGauge1.PerformLayout()
        Me.grpBoxGauge2.ResumeLayout(False)
        Me.grpBoxGauge2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.statStrip.ResumeLayout(False)
        Me.statStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grpBoxGauge1 As GroupBox
    Friend WithEvents lblGauge1Sensor As Label
    Friend WithEvents lblGauge1 As Label
    Friend WithEvents btnControlServer As Button
    Friend WithEvents updateTimer As Timer
    Friend WithEvents cmbBoxGauge1 As ComboBox
    Friend WithEvents txtBoxGauge1Label As TextBox
    Friend WithEvents lblGauge1Label As Label
    Friend WithEvents grpBoxGauge2 As GroupBox
    Friend WithEvents txtBoxGauge2Label As TextBox
    Friend WithEvents lblGauge2Label As Label
    Friend WithEvents cmbBoxGauge2 As ComboBox
    Friend WithEvents lblGauge2 As Label
    Friend WithEvents lblGauge2Sensor As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetGaugeHostnameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TestHostnameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents statStrip As StatusStrip
    Friend WithEvents statLabelHost As ToolStripStatusLabel
End Class
