Imports System.Configuration
Imports MySqlConnector

Public Class AdminHistory
    Private historyControl As historyview

    Private _connectionString As String = Nothing
    Private _selectedCustomerId As Integer = 0
    Private _currentCustomerData As DataRow = Nothing
    Private _searchResults As DataTable = Nothing
    Private WithEvents searchTimer As New Timer()
    Private lastSearchText As String = ""
    Private _currentPage As Integer = 1
    Private _pageSize As Integer = 50
    Private _totalRecords As Integer = 0

    Public Property currentCustomerID As String
        Get
            Return _selectedCustomerId.ToString()
        End Get
        Set(value As String)
            If Integer.TryParse(value, _selectedCustomerId) Then
                LoadCustomerById(_selectedCustomerId)
            End If
        End Set
    End Property

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

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub historyview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateSearchDropdown()
        ClearCustomerInfo()


        searchTimer.Interval = 300
        searchTimer.Stop()

    End Sub

    Private Sub CreateSearchDropdown()
        Dim listBox As New ListBox()
        listBox.Name = "SearchSuggestions"
        listBox.Visible = False
        listBox.BorderStyle = BorderStyle.FixedSingle
        listBox.BackColor = Color.White
        listBox.Font = New Font("Segoe UI", 11)
        listBox.Width = txtInstallationSearchSA.Width
        listBox.Height = 150
        listBox.Location = New Point(txtInstallationSearchSA.Location.X, txtInstallationSearchSA.Location.Y + txtInstallationSearchSA.Height)
        listBox.DrawMode = DrawMode.OwnerDrawFixed
        listBox.ItemHeight = 35

        AddHandler listBox.DrawItem, AddressOf SearchSuggestions_DrawItem

        AddHandler listBox.SelectedIndexChanged, AddressOf SearchSuggestion_Selected
        AddHandler listBox.KeyDown, AddressOf SearchSuggestions_KeyDown

        Me.Controls.Add(listBox)
        listBox.BringToFront()
    End Sub

    Private Sub SearchSuggestions_DrawItem(sender As Object, e As DrawItemEventArgs)
        If e.Index < 0 Then Return

        Dim listBox As ListBox = CType(sender, ListBox)
        Dim item As SearchItem = CType(listBox.Items(e.Index), SearchItem)

        ' Background
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(240, 240, 240)), e.Bounds)
        Else
            e.Graphics.FillRectangle(New SolidBrush(Color.White), e.Bounds)
        End If

        ' Border
        e.Graphics.DrawRectangle(New Pen(Color.LightGray), e.Bounds)

        ' Text
        Dim nameFont As New Font("Segoe UI Semibold", 10, FontStyle.Bold)
        Dim phoneFont As New Font("Segoe UI", 9, FontStyle.Regular)
        Dim nameColor As Color = If((e.State And DrawItemState.Selected) = DrawItemState.Selected, Color.Blue, Color.Black)
        Dim phoneColor As Color = If((e.State And DrawItemState.Selected) = DrawItemState.Selected, Color.DarkBlue, Color.Gray)

        ' Draw name
        Dim nameBounds As New Rectangle(e.Bounds.X + 10, e.Bounds.Y + 5, e.Bounds.Width - 20, 18)
        e.Graphics.DrawString(item.DisplayText.Split(" - ")(0), nameFont, New SolidBrush(nameColor), nameBounds)

        ' Draw phone
        Dim phoneBounds As New Rectangle(e.Bounds.X + 10, e.Bounds.Y + 20, e.Bounds.Width - 20, 15)
        e.Graphics.DrawString(item.DisplayText.Split(" - ")(1), phoneFont, New SolidBrush(phoneColor), phoneBounds)
    End Sub

    Private Sub SearchSuggestions_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Dim listBox As ListBox = CType(sender, ListBox)
            If listBox.SelectedIndex >= 0 Then
                SearchSuggestion_Selected(sender, EventArgs.Empty)
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            HideSearchSuggestions()
        End If
    End Sub

    Private Sub txtInstallationSearchSA_TextChanged(sender As Object, e As EventArgs) Handles txtInstallationSearchSA.TextChanged
        If txtInstallationSearchSA.Text.Length >= 2 Then
            lastSearchText = txtInstallationSearchSA.Text
            searchTimer.Stop()
            searchTimer.Start() ' Wait 300ms before searching
        Else
            searchTimer.Stop()
            HideSearchSuggestions()
            If String.IsNullOrEmpty(txtInstallationSearchSA.Text) Then
                ClearCustomerInfo()
            End If
        End If
    End Sub

    Private Sub searchTimer_Tick(sender As Object, e As EventArgs) Handles searchTimer.Tick
        searchTimer.Stop()
        SearchCustomers(lastSearchText)
    End Sub

    Private Sub SearchCustomers(searchText As String)
        If String.IsNullOrEmpty(CONNECTION_STRING) Then
            Exit Sub
        End If

        Task.Run(Sub()
                     Try
                         Using conn As New MySqlConnection(CONNECTION_STRING)
                             conn.Open()

                             Dim query As String = "
SELECT customer_id, first_name, last_name, contact_number
FROM customer
WHERE
(
    (@first IS NULL OR first_name LIKE @first)
    AND
    (@last IS NULL OR last_name LIKE @last)
)
OR contact_number LIKE @phone
ORDER BY
    CASE
        WHEN first_name LIKE @first AND last_name LIKE @last THEN 0
        ELSE 1
    END,
    first_name, last_name
LIMIT 10"


                             Using cmd As New MySqlCommand(query, conn)

                                 Dim parts = searchText.Trim().
                                                 Split(" "c, StringSplitOptions.RemoveEmptyEntries)

                                 Dim first As String = If(parts.Length > 0, $"%{parts(0)}%", Nothing)
                                 Dim last As String = If(parts.Length > 1, $"%{parts(1)}%", Nothing)
                                 Dim phone As String = $"%{searchText}%"

                                 cmd.Parameters.AddWithValue("@first", If(first, DBNull.Value))
                                 cmd.Parameters.AddWithValue("@last", If(last, DBNull.Value))
                                 cmd.Parameters.AddWithValue("@phone", phone)

                                 Using adapter As New MySqlDataAdapter(cmd)
                                     Dim results As New DataTable()
                                     adapter.Fill(results)

                                     Me.Invoke(Sub()
                                                   ShowSearchSuggestions(results)
                                               End Sub)
                                 End Using
                             End Using
                         End Using
                     Catch ex As Exception
                         Console.WriteLine($"Search error: {ex.Message}")
                     End Try
                 End Sub)

    End Sub

    Private Sub ShowSearchSuggestions(results As DataTable)
        Dim listBox As ListBox = TryCast(Me.Controls("SearchSuggestions"), ListBox)
        If listBox Is Nothing Then Exit Sub

        listBox.Items.Clear()

        If results.Rows.Count > 0 Then
            For Each row As DataRow In results.Rows
                Dim paddedId As String = Convert.ToInt32(row("customer_id")).ToString("D5")
                Dim displayText As String = $"[{paddedId}] {row("first_name")} {row("last_name")} - {row("contact_number")}"
                listBox.Items.Add(New SearchItem(displayText, Convert.ToInt32(row("customer_id"))))
            Next

            listBox.Visible = True
            listBox.BringToFront()
            listBox.ClearSelected()
        Else
            listBox.Visible = False
        End If
    End Sub

    Private Sub HideSearchSuggestions()
        Dim listBox As ListBox = TryCast(Me.Controls("SearchSuggestions"), ListBox)
        If listBox IsNot Nothing Then
            listBox.Visible = False
        End If
    End Sub

    Private Sub SearchSuggestion_Selected(sender As Object, e As EventArgs)
        Dim listBox As ListBox = TryCast(sender, ListBox)
        If listBox Is Nothing OrElse listBox.SelectedIndex = -1 Then Exit Sub

        Dim selectedItem As SearchItem = TryCast(listBox.SelectedItem, SearchItem)
        If selectedItem IsNot Nothing Then
            Dim displayText As String = selectedItem.DisplayText.Split(" - ")(0)
            txtInstallationSearchSA.Text = displayText

            LoadCustomerById(selectedItem.CustomerId)

            HideSearchSuggestions()
        End If
    End Sub

    Private Sub LoadCustomerById(customerId As Integer)
        If String.IsNullOrEmpty(CONNECTION_STRING) Then
            MessageBox.Show("Database connection not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        SetLoadingState(True)

        Task.Run(Sub()
                     Try
                         Using conn As New MySqlConnection(CONNECTION_STRING)
                             conn.Open()
                             Dim query As String = "
                        SELECT customer_id, first_name, last_name, contact_number, email_address, 
                               plan_type, account_status, date_installed, monthly_rate
                        FROM customer 
                        WHERE customer_id = @customerId"

                             Using cmd As New MySqlCommand(query, conn)
                                 cmd.Parameters.AddWithValue("@customerId", customerId)

                                 Using adapter As New MySqlDataAdapter(cmd)
                                     Dim dt As New DataTable()
                                     adapter.Fill(dt)

                                     If dt.Rows.Count > 0 Then
                                         Me.Invoke(Sub()
                                                       LoadCustomerData(dt.Rows(0))
                                                       SetLoadingState(False)
                                                   End Sub)
                                     Else
                                         Me.Invoke(Sub()
                                                       MessageBox.Show("Customer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                       SetLoadingState(False)
                                                   End Sub)
                                     End If
                                 End Using
                             End Using
                         End Using
                     Catch ex As Exception
                         Me.Invoke(Sub()
                                       MessageBox.Show($"Error loading customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                       SetLoadingState(False)
                                   End Sub)
                     End Try
                 End Sub)
    End Sub

    Private Sub SetLoadingState(isLoading As Boolean)
        If isLoading Then
            Cursor = Cursors.WaitCursor

            btnNext.Enabled = False
            btnHistoryPreviousSA.Enabled = False
        Else
            Cursor = Cursors.Default

            btnNext.Enabled = True
            btnHistoryPreviousSA.Enabled = True
        End If
    End Sub

    Private Sub LoadCustomerData(customerRow As DataRow)
        _selectedCustomerId = Convert.ToInt32(customerRow("customer_id"))
        _currentCustomerData = customerRow
        _currentPage = 1

        IDLbl.Text = $"C{_selectedCustomerId:0000}"
        NameCustomerLbl.Text = $"{customerRow("first_name")} {customerRow("last_name")}"
        NumberLbl.Text = customerRow("contact_number").ToString()
        EmailAddLbl.Text = customerRow("email_address").ToString()
        PlanTypeLbl.Text = customerRow("plan_type").ToString()
        StatusLbl.Text = customerRow("account_status").ToString()

        If StatusLbl.Text.ToLower() = "active" Then
            StatusLbl.ForeColor = Color.Green
            PanelRound3.BackColor = Color.FromArgb(192, 255, 192)
        Else
            StatusLbl.ForeColor = Color.Red
            PanelRound3.BackColor = Color.FromArgb(255, 192, 192)
        End If

        Select Case PlanTypeLbl.Text.ToLower()
            Case "premium"
                PlanTypeLbl.ForeColor = Color.Purple
                PanelRound2.BackColor = Color.FromArgb(255, 192, 255)
            Case "standard"
                PlanTypeLbl.ForeColor = Color.Blue
                PanelRound2.BackColor = Color.FromArgb(192, 192, 255)
            Case "basic"
                PlanTypeLbl.ForeColor = Color.DarkBlue
                PanelRound2.BackColor = Color.FromArgb(192, 255, 255)
            Case Else
                PlanTypeLbl.ForeColor = Color.Black
                PanelRound2.BackColor = Color.FromArgb(192, 255, 192)
        End Select

        LoadCustomerStatistics()
        LoadPaymentHistory()
    End Sub

    Private Sub LoadCustomerStatistics()
        If _selectedCustomerId = 0 Then Exit Sub

        Task.Run(Sub()
                     Try
                         Using conn As New MySqlConnection(CONNECTION_STRING)
                             conn.Open()

                             ' Query to get the correct totals and counts from the service table
                             Dim statsQuery As String = "
                    SELECT 
                        COALESCE(SUM(service_cost), 0) as total_amount,
                        COUNT(CASE WHEN status = 'Completed' THEN 1 END) as completed_count,
                        COUNT(*) as total_requests
                    FROM service 
                    WHERE customer_id = @customerId"

                             Using cmd As New MySqlCommand(statsQuery, conn)
                                 cmd.Parameters.AddWithValue("@customerId", _selectedCustomerId)
                                 Using reader As MySqlDataReader = cmd.ExecuteReader()
                                     If reader.Read() Then
                                         ' Calculate Total Paid (₱1,831.99)
                                         Dim totalPaidAmt As Decimal = reader.GetDecimal("total_amount")
                                         Dim servicesDone As Integer = reader.GetInt32("completed_count")
                                         Dim totalRequests As Integer = reader.GetInt32("total_requests")

                                         Me.Invoke(Sub()
                                                       ' 1. Update Top Total Paid (Fixes the ₱0.00 issue)
                                                       AmountPaidLbl.Text = $"₱{totalPaidAmt:N2}"

                                                       ' 2. Update Top Services Completed (Should show 2)
                                                       NumServicesLbl.Text = servicesDone.ToString()

                                                       ' 3. Update Bottom Total Payments (Should show 2)
                                                       NumPaymentsLbl.Text = servicesDone.ToString()

                                                       ' 4. Update Bottom Service Requests (Should show 2)
                                                       NumRequestServiceLbl.Text = totalRequests.ToString()
                                                   End Sub)
                                     End If
                                 End Using
                             End Using

                             ' Re-calculate Account Age to prevent it from showing "---"
                             If _currentCustomerData IsNot Nothing AndAlso Not IsDBNull(_currentCustomerData("date_installed")) Then
                                 Dim installDate As Date = _currentCustomerData("date_installed")
                                 Dim accountAge As TimeSpan = DateTime.Now - installDate
                                 Dim months As Integer = CInt(accountAge.TotalDays / 30.437)
                                 Me.Invoke(Sub() AccAgeLbl.Text = $"{months} Month{If(months <> 1, "s", "")}")
                             End If
                         End Using
                     Catch ex As Exception
                         Console.WriteLine($"Error updating labels: {ex.Message}")
                     End Try
                 End Sub)
    End Sub

    Private Sub LoadPaymentHistory()
        If _selectedCustomerId = 0 Then Exit Sub
        SetLoadingState(True)

        Task.Run(Sub()
                     Try
                         Using conn As New MySqlConnection(CONNECTION_STRING)
                             conn.Open()

                             ' Pulling only unique service entries to avoid duplicates with Billing
                             Dim query As String = "
                    SELECT 
                        s.date_completed as Date, 
                        s.service_cost as Amount, 
                        s.service_type as Method, 
                        s.status as Status, 
                        CONCAT('SVC-', s.service_id) as Reference
                    FROM service s 
                    WHERE s.customer_id = @customerId AND s.status = 'Completed'
                    ORDER BY Date DESC"

                             Using cmd As New MySqlCommand(query, conn)
                                 cmd.Parameters.AddWithValue("@customerId", _selectedCustomerId)
                                 Using adapter As New MySqlDataAdapter(cmd)
                                     Dim dt As New DataTable()
                                     adapter.Fill(dt)

                                     Me.Invoke(Sub()
                                                   PaymentHistoryDVG.Rows.Clear()
                                                   For Each row As DataRow In dt.Rows
                                                       Dim rowIndex As Integer = PaymentHistoryDVG.Rows.Add()
                                                       Dim dgvRow = PaymentHistoryDVG.Rows(rowIndex)

                                                       ' Populate columns with individual service costs
                                                       dgvRow.Cells("DateColumn").Value = Convert.ToDateTime(row("Date")).ToString("MM/dd/yyyy")
                                                       dgvRow.Cells("Amount").Value = $"₱{Convert.ToDecimal(row("Amount")):N2}"
                                                       dgvRow.Cells("PaymentMethod").Value = row("Method").ToString() ' Repair or Installation
                                                       dgvRow.Cells("Status").Value = row("Status").ToString()
                                                       dgvRow.Cells("Reference").Value = row("Reference").ToString()
                                                   Next
                                                   SetLoadingState(False)
                                               End Sub)
                                 End Using
                             End Using
                         End Using
                     Catch ex As Exception
                         Me.Invoke(Sub() SetLoadingState(False))
                     End Try
                 End Sub)
    End Sub

    Private Sub UpdatePaginationButtons()
        Dim totalPages As Integer = If(_totalRecords > 0, Math.Ceiling(_totalRecords / _pageSize), 1)

        btnHistoryPreviousSA.Enabled = (_currentPage > 1)
        btnNext.Enabled = (_currentPage < totalPages)

        btnHistoryPreviousSA.Visible = (_totalRecords > _pageSize)
        btnNext.Visible = (_totalRecords > _pageSize)

        btnHistoryPreviousSA.Text = "‹ Previous"
        btnNext.Text = $"Next › (Page {_currentPage} of {totalPages})"
    End Sub

    Private Sub ClearCustomerInfo()
        _selectedCustomerId = 0
        _currentCustomerData = Nothing
        _currentPage = 1
        _totalRecords = 0

        IDLbl.Text = "---"
        NameCustomerLbl.Text = "---"
        NumberLbl.Text = "---"
        EmailAddLbl.Text = "---"
        PlanTypeLbl.Text = "---"
        StatusLbl.Text = "---"
        AmountPaidLbl.Text = "₱0.00"
        NumServicesLbl.Text = "0"
        NumPaymentsLbl.Text = "0"
        NumRequestServiceLbl.Text = "0"
        AccAgeLbl.Text = "---"

        StatusLbl.ForeColor = Color.Black
        PanelRound3.BackColor = Color.FromArgb(224, 224, 224)
        PlanTypeLbl.ForeColor = Color.Black
        PanelRound2.BackColor = Color.FromArgb(224, 224, 224)

        PaymentHistoryDVG.Rows.Clear()

        UpdatePaginationButtons()

        PaymentLbl.Text = "Payment History"
    End Sub

    Private Sub PaymentHistoryBtn_Click(sender As Object, e As EventArgs)
        If _selectedCustomerId = 0 Then
            MessageBox.Show("Please select a customer first.", "No Customer Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        _currentPage = 1

        LoadPaymentHistory()
        PaymentLbl.Text = "Payment History"
    End Sub

    Private Sub ServiceHistoryBtn_Click(sender As Object, e As EventArgs)
        If _selectedCustomerId = 0 Then
            MessageBox.Show("Please select a customer first.", "No Customer Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        _currentPage = 1

        LoadServiceHistoryData()
        PaymentLbl.Text = "Service History"
    End Sub

    Private Sub LoadServiceHistoryData()
        If _selectedCustomerId = 0 Then Exit Sub

        SetLoadingState(True)

        Task.Run(Sub()
                     Try
                         Using conn As New MySqlConnection(CONNECTION_STRING)
                             conn.Open()

                             ' Pagination Count
                             Dim countQuery As String = "SELECT COUNT(*) FROM service WHERE customer_id = @customerId"
                             Using countCmd As New MySqlCommand(countQuery, conn)
                                 countCmd.Parameters.AddWithValue("@customerId", _selectedCustomerId)
                                 _totalRecords = Convert.ToInt32(countCmd.ExecuteScalar())
                             End Using

                             ' Querying individual service details and their specific costs
                             Dim query As String = "
                            SELECT 
                                s.date_completed as Date,
                                s.service_cost as Amount,
                                s.service_type as Method,
                                s.status as Status,
                                CONCAT('SVC-', s.service_id) as Reference
                            FROM service s
                            WHERE s.customer_id = @customerId
                            ORDER BY s.date_completed DESC
                            LIMIT @pageSize OFFSET @offset"

                             Using cmd As New MySqlCommand(query, conn)
                                 cmd.Parameters.AddWithValue("@customerId", _selectedCustomerId)
                                 cmd.Parameters.AddWithValue("@pageSize", _pageSize)
                                 cmd.Parameters.AddWithValue("@offset", (_currentPage - 1) * _pageSize)

                                 Using adapter As New MySqlDataAdapter(cmd)
                                     Dim dt As New DataTable()
                                     adapter.Fill(dt)

                                     Me.Invoke(Sub()
                                                   PaymentHistoryDVG.Rows.Clear()

                                                   For Each row As DataRow In dt.Rows
                                                       Dim newRowIndex As Integer = PaymentHistoryDVG.Rows.Add()

                                                       ' Format Date
                                                       If Not IsDBNull(row("Date")) Then
                                                           PaymentHistoryDVG.Rows(newRowIndex).Cells("DateColumn").Value = Convert.ToDateTime(row("Date")).ToString("MM/dd/yyyy")
                                                       Else
                                                           PaymentHistoryDVG.Rows(newRowIndex).Cells("DateColumn").Value = "N/A"
                                                       End If

                                                       ' Display individual Amount per row (₱1,027.00, ₱804.99, etc.)
                                                       Dim serviceAmt As Decimal = If(IsDBNull(row("Amount")), 0, Convert.ToDecimal(row("Amount")))
                                                       PaymentHistoryDVG.Rows(newRowIndex).Cells("Amount").Value = $"₱{serviceAmt:N2}"

                                                       ' Service Type in the Method column
                                                       PaymentHistoryDVG.Rows(newRowIndex).Cells("PaymentMethod").Value = row("Method").ToString()
                                                       PaymentHistoryDVG.Rows(newRowIndex).Cells("Status").Value = row("Status").ToString()
                                                       PaymentHistoryDVG.Rows(newRowIndex).Cells("Reference").Value = row("Reference").ToString()
                                                   Next

                                                   UpdatePaginationButtons()
                                                   SetLoadingState(False)
                                               End Sub)
                                 End Using
                             End Using
                         End Using
                     Catch ex As Exception
                         Me.Invoke(Sub()
                                       SetLoadingState(False)
                                       MessageBox.Show($"Error: {ex.Message}")
                                   End Sub)
                     End Try
                 End Sub)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim totalPages As Integer = If(_totalRecords > 0, Math.Ceiling(_totalRecords / _pageSize), 1)
        If _currentPage < totalPages Then
            _currentPage += 1

        End If
    End Sub






    Private Sub DataGridServiceRequestDetails_SelectionChanged(
        sender As Object,
        e As EventArgs
    ) Handles PaymentHistoryDVG.SelectionChanged
        PaymentHistoryDVG.ClearSelection()
    End Sub


    Private Sub btnHistoryPreviousSA_Click(sender As Object, e As EventArgs) Handles btnHistoryPreviousSA.Click
        If _currentPage > 1 Then
            _currentPage -= 1

        End If
    End Sub

    Private Sub txtInstallationSearchSA_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles txtInstallationSearchSA.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            HideSearchSuggestions()

            Dim listBox As ListBox = TryCast(Me.Controls("SearchSuggestions"), ListBox)
            If listBox Is Nothing OrElse listBox.Items.Count = 0 Then Exit Sub

            Dim searchText As String = txtInstallationSearchSA.Text.Trim()

            Dim exactMatch As SearchItem =
                listBox.Items.
                Cast(Of SearchItem)().
                FirstOrDefault(Function(i)
                                   Dim namePart = i.DisplayText.Split(" - ")(0)
                                   Return namePart.Equals(searchText, StringComparison.OrdinalIgnoreCase)
                               End Function)

            If exactMatch IsNot Nothing Then
                LoadCustomerById(exactMatch.CustomerId)
                Exit Sub
            End If

            If listBox.SelectedIndex >= 0 Then
                Dim selectedItem As SearchItem = CType(listBox.SelectedItem, SearchItem)
                LoadCustomerById(selectedItem.CustomerId)
            End If
        End If

        If e.KeyCode = Keys.Escape Then
            HideSearchSuggestions()
        ElseIf e.KeyCode = Keys.Down Then
            Dim listBox As ListBox = TryCast(Me.Controls("SearchSuggestions"), ListBox)
            If listBox IsNot Nothing AndAlso listBox.Visible Then
                listBox.Focus()
                If listBox.Items.Count > 0 Then
                    listBox.SelectedIndex = 0
                End If
            End If
        End If
    End Sub
    Private Sub historyview_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        HideSearchSuggestions()
    End Sub

    Private Sub CustomerFilterPanel_Click(sender As Object, e As EventArgs) Handles CustomerFilterPanel.Click
    End Sub

    Private Sub txtInstallationSearchSA_Click(sender As Object, e As EventArgs) Handles txtInstallationSearchSA.Click
        If _searchResults IsNot Nothing AndAlso _searchResults.Rows.Count > 0 Then
            ShowSearchSuggestions(_searchResults)
        End If
    End Sub

    Private Sub PanelRound1_Paint(sender As Object, e As PaintEventArgs) Handles PanelRound1.Paint

    End Sub

    Private Sub PaymentHistoryPanel_Paint(sender As Object, e As PaintEventArgs) Handles PaymentHistoryPanel.Paint

    End Sub

    Private Sub CustomerFilterPanel_Paint(sender As Object, e As PaintEventArgs) Handles CustomerFilterPanel.Paint

    End Sub

    Private Sub PaymentHistoryDVG_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles PaymentHistoryDVG.CellFormatting

        If e.RowIndex < 0 OrElse e.Value Is Nothing OrElse IsDBNull(e.Value) Then Return

        Dim colName As String = PaymentHistoryDVG.Columns(e.ColumnIndex).Name

        If colName = "Amount" Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

        If e.ColumnIndex >= 0 Then
            Dim columnName As String = PaymentHistoryDVG.Columns(e.ColumnIndex).Name

            If columnName = "DateColumn" Then
                If e.Value IsNot Nothing AndAlso TypeOf e.Value Is Date Then
                    Dim dateValue As Date = CType(e.Value, Date)
                    e.Value = If(dateValue <> Date.MinValue, dateValue.ToString("MM/dd/yyyy"), "")
                    e.FormattingApplied = True
                End If
            End If
        End If
    End Sub

    Private Sub PaymentHistoryDVG_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles PaymentHistoryDVG.CellContentClick

    End Sub
End Class

Public Class SearchItem2
    Public Property DisplayText As String
    Public Property CustomerId As Integer

    Public Sub New(displayText As String, customerId As Integer)
        Me.DisplayText = displayText
        Me.CustomerId = customerId
    End Sub

    Public Overrides Function ToString() As String
        Return DisplayText
    End Function
End Class


