<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigurationPage
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        pnlHeader = New Panel()
        PictureBox4 = New PictureBox()
        PanelRound1 = New PanelRound()
        PictureBox3 = New PictureBox()
        LabelSystemOnline = New Label()
        PictureBox1 = New PictureBox()
        lblIPConfig = New Label()
        lblServer = New Label()
        txtServer = New TextBox()
        LblHost = New Label()
        txtHost = New TextBox()
        LblPort = New Label()
        txtPort = New TextBox()
        LblProtocol = New Label()
        LblUsername = New Label()
        TxtUN = New TextBox()
        cbProtocol = New ComboBox()
        LblConnectionTimeout = New Label()
        txtConnectionTimeout = New TextBox()
        LblPassword = New Label()
        TextBox1 = New TextBox()
        btnCancel = New ButtonRounded()
        btnUpdate = New ButtonRounded()
        pnlHeader.SuspendLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        PanelRound1.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.LightSteelBlue
        pnlHeader.Controls.Add(PictureBox4)
        pnlHeader.Controls.Add(PanelRound1)
        pnlHeader.Controls.Add(PictureBox1)
        pnlHeader.Controls.Add(lblIPConfig)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(542, 51)
        pnlHeader.TabIndex = 1
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Anchor = AnchorStyles.Top
        PictureBox4.Image = My.Resources.Resources.redDot
        PictureBox4.Location = New Point(1892, 20)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(12, 10)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 7
        PictureBox4.TabStop = False
        ' 
        ' PanelRound1
        ' 
        PanelRound1.Anchor = AnchorStyles.Top
        PanelRound1.BackColor = SystemColors.Control
        PanelRound1.Controls.Add(PictureBox3)
        PanelRound1.Controls.Add(LabelSystemOnline)
        PanelRound1.CornerRadius = 8
        PanelRound1.Location = New Point(1696, 20)
        PanelRound1.Name = "PanelRound1"
        PanelRound1.Size = New Size(176, 31)
        PanelRound1.TabIndex = 5
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Location = New Point(3, 3)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(24, 25)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 6
        PictureBox3.TabStop = False
        ' 
        ' LabelSystemOnline
        ' 
        LabelSystemOnline.AutoSize = True
        LabelSystemOnline.Font = New Font("Verdana", 10F)
        LabelSystemOnline.Location = New Point(33, 6)
        LabelSystemOnline.Name = "LabelSystemOnline"
        LabelSystemOnline.Size = New Size(141, 17)
        LabelSystemOnline.TabIndex = 0
        LabelSystemOnline.Text = "Configuration Page"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top
        PictureBox1.Image = My.Resources.Resources.notificationBell
        PictureBox1.Location = New Point(1878, 23)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(24, 24)
        PictureBox1.TabIndex = 4
        PictureBox1.TabStop = False
        ' 
        ' lblIPConfig
        ' 
        lblIPConfig.AutoSize = True
        lblIPConfig.Font = New Font("Verdana", 12F)
        lblIPConfig.Location = New Point(26, 16)
        lblIPConfig.Name = "lblIPConfig"
        lblIPConfig.Size = New Size(83, 18)
        lblIPConfig.TabIndex = 0
        lblIPConfig.Text = "IP Config"
        ' 
        ' lblServer
        ' 
        lblServer.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblServer.AutoSize = True
        lblServer.BackColor = Color.Transparent
        lblServer.Font = New Font("Verdana", 11F)
        lblServer.Location = New Point(79, 81)
        lblServer.Name = "lblServer"
        lblServer.Size = New Size(57, 18)
        lblServer.TabIndex = 71
        lblServer.Text = "Server"
        ' 
        ' txtServer
        ' 
        txtServer.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtServer.BackColor = Color.WhiteSmoke
        txtServer.BorderStyle = BorderStyle.FixedSingle
        txtServer.Cursor = Cursors.Hand
        txtServer.Enabled = True
        txtServer.Font = New Font("Segoe UI", 12F)
        txtServer.ForeColor = SystemColors.WindowText
        txtServer.Location = New Point(188, 77)
        txtServer.Name = "txtServer"
        txtServer.Size = New Size(265, 29)
        txtServer.TabIndex = 84
        txtServer.TabStop = False
        txtServer.TextAlign = HorizontalAlignment.Center
        ' 
        ' LblHost
        ' 
        LblHost.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblHost.AutoSize = True
        LblHost.BackColor = Color.Transparent
        LblHost.Font = New Font("Verdana", 11F)
        LblHost.Location = New Point(81, 134)
        LblHost.Name = "LblHost"
        LblHost.Size = New Size(43, 18)
        LblHost.TabIndex = 85
        LblHost.Text = "Host"
        ' 
        ' txtHost
        ' 
        txtHost.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtHost.BackColor = Color.WhiteSmoke
        txtHost.BorderStyle = BorderStyle.FixedSingle
        txtHost.Cursor = Cursors.Hand
        txtHost.Enabled = True
        txtHost.Font = New Font("Segoe UI", 12F)
        txtHost.ForeColor = SystemColors.WindowText
        txtHost.Location = New Point(188, 134)
        txtHost.Name = "txtHost"
        txtHost.Size = New Size(265, 29)
        txtHost.TabIndex = 86
        txtHost.TabStop = False
        txtHost.TextAlign = HorizontalAlignment.Center
        ' 
        ' LblPort
        ' 
        LblPort.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblPort.AutoSize = True
        LblPort.BackColor = Color.Transparent
        LblPort.Font = New Font("Verdana", 11F)
        LblPort.Location = New Point(81, 187)
        LblPort.Name = "LblPort"
        LblPort.Size = New Size(39, 18)
        LblPort.TabIndex = 87
        LblPort.Text = "Port"
        ' 
        ' txtPort
        ' 
        txtPort.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtPort.BackColor = Color.WhiteSmoke
        txtPort.BorderStyle = BorderStyle.FixedSingle
        txtPort.Cursor = Cursors.Hand
        txtPort.Enabled = True
        txtPort.Font = New Font("Segoe UI", 12F)
        txtPort.ForeColor = SystemColors.WindowText
        txtPort.Location = New Point(188, 183)
        txtPort.Name = "txtPort"
        txtPort.Size = New Size(265, 29)
        txtPort.TabIndex = 88
        txtPort.TabStop = False
        txtPort.TextAlign = HorizontalAlignment.Center
        ' 
        ' LblProtocol
        ' 
        LblProtocol.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblProtocol.AutoSize = True
        LblProtocol.BackColor = Color.Transparent
        LblProtocol.Font = New Font("Verdana", 11F)
        LblProtocol.Location = New Point(81, 241)
        LblProtocol.Name = "LblProtocol"
        LblProtocol.Size = New Size(70, 18)
        LblProtocol.TabIndex = 89
        LblProtocol.Text = "Protocol"
        ' 
        ' LblUsername
        ' 
        LblUsername.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblUsername.AutoSize = True
        LblUsername.BackColor = Color.Transparent
        LblUsername.Font = New Font("Verdana", 11F)
        LblUsername.Location = New Point(81, 294)
        LblUsername.Name = "LblUsername"
        LblUsername.Size = New Size(84, 18)
        LblUsername.TabIndex = 91
        LblUsername.Text = "Username"
        ' 
        ' TxtUN
        ' 
        TxtUN.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TxtUN.BackColor = Color.WhiteSmoke
        TxtUN.BorderStyle = BorderStyle.FixedSingle
        TxtUN.Cursor = Cursors.Hand
        TxtUN.Enabled = True
        TxtUN.Font = New Font("Segoe UI", 12F)
        TxtUN.ForeColor = SystemColors.WindowText
        TxtUN.Location = New Point(188, 290)
        TxtUN.Name = "TxtUN"
        TxtUN.Size = New Size(265, 29)
        TxtUN.TabIndex = 92
        TxtUN.TabStop = False
        TxtUN.TextAlign = HorizontalAlignment.Center
        ' 
        ' cbProtocol
        ' 
        cbProtocol.DropDownStyle = ComboBoxStyle.DropDownList
        cbProtocol.Font = New Font("Segoe UI", 12F)
        cbProtocol.FormattingEnabled = True
        cbProtocol.Items.AddRange(New Object() {"None", "Preferred", "Required"})
        cbProtocol.Location = New Point(188, 236)
        cbProtocol.Margin = New Padding(3, 2, 3, 2)
        cbProtocol.Name = "cbProtocol"
        cbProtocol.Size = New Size(267, 29)
        cbProtocol.TabIndex = 93
        ' 
        ' LblConnectionTimeout
        ' 
        LblConnectionTimeout.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblConnectionTimeout.AutoSize = True
        LblConnectionTimeout.BackColor = Color.Transparent
        LblConnectionTimeout.Font = New Font("Verdana", 11F)
        LblConnectionTimeout.Location = New Point(79, 394)
        LblConnectionTimeout.Name = "LblConnectionTimeout"
        LblConnectionTimeout.Size = New Size(158, 18)
        LblConnectionTimeout.TabIndex = 94
        LblConnectionTimeout.Text = "Connection Timeout"
        ' 
        ' txtConnectionTimeout
        ' 
        txtConnectionTimeout.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtConnectionTimeout.BackColor = Color.WhiteSmoke
        txtConnectionTimeout.BorderStyle = BorderStyle.FixedSingle
        txtConnectionTimeout.Cursor = Cursors.Hand
        txtConnectionTimeout.Enabled = True
        txtConnectionTimeout.Font = New Font("Segoe UI", 12F)
        txtConnectionTimeout.ForeColor = SystemColors.WindowText
        txtConnectionTimeout.Location = New Point(264, 390)
        txtConnectionTimeout.Name = "txtConnectionTimeout"
        txtConnectionTimeout.Size = New Size(189, 29)
        txtConnectionTimeout.TabIndex = 95
        txtConnectionTimeout.TabStop = False
        txtConnectionTimeout.TextAlign = HorizontalAlignment.Center
        ' 
        ' LblPassword
        ' 
        LblPassword.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblPassword.AutoSize = True
        LblPassword.BackColor = Color.Transparent
        LblPassword.Font = New Font("Verdana", 11F)
        LblPassword.Location = New Point(81, 344)
        LblPassword.Name = "LblPassword"
        LblPassword.Size = New Size(80, 18)
        LblPassword.TabIndex = 96
        LblPassword.Text = "Password"
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TextBox1.BackColor = Color.WhiteSmoke
        TextBox1.BorderStyle = BorderStyle.FixedSingle
        TextBox1.Cursor = Cursors.Hand
        TextBox1.Enabled = True
        TextBox1.Font = New Font("Segoe UI", 12F)
        TextBox1.ForeColor = SystemColors.WindowText
        TextBox1.Location = New Point(188, 340)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(265, 29)
        TextBox1.TabIndex = 97
        TextBox1.TabStop = False
        TextBox1.TextAlign = HorizontalAlignment.Center
        ' 
        ' btnCancel
        ' 
        btnCancel.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        btnCancel.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnCancel.CornerRadius = 8
        btnCancel.Cursor = Cursors.Hand
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 12F)
        btnCancel.ForeColor = Color.White
        btnCancel.ImageAlign = ContentAlignment.MiddleLeft
        btnCancel.Location = New Point(296, 465)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(113, 28)
        btnCancel.TabIndex = 98
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        btnUpdate.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnUpdate.CornerRadius = 8
        btnUpdate.Cursor = Cursors.Hand
        btnUpdate.FlatAppearance.BorderSize = 0
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.Font = New Font("Segoe UI", 12F)
        btnUpdate.ForeColor = Color.White
        btnUpdate.ImageAlign = ContentAlignment.MiddleLeft
        btnUpdate.Location = New Point(417, 465)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(113, 28)
        btnUpdate.TabIndex = 99
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' ConfigurationPage
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(542, 516)
        Controls.Add(btnUpdate)
        Controls.Add(btnCancel)
        Controls.Add(TextBox1)
        Controls.Add(LblPassword)
        Controls.Add(txtConnectionTimeout)
        Controls.Add(LblConnectionTimeout)
        Controls.Add(cbProtocol)
        Controls.Add(TxtUN)
        Controls.Add(LblUsername)
        Controls.Add(LblProtocol)
        Controls.Add(txtPort)
        Controls.Add(LblPort)
        Controls.Add(txtHost)
        Controls.Add(LblHost)
        Controls.Add(txtServer)
        Controls.Add(lblServer)
        Controls.Add(pnlHeader)
        FormBorderStyle = FormBorderStyle.None
        Name = "ConfigurationPage"
        Text = "Form1"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        PanelRound1.ResumeLayout(False)
        PanelRound1.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PanelRound1 As PanelRound
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents LabelSystemOnline As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblIPConfig As Label
    Friend WithEvents lblServer As Label
    Friend WithEvents txtServer As TextBox
    Friend WithEvents LblHost As Label
    Friend WithEvents txtHost As TextBox
    Friend WithEvents LblPort As Label
    Friend WithEvents txtPort As TextBox
    Friend WithEvents LblProtocol As Label
    Friend WithEvents LblUsername As Label
    Friend WithEvents TxtUN As TextBox
    Friend WithEvents cbProtocol As ComboBox
    Friend WithEvents LblConnectionTimeout As Label
    Friend WithEvents txtConnectionTimeout As TextBox
    Friend WithEvents LblPassword As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btnCancel As ButtonRounded
    Friend WithEvents btnUpdate As ButtonRounded
End Class
