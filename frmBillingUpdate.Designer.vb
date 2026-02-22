<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBillingUpdate
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
        txtMonthlyRate = New TextBox()
        TxtBoxAddress = New TextBox()
        txtName = New TextBox()
        txtPaymentID = New TextBox()
        btnUpdate = New ButtonRounded()
        btnCancel = New ButtonRounded()
        lblAmountPaid = New Label()
        lblMonthlyRate = New Label()
        lblPaymentDate = New Label()
        LblPlanType = New Label()
        LblAddress = New Label()
        LblName = New Label()
        lblPaymentID = New Label()
        LblUpdate = New Label()
        cbPlanType = New ComboBox()
        cbStatus = New ComboBox()
        lblStatus = New Label()
        txtAmountPaid = New TextBox()
        cbModeofPayment = New ComboBox()
        lblModeOfPayment = New Label()
        dtpPaymentDate = New DateTimePicker()
        SuspendLayout()
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
        txtMonthlyRate.Location = New Point(166, 347)
        txtMonthlyRate.Name = "txtMonthlyRate"
        txtMonthlyRate.ReadOnly = True
        txtMonthlyRate.Size = New Size(267, 29)
        txtMonthlyRate.TabIndex = 59
        txtMonthlyRate.TabStop = False
        txtMonthlyRate.TextAlign = HorizontalAlignment.Center
        ' 
        ' TxtBoxAddress
        ' 
        TxtBoxAddress.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TxtBoxAddress.BackColor = Color.WhiteSmoke
        TxtBoxAddress.BorderStyle = BorderStyle.FixedSingle
        TxtBoxAddress.Cursor = Cursors.Hand
        TxtBoxAddress.Enabled = False
        TxtBoxAddress.Font = New Font("Segoe UI", 12F)
        TxtBoxAddress.ForeColor = SystemColors.WindowText
        TxtBoxAddress.Location = New Point(166, 164)
        TxtBoxAddress.Name = "TxtBoxAddress"
        TxtBoxAddress.ReadOnly = True
        TxtBoxAddress.Size = New Size(267, 29)
        TxtBoxAddress.TabIndex = 53
        TxtBoxAddress.TabStop = False
        TxtBoxAddress.TextAlign = HorizontalAlignment.Center
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
        txtName.Location = New Point(166, 115)
        txtName.Name = "txtName"
        txtName.ReadOnly = True
        txtName.Size = New Size(267, 29)
        txtName.TabIndex = 52
        txtName.TextAlign = HorizontalAlignment.Center
        ' 
        ' txtPaymentID
        ' 
        txtPaymentID.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtPaymentID.BackColor = Color.WhiteSmoke
        txtPaymentID.BorderStyle = BorderStyle.FixedSingle
        txtPaymentID.Cursor = Cursors.Hand
        txtPaymentID.Enabled = False
        txtPaymentID.Font = New Font("Segoe UI", 12F)
        txtPaymentID.ForeColor = SystemColors.WindowText
        txtPaymentID.Location = New Point(166, 64)
        txtPaymentID.Name = "txtPaymentID"
        txtPaymentID.ReadOnly = True
        txtPaymentID.Size = New Size(131, 29)
        txtPaymentID.TabIndex = 51
        txtPaymentID.TextAlign = HorizontalAlignment.Center
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
        btnUpdate.Location = New Point(343, 490)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(111, 28)
        btnUpdate.TabIndex = 58
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = False
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
        btnCancel.Location = New Point(212, 490)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(111, 28)
        btnCancel.TabIndex = 57
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' lblAmountPaid
        ' 
        lblAmountPaid.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblAmountPaid.AutoSize = True
        lblAmountPaid.BackColor = Color.Transparent
        lblAmountPaid.Font = New Font("Verdana", 11F)
        lblAmountPaid.Location = New Point(18, 398)
        lblAmountPaid.Name = "lblAmountPaid"
        lblAmountPaid.Size = New Size(102, 18)
        lblAmountPaid.TabIndex = 54
        lblAmountPaid.Text = "Amount Paid"
        ' 
        ' lblMonthlyRate
        ' 
        lblMonthlyRate.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblMonthlyRate.AutoSize = True
        lblMonthlyRate.BackColor = Color.Transparent
        lblMonthlyRate.Font = New Font("Verdana", 11F)
        lblMonthlyRate.Location = New Point(18, 351)
        lblMonthlyRate.Name = "lblMonthlyRate"
        lblMonthlyRate.Size = New Size(106, 18)
        lblMonthlyRate.TabIndex = 50
        lblMonthlyRate.Text = "Monthly Rate"
        ' 
        ' lblPaymentDate
        ' 
        lblPaymentDate.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblPaymentDate.AutoSize = True
        lblPaymentDate.BackColor = Color.Transparent
        lblPaymentDate.Font = New Font("Verdana", 11F)
        lblPaymentDate.Location = New Point(18, 215)
        lblPaymentDate.Name = "lblPaymentDate"
        lblPaymentDate.Size = New Size(114, 18)
        lblPaymentDate.TabIndex = 49
        lblPaymentDate.Text = "Payment Date"
        ' 
        ' LblPlanType
        ' 
        LblPlanType.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblPlanType.AutoSize = True
        LblPlanType.BackColor = Color.Transparent
        LblPlanType.Font = New Font("Verdana", 11F)
        LblPlanType.Location = New Point(18, 265)
        LblPlanType.Name = "LblPlanType"
        LblPlanType.Size = New Size(78, 18)
        LblPlanType.TabIndex = 48
        LblPlanType.Text = "Plan Type"
        ' 
        ' LblAddress
        ' 
        LblAddress.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblAddress.AutoSize = True
        LblAddress.BackColor = Color.Transparent
        LblAddress.Font = New Font("Verdana", 11F)
        LblAddress.Location = New Point(18, 164)
        LblAddress.Name = "LblAddress"
        LblAddress.Size = New Size(67, 18)
        LblAddress.TabIndex = 47
        LblAddress.Text = "Address"
        ' 
        ' LblName
        ' 
        LblName.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblName.AutoSize = True
        LblName.BackColor = Color.Transparent
        LblName.Font = New Font("Verdana", 11F)
        LblName.Location = New Point(18, 115)
        LblName.Name = "LblName"
        LblName.Size = New Size(52, 18)
        LblName.TabIndex = 46
        LblName.Text = "Name"
        ' 
        ' lblPaymentID
        ' 
        lblPaymentID.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblPaymentID.AutoSize = True
        lblPaymentID.BackColor = Color.Transparent
        lblPaymentID.Font = New Font("Verdana", 11F)
        lblPaymentID.Location = New Point(16, 64)
        lblPaymentID.Name = "lblPaymentID"
        lblPaymentID.Size = New Size(95, 18)
        lblPaymentID.TabIndex = 45
        lblPaymentID.Text = "Payment ID"
        ' 
        ' LblUpdate
        ' 
        LblUpdate.AutoSize = True
        LblUpdate.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblUpdate.Location = New Point(12, 20)
        LblUpdate.Name = "LblUpdate"
        LblUpdate.Size = New Size(77, 25)
        LblUpdate.TabIndex = 44
        LblUpdate.Text = "Update"
        ' 
        ' cbPlanType
        ' 
        cbPlanType.DropDownStyle = ComboBoxStyle.DropDownList
        cbPlanType.FormattingEnabled = True
        cbPlanType.Items.AddRange(New Object() {"All Plans", "Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})
        cbPlanType.Location = New Point(166, 260)
        cbPlanType.Margin = New Padding(3, 2, 3, 2)
        cbPlanType.Name = "cbPlanType"
        cbPlanType.Size = New Size(267, 23)
        cbPlanType.TabIndex = 63
        ' 
        ' cbStatus
        ' 
        cbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cbStatus.FormattingEnabled = True
        cbStatus.Items.AddRange(New Object() {"All Plans", "Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})
        cbStatus.Location = New Point(166, 302)
        cbStatus.Margin = New Padding(3, 2, 3, 2)
        cbStatus.Name = "cbStatus"
        cbStatus.Size = New Size(267, 23)
        cbStatus.TabIndex = 65
        ' 
        ' lblStatus
        ' 
        lblStatus.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblStatus.AutoSize = True
        lblStatus.BackColor = Color.Transparent
        lblStatus.Font = New Font("Verdana", 11F)
        lblStatus.Location = New Point(18, 307)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(56, 18)
        lblStatus.TabIndex = 64
        lblStatus.Text = "Status"
        ' 
        ' txtAmountPaid
        ' 
        txtAmountPaid.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtAmountPaid.BackColor = Color.WhiteSmoke
        txtAmountPaid.BorderStyle = BorderStyle.FixedSingle
        txtAmountPaid.Cursor = Cursors.Hand
        txtAmountPaid.Enabled = False
        txtAmountPaid.Font = New Font("Segoe UI", 12F)
        txtAmountPaid.ForeColor = SystemColors.WindowText
        txtAmountPaid.Location = New Point(166, 392)
        txtAmountPaid.Name = "txtAmountPaid"
        txtAmountPaid.ReadOnly = True
        txtAmountPaid.Size = New Size(267, 29)
        txtAmountPaid.TabIndex = 66
        txtAmountPaid.TabStop = False
        txtAmountPaid.TextAlign = HorizontalAlignment.Center
        ' 
        ' cbModeofPayment
        ' 
        cbModeofPayment.DropDownStyle = ComboBoxStyle.DropDownList
        cbModeofPayment.FormattingEnabled = True
        cbModeofPayment.Items.AddRange(New Object() {"All Plans", "Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})
        cbModeofPayment.Location = New Point(166, 439)
        cbModeofPayment.Margin = New Padding(3, 2, 3, 2)
        cbModeofPayment.Name = "cbModeofPayment"
        cbModeofPayment.Size = New Size(267, 23)
        cbModeofPayment.TabIndex = 68
        ' 
        ' lblModeOfPayment
        ' 
        lblModeOfPayment.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblModeOfPayment.AutoSize = True
        lblModeOfPayment.BackColor = Color.Transparent
        lblModeOfPayment.Font = New Font("Verdana", 11F)
        lblModeOfPayment.Location = New Point(18, 444)
        lblModeOfPayment.Name = "lblModeOfPayment"
        lblModeOfPayment.Size = New Size(140, 18)
        lblModeOfPayment.TabIndex = 67
        lblModeOfPayment.Text = "Mode of Payment"
        ' 
        ' dtpPaymentDate
        ' 
        dtpPaymentDate.Location = New Point(166, 215)
        dtpPaymentDate.Margin = New Padding(3, 2, 3, 2)
        dtpPaymentDate.Name = "dtpPaymentDate"
        dtpPaymentDate.Size = New Size(267, 23)
        dtpPaymentDate.TabIndex = 91
        ' 
        ' frmBillingUpdate
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(466, 552)
        Controls.Add(dtpPaymentDate)
        Controls.Add(cbModeofPayment)
        Controls.Add(lblModeOfPayment)
        Controls.Add(txtAmountPaid)
        Controls.Add(cbStatus)
        Controls.Add(lblStatus)
        Controls.Add(cbPlanType)
        Controls.Add(txtMonthlyRate)
        Controls.Add(TxtBoxAddress)
        Controls.Add(txtName)
        Controls.Add(txtPaymentID)
        Controls.Add(btnUpdate)
        Controls.Add(btnCancel)
        Controls.Add(lblAmountPaid)
        Controls.Add(lblMonthlyRate)
        Controls.Add(lblPaymentDate)
        Controls.Add(LblPlanType)
        Controls.Add(LblAddress)
        Controls.Add(LblName)
        Controls.Add(lblPaymentID)
        Controls.Add(LblUpdate)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmBillingUpdate"
        Text = "v"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents txtMonthlyRate As TextBox
    Friend WithEvents TxtBoxAddress As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtPaymentID As TextBox
    Friend WithEvents btnUpdate As ButtonRounded
    Friend WithEvents btnCancel As ButtonRounded
    Friend WithEvents lblAmountPaid As Label
    Friend WithEvents lblMonthlyRate As Label
    Friend WithEvents lblPaymentDate As Label
    Friend WithEvents LblPlanType As Label
    Friend WithEvents LblAddress As Label
    Friend WithEvents LblName As Label
    Friend WithEvents lblPaymentID As Label
    Friend WithEvents LblUpdate As Label
    Friend WithEvents cbPlanType As ComboBox
    Friend WithEvents cbStatus As ComboBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents txtAmountPaid As TextBox
    Friend WithEvents cbModeofPayment As ComboBox
    Friend WithEvents lblModeOfPayment As Label
    Friend WithEvents dtpPaymentDate As DateTimePicker
End Class
