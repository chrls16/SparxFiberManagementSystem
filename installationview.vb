Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Media
Imports LiveCharts
Imports LiveCharts.WinForms
Imports LiveCharts.Wpf
Imports MySqlConnector
Imports Color = System.Drawing.Color

Public Class installationview

    Private _connectionString As String = Nothing
    Private installationDataTable As DataTable

    Private InstallationStatus As LiveCharts.WinForms.PieChart

    Private updateTimer As Timer
    Private installationBindingSource As New BindingSource()

    Private Const PAGE_SIZE As Integer = 25
    Private currentPageIndex As Integer = 0
    Private totalRecords As Integer = 0

    Private selectedServiceIds As New List(Of Integer)()

    Private ReadOnly Property CONNECTION_STRING As String

        Get
            If _connectionString Is Nothing AndAlso Not DesignMode Then
                Try
                    _connectionString = ConfigurationManager.ConnectionStrings("SparxDb").ConnectionString
                Catch
                    _connectionString = String.Empty
                End Try
            End If
            Return If(_connectionString IsNot Nothing, _connectionString, String.Empty)
        End Get

    End Property

    'FOR UI
    Private Sub DataGridInstallationDetails_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridInstallationDetails.CellFormatting
        If e.RowIndex < 0 Then Return

        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        e.CellStyle.BackColor = Color.White
        e.CellStyle.ForeColor = Color.Black
        e.CellStyle.SelectionBackColor = Color.White
        e.CellStyle.SelectionForeColor = Color.Black

        If e.ColumnIndex >= 0 Then
            Dim columnName As String = DataGridInstallationDetails.Columns(e.ColumnIndex).Name

            If columnName = "ServiceID" Then
                If e.Value IsNot Nothing AndAlso IsNumeric(e.Value) Then
                    e.Value = Convert.ToInt32(e.Value).ToString("D5")
                    e.FormattingApplied = True
                End If
            End If

            If columnName = "ServiceID" Then
                If e.Value IsNot Nothing AndAlso IsNumeric(e.Value) Then
                    e.Value = Convert.ToInt32(e.Value).ToString("D5")
                    e.FormattingApplied = True
                End If
            End If
            If columnName = "DateRequested" AndAlso e.Value IsNot Nothing Then
                If TypeOf e.Value Is Date Then
                    Dim dateValue As Date = CType(e.Value, Date)
                    e.Value = If(dateValue <> Date.MinValue, dateValue.ToString("MM/dd/yyyy"), "")
                    e.FormattingApplied = True
                End If
            End If
        End If
    End Sub

    Private Sub UpdateInstallationGrid(dt As DataTable)

        DataGridInstallationDetails.SuspendLayout()
        Try

            installationBindingSource.DataSource = dt
            DataGridInstallationDetails.DataSource = installationBindingSource

            If DataGridInstallationDetails.Columns.Contains("ServiceID") Then
                DataGridInstallationDetails.Columns("ServiceID").Visible = True
            End If
        Finally
            DataGridInstallationDetails.ResumeLayout(True)
        End Try

    End Sub

    Private Sub DataGridServiceRequestDetails_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridInstallationDetails.SelectionChanged

        DataGridInstallationDetails.ClearSelection()

    End Sub

    Private Sub ConfigureDataGridViewBehavior()

        With DataGridInstallationDetails
            EnableDoubleBuffering(DataGridInstallationDetails)
        End With

    End Sub

    'FOR DATA LABELS
    Private Sub UpdateInstallationPercentageLabels(statusData As Dictionary(Of String, Integer))

        Dim total As Integer = 0

        For Each value In statusData.Values
            total += value
        Next

        If total > 0 Then
            Dim completedCount As Integer = statusData.GetValueOrDefault("Completed", 0)
            Dim completedPct As Double = (CDbl(completedCount) / total) * 100.0

            Dim lblCompleted As Control = FindControlRecursive(Me, "percentCompleted")
            If lblCompleted Is Nothing Then lblCompleted = FindControlRecursive(Me, "PercentCompleted")
            If lblCompleted Is Nothing Then lblCompleted = FindControlRecursive(Me, "PercentComplete")

            If lblCompleted IsNot Nothing AndAlso TypeOf lblCompleted Is Label Then
                CType(lblCompleted, Label).Text = completedPct.ToString("F0") & "%"
            End If

            Dim inProgressCount As Integer = statusData.GetValueOrDefault("In Progress", 0) + statusData.GetValueOrDefault("In-progress", 0)
            Dim inProgressPct As Double = (CDbl(inProgressCount) / total) * 100.0

            Dim lblInProgress As Control = FindControlRecursive(Me, "percentInProgress")
            If lblInProgress Is Nothing Then lblInProgress = FindControlRecursive(Me, "PercentInProgress")

            If lblInProgress IsNot Nothing AndAlso TypeOf lblInProgress Is Label Then
                CType(lblInProgress, Label).Text = inProgressPct.ToString("F0") & "%"
            End If

            Dim requestedCount As Integer = statusData.GetValueOrDefault("Requested", 0) + statusData.GetValueOrDefault("Pending", 0)
            Dim requestedPct As Double = (CDbl(requestedCount) / total) * 100.0

            Dim lblRequested As Control = FindControlRecursive(Me, "percentRequested")
            If lblRequested Is Nothing Then lblRequested = FindControlRecursive(Me, "PercentRequested")

            If lblRequested IsNot Nothing AndAlso TypeOf lblRequested Is Label Then
                CType(lblRequested, Label).Text = requestedPct.ToString("F0") & "%"
            End If
        Else

            Dim lblCompleted As Control = FindControlRecursive(Me, "percentCompleted")
            If lblCompleted IsNot Nothing AndAlso TypeOf lblCompleted Is Label Then CType(lblCompleted, Label).Text = "0%"

            Dim lblInProgress As Control = FindControlRecursive(Me, "percentInProgress")
            If lblInProgress IsNot Nothing AndAlso TypeOf lblInProgress Is Label Then CType(lblInProgress, Label).Text = "0%"

            Dim lblRequested As Control = FindControlRecursive(Me, "percentRequested")
            If lblRequested IsNot Nothing AndAlso TypeOf lblRequested Is Label Then CType(lblRequested, Label).Text = "0%"

        End If

    End Sub

    Private Sub UpdateInstallationKPIs(total As Integer, statusData As Dictionary(Of String, Integer))

        Dim completedCount As Integer = statusData.GetValueOrDefault("Completed", 0)
        Dim inProgressCount As Integer = statusData.GetValueOrDefault("In Progress", 0) + statusData.GetValueOrDefault("In-progress", 0)
        Dim requestedCount As Integer = statusData.GetValueOrDefault("Requested", 0) + statusData.GetValueOrDefault("Pending", 0)

        Dim lblTotal As Control = FindControlRecursive(Me, "NumTotalInstallations")
        If lblTotal IsNot Nothing AndAlso TypeOf lblTotal Is Label Then
            CType(lblTotal, Label).Text = total.ToString()
        End If

        Dim lblCompleted As Control = FindControlRecursive(Me, "NumCompleted")
        If lblCompleted IsNot Nothing AndAlso TypeOf lblCompleted Is Label Then
            CType(lblCompleted, Label).Text = completedCount.ToString()
        End If

        Dim lblInProgress As Control = FindControlRecursive(Me, "NumInProgress")
        If lblInProgress IsNot Nothing AndAlso TypeOf lblInProgress Is Label Then
            CType(lblInProgress, Label).Text = inProgressCount.ToString()
        End If

        Dim lblRequested As Control = FindControlRecursive(Me, "NumPending")
        If lblRequested IsNot Nothing AndAlso TypeOf lblRequested Is Label Then
            CType(lblRequested, Label).Text = requestedCount.ToString()
        End If

    End Sub

    'FOR CHARTS
    Private Sub CreateCharts()

        If Panel1 Is Nothing Then
            MessageBox.Show("Panel1 not found! Check your Designer file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        InstallationStatus = New LiveCharts.WinForms.PieChart()
        InstallationStatus.Dock = DockStyle.Fill
        InstallationStatus.BackColor = System.Drawing.Color.White
        InstallationStatus.LegendLocation = LegendLocation.Bottom

        Panel1.Visible = True
        If Panel1.Width = 0 Or Panel1.Height = 0 Then
            Panel1.Size = New Size(634, 434)
        End If

        Panel1.Controls.Add(InstallationStatus)
        InstallationStatus.BringToFront()

        InstallationStatus.Refresh()
        Panel1.Refresh()

    End Sub

    Private Sub LoadInstallationStatusChart()

        If InstallationStatus Is Nothing OrElse ComboBox1 Is Nothing Then Return

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim filterClause As String = "WHERE service_type = 'Installation' AND is_deleted = 0 "

                Dim selectedMonth As Integer = ComboBox1.SelectedIndex
                If selectedMonth > 0 Then filterClause &= " AND MONTH(date_requested) = @Month "

                Dim selectedStatus As String = ComboBox3.SelectedItem?.ToString()
                If ComboBox3.SelectedIndex > 0 Then filterClause &= " AND status = @Status "

                Dim query As String = $"SELECT status, COUNT(*) AS count FROM service {filterClause} GROUP BY status"

                Using cmd As New MySqlCommand(query, conn)
                    If selectedMonth > 0 Then cmd.Parameters.AddWithValue("@Month", selectedMonth)
                    If ComboBox3.SelectedIndex > 0 Then cmd.Parameters.AddWithValue("@Status", selectedStatus)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim statusData As New Dictionary(Of String, Integer)()
                        Dim total As Integer = 0
                        While reader.Read()
                            Dim status As String = reader("status").ToString()
                            Dim count As Integer = Convert.ToInt32(reader("count"))
                            statusData(status) = count
                            total += count
                        End While

                        If Me.InvokeRequired Then
                            Me.Invoke(New Action(Sub() UpdateChartAndKPIs(statusData, total)))
                        Else
                            UpdateChartAndKPIs(statusData, total)
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error updating chart: " & ex.Message)
        End Try

    End Sub

    Private Sub UpdateChartAndKPIs(statusData As Dictionary(Of String, Integer), total As Integer)

        If InstallationStatus Is Nothing Then Return

        Dim pieSeries As New SeriesCollection()

        If total > 0 Then
            For Each kvp In statusData
                Dim percentage As Double = (kvp.Value / total) * 100
                Dim item As New PieSeries() With {
                .Title = $"{kvp.Key} ({percentage:F0}%)",
                .Values = New ChartValues(Of Double)({kvp.Value}),
                .DataLabels = False
            }

                Select Case kvp.Key.ToLower().Trim()
                    Case "completed" : item.Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(34, 197, 94))
                    Case "in progress", "in-progress" : item.Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(251, 146, 60))
                End Select

                pieSeries.Add(item)
            Next
        End If

        InstallationStatus.Series = pieSeries
        InstallationStatus.Refresh()

        UpdateInstallationPercentageLabels(statusData)
        UpdateInstallationKPIs(total, statusData)

    End Sub

    'FOR TABLE
    Private Sub LoadCustomers(cmb As ComboBox)

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Dim query As String = "SELECT customer_id, CONCAT(first_name, ' ', last_name) AS full_name FROM customer ORDER BY first_name, last_name"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim dt As New DataTable()
                        dt.Load(reader)
                        cmb.DataSource = dt
                        cmb.DisplayMember = "full_name"
                        cmb.ValueMember = "customer_id"
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading customers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub LoadCustomerAddress(customerId As Integer, txtAddress As TextBox)

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Dim query As String = "SELECT installation_address FROM customer WHERE customer_id = @customerId"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@customerId", customerId)
                    Dim address As Object = cmd.ExecuteScalar()
                    If address IsNot Nothing AndAlso address IsNot DBNull.Value Then
                        txtAddress.Text = address.ToString()
                    Else
                        txtAddress.Text = ""
                    End If
                End Using
            End Using

        Catch ex As Exception
            ' Silently fail - address will remain empty
        End Try

    End Sub

    Private Sub LoadTechnicians(cmb As ComboBox)

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Dim query As String = "SELECT CONCAT(first_name, ' ', last_name) AS full_name FROM staff WHERE position = 'Technician' ORDER BY first_name"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cmb.Items.Add(reader("full_name").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Silently fail - technicians will remain unassigned
        End Try

    End Sub

    Private Sub LoadInstallationDetailsGrid()

        If DataGridInstallationDetails Is Nothing Then Return

        If updateTimer IsNot Nothing Then updateTimer.Stop()

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim searchText As String = txtInstallationSearchSA.Text.Trim()
                Dim whereClause As New System.Text.StringBuilder()

                ' Base filter
                whereClause.Append("WHERE s.service_type = 'Installation' AND s.is_deleted = 0 ")

                ' Filter by Month ComboBox
                Dim selectedMonth As Integer = ComboBox1.SelectedIndex
                If selectedMonth > 0 Then
                    whereClause.Append(" AND MONTH(s.date_requested) = @Month ")
                End If

                ' Filter by Status ComboBox
                Dim selectedStatus As String = ComboBox3.SelectedItem?.ToString()
                If ComboBox3.SelectedIndex > 0 Then
                    whereClause.Append(" AND s.status = @Status ")
                End If

                ' --- UPDATED SEARCH LOGIC HERE ---
                If Not String.IsNullOrWhiteSpace(searchText) Then
                    whereClause.Append(" AND (s.service_id LIKE @Search " &
                                       "OR LPAD(s.service_id, 5, '0') LIKE @Search " &
                                       "OR CONCAT(c.first_name, ' ', c.last_name) LIKE @Search " &
                                       "OR c.contact_number LIKE @Search " &
                                       "OR c.installation_address LIKE @Search " &
                                       "OR CONCAT(t.first_name, ' ', t.last_name) LIKE @Search " &
                                       "OR DATE_FORMAT(s.date_requested, '%m/%d/%Y') LIKE @Search)") ' <--- ADDED THIS LINE
                End If
                ' ---------------------------------

                ' Step A: Get Total Count for Pagination
                Dim countQuery As String = "SELECT COUNT(*) FROM service s " &
                                           "JOIN customer c ON s.customer_id = c.customer_id " &
                                           "LEFT JOIN staff t ON s.staff_id = t.staff_id AND t.position = 'Technician' " &
                                           whereClause.ToString()

                Using countCmd As New MySqlCommand(countQuery, conn)
                    AddFiltersToCommand(countCmd, searchText, selectedMonth, selectedStatus)
                    totalRecords = Convert.ToInt32(countCmd.ExecuteScalar())
                End Using

                ' Step B: Calculate Pagination
                Dim totalPages As Integer = CInt(Math.Ceiling(totalRecords / PAGE_SIZE))
                If currentPageIndex >= totalPages Then
                    currentPageIndex = Math.Max(0, totalPages - 1)
                End If
                Dim offset As Integer = currentPageIndex * PAGE_SIZE

                ' Step C: Get Paginated Data
                Dim query As String = "SELECT s.service_id AS ServiceID, " &
                                    "CONCAT(c.first_name, ' ', c.last_name) AS Customer, " &
                                    "c.contact_number AS ContactNo, DATE_FORMAT(s.date_requested, '%m/%d/%Y') AS DateRequested, " &
                                    "CONCAT(t.first_name, ' ', t.last_name) AS Technician, " &
                                    "c.installation_address AS Address, s.status AS Status " &
                                    "FROM service s JOIN customer c ON s.customer_id = c.customer_id " &
                                    "LEFT JOIN staff t ON s.staff_id = t.staff_id AND t.position = 'Technician' " &
                                    whereClause.ToString() &
                                    " ORDER BY s.date_requested DESC LIMIT @PageSize OFFSET @Offset"

                Using cmd As New MySqlCommand(query, conn)
                    AddFiltersToCommand(cmd, searchText, selectedMonth, selectedStatus)
                    cmd.Parameters.AddWithValue("@PageSize", PAGE_SIZE)
                    cmd.Parameters.AddWithValue("@Offset", offset)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim dt As New DataTable()
                        dt.Load(reader)

                        If Me.InvokeRequired Then
                            Me.Invoke(New Action(Sub()
                                                     UpdateInstallationGrid(dt)
                                                     UpdatePaginationControls()
                                                 End Sub))
                        Else
                            UpdateInstallationGrid(dt)
                            UpdatePaginationControls()
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading installations: " & ex.Message)
        Finally
            If updateTimer IsNot Nothing Then updateTimer.Start()
        End Try

    End Sub

    ' FOR FILTERS
    Private Sub AddFiltersToCommand(ByRef cmd As MySqlCommand, searchText As String, month As Integer, status As String)
        If month > 0 Then cmd.Parameters.AddWithValue("@Month", month)
        If ComboBox3.SelectedIndex > 0 Then cmd.Parameters.AddWithValue("@Status", status)
        If Not String.IsNullOrWhiteSpace(searchText) Then
            cmd.Parameters.AddWithValue("@Search", "%" & searchText & "%")
        End If
    End Sub

    Private Sub PopulateDropdowns()

        Me.ComboBox1.Items.Clear()
        Me.ComboBox1.Items.Add("All Time")
        Me.ComboBox1.Items.AddRange(New String() {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
            })

        Me.ComboBox3.Items.Clear()
        Me.ComboBox3.Items.Add("All Status")
        Me.ComboBox3.Items.AddRange(New String() {"Completed", "In Progress", "Requested"})
        Me.ComboBox3.SelectedIndex = 0

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        currentPageIndex = 0
        LoadInstallationDetailsGrid()
        LoadInstallationStatusChart()

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

        currentPageIndex = 0
        LoadInstallationDetailsGrid()
        LoadInstallationStatusChart()

    End Sub

    ' FOR EDIT, DELETE, CHECKBOX
    Private Sub DataGridInstallationDetails_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridInstallationDetails.CellClick

        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim columnName As String = DataGridInstallationDetails.Columns(e.ColumnIndex).Name

        If columnName = "DeleteIcon" Then
            Dim serviceId As Integer = Convert.ToInt32(DataGridInstallationDetails.Rows(e.RowIndex).Cells("ServiceID").Value)
            DeleteInstallation(serviceId, e.RowIndex)
        End If

        If columnName = "EditIcon" Then
            Dim val As String = DataGridInstallationDetails.Rows(e.RowIndex).Cells("ServiceID").Value.ToString()
            Dim serviceIdInt As Integer
            If Integer.TryParse(val, serviceIdInt) Then
                EditInstallation(serviceIdInt, e.RowIndex)
            End If
        End If

        If columnName = "checkbox" Then
            Dim cell As DataGridViewCheckBoxCell = TryCast(DataGridInstallationDetails.Rows(e.RowIndex).Cells("checkbox"), DataGridViewCheckBoxCell)
            If cell IsNot Nothing Then
                cell.Value = Not Convert.ToBoolean(cell.Value)
                DataGridInstallationDetails.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
        End If

    End Sub

    Private Sub DataGridInstallationDetails_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)

        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim columnName As String = DataGridInstallationDetails.Columns(e.ColumnIndex).Name

        If columnName = "checkbox" Then
            Dim serviceId As Integer = Convert.ToInt32(DataGridInstallationDetails.Rows(e.RowIndex).Cells("ServiceID").Value)
            Dim isChecked As Boolean = CBool(DataGridInstallationDetails.Rows(e.RowIndex).Cells("checkbox").Value)

            If isChecked Then
                If Not selectedServiceIds.Contains(serviceId) Then
                    selectedServiceIds.Add(serviceId)
                End If
            Else
                selectedServiceIds.Remove(serviceId)
            End If

            UpdateSelectionUI()

        End If

    End Sub

    Private Sub DeleteInstallation(serviceId As Integer, rowIndex As Integer)

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete installation #" & serviceId & "?",
                                                 "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                Using conn As New MySqlConnection(CONNECTION_STRING)
                    conn.Open()

                    Dim query As String = "UPDATE service SET is_deleted = 1 WHERE service_id = @serviceId"

                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@serviceId", serviceId)
                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show("Deleted successfully!")

                            ' Clear selection and refresh
                            currentPageIndex = 0
                            LoadInstallationDetailsGrid()
                            LoadInstallationStatusChart()
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Database Error: " & ex.Message)
            End Try
        End If

    End Sub

    Private Sub deleteAll_Click(sender As Object, e As EventArgs) Handles deleteAll.Click

        If selectedServiceIds.Count = 0 Then
            MessageBox.Show("Please select at least one installation to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete the {selectedServiceIds.Count} selected installation(s)?",
                                                 "Confirm Bulk Delete",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                Using conn As New MySqlConnection(CONNECTION_STRING)
                    conn.Open()

                    Dim paramNames As New List(Of String)
                    For i As Integer = 0 To selectedServiceIds.Count - 1
                        paramNames.Add("@id" & i)
                    Next

                    ' --- CHANGE TO SOFT DELETE ---
                    Dim query As String = $"UPDATE service SET is_deleted = 1 WHERE service_id IN ({String.Join(",", paramNames)})"
                    ' -----------------------------

                    Using cmd As New MySqlCommand(query, conn)
                        For i As Integer = 0 To selectedServiceIds.Count - 1
                            cmd.Parameters.AddWithValue("@id" & i, selectedServiceIds(i))
                        Next

                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                        MessageBox.Show($"{rowsAffected} installation(s) deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        selectedServiceIds.Clear()
                        LoadInstallationDetailsGrid()
                        LoadInstallationStatusChart()
                        UpdateSelectionUI()
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error deleting records: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub

    Private Sub UpdateSelectionUI()

        If selectedServiceIds.Count > 0 Then
            deleteAll.Enabled = True
            deleteAll.Text = $"Delete Selected ({selectedServiceIds.Count})"
        Else
            deleteAll.Enabled = False
            deleteAll.Text = "Delete Selected"
        End If
    End Sub

    'FOR SEARCHING
    Private Sub txtInstallationSearchSA_TextChanged(sender As Object, e As EventArgs) Handles txtInstallationSearchSA.TextChanged

        Static searchTimer As New Timer With {.Interval = 500}

        RemoveHandler searchTimer.Tick, AddressOf PerformSearch
        AddHandler searchTimer.Tick, AddressOf PerformSearch
        searchTimer.Start()

    End Sub

    Private Sub PerformSearch(sender As Object, e As EventArgs)

        CType(sender, Timer).Stop()
        currentPageIndex = 0
        LoadInstallationDetailsGrid()

    End Sub

    Private Sub SearchInstallations(searchText As String)

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim query As String = "SELECT " & "s.service_id AS ServiceID, " &
                                "CONCAT(c.first_name, ' ', c.last_name) AS Customer, " &
                                "c.contact_number AS ContactNo, " & "s.date_requested AS DateRequested, " &
                                "CONCAT(t.first_name, ' ', t.last_name) AS Technician, " & "c.installation_address AS Address, " &
                                "s.status AS Status " & "FROM " & "service s " &
                                "JOIN " & "customer c ON s.customer_id = c.customer_id " &
                                "LEFT JOIN " & "staff t ON s.staff_id = t.staff_id AND t.position = 'Technician' " &
                                "WHERE " & "s.service_type = 'Installation' " &
                                "AND (c.first_name LIKE @search OR c.last_name LIKE @search " &
                                "OR CONCAT(c.first_name, ' ', c.last_name) LIKE @search " &
                                "OR c.contact_number LIKE @search OR c.installation_address LIKE @search " &
                                "OR s.status LIKE @search " &
                                "OR CONCAT(t.first_name, ' ', t.last_name) LIKE @search) " &
                                "ORDER BY " & "s.date_requested DESC " & "LIMIT @PageSize"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@search", "%" & searchText & "%")
                    cmd.Parameters.AddWithValue("@PageSize", PAGE_SIZE)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim dt As New DataTable()
                        dt.Load(reader)

                        If Me.InvokeRequired Then
                            Me.Invoke(New Action(Sub()
                                                     btnInstallationPrevious.Visible = False
                                                     btnNextInstallationSA.Visible = False
                                                 End Sub))
                        Else

                            btnInstallationPrevious.Visible = False
                            btnNextInstallationSA.Visible = False
                        End If

                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error searching installations: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtTechnicianSearchSA_TextChanged(sender As Object, e As EventArgs)

        Static techSearchTimer As New Timer With {.Interval = 500}

        RemoveHandler techSearchTimer.Tick, AddressOf PerformTechSearch
        AddHandler techSearchTimer.Tick, AddressOf PerformTechSearch
        techSearchTimer.Start

    End Sub

    Private Sub PerformTechSearch(sender As Object, e As EventArgs)

        CType(sender, Timer).Stop()
        currentPageIndex = 0
        LoadInstallationDetailsGrid()

    End Sub

    Private Sub SearchByTechnician(searchText As String)

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim query As String = "SELECT " & "s.service_id AS ServiceID, " &
                                    "CONCAT(c.first_name, ' ', c.last_name) AS Customer, " &
                                    "c.contact_number AS ContactNo, " & "s.date_requested AS DateRequested, " &
                                    "CONCAT(t.first_name, ' ', t.last_name) AS Technician, " & "c.installation_address AS Address, " &
                                    "s.status AS Status " & "FROM service s " &
                                    "JOIN customer c ON s.customer_id = c.customer_id " & "LEFT JOIN staff t ON s.staff_id = t.staff_id AND t.position = 'Technician' " &
                                    "WHERE s.service_type = 'Installation' " & "AND (t.first_name LIKE @search " &
                                    "OR t.last_name LIKE @search " & "OR CONCAT(t.first_name, ' ', t.last_name) LIKE @search) " &
                                    "ORDER BY s.date_requested DESC"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@search", "%" & searchText & "%")

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim dt As New DataTable()
                        dt.Load(reader)

                        If Me.InvokeRequired Then
                            Me.Invoke(New Action(Sub()
                                                     btnInstallationPrevious.Visible = False
                                                     btnNextInstallationSA.Visible = False
                                                 End Sub))
                        Else

                            btnInstallationPrevious.Visible = False
                            btnNextInstallationSA.Visible = False
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error searching technicians: " & ex.Message)
        End Try

    End Sub

    ' FOR FORMS

    Private Function ValidateInstallationForm(cmbCustomer As ComboBox, txtAddress As TextBox, cmbStatus As ComboBox) As Boolean

        If cmbCustomer.SelectedIndex < 0 Then
            MessageBox.Show("Please select a customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtAddress.Text) Then
            MessageBox.Show("Please enter an installation address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cmbStatus.SelectedIndex < 0 Then
            MessageBox.Show("Please select a status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True

    End Function

    Private Sub ShowNewCustomerForm(cmbCustomer As ComboBox)

        Try
            Using newCustomerForm As New Form()
                newCustomerForm.Text = "New Customer"
                newCustomerForm.Size = New Size(400, 350)
                newCustomerForm.StartPosition = FormStartPosition.CenterScreen

                Dim lblFirstName As New Label() With {
                    .Text = "First Name:",
                    .Location = New Point(20, 20),
                    .Size = New Size(80, 25)
                }

                Dim txtFirstName As New TextBox() With {
                    .Location = New Point(120, 20),
                    .Size = New Size(250, 25)
                }

                Dim lblLastName As New Label() With {
                    .Text = "Last Name:",
                    .Location = New Point(20, 60),
                    .Size = New Size(80, 25)
                }

                Dim txtLastName As New TextBox() With {
                    .Location = New Point(120, 60),
                    .Size = New Size(250, 25)
                }

                Dim lblContact As New Label() With {
                    .Text = "Contact No:",
                    .Location = New Point(20, 100),
                    .Size = New Size(80, 25)
                }

                Dim txtContact As New TextBox() With {
                    .Location = New Point(120, 100),
                    .Size = New Size(250, 25)
                }

                Dim lblEmail As New Label() With {
                    .Text = "Email:",
                    .Location = New Point(20, 140),
                    .Size = New Size(80, 25)
                }

                Dim txtEmail As New TextBox() With {
                    .Location = New Point(120, 140),
                    .Size = New Size(250, 25)
                }

                Dim lblAddress As New Label() With {
                    .Text = "Address:",
                    .Location = New Point(20, 180),
                    .Size = New Size(80, 25)
                }

                Dim txtAddress As New TextBox() With {
                    .Location = New Point(120, 180),
                    .Size = New Size(250, 60),
                    .Multiline = True
                }

                Dim btnSaveCustomer As New Button() With {
                    .Text = "Save Customer",
                    .Location = New Point(120, 260),
                    .Size = New Size(120, 30)
                }

                Dim btnCancelCustomer As New Button() With {
                    .Text = "Cancel",
                    .Location = New Point(250, 260),
                    .Size = New Size(100, 30)
                }

                AddHandler btnSaveCustomer.Click, Sub(sender2 As Object, e2 As EventArgs)
                                                      If ValidateNewCustomer(txtFirstName, txtLastName, txtContact, txtAddress) Then
                                                          Dim newCustomerId As Integer = SaveNewCustomer(txtFirstName.Text, txtLastName.Text,
                                                                                                       txtContact.Text, txtEmail.Text, txtAddress.Text)
                                                          If newCustomerId > 0 Then
                                                              LoadCustomers(cmbCustomer)
                                                              For i As Integer = 0 To cmbCustomer.Items.Count - 1
                                                                  If CType(cmbCustomer.Items(i), DataRowView)("customer_id").ToString() = newCustomerId.ToString() Then
                                                                      cmbCustomer.SelectedIndex = i
                                                                      Exit For
                                                                  End If
                                                              Next
                                                              newCustomerForm.DialogResult = DialogResult.OK
                                                              newCustomerForm.Close()
                                                          End If
                                                      End If
                                                  End Sub

                AddHandler btnCancelCustomer.Click, Sub(sender2 As Object, e2 As EventArgs)
                                                        newCustomerForm.DialogResult = DialogResult.Cancel
                                                        newCustomerForm.Close()
                                                    End Sub

                newCustomerForm.Controls.AddRange({
                    lblFirstName, txtFirstName, lblLastName, txtLastName,
                    lblContact, txtContact, lblEmail, txtEmail,
                    lblAddress, txtAddress, btnSaveCustomer, btnCancelCustomer
                })

                newCustomerForm.ShowDialog()
            End Using

        Catch ex As Exception
            MessageBox.Show("Error showing new customer form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function ValidateNewCustomer(txtFirstName As TextBox, txtLastName As TextBox, txtContact As TextBox, txtAddress As TextBox) As Boolean

        If String.IsNullOrWhiteSpace(txtFirstName.Text) Then
            MessageBox.Show("Please enter first name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtLastName.Text) Then
            MessageBox.Show("Please enter last name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtContact.Text) Then
            MessageBox.Show("Please enter contact number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtAddress.Text) Then
            MessageBox.Show("Please enter address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True

    End Function

    Private Function SaveNewCustomer(firstName As String, lastName As String, contact As String, email As String, address As String) As Integer

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Dim query As String = "INSERT INTO customer (first_name, last_name, contact_number, email, installation_address, date_registered) " &
                                      "VALUES (@firstName, @lastName, @contact, @email, @address, NOW()); SELECT LAST_INSERT_ID();"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@firstName", firstName)
                    cmd.Parameters.AddWithValue("@lastName", lastName)
                    cmd.Parameters.AddWithValue("@contact", contact)
                    cmd.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(email), DBNull.Value, email))
                    cmd.Parameters.AddWithValue("@address", address)

                    Dim newId As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    MessageBox.Show("Customer added successfully! Customer ID: " & newId, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return newId
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error saving new customer: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try

    End Function

    Private Sub SaveNewInstallation(customerId As Object, address As String, technicianName As String, status As String, installDate As DateTime)

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim staffId As Object = DBNull.Value

                If Not String.IsNullOrEmpty(technicianName) AndAlso technicianName <> "(Not Assigned)" Then
                    Dim getStaffIdQuery As String = "SELECT staff_id FROM staff WHERE CONCAT(first_name, ' ', last_name) = @technicianName AND position = 'Technician'"
                    Using getCmd As New MySqlCommand(getStaffIdQuery, conn)
                        getCmd.Parameters.AddWithValue("@technicianName", technicianName)
                        Dim result = getCmd.ExecuteScalar()
                        If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                            staffId = result
                        End If
                    End Using
                End If

                Dim updateAddressQuery As String = "UPDATE customer SET installation_address = @address WHERE customer_id = @customerId"
                Using updateCmd As New MySqlCommand(updateAddressQuery, conn)
                    updateCmd.Parameters.AddWithValue("@address", address)
                    updateCmd.Parameters.AddWithValue("@customerId", customerId)
                    updateCmd.ExecuteNonQuery()
                End Using

                Dim query As String = "INSERT INTO service (customer_id, staff_id, service_type, status, date_requested) " &
                                      "VALUES (@customerId, @staffId, 'Installation', @status, @dateRequested)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@customerId", customerId)
                    cmd.Parameters.AddWithValue("@staffId", staffId)
                    cmd.Parameters.AddWithValue("@status", status)
                    cmd.Parameters.AddWithValue("@dateRequested", installDate)

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("New installation added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error saving new installation: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ClearCheckboxes()

        For Each row As DataGridViewRow In DataGridInstallationDetails.Rows
            If Not row.IsNewRow Then
                row.Cells("checkbox").Value = False
            End If
        Next
        selectedServiceIds.Clear()

    End Sub

    Private Sub EditInstallation(serviceId As Integer, rowIndex As Integer)

        Try

            Dim row As DataGridViewRow = DataGridInstallationDetails.Rows(rowIndex)

            Dim customer As String = ""
            If row.Cells("Customer").Value IsNot Nothing Then
                customer = row.Cells("Customer").Value.ToString()
            End If

            Dim address As String = ""
            If row.Cells("Address").Value IsNot Nothing Then
                address = row.Cells("Address").Value.ToString()
            End If

            Dim status As String = "Requested"
            If row.Cells("Status").Value IsNot Nothing Then
                status = row.Cells("Status").Value.ToString()
            End If

            Dim technician As String = ""
            If row.Cells("Technician").Value IsNot Nothing Then
                technician = row.Cells("Technician").Value.ToString()
            End If

            Dim dateReq As String = ""
            If row.Cells("DateRequested").Value IsNot Nothing Then
                Dim dVal As DateTime
                If DateTime.TryParse(row.Cells("DateRequested").Value.ToString(), dVal) Then
                    dateReq = dVal.ToString("yyyy-MM-dd")
                End If
            End If


            Using updateForm As New frmInstallationUpdate()

                updateForm.SelectedServiceID = serviceId
                updateForm.CustomerName = customer
                updateForm.Address = address
                updateForm.Status = status
                updateForm.Technician = technician
                updateForm.DateRequestedStr = dateReq

                If updateForm.ShowDialog(Me) = DialogResult.OK Then
                    LoadInstallationDetailsGrid()
                    LoadInstallationStatusChart()
                End If

            End Using

        Catch ex As Exception
            MessageBox.Show("Error opening update form. Check Column Names in Designer." & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    'FOR PAGING
    Private Sub btnNextInstallationSA_Click(sender As Object, e As EventArgs) Handles btnNextInstallationSA.Click

        Dim totalPages As Integer = CInt(Math.Ceiling(totalRecords / PAGE_SIZE))

        If currentPageIndex < totalPages - 1 Then
            currentPageIndex += 1
            LoadInstallationDetailsGrid()
        End If

    End Sub

    Private Sub btnSalesPreviousSA_Click(sender As Object, e As EventArgs) Handles btnInstallationPrevious.Click

        If currentPageIndex > 0 Then
            currentPageIndex -= 1
            LoadInstallationDetailsGrid()
        End If

    End Sub

    Private Sub UpdatePaginationControls()

        Dim totalPages As Integer = CInt(Math.Ceiling(totalRecords / PAGE_SIZE))

        btnInstallationPrevious.Enabled = currentPageIndex > 0
        btnInstallationPrevious.Visible = currentPageIndex > 0

        btnNextInstallationSA.Enabled = currentPageIndex < totalPages - 1

        If Me.Controls.Find("lblPageInfo", True).Length > 0 Then
            Dim lblPageInfo As Label = CType(Me.Controls.Find("lblPageInfo", True)(0), Label)
            If totalRecords > 0 Then
                lblPageInfo.Text = $"Page {currentPageIndex + 1} of {totalPages} (Total: {totalRecords})"
            Else
                lblPageInfo.Text = "No Records Found"
            End If
        End If

    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        LoadInstallationStatusChart()

        If String.IsNullOrWhiteSpace(txtInstallationSearchSA.Text) Then
            LoadInstallationDetailsGrid()
        End If

    End Sub

    Private Function FindControlRecursive(root As Control, id As String) As Control

        If root.Name = id Then
            Return root
        End If
        For Each c As Control In root.Controls
            Dim t As Control = FindControlRecursive(c, id)
            If t IsNot Nothing Then
                Return t
            End If
        Next
        Return Nothing

    End Function

    Private Sub EnableDoubleBuffering(dgv As DataGridView)
        Try
            Dim dgvType As Type = dgv.GetType()
            Dim pi As Reflection.PropertyInfo = dgvType.GetProperty("DoubleBuffered",
            Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
            If pi IsNot Nothing Then
                pi.SetValue(dgv, True, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Overrides Sub OnHandleDestroyed(e As EventArgs)
        If updateTimer IsNot Nothing Then
            updateTimer.Stop()
            updateTimer.Dispose()
        End If
        MyBase.OnHandleDestroyed(e)
    End Sub

    Private Sub installationview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ComboBox1.SelectedIndex = 0
        Me.ComboBox3.SelectedIndex = 0

        CreateCharts()
        LoadInstallationStatusChart()

        If DataGridInstallationDetails IsNot Nothing Then
            DataGridInstallationDetails.AutoGenerateColumns = False
            DataGridInstallationDetails.DataSource = installationBindingSource

            DataGridInstallationDetails.RowTemplate.Height = 45
            DataGridInstallationDetails.RowTemplate.MinimumHeight = 40
            DataGridInstallationDetails.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            DataGridInstallationDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

            DataGridInstallationDetails.DefaultCellStyle.WrapMode = DataGridViewTriState.False

            EnableDoubleBuffering(DataGridInstallationDetails)

            AddHandler DataGridInstallationDetails.CellValueChanged, AddressOf DataGridInstallationDetails_CellValueChanged
        End If

        LoadInstallationDetailsGrid()

        updateTimer = New Timer()
        updateTimer.Interval = 30000 ' 30 seconds
        AddHandler updateTimer.Tick, AddressOf Timer_Tick
        updateTimer.Start()

        If btnSelectInstallation IsNot Nothing Then
            AddHandler btnSelectInstallation.Click, AddressOf btnSelectInstallation_Click
        End If


    End Sub

    Private Sub btnSelectInstallation_Click(sender As Object, e As EventArgs)

        Dim allSelected As Boolean = True

        For Each row As DataGridViewRow In DataGridInstallationDetails.Rows
            If Not row.IsNewRow Then
                If Not CBool(row.Cells("checkbox").Value) Then
                    allSelected = False
                    Exit For
                End If
            End If
        Next

        For Each row As DataGridViewRow In DataGridInstallationDetails.Rows
            If Not row.IsNewRow Then
                row.Cells("checkbox").Value = Not allSelected
            End If
        Next

        If Not allSelected Then
            selectedServiceIds.Clear()
            For Each row As DataGridViewRow In DataGridInstallationDetails.Rows
                If Not row.IsNewRow Then
                    Dim serviceId As Integer = Convert.ToInt32(row.Cells("ServiceID").Value)
                    selectedServiceIds.Add(serviceId)
                End If
            Next
        Else
            selectedServiceIds.Clear()
        End If

        UpdateSelectionUI()

    End Sub

End Class