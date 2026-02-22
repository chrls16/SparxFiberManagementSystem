<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPayrollUpdate
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
        lblNetPay = New Label()
        txtDeductions = New TextBox()
        txtGrosPay = New TextBox()
        TxtDaysWorked = New TextBox()
        txtName = New TextBox()
        txtEmployeeID = New TextBox()
        btnUpdate = New ButtonRounded()
        btnCancel = New ButtonRounded()
        DropDownDailyRate = New ComboBox()
        lblDeduction = New Label()
        lblGrossPay = New Label()
        lblDailyRate = New Label()
        LblDaysWorked = New Label()
        LblPosition = New Label()
        LblName = New Label()
        lblEmploymeeID = New Label()
        LblUpdate = New Label()
        cbPosition = New ComboBox()
        lblAddress = New Label()
        txtAddress = New TextBox()
        lblAttendanceSummary = New Label()
        txtAttendanceSummary = New TextBox()
        lblAttendanceDate = New Label()
        dtpAttendanceDate = New DateTimePicker()
        btnMarkAttendance = New ButtonRounded()
        Panel1 = New Panel()
        txtNetPay = New TextBox()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblNetPay
        ' 
        lblNetPay.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblNetPay.AutoSize = True
        lblNetPay.BackColor = Color.Transparent
        lblNetPay.Font = New Font("Verdana", 11F)
        lblNetPay.Location = New Point(12, 493)
        lblNetPay.Name = "lblNetPay"
        lblNetPay.Size = New Size(66, 18)
        lblNetPay.TabIndex = 88
        lblNetPay.Text = "Net Pay"
        ' 
        ' txtDeductions
        ' 
        txtDeductions.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtDeductions.BackColor = Color.WhiteSmoke
        txtDeductions.BorderStyle = BorderStyle.FixedSingle
        txtDeductions.Cursor = Cursors.Hand
        txtDeductions.Enabled = False
        txtDeductions.Font = New Font("Segoe UI", 12F)
        txtDeductions.ForeColor = SystemColors.WindowText
        txtDeductions.Location = New Point(160, 441)
        txtDeductions.Name = "txtDeductions"
        txtDeductions.ReadOnly = True
        txtDeductions.Size = New Size(265, 29)
        txtDeductions.TabIndex = 87
        txtDeductions.TabStop = False
        txtDeductions.TextAlign = HorizontalAlignment.Center
        ' 
        ' txtGrosPay
        ' 
        txtGrosPay.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtGrosPay.BackColor = Color.WhiteSmoke
        txtGrosPay.BorderStyle = BorderStyle.FixedSingle
        txtGrosPay.Cursor = Cursors.Hand
        txtGrosPay.Enabled = False
        txtGrosPay.Font = New Font("Segoe UI", 12F)
        txtGrosPay.ForeColor = SystemColors.WindowText
        txtGrosPay.Location = New Point(160, 396)
        txtGrosPay.Name = "txtGrosPay"
        txtGrosPay.ReadOnly = True
        txtGrosPay.Size = New Size(265, 29)
        txtGrosPay.TabIndex = 83
        txtGrosPay.TabStop = False
        txtGrosPay.TextAlign = HorizontalAlignment.Center
        ' 
        ' TxtDaysWorked
        ' 
        TxtDaysWorked.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TxtDaysWorked.BackColor = Color.WhiteSmoke
        TxtDaysWorked.BorderStyle = BorderStyle.FixedSingle
        TxtDaysWorked.Cursor = Cursors.Hand
        TxtDaysWorked.Enabled = False
        TxtDaysWorked.Font = New Font("Segoe UI", 12F)
        TxtDaysWorked.ForeColor = SystemColors.WindowText
        TxtDaysWorked.Location = New Point(160, 348)
        TxtDaysWorked.Name = "TxtDaysWorked"
        TxtDaysWorked.ReadOnly = True
        TxtDaysWorked.Size = New Size(265, 29)
        TxtDaysWorked.TabIndex = 78
        TxtDaysWorked.TabStop = False
        TxtDaysWorked.TextAlign = HorizontalAlignment.Center
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
        txtName.Location = New Point(158, 102)
        txtName.Name = "txtName"
        txtName.ReadOnly = True
        txtName.Size = New Size(265, 29)
        txtName.TabIndex = 77
        txtName.TextAlign = HorizontalAlignment.Center
        ' 
        ' txtEmployeeID
        ' 
        txtEmployeeID.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtEmployeeID.BackColor = Color.WhiteSmoke
        txtEmployeeID.BorderStyle = BorderStyle.FixedSingle
        txtEmployeeID.Cursor = Cursors.Hand
        txtEmployeeID.Enabled = False
        txtEmployeeID.Font = New Font("Segoe UI", 12F)
        txtEmployeeID.ForeColor = SystemColors.WindowText
        txtEmployeeID.Location = New Point(158, 51)
        txtEmployeeID.Name = "txtEmployeeID"
        txtEmployeeID.ReadOnly = True
        txtEmployeeID.Size = New Size(129, 29)
        txtEmployeeID.TabIndex = 76
        txtEmployeeID.TextAlign = HorizontalAlignment.Center
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
        btnUpdate.Location = New Point(335, 537)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(109, 28)
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
        btnCancel.DialogResult = DialogResult.Cancel
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 12F)
        btnCancel.ForeColor = Color.White
        btnCancel.ImageAlign = ContentAlignment.MiddleLeft
        btnCancel.Location = New Point(204, 537)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(109, 28)
        btnCancel.TabIndex = 81
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' DropDownDailyRate
        ' 
        DropDownDailyRate.DropDownStyle = ComboBoxStyle.DropDownList
        DropDownDailyRate.FormattingEnabled = True
        DropDownDailyRate.Items.AddRange(New Object() {"All Plans", "Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})
        DropDownDailyRate.Location = New Point(158, 302)
        DropDownDailyRate.Margin = New Padding(3, 2, 3, 2)
        DropDownDailyRate.Name = "DropDownDailyRate"
        DropDownDailyRate.Size = New Size(267, 23)
        DropDownDailyRate.TabIndex = 80
        ' 
        ' lblDeduction
        ' 
        lblDeduction.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblDeduction.AutoSize = True
        lblDeduction.BackColor = Color.Transparent
        lblDeduction.Font = New Font("Verdana", 11F)
        lblDeduction.Location = New Point(12, 447)
        lblDeduction.Name = "lblDeduction"
        lblDeduction.Size = New Size(90, 18)
        lblDeduction.TabIndex = 79
        lblDeduction.Text = "Deductions"
        ' 
        ' lblGrossPay
        ' 
        lblGrossPay.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblGrossPay.AutoSize = True
        lblGrossPay.BackColor = Color.Transparent
        lblGrossPay.Font = New Font("Verdana", 11F)
        lblGrossPay.Location = New Point(12, 400)
        lblGrossPay.Name = "lblGrossPay"
        lblGrossPay.Size = New Size(84, 18)
        lblGrossPay.TabIndex = 75
        lblGrossPay.Text = "Gross Pay"
        ' 
        ' lblDailyRate
        ' 
        lblDailyRate.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblDailyRate.AutoSize = True
        lblDailyRate.BackColor = Color.Transparent
        lblDailyRate.Font = New Font("Verdana", 11F)
        lblDailyRate.Location = New Point(10, 302)
        lblDailyRate.Name = "lblDailyRate"
        lblDailyRate.Size = New Size(82, 18)
        lblDailyRate.TabIndex = 74
        lblDailyRate.Text = "Daily Rate"
        ' 
        ' LblDaysWorked
        ' 
        LblDaysWorked.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblDaysWorked.AutoSize = True
        LblDaysWorked.BackColor = Color.Transparent
        LblDaysWorked.Font = New Font("Verdana", 11F)
        LblDaysWorked.Location = New Point(10, 352)
        LblDaysWorked.Name = "LblDaysWorked"
        LblDaysWorked.Size = New Size(107, 18)
        LblDaysWorked.TabIndex = 73
        LblDaysWorked.Text = "Days Worked"
        ' 
        ' LblPosition
        ' 
        LblPosition.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblPosition.AutoSize = True
        LblPosition.BackColor = Color.Transparent
        LblPosition.Font = New Font("Verdana", 11F)
        LblPosition.Location = New Point(10, 251)
        LblPosition.Name = "LblPosition"
        LblPosition.Size = New Size(66, 18)
        LblPosition.TabIndex = 72
        LblPosition.Text = "Position"
        ' 
        ' LblName
        ' 
        LblName.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblName.AutoSize = True
        LblName.BackColor = Color.Transparent
        LblName.Font = New Font("Verdana", 11F)
        LblName.Location = New Point(10, 102)
        LblName.Name = "LblName"
        LblName.Size = New Size(52, 18)
        LblName.TabIndex = 71
        LblName.Text = "Name"
        ' 
        ' lblEmploymeeID
        ' 
        lblEmploymeeID.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblEmploymeeID.AutoSize = True
        lblEmploymeeID.BackColor = Color.Transparent
        lblEmploymeeID.Font = New Font("Verdana", 11F)
        lblEmploymeeID.Location = New Point(8, 51)
        lblEmploymeeID.Name = "lblEmploymeeID"
        lblEmploymeeID.Size = New Size(102, 18)
        lblEmploymeeID.TabIndex = 70
        lblEmploymeeID.Text = "Employee ID"
        ' 
        ' LblUpdate
        ' 
        LblUpdate.AutoSize = True
        LblUpdate.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblUpdate.Location = New Point(4, 7)
        LblUpdate.Name = "LblUpdate"
        LblUpdate.Size = New Size(77, 25)
        LblUpdate.TabIndex = 69
        LblUpdate.Text = "Update"
        ' 
        ' cbPosition
        ' 
        cbPosition.DropDownStyle = ComboBoxStyle.DropDownList
        cbPosition.FormattingEnabled = True
        cbPosition.Items.AddRange(New Object() {"All Plans", "Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})
        cbPosition.Location = New Point(158, 251)
        cbPosition.Margin = New Padding(3, 2, 3, 2)
        cbPosition.Name = "cbPosition"
        cbPosition.Size = New Size(260, 23)
        cbPosition.TabIndex = 90
        ' 
        ' lblAddress
        ' 
        lblAddress.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblAddress.AutoSize = True
        lblAddress.BackColor = Color.Transparent
        lblAddress.Font = New Font("Verdana", 11F)
        lblAddress.Location = New Point(10, 151)
        lblAddress.Name = "lblAddress"
        lblAddress.Size = New Size(67, 18)
        lblAddress.TabIndex = 92
        lblAddress.Text = "Address"
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
        txtAddress.Location = New Point(158, 151)
        txtAddress.Name = "txtAddress"
        txtAddress.ReadOnly = True
        txtAddress.Size = New Size(265, 29)
        txtAddress.TabIndex = 93
        txtAddress.TextAlign = HorizontalAlignment.Center
        ' 
        ' lblAttendanceSummary
        ' 
        lblAttendanceSummary.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblAttendanceSummary.AutoSize = True
        lblAttendanceSummary.BackColor = Color.Transparent
        lblAttendanceSummary.Font = New Font("Verdana", 11F)
        lblAttendanceSummary.Location = New Point(10, 201)
        lblAttendanceSummary.Name = "lblAttendanceSummary"
        lblAttendanceSummary.Size = New Size(92, 18)
        lblAttendanceSummary.TabIndex = 94
        lblAttendanceSummary.Text = "Attendance"
        ' 
        ' txtAttendanceSummary
        ' 
        txtAttendanceSummary.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtAttendanceSummary.BackColor = Color.WhiteSmoke
        txtAttendanceSummary.BorderStyle = BorderStyle.FixedSingle
        txtAttendanceSummary.Cursor = Cursors.Hand
        txtAttendanceSummary.Enabled = False
        txtAttendanceSummary.Font = New Font("Segoe UI", 10F)
        txtAttendanceSummary.ForeColor = SystemColors.WindowText
        txtAttendanceSummary.Location = New Point(158, 201)
        txtAttendanceSummary.Name = "txtAttendanceSummary"
        txtAttendanceSummary.ReadOnly = True
        txtAttendanceSummary.Size = New Size(265, 25)
        txtAttendanceSummary.TabIndex = 95
        txtAttendanceSummary.TextAlign = HorizontalAlignment.Center
        ' 
        ' lblAttendanceDate
        ' 
        lblAttendanceDate.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblAttendanceDate.AutoSize = True
        lblAttendanceDate.BackColor = Color.Transparent
        lblAttendanceDate.Font = New Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblAttendanceDate.Location = New Point(6, 12)
        lblAttendanceDate.Name = "lblAttendanceDate"
        lblAttendanceDate.Size = New Size(113, 14)
        lblAttendanceDate.TabIndex = 96
        lblAttendanceDate.Text = "Attendance Date"
        ' 
        ' dtpAttendanceDate
        ' 
        dtpAttendanceDate.Format = DateTimePickerFormat.Short
        dtpAttendanceDate.Location = New Point(6, 29)
        dtpAttendanceDate.Name = "dtpAttendanceDate"
        dtpAttendanceDate.Size = New Size(122, 23)
        dtpAttendanceDate.TabIndex = 97
        ' 
        ' btnMarkAttendance
        ' 
        btnMarkAttendance.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        btnMarkAttendance.BackColor = Color.FromArgb(CByte(50), CByte(180), CByte(50))
        btnMarkAttendance.CornerRadius = 6
        btnMarkAttendance.Cursor = Cursors.Hand
        btnMarkAttendance.FlatAppearance.BorderSize = 0
        btnMarkAttendance.FlatStyle = FlatStyle.Flat
        btnMarkAttendance.Font = New Font("Segoe UI", 10F)
        btnMarkAttendance.ForeColor = Color.White
        btnMarkAttendance.ImageAlign = ContentAlignment.MiddleLeft
        btnMarkAttendance.Location = New Point(134, 27)
        btnMarkAttendance.Name = "btnMarkAttendance"
        btnMarkAttendance.Size = New Size(125, 27)
        btnMarkAttendance.TabIndex = 98
        btnMarkAttendance.Text = "Mark Attendance"
        btnMarkAttendance.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.WhiteSmoke
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(lblAttendanceDate)
        Panel1.Controls.Add(btnMarkAttendance)
        Panel1.Controls.Add(dtpAttendanceDate)
        Panel1.Location = New Point(158, 232)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(265, 64)
        Panel1.TabIndex = 99
        ' 
        ' txtNetPay
        ' 
        txtNetPay.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtNetPay.BackColor = Color.WhiteSmoke
        txtNetPay.BorderStyle = BorderStyle.FixedSingle
        txtNetPay.Cursor = Cursors.Hand
        txtNetPay.Enabled = False
        txtNetPay.Font = New Font("Segoe UI", 12F)
        txtNetPay.ForeColor = SystemColors.WindowText
        txtNetPay.Location = New Point(160, 489)
        txtNetPay.Name = "txtNetPay"
        txtNetPay.ReadOnly = True
        txtNetPay.Size = New Size(265, 29)
        txtNetPay.TabIndex = 100
        txtNetPay.TabStop = False
        txtNetPay.TextAlign = HorizontalAlignment.Center
        ' 
        ' frmPayrollUpdate
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(448, 580)
        Controls.Add(txtNetPay)
        Controls.Add(Panel1)
        Controls.Add(txtAttendanceSummary)
        Controls.Add(lblAttendanceSummary)
        Controls.Add(txtAddress)
        Controls.Add(lblAddress)
        Controls.Add(cbPosition)
        Controls.Add(lblNetPay)
        Controls.Add(txtDeductions)
        Controls.Add(txtGrosPay)
        Controls.Add(TxtDaysWorked)
        Controls.Add(txtName)
        Controls.Add(txtEmployeeID)
        Controls.Add(btnUpdate)
        Controls.Add(btnCancel)
        Controls.Add(DropDownDailyRate)
        Controls.Add(lblDeduction)
        Controls.Add(lblGrossPay)
        Controls.Add(lblDailyRate)
        Controls.Add(LblDaysWorked)
        Controls.Add(LblPosition)
        Controls.Add(LblName)
        Controls.Add(lblEmploymeeID)
        Controls.Add(LblUpdate)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmPayrollUpdate"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmPayrollUpdate"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents lblNetPay As Label
    Friend WithEvents txtDeductions As TextBox
    Friend WithEvents txtGrosPay As TextBox
    Friend WithEvents TxtDaysWorked As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtEmployeeID As TextBox
    Friend WithEvents btnUpdate As ButtonRounded
    Friend WithEvents btnCancel As ButtonRounded
    Friend WithEvents DropDownDailyRate As ComboBox
    Friend WithEvents lblDeduction As Label
    Friend WithEvents lblGrossPay As Label
    Friend WithEvents lblDailyRate As Label
    Friend WithEvents LblDaysWorked As Label
    Friend WithEvents LblPosition As Label
    Friend WithEvents LblName As Label
    Friend WithEvents lblEmploymeeID As Label
    Friend WithEvents LblUpdate As Label
    Friend WithEvents cbPosition As ComboBox
    Friend WithEvents lblAddress As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents lblAttendanceSummary As Label
    Friend WithEvents txtAttendanceSummary As TextBox
    Friend WithEvents lblAttendanceDate As Label
    Friend WithEvents dtpAttendanceDate As DateTimePicker
    Friend WithEvents btnMarkAttendance As ButtonRounded
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtNetPay As TextBox
End Class