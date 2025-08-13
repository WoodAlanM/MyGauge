Imports System.Collections.ObjectModel
Imports System.IO.Ports
Imports System.Management
Imports System
Imports OpenHardwareMonitor
Imports OpenHardwareMonitor.Hardware
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Diagnostics.Contracts
Imports System.Security.Cryptography
Imports System.IO
Imports System.Linq.Expressions
Imports System.CodeDom
Imports System.Runtime.InteropServices


Public Class Form1

    Public computer As New Computer()
    Public cpu As IHardware
    Public gpuAti As IHardware
    Public gpuNvidia As IHardware
    Public connected As Boolean
    Public gaugeOneSensor As String
    Public gaugeTwoSensor As String
    Public hostIP As String
    Public intermittentPing As Boolean

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        computer.Open()
        computer.CPUEnabled = True
        computer.GPUEnabled = True

        cpu = computer.Hardware.Where(Function(h) h.HardwareType = HardwareType.CPU).FirstOrDefault()

        ' Try to get gpu information if it is available
        Try
            gpuAti = computer.Hardware.Where(Function(h) h.HardwareType = HardwareType.GpuAti).FirstOrDefault()
        Catch ex As Exception
            ErrorLogger.LogError(ex)
        End Try

        Try
            gpuNvidia = computer.Hardware.Where(Function(h) h.HardwareType = HardwareType.GpuNvidia).FirstOrDefault()
        Catch ex As Exception
            ErrorLogger.LogError(ex)
        End Try

        ' Gets available sensors and populates combo boxes
        PopulateTemperatureSensors()

        ' Now checks available sensors against previously selected sensor on last form close
        ' For gauge 1
        If My.Settings.Gauge1Sensor <> "" Then
            For Each item In cmbBoxGauge1.Items
                If item.ToString() = My.Settings.Gauge1Sensor Then
                    cmbBoxGauge1.SelectedItem = item
                    Exit For
                End If
            Next
        End If

        ' For gauge 2
        If My.Settings.Gauge2Sensor <> "" Then
            For Each item In cmbBoxGauge2.Items
                If item.ToString() = My.Settings.Gauge2Sensor Then
                    cmbBoxGauge2.SelectedItem = item
                    Exit For
                End If
            Next
        End If

        ' Reset gauge labels to labels from previous run
        If My.Settings.Gauge1Label <> "" Then
            txtBoxGauge1Label.Text = My.Settings.Gauge1Label
        End If

        If My.Settings.Gauge2Label <> "" Then
            txtBoxGauge2Label.Text = My.Settings.Gauge2Label
        End If

        ' Check old ip against old hostname
        Dim oldHostname As String = My.Settings.HostName
        Dim hostnameIP As String = GetIPFromHostname(oldHostname)

        If hostnameIP = "noip" Or hostnameIP.StartsWith("Error") Or oldHostname = "" Then
            If oldHostname = "" Then
                MessageBox.Show("You have not set a host gauge. Please do so under File > Set Gauge Hostname.")
                statLabelHost.Text = "No host set. Set host at File > Set Gauge Hostname."
            End If
            If oldHostname <> "" Then
                MessageBox.Show("The previously used hostname does not have an associated IP address. Please ensure the host is online and connected to the network.")
                statLabelHost.Text = "Host: (" + oldHostname + ") UNAVAILABLE."
            End If
        Else
            ' if ip is different change it
            If hostnameIP <> My.Settings.IPAddress Then
                My.Settings.IPAddress = hostnameIP
                My.Settings.Save()
            End If

            ' Show host availability
            statLabelHost.Text = "Host: (" + oldHostname + ") available at: " + hostnameIP
            hostIP = hostnameIP
            btnControlServer.Enabled = True
            intermittentPing = True
        End If

        updateTimer.Interval = 2000
        updateTimer.Start()

        connected = False
    End Sub

    Private Sub PopulateTemperatureSensors()
        cmbBoxGauge1.Items.Clear()
        cmbBoxGauge2.Items.Clear()

        If cpu IsNot Nothing Then
            cpu.Update()

            If gpuAti IsNot Nothing Then
                gpuAti.Update()
                For Each sensor In gpuAti.Sensors
                    If sensor.SensorType = SensorType.Temperature Then
                        cmbBoxGauge1.Items.Add(sensor.Name)
                        cmbBoxGauge2.Items.Add(sensor.Name)
                    End If
                Next
            End If

            If gpuNvidia IsNot Nothing Then
                gpuNvidia.Update()
                For Each sensor In gpuNvidia.Sensors
                    If sensor.SensorType = SensorType.Temperature Then
                        cmbBoxGauge1.Items.Add(sensor.Name)
                        cmbBoxGauge2.Items.Add(sensor.Name)
                    End If
                Next
            End If

            For Each sensor In cpu.Sensors
                If sensor.SensorType = SensorType.Temperature Then
                    cmbBoxGauge1.Items.Add(sensor.Name)
                    cmbBoxGauge2.Items.Add(sensor.Name)
                End If
            Next
        End If

        If cmbBoxGauge1.Items.Count > 0 Then
            cmbBoxGauge1.SelectedIndex = 0
            gaugeOneSensor = cmbBoxGauge1.Text
        End If

        If cmbBoxGauge2.Items.Count > 0 Then
            cmbBoxGauge2.SelectedIndex = 0
            gaugeTwoSensor = cmbBoxGauge2.Text
        End If
    End Sub

    Private Sub UpdateGaugeOne()
        If gaugeOneSensor.StartsWith("GPU") Then
            If gpuAti IsNot Nothing Then
                gpuAti.Update()
                Dim gpuTempSensors = gpuAti.Sensors.Where(Function(s) s.SensorType = SensorType.Temperature).ToList()
                If gpuTempSensors.Count > 0 Then
                    For i As Integer = 0 To gpuTempSensors.Count - 1
                        If gpuTempSensors(i).Name = gaugeOneSensor Then
                            lblGauge1.Text = gpuTempSensors(i).Value
                        End If
                    Next
                End If
            Else
                MessageBox.Show("Unexpected error occurred.")
            End If

            If gpuNvidia IsNot Nothing Then
                gpuNvidia.Update()
                Dim gpuTempSensors = gpuAti.Sensors.Where(Function(s) s.SensorType = SensorType.Temperature).ToList()
                If gpuTempSensors.Count > 0 Then
                    For i As Integer = 0 To gpuTempSensors.Count - 1
                        If gpuTempSensors(i).Name = gaugeOneSensor Then
                            lblGauge1.Text = gpuTempSensors(i).Value
                        End If
                    Next
                Else
                    MessageBox.Show("Unexpected error occurred.")
                End If
            End If
        End If

        If gaugeOneSensor.StartsWith("CPU") Then
            If cpu IsNot Nothing Then
                cpu.Update()

                Dim cpuTempSensors = cpu.Sensors.Where(Function(s) s.SensorType = SensorType.Temperature).ToList()

                If cpuTempSensors.Count > 0 Then
                    For i As Integer = 0 To cpuTempSensors.Count - 1
                        If cpuTempSensors(i).Name = gaugeOneSensor Then
                            lblGauge1.Text = cpuTempSensors(i).Value
                        End If
                    Next
                End If
            Else
                MessageBox.Show("Unexpected error occurred.")
            End If
        End If
    End Sub

    Private Sub UpdateGaugeTwo()
        If gaugeTwoSensor.StartsWith("GPU") Then
            If gpuAti IsNot Nothing Then
                gpuAti.Update()
                Dim gpuTempSensors = gpuAti.Sensors.Where(Function(s) s.SensorType = SensorType.Temperature).ToList()
                If gpuTempSensors.Count > 0 Then
                    For i As Integer = 0 To gpuTempSensors.Count - 1
                        If gpuTempSensors(i).Name = gaugeTwoSensor Then
                            lblGauge2.Text = gpuTempSensors(i).Value
                        End If
                    Next
                End If
            End If

            If gpuNvidia IsNot Nothing Then
                gpuNvidia.Update()
                Dim gpuTempSensors = gpuNvidia.Sensors.Where(Function(s) s.SensorType = SensorType.Temperature).ToList()
                If gpuTempSensors.Count > 0 Then
                    For i As Integer = 0 To gpuTempSensors.Count - 1
                        If gpuTempSensors(i).Name = gaugeTwoSensor Then
                            lblGauge2.Text = gpuTempSensors(i).Value
                        End If
                    Next
                End If
            End If
        End If

        If gaugeTwoSensor.StartsWith("CPU") Then
            If cpu IsNot Nothing Then
                cpu.Update()

                Dim cpuTempSensors = cpu.Sensors.Where(Function(s) s.SensorType = SensorType.Temperature).ToList()

                If cpuTempSensors.Count > 0 Then
                    For i As Integer = 0 To cpuTempSensors.Count - 1
                        If cpuTempSensors(i).Name = gaugeTwoSensor Then
                            lblGauge2.Text = cpuTempSensors(i).Value
                        End If
                    Next
                End If
            Else
                MessageBox.Show("Unexpected error occurred.")
            End If
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Dim changes As Boolean = False

        My.Settings.Gauge1Label = txtBoxGauge1Label.Text
        My.Settings.Gauge2Label = txtBoxGauge2Label.Text
        My.Settings.Gauge1Sensor = cmbBoxGauge1.Text
        My.Settings.Gauge2Sensor = cmbBoxGauge2.Text

        ' If any of the settings have changed update them
        If My.Settings.Gauge1Label <> txtBoxGauge1Label.Text Then
            changes = True
            My.Settings.Gauge1Label = txtBoxGauge1Label.Text
        End If

        If My.Settings.Gauge2Label <> txtBoxGauge2Label.Text Then
            changes = True
            My.Settings.Gauge2Label = txtBoxGauge2Label.Text
        End If

        If My.Settings.Gauge1Sensor <> cmbBoxGauge1.Text Then
            changes = True
            My.Settings.Gauge1Sensor = cmbBoxGauge1.Text
        End If

        If My.Settings.Gauge2Sensor <> cmbBoxGauge2.Text Then
            changes = True
            My.Settings.Gauge2Sensor = cmbBoxGauge2.Text
        End If

        ' If changes occured, save the changes
        If changes Then
            My.Settings.Save()
        End If

    End Sub

    Private Sub SendDataViaUDP(sender As Object, e As EventArgs)
        Dim gauge1 As String = lblGauge1.Text
        Dim gauge2 As String = lblGauge2.Text

        Dim message = txtBoxGauge1Label.Text + ":" + gauge1 + "," + txtBoxGauge2Label.Text + ":" + gauge2

        Dim udpClient As New UdpClient()
        Try
            Dim remoteEP As New IPEndPoint(IPAddress.Parse(hostIP), 12345) ' <-- Replace with your Pi's IP

            Dim data As Byte() = Encoding.UTF8.GetBytes(message)
            udpClient.Send(data, data.Length, remoteEP)
            udpClient.Close()
        Catch ex As Exception
            ErrorLogger.LogError(ex)
        End Try
    End Sub

    Private Sub btnControlServer_Click(sender As Object, e As EventArgs) Handles btnControlServer.Click
        If connected Then
            RemoveHandler updateTimer.Tick, AddressOf SendDataViaUDP
            btnControlServer.Text = "Start Temp Server"
            intermittentPing = True
            connected = False
        Else
            connected = True
            intermittentPing = False
            btnControlServer.Text = "Disconnect"
            AddHandler updateTimer.Tick, AddressOf SendDataViaUDP
        End If
    End Sub

    Private Function PingHost(hostname As String) As Boolean
        Dim pingIP As String = GetIPFromHostname(hostname)

        If pingIP <> "" And pingIP <> "noip" And Not pingIP.StartsWith("Error") Then
            Return True
        Else
            intermittentPing = False
            Return False
        End If
    End Function

    Private Sub updateTimer_Tick(sender As Object, e As EventArgs) Handles updateTimer.Tick
        UpdateGaugeOne()
        UpdateGaugeTwo()

        If intermittentPing Then
            If Not PingHost(My.Settings.HostName) Then
                MessageBox.Show("The host has become unavailable. Please ensure the host is powered on and connected to the network.")
                statLabelHost.Text = "Host: (" + My.Settings.HostName + ") UNAVAILABLE."
                btnControlServer.Enabled = False
            End If
        End If

    End Sub

    Private Sub cmbBoxGauge1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBoxGauge1.SelectedIndexChanged
        gaugeOneSensor = cmbBoxGauge1.Text
        My.Settings.Save()
    End Sub

    Private Sub cmbBoxGauge2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBoxGauge2.SelectedIndexChanged
        gaugeTwoSensor = cmbBoxGauge2.Text
        My.Settings.Save()
    End Sub

    Public Function GetIPFromHostname(hostname As String) As String
        Try
            Dim hostEntry As IPHostEntry = Dns.GetHostEntry(hostname)
            For Each ip As IPAddress In hostEntry.AddressList
                If ip.AddressFamily = Sockets.AddressFamily.InterNetwork Then
                    Return ip.ToString()
                End If
            Next
            Return "noip"
        Catch ex As Exception
            Return "Error: " & ex.Message
            ErrorLogger.LogError(ex)
        End Try
    End Function

    Private Sub SetGaugeHostnameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetGaugeHostnameToolStripMenuItem.Click
        Dim gaugeHostName As String
        Dim previousHostName As String = My.Settings.HostName
        Dim gaugeIP As String

        ' Collect new hostname
        If previousHostName <> "" Then
            gaugeHostName = InputBox("Enter the hostname for your gauge(s): ", "Hostname Prompt", previousHostName)
        Else
            gaugeHostName = InputBox("Enter the hostname for your gauge(s): ", "Hostname Prompt", "Gauge Hostname")
        End If

        ' If the hostname is not nothing
        If gaugeHostName <> "" Then
            ' If hostname is the same as the old hostname
            If gaugeHostName = previousHostName Then
                ' Check if the old ip is the same
                gaugeIP = GetIPFromHostname(gaugeHostName)
                If gaugeIP = "noip" Then
                    MessageBox.Show("The hostname you entered does not have an associated IP address.")
                ElseIf gaugeIP.StartsWith("Error") Then
                    MessageBox.Show("The hostname you entered does not have an associated IP address.")
                Else
                    If gaugeIP <> My.Settings.IPAddress Then
                        My.Settings.IPAddress = gaugeIP
                        My.Settings.Save()
                    End If
                End If
            Else
                ' If not the same change hostname
                My.Settings.HostName = gaugeHostName.ToLower()
                ' Get new ip from new hostname
                gaugeIP = GetIPFromHostname(gaugeHostName)
                If gaugeIP = "noip" Then
                    MessageBox.Show("The hostname you entered does not have an associated IP address.")
                ElseIf gaugeIP.StartsWith("Error") Then
                    MessageBox.Show("The hostname you entered does not have an associated IP address.")
                Else
                    ' Set new ip
                    MessageBox.Show("The entered hostname resolves to the IP (" + gaugeIP + ").")
                    My.Settings.IPAddress = gaugeIP
                    My.Settings.HostName = gaugeHostName
                    My.Settings.Save()
                    statLabelHost.Text = "Host: (" + gaugeHostName + ") available at: " + gaugeIP
                    intermittentPing = True
                    btnControlServer.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub TestHostnameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestHostnameToolStripMenuItem.Click
        Dim oldHostname As String = My.Settings.HostName
        Dim oldIPAddress As String = My.Settings.IPAddress
        Dim currentIP As String = GetIPFromHostname(oldHostname)

        If oldHostname <> "" Then
            If oldIPAddress = currentIP And Not currentIP.StartsWith("Error") Then
                MessageBox.Show("The saved hostname resolves to the saved IP, and connection to the host is available.")
            Else
                MessageBox.Show("The saved hostname does not resolve to the saved IP. Please ensure the host is available and connected to the network.")
            End If
        Else
            MessageBox.Show("There is no saved hostname to test.")
        End If

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
