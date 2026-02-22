<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewPassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewPassword))
        ButtonRounded2 = New ButtonRounded()
        ButtonRounded1 = New ButtonRounded()
        Label1 = New Label()
        LinkBtnLogin = New LinkLabel()
        LblHAA = New Label()
        LinkBtnSignup = New LinkLabel()
        LblDHA = New Label()
        lblEmail = New Label()
        lblUserLevel = New Label()
        lnkAdminContact = New LinkLabel()
        lblAccess = New Label()
        sparxLogo = New PictureBox()
        line = New Label()
        pnlLoginCard = New PanelRound()
        ButtonRounded4 = New ButtonRounded()
        Label2 = New Label()
        PanelRound1 = New PanelRound()
        TextBox1 = New TextBox()
        pnlEmail = New PanelRound()
        txtEmail = New TextBox()
        logo = New PictureBox()
        CType(sparxLogo, ComponentModel.ISupportInitialize).BeginInit()
        pnlLoginCard.SuspendLayout()
        PanelRound1.SuspendLayout()
        pnlEmail.SuspendLayout()
        CType(logo, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
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
        ButtonRounded1.Location = New Point(24, 466)
        ButtonRounded1.Name = "ButtonRounded1"
        ButtonRounded1.Size = New Size(458, 48)
        ButtonRounded1.TabIndex = 25
        ButtonRounded1.Text = "Reset Password"
        ButtonRounded1.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Label1.BackColor = Color.White
        Label1.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ControlDarkDark
        Label1.Location = New Point(50, 221)
        Label1.Name = "Label1"
        Label1.Size = New Size(432, 25)
        Label1.TabIndex = 24
        Label1.Text = "Enter your new password below."
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
        ' lblEmail
        ' 
        lblEmail.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblEmail.AutoSize = True
        lblEmail.BackColor = Color.Transparent
        lblEmail.Font = New Font("Verdana", 11F)
        lblEmail.Location = New Point(24, 262)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(118, 18)
        lblEmail.TabIndex = 5
        lblEmail.Text = "New Password"
        ' 
        ' lblUserLevel
        ' 
        lblUserLevel.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblUserLevel.Font = New Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblUserLevel.Location = New Point(3, 108)
        lblUserLevel.Name = "lblUserLevel"
        lblUserLevel.Size = New Size(519, 35)
        lblUserLevel.TabIndex = 1
        lblUserLevel.Text = "Forgot Password"
        lblUserLevel.TextAlign = ContentAlignment.MiddleCenter
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
        ' sparxLogo
        ' 
        sparxLogo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        sparxLogo.Location = New Point(41, -240)
        sparxLogo.Name = "sparxLogo"
        sparxLogo.Size = New Size(110, 52)
        sparxLogo.SizeMode = PictureBoxSizeMode.Zoom
        sparxLogo.TabIndex = 32
        sparxLogo.TabStop = False
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
        ' pnlLoginCard
        ' 
        pnlLoginCard.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlLoginCard.BackColor = Color.White
        pnlLoginCard.Controls.Add(ButtonRounded4)
        pnlLoginCard.Controls.Add(Label2)
        pnlLoginCard.Controls.Add(PanelRound1)
        pnlLoginCard.Controls.Add(ButtonRounded2)
        pnlLoginCard.Controls.Add(ButtonRounded1)
        pnlLoginCard.Controls.Add(Label1)
        pnlLoginCard.Controls.Add(LinkBtnLogin)
        pnlLoginCard.Controls.Add(LblHAA)
        pnlLoginCard.Controls.Add(LinkBtnSignup)
        pnlLoginCard.Controls.Add(LblDHA)
        pnlLoginCard.Controls.Add(lblEmail)
        pnlLoginCard.Controls.Add(lblUserLevel)
        pnlLoginCard.Controls.Add(line)
        pnlLoginCard.Controls.Add(lnkAdminContact)
        pnlLoginCard.Controls.Add(lblAccess)
        pnlLoginCard.Controls.Add(pnlEmail)
        pnlLoginCard.Controls.Add(logo)
        pnlLoginCard.Font = New Font("Verdana", 8.25F)
        pnlLoginCard.Location = New Point(0, 0)
        pnlLoginCard.Name = "pnlLoginCard"
        pnlLoginCard.Size = New Size(519, 588)
        pnlLoginCard.TabIndex = 33
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
        ButtonRounded4.Location = New Point(24, 520)
        ButtonRounded4.Name = "ButtonRounded4"
        ButtonRounded4.Size = New Size(458, 51)
        ButtonRounded4.TabIndex = 30
        ButtonRounded4.Text = "Back to Login"
        ButtonRounded4.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Verdana", 11F)
        Label2.Location = New Point(24, 362)
        Label2.Name = "Label2"
        Label2.Size = New Size(188, 18)
        Label2.TabIndex = 27
        Label2.Text = "Re-enter New Password"
        ' 
        ' PanelRound1
        ' 
        PanelRound1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        PanelRound1.BackColor = Color.WhiteSmoke
        PanelRound1.Controls.Add(TextBox1)
        PanelRound1.CornerRadius = 8
        PanelRound1.Location = New Point(24, 392)
        PanelRound1.Name = "PanelRound1"
        PanelRound1.Size = New Size(458, 48)
        PanelRound1.TabIndex = 15
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TextBox1.BackColor = Color.WhiteSmoke
        TextBox1.BorderStyle = BorderStyle.None
        TextBox1.CharacterCasing = CharacterCasing.Lower
        TextBox1.Cursor = Cursors.Hand
        TextBox1.Font = New Font("Segoe UI", 12F)
        TextBox1.Location = New Point(8, 10)
        TextBox1.Name = "TextBox1"
        TextBox1.PlaceholderText = "Re-enter new Passowrd"
        TextBox1.Size = New Size(434, 22)
        TextBox1.TabIndex = 11
        ' 
        ' pnlEmail
        ' 
        pnlEmail.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlEmail.BackColor = Color.WhiteSmoke
        pnlEmail.Controls.Add(txtEmail)
        pnlEmail.CornerRadius = 8
        pnlEmail.Location = New Point(24, 292)
        pnlEmail.Name = "pnlEmail"
        pnlEmail.Size = New Size(458, 48)
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
        txtEmail.PlaceholderText = "Enter New Password"
        txtEmail.Size = New Size(751, 22)
        txtEmail.TabIndex = 11
        ' 
        ' logo
        ' 
        logo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        logo.Image = CType(resources.GetObject("logo.Image"), Image)
        logo.Location = New Point(226, 35)
        logo.Name = "logo"
        logo.Size = New Size(73, 50)
        logo.SizeMode = PictureBoxSizeMode.Zoom
        logo.TabIndex = 31
        logo.TabStop = False
        ' 
        ' NewPassword
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(pnlLoginCard)
        Controls.Add(sparxLogo)
        Name = "NewPassword"
        Size = New Size(519, 588)
        CType(sparxLogo, ComponentModel.ISupportInitialize).EndInit()
        pnlLoginCard.ResumeLayout(False)
        pnlLoginCard.PerformLayout()
        PanelRound1.ResumeLayout(False)
        PanelRound1.PerformLayout()
        pnlEmail.ResumeLayout(False)
        pnlEmail.PerformLayout()
        CType(logo, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents ButtonRounded2 As ButtonRounded
    Friend WithEvents ButtonRounded1 As ButtonRounded
    Friend WithEvents Label1 As Label
    Friend WithEvents LinkBtnLogin As LinkLabel
    Friend WithEvents LblHAA As Label
    Friend WithEvents LinkBtnSignup As LinkLabel
    Friend WithEvents LblDHA As Label
    Friend WithEvents logo As PictureBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblUserLevel As Label
    Friend WithEvents lnkAdminContact As LinkLabel
    Friend WithEvents lblAccess As Label
    Friend WithEvents sparxLogo As PictureBox
    Friend WithEvents line As Label
    Friend WithEvents pnlLoginCard As PanelRound
    Friend WithEvents pnlEmail As PanelRound
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PanelRound1 As PanelRound
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ButtonRounded4 As ButtonRounded

End Class

