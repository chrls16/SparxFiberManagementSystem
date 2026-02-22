<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ForgotVerification
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ForgotVerification))
        pnlLoginCard = New PanelRound()
        lblUserLevel = New Label()
        ButtonRounded5 = New ButtonRounded()
        ButtonRounded4 = New ButtonRounded()
        ButtonRounded3 = New ButtonRounded()
        pnlEmail = New PanelRound()
        Verifycode = New TextBox()
        ButtonRounded2 = New ButtonRounded()
        ButtonRounded1 = New ButtonRounded()
        Label1 = New Label()
        LinkBtnLogin = New LinkLabel()
        LblHAA = New Label()
        LinkBtnSignup = New LinkLabel()
        LblDHA = New Label()
        lnkForgot = New LinkLabel()
        lblEmail = New Label()
        btnSignup = New ButtonRounded()
        line = New Label()
        lnkAdminContact = New LinkLabel()
        lblAccess = New Label()
        logo = New PictureBox()
        sparxLogo = New PictureBox()
        pnlLoginCard.SuspendLayout()
        pnlEmail.SuspendLayout()
        CType(logo, ComponentModel.ISupportInitialize).BeginInit()
        CType(sparxLogo, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlLoginCard
        ' 
        pnlLoginCard.BackColor = Color.White
        pnlLoginCard.Controls.Add(lblUserLevel)
        pnlLoginCard.Controls.Add(ButtonRounded5)
        pnlLoginCard.Controls.Add(ButtonRounded4)
        pnlLoginCard.Controls.Add(ButtonRounded3)
        pnlLoginCard.Controls.Add(pnlEmail)
        pnlLoginCard.Controls.Add(ButtonRounded2)
        pnlLoginCard.Controls.Add(ButtonRounded1)
        pnlLoginCard.Controls.Add(Label1)
        pnlLoginCard.Controls.Add(LinkBtnLogin)
        pnlLoginCard.Controls.Add(LblHAA)
        pnlLoginCard.Controls.Add(LinkBtnSignup)
        pnlLoginCard.Controls.Add(LblDHA)
        pnlLoginCard.Controls.Add(lnkForgot)
        pnlLoginCard.Controls.Add(lblEmail)
        pnlLoginCard.Controls.Add(btnSignup)
        pnlLoginCard.Controls.Add(line)
        pnlLoginCard.Controls.Add(lnkAdminContact)
        pnlLoginCard.Controls.Add(lblAccess)
        pnlLoginCard.Controls.Add(logo)
        pnlLoginCard.Cursor = Cursors.No
        pnlLoginCard.Dock = DockStyle.Fill
        pnlLoginCard.Font = New Font("Verdana", 8.25F)
        pnlLoginCard.Location = New Point(0, 0)
        pnlLoginCard.Name = "pnlLoginCard"
        pnlLoginCard.Size = New Size(519, 588)
        pnlLoginCard.TabIndex = 33
        ' 
        ' lblUserLevel
        ' 
        lblUserLevel.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblUserLevel.Font = New Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblUserLevel.Location = New Point(0, 110)
        lblUserLevel.Name = "lblUserLevel"
        lblUserLevel.Size = New Size(519, 35)
        lblUserLevel.TabIndex = 1
        lblUserLevel.Text = "Forgot Password"
        lblUserLevel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' ButtonRounded5
        ' 
        ButtonRounded5.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        ButtonRounded5.BackColor = Color.White
        ButtonRounded5.CornerRadius = 8
        ButtonRounded5.Cursor = Cursors.Hand
        ButtonRounded5.FlatAppearance.BorderSize = 0
        ButtonRounded5.FlatStyle = FlatStyle.Flat
        ButtonRounded5.Font = New Font("Segoe UI", 12F)
        ButtonRounded5.ForeColor = Color.Black
        ButtonRounded5.Location = New Point(409, 326)
        ButtonRounded5.Name = "ButtonRounded5"
        ButtonRounded5.Size = New Size(81, 40)
        ButtonRounded5.TabIndex = 30
        ButtonRounded5.Text = "Edit email"
        ButtonRounded5.UseVisualStyleBackColor = False
        ' 
        ' ButtonRounded4
        ' 
        ButtonRounded4.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        ButtonRounded4.BackColor = Color.White
        ButtonRounded4.CornerRadius = 8
        ButtonRounded4.Cursor = Cursors.Hand
        ButtonRounded4.FlatAppearance.BorderSize = 0
        ButtonRounded4.FlatStyle = FlatStyle.Flat
        ButtonRounded4.Font = New Font("Segoe UI", 12F)
        ButtonRounded4.ForeColor = Color.Black
        ButtonRounded4.Location = New Point(29, 494)
        ButtonRounded4.Name = "ButtonRounded4"
        ButtonRounded4.Size = New Size(461, 51)
        ButtonRounded4.TabIndex = 29
        ButtonRounded4.Text = "Resend Code"
        ButtonRounded4.UseVisualStyleBackColor = False
        ' 
        ' ButtonRounded3
        ' 
        ButtonRounded3.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        ButtonRounded3.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        ButtonRounded3.CornerRadius = 8
        ButtonRounded3.Cursor = Cursors.Hand
        ButtonRounded3.FlatAppearance.BorderSize = 0
        ButtonRounded3.FlatStyle = FlatStyle.Flat
        ButtonRounded3.Font = New Font("Segoe UI", 12F)
        ButtonRounded3.ForeColor = Color.White
        ButtonRounded3.Location = New Point(29, 437)
        ButtonRounded3.Name = "ButtonRounded3"
        ButtonRounded3.Size = New Size(461, 51)
        ButtonRounded3.TabIndex = 28
        ButtonRounded3.Text = "Verify Code"
        ButtonRounded3.UseVisualStyleBackColor = False
        ' 
        ' pnlEmail
        ' 
        pnlEmail.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlEmail.BackColor = Color.WhiteSmoke
        pnlEmail.Controls.Add(Verifycode)
        pnlEmail.CornerRadius = 8
        pnlEmail.Location = New Point(32, 372)
        pnlEmail.Name = "pnlEmail"
        pnlEmail.Size = New Size(458, 48)
        pnlEmail.TabIndex = 27
        ' 
        ' Verifycode
        ' 
        Verifycode.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Verifycode.BackColor = Color.WhiteSmoke
        Verifycode.BorderStyle = BorderStyle.None
        Verifycode.CharacterCasing = CharacterCasing.Lower
        Verifycode.Cursor = Cursors.Hand
        Verifycode.Font = New Font("Segoe UI", 12F)
        Verifycode.Location = New Point(8, 10)
        Verifycode.Name = "Verifycode"
        Verifycode.PlaceholderText = "Enter 6-digit Code"
        Verifycode.Size = New Size(447, 22)
        Verifycode.TabIndex = 11
        ' 
        ' ButtonRounded2
        ' 
        ButtonRounded2.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        ButtonRounded2.BackColor = Color.White
        ButtonRounded2.CornerRadius = 8
        ButtonRounded2.Cursor = Cursors.Hand
        ButtonRounded2.FlatAppearance.BorderSize = 0
        ButtonRounded2.FlatStyle = FlatStyle.Flat
        ButtonRounded2.Font = New Font("Segoe UI", 12F)
        ButtonRounded2.ForeColor = Color.Black
        ButtonRounded2.Location = New Point(43, 735)
        ButtonRounded2.Name = "ButtonRounded2"
        ButtonRounded2.Size = New Size(815, 51)
        ButtonRounded2.TabIndex = 26
        ButtonRounded2.Text = "Back to Login"
        ButtonRounded2.UseVisualStyleBackColor = False
        ' 
        ' ButtonRounded1
        ' 
        ButtonRounded1.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        ButtonRounded1.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        ButtonRounded1.CornerRadius = 8
        ButtonRounded1.Cursor = Cursors.Hand
        ButtonRounded1.FlatAppearance.BorderSize = 0
        ButtonRounded1.FlatStyle = FlatStyle.Flat
        ButtonRounded1.Font = New Font("Segoe UI", 12F)
        ButtonRounded1.ForeColor = Color.White
        ButtonRounded1.Location = New Point(43, 664)
        ButtonRounded1.Name = "ButtonRounded1"
        ButtonRounded1.Size = New Size(815, 51)
        ButtonRounded1.TabIndex = 25
        ButtonRounded1.Text = "Send Verification Code"
        ButtonRounded1.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Label1.BackColor = Color.AliceBlue
        Label1.BorderStyle = BorderStyle.FixedSingle
        Label1.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.HotTrack
        Label1.Location = New Point(50, 289)
        Label1.Name = "Label1"
        Label1.Size = New Size(423, 25)
        Label1.TabIndex = 24
        Label1.Text = "A verification code has been sent to"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LinkBtnLogin
        ' 
        LinkBtnLogin.Anchor = AnchorStyles.Bottom
        LinkBtnLogin.AutoSize = True
        LinkBtnLogin.Font = New Font("Verdana", 11F)
        LinkBtnLogin.LinkBehavior = LinkBehavior.NeverUnderline
        LinkBtnLogin.Location = New Point(665, 1546)
        LinkBtnLogin.Name = "LinkBtnLogin"
        LinkBtnLogin.Size = New Size(47, 18)
        LinkBtnLogin.TabIndex = 23
        LinkBtnLogin.TabStop = True
        LinkBtnLogin.Text = "Login"
        LinkBtnLogin.Visible = False
        ' 
        ' LblHAA
        ' 
        LblHAA.Anchor = AnchorStyles.Bottom
        LblHAA.AutoSize = True
        LblHAA.Font = New Font("Verdana", 11F)
        LblHAA.Location = New Point(466, 1546)
        LblHAA.Name = "LblHAA"
        LblHAA.Size = New Size(143, 18)
        LblHAA.TabIndex = 22
        LblHAA.Text = "Have An Account?"
        LblHAA.Visible = False
        ' 
        ' LinkBtnSignup
        ' 
        LinkBtnSignup.Anchor = AnchorStyles.Bottom
        LinkBtnSignup.AutoSize = True
        LinkBtnSignup.Font = New Font("Verdana", 11F)
        LinkBtnSignup.LinkBehavior = LinkBehavior.NeverUnderline
        LinkBtnSignup.Location = New Point(665, 1546)
        LinkBtnSignup.Name = "LinkBtnSignup"
        LinkBtnSignup.Size = New Size(62, 18)
        LinkBtnSignup.TabIndex = 21
        LinkBtnSignup.TabStop = True
        LinkBtnSignup.Text = "Sign up"
        LinkBtnSignup.Visible = False
        ' 
        ' LblDHA
        ' 
        LblDHA.Anchor = AnchorStyles.Bottom
        LblDHA.AutoSize = True
        LblDHA.Font = New Font("Verdana", 11F)
        LblDHA.Location = New Point(478, 1546)
        LblDHA.Name = "LblDHA"
        LblDHA.Size = New Size(164, 18)
        LblDHA.TabIndex = 20
        LblDHA.Text = "Don't Have Account?"
        LblDHA.Visible = False
        ' 
        ' lnkForgot
        ' 
        lnkForgot.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        lnkForgot.AutoSize = True
        lnkForgot.Font = New Font("Verdana", 11F)
        lnkForgot.LinkBehavior = LinkBehavior.NeverUnderline
        lnkForgot.Location = New Point(1054, 389)
        lnkForgot.Name = "lnkForgot"
        lnkForgot.Size = New Size(143, 18)
        lnkForgot.TabIndex = 12
        lnkForgot.TabStop = True
        lnkForgot.Text = "Forgot Password?"
        ' 
        ' lblEmail
        ' 
        lblEmail.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblEmail.AutoSize = True
        lblEmail.BackColor = Color.Transparent
        lblEmail.Font = New Font("Verdana", 11F)
        lblEmail.Location = New Point(32, 340)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(132, 18)
        lblEmail.TabIndex = 5
        lblEmail.Text = "Verification Code"
        ' 
        ' btnSignup
        ' 
        btnSignup.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        btnSignup.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnSignup.CornerRadius = 8
        btnSignup.Cursor = Cursors.Hand
        btnSignup.FlatAppearance.BorderSize = 0
        btnSignup.FlatStyle = FlatStyle.Flat
        btnSignup.Font = New Font("Segoe UI", 12F)
        btnSignup.ForeColor = Color.White
        btnSignup.Location = New Point(26, 965)
        btnSignup.Name = "btnSignup"
        btnSignup.Size = New Size(1171, 45)
        btnSignup.TabIndex = 13
        btnSignup.Text = "Sign in"
        btnSignup.UseVisualStyleBackColor = False
        ' 
        ' line
        ' 
        line.Anchor = AnchorStyles.Bottom
        line.AutoSize = True
        line.ForeColor = SystemColors.ControlLight
        line.Location = New Point(360, 1514)
        line.Name = "line"
        line.Size = New Size(497, 13)
        line.TabIndex = 16
        line.Text = "______________________________________________________________________"
        line.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lnkAdminContact
        ' 
        lnkAdminContact.Anchor = AnchorStyles.Bottom
        lnkAdminContact.AutoSize = True
        lnkAdminContact.Font = New Font("Verdana", 11F)
        lnkAdminContact.LinkBehavior = LinkBehavior.NeverUnderline
        lnkAdminContact.Location = New Point(584, 1546)
        lnkAdminContact.Name = "lnkAdminContact"
        lnkAdminContact.Size = New Size(172, 18)
        lnkAdminContact.TabIndex = 18
        lnkAdminContact.TabStop = True
        lnkAdminContact.Text = "Contact Administrator"
        ' 
        ' lblAccess
        ' 
        lblAccess.Anchor = AnchorStyles.Bottom
        lblAccess.AutoSize = True
        lblAccess.Font = New Font("Verdana", 11F)
        lblAccess.Location = New Point(466, 1546)
        lblAccess.Name = "lblAccess"
        lblAccess.Size = New Size(110, 18)
        lblAccess.TabIndex = 17
        lblAccess.Text = "Need Access?"
        ' 
        ' logo
        ' 
        logo.Image = CType(resources.GetObject("logo.Image"), Image)
        logo.Location = New Point(226, 35)
        logo.Name = "logo"
        logo.Size = New Size(73, 50)
        logo.SizeMode = PictureBoxSizeMode.Zoom
        logo.TabIndex = 31
        logo.TabStop = False
        ' 
        ' sparxLogo
        ' 
        sparxLogo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        sparxLogo.Location = New Point(-39, -482)
        sparxLogo.Name = "sparxLogo"
        sparxLogo.Size = New Size(285, 325)
        sparxLogo.SizeMode = PictureBoxSizeMode.Zoom
        sparxLogo.TabIndex = 32
        sparxLogo.TabStop = False
        ' 
        ' ForgotVerification
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(pnlLoginCard)
        Controls.Add(sparxLogo)
        Name = "ForgotVerification"
        Size = New Size(519, 588)
        pnlLoginCard.ResumeLayout(False)
        pnlLoginCard.PerformLayout()
        pnlEmail.ResumeLayout(False)
        pnlEmail.PerformLayout()
        CType(logo, ComponentModel.ISupportInitialize).EndInit()
        CType(sparxLogo, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlLoginCard As PanelRound
    Friend WithEvents ButtonRounded2 As ButtonRounded
    Friend WithEvents ButtonRounded1 As ButtonRounded
    Friend WithEvents Label1 As Label
    Friend WithEvents LinkBtnLogin As LinkLabel
    Friend WithEvents LblHAA As Label
    Friend WithEvents LinkBtnSignup As LinkLabel
    Friend WithEvents LblDHA As Label
    Friend WithEvents logo As PictureBox
    Friend WithEvents lnkForgot As LinkLabel
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblUserLevel As Label
    Friend WithEvents btnSignup As ButtonRounded
    Friend WithEvents line As Label
    Friend WithEvents lnkAdminContact As LinkLabel
    Friend WithEvents lblAccess As Label
    Friend WithEvents sparxLogo As PictureBox
    Friend WithEvents pnlEmail As PanelRound
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents ButtonRounded3 As ButtonRounded
    Friend WithEvents ButtonRounded4 As ButtonRounded
    Friend WithEvents ButtonRounded5 As ButtonRounded
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Verifycode As TextBox

End Class

