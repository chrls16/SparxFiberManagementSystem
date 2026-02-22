Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports MySqlConnector
Imports System.Drawing.Printing
Imports System.Text
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class SAPayrollExport
    ' MySQL/MariaDB connection string
    Private connString As String = "server=127.0.0.1;port=3306;userid=root;password=;database=sparx;"

    ' iTextSharp PDF variables
    Private _totalGrossPay As Decimal = 0
    Private _totalNetPay As Decimal = 0
    Private _totalEmployees As Integer = 0

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            ' Get filter values
            Dim selectedPosition As String = If(cbPositions.SelectedItem IsNot Nothing, cbPositions.SelectedItem.ToString(), "All")
            Dim startDate As DateTime = DTPStart.Value.Date
            Dim endDate As DateTime = DTPEnd.Value.Date.AddDays(1).AddSeconds(-1)

            ' Get export format
            If cbExportFormat.SelectedItem Is Nothing Then
                MessageBox.Show("Please select an export format.", "Export Format", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim exportFormat As String = cbExportFormat.SelectedItem.ToString()
            Dim exportAsPDF As Boolean = (exportFormat = "PDF")

            ' Validate
            If startDate > endDate Then
                MessageBox.Show("Start date cannot be later than end date.",
                              "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Get data
            Dim dt As DataTable = GetPayrollData(selectedPosition, startDate, endDate)

            If dt Is Nothing Then
                MessageBox.Show("Failed to retrieve data from database.",
                              "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If dt.Rows.Count = 0 Then
                MessageBox.Show("No payroll data found for the selected criteria.",
                              "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Calculate totals
            CalculateTotals(dt)

            ' Export based on format
            Using sfd As New SaveFileDialog()
                If exportAsPDF Then
                    sfd.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*"
                    sfd.FileName = $"Payroll_Report_{startDate:yyyyMMdd}_to_{endDate:yyyyMMdd}.pdf"

                    If sfd.ShowDialog() = DialogResult.OK Then
                        ' Generate PDF using iTextSharp
                        Try
                            Dim criteria As String = $"Position: {selectedPosition} | Date Range: {startDate:MM-dd-yyyy} to {endDate:MM-dd-yyyy}"
                            GeneratePDF(dt, sfd.FileName, criteria)

                            MessageBox.Show($"Successfully exported {dt.Rows.Count} records to:{vbCrLf}{sfd.FileName}",
                                          "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            ' Optionally open the file after export
                            If MessageBox.Show("Do you want to open the exported file?", "Open File",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                Process.Start(sfd.FileName)
                            End If
                        Catch ex As Exception
                            MessageBox.Show($"Error generating PDF: {ex.Message}", "PDF Export Error",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                Else
                    sfd.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
                    sfd.FilterIndex = 1
                    sfd.RestoreDirectory = True
                    sfd.FileName = $"Payroll_Report_{startDate:yyyyMMdd}_to_{endDate:yyyyMMdd}.csv"
                    sfd.Title = "Export Payroll Report"

                    If sfd.ShowDialog() = DialogResult.OK Then
                        ExportToCSV(dt, sfd.FileName)

                        MessageBox.Show($"Successfully exported {dt.Rows.Count} records to:{vbCrLf}{sfd.FileName}",
                                      "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        If MessageBox.Show("Do you want to open the exported file?", "Open File",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Process.Start(sfd.FileName)
                        End If
                    End If
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}{vbCrLf}{vbCrLf}Stack Trace:{vbCrLf}{ex.StackTrace}",
                          "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetPayrollData(position As String, startDate As DateTime, endDate As DateTime) As DataTable
        Dim dt As New DataTable()

        Try
            Using conn As New MySqlConnection(connString)
                ' Simple query to get staff data first
                Dim query As String = "
                    SELECT 
                        s.staff_id,
                        CONCAT(s.first_name, ' ', s.last_name) as full_name,
                        s.position,
                        s.daily_rate,
                        -- Calculate days worked from service table
                        COALESCE((
                            SELECT COUNT(DISTINCT DATE(date_completed)) 
                            FROM service 
                            WHERE staff_id = s.staff_id 
                            AND date_completed BETWEEN @startDate AND @endDate
                            AND status = 'Completed'
                        ), 0) as days_worked,
                        -- Default overtime calculation
                        COALESCE((
                            SELECT COUNT(*) * 2 
                            FROM service 
                            WHERE staff_id = s.staff_id 
                            AND date_completed BETWEEN @startDate AND @endDate
                            AND status = 'Completed'
                        ), 0) as overtime_hours
                    FROM staff s
                    WHERE s.position IS NOT NULL"

                ' Add position filter if not "All"
                If position <> "All" Then
                    query &= " AND s.position = @position"
                End If

                query &= " ORDER BY s.position, s.last_name, s.first_name"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@startDate", startDate)
                    cmd.Parameters.AddWithValue("@endDate", endDate)

                    If position <> "All" Then
                        cmd.Parameters.AddWithValue("@position", position)
                    End If

                    conn.Open()

                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using

            ' Add calculated columns
            dt.Columns.Add("Staff_ID", GetType(Integer))
            dt.Columns.Add("Name", GetType(String))
            dt.Columns.Add("Position", GetType(String))
            dt.Columns.Add("Daily_Rate", GetType(Decimal))
            dt.Columns.Add("Days_Worked", GetType(Integer))
            dt.Columns.Add("Overtime_Hours", GetType(Decimal))
            dt.Columns.Add("Gross_Pay", GetType(Decimal))
            dt.Columns.Add("Deductions", GetType(Decimal))
            dt.Columns.Add("Net_Pay", GetType(Decimal))

            ' Calculate payroll
            For Each row As DataRow In dt.Rows
                Dim staffId As Integer = Convert.ToInt32(row("staff_id"))
                Dim name As String = row("full_name").ToString()
                Dim positionName As String = row("position").ToString()
                Dim dailyRate As Decimal = Convert.ToDecimal(row("daily_rate"))
                Dim daysWorked As Integer = Convert.ToInt32(row("days_worked"))
                Dim overtimeHours As Decimal = Convert.ToDecimal(row("overtime_hours"))

                ' Calculations
                Dim basePay As Decimal = dailyRate * daysWorked
                Dim overtimePay As Decimal = overtimeHours * dailyRate * 1.5D ' 1.5x overtime rate
                Dim grossPay As Decimal = basePay + overtimePay
                Dim deductions As Decimal = grossPay * 0.1D ' 10% deductions
                Dim netPay As Decimal = grossPay - deductions

                ' Set values
                row("Staff_ID") = staffId
                row("Name") = name
                row("Position") = positionName
                row("Daily_Rate") = dailyRate
                row("Days_Worked") = daysWorked
                row("Overtime_Hours") = overtimeHours
                row("Gross_Pay") = grossPay
                row("Deductions") = deductions
                row("Net_Pay") = netPay
            Next

            ' Remove original columns
            dt.Columns.Remove("staff_id")
            dt.Columns.Remove("full_name")
            dt.Columns.Remove("position")
            dt.Columns.Remove("daily_rate")
            dt.Columns.Remove("days_worked")
            dt.Columns.Remove("overtime_hours")

        Catch ex As Exception
            MessageBox.Show($"Database error: {ex.Message}", "Database Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

        Return dt
    End Function

    Private Sub CalculateTotals(dt As DataTable)
        _totalGrossPay = 0
        _totalNetPay = 0
        _totalEmployees = dt.Rows.Count

        For Each row As DataRow In dt.Rows
            If row("Gross_Pay") IsNot DBNull.Value Then
                Dim grossPay As Decimal
                If Decimal.TryParse(row("Gross_Pay").ToString(), grossPay) Then
                    _totalGrossPay += grossPay
                End If
            End If

            If row("Net_Pay") IsNot DBNull.Value Then
                Dim netPay As Decimal
                If Decimal.TryParse(row("Net_Pay").ToString(), netPay) Then
                    _totalNetPay += netPay
                End If
            End If
        Next
    End Sub

    Private Sub ExportToCSV(dt As DataTable, filePath As String)
        Try
            Using writer As New StreamWriter(filePath, False, Encoding.UTF8)
                ' Write UTF-8 BOM for Excel compatibility
                writer.Write(ChrW(&HFEFF))

                ' Peso sign
                Dim pesoSign As String = "₱"

                ' Write header without peso sign in column names (Excel handles it better this way)
                Dim headers As String = "Staff ID,Name,Position,Daily Rate,Days Worked,Overtime Hours,Gross Pay,Deductions,Net Pay"
                writer.WriteLine(headers)

                ' Write data rows
                For Each row As DataRow In dt.Rows
                    Dim line As String = ""
                    For i As Integer = 0 To dt.Columns.Count - 1
                        Dim value As String = ""

                        ' Format values based on column type
                        Select Case dt.Columns(i).ColumnName
                            Case "Daily_Rate", "Gross_Pay", "Deductions", "Net_Pay"
                                ' Format currency values
                                Dim numericValue As Decimal
                                If Decimal.TryParse(row(i).ToString(), numericValue) Then
                                    value = pesoSign & " " & numericValue.ToString("N2")
                                Else
                                    value = pesoSign & " 0.00"
                                End If

                            Case "Overtime_Hours"
                                ' Format decimal with 1 decimal place
                                Dim numericValue As Decimal
                                If Decimal.TryParse(row(i).ToString(), numericValue) Then
                                    value = numericValue.ToString("N1")
                                Else
                                    value = "0.0"
                                End If

                            Case "Days_Worked"
                                ' Integer value
                                value = row(i).ToString()

                            Case Else
                                ' String values
                                value = row(i).ToString()
                        End Select

                        ' Escape CSV special characters
                        If value.Contains(",") OrElse value.Contains("""") OrElse value.Contains(vbCr) OrElse value.Contains(vbLf) Then
                            value = """" & value.Replace("""", """""") & """"
                        End If

                        line &= value
                        If i < dt.Columns.Count - 1 Then
                            line &= ","
                        End If
                    Next

                    writer.WriteLine(line)
                Next

                ' Add empty line
                writer.WriteLine()

                ' Add totals section
                writer.WriteLine($"Total Employees:,{_totalEmployees}")
                writer.WriteLine($"Total Gross Pay:,{pesoSign} {_totalGrossPay:N2}")
                writer.WriteLine($"Total Net Pay:,{pesoSign} {_totalNetPay:N2}")
                writer.WriteLine($"Total Deductions:,{pesoSign} {(_totalGrossPay - _totalNetPay):N2}")

                ' Add footer with generation info
                writer.WriteLine()
                writer.WriteLine($"Generated on:,{DateTime.Now:MM-dd-yyyy HH:mm:ss}")
            End Using

        Catch ex As Exception
            MessageBox.Show($"Error creating CSV file: {ex.Message}{vbCrLf}Stack Trace:{vbCrLf}{ex.StackTrace}",
                      "CSV Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw
        End Try
    End Sub
    Private Function CsvEscape(value As String) As String
        If value.Contains(",") OrElse value.Contains("""") OrElse value.Contains(vbCr) OrElse value.Contains(vbLf) Then
            Return """" & value.Replace("""", """""") & """"
        End If
        Return value
    End Function

    Private Sub GeneratePDF(data As DataTable, filePath As String, criteria As String)
        ' Create document - use landscape for better table display
        Dim document As New Document(PageSize.A4.Rotate())
        document.SetMargins(20, 20, 30, 30)

        ' Create PDF writer
        Dim writer As PdfWriter = PdfWriter.GetInstance(document, New FileStream(filePath, FileMode.Create))

        ' Add metadata
        document.AddTitle("Payroll Report")
        document.AddAuthor("Sparx System")
        document.AddCreationDate()

        ' Open document
        document.Open()

        ' Use a font that supports the peso symbol
        Dim baseFont As BaseFont
        Try
            ' Try to use Arial Unicode MS for Unicode support
            baseFont = BaseFont.CreateFont("c:\windows\fonts\arialuni.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED)
        Catch
            Try
                ' Fallback to Arial
                baseFont = BaseFont.CreateFont("c:\windows\fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED)
            Catch
                ' Final fallback to Helvetica
                baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)
            End Try
        End Try

        ' Create fonts - Fully qualify iTextSharp.text.Font to avoid ambiguity
        Dim titleFont = New iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim headerFont = New iTextSharp.text.Font(baseFont, 11, iTextSharp.text.Font.BOLD, BaseColor.WHITE)
        Dim normalFont = New iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim criteriaFont = New iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL, BaseColor.DARK_GRAY)
        Dim summaryFont = New iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim totalFont = New iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)

        ' Peso symbol
        Dim pesoSign As String = "₱"

        ' Add title
        Dim title As New Paragraph("PAYROLL REPORT", titleFont)
        title.Alignment = Element.ALIGN_CENTER
        title.SpacingAfter = 10
        document.Add(title)

        ' Add criteria
        Dim criteriaPara As New Paragraph(criteria, criteriaFont)
        criteriaPara.Alignment = Element.ALIGN_CENTER
        criteriaPara.SpacingAfter = 5
        document.Add(criteriaPara)

        ' Add generated date
        Dim generatedDate As New Paragraph($"Generated on: {DateTime.Now:MM-dd-yyyy HH:mm:ss}", criteriaFont)
        generatedDate.Alignment = Element.ALIGN_CENTER
        generatedDate.SpacingAfter = 15
        document.Add(generatedDate)

        ' Create table with 9 columns
        Dim table As New PdfPTable(9)
        table.WidthPercentage = 100
        table.SpacingBefore = 10
        table.SpacingAfter = 10

        ' Set column widths
        Dim columnWidths As Single() = {8, 18, 12, 10, 8, 10, 12, 12, 12}
        table.SetWidths(columnWidths)

        ' Add headers with peso signs
        Dim headers() As String = {
            "Staff ID",
            "Name",
            "Position",
            $"Daily Rate ({pesoSign})",
            "Days Worked",
            "Overtime Hours",
            $"Gross Pay ({pesoSign})",
            $"Deductions ({pesoSign})",
            $"Net Pay ({pesoSign})"
        }

        For Each header As String In headers
            Dim cell As New PdfPCell(New Phrase(header, headerFont))
            cell.BackgroundColor = New BaseColor(70, 130, 180) ' Steel blue
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.VerticalAlignment = Element.ALIGN_MIDDLE
            cell.Padding = 5
            table.AddCell(cell)
        Next

        ' Add data rows
        For Each row As DataRow In data.Rows
            ' Staff ID
            table.AddCell(New PdfPCell(New Phrase(row("Staff_ID").ToString(), normalFont)) With {
                .Padding = 5,
                .HorizontalAlignment = Element.ALIGN_CENTER
            })

            ' Name
            table.AddCell(New PdfPCell(New Phrase(row("Name").ToString(), normalFont)) With {
                .Padding = 5
            })

            ' Position
            table.AddCell(New PdfPCell(New Phrase(row("Position").ToString(), normalFont)) With {
                .Padding = 5
            })

            ' Daily Rate with peso sign
            Dim dailyRate As Decimal = Convert.ToDecimal(row("Daily_Rate"))
            Dim dailyRateText As String = $"{pesoSign} {dailyRate:N2}"
            table.AddCell(New PdfPCell(New Phrase(dailyRateText, normalFont)) With {
                .Padding = 5,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })

            ' Days Worked
            table.AddCell(New PdfPCell(New Phrase(row("Days_Worked").ToString(), normalFont)) With {
                .Padding = 5,
                .HorizontalAlignment = Element.ALIGN_CENTER
            })

            ' Overtime Hours
            Dim overtimeHours As Decimal = Convert.ToDecimal(row("Overtime_Hours"))
            table.AddCell(New PdfPCell(New Phrase(overtimeHours.ToString("N1"), normalFont)) With {
                .Padding = 5,
                .HorizontalAlignment = Element.ALIGN_CENTER
            })

            ' Gross Pay with peso sign
            Dim grossPay As Decimal = Convert.ToDecimal(row("Gross_Pay"))
            Dim grossPayText As String = $"{pesoSign} {grossPay:N2}"
            table.AddCell(New PdfPCell(New Phrase(grossPayText, normalFont)) With {
                .Padding = 5,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })

            ' Deductions with peso sign
            Dim deductions As Decimal = Convert.ToDecimal(row("Deductions"))
            Dim deductionsText As String = $"{pesoSign} {deductions:N2}"
            table.AddCell(New PdfPCell(New Phrase(deductionsText, normalFont)) With {
                .Padding = 5,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })

            ' Net Pay with peso sign
            Dim netPay As Decimal = Convert.ToDecimal(row("Net_Pay"))
            Dim netPayText As String = $"{pesoSign} {netPay:N2}"
            table.AddCell(New PdfPCell(New Phrase(netPayText, normalFont)) With {
                .Padding = 5,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })
        Next

        ' Add totals row with peso signs
        table.AddCell(New PdfPCell(New Phrase("TOTALS", totalFont)) With {
            .BackgroundColor = New BaseColor(255, 255, 200), ' Light yellow
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Padding = 5
        })

        ' Empty cells for Name, Position
        table.AddCell(New PdfPCell(New Phrase("", totalFont)) With {
            .BackgroundColor = New BaseColor(255, 255, 200),
            .Padding = 5
        })

        table.AddCell(New PdfPCell(New Phrase("", totalFont)) With {
            .BackgroundColor = New BaseColor(255, 255, 200),
            .Padding = 5
        })

        ' Total Daily Rate (average)
        Dim avgDailyRate As Decimal = If(_totalEmployees > 0, _totalGrossPay / (_totalEmployees * 20), 0) ' Approximation
        table.AddCell(New PdfPCell(New Phrase($"{pesoSign} {avgDailyRate:N2}", totalFont)) With {
            .BackgroundColor = New BaseColor(255, 255, 200),
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Padding = 5
        })

        ' Total Days Worked
        Dim totalDaysWorked As Integer = data.AsEnumerable().Sum(Function(r) Convert.ToInt32(r("Days_Worked")))
        table.AddCell(New PdfPCell(New Phrase(totalDaysWorked.ToString(), totalFont)) With {
            .BackgroundColor = New BaseColor(255, 255, 200),
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Padding = 5
        })

        ' Total Overtime Hours
        Dim totalOvertime As Decimal = data.AsEnumerable().Sum(Function(r) Convert.ToDecimal(r("Overtime_Hours")))
        table.AddCell(New PdfPCell(New Phrase(totalOvertime.ToString("N1"), totalFont)) With {
            .BackgroundColor = New BaseColor(255, 255, 200),
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Padding = 5
        })

        ' Total Gross Pay with peso sign
        table.AddCell(New PdfPCell(New Phrase($"{pesoSign} {_totalGrossPay:N2}", totalFont)) With {
            .BackgroundColor = New BaseColor(255, 255, 200),
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Padding = 5
        })

        ' Total Deductions with peso sign
        Dim totalDeductions As Decimal = _totalGrossPay - _totalNetPay
        table.AddCell(New PdfPCell(New Phrase($"{pesoSign} {totalDeductions:N2}", totalFont)) With {
            .BackgroundColor = New BaseColor(255, 255, 200),
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Padding = 5
        })

        ' Total Net Pay with peso sign
        table.AddCell(New PdfPCell(New Phrase($"{pesoSign} {_totalNetPay:N2}", totalFont)) With {
            .BackgroundColor = New BaseColor(255, 255, 200),
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Padding = 5
        })

        ' Add table to document
        document.Add(table)

        ' Add summary section
        Dim summaryPara As New Paragraph("Report Summary", summaryFont)
        summaryPara.SpacingBefore = 20
        summaryPara.SpacingAfter = 10
        document.Add(summaryPara)

        Dim summaryText As String = $"Total Employees: {_totalEmployees} | " &
                                    $"Total Days Worked: {totalDaysWorked} | " &
                                    $"Total Overtime Hours: {totalOvertime:N1} | " &
                                    $"Total Gross Pay: {pesoSign} {_totalGrossPay:N2} | " &
                                    $"Total Net Pay: {pesoSign} {_totalNetPay:N2}"

        Dim detailsPara As New Paragraph(summaryText, normalFont)
        detailsPara.SpacingAfter = 10
        document.Add(detailsPara)

        ' Add footer with page number
        Dim footer As New Paragraph($"Page {writer.PageNumber}", criteriaFont)
        footer.Alignment = Element.ALIGN_CENTER
        document.Add(footer)

        ' Close document
        document.Close()
    End Sub

    Private Sub SAPayrollExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPositions()
        SetDefaultDates()

        ' Initialize export format combo box
        cbExportFormat.Items.Clear()
        cbExportFormat.Items.AddRange(New Object() {"CSV", "PDF"})
        cbExportFormat.SelectedIndex = 0
    End Sub

    Private Sub LoadPositions()
        Try
            cbPositions.Items.Clear()
            cbPositions.Items.Add("All")

            ' Test connection first
            If TestConnection() Then
                Using conn As New MySqlConnection(connString)
                    Dim query As String = "SELECT DISTINCT position FROM staff WHERE position IS NOT NULL ORDER BY position"
                    Using cmd As New MySqlCommand(query, conn)
                        conn.Open()
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            While reader.Read()
                                cbPositions.Items.Add(reader("position").ToString())
                            End While
                        End Using
                    End Using
                End Using
            Else
                ' Use defaults if connection fails
                cbPositions.Items.AddRange({"Technician", "Customer Service", "Inventory"})
            End If

            cbPositions.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show($"Could not load positions: {ex.Message}", "Warning",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cbPositions.Items.AddRange({"All", "Technician", "Customer Service", "Inventory"})
            cbPositions.SelectedIndex = 0
        End Try
    End Sub

    Private Function TestConnection() As Boolean
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                conn.Close()
                Return True
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub SetDefaultDates()
        ' Set default to current month
        DTPStart.Value = New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
        DTPEnd.Value = DateTime.Today
        cbTimePeriod.SelectedIndex = 3 ' Monthly
    End Sub

    Private Sub cbTimePeriod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTimePeriod.SelectedIndexChanged
        Select Case cbTimePeriod.Text
            Case "Daily"
                DTPStart.Value = DateTime.Today
                DTPEnd.Value = DateTime.Today
                DTPStart.Enabled = True
                DTPEnd.Enabled = False

            Case "Weekly"
                Dim today As DateTime = DateTime.Today
                Dim startOfWeek As DateTime = today.AddDays(-(today.DayOfWeek - DayOfWeek.Monday))
                DTPStart.Value = startOfWeek
                DTPEnd.Value = startOfWeek.AddDays(6)
                DTPStart.Enabled = False
                DTPEnd.Enabled = False

            Case "Monthly"
                DTPStart.Value = New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
                DTPEnd.Value = DTPStart.Value.AddMonths(1).AddDays(-1)
                DTPStart.Enabled = False
                DTPEnd.Enabled = False

            Case "Quarterly"
                Dim quarter As Integer = Math.Ceiling(DateTime.Today.Month / 3.0)
                Dim startMonth As Integer = (quarter - 1) * 3 + 1
                DTPStart.Value = New DateTime(DateTime.Today.Year, startMonth, 1)
                DTPEnd.Value = DTPStart.Value.AddMonths(3).AddDays(-1)
                DTPStart.Enabled = False
                DTPEnd.Enabled = False

            Case "Yearly"
                DTPStart.Value = New DateTime(DateTime.Today.Year, 1, 1)
                DTPEnd.Value = New DateTime(DateTime.Today.Year, 12, 31)
                DTPStart.Enabled = False
                DTPEnd.Enabled = False

            Case "Custom"
                DTPStart.Enabled = True
                DTPEnd.Enabled = True
        End Select
    End Sub

    Private Sub DTPEnd_ValueChanged(sender As Object, e As EventArgs) Handles DTPEnd.ValueChanged
        ' Add any necessary validation here
    End Sub

    Private Sub cbExportFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbExportFormat.SelectedIndexChanged
        ' Add any necessary format-specific settings here
    End Sub
End Class