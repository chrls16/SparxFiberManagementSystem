Imports System.Configuration
Imports MySqlConnector

Public Class Profile
    ' Add these public properties at the top
    Public Property CurrentCustomerId As Integer
    Public Property CurrentFirstName As String
    Public Property CurrentLastName As String
    Public Property CurrentEmail As String

    Private _customerId As Integer
    Private _connectionString As String = Nothing

    Private ReadOnly Property CONNECTION_STRING As String
        Get
            If _connectionString Is Nothing AndAlso Not DesignMode Then
                Try
                    _connectionString = ConfigurationManager.ConnectionStrings("SparxDb").ConnectionString
                Catch
                    _connectionString = "Server=localhost;Database=sparx;Uid=root;Pwd=;"
                End Try
            End If
            Return If(_connectionString IsNot Nothing, _connectionString, String.Empty)
        End Get
    End Property

    Private Sub Profile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Use the passed customer ID if available
        If CurrentCustomerId > 0 Then
            _customerId = CurrentCustomerId
            LoadProfileData()
        Else
            MessageBox.Show("No customer ID found. Please log in again.", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub LoadProfileData()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                ' Query to get customer data from customer_data table - INCLUDING PUROK
                Dim query As String = "SELECT first_name, last_name, email_address, contact_number, " &
                                      "billing_address, landmark, purok, barangay, municipality, province, " &
                                      "plan_type, monthly_rate, date_installed, account_status " &
                                      "FROM customer_data WHERE customer_id = @id"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", _customerId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Personal Information
                            UserFNLbl.Text = reader("first_name").ToString()
                            UserLNLbl.Text = reader("last_name").ToString()
                            UserEmailLbl.Text = reader("email_address").ToString()
                            UserPhoneLbl.Text = reader("contact_number").ToString()

                            ' Address Information
                            ' Get all address components from separate columns
                            Dim purok As String = reader("purok").ToString()
                            Dim barangay As String = reader("barangay").ToString()
                            Dim municipality As String = reader("municipality").ToString()
                            Dim province As String = reader("province").ToString()
                            Dim landmark As String = reader("landmark").ToString()

                            ' Check if province is empty, set default to Camarines Norte
                            If String.IsNullOrEmpty(province) Then
                                province = "Camarines Norte"
                            End If

                            ' Check if municipality is empty
                            If String.IsNullOrEmpty(municipality) Then
                                municipality = "Daet" ' Default municipality
                            End If

                            ' Set address labels including Purok
                            UserBrgyLbl.Text = barangay
                            UserMunLbl.Text = municipality
                            UserProvinceLbl.Text = province
                            UserCountryLbl.Text = "Philippines"
                            UserLandmarkLbl.Text = landmark

                            ' Set Purok label (Label1 is the value label for purok based on your designer)
                            Label1.Text = purok

                            ' Set Hello message with first name
                            HelloLbl.Text = "Hello, " & reader("first_name").ToString() & "!"
                        Else
                            MessageBox.Show("User data not found in the database.", "Error",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Database Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error loading profile data: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EditInfoBtn_Click(sender As Object, e As EventArgs) Handles EditInfoBtn.Click
        Dim editForm As New EditInfo()

        ' Pass current data to edit form
        editForm.CustomerId = _customerId
        editForm.FirstName = UserFNLbl.Text
        editForm.LastName = UserLNLbl.Text
        editForm.EmailAddress = UserEmailLbl.Text
        editForm.ContactNumber = UserPhoneLbl.Text

        ' Show as dialog
        If editForm.ShowDialog() = DialogResult.OK Then
            ' Update local labels with new values
            UserFNLbl.Text = editForm.FirstName
            UserLNLbl.Text = editForm.LastName
            UserEmailLbl.Text = editForm.EmailAddress
            UserPhoneLbl.Text = editForm.ContactNumber

            ' Update Hello message
            HelloLbl.Text = "Hello, " & editForm.FirstName & "!"

            ' Update the database
            UpdatePersonalInfo(editForm)
        End If
    End Sub

    Private Sub UpdatePersonalInfo(editForm As EditInfo)
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim query As String = "UPDATE customer_data SET " &
                                      "first_name = @firstName, " &
                                      "last_name = @lastName, " &
                                      "email_address = @email, " &
                                      "contact_number = @phone " &
                                      "WHERE customer_id = @id"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@firstName", editForm.FirstName)
                    cmd.Parameters.AddWithValue("@lastName", editForm.LastName)
                    cmd.Parameters.AddWithValue("@email", editForm.EmailAddress)
                    cmd.Parameters.AddWithValue("@phone", editForm.ContactNumber)
                    cmd.Parameters.AddWithValue("@id", _customerId)

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Personal information updated successfully!", "Success",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("No records were updated.", "Warning",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating personal information: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EditAddressBtn_Click(sender As Object, e As EventArgs) Handles EditAddressBtn.Click
        Dim editAddressForm As New EditAddress()

        ' Pass current data to edit form
        editAddressForm.CustomerId = _customerId
        editAddressForm.Province = UserProvinceLbl.Text
        editAddressForm.Municipality = UserMunLbl.Text
        editAddressForm.Barangay = UserBrgyLbl.Text
        editAddressForm.Landmark = UserLandmarkLbl.Text
        editAddressForm.Purok = Label1.Text ' Pass purok value from Label1

        ' Show as dialog
        If editAddressForm.ShowDialog() = DialogResult.OK Then
            ' Refresh the address display
            LoadProfileData()
            MessageBox.Show("Address updated successfully!", "Success",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ChangePassBtn_Click(sender As Object, e As EventArgs) Handles ChangePassBtn.Click
        Dim changePassForm As New ChangePassword()
        changePassForm.CustomerId = _customerId

        If changePassForm.ShowDialog() = DialogResult.OK Then
            MessageBox.Show("Password changed successfully!", "Success",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub PanelRound4_Paint(sender As Object, e As PaintEventArgs) Handles PanelRound4.Paint
        ' Paint code if needed
    End Sub

    Private Sub PanelRound3_Paint(sender As Object, e As PaintEventArgs) Handles PanelRound3.Paint
        ' Paint code if needed
    End Sub
End Class