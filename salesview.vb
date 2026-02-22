Imports System.Collections.Generic
Imports System.Configuration
Imports System.Drawing
Imports System.Windows.Media
Imports LiveCharts
Imports LiveCharts.WinForms
Imports LiveCharts.Wpf
Imports MySqlConnector
Imports Windows.Win32.System
Public Class salesview

    Private _connectionString As String = Nothing

    Private Const PAGE_SIZE As Integer = 25
    Private currentPageIndex As Integer = 0
    Private totalRecords As Integer = 0

    Private updateTimer As Timer

    Private salesBindingSource As New BindingSource()

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


    Private ChartMonthlySales As LiveCharts.WinForms.CartesianChart

    'FOR UI
    Private Sub dgvRecentSales_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        Dim col = dgvRecentSales.Columns(e.ColumnIndex)

        ' Format Customer ID to 00001
        If col.Name = "CustomerID" OrElse col.DataPropertyName = "CustomerID" Then
            If e.Value IsNot Nothing AndAlso IsNumeric(e.Value) Then
                e.Value = Convert.ToInt32(e.Value).ToString("D5")
                e.FormattingApplied = True
            End If
        End If

        ' Format Date to MM/dd/yyyy
        If col.Name = "colDateInstalled" OrElse col.DataPropertyName = "DateInstalled" Then
            If e.Value IsNot Nothing AndAlso TypeOf e.Value Is Date Then
                Dim dateValue As Date = CType(e.Value, Date)
                e.Value = If(dateValue <> Date.MinValue, dateValue.ToString("MM/dd/yyyy"), "N/A")
                e.FormattingApplied = True
            End If
        End If
    End Sub


    ' Data for Labels
    Private Function GetTotalSales() As Integer

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim query As String = "SELECT COUNT(*) FROM customer_data WHERE date_installed IS NOT NULL"
                Dim cmd As New MySqlCommand()
                cmd.Connection = conn

                ' Month filter
                If CBDateRange.SelectedItem IsNot Nothing AndAlso CBDateRange.SelectedItem.ToString() <> "All Time" Then
                    query &= " AND MONTHNAME(date_installed) = @MonthName"
                    cmd.Parameters.AddWithValue("@MonthName", CBDateRange.SelectedItem.ToString())
                Else
                    query &= " AND YEAR(date_installed) = YEAR(CURDATE())"
                End If

                ' Plan filter
                If CBPlanType.SelectedItem IsNot Nothing AndAlso CBPlanType.SelectedItem.ToString() <> "All Plans" Then
                    Dim planType As String = CBPlanType.SelectedItem.ToString().Split(" "c)(0)
                    query &= " AND plan_type = @PlanType"
                    cmd.Parameters.AddWithValue("@PlanType", planType)
                End If

                cmd.CommandText = query
                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using

        Catch
            Return 0
        End Try

    End Function

    Private Function GetMonthlyRevenue() As Decimal

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim query As String =
                "SELECT COALESCE(SUM(p.amount_paid),0)
                 FROM payment p
                 INNER JOIN customer_data c ON p.customer_id = c.customer_id
                 WHERE c.date_installed IS NOT NULL"

                Dim cmd As New MySqlCommand()
                cmd.Connection = conn

                ' Month filter
                If CBDateRange.SelectedItem IsNot Nothing AndAlso CBDateRange.SelectedItem.ToString() <> "All Time" Then
                    query &= " AND MONTHNAME(c.date_installed) = @MonthName"
                    cmd.Parameters.AddWithValue("@MonthName", CBDateRange.SelectedItem.ToString())
                Else
                    query &= " AND YEAR(c.date_installed) = YEAR(CURDATE())"
                End If

                ' Plan filter
                If CBPlanType.SelectedItem IsNot Nothing AndAlso CBPlanType.SelectedItem.ToString() <> "All Plans" Then
                    Dim planType As String = CBPlanType.SelectedItem.ToString().Split(" "c)(0)
                    query &= " AND c.plan_type = @PlanType"
                    cmd.Parameters.AddWithValue("@PlanType", planType)
                End If

                cmd.CommandText = query
                Return Convert.ToDecimal(cmd.ExecuteScalar())
            End Using

        Catch
            Return 0
        End Try

    End Function

    Private Function GetAvgRevenue() As Decimal

        Try
            Dim totalSales As Integer = GetTotalSales()
            If totalSales > 0 Then
                Dim revenue As Decimal = GetMonthlyRevenue()
                Return revenue / totalSales
            Else
                Return 0
            End If

        Catch ex As Exception
            Return 0
        End Try

    End Function

    Private Sub UpdateSalesLabel()

        Dim salesValue As Integer = GetTotalSales()
        TotalSales.Text = salesValue.ToString()

        Dim monthlyRevenue As Decimal = GetMonthlyRevenue()
        MonthlyRev.Text = "₱" & monthlyRevenue.ToString("N2")

        Dim avgRevenue As Decimal = GetAvgRevenue()
        AvgRev.Text = "₱" & avgRevenue.ToString("N2")

    End Sub

    'FOR CHARTS
    Private Sub CreateSalesChart()

        ChartMonthlySales = New LiveCharts.WinForms.CartesianChart()
        ChartMonthlySales.Dock = DockStyle.Fill
        ChartMonthlySales.BackColor = System.Drawing.Color.White
        ChartMonthlySales.Location = New Point(0, 40)
        ChartMonthlySales.Size = New Size(pnlMonthlySalesVol.Width, pnlMonthlySalesVol.Height - 50)
        PanelRound1.Controls.Add(ChartMonthlySales)
        ChartMonthlySales.BringToFront()

    End Sub

    Private Sub LoadMonthlySalesChart()

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim query As String = "SELECT MONTHNAME(date_installed) AS month_name, COUNT(*) AS sales_count FROM customer_data WHERE date_installed IS NOT NULL"

                If CBDateRange.SelectedItem IsNot Nothing AndAlso CBDateRange.SelectedItem.ToString() <> "All Time" Then
                    Dim monthName As String = CBDateRange.SelectedItem.ToString()
                    query &= " AND MONTHNAME(date_installed) = '" & monthName & "'"
                Else
                    query &= " AND YEAR(date_installed) = YEAR(CURDATE())"
                End If

                If CBPlanType.SelectedItem IsNot Nothing AndAlso CBPlanType.SelectedItem.ToString() <> "All Plans" Then
                    Dim planFilter As String = CBPlanType.SelectedItem.ToString()
                    If planFilter.StartsWith("Basic") Then
                        query &= " AND plan_type = 'Basic'"
                    ElseIf planFilter.StartsWith("Standard") Then
                        query &= " AND plan_type = 'Standard'"
                    ElseIf planFilter.StartsWith("Premium") Then
                        query &= " AND plan_type = 'Premium'"
                    End If
                End If

                query &= " GROUP BY MONTH(date_installed), MONTHNAME(date_installed) ORDER BY MONTH(date_installed)"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim monthlyData As New Dictionary(Of String, Integer)()

                        While reader.Read()
                            Dim monthName As String = reader("month_name").ToString()
                            Dim count As Integer = Convert.ToInt32(reader("sales_count"))
                            monthlyData(monthName) = count
                        End While

                        ' Get current month and show 6 months before and 6 months after (13 months total)
                        Dim currentMonth As Integer = DateTime.Now.Month
                        Dim currentYear As Integer = DateTime.Now.Year
                        Dim monthLabels As New List(Of String)()
                        Dim monthNumbers As New List(Of Integer)()

                        ' Generate month labels starting from 6 months ago to 6 months ahead
                        For i As Integer = -6 To 6
                            Dim monthIndex As Integer = currentMonth + i
                            Dim yearOffset As Integer = 0

                            While monthIndex < 1
                                monthIndex += 12
                                yearOffset -= 1
                            End While
                            While monthIndex > 12
                                monthIndex -= 12
                                yearOffset += 1
                            End While

                            Dim monthName As String = New DateTime(currentYear + yearOffset, monthIndex, 1).ToString("MMM")
                            monthLabels.Add(monthName)
                            monthNumbers.Add(monthIndex)
                        Next

                        Dim values As New ChartValues(Of Double)()
                        Dim displayLabels As New List(Of String)()

                        For i As Integer = 0 To monthLabels.Count - 1
                            Dim monthLabel As String = monthLabels(i)
                            Dim found As Boolean = False

                            For Each kvp In monthlyData
                                If kvp.Key.StartsWith(monthLabel, StringComparison.OrdinalIgnoreCase) Then
                                    values.Add(kvp.Value)
                                    found = True
                                    Exit For
                                End If
                            Next

                            If Not found Then
                                values.Add(0)
                            End If

                            displayLabels.Add(monthLabel)
                        Next

                        If Me.InvokeRequired Then
                            Me.Invoke(New Action(Sub() UpdateSalesChart(values, displayLabels)))
                        Else
                            UpdateSalesChart(values, displayLabels)
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading sales chart: " & ex.Message)
        End Try

    End Sub

    Private Sub UpdateSalesChart(values As ChartValues(Of Double), labels As List(Of String))

        If ChartMonthlySales.Series.Count = 0 Then

            Dim axisX As New Axis()
            axisX.Title = "Month"
            axisX.Labels = labels
            axisX.MinValue = 0
            axisX.MaxValue = labels.Count - 1
            ChartMonthlySales.AxisX.Add(axisX)

            Dim axisY As New Axis()
            axisY.Title = "Sales Volume"
            axisY.MinValue = 0
            ChartMonthlySales.AxisY.Add(axisY)

            Dim series As New ColumnSeries()
            series.Title = "Sales"
            series.Values = values
            series.Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(59, 130, 246))
            ChartMonthlySales.Series.Add(series)

            ChartMonthlySales.Zoom = ZoomingOptions.X
            ChartMonthlySales.Pan = PanningOptions.X

        Else
            ChartMonthlySales.Series(0).Values = values
            If ChartMonthlySales.AxisX.Count > 0 Then
                ChartMonthlySales.AxisX(0).Labels = labels
            End If
        End If

    End Sub

    ' FOR TABLE
    Private Sub LoadRecentSales(Optional keepScroll As Boolean = False)
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim selectQuery As String = "SELECT customer_id, first_name, last_name, date_installed, plan_type, monthly_rate FROM customer_data WHERE 1=1"
                Dim countQuery As String = "SELECT COUNT(*) FROM customer_data WHERE 1=1"
                Dim whereClause As New System.Text.StringBuilder()
                Dim searchText As String = txtSalesSearchSA.Text.Trim()

                If CBDateRange.SelectedItem IsNot Nothing AndAlso CBDateRange.SelectedItem.ToString() <> "All Time" Then
                    whereClause.Append(" AND date_installed Is Not NULL AND MONTHNAME(date_installed) = @MonthName")
                End If

                If CBPlanType.SelectedItem IsNot Nothing AndAlso CBPlanType.SelectedItem.ToString() <> "All Plans" Then
                    whereClause.Append(" AND plan_type = @PlanType")
                End If

                ' 3. SEARCH FILTER
                If Not String.IsNullOrWhiteSpace(searchText) Then
                    ' Added LPAD to the customer_id check so users can search "00001"
                    whereClause.Append(" AND (customer_id LIKE @Search " &
                       " OR LPAD(customer_id, 5, '0') LIKE @Search " &
                       " OR first_name LIKE @Search " &
                       " OR last_name LIKE @Search " &
                       " OR CONCAT(first_name, ' ', last_name) LIKE @Search " &
                       " OR date_format(date_installed, '%m/%d/%Y') LIKE @Search)")
                End If

                Using cmdCount As New MySqlCommand(countQuery & whereClause.ToString(), conn)
                    AddParameters(cmdCount, searchText)
                    totalRecords = Convert.ToInt32(cmdCount.ExecuteScalar())
                End Using

                Dim totalPages As Integer = CInt(Math.Ceiling(totalRecords / PAGE_SIZE))
                If currentPageIndex >= totalPages Then currentPageIndex = Math.Max(0, totalPages - 1)
                Dim offset As Integer = currentPageIndex * PAGE_SIZE

                Dim finalQuery As String = selectQuery & whereClause.ToString() &
                " ORDER BY date_installed DESC, customer_id DESC LIMIT @Limit OFFSET @Offset"

                Using cmd As New MySqlCommand(finalQuery, conn)
                    AddParameters(cmd, searchText)
                    cmd.Parameters.AddWithValue("@Limit", PAGE_SIZE)
                    cmd.Parameters.AddWithValue("@Offset", offset)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        salesBindingSource.Clear()
                        While reader.Read()
                            Dim record As New SalesRecord2()
                            If Not reader.IsDBNull(reader.GetOrdinal("customer_id")) Then
                                record.CustomerID = Convert.ToInt32(reader("customer_id"))
                            End If
                            Dim cid As Integer = Convert.ToInt32(reader("customer_id"))
                            If Not reader.IsDBNull(reader.GetOrdinal("customer_id")) Then
                                record.CustomerID = reader("customer_id").ToString() ' Keep as string or int depending on your SalesRecord2 class
                            End If
                            record.Name = (reader("first_name").ToString() & " " & reader("last_name").ToString()).Trim()
                            record.DateInstalled = If(reader.IsDBNull(reader.GetOrdinal("date_installed")), Date.MinValue, Convert.ToDateTime(reader("date_installed")))
                            record.PlanType = reader("plan_type").ToString()
                            record.MonthlyRate = Convert.ToDecimal(reader("monthly_rate"))
                            salesBindingSource.Add(record)
                        End While
                    End Using
                End Using

                UpdatePaginationControls()
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

    End Sub

    Private Sub AddParameters(ByRef cmd As MySqlCommand, searchText As String)

        If CBDateRange.SelectedItem IsNot Nothing AndAlso CBDateRange.SelectedItem.ToString() <> "All Time" Then
            cmd.Parameters.AddWithValue("@MonthName", CBDateRange.SelectedItem.ToString())
        End If
        If CBPlanType.SelectedItem IsNot Nothing AndAlso CBPlanType.SelectedItem.ToString() <> "All Plans" Then
            Dim planType As String = CBPlanType.SelectedItem.ToString().Split(" "c)(0)
            cmd.Parameters.AddWithValue("@PlanType", planType)
        End If
        If Not String.IsNullOrWhiteSpace(searchText) Then
            cmd.Parameters.AddWithValue("@Search", "%" & searchText & "%")
        End If

    End Sub

    'FOR FILTERS
    Private Sub PopulateDropdowns()

        Me.CBDateRange.Items.Clear()
        Me.CBDateRange.Items.Add("All Time")
        Me.CBDateRange.Items.AddRange(New String() {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
            })

        Me.CBPlanType.Items.Clear()
        Me.CBPlanType.Items.Add("All Plans")
        Me.CBPlanType.Items.AddRange(New String() {"Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})

    End Sub

    Private Sub Filters_Changed(sender As Object, e As EventArgs)

        currentPageIndex = 0
        UpdateSalesLabel()
        LoadMonthlySalesChart()
        LoadRecentSales()

    End Sub

    ' FOR SEARCH
    Private Sub txtSalesSearchSA_TextChanged(sender As Object, e As EventArgs) Handles txtSalesSearchSA.TextChanged

        Static searchTimer As New Timer With {.Interval = 500}
        RemoveHandler searchTimer.Tick, AddressOf PerformSearch
        AddHandler searchTimer.Tick, AddressOf PerformSearch
        searchTimer.Start()

    End Sub

    Private Sub PerformSearch(sender As Object, e As EventArgs)

        CType(sender, Timer).Stop()
        currentPageIndex = 0
        LoadRecentSales()

    End Sub

    Private Sub SearchSales(searchText As String)

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim query As String = "SELECT customer_id, first_name, last_name, date_installed, plan_type, monthly_rate
                                       FROM customer_data WHERE date_installed IS NOT NULL AND (
                                       customer_id LIKE @Search OR first_name LIKE @Search
                                       OR last_name LIKE @Search OR CONCAT(first_name, ' ', last_name)
                                       LIKE @Search)"

                Dim cmd As New MySqlCommand()
                cmd.Connection = conn
                cmd.Parameters.AddWithValue("@Search", "%" & searchText & "%")

                If CBDateRange.SelectedItem IsNot Nothing AndAlso CBDateRange.SelectedItem.ToString() <> "All Time" Then
                    query &= " AND MONTHNAME(date_installed) = @MonthName"
                    cmd.Parameters.AddWithValue("@MonthName", CBDateRange.SelectedItem.ToString())
                End If

                If CBPlanType.SelectedItem IsNot Nothing AndAlso CBPlanType.SelectedItem.ToString() <> "All Plans" Then
                    Dim planType As String = CBPlanType.SelectedItem.ToString().Split(" "c)(0)
                    query &= " AND plan_type = @PlanType"
                    cmd.Parameters.AddWithValue("@PlanType", planType)
                End If

                query &= " ORDER BY date_installed DESC, customer_id DESC"
                cmd.CommandText = query

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    Dim results As New List(Of SalesRecord2)()

                    While reader.Read()
                        Dim record As New SalesRecord2()

                        Dim cid As Integer = Convert.ToInt32(reader("customer_id"))
                        record.CustomerID = Convert.ToInt32(reader("customer_id"))

                        Dim firstName As String = reader("first_name").ToString()
                        Dim lastName As String = reader("last_name").ToString()
                        record.Name = (firstName & " " & lastName).Trim()

                        record.DateInstalled = Convert.ToDateTime(reader("date_installed"))

                        Select Case reader("plan_type").ToString()
                            Case "Basic" : record.PlanType = "Basic 25Mbps"
                            Case "Standard" : record.PlanType = "Standard 50Mbps"
                            Case "Premium" : record.PlanType = "Premium 100Mbps"
                            Case Else : record.PlanType = "Unknown Plan"
                        End Select

                        record.MonthlyRate = Convert.ToDecimal(reader("monthly_rate"))

                        results.Add(record)
                    End While

                    salesBindingSource.Clear()
                    For Each r In results
                        salesBindingSource.Add(r)
                    Next

                    dgvRecentSales.ClearSelection()

                    totalRecords = results.Count
                    btnNext.Enabled = False
                    btnSalesPreviousSA.Enabled = False

                    If Me.Controls.Find("lblPageInfo", True).Length > 0 Then
                        CType(Me.Controls.Find("lblPageInfo", True)(0), Label).Text =
                            $"Search Results: {results.Count}"
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Search error: " & ex.Message)
        End Try

    End Sub

    ' FOR PAGING
    Private Sub UpdatePaginationControls()

        Dim totalPages As Integer = CInt(Math.Ceiling(totalRecords / PAGE_SIZE))

        btnSalesPreviousSA.Enabled = currentPageIndex > 0
        btnSalesPreviousSA.Visible = currentPageIndex > 0

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

    Private Sub btnSalesPreviousSA_Click(sender As Object, e As EventArgs) Handles btnSalesPreviousSA.Click

        If currentPageIndex > 0 Then
            currentPageIndex -= 1
            LoadRecentSales()
        End If

    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

        Dim totalPages As Integer = CInt(Math.Ceiling(totalRecords / PAGE_SIZE))

        If currentPageIndex < totalPages - 1 Then
            currentPageIndex += 1
            LoadRecentSales()
        End If

    End Sub

    ' FOR EXPORT
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

        Dim exportForm As New SASalesExport()
        exportForm.ShowDialog()

    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)

        UpdateSalesLabel()
        LoadMonthlySalesChart()
        LoadRecentSales(keepScroll:=True)

    End Sub

    Private Sub salesview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PopulateDropdowns()
        Me.CBDateRange.SelectedIndex = 0
        Me.CBPlanType.SelectedIndex = 0

        CreateSalesChart()

        dgvRecentSales.AutoGenerateColumns = True
        dgvRecentSales.DataSource = salesBindingSource

        UpdateSalesLabel()
        LoadMonthlySalesChart()
        LoadRecentSales()
        AddHandler dgvRecentSales.CellFormatting, AddressOf dgvRecentSales_CellFormatting
        AddHandler CBDateRange.SelectedIndexChanged, AddressOf Filters_Changed
        AddHandler CBPlanType.SelectedIndexChanged, AddressOf Filters_Changed

        updateTimer = New Timer()
        updateTimer.Interval = 30000
        AddHandler updateTimer.Tick, AddressOf Timer_Tick
        updateTimer.Start()

    End Sub

End Class

