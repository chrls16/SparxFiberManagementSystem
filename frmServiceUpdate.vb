Imports System.Configuration
Imports MySqlConnector
Imports System.Collections.Generic

Public Class frmServiceUpdate
    ' --- Variables ---
    Private _connectionString As String = Nothing
    Private _serviceId As Integer = 0
    Private _originalData As DataRow = Nothing

    ' Dictionary to map "John Doe" back to ID "12"
    Private _technicianMap As New Dictionary(Of String, Integer)

    ' Variables for form dragging
    Private mouseOffset As Point
    Private isMouseDown As Boolean = False

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

    ' Public property to set the service ID from the main form
    Public Property SelectedServiceID As Integer
        Get
            Return _serviceId
        End Get
        Set(value As Integer)
            _serviceId = value
        End Set
    End Property

    Private Sub frmServiceUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Center the form on the screen
        Me.CenterToScreen()

        If String.IsNullOrEmpty(CONNECTION_STRING) Then
            MessageBox.Show("Database connection not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Return
        End If

        If _serviceId = 0 Then
            MessageBox.Show("No service selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Return
        End If

        LoadDropdowns()
        LoadTechnicians() ' Load AutoComplete data (Name only)
        LoadServiceData() ' Load current record

        ' Make form draggable by the title area (LblUpdate)
        AddHandler LblUpdate.MouseDown, AddressOf TitleBar_MouseDown
        AddHandler LblUpdate.MouseMove, AddressOf TitleBar_MouseMove
        AddHandler LblUpdate.MouseUp, AddressOf TitleBar_MouseUp
    End Sub

    ' ============================================
    ' DRAGGABLE FORM IMPLEMENTATION
    ' ============================================
    Private Sub TitleBar_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            mouseOffset = New Point(-e.X, -e.Y)
            isMouseDown = True
        End If
    End Sub

    Private Sub TitleBar_MouseMove(sender As Object, e As MouseEventArgs)
        If isMouseDown Then
            Dim mousePos As Point = Control.MousePosition
            mousePos.Offset(mouseOffset.X, mouseOffset.Y)
            Location = mousePos
        End If
    End Sub

    Private Sub TitleBar_MouseUp(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            isMouseDown = False
        End If
    End Sub

    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs) Handles btnCancel.MouseDown, btnUpdate.MouseDown
        If e.Button = MouseButtons.Left Then
            mouseOffset = New Point(-e.X - (sender.Left - Me.Left), -e.Y - (sender.Top - Me.Top))
            isMouseDown = True
        End If
    End Sub

    ' ============================================
    ' DATA LOADING & SETUP
    ' ============================================

    Private Sub LoadDropdowns()
        ' Load Service Types
        DropDownServiceType.Items.Clear()
        DropDownServiceType.Items.Add("Installation")
        DropDownServiceType.Items.Add("Repair")
        DropDownServiceType.Items.Add("Relocation")

        ' Load Status Options
        cbStatus.Items.Clear()
        cbStatus.Items.Add("Requested")
        cbStatus.Items.Add("In Progress")
        cbStatus.Items.Add("Completed")
        cbStatus.Items.Add("Cancelled")
    End Sub

    ' --- CONCATENATED TECHNICIAN LOADING (NAME ONLY) ---
    Private Sub LoadTechnicians()
        If String.IsNullOrEmpty(CONNECTION_STRING) Then Return

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                ' UPDATED QUERY: Removed ID from display_name. Only First + Last Name.
                Dim query As String = "SELECT staff_id, CONCAT(first_name, ' ', last_name) AS display_name " &
                                      "FROM staff WHERE position = 'Technician' ORDER BY last_name, first_name"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        _technicianMap.Clear()
                        Dim autoComplete As New AutoCompleteStringCollection()

                        While reader.Read()
                            Dim id As Integer = reader.GetInt32("staff_id")
                            Dim name As String = reader.GetString("display_name")

                            ' Store in dictionary (Name -> ID)
                            ' Note: If two technicians have the exact same name, the last one loaded will persist.
                            If Not _technicianMap.ContainsKey(name) Then
                                _technicianMap.Add(name, id)
                                autoComplete.Add(name)
                            End If
                        End While

                        ' Configure TextBox for AutoComplete
                        txtTechSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                        txtTechSearch.AutoCompleteSource = AutoCompleteSource.CustomSource
                        txtTechSearch.AutoCompleteCustomSource = autoComplete
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error loading technicians: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadServiceData()
        If String.IsNullOrEmpty(CONNECTION_STRING) Or _serviceId = 0 Then Return

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Dim query As String = "
                    SELECT 
                        s.service_id,
                        CONCAT(c.first_name, ' ', c.last_name) AS customer_name,
                        c.installation_address,
                        s.service_type,
                        s.date_requested,
                        s.date_completed,
                        s.service_cost,
                        CONCAT(st.first_name, ' ', st.last_name) AS technician_name,
                        st.staff_id,
                        s.status,
                        s.technician_notes,
                        s.service_description
                    FROM service s
                    LEFT JOIN customer c ON s.customer_id = c.customer_id
                    LEFT JOIN staff st ON s.staff_id = st.staff_id
                    WHERE s.service_id = @serviceId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@serviceId", _serviceId)

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        If dt.Rows.Count > 0 Then
                            _originalData = dt.Rows(0)
                            DisplayServiceData(dt.Rows(0))
                        Else
                            MessageBox.Show("Service record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.Close()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading service data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisplayServiceData(row As DataRow)
        ' Display read-only fields
        txtServuceID.Text = row("service_id").ToString()
        txtCustomer.Text = If(IsDBNull(row("customer_name")), "", row("customer_name").ToString())
        TxtBoxAddress.Text = If(IsDBNull(row("installation_address")), "", row("installation_address").ToString())
        txtServiceFee.Text = If(IsDBNull(row("service_cost")), "0", Convert.ToDecimal(row("service_cost")).ToString("N2"))

        ' Dropdowns
        If Not IsDBNull(row("service_type")) Then
            DropDownServiceType.SelectedItem = row("service_type").ToString()
        End If

        If Not IsDBNull(row("date_requested")) Then
            DateTimePicker1.Value = Convert.ToDateTime(row("date_requested"))
        End If

        If Not IsDBNull(row("status")) Then
            cbStatus.SelectedItem = row("status").ToString()
        End If

        ' --- SERVICE NOTES ---
        If Not IsDBNull(row("technician_notes")) Then
            txtServiceNotes.Text = row("technician_notes").ToString()
        Else
            txtServiceNotes.Text = ""
        End If

        ' --- TECHNICIAN (Name Only) ---
        If Not IsDBNull(row("staff_id")) AndAlso Not IsDBNull(row("technician_name")) Then
            ' Just show the name directly
            txtTechSearch.Text = row("technician_name").ToString()
        Else
            txtTechSearch.Text = ""
        End If

        ' Enable fields
        txtServiceFee.Enabled = True
        DropDownServiceType.Enabled = True
        DateTimePicker1.Enabled = True
        cbStatus.Enabled = True
        txtServiceNotes.Enabled = True
        txtTechSearch.Enabled = True
    End Sub

    ' ============================================
    ' SAVING & VALIDATION
    ' ============================================

    Private Function ValidateForm() As Boolean
        If DropDownServiceType.SelectedIndex = -1 Then
            MessageBox.Show("Please select a service type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            DropDownServiceType.Focus()
            Return False
        End If

        If cbStatus.SelectedIndex = -1 Then
            MessageBox.Show("Please select a status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cbStatus.Focus()
            Return False
        End If

        Dim fee As Decimal
        If Not Decimal.TryParse(txtServiceFee.Text, fee) OrElse fee < 0 Then
            MessageBox.Show("Please enter a valid service fee (positive number).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtServiceFee.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If Not ValidateForm() Then Return

        ' --- VALIDATE TECHNICIAN FROM TEXTBOX ---
        Dim selectedStaffId As Integer = 0
        If Not String.IsNullOrWhiteSpace(txtTechSearch.Text) Then
            ' Look up the ID using the Name typed in the box
            If _technicianMap.ContainsKey(txtTechSearch.Text) Then
                selectedStaffId = _technicianMap(txtTechSearch.Text)
            Else
                MessageBox.Show("The technician entered is not valid. Please select a name from the suggestions list.", "Invalid Technician", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTechSearch.Focus()
                Return
            End If
        Else
            MessageBox.Show("Please select a technician.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTechSearch.Focus()
            Return
        End If

        If MessageBox.Show("Are you sure you want to update this service record?", "Confirm Update",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim query As String = "
                UPDATE service 
                SET service_type = @serviceType,
                    date_requested = @dateRequested,
                    service_cost = @serviceCost,
                    staff_id = @staffId,
                    status = @status,
                    technician_notes = @techNotes,
                    date_completed = CASE 
                        WHEN @status = 'Completed' AND date_completed IS NULL THEN NOW()
                        WHEN @status = 'Completed' THEN date_completed
                        ELSE NULL 
                    END
                WHERE service_id = @serviceId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@serviceType", DropDownServiceType.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@dateRequested", DateTimePicker1.Value)
                    cmd.Parameters.AddWithValue("@serviceCost", Decimal.Parse(txtServiceFee.Text))

                    ' Use the ID found from our map
                    cmd.Parameters.AddWithValue("@staffId", selectedStaffId)

                    cmd.Parameters.AddWithValue("@status", cbStatus.SelectedItem.ToString())

                    ' Save Notes
                    cmd.Parameters.AddWithValue("@techNotes", txtServiceNotes.Text.Trim())

                    cmd.Parameters.AddWithValue("@serviceId", _serviceId)

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Service record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LogServiceUpdate(selectedStaffId)
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    Else
                        MessageBox.Show("No changes were made to the service record.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error updating service: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LogServiceUpdate(newStaffId As Integer)
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Dim query As String = "INSERT INTO service_audit_log (service_id, updated_by, update_date, changes_made) VALUES (@serviceId, @updatedBy, NOW(), @changes)"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@serviceId", _serviceId)
                    cmd.Parameters.AddWithValue("@updatedBy", "System")
                    cmd.Parameters.AddWithValue("@changes", GetChangeSummary(newStaffId))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error logging update: " & ex.Message)
        End Try
    End Sub

    Private Function GetChangeSummary(newStaffId As Integer) As String
        If _originalData Is Nothing Then Return "Initial update"

        Dim changes As New List(Of String)

        If DropDownServiceType.SelectedItem.ToString() <> _originalData("service_type").ToString() Then
            changes.Add($"Service Type: {_originalData("service_type")} → {DropDownServiceType.SelectedItem}")
        End If

        If Decimal.Parse(txtServiceFee.Text) <> Convert.ToDecimal(_originalData("service_cost")) Then
            changes.Add($"Service Fee: {_originalData("service_cost")} → {txtServiceFee.Text}")
        End If

        If cbStatus.SelectedItem.ToString() <> _originalData("status").ToString() Then
            changes.Add($"Status: {_originalData("status")} → {cbStatus.SelectedItem}")
        End If

        ' Compare Technician using ID
        Dim oldStaffId As Integer = If(IsDBNull(_originalData("staff_id")), 0, Convert.ToInt32(_originalData("staff_id")))
        If newStaffId <> oldStaffId Then
            changes.Add($"Technician ID: {oldStaffId} → {newStaffId}")
        End If

        ' Compare Notes
        Dim originalNotes As String = If(IsDBNull(_originalData("technician_notes")), "", _originalData("technician_notes").ToString())
        If txtServiceNotes.Text.Trim() <> originalNotes Then
            changes.Add("Notes Updated")
        End If

        Return If(changes.Count > 0, String.Join("; ", changes), "No changes detected")
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ' Currency Formatting
    Private Sub txtServiceFee_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtServiceFee.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True
            Return
        End If
        If e.KeyChar = "." AndAlso txtServiceFee.Text.Contains(".") Then
            e.Handled = True
            Return
        End If
    End Sub

    Private Sub txtServiceFee_Leave(sender As Object, e As EventArgs) Handles txtServiceFee.Leave
        Dim fee As Decimal
        If Decimal.TryParse(txtServiceFee.Text, fee) Then
            txtServiceFee.Text = fee.ToString("N2")
        End If
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If Me.DialogResult = DialogResult.None Then
            Me.DialogResult = DialogResult.Cancel
        End If
        MyBase.OnFormClosing(e)
    End Sub

    Private Sub txtTechSearch_TextChanged(sender As Object, e As EventArgs) Handles txtTechSearch.TextChanged
        ' AutoComplete handles the filtering, so we don't need manual code here 
        ' unless you want to clear selection if text is empty.
    End Sub

End Class