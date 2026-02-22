Imports System.Windows.Forms.Design

Public Class ForgotPassword
    Public Event SendCodeRequested()

    Private Sub ButtonRounded2_Click(sender As Object, e As EventArgs) Handles ButtonRounded2.Click
        ' Go back to login - Clear ALL stored forgot password states
        GlobalState.ClearForgotPasswordState()

        Dim parentContainer = TryCast(Me.Parent, Control)
        If parentContainer IsNot Nothing Then
            parentContainer.Controls.Remove(Me)
            Me.Dispose()
        End If

        ' Try to find and restore the login view
        Dim loginForm = TryCast(FindForm(), sparxLogin)
        If loginForm IsNot Nothing Then
            loginForm.RestoreFromForgotPassword()
        End If
    End Sub

    Private Async Sub ButtonRounded1_Click(sender As Object, e As EventArgs) Handles ButtonRounded1.Click
        ' The "Send Code" button click handler

        ' 1. Validate Phone Number Input
        Dim phoneInput As String = If(EmailInput IsNot Nothing, EmailInput.Text.Trim(), String.Empty)
        Dim username As String = GlobalState.ForgotPasswordUsername

        If String.IsNullOrEmpty(username) Then
            MessageBox.Show("Username context lost. Please return to login and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If String.IsNullOrEmpty(phoneInput) OrElse phoneInput.Length <> 11 OrElse Not phoneInput.All(Function(c) Char.IsDigit(c)) Then
            MessageBox.Show("Please enter a valid 11-digit phone number.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ButtonRounded1.Enabled = False
        ButtonRounded1.Text = "Sending..."

        ' 2. Call the API to send the code to the phone number entered
        Dim purpose As String = "password_reset"

        Try
            ' Use the NEW method that sends both username and phone number
            Dim result = Await APIService.SendCodeAsync(username, phoneInput, purpose)
            Dim success = result.Item1
            Dim responseMessage = result.Item2

            If success Then
                ' 3. Store phone number globally (username is already stored)
                GlobalState.UserPhoneNumber = phoneInput

                MessageBox.Show(responseMessage, "Code Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)
                RaiseEvent SendCodeRequested()
            Else
                ' 4. Show error message
                MessageBox.Show(responseMessage, "Error Sending Code", MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' Optionally: Clear phone if verification fails
                If responseMessage.Contains("not match") Or responseMessage.Contains("not found") Or responseMessage.Contains("invalid") Then
                    GlobalState.UserPhoneNumber = String.Empty
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Network error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ButtonRounded1.Enabled = True
            ButtonRounded1.Text = "Send Code"
        End Try
    End Sub

    Private Sub ForgotPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Display the username for confirmation
        If lblEmail IsNot Nothing AndAlso Not String.IsNullOrEmpty(GlobalState.ForgotPasswordUsername) Then
            lblEmail.Text = "Username: " & GlobalState.ForgotPasswordUsername
        End If

        ' Clear any previous phone number
        GlobalState.UserPhoneNumber = String.Empty

        ' Set focus to phone input
        If EmailInput IsNot Nothing Then
            EmailInput.Focus()
        End If
    End Sub

    Private Sub EmailInput_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EmailInput.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub EmailInput_TextChanged(sender As Object, e As EventArgs) Handles EmailInput.TextChanged
        Dim maxLen As Integer = 11
        If EmailInput.TextLength > maxLen Then
            EmailInput.Text = EmailInput.Text.Substring(0, maxLen)
            EmailInput.SelectionStart = EmailInput.TextLength
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
    End Sub

    Private Sub lblEmail_Click(sender As Object, e As EventArgs) Handles lblEmail.Click
    End Sub

    Private Sub lblUserLevel_Click(sender As Object, e As EventArgs) Handles lblUserLevel.Click
    End Sub

    Private Sub pnlLoginCard_Paint(sender As Object, e As PaintEventArgs) Handles pnlLoginCard.Paint
    End Sub
End Class