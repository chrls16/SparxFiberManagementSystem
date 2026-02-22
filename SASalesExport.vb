Imports System.Drawing
Imports System.Configuration
Imports MySqlConnector
Imports System.Data
Imports System.IO
Imports System.Diagnostics
Imports System.Text
Imports iTextSharpText = iTextSharp.text
Imports iTextSharpTextPdf = iTextSharp.text.pdf

Public Class SASalesExport
    Private _totalPlanSold As Integer = 0
    Private _totalServiceSold As Integer = 0
    Private _totalOverallSales As Integer = 0
    Private _totalVolumeRevenue As Decimal = 0

    Private Sub SASalesExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set date format to MM-dd-yyyy
        DTPStart.Format = DateTimePickerFormat.Custom
        DTPStart.CustomFormat = "MM-dd-yyyy"
        DTPEnd.Format = DateTimePickerFormat.Custom
        DTPEnd.CustomFormat = "MM-dd-yyyy"

        ' Set default dates (last 30 days)
        DTPStart.Value = DateTime.Now.AddDays(-30)
        DTPEnd.Value = DateTime.Now

        ' Set export format options
        cbExportFormat.Items.Clear()
        cbExportFormat.Items.AddRange(New Object() {"CSV", "PDF"})
        cbExportFormat.SelectedIndex = 0

        ' Set "All Time" as default time period
        cbTimePeriod.SelectedIndex = 0
    End Sub

    Private Sub cbTimePeriod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTimePeriod.SelectedIndexChanged
        Dim selectedPeriod As String = cbTimePeriod.SelectedItem.ToString()

        ' Enable/disable date controls based on selection
        If selectedPeriod = "All Time" Then
            DTPStart.Enabled = False
            DTPEnd.Enabled = False
            lblStartDate.Enabled = False
            lblEndDate.Enabled = False
        Else
            DTPStart.Enabled = True
            DTPEnd.Enabled = True
            lblStartDate.Enabled = True
            lblEndDate.Enabled = True

            If selectedPeriod = "Custom" Then
                Exit Sub
            End If

            Dim startDate As DateTime = DTPStart.Value
            Dim endDate As DateTime

            Select Case selectedPeriod
                Case "Daily"
                    endDate = startDate
                Case "Weekly"
                    endDate = startDate.AddDays(6)
                Case "Monthly"
                    endDate = startDate.AddMonths(1).AddDays(-1)
                Case "Quarterly"
                    endDate = startDate.AddMonths(3).AddDays(-1)
                Case "Yearly"
                    endDate = startDate.AddYears(1).AddDays(-1)
                Case Else
                    Exit Sub
            End Select
            DTPEnd.Value = endDate
        End If
    End Sub

    Private Sub cbPlanType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPlanType.SelectedIndexChanged
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ' 1. Fetch the filtered data from the database
        Dim filteredData As DataTable = GetFilteredData()

        ' 2. Check if data was successfully returned
        If filteredData IsNot Nothing AndAlso filteredData.Rows.Count > 0 Then
            ' 3. Calculate totals
            CalculateTotals(filteredData)

            ' 4. Get export format from dropdown
            If cbExportFormat.SelectedItem Is Nothing Then
                MessageBox.Show("Please select an export format.", "Export Format", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim exportFormat As String = cbExportFormat.SelectedItem.ToString()
            Dim exportAsPDF As Boolean = (exportFormat = "PDF")

            ' 5. Let user choose save location
            Using saveDialog As New SaveFileDialog()
                If exportAsPDF Then
                    saveDialog.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*"
                    saveDialog.FileName = $"Sales_Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                Else
                    saveDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
                    saveDialog.FileName = $"Sales_Report_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
                End If

                saveDialog.FilterIndex = 1
                saveDialog.RestoreDirectory = True

                If saveDialog.ShowDialog() = DialogResult.OK Then
                    ' 6. Save to selected format
                    If exportAsPDF Then
                        ' Generate PDF using iTextSharp
                        Try
                            Dim criteria As String = GetCriteriaString()
                            GeneratePDF(filteredData, saveDialog.FileName, criteria)

                            MessageBox.Show($"Sales report exported successfully to:{vbCrLf}{saveDialog.FileName}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
                        ' Generate CSV file
                        Try
                            GenerateCSV(filteredData, saveDialog.FileName)

                            MessageBox.Show($"Sales report exported successfully to:{vbCrLf}{saveDialog.FileName}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
                            MessageBox.Show($"Error generating CSV file: {ex.Message}", "CSV Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                End If
            End Using
        Else
            ' Inform the user if no data was found
            MessageBox.Show("No sales data found for the selected filter criteria.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function GetCriteriaString() As String
        Dim criteria As New StringBuilder()

        ' Date criteria
        If cbTimePeriod.SelectedItem.ToString() = "All Time" Then
            criteria.Append("Date Range: All Time")
        Else
            criteria.Append($"Date Range: {DTPStart.Value.ToString("MM-dd-yyyy")} to {DTPEnd.Value.ToString("MM-dd-yyyy")}")
        End If

        ' Plan type criteria
        Dim selectedPlan As String = If(cbPlanType.SelectedItem IsNot Nothing, cbPlanType.SelectedItem.ToString(), "All Plans")
        If selectedPlan <> "All Plans" Then
            criteria.Append($" | Plan Type: {selectedPlan}")
        End If

        Return criteria.ToString()
    End Function

    Private Sub GeneratePDF(data As DataTable, filePath As String, criteria As String)
        ' Create document
        Dim document As New iTextSharpText.Document(iTextSharpText.PageSize.A4.Rotate())
        document.SetMargins(20, 20, 30, 30)

        ' Create PDF writer
        Dim writer As iTextSharpTextPdf.PdfWriter = iTextSharpTextPdf.PdfWriter.GetInstance(document, New FileStream(filePath, FileMode.Create))

        ' Add metadata
        document.AddTitle("Sales Report")
        document.AddAuthor("Sparx System")
        document.AddCreationDate()

        ' Open document
        document.Open()

        ' Use a font that supports the peso symbol (₱)
        Dim baseFont As iTextSharpTextPdf.BaseFont
        Try
            ' Try to use Arial Unicode MS which has full Unicode support
            baseFont = iTextSharpTextPdf.BaseFont.CreateFont("c:\windows\fonts\arialuni.ttf", iTextSharpTextPdf.BaseFont.IDENTITY_H, iTextSharpTextPdf.BaseFont.EMBEDDED)
        Catch
            Try
                ' Fallback to Arial
                baseFont = iTextSharpTextPdf.BaseFont.CreateFont("c:\windows\fonts\arial.ttf", iTextSharpTextPdf.BaseFont.IDENTITY_H, iTextSharpTextPdf.BaseFont.EMBEDDED)
            Catch
                ' Final fallback to Helvetica with Windows-1252 encoding
                baseFont = iTextSharpTextPdf.BaseFont.CreateFont(iTextSharpTextPdf.BaseFont.HELVETICA, iTextSharpTextPdf.BaseFont.CP1252, iTextSharpTextPdf.BaseFont.NOT_EMBEDDED)
            End Try
        End Try

        ' Create fonts
        Dim titleFont = New iTextSharpText.Font(baseFont, 16, iTextSharpText.Font.BOLD)
        Dim headerFont = New iTextSharpText.Font(baseFont, 10, iTextSharpText.Font.BOLD, iTextSharpText.BaseColor.WHITE)
        Dim normalFont = New iTextSharpText.Font(baseFont, 9, iTextSharpText.Font.NORMAL)
        Dim criteriaFont = New iTextSharpText.Font(baseFont, 9, iTextSharpText.Font.NORMAL, iTextSharpText.BaseColor.DARK_GRAY)
        Dim summaryFont = New iTextSharpText.Font(baseFont, 10, iTextSharpText.Font.BOLD)
        Dim totalFont = New iTextSharpText.Font(baseFont, 9, iTextSharpText.Font.BOLD)

        ' Peso symbol constant
        Dim pesoSign As String = "₱" ' Direct Unicode character

        ' Add title
        Dim title As New iTextSharpText.Paragraph("SALES REPORT", titleFont)
        title.Alignment = iTextSharpText.Element.ALIGN_CENTER
        title.SpacingAfter = 10
        document.Add(title)

        ' Add criteria
        Dim criteriaPara As New iTextSharpText.Paragraph(criteria, criteriaFont)
        criteriaPara.Alignment = iTextSharpText.Element.ALIGN_CENTER
        criteriaPara.SpacingAfter = 5
        document.Add(criteriaPara)

        ' Add generated date
        Dim generatedDate As New iTextSharpText.Paragraph($"Generated on: {DateTime.Now:MM-dd-yyyy HH:mm:ss}", criteriaFont)
        generatedDate.Alignment = iTextSharpText.Element.ALIGN_CENTER
        generatedDate.SpacingAfter = 15
        document.Add(generatedDate)

        ' Create table with 5 columns
        Dim table As New iTextSharpTextPdf.PdfPTable(5)
        table.WidthPercentage = 100
        table.SpacingBefore = 10
        table.SpacingAfter = 10

        ' Set column widths
        Dim columnWidths As Single() = {20, 15, 15, 15, 35}
        table.SetWidths(columnWidths)

        ' Add headers with peso symbol
        Dim headers() As String = {
        "Date",
        "Plan Sold",
        "Service Sold",
        "Total Sales",
        $"Volume Revenue ({pesoSign})"
    }

        For Each header As String In headers
            Dim cell As New iTextSharpTextPdf.PdfPCell(New iTextSharpText.Phrase(header, headerFont))
            cell.BackgroundColor = New iTextSharpText.BaseColor(70, 130, 180)
            cell.HorizontalAlignment = iTextSharpText.Element.ALIGN_CENTER
            cell.VerticalAlignment = iTextSharpText.Element.ALIGN_MIDDLE
            cell.Padding = 5
            table.AddCell(cell)
        Next

        ' Add data rows
        For Each row As DataRow In data.Rows
            ' Date column
            Dim dateCell As New iTextSharpTextPdf.PdfPCell(New iTextSharpText.Phrase(
            CDate(row("Date")).ToString("MM-dd-yyyy"), normalFont))
            dateCell.Padding = 5
            table.AddCell(dateCell)

            ' Plan Sold column
            Dim planSoldCell As New iTextSharpTextPdf.PdfPCell(New iTextSharpText.Phrase(
            row("PlanSold").ToString(), normalFont))
            planSoldCell.HorizontalAlignment = iTextSharpText.Element.ALIGN_CENTER
            planSoldCell.Padding = 5
            table.AddCell(planSoldCell)

            ' Service Sold column
            Dim serviceSoldCell As New iTextSharpTextPdf.PdfPCell(New iTextSharpText.Phrase(
            row("ServiceSold").ToString(), normalFont))
            serviceSoldCell.HorizontalAlignment = iTextSharpText.Element.ALIGN_CENTER
            serviceSoldCell.Padding = 5
            table.AddCell(serviceSoldCell)

            ' Total Sales column
            Dim totalSalesCell As New iTextSharpTextPdf.PdfPCell(New iTextSharpText.Phrase(
            row("TotalSales").ToString(), normalFont))
            totalSalesCell.HorizontalAlignment = iTextSharpText.Element.ALIGN_CENTER
            totalSalesCell.Padding = 5
            table.AddCell(totalSalesCell)

            ' Volume Revenue column - WITH PESO SYMBOL
            Dim revenue As Decimal = If(row("VolumeRevenue") IsNot DBNull.Value, CDec(row("VolumeRevenue")), 0)
            Dim revenueText As String = $"{pesoSign} {revenue:N2}"
            Dim revenueCell As New iTextSharpTextPdf.PdfPCell(New iTextSharpText.Phrase(revenueText, normalFont))
            revenueCell.HorizontalAlignment = iTextSharpText.Element.ALIGN_RIGHT
            revenueCell.Padding = 5
            table.AddCell(revenueCell)
        Next

        ' Add totals row with peso symbol
        table.AddCell(New iTextSharpTextPdf.PdfPCell(New iTextSharpText.Phrase("TOTALS", totalFont)) With {
        .BackgroundColor = New iTextSharpText.BaseColor(255, 255, 200),
        .HorizontalAlignment = iTextSharpText.Element.ALIGN_CENTER,
        .Padding = 5
    })

        table.AddCell(New iTextSharpTextPdf.PdfPCell(New iTextSharpText.Phrase(_totalPlanSold.ToString(), totalFont)) With {
        .BackgroundColor = New iTextSharpText.BaseColor(255, 255, 200),
        .HorizontalAlignment = iTextSharpText.Element.ALIGN_CENTER,
        .Padding = 5
    })

        table.AddCell(New iTextSharpTextPdf.PdfPCell(New iTextSharpText.Phrase(_totalServiceSold.ToString(), totalFont)) With {
        .BackgroundColor = New iTextSharpText.BaseColor(255, 255, 200),
        .HorizontalAlignment = iTextSharpText.Element.ALIGN_CENTER,
        .Padding = 5
    })

        table.AddCell(New iTextSharpTextPdf.PdfPCell(New iTextSharpText.Phrase(_totalOverallSales.ToString(), totalFont)) With {
        .BackgroundColor = New iTextSharpText.BaseColor(255, 255, 200),
        .HorizontalAlignment = iTextSharpText.Element.ALIGN_CENTER,
        .Padding = 5
    })

        ' Total Revenue with peso symbol
        Dim totalRevenueText As String = $"{pesoSign} {_totalVolumeRevenue:N2}"
        table.AddCell(New iTextSharpTextPdf.PdfPCell(New iTextSharpText.Phrase(totalRevenueText, totalFont)) With {
        .BackgroundColor = New iTextSharpText.BaseColor(255, 255, 200),
        .HorizontalAlignment = iTextSharpText.Element.ALIGN_RIGHT,
        .Padding = 5
    })

        ' Add table to document
        document.Add(table)

        ' Add summary section with peso symbol
        Dim summaryPara As New iTextSharpText.Paragraph("Report Summary", summaryFont)
        summaryPara.SpacingBefore = 20
        summaryPara.SpacingAfter = 5
        document.Add(summaryPara)

        Dim detailsText As String = $"Total Days: {data.Rows.Count} | " &
                                $"Total Plans Sold: {_totalPlanSold} | " &
                                $"Total Services Sold: {_totalServiceSold} | " &
                                $"Total Sales: {_totalOverallSales} | " &
                                $"Total Revenue: {pesoSign} {_totalVolumeRevenue:N2}"

        Dim detailsPara As New iTextSharpText.Paragraph(detailsText, normalFont)
        detailsPara.SpacingAfter = 10
        document.Add(detailsPara)

        ' Add footer
        Dim footer As New iTextSharpText.Paragraph($"Page {writer.PageNumber}", criteriaFont)
        footer.Alignment = iTextSharpText.Element.ALIGN_CENTER
        document.Add(footer)

        ' Close document
        document.Close()
    End Sub
    Private Sub GenerateCSV(data As DataTable, filePath As String)
        Try
            Using writer As New StreamWriter(filePath, False, Encoding.UTF8)
                ' Add UTF-8 BOM for Excel compatibility
                writer.Write(ChrW(&HFEFF))

                ' Peso symbol constant
                Dim pesoSign As String = "₱"

                ' Write CSV header WITH PESO SYMBOL
                Dim headers() As String = {
                "Date",
                "Plan Sold",
                "Service Sold",
                "Total Sales",
                $"Volume Revenue ({pesoSign})"
            }
                writer.WriteLine(String.Join(",", headers))

                ' Write data rows - WITH PESO SYMBOL in revenue column
                For Each row As DataRow In data.Rows
                    Dim rowValues As New List(Of String)

                    ' Date
                    rowValues.Add(CDate(row("Date")).ToString("MM-dd-yyyy"))

                    ' Plan Sold
                    rowValues.Add(row("PlanSold").ToString())

                    ' Service Sold
                    rowValues.Add(row("ServiceSold").ToString())

                    ' Total Sales
                    rowValues.Add(row("TotalSales").ToString())

                    ' Volume Revenue WITH PESO SYMBOL
                    Dim revenue As Decimal = If(row("VolumeRevenue") IsNot DBNull.Value, CDec(row("VolumeRevenue")), 0)
                    ' Format with peso symbol and ensure proper formatting for CSV
                    Dim revenueText As String = $"{pesoSign} {revenue:N2}"
                    ' Wrap in quotes to handle comma in thousands separator
                    rowValues.Add("""" & revenueText & """")

                    writer.WriteLine(String.Join(",", rowValues))
                Next

                ' Add empty line
                writer.WriteLine()

                ' Add totals row WITH PESO SYMBOL
                Dim totals() As String = {
                "TOTALS",
                _totalPlanSold.ToString(),
                _totalServiceSold.ToString(),
                _totalOverallSales.ToString(),
                $"""{pesoSign} {_totalVolumeRevenue:N2}"""  ' Wrapped in quotes
            }
                writer.WriteLine(String.Join(",", totals))

                ' Add summary section WITH PESO SYMBOL
                writer.WriteLine()
                writer.WriteLine("Report Summary")
                writer.WriteLine($"Criteria: {GetCriteriaString()}")
                writer.WriteLine($"Generated on: {DateTime.Now:MM-dd-yyyy HH:mm:ss}")
                writer.WriteLine($"Total Days: {data.Rows.Count}")
                writer.WriteLine($"Total Plans Sold: {_totalPlanSold}")
                writer.WriteLine($"Total Services Sold: {_totalServiceSold}")
                writer.WriteLine($"Total Sales: {_totalOverallSales}")
                writer.WriteLine($"Total Revenue: {pesoSign} {_totalVolumeRevenue:N2}")
            End Using

        Catch ex As Exception
            MessageBox.Show($"Error creating CSV file: {ex.Message}", "CSV Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw
        End Try
    End Sub

    Private Sub CalculateTotals(dt As DataTable)
        _totalPlanSold = 0
        _totalServiceSold = 0
        _totalOverallSales = 0
        _totalVolumeRevenue = 0

        For Each row As DataRow In dt.Rows
            ' Plan Sold
            If row("PlanSold") IsNot DBNull.Value Then
                Dim planSold As Integer
                If Integer.TryParse(row("PlanSold").ToString(), planSold) Then
                    _totalPlanSold += planSold
                End If
            End If

            ' Service Sold
            If row("ServiceSold") IsNot DBNull.Value Then
                Dim serviceSold As Integer
                If Integer.TryParse(row("ServiceSold").ToString(), serviceSold) Then
                    _totalServiceSold += serviceSold
                End If
            End If

            ' Total Sales
            If row("TotalSales") IsNot DBNull.Value Then
                Dim totalSales As Integer
                If Integer.TryParse(row("TotalSales").ToString(), totalSales) Then
                    _totalOverallSales += totalSales
                End If
            End If

            ' Volume Revenue
            If row("VolumeRevenue") IsNot DBNull.Value Then
                Dim revenue As Decimal
                If Decimal.TryParse(row("VolumeRevenue").ToString(), revenue) Then
                    _totalVolumeRevenue += revenue
                End If
            End If
        Next
    End Sub

    Private Function GetFilteredData() As DataTable
        Dim dt As New DataTable()

        ' Define columns based on your requirements - use underscore instead of space
        dt.Columns.Add("Date", GetType(Date))
        dt.Columns.Add("PlanSold", GetType(Integer))
        dt.Columns.Add("ServiceSold", GetType(Integer))
        dt.Columns.Add("TotalSales", GetType(Integer))
        dt.Columns.Add("VolumeRevenue", GetType(Decimal))

        Try
            Dim connString As String = ConfigurationManager.ConnectionStrings("SparxDb").ConnectionString
            Using conn As New MySqlConnection(connString)
                conn.Open()

                ' This query gets daily sales data by combining customer installations and service sales
                Dim query As String = "
                SELECT 
                    DateData.SalesDate,
                    COALESCE(SUM(PlanCount), 0) AS PlanSold,
                    COALESCE(SUM(ServiceCount), 0) AS ServiceSold,
                    COALESCE(SUM(PlanCount), 0) + COALESCE(SUM(ServiceCount), 0) AS TotalSales,
                    COALESCE(SUM(PlanRevenue), 0) + COALESCE(SUM(ServiceRevenue), 0) AS VolumeRevenue
                FROM (
                        -- Get plan sales (customer installations)
                        SELECT 
                            DATE(date_installed) AS SalesDate,
                            COUNT(customer_id) AS PlanCount,
                            0 AS ServiceCount,
                            SUM(monthly_rate) AS PlanRevenue,
                            0 AS ServiceRevenue
                        FROM customer 
                        WHERE date_installed IS NOT NULL"

                ' Add date filter if not "All Time"
                Dim selectedPeriod As String = If(cbTimePeriod.SelectedItem IsNot Nothing, cbTimePeriod.SelectedItem.ToString(), "All Time")
                If selectedPeriod <> "All Time" Then
                    query &= " AND date_installed BETWEEN @startDate AND @endDate"
                End If

                ' Apply plan type filter if user selected a specific plan
                Dim selectedPlan As String = If(cbPlanType.SelectedItem IsNot Nothing, cbPlanType.SelectedItem.ToString(), String.Empty)
                If Not String.IsNullOrWhiteSpace(selectedPlan) AndAlso selectedPlan <> "All Plans" Then
                    ' Extract plan type from display name (e.g., "Basic 25Mbps" -> "Basic")
                    Dim planType As String = selectedPlan.Split(" "c)(0)
                    query &= " AND plan_type = @planType"
                End If

                query &= " 
                        GROUP BY DATE(date_installed)
                        
                        UNION ALL
                        
                        -- Get service sales (completed services)
                        SELECT 
                            DATE(date_completed) AS SalesDate,
                            0 AS PlanCount,
                            COUNT(service_id) AS ServiceCount,
                            0 AS PlanRevenue,
                            SUM(service_cost) AS ServiceRevenue
                        FROM service 
                        WHERE status = 'Completed' 
                        AND date_completed IS NOT NULL"

                ' Add date filter if not "All Time"
                If selectedPeriod <> "All Time" Then
                    query &= " AND date_completed BETWEEN @startDate AND @endDate"
                End If

                query &= " 
                        GROUP BY DATE(date_completed)
                    ) AS DateData
                    GROUP BY DateData.SalesDate
                    ORDER BY DateData.SalesDate DESC"

                Using cmd As New MySqlCommand(query, conn)
                    ' Only add date parameters if not "All Time"
                    If selectedPeriod <> "All Time" Then
                        cmd.Parameters.AddWithValue("@startDate", DTPStart.Value.Date)
                        cmd.Parameters.AddWithValue("@endDate", DTPEnd.Value.Date.AddDays(1).AddSeconds(-1)) ' Include the entire end date
                    End If

                    If Not String.IsNullOrWhiteSpace(selectedPlan) AndAlso selectedPlan <> "All Plans" Then
                        Dim planType As String = selectedPlan.Split(" "c)(0)
                        cmd.Parameters.AddWithValue("@planType", planType)
                    End If

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim row As DataRow = dt.NewRow()

                            ' Date
                            If reader("SalesDate") IsNot DBNull.Value Then
                                row("Date") = Convert.ToDateTime(reader("SalesDate")).Date
                            Else
                                Continue While ' Skip rows without date
                            End If

                            ' Plan Sold (customer installations)
                            row("PlanSold") = If(reader("PlanSold") IsNot DBNull.Value, Convert.ToInt32(reader("PlanSold")), 0)

                            ' Service Sold (completed services)
                            row("ServiceSold") = If(reader("ServiceSold") IsNot DBNull.Value, Convert.ToInt32(reader("ServiceSold")), 0)

                            ' Total Sales (Plan + Service)
                            row("TotalSales") = If(reader("TotalSales") IsNot DBNull.Value, Convert.ToInt32(reader("TotalSales")), 0)

                            ' Volume Revenue (Plan Revenue + Service Revenue)
                            row("VolumeRevenue") = If(reader("VolumeRevenue") IsNot DBNull.Value, Convert.ToDecimal(reader("VolumeRevenue")), 0)

                            dt.Rows.Add(row)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' If DB access fails, log and return an empty table so UI can inform user
            Debug.WriteLine("GetFilteredData error: " & ex.Message)
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return dt
        End Try

        Return dt
    End Function

    Private Sub cbExportFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbExportFormat.SelectedIndexChanged

    End Sub
End Class