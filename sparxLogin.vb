Imports System.Configuration
Imports System.Net.Http
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySqlConnector

Public Class sparxLogin
    Private Const ROLE_SUPER_ADMIN As String = "Super Admin"
    Private Const ROLE_INVENTORY_ADMIN As String = "Inventory"
    Private Const ROLE_SUBSCRIBER As String = "Subscriber"
    Private Const ROLE_CUSTOMER_SERVICE As String = "Customer Service"

    Private configurationPage As ConfigurationPage
    Private keyPressCount As Integer = 0
    Private lastKeyPressTime As DateTime = DateTime.Now
    Private Const KEY_COMBO_TIMEOUT As Integer = 2000 '

    Private Shared ReadOnly http As New HttpClient() With {.Timeout = TimeSpan.FromSeconds(30)}
    Private ReadOnly Property API_URL As String
        Get
            Dim serverIP As String = "127.0.0.1"
            Try
                Dim connStr As String = ConfigurationManager.ConnectionStrings("SparxDb").ConnectionString
                Dim parts As String() = connStr.Split(";"c)
                For Each part As String In parts
                    If part.Trim().ToLower().StartsWith("server=") Then
                        serverIP = part.Split("="c)(1).Trim()
                        Exit For
                    End If
                Next
            Catch
            End Try
            Return $"http://{serverIP}/sparx-api/login.php" ' <--- MAKE SURE THIS ENDING MATCHES THE FILE YOU NEED
        End Get
    End Property
    Private ForgotView As ForgotPassword
    Private forgotVerificationView As ForgotVerification
    Private subscriberSignUpControl As SubscriberSignup

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

    Private Sub sparxLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load, MyBase.Resize
        If DesignMode Then Return

        If btnConfigPage IsNot Nothing Then
            btnConfigPage.Visible = False
        End If
        AddToolTipToConfigButton()

        ' Initialize picShowHide image
        If picShowHide IsNot Nothing AndAlso picShowHide.Image Is Nothing Then
            picShowHide.Image = My.Resources.eye_slashed
        End If

        ' Initialize logo image
        If logo IsNot Nothing AndAlso logo.Image Is Nothing Then
            Try
                logo.Image = My.Resources.SparxLogo2
            Catch
                ' Resource not found, skip
            End Try
        End If

        ' Initialize background image
        If SplitContainer1 IsNot Nothing AndAlso SplitContainer1.Panel1.BackgroundImage Is Nothing Then
            Try
                SplitContainer1.Panel1.BackgroundImage = My.Resources.Resources.SparxBackground
            Catch
                ' Resource not found, skip
            End Try
        End If

        If subscriberSignUpControl Is Nothing Then
            subscriberSignUpControl = New SubscriberSignup()
            subscriberSignUpControl.Dock = DockStyle.Fill
            pnlLoginCard.Controls.Add(subscriberSignUpControl)
            subscriberSignUpControl.Visible = False
        End If

        ' Default to login view
        If subscriberSignUpControl IsNot Nothing Then
            subscriberSignUpControl.Visible = False
        End If

        ' Hide configuration button by default
        If btnConfigPage IsNot Nothing Then
            btnConfigPage.Visible = False
        End If
        Me.KeyPreview = True
    End Sub

    Private Sub AddToolTipToConfigButton()
        Dim toolTip As New System.Windows.Forms.ToolTip()
        toolTip.AutoPopDelay = 5000
        toolTip.InitialDelay = 1000
        toolTip.ReshowDelay = 500
        toolTip.ShowAlways = True

        ' Update this line - change Ctrl+C to F12
        toolTip.SetToolTip(btnConfigPage, "Configuration Page" & vbCrLf &
                                    "Press F12 to reveal this button" & vbCrLf &
                                    "Button remains visible until app restart")
    End Sub

    Private Sub ShowKeyCombinationMessage()
        ' Create a temporary message label
        Dim messageLabel As New Label()
        messageLabel.Text = "✓ Configuration button revealed!" & vbCrLf &
                   "Press Ctrl+C to show this button again"
        messageLabel.ForeColor = Color.Green
        messageLabel.BackColor = Color.FromArgb(230, 255, 230)
        messageLabel.Font = New Font("Verdana", 9, FontStyle.Bold)
        messageLabel.AutoSize = False
        messageLabel.Size = New Size(300, 50)

        ' Position it relative to the config button
        If btnConfigPage.Visible Then
            messageLabel.Location = New Point(
        btnConfigPage.Location.X + btnConfigPage.Width + 10,
        btnConfigPage.Location.Y
    )
        Else
            messageLabel.Location = New Point(100, 100) ' Default position
        End If

        messageLabel.TextAlign = ContentAlignment.MiddleCenter
        messageLabel.BorderStyle = BorderStyle.FixedSingle
        messageLabel.Padding = New Padding(5)

        ' Add to form
        SplitContainer1.Panel1.Controls.Add(messageLabel)
        messageLabel.BringToFront()

        ' Create timer to remove message after 5 seconds
        Dim timer As New Timer()
        timer.Interval = 5000 ' 5 seconds
        AddHandler timer.Tick, Sub(s, evt)
                                   SplitContainer1.Panel1.Controls.Remove(messageLabel)
                                   messageLabel.Dispose()
                                   timer.Stop()
                                   timer.Dispose()
                               End Sub
        timer.Start()
    End Sub

    Private Sub TestKeyPress()
        ' Add a label to show key presses
        Dim testLabel As New Label()
        testLabel.Text = "Press any key..."
        testLabel.Location = New Point(50, 50)
        testLabel.ForeColor = Color.Red
        testLabel.Font = New Font("Arial", 12, FontStyle.Bold)

        ' Add keydown handler to show what's being pressed
        AddHandler Me.KeyDown, Sub(sender, e)
                                   testLabel.Text = $"Key pressed: {e.KeyCode}, Ctrl: {e.Control}, Shift: {e.Shift}, Alt: {e.Alt}"
                               End Sub

        SplitContainer1.Panel1.Controls.Add(testLabel)
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

    Private Sub pnlPassword_Paint(sender As Object, e As PaintEventArgs) Handles pnlPassword.Paint
    End Sub

    Private Sub UserRole_Click(sender As Object, e As EventArgs)
        Dim clickedLabel = CType(sender, Label)
        clickedLabel.Font = New Font(clickedLabel.Font, FontStyle.Bold)

        ' Use the new method to show login
        ShowLoginView()

        ' Clear any forgot password overlays
        Dim overlays As New List(Of Control)
        For Each c As Control In pnlLoginCard.Controls
            If c.GetType.Name = "ForgotPassword" OrElse c.GetType.Name = "ForgotVerification" OrElse c.GetType.Name = "NewPassword" OrElse c.GetType.Name = "forgotPasswordView" Then
                overlays.Add(c)
            End If
        Next
        For Each c In overlays
            pnlLoginCard.Controls.Remove(c)
        Next

        ' Reset forgot password variables
        ForgotView = Nothing
        forgotVerificationView = Nothing
    End Sub

    Private Sub LinkBtnSignup_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkBtnSignup.LinkClicked
        lblUserLevel.Text = "Sparx "
        btnSignup.Text = "Sign Up"

        ' Hide login inputs
        lblEmail.Visible = False
        lblPassword.Visible = False
        txtEmail.Visible = False
        txtPassword.Visible = False
        pnlEmail.Visible = False
        pnlPassword.Visible = False
        chkRemember.Visible = False
        lnkForgot.Visible = True

        ' Show the sign-up view
        subscriberSignUpControl.Visible = True
        subscriberSignUpControl.BringToFront()
    End Sub

    Private Sub lblUserLevel_Click(sender As Object, e As EventArgs) Handles lblUserLevel.Click
    End Sub

    ' UPDATED: Forgot password link clicked - stores username
    Private Sub lnkForgot_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkForgot.LinkClicked
        ' Store the username/email from the login field
        Dim username As String = txtEmail.Text.Trim()

        If String.IsNullOrEmpty(username) Then
            MessageBox.Show("Please enter your username/email first.", "Missing Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Clear any previous forgot password state
        GlobalState.ClearForgotPasswordState()

        ' Store the new username globally
        GlobalState.ForgotPasswordUsername = username

        If ForgotView Is Nothing OrElse ForgotView.IsDisposed Then
            ForgotView = New ForgotPassword()
            AddHandler ForgotView.SendCodeRequested, AddressOf OnSendCodeRequested
            ForgotView.Dock = DockStyle.Fill
        End If

        If Not pnlLoginCard.Controls.Contains(ForgotView) Then
            pnlLoginCard.Controls.Add(ForgotView)
        End If
        ForgotView.BringToFront()
    End Sub

    Private Sub OnSendCodeRequested()
        If forgotVerificationView Is Nothing OrElse forgotVerificationView.IsDisposed Then
            forgotVerificationView = New ForgotVerification()
            forgotVerificationView.Dock = DockStyle.Fill
        End If
        If Not pnlLoginCard.Controls.Contains(forgotVerificationView) Then
            pnlLoginCard.Controls.Add(forgotVerificationView)
        End If
        forgotVerificationView.BringToFront()
    End Sub

    Private Function IsValidEmail(ByVal email As String) As Boolean
        Dim pattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
        Return Regex.IsMatch(email, pattern)
    End Function

    Private Async Sub btnSignup_Click(sender As Object, e As EventArgs) Handles btnSignup.Click
        Dim email As String = txtEmail.Text.Trim()
        Dim password As String = txtPassword.Text

        If String.IsNullOrEmpty(email) AndAlso String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter both an email and a password to sign up.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        ElseIf String.IsNullOrEmpty(email) Then
            MessageBox.Show("Please enter your email.", "Missing Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        ElseIf String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter your password.", "Missing Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not IsValidEmail(email) Then
            MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If btnSignup.Text = "Sign Up" Then
            ' Existing Sign Up logic remains unchanged
            Dim form As New Dictionary(Of String, String) From {
            {"action", "signup"},
            {"email", email},
            {"username", email},
            {"password", password}
        }
            Dim content = New FormUrlEncodedContent(form)

            Try
                Dim resp = Await http.PostAsync(API_URL, content)
                Dim responseString = Await resp.Content.ReadAsStringAsync()

                If Not resp.IsSuccessStatusCode Then
                    MessageBox.Show("Server returned " & CInt(resp.StatusCode) & ": " & resp.ReasonPhrase, "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If responseString.Contains("""status"":""success""") OrElse responseString.Contains("""success"":true") Then
                    MessageBox.Show("Sign up successful! Please log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' Return to login view
                    If subscriberSignUpControl IsNot Nothing Then
                        subscriberSignUpControl.Visible = False
                    End If
                    btnSignup.Text = "Sign In"
                    lblEmail.Visible = True
                    lblPassword.Visible = True
                    txtEmail.Visible = True
                    txtPassword.Visible = True
                    pnlEmail.Visible = True
                    pnlPassword.Visible = True
                    chkRemember.Visible = True
                    lnkForgot.Visible = True
                    txtEmail.Text = email ' Keep email for convenience
                    txtPassword.Text = ""
                Else
                    Dim messageMatch As Match = Regex.Match(responseString, """message"":""([^""]+)""")
                    Dim errorMessage As String = If(messageMatch.Success, messageMatch.Groups(1).Value, "Sign up failed.")
                    MessageBox.Show(errorMessage, "Sign Up Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Error connecting to server: " & ex.Message & " (Check XAMPP and URL: " & API_URL & ")", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            ' --- PATH 2: Handle Sign In (Unified Login) ---
        Else ' btnSignup.Text = "Sign In"

            ' --- 2a: Try API Login (for Staff Roles) ---
            Dim formLogin As New Dictionary(Of String, String) From {
            {"action", "login"},
            {"email", email},
            {"username", email},
            {"password", password}}

            Dim contentLogin = New FormUrlEncodedContent(formLogin)

            Try
                Dim resp = Await http.PostAsync(API_URL, contentLogin)
                Dim responseString = Await resp.Content.ReadAsStringAsync()

                If resp.IsSuccessStatusCode AndAlso (responseString.Contains("""status"":""success""") OrElse responseString.Contains("""success"":true")) Then

                    ' API Login Success! Determine role and navigate.
                    Dim roleMatch As Match = Regex.Match(responseString, """user_role"":""([^""]+)""")
                    Dim userRole As String = If(roleMatch.Success, roleMatch.Groups(1).Value, "User")

                    'MessageBox.Show($"DEBUG: Database returned Role = '{userRole}'", "Debug Info")

                    Select Case userRole
                        Case ROLE_SUPER_ADMIN
                            Dim dash As New dashboardSuperAdmin()
                            Me.Hide()
                            dash.Show()
                            AddHandler dash.FormClosed, Sub() Me.Close()

                        Case ROLE_INVENTORY_ADMIN, ROLE_CUSTOMER_SERVICE
                            Dim adminPortal As New customerservicetab()
                            adminPortal.CurrentUserRole = userRole
                            Me.Hide()
                            adminPortal.Show()
                            AddHandler adminPortal.FormClosed, Sub() Me.Close()

                        Case Else
                            ' Handle other staff/unknown roles here if necessary
                            MessageBox.Show($"Unknown Staff Role ({userRole}) logged in.", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Select
                    Exit Sub ' IMPORTANT: Exit after successful API login and navigation.
                End If

                ' If API failed, it falls through to the next Try block (Local DB check).

            Catch ex As Exception
                ' Log network error but continue to try local DB check
                Console.WriteLine("API Network Error or Server Unreachable. Trying local DB...")
            End Try

            ' --- 2b: Try Direct MySQL Login (for Subscriber Role) ---
            Try
                Using conn As New MySqlConnection(CONNECTION_STRING)
                    conn.Open()

                    Dim passwordColumn As String = ResolvePasswordColumn(conn, "customer_data")
                    If String.IsNullOrEmpty(passwordColumn) Then
                        MessageBox.Show("System Error: Missing password column in customer table.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    Dim query As String = $"SELECT customer_id, first_name, last_name, {passwordColumn}, account_status FROM customer_data WHERE email_address = @email"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@email", email)
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                Dim storedPassword As String = reader(passwordColumn).ToString()
                                Dim customerId As Integer = Convert.ToInt32(reader("customer_id"))
                                Dim firstName As String = reader("first_name").ToString()
                                Dim lastName As String = reader("last_name").ToString()
                                Dim status As String = reader("account_status").ToString()

                                If VerifyPasswordValue(password, storedPassword) Then ' Verify password hash
                                    If status = "Active" Then
                                        'MessageBox.Show("Subscriber Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Dim subView As New SidePanel()
                                        subView.CurrentCustomerId = customerId
                                        subView.CurrentFirstName = firstName
                                        subView.CurrentLastName = lastName
                                        subView.CurrentEmail = email
                                        Me.Hide()
                                        subView.Show()
                                        AddHandler subView.FormClosed, AddressOf OnSubViewClosing
                                        Exit Sub ' IMPORTANT: Exit after successful DB login and navigation.
                                    Else
                                        MessageBox.Show("Account is not active.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Exit Sub
                                    End If
                                End If
                            End If
                        End Using
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Database error during subscriber login: " & ex.Message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            ' --- Final Failure Message ---
            ' If execution reaches here, neither API nor DB login succeeded.
            MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If ' End of Sign Up / Sign In block
    End Sub



    Private Sub OnSubViewClosing(sender As Object, e As FormClosedEventArgs)
        Me.Close()
    End Sub



    Private Function ResolvePasswordColumn(conn As MySqlConnection, tableName As String) As String
        Try
            Dim query As String = "SHOW COLUMNS FROM " & tableName & " WHERE Field LIKE '%password%'"
            Using cmd As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Return reader("Field").ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Fallback to common column names
            Return "password"
        End Try
        Return "password"
    End Function

    Private Function VerifyPasswordValue(inputPassword As String, storedPassword As String) As Boolean
        Try

            If storedPassword.StartsWith("$2") Then
                Return BCrypt.Net.BCrypt.Verify(inputPassword, storedPassword)
            End If


            Return inputPassword = storedPassword

        Catch ex As Exception
            ' STOP SWALLOWING THE ERROR!
            ' Show us exactly why BCrypt is failing on Computer 2
            MessageBox.Show("CRITICAL BCRYPT ERROR: " & ex.Message & vbCrLf & ex.StackTrace)
            Return False
        End Try
    End Function

    Private Sub sparxLogin_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        ' Check for F12 key
        If e.KeyCode = Keys.F12 Then
            e.SuppressKeyPress = True
            btnConfigPage.Visible = True
            ShowKeyCombinationMessage()
        End If
    End Sub

    Private Sub btnConfigPage_Click(sender As Object, e As EventArgs) Handles btnConfigPage.Click
        If configurationPage Is Nothing OrElse configurationPage.IsDisposed Then
            configurationPage = New ConfigurationPage()
            AddHandler configurationPage.FormClosed, AddressOf OnConfigurationPageClosed
        End If

        configurationPage.Show()
        configurationPage.BringToFront()
    End Sub

    Private Sub OnConfigurationPageClosed(sender As Object, e As FormClosedEventArgs)
        ' Optional: hide the config button when configuration page is closed
        ' btnConfigPage.Visible = False
    End Sub

    Private Sub logo_Click_1(sender As Object, e As EventArgs) Handles logo.Click
    End Sub

    ' Add this helper method anywhere inside the sparxLogin class (e.g., after sparxLogin_Load)
    Private Sub RestoreLoginView(Optional prefillEmail As String = "")
        Try
            If subscriberSignUpControl IsNot Nothing Then
                subscriberSignUpControl.Visible = False
                ' Ensure sign-up control is moved behind login controls so it can't block input
                subscriberSignUpControl.SendToBack()
            End If

            btnSignup.Text = "Sign In"

            If lblEmail IsNot Nothing Then lblEmail.Visible = True
            If lblPassword IsNot Nothing Then lblPassword.Visible = True
            If txtEmail IsNot Nothing Then
                txtEmail.Visible = True
                txtEmail.Enabled = True
                txtEmail.ReadOnly = False
                txtEmail.Text = prefillEmail
            End If
            If txtPassword IsNot Nothing Then
                txtPassword.Visible = True
                txtPassword.Enabled = True
                txtPassword.ReadOnly = False
                txtPassword.Text = ""
            End If
            If pnlEmail IsNot Nothing Then pnlEmail.Visible = True
            If pnlPassword IsNot Nothing Then pnlPassword.Visible = True
            If chkRemember IsNot Nothing Then chkRemember.Visible = True
            If lnkForgot IsNot Nothing Then lnkForgot.Visible = True

            ' Give keyboard focus to email field so typing works immediately
            If txtEmail IsNot Nothing Then
                txtEmail.Focus()
                txtEmail.SelectionStart = txtEmail.Text.Length
            End If
        Catch
            ' Swallow silently — restore should be best-effort only
        End Try
    End Sub

    ' In sparxLogin class
    Public Sub ShowLoginView()
        ' Hide any signup or forgot password views
        If subscriberSignUpControl IsNot Nothing Then
            subscriberSignUpControl.Visible = False
            subscriberSignUpControl.SendToBack()
        End If

        If ForgotView IsNot Nothing Then
            ForgotView.Visible = False
        End If

        If forgotVerificationView IsNot Nothing Then
            forgotVerificationView.Visible = False
        End If

        ' Show login controls - use Me. to ensure we're accessing the form's controls
        Me.lblEmail.Visible = True
        Me.pnlEmail.Visible = True
        Me.txtEmail.Visible = True
        Me.txtEmail.Enabled = True
        Me.txtEmail.ReadOnly = False

        Me.lblPassword.Visible = True
        Me.pnlPassword.Visible = True
        Me.txtPassword.Visible = True
        Me.txtPassword.Enabled = True
        Me.txtPassword.ReadOnly = False

        Me.chkRemember.Visible = True
        Me.lnkForgot.Visible = True

        ' Set button text
        Me.btnSignup.Text = "Sign In"
        Me.lblUserLevel.Text = "Sparx Login"

        ' Clear and focus
        Me.txtPassword.Text = ""
        Me.txtEmail.Focus()
        Me.txtEmail.SelectAll()

        ' Force a refresh
        Me.Refresh()
    End Sub

    ' NEW: Method to restore from forgot password flow
    Public Sub RestoreFromForgotPassword()
        ' Clear all forgot password states
        GlobalState.ClearForgotPasswordState()

        ' Remove any forgot password views
        Dim forgotViews = New List(Of Control)
        For Each ctrl As Control In pnlLoginCard.Controls
            If TypeOf ctrl Is ForgotPassword OrElse
               TypeOf ctrl Is ForgotVerification OrElse
               TypeOf ctrl Is NewPassword Then
                forgotViews.Add(ctrl)
            End If
        Next

        For Each ctrl In forgotViews
            pnlLoginCard.Controls.Remove(ctrl)
            ctrl.Dispose()
        Next

        ' Clear the forgot password references
        ForgotView = Nothing
        forgotVerificationView = Nothing

        ' Show login view
        ShowLoginView()
    End Sub

    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

    Private Sub pnlLoginCard_Paint(sender As Object, e As PaintEventArgs) Handles pnlLoginCard.Paint

    End Sub
End Class