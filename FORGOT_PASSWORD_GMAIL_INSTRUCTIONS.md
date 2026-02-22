# 📧 Forgot Password with Gmail Verification - Step-by-Step Instructions

This guide will help you implement a forgot password feature that sends a verification code to the user's Gmail and verifies it.

---

## 🔑 **Prerequisites: Gmail App Password**

Before you start, you need to set up Gmail App Password:

1. **Enable 2-Factor Authentication** on your Google account
   - Go to: https://myaccount.google.com/security
   - Enable 2-Step Verification

2. **Generate App Password**
   - Go to: https://myaccount.google.com/apppasswords
   - Select "Mail" and your device
   - Copy the 16-character password (you'll need it later)

---

## 📝 **Step 1: Create EmailService.vb**

**Purpose:** Handles sending emails via Gmail SMTP

1. In Visual Studio, right-click your project → **Add** → **Class**
2. Name it: `EmailService.vb`
3. Copy and paste this code:

```vb
Imports System.Net
Imports System.Net.Mail

Public Class EmailService
    ' ⚠️ IMPORTANT: Replace these with your Gmail credentials
    Private Const SMTP_HOST As String = "smtp.gmail.com"
    Private Const SMTP_PORT As Integer = 587
    Private Const SMTP_USERNAME As String = "your-email@gmail.com" ' Change this!
    Private Const SMTP_PASSWORD As String = "your-16-char-app-password" ' Change this!

    ''' <summary>
    ''' Sends verification code email to user
    ''' </summary>
    Public Shared Function SendVerificationCode(toEmail As String, verificationCode As String) As Boolean
        Try
            ' Validate inputs
            If String.IsNullOrWhiteSpace(toEmail) OrElse String.IsNullOrWhiteSpace(verificationCode) Then
                Return False
            End If

            ' Create email message
            Using mail As New MailMessage()
                mail.From = New MailAddress(SMTP_USERNAME, "SPARX Management System")
                mail.To.Add(New MailAddress(toEmail))
                mail.Subject = "Password Reset Verification Code"
                
                ' Create HTML email body
                mail.Body = $"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: Arial, sans-serif; padding: 20px; }}
        .code {{ font-size: 32px; font-weight: bold; color: #4682FF; text-align: center; padding: 20px; background: #f0f0f0; border-radius: 8px; }}
        .container {{ max-width: 600px; margin: 0 auto; }}
    </style>
</head>
<body>
    <div class='container'>
        <h2>Password Reset Verification Code</h2>
        <p>Your verification code is:</p>
        <div class='code'>{verificationCode}</div>
        <p>This code expires in 10 minutes.</p>
        <p>If you didn't request this, please ignore this email.</p>
    </div>
</body>
</html>"
                mail.IsBodyHtml = True

                ' Configure SMTP client
                Using smtpClient As New SmtpClient(SMTP_HOST, SMTP_PORT)
                    smtpClient.EnableSsl = True
                    smtpClient.UseDefaultCredentials = False
                    smtpClient.Credentials = New NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD)
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network

                    ' Send email
                    smtpClient.Send(mail)
                    Return True
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"Error sending email: {ex.Message}")
            Return False
        End Try
    End Function
End Class
```

4. **⚠️ Don't forget:** Update `SMTP_USERNAME` and `SMTP_PASSWORD` with your actual Gmail credentials!

---

## 📝 **Step 2: Create PasswordResetService.vb**

**Purpose:** Generates, stores, and validates verification codes

1. Right-click project → **Add** → **Class**
2. Name it: `PasswordResetService.vb`
3. Copy and paste this code:

```vb
Imports System.Collections.Generic

Public Class PasswordResetService
    ' Temporary storage for verification codes (in memory)
    Private Shared ReadOnly verificationCodes As New Dictionary(Of String, VerificationCodeInfo)()
    Private Shared ReadOnly lockObject As New Object()
    Private Const CODE_EXPIRY_MINUTES As Integer = 10

    ' Inner class to store code information
    Private Class VerificationCodeInfo
        Public Property Code As String
        Public Property Email As String
        Public Property ExpiryTime As DateTime
        Public Property Attempts As Integer = 0
        Public Const MAX_ATTEMPTS As Integer = 5

        Public Sub New(code As String, email As String)
            Me.Code = code
            Me.Email = email
            Me.ExpiryTime = DateTime.Now.AddMinutes(CODE_EXPIRY_MINUTES)
        End Sub

        Public ReadOnly Property IsExpired As Boolean
            Get
                Return DateTime.Now > ExpiryTime
            End Get
        End Property
    End Class

    ''' <summary>
    ''' Generates a random 6-digit code
    ''' </summary>
    Public Shared Function GenerateVerificationCode() As String
        Dim random As New Random()
        Return random.Next(100000, 999999).ToString()
    End Function

    ''' <summary>
    ''' Stores verification code for an email
    ''' </summary>
    Public Shared Sub StoreVerificationCode(email As String, code As String)
        SyncLock lockObject
            Dim emailKey As String = email.ToLower()
            
            ' Remove old code if exists
            If verificationCodes.ContainsKey(emailKey) Then
                verificationCodes.Remove(emailKey)
            End If

            ' Store new code
            verificationCodes(emailKey) = New VerificationCodeInfo(code, email)
        End SyncLock
    End Sub

    ''' <summary>
    ''' Validates if the code matches for the email
    ''' </summary>
    Public Shared Function ValidateVerificationCode(email As String, code As String) As Boolean
        SyncLock lockObject
            Dim emailKey As String = email.ToLower()

            ' Check if code exists
            If Not verificationCodes.ContainsKey(emailKey) Then
                Return False
            End If

            Dim codeInfo As VerificationCodeInfo = verificationCodes(emailKey)

            ' Check if expired
            If codeInfo.IsExpired Then
                verificationCodes.Remove(emailKey)
                Return False
            End If

            ' Check if too many attempts
            If codeInfo.Attempts >= VerificationCodeInfo.MAX_ATTEMPTS Then
                verificationCodes.Remove(emailKey)
                Return False
            End If

            ' Increment attempts
            codeInfo.Attempts += 1

            ' Check if code matches
            If codeInfo.Code = code Then
                ' Valid! Remove code so it can't be used again
                verificationCodes.Remove(emailKey)
                Return True
            End If

            Return False
        End SyncLock
    End Function
End Class
```

---

## 📝 **Step 3: Update ForgotPassword.vb**

**Purpose:** Validate email, generate code, and send email

1. Open `ForgotPassword.vb`
2. Add these imports at the top:

```vb
Imports System.Configuration
Imports MySqlConnector
Imports System.Text.RegularExpressions
```

3. Add connection string (after class declaration):

```vb
Private ReadOnly CONNECTION_STRING As String =
    ConfigurationManager.ConnectionStrings("SparxDb").ConnectionString
```

4. Update the event declaration (change this line):

```vb
' OLD:
Public Event SendCodeRequested()

' NEW:
Public Event SendCodeRequested(email As String)
```

5. Replace the `ButtonRounded1_Click` method with:

```vb
Private Sub ButtonRounded1_Click(sender As Object, e As EventArgs) Handles ButtonRounded1.Click
    ' Step 1: Get email from textbox
    Dim email As String = If(txtEmail IsNot Nothing, txtEmail.Text.Trim().ToLower(), String.Empty)

    ' Step 2: Validate email is not empty
    If String.IsNullOrWhiteSpace(email) Then
        MessageBox.Show("Please enter your email address.", "Missing Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Return
    End If

    ' Step 3: Validate email format
    If Not IsValidEmail(email) Then
        MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Return
    End If

    ' Step 4: Check if email exists in database
    If Not EmailExistsInDatabase(email) Then
        MessageBox.Show("No account found with this email address.", "Email Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Return
    End If

    ' Step 5: Disable button to prevent multiple clicks
    ButtonRounded1.Enabled = False
    ButtonRounded1.Text = "Sending..."

    Try
        ' Step 6: Generate verification code
        Dim verificationCode As String = PasswordResetService.GenerateVerificationCode()

        ' Step 7: Store the code
        PasswordResetService.StoreVerificationCode(email, verificationCode)

        ' Step 8: Send email
        Dim emailSent As Boolean = EmailService.SendVerificationCode(email, verificationCode)

        If emailSent Then
            MessageBox.Show($"Verification code has been sent to {email}. Please check your inbox.", "Code Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RaiseEvent SendCodeRequested(email) ' Navigate to verification screen
        Else
            MessageBox.Show("Failed to send verification code. Please try again later.", "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    Catch ex As Exception
        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    Finally
        ' Step 9: Re-enable button
        ButtonRounded1.Enabled = True
        ButtonRounded1.Text = "Send Verification Code"
    End Try
End Sub
```

6. Add these helper functions at the end of the class (before `End Class`):

```vb
''' <summary>
''' Validates email format using regex
''' </summary>
Private Function IsValidEmail(email As String) As Boolean
    If String.IsNullOrWhiteSpace(email) Then
        Return False
    End If
    Try
        Dim pattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
        Return Regex.IsMatch(email, pattern)
    Catch
        Return False
    End Try
End Function

''' <summary>
''' Checks if email exists in customer table
''' </summary>
Private Function EmailExistsInDatabase(email As String) As Boolean
    Try
        Using conn As New MySqlConnection(CONNECTION_STRING)
            conn.Open()
            Dim query As String = "SELECT COUNT(*) FROM customer WHERE email_address = @email"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@email", email)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return count > 0
            End Using
        End Using
    Catch ex As Exception
        MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return False
    End Try
End Function
```

---

## 📝 **Step 4: Update sparxLogin.vb**

**Purpose:** Pass email to verification view

1. Open `sparxLogin.vb`
2. Find the `OnSendCodeRequested` method (around line 205)
3. Replace it with:

```vb
Private Sub OnSendCodeRequested(email As String)
    If forgotVerificationView Is Nothing Then
        forgotVerificationView = New ForgotVerification()
        forgotVerificationView.Dock = DockStyle.Fill
    End If
    ' Pass email to verification view
    forgotVerificationView.SetEmail(email)
    If Not pnlLoginCard.Controls.Contains(forgotVerificationView) Then
        pnlLoginCard.Controls.Add(forgotVerificationView)
    End If
    forgotVerificationView.BringToFront()
End Sub
```

4. Find the line where you add the handler (around line 196):

```vb
AddHandler ForgotView.SendCodeRequested, AddressOf OnSendCodeRequested
```

This should already work because we updated the event signature in ForgotPassword.vb.

---

## 📝 **Step 5: Update ForgotVerification.vb**

**Purpose:** Validate code and handle resend

1. Open `ForgotVerification.vb`
2. Add a field to store email (at the top of the class):

```vb
Private userEmail As String = String.Empty
```

3. Add method to set email (before `ButtonRounded3_Click`):

```vb
Public Sub SetEmail(email As String)
    userEmail = email
    ' Update label to show email
    If Label1 IsNot Nothing Then
        Label1.Text = $"A verification code has been sent to {email}"
    End If
End Sub
```

4. Replace the `ButtonRounded3_Click` method (Verify Code button):

```vb
Private Sub ButtonRounded3_Click(sender As Object, e As EventArgs) Handles ButtonRounded3.Click
    ' Step 1: Get code from textbox
    Dim code As String = If(Verifycode IsNot Nothing, Verifycode.Text.Trim(), String.Empty)

    ' Step 2: Validate code is entered
    If String.IsNullOrWhiteSpace(code) Then
        MessageBox.Show("Please enter the verification code.", "Missing Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Return
    End If

    ' Step 3: Validate code length
    If code.Length <> 6 Then
        MessageBox.Show("Verification code must be 6 digits.", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Return
    End If

    ' Step 4: Validate email exists
    If String.IsNullOrWhiteSpace(userEmail) Then
        MessageBox.Show("Email not found. Please start over.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return
    End If

    ' Step 5: Validate the code
    If PasswordResetService.ValidateVerificationCode(userEmail, code) Then
        ' Code is valid! Navigate to NewPassword
        Dim parentContainer = TryCast(Me.Parent, Control)
        If parentContainer Is Nothing Then
            Return
        End If

        Dim newPasswordView As New NewPassword()
        newPasswordView.SetEmail(userEmail) ' Pass email to next form
        newPasswordView.Dock = DockStyle.Fill
        parentContainer.Controls.Add(newPasswordView)
        newPasswordView.BringToFront()
    Else
        MessageBox.Show("Invalid or expired verification code. Please try again.", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ' Clear the input
        If Verifycode IsNot Nothing Then
            Verifycode.Text = String.Empty
        End If
    End If
End Sub
```

5. Replace the `ButtonRounded4_Click` method (Resend Code button):

```vb
Private Sub ButtonRounded4_Click(sender As Object, e As EventArgs) Handles ButtonRounded4.Click
    If String.IsNullOrWhiteSpace(userEmail) Then
        MessageBox.Show("Email not found. Please start over.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return
    End If

    ButtonRounded4.Enabled = False
    ButtonRounded4.Text = "Sending..."

    Try
        ' Generate new code
        Dim verificationCode As String = PasswordResetService.GenerateVerificationCode()
        
        ' Store new code
        PasswordResetService.StoreVerificationCode(userEmail, verificationCode)
        
        ' Send email
        Dim emailSent As Boolean = EmailService.SendVerificationCode(userEmail, verificationCode)
        
        If emailSent Then
            MessageBox.Show($"A new verification code has been sent to {userEmail}.", "Code Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If Verifycode IsNot Nothing Then
                Verifycode.Text = String.Empty
            End If
        Else
            MessageBox.Show("Failed to send verification code. Please try again later.", "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    Catch ex As Exception
        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    Finally
        ButtonRounded4.Enabled = True
        ButtonRounded4.Text = "Resend Code"
    End Try
End Sub
```

---

## 📝 **Step 6: Update NewPassword.vb (Optional)**

If you want the password reset to work end-to-end, you'll need to update `NewPassword.vb` too. The guide in `IMPLEMENTATION_GUIDE.md` has details for this step.

---

## ✅ **Testing Checklist**

1. ✅ Test with valid email that exists in database
2. ✅ Test with email that doesn't exist
3. ✅ Test with invalid email format
4. ✅ Check email arrives in inbox
5. ✅ Test verification code validation (correct code)
6. ✅ Test verification code validation (wrong code)
7. ✅ Test resend code functionality

---

## 🔧 **Troubleshooting**

### Email not sending?
- ✅ Check Gmail App Password is correct (16 characters, no spaces)
- ✅ Check 2FA is enabled on Gmail account
- ✅ Check `SMTP_USERNAME` and `SMTP_PASSWORD` are set correctly in `EmailService.vb`
- ✅ Check firewall/antivirus isn't blocking SMTP port 587
- ✅ Check internet connection

### Code not validating?
- ✅ Check code is exactly 6 digits
- ✅ Check code hasn't expired (10 minutes)
- ✅ Check you're using the same email that received the code

### Database errors?
- ✅ Check connection string in `App.config` is correct
- ✅ Check MySQL server is running
- ✅ Check table name is `customer` and column is `email_address`

---

## 🎯 **Summary**

The flow works like this:

1. **User enters email** → `ForgotPassword.vb` validates it
2. **System generates 6-digit code** → `PasswordResetService.GenerateVerificationCode()`
3. **Code is stored** → `PasswordResetService.StoreVerificationCode()`
4. **Email is sent** → `EmailService.SendVerificationCode()`
5. **User enters code** → `ForgotVerification.vb` validates it
6. **Code is verified** → `PasswordResetService.ValidateVerificationCode()`
7. **User sets new password** → Password updated in database

Good luck! 🚀


