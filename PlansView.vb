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

Public Class plansview
    Inherits UserControl

    Private ChartMonthlySubscriberGrowth As LiveCharts.WinForms.CartesianChart
    Private ChartSubscriberDistributionByPlan As LiveCharts.WinForms.PieChart

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

    Private updateTimer As Timer

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub plansview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            PopulateDropdowns()

            RemoveHandler cbDateRange.SelectedIndexChanged, AddressOf cbDateRange_SelectedIndexChanged
            RemoveHandler cbAccountStatus.SelectedIndexChanged, AddressOf cbAccountStatus_SelectedIndexChanged


            Me.cbDateRange.SelectedIndex = 0
            Me.cbAccountStatus.SelectedIndex = 0


            AddHandler cbDateRange.SelectedIndexChanged, AddressOf cbDateRange_SelectedIndexChanged
            AddHandler cbAccountStatus.SelectedIndexChanged, AddressOf cbAccountStatus_SelectedIndexChanged


            CreateCharts()

            LoadChartsData()
            UpdatePlanMetrics()
            UpdatePlanSummaryDetails()
            UpdateTopPerformingPlans()

            updateTimer = New Timer()
            updateTimer.Interval = 30000
            AddHandler updateTimer.Tick, AddressOf Timer_Tick
            updateTimer.Start()

        Catch ex As Exception
            MessageBox.Show("Error loading plans view: " & ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PopulateDropdowns()
        ' Date Range
        Me.cbDateRange.Items.Clear()
        Me.cbDateRange.Items.Add("All Time")
        Me.cbDateRange.Items.Add("Last 7 Days")
        Me.cbDateRange.Items.Add("Last 30 Days")
        Me.cbDateRange.Items.Add("Last 3 Months")
        Me.cbDateRange.Items.Add("Last 6 Months")
        Me.cbDateRange.Items.Add("Last Year")
        Me.cbDateRange.Items.Add("This Month")
        Me.cbDateRange.Items.Add("This Year")

        ' Account Status
        Me.cbAccountStatus.Items.Clear()
        Me.cbAccountStatus.Items.Add("All Status")
        Me.cbAccountStatus.Items.Add("Active")
        Me.cbAccountStatus.Items.Add("Suspended")

    End Sub

    Private Function BuildFilterClause(cmd As MySqlCommand, Optional dateCol As String = "date_installed") As String
        Dim sb As New System.Text.StringBuilder()

        If cbDateRange.SelectedItem IsNot Nothing Then
            Select Case cbDateRange.SelectedItem.ToString()
                Case "Last 7 Days"
                    sb.Append($" AND {dateCol} >= DATE_SUB(CURDATE(), INTERVAL 7 DAY)")
                Case "Last 30 Days"
                    sb.Append($" AND {dateCol} >= DATE_SUB(CURDATE(), INTERVAL 30 DAY)")
                Case "Last 3 Months"
                    sb.Append($" AND {dateCol} >= DATE_SUB(CURDATE(), INTERVAL 3 MONTH)")
                Case "Last 6 Months"
                    sb.Append($" AND {dateCol} >= DATE_SUB(CURDATE(), INTERVAL 6 MONTH)")
                Case "Last Year"
                    sb.Append($" AND {dateCol} >= DATE_SUB(CURDATE(), INTERVAL 1 YEAR)")
                Case "This Month"
                    sb.Append($" AND YEAR({dateCol}) = YEAR(CURDATE()) AND MONTH({dateCol}) = MONTH(CURDATE())")
                Case "This Year"
                    sb.Append($" AND YEAR({dateCol}) = YEAR(CURDATE())")
            End Select
        End If

        If cbAccountStatus.SelectedIndex > 0 Then
            sb.Append(" AND account_status = @FilterStatus")
            cmd.Parameters.AddWithValue("@FilterStatus", cbAccountStatus.SelectedItem.ToString())
        End If

        Return sb.ToString()
    End Function

    Private Sub CreateCharts()
        Try
            ChartMonthlySubscriberGrowth = New LiveCharts.WinForms.CartesianChart()
            ChartMonthlySubscriberGrowth.Dock = DockStyle.Fill
            ChartMonthlySubscriberGrowth.BackColor = Color.White
            ChartMonthlySubscriberGrowth.LegendLocation = LegendLocation.Right

            ChartMonthlySubscriberGrowth.AxisX.Add(New Axis With {
              .Title = "Month",
              .LabelsRotation = 0,
              .Separator = New Separator With {.Step = 1}
            })

            ChartMonthlySubscriberGrowth.AxisY.Add(New Axis With {
              .Title = "Subscribers",
              .LabelFormatter = Function(value) value.ToString("N0")
            })

            Panel2.Controls.Clear()
            Panel2.Controls.Add(ChartMonthlySubscriberGrowth)
            ChartMonthlySubscriberGrowth.BringToFront()

            ChartSubscriberDistributionByPlan = New LiveCharts.WinForms.PieChart()
            ChartSubscriberDistributionByPlan.Dock = DockStyle.Fill
            ChartSubscriberDistributionByPlan.BackColor = Color.White
            ChartSubscriberDistributionByPlan.LegendLocation = LegendLocation.Bottom
            ChartSubscriberDistributionByPlan.InnerRadius = 100

            Panel1.Controls.Clear()
            Panel1.Controls.Add(ChartSubscriberDistributionByPlan)
            ChartSubscriberDistributionByPlan.BringToFront()

        Catch ex As Exception
            MessageBox.Show("Error creating charts: " & ex.Message, "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadChartsData()
        Try
            LoadMonthlySubscriberGrowthChart()
            LoadSubscriberDistributionByPlanChart()
        Catch ex As Exception
            MessageBox.Show("Error loading chart data: " & ex.Message, "Chart Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            LoadMockMonthlySubscriberGrowthChart()
            LoadMockSubscriberDistributionByPlanChart()
        End Try
    End Sub

    Private Sub LoadMonthlySubscriberGrowthChart()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Using cmd As New MySqlCommand()
                    cmd.Connection = conn

                    Dim sb As New System.Text.StringBuilder()
                    sb.Append("SELECT DATE_FORMAT(date_installed, '%Y-%m') as Month, COUNT(*) as SubscriberCount ")
                    sb.Append("FROM customer WHERE 1=1 ")

                    sb.Append(BuildFilterClause(cmd))

                    sb.Append(" GROUP BY DATE_FORMAT(date_installed, '%Y-%m') ORDER BY Month DESC LIMIT 12")

                    cmd.CommandText = sb.ToString()

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim monthLabels As New List(Of String)()
                        Dim subscriberCounts As New List(Of Double)()

                        While reader.Read()
                            Dim month As String = reader("Month").ToString()
                            Dim count As Integer = Convert.ToInt32(reader("SubscriberCount"))

                            Dim dateObj As DateTime = DateTime.ParseExact(month & "-01", "yyyy-MM-dd", Nothing)
                            monthLabels.Add(dateObj.ToString("MMM yyyy"))
                            subscriberCounts.Add(count)
                        End While

                        monthLabels.Reverse()
                        subscriberCounts.Reverse()

                        If Me.InvokeRequired Then
                            Me.Invoke(New Action(Sub() UpdateMonthlySubscriberGrowthChart(monthLabels, subscriberCounts)))
                        Else
                            UpdateMonthlySubscriberGrowthChart(monthLabels, subscriberCounts)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            LoadMockMonthlySubscriberGrowthChart()
        End Try
    End Sub

    Private Sub UpdateMonthlySubscriberGrowthChart(monthLabels As List(Of String), subscriberCounts As List(Of Double))
        If ChartMonthlySubscriberGrowth Is Nothing Then
            CreateCharts()
            If ChartMonthlySubscriberGrowth Is Nothing Then
                Return
            End If
        End If

        ChartMonthlySubscriberGrowth.Series = New SeriesCollection()

        Dim barSeries As New ColumnSeries() With {
          .Title = "New Subscribers",
          .Values = New ChartValues(Of Double)(subscriberCounts),
          .DataLabels = True,
          .LabelPoint = Function(point) point.Y.ToString("N0"),
          .Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(59, 130, 246)) ' Blue color
            }

        ChartMonthlySubscriberGrowth.Series.Add(barSeries)

        If ChartMonthlySubscriberGrowth.AxisX.Count > 0 Then
            ChartMonthlySubscriberGrowth.AxisX(0).Labels = monthLabels
        End If

        ChartMonthlySubscriberGrowth.Update()
    End Sub

    Private Sub LoadSubscriberDistributionByPlanChart()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Using cmd As New MySqlCommand()
                    cmd.Connection = conn

                    ' Build Query
                    Dim sb As New System.Text.StringBuilder()
                    sb.Append("SELECT plan_type, COUNT(*) as SubscriberCount FROM customer WHERE 1=1 ")

                    ' Apply filters
                    sb.Append(BuildFilterClause(cmd))

                    sb.Append(" GROUP BY plan_type ORDER BY plan_type")
                    cmd.CommandText = sb.ToString()

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim planData As New Dictionary(Of String, Integer)()
                        Dim totalSubscribers As Integer = 0

                        While reader.Read()
                            Dim planType As String = reader("plan_type").ToString()
                            Dim count As Integer = Convert.ToInt32(reader("SubscriberCount"))
                            planData(planType) = count
                            totalSubscribers += count
                        End While

                        If Me.InvokeRequired Then
                            Me.Invoke(New Action(Sub() UpdateSubscriberDistributionByPlanChart(planData, totalSubscribers)))
                        Else
                            UpdateSubscriberDistributionByPlanChart(planData, totalSubscribers)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            LoadMockSubscriberDistributionByPlanChart()
        End Try
    End Sub

    Private Sub UpdateSubscriberDistributionByPlanChart(planData As Dictionary(Of String, Integer), totalSubscribers As Integer)
        If ChartSubscriberDistributionByPlan Is Nothing Then
            CreateCharts()
            If ChartSubscriberDistributionByPlan Is Nothing Then
                Return
            End If
        End If

        Dim pieSeries As New SeriesCollection()

        Dim colorMap As New Dictionary(Of String, System.Windows.Media.Color) From {
          {"Basic", System.Windows.Media.Color.FromRgb(59, 130, 246)},
          {"Standard", System.Windows.Media.Color.FromRgb(251, 146, 60)},
          {"Premium", System.Windows.Media.Color.FromRgb(34, 197, 94)}
        }

        For Each kvp In planData
            Dim percentage As Double = If(totalSubscribers > 0, (kvp.Value / totalSubscribers) * 100, 0)
            Dim displayText As String = String.Format("{0}: {1} ({2:F1}%)", kvp.Key, kvp.Value, percentage)

            Dim pieSeriesItem As New PieSeries() With {
              .Title = displayText,
              .Values = New ChartValues(Of Double)({kvp.Value}),
              .DataLabels = False,
              .LabelPoint = Function(point) $"{point.Participation:P1}"
            }


            If colorMap.ContainsKey(kvp.Key) Then
                pieSeriesItem.Fill = New SolidColorBrush(colorMap(kvp.Key))
            Else
                pieSeriesItem.Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(156, 163, 175)) ' Gray
            End If

            pieSeries.Add(pieSeriesItem)
        Next

        ChartSubscriberDistributionByPlan.Series = pieSeries

        ChartSubscriberDistributionByPlan.Update()

    End Sub


    Private Sub UpdatePlanMetrics()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Using cmd As New MySqlCommand()
                    cmd.Connection = conn
                    Dim sql As String = "SELECT COUNT(*) FROM customer WHERE 1=1 " & BuildFilterClause(cmd)
                    cmd.CommandText = sql
                    Dim totalSubs As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    SetControlTextByName("ValueTotalSubscribers", totalSubs.ToString("N0"))
                End Using

                Using cmd As New MySqlCommand()
                    cmd.Connection = conn
                    Dim sql As String = "SELECT COUNT(DISTINCT plan_type) FROM customer WHERE account_status = 'Active' " & BuildFilterClause(cmd)
                    cmd.CommandText = sql
                    Dim activePlanCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    SetControlTextByName("ValueMonthlyRevenueActivePlans", activePlanCount.ToString("N0"))
                End Using

                Using cmd As New MySqlCommand()
                    cmd.Connection = conn

                    Dim baseWhere As String = "WHERE 1=1 "
                    If cbAccountStatus.SelectedIndex <= 0 Then baseWhere = "WHERE account_status = 'Active' "

                    Dim sql As String = "SELECT COALESCE(SUM(monthly_rate), 0) FROM customer " & baseWhere & BuildFilterClause(cmd)
                    cmd.CommandText = sql
                    Dim monthlyRevenue As Decimal = Convert.ToDecimal(cmd.ExecuteScalar())
                    SetControlTextByName("ValueMonthlyRevenue", "₱" & monthlyRevenue.ToString("N2"))
                End Using

                Using cmd As New MySqlCommand()
                    cmd.Connection = conn
                    Dim baseWhere As String = "WHERE 1=1 "
                    If cbAccountStatus.SelectedIndex <= 0 Then baseWhere = "WHERE account_status = 'Active' "

                    Dim sql As String = "SELECT COALESCE(AVG(monthly_rate), 0) FROM customer " & baseWhere & BuildFilterClause(cmd)
                    cmd.CommandText = sql
                    Dim avgRevenue As Decimal = Convert.ToDecimal(cmd.ExecuteScalar())
                    SetControlTextByName("ValueRevenuePlan", "₱" & avgRevenue.ToString("N2"))
                End Using

                UpdateDetailedPlanMetrics(conn)

            End Using
        Catch ex As Exception
            LoadMockPlanMetrics()
        End Try
    End Sub

    Private Sub UpdateDetailedPlanMetrics(conn As MySqlConnection)
        Using cmd As New MySqlCommand()
            cmd.Connection = conn
            Dim sql As String = "SELECT plan_type, COUNT(*) as count FROM customer WHERE 1=1 " & BuildFilterClause(cmd) & " GROUP BY plan_type ORDER BY count DESC LIMIT 1"
            cmd.CommandText = sql
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    SetControlTextByName("MostPopularPlan", reader("plan_type").ToString())
                Else
                    SetControlTextByName("MostPopularPlan", "N/A")
                End If
            End Using
        End Using

        Using cmd As New MySqlCommand()
            cmd.Connection = conn
            Dim sql As String = "SELECT plan_type, SUM(monthly_rate) as revenue FROM customer WHERE 1=1 " & BuildFilterClause(cmd) & " GROUP BY plan_type ORDER BY revenue DESC LIMIT 1"
            cmd.CommandText = sql
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    SetControlTextByName("HighestRevenue", "₱" & Convert.ToDecimal(reader("revenue")).ToString("N2"))
                Else
                    SetControlTextByName("HighestRevenue", "₱0.00")
                End If
            End Using
        End Using

        Using cmd As New MySqlCommand()
            cmd.Connection = conn
            Dim sql As String = "SELECT COALESCE(AVG(monthly_rate), 0) as avg_arpu FROM customer WHERE 1=1 " & BuildFilterClause(cmd)
            cmd.CommandText = sql
            Dim arpu As Decimal = Convert.ToDecimal(cmd.ExecuteScalar())
            SetControlTextByName("AverageARPU", "₱" & arpu.ToString("N2"))
        End Using

        Using cmd As New MySqlCommand()
            cmd.Connection = conn
            Dim filterSql As String = BuildFilterClause(cmd)
            Dim sql As String = "SELECT (COUNT(CASE WHEN account_status = 'Active' THEN 1 END) * 100.0 / NULLIF(COUNT(*), 0)) FROM customer WHERE 1=1 " & filterSql
            cmd.CommandText = sql
            Dim result = cmd.ExecuteScalar()
            Dim retentionRate As Decimal = If(IsDBNull(result), 0, Convert.ToDecimal(result))
            SetControlTextByName("RetentionRate", retentionRate.ToString("F1") & "%")
        End Using
    End Sub

    Private Sub UpdatePlanSummaryDetails()
        Try
            ' Ensure the grid doesn't try to make its own columns
            DataGridPlanSummaryDetails.AutoGenerateColumns = False

            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Using cmd As New MySqlCommand()
                    cmd.Connection = conn
                    Dim filterSql As String = BuildFilterClause(cmd)

                    ' ALIASES MUST MATCH YOUR DESIGNER'S DATA-PROPERTY-NAME
                    ' FIXED: Removed leading newline and simplified concatenation
                    Dim query As String = "SELECT " &
                                        "plan_type as PlanType, " &
                                        "monthly_rate as MonthlyRate, " &
                                        "COUNT(*) as TotalSubscribers, " &
                                        "SUM(CASE WHEN account_status = 'Active' THEN 1 ELSE 0 END) as Active, " &
                                        "SUM(CASE WHEN account_status = 'Suspended' THEN 1 ELSE 0 END) as Suspended, " &
                                        "SUM(CASE WHEN account_status = 'Active' THEN monthly_rate ELSE 0 END) as MonthlyRevenue " &
                                        "FROM customer " &
                                        "WHERE 1=1 " & filterSql & " " &
                                        "GROUP BY plan_type, monthly_rate " &
                                        "ORDER BY monthly_rate"

                    cmd.CommandText = query

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        ' Calculate Market Share
                        Dim totalRevenue As Decimal = 0
                        For Each row As DataRow In dt.Rows
                            totalRevenue += If(IsDBNull(row("MonthlyRevenue")), 0, Convert.ToDecimal(row("MonthlyRevenue")))
                        Next

                        ' Add the MarketShare column to the DataTable
                        dt.Columns.Add("MarketShare", GetType(String))
                        For Each row As DataRow In dt.Rows
                            Dim revenue As Decimal = If(IsDBNull(row("MonthlyRevenue")), 0, Convert.ToDecimal(row("MonthlyRevenue")))
                            Dim share As Decimal = If(totalRevenue > 0, (revenue / totalRevenue) * 100, 0)
                            row("MarketShare") = share.ToString("F1") & "%"
                        Next

                        DataGridPlanSummaryDetails.DataSource = dt
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            LoadMockPlanSummaryDetails()
        End Try
    End Sub


    Private Sub DataGridServiceRequestDetails_SelectionChanged(
  sender As Object,
  e As EventArgs
) Handles DataGridPlanSummaryDetails.SelectionChanged
        DataGridPlanSummaryDetails.ClearSelection()
    End Sub


    Private Sub UpdateTopPerformingPlans()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Using cmd As New MySqlCommand()
                    cmd.Connection = conn
                    Dim filterSql As String = BuildFilterClause(cmd)

                    Dim query As String = "SELECT " &
                          "plan_type, " &
                          "COUNT(*) as total_subscribers, " &
                          "SUM(monthly_rate) as monthly_revenue " &
                          "FROM customer " &
                          "WHERE account_status = 'Active' " & filterSql & " " &
                          "GROUP BY plan_type " &
                          "ORDER BY monthly_revenue DESC, total_subscribers DESC " &
                          "LIMIT 3"

                    cmd.CommandText = query

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        ClearTopPerformingPlans()

                        For i As Integer = 0 To Math.Min(2, dt.Rows.Count - 1)
                            Dim row As DataRow = dt.Rows(i)
                            UpdateTopPerformingPlanUI(i + 1, row)
                        Next
                    End Using
                End Using
            End Using
        Catch ex As Exception
            LoadMockTopPerformingPlans()
        End Try
    End Sub

    Private Sub ClearTopPerformingPlans()
        ClearPlanPanel(Panelbasic)
        ClearPlanPanel(PanelStandard)
        ClearPlanPanel(PanelPremium)
    End Sub

    Private Sub ClearPlanPanel(panel As PanelRound)
        For Each ctrl As Control In panel.Controls
            If TypeOf ctrl Is Label Then
                DirectCast(ctrl, Label).Text = "[N/A]"
            End If
        Next
    End Sub

    Private Sub UpdateTopPerformingPlanUI(rank As Integer, row As DataRow)
        Dim planType As String = If(IsDBNull(row("plan_type")), "Unknown", row("plan_type").ToString())
        Dim subscribers As Integer = If(IsDBNull(row("total_subscribers")), 0, Convert.ToInt32(row("total_subscribers")))
        Dim revenue As Decimal = If(IsDBNull(row("monthly_revenue")), 0, Convert.ToDecimal(row("monthly_revenue")))

        Select Case rank
            Case 1
                PlanType1st.Text = planType
                TotalSubscribers1st.Text = $"{subscribers:N0} subscribers"
                MonthlyRevenue1st.Text = "₱" & revenue.ToString("N2")
                PanelNumber1.BackColor = Color.FromArgb(255, 255, 192)
                labelNumber1.ForeColor = Color.DarkGoldenrod

            Case 2
                PlantType2nd.Text = planType
                TotalSubscribers2nd.Text = $"{subscribers:N0} subscribers"
                MonthlyRevenue2nd.Text = "₱" & revenue.ToString("N2")
                PanelNumber2.BackColor = Color.FromArgb(240, 240, 240)
                LabelNumber2.ForeColor = Color.Gray

            Case 3
                PlantType3rd.Text = planType
                TotalSubscribers3rd.Text = $"{subscribers:N0} subscribers"
                MonthlyRevenue3rd.Text = "₱" & revenue.ToString("N2")
                PanelNumber3.BackColor = Color.FromArgb(255, 228, 196)
                LabelNumber3.ForeColor = Color.Sienna
        End Select
    End Sub

    Private Sub SetControlTextByName(controlName As String, text As String)
        Try
            Dim found() As Control = Me.Controls.Find(controlName, True)
            If found IsNot Nothing AndAlso found.Length > 0 Then
                found(0).Text = text
            End If
        Catch
        End Try
    End Sub

    Private Sub LoadMockMonthlySubscriberGrowthChart()
        Dim monthLabels As New List(Of String) From {
          "Jan", "Feb", "Mar", "Apr", "May", "Jun",
          "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
        }

        Dim subscriberCounts As New List(Of Double)()
        Dim random As New Random()
        For i As Integer = 0 To 11
            subscriberCounts.Add(random.Next(50, 200))
        Next

        UpdateMonthlySubscriberGrowthChart(monthLabels, subscriberCounts)
    End Sub

    Private Sub LoadMockSubscriberDistributionByPlanChart()
        Dim planData As New Dictionary(Of String, Integer)() From {
          {"Basic", 350},
          {"Standard", 450},
          {"Premium", 200}
        }

        UpdateSubscriberDistributionByPlanChart(planData, 1000)
    End Sub

    Private Sub LoadMockPlanMetrics()
        SetControlTextByName("ValueTotalSubscribers", "1,250")
        SetControlTextByName("ValueMonthlyRevenueActivePlans", "3")
        SetControlTextByName("ValueMonthlyRevenue", "₱1,256,500.00")
        SetControlTextByName("ValueRevenuePlan", "₱1,004.40")

        SetControlTextByName("MostPopularPlan", "Standard")
        SetControlTextByName("HighestRevenue", "₱675,000.00")
        SetControlTextByName("AverageARPU", "₱1,004.40")
        SetControlTextByName("RetentionRate", "92.5%")
    End Sub

    Private Sub LoadMockPlanSummaryDetails()
        DataGridPlanSummaryDetails.AutoGenerateColumns = False

        Dim dt As New DataTable()
        dt.Columns.Add("Plan Type", GetType(String))
        dt.Columns.Add("Monthly Rate", GetType(String))
        dt.Columns.Add("Total Subscribers", GetType(Integer))
        dt.Columns.Add("Active", GetType(Integer))
        dt.Columns.Add("Suspended", GetType(Integer))
        dt.Columns.Add("Monthly Revenue", GetType(String))
        dt.Columns.Add("Market Share", GetType(String))

        dt.Rows.Add("Basic", "₱700.00", 350, 320, 30, 0, "₱224,000.00", "17.8%")
        dt.Rows.Add("Standard", "₱1,000.00", 450, 420, 30, 0, "₱420,000.00", "33.5%")
        dt.Rows.Add("Premium", "₱1,500.00", 200, 190, 10, 0, "₱285,000.00", "22.7%")

        dt.Rows.Add("Business Basic", "₱2,500.00", 120, 115, 5, 0, "₱287,500.00", "22.9%")
        dt.Rows.Add("Business Pro", "₱5,000.00", 50, 48, 2, 0, "₱240,000.00", "19.1%")


        DataGridPlanSummaryDetails.DataSource = dt

    End Sub

    Private Sub LoadMockTopPerformingPlans()
        ClearTopPerformingPlans()

        PlanType1st.Text = "Standard"
        TotalSubscribers1st.Text = "450 subscribers"
        MonthlyRevenue1st.Text = "₱450,000.00"
        PanelNumber1.BackColor = Color.FromArgb(255, 255, 192)
        labelNumber1.ForeColor = Color.DarkGoldenrod

        PlantType2nd.Text = "Premium"
        TotalSubscribers2nd.Text = "200 subscribers"
        MonthlyRevenue2nd.Text = "₱300,000.00"
        PanelNumber2.BackColor = Color.FromArgb(240, 240, 240)
        LabelNumber2.ForeColor = Color.Gray

        PlantType3rd.Text = "Basic"
        TotalSubscribers3rd.Text = "350 subscribers"
        MonthlyRevenue3rd.Text = "₱245,000.00"
        PanelNumber3.BackColor = Color.FromArgb(255, 228, 196)
        LabelNumber3.ForeColor = Color.Sienna
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        LoadChartsData()
        UpdatePlanMetrics()
        UpdatePlanSummaryDetails()
        UpdateTopPerformingPlans()
    End Sub

    Private Sub cbDateRange_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDateRange.SelectedIndexChanged
        LoadChartsData()
        UpdatePlanMetrics()
        UpdatePlanSummaryDetails()
        UpdateTopPerformingPlans()
    End Sub

    Private Sub cbAccountStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAccountStatus.SelectedIndexChanged
        LoadChartsData()
        UpdatePlanMetrics()
        UpdatePlanSummaryDetails()
        UpdateTopPerformingPlans()
    End Sub


    Private Sub BtnPlansExport_Click(sender As Object, e As EventArgs) Handles BtnPlansExport.Click
        Try
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "CSV Files (.csv)|.csv|PDF Files (.pdf)|.pdf|Excel Files (.xlsx)|.xlsx"
            saveDialog.Title = "Export Plan Summary Report"
            saveDialog.FileName = "Plan_Summary_Report_" & DateTime.Now.ToString("yyyyMMdd_HHmmss")

            If saveDialog.ShowDialog() = DialogResult.OK Then
                ExportPlanSummaryToCSV(saveDialog.FileName)
                MessageBox.Show("Report exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error exporting report: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportPlanSummaryToCSV(filePath As String)
        Dim dt As DataTable = TryCast(DataGridPlanSummaryDetails.DataSource, DataTable)
        If dt Is Nothing Then
            MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using writer As New System.IO.StreamWriter(filePath)
            ' Write headers
            Dim headers As New List(Of String)()
            For Each column As DataColumn In dt.Columns
                headers.Add(column.ColumnName)
            Next
            writer.WriteLine(String.Join(",", headers))

            ' Write data
            For Each row As DataRow In dt.Rows
                Dim values As New List(Of String)()
                For Each column As DataColumn In dt.Columns
                    Dim value As Object = row(column)
                    Dim stringValue As String = If(value Is Nothing, "", value.ToString())

                    If stringValue.Contains(",") OrElse stringValue.Contains("""") Then
                        stringValue = """" & stringValue.Replace("""", """""") & """"
                    End If

                    values.Add(stringValue)
                Next
                writer.WriteLine(String.Join(",", values))
            Next
        End Using
    End Sub

    Private Sub DataGridPlanSummaryDetails_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridPlanSummaryDetails.CellFormatting
        ' Check if the column is MonthlyRate or MonthlyRevenue
        Dim colName As String = DataGridPlanSummaryDetails.Columns(e.ColumnIndex).DataPropertyName

        If (colName = "MonthlyRate" Or colName = "MonthlyRevenue") AndAlso e.Value IsNot Nothing Then
            If Decimal.TryParse(e.Value.ToString(), Nothing) Then
                e.Value = String.Format("₱{0:N2}", e.Value)
                e.FormattingApplied = True
            End If
        End If

        Dim columnName As String = DataGridPlanSummaryDetails.Columns(e.ColumnIndex).Name

        If columnName = "MonthlyRate" OrElse columnName = "MonthlyRevenue" Then

            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Else

            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        End If

    End Sub

    Private Sub PanelFilters_Paint(sender As Object, e As PaintEventArgs) Handles PanelFilters.Paint

    End Sub
End Class