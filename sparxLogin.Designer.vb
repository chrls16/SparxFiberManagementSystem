<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class sparxLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    Friend WithEvents LinkBtnLogin As LinkLabel

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sparxLogin))
        SplitContainer1 = New SplitContainer()
        logo = New PictureBox()
        pictureStaff = New Label()
        btnConfigPage = New Button()
        sparxLogo = New PictureBox()
        pnlLoginCard = New PanelRound()
        LinkBtnSignup = New LinkLabel()
        LblDHA = New Label()
        lnkForgot = New LinkLabel()
        lblEmail = New Label()
        lblUserLevel = New Label()
        chkRemember = New CheckBox()
        btnSignup = New ButtonRounded()
        lblPassword = New Label()
        pnlPassword = New PanelRound()
        picShowHide = New PictureBox()
        txtPassword = New TextBox()
        line = New Label()
        pnlEmail = New PanelRound()
        txtEmail = New TextBox()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(logo, ComponentModel.ISupportInitialize).BeginInit()
        CType(sparxLogo, ComponentModel.ISupportInitialize).BeginInit()
        pnlLoginCard.SuspendLayout()
        pnlPassword.SuspendLayout()
        CType(picShowHide, ComponentModel.ISupportInitialize).BeginInit()
        pnlEmail.SuspendLayout()
        SuspendLayout()
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.BackgroundImage = CType(resources.GetObject("SplitContainer1.Panel1.BackgroundImage"), Image)
        SplitContainer1.Panel1.Controls.Add(logo)
        SplitContainer1.Panel1.ForeColor = Color.FromArgb(CByte(29), CByte(41), CByte(61))
        SplitContainer1.Panel1.RightToLeft = RightToLeft.No
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.BackColor = Color.FromArgb(CByte(5), CByte(0), CByte(0), CByte(255))
        SplitContainer1.Panel2.BackgroundImageLayout = ImageLayout.Stretch
        SplitContainer1.Panel2.Controls.Add(pictureStaff)
        SplitContainer1.Panel2.Controls.Add(btnConfigPage)
        SplitContainer1.Panel2.Controls.Add(sparxLogo)
        SplitContainer1.Panel2.Controls.Add(pnlLoginCard)
        SplitContainer1.Size = New Size(1386, 788)
        SplitContainer1.SplitterDistance = 685
        SplitContainer1.TabIndex = 0
        ' 
        ' logo
        ' 
        logo.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        logo.BackColor = Color.Transparent
        logo.Image = CType(resources.GetObject("logo.Image"), Image)
        logo.Location = New Point(113, 199)
        logo.Name = "logo"
        logo.Size = New Size(419, 322)
        logo.SizeMode = PictureBoxSizeMode.Zoom
        logo.TabIndex = 20
        logo.TabStop = False
        ' 
        ' pictureStaff
        ' 
        pictureStaff.AutoSize = True
        pictureStaff.Font = New Font("Segoe UI", 40F)
        pictureStaff.Image = My.Resources.Resources._2
        pictureStaff.Location = New Point(83, 45)
        pictureStaff.Name = "pictureStaff"
        pictureStaff.Size = New Size(0, 72)
        pictureStaff.TabIndex = 27
        ' 
        ' btnConfigPage
        ' 
        btnConfigPage.BackColor = SystemColors.Control
        btnConfigPage.Font = New Font("Segoe UI", 11F)
        btnConfigPage.Image = My.Resources.Resources.settings
        btnConfigPage.ImageAlign = ContentAlignment.MiddleLeft
        btnConfigPage.Location = New Point(478, 12)
        btnConfigPage.Name = "btnConfigPage"
        btnConfigPage.Size = New Size(198, 37)
        btnConfigPage.TabIndex = 26
        btnConfigPage.Text = "Configuration Page"
        btnConfigPage.UseVisualStyleBackColor = False
        ' 
        ' sparxLogo
        ' 
        sparxLogo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        sparxLogo.Location = New Point(146, -389)
        sparxLogo.Name = "sparxLogo"
        sparxLogo.Size = New Size(169, 41)
        sparxLogo.SizeMode = PictureBoxSizeMode.Zoom
        sparxLogo.TabIndex = 0
        sparxLogo.TabStop = False
        ' 
        ' pnlLoginCard
        ' 
        pnlLoginCard.Anchor = AnchorStyles.None
        pnlLoginCard.BackColor = Color.White
        pnlLoginCard.Controls.Add(LinkBtnSignup)
        pnlLoginCard.Controls.Add(LblDHA)
        pnlLoginCard.Controls.Add(lnkForgot)
        pnlLoginCard.Controls.Add(lblEmail)
        pnlLoginCard.Controls.Add(lblUserLevel)
        pnlLoginCard.Controls.Add(chkRemember)
        pnlLoginCard.Controls.Add(btnSignup)
        pnlLoginCard.Controls.Add(lblPassword)
        pnlLoginCard.Controls.Add(pnlPassword)
        pnlLoginCard.Controls.Add(line)
        pnlLoginCard.Controls.Add(pnlEmail)
        pnlLoginCard.Font = New Font("Verdana", 8.25F)
        pnlLoginCard.Location = New Point(113, 123)
        pnlLoginCard.Name = "pnlLoginCard"
        pnlLoginCard.Size = New Size(472, 580)
        pnlLoginCard.TabIndex = 25
        ' 
        ' LinkBtnSignup
        ' 
        LinkBtnSignup.Anchor = AnchorStyles.Bottom
        LinkBtnSignup.AutoSize = True
        LinkBtnSignup.Font = New Font("Verdana", 11F)
        LinkBtnSignup.LinkBehavior = LinkBehavior.NeverUnderline
        LinkBtnSignup.Location = New Point(293, 543)
        LinkBtnSignup.Name = "LinkBtnSignup"
        LinkBtnSignup.Size = New Size(62, 18)
        LinkBtnSignup.TabIndex = 21
        LinkBtnSignup.TabStop = True
        LinkBtnSignup.Text = "Sign up"
        ' 
        ' LblDHA
        ' 
        LblDHA.Anchor = AnchorStyles.Bottom
        LblDHA.AutoSize = True
        LblDHA.Font = New Font("Verdana", 11F)
        LblDHA.Location = New Point(106, 543)
        LblDHA.Name = "LblDHA"
        LblDHA.Size = New Size(164, 18)
        LblDHA.TabIndex = 20
        LblDHA.Text = "Don't Have Account?"
        ' 
        ' lnkForgot
        ' 
        lnkForgot.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        lnkForgot.AutoSize = True
        lnkForgot.Font = New Font("Verdana", 11F)
        lnkForgot.LinkBehavior = LinkBehavior.NeverUnderline
        lnkForgot.Location = New Point(308, 389)
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
        lblEmail.Location = New Point(23, 198)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(111, 18)
        lblEmail.TabIndex = 5
        lblEmail.Text = "Email Address"
        ' 
        ' lblUserLevel
        ' 
        lblUserLevel.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblUserLevel.Font = New Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblUserLevel.Location = New Point(3, 108)
        lblUserLevel.Name = "lblUserLevel"
        lblUserLevel.Size = New Size(466, 25)
        lblUserLevel.TabIndex = 1
        lblUserLevel.Text = "Sparx Login"
        lblUserLevel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' chkRemember
        ' 
        chkRemember.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        chkRemember.AutoSize = True
        chkRemember.Font = New Font("Verdana", 11F)
        chkRemember.Location = New Point(26, 388)
        chkRemember.Name = "chkRemember"
        chkRemember.Size = New Size(138, 22)
        chkRemember.TabIndex = 11
        chkRemember.Text = "Remember me"
        chkRemember.UseVisualStyleBackColor = True
        ' 
        ' btnSignup
        ' 
        btnSignup.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btnSignup.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnSignup.CornerRadius = 8
        btnSignup.Cursor = Cursors.Hand
        btnSignup.FlatAppearance.BorderSize = 0
        btnSignup.FlatStyle = FlatStyle.Flat
        btnSignup.Font = New Font("Segoe UI", 12F)
        btnSignup.ForeColor = Color.White
        btnSignup.Location = New Point(26, 429)
        btnSignup.Name = "btnSignup"
        btnSignup.Size = New Size(425, 45)
        btnSignup.TabIndex = 13
        btnSignup.Text = "Sign in"
        btnSignup.UseVisualStyleBackColor = False
        ' 
        ' lblPassword
        ' 
        lblPassword.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblPassword.AutoSize = True
        lblPassword.BackColor = Color.Transparent
        lblPassword.Font = New Font("Verdana", 11F)
        lblPassword.Location = New Point(23, 296)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(80, 18)
        lblPassword.TabIndex = 8
        lblPassword.Text = "Password"
        ' 
        ' pnlPassword
        ' 
        pnlPassword.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlPassword.BackColor = Color.WhiteSmoke
        pnlPassword.Controls.Add(picShowHide)
        pnlPassword.Controls.Add(txtPassword)
        pnlPassword.CornerRadius = 8
        pnlPassword.Location = New Point(26, 316)
        pnlPassword.Name = "pnlPassword"
        pnlPassword.Size = New Size(425, 41)
        pnlPassword.TabIndex = 15
        ' 
        ' picShowHide
        ' 
        picShowHide.Anchor = AnchorStyles.Right
        picShowHide.Cursor = Cursors.Hand
        picShowHide.Image = CType(resources.GetObject("picShowHide.Image"), Image)
        picShowHide.Location = New Point(393, 7)
        picShowHide.Name = "picShowHide"
        picShowHide.Size = New Size(25, 25)
        picShowHide.SizeMode = PictureBoxSizeMode.Zoom
        picShowHide.TabIndex = 19
        picShowHide.TabStop = False
        ' 
        ' txtPassword
        ' 
        txtPassword.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtPassword.BackColor = Color.WhiteSmoke
        txtPassword.BorderStyle = BorderStyle.None
        txtPassword.Cursor = Cursors.Hand
        txtPassword.Font = New Font("Segoe UI", 12F)
        txtPassword.Location = New Point(5, 10)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "●"c
        txtPassword.Size = New Size(382, 22)
        txtPassword.TabIndex = 12
        ' 
        ' line
        ' 
        line.Anchor = AnchorStyles.Bottom
        line.AutoSize = True
        line.ForeColor = SystemColors.ControlLight
        line.Location = New Point(-12, 511)
        line.Name = "line"
        line.Size = New Size(0, 13)
        line.TabIndex = 16
        line.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' pnlEmail
        ' 
        pnlEmail.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlEmail.BackColor = Color.WhiteSmoke
        pnlEmail.Controls.Add(txtEmail)
        pnlEmail.CornerRadius = 8
        pnlEmail.Location = New Point(23, 219)
        pnlEmail.Name = "pnlEmail"
        pnlEmail.Size = New Size(428, 41)
        pnlEmail.TabIndex = 14
        ' 
        ' txtEmail
        ' 
        txtEmail.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtEmail.BackColor = Color.WhiteSmoke
        txtEmail.BorderStyle = BorderStyle.None
        txtEmail.CharacterCasing = CharacterCasing.Lower
        txtEmail.Cursor = Cursors.Hand
        txtEmail.Font = New Font("Segoe UI", 12F)
        txtEmail.Location = New Point(8, 10)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(413, 22)
        txtEmail.TabIndex = 11
        ' 
        ' sparxLogin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1386, 788)
        Controls.Add(SplitContainer1)
        FormBorderStyle = FormBorderStyle.None
        Name = "sparxLogin"
        StartPosition = FormStartPosition.CenterScreen
        WindowState = FormWindowState.Maximized
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        SplitContainer1.Panel2.PerformLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        CType(logo, ComponentModel.ISupportInitialize).EndInit()
        CType(sparxLogo, ComponentModel.ISupportInitialize).EndInit()
        pnlLoginCard.ResumeLayout(False)
        pnlLoginCard.PerformLayout()
        pnlPassword.ResumeLayout(False)
        pnlPassword.PerformLayout()
        CType(picShowHide, ComponentModel.ISupportInitialize).EndInit()
        pnlEmail.ResumeLayout(False)
        pnlEmail.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents pnlWelcomeCard As Panel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents pnlLoginCard As PanelRound
    Friend WithEvents pnlPassword As PanelRound
    Friend WithEvents picShowHide As PictureBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents pnlEmail As PanelRound
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents btnSignup As ButtonRounded
    Friend WithEvents lnkForgot As LinkLabel
    Friend WithEvents chkRemember As CheckBox
    Friend WithEvents lblUserLevel As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents sparxLogo As PictureBox
    Friend WithEvents line As Label
    Friend WithEvents LinkBtnSignup As LinkLabel
    Friend WithEvents LblDHA As Label
    Friend WithEvents btnConfigPage As Button
    Friend WithEvents logo As PictureBox
    Friend WithEvents pictureStaff As Label

End Class