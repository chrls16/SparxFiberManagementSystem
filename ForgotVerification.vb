Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Windows.Forms.Design

Public Class ForgotVerification

    Private Async Sub ButtonRounded3_Click(sender As Object, e As EventArgs) Handles ButtonRounded3.Click
        ' The "Verify" button click handler

        Dim codeInput As String = If(Verifycode IsNot Nothing, Verifycode.Text.Trim(), String.Empty)
        ' Retrieve BOTH stored username and phone number
        Dim username As String = GlobalState.ForgotPasswordUsername
        Dim phoneNumber As String = GlobalState.UserPhoneNumber

        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(phoneNumber) Then
            MessageBox.Show("Context lost. Please return to the login screen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If codeInput.Length <> 6 OrElse Not codeInput.All(AddressOf Char.IsDigit) Then
            MessageBox.Show("Please enter the 6-digit code.", "Invalid Code Format", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ButtonRounded3.Enabled = False
        ButtonRounded3.Text = "Verifying..."

        ' 1. Call API to verify the code with BOTH identifiers
        Dim purpose As String = "password_reset"

        Try
            ' Use the NEW method that verifies using both username and phone number
            Dim result = Await APIService.VerifyCodeAsync(username, phoneNumber, purpose, codeInput)
            Dim success = result.Item1
            Dim responseMessage = result.Item2

            If success Then
                MessageBox.Show(responseMessage, "Verification Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' 2. Transition to NewPassword view
                Dim parentContainer = TryCast(Me.Parent, Control)
                If parentContainer Is Nothing Then Return

                Dim newPasswordView As New NewPassword()
                newPasswordView.Dock = DockStyle.Fill
                parentContainer.Controls.Add(newPasswordView)
                newPasswordView.BringToFront()

                parentContainer.Controls.Remove(Me)
                Me.Dispose()
            Else
                ' 3. Show error
                MessageBox.Show(responseMessage, "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Network error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ButtonRounded3.Enabled = True
            ButtonRounded3.Text = "Verify"
        End Try
    End Sub

    Private Sub ButtonRounded5_Click_1(sender As Object, e As EventArgs) Handles ButtonRounded5.Click
        ' Go back to ForgotPassword view (Resend button)
        ' Clear the phone number but keep the username
        GlobalState.UserPhoneNumber = String.Empty

        Dim parentContainer = Me.Parent
        If parentContainer Is Nothing Then Return

        parentContainer.Controls.Remove(Me)
        Me.Dispose()

        Dim fp = parentContainer.Controls.OfType(Of ForgotPassword).FirstOrDefault
        If fp Is Nothing Then
            fp = New ForgotPassword()
            fp.Dock = DockStyle.Fill
            parentContainer.Controls.Add(fp)
        End If
        fp.BringToFront()
    End Sub

    Private Sub ForgotVerification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Display both username and phone number
            If lblEmail IsNot Nothing Then
                lblEmail.Text = $"User: {GlobalState.ForgotPasswordUsername}" & vbCrLf &
                              $"Code sent to: {GlobalState.UserPhoneNumber}"
            End If

            ' Set focus to verification code input
            If Verifycode IsNot Nothing Then
                Verifycode.Focus()
            End If
        Catch
        End Try
    End Sub

    ' (Original validation/limit handlers retained)
    Private Sub Verifycode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Verifycode.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Verifycode_TextChanged(sender As Object, e As EventArgs) Handles Verifycode.TextChanged
        Dim maxLen As Integer = 6
        If Verifycode.TextLength > maxLen Then
            Verifycode.Text = Verifycode.Text.Substring(0, maxLen)
            Verifycode.SelectionStart = Verifycode.TextLength
        End If
    End Sub

    ' (Original unused handlers)
    Private Sub pnlEmail_Paint(sender As Object, e As PaintEventArgs)
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
    End Sub
    Private Sub lblEmail_Click(sender As Object, e As EventArgs) Handles lblEmail.Click
    End Sub
    Private Sub ButtonRounded5_Click(sender As Object, e As EventArgs)
    End Sub
    Private Sub lblUserLevel_Click(sender As Object, e As EventArgs) Handles lblUserLevel.Click
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs)
    End Sub
    Private Sub ButtonRounded4_Click(sender As Object, e As EventArgs) Handles ButtonRounded4.Click
        ' Back button - go to ForgotPassword
        GlobalState.UserPhoneNumber = String.Empty

        Dim parentContainer = TryCast(Me.Parent, Control)
        If parentContainer Is Nothing Then Return

        parentContainer.Controls.Remove(Me)
        Me.Dispose()

        Dim fp = parentContainer.Controls.OfType(Of ForgotPassword).FirstOrDefault
        If fp Is Nothing Then
            fp = New ForgotPassword()
            fp.Dock = DockStyle.Fill
            parentContainer.Controls.Add(fp)
        End If
        fp.BringToFront()
    End Sub
    Private Sub pnlEmail_Paint_1(sender As Object, e As PaintEventArgs) Handles pnlEmail.Paint
    End Sub
    Private Sub ApplyFlatNoHover(btn As Button)
    End Sub

    Private Sub pnlLoginCard_Paint(sender As Object, e As PaintEventArgs) Handles pnlLoginCard.Paint
    End Sub
End Class