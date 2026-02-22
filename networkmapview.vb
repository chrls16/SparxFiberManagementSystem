Imports GMap.NET
Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports MySqlConnector
Imports System.Configuration
Imports System.Drawing

Public Class networkmapview
    Inherits System.Windows.Forms.UserControl

    ' Map components
    Private mapControl As GMapControl
    Private markersOverlay As GMapOverlay
    Private connectionString As String = "Server=localhost;Database=sparx;User ID=root;Password=;"
    ' NAP management
    Private selectedNAPId As Integer = -1
    Private currentNapFormHost As Form
    Private currentNapForm As NapBoxShow

    ' Constants
    Private Const DAET_LAT As Double = 14.1167
    Private Const DAET_LNG As Double = 122.95

    Private Sub networkmapview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeMap()
        InitializeFilters()
        InitializeDataGridViewColumns()
        FormatDataGridView()
        LoadStatistics()
        LoadNAPData()
        LoadInfrastructureStatus()
        LoadCustomerNetworkMapping()
    End Sub

    Private Sub InitializeMap()
        If PanelRound1 Is Nothing Then Return

        mapControl = New GMapControl With {
            .Dock = DockStyle.Fill,
            .CanDragMap = True,
            .DragButton = MouseButtons.Left,
            .MinZoom = 2,
            .MaxZoom = 18,
            .Zoom = 13,
            .MapProvider = GMapProviders.OpenStreetMap,
            .ShowCenter = False
        }

        PanelRound1.Controls.Add(mapControl)
        GMaps.Instance.Mode = AccessMode.ServerAndCache
        mapControl.Position = New PointLatLng(DAET_LAT, DAET_LNG)

        markersOverlay = New GMapOverlay("markers")
        mapControl.Overlays.Add(markersOverlay)

        AddHandler mapControl.OnMarkerClick, AddressOf OnMarkerClick
        AddHandler mapControl.MouseDoubleClick, AddressOf Map_MouseDoubleClick

        ' Load NAP markers
        LoadNAPMarkers()
    End Sub

    Private Sub Map_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Dim point = mapControl.FromLocalToLatLng(e.X, e.Y)
            ShowAddNAPDialog(point.Lat, point.Lng)
        End If
    End Sub

    Private Sub ShowAddNAPDialog(lat As Double, lng As Double)
        Dim addNapControl As New Addnap()

        Using addNapForm As New Form() With {
            .Text = "Add New Network Access Point",
            .StartPosition = FormStartPosition.CenterScreen,
            .MinimizeBox = False,
            .MaximizeBox = False,
            .FormBorderStyle = FormBorderStyle.FixedDialog,
            .Size = New Size(500, 850),
            .AutoScroll = True
        }

            addNapControl.Dock = DockStyle.Fill
            addNapForm.Controls.Add(addNapControl)


            AddHandler addNapControl.CancelBtn.Click, Sub()
                                                          addNapForm.DialogResult = DialogResult.Cancel
                                                          addNapForm.Close()
                                                      End Sub

            AddHandler addNapControl.SaveBtn.Click, Sub()
                                                        SaveNewNAP(addNapControl, addNapForm)
                                                    End Sub

            addNapForm.ShowDialog()

            If addNapForm.DialogResult = DialogResult.OK Then
                LoadNAPData()
                LoadStatistics()
                LoadInfrastructureStatus()
                LoadCustomerNetworkMapping()
                LoadNAPMarkers()
            End If
        End Using
    End Sub

    Private Sub SaveNewNAP(addNapControl As Addnap, addNapForm As Form)
        Dim loc As PointLatLng = addNapControl.NAP_Location
        Dim areaName As String = addNapControl.TextBox1.Text.Trim()
        Dim napModel As String = addNapControl.TextBox2.Text.Trim()

        If String.IsNullOrEmpty(areaName) Or String.IsNullOrEmpty(napModel) Then
            MessageBox.Show("Please enter Area Name and NAP Model.", "Validation Error")
            Return
        End If

        If loc.Lat = 0 And loc.Lng = 0 Then
            MessageBox.Show("Please select a location.", "Validation Error")
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Dim insertNAP As String = "INSERT INTO nap (area_name, nap_model, latitude, longitude) 
                                      VALUES (@areaName, @napModel, @lat, @lng)"
                Using cmd As New MySqlCommand(insertNAP, conn)
                    cmd.Parameters.AddWithValue("@areaName", areaName)
                    cmd.Parameters.AddWithValue("@napModel", napModel)
                    cmd.Parameters.AddWithValue("@lat", loc.Lat)
                    cmd.Parameters.AddWithValue("@lng", loc.Lng)
                    cmd.ExecuteNonQuery()
                End Using

                Dim napId As Integer
                Using cmd As New MySqlCommand("SELECT LAST_INSERT_ID()", conn)
                    napId = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                For port As Integer = 1 To 8
                    Dim insertPort As String = "INSERT INTO nap_ports (nap_id, port_number, status) 
                                           VALUES (@napId, @port, 'Available')"
                    Using cmd As New MySqlCommand(insertPort, conn)
                        cmd.Parameters.AddWithValue("@napId", napId)
                        cmd.Parameters.AddWithValue("@port", port)
                        cmd.ExecuteNonQuery()
                    End Using
                Next

                AddMarker(loc.Lat, loc.Lng, $"NAP-{napId:000} - {areaName}", GMarkerGoogleType.green_dot)
                MessageBox.Show($"NAP added successfully with ID: {napId}", "Success")
                addNapForm.DialogResult = DialogResult.OK
                addNapForm.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saving NAP: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AddMarker(lat As Double, lng As Double, title As String, Optional markerType As GMarkerGoogleType = GMarkerGoogleType.green_dot)
        If markersOverlay Is Nothing Then Return

        Dim p = New PointLatLng(lat, lng)
        Dim marker = New GMarkerGoogle(p, markerType) With {
            .ToolTipText = title
        }
        markersOverlay.Markers.Add(marker)
        mapControl.Refresh()
    End Sub

    Private Sub OnMarkerClick(item As GMarkerGoogle, e As MouseEventArgs)
        Dim napInfo = item.ToolTipText
        If napInfo.Contains("NAP-") Then
            Dim napIdStr = napInfo.Split("-")(1).Split(" ")(0)
            Dim napId As Integer
            If Integer.TryParse(napIdStr, napId) Then
                ShowNAPDetailsForm(napId)
            End If
        End If
    End Sub

    Private Sub ShowNAPDetailsForm(napId As Integer)
        If currentNapFormHost IsNot Nothing AndAlso Not currentNapFormHost.IsDisposed Then
            currentNapFormHost.Close()
        End If

        currentNapForm = New NapBoxShow()
        currentNapForm.CurrentNAPId = napId

        currentNapFormHost = New Form() With {
            .Text = $"NAP-{napId:000} Details",
            .StartPosition = FormStartPosition.CenterScreen,
            .Size = New Size(500, 800),
            .FormBorderStyle = FormBorderStyle.FixedDialog,
            .MinimizeBox = False,
            .MaximizeBox = False
        }

        currentNapForm.Dock = DockStyle.Fill
        currentNapFormHost.Controls.Add(currentNapForm)

        AddHandler currentNapFormHost.FormClosed, Sub()
                                                      currentNapForm = Nothing
                                                      currentNapFormHost = Nothing
                                                  End Sub

        currentNapFormHost.Show()
    End Sub

    Private Sub LoadNAPMarkers()
        markersOverlay.Markers.Clear()

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT nap_id, area_name, latitude, longitude FROM nap WHERE status = 'Active'"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim napId As Integer = reader.GetInt32("nap_id")
                            Dim areaName As String = reader.GetString("area_name")
                            Dim lat As Double = Convert.ToDouble(reader("latitude"))
                            Dim lng As Double = Convert.ToDouble(reader("longitude"))

                            AddMarker(lat, lng, $"NAP-{napId:000} - {areaName}", GMarkerGoogleType.green_dot)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine($"Error loading NAP markers: {ex.Message}")
        End Try

        mapControl.Refresh()
    End Sub

    Private Sub InitializeFilters()
        cbDateRange.Items.Clear()
        cbDateRange.Items.Add("All Locations")
        cbDateRange.Items.Add("Daet")
        cbDateRange.Items.Add("Mercedes")
        cbDateRange.SelectedIndex = 0

        cbPosition.Items.Clear()
        cbPosition.Items.Add("All NAPs")
        LoadNAPFilterData()
        cbPosition.SelectedIndex = 0

        ComboBox3.Items.Clear()
        ComboBox3.Items.Add("All LCPs")
        ComboBox3.Items.Add("LCP-001")
        ComboBox3.Items.Add("LCP-002")
        ComboBox3.Items.Add("LCP-003")
        ComboBox3.SelectedIndex = 0
    End Sub

    Private Sub LoadNAPFilterData()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT DISTINCT area_name FROM nap ORDER BY area_name"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cbPosition.Items.Add(reader.GetString("area_name"))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            cbPosition.Items.AddRange({"Purok 9, Barangay IV, Daet", "Barangay I, Daet", "Mercedes Central"})
        End Try
    End Sub

    Private Sub cbDateRange_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDateRange.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub cbPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPosition.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub ApplyFilters()
        Dim locationFilter As String = If(cbDateRange.SelectedIndex > 0, cbDateRange.SelectedItem.ToString(), "")
        Dim napFilter As String = If(cbPosition.SelectedIndex > 0, cbPosition.SelectedItem.ToString(), "")
        Dim lcpFilter As String = If(ComboBox3.SelectedIndex > 0, ComboBox3.SelectedItem.ToString(), "")

        LoadFilteredStatistics(locationFilter, napFilter, lcpFilter)

        LoadFilteredCustomerMapping(locationFilter, napFilter, lcpFilter)

        LoadInfrastructureStatus()
    End Sub

    Private Sub LoadStatistics()
        LoadFilteredStatistics("", "", "")
    End Sub

    Private Sub LoadFilteredStatistics(locationFilter As String, napFilter As String, lcpFilter As String)
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Dim whereClause As String = "WHERE c.account_status = 'Active'"
                If Not String.IsNullOrEmpty(locationFilter) Then
                    whereClause += " AND c.installation_address LIKE @location"
                End If

                Dim query1 As String = $"SELECT COUNT(*) FROM customer c {whereClause}"
                Using cmd1 As New MySqlCommand(query1, conn)
                    If Not String.IsNullOrEmpty(locationFilter) Then
                        cmd1.Parameters.AddWithValue("@location", $"%{locationFilter}%")
                    End If
                    Dim totalCustomers As Integer = Convert.ToInt32(cmd1.ExecuteScalar())
                    TotalSales.Text = totalCustomers.ToString()
                End Using

                Dim query2 As String = "SELECT COUNT(DISTINCT nap_id) FROM nap WHERE status = 'Active'"
                If Not String.IsNullOrEmpty(napFilter) Then
                    query2 += " AND area_name = @napArea"
                End If

                Using cmd2 As New MySqlCommand(query2, conn)
                    If Not String.IsNullOrEmpty(napFilter) Then
                        cmd2.Parameters.AddWithValue("@napArea", napFilter)
                    End If
                    Dim activeNAPs As Integer = Convert.ToInt32(cmd2.ExecuteScalar())
                    MonthlyRev.Text = activeNAPs.ToString()
                End Using

                Dim query3 As String = "SELECT COUNT(*) FROM nap_ports np 
                                       INNER JOIN nap n ON np.nap_id = n.nap_id
                                       WHERE np.status IN ('Maintenance', 'Faulty', 'Degraded')"

                If Not String.IsNullOrEmpty(napFilter) Then
                    query3 += " AND n.area_name = @napArea"
                End If

                Using cmd3 As New MySqlCommand(query3, conn)
                    If Not String.IsNullOrEmpty(napFilter) Then
                        cmd3.Parameters.AddWithValue("@napArea", napFilter)
                    End If
                    Dim maintenanceCount As Integer = Convert.ToInt32(cmd3.ExecuteScalar())
                    AvgRev.Text = maintenanceCount.ToString()
                End Using

            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading statistics: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadInfrastructureStatus()
        ClearInfrastructurePanels()

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Dim query As String = "
                    SELECT 
                        n.nap_id,
                        n.area_name,
                        COUNT(np.port_id) as total_ports,
                        SUM(CASE WHEN np.status = 'Occupied' THEN 1 ELSE 0 END) as occupied_ports,
                        SUM(CASE WHEN np.status IN ('Maintenance', 'Faulty') THEN 1 ELSE 0 END) as faulty_ports,
                        n.latitude,
                        n.longitude
                    FROM nap n
                    LEFT JOIN nap_ports np ON n.nap_id = np.nap_id
                    WHERE n.status = 'Active'
                    GROUP BY n.nap_id, n.area_name, n.latitude, n.longitude
                    ORDER BY n.nap_id
                    LIMIT 3"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim panelIndex As Integer = 0
                        Dim panels As List(Of PanelRound) = New List(Of PanelRound) From {
                            OverduePanel, PanelRound2, PanelRound4
                        }

                        While reader.Read() AndAlso panelIndex < panels.Count
                            Dim napId As Integer = reader.GetInt32("nap_id")
                            Dim areaName As String = reader.GetString("area_name")
                            Dim totalPorts As Integer = reader.GetInt32("total_ports")
                            Dim occupiedPorts As Integer = reader.GetInt32("occupied_ports")
                            Dim faultyPorts As Integer = reader.GetInt32("faulty_ports")
                            Dim lat As Double = Convert.ToDouble(reader("latitude"))
                            Dim lng As Double = Convert.ToDouble(reader("longitude"))

                            Dim panel As PanelRound = panels(panelIndex)
                            UpdateNAPInfoPanel(panel, napId, areaName, occupiedPorts, totalPorts, faultyPorts, lat, lng)
                            panelIndex += 1
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading infrastructure status: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearInfrastructurePanels()
        ClearNAPInfoPanel(OverduePanel)
        ClearNAPInfoPanel(PanelRound2)
        ClearNAPInfoPanel(PanelRound4)
    End Sub

    Private Sub ClearNAPInfoPanel(panel As PanelRound)
        For Each ctrl As Control In panel.Controls
            If TypeOf ctrl Is Label Then
                Dim lbl As Label = CType(ctrl, Label)
                If lbl.Name.StartsWith("Label") Or lbl.Name.Contains("Lbl") Then
                    lbl.Text = ""
                End If
            End If
        Next

        Dim statusPanels As List(Of Control) = New List(Of Control)
        For Each ctrl As Control In panel.Controls
            If TypeOf ctrl Is PanelRound Then
                statusPanels.Add(ctrl)
            End If
        Next

        For Each statusPanel As Control In statusPanels
            panel.Controls.Remove(statusPanel)
            statusPanel.Dispose()
        Next
    End Sub

    Private Sub UpdateNAPInfoPanel(panel As PanelRound, napId As Integer, areaName As String,
                                   occupiedPorts As Integer, totalPorts As Integer,
                                   faultyPorts As Integer, lat As Double, lng As Double)
        For Each ctrl As Control In panel.Controls
            If TypeOf ctrl Is Label Then
                Dim lbl As Label = CType(ctrl, Label)

                If lbl.Text.Contains("NAP-") Or lbl.Name = "NameOfCustomerLbl" Or lbl.Name = "Label2" Or lbl.Name = "Label5" Then
                    lbl.Text = $"NAP-{napId:000}"
                End If

                If lbl.Name = "Label1" Or lbl.Name = "Label3" Or lbl.Name = "PlanAmountLbl" Then
                    lbl.Text = areaName
                End If

                If lbl.Name = "Label6" Or lbl.Name = "Label7" Or lbl.Name = "Label8" Then
                    lbl.Text = $"{occupiedPorts} Customers"
                End If

                If lbl.Name = "Label4" Or lbl.Text.Contains("Location:") Then
                    lbl.Text = $"Location: {lat:F4}, {lng:F4}"
                End If
            End If
        Next

        Dim statusPanel As PanelRound = Nothing
        For Each ctrl As Control In panel.Controls
            If TypeOf ctrl Is PanelRound AndAlso (ctrl.Name = "PanelRound3" Or ctrl.Name = "PanelRound5" Or ctrl.Name = "PanelRound6") Then
                statusPanel = CType(ctrl, PanelRound)
                Exit For
            End If
        Next

        If statusPanel Is Nothing Then
            statusPanel = New PanelRound()
            statusPanel.Size = New Size(102, 35)
            statusPanel.CornerRadius = 50
            statusPanel.Location = New Point(panel.Width - 122, 27)
            panel.Controls.Add(statusPanel)

            Dim statusLabel As New Label()
            statusLabel.AutoSize = True
            statusLabel.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            statusLabel.ForeColor = Color.FromArgb(64, 64, 64)
            statusLabel.Location = New Point(30, 10)
            statusPanel.Controls.Add(statusLabel)
        End If
        If faultyPorts > 0 Then
            statusPanel.BackColor = Color.LightCoral
            statusPanel.Controls(0).Text = "Faulty"
        ElseIf occupiedPorts = totalPorts Then
            statusPanel.BackColor = Color.LightGoldenrodYellow
            statusPanel.Controls(0).Text = "Full"
        Else
            statusPanel.BackColor = Color.LightGreen
            statusPanel.Controls(0).Text = "Active"
        End If
    End Sub

    Private Sub LoadCustomerNetworkMapping()
        LoadFilteredCustomerMapping("", "", "")
    End Sub

    Private Sub LoadFilteredCustomerMapping(locationFilter As String, napFilter As String, lcpFilter As String)
        Try
            BillingDetailsDGV.Rows.Clear()

            If BillingDetailsDGV.Columns.Count = 0 Then
                InitializeDataGridViewColumns()
            End If

            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Dim whereClause As String = "WHERE (c.account_status = 'Active' OR c.account_status IS NULL)"

                If Not String.IsNullOrEmpty(locationFilter) Then
                    whereClause += " AND c.installation_address LIKE @location"
                End If

                If Not String.IsNullOrEmpty(napFilter) Then
                    whereClause += " AND n.area_name = @napArea"
                End If

                Dim query As String = "
                SELECT 
                    CONCAT(c.first_name, ' ', c.last_name) as customer_name,
                    c.installation_address,
                    c.plan_type,
                    c.monthly_rate,
                    n.nap_id,
                    np.status
                FROM customer c
                LEFT JOIN nap_ports np ON np.customer_id = c.customer_id
                LEFT JOIN nap n ON np.nap_id = n.nap_id
                " & whereClause & "
                ORDER BY c.customer_id
                LIMIT 50"

                Using cmd As New MySqlCommand(query, conn)
                    If Not String.IsNullOrEmpty(locationFilter) Then
                        cmd.Parameters.AddWithValue("@location", "%" & locationFilter & "%")
                    End If

                    If Not String.IsNullOrEmpty(napFilter) Then
                        cmd.Parameters.AddWithValue("@napArea", napFilter)
                    End If

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim customerName As String = ""
                            If Not reader.IsDBNull(reader.GetOrdinal("customer_name")) Then
                                customerName = reader.GetString("customer_name")
                            Else
                                customerName = "Unknown Customer"
                            End If

                            Dim address As String = ""
                            If Not reader.IsDBNull(reader.GetOrdinal("installation_address")) Then
                                address = reader.GetString("installation_address")
                            Else
                                address = "No Address"
                            End If

                            Dim planType As String = ""
                            If Not reader.IsDBNull(reader.GetOrdinal("plan_type")) Then
                                planType = reader.GetString("plan_type")
                            Else
                                planType = "No Plan"
                            End If

                            Dim monthlyRate As Decimal = 0
                            If Not reader.IsDBNull(reader.GetOrdinal("monthly_rate")) Then
                                monthlyRate = reader.GetDecimal("monthly_rate")
                            End If

                            Dim napId As String = "Not Assigned"
                            Dim occupied As String = "No"
                            Dim available As String = "Yes"

                            If Not reader.IsDBNull(reader.GetOrdinal("nap_id")) Then
                                napId = "NAP-" & reader.GetInt32("nap_id").ToString("000")
                                Dim status As String = ""
                                If Not reader.IsDBNull(reader.GetOrdinal("status")) Then
                                    status = reader.GetString("status")
                                    occupied = If(status = "Occupied", "Yes", "No")
                                    available = If(status = "Available", "Yes", "No")
                                End If
                            End If

                            Dim lcpAddress As String = DetermineLCPAddress(address)

                            BillingDetailsDGV.Rows.Add(
                                customerName,
                                address,
                                lcpAddress,
                                napId,
                                occupied,
                                available
                            )
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading customer network mapping: " & ex.Message,
                       "Database Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function DetermineLCPAddress(address As String) As String
        If address.Contains("Daet") Then
            Return "Daet Central LCP"
        ElseIf address.Contains("Mercedes") Then
            Return "Mercedes LCP Hub"
        ElseIf address.Contains("Barangay I") Or address.Contains("Barangay II") Or address.Contains("Barangay III") Then
            Return "Daet North LCP"
        ElseIf address.Contains("Barangay IV") Or address.Contains("Barangay V") Or address.Contains("Barangay VI") Then
            Return "Daet Central LCP"
        ElseIf address.Contains("Barangay VII") Or address.Contains("Barangay VIII") Or address.Contains("Barangay IX") Or address.Contains("Barangay X") Then
            Return "Daet South LCP"
        Else
            Return "Main LCP"
        End If
    End Function

    Private Sub LoadNAPData()
        Try
            ComboBox4.Items.Clear()
            ComboBox4.Items.Add("Select NAP...")

            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT nap_id, area_name FROM nap WHERE status = 'Active' ORDER BY area_name"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim napId As Integer = reader.GetInt32("nap_id")
                            Dim areaName As String = reader.GetString("area_name")
                            ComboBox4.Items.Add($"NAP-{napId:000} - {areaName}")
                        End While
                    End Using
                End Using
            End Using

            ComboBox4.SelectedIndex = 0
            Button2.Visible = False
            Button3.Visible = False

        Catch ex As Exception
            MessageBox.Show("Error loading NAP data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        If ComboBox4.SelectedIndex > 0 Then
            Button2.Visible = True
            Button3.Visible = True

            Dim selectedText As String = ComboBox4.SelectedItem.ToString()
            Dim parts() As String = selectedText.Split("-")
            If parts.Length >= 2 Then
                Dim napIdStr As String = parts(1).Split(" ")(0)
                If Integer.TryParse(napIdStr, selectedNAPId) Then
                    CenterMapOnNAP(selectedNAPId)
                    ShowNAPDetailsForm(selectedNAPId)
                End If
            End If
        Else
            Button2.Visible = False
            Button3.Visible = False
            selectedNAPId = -1
            If currentNapFormHost IsNot Nothing AndAlso Not currentNapFormHost.IsDisposed Then
                currentNapFormHost.Close()
            End If
        End If
    End Sub

    Private Sub CenterMapOnNAP(napId As Integer)
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT latitude, longitude FROM nap WHERE nap_id = @napId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@napId", napId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim lat As Double = Convert.ToDouble(reader("latitude"))
                            Dim lng As Double = Convert.ToDouble(reader("longitude"))

                            mapControl.Position = New PointLatLng(lat, lng)
                            mapControl.Zoom = 15
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine($"Error centering map on NAP: {ex.Message}")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mapControl.Position = New PointLatLng(DAET_LAT, DAET_LNG)
        mapControl.Zoom = 13

        MessageBox.Show("Double-click on the map to add a new NAP at that location.",
                       "Add NAP",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If selectedNAPId = -1 Then
            MessageBox.Show("Please select a NAP first.", "No NAP Selected",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If currentNapFormHost IsNot Nothing AndAlso Not currentNapFormHost.IsDisposed Then
            If currentNapForm IsNot Nothing AndAlso currentNapForm.CurrentNAPId = selectedNAPId Then
                currentNapFormHost.Activate()
                MessageBox.Show("You can now edit the NAP details in the opened form.",
                          "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ShowNAPDetailsForm(selectedNAPId)
            End If
        Else
            ShowNAPDetailsForm(selectedNAPId)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If selectedNAPId = -1 Then
            MessageBox.Show("Please select a NAP to delete", "No NAP Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete NAP-{selectedNAPId:000}?" & vbCrLf &
                                                    "This will also delete all associated ports and unassign any customers!",
                                                    "Confirm Deletion",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            DeleteNAP(selectedNAPId)
        End If
    End Sub

    Private Sub DeleteNAP(napId As Integer)
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Using transaction As MySqlTransaction = conn.BeginTransaction()
                    Try
                        Dim unassignQuery As String = "DELETE FROM customer_nap_assignment 
                                                      WHERE port_id IN (SELECT port_id FROM nap_ports WHERE nap_id = @napId)"

                        Using cmd1 As New MySqlCommand(unassignQuery, conn, transaction)
                            cmd1.Parameters.AddWithValue("@napId", napId)
                            cmd1.ExecuteNonQuery()
                        End Using

                        Dim deletePortsQuery As String = "DELETE FROM nap_ports WHERE nap_id = @napId"

                        Using cmd2 As New MySqlCommand(deletePortsQuery, conn, transaction)
                            cmd2.Parameters.AddWithValue("@napId", napId)
                            cmd2.ExecuteNonQuery()
                        End Using

                        Dim deleteNAPQuery As String = "DELETE FROM nap WHERE nap_id = @napId"

                        Using cmd3 As New MySqlCommand(deleteNAPQuery, conn, transaction)
                            cmd3.Parameters.AddWithValue("@napId", napId)
                            cmd3.ExecuteNonQuery()
                        End Using

                        transaction.Commit()

                        MessageBox.Show($"NAP-{napId:000} deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        If currentNapFormHost IsNot Nothing AndAlso Not currentNapFormHost.IsDisposed Then
                            currentNapFormHost.Close()
                        End If

                        LoadNAPData()
                        LoadStatistics()
                        LoadInfrastructureStatus()
                        LoadCustomerNetworkMapping()
                        LoadNAPMarkers()

                        ComboBox4.SelectedIndex = 0
                        selectedNAPId = -1
                        Button2.Visible = False
                        Button3.Visible = False

                    Catch ex As Exception
                        transaction.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error deleting NAP: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ExportNetworkReport()
    End Sub

    Private Sub ExportNetworkReport()
        Using saveDialog As New SaveFileDialog()
            saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|PDF Files (*.pdf)|*.pdf"
            saveDialog.FilterIndex = 1
            saveDialog.FileName = $"Network_Report_{DateTime.Now:yyyyMMdd_HHmmss}"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                Try
                    Dim dt As New DataTable()

                    For Each column As DataGridViewColumn In BillingDetailsDGV.Columns
                        dt.Columns.Add(column.HeaderText)
                    Next

                    For Each row As DataGridViewRow In BillingDetailsDGV.Rows
                        If Not row.IsNewRow Then
                            Dim newRow As DataRow = dt.NewRow()
                            For i As Integer = 0 To BillingDetailsDGV.Columns.Count - 1
                                Dim cellValue As Object = row.Cells(i).Value
                                newRow(i) = If(cellValue IsNot Nothing, cellValue.ToString(), "")
                            Next
                            dt.Rows.Add(newRow)
                        End If
                    Next

                    Dim summary As String = $"NETWORK MAP REPORT" & vbCrLf &
                                          $"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}" & vbCrLf &
                                          $"Total Customers: {TotalSales.Text}" & vbCrLf &
                                          $"Active NAPs: {MonthlyRev.Text}" & vbCrLf &
                                          $"Maintenance Required: {AvgRev.Text}" & vbCrLf &
                                          $"Export File: {saveDialog.FileName}"

                    MessageBox.Show($"Report prepared for export:{vbCrLf}{summary}",
                                  "Export Complete",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information)

                Catch ex As Exception
                    MessageBox.Show($"Error preparing report: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub BillingDetailsDGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles BillingDetailsDGV.CellContentClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim cellValue As Object = BillingDetailsDGV.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            Dim cellValueStr As String = If(cellValue IsNot Nothing, cellValue.ToString(), "")

            If Not String.IsNullOrEmpty(cellValueStr) Then
                If e.ColumnIndex = 0 Then
                    ShowCustomerDetails(e.RowIndex)
                End If
            End If
        End If
    End Sub

    Private Sub ShowCustomerDetails(rowIndex As Integer)
        Dim customerName As Object = BillingDetailsDGV.Rows(rowIndex).Cells(0).Value
        Dim address As Object = BillingDetailsDGV.Rows(rowIndex).Cells(1).Value
        Dim lcpAddress As Object = BillingDetailsDGV.Rows(rowIndex).Cells(2).Value
        Dim napId As Object = BillingDetailsDGV.Rows(rowIndex).Cells(3).Value
        Dim occupied As Object = BillingDetailsDGV.Rows(rowIndex).Cells(4).Value
        Dim available As Object = BillingDetailsDGV.Rows(rowIndex).Cells(5).Value

        Dim customerNameStr As String = If(customerName IsNot Nothing, customerName.ToString(), "")
        Dim addressStr As String = If(address IsNot Nothing, address.ToString(), "")
        Dim lcpAddressStr As String = If(lcpAddress IsNot Nothing, lcpAddress.ToString(), "")
        Dim napIdStr As String = If(napId IsNot Nothing, napId.ToString(), "")
        Dim occupiedStr As String = If(occupied IsNot Nothing, occupied.ToString(), "")
        Dim availableStr As String = If(available IsNot Nothing, available.ToString(), "")

        Dim details As String = $"Customer: {customerNameStr}" & vbCrLf &
                               $"Address: {addressStr}" & vbCrLf &
                               $"LCP Address: {lcpAddressStr}" & vbCrLf &
                               $"NAP Assignment: {napIdStr}" & vbCrLf &
                               $"Occupied: {occupiedStr}" & vbCrLf &
                               $"Available: {availableStr}"

        MessageBox.Show(details, "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Public Sub RefreshAllData()
        LoadStatistics()
        LoadNAPData()
        LoadInfrastructureStatus()
        LoadCustomerNetworkMapping()
        LoadNAPMarkers()
    End Sub
    Private Sub OverduePanel_Click(sender As Object, e As EventArgs) Handles OverduePanel.Click
        Dim napId As Integer = GetNAPIdFromPanel(OverduePanel)
        If napId > 0 Then
            ShowNAPDetailsForm(napId)
        End If
    End Sub

    Private Sub PanelRound2_Click(sender As Object, e As EventArgs) Handles PanelRound2.Click
        Dim napId As Integer = GetNAPIdFromPanel(PanelRound2)
        If napId > 0 Then
            ShowNAPDetailsForm(napId)
        End If
    End Sub

    Private Sub PanelRound4_Click(sender As Object, e As EventArgs) Handles PanelRound4.Click
        Dim napId As Integer = GetNAPIdFromPanel(PanelRound4)
        If napId > 0 Then
            ShowNAPDetailsForm(napId)
        End If
    End Sub

    Private Function GetNAPIdFromPanel(panel As PanelRound) As Integer
        For Each ctrl As Control In panel.Controls
            If TypeOf ctrl Is Label Then
                Dim lbl As Label = CType(ctrl, Label)
                If lbl.Text.Contains("NAP-") Then
                    Dim napIdStr As String = lbl.Text.Split("-")(1)
                    Dim napId As Integer
                    If Integer.TryParse(napIdStr, napId) Then
                        Return napId
                    End If
                End If
            End If
        Next
        Return 0
    End Function

    Private Sub InitializeDataGridViewColumns()
        BillingDetailsDGV.Columns.Clear()
        Dim colCustomer As New DataGridViewTextBoxColumn()
        colCustomer.HeaderText = "Customer"
        colCustomer.Name = "Customer"
        colCustomer.Width = 150
        BillingDetailsDGV.Columns.Add(colCustomer)

        Dim colAddress As New DataGridViewTextBoxColumn()
        colAddress.HeaderText = "Address"
        colAddress.Name = "Address"
        colAddress.Width = 200
        BillingDetailsDGV.Columns.Add(colAddress)

        Dim colLCP As New DataGridViewTextBoxColumn()
        colLCP.HeaderText = "LCP Address"
        colLCP.Name = "LCPAddress"
        colLCP.Width = 150
        BillingDetailsDGV.Columns.Add(colLCP)

        Dim colNAPID As New DataGridViewTextBoxColumn()
        colNAPID.HeaderText = "NAP ID"
        colNAPID.Name = "NAPID"
        colNAPID.Width = 100
        BillingDetailsDGV.Columns.Add(colNAPID)

        Dim colOccupied As New DataGridViewTextBoxColumn()
        colOccupied.HeaderText = "Occupied"
        colOccupied.Name = "Occupied"
        colOccupied.Width = 80
        colOccupied.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        BillingDetailsDGV.Columns.Add(colOccupied)

        Dim colAvailable As New DataGridViewTextBoxColumn()
        colAvailable.HeaderText = "Available"
        colAvailable.Name = "Available"
        colAvailable.Width = 80
        colAvailable.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        BillingDetailsDGV.Columns.Add(colAvailable)
    End Sub

    Private Sub FormatDataGridView()
        BillingDetailsDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        BillingDetailsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        BillingDetailsDGV.MultiSelect = False
        BillingDetailsDGV.ReadOnly = True
        BillingDetailsDGV.RowHeadersVisible = False
        BillingDetailsDGV.AllowUserToAddRows = False
        BillingDetailsDGV.AllowUserToDeleteRows = False
        BillingDetailsDGV.AllowUserToOrderColumns = False
        BillingDetailsDGV.AllowUserToResizeRows = False

        BillingDetailsDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
    End Sub
End Class