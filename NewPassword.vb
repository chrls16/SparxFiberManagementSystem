Imports System.Windows.Forms.Design

Public Class NewPassword
    ' Use the existing designer textboxes
    Private WithEvents txtNewPassword As TextBox ' This will be txtEmail from designer
    Private WithEvents txtConfirmPassword As TextBox ' This will be TextBox1 from designer

    ' Store password values
    Private newPasswordValue As String = ""
    Private confirmPasswordValue As String = ""

    Private Async Sub ButtonRounded1_Click(sender As Object, e As EventArgs) Handles ButtonRounded1.Click
        ' The "Set New Password" button click handler

        ' Use the stored values
        Dim newPw As String = newPasswordValue
        Dim confirm As String = confirmPasswordValue

        ' Debug: Show what we're comparing
        ' MessageBox.Show($"New: '{newPw}', Confirm: '{confirm}'")

        ' Validate passwords match
        If newPw <> confirm Then
            MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If newPw.Length < 6 Then
            MessageBox.Show("Password must be at least 6 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ButtonRounded1.Enabled = False
        ButtonRounded1.Text = "Updating..."

        ' 1. Call API to change the password using the stored USERNAME
        Dim username As String = GlobalState.ForgotPasswordUsername

        If String.IsNullOrEmpty(username) Then
            MessageBox.Show("User context lost. Please start over.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ButtonRounded1.Enabled = True
            ButtonRounded1.Text = "Set New Password"
            Return
        End If

        Try
            ' Use the NEW method that changes password for specific username
            Dim result = Await APIService.ChangePasswordAsync(username, newPw)
            Dim success = result.Item1
            Dim responseMessage = result.Item2

            If success Then
                MessageBox.Show("Password updated successfully for user: " & username & ". Please log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Clear the stored states
                GlobalState.ClearForgotPasswordState()

                ' 2. Navigate back to the main login view
                ButtonRounded4_Click(sender, e)
            Else
                ' Handle API failure for password update
                MessageBox.Show(responseMessage, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Network error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ButtonRounded1.Enabled = True
            ButtonRounded1.Text = "Set New Password"
        End Try
    End Sub

    Private Sub ButtonRounded4_Click(sender As Object, e As EventArgs) Handles ButtonRounded4.Click
        ' Back button / Return to Login logic

        ' Clear all states
        GlobalState.ClearForgotPasswordState()

        Dim parentContainer = TryCast(Me.Parent, Control)
        If parentContainer Is Nothing Then Return
        parentContainer.Controls.Remove(Me)
        Me.Dispose()

        ' Restore the main Login view
        Dim parentForm = TryCast(FindForm(), sparxLogin)
        If parentForm IsNot Nothing Then
            parentForm.RestoreFromForgotPassword()
        End If
    End Sub

    Private Sub NewPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the textbox references to use designer-created controls
        InitializePasswordControls()

        ' Set focus to new password field
        If txtNewPassword IsNot Nothing Then
            txtNewPassword.Focus()
        End If
    End Sub

    Private Sub InitializePasswordControls()
        ' Get references to the designer-created controls
        txtNewPassword = txtEmail ' Use the txtEmail from designer as new password field
        txtConfirmPassword = TextBox1 ' Use the TextBox1 from designer as confirm password field

        ' Configure the textboxes for password entry
        If txtNewPassword IsNot Nothing Then
            txtNewPassword.PasswordChar = "●"
            txtNewPassword.PlaceholderText = "Enter New Password"
            txtNewPassword.Text = ""
            RemoveHandler txtNewPassword.TextChanged, AddressOf txtNewPassword_TextChanged
            AddHandler txtNewPassword.TextChanged, AddressOf txtNewPassword_TextChanged
        End If

        If txtConfirmPassword IsNot Nothing Then
            txtConfirmPassword.PasswordChar = "●"
            txtConfirmPassword.PlaceholderText = "Confirm New Password"
            txtConfirmPassword.Text = ""
            RemoveHandler txtConfirmPassword.TextChanged, AddressOf txtConfirmPassword_TextChanged
            AddHandler txtConfirmPassword.TextChanged, AddressOf txtConfirmPassword_TextChanged
        End If
    End Sub

    Private Sub txtNewPassword_TextChanged(sender As Object, e As EventArgs)
        If txtNewPassword IsNot Nothing Then
            newPasswordValue = txtNewPassword.Text.Trim()
            ValidatePasswords()
        End If
    End Sub

    Private Sub txtConfirmPassword_TextChanged(sender As Object, e As EventArgs)
        If txtConfirmPassword IsNot Nothing Then
            confirmPasswordValue = txtConfirmPassword.Text.Trim()
            ValidatePasswords()
        End If
    End Sub

    ' Add a method to validate passwords in real-time
    Private Sub ValidatePasswords()
        If String.IsNullOrEmpty(newPasswordValue) OrElse String.IsNullOrEmpty(confirmPasswordValue) Then
            ' Reset to default color
            ButtonRounded1.BackColor = Color.FromArgb(70, 130, 255) ' Original blue
            Return
        End If

        If newPasswordValue = confirmPasswordValue AndAlso newPasswordValue.Length >= 6 Then
            ' Passwords match and are valid
            ButtonRounded1.BackColor = Color.FromArgb(76, 175, 80) ' Green
        Else
            ' Passwords don't match or are too short
            ButtonRounded1.BackColor = Color.FromArgb(244, 67, 54) ' Red
        End If
    End Sub

    ' Also update the button text to be clearer
    Private Sub UpdateButtonText()
        ButtonRounded1.Text = "Set New Password"
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        ' Empty handler
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        ' Empty handler
    End Sub


End Class