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

Public Class payrollview

    Private MonthlyPayrollChart As LiveCharts.WinForms.CartesianChart
    Private PayrollByPositionChart As LiveCharts.WinForms.PieChart

    Private _connectionString As String = Nothing
    Private staffDataTable As DataTable

    Private Const PAGE_SIZE As Integer = 25
    Private currentPageIndex As Integer = 0
    Private totalRecords As Integer = 0
    Private selectedEmployeeID As New List(Of Integer)()

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

    Private Sub payrollview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitializeDataGridView()
        InitializeForm()

        CreateCharts()
        LoadPayrollData()
        LoadMonthlyPayrollChart()
        LoadPayrollByPositionChart()
        LoadPositionPayrollDetails()

    End Sub

    Private Sub CreateCharts()

        MonthlyPayrollChart = New LiveCharts.WinForms.CartesianChart()
        MonthlyPayrollChart.Dock = DockStyle.Fill
        MonthlyPayrollChart.BackColor = System.Drawing.Color.White
        MonthlyPayrollChart.LegendLocation = LegendLocation.Top
        MonthlyPayrollChart.Zoom = ZoomingOptions.X

        If graph IsNot Nothing Then
            graph.Controls.Add(MonthlyPayrollChart)
            MonthlyPayrollChart.BringToFront()
        End If

        PayrollByPositionChart = New LiveCharts.WinForms.PieChart()
        PayrollByPositionChart.Dock = DockStyle.Fill
        PayrollByPositionChart.BackColor = System.Drawing.Color.White
        PayrollByPositionChart.LegendLocation = LegendLocation.Right

    End Sub

    Private Sub DataGridServiceRequestDetails_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridEm0ployeePayrollDetails.SelectionChanged

        DataGridEm0ployeePayrollDetails.ClearSelection()

    End Sub

    'FOR DATA LABELS
    Private Sub LoadPayrollData()

        If String.IsNullOrEmpty(CONNECTION_STRING) Then Return

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Using cmd As New MySqlCommand()
                    cmd.Connection = conn

                    Dim whereClause As String = BuildWhereClause(cmd)

                    cmd.CommandText = "SELECT COUNT(*) FROM staff s " & whereClause
                    Dim totalCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If ValueTotalEmployee IsNot Nothing Then ValueTotalEmployee.Text = totalCount.ToString("N0")

                    cmd.CommandText = "SELECT SUM(COALESCE(s.daily_rate, 0) * 20) FROM staff s " & whereClause
                    Dim resultGross = cmd.ExecuteScalar()
                    Dim grossPay As Decimal = If(IsDBNull(resultGross) OrElse resultGross Is Nothing, 0, Convert.ToDecimal(resultGross))
                    If ValueGrossPay IsNot Nothing Then ValueGrossPay.Text = $"₱ {grossPay:N2}"

                    cmd.CommandText = "SELECT SUM(COALESCE(s.daily_rate, 0) * 20 * 0.1) FROM staff s " & whereClause
                    Dim resultDed = cmd.ExecuteScalar()
                    Dim totalDeductions As Decimal = If(IsDBNull(resultDed) OrElse resultDed Is Nothing, 0, Convert.ToDecimal(resultDed))
                    If ValueTotalDeductions IsNot Nothing Then ValueTotalDeductions.Text = $"₱ {totalDeductions:N2}"

                    cmd.CommandText = "SELECT SUM(COALESCE(s.daily_rate, 0) * 20 * 0.9) FROM staff s " & whereClause
                    Dim resultNet = cmd.ExecuteScalar()
                    Dim netPay As Decimal = If(IsDBNull(resultNet) OrElse resultNet Is Nothing, 0, Convert.ToDecimal(resultNet))
                    If ValueNetPay IsNot Nothing Then ValueNetPay.Text = $"₱ {netPay:N2}"

                End Using
            End Using

        Catch ex As Exception
            Console.WriteLine($"Error loading payroll data: {ex.Message}")
        End Try

    End Sub

    Private Function FormatMonthLabel(monthString As String) As String

        Try
            Dim parts() As String = monthString.Split("-"c)
            If parts.Length = 2 Then
                Dim year As Integer = Integer.Parse(parts(0))
                Dim month As Integer = Integer.Parse(parts(1))
                Dim monthNames() As String = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}
                If month >= 1 AndAlso month <= 12 Then
                    Return $"{monthNames(month - 1)} {year}"
                End If
            End If
        Catch
        End Try
        Return monthString

    End Function

    'FOR CHARTS
    Private Sub LoadMonthlyPayrollChart()

        If String.IsNullOrEmpty(CONNECTION_STRING) Then
            LoadDummyMonthlyChart()
            Exit Sub
        End If

        Dim query As String = "
        SELECT 
            position,
            daily_rate,
            COUNT(*) as employee_count
        FROM staff
        WHERE position IS NOT NULL AND daily_rate IS NOT NULL
        AND is_deleted = 0 GROUP BY position, daily_rate
        ORDER BY position"

        Dim data As New Dictionary(Of String, Dictionary(Of String, Double))()
        Dim months As New List(Of String)()
        Dim positions As New List(Of String)()

        Dim currentDate As Date = Date.Now
        For i As Integer = 5 To 0 Step -1
            Dim monthDate As Date = currentDate.AddMonths(-i)
            months.Add(monthDate.ToString("yyyy-MM"))
        Next

        Using conn As New MySqlConnection(CONNECTION_STRING)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim posName As String = If(reader.IsDBNull(reader.GetOrdinal("position")), "Unknown", reader.GetString("position"))
                            Dim dailyRate As Double = If(reader.IsDBNull(reader.GetOrdinal("daily_rate")), 0, reader.GetDouble("daily_rate"))
                            Dim employeeCount As Integer = 0
                            If Not reader.IsDBNull(reader.GetOrdinal("employee_count")) Then
                                employeeCount = reader.GetInt32("employee_count")
                            End If

                            If String.IsNullOrEmpty(posName) OrElse employeeCount = 0 OrElse dailyRate = 0 Then
                                Continue While
                            End If

                            If Not positions.Contains(posName) Then
                                positions.Add(posName)
                            End If

                            If Not data.ContainsKey(posName) Then
                                data.Add(posName, New Dictionary(Of String, Double)())
                            End If

                            Dim rand As New Random(DateTime.Now.Millisecond)
                            For monthIndex As Integer = 0 To months.Count - 1
                                Dim mon As String = months(monthIndex)
                                Dim variation As Double = 1.0 + (rand.NextDouble() * 0.1 - 0.05)
                                Dim monthlyPay As Double = dailyRate * 20 * employeeCount * variation

                                If data(posName).ContainsKey(mon) Then
                                    data(posName)(mon) += monthlyPay
                                Else
                                    data(posName).Add(mon, monthlyPay)
                                End If
                            Next
                        End While
                    End Using
                End Using

            Catch ex As Exception
                Console.WriteLine($"Error loading monthly chart data: {ex.Message}")
                MessageBox.Show($"Chart Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                LoadDummyMonthlyChart()
                Exit Sub
            End Try

        End Using

        MonthlyPayrollChart.Series.Clear()
        Dim seriesCollection As New SeriesCollection()
        Dim colors As System.Windows.Media.Color() = {
            System.Windows.Media.Color.FromRgb(255, 99, 132),
            System.Windows.Media.Color.FromRgb(54, 162, 235),
            System.Windows.Media.Color.FromRgb(255, 205, 86),
            System.Windows.Media.Color.FromRgb(75, 192, 192),
            System.Windows.Media.Color.FromRgb(153, 102, 255)
        }
        Dim colorIndex As Integer = 0

        For Each posName In positions
            Dim values As New ChartValues(Of Double)()
            For Each monLabel In months
                If data.ContainsKey(posName) AndAlso data(posName).ContainsKey(monLabel) Then
                    values.Add(data(posName)(monLabel) * 0.9)
                Else
                    values.Add(0)
                End If
            Next

            If values.Count > 0 Then
                seriesCollection.Add(New LineSeries With {
                    .Title = posName,
                    .Values = values,
                    .PointGeometry = DefaultGeometries.Circle,
                    .PointGeometrySize = 10,
                    .PointForeground = System.Windows.Media.Brushes.White,
                    .Stroke = New SolidColorBrush(colors(colorIndex Mod colors.Length)),
                    .StrokeThickness = 2,
                    .Fill = System.Windows.Media.Brushes.Transparent,
                    .LineSmoothness = 0.5
                })
                colorIndex += 1
            End If
        Next

        If seriesCollection.Count = 0 Then
            LoadDummyMonthlyChart()
            Exit Sub
        End If

        MonthlyPayrollChart.Series = seriesCollection
        MonthlyPayrollChart.AxisX.Clear()
        MonthlyPayrollChart.AxisX.Add(New Axis With {
            .Title = "Month",
            .Labels = months.Select(Function(m) FormatMonthLabel(m)).ToList(),
            .Separator = New Separator() With {.Step = 1}
        })
        MonthlyPayrollChart.AxisY.Clear()
        MonthlyPayrollChart.AxisY.Add(New Axis With {
            .Title = "Amount (₱)",
            .LabelFormatter = Function(value) String.Format("₱{0:0,0}", value),
            .Separator = New Separator()
        })
        MonthlyPayrollChart.LegendLocation = LegendLocation.Top
        MonthlyPayrollChart.Update()

    End Sub

    Private Sub LoadPayrollByPositionChart()

        If String.IsNullOrEmpty(CONNECTION_STRING) Then
            LoadDummyPieChart()
            Exit Sub
        End If

        Dim query As String = "SELECT position, COUNT(*) as employee_count, SUM(COALESCE(daily_rate, 0) * 20) as monthly_payroll FROM staff WHERE position IS NOT NULL AND daily_rate IS NOT NULL AND is_deleted = 0 GROUP BY position HAVING COUNT(*) > 0"
        Dim pieSeries As New SeriesCollection()

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim position As String = If(reader.IsDBNull(reader.GetOrdinal("position")), "Unknown", reader.GetString("position"))
                            Dim monthlyPayroll As Double = 0
                            If Not reader.IsDBNull(reader.GetOrdinal("monthly_payroll")) Then
                                monthlyPayroll = reader.GetDouble("monthly_payroll")
                            End If

                            If String.IsNullOrEmpty(position) OrElse monthlyPayroll <= 0 Then
                                Continue While
                            End If

                            pieSeries.Add(New PieSeries With {
                                .Title = position,
                                .Values = New ChartValues(Of Double)({monthlyPayroll * 0.9}),
                                .DataLabels = True,
                                .LabelPoint = Function(point) $"{point.Y:C0}"
                            })
                        End While
                    End Using
                End Using
            End Using

            If PayrollByPositionChart IsNot Nothing Then
                If pieSeries.Count > 0 Then
                    PayrollByPositionChart.Series = pieSeries
                    PayrollByPositionChart.LegendLocation = LegendLocation.Right
                Else
                    LoadDummyPieChart()
                End If
            End If
        Catch ex As Exception
            Console.WriteLine($"Error loading pie chart data: {ex.Message}")
            LoadDummyPieChart()
        End Try

    End Sub

    Private Sub LoadPositionPayrollDetails()

        If String.IsNullOrEmpty(CONNECTION_STRING) Then
            LoadDummyPositionData()
            Exit Sub
        End If

        Dim query As String = "SELECT position, COUNT(*) as employee_count, SUM(COALESCE(daily_rate, 0) * 20) as total_payroll, AVG(COALESCE(daily_rate, 0) * 20) as average_payroll FROM staff WHERE position IS NOT NULL AND daily_rate IS NOT NULL AND is_deleted = 0 GROUP BY position"

        Using conn As New MySqlConnection(CONNECTION_STRING)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim position As String = If(reader.IsDBNull(reader.GetOrdinal("position")), "Unknown", reader.GetString("position"))
                            Dim employeeCount As Integer = 0
                            Dim totalPayroll As Decimal = 0
                            Dim averagePayroll As Decimal = 0

                            If Not reader.IsDBNull(reader.GetOrdinal("employee_count")) Then
                                employeeCount = reader.GetInt32("employee_count")
                            End If
                            If Not reader.IsDBNull(reader.GetOrdinal("total_payroll")) Then
                                totalPayroll = reader.GetDecimal("total_payroll")
                            End If
                            If Not reader.IsDBNull(reader.GetOrdinal("average_payroll")) Then
                                averagePayroll = reader.GetDecimal("average_payroll")
                            End If

                            Select Case position.ToLower()
                                Case "technician"
                                    If NumberOfTechnician IsNot Nothing Then NumberOfTechnician.Text = $"{employeeCount} Employees"
                                    If TotalPayrollTechnician IsNot Nothing Then TotalPayrollTechnician.Text = $"₱ {totalPayroll:N2}"
                                    If AveragePayrollTechnician IsNot Nothing Then AveragePayrollTechnician.Text = $"₱ {averagePayroll:N2}"
                                Case "customer service"
                                    If NumberOfCS IsNot Nothing Then NumberOfCS.Text = $"{employeeCount} Employees"
                                    If TotalPayrollCS IsNot Nothing Then TotalPayrollCS.Text = $"₱ {totalPayroll:N2}"
                                    If AveragePayrollCS IsNot Nothing Then AveragePayrollCS.Text = $"₱ {averagePayroll:N2}"
                                Case "inventory"
                                    If NumberOfInventory IsNot Nothing Then NumberOfInventory.Text = $"{employeeCount} Employees"
                                    If TotalPayrollInventory IsNot Nothing Then TotalPayrollInventory.Text = $"₱ {totalPayroll:N2}"
                                    If AveragePayrollInventory IsNot Nothing Then AveragePayrollInventory.Text = $"₱ {averagePayroll:N2}"
                            End Select
                        End While
                    End Using
                End Using

            Catch ex As Exception
                Console.WriteLine($"Error loading position data: {ex.Message}")
                LoadDummyPositionData()
            End Try

        End Using

    End Sub

    'FOR TABLE
    Private Sub LoadStaffDetailsForDataGrid()
        If String.IsNullOrEmpty(CONNECTION_STRING) Then Return

        LoadTotalFilteredRecords()

        Dim offset As Integer = currentPageIndex * PAGE_SIZE

        Dim query As String = "
    SELECT 
        s.staff_id as 'EmployeeID',
        CONCAT(s.first_name, ' ', s.last_name) as 'EmployeeName',
        CASE 
            WHEN s.daily_rate >= 450 THEN 'Technician'
            WHEN s.daily_rate >= 365 THEN 'Customer Service'
            WHEN s.daily_rate >= 200 THEN 'Inventory'
            ELSE 'Other'
        END as 'Position',
        COALESCE(s.daily_rate, 0) as 'DailyRate',
        COALESCE(p.days_worked, 0) as 'DaysWorked',
        COALESCE(p.gross_pay, 0) as 'GrossPay',
        COALESCE(p.deductions, 0) as 'Deductions',
        COALESCE(p.net_pay, 0) as 'NetPay'
    FROM staff s
    LEFT JOIN payroll p ON s.staff_id = p.staff_id "

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Using cmd As New MySqlCommand()
                    cmd.Connection = conn

                    Dim whereClause As String = BuildWhereClause(cmd)

                    cmd.CommandText = query & whereClause & " ORDER BY s.last_name, s.first_name LIMIT @PageSize OFFSET @Offset"

                    cmd.Parameters.AddWithValue("@PageSize", PAGE_SIZE)
                    cmd.Parameters.AddWithValue("@Offset", offset)

                    Using adapter As New MySqlDataAdapter(cmd)
                        staffDataTable = New DataTable()
                        adapter.Fill(staffDataTable)
                        If DataGridEm0ployeePayrollDetails IsNot Nothing Then
                            DataGridEm0ployeePayrollDetails.DataSource = staffDataTable
                        End If
                    End Using
                End Using

                UpdatePaginationControls()
            End Using

        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message)
        End Try

    End Sub

    Private Sub LoadTotalFilteredRecords()
        Using conn As New MySqlConnection(CONNECTION_STRING)
            conn.Open()
            Using cmd As New MySqlCommand()
                cmd.Connection = conn
                Dim whereClause As String = BuildWhereClause(cmd)
                cmd.CommandText = "SELECT COUNT(*) FROM staff s " & whereClause
                totalRecords = Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using
    End Sub

    'FOR DUMMY DATA
    Private Sub LoadDummyPayrollData()

        If ValueTotalEmployee IsNot Nothing Then ValueTotalEmployee.Text = "25"
        If ValueGrossPay IsNot Nothing Then ValueGrossPay.Text = "₱ 220,000.00"
        If ValueTotalDeductions IsNot Nothing Then ValueTotalDeductions.Text = "₱ 22,000.00"
        If ValueNetPay IsNot Nothing Then ValueNetPay.Text = "₱ 198,000.00"

    End Sub

    Private Sub LoadDummyMonthlyChart()

        Dim months As String() = {"Jan", "Feb", "Mar", "Apr", "May", "Jun"}
        Dim positions As String() = {"Technician", "Customer Service", "Inventory"}
        Dim seriesCollection As New SeriesCollection()
        Dim colors As System.Windows.Media.Color() = {
            System.Windows.Media.Color.FromRgb(255, 99, 132),
            System.Windows.Media.Color.FromRgb(54, 162, 235),
            System.Windows.Media.Color.FromRgb(255, 205, 86)
        }
        Dim technicianData As Double() = {150000, 155000, 160000, 165000, 170000, 175000}
        Dim csData As Double() = {43800, 44500, 45200, 45900, 46600, 47300}
        Dim inventoryData As Double() = {29200, 29800, 30400, 31000, 31600, 32200}
        Dim dataArrays As New List(Of Double()) From {technicianData, csData, inventoryData}

        For i As Integer = 0 To positions.Length - 1
            seriesCollection.Add(New LineSeries With {
                .Title = positions(i),
                .Values = New ChartValues(Of Double)(dataArrays(i)),
                .PointGeometry = DefaultGeometries.Circle,
                .PointGeometrySize = 10,
                .PointForeground = System.Windows.Media.Brushes.White,
                .Stroke = New SolidColorBrush(colors(i)),
                .StrokeThickness = 2,
                .Fill = System.Windows.Media.Brushes.Transparent,
                .LineSmoothness = 0.5
            })
        Next

        MonthlyPayrollChart.Series = seriesCollection
        MonthlyPayrollChart.AxisX.Clear()
        MonthlyPayrollChart.AxisX.Add(New Axis With {
            .Title = "Month",
            .Labels = months,
            .Separator = New Separator() With {.Step = 1}
        })
        MonthlyPayrollChart.AxisY.Clear()
        MonthlyPayrollChart.AxisY.Add(New Axis With {
            .Title = "Amount (₱)",
            .LabelFormatter = Function(value) String.Format("₱{0:0,0}", value),
            .Separator = New Separator()
        })

        MonthlyPayrollChart.Update()

    End Sub

    Private Sub LoadDummyPieChart()

        Dim pieSeries As New SeriesCollection()
        pieSeries.Add(New PieSeries With {
            .Title = "Technician",
            .Values = New ChartValues(Of Double)({150000}),
            .DataLabels = True,
            .LabelPoint = Function(point) $"₱{point.Y:0,0}"
        })
        pieSeries.Add(New PieSeries With {
            .Title = "Customer Service",
            .Values = New ChartValues(Of Double)({45000}),
            .DataLabels = True,
            .LabelPoint = Function(point) $"₱{point.Y:0,0}"
        })
        pieSeries.Add(New PieSeries With {
            .Title = "Inventory",
            .Values = New ChartValues(Of Double)({30000}),
            .DataLabels = True,
            .LabelPoint = Function(point) $"₱{point.Y:0,0}"
        })

        If PayrollByPositionChart IsNot Nothing Then
            PayrollByPositionChart.Series = pieSeries
            PayrollByPositionChart.LegendLocation = LegendLocation.Right
        End If

    End Sub
    Private Sub LoadDummyPositionData()

        If NumberOfTechnician IsNot Nothing Then NumberOfTechnician.Text = "15 Employees"
        If TotalPayrollTechnician IsNot Nothing Then TotalPayrollTechnician.Text = "₱ 150,000.00"
        If AveragePayrollTechnician IsNot Nothing Then AveragePayrollTechnician.Text = "₱ 10,000.00"

        If NumberOfCS IsNot Nothing Then NumberOfCS.Text = "6 Employees"
        If TotalPayrollCS IsNot Nothing Then TotalPayrollCS.Text = "₱ 43,800.00"
        If AveragePayrollCS IsNot Nothing Then AveragePayrollCS.Text = "₱ 7,300.00"

        If NumberOfInventory IsNot Nothing Then NumberOfInventory.Text = "4 Employees"
        If TotalPayrollInventory IsNot Nothing Then TotalPayrollInventory.Text = "₱ 29,200.00"
        If AveragePayrollInventory IsNot Nothing Then AveragePayrollInventory.Text = "₱ 7,300.00"

    End Sub

    Private Sub LoadDummyStaffData()

        Dim rand As New Random()

        For i As Integer = 1 To 15
            Dim dailyRate As Decimal = 500D + rand.Next(-50, 50)
            Dim daysWorked As Integer = 20

            Dim monthlyGross As Decimal = dailyRate * daysWorked
            Dim deductions As Decimal = monthlyGross * 0.1D
            Dim netPay As Decimal = monthlyGross - deductions

            staffDataTable.Rows.Add(1000 + i, $"Technician Staff {i}", "Technician", dailyRate, daysWorked, monthlyGross, deductions, netPay)
        Next

        For i As Integer = 1 To 6
            Dim dailyRate As Decimal = 365D + rand.Next(-30, 30)
            Dim daysWorked As Integer = 20

            Dim monthlyGross As Decimal = dailyRate * daysWorked
            Dim deductions As Decimal = monthlyGross * 0.1D
            Dim netPay As Decimal = monthlyGross - deductions

            staffDataTable.Rows.Add(2000 + i, $"CS Staff {i}", "Customer Service", dailyRate, daysWorked, monthlyGross, deductions, netPay)
        Next

        For i As Integer = 1 To 4
            Dim dailyRate As Decimal = 365D + rand.Next(-30, 30)
            Dim daysWorked As Integer = 20

            Dim monthlyGross As Decimal = dailyRate * daysWorked
            Dim deductions As Decimal = monthlyGross * 0.1D
            Dim netPay As Decimal = monthlyGross - deductions

            staffDataTable.Rows.Add(3000 + i, $"Inventory Staff {i}", "Inventory", dailyRate, daysWorked, monthlyGross, deductions, netPay)
        Next

        If DataGridEm0ployeePayrollDetails IsNot Nothing Then
            DataGridEm0ployeePayrollDetails.DataSource = staffDataTable
        End If

    End Sub

    Private Sub txtEmployeeName_TextChanged(sender As Object, e As EventArgs)

        FilterEmployeeData()

    End Sub

    Private Sub cbPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPosition.SelectedIndexChanged

        FilterEmployeeData()

    End Sub

    Private Sub cbDateRange_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDateRange.SelectedIndexChanged

        FilterEmployeeData()

    End Sub

    'FOR EXPORT
    Private Sub BtnPayrollExport_Click(sender As Object, e As EventArgs)

        Try
            Dim saveDialog As New SaveFileDialog
            saveDialog.Filter = "CSV Files (.csv)|.csv|Excel Files (.xlsx)|.xlsx"
            saveDialog.Title = "Export Payroll Report"
            saveDialog.FileName = $"Payroll_Report_{Date.Now:yyyyMMdd_HHmmss}"

            If saveDialog.ShowDialog = DialogResult.OK Then
                If saveDialog.FilterIndex = 1 Then
                    ExportToCSV(saveDialog.FileName)
                Else
                    ExportToExcel(saveDialog.FileName)
                End If
                MessageBox.Show($"Report exported successfully to {saveDialog.FileName}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error exporting report: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim exportForm As New SAPayrollExport
        exportForm.ShowDialog()
    End Sub

    Private Sub ExportToCSV(filePath As String)

        If staffDataTable IsNot Nothing Then
            Using writer As New System.IO.StreamWriter(filePath)
                Dim headers As New List(Of String)()
                For Each col As DataColumn In staffDataTable.Columns
                    headers.Add(col.ColumnName)
                Next
                writer.WriteLine(String.Join(",", headers))

                For Each row As DataRow In staffDataTable.Rows
                    Dim values As New List(Of String)()
                    For Each col As DataColumn In staffDataTable.Columns
                        values.Add(row(col).ToString())
                    Next
                    writer.WriteLine(String.Join(",", values))
                Next
            End Using
        End If

    End Sub

    Private Sub ExportToExcel(filePath As String)

        ExportToCSV(filePath)

    End Sub

    'FOR FILTERS
    Private Sub FilterEmployeeData()

        currentPageIndex = 0

        LoadStaffDetailsForDataGrid()

        LoadPayrollData()
    End Sub

    Private Sub InitializeFilters()

        If cbPosition IsNot Nothing Then
            cbPosition.Items.Clear()
            cbPosition.Items.Add("All Positions")
            If Not String.IsNullOrEmpty(CONNECTION_STRING) Then
                Try
                    Using conn As New MySqlConnection(CONNECTION_STRING)
                        conn.Open()
                        Dim query As String = "SELECT DISTINCT position FROM staff WHERE position IS NOT NULL ORDER BY position"
                        Using cmd As New MySqlCommand(query, conn)
                            Using reader As MySqlDataReader = cmd.ExecuteReader()
                                While reader.Read()
                                    If Not reader.IsDBNull(reader.GetOrdinal("position")) Then
                                        cbPosition.Items.Add(reader.GetString("position"))
                                    End If
                                End While
                            End Using
                        End Using
                    End Using
                Catch ex As Exception
                    cbPosition.Items.Add("Technician")
                    cbPosition.Items.Add("Customer Service")
                    cbPosition.Items.Add("Inventory")
                End Try
            End If
            cbPosition.SelectedIndex = 0
        End If

        If cbDateRange IsNot Nothing Then
            cbDateRange.Items.Clear()
            cbDateRange.Items.Add("All Time")
            cbDateRange.Items.Add("Last Month")
            cbDateRange.Items.Add("Last 3 Months")
            cbDateRange.Items.Add("Last 6 Months")
            cbDateRange.Items.Add("This Year")
            cbDateRange.SelectedIndex = 0
        End If

    End Sub

    Private Sub InitializeForm()

        InitializeFilters()

        LoadTotalRecords()
        currentPageIndex = 0
        LoadStaffDetailsForDataGrid()
        UpdatePaginationControls()

    End Sub


    Private Sub DataGridEm0ployeePayrollDetails_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridEm0ployeePayrollDetails.CellDoubleClick

        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = DataGridEm0ployeePayrollDetails.Rows(e.RowIndex)
            Dim employeeName As String = If(selectedRow.Cells("EmployeeName").Value IsNot Nothing, selectedRow.Cells("EmployeeName").Value.ToString(), "N/A")
            Dim position As String = If(selectedRow.Cells("Position").Value IsNot Nothing, selectedRow.Cells("Position").Value.ToString(), "N/A")
            Dim grossPay As String = If(selectedRow.Cells("GrossPay").Value IsNot Nothing, selectedRow.Cells("GrossPay").Value.ToString(), "₱ 0.00")
            Dim netPay As String = If(selectedRow.Cells("NetPay").Value IsNot Nothing, selectedRow.Cells("NetPay").Value.ToString(), "₱ 0.00")

            MessageBox.Show($"Employee: {employeeName}" & vbCrLf & $"Position: {position}" & vbCrLf & $"Gross Pay: {grossPay}" & vbCrLf & $"Net Pay: {netPay}", "Employee Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub DataGridEm0ployeePayrollDetails_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridEm0ployeePayrollDetails.ColumnHeaderMouseClick

        If e.ColumnIndex >= 0 Then
            Dim columnName As String = DataGridEm0ployeePayrollDetails.Columns(e.ColumnIndex).Name
            If staffDataTable IsNot Nothing Then
                Dim dv As DataView = staffDataTable.DefaultView
                dv.Sort = $"{columnName} ASC"
                staffDataTable = dv.ToTable()
                DataGridEm0ployeePayrollDetails.DataSource = staffDataTable
            End If
        End If

    End Sub

    Private Sub LoadTotalRecords()

        Dim searchText As String = txtPayrollSearchSA.Text.Trim()
        Dim query As String = "SELECT COUNT(*) FROM staff s WHERE s.daily_rate IS NOT NULL"

        If Not String.IsNullOrWhiteSpace(searchText) Then
            query &= " AND (s.staff_id LIKE @search OR s.first_name LIKE @search OR s.last_name LIKE @search OR CONCAT(s.first_name, ' ', s.last_name) LIKE @search)"
        End If

        Using conn As New MySqlConnection(CONNECTION_STRING)
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                If Not String.IsNullOrWhiteSpace(searchText) Then
                    cmd.Parameters.AddWithValue("@search", "%" & searchText & "%")
                End If
                totalRecords = Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using

    End Sub

    'FOR PAGING
    Private Sub UpdatePaginationControls()

        Dim totalPages As Integer = CInt(Math.Ceiling(totalRecords / PAGE_SIZE))
        btnPayrollPreviousSA.Enabled = currentPageIndex > 0
        btnPayrollPreviousSA.Visible = currentPageIndex > 0
        btnNextPayrollSA.Enabled = currentPageIndex < totalPages - 1

        If Me.Controls.Find("lblPageInfo", True).Length > 0 Then
            Dim lblPageInfo As Label = CType(Me.Controls.Find("lblPageInfo", True)(0), Label)
            If totalRecords > 0 Then
                lblPageInfo.Text = $"Page {currentPageIndex + 1} of {totalPages} (Total: {totalRecords})"
            Else
                lblPageInfo.Text = "No Records Found"
            End If
        End If

    End Sub

    Private Sub btnNextPayrollSA_Click(sender As Object, e As EventArgs) Handles btnNextPayrollSA.Click

        Dim totalPages As Integer = CInt(Math.Ceiling(totalRecords / PAGE_SIZE))
        If currentPageIndex < totalPages - 1 Then
            currentPageIndex += 1
            LoadStaffDetailsForDataGrid()
        End If

    End Sub

    Private Sub btnPayrollPreviousSA_Click(sender As Object, e As EventArgs) Handles btnPayrollPreviousSA.Click

        If currentPageIndex > 0 Then
            currentPageIndex -= 1
            LoadStaffDetailsForDataGrid()
        End If

    End Sub

    Private Sub DataGridEm0ployeePayrollDetails_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridEm0ployeePayrollDetails.CellContentClick

        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Exit Sub
        Dim columnName As String = DataGridEm0ployeePayrollDetails.Columns(e.ColumnIndex).Name
        Dim dataGridView As DataGridView = DirectCast(sender, DataGridView)

        If dataGridView.Columns(e.ColumnIndex).Name = "colEdit" Then

            Dim staffId As Integer = 0
            If dataGridView.Rows(e.RowIndex).Cells("EmployeeID").Value IsNot Nothing Then
                Integer.TryParse(dataGridView.Rows(e.RowIndex).Cells("EmployeeID").Value.ToString(), staffId)
            End If

            If staffId > 0 Then
                Dim updateForm As New frmPayrollUpdate()
                updateForm.SetStaffId(staffId)

                Dim employeeName As String = If(dataGridView.Rows(e.RowIndex).Cells("EmployeeName").Value, "").ToString()
                Dim position As String = If(dataGridView.Rows(e.RowIndex).Cells("Position").Value, "").ToString()
                Dim dailyRate As String = If(dataGridView.Rows(e.RowIndex).Cells("DailyRate").Value, "0").ToString()

                updateForm.SetEmployeeName(employeeName)
                updateForm.SetPosition(position)
                updateForm.SetDailyRate(dailyRate)

                updateForm.ShowDialog()

                LoadStaffDetailsForDataGrid()
            End If
        End If
        If dataGridView.Columns(e.ColumnIndex).Name = "colDelete" Then
            Dim staffId As Integer = 0
            If dataGridView.Rows(e.RowIndex).Cells("EmployeeID").Value IsNot Nothing Then
                Integer.TryParse(dataGridView.Rows(e.RowIndex).Cells("EmployeeID").Value.ToString(), staffId)
            End If

            If staffId > 0 Then
                Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete employee ID {staffId}?",
                                                         "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If result = DialogResult.Yes Then
                    DeleteStaffRecord(staffId)
                End If
            End If
        End If

        If columnName = "colCheckBox" Then
            Dim currentValue As Boolean = CBool(DataGridEm0ployeePayrollDetails.Rows(e.RowIndex).Cells("colCheckBox").Value)
            DataGridEm0ployeePayrollDetails.Rows(e.RowIndex).Cells("colCheckBox").Value = Not currentValue
        End If

    End Sub

    Private Sub ShowUpdateForm(staffId As Integer)

        Try
            Dim updateForm As New frmPayrollUpdate()
            LoadStaffDataForUpdate(updateForm, staffId)
            updateForm.ShowDialog()

            LoadStaffDetailsForDataGrid()
            LoadPayrollData()
            LoadMonthlyPayrollChart()
            LoadPayrollByPositionChart()
            LoadPositionPayrollDetails()
        Catch ex As Exception
            MessageBox.Show($"Error opening update form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub LoadStaffDataForUpdate(updateForm As frmPayrollUpdate, staffId As Integer)

        If String.IsNullOrEmpty(CONNECTION_STRING) Then
            MessageBox.Show("Database connection not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Dim query As String = "SELECT staff_id, first_name, last_name, position, daily_rate FROM staff WHERE staff_id = @staffId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@staffId", staffId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            updateForm.txtEmployeeID.Text = reader.GetInt32("staff_id").ToString("D5")
                            updateForm.txtName.Text = $"{reader.GetString("first_name")} {reader.GetString("last_name")}"

                            Dim position As String = If(reader.IsDBNull(reader.GetOrdinal("position")), "", reader.GetString("position"))
                            updateForm.cbPosition.Text = position

                            Dim dailyRate As Decimal = If(reader.IsDBNull(reader.GetOrdinal("daily_rate")), 0, reader.GetDecimal("daily_rate"))
                            updateForm.DropDownDailyRate.Text = dailyRate.ToString("N2")

                            Dim daysWorked As Integer = 20 ' Default value
                            Dim dailyRateDecimal As Decimal = dailyRate

                            ' Calculate gross pay (daily rate * days worked) - Overtime removed
                            Dim grossPay As Decimal = dailyRateDecimal * daysWorked
                            updateForm.txtGrosPay.Text = grossPay.ToString("N2")

                            ' Calculate deductions (10%)
                            Dim deductions As Decimal = grossPay * 0.1D
                            updateForm.txtDeductions.Text = deductions.ToString("N2")

                            Dim netPay As Decimal = grossPay - deductions
                            updateForm.txtNetPay.Text = netPay.ToString("N2")

                            updateForm.TxtDaysWorked.Text = daysWorked.ToString()

                        Else
                            MessageBox.Show("Employee record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show($"Error loading staff data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DeleteStaffRecord(staffId As Integer)

        If String.IsNullOrEmpty(CONNECTION_STRING) Then
            MessageBox.Show("Database connection not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Dim query As String = "UPDATE staff SET is_deleted = 1 WHERE staff_id = @staffId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@staffId", staffId)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Employee record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        LoadStaffDetailsForDataGrid()
                        LoadPayrollData()
                        LoadMonthlyPayrollChart()
                        LoadPayrollByPositionChart()
                        LoadPositionPayrollDetails()
                    Else
                        MessageBox.Show("No employee record found to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show($"Error deleting staff record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub InitializeDataGridView()

        With DataGridEm0ployeePayrollDetails
            .AutoGenerateColumns = False
        End With

        AddHandler DataGridEm0ployeePayrollDetails.CellClick, AddressOf DataGridEm0ployeePayrollDetails_CellContentClick

    End Sub

    Private Sub DataGridEm0ployeePayrollDetails_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridEm0ployeePayrollDetails.CellFormatting
        If e.RowIndex < 0 Then Return

        Dim colName As String = DataGridEm0ployeePayrollDetails.Columns(e.ColumnIndex).Name

        ' NEW: Format Employee ID to 00001
        If colName = "EmployeeID" Then
            If e.Value IsNot Nothing AndAlso IsNumeric(e.Value) Then
                e.Value = Convert.ToInt32(e.Value).ToString("D5")
                e.FormattingApplied = True
            End If
        End If

        ' Existing Alignment Logic
        If colName = "DailyRate" OrElse colName = "GrossPay" OrElse colName = "NetPay" Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' Optional: Force currency formatting if needed
            If IsNumeric(e.Value) Then
                e.Value = String.Format("₱{0:N2}", e.Value)
                e.FormattingApplied = True
            End If
        Else
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If
    End Sub

    'FOR SEARCH
    Private Sub txtPayrollSearchSA_TextChanged(sender As Object, e As EventArgs) Handles txtPayrollSearchSA.TextChanged

        currentPageIndex = 0

        Static searchDelayTimer As New Timer With {.Interval = 500}
        RemoveHandler searchDelayTimer.Tick, AddressOf OnSearchDelayComplete
        AddHandler searchDelayTimer.Tick, AddressOf OnSearchDelayComplete

        searchDelayTimer.Stop()
        searchDelayTimer.Start()

    End Sub

    Private Sub OnSearchDelayComplete(sender As Object, e As EventArgs)

        Dim t = DirectCast(sender, Timer)
        t.Stop()
        LoadStaffDetailsForDataGrid()

    End Sub

    Private Sub btnSelectSubscriber_Click(sender As Object, e As EventArgs) Handles btnSelectSubscriber.Click
        Dim allSelected As Boolean = True

        For Each row As DataGridViewRow In DataGridEm0ployeePayrollDetails.Rows
            If Not row.IsNewRow Then
                If Not CBool(row.Cells("colCheckBox").Value) Then
                    allSelected = False
                    Exit For
                End If
            End If
        Next

        For Each row As DataGridViewRow In DataGridEm0ployeePayrollDetails.Rows
            If Not row.IsNewRow Then
                row.Cells("colCheckBox").Value = Not allSelected
            End If
        Next

        If Not allSelected Then
            selectedEmployeeID.Clear()
            For Each row As DataGridViewRow In DataGridEm0ployeePayrollDetails.Rows
                If Not row.IsNewRow Then
                    Dim employeeID As Integer = Convert.ToInt32(row.Cells("EmployeeID").Value)
                    selectedEmployeeID.Add(employeeID)
                End If
            Next
        Else
            selectedEmployeeID.Clear()
        End If

        UpdateSelectionUI()
    End Sub

    Private Sub UpdateSelectionUI()
        If selectedEmployeeID.Count > 0 Then

        Else

        End If
    End Sub

    Private Sub DataGridEm0ployeePayrollDetails_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridEm0ployeePayrollDetails.CellValueChanged
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim columnName As String = DataGridEm0ployeePayrollDetails.Columns(e.ColumnIndex).Name

        If columnName = "colCheckBox" Then
            Dim row As DataGridViewRow = DataGridEm0ployeePayrollDetails.Rows(e.RowIndex)
            Dim employeeID As Integer = Convert.ToInt32(row.Cells("EmployeeID").Value)
            Dim isChecked As Boolean = If(row.Cells("colCheckBox").Value IsNot Nothing, CBool(row.Cells("colCheckBox").Value), False)

            If isChecked Then
                If Not selectedEmployeeID.Contains(employeeID) Then
                    selectedEmployeeID.Add(employeeID)
                End If
            Else
                selectedEmployeeID.Remove(employeeID)
            End If

            UpdateSelectionUI()
        End If

    End Sub

    Private Sub deleteAll_Click(sender As Object, e As EventArgs) Handles deleteAll.Click

        If selectedEmployeeID.Count = 0 Then
            MessageBox.Show("Please select at least one employee record to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete the {selectedEmployeeID.Count} selected employee record(s)?",
                                                     "Confirm Bulk Delete",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                Using conn As New MySqlConnection(CONNECTION_STRING)
                    conn.Open()

                    Dim paramNames As New List(Of String)
                    For i As Integer = 0 To selectedEmployeeID.Count - 1
                        paramNames.Add("@id" & i)
                    Next

                    Dim query As String = $"UPDATE staff SET is_deleted = 1 WHERE staff_id IN ({String.Join(",", paramNames)})"


                    Using cmd As New MySqlCommand(query, conn)
                        For i As Integer = 0 To selectedEmployeeID.Count - 1
                            cmd.Parameters.AddWithValue("@id" & i, selectedEmployeeID(i))
                        Next

                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                        MessageBox.Show($"{rowsAffected} employee(s) deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        selectedEmployeeID.Clear()
                        LoadStaffDetailsForDataGrid()
                        LoadPayrollData()
                        LoadMonthlyPayrollChart()
                        LoadPayrollByPositionChart()
                        LoadPositionPayrollDetails()
                        UpdateSelectionUI()
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error deleting records: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub

    Private Function BuildWhereClause(ByVal cmd As MySqlCommand) As String
        Dim conditions As New List(Of String)()

        conditions.Add("s.daily_rate IS NOT NULL")
        conditions.Add("s.is_deleted = 0")

        If Not String.IsNullOrWhiteSpace(txtPayrollSearchSA.Text) Then
            conditions.Add("(s.staff_id LIKE @search OR s.first_name LIKE @search OR s.last_name LIKE @search OR CONCAT(s.first_name, ' ', s.last_name) LIKE @search)")
            cmd.Parameters.AddWithValue("@search", "%" & txtPayrollSearchSA.Text.Trim() & "%")
        End If

        If cbPosition.SelectedItem IsNot Nothing AndAlso cbPosition.SelectedItem.ToString() <> "All Positions" Then
            conditions.Add("s.position = @positionFilter")
            cmd.Parameters.AddWithValue("@positionFilter", cbPosition.SelectedItem.ToString())
        End If

        If cbDateRange.SelectedItem IsNot Nothing Then
            Dim today As Date = Date.Now
            Select Case cbDateRange.SelectedItem.ToString()
                Case "Last Month"
                    conditions.Add("s.date_hired >= @dateStart")
                    cmd.Parameters.AddWithValue("@dateStart", today.AddMonths(-1))
                Case "Last 3 Months"
                    conditions.Add("s.date_hired >= @dateStart")
                    cmd.Parameters.AddWithValue("@dateStart", today.AddMonths(-3))
                Case "Last 6 Months"
                    conditions.Add("s.date_hired >= @dateStart")
                    cmd.Parameters.AddWithValue("@dateStart", today.AddMonths(-6))
                Case "This Year"
                    conditions.Add("YEAR(s.date_hired) = @year")
                    cmd.Parameters.AddWithValue("@year", today.Year)
            End Select
        End If

        Return " WHERE " & String.Join(" AND ", conditions)
    End Function

End Class