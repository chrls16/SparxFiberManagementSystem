Imports System.IO
Imports System.Text
Imports MySqlConnector
Imports System.Configuration
Imports System.Drawing
Imports System.Drawing.Printing
Imports iTextSharpText = iTextSharp.text
Imports iTextSharpTextPdf = iTextSharp.text.pdf

Public Class SAServiceExport
    Private _connectionString As String = Nothing
    Private _totalFee As Decimal = 0

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

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ExportServiceReport()
    End Sub

    Private Sub ExportServiceReport()
        Try
            ' Get parameters from form controls
            Dim serviceType As String = If(cbServiceType.SelectedItem IsNot Nothing, cbServiceType.SelectedItem.ToString(), "")
            Dim startDate As DateTime = DTPStart.Value
            Dim endDate As DateTime = DTPEnd.Value
            Dim timePeriod As String = If(cbTimePeriod.SelectedItem IsNot Nothing, cbTimePeriod.SelectedItem.ToString(), "")

            ' Generate report data
            Dim dt As DataTable = GenerateServiceReportData(startDate, endDate, serviceType, timePeriod)

            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                MessageBox.Show("No data found for the selected criteria.", "Export Service Report", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Get export format from combo box
            If cbExportFormat.SelectedItem Is Nothing Then
                MessageBox.Show("Please select an export format.", "Export Format", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim exportFormat As String = cbExportFormat.SelectedItem.ToString()
            Dim exportAsPDF As Boolean = (exportFormat = "PDF")

            ' Let user choose save location
            Using saveDialog As New SaveFileDialog()
                If exportAsPDF Then
                    saveDialog.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*"
                    saveDialog.FileName = $"Service_Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                Else
                    saveDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
                    saveDialog.FileName = $"Service_Report_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
                End If

                saveDialog.FilterIndex = 1
                saveDialog.RestoreDirectory = True

                If saveDialog.ShowDialog() = DialogResult.OK Then
                    ' Save to selected format
                    If exportAsPDF Then
                        ' Generate PDF using iTextSharp
                        Try
                            Dim criteria As String = GetCriteriaString(startDate, endDate, timePeriod, serviceType)
                            GeneratePDFWithiTextSharp(dt, saveDialog.FileName, criteria)

                            MessageBox.Show($"Service report exported successfully to:{vbCrLf}{saveDialog.FileName}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            ' Optionally open the exported file
                            If MessageBox.Show("Do you want to open the exported file?", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                Try
                                    Process.Start(saveDialog.FileName)
                                Catch ex As Exception
                                    MessageBox.Show($"Cannot open file: {ex.Message}", "Open File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End Try
                            End If
                            Me.Close()

                        Catch ex As Exception
                            MessageBox.Show($"Error generating PDF: {ex.Message}", "PDF Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    Else
                        ' For CSV, calculate total fee first
                        _totalFee = CalculateTotalFee(dt)
                        SaveDataTableToCSV(dt, saveDialog.FileName)
                        MessageBox.Show($"Service report exported successfully to:{vbCrLf}{saveDialog.FileName}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Optionally open the exported file
                        If MessageBox.Show("Do you want to open the exported file?", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Try
                                System.Diagnostics.Process.Start(saveDialog.FileName)
                            Catch ex As Exception
                                MessageBox.Show($"Cannot open file: {ex.Message}", "Open File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End Try
                        End If
                        Me.Close()
                    End If
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show($"Error exporting service report: {ex.Message}{vbCrLf}{ex.StackTrace}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetCriteriaString(startDate As DateTime, endDate As DateTime, timePeriod As String, serviceType As String) As String
        Dim criteria As New StringBuilder()

        ' Date criteria
        If timePeriod = "All Time" Then
            criteria.Append("Date Range: All Time")
        Else
            criteria.Append($"Date Range: {startDate.ToString("MM-dd-yyyy")} to {endDate.ToString("MM-dd-yyyy")}")
        End If

        ' Service type criteria
        If serviceType <> "All" AndAlso Not String.IsNullOrEmpty(serviceType) Then
            criteria.Append($" | Service Type: {serviceType}")
        End If

        Return criteria.ToString()
    End Function

    Private Sub GeneratePDFWithiTextSharp(data As DataTable, filePath As String, criteria As String)
        ' Calculate total fee
        _totalFee = CalculateTotalFee(data)

        ' Create document - Landscape orientation for better table display
        Dim document As New iTextSharpText.Document(iTextSharpText.PageSize.A4.Rotate())
        document.SetMargins(20, 20, 30, 30)

        ' Create PDF writer
        Dim writer As iTextSharpTextPdf.PdfWriter = iTextSharpTextPdf.PdfWriter.GetInstance(document, New FileStream(filePath, FileMode.Create))

        ' Add metadata
        document.AddTitle("Service Report")
        document.AddAuthor("Sparx System")
        document.AddCreationDate()

        ' Open document
        document.Open()

        ' Create fonts using iTextSharp Font
        Dim titleFont = iTextSharpText.FontFactory.GetFont("Arial", 16, iTextSharpText.Font.BOLD, iTextSharpText.BaseColor.BLACK)
        Dim headerFont = iTextSharpText.FontFactory.GetFont("Arial", 10, iTextSharpText.Font.BOLD, iTextSharpText.BaseColor.WHITE)
        Dim normalFont = iTextSharpText.FontFactory.GetFont("Arial", 9, iTextSharpText.Font.NORMAL, iTextSharpText.BaseColor.BLACK)
        Dim criteriaFont = iTextSharpText.FontFactory.GetFont("Arial", 9, iTextSharpText.Font.NORMAL, iTextSharpText.BaseColor.DARK_GRAY)
        Dim summaryFont = iTextSharpText.FontFactory.GetFont("Arial", 10, iTextSharpText.Font.BOLD, iTextSharpText.BaseColor.BLACK)
        Dim totalFont = iTextSharpText.FontFactory.GetFont("Arial", 9, iTextSharpText.Font.BOLD, iTextSharpText.BaseColor.BLACK)

        ' Add title
        Dim title As New iTextSharpText.Paragraph("SERVICE REPORT", titleFont)
        title.Alignment = iTextSharpText.Element.ALIGN_CENTER
        title.SpacingAfter = 10
        document.Add(title)

        ' Add criteria
        Dim criteriaPara As New iTextSharpText.Paragraph(criteria, criteriaFont)
        criteriaPara.Alignment = iTextSharpText.Element.ALIGN_CENTER
        criteriaPara.SpacingAfter = 5
        document.Add(criteriaPara)

        ' Add generated date
        Dim generatedDate As New iTextSharpText.Paragraph($"Generated on: {DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss")}", criteriaFont)
        generatedDate.Alignment = iTextSharpText.Element.ALIGN_CENTER
        generatedDate.SpacingAfter = 15
        document.Add(generatedDate)

        ' Create table with optimized column widths
        Dim columnCount As Integer = data.Columns.Count
        Dim table As New iTextSharpTextPdf.PdfPTable(columnCount)
        table.WidthPercentage = 100
        table.SpacingBefore = 10
        table.SpacingAfter = 10

        ' Set optimized column widths (percentage-based)
        Dim columnWidths As Single() = GetOptimizedColumnWidths(data, columnCount)
        table.SetWidths(columnWidths)

        ' Add table headers
        For Each column As DataColumn In data.Columns
            Dim headerText As String = column.ColumnName
            ' Truncate long headers
            If headerText.Length > 20 Then
                headerText = headerText.Substring(0, 18) & "..."
            End If

            Dim cell As New iTextSharpTextPdf.PdfPCell(New iTextSharpText.Phrase(headerText, headerFont))
            cell.BackgroundColor = New iTextSharpText.BaseColor(70, 130, 180) ' Steel blue
            cell.HorizontalAlignment = iTextSharpText.Element.ALIGN_CENTER
            cell.VerticalAlignment = iTextSharpText.Element.ALIGN_MIDDLE
            cell.Padding = 5
            table.AddCell(cell)
        Next

        ' Add data rows
        For Each row As DataRow In data.Rows
            For Each column As DataColumn In data.Columns
                Dim value As Object = row(column)
                Dim cellText As String = ""

                If value IsNot DBNull.Value AndAlso value IsNot Nothing Then
                    ' Format date columns
                    If column.ColumnName.Contains("Date") AndAlso TypeOf value Is DateTime Then
                        Dim dateValue As DateTime = DirectCast(value, DateTime)
                        cellText = dateValue.ToString("MM-dd-yyyy")
                    ElseIf column.ColumnName = "Service Fee" Then
                        ' Format currency with peso symbol
                        Dim amount As Decimal
                        If Decimal.TryParse(value.ToString(), amount) Then
                            cellText = "₱" & amount.ToString("N2")
                        Else
                            cellText = value.ToString()
                        End If
                    Else
                        cellText = value.ToString()
                    End If
                End If

                ' Truncate long text
                If cellText.Length > 30 Then
                    cellText = cellText.Substring(0, 27) & "..."
                End If

                Dim cell As New iTextSharpTextPdf.PdfPCell(New iTextSharpText.Phrase(cellText, normalFont))
                cell.Padding = 5

                ' Set alignment based on content type
                If column.ColumnName.Contains("Date") Or column.ColumnName.Contains("ID") Then
                    cell.HorizontalAlignment = iTextSharpText.Element.ALIGN_CENTER
                ElseIf column.ColumnName = "Service Fee" Then
                    cell.HorizontalAlignment = iTextSharpText.Element.ALIGN_RIGHT
                Else
                    cell.HorizontalAlignment = iTextSharpText.Element.ALIGN_LEFT
                End If

                table.AddCell(cell)
            Next
        Next

        ' Add totals row
        For i As Integer = 0 To columnCount - 1
            Dim cell As iTextSharpTextPdf.PdfPCell
            Select Case data.Columns(i).ColumnName
                Case "Service ID"
                    cell = New iTextSharpTextPdf.PdfPCell(New iTextSharpText.Phrase("TOTAL", totalFont))
                Case "Service Fee"
                    Dim totalText As String = "₱" & _totalFee.ToString("N2")
                    cell = New iTextSharpTextPdf.PdfPCell(New iTextSharpText.Phrase(totalText, totalFont))
                    cell.HorizontalAlignment = iTextSharpText.Element.ALIGN_RIGHT
                Case Else
                    cell = New iTextSharpTextPdf.PdfPCell(New iTextSharpText.Phrase("", totalFont))
            End Select

            cell.BackgroundColor = New iTextSharpText.BaseColor(255, 255, 200) ' Light yellow
            cell.Padding = 5
            table.AddCell(cell)
        Next

        ' Add table to document
        document.Add(table)

        ' Add summary
        Dim summaryPara As New iTextSharpText.Paragraph("Report Summary", summaryFont)
        summaryPara.SpacingBefore = 20
        document.Add(summaryPara)

        Dim detailsPara As New iTextSharpText.Paragraph($"Total Records: {data.Rows.Count} | Total Service Fee: ₱{_totalFee:N2}", normalFont)
        detailsPara.SpacingAfter = 10
        document.Add(detailsPara)

        ' Add footer with page number
        Dim footerTable As New iTextSharpTextPdf.PdfPTable(1)
        footerTable.WidthPercentage = 100
        footerTable.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin

        Dim footerCell As New iTextSharpTextPdf.PdfPCell(New iTextSharpText.Phrase($"Page {writer.PageNumber}", criteriaFont))
        footerCell.Border = iTextSharpText.Rectangle.NO_BORDER
        footerCell.HorizontalAlignment = iTextSharpText.Element.ALIGN_CENTER
        footerCell.PaddingTop = 10
        footerTable.AddCell(footerCell)

        ' Position footer at bottom
        footerTable.WriteSelectedRows(0, -1, document.LeftMargin, document.BottomMargin, writer.DirectContent)

        ' Close document
        document.Close()
    End Sub

    Private Function GetOptimizedColumnWidths(data As DataTable, columnCount As Integer) As Single()
        ' Optimized column widths for better fit in landscape mode
        Dim widths(columnCount - 1) As Single

        For i As Integer = 0 To columnCount - 1
            Dim columnName As String = data.Columns(i).ColumnName

            Select Case columnName
                Case "Service ID"
                    widths(i) = 8 ' 8% of page width
                Case "Customer", "Name", "Technician"
                    widths(i) = 15 ' 15% of page width
                Case "Service Type"
                    widths(i) = 12 ' 12% of page width
                Case "Date Requested"
                    widths(i) = 12 ' 12% of page width
                Case "Service Fee"
                    widths(i) = 12 ' 12% of page width
                Case "Status"
                    widths(i) = 10 ' 10% of page width
                Case Else
                    widths(i) = 12 ' Default 12% of page width
            End Select
        Next

        ' Ensure total is 100%
        Dim total As Single = 0
        For Each width As Single In widths
            total += width
        Next

        If total <> 100 Then
            ' Adjust to make total 100%
            Dim adjustment As Single = 100 / total
            For i As Integer = 0 To widths.Length - 1
                widths(i) = widths(i) * adjustment
            Next
        End If

        Return widths
    End Function

    Private Function CalculateTotalFee(dt As DataTable) As Decimal
        Dim total As Decimal = 0
        For Each row As DataRow In dt.Rows
            If row("Service Fee") IsNot DBNull.Value Then
                Dim fee As Decimal
                If Decimal.TryParse(row("Service Fee").ToString(), fee) Then
                    total += fee
                End If
            End If
        Next
        Return total
    End Function

    Private Function GenerateServiceReportData(startDate As DateTime, endDate As DateTime, serviceType As String, timePeriod As String) As DataTable
        If String.IsNullOrEmpty(CONNECTION_STRING) Then
            MessageBox.Show("Cannot connect to database.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End If

        Dim dt As New DataTable()

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                ' Build the SQL query based on parameters
                Dim query As New StringBuilder()
                query.AppendLine("SELECT")
                query.AppendLine("    s.service_id AS 'Service ID',")
                query.AppendLine("    CONCAT(c.first_name, ' ', c.last_name) AS 'Customer',")
                query.AppendLine("    s.service_type AS 'Service Type',")
                query.AppendLine("    s.date_requested AS 'Date Requested',")
                query.AppendLine("    CONCAT(st.first_name, ' ', st.last_name) AS 'Technician',")
                query.AppendLine("    s.service_cost AS 'Service Fee',")
                query.AppendLine("    s.status AS 'Status'")
                query.AppendLine("FROM service s")
                query.AppendLine("LEFT JOIN customer c ON s.customer_id = c.customer_id")
                query.AppendLine("LEFT JOIN staff st ON s.staff_id = st.staff_id")
                query.AppendLine("WHERE 1=1") ' Always true for easier conditional adding

                ' Add date filter only if not "All Time"
                If timePeriod <> "All Time" Then
                    ' Adjust end date to include the entire day
                    Dim adjustedEndDate As DateTime = endDate.Date.AddDays(1).AddSeconds(-1)
                    query.AppendLine(" AND s.date_requested BETWEEN @startDate AND @endDate")
                End If

                ' Add service type filter if specified
                If Not String.IsNullOrEmpty(serviceType) AndAlso serviceType <> "All" Then
                    Dim dbServiceType As String = MapServiceType(serviceType)
                    If Not String.IsNullOrEmpty(dbServiceType) Then
                        query.AppendLine(" AND s.service_type = @serviceType")
                    End If
                End If

                query.AppendLine("ORDER BY s.date_requested DESC")

                Using cmd As New MySqlCommand(query.ToString(), conn)
                    ' Only add date parameters if not "All Time"
                    If timePeriod <> "All Time" Then
                        cmd.Parameters.AddWithValue("@startDate", startDate)
                        cmd.Parameters.AddWithValue("@endDate", endDate.Date.AddDays(1).AddSeconds(-1))
                    End If

                    If Not String.IsNullOrEmpty(serviceType) AndAlso serviceType <> "All" Then
                        Dim dbServiceType As String = MapServiceType(serviceType)
                        If Not String.IsNullOrEmpty(dbServiceType) Then
                            cmd.Parameters.AddWithValue("@serviceType", dbServiceType)
                        End If
                    End If

                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using

            Return dt

        Catch ex As Exception
            MessageBox.Show($"Error generating report data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Private Function MapServiceType(displayType As String) As String
        ' Map dropdown display values to database values
        Select Case displayType
            Case "Basic 25Mbps"
                Return "Basic"
            Case "Standard 50Mbps"
                Return "Standard"
            Case "Premium 100Mbps"
                Return "Premium"
            Case Else
                Return displayType ' Return as-is for service types like Installation, Repair, etc.
        End Select
    End Function

    Private Sub SaveDataTableToCSV(dt As DataTable, filePath As String)
        Try
            Using writer As New StreamWriter(filePath, False, Encoding.UTF8)
                ' Add UTF-8 BOM for Excel compatibility
                writer.Write(ChrW(&HFEFF))

                ' Write headers
                Dim headers As New List(Of String)()
                For Each column As DataColumn In dt.Columns
                    headers.Add(column.ColumnName)
                Next
                writer.WriteLine(String.Join(",", headers))

                ' Write data rows
                For Each row As DataRow In dt.Rows
                    Dim fields As New List(Of String)()
                    For Each column As DataColumn In dt.Columns
                        Dim value As Object = row(column)
                        If value Is DBNull.Value Then
                            fields.Add("")
                        Else
                            Dim stringValue As String
                            ' Format date columns properly - Changed to MM-dd-yyyy
                            If column.ColumnName.Contains("Date") AndAlso TypeOf value Is DateTime Then
                                Dim dateValue As DateTime = DirectCast(value, DateTime)
                                stringValue = dateValue.ToString("MM-dd-yyyy")
                            ElseIf column.ColumnName = "Service Fee" Then
                                ' Format currency with peso symbol for CSV
                                Dim amount As Decimal
                                If Decimal.TryParse(value.ToString(), amount) Then
                                    stringValue = $"₱{amount:N2}"
                                Else
                                    stringValue = value.ToString()
                                End If
                            Else
                                stringValue = value.ToString()
                            End If

                            ' Escape commas and quotes for CSV
                            If stringValue.Contains(",") OrElse stringValue.Contains("""") Then
                                stringValue = """" & stringValue.Replace("""", """""") & """"
                            End If
                            fields.Add(stringValue)
                        End If
                    Next
                    writer.WriteLine(String.Join(",", fields))
                Next

                ' Add empty line before total
                writer.WriteLine()

                ' Add total row
                Dim totalFields As New List(Of String)()
                For Each column As DataColumn In dt.Columns
                    If column.ColumnName = "Service ID" Then
                        totalFields.Add("TOTAL")
                    ElseIf column.ColumnName = "Service Fee" Then
                        totalFields.Add($"₱{_totalFee:N2}")
                    Else
                        totalFields.Add("")
                    End If
                Next
                writer.WriteLine(String.Join(",", totalFields))

                ' Add summary line
                writer.WriteLine()
                writer.WriteLine($"Total Records: {dt.Rows.Count}, Total Service Fee: ₱{_totalFee:N2}")
            End Using

        Catch ex As Exception
            Throw New Exception($"Error saving CSV file: {ex.Message}")
        End Try
    End Sub

    Private Sub SAServiceExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set default dates
        DTPStart.Value = DateTime.Now.AddDays(-30) ' Last 30 days
        DTPEnd.Value = DateTime.Now

        ' Set date format to MM-dd-yyyy
        DTPStart.Format = DateTimePickerFormat.Custom
        DTPStart.CustomFormat = "MM-dd-yyyy"
        DTPEnd.Format = DateTimePickerFormat.Custom
        DTPEnd.CustomFormat = "MM-dd-yyyy"

        ' Set default export format to CSV
        cbExportFormat.SelectedIndex = 0

        ' Set "All Time" as default time period
        cbTimePeriod.SelectedIndex = 0

        ' Populate service type combo box with actual service types from database
        LoadServiceTypes()

        ' Disable date pickers for "All Time"
        UpdateDatePickerEnabledState()
    End Sub

    Private Sub LoadServiceTypes()
        Try
            ' Clear existing items
            cbServiceType.Items.Clear()

            ' Add "All" option
            cbServiceType.Items.Add("All")

            ' Load distinct service types from database
            If Not String.IsNullOrEmpty(CONNECTION_STRING) Then
                Using conn As New MySqlConnection(CONNECTION_STRING)
                    conn.Open()
                    Dim query As String = "SELECT DISTINCT service_type FROM service ORDER BY service_type"
                    Using cmd As New MySqlCommand(query, conn)
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            While reader.Read()
                                Dim serviceType As String = reader.GetString(0)
                                If Not cbServiceType.Items.Contains(serviceType) Then
                                    cbServiceType.Items.Add(serviceType)
                                End If
                            End While
                        End Using
                    End Using
                End Using
            End If

            ' Select "All" by default
            cbServiceType.SelectedIndex = 0

        Catch ex As Exception
            Console.WriteLine($"Error loading service types: {ex.Message}")
        End Try
    End Sub

    Private Sub cbTimePeriod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTimePeriod.SelectedIndexChanged
        If cbTimePeriod.SelectedItem Is Nothing Then Return

        Dim selectedPeriod As String = cbTimePeriod.SelectedItem.ToString()
        Dim today As DateTime = DateTime.Now

        Select Case selectedPeriod
            Case "All Time"
                ' Set to a very early date for all records
                DTPStart.Value = New DateTime(2025, 11, 26)
                DTPEnd.Value = today
            Case "Daily"
                DTPStart.Value = today.Date
                DTPEnd.Value = today
            Case "Weekly"
                DTPStart.Value = today.Date.AddDays(-7)
                DTPEnd.Value = today
            Case "Monthly"
                DTPStart.Value = today.Date.AddMonths(-1)
                DTPEnd.Value = today
            Case "Quarterly"
                DTPStart.Value = today.Date.AddMonths(-3)
                DTPEnd.Value = today
            Case "Yearly"
                DTPStart.Value = today.Date.AddYears(-1)
                DTPEnd.Value = today
            Case "Custom"
                ' Don't change dates for custom selection
        End Select

        ' Update date picker enabled state
        UpdateDatePickerEnabledState()
    End Sub

    Private Sub UpdateDatePickerEnabledState()
        If cbTimePeriod.SelectedItem Is Nothing Then Return

        Dim selectedPeriod As String = cbTimePeriod.SelectedItem.ToString()
        Dim isEnabled As Boolean = (selectedPeriod <> "All Time")

        DTPStart.Enabled = isEnabled
        DTPEnd.Enabled = isEnabled
        lblStartDate.Enabled = isEnabled
        lblEndDate.Enabled = isEnabled
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cbServiceType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbServiceType.SelectedIndexChanged
    End Sub

    Private Sub cbExportFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbExportFormat.SelectedIndexChanged
    End Sub
End Class