<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SAServiceExport
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
        btnCancel = New Button()
        btnExport = New Button()
        lblEndDate = New Label()
        lblStartDate = New Label()
        cbTimePeriod = New ComboBox()
        LblTimePeriod = New Label()
        DTPEnd = New DateTimePicker()
        DTPStart = New DateTimePicker()
        cbServiceType = New ComboBox()
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
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(295, 342)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(83, 36)
        btnCancel.TabIndex = 109
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' btnExport
        ' 
        btnExport.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnExport.FlatStyle = FlatStyle.Flat
        btnExport.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        btnExport.ForeColor = Color.White
        btnExport.Location = New Point(405, 342)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(83, 36)
        btnExport.TabIndex = 108
        btnExport.Text = "Export"
        btnExport.UseVisualStyleBackColor = False
        ' 
        ' lblEndDate
        ' 
        lblEndDate.AutoSize = True
        lblEndDate.BackColor = Color.Transparent
        lblEndDate.Font = New Font("Verdana", 11.0F)
        lblEndDate.ForeColor = SystemColors.ControlDarkDark
        lblEndDate.Location = New Point(158, 188)
        lblEndDate.Name = "lblEndDate"
        lblEndDate.Size = New Size(42, 18)
        lblEndDate.TabIndex = 107
        lblEndDate.Text = "End:"
        ' 
        ' lblStartDate
        ' 
        lblStartDate.AutoSize = True
        lblStartDate.BackColor = Color.Transparent
        lblStartDate.Font = New Font("Verdana", 11.0F)
        lblStartDate.ForeColor = SystemColors.ControlDarkDark
        lblStartDate.Location = New Point(158, 153)
        lblStartDate.Name = "lblStartDate"
        lblStartDate.Size = New Size(52, 18)
        lblStartDate.TabIndex = 106
        lblStartDate.Text = "Start:"
        ' 
        ' cbTimePeriod
        ' 
        cbTimePeriod.DropDownStyle = ComboBoxStyle.DropDownList
        cbTimePeriod.Font = New Font("Segoe UI", 12.0F)
        cbTimePeriod.FormattingEnabled = True
        cbTimePeriod.Items.AddRange(New Object() {"All Time", "Custom", "Daily", "Weekly", "Monthly", "Quarterly", "Yearly"})
        cbTimePeriod.Location = New Point(158, 80)
        cbTimePeriod.Name = "cbTimePeriod"
        cbTimePeriod.Size = New Size(330, 29)
        cbTimePeriod.TabIndex = 105
        ' 
        ' LblTimePeriod
        ' 
        LblTimePeriod.AutoSize = True
        LblTimePeriod.BackColor = Color.Transparent
        LblTimePeriod.Font = New Font("Verdana", 11.0F)
        LblTimePeriod.Location = New Point(31, 85)
        LblTimePeriod.Name = "LblTimePeriod"
        LblTimePeriod.Size = New Size(95, 18)
        LblTimePeriod.TabIndex = 104
        LblTimePeriod.Text = "Time Period"
        ' 
        ' DTPEnd
        ' 
        DTPEnd.Font = New Font("Segoe UI", 12.0F)
        DTPEnd.Format = DateTimePickerFormat.Custom
        DTPEnd.Location = New Point(216, 180)
        DTPEnd.Name = "DTPEnd"
        DTPEnd.Size = New Size(272, 29)
        DTPEnd.TabIndex = 103
        ' 
        ' DTPStart
        ' 
        DTPStart.Font = New Font("Segoe UI", 12.0F)
        DTPStart.Format = DateTimePickerFormat.Custom
        DTPStart.Location = New Point(216, 145)
        DTPStart.Name = "DTPStart"
        DTPStart.Size = New Size(272, 29)
        DTPStart.TabIndex = 102
        ' 
        ' cbServiceType
        ' 
        cbServiceType.DropDownStyle = ComboBoxStyle.DropDownList
        cbServiceType.Font = New Font("Segoe UI", 12.0F)
        cbServiceType.FormattingEnabled = True
        cbServiceType.Location = New Point(158, 242)
        cbServiceType.Name = "cbServiceType"
        cbServiceType.Size = New Size(330, 29)
        cbServiceType.TabIndex = 101
        ' 
        ' LblServiceType
        ' 
        LblServiceType.AutoSize = True
        LblServiceType.BackColor = Color.Transparent
        LblServiceType.Font = New Font("Verdana", 11.0F)
        LblServiceType.Location = New Point(31, 247)
        LblServiceType.Name = "LblServiceType"
        LblServiceType.Size = New Size(102, 18)
        LblServiceType.TabIndex = 100
        LblServiceType.Text = "Service Type"
        ' 
        ' LblDateRange
        ' 
        LblDateRange.AutoSize = True
        LblDateRange.BackColor = Color.Transparent
        LblDateRange.Font = New Font("Verdana", 11.0F)
        LblDateRange.Location = New Point(31, 153)
        LblDateRange.Name = "LblDateRange"
        LblDateRange.Size = New Size(94, 18)
        LblDateRange.TabIndex = 99
        LblDateRange.Text = "Date Range"
        ' 
        ' LblExportReportForm
        ' 
        LblExportReportForm.AutoSize = True
        LblExportReportForm.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold)
        LblExportReportForm.Location = New Point(31, 34)
        LblExportReportForm.Name = "LblExportReportForm"
        LblExportReportForm.Size = New Size(194, 25)
        LblExportReportForm.TabIndex = 98
        LblExportReportForm.Text = "Service Export Form"
        ' 
        ' cbExportFormat
        ' 
        cbExportFormat.DropDownStyle = ComboBoxStyle.DropDownList
        cbExportFormat.Font = New Font("Segoe UI", 12.0F)
        cbExportFormat.FormattingEnabled = True
        cbExportFormat.Items.AddRange(New Object() {"CSV", "PDF"})
        cbExportFormat.Location = New Point(158, 295)
        cbExportFormat.Name = "cbExportFormat"
        cbExportFormat.Size = New Size(330, 29)
        cbExportFormat.TabIndex = 111
        ' 
        ' LblExportFormat
        ' 
        LblExportFormat.AutoSize = True
        LblExportFormat.BackColor = Color.Transparent
        LblExportFormat.Font = New Font("Verdana", 11.0F)
        LblExportFormat.Location = New Point(31, 300)
        LblExportFormat.Name = "LblExportFormat"
        LblExportFormat.Size = New Size(117, 18)
        LblExportFormat.TabIndex = 110
        LblExportFormat.Text = "Export Format"
        ' 
        ' SAServiceExport
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(519, 412)
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
        Controls.Add(cbServiceType)
        Controls.Add(LblServiceType)
        Controls.Add(LblDateRange)
        Controls.Add(LblExportReportForm)
        FormBorderStyle = FormBorderStyle.None
        Name = "SAServiceExport"
        StartPosition = FormStartPosition.CenterScreen
        Text = "SAServiceExport"
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents lblEndDate As Label
    Friend WithEvents lblStartDate As Label
    Friend WithEvents cbTimePeriod As ComboBox
    Friend WithEvents LblTimePeriod As Label
    Friend WithEvents DTPEnd As DateTimePicker
    Friend WithEvents DTPStart As DateTimePicker
    Friend WithEvents cbServiceType As ComboBox
    Friend WithEvents LblServiceType As Label
    Friend WithEvents LblDateRange As Label
    Friend WithEvents LblExportReportForm As Label
    Friend WithEvents cbExportFormat As ComboBox
    Friend WithEvents LblExportFormat As Label
End Class