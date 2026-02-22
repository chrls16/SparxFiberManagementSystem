Imports System.Configuration
Imports MySqlConnector
Imports System.Data
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports LiveCharts
Imports LiveCharts.Wpf
Imports LiveCharts.WinForms
Imports System.Windows.Media
Imports Color = System.Drawing.Color

Public Class service

    Private isFormOpen As Boolean = False
    Private updateTimer As Timer

    Private ChartServiceStatus As LiveCharts.WinForms.PieChart
    Private ChartServiceType As LiveCharts.WinForms.PieChart
    Private _connectionString As String = Nothing

    Private Const PAGE_SIZE As Integer = 25
    Private currentPageIndex As Integer = 0
    Private totalRecords As Integer = 0
    Private lastRefreshTime As DateTime = DateTime.MinValue
    Private selectedServiceIds As New List(Of Integer)()

    Private isClosing As Boolean = False

    Private ReadOnly Property CONNECTION_STRING As String

        Get
            If _connectionString Is Nothing AndAlso Not DesignMode Then
                Try
                    _connectionString = ConfigurationManager.ConnectionStrings("SparxDb").ConnectionString
                Catch
                    _connectionString = String.Empty
                    Console.WriteLine("Error: Could not retrieve connection string 'SparxDb'.")
                End Try
            End If
            Return If(_connectionString IsNot Nothing, _connectionString, String.Empty)
        End Get

    End Property

    Public Sub New()

        InitializeComponent()

    End Sub

    Private Sub LoadDataAsync()

        If Me.IsDisposed OrElse Me.Disposing Then Return

        Me.BeginInvoke(New Action(Sub()
                                      If Me.IsDisposed OrElse Me.Disposing Then Return

                                      LoadKPIData()
                                      LoadServiceStatusChart()
                                      LoadServiceTypeChart()
                                      LoadServiceData()
                                      lastRefreshTime = DateTime.Now
                                  End Sub))
    End Sub

    Private Sub ForceRefreshAllData()

        DataGridServiceRequestDetails.Rows.Clear()

        currentPageIndex = 0

        LoadServiceData()
        LoadServiceStatusChart()
        LoadServiceTypeChart()
        LoadKPIData()

        lastRefreshTime = DateTime.Now

        If DataGridServiceRequestDetails.Rows.Count > 0 Then
            DataGridServiceRequestDetails.FirstDisplayedScrollingRowIndex = 0
        End If

        DataGridServiceRequestDetails.Refresh()

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean

        If keyData = Keys.F5 Then
            ForceRefreshAllData()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)

    End Function

    Private Sub service_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        isClosing = False

        If String.IsNullOrEmpty(CONNECTION_STRING) Then
            MessageBox.Show("Database Connection String not found in App.config!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        PopulateDropdowns()

        CreateCharts()

        If Me.Visible Then
            updateTimer = New Timer()
            updateTimer.Interval = 30000
            AddHandler updateTimer.Tick, AddressOf Timer_Tick
            updateTimer.Start()
        End If

        Me.BeginInvoke(New Action(AddressOf LoadDataAsync))

    End Sub

    Private Sub DataGridServiceRequestDetails_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridServiceRequestDetails.SelectionChanged

        DataGridServiceRequestDetails.ClearSelection()

    End Sub

    'FOR CHARTS
    Private Sub CreateCharts()

        ChartServiceStatus = New LiveCharts.WinForms.PieChart()
        ChartServiceStatus.Dock = DockStyle.Fill
        ChartServiceStatus.BackColor = System.Drawing.Color.White
        ChartServiceStatus.LegendLocation = LegendLocation.Bottom
        ChartServiceStatus.InnerRadius = 50

        PanelRound1.Controls.Add(ChartServiceStatus)
        ChartServiceStatus.BringToFront()

        ChartServiceType = New LiveCharts.WinForms.PieChart()
        ChartServiceType.Dock = DockStyle.Fill
        ChartServiceType.BackColor = System.Drawing.Color.White
        ChartServiceType.LegendLocation = LegendLocation.Bottom
        ChartServiceType.InnerRadius = 0

        PanelRound2.Controls.Add(ChartServiceType)
        ChartServiceType.BringToFront()

    End Sub

    Private Sub LoadServiceStatusChart()
        If ChartServiceStatus Is Nothing Then Return
        If String.IsNullOrEmpty(CONNECTION_STRING) Then Return

        ' Filters
        Dim whereConditions As New List(Of String)
        If ComboDateRange.SelectedIndex > 0 Then whereConditions.Add("MONTH(s.date_requested) = @Month")
        If ComboServiceType.SelectedIndex > 0 Then whereConditions.Add("s.service_type = @Type")

        Dim joinStaff As String = ""

        joinStaff = " LEFT JOIN staff st ON s.staff_id = st.staff_id "

        Dim filterClause As String = " WHERE s.is_deleted = 0 "
        If whereConditions.Count > 0 Then filterClause = " WHERE " & String.Join(" AND ", whereConditions)

        Dim query As String = "SELECT s.status, COUNT(s.service_id) as count FROM service s" & joinStaff & filterClause & " GROUP BY s.status"
        Dim data As New Dictionary(Of String, Double)

        Using conn As New MySqlConnection(CONNECTION_STRING)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    ApplyParameters(cmd)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim statusName As String = reader.GetString("status")
                            Dim countVal As Double = Convert.ToDouble(reader("count"))

                            data.Add(statusName, countVal)
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Chart Error: " & ex.Message)
                LoadDummyServiceStatusChart()
                Exit Sub
            End Try
        End Using

        If ChartServiceStatus.Series IsNot Nothing Then ChartServiceStatus.Series.Clear()
        Dim seriesCollection As New SeriesCollection()

        Dim colors As System.Windows.Media.Color() = {
     System.Windows.Media.Color.FromRgb(76, 175, 80),
     System.Windows.Media.Color.FromRgb(255, 152, 0),
     System.Windows.Media.Color.FromRgb(255, 193, 7),
     System.Windows.Media.Color.FromRgb(244, 67, 54),
     System.Windows.Media.Color.FromRgb(156, 39, 176)
 }
        Dim colorIndex As Integer = 0

        For Each kvp In data
            seriesCollection.Add(New PieSeries With {
         .Title = kvp.Key,
         .Values = New ChartValues(Of Double)({kvp.Value}),
         .DataLabels = True,
         .Fill = New SolidColorBrush(colors(colorIndex Mod colors.Length)),
         .LabelPoint = Function(point) String.Format("{0} ({1:P0})", kvp.Key, point.Participation)
     })
            colorIndex += 1
        Next

        ChartServiceStatus.Series = seriesCollection

    End Sub

    Private Sub LoadServiceTypeChart()
        If ChartServiceType Is Nothing Then Return

        If String.IsNullOrEmpty(CONNECTION_STRING) Then
            LoadDummyServiceTypeChart()
            Exit Sub
        End If

        Dim whereConditions As New List(Of String)
        If ComboDateRange.SelectedIndex > 0 Then whereConditions.Add("MONTH(s.date_requested) = @Month")

        Dim filterClause As String = " WHERE s.is_deleted = 0 "
        If whereConditions.Count > 0 Then filterClause = " WHERE " & String.Join(" AND ", whereConditions)

        Dim data As New Dictionary(Of String, Double)

        Dim query As String = "SELECT s.service_type, COUNT(s.service_id) as count " &
                          "FROM service s " &
                          "LEFT JOIN staff st ON s.staff_id = st.staff_id " &
                          filterClause & " GROUP BY s.service_type"

        Using conn As New MySqlConnection(CONNECTION_STRING)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    ApplyParameters(cmd)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim typeName As String = reader.GetString("service_type")
                            Dim countVal As Double = Convert.ToDouble(reader("count"))

                            data.Add(typeName, countVal)
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Type Chart Error: " & ex.Message)

                Console.WriteLine("Chart Error: " & ex.Message)
                LoadDummyServiceTypeChart()
                Exit Sub
            End Try
        End Using

        Dim seriesCollection As New SeriesCollection()
        Dim colorIndex As Integer = 0
        Dim colors As System.Windows.Media.Color() = {
        System.Windows.Media.Color.FromRgb(244, 67, 54),
        System.Windows.Media.Color.FromRgb(33, 150, 243),
        System.Windows.Media.Color.FromRgb(255, 193, 7),
        System.Windows.Media.Color.FromRgb(0, 150, 136),
        System.Windows.Media.Color.FromRgb(156, 39, 176)
    }

        For Each kvp In data
            seriesCollection.Add(New PieSeries With {
            .Title = kvp.Key,
            .Values = New ChartValues(Of Double)({kvp.Value}),
            .DataLabels = True,
            .Fill = New SolidColorBrush(colors(colorIndex Mod colors.Length)),
            .LabelPoint = Function(point) String.Format("{0} ({1:P0})", kvp.Key, point.Participation)
        })
            colorIndex += 1
        Next

        ChartServiceType.Series = seriesCollection
    End Sub

    'FOR DATA LABELS
    Private Sub LoadKPIData()

        If String.IsNullOrEmpty(CONNECTION_STRING) Then
            LoadDummyKPIData()
            Exit Sub
        End If

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim whereConditions As New List(Of String)
                If ComboDateRange.SelectedIndex > 0 Then whereConditions.Add("MONTH(s.date_requested) = @Month")
                If ComboServiceType.SelectedIndex > 0 Then whereConditions.Add("s.service_type = @Type")

                Dim joinStaff As String = ""

                Dim filterClause As String = " WHERE is_deleted = 0 "
                If whereConditions.Count > 0 Then filterClause = " WHERE " & String.Join(" AND ", whereConditions)

                Dim totalQuery As String = "SELECT COUNT(*) FROM service s" & joinStaff & filterClause
                Using cmd As New MySqlCommand(totalQuery, conn)
                    ApplyParameters(cmd)
                    NumTotalInstalRequest.Text = cmd.ExecuteScalar().ToString()
                End Using

                Dim completedQuery As String = "SELECT COUNT(*) FROM service s" & joinStaff & filterClause &
                (If(filterClause = "", " WHERE ", " AND ")) & "s.status = 'Completed'"
                Using cmd As New MySqlCommand(completedQuery, conn)
                    ApplyParameters(cmd)
                    NumCompleted.Text = cmd.ExecuteScalar().ToString()
                End Using

                Dim inProgressQuery As String = "SELECT COUNT(*) FROM service s" & joinStaff & filterClause &
                (If(filterClause = "", " WHERE ", " AND ")) & "s.status = 'In Progress'"
                Using cmd As New MySqlCommand(inProgressQuery, conn)
                    ApplyParameters(cmd)
                    NumInProgress.Text = cmd.ExecuteScalar().ToString()
                End Using

                Dim pendingQuery As String = "SELECT COUNT(*) FROM service s" & joinStaff & filterClause &
                (If(filterClause = "", " WHERE ", " AND ")) & "s.status = 'Requested'"
                Using cmd As New MySqlCommand(pendingQuery, conn)
                    ApplyParameters(cmd)
                    NumPending.Text = cmd.ExecuteScalar().ToString()
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show($"Error loading KPI: {ex.Message}")
            LoadDummyKPIData()
        End Try

    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)

        If isClosing OrElse Me.IsDisposed OrElse Me.Disposing OrElse Not Me.IsHandleCreated OrElse Me.Handle = IntPtr.Zero Then
            If updateTimer IsNot Nothing Then
                updateTimer.Stop()
            End If
            Return
        End If

        If Me.ParentForm IsNot Nothing AndAlso (Me.ParentForm.WindowState = FormWindowState.Minimized OrElse Not Me.Visible) Then
            Return
        End If

        If (DateTime.Now - lastRefreshTime).TotalSeconds > 30 Then
            LoadServiceStatusChart()
            LoadServiceTypeChart()
            LoadServiceData()
            LoadKPIData()
            lastRefreshTime = DateTime.Now
        End If

    End Sub

    'FOR TABLE
    Private Sub PopulateGridFromDataTable(dt As DataTable)

        DataGridServiceRequestDetails.Rows.Clear()

        For Each row As DataRow In dt.Rows
            Dim dgvRowIndex As Integer = DataGridServiceRequestDetails.Rows.Add()


            With DataGridServiceRequestDetails.Rows(dgvRowIndex)
                If Not row.IsNull("service_id") Then
                    .Cells("ServiceID").Value = Convert.ToInt32(row("service_id")).ToString("D5")
                End If

                If Not row.IsNull("customer_name") Then
                    .Cells("Customer").Value = row("customer_name")
                Else
                    .Cells("Customer").Value = "N/A"
                End If

                If Not row.IsNull("service_type") Then
                    .Cells("ServiceType").Value = row("service_type")
                Else
                    .Cells("ServiceType").Value = "N/A"
                End If

                If Not row.IsNull("time_requested") Then
                    Dim timeValue As Object = row("time_requested")
                    If TypeOf timeValue Is TimeSpan Then
                        .Cells("colTimeRequested").Value = CType(timeValue, TimeSpan).ToString("hh\:mm")
                    ElseIf TypeOf timeValue Is DateTime Then
                        .Cells("colTimeRequested").Value = CType(timeValue, DateTime).ToString("HH:mm")
                    ElseIf timeValue.ToString() <> "" Then
                        .Cells("colTimeRequested").Value = timeValue.ToString()
                    End If
                End If

                If Not row.IsNull("date_requested") Then
                    Dim dateValue As Object = row("date_requested")
                    If TypeOf dateValue Is DateTime Then
                        .Cells("DateRequested").Value = CType(dateValue, DateTime).ToString("MM/dd/yyyy")
                    ElseIf dateValue.ToString() <> "" Then
                        Dim parsedDate As DateTime
                        If DateTime.TryParse(dateValue.ToString(), parsedDate) Then
                            .Cells("DateRequested").Value = parsedDate.ToString("MM/dd/yyyy")
                        Else
                            .Cells("DateRequested").Value = dateValue.ToString()
                        End If
                    End If
                End If

                If Not row.IsNull("status") AndAlso row("status").ToString() = "In Progress" Then
                    .Cells("colDateCompleted").Value = "N/A"
                ElseIf Not row.IsNull("date_completed") Then
                    Dim dateValue As Object = row("date_completed")
                    If TypeOf dateValue Is DateTime Then
                        .Cells("colDateCompleted").Value = CType(dateValue, DateTime).ToString("MM/dd/yyyy")
                    ElseIf dateValue.ToString() <> "" Then
                        Dim parsedDate As DateTime
                        If DateTime.TryParse(dateValue.ToString(), parsedDate) Then
                            .Cells("colDateCompleted").Value = parsedDate.ToString("MM/dd/yyyy")
                        Else
                            .Cells("colDateCompleted").Value = dateValue.ToString()
                        End If
                    End If
                Else
                    .Cells("colDateCompleted").Value = ""
                End If

                If Not row.IsNull("service_cost") Then
                    Dim costValue As Object = row("service_cost")
                    If IsNumeric(costValue) Then
                        .Cells("ServiceCost").Value = String.Format("{0:C}", Convert.ToDecimal(costValue))
                    Else
                        .Cells("ServiceCost").Value = costValue.ToString()
                    End If
                Else
                    .Cells("ServiceCost").Value = "$0.00"
                End If

                If Not row.IsNull("technician_name") Then
                    .Cells("Technician").Value = row("technician_name")
                Else
                    .Cells("Technician").Value = "Unassigned"
                End If

                If Not row.IsNull("service_description") Then
                    .Cells("colServiceDescription").Value = row("service_description")
                Else
                    .Cells("colServiceDescription").Value = "No description"
                End If

                If Not row.IsNull("status") Then
                    .Cells("Status").Value = row("status")
                Else
                    .Cells("Status").Value = "Unknown"
                End If

                If Not row.IsNull("technician_notes") Then
                    .Cells("ColTechNotes").Value = row("technician_notes")
                Else
                    .Cells("ColTechNotes").Value = "No notes"
                End If

                If DataGridServiceRequestDetails.Columns.Contains("colEdit") Then
                    .Cells("colEdit").Value = If(My.Resources.Resources.edit IsNot Nothing, My.Resources.Resources.edit, Nothing)
                End If

                If DataGridServiceRequestDetails.Columns.Contains("colDelete") Then
                    .Cells("colDelete").Value = If(My.Resources.Resources.delete1 IsNot Nothing, My.Resources.Resources.delete1, Nothing)
                End If

                If DataGridServiceRequestDetails.Columns.Contains("colCheckBox") Then
                    .Cells("colCheckBox").Value = False
                End If
            End With
        Next

        UpdatePaginationControls()

    End Sub

    'FOR DUMMY DATA
    Private Sub LoadDummyKPIData()

        NumTotalInstalRequest.Text = "125"
        NumCompleted.Text = "85"
        NumInProgress.Text = "25"
        NumPending.Text = "15"

    End Sub

    Private Sub LoadDummyServiceStatusChart()

        Dim seriesCollection As New SeriesCollection()
        seriesCollection.Add(New PieSeries With {
            .Title = "Completed",
            .Values = New ChartValues(Of Double)({85}),
            .DataLabels = True,
            .Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(76, 175, 80))
        })
        seriesCollection.Add(New PieSeries With {
            .Title = "In Progress",
            .Values = New ChartValues(Of Double)({25}),
            .DataLabels = True,
            .Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 152, 0))
        })
        seriesCollection.Add(New PieSeries With {
            .Title = "Requested",
            .Values = New ChartValues(Of Double)({15}),
            .DataLabels = True,
            .Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 193, 7))
        })

        ChartServiceStatus.Series = seriesCollection
        ChartServiceStatus.Update()

    End Sub

    Private Sub LoadDummyServiceTypeChart()

        Dim seriesCollection As New SeriesCollection()
        seriesCollection.Add(New PieSeries With {
            .Title = "Installation",
            .Values = New ChartValues(Of Double)({60}),
            .DataLabels = True,
            .Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(33, 150, 243))
        })
        seriesCollection.Add(New PieSeries With {
            .Title = "Repair",
            .Values = New ChartValues(Of Double)({35}),
            .DataLabels = True,
            .Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(244, 67, 54))
        })
        seriesCollection.Add(New PieSeries With {
            .Title = "Relocation",
            .Values = New ChartValues(Of Double)({20}),
            .DataLabels = True,
            .Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 193, 7))
        })
        seriesCollection.Add(New PieSeries With {
            .Title = "Maintenance",
            .Values = New ChartValues(Of Double)({10}),
            .DataLabels = True,
            .Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 150, 136))
        })

        ChartServiceType.Series = seriesCollection
        ChartServiceType.Update()

    End Sub

    Private Sub LoadDummyServiceData()
        DataGridServiceRequestDetails.Rows.Clear()

        Dim row1 As Integer = DataGridServiceRequestDetails.Rows.Add()
        DataGridServiceRequestDetails.Rows(row1).Cells("ServiceID").Value = 1
        DataGridServiceRequestDetails.Rows(row1).Cells("Customer").Value = "John Doe"
        DataGridServiceRequestDetails.Rows(row1).Cells("ServiceType").Value = "Installation"
        DataGridServiceRequestDetails.Rows(row1).Cells("colTimeRequested").Value = "10:30:00"
        DataGridServiceRequestDetails.Rows(row1).Cells("DateRequested").Value = DateTime.Now.AddDays(-2)
        DataGridServiceRequestDetails.Rows(row1).Cells("colDateCompleted").Value = DateTime.Now.AddDays(-1)
        DataGridServiceRequestDetails.Rows(row1).Cells("ServiceCost").Value = 1500.0
        DataGridServiceRequestDetails.Rows(row1).Cells("Technician").Value = "Tech1"
        DataGridServiceRequestDetails.Rows(row1).Cells("colServiceDescription").Value = "Internet installation"
        DataGridServiceRequestDetails.Rows(row1).Cells("Status").Value = "Completed"
        DataGridServiceRequestDetails.Rows(row1).Cells("ColTechNotes").Value = "Installed successfully"
        DataGridServiceRequestDetails.Rows(row1).Cells("colEdit").Value = My.Resources.Resources.edit
        DataGridServiceRequestDetails.Rows(row1).Cells("colDelete").Value = My.Resources.Resources.delete1
        If DataGridServiceRequestDetails.Columns.Contains("colCheckBox") Then
            DataGridServiceRequestDetails.Rows(row1).Cells("colCheckBox").Value = False
        End If

        Dim row2 As Integer = DataGridServiceRequestDetails.Rows.Add()
        DataGridServiceRequestDetails.Rows(row2).Cells("ServiceID").Value = 2
        DataGridServiceRequestDetails.Rows(row2).Cells("Customer").Value = "Jane Smith"
        DataGridServiceRequestDetails.Rows(row2).Cells("ServiceType").Value = "Repair"
        DataGridServiceRequestDetails.Rows(row2).Cells("colTimeRequested").Value = "14:15:00"
        DataGridServiceRequestDetails.Rows(row2).Cells("DateRequested").Value = DateTime.Now.AddDays(-1)
        DataGridServiceRequestDetails.Rows(row2).Cells("colDateCompleted").Value = DBNull.Value
        DataGridServiceRequestDetails.Rows(row2).Cells("ServiceCost").Value = 200.0
        DataGridServiceRequestDetails.Rows(row2).Cells("Technician").Value = "Tech2"
        DataGridServiceRequestDetails.Rows(row2).Cells("colServiceDescription").Value = "Connection issues"
        DataGridServiceRequestDetails.Rows(row2).Cells("Status").Value = "In Progress"
        DataGridServiceRequestDetails.Rows(row2).Cells("ColTechNotes").Value = "Working on router"
        DataGridServiceRequestDetails.Rows(row2).Cells("colEdit").Value = My.Resources.Resources.edit
        DataGridServiceRequestDetails.Rows(row2).Cells("colDelete").Value = My.Resources.Resources.delete1
        If DataGridServiceRequestDetails.Columns.Contains("colCheckBox") Then
            DataGridServiceRequestDetails.Rows(row2).Cells("colCheckBox").Value = False
        End If

        If DataGridServiceRequestDetails.Rows.Count > 0 Then
            DataGridServiceRequestDetails.FirstDisplayedScrollingRowIndex = 0
        End If
    End Sub

    Private Sub LoadServiceData()

        If updateTimer IsNot Nothing Then updateTimer.Stop()

        If DataGridServiceRequestDetails Is Nothing OrElse String.IsNullOrEmpty(CONNECTION_STRING) Then
            If updateTimer IsNot Nothing Then updateTimer.Start()
            Return
        End If

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim searchText As String = txtInventorySearchSA.Text.Trim()
                Dim whereConditions As New List(Of String)
                whereConditions.Add("1=1")
                whereConditions.Add("s.is_deleted = 0")

                If ComboDateRange.SelectedIndex > 0 Then
                    whereConditions.Add("MONTH(s.date_requested) = @Month")
                End If

                If ComboServiceType.SelectedIndex > 0 Then
                    whereConditions.Add("s.service_type = @Type")
                End If

                If cbStatus.SelectedIndex > 0 Then
                    whereConditions.Add("s.status = @Status")
                End If

                If Not String.IsNullOrWhiteSpace(searchText) Then
                    whereConditions.Add("(s.service_id LIKE @Search " &
                        "OR LPAD(s.service_id, 5, '0') LIKE @Search " & ' Added this line for zero-padding search
                        "OR DATE_FORMAT(s.date_requested, '%m/%d/%Y') LIKE @Search " &
                        "OR DATE_FORMAT(s.date_completed, '%m/%d/%Y') LIKE @Search " &
                        "OR CONCAT(c.first_name, ' ', c.last_name) LIKE @Search)")
                End If

                Dim filterClause As String = " WHERE " & String.Join(" AND ", whereConditions)

                Dim countQuery As String = "SELECT COUNT(*) FROM service s " &
                                           "LEFT JOIN customer c ON s.customer_id = c.customer_id " &
                                           "LEFT JOIN staff st ON s.staff_id = st.staff_id" & filterClause

                Using countCmd As New MySqlCommand(countQuery, conn)
                    ApplyParameters(countCmd)
                    totalRecords = Convert.ToInt32(countCmd.ExecuteScalar())
                End Using

                Dim totalPages As Integer = CInt(Math.Ceiling(totalRecords / PAGE_SIZE))
                If currentPageIndex >= totalPages Then currentPageIndex = Math.Max(0, totalPages - 1)
                Dim offset As Integer = currentPageIndex * PAGE_SIZE

                Dim query As String = "SELECT s.service_id, CONCAT(c.first_name, ' ', c.last_name) AS customer_name, " &
                                      "s.service_type, s.time_requested, DATE(s.date_requested) AS date_requested, DATE(s.date_completed) AS date_completed, " &
                                      "s.service_cost, CONCAT(st.first_name, ' ', st.last_name) AS technician_name, " &
                                      "s.service_description, s.status, s.technician_notes " &
                                      "FROM service s " &
                                      "LEFT JOIN customer c ON s.customer_id = c.customer_id " &
                                      "LEFT JOIN staff st ON s.staff_id = st.staff_id " & filterClause & " " &
                                      "ORDER BY s.date_requested DESC, s.time_requested DESC " &
                                      "LIMIT @Offset, @Limit"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Offset", offset)
                    cmd.Parameters.AddWithValue("@Limit", PAGE_SIZE)
                    ApplyParameters(cmd)

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        If Me.InvokeRequired Then
                            Me.Invoke(New Action(Sub() PopulateGridFromDataTable(dt)))
                        Else
                            PopulateGridFromDataTable(dt)
                        End If
                    End Using
                End Using

                If Me.InvokeRequired Then
                    Me.Invoke(New Action(Sub() UpdatePaginationControls()))
                Else
                    UpdatePaginationControls()
                End If
            End Using

        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        Finally
            If updateTimer IsNot Nothing Then updateTimer.Start()
            lastRefreshTime = DateTime.Now
        End Try

    End Sub

    Private Sub ApplyParameters(cmd As MySqlCommand)

        If ComboDateRange.SelectedIndex > 0 Then
            cmd.Parameters.AddWithValue("@Month", ComboDateRange.SelectedIndex)
        End If

        If ComboServiceType.SelectedIndex > 0 Then
            cmd.Parameters.AddWithValue("@Type", ComboServiceType.SelectedItem.ToString())
        End If

        If cbStatus.SelectedIndex > 0 Then
            cmd.Parameters.AddWithValue("@Status", cbStatus.SelectedItem.ToString())
        End If

        If Not String.IsNullOrWhiteSpace(txtInventorySearchSA.Text) Then
            cmd.Parameters.AddWithValue("@Search", "%" & txtInventorySearchSA.Text.Trim() & "%")
        End If

    End Sub

    Private Sub DataGridServiceRequestDetails_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridServiceRequestDetails.CellClick

        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Exit Sub

        Dim dgv As DataGridView = CType(sender, DataGridView)
        Dim selectedRow As DataGridViewRow = dgv.Rows(e.RowIndex)

        If dgv.Columns(e.ColumnIndex).Name = "colEdit" Then
            Dim serviceId As Integer = Convert.ToInt32(selectedRow.Cells("ServiceID").Value)

            Using frmUpdate As New frmServiceUpdate()
                frmUpdate.SelectedServiceID = serviceId
                If frmUpdate.ShowDialog() = DialogResult.OK Then
                    ForceRefreshAllData()
                    MessageBox.Show("Service updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using

        ElseIf dgv.Columns(e.ColumnIndex).Name = "colDelete" Then
            Dim serviceId As Integer = Convert.ToInt32(selectedRow.Cells("ServiceID").Value)
            Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete service ID: {serviceId}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                DeleteService(serviceId)
            End If

        ElseIf dgv.Columns(e.ColumnIndex).Name = "colCheckBox" Then
            ' Handle checkbox if needed
        Else
            Console.WriteLine($"Cell clicked: Row {e.RowIndex}, Column {e.ColumnIndex}")
        End If

    End Sub

    Private Sub DeleteService(serviceId As Integer)

        If String.IsNullOrEmpty(CONNECTION_STRING) Then
            MessageBox.Show("Cannot connect to database to delete service.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim query As String = "UPDATE service SET is_deleted = 1 WHERE service_id = @serviceId"

        Using conn As New MySqlConnection(CONNECTION_STRING)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@serviceId", serviceId)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Service deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ForceRefreshAllData()
                    Else
                        MessageBox.Show("Service not found or could not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error deleting service: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

    End Sub

    Private Sub txtInventorySearchSA_TextChanged(sender As Object, e As EventArgs) Handles txtInventorySearchSA.TextChanged

        currentPageIndex = 0
        Static searchTimer As New Timer With {.Interval = 500}
        RemoveHandler searchTimer.Tick, AddressOf OnMainSearchTimerTick
        AddHandler searchTimer.Tick, AddressOf OnMainSearchTimerTick
        searchTimer.Start()

    End Sub

    Private Sub OnMainSearchTimerTick(sender As Object, e As EventArgs)

        CType(sender, Timer).Stop()
        LoadServiceData()

    End Sub

    Private Sub SearchServices(searchText As String)

        If String.IsNullOrWhiteSpace(searchText) Then
            For Each row As DataGridViewRow In DataGridServiceRequestDetails.Rows
                row.Visible = True
            Next
        Else
            For Each row As DataGridViewRow In DataGridServiceRequestDetails.Rows
                If row.IsNewRow Then Continue For

                Dim customerName As String = If(row.Cells("Customer").Value?.ToString(), "")
                Dim serviceType As String = If(row.Cells("ServiceType").Value?.ToString(), "")
                Dim description As String = If(row.Cells("colServiceDescription").Value?.ToString(), "")
                Dim status As String = If(row.Cells("Status").Value?.ToString(), "")

                If customerName.ToLower().Contains(searchText.ToLower()) OrElse
                   serviceType.ToLower().Contains(searchText.ToLower()) OrElse
                   description.ToLower().Contains(searchText.ToLower()) OrElse
                   status.ToLower().Contains(searchText.ToLower()) Then
                    row.Visible = True
                Else
                    row.Visible = False
                End If
            Next
        End If

    End Sub

    Private Sub btnAddInventory_Click(sender As Object, e As EventArgs) Handles btnAddInventory.Click

        Using frmCreate As New frmServiceCreate()

            Dim result As DialogResult = frmCreate.ShowDialog()


            If result = DialogResult.OK Then
                ForceRefreshAllData()

                MessageBox.Show("Service created successfully! The new service will appear at the top of the list.",
                              "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using

    End Sub

    Private Sub btnSelectInventory_Click(sender As Object, e As EventArgs) Handles btnSelectInventory.Click

        Dim allSelected As Boolean = True

        For Each row As DataGridViewRow In DataGridServiceRequestDetails.Rows
            If Not row.IsNewRow Then
                If Not CBool(row.Cells("colCheckBox").Value) Then
                    allSelected = False
                    Exit For
                End If
            End If
        Next

        For Each row As DataGridViewRow In DataGridServiceRequestDetails.Rows
            If Not row.IsNewRow Then
                row.Cells("colCheckBox").Value = Not allSelected
            End If
        Next

        If Not allSelected Then
            selectedServiceIds.Clear()
            For Each row As DataGridViewRow In DataGridServiceRequestDetails.Rows
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

    Private Sub UpdateSelectionUI()
        If selectedServiceIds.Count > 0 Then
            ' can add visual feedback here
        Else
            ' btnSelectInstallation.Image = My.Resources.Resources.selectall
        End If
    End Sub

    Private Sub btnNextInstallationSA_Click(sender As Object, e As EventArgs) Handles btnNextInstallationSA.Click

        Dim totalPages As Integer = CInt(Math.Ceiling(totalRecords / PAGE_SIZE))

        If currentPageIndex < totalPages - 1 Then
            currentPageIndex += 1
            LoadServiceData()
        End If

    End Sub

    Private Sub btnSalesPreviousSA_Click(sender As Object, e As EventArgs) Handles btnSalesPreviousSA.Click

        If currentPageIndex > 0 Then
            currentPageIndex -= 1
            LoadServiceData()
        End If

    End Sub

    'FOR PAGING
    Private Sub UpdatePaginationControls()

        Dim totalPages As Integer = CInt(Math.Ceiling(totalRecords / PAGE_SIZE))

        btnSalesPreviousSA.Enabled = currentPageIndex > 0
        btnSalesPreviousSA.Visible = currentPageIndex > 0

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

    'FOR FILTERS
    Private Sub PopulateDropdowns()

        Me.ComboDateRange.Items.Clear()
        Me.ComboDateRange.Items.Add("All Time")
        Me.ComboDateRange.Items.AddRange(New String() {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        })
        Me.ComboDateRange.SelectedIndex = 0

        Me.ComboServiceType.Items.Clear()
        Me.ComboServiceType.Items.Add("All Types")
        Me.ComboServiceType.Items.AddRange(New String() {"Installation", "Repair", "Relocation"})
        Me.ComboServiceType.SelectedIndex = 0

        Me.cbStatus.Items.Clear()
        Me.cbStatus.Items.Add("All Status")
        Me.cbStatus.Items.Add("Requested")
        Me.cbStatus.Items.Add("In Progress")
        Me.cbStatus.Items.Add("Completed")
        Me.cbStatus.SelectedIndex = 0

    End Sub

    Private Sub cbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbStatus.SelectedIndexChanged

        currentPageIndex = 0
        LoadServiceData()
        LoadServiceStatusChart()
        LoadKPIData()

    End Sub

    Private Sub ComboDateRange_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboDateRange.SelectedIndexChanged

        RefreshFilters()

    End Sub

    Private Sub ComboServiceType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboServiceType.SelectedIndexChanged

        RefreshFilters()

    End Sub

    'FOR SEARCHING 
    Private Sub txtTechnicianSearchSA_TextChanged(sender As Object, e As EventArgs)

        Static techSearchTimer As New Timer With {.Interval = 500}
        RemoveHandler techSearchTimer.Tick, AddressOf OnTechSearchTimerTick
        AddHandler techSearchTimer.Tick, AddressOf OnTechSearchTimerTick
        techSearchTimer.Start()

    End Sub

    Private Sub OnTechSearchTimerTick(sender As Object, e As EventArgs)
        CType(sender, Timer).Stop()
        RefreshFilters()
    End Sub

    Private Sub RefreshFilters()

        currentPageIndex = 0
        LoadServiceData()
        LoadServiceStatusChart()
        LoadServiceTypeChart()
        LoadKPIData()

    End Sub

    Private Sub DataGridServiceRequestDetails_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridServiceRequestDetails.CellContentClick

        If e.RowIndex < 0 Then Return
        Dim columnName As String = DataGridServiceRequestDetails.Columns(e.ColumnIndex).Name

        If DataGridServiceRequestDetails.Columns(e.ColumnIndex).Name = "colEdit" Then
            Dim serviceId As String = DataGridServiceRequestDetails.Rows(e.RowIndex).Cells("ServiceID").Value.ToString()

            Dim serviceIdInt As Integer
            If Integer.TryParse(serviceId, serviceIdInt) Then

                Using frmUpdate As New frmServiceUpdate()

                    frmUpdate.SelectedServiceID = serviceIdInt

                    If frmUpdate.ShowDialog() = DialogResult.OK Then

                        ForceRefreshAllData()
                    End If
                End Using
            Else
                MessageBox.Show("Invalid Service ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        If columnName = "colCheckBox" Then
            Dim currentValue As Boolean = CBool(DataGridServiceRequestDetails.Rows(e.RowIndex).Cells("colCheckBox").Value)
            DataGridServiceRequestDetails.Rows(e.RowIndex).Cells("colCheckBox").Value = Not currentValue
        End If

    End Sub

    'FOR EXPORT
    Private Sub btnExport_Click(sender As Object, e As EventArgs)
        Dim exportForm As New SAServiceExport
        exportForm.ShowDialog()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs)
        ForceRefreshAllData()
    End Sub

    'FOR UI
    Private Sub DataGridServiceRequestDetails_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridServiceRequestDetails.CellFormatting
        If e.ColumnIndex >= 0 Then
            Dim columnName As String = DataGridServiceRequestDetails.Columns(e.ColumnIndex).Name

            ' Format IDs to 00001
            If columnName = "ServiceID" Then
                If e.Value IsNot Nothing AndAlso IsNumeric(e.Value) Then
                    e.Value = Convert.ToInt32(e.Value).ToString("D5")
                    e.FormattingApplied = True
                End If
            End If

            ' Format Dates
            If columnName = "DateRequested" OrElse columnName = "colDateCompleted" Then
                If e.Value IsNot Nothing AndAlso TypeOf e.Value Is Date Then
                    Dim dateValue As Date = CType(e.Value, Date)
                    e.Value = If(dateValue <> Date.MinValue, dateValue.ToString("MM/dd/yyyy"), "N/A")
                    e.FormattingApplied = True
                End If
            End If
        End If
    End Sub

    Private Sub DataGridServiceRequestDetails_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridServiceRequestDetails.CellValueChanged

        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim columnName As String = DataGridServiceRequestDetails.Columns(e.ColumnIndex).Name

        If columnName = "colCheckBox" Then
            Dim serviceId As Integer = Convert.ToInt32(DataGridServiceRequestDetails.Rows(e.RowIndex).Cells("ServiceID").Value)
            Dim isChecked As Boolean = CBool(DataGridServiceRequestDetails.Rows(e.RowIndex).Cells("colCheckBox").Value)

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

    Private Sub deleteAll_Click(sender As Object, e As EventArgs) Handles deleteAll.Click

        If selectedServiceIds.Count = 0 Then
            MessageBox.Show("Please select at least one service to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete the {selectedServiceIds.Count} selected service(s)?",
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

                    Dim query As String = $"UPDATE service SET is_deleted = 1 WHERE service_id IN ({String.Join(",", paramNames)})"

                    Using cmd As New MySqlCommand(query, conn)
                        For i As Integer = 0 To selectedServiceIds.Count - 1
                            cmd.Parameters.AddWithValue("@id" & i, selectedServiceIds(i))
                        Next

                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                        MessageBox.Show($"{rowsAffected} services(s) deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        selectedServiceIds.Clear()
                        ForceRefreshAllData()
                        UpdateSelectionUI()
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error deleting records: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    Private Sub Cleanup()

        isClosing = True

        If updateTimer IsNot Nothing Then
            updateTimer.Stop()
            RemoveHandler updateTimer.Tick, AddressOf Timer_Tick
            updateTimer.Dispose()
            updateTimer = Nothing
        End If

        Try
            If ChartServiceStatus IsNot Nothing Then
                ChartServiceStatus.Series = Nothing
                If Not ChartServiceStatus.IsDisposed Then
                    ChartServiceStatus.Dispose()
                End If
            End If

            If ChartServiceType IsNot Nothing Then
                ChartServiceType.Series = Nothing
                If Not ChartServiceType.IsDisposed Then
                    ChartServiceType.Dispose()
                End If
            End If

        Catch ex As Exception
            ' Ignore disposal errors
        End Try

    End Sub
    Protected Overrides Sub OnHandleDestroyed(e As EventArgs)

        Cleanup()
        MyBase.OnHandleDestroyed(e)

    End Sub

    Private Sub service_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

        Cleanup()

    End Sub


    Private Sub service_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged

        If Not Me.Visible Then
            If updateTimer IsNot Nothing Then
                updateTimer.Stop()
            End If
        ElseIf Not isClosing AndAlso updateTimer IsNot Nothing Then

            updateTimer.Start()
        End If

    End Sub

    Private Sub service_ParentChanged(sender As Object, e As EventArgs) Handles Me.ParentChanged

        If Me.Parent Is Nothing AndAlso Not isClosing Then
            Cleanup()
        End If
    End Sub

End Class