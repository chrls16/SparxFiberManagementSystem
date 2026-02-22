<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmServiceCreate
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
        PanelCustomerSearch = New Panel()
        txtSearchCustomer = New TextBox()
        btnSearchCustomer = New ButtonRounded()
        lvCustomers = New ListView()
        ColumnHeader1 = New ColumnHeader()
        ColumnHeader2 = New ColumnHeader()
        ColumnHeader3 = New ColumnHeader()
        lblStatus = New Label()
        cbStatus = New ComboBox()
        cbTechnician = New ComboBox()
        txtServiceFee = New TextBox()
        TxtBoxAddress = New TextBox()
        txtCustomer = New TextBox()
        btnUpdate = New ButtonRounded()
        btnCancel = New ButtonRounded()
        cbServiceType = New ComboBox()
        dtpService = New DateTimePicker()
        LblTechnician = New Label()
        LblServiceFee = New Label()
        lblServiceType = New Label()
        LblDate = New Label()
        LblAddress = New Label()
        LblCustomer = New Label()
        LblCreateService = New Label()
        lblSelectedCustomer = New Label()
        txtCustomerPhone = New TextBox()
        LblPhone = New Label()
        dtpTime = New DateTimePicker()
        lblTime = New Label()
        txtServiceDescription = New TextBox()
        lblDescription = New Label()
        chkSendSMS = New CheckBox()
        btnSMSPreview = New ButtonRounded()
        PanelCustomerSearch.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelCustomerSearch
        ' 
        PanelCustomerSearch.BackColor = Color.White
        PanelCustomerSearch.BorderStyle = BorderStyle.FixedSingle
        PanelCustomerSearch.Controls.Add(txtSearchCustomer)
        PanelCustomerSearch.Controls.Add(btnSearchCustomer)
        PanelCustomerSearch.Controls.Add(lvCustomers)
        PanelCustomerSearch.Location = New Point(503, 94)
        PanelCustomerSearch.Name = "PanelCustomerSearch"
        PanelCustomerSearch.Size = New Size(400, 250)
        PanelCustomerSearch.TabIndex = 100
        PanelCustomerSearch.Visible = False
        ' 
        ' txtSearchCustomer
        ' 
        txtSearchCustomer.Font = New Font("Segoe UI", 11F)
        txtSearchCustomer.Location = New Point(10, 10)
        txtSearchCustomer.Name = "txtSearchCustomer"
        txtSearchCustomer.PlaceholderText = "Search by name, phone, or email..."
        txtSearchCustomer.Size = New Size(280, 27)
        txtSearchCustomer.TabIndex = 2
        ' 
        ' btnSearchCustomer
        ' 
        btnSearchCustomer.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnSearchCustomer.CornerRadius = 4
        btnSearchCustomer.FlatAppearance.BorderSize = 0
        btnSearchCustomer.FlatStyle = FlatStyle.Flat
        btnSearchCustomer.Font = New Font("Segoe UI", 10F)
        btnSearchCustomer.ForeColor = Color.White
        btnSearchCustomer.Location = New Point(296, 10)
        btnSearchCustomer.Name = "btnSearchCustomer"
        btnSearchCustomer.Size = New Size(90, 27)
        btnSearchCustomer.TabIndex = 1
        btnSearchCustomer.Text = "Search"
        btnSearchCustomer.UseVisualStyleBackColor = False
        ' 
        ' lvCustomers
        ' 
        lvCustomers.Columns.AddRange(New ColumnHeader() {ColumnHeader1, ColumnHeader2, ColumnHeader3})
        lvCustomers.FullRowSelect = True
        lvCustomers.GridLines = True
        lvCustomers.Location = New Point(10, 45)
        lvCustomers.Name = "lvCustomers"
        lvCustomers.Size = New Size(380, 195)
        lvCustomers.TabIndex = 0
        lvCustomers.UseCompatibleStateImageBehavior = False
        lvCustomers.View = View.Details
        ' 
        ' ColumnHeader1
        ' 
        ColumnHeader1.Text = "Customer Name"
        ColumnHeader1.Width = 150
        ' 
        ' ColumnHeader2
        ' 
        ColumnHeader2.Text = "Phone"
        ColumnHeader2.Width = 120
        ' 
        ' ColumnHeader3
        ' 
        ColumnHeader3.Text = "Email"
        ColumnHeader3.Width = 150
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Font = New Font("Verdana", 11F)
        lblStatus.Location = New Point(19, 470)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(56, 18)
        lblStatus.TabIndex = 62
        lblStatus.Text = "Status"
        ' 
        ' cbStatus
        ' 
        cbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cbStatus.Font = New Font("Segoe UI", 10F)
        cbStatus.FormattingEnabled = True
        cbStatus.Items.AddRange(New Object() {"Requested", "In Progress", "Completed", "Cancelled"})
        cbStatus.Location = New Point(167, 467)
        cbStatus.Name = "cbStatus"
        cbStatus.Size = New Size(304, 25)
        cbStatus.TabIndex = 61
        ' 
        ' cbTechnician
        ' 
        cbTechnician.DropDownStyle = ComboBoxStyle.DropDownList
        cbTechnician.Font = New Font("Segoe UI", 10F)
        cbTechnician.FormattingEnabled = True
        cbTechnician.Location = New Point(167, 427)
        cbTechnician.Name = "cbTechnician"
        cbTechnician.Size = New Size(304, 25)
        cbTechnician.TabIndex = 60
        ' 
        ' txtServiceFee
        ' 
        txtServiceFee.BackColor = Color.WhiteSmoke
        txtServiceFee.BorderStyle = BorderStyle.FixedSingle
        txtServiceFee.Font = New Font("Segoe UI", 12F)
        txtServiceFee.Location = New Point(167, 381)
        txtServiceFee.Name = "txtServiceFee"
        txtServiceFee.ReadOnly = True
        txtServiceFee.Size = New Size(304, 29)
        txtServiceFee.TabIndex = 59
        txtServiceFee.TextAlign = HorizontalAlignment.Center
        ' 
        ' TxtBoxAddress
        ' 
        TxtBoxAddress.BackColor = Color.WhiteSmoke
        TxtBoxAddress.BorderStyle = BorderStyle.FixedSingle
        TxtBoxAddress.Cursor = Cursors.Hand
        TxtBoxAddress.Enabled = False
        TxtBoxAddress.Font = New Font("Segoe UI", 12F)
        TxtBoxAddress.Location = New Point(167, 202)
        TxtBoxAddress.Name = "TxtBoxAddress"
        TxtBoxAddress.ReadOnly = True
        TxtBoxAddress.Size = New Size(300, 29)
        TxtBoxAddress.TabIndex = 53
        TxtBoxAddress.TextAlign = HorizontalAlignment.Center
        ' 
        ' txtCustomer
        ' 
        txtCustomer.BackColor = Color.WhiteSmoke
        txtCustomer.BorderStyle = BorderStyle.FixedSingle
        txtCustomer.Cursor = Cursors.Hand
        txtCustomer.Enabled = False
        txtCustomer.Font = New Font("Segoe UI", 12F)
        txtCustomer.Location = New Point(167, 94)
        txtCustomer.Name = "txtCustomer"
        txtCustomer.ReadOnly = True
        txtCustomer.Size = New Size(300, 29)
        txtCustomer.TabIndex = 52
        txtCustomer.TextAlign = HorizontalAlignment.Center
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnUpdate.CornerRadius = 8
        btnUpdate.Cursor = Cursors.Hand
        btnUpdate.FlatAppearance.BorderSize = 0
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.Font = New Font("Segoe UI", 12F)
        btnUpdate.ForeColor = Color.White
        btnUpdate.Location = New Point(503, 570)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(247, 36)
        btnUpdate.TabIndex = 58
        btnUpdate.Text = "Create"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.Red
        btnCancel.CornerRadius = 8
        btnCancel.Cursor = Cursors.Hand
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 12F)
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(212, 570)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(255, 36)
        btnCancel.TabIndex = 57
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' cbServiceType
        ' 
        cbServiceType.DropDownStyle = ComboBoxStyle.DropDownList
        cbServiceType.Font = New Font("Segoe UI", 10F)
        cbServiceType.FormattingEnabled = True
        cbServiceType.Items.AddRange(New Object() {"Installation", "Repair", "Relocation"})
        cbServiceType.Location = New Point(167, 154)
        cbServiceType.Name = "cbServiceType"
        cbServiceType.Size = New Size(300, 25)
        cbServiceType.TabIndex = 56
        ' 
        ' dtpService
        ' 
        dtpService.Font = New Font("Segoe UI", 10F)
        dtpService.Format = DateTimePickerFormat.Short
        dtpService.Location = New Point(167, 244)
        dtpService.Name = "dtpService"
        dtpService.Size = New Size(140, 25)
        dtpService.TabIndex = 55
        ' 
        ' LblTechnician
        ' 
        LblTechnician.AutoSize = True
        LblTechnician.Font = New Font("Verdana", 11F)
        LblTechnician.Location = New Point(19, 432)
        LblTechnician.Name = "LblTechnician"
        LblTechnician.Size = New Size(82, 18)
        LblTechnician.TabIndex = 54
        LblTechnician.Text = "Technician"
        ' 
        ' LblServiceFee
        ' 
        LblServiceFee.AutoSize = True
        LblServiceFee.Font = New Font("Verdana", 11F)
        LblServiceFee.Location = New Point(19, 386)
        LblServiceFee.Name = "LblServiceFee"
        LblServiceFee.Size = New Size(94, 18)
        LblServiceFee.TabIndex = 50
        LblServiceFee.Text = "Service Fee"
        ' 
        ' lblServiceType
        ' 
        lblServiceType.AutoSize = True
        lblServiceType.Font = New Font("Verdana", 11F)
        lblServiceType.Location = New Point(19, 159)
        lblServiceType.Name = "lblServiceType"
        lblServiceType.Size = New Size(102, 18)
        lblServiceType.TabIndex = 49
        lblServiceType.Text = "Service Type"
        ' 
        ' LblDate
        ' 
        LblDate.AutoSize = True
        LblDate.Font = New Font("Verdana", 11F)
        LblDate.Location = New Point(19, 249)
        LblDate.Name = "LblDate"
        LblDate.Size = New Size(43, 18)
        LblDate.TabIndex = 48
        LblDate.Text = "Date"
        ' 
        ' LblAddress
        ' 
        LblAddress.AutoSize = True
        LblAddress.Font = New Font("Verdana", 11F)
        LblAddress.Location = New Point(19, 207)
        LblAddress.Name = "LblAddress"
        LblAddress.Size = New Size(67, 18)
        LblAddress.TabIndex = 47
        LblAddress.Text = "Address"
        ' 
        ' LblCustomer
        ' 
        LblCustomer.AutoSize = True
        LblCustomer.Font = New Font("Verdana", 11F)
        LblCustomer.Location = New Point(19, 99)
        LblCustomer.Name = "LblCustomer"
        LblCustomer.Size = New Size(82, 18)
        LblCustomer.TabIndex = 46
        LblCustomer.Text = "Customer"
        ' 
        ' LblCreateService
        ' 
        LblCreateService.AutoSize = True
        LblCreateService.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold)
        LblCreateService.Location = New Point(13, 32)
        LblCreateService.Name = "LblCreateService"
        LblCreateService.Size = New Size(138, 25)
        LblCreateService.TabIndex = 44
        LblCreateService.Text = "Create Service"
        ' 
        ' lblSelectedCustomer
        ' 
        lblSelectedCustomer.AutoSize = True
        lblSelectedCustomer.Font = New Font("Segoe UI", 9F, FontStyle.Italic)
        lblSelectedCustomer.ForeColor = Color.Green
        lblSelectedCustomer.Location = New Point(167, 126)
        lblSelectedCustomer.Name = "lblSelectedCustomer"
        lblSelectedCustomer.Size = New Size(0, 15)
        lblSelectedCustomer.TabIndex = 64
        ' 
        ' txtCustomerPhone
        ' 
        txtCustomerPhone.BackColor = Color.WhiteSmoke
        txtCustomerPhone.BorderStyle = BorderStyle.FixedSingle
        txtCustomerPhone.Cursor = Cursors.Hand
        txtCustomerPhone.Enabled = False
        txtCustomerPhone.Font = New Font("Segoe UI", 12F)
        txtCustomerPhone.Location = New Point(167, 336)
        txtCustomerPhone.Name = "txtCustomerPhone"
        txtCustomerPhone.ReadOnly = True
        txtCustomerPhone.Size = New Size(304, 29)
        txtCustomerPhone.TabIndex = 66
        txtCustomerPhone.TextAlign = HorizontalAlignment.Center
        ' 
        ' LblPhone
        ' 
        LblPhone.AutoSize = True
        LblPhone.Font = New Font("Verdana", 11F)
        LblPhone.Location = New Point(19, 341)
        LblPhone.Name = "LblPhone"
        LblPhone.Size = New Size(54, 18)
        LblPhone.TabIndex = 65
        LblPhone.Text = "Phone"
        ' 
        ' dtpTime
        ' 
        dtpTime.Font = New Font("Segoe UI", 10F)
        dtpTime.Format = DateTimePickerFormat.Time
        dtpTime.Location = New Point(313, 244)
        dtpTime.Name = "dtpTime"
        dtpTime.ShowUpDown = True
        dtpTime.Size = New Size(121, 25)
        dtpTime.TabIndex = 68
        ' 
        ' lblTime
        ' 
        lblTime.AutoSize = True
        lblTime.Font = New Font("Verdana", 11F)
        lblTime.Location = New Point(65, 249)
        lblTime.Name = "lblTime"
        lblTime.Size = New Size(44, 18)
        lblTime.TabIndex = 67
        lblTime.Text = "Time"
        ' 
        ' txtServiceDescription
        ' 
        txtServiceDescription.BackColor = Color.White
        txtServiceDescription.BorderStyle = BorderStyle.FixedSingle
        txtServiceDescription.Font = New Font("Segoe UI", 10F)
        txtServiceDescription.Location = New Point(167, 286)
        txtServiceDescription.Multiline = True
        txtServiceDescription.Name = "txtServiceDescription"
        txtServiceDescription.ScrollBars = ScrollBars.Vertical
        txtServiceDescription.Size = New Size(304, 40)
        txtServiceDescription.TabIndex = 70
        ' 
        ' lblDescription
        ' 
        lblDescription.AutoSize = True
        lblDescription.Font = New Font("Verdana", 11F)
        lblDescription.Location = New Point(19, 291)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Size(90, 18)
        lblDescription.TabIndex = 69
        lblDescription.Text = "Description"
        ' 
        ' chkSendSMS
        ' 
        chkSendSMS.AutoSize = True
        chkSendSMS.Checked = True
        chkSendSMS.CheckState = CheckState.Checked
        chkSendSMS.Font = New Font("Segoe UI", 10F)
        chkSendSMS.Location = New Point(167, 520)
        chkSendSMS.Name = "chkSendSMS"
        chkSendSMS.Size = New Size(201, 23)
        chkSendSMS.TabIndex = 71
        chkSendSMS.Text = "Send SMS Notification (PHP)"
        chkSendSMS.UseVisualStyleBackColor = True
        ' 
        ' btnSMSPreview
        ' 
        btnSMSPreview.BackColor = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        btnSMSPreview.CornerRadius = 4
        btnSMSPreview.FlatAppearance.BorderSize = 0
        btnSMSPreview.FlatStyle = FlatStyle.Flat
        btnSMSPreview.Font = New Font("Segoe UI", 9F)
        btnSMSPreview.ForeColor = Color.Black
        btnSMSPreview.Location = New Point(477, 286)
        btnSMSPreview.Name = "btnSMSPreview"
        btnSMSPreview.Size = New Size(80, 40)
        btnSMSPreview.TabIndex = 72
        btnSMSPreview.Text = "SMS Preview"
        btnSMSPreview.UseVisualStyleBackColor = False
        ' 
        ' frmServiceCreate
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        ClientSize = New Size(940, 625)
        Controls.Add(chkSendSMS)
        Controls.Add(txtServiceDescription)
        Controls.Add(lblDescription)
        Controls.Add(dtpTime)
        Controls.Add(lblTime)
        Controls.Add(txtCustomerPhone)
        Controls.Add(LblPhone)
        Controls.Add(lblSelectedCustomer)
        Controls.Add(PanelCustomerSearch)
        Controls.Add(lblStatus)
        Controls.Add(cbStatus)
        Controls.Add(cbTechnician)
        Controls.Add(txtServiceFee)
        Controls.Add(TxtBoxAddress)
        Controls.Add(txtCustomer)
        Controls.Add(btnUpdate)
        Controls.Add(btnCancel)
        Controls.Add(cbServiceType)
        Controls.Add(dtpService)
        Controls.Add(LblTechnician)
        Controls.Add(LblServiceFee)
        Controls.Add(lblServiceType)
        Controls.Add(LblDate)
        Controls.Add(LblAddress)
        Controls.Add(LblCustomer)
        Controls.Add(LblCreateService)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmServiceCreate"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmServiceCreate"
        PanelCustomerSearch.ResumeLayout(False)
        PanelCustomerSearch.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    ' ... (Friend WithEvents declarations remain the same) ...
    Friend WithEvents PanelCustomerSearch As Panel
    Friend WithEvents txtSearchCustomer As TextBox
    Friend WithEvents btnSearchCustomer As ButtonRounded
    Friend WithEvents lvCustomers As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents lblStatus As Label
    Friend WithEvents cbStatus As ComboBox
    Friend WithEvents cbTechnician As ComboBox
    Friend WithEvents txtServiceFee As TextBox
    Friend WithEvents TxtBoxAddress As TextBox
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents btnUpdate As ButtonRounded
    Friend WithEvents btnCancel As ButtonRounded
    Friend WithEvents cbServiceType As ComboBox
    Friend WithEvents dtpService As DateTimePicker
    Friend WithEvents LblTechnician As Label
    Friend WithEvents LblServiceFee As Label
    Friend WithEvents lblServiceType As Label
    Friend WithEvents LblDate As Label
    Friend WithEvents LblAddress As Label
    Friend WithEvents LblCustomer As Label
    Friend WithEvents LblCreateService As Label
    Friend WithEvents lblSelectedCustomer As Label
    Friend WithEvents txtCustomerPhone As TextBox
    Friend WithEvents LblPhone As Label
    Friend WithEvents dtpTime As DateTimePicker
    Friend WithEvents lblTime As Label
    Friend WithEvents txtServiceDescription As TextBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents chkSendSMS As CheckBox
    Friend WithEvents btnSMSPreview As ButtonRounded
End Class
