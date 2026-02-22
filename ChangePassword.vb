Imports System.Configuration
Imports MySqlConnector
Imports System.Security.Cryptography
Imports System.Text

Public Class ChangePassword
    ' This must be set by the Profile form before calling ShowDialog()
    Public Property CustomerId As Integer

    ' Track if the form was closed by Save or Cancel
    Private _passwordChanged As Boolean = False

    ' Centralized connection string
    Private ReadOnly Property CONNECTION_STRING As String
        Get
            ' Attempt to get from config, otherwise use default
            Try
                Return ConfigurationManager.ConnectionStrings("SparxDb").ConnectionString
            Catch ex As Exception
                ' Log error if needed
                Debug.WriteLine($"Error reading connection string: {ex.Message}")
                Return "Server=localhost;Database=sparx;Uid=root;Pwd=;"
            End Try
        End Get
    End Property

    Private Sub ChangePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize password masking
        CurrentPasswordTxt.PasswordChar = "•"c
        NewPasswordTxt.PasswordChar = "•"c
        ConfirmPasswordTxt.PasswordChar = "•"c

        ' Clear any previous input
        CurrentPasswordTxt.Clear()
        NewPasswordTxt.Clear()
        ConfirmPasswordTxt.Clear()
        ShowCurrentPasswordCheck.Checked = False
        ShowNewPasswordCheck.Checked = False

        ' Set focus to current password field
        CurrentPasswordTxt.Focus()

        ' DEBUG: Show customer ID
        Debug.WriteLine($"DEBUG: Customer ID = {CustomerId}")
    End Sub

    ' Toggle password visibility with separate handlers for better control
    Private Sub ShowCurrentPasswordCheck_CheckedChanged(sender As Object, e As EventArgs) Handles ShowCurrentPasswordCheck.CheckedChanged
        CurrentPasswordTxt.PasswordChar = If(ShowCurrentPasswordCheck.Checked, Chr(0), "•"c)
    End Sub

    Private Sub ShowNewPasswordCheck_CheckedChanged(sender As Object, e As EventArgs) Handles ShowNewPasswordCheck.CheckedChanged
        Dim mask = If(ShowNewPasswordCheck.Checked, Chr(0), "•"c)
        NewPasswordTxt.PasswordChar = mask
        ConfirmPasswordTxt.PasswordChar = mask
    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        ' DEBUG: Log what's being entered
        Debug.WriteLine($"DEBUG: Current password entered: '{CurrentPasswordTxt.Text}'")
        Debug.WriteLine($"DEBUG: New password entered: '{NewPasswordTxt.Text}'")
        Debug.WriteLine($"DEBUG: Confirm password entered: '{ConfirmPasswordTxt.Text}'")

        ' 1. Validation
        If String.IsNullOrWhiteSpace(CurrentPasswordTxt.Text) Then
            MessageBox.Show("Please enter your current password.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CurrentPasswordTxt.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(NewPasswordTxt.Text) Then
            MessageBox.Show("Please enter a new password.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            NewPasswordTxt.Focus()
            Return
        End If

        ' Added: Minimum length check
        If NewPasswordTxt.Text.Length < 6 Then
            MessageBox.Show("New password must be at least 6 characters long.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            NewPasswordTxt.Focus()
            Return
        End If

        ' Added: Check if new password is same as current
        If CurrentPasswordTxt.Text = NewPasswordTxt.Text Then
            MessageBox.Show("New password must be different from current password.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            NewPasswordTxt.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(ConfirmPasswordTxt.Text) Then
            MessageBox.Show("Please confirm your new password.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConfirmPasswordTxt.Focus()
            Return
        End If

        If NewPasswordTxt.Text <> ConfirmPasswordTxt.Text Then
            MessageBox.Show("New passwords do not match.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConfirmPasswordTxt.Clear()
            ConfirmPasswordTxt.Focus()
            Return
        End If

        ' Disable buttons during processing
        SaveBtn.Enabled = False
        CancelBtn.Enabled = False

        ' Show processing indicator
        Dim originalText = SaveBtn.Text
        SaveBtn.Text = "Processing..."
        Application.DoEvents()

        ' 2. Process Change
        Try
            If ChangePasswordProcess() Then
                _passwordChanged = True
                MessageBox.Show("Password changed successfully!", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        Finally
            ' Restore button state
            SaveBtn.Enabled = True
            CancelBtn.Enabled = True
            SaveBtn.Text = originalText
        End Try
    End Sub

    Private Function ChangePasswordProcess() As Boolean
        If CustomerId <= 0 Then
            MessageBox.Show("Invalid customer ID. Please restart the application.",
                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                ' Get the stored hash from database
                Dim getHashQuery As String = "SELECT password_hash, email_address FROM customer_data WHERE customer_id = @id"
                Dim storedHash As String = ""
                Dim email As String = ""

                Using cmd As New MySqlCommand(getHashQuery, conn)
                    cmd.Parameters.AddWithValue("@id", CustomerId)
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            storedHash = If(reader("password_hash").ToString(), "")
                            email = If(reader("email_address").ToString(), "")
                        Else
                            MessageBox.Show("Customer account not found.", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return False
                        End If
                    End Using
                End Using

                ' DETECT HASH TYPE AND VERIFY
                Dim isPasswordCorrect As Boolean = False

                If storedHash.StartsWith("$2a$") OrElse storedHash.StartsWith("$2b$") OrElse storedHash.StartsWith("$2y$") Then
                    ' BCRYPT hash (like $2a$11$...)
                    isPasswordCorrect = VerifyBCryptPassword(CurrentPasswordTxt.Text, storedHash)
                ElseIf storedHash.Length = 32 Then
                    ' MD5 hash (32 hex characters)
                    Dim currentHash = HashPasswordMD5(CurrentPasswordTxt.Text)
                    isPasswordCorrect = (String.Compare(currentHash, storedHash, StringComparison.OrdinalIgnoreCase) = 0)
                Else
                    ' Unknown hash format
                    MessageBox.Show("Unknown password format in database. Please contact administrator.",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                If Not isPasswordCorrect Then
                    MessageBox.Show("Current password is incorrect.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
                    CurrentPasswordTxt.Clear()
                    CurrentPasswordTxt.Focus()
                    Return False
                End If

                ' Update to New Password - Use BCRYPT for new passwords
                Dim newHash = HashPasswordBCrypt(NewPasswordTxt.Text)

                Dim updateQuery As String = "UPDATE customer_data SET password_hash = @newHash WHERE customer_id = @id"
                Using cmd As New MySqlCommand(updateQuery, conn)
                    cmd.Parameters.AddWithValue("@newHash", newHash)
                    cmd.Parameters.AddWithValue("@id", CustomerId)

                    Dim rowsAffected = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        Return True
                    Else
                        MessageBox.Show("Failed to update password. Please try again.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show($"Database error: {ex.Message}", "Database Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "System Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return False
    End Function

    ' MD5 Hashing for old passwords
    Private Function HashPasswordMD5(password As String) As String
        If String.IsNullOrEmpty(password) Then Return String.Empty

        Using md5Hash As MD5 = MD5.Create()
            Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password))
            Dim sBuilder As New StringBuilder()
            For i As Integer = 0 To data.Length - 1
                sBuilder.Append(data(i).ToString("x2"))
            Next
            Return sBuilder.ToString()
        End Using
    End Function

    ' BCRYPT Hashing for new passwords (install BCrypt.Net-Next via NuGet)
    Private Function HashPasswordBCrypt(password As String) As String
        If String.IsNullOrEmpty(password) Then Return String.Empty
        Return BCrypt.Net.BCrypt.HashPassword(password)
    End Function

    Private Function VerifyBCryptPassword(password As String, hash As String) As Boolean
        If String.IsNullOrEmpty(password) OrElse String.IsNullOrEmpty(hash) Then Return False
        Return BCrypt.Net.BCrypt.Verify(password, hash)
    End Function

    ' Helper function to test common passwords
    Private Sub TestCommonPasswords(email As String, customerId As Integer, conn As MySqlConnection)
        ' Based on your database dump, passwords follow patterns:
        ' customer1@gmail.com -> password1
        ' customer2@gmail.com -> password2
        ' etc.

        Debug.WriteLine("DEBUG: Testing password patterns...")

        ' Pattern 1: password + customer number
        Dim customerNumberMatch = System.Text.RegularExpressions.Regex.Match(email, "customer(\d+)")
        If customerNumberMatch.Success Then
            Dim num = customerNumberMatch.Groups(1).Value
            Dim testPassword = "password" & num
            Dim testHash = HashPassword(testPassword)
            Debug.WriteLine($"DEBUG: Testing 'password{num}' -> hash: {testHash}")

            ' Check if this hash matches
            Dim checkQuery = "SELECT customer_id FROM customer_data WHERE customer_id = @id AND password_hash = @hash"
            Using cmd As New MySqlCommand(checkQuery, conn)
                cmd.Parameters.AddWithValue("@id", customerId)
                cmd.Parameters.AddWithValue("@hash", testHash)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not Convert.IsDBNull(result) Then
                    Debug.WriteLine($"DEBUG: FOUND! Password is 'password{num}'")
                    MessageBox.Show($"Try using 'password{num}' as your current password", "Hint",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        End If

        ' Pattern 2: Just the number
        If customerNumberMatch.Success Then
            Dim num = customerNumberMatch.Groups(1).Value
            Dim testPassword = num
            Dim testHash = HashPassword(testPassword)
            Debug.WriteLine($"DEBUG: Testing '{num}' -> hash: {testHash}")
        End If
    End Sub

    ' MD5 Hashing to match database format
    Private Function HashPassword(password As String) As String
        If String.IsNullOrEmpty(password) Then
            Debug.WriteLine("DEBUG: HashPassword called with empty string")
            Return String.Empty
        End If

        Debug.WriteLine($"DEBUG: Hashing password: '{password}'")

        Using md5Hash As MD5 = MD5.Create()
            Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password))
            Dim sBuilder As New StringBuilder()
            For i As Integer = 0 To data.Length - 1
                sBuilder.Append(data(i).ToString("x2"))
            Next
            Dim result = sBuilder.ToString()
            Debug.WriteLine($"DEBUG: Hash result: {result}")
            Return result
        End Using
    End Function

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ' Provide a property to check if password was changed
    Public ReadOnly Property PasswordChanged As Boolean
        Get
            Return _passwordChanged
        End Get
    End Property

    ' Handle Enter key for password fields
    Private Sub PasswordFields_KeyDown(sender As Object, e As KeyEventArgs) Handles _
        CurrentPasswordTxt.KeyDown, NewPasswordTxt.KeyDown, ConfirmPasswordTxt.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SaveBtn.PerformClick()
        End If
    End Sub

    ' Form closing event
    Private Sub ChangePassword_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' If not saved and user is closing with X button
        If Not _passwordChanged AndAlso e.CloseReason = CloseReason.UserClosing Then
            Dim result = MessageBox.Show("Are you sure you want to cancel password change?",
                                       "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub
End Class