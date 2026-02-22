Imports MySqlConnector
Imports BCrypt.Net

Public Class frmStaffCreatevb
    Dim connString As String = "server=localhost;user=root;password=;database=sparx;Convert Zero Datetime=True;Allow Zero Datetime=True;"

    Private currentAccessLevel As String = "2" ' Default to Customer Service

    Private Sub frmStaffCreatevb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize form defaults
        txtPassword.PasswordChar = "●"c
        cbStatus.SelectedIndex = 0 ' Active
        If cbPosition.Items.Count > 0 Then
            cbPosition.SelectedIndex = 0
        End If
        SetupAddressAutoComplete()
        cbAddress.DropDownStyle = ComboBoxStyle.DropDown
        UpdateAccessAndRate()

        ' Set constraints for birthdate (e.g., must be at least 18 years old)
        DateBirthPicker.Format = DateTimePickerFormat.Short
        DateBirthPicker.MaxDate = DateTime.Today.AddYears(-18)
        DateBirthPicker.Value = DateTime.Today.AddYears(-25)

        cbAccessLevel.Items.Clear()
        cbAccessLevel.Items.AddRange(New Object() {"1", "2", "3"})
        cbAccessLevel.DropDownStyle = ComboBoxStyle.DropDownList ' Prevents manual typing
        cbAccessLevel.SelectedIndex = 1 ' Defaults to "2" (Customer Service)

        Me.CancelButton = btnCancel

    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        ' --- 1. BASIC VALIDATION ---
        ' Check if required name and login fields are empty
        If String.IsNullOrWhiteSpace(txtFirstname.Text) OrElse
   String.IsNullOrWhiteSpace(txtLastname.Text) OrElse
   String.IsNullOrWhiteSpace(TxTUsername.Text) Then
            MessageBox.Show("Please fill in First Name, Last Name, and Username.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' --- 2. PHONE NUMBER VALIDATION ---
        Dim contact As String = txtContactNumber.Text.Trim()
        If contact.Length <> 11 OrElse Not contact.StartsWith("09") OrElse Not IsNumeric(contact) Then
            MessageBox.Show("Please enter a valid 11-digit phone number starting with '09'.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContactNumber.Focus()
            Exit Sub
        End If

        ' --- 3. PASSWORD LENGTH VALIDATION ---
        If txtPassword.Text.Length < 6 Then
            MessageBox.Show("Password must be at least 6 characters long.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Exit Sub
        End If

        ' --- 4. DAILY RATE VALIDATION ---
        Dim dailyRate As Decimal
        If Not Decimal.TryParse(txtDailyRate.Text, dailyRate) Then
            MessageBox.Show("Invalid Daily Rate format.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' --- 5. DATABASE INSERT ---
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()

                Dim query As String = "INSERT INTO staff (first_name, last_name, birthdate, sex, contact_number, " &
                             "email_address, address, position, date_hired, username, password_hash, " &
                             "department, status, daily_rate, access_level) " &
                             "VALUES (@fname, @lname, @bday, @sex, @contact, @email, @address, " &
                             "@pos, @hired, @user, @pass, @dept, @status, @rate, @access)"

                Using cmd As New MySqlCommand(query, conn)
                    ' We now use the separate textboxes directly (supporting second names naturally)
                    cmd.Parameters.AddWithValue("@fname", txtFirstname.Text.Trim())
                    cmd.Parameters.AddWithValue("@lname", txtLastname.Text.Trim())
                    cmd.Parameters.AddWithValue("@bday", DateBirthPicker.Value.ToString("yyyy-MM-dd"))

                    ' Sex value (Consider adding a ComboBox for this later)
                    cmd.Parameters.AddWithValue("@sex", "Male")

                    cmd.Parameters.AddWithValue("@contact", contact)
                    cmd.Parameters.AddWithValue("@email", txtEmailAddress.Text.Trim())
                    cmd.Parameters.AddWithValue("@address", cbAddress.Text)
                    cmd.Parameters.AddWithValue("@pos", cbPosition.Text)
                    cmd.Parameters.AddWithValue("@hired", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@user", TxTUsername.Text.Trim())

                    ' BCrypt Hashing
                    cmd.Parameters.AddWithValue("@pass", BCrypt.Net.BCrypt.HashPassword(txtPassword.Text))

                    cmd.Parameters.AddWithValue("@dept", TxtDepartment.Text)
                    cmd.Parameters.AddWithValue("@status", cbStatus.Text)
                    cmd.Parameters.AddWithValue("@rate", dailyRate)

                    Dim accessLvl As Integer = 2 ' Default to 2 (Customer Service)

                    ' Instead of relying on the ComboBox selection which might be lost/reset,
                    ' we determine the level based on the position text directly.
                    Select Case cbPosition.Text.Trim()
                        Case "Inventory"
                            accessLvl = 1
                        Case "Customer Service"
                            accessLvl = 2
                        Case "Technician"
                            accessLvl = 3
                        Case "Super Admin"
                            accessLvl = 0 ' Only Super Admin gets 0
                        Case Else
                            accessLvl = 2 ' Everything else defaults to 2
                    End Select

                    ' Final safety: If the user is creating a regular staff, ensure it's NEVER 0
                    If accessLvl = 0 AndAlso cbPosition.Text.Trim() <> "Super Admin" Then
                        accessLvl = 2
                    End If

                    cmd.Parameters.AddWithValue("@access", accessLvl)

                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Staff Account Created Successfully!", "SFIS Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Database Error: " & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Execution Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cbPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPosition.SelectedIndexChanged
        UpdateAccessAndRate()
    End Sub

    Private Sub UpdateAccessAndRate()
        ' Use a local variable to avoid multiple calls to .Text
        Dim selectedPos As String = cbPosition.Text.Trim()

        Select Case selectedPos
            Case "Inventory"
                cbAccessLevel.SelectedIndex = 0 ' Selects "1"
                txtDailyRate.Text = "365.00"
            Case "Customer Service"
                cbAccessLevel.SelectedIndex = 1 ' Selects "2"
                txtDailyRate.Text = "365.00"
            Case "Technician"
                cbAccessLevel.SelectedIndex = 2 ' Selects "3"
                txtDailyRate.Text = "500.00"
            Case Else
                ' Safe fallback for any other position
                cbAccessLevel.SelectedIndex = 1
                txtDailyRate.Text = "365.00"
        End Select
    End Sub

    Private Sub SetupAddressAutoComplete()
        Dim addrCollection As New AutoCompleteStringCollection()

        ' List of Barangays by Municipality
        Dim barangays As New Dictionary(Of String, String()) From {
        {"Daet", {"Alawihao", "Bagasbas", "Barangay I", "Barangay II", "Barangay III", "Barangay IV", "Barangay V", "Barangay VI", "Barangay VII", "Barangay VIII", "Bibirao", "Borabod", "Calasgasan", "Camambugan", "Dogongan", "Gubat", "Lag-on", "Magang", "Mancruz", "Mantagbac", "Pamorangon", "San Vicente"}},
        {"Labo", {"Abagat", "Alas-as", "Anahaw", "Bagacay", "Bagong Silang I", "Bagong Silang II", "Bakiad", "Bautista", "Binasabas", "Calabasa", "Canapawan", "Dugongan", "Iberica", "Malasugui", "Malatap", "Maligaya", "Masalong", "Pag-asa", "Pangpang", "Potot", "Santa Cruz", "Talobatib", "Tulay Na Lupa"}},
        {"Vinzons", {"Aguit-it", "Banocboc", "Barangay I", "Barangay II", "Barangay III", "Calitcuit", "Guinacutan", "Mangcayo", "Mangcawayan", "Napilihan", "Pinagbirayan Malaki", "Pinagbirayan Munti", "Sabang", "Santo Domingo"}},
        {"Jose Panganiban", {"Alawihao", "Bagong Bayan", "Dahican", "Dayhagan", "Larap", "Luklukan Sur", "Motherlode", "Nakalaya", "Parang", "Plaridel", "San Isidro", "Santa Cruz", "Santa Elena", "Tamisan"}},
        {"Mercedes", {"Apuao", "Caringo", "Catandunganon", "Cayucyucan", "Colasi", "Hamoraon", "Hinampacan", "Lantig", "Mambungalon", "Matoogtog", "Pambuhan", "Quinapaguian", "San Roque"}},
        {"Basud", {"Angas", "Bactas", "Binatagan", "Caayunan", "Guinasayan", "Linga", "Laniton", "Mampili", "Mantugawe", "Matnog", "Mocong", "Oliva", "Pagsangahan", "Plaridel", "San Pascual"}},
        {"Paracale", {"Awitan", "Bagumbayan", "Bakong", "Capacuan", "Casalugan", "Gumaus", "Labnig", "Malisig", "Mampugo", "Palanas", "Pinagbirayan", "Poblacion Sur", "Poblacion Norte", "Tawig"}},
        {"Capalonga", {"Alayao", "Binawangan", "Calabaca", "Camagsaan", "Catabaguangan", "Itok", "Lucbanen", "Mabini", "Maguiron", "Old Camp", "Poblacion", "San Roque", "Villa Aurora"}},
        {"Santa Elena", {"Don Tomas", "Guinacu", "Kabuluan", "Maulawin", "Poblacion", "Polillo", "Rizal", "San Lorenzo", "Santa Maria", "Villa Belen"}},
        {"Talisay", {"Binanuaan", "Caawigan", "Cahabaan", "Calasgasan", "Gabon", "Itomang", "Poblacion", "San Francisco", "San Isidro", "San Jose", "Santa Cruz"}},
        {"San Vicente", {"Asuncion", "Cabancalan", "Calabagas", "Fabrica", "Iraya Sur", "Manloya", "Poblacion"}},
        {"San Lorenzo Ruiz", {"Daculang Bolo", "Dagotdotan", "Langga", "Maisog", "Mampurog", "Manlimonsito", "Matacong", "San Antonio"}}
    }

        ' Convert Dictionary to full address strings for AutoComplete
        For Each municipality In barangays.Keys
            For Each brgy In barangays(municipality)
                addrCollection.Add(brgy & ", " & municipality & ", Camarines Norte")
            Next
        Next

        ' Apply to ComboBox
        cbAddress.AutoCompleteCustomSource = addrCollection
        cbAddress.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cbAddress.AutoCompleteSource = AutoCompleteSource.CustomSource

        ' Set Dropdown list items
        cbAddress.Items.Clear()
        For Each municipality In barangays.Keys
            cbAddress.Items.Add(municipality & ", Camarines Norte")
        Next
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Confirm with the user before closing if they have already typed data
        If Not String.IsNullOrWhiteSpace(txtFirstname.Text) OrElse Not String.IsNullOrWhiteSpace(txtPassword.Text) Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to cancel? Any unsaved changes will be lost.",
                                                     "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                Exit Sub
            End If
        End If

        ' Close the form
        Me.Close()
    End Sub

    Private Sub labelAccess_Click(sender As Object, e As EventArgs) Handles labelAccess.Click

    End Sub

    Private Sub cbAccessLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAccessLevel.SelectedIndexChanged

    End Sub

    Private Sub picShowHide_Click(sender As Object, e As EventArgs) Handles picShowHide.Click
        If txtPassword.PasswordChar = "●" Then
            txtPassword.PasswordChar = Chr(0)
            picShowHide.Image = My.Resources.eye_open
        Else
            txtPassword.PasswordChar = "●"
            picShowHide.Image = My.Resources.eye_slashed
        End If
    End Sub

    Private Sub txtContactNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContactNumber.KeyPress
        ' Allow only numbers and backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


End Class