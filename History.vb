Imports System.Configuration
Imports MySqlConnector
Imports System.Linq

Public Class History
    Public Property CurrentCustomerId As Integer

    Private ReadOnly Property CONNECTION_STRING As String
        Get
            Try
                ' Attempt to get from config, otherwise use default
                Dim configStr = ConfigurationManager.ConnectionStrings("SparxDb")?.ConnectionString
                Return If(configStr, "Server=localhost;Database=sparx;Uid=root;Pwd=;")
            Catch
                Return "Server=localhost;Database=sparx;Uid=root;Pwd=;"
            End Try
        End Get
    End Property

    Private allHistoryData As New List(Of HistoryRecord)()

    Private Class HistoryRecord
        Public Property TransactionDate As DateTime
        Public Property TransactionType As String
        Public Property ServiceID As String
        Public Property StartDate As DateTime
        Public Property EndDate As DateTime
        Public Property MonthlyRate As Decimal
        Public Property PaymentMethod As String
        Public Property Status As String
    End Class

    Private Sub History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeFilters()
        LoadHistoryData()
    End Sub

    Private Sub InitializeFilters()
        ' Clear and Populate filters
        DateComboBox.Items.Clear()
        DateComboBox.Items.AddRange({"All", "Last 7 Days", "Last 30 Days", "Last 3 Months", "Last Year"})
        DateComboBox.SelectedIndex = 0

        ServiceComboBox.Items.Clear()
        ServiceComboBox.Items.AddRange({"All", "Billing", "Service"})
        ServiceComboBox.SelectedIndex = 0

        StatusComboBox.Items.Clear()
        StatusComboBox.Items.AddRange({"All", "Paid", "Unpaid", "Pending", "Completed"})
        StatusComboBox.SelectedIndex = 0

        ' Event handlers
        RemoveHandler DateComboBox.SelectedIndexChanged, AddressOf FilterChanged
        RemoveHandler ServiceComboBox.SelectedIndexChanged, AddressOf FilterChanged
        RemoveHandler StatusComboBox.SelectedIndexChanged, AddressOf FilterChanged

        AddHandler DateComboBox.SelectedIndexChanged, AddressOf FilterChanged
        AddHandler ServiceComboBox.SelectedIndexChanged, AddressOf FilterChanged
        AddHandler StatusComboBox.SelectedIndexChanged, AddressOf FilterChanged
    End Sub

    Private Sub FilterChanged(sender As Object, e As EventArgs)
        ApplyFiltersAndDisplay()
    End Sub

    Private Sub LoadHistoryData()
        HistoryTable.Rows.Clear()
        allHistoryData.Clear()

        If CurrentCustomerId <= 0 Then Return

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                ' Corrected Query based on your sparx.sql
                ' Note: Using service and payment tables
                Dim query As String = "
                    SELECT 
                        p.payment_date as transaction_date,
                        'Billing' as transaction_type,
                        p.payment_id as service_id,
                        s.start_date,
                        s.end_date,
                        p.amount as monthly_rate,
                        p.payment_method,
                        p.status
                    FROM payment p
                    LEFT JOIN service s ON p.service_id = s.service_id
                    WHERE p.customer_id = @id
                    
                    UNION ALL

                    SELECT 
                        s.start_date as transaction_date,
                        'Service' as transaction_type,
                        s.service_id,
                        s.start_date,
                        s.end_date,
                        s.rate as monthly_rate,
                        'N/A' as payment_method,
                        s.status
                    FROM service s
                    WHERE s.customer_id = @id
                    ORDER BY transaction_date DESC"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", CurrentCustomerId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            allHistoryData.Add(New HistoryRecord With {
                                .TransactionDate = If(reader("transaction_date") Is DBNull.Value, DateTime.Now, Convert.ToDateTime(reader("transaction_date"))),
                                .TransactionType = reader("transaction_type").ToString(),
                                .ServiceID = reader("service_id").ToString(),
                                .StartDate = If(reader("start_date") Is DBNull.Value, DateTime.Now, Convert.ToDateTime(reader("start_date"))),
                                .EndDate = If(reader("end_date") Is DBNull.Value, DateTime.Now, Convert.ToDateTime(reader("end_date"))),
                                .MonthlyRate = If(reader("monthly_rate") Is DBNull.Value, 0, Convert.ToDecimal(reader("monthly_rate"))),
                                .PaymentMethod = reader("payment_method").ToString(),
                                .Status = reader("status").ToString()
                            })
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error: " & ex.Message)
            LoadDummyData() ' Fallback to dummy data so the UI isn't empty
        End Try

        ApplyFiltersAndDisplay()
    End Sub

    Private Sub ApplyFiltersAndDisplay()
        HistoryTable.Rows.Clear()

        Dim filtered = allHistoryData.AsEnumerable()

        ' Filter Type
        If ServiceComboBox.Text <> "All" Then
            filtered = filtered.Where(Function(x) x.TransactionType = ServiceComboBox.Text)
        End If

        ' Filter Status
        If StatusComboBox.Text <> "All" Then
            filtered = filtered.Where(Function(x) x.Status.Contains(StatusComboBox.Text))
        End If

        ' Filter Date
        Dim limitDate = GetStartDateForRange(DateComboBox.Text)
        filtered = filtered.Where(Function(x) x.TransactionDate >= limitDate)

        For Each rec In filtered
            HistoryTable.Rows.Add(
                rec.TransactionDate.ToShortDateString(),
                rec.TransactionType,
                rec.ServiceID,
                rec.StartDate.ToShortDateString(),
                rec.EndDate.ToShortDateString(),
                rec.MonthlyRate.ToString("N2"),
                rec.PaymentMethod,
                rec.Status
            )
        Next
    End Sub

    Private Function GetStartDateForRange(range As String) As DateTime
        Select Case range
            Case "Last 7 Days" : Return DateTime.Now.AddDays(-7)
            Case "Last 30 Days" : Return DateTime.Now.AddDays(-30)
            Case "Last 3 Months" : Return DateTime.Now.AddMonths(-3)
            Case "Last Year" : Return DateTime.Now.AddYears(-1)
            Case Else : Return DateTime.MinValue
        End Select
    End Function

    Private Sub LoadDummyData()
        allHistoryData.Add(New HistoryRecord With {
            .TransactionDate = DateTime.Now,
            .TransactionType = "Billing",
            .ServiceID = "DB-ERR",
            .Status = "Check Connection"
        })
    End Sub

    Private Sub lblHistoryDetails_Click(sender As Object, e As EventArgs) Handles lblHistoryDetails.Click

    End Sub

    Private Sub ServiceLbl_Click(sender As Object, e As EventArgs) Handles ServiceLbl.Click

    End Sub

    Private Sub FilterPanel_Paint_1(sender As Object, e As PaintEventArgs) Handles FilterPanel.Paint

    End Sub

    Private Sub btnInstallationPrevious_Click(sender As Object, e As EventArgs) Handles btnInstallationPrevious.Click

    End Sub
End Class