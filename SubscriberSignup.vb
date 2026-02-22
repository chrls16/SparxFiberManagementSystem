Imports System.Configuration
Imports MySqlConnector
Imports BCrypt.Net

Public Class SubscriberSignup

    Private _connectionString As String = Nothing

    Private ReadOnly Property CONNECTION_STRING As String

        Get
            If _connectionString Is Nothing AndAlso Not DesignMode Then
                Try
                    _connectionString = ConfigurationManager.ConnectionStrings("SparxDb").ConnectionString
                Catch
                    _connectionString = String.Empty
                End Try
            End If
            Return If(_connectionString IsNot Nothing, _connectionString, String.Empty)
        End Get

    End Property

    Public Event SignUpCompleted(email As String)
    Public Event SignupRequested(email As String, password As String)

    Private Sub SubscriberSignup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnableScroll()

        Try
            ' Bind known names if present and style them to avoid gray hover background
            Dim ctrl = Me.Controls.Find("LinkBtnLogin", True).FirstOrDefault()
            If ctrl IsNot Nothing Then
                Dim l As LinkLabel = CType(ctrl, LinkLabel)
                AddHandler l.LinkClicked, AddressOf ButtonRounded5_Click
                StyleLoginLink(l)
            End If

            Dim ctrl2 = Me.Controls.Find("LinkBtnSignup", True).FirstOrDefault()
            If ctrl2 IsNot Nothing Then
                Dim l2 As LinkLabel = CType(ctrl2, LinkLabel)
                AddHandler l2.LinkClicked, AddressOf ButtonRounded5_Click
                StyleLoginLink(l2)
            End If

            ' Fallback: bind any LinkLabel whose text contains "Login"
            For Each lnk As LinkLabel In GetAllLinkLabels(Me)
                If lnk.Text IsNot Nothing AndAlso lnk.Text.Trim().ToLower().Contains("login") Then
                    AddHandler lnk.LinkClicked, AddressOf ButtonRounded5_Click
                    StyleLoginLink(lnk)
                End If
            Next

            If PhoneNumber IsNot Nothing Then
                AddHandler PhoneNumber.KeyPress, AddressOf PhoneNumber_KeyPress
                AddHandler PhoneNumber.TextChanged, AddressOf PhoneNumber_TextChanged
            End If

        Catch
        End Try

    End Sub

    Private Sub ButtonRounded3_Click(sender As Object, e As EventArgs) Handles ButtonRounded3.Click

        Dim firstName As String = If(txtFirstName IsNot Nothing, txtFirstName.Text.Trim(), String.Empty)
        Dim lastName As String = If(TxtLastName IsNot Nothing, TxtLastName.Text.Trim(), String.Empty)
        Dim email As String = If(txtEmail IsNot Nothing, txtEmail.Text.Trim(), String.Empty)
        Dim phone As String = If(PhoneNumber IsNot Nothing, PhoneNumber.Text.Trim(), String.Empty)
        Dim password As String = If(password3 IsNot Nothing, password3.Text.Trim(), String.Empty)
        Dim rePassword As String = If(password4 IsNot Nothing, password4.Text.Trim(), String.Empty)

        ' Basic validation
        If String.IsNullOrEmpty(firstName) OrElse String.IsNullOrEmpty(lastName) OrElse String.IsNullOrEmpty(email) OrElse String.IsNullOrEmpty(phone) OrElse String.IsNullOrEmpty(password) Then
            MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim passwordPattern As String = "^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{7,}$"

        If Not System.Text.RegularExpressions.Regex.IsMatch(password, passwordPattern) Then
            MessageBox.Show("Password is too weak!" & vbCrLf &
                        "• Must be at least 7 characters long" & vbCrLf &
                        "• Must contain at least one letter and one number",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            password3.Focus()
            Return
        End If

        If password <> rePassword Then
            MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim emailRegex As New System.Text.RegularExpressions.Regex("^[^@\s]+@[^@\s]+\.[^@\s]+$")
        If Not emailRegex.IsMatch(email) Then
            MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If phone.Length <> 11 OrElse Not IsNumeric(phone) Then
            MessageBox.Show("Phone number must be 11 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim hashedPassword As String = BCrypt.Net.BCrypt.HashPassword(password)

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                ' Check if email already exists
                Dim checkQuery As String = "SELECT COUNT(*) FROM customer_data WHERE email_address = @email"

                Using checkCmd As New MySqlCommand(checkQuery, conn)
                    checkCmd.Parameters.AddWithValue("@email", email)
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("An account with this email already exists.", "Signup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End Using

                Dim insertQuery As String = "INSERT INTO customer_data
                                            (first_name, last_name, contact_number, email_address, password_hash, billing_address)
                                            VALUES (@firstName, @lastName, @phone, @email, @hashedPassword, @billing)"

                Dim rowsAffected As Integer = 0

                Using cmd As New MySqlCommand(insertQuery, conn)
                    cmd.Parameters.AddWithValue("@firstName", firstName)
                    cmd.Parameters.AddWithValue("@lastName", lastName)
                    cmd.Parameters.AddWithValue("@phone", phone)
                    cmd.Parameters.AddWithValue("@email", email)
                    cmd.Parameters.AddWithValue("@hashedPassword", hashedPassword)
                    cmd.Parameters.AddWithValue("@billing", "To be provided")

                    rowsAffected = cmd.ExecuteNonQuery()
                End Using

                If rowsAffected > 0 Then
                    MessageBox.Show("Signup successful! Please contact support to complete your subscription setup.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ClearFields()

                    ' Switch back to login view
                    Dim parentForm = TryCast(Me.FindForm(), sparxLogin)
                    If parentForm IsNot Nothing Then

                        Me.Visible = False

                        parentForm.ShowLoginView()

                        parentForm.txtEmail.Text = email
                        parentForm.txtPassword.Text = ""
                    End If

                Else
                    MessageBox.Show("Signup failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End Using

        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Signup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ClearFields()

        If txtFirstName IsNot Nothing Then txtFirstName.Text = ""
        If TxtLastName IsNot Nothing Then TxtLastName.Text = ""
        If txtEmail IsNot Nothing Then txtEmail.Text = ""
        If PhoneNumber IsNot Nothing Then PhoneNumber.Text = ""
        If password3 IsNot Nothing Then password3.Text = ""
        If password4 IsNot Nothing Then password4.Text = ""

    End Sub

    Private Sub StyleLoginLink(lnk As LinkLabel)

        If lnk Is Nothing Then Return
        lnk.Enabled = True
        lnk.BringToFront()
        lnk.BackColor = Color.Transparent
        lnk.LinkBehavior = LinkBehavior.NeverUnderline
        lnk.LinkColor = Color.RoyalBlue
        lnk.ActiveLinkColor = lnk.LinkColor
        lnk.VisitedLinkColor = lnk.LinkColor
        lnk.TabStop = False
        AddHandler lnk.MouseEnter, Sub(sender As Object, e As EventArgs) lnk.BackColor = Color.Transparent
        AddHandler lnk.MouseLeave, Sub(sender As Object, e As EventArgs) lnk.BackColor = Color.Transparent
        AddHandler lnk.MouseDown, Sub(sender As Object, e As MouseEventArgs) lnk.BackColor = Color.Transparent
        AddHandler lnk.MouseUp, Sub(sender As Object, e As MouseEventArgs) lnk.BackColor = Color.Transparent

    End Sub

    Private Function GetAllLinkLabels(root As Control) As IEnumerable(Of LinkLabel)

        Dim list As New List(Of LinkLabel)
        Dim stack As New Stack(Of Control)
        stack.Push(root)

        While stack.Count > 0
            Dim c = stack.Pop()
            If TypeOf c Is LinkLabel Then list.Add(DirectCast(c, LinkLabel))
            For Each child As Control In c.Controls
                stack.Push(child)
            Next
        End While

        Return list

    End Function

    Private Sub SubscriberSignup_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize

        EnableScroll()

    End Sub

    Private Sub EnableScroll()

        Try
            Dim panel = pnlLoginCard
            If panel Is Nothing Then Return
            panel.AutoScroll = False

            Dim maxBottom As Integer = 0
            For Each c As Control In panel.Controls
                If c.Visible Then
                    maxBottom = Math.Max(maxBottom, c.Bottom)
                End If
            Next

            Dim neededHeight As Integer = Math.Max(maxBottom + 20, panel.ClientSize.Height + 1)
            panel.AutoScrollMinSize = New Size(0, neededHeight)
        Catch
        End Try

    End Sub

    ' Numeric-only input for phone number with max length
    Private Sub PhoneNumber_KeyPress(sender As Object, e As KeyPressEventArgs)

        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub PhoneNumber_TextChanged(sender As Object, e As EventArgs)

        Dim maxLen As Integer = 11
        If PhoneNumber.TextLength > maxLen Then
            PhoneNumber.Text = PhoneNumber.Text.Substring(0, maxLen)
            PhoneNumber.SelectionStart = PhoneNumber.TextLength
        End If

    End Sub

    Private Sub ButtonRounded5_Click(sender As Object, e As EventArgs)

        Dim parentForm = TryCast(FindForm(), sparxLogin)
        If parentForm Is Nothing Then Return

        Visible = False

        parentForm.ShowLoginView()

    End Sub

    Private Sub LinkBtnLogin_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkBtnLogin.LinkClicked

        Dim parentForm = TryCast(Me.FindForm(), sparxLogin)
        If parentForm Is Nothing Then Return

        Me.Visible = False

        parentForm.ShowLoginView()

    End Sub

    'For show/hide password functionality
    Private Sub picShowHide_Click(sender As Object, e As EventArgs) Handles picShowHide.Click

        If password3.PasswordChar = "●" Then
            password3.PasswordChar = Chr(0)
            picShowHide.Image = My.Resources.eye_open
        Else
            password3.PasswordChar = "●"
            picShowHide.Image = My.Resources.eye_slashed
        End If

    End Sub

    Private Sub reShowHide_Click(sender As Object, e As EventArgs) Handles reShowHide.Click
        If password4.PasswordChar = "●" Then
            password4.PasswordChar = Chr(0)
            reShowHide.Image = My.Resources.eye_open
        Else
            password4.PasswordChar = "●"
            reShowHide.Image = My.Resources.eye_slashed
        End If
    End Sub


End Class