<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventoryUpdate
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
        LblServType = New Label()
        txtSerialNo = New TextBox()
        txtBrand = New TextBox()
        btnUpdate = New ButtonRounded()
        btnCancel = New ButtonRounded()
        DateTimePicker1 = New DateTimePicker()
        LblTechnician = New Label()
        LblDate = New Label()
        cbServiceType = New ComboBox()
        LblSerialNo = New Label()
        LblBrand = New Label()
        lblItemID = New Label()
        LblUpdate = New Label()
        LblItemName = New Label()
        lblStatus = New Label()
        txtItemID = New TextBox()
        comboItemName = New ComboBox()
        comboStatus = New ComboBox()
        txtTechSearch = New TextBox()
        SuspendLayout()
        ' 
        ' LblServType
        ' 
        LblServType.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblServType.AutoSize = True
        LblServType.BackColor = Color.Transparent
        LblServType.Font = New Font("Verdana", 11F)
        LblServType.Location = New Point(26, 270)
        LblServType.Name = "LblServType"
        LblServType.Size = New Size(102, 18)
        LblServType.TabIndex = 74
        LblServType.Text = "Service Type"
        ' 
        ' txtSerialNo
        ' 
        txtSerialNo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtSerialNo.BackColor = Color.WhiteSmoke
        txtSerialNo.BorderStyle = BorderStyle.FixedSingle
        txtSerialNo.Cursor = Cursors.Hand
        txtSerialNo.Enabled = False
        txtSerialNo.Font = New Font("Segoe UI", 12F)
        txtSerialNo.ForeColor = SystemColors.WindowText
        txtSerialNo.Location = New Point(174, 214)
        txtSerialNo.Name = "txtSerialNo"
        txtSerialNo.ReadOnly = True
        txtSerialNo.Size = New Size(267, 29)
        txtSerialNo.TabIndex = 70
        txtSerialNo.TextAlign = HorizontalAlignment.Center
        ' 
        ' txtBrand
        ' 
        txtBrand.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtBrand.BackColor = Color.WhiteSmoke
        txtBrand.BorderStyle = BorderStyle.FixedSingle
        txtBrand.Cursor = Cursors.Hand
        txtBrand.Enabled = False
        txtBrand.Font = New Font("Segoe UI", 12F)
        txtBrand.ForeColor = SystemColors.WindowText
        txtBrand.Location = New Point(174, 122)
        txtBrand.Name = "txtBrand"
        txtBrand.ReadOnly = True
        txtBrand.Size = New Size(267, 29)
        txtBrand.TabIndex = 66
        txtBrand.TextAlign = HorizontalAlignment.Center
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
        btnUpdate.Location = New Point(358, 453)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(122, 28)
        btnUpdate.TabIndex = 69
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
        btnCancel.Location = New Point(229, 453)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(122, 28)
        btnCancel.TabIndex = 68
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(174, 310)
        DateTimePicker1.Margin = New Padding(3, 2, 3, 2)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(267, 23)
        DateTimePicker1.TabIndex = 67
        ' 
        ' LblTechnician
        ' 
        LblTechnician.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblTechnician.AutoSize = True
        LblTechnician.BackColor = Color.Transparent
        LblTechnician.Font = New Font("Verdana", 11F)
        LblTechnician.Location = New Point(26, 356)
        LblTechnician.Name = "LblTechnician"
        LblTechnician.Size = New Size(82, 18)
        LblTechnician.TabIndex = 65
        LblTechnician.Text = "Technician"
        ' 
        ' LblDate
        ' 
        LblDate.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblDate.AutoSize = True
        LblDate.BackColor = Color.Transparent
        LblDate.Font = New Font("Verdana", 11F)
        LblDate.Location = New Point(26, 310)
        LblDate.Name = "LblDate"
        LblDate.Size = New Size(43, 18)
        LblDate.TabIndex = 64
        LblDate.Text = "Date"
        ' 
        ' cbServiceType
        ' 
        cbServiceType.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        cbServiceType.DropDownStyle = ComboBoxStyle.DropDownList
        cbServiceType.Font = New Font("Segoe UI", 12F)
        cbServiceType.FormattingEnabled = True
        cbServiceType.Items.AddRange(New Object() {"Installation", "Relocation", "Repair"})
        cbServiceType.Location = New Point(174, 265)
        cbServiceType.Margin = New Padding(3, 2, 3, 2)
        cbServiceType.Name = "cbServiceType"
        cbServiceType.Size = New Size(267, 29)
        cbServiceType.TabIndex = 72
        ' 
        ' LblSerialNo
        ' 
        LblSerialNo.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblSerialNo.AutoSize = True
        LblSerialNo.BackColor = Color.Transparent
        LblSerialNo.Font = New Font("Verdana", 11F)
        LblSerialNo.Location = New Point(26, 214)
        LblSerialNo.Name = "LblSerialNo"
        LblSerialNo.Size = New Size(79, 18)
        LblSerialNo.TabIndex = 63
        LblSerialNo.Text = "Serial No."
        ' 
        ' LblBrand
        ' 
        LblBrand.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblBrand.AutoSize = True
        LblBrand.BackColor = Color.Transparent
        LblBrand.Font = New Font("Verdana", 11F)
        LblBrand.Location = New Point(26, 122)
        LblBrand.Name = "LblBrand"
        LblBrand.Size = New Size(51, 18)
        LblBrand.TabIndex = 62
        LblBrand.Text = "Brand"
        ' 
        ' lblItemID
        ' 
        lblItemID.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblItemID.AutoSize = True
        lblItemID.BackColor = Color.Transparent
        lblItemID.Font = New Font("Verdana", 11F)
        lblItemID.Location = New Point(24, 71)
        lblItemID.Name = "lblItemID"
        lblItemID.Size = New Size(64, 18)
        lblItemID.TabIndex = 61
        lblItemID.Text = "Item ID"
        ' 
        ' LblUpdate
        ' 
        LblUpdate.AutoSize = True
        LblUpdate.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblUpdate.Location = New Point(20, 27)
        LblUpdate.Name = "LblUpdate"
        LblUpdate.Size = New Size(77, 25)
        LblUpdate.TabIndex = 60
        LblUpdate.Text = "Update"
        ' 
        ' LblItemName
        ' 
        LblItemName.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblItemName.AutoSize = True
        LblItemName.BackColor = Color.Transparent
        LblItemName.Font = New Font("Verdana", 11F)
        LblItemName.Location = New Point(24, 167)
        LblItemName.Name = "LblItemName"
        LblItemName.Size = New Size(92, 18)
        LblItemName.TabIndex = 75
        LblItemName.Text = "Item Name"
        ' 
        ' lblStatus
        ' 
        lblStatus.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblStatus.AutoSize = True
        lblStatus.BackColor = Color.Transparent
        lblStatus.Font = New Font("Verdana", 11F)
        lblStatus.Location = New Point(26, 402)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(56, 18)
        lblStatus.TabIndex = 77
        lblStatus.Text = "Status"
        ' 
        ' txtItemID
        ' 
        txtItemID.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtItemID.BackColor = Color.WhiteSmoke
        txtItemID.BorderStyle = BorderStyle.FixedSingle
        txtItemID.Cursor = Cursors.Hand
        txtItemID.Enabled = False
        txtItemID.Font = New Font("Segoe UI", 12F)
        txtItemID.ForeColor = SystemColors.WindowText
        txtItemID.Location = New Point(174, 71)
        txtItemID.Name = "txtItemID"
        txtItemID.ReadOnly = True
        txtItemID.Size = New Size(267, 29)
        txtItemID.TabIndex = 79
        txtItemID.TextAlign = HorizontalAlignment.Center
        ' 
        ' comboItemName
        ' 
        comboItemName.DropDownStyle = ComboBoxStyle.DropDownList
        comboItemName.Font = New Font("Segoe UI", 12F)
        comboItemName.FormattingEnabled = True
        comboItemName.Location = New Point(174, 167)
        comboItemName.Margin = New Padding(3, 2, 3, 2)
        comboItemName.Name = "comboItemName"
        comboItemName.Size = New Size(267, 29)
        comboItemName.TabIndex = 76
        ' 
        ' comboStatus
        ' 
        comboStatus.DropDownStyle = ComboBoxStyle.DropDownList
        comboStatus.Font = New Font("Segoe UI", 12F)
        comboStatus.FormattingEnabled = True
        comboStatus.Items.AddRange(New Object() {"In Stock", "Low Stock", "Critical Low", "Out of Stock"})
        comboStatus.Location = New Point(174, 397)
        comboStatus.Margin = New Padding(3, 2, 3, 2)
        comboStatus.Name = "comboStatus"
        comboStatus.Size = New Size(267, 29)
        comboStatus.TabIndex = 78
        ' 
        ' txtTechSearch
        ' 
        txtTechSearch.Font = New Font("Segoe UI", 13F)
        txtTechSearch.Location = New Point(174, 350)
        txtTechSearch.Name = "txtTechSearch"
        txtTechSearch.PlaceholderText = "Search technician..."
        txtTechSearch.Size = New Size(267, 31)
        txtTechSearch.TabIndex = 80
        ' 
        ' frmInventoryUpdate
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(492, 509)
        Controls.Add(txtTechSearch)
        Controls.Add(txtItemID)
        Controls.Add(comboStatus)
        Controls.Add(lblStatus)
        Controls.Add(comboItemName)
        Controls.Add(LblItemName)
        Controls.Add(LblServType)
        Controls.Add(txtSerialNo)
        Controls.Add(txtBrand)
        Controls.Add(btnUpdate)
        Controls.Add(btnCancel)
        Controls.Add(DateTimePicker1)
        Controls.Add(LblTechnician)
        Controls.Add(LblDate)
        Controls.Add(cbServiceType)
        Controls.Add(LblSerialNo)
        Controls.Add(LblBrand)
        Controls.Add(lblItemID)
        Controls.Add(LblUpdate)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmInventoryUpdate"
        Text = "frmInventoryUpdate"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LblServType As Label
    Friend WithEvents txtSerialNo As TextBox
    Friend WithEvents txtBrand As TextBox
    Friend WithEvents btnUpdate As ButtonRounded
    Friend WithEvents btnCancel As ButtonRounded
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents LblTechnician As Label
    Friend WithEvents LblDate As Label
    Friend WithEvents cbServiceType As ComboBox
    Friend WithEvents LblSerialNo As Label
    Friend WithEvents LblBrand As Label
    Friend WithEvents lblItemID As Label
    Friend WithEvents LblUpdate As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LblItemName As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents txtItemID As TextBox
    Friend WithEvents comboItemName As ComboBox
    Friend WithEvents comboStatus As ComboBox
    Friend WithEvents txtTechSearch As TextBox
End Class
