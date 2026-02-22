Imports System.Configuration
Imports MySqlConnector

Public Class EditInfo
    ' Properties to receive data from Profile form
    Public Property CustomerId As Integer
    Public Property FirstName As String
    Public Property LastName As String
    Public Property EmailAddress As String
    Public Property ContactNumber As String

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

    Private Sub EditInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load user data when form loads
        If CustomerId > 0 Then
            LoadUserData()
        Else
            MessageBox.Show("No user data available.", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
    End Sub

    Private Sub LoadUserData()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                ' Query to get user data
                Dim query As String = "SELECT first_name, last_name, email_address, contact_number " &
                                      "FROM customer_data WHERE customer_id = @id"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", CustomerId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Populate textboxes with current data
                            FNTxtBox.Text = reader("first_name").ToString()
                            LNTxtBox.Text = reader("last_name").ToString()
                            EmailTxtBox.Text = reader("email_address").ToString()
                            PhoneTxtBox.Text = reader("contact_number").ToString()

                            ' Store original values (optional, for validation)
                            FirstName = FNTxtBox.Text
                            LastName = LNTxtBox.Text
                            EmailAddress = EmailTxtBox.Text
                            ContactNumber = PhoneTxtBox.Text
                        Else
                            MessageBox.Show("User data not found.", "Error",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.Close()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading user data: " & ex.Message, "Database Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub UpdateBtn_Click(sender As Object, e As EventArgs) Handles UpdateBtn.Click
        ' Validate inputs
        If String.IsNullOrWhiteSpace(FNTxtBox.Text) Then
            MessageBox.Show("First name is required.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            FNTxtBox.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(LNTxtBox.Text) Then
            MessageBox.Show("Last name is required.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LNTxtBox.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(EmailTxtBox.Text) Then
            MessageBox.Show("Email address is required.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            EmailTxtBox.Focus()
            Return
        End If

        If Not IsValidEmail(EmailTxtBox.Text) Then
            MessageBox.Show("Please enter a valid email address.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            EmailTxtBox.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(PhoneTxtBox.Text) Then
            MessageBox.Show("Contact number is required.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            PhoneTxtBox.Focus()
            Return
        End If

        ' Save changes to database
        If SaveChanges() Then
            ' Update properties with new values
            FirstName = FNTxtBox.Text
            LastName = LNTxtBox.Text
            EmailAddress = EmailTxtBox.Text
            ContactNumber = PhoneTxtBox.Text

            ' Set dialog result to OK
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Function SaveChanges() As Boolean
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                ' Update query
                Dim query As String = "UPDATE customer_data SET " &
                                      "first_name = @firstName, " &
                                      "last_name = @lastName, " &
                                      "email_address = @email, " &
                                      "contact_number = @phone " &
                                      "WHERE customer_id = @id"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@firstName", FNTxtBox.Text.Trim())
                    cmd.Parameters.AddWithValue("@lastName", LNTxtBox.Text.Trim())
                    cmd.Parameters.AddWithValue("@email", EmailTxtBox.Text.Trim())
                    cmd.Parameters.AddWithValue("@phone", PhoneTxtBox.Text.Trim())
                    cmd.Parameters.AddWithValue("@id", CustomerId)

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        Return True
                    Else
                        MessageBox.Show("No changes were made.", "Update Failed",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saving changes: " & ex.Message, "Database Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ChangePassBtn_Click(sender As Object, e As EventArgs) Handles ChangePassBtn.Click
        ' Open change password form
        Dim changePassForm As New ChangePassword()
        changePassForm.CustomerId = CustomerId

        changePassForm.ShowDialog()
    End Sub

    ' Helper function to validate email format
    Private Function IsValidEmail(email As String) As Boolean
        Try
            Dim addr As New System.Net.Mail.MailAddress(email)
            Return addr.Address = email
        Catch
            Return False
        End Try
    End Function

    Private Sub Line3_Click(sender As Object, e As EventArgs) Handles Line3.Click
        ' This event handler can be removed if not needed
    End Sub

    Private Sub LNTxtBox_TextChanged(sender As Object, e As EventArgs) Handles LNTxtBox.TextChanged
        ' This event handler can be removed if not needed
    End Sub
End Class