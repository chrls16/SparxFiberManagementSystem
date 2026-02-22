Imports System.Drawing
Imports Color = System.Drawing.Color
Imports MD = MigraDoc.DocumentObjectModel
Imports MDT = MigraDoc.DocumentObjectModel.Tables
Imports MDC = MigraDoc.DocumentObjectModel.Shapes
Imports System.Configuration
Imports MySqlConnector
Imports System.Data
Imports System.IO
Imports System.Collections.Generic
Imports PdfSharp.Pdf
Imports PdfSharp.Drawing

Public Class SASubscriberExport
    Private connectionString As String = "server=127.0.0.1;database=sparx;uid=root;pwd=;"

    Private Sub SASubscriberExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load Plan Type options
        cbPlanType.Items.Clear()
        cbPlanType.Items.Add("Basic 25Mbps")
        cbPlanType.Items.Add("Standard 50Mbps")
        cbPlanType.Items.Add("Premium 100Mbps")
        cbPlanType.SelectedIndex = 0
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            ' Create a SaveFileDialog to choose where to save the CSV
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv"
            saveFileDialog.Title = "Save Subscriber Report"
            saveFileDialog.FileName = $"Subscriber_Report_{DateTime.Now:yyyyMMdd_HHmmss}.csv"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                ' Get the selected plan type from combobox
                Dim selectedPlan As String = GetPlanTypeFromComboBox()

                ' Export data to CSV
                ExportSubscribersToCSV(saveFileDialog.FileName, selectedPlan)

                MessageBox.Show($"Subscriber report exported successfully to:{vbCrLf}{saveFileDialog.FileName}",
                              "Export Complete",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error exporting data: {ex.Message}",
                          "Export Error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetPlanTypeFromComboBox() As String
        ' Extract the plan type from the combobox selection
        Select Case cbPlanType.SelectedItem.ToString()
            Case "Basic 25Mbps"
                Return "Basic"
            Case "Standard 50Mbps"
                Return "Standard"
            Case "Premium 100Mbps"
                Return "Premium"
            Case Else
                Return "Basic"
        End Select
    End Function

    Private Sub ExportSubscribersToCSV(filePath As String, planType As String)
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' Query to get subscriber data based on plan type
            Dim query As String = "
                SELECT 
                    customer_id AS 'Customer ID',
                    CONCAT(first_name, ' ', last_name) AS 'Full Name',
                    contact_number AS 'Contact No.',
                    installation_address AS 'Installation Address',
                    date_installed AS 'Date Installed',
                    plan_type AS 'Plan Type',
                    monthly_rate AS 'Monthly Rate',
                    DATE_ADD(date_installed, INTERVAL 1 MONTH) AS 'Due Date',
                    account_status AS 'Status'
                FROM customer
                WHERE plan_type = @planType
                ORDER BY customer_id"

            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@planType", planType)

                Using adapter As New MySqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)

                    ' Write data to CSV file
                    Using writer As New StreamWriter(filePath)
                        ' Write header
                        writer.WriteLine("Customer ID,Full Name,Contact No.,Installation Address,Date Installed,Plan Type,Monthly Rate,Due Date,Status")

                        ' Write data rows
                        For Each row As DataRow In dataTable.Rows
                            ' Escape commas in fields and handle null values
                            Dim line As String = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                                                               EscapeCsvField(row("Customer ID").ToString()),
                                                               EscapeCsvField(row("Full Name").ToString()),
                                                               EscapeCsvField(row("Contact No.").ToString()),
                                                               EscapeCsvField(row("Installation Address").ToString()),
                                                               FormatDate(row("Date Installed")),
                                                               EscapeCsvField(row("Plan Type").ToString()),
                                                               FormatDecimal(row("Monthly Rate")),
                                                               FormatDate(row("Due Date")),
                                                               EscapeCsvField(row("Status").ToString()))
                            writer.WriteLine(line)
                        Next
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Function EscapeCsvField(field As String) As String
        ' Escape fields that contain commas or quotes
        If String.IsNullOrEmpty(field) Then
            Return ""
        End If

        ' If field contains comma, quote, or newline, wrap in quotes
        If field.Contains(",") OrElse field.Contains("""") OrElse field.Contains(vbCr) OrElse field.Contains(vbLf) Then
            ' Double up any quotes in the field
            field = field.Replace("""", """""")
            Return $"""{field}"""
        Else
            Return field
        End If
    End Function

    Private Function FormatDate(dateValue As Object) As String
        If dateValue Is DBNull.Value OrElse dateValue Is Nothing Then
            Return ""
        End If

        If TypeOf dateValue Is DateTime Then
            Return DirectCast(dateValue, DateTime).ToString("yyyy-MM-dd")
        Else
            Return dateValue.ToString()
        End If
    End Function

    Private Function FormatDecimal(decimalValue As Object) As String
        If decimalValue Is DBNull.Value OrElse decimalValue Is Nothing Then
            Return "0.00"
        End If

        If IsNumeric(decimalValue) Then
            Return String.Format("{0:N2}", decimalValue)
        Else
            Return "0.00"
        End If
    End Function
End Class