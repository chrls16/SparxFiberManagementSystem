<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSubscriberUpdate
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        LblUpdate = New Label()
        lblCustomerId = New Label()
        LblName = New Label()
        LblDateInstalled = New Label()
        LblPlanType = New Label()
        LblStatus = New Label()
        LblMonthlyRate = New Label()
        LblContactNumber = New Label()
        LblEmailAddress = New Label()
        LblLandmark = New Label()
        LblPurok = New Label()
        LblBarangay = New Label()
        LblProvince = New Label()
        LblMunicipality = New Label()
        txtID = New TextBox()
        txtName = New TextBox()
        txtContactNumber = New TextBox()
        txtEmailAddress = New TextBox()
        txtLandmark = New TextBox()
        txtPurok = New TextBox()
        txtBarangay = New TextBox()
        txtProvince = New TextBox()
        txtMunicipality = New TextBox()
        DateTimePicker1 = New DateTimePicker()
        DropDownPlanType = New ComboBox()
        DropDownStatus = New ComboBox()
        txtMonthlyRate = New TextBox()
        btnCancel = New ButtonRounded()
        btnUpdate = New ButtonRounded()
        SuspendLayout()
        ' 
        ' LblUpdate
        ' 
        LblUpdate.AutoSize = True
        LblUpdate.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblUpdate.Location = New Point(10, 16)
        LblUpdate.Name = "LblUpdate"
        LblUpdate.Size = New Size(77, 25)
        LblUpdate.TabIndex = 0
        LblUpdate.Text = "Update"
        ' 
        ' lblCustomerId
        ' 
        lblCustomerId.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblCustomerId.AutoSize = True
        lblCustomerId.BackColor = Color.Transparent
        lblCustomerId.Font = New Font("Verdana", 11F)
        lblCustomerId.Location = New Point(14, 60)
        lblCustomerId.Name = "lblCustomerId"
        lblCustomerId.Size = New Size(103, 18)
        lblCustomerId.TabIndex = 1
        lblCustomerId.Text = "Customer ID"
        ' 
        ' LblName
        ' 
        LblName.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblName.AutoSize = True
        LblName.BackColor = Color.Transparent
        LblName.Font = New Font("Verdana", 11F)
        LblName.Location = New Point(16, 111)
        LblName.Name = "LblName"
        LblName.Size = New Size(52, 18)
        LblName.TabIndex = 2
        LblName.Text = "Name"
        ' 
        ' LblDateInstalled
        ' 
        LblDateInstalled.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblDateInstalled.AutoSize = True
        LblDateInstalled.BackColor = Color.Transparent
        LblDateInstalled.Font = New Font("Verdana", 11F)
        LblDateInstalled.Location = New Point(16, 171)
        LblDateInstalled.Name = "LblDateInstalled"
        LblDateInstalled.Size = New Size(109, 18)
        LblDateInstalled.TabIndex = 4
        LblDateInstalled.Text = "Date Installed"
        ' 
        ' LblPlanType
        ' 
        LblPlanType.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblPlanType.AutoSize = True
        LblPlanType.BackColor = Color.Transparent
        LblPlanType.Font = New Font("Verdana", 11F)
        LblPlanType.Location = New Point(16, 216)
        LblPlanType.Name = "LblPlanType"
        LblPlanType.Size = New Size(78, 18)
        LblPlanType.TabIndex = 5
        LblPlanType.Text = "Plan Type"
        ' 
        ' LblStatus
        ' 
        LblStatus.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblStatus.AutoSize = True
        LblStatus.BackColor = Color.Transparent
        LblStatus.Font = New Font("Verdana", 11F)
        LblStatus.Location = New Point(16, 262)
        LblStatus.Name = "LblStatus"
        LblStatus.Size = New Size(56, 18)
        LblStatus.TabIndex = 6
        LblStatus.Text = "Status"
        ' 
        ' LblMonthlyRate
        ' 
        LblMonthlyRate.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblMonthlyRate.AutoSize = True
        LblMonthlyRate.BackColor = Color.Transparent
        LblMonthlyRate.Font = New Font("Verdana", 11F)
        LblMonthlyRate.Location = New Point(16, 309)
        LblMonthlyRate.Name = "LblMonthlyRate"
        LblMonthlyRate.Size = New Size(106, 18)
        LblMonthlyRate.TabIndex = 7
        LblMonthlyRate.Text = "Monthly Rate"
        ' 
        ' LblContactNumber
        ' 
        LblContactNumber.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblContactNumber.AutoSize = True
        LblContactNumber.BackColor = Color.Transparent
        LblContactNumber.Font = New Font("Verdana", 11F)
        LblContactNumber.Location = New Point(16, 360)
        LblContactNumber.Name = "LblContactNumber"
        LblContactNumber.Size = New Size(131, 18)
        LblContactNumber.TabIndex = 8
        LblContactNumber.Text = "Contact Number"
        ' 
        ' LblEmailAddress
        ' 
        LblEmailAddress.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblEmailAddress.AutoSize = True
        LblEmailAddress.BackColor = Color.Transparent
        LblEmailAddress.Font = New Font("Verdana", 11F)
        LblEmailAddress.Location = New Point(16, 410)
        LblEmailAddress.Name = "LblEmailAddress"
        LblEmailAddress.Size = New Size(111, 18)
        LblEmailAddress.TabIndex = 9
        LblEmailAddress.Text = "Email Address"
        ' 
        ' LblLandmark
        ' 
        LblLandmark.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblLandmark.AutoSize = True
        LblLandmark.BackColor = Color.Transparent
        LblLandmark.Font = New Font("Verdana", 11F)
        LblLandmark.Location = New Point(16, 460)
        LblLandmark.Name = "LblLandmark"
        LblLandmark.Size = New Size(82, 18)
        LblLandmark.TabIndex = 10
        LblLandmark.Text = "Landmark"
        ' 
        ' LblPurok
        ' 
        LblPurok.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblPurok.AutoSize = True
        LblPurok.BackColor = Color.Transparent
        LblPurok.Font = New Font("Verdana", 11F)
        LblPurok.Location = New Point(16, 510)
        LblPurok.Name = "LblPurok"
        LblPurok.Size = New Size(51, 18)
        LblPurok.TabIndex = 11
        LblPurok.Text = "Purok"
        ' 
        ' LblBarangay
        ' 
        LblBarangay.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblBarangay.AutoSize = True
        LblBarangay.BackColor = Color.Transparent
        LblBarangay.Font = New Font("Verdana", 11F)
        LblBarangay.Location = New Point(16, 560)
        LblBarangay.Name = "LblBarangay"
        LblBarangay.Size = New Size(78, 18)
        LblBarangay.TabIndex = 12
        LblBarangay.Text = "Barangay"
        ' 
        ' LblProvince
        ' 
        LblProvince.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblProvince.AutoSize = True
        LblProvince.BackColor = Color.Transparent
        LblProvince.Font = New Font("Verdana", 11F)
        LblProvince.Location = New Point(16, 610)
        LblProvince.Name = "LblProvince"
        LblProvince.Size = New Size(71, 18)
        LblProvince.TabIndex = 13
        LblProvince.Text = "Province"
        ' 
        ' LblMunicipality
        ' 
        LblMunicipality.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblMunicipality.AutoSize = True
        LblMunicipality.BackColor = Color.Transparent
        LblMunicipality.Font = New Font("Verdana", 11F)
        LblMunicipality.Location = New Point(16, 660)
        LblMunicipality.Name = "LblMunicipality"
        LblMunicipality.Size = New Size(92, 18)
        LblMunicipality.TabIndex = 14
        LblMunicipality.Text = "Municipality"
        ' 
        ' txtID
        ' 
        txtID.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtID.BackColor = Color.WhiteSmoke
        txtID.BorderStyle = BorderStyle.FixedSingle
        txtID.Cursor = Cursors.Hand
        txtID.Enabled = False
        txtID.Font = New Font("Segoe UI", 12F)
        txtID.ForeColor = SystemColors.WindowText
        txtID.Location = New Point(164, 60)
        txtID.Name = "txtID"
        txtID.ReadOnly = True
        txtID.Size = New Size(137, 29)
        txtID.TabIndex = 15
        ' 
        ' txtName
        ' 
        txtName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtName.BackColor = Color.WhiteSmoke
        txtName.BorderStyle = BorderStyle.FixedSingle
        txtName.Cursor = Cursors.Hand
        txtName.Enabled = False
        txtName.Font = New Font("Segoe UI", 12F)
        txtName.ForeColor = SystemColors.WindowText
        txtName.Location = New Point(164, 111)
        txtName.Name = "txtName"
        txtName.ReadOnly = True
        txtName.Size = New Size(262, 29)
        txtName.TabIndex = 16
        ' 
        ' txtContactNumber
        ' 
        txtContactNumber.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtContactNumber.BackColor = Color.WhiteSmoke
        txtContactNumber.BorderStyle = BorderStyle.FixedSingle
        txtContactNumber.Cursor = Cursors.Hand
        txtContactNumber.Enabled = False
        txtContactNumber.Font = New Font("Segoe UI", 12F)
        txtContactNumber.ForeColor = SystemColors.WindowText
        txtContactNumber.Location = New Point(164, 360)
        txtContactNumber.Name = "txtContactNumber"
        txtContactNumber.ReadOnly = True
        txtContactNumber.Size = New Size(262, 29)
        txtContactNumber.TabIndex = 18
        ' 
        ' txtEmailAddress
        ' 
        txtEmailAddress.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtEmailAddress.BackColor = Color.WhiteSmoke
        txtEmailAddress.BorderStyle = BorderStyle.FixedSingle
        txtEmailAddress.Cursor = Cursors.Hand
        txtEmailAddress.Enabled = False
        txtEmailAddress.Font = New Font("Segoe UI", 12F)
        txtEmailAddress.ForeColor = SystemColors.WindowText
        txtEmailAddress.Location = New Point(164, 410)
        txtEmailAddress.Name = "txtEmailAddress"
        txtEmailAddress.ReadOnly = True
        txtEmailAddress.Size = New Size(262, 29)
        txtEmailAddress.TabIndex = 19
        ' 
        ' txtLandmark
        ' 
        txtLandmark.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtLandmark.BackColor = Color.WhiteSmoke
        txtLandmark.BorderStyle = BorderStyle.FixedSingle
        txtLandmark.Cursor = Cursors.Hand
        txtLandmark.Enabled = False
        txtLandmark.Font = New Font("Segoe UI", 12F)
        txtLandmark.ForeColor = SystemColors.WindowText
        txtLandmark.Location = New Point(164, 460)
        txtLandmark.Name = "txtLandmark"
        txtLandmark.ReadOnly = True
        txtLandmark.Size = New Size(262, 29)
        txtLandmark.TabIndex = 20
        ' 
        ' txtPurok
        ' 
        txtPurok.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtPurok.BackColor = Color.WhiteSmoke
        txtPurok.BorderStyle = BorderStyle.FixedSingle
        txtPurok.Cursor = Cursors.Hand
        txtPurok.Enabled = False
        txtPurok.Font = New Font("Segoe UI", 12F)
        txtPurok.ForeColor = SystemColors.WindowText
        txtPurok.Location = New Point(164, 510)
        txtPurok.Name = "txtPurok"
        txtPurok.ReadOnly = True
        txtPurok.Size = New Size(262, 29)
        txtPurok.TabIndex = 21
        ' 
        ' txtBarangay
        ' 
        txtBarangay.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtBarangay.BackColor = Color.WhiteSmoke
        txtBarangay.BorderStyle = BorderStyle.FixedSingle
        txtBarangay.Cursor = Cursors.Hand
        txtBarangay.Enabled = False
        txtBarangay.Font = New Font("Segoe UI", 12F)
        txtBarangay.ForeColor = SystemColors.WindowText
        txtBarangay.Location = New Point(164, 560)
        txtBarangay.Name = "txtBarangay"
        txtBarangay.ReadOnly = True
        txtBarangay.Size = New Size(262, 29)
        txtBarangay.TabIndex = 22
        ' 
        ' txtProvince
        ' 
        txtProvince.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtProvince.BackColor = Color.WhiteSmoke
        txtProvince.BorderStyle = BorderStyle.FixedSingle
        txtProvince.Cursor = Cursors.Hand
        txtProvince.Enabled = False
        txtProvince.Font = New Font("Segoe UI", 12F)
        txtProvince.ForeColor = SystemColors.WindowText
        txtProvince.Location = New Point(164, 610)
        txtProvince.Name = "txtProvince"
        txtProvince.ReadOnly = True
        txtProvince.Size = New Size(262, 29)
        txtProvince.TabIndex = 23
        ' 
        ' txtMunicipality
        ' 
        txtMunicipality.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtMunicipality.BackColor = Color.WhiteSmoke
        txtMunicipality.BorderStyle = BorderStyle.FixedSingle
        txtMunicipality.Cursor = Cursors.Hand
        txtMunicipality.Enabled = False
        txtMunicipality.Font = New Font("Segoe UI", 12F)
        txtMunicipality.ForeColor = SystemColors.WindowText
        txtMunicipality.Location = New Point(164, 660)
        txtMunicipality.Name = "txtMunicipality"
        txtMunicipality.ReadOnly = True
        txtMunicipality.Size = New Size(262, 29)
        txtMunicipality.TabIndex = 24
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(164, 171)
        DateTimePicker1.Margin = New Padding(3, 2, 3, 2)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(262, 23)
        DateTimePicker1.TabIndex = 25
        ' 
        ' DropDownPlanType
        ' 
        DropDownPlanType.DropDownStyle = ComboBoxStyle.DropDownList
        DropDownPlanType.FormattingEnabled = True
        DropDownPlanType.Items.AddRange(New Object() {"All Plans", "Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})
        DropDownPlanType.Location = New Point(164, 216)
        DropDownPlanType.Margin = New Padding(3, 2, 3, 2)
        DropDownPlanType.Name = "DropDownPlanType"
        DropDownPlanType.Size = New Size(123, 23)
        DropDownPlanType.TabIndex = 26
        ' 
        ' DropDownStatus
        ' 
        DropDownStatus.DropDownStyle = ComboBoxStyle.DropDownList
        DropDownStatus.FormattingEnabled = True
        DropDownStatus.Items.AddRange(New Object() {"Active", "Cancelled", "Suspended"})
        DropDownStatus.Location = New Point(164, 258)
        DropDownStatus.Margin = New Padding(3, 2, 3, 2)
        DropDownStatus.Name = "DropDownStatus"
        DropDownStatus.Size = New Size(123, 23)
        DropDownStatus.TabIndex = 27
        ' 
        ' txtMonthlyRate
        ' 
        txtMonthlyRate.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtMonthlyRate.BackColor = Color.WhiteSmoke
        txtMonthlyRate.BorderStyle = BorderStyle.FixedSingle
        txtMonthlyRate.Cursor = Cursors.Hand
        txtMonthlyRate.Enabled = False
        txtMonthlyRate.Font = New Font("Segoe UI", 12F)
        txtMonthlyRate.ForeColor = SystemColors.WindowText
        txtMonthlyRate.Location = New Point(164, 305)
        txtMonthlyRate.Name = "txtMonthlyRate"
        txtMonthlyRate.ReadOnly = True
        txtMonthlyRate.Size = New Size(262, 29)
        txtMonthlyRate.TabIndex = 28
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
        btnCancel.Location = New Point(210, 725)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(117, 28)
        btnCancel.TabIndex = 29
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
        btnUpdate.Location = New Point(341, 725)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(117, 28)
        btnUpdate.TabIndex = 30
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' frmSubscriberUpdate
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(467, 788)
        Controls.Add(btnUpdate)
        Controls.Add(btnCancel)
        Controls.Add(txtMonthlyRate)
        Controls.Add(DropDownStatus)
        Controls.Add(DropDownPlanType)
        Controls.Add(DateTimePicker1)
        Controls.Add(txtMunicipality)
        Controls.Add(txtProvince)
        Controls.Add(txtBarangay)
        Controls.Add(txtPurok)
        Controls.Add(txtLandmark)
        Controls.Add(txtEmailAddress)
        Controls.Add(txtContactNumber)
        Controls.Add(txtName)
        Controls.Add(txtID)
        Controls.Add(LblMunicipality)
        Controls.Add(LblProvince)
        Controls.Add(LblBarangay)
        Controls.Add(LblPurok)
        Controls.Add(LblLandmark)
        Controls.Add(LblEmailAddress)
        Controls.Add(LblContactNumber)
        Controls.Add(LblMonthlyRate)
        Controls.Add(LblStatus)
        Controls.Add(LblPlanType)
        Controls.Add(LblDateInstalled)
        Controls.Add(LblName)
        Controls.Add(lblCustomerId)
        Controls.Add(LblUpdate)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmSubscriberUpdate"
        StartPosition = FormStartPosition.CenterParent
        Text = "frmSubscriberUpdate"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LblUpdate As Label
    Friend WithEvents lblCustomerId As Label
    Friend WithEvents LblName As Label
    Friend WithEvents LblDateInstalled As Label
    Friend WithEvents LblPlanType As Label
    Friend WithEvents LblStatus As Label
    Friend WithEvents LblMonthlyRate As Label
    Friend WithEvents LblContactNumber As Label
    Friend WithEvents LblEmailAddress As Label
    Friend WithEvents LblLandmark As Label
    Friend WithEvents LblPurok As Label
    Friend WithEvents LblBarangay As Label
    Friend WithEvents LblProvince As Label
    Friend WithEvents LblMunicipality As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtContactNumber As TextBox
    Friend WithEvents txtEmailAddress As TextBox
    Friend WithEvents txtLandmark As TextBox
    Friend WithEvents txtPurok As TextBox
    Friend WithEvents txtBarangay As TextBox
    Friend WithEvents txtProvince As TextBox
    Friend WithEvents txtMunicipality As TextBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DropDownPlanType As ComboBox
    Friend WithEvents DropDownStatus As ComboBox
    Friend WithEvents txtMonthlyRate As TextBox
    Friend WithEvents btnCancel As ButtonRounded
    Friend WithEvents btnUpdate As ButtonRounded
End Class