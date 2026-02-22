Imports LiveCharts
Imports LiveCharts.Wpf
Imports System.Configuration
Imports MySqlConnector
Imports System.Drawing
Imports System.Windows.Media
Imports System.Collections.Generic
Imports LiveCharts.WinForms
Imports Color = System.Drawing.Color
Imports System.ComponentModel
Imports System.Data
Imports System.Windows.Forms

Public Class subscriberview
    Inherits UserControl

    Private ChartSubscribersByPlan As LiveCharts.WinForms.PieChart
    Private ChartAccountStatus As LiveCharts.WinForms.PieChart

    ' --- Pagination Variables ---
    Private Const PAGE_SIZE As Integer = 25
    Private currentPageIndex As Integer = 0
    Private totalRecords As Integer = 0

    ' Add this to track selected IDs
    Private selectedSubscriberIds As New List(Of Integer)()

    ' --- Connection String ---
    Private _connectionString As String = Nothing
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

    ' --- Timers ---
    Private updateTimer As Timer
    Private searchTimer As Timer

    Public Sub New()
        InitializeComponent()
        InitializeSearchTimer()
    End Sub

    Private Sub InitializeSearchTimer()
        searchTimer = New Timer()
        searchTimer.Interval = 500
        AddHandler searchTimer.Tick, AddressOf SearchTimer_Tick
    End Sub

    Private Sub SearchTimer_Tick(sender As Object, e As EventArgs)
        searchTimer.Stop()
        LoadSubscriberData()
    End Sub

    Private Sub subscriberview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            PopulateDropdowns()
            Me.CBPlanType.SelectedIndex = 0
            Me.CBAccStat.SelectedIndex = 0

            CreateCharts()
            LoadChartsData()
            UpdateSubscriberLabels()
            LoadSubscriberData()

            updateTimer = New Timer()
            updateTimer.Interval = 30000
            AddHandler updateTimer.Tick, AddressOf Timer_Tick
            updateTimer.Start()
        Catch ex As Exception
            MessageBox.Show("Error loading subscriber view: " & ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PopulateDropdowns()
        Me.CBPlanType.Items.Clear()
        Me.CBPlanType.Items.Add("All Plans")
        Me.CBPlanType.Items.AddRange(New String() {"Basic", "Standard", "Premium"})

        Me.CBAccStat.Items.Clear()
        Me.CBAccStat.Items.Add("All Status")
        Me.CBAccStat.Items.AddRange(New String() {"Active", "Suspended"})

        Me.ComboBoxDate.Items.Clear()
        Me.ComboBoxDate.Items.Add("All Time")
        Me.ComboBoxDate.Items.AddRange(New String() {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        })
        Me.ComboBoxDate.SelectedIndex = 0
    End Sub

    ' =========================================================================================
    '  DATA LOADING
    ' =========================================================================================
    Private Sub LoadSubscriberData()
        totalRecords = GetTotalSubscriberCount()
        Dim totalPages As Integer = If(totalRecords > 0, CInt(Math.Ceiling(totalRecords / PAGE_SIZE)), 0)
        If currentPageIndex >= totalPages Then currentPageIndex = Math.Max(0, totalPages - 1)

        Dim offset As Integer = currentPageIndex * PAGE_SIZE

        Try
            dgvSubsDeets.AutoGenerateColumns = False
            Dim dt As New DataTable()

            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Dim query As New System.Text.StringBuilder()

                query.Append("SELECT customer_id AS CustomerID, ")
                query.Append("CONCAT(first_name, ' ', last_name) AS Name, ")

                ' --- FIX: REMOVED LANDMARK FROM CONCATENATION ---
                ' New format: Purok, Barangay, Municipality, Province
                query.Append("CONCAT_WS(', ', purok, barangay, municipality, province) AS Address, ")

                query.Append("plan_type AS PlanType, ")
                query.Append("monthly_rate AS MonthlyRate, DATE_FORMAT(date_installed, '%m/%d/%Y') AS DateInstalled, ")

                query.Append("account_status AS Status FROM customer_data WHERE is_deleted = 0 ") ' <--- ADDED CONDITION

                ' --- Filters ---
                If CBPlanType.SelectedIndex > 0 Then query.Append(" AND plan_type = @planType")
                If CBAccStat.SelectedIndex > 0 Then query.Append(" AND account_status = @accountStatus")

                Dim searchText As String = txtSubscriberSearchSA.Text.Trim()
                If Not String.IsNullOrWhiteSpace(searchText) Then
                    ' Using LPAD(customer_id, 5, '0') allows matching padded inputs like 00001
                    query.Append(" AND (customer_id LIKE @search " &
                 " OR LPAD(customer_id, 5, '0') LIKE @search " &
                 " OR CONCAT(first_name, ' ', last_name) LIKE @search " &
                 " OR DATE_FORMAT(date_installed, '%m/%d/%Y') LIKE @search)")
                End If

                If ComboBoxDate.SelectedIndex > 0 Then
                    query.Append(" AND MONTH(date_installed) = @month AND YEAR(date_installed) = @year")
                End If

                query.Append(" ORDER BY date_installed DESC LIMIT @offset, @limit")

                Using cmd As New MySqlCommand(query.ToString(), conn)
                    cmd.Parameters.AddWithValue("@offset", offset)
                    cmd.Parameters.AddWithValue("@limit", PAGE_SIZE)

                    If CBPlanType.SelectedIndex > 0 Then cmd.Parameters.AddWithValue("@planType", CBPlanType.SelectedItem.ToString())
                    If CBAccStat.SelectedIndex > 0 Then cmd.Parameters.AddWithValue("@accountStatus", CBAccStat.SelectedItem.ToString())
                    If Not String.IsNullOrWhiteSpace(searchText) Then cmd.Parameters.AddWithValue("@search", "%" & searchText & "%")
                    If ComboBoxDate.SelectedIndex > 0 Then
                        cmd.Parameters.AddWithValue("@month", ComboBoxDate.SelectedIndex)
                        cmd.Parameters.AddWithValue("@year", DateTime.Now.Year)
                    End If

                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using

            dgvSubsDeets.DataSource = dt
            UpdatePaginationControls()

        Catch ex As Exception
            MessageBox.Show("Error loading subscriber data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LoadMockData()
        End Try
    End Sub

    ' =========================================================================================
    '  EDIT BUTTON LOGIC
    ' =========================================================================================
    Private Sub dgvSubsDeets_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSubsDeets.CellContentClick
        If e.RowIndex < 0 Then Exit Sub

        Dim columnName As String = dgvSubsDeets.Columns(e.ColumnIndex).Name
        Dim subscriberID As Object = Nothing

        Dim row As DataGridViewRow = dgvSubsDeets.Rows(e.RowIndex)
        Dim drv As DataRowView = TryCast(row.DataBoundItem, DataRowView)

        If drv Is Nothing Then Exit Sub

        If drv.Row.Table.Columns.Contains("CustomerID") AndAlso Not IsDBNull(drv("CustomerID")) Then
            subscriberID = drv("CustomerID")
        ElseIf drv.Row.Table.Columns.Contains("customer_id") AndAlso Not IsDBNull(drv("customer_id")) Then
            subscriberID = drv("customer_id")
        End If

        Select Case columnName
            Case "colEditIcon"
                If subscriberID Is Nothing OrElse Not IsNumeric(subscriberID) Then
                    MessageBox.Show("Could not retrieve a valid Subscriber ID.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim updateForm As New frmSubscriberUpdate()
                updateForm.SubscriberID = CInt(subscriberID)

                If updateForm.ShowDialog() = DialogResult.OK Then
                    LoadSubscriberData()
                    LoadChartsData()
                    UpdateSubscriberLabels()
                End If

            Case "colDeleteIcon"
                If subscriberID Is Nothing OrElse Not IsNumeric(subscriberID) Then
                    MessageBox.Show("Could not retrieve a valid Subscriber ID for deletion.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim result = MessageBox.Show($"Are you sure you want to delete Subscriber ID: {subscriberID}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                If result = DialogResult.Yes Then
                    Try
                        Using conn As New MySqlConnection(CONNECTION_STRING)
                            conn.Open()
                            ' --- CHANGED TO SOFT DELETE ---
                            Dim deleteQuery As String = "UPDATE customer_data SET is_deleted = 1 WHERE customer_id = @customerID"
                            ' ------------------------------

                            Using cmd As New MySqlCommand(deleteQuery, conn)
                                cmd.Parameters.AddWithValue("@customerID", CInt(subscriberID))
                                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                                If rowsAffected > 0 Then
                                    MessageBox.Show($"Subscriber ID: {subscriberID} deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    LoadSubscriberData()
                                    LoadChartsData()
                                    UpdateSubscriberLabels()
                                Else
                                    MessageBox.Show($"Subscriber ID: {subscriberID} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End Using
                        End Using
                    Catch ex As Exception
                        MessageBox.Show($"Error deleting subscriber: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If

            Case "colSelect"
                If subscriberID IsNot Nothing Then
                    Dim cell As DataGridViewCheckBoxCell = TryCast(dgvSubsDeets.Rows(e.RowIndex).Cells("colSelect"), DataGridViewCheckBoxCell)
                    If cell IsNot Nothing Then
                        Dim current As Boolean = False
                        If cell.Value IsNot Nothing AndAlso Not IsDBNull(cell.Value) Then
                            Try
                                current = CBool(cell.Value)
                            Catch
                                current = False
                            End Try
                        End If
                        cell.Value = Not current
                    End If
                End If
        End Select
    End Sub

    ' --- Chart and Label Logic (Standard) ---

    Public Sub UpdateSubscriberLabels()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim whereClause As New System.Text.StringBuilder(" WHERE 1=1 ")
                If CBPlanType.SelectedIndex > 0 Then whereClause.Append(" AND plan_type = @planType ")
                If CBAccStat.SelectedIndex > 0 Then whereClause.Append(" AND account_status = @accountStatus ")
                If ComboBoxDate.SelectedIndex > 0 Then whereClause.Append(" AND MONTH(date_installed) = @month AND YEAR(date_installed) = @year ")

                Dim addParams As Action(Of MySqlCommand) = Sub(cmd As MySqlCommand)
                                                               If CBPlanType.SelectedIndex > 0 Then cmd.Parameters.AddWithValue("@planType", CBPlanType.SelectedItem.ToString())
                                                               If CBAccStat.SelectedIndex > 0 Then cmd.Parameters.AddWithValue("@accountStatus", CBAccStat.SelectedItem.ToString())
                                                               If ComboBoxDate.SelectedIndex > 0 Then
                                                                   cmd.Parameters.AddWithValue("@month", ComboBoxDate.SelectedIndex)
                                                                   cmd.Parameters.AddWithValue("@year", DateTime.Now.Year)
                                                               End If
                                                           End Sub

                Dim totalQuery As String = "SELECT COUNT(*) FROM customer_data" & whereClause.ToString() & " AND is_deleted = 0"
                Using cmd As New MySqlCommand(totalQuery, conn)
                    addParams(cmd)
                    Dim totalSubs As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    totalSub.Text = totalSubs.ToString("N0")
                End Using

                Dim activeQuery As String = "SELECT COUNT(*) FROM customer_data" & whereClause.ToString() & " AND account_status = 'Active'"
                Using cmd As New MySqlCommand(activeQuery, conn)
                    addParams(cmd)
                    Dim activeCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    ActiveSubs.Text = activeCount.ToString("N0")
                End Using

                Dim revenueQuery As String = "SELECT COALESCE(SUM(p.amount_paid), 0) FROM payment p INNER JOIN customer_data c ON p.customer_id = c.customer_id WHERE MONTH(p.date_of_payment) = MONTH(CURDATE()) AND YEAR(p.date_of_payment) = YEAR(CURDATE())"
                If CBPlanType.SelectedIndex > 0 Then revenueQuery &= " AND c.plan_type = @planType"
                If CBAccStat.SelectedIndex > 0 Then revenueQuery &= " AND c.account_status = @accountStatus"
                If ComboBoxDate.SelectedIndex > 0 Then revenueQuery &= " AND MONTH(c.date_installed) = @month AND YEAR(c.date_installed) = @year"

                Using cmd As New MySqlCommand(revenueQuery, conn)
                    addParams(cmd)
                    Dim monthlyRevenue As Decimal = Convert.ToDecimal(cmd.ExecuteScalar())
                    monthlyRevenues.Text = "₱" & monthlyRevenue.ToString("N2")
                End Using

                Dim avgQuery As String = "SELECT COALESCE(AVG(p.amount_paid), 0) FROM payment p INNER JOIN customer_data c ON p.customer_id = c.customer_id WHERE MONTH(p.date_of_payment) = MONTH(CURDATE()) AND YEAR(p.date_of_payment) = YEAR(CURDATE())"
                If CBPlanType.SelectedIndex > 0 Then avgQuery &= " AND c.plan_type = @planType"
                If CBAccStat.SelectedIndex > 0 Then avgQuery &= " AND c.account_status = @accountStatus"
                If ComboBoxDate.SelectedIndex > 0 Then avgQuery &= " AND MONTH(c.date_installed) = @month AND YEAR(c.date_installed) = @year"

                Using cmd As New MySqlCommand(avgQuery, conn)
                    addParams(cmd)
                    Dim avgRevenue As Decimal = Convert.ToDecimal(cmd.ExecuteScalar())
                    AvgRev.Text = "₱" & avgRevenue.ToString("N2")
                End Using
            End Using
        Catch ex As Exception
            totalSub.Text = "0"
            ActiveSubs.Text = "0"
            monthlyRevenues.Text = "₱0.00"
            AvgRev.Text = "₱0.00"
        End Try
    End Sub

    Private Sub LoadMockData()
        dgvSubsDeets.AutoGenerateColumns = False
        Dim dt As New DataTable()
        dt.Columns.Add("CustomerID", GetType(Integer))
        dt.Columns.Add("Name", GetType(String))
        dt.Columns.Add("Address", GetType(String))
        dt.Columns.Add("PlanType", GetType(String))
        dt.Columns.Add("MonthlyRate", GetType(Decimal))
        dt.Columns.Add("DateInstalled", GetType(DateTime))
        dt.Columns.Add("Status", GetType(String))
        dt.Columns.Add("IsSelected", GetType(Boolean))

        dt.Rows.Add(101, "Ann Dominique C. Estrada", "Basud, Camarines Norte", "Basic", 700D, New DateTime(2025, 1, 15), "Active", False)
        dt.Rows.Add(102, "Donato Antonio Pangilinan", "Daet, Camarines Norte", "Standard", 1000D, New DateTime(2025, 1, 22), "Suspended", True)
        dgvSubsDeets.DataSource = dt
    End Sub

    Private Sub CreateCharts()
        Try
            ChartSubscribersByPlan = New LiveCharts.WinForms.PieChart()
            ChartSubscribersByPlan.Dock = DockStyle.Fill
            ChartSubscribersByPlan.BackColor = Color.White
            ChartSubscribersByPlan.LegendLocation = LegendLocation.None
            Panel1.Controls.Clear()
            Panel1.Controls.Add(ChartSubscribersByPlan)
            ChartSubscribersByPlan.BringToFront()

            ChartAccountStatus = New LiveCharts.WinForms.PieChart()
            ChartAccountStatus.Dock = DockStyle.Fill
            ChartAccountStatus.BackColor = Color.White
            ChartAccountStatus.LegendLocation = LegendLocation.None
            Panel2.Controls.Clear()
            Panel2.Controls.Add(ChartAccountStatus)
            ChartAccountStatus.BringToFront()

            InitializeChartSeries()
        Catch ex As Exception
            MessageBox.Show("Error creating charts: " & ex.Message, "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeChartSeries()
        If ChartSubscribersByPlan IsNot Nothing Then ChartSubscribersByPlan.Series = New SeriesCollection()
        If ChartAccountStatus IsNot Nothing Then ChartAccountStatus.Series = New SeriesCollection()
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        LoadChartsData()
        UpdateSubscriberLabels()
    End Sub

    Private Sub LoadChartsData()
        Try
            LoadSubscribersByPlanChart()
            LoadAccountStatusChart()
        Catch ex As Exception
            LoadMockSubscribersByPlanChart()
            LoadMockAccountStatusChart()
        End Try
    End Sub

    Private Sub LoadSubscribersByPlanChart()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Dim query As String = "SELECT plan_type, COUNT(*) AS count FROM customer_data WHERE is_deleted = 0 GROUP BY plan_type"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim planData As New Dictionary(Of String, Integer)()
                        While reader.Read()
                            Dim key = If(reader("plan_type") Is DBNull.Value, "Unknown", reader("plan_type").ToString())
                            planData(key) = Convert.ToInt32(reader("count"))
                        End While
                        If Me.InvokeRequired Then
                            Me.Invoke(New Action(Sub() UpdateSubscribersByPlanChart(planData)))
                        Else
                            UpdateSubscribersByPlanChart(planData)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            LoadMockSubscribersByPlanChart()
        End Try
    End Sub

    Private Sub UpdateSubscribersByPlanChart(planData As Dictionary(Of String, Integer))
        If ChartSubscribersByPlan Is Nothing Then CreateCharts()
        If ChartSubscribersByPlan Is Nothing Then Return

        Dim total As Integer = 0
        For Each value In planData.Values
            total += value
        Next

        Dim pieSeries As New SeriesCollection()

        For Each kvp In planData
            Dim percentage As Double = If(total > 0, (kvp.Value / total) * 100, 0)
            Dim displayText As String = String.Format("{0}: {1} ({2:F0}%)", kvp.Key, kvp.Value, percentage)
            Dim pieSeriesItem As New PieSeries()
            pieSeriesItem.Title = displayText
            pieSeriesItem.Values = New ChartValues(Of Double)({kvp.Value})
            pieSeriesItem.DataLabels = False

            Select Case kvp.Key.ToLower()
                Case "basic" : pieSeriesItem.Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(59, 130, 246))
                Case "standard" : pieSeriesItem.Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(251, 146, 60))
                Case "premium" : pieSeriesItem.Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(34, 197, 94))
                Case Else : pieSeriesItem.Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(156, 163, 175))
            End Select
            pieSeries.Add(pieSeriesItem)
        Next
        ChartSubscribersByPlan.Series = pieSeries
    End Sub

    Private Sub LoadAccountStatusChart()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Dim query As String = "SELECT account_status, COUNT(*) AS count FROM customer_data WHERE is_deleted = 0 GROUP BY account_status"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim statusData As New Dictionary(Of String, Integer)()
                        While reader.Read()
                            Dim status As String = If(reader("account_status") Is DBNull.Value, "Unknown", reader("account_status").ToString())
                            statusData(status) = Convert.ToInt32(reader("count"))
                        End While
                        If Me.InvokeRequired Then
                            Me.Invoke(New Action(Sub() UpdateAccountStatusChart(statusData)))
                        Else
                            UpdateAccountStatusChart(statusData)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            LoadMockAccountStatusChart()
        End Try
    End Sub

    Private Sub UpdateAccountStatusChart(statusData As Dictionary(Of String, Integer))
        If ChartAccountStatus Is Nothing Then CreateCharts()
        If ChartAccountStatus Is Nothing Then Return

        Dim total As Integer = 0
        For Each value In statusData.Values
            total += value
        Next

        Dim pieSeries As New SeriesCollection()
        For Each kvp In statusData
            Dim percentage As Double = If(total > 0, (kvp.Value / total) * 100, 0)
            Dim displayText As String = String.Format("{0}: {1} ({2:F0}%)", kvp.Key, kvp.Value, percentage)
            Dim pieSeriesItem As New PieSeries()
            pieSeriesItem.Title = displayText
            pieSeriesItem.Values = New ChartValues(Of Double)({kvp.Value})
            pieSeriesItem.DataLabels = False

            Select Case kvp.Key.ToLower()
                Case "active" : pieSeriesItem.Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(34, 197, 94))
                Case "suspended" : pieSeriesItem.Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(251, 146, 60))
                Case "cancelled" : pieSeriesItem.Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(239, 68, 68))
                Case Else : pieSeriesItem.Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(156, 163, 175))
            End Select
            pieSeries.Add(pieSeriesItem)
        Next
        ChartAccountStatus.Series = pieSeries
    End Sub

    Private Sub LoadMockSubscribersByPlanChart()
        Dim mockData As New Dictionary(Of String, Integer)() From {{"Basic", 1250}, {"Standard", 800}, {"Premium", 450}}
        UpdateSubscribersByPlanChart(mockData)
    End Sub

    Private Sub LoadMockAccountStatusChart()
        Dim mockData As New Dictionary(Of String, Integer)() From {{"Active", 2250}, {"Suspended", 150}}
        UpdateAccountStatusChart(mockData)
    End Sub

    Private Sub CBPlanType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBPlanType.SelectedIndexChanged
        LoadSubscriberData()
        LoadChartsData()
        UpdateSubscriberLabels()
    End Sub

    Private Sub CBAccStat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBAccStat.SelectedIndexChanged
        LoadSubscriberData()
        LoadChartsData()
        UpdateSubscriberLabels()
    End Sub

    Private Sub txtSubscriberSearchSA_TextChanged(sender As Object, e As EventArgs) Handles txtSubscriberSearchSA.TextChanged
        If searchTimer IsNot Nothing Then
            If searchTimer.Enabled Then searchTimer.Stop()
            searchTimer.Start()
        End If
    End Sub

    Private Sub btnSubscriberPreviousSA_Click(sender As Object, e As EventArgs) Handles btnSubscriberPreviousSA.Click
        If currentPageIndex > 0 Then
            currentPageIndex -= 1
            LoadSubscriberData()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim totalPages As Integer = CInt(Math.Ceiling(totalRecords / PAGE_SIZE))
        If currentPageIndex < totalPages - 1 Then
            currentPageIndex += 1
            LoadSubscriberData()
        End If
    End Sub

    Private Sub UpdatePaginationControls()
        Dim totalPages As Integer = CInt(Math.Ceiling(totalRecords / PAGE_SIZE))
        btnSubscriberPreviousSA.Enabled = currentPageIndex > 0
        btnSubscriberPreviousSA.Visible = currentPageIndex > 0
        btnNext.Enabled = currentPageIndex < totalPages - 1
        If Me.Controls.Find("lblPageInfo", True).Length > 0 Then
            Dim lblPageInfo As Label = CType(Me.Controls.Find("lblPageInfo", True)(0), Label)
            If totalRecords > 0 Then
                lblPageInfo.Text = $"Page {currentPageIndex + 1} of {totalPages} (Total: {totalRecords})"
            Else
                lblPageInfo.Text = "No Records Found"
            End If
        End If
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "CSV Files (*.csv)|*.csv"
            saveDialog.Title = "Export Subscriber Report"
            saveDialog.FileName = "Subscriber_Report_" & DateTime.Now.ToString("yyyyMMdd_HHmmss")
            If saveDialog.ShowDialog() = DialogResult.OK Then
                ExportToCSV(saveDialog.FileName)
                MessageBox.Show("Report exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error exporting report: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportToCSV(filePath As String)
        Dim dt As DataTable = TryCast(dgvSubsDeets.DataSource, DataTable)
        If dt Is Nothing Then
            MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Using writer As New System.IO.StreamWriter(filePath)
            Dim headers As New List(Of String)()
            For Each column As DataGridViewColumn In dgvSubsDeets.Columns
                If column.Visible AndAlso column.Name <> "colEditIcon" AndAlso column.Name <> "colDeleteIcon" AndAlso column.Name <> "colSelect" Then
                    headers.Add(column.HeaderText)
                End If
            Next
            writer.WriteLine(String.Join(",", headers))
            For Each row As DataGridViewRow In dgvSubsDeets.Rows
                If Not row.IsNewRow Then
                    Dim values As New List(Of String)()
                    For Each column As DataGridViewColumn In dgvSubsDeets.Columns
                        If column.Visible AndAlso column.Name <> "colEditIcon" AndAlso column.Name <> "colDeleteIcon" AndAlso column.Name <> "colSelect" Then
                            Dim value As Object = row.Cells(column.Name).Value
                            Dim stringValue As String = If(value Is Nothing, "", value.ToString())
                            If stringValue.Contains(",") OrElse stringValue.Contains("""") Then
                                stringValue = """" & stringValue.Replace("""", """""") & """"
                            End If
                            values.Add(stringValue)
                        End If
                    Next
                    writer.WriteLine(String.Join(",", values))
                End If
            Next
        End Using
    End Sub

    Private Sub btnSelectSubscriber_Click(sender As Object, e As EventArgs) Handles btnSelectSubscriber.Click
        ' 1. Check current state (Select or Deselect?)
        Dim shouldSelect As Boolean = False

        For Each row As DataGridViewRow In dgvSubsDeets.Rows
            If Not row.IsNewRow Then
                Dim isChecked As Boolean = False
                If row.Cells("colSelect").Value IsNot Nothing Then
                    isChecked = CBool(row.Cells("colSelect").Value)
                End If

                If Not isChecked Then
                    shouldSelect = True
                    Exit For
                End If
            End If
        Next

        ' 2. Pause Events
        RemoveHandler dgvSubsDeets.CellValueChanged, AddressOf dgvSubsDeets_CellValueChanged

        ' 3. Update Visuals and List
        selectedSubscriberIds.Clear()

        For Each row As DataGridViewRow In dgvSubsDeets.Rows
            If Not row.IsNewRow Then
                ' Update Visual Checkbox
                row.Cells("colSelect").Value = shouldSelect

                ' Update List if Selecting
                If shouldSelect Then
                    ' --- FIX IS HERE: Use DataBoundItem instead of Cells("Name") ---
                    Dim drv As DataRowView = TryCast(row.DataBoundItem, DataRowView)
                    If drv IsNot Nothing Then
                        ' accessing the "CustomerID" from the database source directly
                        Dim id As Integer = Convert.ToInt32(drv("CustomerID"))
                        selectedSubscriberIds.Add(id)
                    End If
                End If
            End If
        Next

        ' 4. Resume Events
        AddHandler dgvSubsDeets.CellValueChanged, AddressOf dgvSubsDeets_CellValueChanged
    End Sub
    Private Function GetTotalSubscriberCount() As Integer
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                ' --- UPDATED TABLE NAME ---
                Dim query As New System.Text.StringBuilder("SELECT COUNT(*) FROM customer_data WHERE is_deleted = 0 ")
                Dim searchText As String = txtSubscriberSearchSA.Text.Trim()
                If CBPlanType.SelectedIndex > 0 Then query.Append(" AND plan_type = @planType")
                If CBAccStat.SelectedIndex > 0 Then query.Append(" AND account_status = @accountStatus")
                If Not String.IsNullOrWhiteSpace(searchText) Then
                    query.Append(" AND (customer_id LIKE @search " &
                 " OR LPAD(customer_id, 5, '0') LIKE @search " &
                 " OR CONCAT(first_name, ' ', last_name) LIKE @search " &
                 " OR DATE_FORMAT(date_installed, '%m/%d/%Y') LIKE @search)")
                End If
                If ComboBoxDate.SelectedIndex > 0 Then
                    query.Append(" AND MONTH(date_installed) = @month AND YEAR(date_installed) = @year")
                End If
                Using cmd As New MySqlCommand(query.ToString(), conn)
                    If CBPlanType.SelectedIndex > 0 Then cmd.Parameters.AddWithValue("@planType", CBPlanType.SelectedItem.ToString())
                    If CBAccStat.SelectedIndex > 0 Then cmd.Parameters.AddWithValue("@accountStatus", CBAccStat.SelectedItem.ToString())
                    If Not String.IsNullOrWhiteSpace(searchText) Then cmd.Parameters.AddWithValue("@search", "%" & searchText & "%")
                    If ComboBoxDate.SelectedIndex > 0 Then
                        cmd.Parameters.AddWithValue("@month", ComboBoxDate.SelectedIndex)
                        cmd.Parameters.AddWithValue("@year", DateTime.Now.Year)
                    End If
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch
            Return 0
        End Try
    End Function

    Private Sub ComboBoxDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDate.SelectedIndexChanged
        currentPageIndex = 0
        LoadSubscriberData()
        UpdateSubscriberLabels()
        LoadChartsData()
    End Sub

    Private Sub dgvSubsDeets_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvSubsDeets.CellFormatting
        If e.RowIndex < 0 Then Return

        Dim colName As String = dgvSubsDeets.Columns(e.ColumnIndex).Name

        ' TARGET: colCustomerID (Visual Padding to 00001)
        If colName = "colCustomerID" Then
            If e.Value IsNot Nothing AndAlso IsNumeric(e.Value) Then
                ' D5 converts the number 12 into the string "00012"
                e.Value = Convert.ToInt32(e.Value).ToString("D5")
                e.FormattingApplied = True
            End If
        End If

        ' Existing Alignment Logic for Monthly Rate
        If colName = "colMonthlyRate" OrElse colName = "MonthlyRate" Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If IsNumeric(e.Value) Then
                e.Value = String.Format("₱{0:N2}", e.Value)
                e.FormattingApplied = True
            End If
        End If

        ' Existing Date Formatting
        If colName = "colDateInstalled" OrElse colName = "DateInstalled" Then
            If e.Value IsNot Nothing AndAlso TypeOf e.Value Is Date Then
                Dim dateValue As Date = CType(e.Value, Date)
                e.Value = If(dateValue <> Date.MinValue, dateValue.ToString("MM/dd/yyyy"), "N/A")
                e.FormattingApplied = True
            End If
        End If
    End Sub


    Private Sub deleteAll_Click(sender As Object, e As EventArgs) Handles deleteAll.Click
        Dim idsToDelete As New List(Of Integer)()

        ' 1. Collect Selected IDs
        For Each row As DataGridViewRow In dgvSubsDeets.Rows
            If Not row.IsNewRow Then
                Dim isChecked As Boolean = False
                If row.Cells("colSelect").Value IsNot Nothing Then
                    isChecked = CBool(row.Cells("colSelect").Value)
                End If

                If isChecked Then
                    Dim drv As DataRowView = TryCast(row.DataBoundItem, DataRowView)
                    If drv IsNot Nothing Then
                        If drv.Row.Table.Columns.Contains("CustomerID") Then
                            idsToDelete.Add(Convert.ToInt32(drv("CustomerID")))
                        End If
                    End If
                End If
            End If
        Next

        ' 2. Validation
        If idsToDelete.Count = 0 Then
            MessageBox.Show("Please select at least one subscriber to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' 3. Confirmation (Updated message since we aren't hard deleting history anymore)
        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete the {idsToDelete.Count} selected subscriber(s)?" & vbCrLf & vbCrLf &
                                                     "These accounts will be moved to the archive.",
                                                     "Confirm Bulk Delete",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Dim transaction As MySqlTransaction = conn.BeginTransaction()

                Try
                    Dim paramNames As New List(Of String)
                    For i As Integer = 0 To idsToDelete.Count - 1
                        paramNames.Add("@id" & i)
                    Next
                    Dim inClause As String = String.Join(",", paramNames)

                    Dim deleteCustomerQuery As String = $"UPDATE customer_data SET is_deleted = 1 WHERE customer_id IN ({inClause})"

                    Using cmdCustomer As New MySqlCommand(deleteCustomerQuery, conn, transaction)
                        For i As Integer = 0 To idsToDelete.Count - 1
                            cmdCustomer.Parameters.AddWithValue("@id" & i, idsToDelete(i))
                        Next

                        Dim rowsAffected As Integer = cmdCustomer.ExecuteNonQuery()
                        transaction.Commit()

                        MessageBox.Show($"{rowsAffected} subscriber(s) successfully archived.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Reset and Refresh
                        selectedSubscriberIds.Clear()
                        LoadSubscriberData()
                        LoadChartsData()
                        UpdateSubscriberLabels()
                    End Using

                Catch ex As Exception
                    transaction.Rollback()
                    MessageBox.Show("Error processing request: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End If
    End Sub

    Private Sub dgvSubsDeets_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvSubsDeets.CurrentCellDirtyStateChanged
        If dgvSubsDeets.IsCurrentCellDirty Then
            dgvSubsDeets.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvSubsDeets_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSubsDeets.CellValueChanged
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        ' Check if it's the checkbox column
        If dgvSubsDeets.Columns(e.ColumnIndex).Name = "colSelect" Then
            Dim row As DataGridViewRow = dgvSubsDeets.Rows(e.RowIndex)

            ' --- FIX IS HERE: Use DataBoundItem ---
            Dim drv As DataRowView = TryCast(row.DataBoundItem, DataRowView)
            If drv Is Nothing Then Return

            Dim id As Integer = Convert.ToInt32(drv("CustomerID"))

            Dim isChecked As Boolean = False
            If row.Cells("colSelect").Value IsNot Nothing Then
                isChecked = CBool(row.Cells("colSelect").Value)
            End If

            ' Add or Remove from the tracking list
            If isChecked Then
                If Not selectedSubscriberIds.Contains(id) Then selectedSubscriberIds.Add(id)
            Else
                selectedSubscriberIds.Remove(id)
            End If
        End If
    End Sub
End Class