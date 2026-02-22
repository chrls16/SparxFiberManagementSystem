' SAInstallationExport.vb
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports MySqlConnector

Public Class SAInstallationExport
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

    Private Sub cbTimePeriod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTimePeriod.SelectedIndexChanged
        Dim selectedPeriod As String = cbTimePeriod.SelectedItem.ToString()
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
            Case "Custom"
                Exit Sub
            Case Else
                Exit Sub
        End Select
        DTPEnd.Value = endDate
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If Not ValidateDates() Then
            MessageBox.Show("Start date cannot be greater than end date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' Get installation data
            Dim installationData As DataTable = GetInstallationData(DTPStart.Value, DTPEnd.Value)

            If installationData.Rows.Count = 0 Then
                MessageBox.Show("No installation records found for the selected date range.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Prompt user to save file
            Using saveDialog As New SaveFileDialog()
                saveDialog.Filter = "CSV Files (*.csv)|*.csv"
                saveDialog.FilterIndex = 1
                saveDialog.RestoreDirectory = True
                saveDialog.FileName = $"Installation_Report_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
                saveDialog.DefaultExt = "csv"

                If saveDialog.ShowDialog() = DialogResult.OK Then
                    ' Export to CSV
                    ExportToCSV(installationData, saveDialog.FileName)

                    MessageBox.Show($"Installation report exported successfully!{Environment.NewLine}{installationData.Rows.Count} records saved to:{Environment.NewLine}{saveDialog.FileName}",
                                    "Export Complete",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information)

                    Me.Close()
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error exporting installation data: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDates() As Boolean
        Return DTPStart.Value <= DTPEnd.Value
    End Function

    Private Function GetInstallationData(startDate As DateTime, endDate As DateTime) As DataTable
        Dim dt As New DataTable()

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                ' Modified query to include all required columns and installation fee
                Dim query As String = "SELECT " &
                                    "    s.service_id AS 'Service ID', " &
                                    "    CONCAT(c.first_name, ' ', c.last_name) AS 'Customer Name', " &
                                    "    COALESCE(CONCAT(t.first_name, ' ', t.last_name), 'Not Assigned') AS Technician, " &
                                    "    c.contact_number AS 'Contact No.', " &
                                    "    c.installation_address AS Address, " &
                                    "    s.date_requested AS 'Date Requested', " &
                                    "    CASE " &
                                    "        WHEN c.plan_type = 'Basic' THEN 700.00 " &
                                    "        WHEN c.plan_type = 'Standard' THEN 1000.00 " &
                                    "        WHEN c.plan_type = 'Premium' THEN 1500.00 " &
                                    "        ELSE 0.00 " &
                                    "    END AS 'Installation Fee', " &
                                    "    s.status AS Status " &
                                    "FROM " &
                                    "    service s " &
                                    "JOIN " &
                                    "    customer c ON s.customer_id = c.customer_id " &
                                    "LEFT JOIN " &
                                    "    staff t ON s.staff_id = t.staff_id AND t.position = 'Technician' " &
                                    "WHERE " &
                                    "    s.service_type = 'Installation' " &
                                    "    AND s.date_requested BETWEEN @startDate AND @endDate " &
                                    "ORDER BY " &
                                    "    s.date_requested DESC"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@startDate", startDate.Date)
                    cmd.Parameters.AddWithValue("@endDate", endDate.Date.AddDays(1).AddSeconds(-1)) ' Include entire end date

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        dt.Load(reader)
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Throw New Exception("Error retrieving installation data: " & ex.Message)
        End Try

        Return dt
    End Function

    Private Sub ExportToCSV(dataTable As DataTable, filePath As String)
        Try
            Using writer As New StreamWriter(filePath, False, Encoding.UTF8)
                ' Write CSV header (column names)
                Dim headers As New List(Of String)()
                For Each column As DataColumn In dataTable.Columns
                    headers.Add(QuoteCSVField(column.ColumnName))
                Next
                writer.WriteLine(String.Join(",", headers))

                ' Write data rows
                For Each row As DataRow In dataTable.Rows
                    Dim values As New List(Of String)()
                    For Each column As DataColumn In dataTable.Columns
                        Dim value As String = ""
                        If Not row.IsNull(column) Then
                            value = row(column).ToString()

                            ' Format date fields if needed
                            If column.DataType Is GetType(DateTime) Then
                                Dim dateValue As DateTime
                                If DateTime.TryParse(value, dateValue) Then
                                    value = dateValue.ToString("MM/dd/yyyy")
                                End If
                            End If

                            ' Format numeric fields
                            If column.DataType Is GetType(Decimal) OrElse column.DataType Is GetType(Double) Then
                                Dim decValue As Decimal
                                If Decimal.TryParse(value, decValue) Then
                                    value = decValue.ToString("F2")
                                End If
                            End If
                        End If
                        values.Add(QuoteCSVField(value))
                    Next
                    writer.WriteLine(String.Join(",", values))
                Next
            End Using

        Catch ex As Exception
            Throw New Exception("Error writing CSV file: " & ex.Message)
        End Try
    End Sub

    Private Function QuoteCSVField(field As String) As String
        ' Quote fields that contain commas, quotes, or line breaks
        If String.IsNullOrEmpty(field) Then
            Return ""
        End If

        If field.Contains(",") OrElse field.Contains("""") OrElse field.Contains(Environment.NewLine) OrElse field.Contains(vbCr) OrElse field.Contains(vbLf) Then
            ' Escape quotes by doubling them
            Return """" & field.Replace("""", """""") & """"
        End If

        Return field
    End Function


End Class