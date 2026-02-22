Imports System.IO
Imports System.Data
Imports MySqlConnector
Imports System.Configuration
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Text
Imports System.Diagnostics
Imports iTextSharpText = iTextSharp.text
Imports iTextSharpTextPdf = iTextSharp.text.pdf
Imports Color = System.Drawing.Color

Public Class SAInventoryExport
    Private _connectionString As String = Nothing
    Private _totalUnitCost As Decimal = 0
    Private _totalCurrentStock As Integer = 0
    Private _totalItems As Integer = 0

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

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ExportInventoryReport()
    End Sub

    Private Sub ExportInventoryReport()
        Try
            ' Get time period
            Dim timePeriod As String = If(cbTimePeriod.SelectedItem IsNot Nothing, cbTimePeriod.SelectedItem.ToString(), "All Time")
            Dim startDate As DateTime = DTPStart.Value.Date
            Dim endDate As DateTime = DTPEnd.Value.Date

            ' Validate date range if not "All Time"
            If timePeriod <> "All Time" Then
                If startDate > endDate Then
                    MessageBox.Show("Start date cannot be later than end date.", "Invalid Date Range",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End If

            ' Get export format from combo box
            If cbExportFormat.SelectedItem Is Nothing Then
                MessageBox.Show("Please select an export format.", "Export Format", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim exportFormat As String = cbExportFormat.SelectedItem.ToString()
            Dim exportAsPDF As Boolean = (exportFormat = "PDF")

            ' Get inventory data
            Dim dt As DataTable = GetInventoryData(startDate, endDate, timePeriod)

            ' Check if any data was returned
            If dt.Rows.Count = 0 Then
                MessageBox.Show("No inventory items found for the selected criteria.",
                              "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Calculate totals
            CalculateTotals(dt)

            ' Let user choose save location
            Using saveDialog As New SaveFileDialog()
                If exportAsPDF Then
                    saveDialog.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*"
                    saveDialog.FileName = $"Inventory_Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                Else
                    saveDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
                    saveDialog.FileName = $"Inventory_Report_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
                End If

                saveDialog.FilterIndex = 1
                saveDialog.RestoreDirectory = True
                saveDialog.Title = "Export Inventory Report"

                If saveDialog.ShowDialog() = DialogResult.OK Then
                    ' Save to selected format
                    If exportAsPDF Then
                        ' Generate PDF using iTextSharp
                        Try
                            Dim criteria As String = GetCriteriaString(startDate, endDate, timePeriod)
                            GeneratePDFWithiTextSharp(dt, saveDialog.FileName, criteria)

                            MessageBox.Show($"Successfully exported {dt.Rows.Count} records to:{vbCrLf}{saveDialog.FileName}",
                                          "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            ' Optionally open the file after export
                            If MessageBox.Show("Do you want to open the exported file?", "Open File",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                Process.Start(saveDialog.FileName)
                            End If
                            Me.Close()

                        Catch ex As Exception
                            MessageBox.Show($"Error generating PDF: {ex.Message}", "PDF Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    Else
                        ' For CSV export
                        SaveDataTableToCSV(dt, saveDialog.FileName)
                        MessageBox.Show($"Successfully exported {dt.Rows.Count} records to:{vbCrLf}{saveDialog.FileName}",
                                      "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Optionally open the file after export
                        If MessageBox.Show("Do you want to open the exported file?", "Open File",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Process.Start(saveDialog.FileName)
                        End If
                        Me.Close()
                    End If
                End If
            End Using

        Catch ex As MySqlException
            MessageBox.Show($"Database error: {ex.Message}", "Database Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As IOException
            MessageBox.Show($"File access error: {ex.Message}", "File Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Export Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetCriteriaString(startDate As DateTime, endDate As DateTime, timePeriod As String) As String
        Dim criteria As New StringBuilder()

        ' Date criteria
        If timePeriod = "All Time" Then
            criteria.Append("Date Range: All Time")
        Else
            criteria.Append($"Date Range: {startDate.ToString("MM-dd-yyyy")} to {endDate.ToString("MM-dd-yyyy")}")
        End If

        Return criteria.ToString()
    End Function

    Private Sub GeneratePDFWithiTextSharp(data As DataTable, filePath As String, criteria As String)
        ' Create document - Landscape orientation for better table display
        Dim document As New iTextSharpText.Document(iTextSharpText.PageSize.A4.Rotate())
        document.SetMargins(20, 20, 30, 30)

        ' Create PDF writer
        Dim writer As iTextSharpTextPdf.PdfWriter = iTextSharpTextPdf.PdfWriter.GetInstance(document, New FileStream(filePath, FileMode.Create))

        ' Add metadata
        document.AddTitle("Inventory Report")
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
        Dim title As New iTextSharpText.Paragraph("INVENTORY REPORT", titleFont)
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

        ' Create table with appropriate number of columns
        Dim columnCount As Integer = data.Columns.Count
        Dim table As New iTextSharpTextPdf.PdfPTable(columnCount)
        table.WidthPercentage = 100
        table.SpacingBefore = 10
        table.SpacingAfter = 10

        ' Set optimized column widths
        Dim columnWidths As Single() = GetOptimizedColumnWidths(data, columnCount)
        table.SetWidths(columnWidths)

        ' Add table headers with peso symbol for Unit Cost column
        For Each column As DataColumn In data.Columns
            Dim headerText As String = column.ColumnName
            ' Truncate long headers if needed
            If headerText.Length > 20 Then
                headerText = headerText.Substring(0, 18) & "..."
            End If

            ' Add peso symbol to Unit Cost header
            If column.ColumnName = "Unit Cost" Then
                headerText = "Unit Cost (₱)"
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
                    ElseIf column.ColumnName = "Unit Cost" Then
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
                ElseIf column.ColumnName = "Unit Cost" Then
                    cell.HorizontalAlignment = iTextSharpText.Element.ALIGN_RIGHT
                Else
                    cell.HorizontalAlignment = iTextSharpText.Element.ALIGN_LEFT
                End If

                table.AddCell(cell)
            Next
        Next

        ' Add totals row with peso symbol
        For i As Integer = 0 To columnCount - 1
            Dim cell As iTextSharpTextPdf.PdfPCell
            Select Case data.Columns(i).ColumnName
                Case "Item ID"
                    cell = New iTextSharpTextPdf.PdfPCell(New iTextSharpText.Phrase("TOTAL", totalFont))
                Case "Unit Cost"
                    Dim totalText As String = "₱" & _totalUnitCost.ToString("N2")
                    cell = New iTextSharpTextPdf.PdfPCell(New iTextSharpText.Phrase(totalText, totalFont))
                    cell.HorizontalAlignment = iTextSharpText.Element.ALIGN_RIGHT
                Case "Current Stock"
                    cell = New iTextSharpTextPdf.PdfPCell(New iTextSharpText.Phrase(_totalCurrentStock.ToString(), totalFont))
                    cell.HorizontalAlignment = iTextSharpText.Element.ALIGN_CENTER
                Case Else
                    cell = New iTextSharpTextPdf.PdfPCell(New iTextSharpText.Phrase("", totalFont))
            End Select

            cell.BackgroundColor = New iTextSharpText.BaseColor(255, 255, 200) ' Light yellow
            cell.Padding = 5
            table.AddCell(cell)
        Next

        ' Add table to document
        document.Add(table)

        ' Add summary with peso symbol
        Dim summaryPara As New iTextSharpText.Paragraph("Report Summary", summaryFont)
        summaryPara.SpacingBefore = 20
        document.Add(summaryPara)

        Dim detailsPara As New iTextSharpText.Paragraph($"Total Items: {_totalItems} | Total Stock: {_totalCurrentStock} | Total Value: ₱{_totalUnitCost:N2}", normalFont)
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

    Private Sub SaveDataTableToCSV(dt As DataTable, filePath As String)
        Try
            Using writer As New StreamWriter(filePath, False, Encoding.UTF8)
                ' Add UTF-8 BOM for Excel compatibility
                writer.Write(ChrW(&HFEFF))

                ' Write CSV header with peso symbol for Unit Cost
                Dim headers As New List(Of String)
                For Each column As DataColumn In dt.Columns
                    Dim headerText As String = column.ColumnName
                    ' Add peso symbol to Unit Cost header
                    If column.ColumnName = "Unit Cost" Then
                        headerText = "Unit Cost (₱)"
                    End If
                    headers.Add(headerText)
                Next
                writer.WriteLine(String.Join(",", headers))

                ' Write data rows with peso symbol for Unit Cost values
                For Each row As DataRow In dt.Rows
                    Dim fields As New List(Of String)

                    For Each column As DataColumn In dt.Columns
                        Dim value As Object = row(column)
                        Dim fieldValue As String = ""

                        If value IsNot DBNull.Value Then
                            ' Format based on column type
                            If column.ColumnName = "Date Received" AndAlso TypeOf value Is DateTime Then
                                Dim dateValue As DateTime = DirectCast(value, DateTime)
                                fieldValue = dateValue.ToString("MM-dd-yyyy")
                            ElseIf column.ColumnName = "Unit Cost" Then
                                ' Format as currency with peso symbol
                                Dim cost As Decimal
                                If Decimal.TryParse(value.ToString(), cost) Then
                                    fieldValue = $"₱{cost:N2}"
                                Else
                                    fieldValue = value.ToString()
                                End If
                            Else
                                fieldValue = value.ToString()
                            End If
                        End If

                        ' Escape commas and quotes for CSV
                        If fieldValue.Contains(",") OrElse fieldValue.Contains("""") Then
                            fieldValue = """" & fieldValue.Replace("""", """""") & """"
                        End If

                        fields.Add(fieldValue)
                    Next

                    writer.WriteLine(String.Join(",", fields))
                Next

                ' Add empty line before totals
                writer.WriteLine()

                ' Add totals row with peso symbol
                Dim totalFields As New List(Of String)
                totalFields.Add("TOTALS")
                totalFields.Add("") ' Item Name
                totalFields.Add("") ' Brand
                totalFields.Add("") ' Serial Number
                totalFields.Add($"₱{_totalUnitCost:N2}") ' Unit Cost
                totalFields.Add(_totalCurrentStock.ToString()) ' Current Stock
                totalFields.Add("") ' Status
                totalFields.Add("") ' Date Received
                writer.WriteLine(String.Join(",", totalFields))

                ' Add summary line with peso symbol
                writer.WriteLine()
                writer.WriteLine($"Total Items: {_totalItems}, Total Stock: {_totalCurrentStock}, Total Value: ₱{_totalUnitCost:N2}")
            End Using

        Catch ex As Exception
            Throw New Exception($"Error saving CSV file: {ex.Message}")
        End Try
    End Sub

    Private Function GetOptimizedColumnWidths(data As DataTable, columnCount As Integer) As Single()
        ' Optimized column widths for better fit in landscape mode
        Dim widths(columnCount - 1) As Single

        For i As Integer = 0 To columnCount - 1
            Dim columnName As String = data.Columns(i).ColumnName

            Select Case columnName
                Case "Item ID"
                    widths(i) = 8 ' 8% of page width
                Case "Item Name"
                    widths(i) = 20 ' 20% of page width
                Case "Brand"
                    widths(i) = 12 ' 12% of page width
                Case "Serial Number"
                    widths(i) = 15 ' 15% of page width
                Case "Unit Cost"
                    widths(i) = 12 ' 12% of page width
                Case "Current Stock"
                    widths(i) = 10 ' 10% of page width
                Case "Status"
                    widths(i) = 10 ' 10% of page width
                Case "Date Received"
                    widths(i) = 13 ' 13% of page width
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

    Private Sub CalculateTotals(dt As DataTable)
        _totalUnitCost = 0
        _totalCurrentStock = 0
        _totalItems = dt.Rows.Count

        For Each row As DataRow In dt.Rows
            ' Unit Cost
            If row("Unit Cost") IsNot DBNull.Value Then
                Dim unitCost As Decimal
                If Decimal.TryParse(row("Unit Cost").ToString(), unitCost) Then
                    _totalUnitCost += unitCost
                End If
            End If

            ' Current Stock
            If row("Current Stock") IsNot DBNull.Value Then
                Dim currentStock As Integer
                If Integer.TryParse(row("Current Stock").ToString(), currentStock) Then
                    _totalCurrentStock += currentStock
                End If
            End If
        Next
    End Sub

    Private Function GetInventoryData(startDate As DateTime, endDate As DateTime, timePeriod As String) As DataTable
        Dim dt As New DataTable()

        Try
            ' Build SQL query based on time period
            Dim query As String = "SELECT item_id AS 'Item ID', item_name AS 'Item Name', brand AS 'Brand', " &
                                 "serial_number AS 'Serial Number', unit_cost AS 'Unit Cost', " &
                                 "current_stock AS 'Current Stock', status AS 'Status', " &
                                 "date_received AS 'Date Received' " &
                                 "FROM inventory "

            ' Add WHERE clause only if not "All Time"
            If timePeriod <> "All Time" Then
                query &= "WHERE DATE(date_received) BETWEEN @StartDate AND @EndDate "
            End If

            query &= "ORDER BY item_id"

            Using conn As New MySqlConnection(CONNECTION_STRING)
                Using cmd As New MySqlCommand(query, conn)
                    ' Add parameters only if not "All Time"
                    If timePeriod <> "All Time" Then
                        cmd.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"))
                        cmd.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd"))
                    End If

                    ' Open connection and fill data table
                    conn.Open()
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show($"Database error: {ex.Message}", "Database Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dt
    End Function


    Private Sub SAInventoryExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set default date range (last 30 days)
        DTPEnd.Value = DateTime.Today
        DTPStart.Value = DateTime.Today.AddDays(-30)

        ' Set date format to MM-dd-yyyy
        DTPStart.Format = DateTimePickerFormat.Custom
        DTPStart.CustomFormat = "MM-dd-yyyy"
        DTPEnd.Format = DateTimePickerFormat.Custom
        DTPEnd.CustomFormat = "MM-dd-yyyy"

        ' Set default export format to CSV
        cbExportFormat.SelectedIndex = 0

        ' Set "All Time" as default time period
        cbTimePeriod.SelectedIndex = 0

        ' Update date picker state
        UpdateDatePickerEnabledState()
    End Sub

    Private Sub cbTimePeriod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTimePeriod.SelectedIndexChanged
        If cbTimePeriod.SelectedItem Is Nothing Then Return

        Dim selectedPeriod As String = cbTimePeriod.SelectedItem.ToString()
        Dim today As DateTime = DateTime.Now

        Select Case selectedPeriod
            Case "All Time"
                ' Set to a very early date for all records
                DTPStart.Value = New DateTime(2000, 1, 1)
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
End Class