Imports MySqlConnector
Imports BCrypt.Net

Public Class ChangePasswordStaff

    Public Property TargetStaffID As String

    Dim connString As String = "server=localhost;user=root;password=;database=sparx;Convert Zero Datetime=True;Allow Zero Datetime=True;"

    Private Sub CurrentPasswordTxt_TextChanged(sender As Object, e As EventArgs) Handles CurrentPasswordTxt.TextChanged

    End Sub

    Private Sub NewPasswordTxt_TextChanged(sender As Object, e As EventArgs) Handles NewPasswordTxt.TextChanged
        CheckPasswordStrength(NewPasswordTxt.Text)
    End Sub

    Private Sub ConfirmPasswordTxt_TextChanged(sender As Object, e As EventArgs) Handles ConfirmPasswordTxt.TextChanged

    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        ' 1. Basic Validation
        If String.IsNullOrWhiteSpace(CurrentPasswordTxt.Text) OrElse
       String.IsNullOrWhiteSpace(NewPasswordTxt.Text) Then
            MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If NewPasswordTxt.Text <> ConfirmPasswordTxt.Text Then
            MessageBox.Show("New passwords do not match!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()

                ' 2. Retrieve the stored BCrypt hash (using password_hash column)
                Dim storedHash As String = ""
                Dim fetchQuery As String = "SELECT password_hash FROM staff WHERE staff_id = @id"

                Using fCmd As New MySqlCommand(fetchQuery, conn)
                    fCmd.Parameters.AddWithValue("@id", TargetStaffID)
                    Dim result = fCmd.ExecuteScalar()

                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        storedHash = result.ToString()
                    Else
                        MessageBox.Show("Staff record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End Using

                ' 3. Verify current password (using the full library path to avoid BC30456)
                If Not BCrypt.Net.BCrypt.Verify(CurrentPasswordTxt.Text, storedHash) Then
                    MessageBox.Show("The current password you entered is incorrect.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                ' 4. Generate NEW hash for the new password
                Dim newHashedPassword As String = BCrypt.Net.BCrypt.HashPassword(NewPasswordTxt.Text)

                ' 5. Update the database (using password_hash column)
                Dim updateQuery As String = "UPDATE staff SET password_hash = @newHash WHERE staff_id = @id"
                Using uCmd As New MySqlCommand(updateQuery, conn)
                    uCmd.Parameters.AddWithValue("@newHash", newHashedPassword)
                    uCmd.Parameters.AddWithValue("@id", TargetStaffID)
                    uCmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            ' This will catch any remaining MySQL or Logic errors
            MessageBox.Show("Database Error: " & ex.Message)
        End Try
    End Sub

    Private Sub ChangePasswordStaff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Hide text at startup using the System default (dots)
        CurrentPasswordTxt.UseSystemPasswordChar = True
        NewPasswordTxt.UseSystemPasswordChar = True
        ConfirmPasswordTxt.UseSystemPasswordChar = True

        ' 2. Ensure checkboxes are unchecked
        ShowCurrentPasswordCheck.Checked = False
        ShowNewPasswordCheck.Checked = False
    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ToggleVisibility(chk As CheckBox, txt As TextBox)
        txt.UseSystemPasswordChar = Not chk.Checked
    End Sub

    ' Event for Current Password visibility
    Private Sub ShowCurrentPasswordCheck_CheckedChanged(sender As Object, e As EventArgs) Handles ShowCurrentPasswordCheck.CheckedChanged
        ToggleVisibility(ShowCurrentPasswordCheck, CurrentPasswordTxt)
    End Sub

    ' Event for New & Confirm Password visibility
    Private Sub ShowNewPasswordCheck_CheckedChanged(sender As Object, e As EventArgs) Handles ShowNewPasswordCheck.CheckedChanged
        ToggleVisibility(ShowNewPasswordCheck, NewPasswordTxt)
        ToggleVisibility(ShowNewPasswordCheck, ConfirmPasswordTxt)
    End Sub

    Private Sub CheckPasswordStrength(password As String)
        Dim strength As String = "Weak"
        Dim labelColor As Color = Color.Red

        ' Logic:
        ' Weak: < 6 characters
        ' Medium: >= 6 characters and has at least one number
        ' Strong: >= 8 characters and has a number and a symbol/uppercase

        If password.Length >= 8 AndAlso
       System.Text.RegularExpressions.Regex.IsMatch(password, "[0-9]") AndAlso
       System.Text.RegularExpressions.Regex.IsMatch(password, "[A-Z]") Then
            strength = "Strong"
            labelColor = Color.Green
        ElseIf password.Length >= 6 Then
            strength = "Medium"
            labelColor = Color.Orange
        ElseIf password.Length = 0 Then
            strength = ""
        End If

        ' Update the label
        PasswordRequirementsLabel.Text = "Strength: " & strength
        PasswordRequirementsLabel.ForeColor = labelColor
    End Sub

    Private Sub PasswordRequirementsLabel_Click(sender As Object, e As EventArgs) Handles PasswordRequirementsLabel.Click

    End Sub

End Class