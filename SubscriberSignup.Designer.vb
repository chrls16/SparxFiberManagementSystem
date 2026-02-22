<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SubscriberSignup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SubscriberSignup))
        pnlLoginCard = New PanelRound()
        line = New Label()
        LinkBtnLogin = New LinkLabel()
        Label4 = New Label()
        Label5 = New Label()
        ButtonRounded3 = New ButtonRounded()
        Label3 = New Label()
        PanelRound4 = New PanelRound()
        reShowHide = New PictureBox()
        password4 = New TextBox()
        Label2 = New Label()
        PanelRound3 = New PanelRound()
        picShowHide = New PictureBox()
        password3 = New TextBox()
        Label1 = New Label()
        PanelRound2 = New PanelRound()
        PhoneNumber = New TextBox()
        PanelRound1 = New PanelRound()
        TxtLastName = New TextBox()
        LblHAA = New Label()
        LinkBtnSignup = New LinkLabel()
        LblDHA = New Label()
        lblEmail = New Label()
        lblUserLevel = New Label()
        lblPassword = New Label()
        pnlPassword = New PanelRound()
        txtEmail = New TextBox()
        pnlEmail = New PanelRound()
        txtFirstName = New TextBox()
        pnlLoginCard.SuspendLayout()
        PanelRound4.SuspendLayout()
        CType(reShowHide, ComponentModel.ISupportInitialize).BeginInit()
        PanelRound3.SuspendLayout()
        CType(picShowHide, ComponentModel.ISupportInitialize).BeginInit()
        PanelRound2.SuspendLayout()
        PanelRound1.SuspendLayout()
        pnlPassword.SuspendLayout()
        pnlEmail.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlLoginCard
        ' 
        pnlLoginCard.Anchor = AnchorStyles.Top
        pnlLoginCard.BackColor = Color.White
        pnlLoginCard.Controls.Add(line)
        pnlLoginCard.Controls.Add(LinkBtnLogin)
        pnlLoginCard.Controls.Add(Label4)
        pnlLoginCard.Controls.Add(Label5)
        pnlLoginCard.Controls.Add(ButtonRounded3)
        pnlLoginCard.Controls.Add(Label3)
        pnlLoginCard.Controls.Add(PanelRound4)
        pnlLoginCard.Controls.Add(Label2)
        pnlLoginCard.Controls.Add(PanelRound3)
        pnlLoginCard.Controls.Add(Label1)
        pnlLoginCard.Controls.Add(PanelRound2)
        pnlLoginCard.Controls.Add(PanelRound1)
        pnlLoginCard.Controls.Add(LblHAA)
        pnlLoginCard.Controls.Add(LinkBtnSignup)
        pnlLoginCard.Controls.Add(LblDHA)
        pnlLoginCard.Controls.Add(lblEmail)
        pnlLoginCard.Controls.Add(lblUserLevel)
        pnlLoginCard.Controls.Add(lblPassword)
        pnlLoginCard.Controls.Add(pnlPassword)
        pnlLoginCard.Controls.Add(pnlEmail)
        pnlLoginCard.Font = New Font("Verdana", 8.25F)
        pnlLoginCard.Location = New Point(0, 0)
        pnlLoginCard.Name = "pnlLoginCard"
        pnlLoginCard.Size = New Size(472, 580)
        pnlLoginCard.TabIndex = 26
        ' 
        ' line
        ' 
        line.Anchor = AnchorStyles.Bottom
        line.AutoSize = True
        line.ForeColor = SystemColors.ControlLight
        line.Location = New Point(-11, 520)
        line.Name = "line"
        line.Size = New Size(497, 13)
        line.TabIndex = 37
        line.Text = "______________________________________________________________________"
        line.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' LinkBtnLogin
        ' 
        LinkBtnLogin.Anchor = AnchorStyles.Bottom
        LinkBtnLogin.AutoSize = True
        LinkBtnLogin.Font = New Font("Verdana", 11F)
        LinkBtnLogin.LinkBehavior = LinkBehavior.NeverUnderline
        LinkBtnLogin.Location = New Point(265, 540)
        LinkBtnLogin.Name = "LinkBtnLogin"
        LinkBtnLogin.Size = New Size(47, 18)
        LinkBtnLogin.TabIndex = 36
        LinkBtnLogin.TabStop = True
        LinkBtnLogin.Text = "Login"
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Bottom
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Verdana", 11F)
        Label4.Location = New Point(114, 541)
        Label4.Name = "Label4"
        Label4.Size = New Size(141, 18)
        Label4.TabIndex = 32
        Label4.Text = "Have an account?"
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Verdana", 11F)
        Label5.Location = New Point(259, 88)
        Label5.Name = "Label5"
        Label5.Size = New Size(88, 18)
        Label5.TabIndex = 31
        Label5.Text = "Last Name"
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
        ButtonRounded3.Location = New Point(28, 467)
        ButtonRounded3.Name = "ButtonRounded3"
        ButtonRounded3.Size = New Size(425, 44)
        ButtonRounded3.TabIndex = 28
        ButtonRounded3.Text = "Sign Up"
        ButtonRounded3.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Verdana", 11F)
        Label3.Location = New Point(26, 382)
        Label3.Name = "Label3"
        Label3.Size = New Size(150, 18)
        Label3.TabIndex = 26
        Label3.Text = "Re-enter Password"
        ' 
        ' PanelRound4
        ' 
        PanelRound4.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        PanelRound4.BackColor = Color.WhiteSmoke
        PanelRound4.Controls.Add(reShowHide)
        PanelRound4.Controls.Add(password4)
        PanelRound4.CornerRadius = 8
        PanelRound4.Location = New Point(29, 406)
        PanelRound4.Name = "PanelRound4"
        PanelRound4.Size = New Size(424, 41)
        PanelRound4.TabIndex = 27
        ' 
        ' reShowHide
        ' 
        reShowHide.Anchor = AnchorStyles.Right
        reShowHide.Cursor = Cursors.Hand
        reShowHide.Image = CType(resources.GetObject("reShowHide.Image"), Image)
        reShowHide.Location = New Point(392, 7)
        reShowHide.Name = "reShowHide"
        reShowHide.Size = New Size(25, 25)
        reShowHide.SizeMode = PictureBoxSizeMode.Zoom
        reShowHide.TabIndex = 21
        reShowHide.TabStop = False
        ' 
        ' password4
        ' 
        password4.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        password4.BackColor = Color.WhiteSmoke
        password4.BorderStyle = BorderStyle.None
        password4.Cursor = Cursors.Hand
        password4.Font = New Font("Segoe UI", 12F)
        password4.Location = New Point(5, 10)
        password4.Name = "password4"
        password4.PasswordChar = "●"c
        password4.Size = New Size(381, 22)
        password4.TabIndex = 12
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Verdana", 11F)
        Label2.Location = New Point(26, 308)
        Label2.Name = "Label2"
        Label2.Size = New Size(80, 18)
        Label2.TabIndex = 16
        Label2.Text = "Password"
        ' 
        ' PanelRound3
        ' 
        PanelRound3.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        PanelRound3.BackColor = Color.WhiteSmoke
        PanelRound3.Controls.Add(picShowHide)
        PanelRound3.Controls.Add(password3)
        PanelRound3.CornerRadius = 8
        PanelRound3.Location = New Point(29, 330)
        PanelRound3.Name = "PanelRound3"
        PanelRound3.Size = New Size(424, 41)
        PanelRound3.TabIndex = 17
        ' 
        ' picShowHide
        ' 
        picShowHide.Anchor = AnchorStyles.Right
        picShowHide.Cursor = Cursors.Hand
        picShowHide.Image = CType(resources.GetObject("picShowHide.Image"), Image)
        picShowHide.Location = New Point(392, 7)
        picShowHide.Name = "picShowHide"
        picShowHide.Size = New Size(25, 25)
        picShowHide.SizeMode = PictureBoxSizeMode.Zoom
        picShowHide.TabIndex = 20
        picShowHide.TabStop = False
        ' 
        ' password3
        ' 
        password3.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        password3.BackColor = Color.WhiteSmoke
        password3.BorderStyle = BorderStyle.None
        password3.Cursor = Cursors.Hand
        password3.Font = New Font("Segoe UI", 12F)
        password3.Location = New Point(5, 10)
        password3.Name = "password3"
        password3.PasswordChar = "●"c
        password3.Size = New Size(381, 22)
        password3.TabIndex = 12
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Verdana", 11F)
        Label1.Location = New Point(24, 235)
        Label1.Name = "Label1"
        Label1.Size = New Size(118, 18)
        Label1.TabIndex = 24
        Label1.Text = "Phone Number"
        ' 
        ' PanelRound2
        ' 
        PanelRound2.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        PanelRound2.BackColor = Color.WhiteSmoke
        PanelRound2.Controls.Add(PhoneNumber)
        PanelRound2.CornerRadius = 8
        PanelRound2.Location = New Point(27, 257)
        PanelRound2.Name = "PanelRound2"
        PanelRound2.Size = New Size(424, 41)
        PanelRound2.TabIndex = 25
        ' 
        ' PhoneNumber
        ' 
        PhoneNumber.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        PhoneNumber.BackColor = Color.WhiteSmoke
        PhoneNumber.BorderStyle = BorderStyle.None
        PhoneNumber.Cursor = Cursors.Hand
        PhoneNumber.Font = New Font("Segoe UI", 12F)
        PhoneNumber.Location = New Point(7, 10)
        PhoneNumber.Name = "PhoneNumber"
        PhoneNumber.Size = New Size(414, 22)
        PhoneNumber.TabIndex = 12
        ' 
        ' PanelRound1
        ' 
        PanelRound1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        PanelRound1.BackColor = Color.WhiteSmoke
        PanelRound1.Controls.Add(TxtLastName)
        PanelRound1.CornerRadius = 8
        PanelRound1.Location = New Point(261, 111)
        PanelRound1.Name = "PanelRound1"
        PanelRound1.Size = New Size(190, 41)
        PanelRound1.TabIndex = 15
        ' 
        ' TxtLastName
        ' 
        TxtLastName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TxtLastName.BackColor = Color.WhiteSmoke
        TxtLastName.BorderStyle = BorderStyle.None
        TxtLastName.Cursor = Cursors.Hand
        TxtLastName.Font = New Font("Segoe UI", 12F)
        TxtLastName.Location = New Point(9, 10)
        TxtLastName.Name = "TxtLastName"
        TxtLastName.Size = New Size(176, 22)
        TxtLastName.TabIndex = 11
        ' 
        ' LblHAA
        ' 
        LblHAA.Anchor = AnchorStyles.Bottom
        LblHAA.AutoSize = True
        LblHAA.Font = New Font("Verdana", 11F)
        LblHAA.Location = New Point(253, 1031)
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
        LinkBtnSignup.Location = New Point(452, 1031)
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
        LblDHA.Location = New Point(265, 1031)
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
        lblEmail.Location = New Point(24, 89)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(89, 18)
        lblEmail.TabIndex = 5
        lblEmail.Text = "First Name"
        ' 
        ' lblUserLevel
        ' 
        lblUserLevel.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblUserLevel.Font = New Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblUserLevel.Location = New Point(6, 34)
        lblUserLevel.Name = "lblUserLevel"
        lblUserLevel.Size = New Size(466, 25)
        lblUserLevel.TabIndex = 1
        lblUserLevel.Text = "Create Account"
        lblUserLevel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblPassword
        ' 
        lblPassword.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblPassword.AutoSize = True
        lblPassword.BackColor = Color.Transparent
        lblPassword.Font = New Font("Verdana", 11F)
        lblPassword.Location = New Point(24, 163)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(111, 18)
        lblPassword.TabIndex = 8
        lblPassword.Text = "Email Address"
        ' 
        ' pnlPassword
        ' 
        pnlPassword.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlPassword.BackColor = Color.WhiteSmoke
        pnlPassword.Controls.Add(txtEmail)
        pnlPassword.CornerRadius = 8
        pnlPassword.Location = New Point(27, 185)
        pnlPassword.Name = "pnlPassword"
        pnlPassword.Size = New Size(424, 41)
        pnlPassword.TabIndex = 15
        ' 
        ' txtEmail
        ' 
        txtEmail.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtEmail.BackColor = Color.WhiteSmoke
        txtEmail.BorderStyle = BorderStyle.None
        txtEmail.Cursor = Cursors.Hand
        txtEmail.Font = New Font("Segoe UI", 12F)
        txtEmail.Location = New Point(7, 10)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(414, 22)
        txtEmail.TabIndex = 12
        ' 
        ' pnlEmail
        ' 
        pnlEmail.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlEmail.BackColor = Color.WhiteSmoke
        pnlEmail.Controls.Add(txtFirstName)
        pnlEmail.CornerRadius = 8
        pnlEmail.Location = New Point(26, 111)
        pnlEmail.Name = "pnlEmail"
        pnlEmail.Size = New Size(190, 41)
        pnlEmail.TabIndex = 14
        ' 
        ' txtFirstName
        ' 
        txtFirstName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtFirstName.BackColor = Color.WhiteSmoke
        txtFirstName.BorderStyle = BorderStyle.None
        txtFirstName.Cursor = Cursors.Hand
        txtFirstName.Font = New Font("Segoe UI", 12F)
        txtFirstName.Location = New Point(8, 10)
        txtFirstName.Name = "txtFirstName"
        txtFirstName.Size = New Size(179, 22)
        txtFirstName.TabIndex = 11
        ' 
        ' SubscriberSignup
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(pnlLoginCard)
        Name = "SubscriberSignup"
        Size = New Size(472, 580)
        pnlLoginCard.ResumeLayout(False)
        pnlLoginCard.PerformLayout()
        PanelRound4.ResumeLayout(False)
        PanelRound4.PerformLayout()
        CType(reShowHide, ComponentModel.ISupportInitialize).EndInit()
        PanelRound3.ResumeLayout(False)
        PanelRound3.PerformLayout()
        CType(picShowHide, ComponentModel.ISupportInitialize).EndInit()
        PanelRound2.ResumeLayout(False)
        PanelRound2.PerformLayout()
        PanelRound1.ResumeLayout(False)
        PanelRound1.PerformLayout()
        pnlPassword.ResumeLayout(False)
        pnlPassword.PerformLayout()
        pnlEmail.ResumeLayout(False)
        pnlEmail.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlLoginCard As PanelRound
    Friend WithEvents PanelRound1 As PanelRound
    Friend WithEvents TxtLastName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LblHAA As Label
    Friend WithEvents LinkBtnSignup As LinkLabel
    Friend WithEvents LblDHA As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblUserLevel As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents pnlPassword As PanelRound
    Friend WithEvents picShowHide As PictureBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents pnlEmail As PanelRound
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents PanelRound4 As PanelRound
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents password4 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PanelRound3 As PanelRound
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents password3 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PanelRound2 As PanelRound
    Friend WithEvents reShowHide As PictureBox
    Friend WithEvents PhoneNumber As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents ButtonRounded4 As ButtonRounded
    Friend WithEvents ButtonRounded2 As ButtonRounded
    Friend WithEvents ButtonRounded1 As ButtonRounded
    Friend WithEvents PanelRound5 As PanelRound
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents ButtonRounded3 As ButtonRounded
    Friend WithEvents Label4 As Label
    Friend WithEvents LinkBtnLogin As LinkLabel
    Friend WithEvents line As Label

End Class

