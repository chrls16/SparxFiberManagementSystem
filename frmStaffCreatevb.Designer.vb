<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStaffCreatevb
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStaffCreatevb))
        txtFirstname = New TextBox()
        LblName = New Label()
        LblCreate = New Label()
        cbAddress = New ComboBox()
        cbPosition = New ComboBox()
        LblPosition = New Label()
        DateTimePicker1 = New DateTimePicker()
        txtContactNumber = New TextBox()
        LblAddress = New Label()
        LblContactNumber = New Label()
        LblDateHired = New Label()
        LblBirthdate = New Label()
        DateBirthPicker = New DateTimePicker()
        TxTUsername = New TextBox()
        LblUN = New Label()
        TxtDepartment = New ComboBox()
        LblDepartment = New Label()
        picShowHide = New PictureBox()
        txtPassword = New TextBox()
        LblPassword = New Label()
        btnCreate = New ButtonRounded()
        btnCancel = New ButtonRounded()
        txtDailyRate = New TextBox()
        cbStatus = New ComboBox()
        txtEmailAddress = New TextBox()
        LblEmailAddress = New Label()
        LblDailyRate = New Label()
        LblStatus = New Label()
        cbAccessLevel = New ComboBox()
        labelAccess = New Label()
        txtLastname = New TextBox()
        Label1 = New Label()
        CType(picShowHide, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtFirstname
        ' 
        txtFirstname.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtFirstname.BackColor = Color.WhiteSmoke
        txtFirstname.BorderStyle = BorderStyle.FixedSingle
        txtFirstname.Cursor = Cursors.Hand
        txtFirstname.Font = New Font("Segoe UI", 12F)
        txtFirstname.ForeColor = SystemColors.WindowText
        txtFirstname.Location = New Point(175, 65)
        txtFirstname.Name = "txtFirstname"
        txtFirstname.Size = New Size(257, 29)
        txtFirstname.TabIndex = 72
        ' 
        ' LblName
        ' 
        LblName.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblName.AutoSize = True
        LblName.BackColor = Color.Transparent
        LblName.Font = New Font("Verdana", 11F)
        LblName.Location = New Point(27, 65)
        LblName.Name = "LblName"
        LblName.Size = New Size(89, 18)
        LblName.TabIndex = 65
        LblName.Text = "First Name"
        ' 
        ' LblCreate
        ' 
        LblCreate.AutoSize = True
        LblCreate.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblCreate.Location = New Point(23, 16)
        LblCreate.Name = "LblCreate"
        LblCreate.Size = New Size(69, 25)
        LblCreate.TabIndex = 64
        LblCreate.Text = "Create"
        ' 
        ' cbAddress
        ' 
        cbAddress.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cbAddress.AutoCompleteSource = AutoCompleteSource.ListItems
        cbAddress.FormattingEnabled = True
        cbAddress.Items.AddRange(New Object() {"Active", "Cancelled", "Suspended"})
        cbAddress.Location = New Point(175, 318)
        cbAddress.Margin = New Padding(3, 2, 3, 2)
        cbAddress.Name = "cbAddress"
        cbAddress.Size = New Size(257, 23)
        cbAddress.TabIndex = 105
        ' 
        ' cbPosition
        ' 
        cbPosition.DropDownStyle = ComboBoxStyle.DropDownList
        cbPosition.FormattingEnabled = True
        cbPosition.Items.AddRange(New Object() {"Customer Service", "Inventory Staff", "Technician"})
        cbPosition.Location = New Point(175, 411)
        cbPosition.Margin = New Padding(3, 2, 3, 2)
        cbPosition.Name = "cbPosition"
        cbPosition.Size = New Size(257, 23)
        cbPosition.TabIndex = 101
        ' 
        ' LblPosition
        ' 
        LblPosition.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblPosition.AutoSize = True
        LblPosition.BackColor = Color.Transparent
        LblPosition.Font = New Font("Verdana", 11F)
        LblPosition.Location = New Point(27, 415)
        LblPosition.Name = "LblPosition"
        LblPosition.Size = New Size(66, 18)
        LblPosition.TabIndex = 100
        LblPosition.Text = "Position"
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(175, 368)
        DateTimePicker1.Margin = New Padding(3, 2, 3, 2)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(257, 23)
        DateTimePicker1.TabIndex = 95
        ' 
        ' txtContactNumber
        ' 
        txtContactNumber.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtContactNumber.BackColor = Color.WhiteSmoke
        txtContactNumber.BorderStyle = BorderStyle.FixedSingle
        txtContactNumber.Cursor = Cursors.Hand
        txtContactNumber.Font = New Font("Segoe UI", 12F)
        txtContactNumber.ForeColor = SystemColors.WindowText
        txtContactNumber.Location = New Point(175, 214)
        txtContactNumber.Name = "txtContactNumber"
        txtContactNumber.Size = New Size(257, 29)
        txtContactNumber.TabIndex = 93
        ' 
        ' LblAddress
        ' 
        LblAddress.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblAddress.AutoSize = True
        LblAddress.BackColor = Color.Transparent
        LblAddress.Font = New Font("Verdana", 11F)
        LblAddress.Location = New Point(27, 318)
        LblAddress.Name = "LblAddress"
        LblAddress.Size = New Size(67, 18)
        LblAddress.TabIndex = 92
        LblAddress.Text = "Address"
        ' 
        ' LblContactNumber
        ' 
        LblContactNumber.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblContactNumber.AutoSize = True
        LblContactNumber.BackColor = Color.Transparent
        LblContactNumber.Font = New Font("Verdana", 11F)
        LblContactNumber.Location = New Point(27, 214)
        LblContactNumber.Name = "LblContactNumber"
        LblContactNumber.Size = New Size(131, 18)
        LblContactNumber.TabIndex = 90
        LblContactNumber.Text = "Contact Number"
        ' 
        ' LblDateHired
        ' 
        LblDateHired.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblDateHired.AutoSize = True
        LblDateHired.BackColor = Color.Transparent
        LblDateHired.Font = New Font("Verdana", 11F)
        LblDateHired.Location = New Point(27, 368)
        LblDateHired.Name = "LblDateHired"
        LblDateHired.Size = New Size(86, 18)
        LblDateHired.TabIndex = 87
        LblDateHired.Text = "Date Hired"
        ' 
        ' LblBirthdate
        ' 
        LblBirthdate.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblBirthdate.AutoSize = True
        LblBirthdate.BackColor = Color.Transparent
        LblBirthdate.Font = New Font("Verdana", 11F)
        LblBirthdate.Location = New Point(27, 164)
        LblBirthdate.Name = "LblBirthdate"
        LblBirthdate.Size = New Size(75, 18)
        LblBirthdate.TabIndex = 106
        LblBirthdate.Text = "Birthdate"
        ' 
        ' DateBirthPicker
        ' 
        DateBirthPicker.Location = New Point(175, 164)
        DateBirthPicker.Margin = New Padding(3, 2, 3, 2)
        DateBirthPicker.Name = "DateBirthPicker"
        DateBirthPicker.Size = New Size(257, 23)
        DateBirthPicker.TabIndex = 107
        ' 
        ' TxTUsername
        ' 
        TxTUsername.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TxTUsername.BackColor = Color.WhiteSmoke
        TxTUsername.BorderStyle = BorderStyle.FixedSingle
        TxTUsername.Cursor = Cursors.Hand
        TxTUsername.Font = New Font("Segoe UI", 12F)
        TxTUsername.ForeColor = SystemColors.WindowText
        TxTUsername.Location = New Point(175, 268)
        TxTUsername.Name = "TxTUsername"
        TxTUsername.Size = New Size(257, 29)
        TxTUsername.TabIndex = 109
        ' 
        ' LblUN
        ' 
        LblUN.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblUN.AutoSize = True
        LblUN.BackColor = Color.Transparent
        LblUN.Font = New Font("Verdana", 11F)
        LblUN.Location = New Point(27, 268)
        LblUN.Name = "LblUN"
        LblUN.Size = New Size(84, 18)
        LblUN.TabIndex = 108
        LblUN.Text = "Username"
        ' 
        ' TxtDepartment
        ' 
        TxtDepartment.DropDownStyle = ComboBoxStyle.DropDownList
        TxtDepartment.FormattingEnabled = True
        TxtDepartment.Items.AddRange(New Object() {"Billing", "Support", "Operations"})
        TxtDepartment.Location = New Point(175, 451)
        TxtDepartment.Margin = New Padding(3, 2, 3, 2)
        TxtDepartment.Name = "TxtDepartment"
        TxtDepartment.Size = New Size(257, 23)
        TxtDepartment.TabIndex = 111
        ' 
        ' LblDepartment
        ' 
        LblDepartment.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblDepartment.AutoSize = True
        LblDepartment.BackColor = Color.Transparent
        LblDepartment.Font = New Font("Verdana", 11F)
        LblDepartment.Location = New Point(27, 455)
        LblDepartment.Name = "LblDepartment"
        LblDepartment.Size = New Size(97, 18)
        LblDepartment.TabIndex = 110
        LblDepartment.Text = "Department"
        ' 
        ' picShowHide
        ' 
        picShowHide.Anchor = AnchorStyles.Right
        picShowHide.Cursor = Cursors.Hand
        picShowHide.Image = CType(resources.GetObject("picShowHide.Image"), Image)
        picShowHide.Location = New Point(407, 586)
        picShowHide.Name = "picShowHide"
        picShowHide.Size = New Size(20, 16)
        picShowHide.SizeMode = PictureBoxSizeMode.Zoom
        picShowHide.TabIndex = 122
        picShowHide.TabStop = False
        ' 
        ' txtPassword
        ' 
        txtPassword.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtPassword.BackColor = Color.WhiteSmoke
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        txtPassword.Cursor = Cursors.Hand
        txtPassword.Font = New Font("Segoe UI", 12F)
        txtPassword.ForeColor = SystemColors.WindowText
        txtPassword.Location = New Point(175, 580)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(257, 29)
        txtPassword.TabIndex = 121
        ' 
        ' LblPassword
        ' 
        LblPassword.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblPassword.AutoSize = True
        LblPassword.BackColor = Color.Transparent
        LblPassword.Font = New Font("Verdana", 11F)
        LblPassword.Location = New Point(27, 580)
        LblPassword.Name = "LblPassword"
        LblPassword.Size = New Size(80, 18)
        LblPassword.TabIndex = 120
        LblPassword.Text = "Password"
        ' 
        ' btnCreate
        ' 
        btnCreate.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        btnCreate.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnCreate.CornerRadius = 8
        btnCreate.Cursor = Cursors.Hand
        btnCreate.FlatAppearance.BorderSize = 0
        btnCreate.FlatStyle = FlatStyle.Flat
        btnCreate.Font = New Font("Segoe UI", 12F)
        btnCreate.ForeColor = Color.White
        btnCreate.ImageAlign = ContentAlignment.MiddleLeft
        btnCreate.Location = New Point(320, 742)
        btnCreate.Name = "btnCreate"
        btnCreate.Size = New Size(112, 28)
        btnCreate.TabIndex = 119
        btnCreate.Text = "Create"
        btnCreate.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        btnCancel.BackColor = Color.Red
        btnCancel.CornerRadius = 8
        btnCancel.Cursor = Cursors.Hand
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 12F)
        btnCancel.ForeColor = Color.White
        btnCancel.ImageAlign = ContentAlignment.MiddleLeft
        btnCancel.Location = New Point(189, 742)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(112, 28)
        btnCancel.TabIndex = 118
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' txtDailyRate
        ' 
        txtDailyRate.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtDailyRate.BackColor = Color.LightGray
        txtDailyRate.BorderStyle = BorderStyle.FixedSingle
        txtDailyRate.Cursor = Cursors.Hand
        txtDailyRate.Font = New Font("Segoe UI", 12F)
        txtDailyRate.ForeColor = SystemColors.WindowText
        txtDailyRate.Location = New Point(175, 632)
        txtDailyRate.Name = "txtDailyRate"
        txtDailyRate.ReadOnly = True
        txtDailyRate.Size = New Size(257, 29)
        txtDailyRate.TabIndex = 117
        ' 
        ' cbStatus
        ' 
        cbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cbStatus.FormattingEnabled = True
        cbStatus.Items.AddRange(New Object() {"Active", "Cancelled", "Suspended"})
        cbStatus.Location = New Point(175, 682)
        cbStatus.Margin = New Padding(3, 2, 3, 2)
        cbStatus.Name = "cbStatus"
        cbStatus.Size = New Size(257, 23)
        cbStatus.TabIndex = 116
        ' 
        ' txtEmailAddress
        ' 
        txtEmailAddress.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtEmailAddress.BackColor = Color.WhiteSmoke
        txtEmailAddress.BorderStyle = BorderStyle.FixedSingle
        txtEmailAddress.Cursor = Cursors.Hand
        txtEmailAddress.Font = New Font("Segoe UI", 12F)
        txtEmailAddress.ForeColor = SystemColors.WindowText
        txtEmailAddress.Location = New Point(175, 532)
        txtEmailAddress.Name = "txtEmailAddress"
        txtEmailAddress.Size = New Size(257, 29)
        txtEmailAddress.TabIndex = 115
        ' 
        ' LblEmailAddress
        ' 
        LblEmailAddress.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblEmailAddress.AutoSize = True
        LblEmailAddress.BackColor = Color.Transparent
        LblEmailAddress.Font = New Font("Verdana", 11F)
        LblEmailAddress.Location = New Point(27, 532)
        LblEmailAddress.Name = "LblEmailAddress"
        LblEmailAddress.Size = New Size(111, 18)
        LblEmailAddress.TabIndex = 114
        LblEmailAddress.Text = "Email Address"
        ' 
        ' LblDailyRate
        ' 
        LblDailyRate.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblDailyRate.AutoSize = True
        LblDailyRate.BackColor = Color.Transparent
        LblDailyRate.Font = New Font("Verdana", 11F)
        LblDailyRate.Location = New Point(27, 636)
        LblDailyRate.Name = "LblDailyRate"
        LblDailyRate.Size = New Size(82, 18)
        LblDailyRate.TabIndex = 113
        LblDailyRate.Text = "Daily Rate"
        ' 
        ' LblStatus
        ' 
        LblStatus.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblStatus.AutoSize = True
        LblStatus.BackColor = Color.Transparent
        LblStatus.Font = New Font("Verdana", 11F)
        LblStatus.Location = New Point(27, 686)
        LblStatus.Name = "LblStatus"
        LblStatus.Size = New Size(56, 18)
        LblStatus.TabIndex = 112
        LblStatus.Text = "Status"
        ' 
        ' cbAccessLevel
        ' 
        cbAccessLevel.FormattingEnabled = True
        cbAccessLevel.Items.AddRange(New Object() {"1", "2", "3"})
        cbAccessLevel.Location = New Point(175, 491)
        cbAccessLevel.Name = "cbAccessLevel"
        cbAccessLevel.Size = New Size(257, 23)
        cbAccessLevel.TabIndex = 123
        ' 
        ' labelAccess
        ' 
        labelAccess.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        labelAccess.AutoSize = True
        labelAccess.BackColor = Color.Transparent
        labelAccess.Font = New Font("Verdana", 11F)
        labelAccess.Location = New Point(27, 496)
        labelAccess.Name = "labelAccess"
        labelAccess.Size = New Size(102, 18)
        labelAccess.TabIndex = 124
        labelAccess.Text = "Access Level"
        ' 
        ' txtLastname
        ' 
        txtLastname.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtLastname.BackColor = Color.WhiteSmoke
        txtLastname.BorderStyle = BorderStyle.FixedSingle
        txtLastname.Cursor = Cursors.Hand
        txtLastname.Font = New Font("Segoe UI", 12F)
        txtLastname.ForeColor = SystemColors.WindowText
        txtLastname.Location = New Point(175, 114)
        txtLastname.Name = "txtLastname"
        txtLastname.Size = New Size(257, 29)
        txtLastname.TabIndex = 126
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Verdana", 11F)
        Label1.Location = New Point(27, 114)
        Label1.Name = "Label1"
        Label1.Size = New Size(88, 18)
        Label1.TabIndex = 125
        Label1.Text = "Last Name"
        ' 
        ' frmStaffCreatevb
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(458, 788)
        Controls.Add(txtLastname)
        Controls.Add(Label1)
        Controls.Add(labelAccess)
        Controls.Add(cbAccessLevel)
        Controls.Add(picShowHide)
        Controls.Add(txtPassword)
        Controls.Add(LblPassword)
        Controls.Add(btnCreate)
        Controls.Add(btnCancel)
        Controls.Add(txtDailyRate)
        Controls.Add(cbStatus)
        Controls.Add(txtEmailAddress)
        Controls.Add(LblEmailAddress)
        Controls.Add(LblDailyRate)
        Controls.Add(LblStatus)
        Controls.Add(TxtDepartment)
        Controls.Add(LblDepartment)
        Controls.Add(TxTUsername)
        Controls.Add(LblUN)
        Controls.Add(DateBirthPicker)
        Controls.Add(LblBirthdate)
        Controls.Add(cbAddress)
        Controls.Add(cbPosition)
        Controls.Add(LblPosition)
        Controls.Add(DateTimePicker1)
        Controls.Add(txtContactNumber)
        Controls.Add(LblAddress)
        Controls.Add(LblContactNumber)
        Controls.Add(LblDateHired)
        Controls.Add(txtFirstname)
        Controls.Add(LblName)
        Controls.Add(LblCreate)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmStaffCreatevb"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmStaffCreatevb"
        CType(picShowHide, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents txtFirstname As TextBox
    Friend WithEvents LblName As Label
    Friend WithEvents LblCreate As Label
    Friend WithEvents cbAddress As ComboBox
    Friend WithEvents cbPosition As ComboBox
    Friend WithEvents LblPosition As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents txtContactNumber As TextBox
    Friend WithEvents LblAddress As Label
    Friend WithEvents LblContactNumber As Label
    Friend WithEvents LblDateHired As Label
    Friend WithEvents LblBirthdate As Label
    Friend WithEvents DateBirthPicker As DateTimePicker
    Friend WithEvents TxTUsername As TextBox
    Friend WithEvents LblUN As Label
    Friend WithEvents TxtDepartment As ComboBox
    Friend WithEvents LblDepartment As Label
    Friend WithEvents picShowHide As PictureBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents LblPassword As Label
    Friend WithEvents btnCreate As ButtonRounded
    Friend WithEvents btnCancel As ButtonRounded
    Friend WithEvents txtDailyRate As TextBox
    Friend WithEvents cbStatus As ComboBox
    Friend WithEvents txtEmailAddress As TextBox
    Friend WithEvents LblEmailAddress As Label
    Friend WithEvents LblDailyRate As Label
    Friend WithEvents LblStatus As Label
    Friend WithEvents cbAccessLevel As ComboBox
    Friend WithEvents labelAccess As Label
    Friend WithEvents txtLastname As TextBox
    Friend WithEvents Label1 As Label
End Class
