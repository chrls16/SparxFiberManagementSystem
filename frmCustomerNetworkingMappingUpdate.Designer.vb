<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerNetworkingMappingUpdate
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
        cbAvailable = New ComboBox()
        lblAvailable = New Label()
        cbOccupied = New ComboBox()
        lblOccupied = New Label()
        cbNAP = New ComboBox()
        TxtBoxAddress = New TextBox()
        txtCustomer = New TextBox()
        btnUpdate = New ButtonRounded()
        btnCancel = New ButtonRounded()
        DropDownLCPLocation = New ComboBox()
        lblLCPLocation = New Label()
        LblNAP = New Label()
        LblAddress = New Label()
        lblCustomer = New Label()
        LblUpdate = New Label()
        SuspendLayout()
        ' 
        ' cbAvailable
        ' 
        cbAvailable.DropDownStyle = ComboBoxStyle.DropDownList
        cbAvailable.FormattingEnabled = True
        cbAvailable.Items.AddRange(New Object() {"All Plans", "Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})
        cbAvailable.Location = New Point(166, 298)
        cbAvailable.Margin = New Padding(3, 2, 3, 2)
        cbAvailable.Name = "cbAvailable"
        cbAvailable.Size = New Size(165, 23)
        cbAvailable.TabIndex = 89
        ' 
        ' lblAvailable
        ' 
        lblAvailable.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblAvailable.AutoSize = True
        lblAvailable.BackColor = Color.Transparent
        lblAvailable.Font = New Font("Verdana", 11F)
        lblAvailable.Location = New Point(18, 303)
        lblAvailable.Name = "lblAvailable"
        lblAvailable.Size = New Size(72, 18)
        lblAvailable.TabIndex = 88
        lblAvailable.Text = "Available"
        ' 
        ' cbOccupied
        ' 
        cbOccupied.DropDownStyle = ComboBoxStyle.DropDownList
        cbOccupied.FormattingEnabled = True
        cbOccupied.Items.AddRange(New Object() {"All Plans", "Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})
        cbOccupied.Location = New Point(166, 253)
        cbOccupied.Margin = New Padding(3, 2, 3, 2)
        cbOccupied.Name = "cbOccupied"
        cbOccupied.Size = New Size(165, 23)
        cbOccupied.TabIndex = 86
        ' 
        ' lblOccupied
        ' 
        lblOccupied.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblOccupied.AutoSize = True
        lblOccupied.BackColor = Color.Transparent
        lblOccupied.Font = New Font("Verdana", 11F)
        lblOccupied.Location = New Point(18, 258)
        lblOccupied.Name = "lblOccupied"
        lblOccupied.Size = New Size(75, 18)
        lblOccupied.TabIndex = 85
        lblOccupied.Text = "Occupied"
        ' 
        ' cbNAP
        ' 
        cbNAP.DropDownStyle = ComboBoxStyle.DropDownList
        cbNAP.FormattingEnabled = True
        cbNAP.Items.AddRange(New Object() {"All Plans", "Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})
        cbNAP.Location = New Point(166, 207)
        cbNAP.Margin = New Padding(3, 2, 3, 2)
        cbNAP.Name = "cbNAP"
        cbNAP.Size = New Size(267, 23)
        cbNAP.TabIndex = 84
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
        TxtBoxAddress.Location = New Point(166, 110)
        TxtBoxAddress.Name = "TxtBoxAddress"
        TxtBoxAddress.ReadOnly = True
        TxtBoxAddress.Size = New Size(267, 29)
        TxtBoxAddress.TabIndex = 78
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
        txtCustomer.Location = New Point(166, 62)
        txtCustomer.Name = "txtCustomer"
        txtCustomer.ReadOnly = True
        txtCustomer.Size = New Size(165, 29)
        txtCustomer.TabIndex = 76
        txtCustomer.TextAlign = HorizontalAlignment.Center
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
        btnUpdate.Location = New Point(349, 343)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(96, 28)
        btnUpdate.TabIndex = 82
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
        btnCancel.Location = New Point(231, 343)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(100, 28)
        btnCancel.TabIndex = 81
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' DropDownLCPLocation
        ' 
        DropDownLCPLocation.DropDownStyle = ComboBoxStyle.DropDownList
        DropDownLCPLocation.FormattingEnabled = True
        DropDownLCPLocation.Items.AddRange(New Object() {"All Plans", "Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})
        DropDownLCPLocation.Location = New Point(166, 161)
        DropDownLCPLocation.Margin = New Padding(3, 2, 3, 2)
        DropDownLCPLocation.Name = "DropDownLCPLocation"
        DropDownLCPLocation.Size = New Size(267, 23)
        DropDownLCPLocation.TabIndex = 80
        ' 
        ' lblLCPLocation
        ' 
        lblLCPLocation.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblLCPLocation.AutoSize = True
        lblLCPLocation.BackColor = Color.Transparent
        lblLCPLocation.Font = New Font("Verdana", 11F)
        lblLCPLocation.Location = New Point(18, 161)
        lblLCPLocation.Name = "lblLCPLocation"
        lblLCPLocation.Size = New Size(103, 18)
        lblLCPLocation.TabIndex = 74
        lblLCPLocation.Text = "LCL Location"
        ' 
        ' LblNAP
        ' 
        LblNAP.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblNAP.AutoSize = True
        LblNAP.BackColor = Color.Transparent
        LblNAP.Font = New Font("Verdana", 11F)
        LblNAP.Location = New Point(18, 212)
        LblNAP.Name = "LblNAP"
        LblNAP.Size = New Size(38, 18)
        LblNAP.TabIndex = 73
        LblNAP.Text = "NAP"
        ' 
        ' LblAddress
        ' 
        LblAddress.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblAddress.AutoSize = True
        LblAddress.BackColor = Color.Transparent
        LblAddress.Font = New Font("Verdana", 11F)
        LblAddress.Location = New Point(18, 110)
        LblAddress.Name = "LblAddress"
        LblAddress.Size = New Size(67, 18)
        LblAddress.TabIndex = 72
        LblAddress.Text = "Address"
        ' 
        ' lblCustomer
        ' 
        lblCustomer.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblCustomer.AutoSize = True
        lblCustomer.BackColor = Color.Transparent
        lblCustomer.Font = New Font("Verdana", 11F)
        lblCustomer.Location = New Point(16, 62)
        lblCustomer.Name = "lblCustomer"
        lblCustomer.Size = New Size(82, 18)
        lblCustomer.TabIndex = 70
        lblCustomer.Text = "Customer"
        ' 
        ' LblUpdate
        ' 
        LblUpdate.AutoSize = True
        LblUpdate.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblUpdate.Location = New Point(12, 18)
        LblUpdate.Name = "LblUpdate"
        LblUpdate.Size = New Size(77, 25)
        LblUpdate.TabIndex = 69
        LblUpdate.Text = "Update"
        ' 
        ' frmCustomerNetworkingMappingUpdate
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(466, 396)
        Controls.Add(cbAvailable)
        Controls.Add(lblAvailable)
        Controls.Add(cbOccupied)
        Controls.Add(lblOccupied)
        Controls.Add(cbNAP)
        Controls.Add(TxtBoxAddress)
        Controls.Add(txtCustomer)
        Controls.Add(btnUpdate)
        Controls.Add(btnCancel)
        Controls.Add(DropDownLCPLocation)
        Controls.Add(lblLCPLocation)
        Controls.Add(LblNAP)
        Controls.Add(LblAddress)
        Controls.Add(lblCustomer)
        Controls.Add(LblUpdate)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmCustomerNetworkingMappingUpdate"
        Text = "frmCustomerNetworkingMappingUpdate"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents cbAvailable As ComboBox
    Friend WithEvents lblAvailable As Label
    Friend WithEvents cbOccupied As ComboBox
    Friend WithEvents lblOccupied As Label
    Friend WithEvents cbNAP As ComboBox
    Friend WithEvents TxtBoxAddress As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents btnUpdate As ButtonRounded
    Friend WithEvents btnCancel As ButtonRounded
    Friend WithEvents DropDownLCPLocation As ComboBox
    Friend WithEvents lblLCPLocation As Label
    Friend WithEvents LblNAP As Label
    Friend WithEvents LblAddress As Label
    Friend WithEvents LblName As Label
    Friend WithEvents lblCustomer As Label
    Friend WithEvents LblUpdate As Label
End Class
