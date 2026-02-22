<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerNetworkMappingCreate
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
        txtAddressNetwork = New TextBox()
        txtCustomerNetwork = New TextBox()
        btnUpdate = New ButtonRounded()
        btnCancel = New ButtonRounded()
        lblAvailable = New Label()
        LblOccupied = New Label()
        lblLCPLocation = New Label()
        lblNap = New Label()
        LblAddressNetwork = New Label()
        LblCustomerNetwork = New Label()
        LblCreateService = New Label()
        txtLCPLoc = New TextBox()
        cbNAP = New ComboBox()
        cbOccupied = New ComboBox()
        cbAvailable = New ComboBox()
        SuspendLayout()
        ' 
        ' txtAddressNetwork
        ' 
        txtAddressNetwork.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtAddressNetwork.BackColor = Color.WhiteSmoke
        txtAddressNetwork.BorderStyle = BorderStyle.FixedSingle
        txtAddressNetwork.Cursor = Cursors.Hand
        txtAddressNetwork.Enabled = False
        txtAddressNetwork.Font = New Font("Segoe UI", 12F)
        txtAddressNetwork.ForeColor = SystemColors.WindowText
        txtAddressNetwork.Location = New Point(166, 119)
        txtAddressNetwork.Name = "txtAddressNetwork"
        txtAddressNetwork.ReadOnly = True
        txtAddressNetwork.Size = New Size(267, 29)
        txtAddressNetwork.TabIndex = 70
        txtAddressNetwork.TabStop = False
        txtAddressNetwork.TextAlign = HorizontalAlignment.Center
        ' 
        ' txtCustomerNetwork
        ' 
        txtCustomerNetwork.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtCustomerNetwork.BackColor = Color.WhiteSmoke
        txtCustomerNetwork.BorderStyle = BorderStyle.FixedSingle
        txtCustomerNetwork.Cursor = Cursors.Hand
        txtCustomerNetwork.Enabled = False
        txtCustomerNetwork.Font = New Font("Segoe UI", 12F)
        txtCustomerNetwork.ForeColor = SystemColors.WindowText
        txtCustomerNetwork.Location = New Point(166, 70)
        txtCustomerNetwork.Name = "txtCustomerNetwork"
        txtCustomerNetwork.ReadOnly = True
        txtCustomerNetwork.Size = New Size(267, 29)
        txtCustomerNetwork.TabIndex = 69
        txtCustomerNetwork.TextAlign = HorizontalAlignment.Center
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
        btnUpdate.Location = New Point(343, 360)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(111, 28)
        btnUpdate.TabIndex = 75
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
        btnCancel.Location = New Point(212, 360)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(111, 28)
        btnCancel.TabIndex = 74
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' lblAvailable
        ' 
        lblAvailable.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblAvailable.AutoSize = True
        lblAvailable.BackColor = Color.Transparent
        lblAvailable.Font = New Font("Verdana", 11F)
        lblAvailable.Location = New Point(18, 308)
        lblAvailable.Name = "lblAvailable"
        lblAvailable.Size = New Size(72, 18)
        lblAvailable.TabIndex = 71
        lblAvailable.Text = "Available"
        ' 
        ' LblOccupied
        ' 
        LblOccupied.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblOccupied.AutoSize = True
        LblOccupied.BackColor = Color.Transparent
        LblOccupied.Font = New Font("Verdana", 11F)
        LblOccupied.Location = New Point(18, 261)
        LblOccupied.Name = "LblOccupied"
        LblOccupied.Size = New Size(75, 18)
        LblOccupied.TabIndex = 68
        LblOccupied.Text = "Occupied"
        ' 
        ' lblLCPLocation
        ' 
        lblLCPLocation.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblLCPLocation.AutoSize = True
        lblLCPLocation.BackColor = Color.Transparent
        lblLCPLocation.Font = New Font("Verdana", 11F)
        lblLCPLocation.Location = New Point(18, 170)
        lblLCPLocation.Name = "lblLCPLocation"
        lblLCPLocation.Size = New Size(104, 18)
        lblLCPLocation.TabIndex = 67
        lblLCPLocation.Text = "LCP Location"
        ' 
        ' lblNap
        ' 
        lblNap.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblNap.AutoSize = True
        lblNap.BackColor = Color.Transparent
        lblNap.Font = New Font("Verdana", 11F)
        lblNap.Location = New Point(18, 220)
        lblNap.Name = "lblNap"
        lblNap.Size = New Size(38, 18)
        lblNap.TabIndex = 66
        lblNap.Text = "NAP"
        ' 
        ' LblAddressNetwork
        ' 
        LblAddressNetwork.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblAddressNetwork.AutoSize = True
        LblAddressNetwork.BackColor = Color.Transparent
        LblAddressNetwork.Font = New Font("Verdana", 11F)
        LblAddressNetwork.Location = New Point(18, 119)
        LblAddressNetwork.Name = "LblAddressNetwork"
        LblAddressNetwork.Size = New Size(67, 18)
        LblAddressNetwork.TabIndex = 65
        LblAddressNetwork.Text = "Address"
        ' 
        ' LblCustomerNetwork
        ' 
        LblCustomerNetwork.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblCustomerNetwork.AutoSize = True
        LblCustomerNetwork.BackColor = Color.Transparent
        LblCustomerNetwork.Font = New Font("Verdana", 11F)
        LblCustomerNetwork.Location = New Point(18, 70)
        LblCustomerNetwork.Name = "LblCustomerNetwork"
        LblCustomerNetwork.Size = New Size(82, 18)
        LblCustomerNetwork.TabIndex = 64
        LblCustomerNetwork.Text = "Customer"
        ' 
        ' LblCreateService
        ' 
        LblCreateService.AutoSize = True
        LblCreateService.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblCreateService.Location = New Point(12, 27)
        LblCreateService.Name = "LblCreateService"
        LblCreateService.Size = New Size(69, 25)
        LblCreateService.TabIndex = 63
        LblCreateService.Text = "Create"
        ' 
        ' txtLCPLoc
        ' 
        txtLCPLoc.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtLCPLoc.BackColor = Color.WhiteSmoke
        txtLCPLoc.BorderStyle = BorderStyle.FixedSingle
        txtLCPLoc.Cursor = Cursors.Hand
        txtLCPLoc.Enabled = False
        txtLCPLoc.Font = New Font("Segoe UI", 12F)
        txtLCPLoc.ForeColor = SystemColors.WindowText
        txtLCPLoc.Location = New Point(166, 170)
        txtLCPLoc.Name = "txtLCPLoc"
        txtLCPLoc.ReadOnly = True
        txtLCPLoc.Size = New Size(267, 29)
        txtLCPLoc.TabIndex = 80
        txtLCPLoc.TabStop = False
        txtLCPLoc.TextAlign = HorizontalAlignment.Center
        ' 
        ' cbNAP
        ' 
        cbNAP.DropDownStyle = ComboBoxStyle.DropDownList
        cbNAP.FormattingEnabled = True
        cbNAP.Items.AddRange(New Object() {"All Plans", "Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})
        cbNAP.Location = New Point(166, 217)
        cbNAP.Margin = New Padding(3, 2, 3, 2)
        cbNAP.Name = "cbNAP"
        cbNAP.Size = New Size(267, 23)
        cbNAP.TabIndex = 81
        ' 
        ' cbOccupied
        ' 
        cbOccupied.DropDownStyle = ComboBoxStyle.DropDownList
        cbOccupied.FormattingEnabled = True
        cbOccupied.Items.AddRange(New Object() {"All Plans", "Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})
        cbOccupied.Location = New Point(166, 258)
        cbOccupied.Margin = New Padding(3, 2, 3, 2)
        cbOccupied.Name = "cbOccupied"
        cbOccupied.Size = New Size(267, 23)
        cbOccupied.TabIndex = 82
        ' 
        ' cbAvailable
        ' 
        cbAvailable.DropDownStyle = ComboBoxStyle.DropDownList
        cbAvailable.FormattingEnabled = True
        cbAvailable.Items.AddRange(New Object() {"All Plans", "Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})
        cbAvailable.Location = New Point(166, 303)
        cbAvailable.Margin = New Padding(3, 2, 3, 2)
        cbAvailable.Name = "cbAvailable"
        cbAvailable.Size = New Size(267, 23)
        cbAvailable.TabIndex = 83
        ' 
        ' frmCustomerNetworkMappingCreate
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(466, 409)
        Controls.Add(cbAvailable)
        Controls.Add(cbOccupied)
        Controls.Add(cbNAP)
        Controls.Add(txtLCPLoc)
        Controls.Add(txtAddressNetwork)
        Controls.Add(txtCustomerNetwork)
        Controls.Add(btnUpdate)
        Controls.Add(btnCancel)
        Controls.Add(lblAvailable)
        Controls.Add(LblOccupied)
        Controls.Add(lblLCPLocation)
        Controls.Add(lblNap)
        Controls.Add(LblAddressNetwork)
        Controls.Add(LblCustomerNetwork)
        Controls.Add(LblCreateService)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmCustomerNetworkMappingCreate"
        Text = "frmCustomerNetworkMappingCreate"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtAddressNetwork As TextBox
    Friend WithEvents txtCustomerNetwork As TextBox
    Friend WithEvents btnUpdate As ButtonRounded
    Friend WithEvents btnCancel As ButtonRounded
    Friend WithEvents lblAvailable As Label
    Friend WithEvents LblOccupied As Label
    Friend WithEvents lblLCPLocation As Label
    Friend WithEvents lblNap As Label
    Friend WithEvents LblAddressNetwork As Label
    Friend WithEvents LblCustomerNetwork As Label
    Friend WithEvents LblCreateService As Label
    Friend WithEvents txtLCPLoc As TextBox
    Friend WithEvents cbNAP As ComboBox
    Friend WithEvents cbOccupied As ComboBox
    Friend WithEvents cbAvailable As ComboBox
End Class
