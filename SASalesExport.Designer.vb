<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SASalesExport
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
        LblExportReportForm = New Label()
        LblDateRange = New Label()
        DTPStart = New DateTimePicker()
        DTPEnd = New DateTimePicker()
        LblTimePeriod = New Label()
        cbTimePeriod = New ComboBox()
        lblEndDate = New Label()
        lblStartDate = New Label()
        btnExport = New ButtonRounded()
        btnCancel = New ButtonRounded()
        LblPlanType = New Label()
        cbPlanType = New ComboBox()
        cbExportFormat = New ComboBox()
        LblExportFormat = New Label()
        SuspendLayout()
        ' 
        ' LblExportReportForm
        ' 
        LblExportReportForm.AutoSize = True
        LblExportReportForm.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblExportReportForm.Location = New Point(25, 22)
        LblExportReportForm.Name = "LblExportReportForm"
        LblExportReportForm.Size = New Size(174, 25)
        LblExportReportForm.TabIndex = 64
        LblExportReportForm.Text = "Sales Export Form"
        ' 
        ' LblDateRange
        ' 
        LblDateRange.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblDateRange.AutoSize = True
        LblDateRange.BackColor = Color.Transparent
        LblDateRange.Font = New Font("Verdana", 11F)
        LblDateRange.Location = New Point(25, 141)
        LblDateRange.Name = "LblDateRange"
        LblDateRange.Size = New Size(94, 18)
        LblDateRange.TabIndex = 73
        LblDateRange.Text = "Date Range"
        ' 
        ' DTPStart
        ' 
        DTPStart.Font = New Font("Segoe UI", 12F)
        DTPStart.Format = DateTimePickerFormat.Custom
        DTPStart.Location = New Point(210, 133)
        DTPStart.Name = "DTPStart"
        DTPStart.Size = New Size(272, 29)
        DTPStart.TabIndex = 90
        ' 
        ' DTPEnd
        ' 
        DTPEnd.Font = New Font("Segoe UI", 12F)
        DTPEnd.Format = DateTimePickerFormat.Custom
        DTPEnd.Location = New Point(210, 168)
        DTPEnd.Name = "DTPEnd"
        DTPEnd.Size = New Size(272, 29)
        DTPEnd.TabIndex = 91
        ' 
        ' LblTimePeriod
        ' 
        LblTimePeriod.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblTimePeriod.AutoSize = True
        LblTimePeriod.BackColor = Color.Transparent
        LblTimePeriod.Font = New Font("Verdana", 11F)
        LblTimePeriod.Location = New Point(25, 73)
        LblTimePeriod.Name = "LblTimePeriod"
        LblTimePeriod.Size = New Size(95, 18)
        LblTimePeriod.TabIndex = 92
        LblTimePeriod.Text = "Time Period"
        ' 
        ' cbTimePeriod
        ' 
        cbTimePeriod.DropDownStyle = ComboBoxStyle.DropDownList
        cbTimePeriod.Font = New Font("Segoe UI", 12F)
        cbTimePeriod.FormattingEnabled = True
        cbTimePeriod.Items.AddRange(New Object() {"All Time", "Custom", "Daily", "Weekly", "Monthly", "Quarterly", "Yearly"})
        cbTimePeriod.Location = New Point(152, 68)
        cbTimePeriod.Name = "cbTimePeriod"
        cbTimePeriod.Size = New Size(330, 29)
        cbTimePeriod.TabIndex = 93
        ' 
        ' lblEndDate
        ' 
        lblEndDate.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblEndDate.AutoSize = True
        lblEndDate.BackColor = Color.Transparent
        lblEndDate.Font = New Font("Verdana", 11F)
        lblEndDate.ForeColor = SystemColors.ControlDarkDark
        lblEndDate.Location = New Point(152, 176)
        lblEndDate.Name = "lblEndDate"
        lblEndDate.Size = New Size(42, 18)
        lblEndDate.TabIndex = 95
        lblEndDate.Text = "End:"
        ' 
        ' lblStartDate
        ' 
        lblStartDate.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblStartDate.AutoSize = True
        lblStartDate.BackColor = Color.Transparent
        lblStartDate.Font = New Font("Verdana", 11F)
        lblStartDate.ForeColor = SystemColors.ControlDarkDark
        lblStartDate.Location = New Point(152, 141)
        lblStartDate.Name = "lblStartDate"
        lblStartDate.Size = New Size(52, 18)
        lblStartDate.TabIndex = 94
        lblStartDate.Text = "Start:"
        ' 
        ' btnExport
        ' 
        btnExport.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnExport.CornerRadius = 8
        btnExport.FlatAppearance.BorderSize = 0
        btnExport.FlatStyle = FlatStyle.Flat
        btnExport.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnExport.ForeColor = Color.White
        btnExport.Location = New Point(399, 304)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(83, 36)
        btnExport.TabIndex = 96
        btnExport.Text = "Export"
        btnExport.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.Red
        btnCancel.CornerRadius = 8
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(289, 304)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(83, 36)
        btnCancel.TabIndex = 97
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' LblPlanType
        ' 
        LblPlanType.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblPlanType.AutoSize = True
        LblPlanType.BackColor = Color.Transparent
        LblPlanType.Font = New Font("Verdana", 11F)
        LblPlanType.Location = New Point(25, 205)
        LblPlanType.Name = "LblPlanType"
        LblPlanType.Size = New Size(78, 18)
        LblPlanType.TabIndex = 75
        LblPlanType.Text = "Plan Type"
        ' 
        ' cbPlanType
        ' 
        cbPlanType.DropDownStyle = ComboBoxStyle.DropDownList
        cbPlanType.Font = New Font("Segoe UI", 12F)
        cbPlanType.FormattingEnabled = True
        cbPlanType.Items.AddRange(New Object() {"All Plans", "Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})
        cbPlanType.Location = New Point(152, 200)
        cbPlanType.MaxDropDownItems = 3
        cbPlanType.Name = "cbPlanType"
        cbPlanType.Size = New Size(330, 29)
        cbPlanType.TabIndex = 89
        ' 
        ' cbExportFormat
        ' 
        cbExportFormat.DropDownStyle = ComboBoxStyle.DropDownList
        cbExportFormat.Font = New Font("Segoe UI", 12F)
        cbExportFormat.FormattingEnabled = True
        cbExportFormat.Items.AddRange(New Object() {"CSV", "PDF"})
        cbExportFormat.Location = New Point(152, 251)
        cbExportFormat.Name = "cbExportFormat"
        cbExportFormat.Size = New Size(330, 29)
        cbExportFormat.TabIndex = 99
        ' 
        ' LblExportFormat
        ' 
        LblExportFormat.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblExportFormat.AutoSize = True
        LblExportFormat.BackColor = Color.Transparent
        LblExportFormat.Font = New Font("Verdana", 11F)
        LblExportFormat.Location = New Point(25, 256)
        LblExportFormat.Name = "LblExportFormat"
        LblExportFormat.Size = New Size(117, 18)
        LblExportFormat.TabIndex = 98
        LblExportFormat.Text = "Export Format"
        ' 
        ' SASalesExport
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        BackgroundImageLayout = ImageLayout.None
        ClientSize = New Size(519, 365)
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
        Controls.Add(cbPlanType)
        Controls.Add(LblPlanType)
        Controls.Add(LblDateRange)
        Controls.Add(LblExportReportForm)
        FormBorderStyle = FormBorderStyle.None
        Name = "SASalesExport"
        StartPosition = FormStartPosition.CenterScreen
        Text = "SASalesExport"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LblExportReportForm As Label
    Friend WithEvents LblDateRange As Label
    Friend WithEvents DTPStart As DateTimePicker
    Friend WithEvents DTPEnd As DateTimePicker
    Friend WithEvents LblTimePeriod As Label
    Friend WithEvents cbTimePeriod As ComboBox
    Friend WithEvents lblEndDate As Label
    Friend WithEvents lblStartDate As Label
    Friend WithEvents btnExport As ButtonRounded
    Friend WithEvents btnCancel As ButtonRounded
    Friend WithEvents LblPlanType As Label
    Friend WithEvents cbPlanType As ComboBox
    Friend WithEvents cbExportFormat As ComboBox
    Friend WithEvents LblExportFormat As Label
End Class