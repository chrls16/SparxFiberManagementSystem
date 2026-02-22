<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventoryCreate
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
        txtBrand = New TextBox()
        btnCreate = New ButtonRounded()
        btnCancel = New ButtonRounded()
        lblUnitCost = New Label()
        LblSerialNo = New Label()
        LblBrand = New Label()
        lblItemName = New Label()
        LblCreate = New Label()
        txtSerialNo = New TextBox()
        lblStock = New Label()
        textItemName = New TextBox()
        txtStock = New TextBox()
        txtUnitCost = New TextBox()
        LblStatus = New Label()
        TxtStat = New TextBox()
        SuspendLayout()
        ' 
        ' txtBrand
        ' 
        txtBrand.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtBrand.BackColor = Color.WhiteSmoke
        txtBrand.BorderStyle = BorderStyle.FixedSingle
        txtBrand.Cursor = Cursors.Hand
        txtBrand.Font = New Font("Segoe UI", 12F)
        txtBrand.ForeColor = SystemColors.WindowText
        txtBrand.Location = New Point(164, 110)
        txtBrand.Name = "txtBrand"
        txtBrand.Size = New Size(267, 29)
        txtBrand.TabIndex = 49
        txtBrand.TextAlign = HorizontalAlignment.Center
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
        btnCreate.Location = New Point(338, 358)
        btnCreate.Name = "btnCreate"
        btnCreate.Size = New Size(122, 28)
        btnCreate.TabIndex = 54
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
        btnCancel.Location = New Point(209, 358)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(122, 28)
        btnCancel.TabIndex = 53
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' lblUnitCost
        ' 
        lblUnitCost.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblUnitCost.AutoSize = True
        lblUnitCost.BackColor = Color.Transparent
        lblUnitCost.Font = New Font("Verdana", 11F)
        lblUnitCost.Location = New Point(16, 267)
        lblUnitCost.Name = "lblUnitCost"
        lblUnitCost.Size = New Size(77, 18)
        lblUnitCost.TabIndex = 47
        lblUnitCost.Text = "Unit Cost"
        ' 
        ' LblSerialNo
        ' 
        LblSerialNo.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblSerialNo.AutoSize = True
        LblSerialNo.BackColor = Color.Transparent
        LblSerialNo.Font = New Font("Verdana", 11F)
        LblSerialNo.Location = New Point(16, 159)
        LblSerialNo.Name = "LblSerialNo"
        LblSerialNo.Size = New Size(79, 18)
        LblSerialNo.TabIndex = 44
        LblSerialNo.Text = "Serial No."
        ' 
        ' LblBrand
        ' 
        LblBrand.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblBrand.AutoSize = True
        LblBrand.BackColor = Color.Transparent
        LblBrand.Font = New Font("Verdana", 11F)
        LblBrand.Location = New Point(16, 110)
        LblBrand.Name = "LblBrand"
        LblBrand.Size = New Size(51, 18)
        LblBrand.TabIndex = 43
        LblBrand.Text = "Brand"
        ' 
        ' lblItemName
        ' 
        lblItemName.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblItemName.AutoSize = True
        lblItemName.BackColor = Color.Transparent
        lblItemName.Font = New Font("Verdana", 11F)
        lblItemName.Location = New Point(14, 59)
        lblItemName.Name = "lblItemName"
        lblItemName.Size = New Size(92, 18)
        lblItemName.TabIndex = 42
        lblItemName.Text = "Item Name"
        ' 
        ' LblCreate
        ' 
        LblCreate.AutoSize = True
        LblCreate.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblCreate.Location = New Point(10, 15)
        LblCreate.Name = "LblCreate"
        LblCreate.Size = New Size(69, 25)
        LblCreate.TabIndex = 41
        LblCreate.Text = "Create"
        ' 
        ' txtSerialNo
        ' 
        txtSerialNo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtSerialNo.BackColor = Color.WhiteSmoke
        txtSerialNo.BorderStyle = BorderStyle.FixedSingle
        txtSerialNo.Cursor = Cursors.Hand
        txtSerialNo.Font = New Font("Segoe UI", 12F)
        txtSerialNo.ForeColor = SystemColors.WindowText
        txtSerialNo.Location = New Point(164, 159)
        txtSerialNo.Name = "txtSerialNo"
        txtSerialNo.Size = New Size(267, 29)
        txtSerialNo.TabIndex = 55
        txtSerialNo.TextAlign = HorizontalAlignment.Center
        ' 
        ' lblStock
        ' 
        lblStock.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblStock.AutoSize = True
        lblStock.BackColor = Color.Transparent
        lblStock.Font = New Font("Verdana", 11F)
        lblStock.Location = New Point(16, 215)
        lblStock.Name = "lblStock"
        lblStock.Size = New Size(51, 18)
        lblStock.TabIndex = 59
        lblStock.Text = "Stock"
        ' 
        ' textItemName
        ' 
        textItemName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        textItemName.BackColor = Color.WhiteSmoke
        textItemName.BorderStyle = BorderStyle.FixedSingle
        textItemName.Cursor = Cursors.Hand
        textItemName.Font = New Font("Segoe UI", 12F)
        textItemName.ForeColor = SystemColors.WindowText
        textItemName.Location = New Point(164, 59)
        textItemName.Name = "textItemName"
        textItemName.Size = New Size(267, 29)
        textItemName.TabIndex = 60
        textItemName.TextAlign = HorizontalAlignment.Center
        ' 
        ' txtStock
        ' 
        txtStock.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtStock.BackColor = Color.WhiteSmoke
        txtStock.BorderStyle = BorderStyle.FixedSingle
        txtStock.Cursor = Cursors.Hand
        txtStock.Font = New Font("Segoe UI", 12F)
        txtStock.ForeColor = SystemColors.WindowText
        txtStock.Location = New Point(164, 211)
        txtStock.Name = "txtStock"
        txtStock.Size = New Size(267, 29)
        txtStock.TabIndex = 61
        txtStock.TextAlign = HorizontalAlignment.Center
        ' 
        ' txtUnitCost
        ' 
        txtUnitCost.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtUnitCost.BackColor = Color.WhiteSmoke
        txtUnitCost.BorderStyle = BorderStyle.FixedSingle
        txtUnitCost.Cursor = Cursors.Hand
        txtUnitCost.Font = New Font("Segoe UI", 12F)
        txtUnitCost.ForeColor = SystemColors.WindowText
        txtUnitCost.Location = New Point(164, 263)
        txtUnitCost.Name = "txtUnitCost"
        txtUnitCost.Size = New Size(267, 29)
        txtUnitCost.TabIndex = 62
        txtUnitCost.TextAlign = HorizontalAlignment.Center
        ' 
        ' LblStatus
        ' 
        LblStatus.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblStatus.AutoSize = True
        LblStatus.BackColor = Color.Transparent
        LblStatus.Font = New Font("Verdana", 11F)
        LblStatus.Location = New Point(16, 319)
        LblStatus.Name = "LblStatus"
        LblStatus.Size = New Size(56, 18)
        LblStatus.TabIndex = 63
        LblStatus.Text = "Status"
        ' 
        ' TxtStat
        ' 
        TxtStat.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TxtStat.BackColor = Color.WhiteSmoke
        TxtStat.BorderStyle = BorderStyle.FixedSingle
        TxtStat.Cursor = Cursors.Hand
        TxtStat.Font = New Font("Segoe UI", 12F)
        TxtStat.ForeColor = SystemColors.WindowText
        TxtStat.Location = New Point(164, 315)
        TxtStat.Name = "TxtStat"
        TxtStat.Size = New Size(267, 29)
        TxtStat.TabIndex = 64
        TxtStat.Text = "In Stock"
        TxtStat.TextAlign = HorizontalAlignment.Center
        ' 
        ' frmInventoryCreate
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(472, 398)
        Controls.Add(TxtStat)
        Controls.Add(LblStatus)
        Controls.Add(txtUnitCost)
        Controls.Add(txtStock)
        Controls.Add(textItemName)
        Controls.Add(lblStock)
        Controls.Add(txtSerialNo)
        Controls.Add(txtBrand)
        Controls.Add(btnCreate)
        Controls.Add(btnCancel)
        Controls.Add(lblUnitCost)
        Controls.Add(LblSerialNo)
        Controls.Add(LblBrand)
        Controls.Add(lblItemName)
        Controls.Add(LblCreate)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmInventoryCreate"
        Text = "frmInventoryCreate"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents txtBrand As TextBox
    Friend WithEvents txtItemName As TextBox
    Friend WithEvents btnCreate As ButtonRounded
    Friend WithEvents btnCancel As ButtonRounded
    Friend WithEvents DropDownStatus As ComboBox
    Friend WithEvents DropDownTechnician As ComboBox
    Friend WithEvents LblStatus As Label
    Friend WithEvents lblUnitCost As Label
    Friend WithEvents LblSerialNo As Label
    Friend WithEvents LblBrand As Label
    Friend WithEvents lblItemName As Label
    Friend WithEvents LblCreate As Label
    Friend WithEvents txtSerialNo As TextBox
    Friend WithEvents lblStock As Label
    Friend WithEvents textItemName As TextBox
    Friend WithEvents txtStock As TextBox
    Friend WithEvents txtUnitCost As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TxtStat As TextBox
End Class
