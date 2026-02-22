<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SAPayrollExport
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
        btnCancel = New ButtonRounded()
        btnExport = New ButtonRounded()
        lblEndDate = New Label()
        lblStartDate = New Label()
        cbTimePeriod = New ComboBox()
        LblTimePeriod = New Label()
        DTPEnd = New DateTimePicker()
        DTPStart = New DateTimePicker()
        cbPositions = New ComboBox()
        LblServiceType = New Label()
        LblDateRange = New Label()
        LblExportReportForm = New Label()
        cbExportFormat = New ComboBox()
        LblExportFormat = New Label()
        SuspendLayout()
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.Red
        btnCancel.CornerRadius = 8
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(295, 332)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(83, 36)
        btnCancel.TabIndex = 121
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' btnExport
        ' 
        btnExport.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnExport.CornerRadius = 8
        btnExport.FlatAppearance.BorderSize = 0
        btnExport.FlatStyle = FlatStyle.Flat
        btnExport.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnExport.ForeColor = Color.White
        btnExport.Location = New Point(405, 332)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(83, 36)
        btnExport.TabIndex = 120
        btnExport.Text = "Export"
        btnExport.UseVisualStyleBackColor = False
        ' 
        ' lblEndDate
        ' 
        lblEndDate.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblEndDate.AutoSize = True
        lblEndDate.BackColor = Color.Transparent
        lblEndDate.Font = New Font("Verdana", 11F)
        lblEndDate.ForeColor = SystemColors.ControlDarkDark
        lblEndDate.Location = New Point(157, 256)
        lblEndDate.Name = "lblEndDate"
        lblEndDate.Size = New Size(42, 18)
        lblEndDate.TabIndex = 119
        lblEndDate.Text = "End:"
        ' 
        ' lblStartDate
        ' 
        lblStartDate.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblStartDate.AutoSize = True
        lblStartDate.BackColor = Color.Transparent
        lblStartDate.Font = New Font("Verdana", 11F)
        lblStartDate.ForeColor = SystemColors.ControlDarkDark
        lblStartDate.Location = New Point(157, 221)
        lblStartDate.Name = "lblStartDate"
        lblStartDate.Size = New Size(52, 18)
        lblStartDate.TabIndex = 118
        lblStartDate.Text = "Start:"
        ' 
        ' cbTimePeriod
        ' 
        cbTimePeriod.DropDownStyle = ComboBoxStyle.DropDownList
        cbTimePeriod.Font = New Font("Segoe UI", 12F)
        cbTimePeriod.FormattingEnabled = True

        cbTimePeriod.Items.AddRange(New Object() {"All Time", "Custom", "Daily", "Weekly", "Monthly", "Quarterly", "Yearly"})
        cbTimePeriod.Location = New Point(157, 154)
        cbTimePeriod.Name = "cbTimePeriod"
        cbTimePeriod.Size = New Size(330, 29)
        cbTimePeriod.TabIndex = 117
        ' 
        ' LblTimePeriod
        ' 
        LblTimePeriod.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblTimePeriod.AutoSize = True
        LblTimePeriod.BackColor = Color.Transparent
        LblTimePeriod.Font = New Font("Verdana", 11F)
        LblTimePeriod.Location = New Point(30, 159)
        LblTimePeriod.Name = "LblTimePeriod"
        LblTimePeriod.Size = New Size(95, 18)
        LblTimePeriod.TabIndex = 116
        LblTimePeriod.Text = "Time Period"
        ' 
        ' DTPEnd
        ' 
        DTPEnd.Font = New Font("Segoe UI", 12F)
        DTPEnd.Format = DateTimePickerFormat.Custom
        DTPEnd.Location = New Point(215, 248)
        DTPEnd.Name = "DTPEnd"
        DTPEnd.Size = New Size(272, 29)
        DTPEnd.TabIndex = 115
        ' 
        ' DTPStart
        ' 
        DTPStart.Font = New Font("Segoe UI", 12F)
        DTPStart.Format = DateTimePickerFormat.Custom
        DTPStart.Location = New Point(215, 213)
        DTPStart.Name = "DTPStart"
        DTPStart.Size = New Size(272, 29)
        DTPStart.TabIndex = 114
        ' 
        ' cbPositions
        ' 
        cbPositions.DropDownStyle = ComboBoxStyle.DropDownList
        cbPositions.Font = New Font("Segoe UI", 12F)
        cbPositions.FormattingEnabled = True
        cbPositions.Location = New Point(158, 85)
        cbPositions.Name = "cbPositions"
        cbPositions.Size = New Size(330, 29)
        cbPositions.TabIndex = 113
        ' 
        ' LblServiceType
        ' 
        LblServiceType.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblServiceType.AutoSize = True
        LblServiceType.BackColor = Color.Transparent
        LblServiceType.Font = New Font("Verdana", 11F)
        LblServiceType.Location = New Point(31, 90)
        LblServiceType.Name = "LblServiceType"
        LblServiceType.Size = New Size(74, 18)
        LblServiceType.TabIndex = 112
        LblServiceType.Text = "Positions"
        ' 
        ' LblDateRange
        ' 
        LblDateRange.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblDateRange.AutoSize = True
        LblDateRange.BackColor = Color.Transparent
        LblDateRange.Font = New Font("Verdana", 11F)
        LblDateRange.Location = New Point(30, 221)
        LblDateRange.Name = "LblDateRange"
        LblDateRange.Size = New Size(94, 18)
        LblDateRange.TabIndex = 111
        LblDateRange.Text = "Date Range"
        ' 
        ' LblExportReportForm
        ' 
        LblExportReportForm.AutoSize = True
        LblExportReportForm.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblExportReportForm.Location = New Point(31, 34)
        LblExportReportForm.Name = "LblExportReportForm"
        LblExportReportForm.Size = New Size(192, 25)
        LblExportReportForm.TabIndex = 110
        LblExportReportForm.Text = "Payroll Export Form"
        ' 
        ' cbExportFormat
        ' 
        cbExportFormat.DropDownStyle = ComboBoxStyle.DropDownList
        cbExportFormat.Font = New Font("Segoe UI", 12F)
        cbExportFormat.FormattingEnabled = True
        cbExportFormat.Items.AddRange(New Object() {"CSV", "PDF"})
        cbExportFormat.Location = New Point(158, 285)
        cbExportFormat.Name = "cbExportFormat"
        cbExportFormat.Size = New Size(330, 29)
        cbExportFormat.TabIndex = 123
        ' 
        ' LblExportFormat
        ' 
        LblExportFormat.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblExportFormat.AutoSize = True
        LblExportFormat.BackColor = Color.Transparent
        LblExportFormat.Font = New Font("Verdana", 11F)
        LblExportFormat.Location = New Point(31, 290)
        LblExportFormat.Name = "LblExportFormat"
        LblExportFormat.Size = New Size(117, 18)
        LblExportFormat.TabIndex = 122
        LblExportFormat.Text = "Export Format"
        ' 
        ' SAPayrollExport
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(519, 402)
        Controls.Add(cbExportFormat)
        Controls.Add(LblExportFormat)
        Controls.Add(btnCancel)
        Controls.Add(btnExport)
        Controls.Add(lblEndDate)
        Controls.Add(lblStartDate)
        Controls.Add(cbTimePeriod)
        Controls.Add(LblTimePeriod)
        Controls.Add(DTPEnd)
        Controls.Add(DTPStart)
        Controls.Add(cbPositions)
        Controls.Add(LblServiceType)
        Controls.Add(LblDateRange)
        Controls.Add(LblExportReportForm)
        FormBorderStyle = FormBorderStyle.None
        Name = "SAPayrollExport"
        Text = "SAPayrollExport"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnCancel As ButtonRounded
    Friend WithEvents btnExport As ButtonRounded
    Friend WithEvents lblEndDate As Label
    Friend WithEvents lblStartDate As Label
    Friend WithEvents cbTimePeriod As ComboBox
    Friend WithEvents LblTimePeriod As Label
    Friend WithEvents DTPEnd As DateTimePicker
    Friend WithEvents DTPStart As DateTimePicker
    Friend WithEvents cbPositions As ComboBox
    Friend WithEvents LblServiceType As Label
    Friend WithEvents LblDateRange As Label
    Friend WithEvents LblExportReportForm As Label
    Friend WithEvents cbExportFormat As ComboBox
    Friend WithEvents LblExportFormat As Label
End Class