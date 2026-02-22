<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBillingCreate
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
        cbModeofPaymentBilling = New ComboBox()
        lblModeOfPaymentBilling = New Label()
        txtAmountPaidBilling = New TextBox()
        cbStatusBilling = New ComboBox()
        lblStatusBilling = New Label()
        cbPlanTypeBilling = New ComboBox()
        txtMonthlyRateBilling = New TextBox()
        txtAddressBilling = New TextBox()
        txtCustomer = New TextBox()
        btnUpdate = New ButtonRounded()
        btnCancel = New ButtonRounded()
        lblAmountPaidBilling = New Label()
        lblMonthlyRateBilling = New Label()
        lblPaymentDateBilling = New Label()
        LblPlanTypeBilling = New Label()
        LblAddressBilling = New Label()
        lblCustomer = New Label()
        LblCreate = New Label()
        dtpPaymentDate = New DateTimePicker()
        SuspendLayout()
        ' 
        ' cbModeofPaymentBilling
        ' 
        cbModeofPaymentBilling.DropDownStyle = ComboBoxStyle.DropDownList
        cbModeofPaymentBilling.FormattingEnabled = True
        cbModeofPaymentBilling.Items.AddRange(New Object() {"Walk In", "Gcash"})
        cbModeofPaymentBilling.Location = New Point(166, 394)
        cbModeofPaymentBilling.Margin = New Padding(3, 2, 3, 2)
        cbModeofPaymentBilling.Name = "cbModeofPaymentBilling"
        cbModeofPaymentBilling.Size = New Size(267, 23)
        cbModeofPaymentBilling.TabIndex = 89
        ' 
        ' lblModeOfPaymentBilling
        ' 
        lblModeOfPaymentBilling.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblModeOfPaymentBilling.AutoSize = True
        lblModeOfPaymentBilling.BackColor = Color.Transparent
        lblModeOfPaymentBilling.Font = New Font("Verdana", 11F)
        lblModeOfPaymentBilling.Location = New Point(18, 399)
        lblModeOfPaymentBilling.Name = "lblModeOfPaymentBilling"
        lblModeOfPaymentBilling.Size = New Size(140, 18)
        lblModeOfPaymentBilling.TabIndex = 88
        lblModeOfPaymentBilling.Text = "Mode of Payment"
        ' 
        ' txtAmountPaidBilling
        ' 
        txtAmountPaidBilling.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtAmountPaidBilling.BackColor = Color.WhiteSmoke
        txtAmountPaidBilling.BorderStyle = BorderStyle.FixedSingle
        txtAmountPaidBilling.Cursor = Cursors.Hand
        txtAmountPaidBilling.Font = New Font("Segoe UI", 12F)
        txtAmountPaidBilling.ForeColor = SystemColors.WindowText
        txtAmountPaidBilling.Location = New Point(166, 347)
        txtAmountPaidBilling.Name = "txtAmountPaidBilling"
        txtAmountPaidBilling.Size = New Size(267, 29)
        txtAmountPaidBilling.TabIndex = 87
        txtAmountPaidBilling.TabStop = False
        txtAmountPaidBilling.TextAlign = HorizontalAlignment.Center
        ' 
        ' cbStatusBilling
        ' 
        cbStatusBilling.DropDownStyle = ComboBoxStyle.DropDownList
        cbStatusBilling.FormattingEnabled = True
        cbStatusBilling.Items.AddRange(New Object() {"Paid", "Unpaid"})
        cbStatusBilling.Location = New Point(166, 257)
        cbStatusBilling.Margin = New Padding(3, 2, 3, 2)
        cbStatusBilling.Name = "cbStatusBilling"
        cbStatusBilling.Size = New Size(267, 23)
        cbStatusBilling.TabIndex = 86
        ' 
        ' lblStatusBilling
        ' 
        lblStatusBilling.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblStatusBilling.AutoSize = True
        lblStatusBilling.BackColor = Color.Transparent
        lblStatusBilling.Font = New Font("Verdana", 11F)
        lblStatusBilling.Location = New Point(18, 262)
        lblStatusBilling.Name = "lblStatusBilling"
        lblStatusBilling.Size = New Size(56, 18)
        lblStatusBilling.TabIndex = 85
        lblStatusBilling.Text = "Status"
        ' 
        ' cbPlanTypeBilling
        ' 
        cbPlanTypeBilling.DropDownStyle = ComboBoxStyle.DropDownList
        cbPlanTypeBilling.FormattingEnabled = True
        cbPlanTypeBilling.Items.AddRange(New Object() {"All Plans", "Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})
        cbPlanTypeBilling.Location = New Point(166, 215)
        cbPlanTypeBilling.Margin = New Padding(3, 2, 3, 2)
        cbPlanTypeBilling.Name = "cbPlanTypeBilling"
        cbPlanTypeBilling.Size = New Size(267, 23)
        cbPlanTypeBilling.TabIndex = 84
        ' 
        ' txtMonthlyRateBilling
        ' 
        txtMonthlyRateBilling.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtMonthlyRateBilling.BackColor = Color.WhiteSmoke
        txtMonthlyRateBilling.BorderStyle = BorderStyle.FixedSingle
        txtMonthlyRateBilling.Cursor = Cursors.Hand
        txtMonthlyRateBilling.Enabled = False
        txtMonthlyRateBilling.Font = New Font("Segoe UI", 12F)
        txtMonthlyRateBilling.ForeColor = SystemColors.WindowText
        txtMonthlyRateBilling.Location = New Point(166, 302)
        txtMonthlyRateBilling.Name = "txtMonthlyRateBilling"
        txtMonthlyRateBilling.Size = New Size(267, 29)
        txtMonthlyRateBilling.TabIndex = 83
        txtMonthlyRateBilling.TabStop = False
        txtMonthlyRateBilling.TextAlign = HorizontalAlignment.Center
        ' 
        ' txtAddressBilling
        ' 
        txtAddressBilling.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtAddressBilling.BackColor = Color.WhiteSmoke
        txtAddressBilling.BorderStyle = BorderStyle.FixedSingle
        txtAddressBilling.Cursor = Cursors.Hand
        txtAddressBilling.Font = New Font("Segoe UI", 12F)
        txtAddressBilling.ForeColor = SystemColors.WindowText
        txtAddressBilling.Location = New Point(166, 119)
        txtAddressBilling.Name = "txtAddressBilling"
        txtAddressBilling.Size = New Size(267, 29)
        txtAddressBilling.TabIndex = 78
        txtAddressBilling.TabStop = False
        txtAddressBilling.TextAlign = HorizontalAlignment.Center
        ' 
        ' txtCustomer
        ' 
        txtCustomer.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtCustomer.BackColor = Color.WhiteSmoke
        txtCustomer.BorderStyle = BorderStyle.FixedSingle
        txtCustomer.Cursor = Cursors.Hand
        txtCustomer.Font = New Font("Segoe UI", 12F)
        txtCustomer.ForeColor = SystemColors.WindowText
        txtCustomer.Location = New Point(166, 68)
        txtCustomer.Name = "txtCustomer"
        txtCustomer.Size = New Size(267, 29)
        txtCustomer.TabIndex = 76
        txtCustomer.TextAlign = HorizontalAlignment.Center
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        btnUpdate.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnUpdate.CornerRadius = 8
        btnUpdate.Cursor = Cursors.Hand
        btnUpdate.DialogResult = DialogResult.OK
        btnUpdate.FlatAppearance.BorderSize = 0
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.Font = New Font("Segoe UI", 12F)
        btnUpdate.ForeColor = Color.White
        btnUpdate.ImageAlign = ContentAlignment.MiddleLeft
        btnUpdate.Location = New Point(343, 437)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(111, 28)
        btnUpdate.TabIndex = 82
        btnUpdate.Text = "Create"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        btnCancel.BackColor = Color.Red
        btnCancel.CornerRadius = 8
        btnCancel.Cursor = Cursors.Hand
        btnCancel.DialogResult = DialogResult.Cancel
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 12F)
        btnCancel.ForeColor = Color.White
        btnCancel.ImageAlign = ContentAlignment.MiddleLeft
        btnCancel.Location = New Point(212, 437)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(111, 28)
        btnCancel.TabIndex = 81
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' lblAmountPaidBilling
        ' 
        lblAmountPaidBilling.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblAmountPaidBilling.AutoSize = True
        lblAmountPaidBilling.BackColor = Color.Transparent
        lblAmountPaidBilling.Font = New Font("Verdana", 11F)
        lblAmountPaidBilling.Location = New Point(18, 353)
        lblAmountPaidBilling.Name = "lblAmountPaidBilling"
        lblAmountPaidBilling.Size = New Size(102, 18)
        lblAmountPaidBilling.TabIndex = 79
        lblAmountPaidBilling.Text = "Amount Paid"
        ' 
        ' lblMonthlyRateBilling
        ' 
        lblMonthlyRateBilling.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblMonthlyRateBilling.AutoSize = True
        lblMonthlyRateBilling.BackColor = Color.Transparent
        lblMonthlyRateBilling.Font = New Font("Verdana", 11F)
        lblMonthlyRateBilling.Location = New Point(18, 306)
        lblMonthlyRateBilling.Name = "lblMonthlyRateBilling"
        lblMonthlyRateBilling.Size = New Size(106, 18)
        lblMonthlyRateBilling.TabIndex = 75
        lblMonthlyRateBilling.Text = "Monthly Rate"
        ' 
        ' lblPaymentDateBilling
        ' 
        lblPaymentDateBilling.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblPaymentDateBilling.AutoSize = True
        lblPaymentDateBilling.BackColor = Color.Transparent
        lblPaymentDateBilling.Font = New Font("Verdana", 11F)
        lblPaymentDateBilling.Location = New Point(18, 170)
        lblPaymentDateBilling.Name = "lblPaymentDateBilling"
        lblPaymentDateBilling.Size = New Size(114, 18)
        lblPaymentDateBilling.TabIndex = 74
        lblPaymentDateBilling.Text = "Payment Date"
        ' 
        ' LblPlanTypeBilling
        ' 
        LblPlanTypeBilling.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblPlanTypeBilling.AutoSize = True
        LblPlanTypeBilling.BackColor = Color.Transparent
        LblPlanTypeBilling.Font = New Font("Verdana", 11F)
        LblPlanTypeBilling.Location = New Point(18, 220)
        LblPlanTypeBilling.Name = "LblPlanTypeBilling"
        LblPlanTypeBilling.Size = New Size(78, 18)
        LblPlanTypeBilling.TabIndex = 73
        LblPlanTypeBilling.Text = "Plan Type"
        ' 
        ' LblAddressBilling
        ' 
        LblAddressBilling.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblAddressBilling.AutoSize = True
        LblAddressBilling.BackColor = Color.Transparent
        LblAddressBilling.Font = New Font("Verdana", 11F)
        LblAddressBilling.Location = New Point(18, 119)
        LblAddressBilling.Name = "LblAddressBilling"
        LblAddressBilling.Size = New Size(67, 18)
        LblAddressBilling.TabIndex = 72
        LblAddressBilling.Text = "Address"
        ' 
        ' lblCustomer
        ' 
        lblCustomer.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblCustomer.AutoSize = True
        lblCustomer.BackColor = Color.Transparent
        lblCustomer.Font = New Font("Verdana", 11F)
        lblCustomer.Location = New Point(16, 68)
        lblCustomer.Name = "lblCustomer"
        lblCustomer.Size = New Size(82, 18)
        lblCustomer.TabIndex = 70
        lblCustomer.Text = "Customer"
        ' 
        ' LblCreate
        ' 
        LblCreate.AutoSize = True
        LblCreate.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblCreate.Location = New Point(12, 24)
        LblCreate.Name = "LblCreate"
        LblCreate.Size = New Size(69, 25)
        LblCreate.TabIndex = 69
        LblCreate.Text = "Create"
        ' 
        ' dtpPaymentDate
        ' 
        dtpPaymentDate.Location = New Point(166, 170)
        dtpPaymentDate.Margin = New Padding(3, 2, 3, 2)
        dtpPaymentDate.Name = "dtpPaymentDate"
        dtpPaymentDate.Size = New Size(267, 23)
        dtpPaymentDate.TabIndex = 90
        ' 
        ' frmBillingCreate
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(466, 477)
        Controls.Add(dtpPaymentDate)
        Controls.Add(cbModeofPaymentBilling)
        Controls.Add(lblModeOfPaymentBilling)
        Controls.Add(txtAmountPaidBilling)
        Controls.Add(cbStatusBilling)
        Controls.Add(lblStatusBilling)
        Controls.Add(cbPlanTypeBilling)
        Controls.Add(txtMonthlyRateBilling)
        Controls.Add(txtAddressBilling)
        Controls.Add(txtCustomer)
        Controls.Add(btnUpdate)
        Controls.Add(btnCancel)
        Controls.Add(lblAmountPaidBilling)
        Controls.Add(lblMonthlyRateBilling)
        Controls.Add(lblPaymentDateBilling)
        Controls.Add(LblPlanTypeBilling)
        Controls.Add(LblAddressBilling)
        Controls.Add(lblCustomer)
        Controls.Add(LblCreate)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmBillingCreate"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmBillingCreate"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents cbModeofPaymentBilling As ComboBox
    Friend WithEvents lblModeOfPaymentBilling As Label
    Friend WithEvents txtAmountPaidBilling As TextBox
    Friend WithEvents cbStatusBilling As ComboBox
    Friend WithEvents lblStatusBilling As Label
    Friend WithEvents cbPlanTypeBilling As ComboBox
    Friend WithEvents txtMonthlyRateBilling As TextBox
    Friend WithEvents txtAddressBilling As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents btnUpdate As ButtonRounded
    Friend WithEvents btnCancel As ButtonRounded
    Friend WithEvents DropDownPaymentDate As ComboBox
    Friend WithEvents lblAmountPaidBilling As Label
    Friend WithEvents lblMonthlyRateBilling As Label
    Friend WithEvents lblPaymentDateBilling As Label
    Friend WithEvents LblPlanTypeBilling As Label
    Friend WithEvents LblAddressBilling As Label
    Friend WithEvents LblName As Label
    Friend WithEvents lblCustomer As Label
    Friend WithEvents LblCreate As Label
    Friend WithEvents dtpPaymentDate As DateTimePicker
End Class
