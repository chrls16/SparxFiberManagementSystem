Imports System.Data
Imports MySql.Data.MySqlClient
Imports MySqlConnector
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class frmInstallationUpdate
    ' Properties to hold the data
    Public Property ServiceIDValue As Integer
    Public Property CustomerName As String
    Public Property Address As String
    Public Property DateRequestedStr As String
    Public Property Technician As String
    Public Property Status As String
    Public Property DateCompletedStr As String
    Public Property SelectedServiceID As Integer

    ' Connection string - update with your actual connection string
    Private ReadOnly connectionString As String = "server=127.0.0.1;user=root;password=;database=sparx;"

    ' Store technicians and statuses for searching
    Private techniciansList As New List(Of KeyValuePair(Of Integer, String))()
    Private statusesList As New List(Of String)()

    ' For making form draggable
    Private drag As Boolean
    Private mouseX As Integer, mouseY As Integer

    ' ToolTip to simulate placeholder for ComboBox
    Private ReadOnly tt As New ToolTip()

    Private Sub frmInstallationUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Center the form on the screen
        Me.CenterToScreen()
        Me.Text = "Update Installation"

        ' --- 1. PREFILL AND LOCK CUSTOMER & ADDRESS ---
        ' Set values
        txtCustomer.Text = CustomerName
        txtAddress.Text = Address

        ' Parse and set date values
        If Not String.IsNullOrEmpty(DateRequestedStr) AndAlso Date.TryParse(DateRequestedStr, New Date) Then
            DateTimePicker.Value = Date.Parse(DateRequestedStr)
        Else
            DateTimePicker.Value = Date.Today
        End If



        ' --- 2. SETUP TECHNICIAN SEARCH ---
        LoadTechnicians()           ' 1. Load data from DB
        ConfigureTechnicianTextBox() ' 2. Bind AutoComplete source

        ' 3. Prefill the technician IF it exists
        If Not String.IsNullOrEmpty(Technician) Then
            txtTechnicianSearch.Text = Technician
        Else
            txtTechnicianSearch.Text = ""
            tt.SetToolTip(txtTechnicianSearch, "Type technician name...")
        End If
        ' ----------------------------------

        ' Load Statuses
        LoadStatuses()


        btnCreate.Text = "Update"
        ConfigureStatusDropdown()
    End Sub
    Private Sub ConfigureTechnicianTextBox()
        ' Ensure the list isn't empty
        If techniciansList.Count = 0 Then Exit Sub

        Dim techCollection As New AutoCompleteStringCollection()

        For Each tech In techniciansList
            techCollection.Add(tech.Value)
        Next

        ' SuggestAppend allows them to type "Jo" and see "John Doe" 
        ' while also allowing them to simply select it.
        txtTechnicianSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtTechnicianSearch.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtTechnicianSearch.AutoCompleteCustomSource = techCollection
    End Sub

    Private Sub ConfigureStatusDropdown()
        ' Configure Status dropdown for searching
        DropDownStatus.DropDownStyle = ComboBoxStyle.DropDown
        DropDownStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        DropDownStatus.AutoCompleteSource = AutoCompleteSource.ListItems

        ' Add typing event for search
        AddHandler DropDownStatus.KeyUp, AddressOf DropDownStatus_KeyUp
    End Sub

    Private Sub LoadStatuses()
        Try
            ' Clear existing items
            DropDownStatus.Items.Clear()
            statusesList.Clear()

            ' Add default item
            DropDownStatus.Items.Add("Select Status")

            Dim statusOptions() As String = {"Requested", "In Progress", "Completed"}

            For Each statusOpt As String In statusOptions
                DropDownStatus.Items.Add(statusOpt)
                statusesList.Add(statusOpt)
            Next

            ' Set default selection
            If DropDownStatus.Items.Count > 0 Then
                DropDownStatus.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading statuses: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub LoadTechnicians()
        Try
            techniciansList.Clear()

            ' Query to get all technicians
            ' Ensure 'staff' table exists and has 'staff_id', 'first_name', 'last_name', and 'position' columns
            Dim query As String = "SELECT staff_id, CONCAT(first_name, ' ', last_name) as technician_name " &
                                  "FROM staff WHERE position = 'Technician' ORDER BY first_name"

            Using conn As New MySqlConnection(connectionString)
                Using cmd As New MySqlCommand(query, conn)
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            ' Safely read values
                            Dim techId As Integer = 0
                            If Not IsDBNull(reader("staff_id")) Then
                                techId = Convert.ToInt32(reader("staff_id"))
                            End If

                            Dim techName As String = ""
                            If Not IsDBNull(reader("technician_name")) Then
                                techName = reader("technician_name").ToString()
                            End If

                            ' Store in list for searching if valid
                            If techId > 0 AndAlso Not String.IsNullOrEmpty(techName) Then
                                techniciansList.Add(New KeyValuePair(Of Integer, String)(techId, techName))
                            End If
                        End While
                    End Using
                End Using
            End Using

            ' Refresh the AutoComplete source
            ConfigureTechnicianTextBox()

        Catch ex As Exception
            MessageBox.Show("Error loading technicians: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub DropDownStatus_KeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            ' Find matching status when user presses Enter or Tab
            FindAndSelectStatus()
        ElseIf e.KeyCode <> Keys.Up And e.KeyCode <> Keys.Down Then
            ' Auto-suggest while typing
            AutoSuggestStatus()
        End If
    End Sub

    ' Add KeyUp event handler for txtTechnician
    Private Sub txtTechnician_KeyUp(sender As Object, e As KeyEventArgs) Handles txtTechnicianSearch.KeyUp
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            ' Validate technician when user presses Enter or Tab
            ValidateTechnician()
        End If
    End Sub

    Private Sub AutoSuggestStatus()
        Dim searchText As String = DropDownStatus.Text.Trim().ToLower()

        If String.IsNullOrEmpty(searchText) Or searchText = "select status" Then
            Return
        End If

        ' Filter statuses based on search text
        Dim filteredStatuses = statusesList.Where(Function(s)
                                                      Return s.ToLower().Contains(searchText)
                                                  End Function).ToList()

        ' Show dropdown with filtered results
        If filteredStatuses.Count > 0 Then
            DropDownStatus.DroppedDown = True
        End If
    End Sub

    Private Sub ValidateTechnician()
        Dim searchText As String = txtTechnicianSearch.Text.Trim()

        If String.IsNullOrEmpty(searchText) Then
            Return
        End If

        ' Find exact match first
        Dim match = techniciansList.FirstOrDefault(Function(t)
                                                       Return t.Value.Equals(searchText, StringComparison.OrdinalIgnoreCase)
                                                   End Function)

        If String.IsNullOrEmpty(match.Value) Then
            ' Find partial match
            match = techniciansList.FirstOrDefault(Function(t)
                                                       Return t.Value.ToLower().Contains(searchText.ToLower())
                                                   End Function)
        End If

        If Not String.IsNullOrEmpty(match.Value) Then
            txtTechnicianSearch.Text = match.Value
        Else
            ' Show available technicians
            Dim availableTechs = String.Join(vbCrLf, techniciansList.Select(Function(t) t.Value))
            MessageBox.Show($"Technician '{searchText}' not found. Available technicians:{vbCrLf}{availableTechs}",
                          "Technician Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTechnicianSearch.Focus()
            txtTechnicianSearch.SelectAll()
        End If
    End Sub

    Private Sub FindAndSelectStatus()
        Dim searchText As String = DropDownStatus.Text.Trim()

        If String.IsNullOrEmpty(searchText) Or searchText = "Select Status" Then
            Return
        End If

        ' Find exact match first
        Dim match = statusesList.FirstOrDefault(Function(s)
                                                    Return s.Equals(searchText, StringComparison.OrdinalIgnoreCase)
                                                End Function)

        If String.IsNullOrEmpty(match) Then
            ' Find partial match
            match = statusesList.FirstOrDefault(Function(s)
                                                    Return s.ToLower().Contains(searchText.ToLower())
                                                End Function)
        End If


    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        ' Validate inputs
        If String.IsNullOrEmpty(txtTechnicianSearch.Text.Trim()) Then
            MessageBox.Show("Please enter a technician name.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTechnicianSearch.Focus()
            Return
        End If

        If String.IsNullOrEmpty(DropDownStatus.Text.Trim()) Or
           DropDownStatus.Text = "Select Status" Then
            MessageBox.Show("Please select or enter a status.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            DropDownStatus.Focus()
            Return
        End If

        ' Validate that entered technician exists
        Dim staffId As Integer = GetStaffId(txtTechnicianSearch.Text.Trim())
        If staffId = 0 Then
            MessageBox.Show("Could not find technician. Please enter a valid technician name.",
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTechnicianSearch.Focus()
            txtTechnicianSearch.SelectAll()
            Return
        End If

        ' Validate that entered status is valid
        If Not statusesList.Contains(DropDownStatus.Text) Then
            MessageBox.Show("Invalid status. Please select from the available statuses.",
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DropDownStatus.Focus()
            Return
        End If

        Try
            ' Update database
            Dim query As String = "UPDATE service SET " &
                          "staff_id = @StaffID, " &
                          "status = @Status, " &
                          "date_completed = @DateCompleted " &
                          "WHERE service_id = @ServiceID"

            Using conn As New MySqlConnection(connectionString)
                Using cmd As New MySqlCommand(query, conn)
                    ' Add parameters
                    cmd.Parameters.AddWithValue("@StaffID", staffId)

                    cmd.Parameters.AddWithValue("@ServiceID", ServiceIDValue)

                    conn.Open()
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Installation updated successfully!", "Success",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    Else
                        MessageBox.Show("No records were updated. Service ID might not exist.",
                              "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error saving changes: " & ex.Message, "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetStaffId(technicianName As String) As Integer
        Try
            Dim query As String = "SELECT staff_id FROM staff " &
                                  "WHERE CONCAT(first_name, ' ', last_name) = @TechnicianName " &
                                  "AND position = 'Technician'"

            Using conn As New MySqlConnection(connectionString)
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@TechnicianName", technicianName)

                    conn.Open()
                    Dim result As Object = cmd.ExecuteScalar()

                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        Return Convert.ToInt32(result)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error getting staff ID: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        Return 0
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub


    ' Add LostFocus events to validate fields when user leaves them
    Private Sub DropDownStatus_LostFocus(sender As Object, e As EventArgs) Handles DropDownStatus.LostFocus
        FindAndSelectStatus()
    End Sub

    Private Sub txtTechnician_LostFocus(sender As Object, e As EventArgs) Handles txtTechnicianSearch.LostFocus
        ValidateTechnician()
    End Sub

    ' Handle mouse click to show dropdown for status
    Private Sub DropDownStatus_MouseClick(sender As Object, e As MouseEventArgs) Handles DropDownStatus.MouseClick
        DropDownStatus.DroppedDown = True
    End Sub

    ' ========== DRAGGABLE FORM CODE ==========
    ' Mouse down event to start dragging
    Private Sub Form_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        ' Only drag from the title area (top part of form)
        If e.Y <= 40 Then
            drag = True
            mouseX = Cursor.Position.X - Me.Left
            mouseY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    ' Mouse move event while dragging
    Private Sub Form_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - mouseX
            Me.Top = Cursor.Position.Y - mouseY
        End If
    End Sub

    ' Mouse up event to stop dragging
    Private Sub Form_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        drag = False
    End Sub

    ' Also make the label draggable (for title area)
    Private Sub LblUpdate_MouseDown(sender As Object, e As MouseEventArgs) Handles LblUpdate.MouseDown
        drag = True
        mouseX = Cursor.Position.X - Me.Left
        mouseY = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub LblUpdate_MouseMove(sender As Object, e As MouseEventArgs) Handles LblUpdate.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - mouseX
            Me.Top = Cursor.Position.Y - mouseY
        End If
    End Sub

    Private Sub LblUpdate_MouseUp(sender As Object, e As MouseEventArgs) Handles LblUpdate.MouseUp
        drag = False
    End Sub

    ' ========== END DRAGGABLE FORM CODE ==========

    ' Show technician suggestions when double-clicking the textbox
    Private Sub txtTechnician_DoubleClick(sender As Object, e As EventArgs) Handles txtTechnicianSearch.DoubleClick
        ShowTechnicianSuggestions()
    End Sub

    Private Sub ShowTechnicianSuggestions()
        If techniciansList.Count = 0 Then
            MessageBox.Show("No technicians available in the database.", "Information",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Create a simple list form for technician selection
        Using suggestionForm As New Form()
            suggestionForm.Text = "Select Technician"
            suggestionForm.FormBorderStyle = FormBorderStyle.FixedDialog
            suggestionForm.StartPosition = FormStartPosition.CenterParent
            suggestionForm.Size = New Size(300, 400)
            suggestionForm.MaximizeBox = False
            suggestionForm.MinimizeBox = False

            ' Create ListBox
            Dim listBox As New ListBox()
            listBox.Dock = DockStyle.Fill
            listBox.Font = New Font("Segoe UI", 10.0F)

            ' Add technicians to list
            For Each tech In techniciansList
                listBox.Items.Add(tech.Value)
            Next

            ' Create OK button
            Dim btnOK As New Button()
            btnOK.Text = "Select"
            btnOK.Dock = DockStyle.Bottom
            btnOK.Height = 40

            ' Add event handler
            AddHandler btnOK.Click, Sub(s, ev)
                                        If listBox.SelectedIndex >= 0 Then
                                            txtTechnicianSearch.Text = listBox.SelectedItem.ToString()
                                            suggestionForm.Close()
                                        Else
                                            MessageBox.Show("Please select a technician.", "Selection Required",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        End If
                                    End Sub

            ' Add controls to form
            suggestionForm.Controls.Add(listBox)
            suggestionForm.Controls.Add(btnOK)

            ' Show the form
            suggestionForm.ShowDialog(Me)
        End Using
    End Sub

    ' Make all controls on form click-through for dragging (except buttons and input controls)
    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs) Handles LblCustomer.MouseDown, LblAddress.MouseDown, LblDateRequested.MouseDown, LblTechnician.MouseDown, LblStatus.MouseDown

        ' Only drag if clicking on empty areas of labels
        If TypeOf sender Is Label Then
            drag = True
            mouseX = Cursor.Position.X - Left
            mouseY = Cursor.Position.Y - Top
        End If
    End Sub

    Private Sub Control_MouseMove(sender As Object, e As MouseEventArgs) Handles LblCustomer.MouseMove, LblAddress.MouseMove, LblDateRequested.MouseMove, LblTechnician.MouseMove, LblStatus.MouseMove

        If drag Then
            Left = Cursor.Position.X - mouseX
            Top = Cursor.Position.Y - mouseY
        End If
    End Sub

    Private Sub Control_MouseUp(sender As Object, e As MouseEventArgs) Handles LblCustomer.MouseUp, LblAddress.MouseUp, LblDateRequested.MouseUp, LblTechnician.MouseUp, LblStatus.MouseUp

        drag = False
    End Sub

    Private Sub txtCustomer_TextChanged(sender As Object, e As EventArgs) Handles txtCustomer.TextChanged

    End Sub

    Private Sub txtAddress_TextChanged(sender As Object, e As EventArgs) Handles txtAddress.TextChanged

    End Sub

    Private Sub txtTechnicianSearch_TextChanged(sender As Object, e As EventArgs) Handles txtTechnicianSearch.TextChanged

    End Sub
End Class