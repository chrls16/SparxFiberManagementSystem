<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInstallationUpdate
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
        txtCustomer = New TextBox()
        btnCreate = New ButtonRounded()
        btnCancel = New ButtonRounded()
        DropDownStatus = New ComboBox()
        txtTechnicianSearch = New TextBox()
        LblStatus = New Label()
        LblTechnician = New Label()
        LblAddress = New Label()
        LblCustomer = New Label()
        LblUpdate = New Label()
        LblDateRequested = New Label()
        DateTimePicker = New DateTimePicker()
        txtAddress = New TextBox()
        SuspendLayout()
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
        txtCustomer.Location = New Point(163, 59)
        txtCustomer.Name = "txtCustomer"
        txtCustomer.ReadOnly = True
        txtCustomer.Size = New Size(267, 29)
        txtCustomer.TabIndex = 64
        txtCustomer.TextAlign = HorizontalAlignment.Center
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
        btnCreate.Location = New Point(327, 304)
        btnCreate.Name = "btnCreate"
        btnCreate.Size = New Size(100, 28)
        btnCreate.TabIndex = 69
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
        btnCancel.Location = New Point(212, 304)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(100, 28)
        btnCancel.TabIndex = 68
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' DropDownStatus
        ' 
        DropDownStatus.DropDownStyle = ComboBoxStyle.DropDownList
        DropDownStatus.FormattingEnabled = True
        DropDownStatus.Items.AddRange(New Object() {"Active", "Cancelled", "Suspended"})
        DropDownStatus.Location = New Point(160, 247)
        DropDownStatus.Margin = New Padding(3, 2, 3, 2)
        DropDownStatus.Name = "DropDownStatus"
        DropDownStatus.Size = New Size(267, 23)
        DropDownStatus.TabIndex = 67
        ' 
        ' txtTechnicianSearch
        ' 
        txtTechnicianSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtTechnicianSearch.BackColor = Color.White
        txtTechnicianSearch.BorderStyle = BorderStyle.FixedSingle
        txtTechnicianSearch.Cursor = Cursors.IBeam
        txtTechnicianSearch.Font = New Font("Segoe UI", 12F)
        txtTechnicianSearch.ForeColor = SystemColors.WindowText
        txtTechnicianSearch.Location = New Point(160, 201)
        txtTechnicianSearch.Name = "txtTechnicianSearch"
        txtTechnicianSearch.Size = New Size(267, 29)
        txtTechnicianSearch.TabIndex = 66
        ' 
        ' LblStatus
        ' 
        LblStatus.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblStatus.AutoSize = True
        LblStatus.BackColor = Color.Transparent
        LblStatus.Font = New Font("Verdana", 11F)
        LblStatus.Location = New Point(12, 251)
        LblStatus.Name = "LblStatus"
        LblStatus.Size = New Size(56, 18)
        LblStatus.TabIndex = 62
        LblStatus.Text = "Status"
        ' 
        ' LblTechnician
        ' 
        LblTechnician.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblTechnician.AutoSize = True
        LblTechnician.BackColor = Color.Transparent
        LblTechnician.Font = New Font("Verdana", 11F)
        LblTechnician.Location = New Point(12, 205)
        LblTechnician.Name = "LblTechnician"
        LblTechnician.Size = New Size(82, 18)
        LblTechnician.TabIndex = 61
        LblTechnician.Text = "Technician"
        ' 
        ' LblAddress
        ' 
        LblAddress.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblAddress.AutoSize = True
        LblAddress.BackColor = Color.Transparent
        LblAddress.Font = New Font("Verdana", 11F)
        LblAddress.Location = New Point(15, 108)
        LblAddress.Name = "LblAddress"
        LblAddress.Size = New Size(67, 18)
        LblAddress.TabIndex = 59
        LblAddress.Text = "Address"
        ' 
        ' LblCustomer
        ' 
        LblCustomer.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblCustomer.AutoSize = True
        LblCustomer.BackColor = Color.Transparent
        LblCustomer.Font = New Font("Verdana", 11F)
        LblCustomer.Location = New Point(15, 59)
        LblCustomer.Name = "LblCustomer"
        LblCustomer.Size = New Size(82, 18)
        LblCustomer.TabIndex = 58
        LblCustomer.Text = "Customer"
        ' 
        ' LblUpdate
        ' 
        LblUpdate.AutoSize = True
        LblUpdate.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblUpdate.Location = New Point(10, 17)
        LblUpdate.Name = "LblUpdate"
        LblUpdate.Size = New Size(77, 25)
        LblUpdate.TabIndex = 56
        LblUpdate.Text = "Update"
        ' 
        ' LblDateRequested
        ' 
        LblDateRequested.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblDateRequested.AutoSize = True
        LblDateRequested.BackColor = Color.Transparent
        LblDateRequested.Font = New Font("Verdana", 11F)
        LblDateRequested.Location = New Point(12, 157)
        LblDateRequested.Name = "LblDateRequested"
        LblDateRequested.Size = New Size(126, 18)
        LblDateRequested.TabIndex = 71
        LblDateRequested.Text = "Date Requested"
        ' 
        ' DateTimePicker
        ' 
        DateTimePicker.Location = New Point(160, 157)
        DateTimePicker.Margin = New Padding(3, 2, 3, 2)
        DateTimePicker.Name = "DateTimePicker"
        DateTimePicker.Size = New Size(267, 23)
        DateTimePicker.TabIndex = 72
        ' 
        ' txtAddress
        ' 
        txtAddress.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtAddress.BackColor = Color.WhiteSmoke
        txtAddress.BorderStyle = BorderStyle.FixedSingle
        txtAddress.Cursor = Cursors.Hand
        txtAddress.Enabled = False
        txtAddress.Font = New Font("Segoe UI", 12F)
        txtAddress.ForeColor = SystemColors.WindowText
        txtAddress.Location = New Point(163, 104)
        txtAddress.Name = "txtAddress"
        txtAddress.ReadOnly = True
        txtAddress.Size = New Size(267, 29)
        txtAddress.TabIndex = 73
        txtAddress.TextAlign = HorizontalAlignment.Center
        ' 
        ' frmInstallationUpdate
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        ClientSize = New Size(450, 370)
        Controls.Add(txtAddress)
        Controls.Add(DateTimePicker)
        Controls.Add(LblDateRequested)
        Controls.Add(txtCustomer)
        Controls.Add(btnCreate)
        Controls.Add(btnCancel)
        Controls.Add(DropDownStatus)
        Controls.Add(txtTechnicianSearch)
        Controls.Add(LblStatus)
        Controls.Add(LblTechnician)
        Controls.Add(LblAddress)
        Controls.Add(LblCustomer)
        Controls.Add(LblUpdate)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmInstallationUpdate"
        Text = "frmInstallationUpdate"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents serviceID As TextBox
    Friend WithEvents btnCreate As ButtonRounded
    Friend WithEvents btnCancel As ButtonRounded
    Friend WithEvents DropDownStatus As ComboBox
    Friend WithEvents txtTechnicianSearch As TextBox
    Friend WithEvents LblStatus As Label
    Friend WithEvents LblTechnician As Label
    Friend WithEvents LblAddress As Label
    Friend WithEvents LblCustomer As Label
    Friend WithEvents LblUpdate As Label
    Friend WithEvents LblDateRequested As Label
    Friend WithEvents DateTimePicker As DateTimePicker
    Friend WithEvents txtAddress As TextBox
End Class