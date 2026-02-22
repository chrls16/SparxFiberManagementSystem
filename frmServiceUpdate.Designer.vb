<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServiceUpdate
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
        TxtBoxAddress = New TextBox()
        txtCustomer = New TextBox()
        txtServuceID = New TextBox()
        btnUpdate = New ButtonRounded()
        btnCancel = New ButtonRounded()
        DropDownServiceType = New ComboBox()
        DateTimePicker1 = New DateTimePicker()
        LblMonthlyRate = New Label()
        LblServiceFee = New Label()
        lblServiceType = New Label()
        LblDate = New Label()
        LblAddress = New Label()
        LblCustomer = New Label()
        lblServiceID = New Label()
        LblUpdate = New Label()
        txtServiceFee = New TextBox()
        cbStatus = New ComboBox()
        lblStatus = New Label()
        LblTechNotes = New Label()
        txtServiceNotes = New TextBox()
        txtTechSearch = New TextBox()
        SuspendLayout()
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
        TxtBoxAddress.Location = New Point(167, 162)
        TxtBoxAddress.Name = "TxtBoxAddress"
        TxtBoxAddress.ReadOnly = True
        TxtBoxAddress.Size = New Size(267, 29)
        TxtBoxAddress.TabIndex = 33
        TxtBoxAddress.TabStop = False
        TxtBoxAddress.TextAlign = HorizontalAlignment.Center
        ' 
        ' txtCustomer
        ' 
        txtCustomer.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtCustomer.BackColor = Color.WhiteSmoke
        txtCustomer.BorderStyle = BorderStyle.FixedSingle
        txtCustomer.Cursor = Cursors.Hand
        txtCustomer.Enabled = False
        txtCustomer.Font = New Font("Segoe UI", 12F)
        txtCustomer.ForeColor = SystemColors.WindowText
        txtCustomer.Location = New Point(167, 113)
        txtCustomer.Name = "txtCustomer"
        txtCustomer.ReadOnly = True
        txtCustomer.Size = New Size(267, 29)
        txtCustomer.TabIndex = 32
        txtCustomer.TextAlign = HorizontalAlignment.Center
        ' 
        ' txtServuceID
        ' 
        txtServuceID.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtServuceID.BackColor = Color.WhiteSmoke
        txtServuceID.BorderStyle = BorderStyle.FixedSingle
        txtServuceID.Cursor = Cursors.Hand
        txtServuceID.Enabled = False
        txtServuceID.Font = New Font("Segoe UI", 12F)
        txtServuceID.ForeColor = SystemColors.WindowText
        txtServuceID.Location = New Point(167, 62)
        txtServuceID.Name = "txtServuceID"
        txtServuceID.ReadOnly = True
        txtServuceID.Size = New Size(131, 29)
        txtServuceID.TabIndex = 31
        txtServuceID.TextAlign = HorizontalAlignment.Center
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
        btnUpdate.Location = New Point(343, 505)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(111, 28)
        btnUpdate.TabIndex = 39
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
        btnCancel.Location = New Point(212, 505)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(111, 28)
        btnCancel.TabIndex = 38
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' DropDownServiceType
        ' 
        DropDownServiceType.DropDownStyle = ComboBoxStyle.DropDownList
        DropDownServiceType.FormattingEnabled = True
        DropDownServiceType.Items.AddRange(New Object() {"All Plans", "Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})
        DropDownServiceType.Location = New Point(167, 213)
        DropDownServiceType.Margin = New Padding(3, 2, 3, 2)
        DropDownServiceType.Name = "DropDownServiceType"
        DropDownServiceType.Size = New Size(267, 23)
        DropDownServiceType.TabIndex = 36
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(167, 258)
        DateTimePicker1.Margin = New Padding(3, 2, 3, 2)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(267, 23)
        DateTimePicker1.TabIndex = 35
        ' 
        ' LblMonthlyRate
        ' 
        LblMonthlyRate.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblMonthlyRate.AutoSize = True
        LblMonthlyRate.BackColor = Color.Transparent
        LblMonthlyRate.Font = New Font("Verdana", 11F)
        LblMonthlyRate.Location = New Point(19, 351)
        LblMonthlyRate.Name = "LblMonthlyRate"
        LblMonthlyRate.Size = New Size(82, 18)
        LblMonthlyRate.TabIndex = 34
        LblMonthlyRate.Text = "Technician"
        ' 
        ' LblServiceFee
        ' 
        LblServiceFee.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblServiceFee.AutoSize = True
        LblServiceFee.BackColor = Color.Transparent
        LblServiceFee.Font = New Font("Verdana", 11F)
        LblServiceFee.Location = New Point(19, 304)
        LblServiceFee.Name = "LblServiceFee"
        LblServiceFee.Size = New Size(94, 18)
        LblServiceFee.TabIndex = 29
        LblServiceFee.Text = "Service Fee"
        ' 
        ' lblServiceType
        ' 
        lblServiceType.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblServiceType.AutoSize = True
        lblServiceType.BackColor = Color.Transparent
        lblServiceType.Font = New Font("Verdana", 11F)
        lblServiceType.Location = New Point(19, 213)
        lblServiceType.Name = "lblServiceType"
        lblServiceType.Size = New Size(102, 18)
        lblServiceType.TabIndex = 28
        lblServiceType.Text = "Service Type"
        ' 
        ' LblDate
        ' 
        LblDate.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblDate.AutoSize = True
        LblDate.BackColor = Color.Transparent
        LblDate.Font = New Font("Verdana", 11F)
        LblDate.Location = New Point(19, 263)
        LblDate.Name = "LblDate"
        LblDate.Size = New Size(43, 18)
        LblDate.TabIndex = 27
        LblDate.Text = "Date"
        ' 
        ' LblAddress
        ' 
        LblAddress.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblAddress.AutoSize = True
        LblAddress.BackColor = Color.Transparent
        LblAddress.Font = New Font("Verdana", 11F)
        LblAddress.Location = New Point(19, 162)
        LblAddress.Name = "LblAddress"
        LblAddress.Size = New Size(67, 18)
        LblAddress.TabIndex = 26
        LblAddress.Text = "Address"
        ' 
        ' LblCustomer
        ' 
        LblCustomer.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblCustomer.AutoSize = True
        LblCustomer.BackColor = Color.Transparent
        LblCustomer.Font = New Font("Verdana", 11F)
        LblCustomer.Location = New Point(19, 113)
        LblCustomer.Name = "LblCustomer"
        LblCustomer.Size = New Size(82, 18)
        LblCustomer.TabIndex = 25
        LblCustomer.Text = "Customer"
        ' 
        ' lblServiceID
        ' 
        lblServiceID.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblServiceID.AutoSize = True
        lblServiceID.BackColor = Color.Transparent
        lblServiceID.Font = New Font("Verdana", 11F)
        lblServiceID.Location = New Point(17, 62)
        lblServiceID.Name = "lblServiceID"
        lblServiceID.Size = New Size(83, 18)
        lblServiceID.TabIndex = 24
        lblServiceID.Text = "Service ID"
        ' 
        ' LblUpdate
        ' 
        LblUpdate.AutoSize = True
        LblUpdate.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblUpdate.Location = New Point(13, 18)
        LblUpdate.Name = "LblUpdate"
        LblUpdate.Size = New Size(77, 25)
        LblUpdate.TabIndex = 23
        LblUpdate.Text = "Update"
        ' 
        ' txtServiceFee
        ' 
        txtServiceFee.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtServiceFee.BackColor = Color.WhiteSmoke
        txtServiceFee.BorderStyle = BorderStyle.FixedSingle
        txtServiceFee.Cursor = Cursors.Hand
        txtServiceFee.Enabled = False
        txtServiceFee.Font = New Font("Segoe UI", 12F)
        txtServiceFee.ForeColor = SystemColors.WindowText
        txtServiceFee.Location = New Point(167, 300)
        txtServiceFee.Name = "txtServiceFee"
        txtServiceFee.ReadOnly = True
        txtServiceFee.Size = New Size(267, 29)
        txtServiceFee.TabIndex = 40
        txtServiceFee.TabStop = False
        txtServiceFee.TextAlign = HorizontalAlignment.Center
        ' 
        ' cbStatus
        ' 
        cbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cbStatus.FormattingEnabled = True
        cbStatus.Items.AddRange(New Object() {"All Plans", "Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})
        cbStatus.Location = New Point(167, 386)
        cbStatus.Margin = New Padding(3, 2, 3, 2)
        cbStatus.Name = "cbStatus"
        cbStatus.Size = New Size(267, 23)
        cbStatus.TabIndex = 42
        ' 
        ' lblStatus
        ' 
        lblStatus.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblStatus.AutoSize = True
        lblStatus.BackColor = Color.Transparent
        lblStatus.Font = New Font("Verdana", 11F)
        lblStatus.Location = New Point(19, 391)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(56, 18)
        lblStatus.TabIndex = 43
        lblStatus.Text = "Status"
        ' 
        ' LblTechNotes
        ' 
        LblTechNotes.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblTechNotes.AutoSize = True
        LblTechNotes.BackColor = Color.Transparent
        LblTechNotes.Font = New Font("Verdana", 11F)
        LblTechNotes.Location = New Point(19, 436)
        LblTechNotes.Name = "LblTechNotes"
        LblTechNotes.Size = New Size(131, 18)
        LblTechNotes.TabIndex = 44
        LblTechNotes.Text = "Technician Notes"
        ' 
        ' txtServiceNotes
        ' 
        txtServiceNotes.BackColor = Color.White
        txtServiceNotes.BorderStyle = BorderStyle.FixedSingle
        txtServiceNotes.Font = New Font("Segoe UI", 10F)
        txtServiceNotes.Location = New Point(167, 435)
        txtServiceNotes.Multiline = True
        txtServiceNotes.Name = "txtServiceNotes"
        txtServiceNotes.ScrollBars = ScrollBars.Vertical
        txtServiceNotes.Size = New Size(267, 40)
        txtServiceNotes.TabIndex = 71
        ' 
        ' txtTechSearch
        ' 
        txtTechSearch.Font = New Font("Segoe UI", 12F)
        txtTechSearch.Location = New Point(167, 346)
        txtTechSearch.Name = "txtTechSearch"
        txtTechSearch.PlaceholderText = "Search..."
        txtTechSearch.Size = New Size(267, 29)
        txtTechSearch.TabIndex = 72
        ' 
        ' frmServiceUpdate
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(466, 562)
        Controls.Add(txtTechSearch)
        Controls.Add(txtServiceNotes)
        Controls.Add(LblTechNotes)
        Controls.Add(lblStatus)
        Controls.Add(cbStatus)
        Controls.Add(txtServiceFee)
        Controls.Add(TxtBoxAddress)
        Controls.Add(txtCustomer)
        Controls.Add(txtServuceID)
        Controls.Add(btnUpdate)
        Controls.Add(btnCancel)
        Controls.Add(DropDownServiceType)
        Controls.Add(DateTimePicker1)
        Controls.Add(LblMonthlyRate)
        Controls.Add(LblServiceFee)
        Controls.Add(lblServiceType)
        Controls.Add(LblDate)
        Controls.Add(LblAddress)
        Controls.Add(LblCustomer)
        Controls.Add(lblServiceID)
        Controls.Add(LblUpdate)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmServiceUpdate"
        Text = "frmServiceUpdate"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents TxtBoxAddress As TextBox
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents txtServuceID As TextBox
    Friend WithEvents btnUpdate As ButtonRounded
    Friend WithEvents btnCancel As ButtonRounded
    Friend WithEvents DropDownServiceType As ComboBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents LblMonthlyRate As Label
    Friend WithEvents LblServiceFee As Label
    Friend WithEvents lblServiceType As Label
    Friend WithEvents LblDate As Label
    Friend WithEvents LblAddress As Label
    Friend WithEvents LblCustomer As Label
    Friend WithEvents lblServiceID As Label
    Friend WithEvents LblUpdate As Label
    Friend WithEvents txtServiceFee As TextBox
    Friend WithEvents cbStatus As ComboBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents LblTechNotes As Label
    Friend WithEvents txtServiceNotes As TextBox
    Friend WithEvents txtTechSearch As TextBox
End Class
