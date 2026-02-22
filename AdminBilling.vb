Imports System.ComponentModel
Imports System.Configuration
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Printing
Imports MySqlConnector

Public Class AdminBilling
    Inherits System.Windows.Forms.UserControl

    Private ReadOnly CONNECTION_STRING As String = "Server=127.0.0.1;Port=3306;Database=sparx;User ID=root;Password=;SslMode=Preferred;"

    Private Const PAGE_SIZE As Integer = 25
    Private currentPageIndex As Integer = 0
    Private totalRecords As Integer = 0
    Private selectedPaymentIDs As New List(Of Integer)()

    Private ReadOnly searchTimer As New Timer() With {.Interval = 500}

    Public Property IsReadOnly As Boolean = False

    Private Sub billingview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BillingDetailsDGV.AutoGenerateColumns = False

        PopulateDropdowns()

        AddHandler searchTimer.Tick, Sub(s, args)
                                         searchTimer.Stop()
                                         currentPageIndex = 0
                                         LoadPaymentGrid()
                                         LoadSummaryData()
                                     End Sub

        ' Load all data
        LoadAllData()

        If IsReadOnly = True Then
            If btnAddBilling IsNot Nothing Then btnAddBilling.Visible = False

            If btnExport IsNot Nothing Then btnExport.Visible = False
        End If
    End Sub



    Private Sub LoadAllData()
        Try
            LoadSummaryData()
            LoadPaymentGrid()
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub LoadSummaryData()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim dateFilter As String = ""
                Dim pDateCol As String = "p.date_of_payment"

                ' Defensive checks — some combobox controls can be Nothing in designer renames
                If ComboBoxDate IsNot Nothing AndAlso ComboBoxDate.SelectedIndex > 0 Then
                    Dim selectedMonth As String = ComboBoxDate.SelectedItem.ToString()
                    Select Case selectedMonth
                        Case "January" : dateFilter = $" AND MONTH({pDateCol}) = 1"
                        Case "February" : dateFilter = $" AND MONTH({pDateCol}) = 2"
                        Case "March" : dateFilter = $" AND MONTH({pDateCol}) = 3"
                        Case "April" : dateFilter = $" AND MONTH({pDateCol}) = 4"
                        Case "May" : dateFilter = $" AND MONTH({pDateCol}) = 5"
                        Case "June" : dateFilter = $" AND MONTH({pDateCol}) = 6"
                        Case "July" : dateFilter = $" AND MONTH({pDateCol}) = 7"
                        Case "August" : dateFilter = $" AND MONTH({pDateCol}) = 8"
                        Case "September" : dateFilter = $" AND MONTH({pDateCol}) = 9"
                        Case "October" : dateFilter = $" AND MONTH({pDateCol}) = 10"
                        Case "November" : dateFilter = $" AND MONTH({pDateCol}) = 11"
                        Case "December" : dateFilter = $" AND MONTH({pDateCol}) = 12"
                    End Select
                End If

                Dim typeFilter As String = ""
                If CBBillingType IsNot Nothing AndAlso CBBillingType.SelectedIndex > 0 Then
                    Dim selectedType As String = CBBillingType.SelectedItem.ToString()
                    If selectedType = "Plan Type" Then
                        typeFilter = " AND p.billing_type = 'plan_type'"
                    ElseIf selectedType = "Service Type" Then
                        typeFilter = " AND p.billing_type = 'service_type'"
                    End If
                End If

                Dim totalReceivedQuery As String = "SELECT SUM(" &
                            "CASE WHEN p.billing_type = 'plan_type' THEN c.monthly_rate ELSE s.service_cost END" &
                            ") FROM payment p " &
                            "LEFT JOIN service s ON p.service_id = s.service_id " &
                            "LEFT JOIN customer c ON p.customer_id = c.customer_id " &
                            "WHERE p.date_of_payment IS NOT NULL" & dateFilter & typeFilter
                Using cmd As New MySqlCommand(totalReceivedQuery, conn)
                    Dim totalReceived As Decimal = Convert.ToDecimal(cmd.ExecuteScalar())
                    AmoundReceivedLbl.Text = "₱" & totalReceived.ToString("N2")
                End Using

                Dim totalExpectedQuery As String = "SELECT COALESCE(SUM(monthly_rate), 0) FROM customer WHERE account_status = 'Active'"
                Using cmd As New MySqlCommand(totalExpectedQuery, conn)
                    Dim totalExpected As Decimal = Convert.ToDecimal(cmd.ExecuteScalar())
                    AmountExpectedLbl.Text = "₱" & totalExpected.ToString("N2")
                End Using

                Dim expectedVal As Decimal = 0
                Dim receivedVal As Decimal = 0
                Decimal.TryParse(AmountExpectedLbl.Text.Replace("₱", "").Replace(",", ""), expectedVal)
                Decimal.TryParse(AmoundReceivedLbl.Text.Replace("₱", "").Replace(",", ""), receivedVal)

                Dim outstanding As Decimal = expectedVal - receivedVal
                AmountOutstandingLbl.Text = "₱" & outstanding.ToString("N2")

                Dim paidBillsQuery As String = "SELECT COUNT(*) FROM payment p WHERE p.date_of_payment IS NOT NULL" & dateFilter & typeFilter
                Using cmd As New MySqlCommand(paidBillsQuery, conn)
                    Dim paidCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    NumPaidLbl.Text = paidCount.ToString("N0")
                End Using

                Dim unpaidBillsQuery As String = "SELECT COUNT(*) FROM payment p WHERE p.date_of_payment IS NULL" & typeFilter
                Using cmd As New MySqlCommand(unpaidBillsQuery, conn)
                    Dim unpaidCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    NumUnpaidLbl.Text = unpaidCount.ToString("N0")
                End Using



                ' 7. PERCENTAGES
                If expectedVal > 0 Then
                    Dim collectionRate As Decimal = (receivedVal / expectedVal) * 100
                    CollectionPercentLbl.Text = collectionRate.ToString("N1") & "%"
                    DefaultPercentLbl.Text = (100 - collectionRate).ToString("N1") & "%"
                Else
                    CollectionPercentLbl.Text = "0.0%"
                    DefaultPercentLbl.Text = "0.0%"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading summary data: " & ex.Message, "Summary Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub


    Private Sub UpdatePaginationControls()
        ' Ensure float division to compute pages correctly and handle zero records
        Dim totalPages As Integer = If(totalRecords > 0, CInt(Math.Ceiling(totalRecords / CDbl(PAGE_SIZE))), 0)
        btnBillingPreviousSA.Enabled = currentPageIndex > 0
        btnBillingPreviousSA.Visible = currentPageIndex > 0
        btnNext.Enabled = (totalPages > 0) AndAlso (currentPageIndex < totalPages - 1)
        If Me.Controls.Find("lblPageInfo", True).Length > 0 Then
            Dim lblPageInfo As Label = CType(Me.Controls.Find("lblPageInfo", True)(0), Label)
            If totalRecords > 0 Then
                lblPageInfo.Text = $"Page {currentPageIndex + 1} of {totalPages} (Total: {totalRecords})"
            Else
                lblPageInfo.Text = "No Records Found"
            End If
        End If
    End Sub
    Private Sub LoadPaymentGrid()
        Try
            BillingDetailsDGV.Rows.Clear()

            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                ' Get search text
                Dim searchText As String = txtBillingSearchSA.Text.Trim()

                ' 1. Get total records for pagination
                Dim countQuery As String = BuildPaymentQuery(True)
                Using cmdCount As New MySqlCommand(countQuery, conn)
                    ' Add parameter if search text exists
                    If Not String.IsNullOrWhiteSpace(searchText) Then
                        cmdCount.Parameters.AddWithValue("@search", "%" & searchText & "%")
                    End If
                    totalRecords = Convert.ToInt32(cmdCount.ExecuteScalar())
                End Using

                ' 2. Get paginated data
                Dim offset As Integer = currentPageIndex * PAGE_SIZE
                Dim query As String = BuildPaymentQuery(False) & " LIMIT @Limit OFFSET @Offset"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Limit", PAGE_SIZE)
                    cmd.Parameters.AddWithValue("@Offset", offset)

                    ' Add parameter if search text exists
                    If Not String.IsNullOrWhiteSpace(searchText) Then
                        cmd.Parameters.AddWithValue("@search", "%" & searchText & "%")
                    End If

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim rowIndex As Integer = BillingDetailsDGV.Rows.Add()
                            Dim row As DataGridViewRow = BillingDetailsDGV.Rows(rowIndex)
                            row.Height = 40

                            ' --- ROW DATA POPULATION (Same as your existing code) ---
                            Dim rawBillingType As String = reader("BillingType").ToString()
                            Dim formattedBillingType As String = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(rawBillingType.Replace("_", " ").ToLower())
                            row.Cells("colBillingType").Value = formattedBillingType

                            If formattedBillingType = "Plan Type" Then
                                row.Cells("colServiceType").Value = "N/A"
                            Else
                                row.Cells("colServiceType").Value = If(IsDBNull(reader("ServiceType")), "N/A", reader("ServiceType").ToString())
                            End If

                            Dim rawPlanType As String = reader("PlanType").ToString()
                            row.Cells("PlanType").Value = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(rawPlanType.Replace("_", " ").ToLower())

                            Dim rawMethod As String = If(IsDBNull(reader("ModeOfPayment")), "", reader("ModeOfPayment").ToString())
                            Dim formattedMethod As String = ""
                            Select Case rawMethod.ToLower()
                                Case "gcash" : formattedMethod = "Gcash"
                                Case "walk-in" : formattedMethod = "Walk-in"
                                Case "n/a", "", "none" : formattedMethod = "N/A"
                                Case Else : formattedMethod = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(rawMethod.Replace("_", " ").ToLower())
                            End Select
                            row.Cells("ModeOfPayment").Value = formattedMethod

                            row.Cells("PaymentID").Value = reader("PaymentID")
                            row.Cells("CustomerName").Value = reader("CustomerName")

                            Dim mRate As Decimal = If(IsDBNull(reader("MonthlyRate")), 0, Convert.ToDecimal(reader("MonthlyRate")))
                            row.Cells("MonthlyRate").Value = "₱" & mRate.ToString("N2")

                            row.Cells("colBillingStart").Value = reader("BillingStart")
                            row.Cells("colBillingEnd").Value = reader("BillingEnd")

                            Dim aPaid As Decimal = If(IsDBNull(reader("AmountPaid")), 0, Convert.ToDecimal(reader("AmountPaid")))
                            row.Cells("AmountPaid").Value = "₱" & aPaid.ToString("N2")

                            Dim realCost As Decimal = If(IsDBNull(reader("ActualCost")), 0, Convert.ToDecimal(reader("ActualCost")))
                            row.Tag = realCost

                            row.Cells("PaymentDate").Value = reader("PaymentDate")
                            row.Cells("Status").Value = reader("Status")
                        End While
                    End Using
                End Using
            End Using

            UpdatePaginationControls()

            If IsReadOnly = True Then

                If BillingDetailsDGV.Columns.Contains("paidBtn") Then
                    BillingDetailsDGV.Columns("paidBtn").Visible = False
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading payments: " & ex.Message)
        End Try
    End Sub

    Private Function BuildPaymentQuery(isCount As Boolean) As String
        Dim selectClause As String
        Dim fromClause As String = " FROM payment p " &
                               "LEFT JOIN customer c ON p.customer_id = c.customer_id " &
                               "LEFT JOIN service s ON p.service_id = s.service_id"

        If isCount Then
            selectClause = "SELECT COUNT(*)"
        Else
            selectClause = "SELECT " &
                       "p.payment_id AS PaymentID, " &
                       "CONCAT(c.first_name, ' ', c.last_name) AS CustomerName, " &
                       "p.billing_type AS BillingType, " &
                       "c.plan_type AS PlanType, " &
                       "c.monthly_rate AS MonthlyRate, " &
                       "c.date_installed AS BillingStart, " &
                       "DATE_ADD(c.date_installed, INTERVAL 1 MONTH) AS BillingEnd, " &
                       "s.service_type AS ServiceType, " &
                       "CASE " &
                       "    WHEN p.date_of_payment IS NOT NULL THEN " &
                       "        CASE WHEN p.billing_type LIKE 'plan%' THEN c.monthly_rate ELSE s.service_cost END " &
                       "    ELSE 0 " &
                       "END AS AmountPaid, " &
                       "CASE " &
                       "    WHEN p.billing_type LIKE 'plan%' THEN c.monthly_rate " &
                       "    ELSE s.service_cost " &
                       "END AS ActualCost, " &
                       "p.date_of_payment AS PaymentDate, " &
                       "CASE WHEN p.date_of_payment IS NOT NULL THEN 'Paid' ELSE 'Unpaid' END AS Status, " &
                       "CASE WHEN p.date_of_payment IS NOT NULL THEN COALESCE(p.payment_method, 'N/A') ELSE '' END AS ModeOfPayment"
        End If

        Dim whereConditions As New List(Of String)
        whereConditions.Add("1=1") ' Base condition

        ' --- 1. SEARCH LOGIC (Updated for MM/dd/yyyy format) ---
        Dim searchText As String = txtBillingSearchSA.Text.Trim()

        If Not String.IsNullOrWhiteSpace(searchText) Then
            ' Note the change to '%m/%d/%Y' to match your preferred format
            Dim searchCondition As String = "(" &
            "p.payment_id LIKE @search OR " &
            "CONCAT(c.first_name, ' ', c.last_name) LIKE @search OR " &
            "DATE_FORMAT(c.date_installed, '%m/%d/%Y') LIKE @search OR " &
            "DATE_FORMAT(DATE_ADD(c.date_installed, INTERVAL 1 MONTH), '%m/%d/%Y') LIKE @search OR " &
            "DATE_FORMAT(p.date_of_payment, '%m/%d/%Y') LIKE @search" &
            ")"
            whereConditions.Add(searchCondition)
        End If

        ' --- 2. Existing Filters ---
        If ComboBoxStat.SelectedIndex > 0 Then
            Dim status As String = ComboBoxStat.SelectedItem.ToString()
            If status = "Paid" Then
                whereConditions.Add("p.date_of_payment IS NOT NULL")
            ElseIf status = "Unpaid" Then
                whereConditions.Add("p.date_of_payment IS NULL")
            End If
        End If

        If ComboBoxDate.SelectedIndex > 0 Then
            whereConditions.Add($"MONTH(p.date_of_payment) = {ComboBoxDate.SelectedIndex}")
        End If

        If CBBillingType.SelectedIndex > 0 Then
            Dim selectedType As String = CBBillingType.SelectedItem.ToString()
            If selectedType = "Plan Type" Then
                whereConditions.Add("p.billing_type = 'plan_type'")
            ElseIf selectedType = "Service Type" Then
                whereConditions.Add("p.billing_type = 'service_type'")
            End If
        End If

        Dim whereClause As String = " WHERE " & String.Join(" AND ", whereConditions)

        If isCount Then
            Return selectClause & fromClause & whereClause
        Else
            Return selectClause & fromClause & whereClause & " ORDER BY p.date_of_payment DESC, p.payment_id DESC"
        End If
    End Function


    Private Sub BillingDetailsDGV_SelectionChanged(sender As Object, e As EventArgs) Handles BillingDetailsDGV.SelectionChanged
        BillingDetailsDGV.ClearSelection()
    End Sub

    Private Sub SetCellValue(row As DataGridViewRow, colName As String, value As Object)
        If BillingDetailsDGV.Columns.Contains(colName) Then
            row.Cells(colName).Value = If(IsDBNull(value), "", value)
        End If
    End Sub

    Private Sub PopulateDropdowns()

        Me.ComboBoxDate.Items.Clear()
        Me.ComboBoxDate.Items.Add("All Time")
        Me.ComboBoxDate.Items.AddRange(New String() {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        })
        Me.ComboBoxDate.SelectedIndex = 0

        Me.ComboBoxStat.Items.Clear()
        Me.ComboBoxStat.Items.Add("All Status")
        Me.ComboBoxStat.Items.AddRange(New String() {"Paid", "Unpaid"})
        Me.ComboBoxStat.SelectedIndex = 0

        Me.CBBillingType.Items.Clear()
        Me.CBBillingType.Items.Add("All Type")
        Me.CBBillingType.Items.AddRange(New String() {"Plan Type", "Service Type"})
        Me.CBBillingType.SelectedIndex = 0
    End Sub

    Private Sub ComboBoxStat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxStat.SelectedIndexChanged
        currentPageIndex = 0
        LoadPaymentGrid()
        LoadSummaryData()
    End Sub

    Private Sub ComboBoxDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDate.SelectedIndexChanged
        currentPageIndex = 0
        LoadPaymentGrid()
        LoadSummaryData()
    End Sub

    Private Sub txtBillingSearchSA_TextChanged(sender As Object, e As EventArgs) Handles txtBillingSearchSA.TextChanged

        searchTimer.Stop()
        searchTimer.Start()
    End Sub

    Private Sub btnAddBilling_Click(sender As Object, e As EventArgs) Handles btnAddBilling.Click
        Using frmCreate As New frmBillingCreate()
            ' Show the form as a dialog
            Dim result As DialogResult = frmCreate.ShowDialog()

            ' Check if service was created successfully
            If result = DialogResult.OK Then
                ' Force refresh all data - this will clear the grid and reload from database

                ' Show success message
                MessageBox.Show("Service created successfully! The new service will appear at the top of the list.",
                              "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    Private Sub btnSelectBilling_Click(sender As Object, e As EventArgs)
        ' 1. Determine state (Select All or Deselect All) based on current visible rows
        Dim shouldSelect = False

        ' Check visible rows (limited by pagination)
        For Each row As DataGridViewRow In BillingDetailsDGV.Rows
            If Not row.IsNewRow Then
                Dim isChecked = False
                If row.Cells("checkbox").Value IsNot Nothing Then
                    isChecked = CBool(row.Cells("checkbox").Value)
                End If

                ' If even one is unchecked, we switch mode to "Select All"
                If Not isChecked Then
                    shouldSelect = True
                    Exit For
                End If
            End If
        Next

        ' 2. Pause events to prevent lag
        RemoveHandler BillingDetailsDGV.CellValueChanged, AddressOf BillingDetailsDGV_CellValueChanged

        ' 3. Apply changes
        selectedPaymentIDs.Clear() ' Reset list for current view to avoid duplicates

        For Each row As DataGridViewRow In BillingDetailsDGV.Rows
            If Not row.IsNewRow Then
                ' Update Visual
                row.Cells("checkbox").Value = shouldSelect

                ' Update List
                If shouldSelect Then
                    Dim id = Convert.ToInt32(row.Cells("PaymentID").Value)
                    selectedPaymentIDs.Add(id)
                End If
            End If
        Next

        ' 4. Resume events
        AddHandler BillingDetailsDGV.CellValueChanged, AddressOf BillingDetailsDGV_CellValueChanged

        UpdateSelectionUI()
    End Sub

    Private Sub EditPayment(paymentId As String)
        MessageBox.Show($"Would edit payment ID: {paymentId}", "Edit Payment", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub DeletePayment(paymentId As String)
        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete payment ID: {paymentId}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            Try
                Using conn As New MySqlConnection(CONNECTION_STRING)
                    conn.Open()
                    Dim deleteQuery As String = "DELETE FROM payment WHERE payment_id = @paymentId"
                    Using cmd As New MySqlCommand(deleteQuery, conn)
                        cmd.Parameters.AddWithValue("@paymentId", paymentId)
                        cmd.ExecuteNonQuery()
                        MessageBox.Show($"Payment ID {paymentId} deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadAllData()
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error deleting payment: " & ex.Message, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub BillingDetailsDGV_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles BillingDetailsDGV.ColumnHeaderMouseClick
        If e.ColumnIndex >= 0 AndAlso BillingDetailsDGV.Columns(e.ColumnIndex).Name = "colCheckBox" Then
            btnSelectBilling_Click(sender, e)
        End If

    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim totalPages As Integer = CInt(Math.Ceiling(totalRecords / PAGE_SIZE))
        If currentPageIndex < totalPages - 1 Then
            currentPageIndex += 1
            LoadPaymentGrid()
        End If
    End Sub

    Private Sub btnBillingPreviousSA_Click(sender As Object, e As EventArgs) Handles btnBillingPreviousSA.Click
        If currentPageIndex > 0 Then
            currentPageIndex -= 1
            LoadPaymentGrid()
        End If
    End Sub

    Private Sub InventoryFilterPanel_Paint(sender As Object, e As PaintEventArgs) Handles InventoryFilterPanel.Paint

    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim exportForm As New SABillingExport()
        exportForm.ShowDialog()
    End Sub

    Private Sub DateRangeLbl_Click(sender As Object, e As EventArgs) Handles DateRangeLbl.Click

    End Sub

    Private Sub BillingDetailsDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles BillingDetailsDGV.CellClick
        Dim columnName As String = BillingDetailsDGV.Columns(e.ColumnIndex).Name
        If columnName = "checkbox" Then
            Dim currentValue As Boolean = CBool(BillingDetailsDGV.Rows(e.RowIndex).Cells("checkbox").Value)
            BillingDetailsDGV.Rows(e.RowIndex).Cells("checkbox").Value = Not currentValue
        End If
    End Sub

    Private Sub BillingDetailsDGV_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles BillingDetailsDGV.CellValueChanged
        ' Ignore header clicks or initialization
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim columnName As String = BillingDetailsDGV.Columns(e.ColumnIndex).Name

        ' Update this to match the actual name of your checkbox column ("colCheckBox")
        If columnName = "colCheckBox" Then
            Dim row As DataGridViewRow = BillingDetailsDGV.Rows(e.RowIndex)
            Dim paymentId As Integer = Convert.ToInt32(row.Cells("PaymentID").Value)
            Dim isChecked As Boolean = If(row.Cells("colCheckBox").Value IsNot Nothing, CBool(row.Cells("colCheckBox").Value), False)

            If isChecked Then
                If Not selectedPaymentIDs.Contains(paymentId) Then
                    selectedPaymentIDs.Add(paymentId)
                End If
            Else
                selectedPaymentIDs.Remove(paymentId)
            End If

            UpdateSelectionUI()
        End If
    End Sub

    Private Sub UpdateSelectionUI()
        If selectedPaymentIDs.Count > 0 Then
            ' You can add visual feedback here
            ' For example, change the select all button icon
            ' btnSelectInstallation.Image = My.Resources.Resources.selectall_active
        Else
            ' btnSelectInstallation.Image = My.Resources.Resources.selectall
        End If
    End Sub

    Private Sub BillingDetailsDGV_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles BillingDetailsDGV.CellFormatting
        ' 1. Ensure we are checking a valid row
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim colName As String = BillingDetailsDGV.Columns(e.ColumnIndex).Name
        Dim row As DataGridViewRow = BillingDetailsDGV.Rows(e.RowIndex)
        Dim status As String = If(row.Cells("Status").Value IsNot Nothing, row.Cells("Status").Value.ToString(), "")

        ' --- A. Standard Text Alignment (Existing Logic) ---
        If colName = "MonthlyRate" OrElse colName = "AmountPaid" Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Else
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If

        ' --- B. Format Dates (Existing Logic) ---
        If colName = "colBillingStart" OrElse colName = "colBillingEnd" OrElse colName = "PaymentDate" Then
            If e.Value IsNot Nothing AndAlso TypeOf e.Value Is Date Then
                Dim dateValue As Date = CType(e.Value, Date)
                e.Value = If(dateValue <> Date.MinValue, dateValue.ToString("MM/dd/yyyy"), "")
                e.FormattingApplied = True
            End If
        End If

        ' --- C. BUTTON COLOR LOGIC (New) ---
        ' Make sure "paidBtn" matches the actual Name of your button column in the designer
        If colName = "paidBtn" Then
            If status = "Paid" Then
                e.CellStyle.BackColor = Color.LightGreen
                e.CellStyle.ForeColor = Color.White
                e.CellStyle.SelectionBackColor = Color.LightGreen
                e.CellStyle.SelectionForeColor = Color.White
                e.Value = "Paid"
            Else
                e.CellStyle.BackColor = Color.Red
                e.CellStyle.ForeColor = Color.White
                e.CellStyle.SelectionBackColor = Color.DarkOrange
                e.CellStyle.SelectionForeColor = Color.White
                e.Value = "Unpaid"
            End If
        End If
    End Sub

    Private Sub BillingDetailsDGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles BillingDetailsDGV.CellContentClick

        If IsReadOnly = True Then
            ' Prevent any action if clicking restricted columns
            Dim colName As String = BillingDetailsDGV.Columns(e.ColumnIndex).Name
            If colName = "paidBtn" Then
                Exit Sub
            End If
        End If

        ' Ensure we clicked the "paidBtn" column
        If e.RowIndex >= 0 AndAlso BillingDetailsDGV.Columns(e.ColumnIndex).Name = "paidBtn" Then

            Dim row As DataGridViewRow = BillingDetailsDGV.Rows(e.RowIndex)
            Dim currentStatus As String = row.Cells("Status").Value.ToString()

            ' 1. Check if already paid
            If currentStatus = "Paid" Then
                MessageBox.Show("This record is already marked as Paid.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' 2. Instantiate the Payment Form
            Dim payForm As New paymentMethod()

            ' 3. Pass data from the Grid to the Form Properties
            payForm.PayID = Convert.ToInt32(row.Cells("PaymentID").Value)
            payForm.CustName = row.Cells("CustomerName").Value.ToString()
            payForm.PlanType = row.Cells("PlanType").Value.ToString()

            ' Handle Currency formatting (remove ₱ for cleaner display if needed, or keep it)
            payForm.MonthlyRate = row.Cells("MonthlyRate").Value.ToString()
            Dim costToPay As Decimal = Convert.ToDecimal(row.Tag)
            payForm.AmountToPay = "₱" & costToPay.ToString("N2")
            payForm.BillStatus = currentStatus
            payForm.PaymentDate = If(row.Cells("PaymentDate").Value IsNot Nothing, row.Cells("PaymentDate").Value.ToString(), "")
            payForm.PaymentMethod = If(row.Cells("ModeOfPayment").Value IsNot Nothing, row.Cells("ModeOfPayment").Value.ToString(), "Walk-in")

            ' 4. Show the form as a Dialog and wait for result
            If payForm.ShowDialog() = DialogResult.OK Then
                ' If payment was successful (DialogResult.OK), refresh the grid
                currentPageIndex = 0
                LoadAllData()
            End If

        End If
    End Sub

    Private Sub MarkPaymentAsPaid(paymentId As Integer)
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                ' Update the date_of_payment to current time. 
                ' You can also set a default payment method (e.g., 'Walk-in') if needed.
                Dim query As String = "UPDATE payment SET date_of_payment = NOW(), payment_method = 'Walk-in' WHERE payment_id = @id"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", paymentId)

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Payment marked as successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Refresh the grid and summary to show changes immediately
                        currentPageIndex = 0
                        LoadAllData()
                    Else
                        MessageBox.Show("Record not found or update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating payment: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub deleteAll_Click(sender As Object, e As EventArgs)
        ' 1. Check if selection exists
        If selectedPaymentIDs.Count = 0 Then
            MessageBox.Show("Please select at least one payment record to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' 2. Confirm Action
        Dim result = MessageBox.Show($"Are you sure you want to delete the {selectedPaymentIDs.Count} selected payment record(s)?" & vbCrLf & "This action cannot be undone.",
                                                     "Confirm Bulk Delete",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                Using conn As New MySqlConnection(CONNECTION_STRING)
                    conn.Open()

                    ' 3. Build Safe Parameterized Query
                    ' Creates: DELETE FROM payment WHERE payment_id IN (@id0, @id1, ...)
                    Dim paramNames As New List(Of String)
                    For i = 0 To selectedPaymentIDs.Count - 1
                        paramNames.Add("@id" & i)
                    Next

                    Dim query = $"DELETE FROM payment WHERE payment_id IN ({String.Join(",", paramNames)})"

                    Using cmd As New MySqlCommand(query, conn)
                        ' 4. Add Parameters
                        For i = 0 To selectedPaymentIDs.Count - 1
                            cmd.Parameters.AddWithValue("@id" & i, selectedPaymentIDs(i))
                        Next

                        ' 5. Execute
                        Dim rowsAffected = cmd.ExecuteNonQuery
                        MessageBox.Show($"{rowsAffected} payment(s) deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' 6. Reset & Refresh
                        selectedPaymentIDs.Clear()

                        ' Reload Grid and Summaries
                        LoadAllData() ' This calls LoadSummaryData and LoadPaymentGrid

                        ' Update UI
                        UpdateSelectionUI()
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error deleting records: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub CBBillingType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBBillingType.SelectedIndexChanged
        currentPageIndex = 0 ' Reset to first page
        LoadPaymentGrid()
        ' Optional: LoadSummaryData() if you want the totals at the top to filter too
        LoadSummaryData()
    End Sub

End Class