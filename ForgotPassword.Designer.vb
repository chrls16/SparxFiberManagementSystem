<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ForgotPassword
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlEmail = New PanelRound()
        EmailInput = New TextBox()
        lblAccess = New Label()
        lnkAdminContact = New LinkLabel()
        line = New Label()
        pnlLoginCard = New PanelRound()
        ButtonRounded2 = New ButtonRounded()
        ButtonRounded1 = New ButtonRounded()
        Label1 = New Label()
        LinkBtnLogin = New LinkLabel()
        LblHAA = New Label()
        LinkBtnSignup = New LinkLabel()
        LblDHA = New Label()
        logo = New PictureBox()
        lblEmail = New Label()
        lblUserLevel = New Label()
        PictureBox1 = New PictureBox()
        pnlEmail.SuspendLayout()
        pnlLoginCard.SuspendLayout()
        CType(logo, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlEmail
        ' 
        pnlEmail.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlEmail.BackColor = Color.WhiteSmoke
        pnlEmail.Controls.Add(EmailInput)
        pnlEmail.CornerRadius = 8
        pnlEmail.Location = New Point(35, 340)
        pnlEmail.Name = "pnlEmail"
        pnlEmail.Size = New Size(451, 48)
        pnlEmail.TabIndex = 14
        ' 
        ' EmailInput
        ' 
        EmailInput.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        EmailInput.BackColor = Color.WhiteSmoke
        EmailInput.BorderStyle = BorderStyle.None
        EmailInput.Cursor = Cursors.Hand
        EmailInput.Font = New Font("Segoe UI", 12F)
        EmailInput.Location = New Point(8, 12)
        EmailInput.Name = "EmailInput"
        EmailInput.Size = New Size(435, 22)
        EmailInput.TabIndex = 28
        ' 
        ' lblAccess
        ' 
        lblAccess.Anchor = AnchorStyles.Bottom
        lblAccess.AutoSize = True
        lblAccess.Font = New Font("Verdana", 11F)
        lblAccess.Location = New Point(276, 1039)
        lblAccess.Name = "lblAccess"
        lblAccess.Size = New Size(110, 18)
        lblAccess.TabIndex = 17
        lblAccess.Text = "Need Access?"
        ' 
        ' lnkAdminContact
        ' 
        lnkAdminContact.Anchor = AnchorStyles.Bottom
        lnkAdminContact.AutoSize = True
        lnkAdminContact.Font = New Font("Verdana", 11F)
        lnkAdminContact.LinkBehavior = LinkBehavior.NeverUnderline
        lnkAdminContact.Location = New Point(394, 1039)
        lnkAdminContact.Name = "lnkAdminContact"
        lnkAdminContact.Size = New Size(172, 18)
        lnkAdminContact.TabIndex = 18
        lnkAdminContact.TabStop = True
        lnkAdminContact.Text = "Contact Administrator"
        ' 
        ' line
        ' 
        line.Anchor = AnchorStyles.Bottom
        line.AutoSize = True
        line.ForeColor = SystemColors.ControlLight
        line.Location = New Point(170, 1007)
        line.Name = "line"
        line.Size = New Size(497, 13)
        line.TabIndex = 16
        line.Text = "______________________________________________________________________"
        line.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' pnlLoginCard
        ' 
        pnlLoginCard.BackColor = Color.White
        pnlLoginCard.Controls.Add(ButtonRounded2)
        pnlLoginCard.Controls.Add(ButtonRounded1)
        pnlLoginCard.Controls.Add(Label1)
        pnlLoginCard.Controls.Add(LinkBtnLogin)
        pnlLoginCard.Controls.Add(LblHAA)
        pnlLoginCard.Controls.Add(LinkBtnSignup)
        pnlLoginCard.Controls.Add(LblDHA)
        pnlLoginCard.Controls.Add(logo)
        pnlLoginCard.Controls.Add(lblEmail)
        pnlLoginCard.Controls.Add(lblUserLevel)
        pnlLoginCard.Controls.Add(line)
        pnlLoginCard.Controls.Add(PictureBox1)
        pnlLoginCard.Controls.Add(lnkAdminContact)
        pnlLoginCard.Controls.Add(lblAccess)
        pnlLoginCard.Controls.Add(pnlEmail)
        pnlLoginCard.Dock = DockStyle.Fill
        pnlLoginCard.Font = New Font("Verdana", 8.25F)
        pnlLoginCard.Location = New Point(0, 0)
        pnlLoginCard.Name = "pnlLoginCard"
        pnlLoginCard.Size = New Size(519, 588)
        pnlLoginCard.TabIndex = 31
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
        ButtonRounded2.Location = New Point(43, 482)
        ButtonRounded2.Name = "ButtonRounded2"
        ButtonRounded2.Size = New Size(435, 51)
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
        ButtonRounded1.Location = New Point(43, 411)
        ButtonRounded1.Name = "ButtonRounded1"
        ButtonRounded1.Size = New Size(435, 51)
        ButtonRounded1.TabIndex = 25
        ButtonRounded1.Text = "Send Verification Code"
        ButtonRounded1.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Label1.BackColor = Color.White
        Label1.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ControlDarkDark
        Label1.Location = New Point(23, 274)
        Label1.Name = "Label1"
        Label1.Size = New Size(492, 25)
        Label1.TabIndex = 24
        Label1.Text = "Enter your phone number and we'll send you a verification code."
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LinkBtnLogin
        ' 
        LinkBtnLogin.Anchor = AnchorStyles.Bottom
        LinkBtnLogin.AutoSize = True
        LinkBtnLogin.Font = New Font("Verdana", 11F)
        LinkBtnLogin.LinkBehavior = LinkBehavior.NeverUnderline
        LinkBtnLogin.Location = New Point(475, 1039)
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
        LblHAA.Location = New Point(276, 1039)
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
        LinkBtnSignup.Location = New Point(475, 1039)
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
        LblDHA.Location = New Point(288, 1039)
        LblDHA.Name = "LblDHA"
        LblDHA.Size = New Size(164, 18)
        LblDHA.TabIndex = 20
        LblDHA.Text = "Don't Have Account?"
        LblDHA.Visible = False
        ' 
        ' logo
        ' 
        logo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        logo.Location = New Point(146, -389)
        logo.Name = "logo"
        logo.Size = New Size(155, 41)
        logo.SizeMode = PictureBoxSizeMode.Zoom
        logo.TabIndex = 0
        logo.TabStop = False
        ' 
        ' lblEmail
        ' 
        lblEmail.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblEmail.AutoSize = True
        lblEmail.BackColor = Color.Transparent
        lblEmail.Font = New Font("Verdana", 11F)
        lblEmail.Location = New Point(35, 310)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(118, 18)
        lblEmail.TabIndex = 5
        lblEmail.Text = "Phone Number"
        ' 
        ' lblUserLevel
        ' 
        lblUserLevel.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblUserLevel.Font = New Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblUserLevel.Location = New Point(0, 108)
        lblUserLevel.Name = "lblUserLevel"
        lblUserLevel.Size = New Size(519, 35)
        lblUserLevel.TabIndex = 1
        lblUserLevel.Text = "Forgot Password"
        lblUserLevel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        PictureBox1.Image = My.Resources.Resources.SparxLogo2
        PictureBox1.Location = New Point(226, 35)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(73, 50)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 27
        PictureBox1.TabStop = False
        ' 
        ' ForgotPassword
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(pnlLoginCard)
        Name = "ForgotPassword"
        Size = New Size(519, 588)
        pnlEmail.ResumeLayout(False)
        pnlEmail.PerformLayout()
        pnlLoginCard.ResumeLayout(False)
        pnlLoginCard.PerformLayout()
        CType(logo, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlLoginCard As PanelRound
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
    Friend WithEvents pnlEmail As PanelRound
    Friend WithEvents sparxLogo As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonRounded2 As ButtonRounded
    Friend WithEvents ButtonRounded1 As ButtonRounded
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents EmailInput As TextBox
End Class
