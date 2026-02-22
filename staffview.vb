Imports MySqlConnector

Public Class staffview

    Private currentPage As Integer = 1
    Private pageSize As Integer = 25
    Private totalRecords As Integer = 0
    Private totalPages As Integer = 0

    ' Add this to track selected IDs for bulk delete
    Private selectedStaffIds As New List(Of Integer)()

    Dim connString As String = "server=localhost;user=root;password=;database=sparx;Convert Zero Datetime=True;Allow Zero Datetime=True;"

    Private Sub staffview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulatePositions()
        RefreshData()
    End Sub

    Private Sub PopulatePositions()
        cbPosition.Items.Clear()
        cbPosition.Items.Add("All Staff") ' Default option

        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                ' Get unique positions from the database
                Dim cmd As New MySqlCommand("SELECT DISTINCT position FROM staff WHERE is_deleted = 0 AND position IS NOT NULL", conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim pos As String = reader.GetString(0)
                        If Not String.IsNullOrWhiteSpace(pos) Then
                            cbPosition.Items.Add(pos)
                        End If
                    End While
                End Using
            End Using
        Catch ex As Exception

            cbPosition.Items.Add("Technician")
            cbPosition.Items.Add("Customer Service")
            cbPosition.Items.Add("Inventory")
        End Try

        cbPosition.SelectedIndex = 0 ' Select "All Staff" by default
    End Sub

    Public Sub RefreshData()
        currentPage = 1 ' Reset to the first page so the new entry is visible
        GetTotalStaffCount()
        LoadStaffTable()
    End Sub

    Private Sub GetTotalStaffCount()
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                ' Filter by is_deleted = 0
                Dim cmd As New MySqlCommand("SELECT COUNT(*) FROM staff WHERE is_deleted = 0", conn)
                totalRecords = Convert.ToInt32(cmd.ExecuteScalar())

                totalPages = Math.Ceiling(totalRecords / pageSize)
                If totalPages = 0 Then totalPages = 1

                totalStaff.Text = totalRecords.ToString("D5")
            End Using
        Catch ex As Exception
            totalRecords = 0
            totalPages = 1
        End Try
    End Sub

    Public Sub LoadStaffTable()
        Try
            Using conn As New MySqlConnection(connString)
                Dim offset As Integer = (currentPage - 1) * pageSize

                ' Updated Query: Check is_deleted = 0
                Dim query As String = "SELECT staff_id, " &
                                     "CONCAT(first_name, ' ', last_name) AS 'EmployeeName', " &
                                     "DATE_FORMAT(birthdate, '%m/%d/%Y') AS 'birthdate', " &
                                     "username, department, " &
                                     "contact_number, address, " &
                                     "email_address AS 'EmailAddress', " &
                                     "CASE WHEN date_hired = '0000-00-00' OR date_hired IS NULL THEN 'N/A' " &
                                     "     ELSE DATE_FORMAT(date_hired, '%m/%d/%Y') END AS 'date_hired', " &
                                     "position, daily_rate, status " &
                                     "FROM staff " &
                                     "WHERE is_deleted = 0 " &
                                     "ORDER BY date_hired DESC, staff_id DESC " &
                                     "LIMIT @limit OFFSET @offset"

                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@limit", pageSize)
                cmd.Parameters.AddWithValue("@offset", offset)

                Dim adapter As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                DataGridStaffDetails.AutoGenerateColumns = False
                DataGridStaffDetails.DataSource = dt

                LblPageInfo.Text = String.Format("Page {0} of {1} (Total: {2})", currentPage, totalPages, totalRecords)

                btnSubscriberPreviousSA.Visible = (currentPage > 1)
                btnNext.Enabled = (currentPage < totalPages)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentPage < totalPages Then
            currentPage += 1

            ' Determine which loading method to use
            If Not String.IsNullOrWhiteSpace(txtStaffSearch.Text) Then
                PerformSearch() ' Paginated Search
            ElseIf cbPosition.SelectedIndex > 0 AndAlso cbPosition.SelectedItem.ToString() <> "All Staff" Then
                Dim pos As String = cbPosition.SelectedItem.ToString()
                If pos = "Inventory Staff" Then pos = "Inventory"
                LoadStaffTableFiltered(pos) ' Paginated Filter
            Else
                LoadStaffTable() ' Paginated Normal
            End If
        End If
    End Sub

    Private Sub btnSubscriberPreviousSA_Click(sender As Object, e As EventArgs) Handles btnSubscriberPreviousSA.Click
        If currentPage > 1 Then
            currentPage -= 1

            ' Determine which context we are in to load the correct data
            If Not String.IsNullOrWhiteSpace(txtStaffSearch.Text) Then
                PerformSearch()
            ElseIf cbPosition.SelectedIndex > 0 AndAlso cbPosition.SelectedItem.ToString() <> "All Staff" Then
                Dim pos As String = cbPosition.SelectedItem.ToString()
                If pos = "Inventory Staff" Then pos = "Inventory"
                LoadStaffTableFiltered(pos)
            Else
                LoadStaffTable()
            End If
        End If
    End Sub

    Private Sub txtStaffSearch_TextChanged(sender As Object, e As EventArgs) Handles txtStaffSearch.TextChanged
        ' Reset to page 1 every time the user types a new character
        currentPage = 1
        PerformSearch()
    End Sub

    Public Sub PerformSearch()
        Try
            If String.IsNullOrWhiteSpace(txtStaffSearch.Text) Then
                RefreshData()
                Return
            End If

            Using conn As New MySqlConnection(connString)
                conn.Open()
                Dim countQuery As String = "SELECT COUNT(*) FROM staff " &
                     "WHERE is_deleted = 0 AND status != 'Inactive' AND (" &
                     "staff_id LIKE @search " &
                     "OR CONCAT(first_name, ' ', last_name) LIKE @search " &
                     "OR address LIKE @search " &
                     "OR DATE_FORMAT(date_hired, '%m/%d/%Y') LIKE @search)"

                Dim searchCount As Integer
                Using countCmd As New MySqlCommand(countQuery, conn)
                    countCmd.Parameters.AddWithValue("@search", "%" & txtStaffSearch.Text & "%")
                    searchCount = Convert.ToInt32(countCmd.ExecuteScalar())
                End Using

                totalPages = Math.Ceiling(searchCount / pageSize)
                If totalPages = 0 Then totalPages = 1
                Dim offset As Integer = (currentPage - 1) * pageSize

                Dim query As String = "SELECT staff_id, " &
                         "CONCAT(first_name, ' ', last_name) AS 'EmployeeName', " &
                         "DATE_FORMAT(birthdate, '%m/%d/%Y') AS 'birthdate', " &
                         "username, department, " &
                         "contact_number, address, email_address AS 'EmailAddress', " &
                         "DATE_FORMAT(date_hired, '%m/%d/%Y') AS 'date_hired', " &
                         "position, daily_rate, status FROM staff " &
                         "WHERE status != 'Inactive' AND (" &
                         "staff_id LIKE @search " &
                         "OR LPAD(staff_id, 5, '0') LIKE @search " & ' Added for zero-padding search
                         "OR CONCAT(first_name, ' ', last_name) LIKE @search " &
                         "OR username LIKE @search " &
                         "OR address LIKE @search " &
                         "OR DATE_FORMAT(date_hired, '%m/%d/%Y') LIKE @search) " &
                         "ORDER BY date_hired DESC, staff_id DESC " &
                         "LIMIT @limit OFFSET @offset"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@search", "%" & txtStaffSearch.Text & "%")
                    cmd.Parameters.AddWithValue("@limit", pageSize)
                    cmd.Parameters.AddWithValue("@offset", offset)

                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    DataGridStaffDetails.DataSource = dt

                    LblPageInfo.Text = String.Format("Page {0} of {1} (Total: {2})", currentPage, totalPages.ToString("D2"), searchCount.ToString("D4"))

                    btnSubscriberPreviousSA.Visible = (currentPage > 1)
                    btnNext.Enabled = (currentPage < totalPages)
                    btnNext.Visible = True
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Search Error: " & ex.Message)
        End Try
    End Sub

    Private Sub DataGridStaffDetails_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridStaffDetails.CellFormatting
        If e.RowIndex < 0 Then Return

        ' Check if this is the Employee ID column
        ' Replace "colEmployeeID" with the actual Name of your ID column in Designer
        Dim colName As String = DataGridStaffDetails.Columns(e.ColumnIndex).Name

        If colName = "colEmployeeID" OrElse colName = "staff_id" Then
            If e.Value IsNot Nothing AndAlso IsNumeric(e.Value) Then
                e.Value = Convert.ToInt32(e.Value).ToString("D5")
                e.FormattingApplied = True
            End If
        End If
    End Sub

    Private Sub DataGridStaffDetails_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridStaffDetails.CellContentClick
        If e.RowIndex < 0 Then Return

        Dim colName As String = DataGridStaffDetails.Columns(e.ColumnIndex).Name

        If colName = "colSelect" Then
            Dim currentValue As Boolean = CBool(DataGridStaffDetails.Rows(e.RowIndex).Cells("colSelect").Value)
            DataGridStaffDetails.Rows(e.RowIndex).Cells("colSelect").Value = Not currentValue
        End If

        If colName = "colDeleteIcon" Then

            Dim idVal As Object = DataGridStaffDetails.Rows(e.RowIndex).Cells("colEmployeeID").Value
            Dim staffID As String = If(idVal Is Nothing, "", idVal.ToString())

            Dim nameVal As Object = DataGridStaffDetails.Rows(e.RowIndex).Cells("colEmployeeName").Value
            Dim employeeName As String = If(nameVal Is Nothing, "Unknown", nameVal.ToString())

            Dim result As DialogResult = MessageBox.Show($"Are you sure you want to permanently delete {employeeName} (ID: {staffID})?",
                                                  "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                DeleteStaff(staffID)
            End If

        ElseIf colName = "colEditIcon" Then

            ' Get the ID safely using the column NAME, not index 0 (safer)
            Dim idVal As Object = DataGridStaffDetails.Rows(e.RowIndex).Cells("colEmployeeID").Value
            Dim staffID As String = If(idVal Is Nothing, "", idVal.ToString())

            If String.IsNullOrEmpty(staffID) Then
                MessageBox.Show("Error: Could not retrieve Staff ID for this row.")
                Return
            End If

            Dim changePwdForm As New ChangePasswordStaff()
            changePwdForm.TargetStaffID = staffID
            changePwdForm.ShowDialog()
        End If
    End Sub

    Private Sub DeleteStaff(id As String)
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                ' --- SOFT DELETE: Set is_deleted to 1 ---
                Dim query As String = "UPDATE staff SET is_deleted = 1 WHERE staff_id = @id"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Staff member has been successfully archived.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RefreshData()
        Catch ex As Exception
            MessageBox.Show("Error deleting staff: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cbPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPosition.SelectedIndexChanged
        currentPage = 1

        Dim selectedPos As String = cbPosition.SelectedItem.ToString()

        If selectedPos = "All Staff" Then
            RefreshData()
        Else
            ' CONVERSION LOGIC: 
            ' If the UI says "Inventory Staff", tell SQL to look for "Inventory"
            If selectedPos = "Inventory Staff" Then
                selectedPos = "Inventory"
            End If

            LoadStaffTableFiltered(selectedPos)
        End If
    End Sub

    Public Sub LoadStaffTableFiltered(posToSearch As String)
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()

                Dim countQuery As String = "SELECT COUNT(*) FROM staff WHERE position = @pos AND is_deleted = 0"
                Using countCmd As New MySqlCommand(countQuery, conn)
                    countCmd.Parameters.AddWithValue("@pos", posToSearch)
                    totalRecords = Convert.ToInt32(countCmd.ExecuteScalar())
                    totalPages = Math.Ceiling(totalRecords / pageSize)
                    If totalPages = 0 Then totalPages = 1
                End Using

                Dim offset As Integer = (currentPage - 1) * pageSize
                Dim query As String = "SELECT staff_id, " &
                                     "CONCAT(first_name, ' ', last_name) AS 'EmployeeName', " &
                                     "DATE_FORMAT(birthdate, '%m/%d/%Y') AS 'birthdate', " &
                                     "username, department, " &
                                     "contact_number, address, " &
                                     "email_address AS 'EmailAddress', " &
                                     "CASE WHEN date_hired = '0000-00-00' OR date_hired IS NULL THEN 'N/A' " &
                                     "     ELSE DATE_FORMAT(date_hired, '%m/%d/%Y') END AS 'date_hired', " &
                                     "position, daily_rate, status " &
                                     "FROM staff " &
                                     "WHERE position = @pos AND is_deleted = 0 " &
                                     "ORDER BY date_hired DESC, staff_id DESC " &
                                     "LIMIT @limit OFFSET @offset"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@pos", posToSearch)
                    cmd.Parameters.AddWithValue("@limit", pageSize)
                    cmd.Parameters.AddWithValue("@offset", offset)

                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    ' Bind to DataGrid
                    DataGridStaffDetails.AutoGenerateColumns = False
                    DataGridStaffDetails.DataSource = dt

                    ' Update the UI Labels
                    totalStaff.Text = totalRecords.ToString("D5")
                    LblPageInfo.Text = String.Format("Page {0} of {1} (Total: {2})", currentPage, totalPages, totalRecords)

                    ' Manage Pagination Buttons
                    btnSubscriberPreviousSA.Visible = (currentPage > 1)
                    btnNext.Enabled = (currentPage < totalPages)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Filter Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAddStaff_Click(sender As Object, e As EventArgs) Handles btnAddStaff.Click
        ' 1. Create an instance of the Create Form
        Dim createForm As New frmStaffCreatevb()

        If createForm.ShowDialog() = DialogResult.OK Then
            ' 4. If a new staff was added, refresh the table immediately
            RefreshData()
        End If
    End Sub

    Private Sub pnlFilters_Paint(sender As Object, e As PaintEventArgs) Handles pnlFilters.Paint

    End Sub

    Private Sub deleteAll_Click(sender As Object, e As EventArgs) Handles deleteAll.Click

        If selectedStaffIds.Count = 0 Then
            MessageBox.Show("Please select at least one staff member to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete the {selectedStaffIds.Count} selected staff member(s)?",
                                                     "Confirm Bulk Delete",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                Using conn As New MySqlConnection(connString)
                    conn.Open()

                    Dim paramNames As New List(Of String)
                    For i As Integer = 0 To selectedStaffIds.Count - 1
                        paramNames.Add("@id" & i)
                    Next

                    Dim inClause As String = String.Join(",", paramNames)
                    Dim query As String = $"UPDATE staff SET is_deleted = 1 WHERE staff_id IN ({inClause})"

                    Using cmd As New MySqlCommand(query, conn)
                        For i As Integer = 0 To selectedStaffIds.Count - 1
                            cmd.Parameters.AddWithValue("@id" & i, selectedStaffIds(i))
                        Next

                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                        MessageBox.Show($"{rowsAffected} staff member(s) successfully archived.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        selectedStaffIds.Clear()
                        RefreshData()

                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error deleting records: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub DataGridStaffDetails_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridStaffDetails.CellValueChanged
        If e.RowIndex < 0 Then Return

        If DataGridStaffDetails.Columns(e.ColumnIndex).Name = "colSelect" Then
            Dim row As DataGridViewRow = DataGridStaffDetails.Rows(e.RowIndex)

            Dim idVal As Object = row.Cells("colEmployeeID").Value
            If idVal Is Nothing Then Return

            Dim id As Integer = 0
            Integer.TryParse(idVal.ToString(), id)

            Dim isChecked As Boolean = False
            If row.Cells("colSelect").Value IsNot Nothing Then
                isChecked = CBool(row.Cells("colSelect").Value)
            End If

            If isChecked Then
                If Not selectedStaffIds.Contains(id) Then selectedStaffIds.Add(id)
            Else
                selectedStaffIds.Remove(id)
            End If
        End If
    End Sub

    Private Sub DataGridStaffDetails_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridStaffDetails.CurrentCellDirtyStateChanged
        If DataGridStaffDetails.IsCurrentCellDirty Then
            DataGridStaffDetails.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub btnSelectStaff_Click(sender As Object, e As EventArgs) Handles btnSelectStaff.Click

        If DataGridStaffDetails.Rows.Count = 0 Then Exit Sub

        Dim shouldSelect As Boolean = False

        For Each row As DataGridViewRow In DataGridStaffDetails.Rows
            Dim isChecked As Boolean = False
            If row.Cells("colSelect").Value IsNot Nothing Then
                isChecked = CBool(row.Cells("colSelect").Value)
            End If

            If Not isChecked Then
                shouldSelect = True
                Exit For
            End If
        Next

        RemoveHandler DataGridStaffDetails.CellValueChanged, AddressOf DataGridStaffDetails_CellValueChanged

        selectedStaffIds.Clear()

        For Each row As DataGridViewRow In DataGridStaffDetails.Rows
            row.Cells("colSelect").Value = shouldSelect

            ' If we are selecting, add the ID to the list
            If shouldSelect Then
                Dim idVal As Object = row.Cells("colEmployeeID").Value
                If idVal IsNot Nothing Then
                    Dim id As Integer = Convert.ToInt32(idVal)
                    selectedStaffIds.Add(id)
                End If
            End If
        Next

        AddHandler DataGridStaffDetails.CellValueChanged, AddressOf DataGridStaffDetails_CellValueChanged

    End Sub
End Class