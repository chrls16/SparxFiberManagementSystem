Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports MySqlConnector
Imports System.Diagnostics
Imports System.Configuration
Imports System.Drawing.Printing
Imports System.Text
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Color = System.Drawing.Color

Public Class SABillingExport
    Private _connectionString As String = Nothing
    Private _printDataTable As DataTable = Nothing
    Private _printFileName As String = ""
    Private _printCriteria As String = ""
    Private _totalPaidAmount As Decimal = 0
    Private _totalRecords As Integer = 0
    Private _paidCount As Integer = 0
    Private _unpaidCount As Integer = 0

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
        ExportBillingReport()
    End Sub

    Private Sub ExportBillingReport()
        Try
            ' Validate export format
            If cbExportFormat.SelectedItem Is Nothing Then
                MessageBox.Show("Please select an export format.", "Export Format",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Validate time period
            If cbTimePeriod.SelectedItem Is Nothing Then
                MessageBox.Show("Please select a time period.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Validate date range for custom period
            Dim selectedPeriod As String = cbTimePeriod.SelectedItem.ToString()
            If selectedPeriod = "Custom" Then
                If DTPStart.Value > DTPEnd.Value Then
                    MessageBox.Show("Start date cannot be later than end date.",
                                  "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End If

            ' Get date range based on selected time period
            Dim startDate As DateTime = GetStartDate()
            Dim endDate As DateTime = GetEndDate()

            ' Get export format
            Dim exportFormat As String = cbExportFormat.SelectedItem.ToString()
            Dim exportAsPDF As Boolean = (exportFormat = "PDF")

            ' Get billing data
            Dim dt As DataTable = GetBillingData(startDate, endDate)

            ' Check if any data was returned
            If dt.Rows.Count = 0 Then
                MessageBox.Show("No billing records found for the selected date range.",
                              "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Calculate totals
            CalculateTotals(dt)

            ' Let user choose save location
            Using saveDialog As New SaveFileDialog()
                Dim periodText As String = GetPeriodText(startDate, endDate)
                If exportAsPDF Then
                    saveDialog.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*"
                    saveDialog.FileName = $"Billing_Report_{periodText}.pdf"
                Else
                    saveDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
                    saveDialog.FileName = $"Billing_Report_{periodText}.csv"
                End If

                saveDialog.FilterIndex = 1
                saveDialog.RestoreDirectory = True
                saveDialog.Title = "Export Billing Report"

                If saveDialog.ShowDialog() = DialogResult.OK Then
                    ' Save to selected format
                    If exportAsPDF Then
                        ' For PDF export using iTextSharp
                        _printDataTable = dt
                        _printFileName = saveDialog.FileName
                        _printCriteria = $"Period: {periodText}"

                        ' Generate PDF using iTextSharp
                        If GeneratePdfReport() Then
                            MessageBox.Show($"Successfully exported {dt.Rows.Count} records to:{vbCrLf}{saveDialog.FileName}",
                                          "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            ' Optionally open the file after export
                            If MessageBox.Show("Do you want to open the exported file?", "Open File",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                Process.Start(saveDialog.FileName)
                            End If
                        Else
                            MessageBox.Show("Failed to generate PDF file.", "Export Failed",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        ' For CSV export
                        SaveDataTableToCSV(dt, saveDialog.FileName, periodText)
                        MessageBox.Show($"Successfully exported {dt.Rows.Count} records to:{vbCrLf}{saveDialog.FileName}",
                                      "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Optionally open the file after export
                        If MessageBox.Show("Do you want to open the exported file?", "Open File",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Process.Start(saveDialog.FileName)
                        End If
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

    Private Function GetPeriodText(startDate As DateTime, endDate As DateTime) As String
        Dim timePeriod As String = cbTimePeriod.SelectedItem.ToString()
        Select Case timePeriod
            Case "Daily"
                Return DateTime.Today.ToString("yyyyMMdd")
            Case "Weekly"
                Return $"{startDate:yyyyMMdd}_to_{endDate:yyyyMMdd}"
            Case "Monthly"
                Return startDate.ToString("yyyyMM")
            Case "Quarterly"
                Return $"{startDate:yyyyMM}_to_{endDate:yyyyMM}"
            Case "Yearly"
                Return startDate.ToString("yyyy")
            Case "All Time"
                Return "All_Time"
            Case Else
                Return $"{startDate:yyyyMMdd}_to_{endDate:yyyyMMdd}"
        End Select
    End Function

    Private Function GeneratePdfReport() As Boolean
        Try
            ' Create document with margins
            Dim document As New Document(PageSize.A4.Rotate(), 40, 40, 40, 40)
            Dim writer As PdfWriter = PdfWriter.GetInstance(document, New FileStream(_printFileName, FileMode.Create))

            document.Open()

            ' Add title
            Dim titleFont = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD)
            Dim titleParagraph As New Paragraph("Billing Report", titleFont)
            titleParagraph.Alignment = Element.ALIGN_CENTER
            titleParagraph.SpacingAfter = 20
            document.Add(titleParagraph)

            ' Add criteria
            Dim criteriaFont = FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.NORMAL)
            Dim criteriaParagraph As New Paragraph(_printCriteria, criteriaFont)
            criteriaParagraph.Alignment = Element.ALIGN_CENTER
            criteriaParagraph.SpacingAfter = 10
            document.Add(criteriaParagraph)

            ' Add generation date
            Dim dateParagraph As New Paragraph($"Generated on: {DateTime.Now:MM-dd-yyyy HH:mm:ss}", criteriaFont)
            dateParagraph.Alignment = Element.ALIGN_CENTER
            dateParagraph.SpacingAfter = 30
            document.Add(dateParagraph)

            ' Create table for data
            Dim columnCount As Integer = _printDataTable.Columns.Count
            Dim table As New PdfPTable(columnCount)
            table.WidthPercentage = 100
            table.SpacingBefore = 10
            table.SpacingAfter = 10

            ' Set column widths
            Dim columnWidths As Single() = {60, 60, 120, 100, 80, 100, 90, 60} ' Adjusted widths for better fit
            table.SetWidths(columnWidths)

            ' Add table headers
            Dim headerFont = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, BaseColor.WHITE)
            For Each column As DataColumn In _printDataTable.Columns
                Dim cell As New PdfPCell(New Phrase(column.ColumnName, headerFont))
                cell.BackgroundColor = New BaseColor(70, 130, 180) ' Steel blue
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.VerticalAlignment = Element.ALIGN_MIDDLE
                cell.Padding = 5
                table.AddCell(cell)
            Next

            ' Add data rows with alternating colors
            Dim normalFont = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim rowIndex As Integer = 0

            For Each row As DataRow In _printDataTable.Rows
                For colIndex As Integer = 0 To columnCount - 1
                    Dim value As Object = row(colIndex)
                    Dim cellText As String = String.Empty

                    If value IsNot DBNull.Value AndAlso value IsNot Nothing Then
                        ' Format specific columns
                        If _printDataTable.Columns(colIndex).ColumnName = "Date of Payment" Then
                            Dim dateStr As String = value.ToString()
                            If Not String.IsNullOrEmpty(dateStr) AndAlso dateStr.Length >= 10 Then
                                Try
                                    Dim dateValue As DateTime = DateTime.Parse(dateStr)
                                    cellText = dateValue.ToString("MM-dd-yyyy")
                                Catch
                                    cellText = dateStr
                                End Try
                            Else
                                cellText = value.ToString()
                            End If
                        ElseIf _printDataTable.Columns(colIndex).ColumnName = "Monthly Rate" Then
                            Dim amount As Decimal
                            If Decimal.TryParse(value.ToString(), amount) Then
                                cellText = $"₱{amount:N2}"
                            Else
                                cellText = value.ToString()
                            End If
                        Else
                            cellText = value.ToString()
                        End If
                    End If

                    ' Create cell
                    Dim cell As New PdfPCell(New Phrase(cellText, normalFont))

                    ' Set alternating row colors
                    If rowIndex Mod 2 = 0 Then
                        cell.BackgroundColor = BaseColor.WHITE
                    Else
                        cell.BackgroundColor = New BaseColor(240, 240, 240)
                    End If

                    ' Set text color for status column
                    If _printDataTable.Columns(colIndex).ColumnName = "Status" Then
                        If cellText.ToUpper() = "PAID" Then
                            cell.Phrase = New Phrase(cellText, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, BaseColor.GREEN))
                        ElseIf cellText.ToUpper() = "UNPAID" Then
                            cell.Phrase = New Phrase(cellText, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, BaseColor.RED))
                        End If
                    End If

                    ' Set alignment
                    If _printDataTable.Columns(colIndex).ColumnName = "Customer Name" Or
                       _printDataTable.Columns(colIndex).ColumnName = "Plan Type" Then
                        cell.HorizontalAlignment = Element.ALIGN_LEFT
                    Else
                        cell.HorizontalAlignment = Element.ALIGN_CENTER
                    End If

                    cell.VerticalAlignment = Element.ALIGN_MIDDLE
                    cell.Padding = 5
                    table.AddCell(cell)
                Next
                rowIndex += 1
            Next

            document.Add(table)

            ' Add totals row
            Dim totalsTable As New PdfPTable(columnCount)
            totalsTable.WidthPercentage = 100
            totalsTable.SpacingBefore = 20

            For colIndex As Integer = 0 To columnCount - 1
                Dim cellText As String = String.Empty
                If colIndex = 0 Then
                    cellText = "TOTALS"
                ElseIf colIndex = 4 Then ' Monthly Rate column
                    cellText = $"₱{_totalPaidAmount:N2}"
                End If

                Dim cell As New PdfPCell(New Phrase(cellText, headerFont))
                cell.BackgroundColor = New BaseColor(255, 255, 204) ' Light yellow
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.VerticalAlignment = Element.ALIGN_MIDDLE
                cell.Padding = 5
                totalsTable.AddCell(cell)
            Next
            document.Add(totalsTable)

            ' Add summary section
            Dim summaryFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim summaryParagraph As New Paragraph("Report Summary", summaryFont)
            summaryParagraph.SpacingBefore = 20
            document.Add(summaryParagraph)

            Dim summaryText As String = $"Total Records: {_totalRecords} | Paid: {_paidCount} | Unpaid: {_unpaidCount} | Total Amount: ₱{_totalPaidAmount:N2}"
            Dim summaryDetails As New Paragraph(summaryText, criteriaFont)
            summaryDetails.SpacingAfter = 20
            document.Add(summaryDetails)

            ' Add footer
            Dim footerFont = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.ITALIC)
            Dim footer As New Paragraph($"Generated by Sparx System - {DateTime.Now:MM-dd-yyyy HH:mm:ss}", footerFont)
            footer.Alignment = Element.ALIGN_CENTER
            document.Add(footer)

            document.Close()
            writer.Close()

            Return True

        Catch ex As Exception
            MessageBox.Show($"Error generating PDF: {ex.Message}", "PDF Generation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub CalculateTotals(dt As DataTable)
        _totalPaidAmount = 0
        _totalRecords = dt.Rows.Count
        _paidCount = 0
        _unpaidCount = 0

        For Each row As DataRow In dt.Rows
            ' Monthly Rate for paid records
            If row("Status").ToString().ToUpper() = "PAID" Then
                _paidCount += 1
                If row("Monthly Rate") IsNot DBNull.Value Then
                    Dim monthlyRate As Decimal
                    If Decimal.TryParse(row("Monthly Rate").ToString(), monthlyRate) Then
                        _totalPaidAmount += monthlyRate
                    End If
                End If
            Else
                _unpaidCount += 1
            End If
        Next
    End Sub

    ' Update the GetBillingData method to include billing filter
    Private Function GetBillingData(startDate As DateTime, endDate As DateTime) As DataTable
        Dim dt As New DataTable("BillingReport")

        Try
            ' Create SQL query
            Dim query As String = "
            SELECT 
                IFNULL(p.payment_id, 0) AS 'Payment ID',
                c.customer_id AS 'Customer ID',
                CONCAT(c.first_name, ' ', c.last_name) AS 'Customer Name',
                c.plan_type AS 'Plan Type',
                c.monthly_rate AS 'Monthly Rate',
                IFNULL(p.payment_method, 'Not Paid') AS 'Mode of Payment',
                DATE_FORMAT(p.date_of_payment, '%Y-%m-%d') AS 'Date of Payment',
                CASE 
                    WHEN p.date_of_payment IS NULL THEN 'Unpaid'
                    ELSE 'Paid'
                END AS 'Status'
            FROM customer c
            LEFT JOIN payment p ON c.customer_id = p.customer_id 
                AND p.billing_type = 'plan_type'"

            ' Build WHERE clause
            Dim whereConditions As New List(Of String)
            Dim parameters As New Dictionary(Of String, Object)

            ' Date filter only if not "All Time"
            Dim selectedPeriod As String = cbTimePeriod.SelectedItem.ToString()
            If selectedPeriod <> "All Time" Then
                whereConditions.Add("(p.date_of_payment BETWEEN @startDate AND @endDate 
                   OR (p.date_of_payment IS NULL AND c.date_installed BETWEEN @startDate AND @endDate))")
                parameters.Add("@startDate", startDate.ToString("yyyy-MM-dd"))
                parameters.Add("@endDate", endDate.ToString("yyyy-MM-dd"))
            End If

            ' Billing filter
            Dim billingFilter As String = ""
            If cbBillingFilter.SelectedItem IsNot Nothing Then
                Select Case cbBillingFilter.SelectedItem.ToString()
                    Case "Paid Only"
                        billingFilter = " AND p.date_of_payment IS NOT NULL"
                    Case "Unpaid Only"
                        billingFilter = " AND p.date_of_payment IS NULL"
                    Case Else
                        billingFilter = ""
                End Select
            End If

            ' Combine WHERE conditions
            If whereConditions.Count > 0 Then
                query &= " WHERE " & String.Join(" AND ", whereConditions)
            End If

            ' Add billing filter
            If Not String.IsNullOrEmpty(billingFilter) Then
                If whereConditions.Count > 0 Then
                    query &= billingFilter
                Else
                    query &= " WHERE " & billingFilter.TrimStart(" AND ")
                End If
            End If

            query &= " ORDER BY 
                CASE WHEN p.date_of_payment IS NULL THEN 1 ELSE 0 END,
                p.date_of_payment DESC, 
                c.customer_id"

            Using conn As New MySqlConnection(CONNECTION_STRING)
                Using cmd As New MySqlCommand(query, conn)
                    ' Add parameters
                    For Each param In parameters
                        cmd.Parameters.AddWithValue(param.Key, param.Value)
                    Next

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



    ' Add InitializeComboBoxes method
    Private Sub InitializeComboBoxes()
        If cbTimePeriod.Items.Count = 0 Then
            cbTimePeriod.Items.AddRange({"All Time", "Custom", "Daily", "Weekly", "Monthly", "Quarterly", "Yearly"})
        End If

        If cbBillingFilter.Items.Count = 0 Then
            cbBillingFilter.Items.AddRange({"All Billing", "Paid Only", "Unpaid Only"})
        End If

        If cbExportFormat.Items.Count = 0 Then
            cbExportFormat.Items.AddRange({"CSV", "PDF"})
        End If
    End Sub
    Private Sub SaveDataTableToCSV(dt As DataTable, filePath As String, periodText As String)
        Try
            Using writer As New StreamWriter(filePath, False, Encoding.UTF8)
                ' Write report header
                writer.WriteLine($"Billing Report - {_printCriteria}")
                writer.WriteLine($"Generated on: {DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss")}")
                writer.WriteLine()

                ' Write CSV header
                Dim headers As New List(Of String)
                For Each column As DataColumn In dt.Columns
                    headers.Add(column.ColumnName)
                Next
                writer.WriteLine(String.Join(",", headers))

                ' Write data rows
                For Each row As DataRow In dt.Rows
                    Dim fields As New List(Of String)

                    For Each column As DataColumn In dt.Columns
                        Dim value As Object = row(column)
                        Dim fieldValue As String = ""

                        If value IsNot DBNull.Value Then
                            ' Format based on column type
                            If column.ColumnName = "Date of Payment" Then
                                Dim dateStr As String = value.ToString()
                                If Not String.IsNullOrEmpty(dateStr) AndAlso dateStr.Length >= 10 Then
                                    fieldValue = dateStr.Substring(5, 2) & "-" & dateStr.Substring(8, 2) & "-" & dateStr.Substring(0, 4)
                                Else
                                    fieldValue = value.ToString()
                                End If
                            ElseIf column.ColumnName = "Monthly Rate" Then
                                ' Format as currency with peso symbol
                                Dim amount As Decimal
                                If Decimal.TryParse(value.ToString(), amount) Then
                                    fieldValue = $"₱{amount:N2}"
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

                ' Add totals row
                Dim totalFields As New List(Of String)
                totalFields.Add("TOTALS")
                totalFields.Add("") ' Customer ID
                totalFields.Add("") ' Customer Name
                totalFields.Add("") ' Plan Type
                totalFields.Add($"₱{_totalPaidAmount:N2}") ' Monthly Rate
                totalFields.Add("") ' Mode of Payment
                totalFields.Add("") ' Date of Payment
                totalFields.Add("") ' Status
                writer.WriteLine(String.Join(",", totalFields))

                ' Add summary lines
                writer.WriteLine()
                writer.WriteLine("Report Summary")
                writer.WriteLine($"Total Records: {_totalRecords}")
                writer.WriteLine($"Paid Records: {_paidCount}")
                writer.WriteLine($"Unpaid Records: {_unpaidCount}")
                writer.WriteLine($"Total Amount: ₱{_totalPaidAmount:N2}")
            End Using

        Catch ex As Exception
            Throw New Exception($"Error saving CSV file: {ex.Message}")
        End Try
    End Sub

    Private Function GetStartDate() As DateTime
        If cbTimePeriod.SelectedItem Is Nothing Then Return DateTime.MinValue

        Dim selectedPeriod As String = cbTimePeriod.SelectedItem.ToString()
        Select Case selectedPeriod
            Case "Daily"
                Return DateTime.Today
            Case "Weekly"
                Return DateTime.Today.AddDays(-7)
            Case "Monthly"
                Return DateTime.Today.AddMonths(-1)
            Case "Quarterly"
                Return DateTime.Today.AddMonths(-3)
            Case "Yearly"
                Return DateTime.Today.AddYears(-1)
            Case "All Time"
                Return New DateTime(2025, 11, 26) ' Very old date to get all records
            Case "Custom"
                Return DTPStart.Value.Date
            Case Else
                Return DateTime.MinValue
        End Select
    End Function

    Private Function GetEndDate() As DateTime
        If cbTimePeriod.SelectedItem Is Nothing Then Return DateTime.Today

        Dim selectedPeriod As String = cbTimePeriod.SelectedItem.ToString()
        Select Case selectedPeriod
            Case "Custom"
                Return DTPEnd.Value.Date
            Case "All Time"
                Return DateTime.Now.AddYears(100) ' Far future date to get all records
            Case Else
                Return DateTime.Today
        End Select
    End Function

    Private Sub cbTimePeriod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTimePeriod.SelectedIndexChanged
        ' Enable/disable date pickers based on selection
        If cbTimePeriod.SelectedItem IsNot Nothing Then
            Dim selectedPeriod As String = cbTimePeriod.SelectedItem.ToString()

            ' Set enabled state
            Dim isCustom As Boolean = (selectedPeriod = "Custom")
            DTPStart.Enabled = isCustom
            DTPEnd.Enabled = isCustom
            lblStartDate.Enabled = isCustom
            lblEndDate.Enabled = isCustom

            ' Set date values based on selection
            Select Case selectedPeriod
                Case "Daily"
                    DTPStart.Value = DateTime.Today
                    DTPEnd.Value = DateTime.Today

                Case "Weekly"
                    DTPStart.Value = DateTime.Today.AddDays(-7)
                    DTPEnd.Value = DateTime.Today

                Case "Monthly"
                    DTPStart.Value = DateTime.Today.AddMonths(-1)
                    DTPEnd.Value = DateTime.Today

                Case "Quarterly"
                    DTPStart.Value = DateTime.Today.AddMonths(-3)
                    DTPEnd.Value = DateTime.Today

                Case "Yearly"
                    DTPStart.Value = DateTime.Today.AddYears(-1)
                    DTPEnd.Value = DateTime.Today

                Case "All Time"
                    ' For "All Time", we set to very old and far future dates
                    ' but disable the date pickers
                    DTPStart.Value = New DateTime(1900, 1, 1)
                    DTPEnd.Value = DateTime.Now.AddYears(100)
                    DTPStart.Enabled = False
                    DTPEnd.Enabled = False
                    lblStartDate.Enabled = False
                    lblEndDate.Enabled = False

                Case "Custom"
                    ' Keep current values for custom
                    DTPStart.Enabled = True
                    DTPEnd.Enabled = True
                    lblStartDate.Enabled = True
                    lblEndDate.Enabled = True

            End Select

            ' Update date labels to show they're disabled for All Time
            If selectedPeriod = "All Time" Then
                lblStartDate.Text = ""
                lblEndDate.Text = ""
                lblStartDate.ForeColor = Color.Gray
                lblEndDate.ForeColor = Color.Gray
            Else
                lblStartDate.Text = "Start:"
                lblEndDate.Text = "End:"
                lblStartDate.ForeColor = SystemColors.ControlDarkDark
                lblEndDate.ForeColor = SystemColors.ControlDarkDark
            End If
        End If
    End Sub

    Private Sub SABillingExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize form
        If cbTimePeriod.Items.Count = 0 Then
            ' Add time periods with "All Time" included
            cbTimePeriod.Items.AddRange(New String() {
                "Custom",
                "Daily",
                "Weekly",
                "Monthly",
                "Quarterly",
                "Yearly",
                "All Time"
            })
        End If

        ' Set default selection to "Monthly"
        cbTimePeriod.SelectedIndex = 3 ' Monthly

        ' Initialize export format
        If cbExportFormat.Items.Count = 0 Then
            cbExportFormat.Items.AddRange(New String() {"CSV", "PDF"})
        End If
        cbExportFormat.SelectedIndex = 1 ' Select PDF as default

        ' Set default dates for monthly view
        DTPStart.Value = DateTime.Today.AddMonths(-1)
        DTPEnd.Value = DateTime.Today

        ' Set date format to MM-dd-yyyy
        DTPStart.Format = DateTimePickerFormat.Custom
        DTPStart.CustomFormat = "MM-dd-yyyy"
        DTPEnd.Format = DateTimePickerFormat.Custom
        DTPEnd.CustomFormat = "MM-dd-yyyy"

        ' Initialize date picker states
        cbTimePeriod_SelectedIndexChanged(Nothing, EventArgs.Empty)

        ' Initialize form
        InitializeComboBoxes()


        ' Set default selections
        cbTimePeriod.SelectedIndex = 0 ' All Time (now first)
        cbBillingFilter.SelectedIndex = 0 ' All Billing
        cbExportFormat.SelectedIndex = 1 ' PDF

        ' Set default dates for All Time
        DTPStart.Value = New DateTime(2025, 11, 26)
        DTPEnd.Value = DateTime.Now.AddYears(100)

        ' Set date format
        DTPStart.Format = DateTimePickerFormat.Custom
        DTPStart.CustomFormat = "MM-dd-yyyy"
        DTPEnd.Format = DateTimePickerFormat.Custom
        DTPEnd.CustomFormat = "MM-dd-yyyy"

        ' Initialize date picker states
        cbTimePeriod_SelectedIndexChanged(Nothing, EventArgs.Empty)
    End Sub

    Private Sub cbExportFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbExportFormat.SelectedIndexChanged

    End Sub
End Class