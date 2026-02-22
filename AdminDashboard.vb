Imports LiveCharts
Imports LiveCharts.Wpf
Imports System.Configuration
Imports MySqlConnector
Imports System.Drawing
Imports System.Windows.Media
Imports System.Collections.Generic
Imports LiveCharts.WinForms

Public Class AdminDashboard

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

    Private ChartSubscriberGrowth As LiveCharts.WinForms.CartesianChart
    Private ChartServiceStatus As LiveCharts.WinForms.PieChart
    Private ChartSubscribersByPlan As LiveCharts.WinForms.PieChart

    Private updateTimer As Timer

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub LblSubscribers_Click(sender As Object, e As EventArgs) Handles AmountSubscribers.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles percentInProgress.Click

    End Sub

    Private Sub dashboardview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateCharts()
        LoadKPIData()
        LoadSubscriberChart()
        LoadServiceStatusChart()
        LoadSubscribersByPlanChart()

        updateTimer = New Timer()
        updateTimer.Interval = 30000
        AddHandler updateTimer.Tick, AddressOf Timer_Tick
        updateTimer.Start()
    End Sub

    Private Sub CreateCharts()
        ChartSubscriberGrowth = New LiveCharts.WinForms.CartesianChart()
        ChartSubscriberGrowth.Dock = DockStyle.Fill
        Panel1.Controls.Add(ChartSubscriberGrowth) ' Assuming Panel1 is where the chart goes inside the parent PanelRound5
        ChartSubscriberGrowth.BringToFront()

        ChartServiceStatus = New LiveCharts.WinForms.PieChart()
        ChartServiceStatus.Dock = DockStyle.Fill
        ChartServiceStatus.BackColor = System.Drawing.Color.White
        ChartServiceStatus.LegendLocation = LegendLocation.None
        Panel2.Controls.Add(ChartServiceStatus)
        ChartServiceStatus.BringToFront()

        ChartSubscribersByPlan = New LiveCharts.WinForms.PieChart()
        ChartSubscribersByPlan.Dock = DockStyle.Fill
        ChartSubscribersByPlan.BackColor = System.Drawing.Color.White
        ChartSubscribersByPlan.LegendLocation = LegendLocation.None
        Panel3.Controls.Add(ChartSubscribersByPlan)
        ChartSubscribersByPlan.BringToFront()
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        LoadSubscriberChart()
        LoadServiceStatusChart()
        LoadSubscribersByPlanChart()
    End Sub

    Private Sub LoadKPIData()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim currentNewSubsQuery As String = "SELECT COUNT(*) FROM customer WHERE account_status = 'Active' AND MONTH(date_installed) = MONTH(CURDATE()) AND YEAR(date_installed) = YEAR(CURDATE())"
                Dim currentNewSubs As Integer
                Using cmd As New MySqlCommand(currentNewSubsQuery, conn)
                    currentNewSubs = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                Dim previousNewSubsQuery As String = "SELECT COUNT(*) FROM customer WHERE account_status = 'Active' AND MONTH(date_installed) = MONTH(DATE_SUB(CURDATE(), INTERVAL 1 MONTH)) AND YEAR(date_installed) = YEAR(DATE_SUB(CURDATE(), INTERVAL 1 MONTH))"
                Dim previousNewSubs As Integer
                Using cmd As New MySqlCommand(previousNewSubsQuery, conn)
                    previousNewSubs = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                Dim totalSubsQuery As String = "SELECT COUNT(*) FROM customer WHERE account_status = 'Active'"
                Dim totalSubs As Integer
                Using cmd As New MySqlCommand(totalSubsQuery, conn)
                    totalSubs = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                Dim subPercentageChange As Double = 0.0
                If previousNewSubs > 0 Then
                    subPercentageChange = ((CDbl(currentNewSubs) - CDbl(previousNewSubs)) / CDbl(previousNewSubs)) * 100
                ElseIf currentNewSubs > 0 Then
                End If

                AmountSubscribers.Text = totalSubs.ToString("N0")
                Dim subText As String = $"{If(subPercentageChange >= 0, "+", "")}{subPercentageChange.ToString("N2")}% from last month"
                PercentTotalSub.Text = subText
                PercentTotalSub.ForeColor = If(subPercentageChange >= 0, System.Drawing.Color.FromArgb(0, 201, 80), System.Drawing.Color.FromArgb(239, 68, 68)) ' Green for growth, Red for decline

                Dim currentRevenueQuery As String = "SELECT COALESCE(SUM(amount_paid), 0) FROM payment WHERE MONTH(date_of_payment) = MONTH(CURDATE()) AND YEAR(date_of_payment) = YEAR(CURDATE())"
                Dim currentRevenue As Decimal
                Using cmd As New MySqlCommand(currentRevenueQuery, conn)
                    currentRevenue = Convert.ToDecimal(cmd.ExecuteScalar())
                End Using

                Dim previousRevenueQuery As String = "SELECT COALESCE(SUM(amount_paid), 0) FROM payment WHERE MONTH(date_of_payment) = MONTH(DATE_SUB(CURDATE(), INTERVAL 1 MONTH)) AND YEAR(date_of_payment) = YEAR(DATE_SUB(CURDATE(), INTERVAL 1 MONTH))"
                Dim previousRevenue As Decimal
                Using cmd As New MySqlCommand(previousRevenueQuery, conn)
                    previousRevenue = Convert.ToDecimal(cmd.ExecuteScalar())
                End Using

                Dim revPercentageChange As Double = 0.0
                If previousRevenue > 0 Then
                    revPercentageChange = ((CDbl(currentRevenue) - CDbl(previousRevenue)) / CDbl(previousRevenue)) * 100
                ElseIf currentRevenue > 0 Then
                    revPercentageChange = 100.0
                End If

                AmountMonthlyRev.Text = "₱" & currentRevenue.ToString("N2")
                Dim revText As String = $"{If(revPercentageChange >= 0, "+", "")}{revPercentageChange.ToString("N2")}% from last month"
                PercentMonthlyRev.Text = revText
                PercentMonthlyRev.ForeColor = If(revPercentageChange >= 0, System.Drawing.Color.FromArgb(0, 201, 80), System.Drawing.Color.FromArgb(239, 68, 68)) ' Green or Red


                Dim currentInstallsQuery As String = "SELECT COUNT(*) FROM service WHERE service_type = 'Installation' AND status IN ('Requested', 'In Progress', 'In-progress') AND MONTH(date_requested) = 11 AND YEAR(date_requested) = 2025"
                Dim currentInstalls As Integer
                Using cmd As New MySqlCommand(currentInstallsQuery, conn)
                    currentInstalls = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                Dim previousInstallsQuery As String = "SELECT COUNT(*) FROM service WHERE service_type = 'Installation' AND status IN ('Requested', 'In Progress', 'In-progress') AND MONTH(date_requested) = 10 AND YEAR(date_requested) = 2025"
                Dim previousInstalls As Integer
                Using cmd As New MySqlCommand(previousInstallsQuery, conn)
                    previousInstalls = Convert.ToInt32(cmd.ExecuteScalar())
                End Using


                Dim installPercentageChange As Double = 0.0
                If previousInstalls > 0 Then
                    installPercentageChange = ((CDbl(currentInstalls) - CDbl(previousInstalls)) / CDbl(previousInstalls)) * 100
                ElseIf currentInstalls > 0 Then
                    installPercentageChange = 100.0
                End If

                AmountActiveInstall.Text = currentInstalls.ToString("N0")
                Dim installText As String = $"{If(installPercentageChange >= 0, "+", "")}{installPercentageChange.ToString("N2")}% from last month"
                PercentActiveInstall.Text = installText
                PercentActiveInstall.ForeColor = If(installPercentageChange >= 0, System.Drawing.Color.FromArgb(0, 201, 80), System.Drawing.Color.FromArgb(239, 68, 68)) ' Green or Red


                Dim currentPendingQuery As String = "SELECT COUNT(*) FROM service WHERE status = 'Requested'"
                Dim currentPending As Integer
                Using cmd As New MySqlCommand(currentPendingQuery, conn)
                    currentPending = Convert.ToInt32(cmd.ExecuteScalar())
                End Using


                Dim previousPendingComparisonQuery As String = "SELECT COUNT(*) FROM service WHERE status = 'Completed' AND MONTH(date_completed) = MONTH(DATE_SUB(CURDATE(), INTERVAL 1 MONTH)) AND YEAR(date_completed) = YEAR(DATE_SUB(CURDATE(), INTERVAL 1 MONTH))"
                Dim previousPendingComparison As Integer
                Using cmd As New MySqlCommand(previousPendingComparisonQuery, conn)
                    previousPendingComparison = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                Dim pendingPercentageChange As Double = 0.0
                If previousPendingComparison > 0 Then
                    pendingPercentageChange = ((CDbl(currentPending) - CDbl(previousPendingComparison)) / CDbl(previousPendingComparison)) * 100
                ElseIf currentPending > 0 Then
                    pendingPercentageChange = 100.0
                End If

                AmountPendingServices.Text = currentPending.ToString("N0")
                Dim pendingText As String = $"{If(pendingPercentageChange >= 0, "+", "")}{pendingPercentageChange.ToString("N2")}% from last month"
                PercentPendingService.Text = pendingText
                PercentPendingService.ForeColor = If(pendingPercentageChange < 0, System.Drawing.Color.FromArgb(0, 201, 80), System.Drawing.Color.FromArgb(239, 68, 68))

                Dim basicQuery As String = "SELECT COUNT(*) FROM customer WHERE plan_type = 'Basic' AND account_status = 'Active'"
                Using cmd As New MySqlCommand(basicQuery, conn)
                    Dim basicSubs As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    AmountBasic.Text = basicSubs.ToString("N0")
                End Using

                Dim standardQuery As String = "SELECT COUNT(*) FROM customer WHERE plan_type = 'Standard' AND account_status = 'Active'"
                Using cmd As New MySqlCommand(standardQuery, conn)
                    Dim standardSubs As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    AmountStandard.Text = standardSubs.ToString("N0")
                End Using

                Dim premiumQuery As String = "SELECT COUNT(*) FROM customer WHERE plan_type = 'Premium' AND account_status = 'Active'"
                Using cmd As New MySqlCommand(premiumQuery, conn)
                    Dim premiumSubs As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    AmountPremium.Text = premiumSubs.ToString("N0")
                End Using

            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading KPI data: " & ex.Message)
        End Try
    End Sub

    Private Sub UpdateServiceStatusPercentageLabels(percentages As Dictionary(Of String, Double))

        If percentages.ContainsKey("Requested") Then
            percentRequested.Text = percentages("Requested").ToString("F0") & "%"
        End If

        If percentages.ContainsKey("In Progress") Then
            percentInProgress.Text = percentages("In Progress").ToString("F0") & "%"
        ElseIf percentages.ContainsKey("In-progress") Then
            percentInProgress.Text = percentages("In-progress").ToString("F0") & "%"
        End If

        If percentages.ContainsKey("Completed") Then
            percentCompleted.Text = percentages("Completed").ToString("F0") & "%"
        End If
    End Sub

    Private Sub LoadSystemAlerts()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim alerts As New List(Of String)()

                Dim lowStockQuery As String = "SELECT COUNT(*) FROM inventory WHERE quantity <= 10"
                Using cmd As New MySqlCommand(lowStockQuery, conn)
                    Dim lowStockCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If lowStockCount > 0 Then
                        alerts.Add("Low Stock Inventory: " & lowStockCount & " items need restocking")
                    End If
                End Using

                Dim pendingInstallsQuery As String = "SELECT COUNT(*) FROM customer WHERE account_status = 'Pending' AND DATE(date_installed) = DATE_ADD(CURDATE(), INTERVAL 1 DAY)"
                Using cmd As New MySqlCommand(pendingInstallsQuery, conn)
                    Dim pendingCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If pendingCount > 0 Then
                        alerts.Add(pendingCount & " pending installations tomorrow")
                    End If
                End Using

                Dim revenueQuery As String = "SELECT COALESCE(SUM(amount_paid), 0) FROM payment WHERE MONTH(date_of_payment) = MONTH(CURDATE()) AND YEAR(date_of_payment) = YEAR(CURDATE())"

                Using cmd As New MySqlCommand(revenueQuery, conn)
                    Dim revenue As Decimal = Convert.ToDecimal(cmd.ExecuteScalar())
                    Dim target As Decimal = 2000000
                    If revenue >= target Then
                        Dim percentage As Integer = CInt((revenue / target) * 100)
                        alerts.Add("Monthly revenue target reached (" & percentage & "%)")
                    End If
                End Using


            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading alerts: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadSubscriberChart()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Dim query As String = "SELECT MONTH(date_installed) AS month_num, MONTHNAME(date_installed) AS month_name, COUNT(*) AS subscriber_count FROM customer WHERE date_installed >= DATE_SUB(CURDATE(), INTERVAL 6 MONTH) GROUP BY MONTH(date_installed), MONTHNAME(date_installed) ORDER BY MONTH(date_installed)"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim monthlyData As New SortedDictionary(Of Integer, Integer)()

                        While reader.Read()
                            Dim monthNum As Integer = Convert.ToInt32(reader("month_num"))
                            Dim count As Integer = Convert.ToInt32(reader("subscriber_count"))
                            monthlyData(monthNum) = count
                        End While

                        Dim labelsList As New List(Of String)
                        Dim valuesList As New ChartValues(Of Double)()
                        Dim today As DateTime = DateTime.Now

                        For i As Integer = -5 To 0
                            Dim monthDate As DateTime = today.AddMonths(i)
                            Dim monthName As String = monthDate.ToString("MMM")
                            Dim monthKey As Integer = monthDate.Month

                            labelsList.Add(monthName)

                            If monthlyData.ContainsKey(monthKey) Then
                                valuesList.Add(monthlyData(monthKey))
                            Else
                                valuesList.Add(0)
                            End If
                        Next

                        Dim dynamicLabels() As String = labelsList.ToArray()

                        If Me.InvokeRequired Then
                            Me.Invoke(New Action(Sub() UpdateSubscriberChart(valuesList, dynamicLabels)))
                        Else
                            UpdateSubscriberChart(valuesList, dynamicLabels)
                        End If
                        ' ---------------------------------
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading subscriber chart: " & ex.Message)
        End Try
    End Sub


    Private Sub UpdateSubscriberChart(values As ChartValues(Of Double), monthLabels() As String)
        If ChartSubscriberGrowth.Series.Count = 0 Then
            Dim axisX As New Axis()
            axisX.Title = "Month"
            axisX.Labels = New List(Of String)(monthLabels)
            axisX.LabelFormatter = Function(value) axisX.Labels(CInt(value))
            ChartSubscriberGrowth.AxisX.Add(axisX)

            Dim axisY As New Axis()
            axisY.Title = "Subscribers"
            axisY.MinValue = 0
            axisY.MaxValue = 3000.0
            axisY.Separator = New Separator() With {.Step = 750.0}
            axisY.LabelFormatter = Function(value) value.ToString("N0")
            ChartSubscriberGrowth.AxisY.Add(axisY)

            Dim series As New ColumnSeries()
            series.Title = "Subscribers"
            series.Values = values
            series.Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(59, 130, 246))
            ChartSubscriberGrowth.Series.Add(series)
        Else
            ChartSubscriberGrowth.Series(0).Values = values
            ChartSubscriberGrowth.AxisX(0).Labels = New List(Of String)(monthLabels)
        End If
    End Sub

    Private Sub LoadServiceStatusChart()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim query As String = "SELECT status AS status, COUNT(*) AS count FROM service GROUP BY status"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim statusData As New Dictionary(Of String, Integer)()

                        While reader.Read()
                            Dim status As String = reader("status").ToString()
                            Dim count As Integer = Convert.ToInt32(reader("count"))
                            statusData(status) = count
                        End While

                        Dim total As Integer = 0
                        For Each value In statusData.Values
                            total += value
                        Next

                        Dim percentages As New Dictionary(Of String, Double)()

                        Dim pieSeries As New SeriesCollection()

                        For Each kvp In statusData
                            Dim percentage As Double = If(total > 0, (kvp.Value / total) * 100, 0)

                            percentages(kvp.Key) = percentage

                            Dim pieSeriesItem As New PieSeries()
                            pieSeriesItem.Title = String.Format("{0} ({1:F0}%)", kvp.Key, percentage)
                            pieSeriesItem.Values = New ChartValues(Of Double)({kvp.Value})
                            pieSeriesItem.DataLabels = False

                            Select Case kvp.Key.ToLower().Trim()
                                Case "completed"
                                    pieSeriesItem.Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(34, 197, 94))
                                Case "in progress", "in-progress"
                                    pieSeriesItem.Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(251, 146, 60))
                                Case "requested"
                                    pieSeriesItem.Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(253, 186, 116))
                            End Select

                            pieSeries.Add(pieSeriesItem)
                        Next

                        If Me.InvokeRequired Then
                            Me.Invoke(New Action(Sub() ChartServiceStatus.Series = pieSeries))
                            Me.Invoke(New Action(Sub() UpdateServiceStatusPercentageLabels(percentages)))
                        Else
                            ChartServiceStatus.Series = pieSeries
                            UpdateServiceStatusPercentageLabels(percentages)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading service status chart: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadSubscribersByPlanChart()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim query As String = "SELECT plan_type, COUNT(*) AS count FROM customer WHERE account_status = 'Active' GROUP BY plan_type"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim planData As New Dictionary(Of String, Integer)()

                        While reader.Read()
                            planData(reader("plan_type").ToString()) = Convert.ToInt32(reader("count"))
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
            MessageBox.Show("Error loading subscribers by plan chart: " & ex.Message)
        End Try
    End Sub

    Private Sub UpdateSubscribersByPlanChart(planData As Dictionary(Of String, Integer))
        Dim total As Integer = 0
        For Each value In planData.Values
            total += value
        Next

        Dim percentages As New Dictionary(Of String, Double)()
        Dim pieSeries As New SeriesCollection()

        For Each kvp In planData
            Dim percentage As Double = If(total > 0, (kvp.Value / total) * 100, 0)

            percentages(kvp.Key) = percentage

            Dim displayText As String = String.Format("{0}: {1} subscribers ({2:F0}%)", kvp.Key, kvp.Value, percentage)

            Dim pieSeriesItem As New PieSeries()
            pieSeriesItem.Title = displayText
            pieSeriesItem.Values = New ChartValues(Of Double)({kvp.Value})
            pieSeriesItem.DataLabels = False

            Select Case kvp.Key.ToLower().Trim()
                Case "basic"
                    pieSeriesItem.Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(59, 130, 246))
                Case "standard"
                    pieSeriesItem.Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(251, 146, 60))
                Case "premium"
                    pieSeriesItem.Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(34, 197, 94))
            End Select

            pieSeries.Add(pieSeriesItem)
        Next

        Me.ChartSubscribersByPlan.Series = pieSeries
        UpdatePlanPercentageLabels(percentages)
    End Sub

    Private Sub UpdatePlanPercentageLabels(percentages As Dictionary(Of String, Double))


        If percentages.ContainsKey("Basic") Then
            PercentBasic.Text = percentages("Basic").ToString("F0") & "%"
        End If

        If percentages.ContainsKey("Standard") Then
            PercentStandard.Text = percentages("Standard").ToString("F0") & "%"
        End If

        If percentages.ContainsKey("Premium") Then
            PercentPremium.Text = percentages("Premium").ToString("F0") & "%"
        End If
    End Sub

    Private Sub PanelRound2_Paint(sender As Object, e As PaintEventArgs) Handles PanelRound2.Paint

    End Sub

    Private Sub AmountActiveInstall_Click(sender As Object, e As EventArgs) Handles AmountActiveInstall.Click

    End Sub
End Class
