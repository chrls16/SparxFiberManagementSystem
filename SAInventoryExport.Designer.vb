<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SAInventoryExport
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
        DTPEnd = New DateTimePicker()
        DTPStart = New DateTimePicker()
        LblDateRange = New Label()
        LblExportReportForm = New Label()
        cbExportFormat = New ComboBox()
        LblExportFormat = New Label()
        cbTimePeriod = New ComboBox()
        LblTimePeriod = New Label()
        SuspendLayout()
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.Red
        btnCancel.CornerRadius = 8
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(295, 270)
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
        btnExport.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnExport.ForeColor = Color.White
        btnExport.Location = New Point(405, 270)
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
        lblEndDate.Font = New Font("Verdana", 11.0F)
        lblEndDate.ForeColor = SystemColors.ControlDarkDark
        lblEndDate.Location = New Point(158, 145)
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
        lblStartDate.Font = New Font("Verdana", 11.0F)
        lblStartDate.ForeColor = SystemColors.ControlDarkDark
        lblStartDate.Location = New Point(158, 110)
        lblStartDate.Name = "lblStartDate"
        lblStartDate.Size = New Size(52, 18)
        lblStartDate.TabIndex = 118
        lblStartDate.Text = "Start:"
        ' 
        ' DTPEnd
        ' 
        DTPEnd.Font = New Font("Segoe UI", 12.0F)
        DTPEnd.Format = DateTimePickerFormat.Custom
        DTPEnd.Location = New Point(216, 137)
        DTPEnd.Name = "DTPEnd"
        DTPEnd.Size = New Size(272, 29)
        DTPEnd.TabIndex = 115
        ' 
        ' DTPStart
        ' 
        DTPStart.Font = New Font("Segoe UI", 12.0F)
        DTPStart.Format = DateTimePickerFormat.Custom
        DTPStart.Location = New Point(216, 102)
        DTPStart.Name = "DTPStart"
        DTPStart.Size = New Size(272, 29)
        DTPStart.TabIndex = 114
        ' 
        ' LblDateRange
        ' 
        LblDateRange.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblDateRange.AutoSize = True
        LblDateRange.BackColor = Color.Transparent
        LblDateRange.Font = New Font("Verdana", 11.0F)
        LblDateRange.Location = New Point(31, 110)
        LblDateRange.Name = "LblDateRange"
        LblDateRange.Size = New Size(114, 18)
        LblDateRange.TabIndex = 111
        LblDateRange.Text = "Date Received"
        ' 
        ' LblExportReportForm
        ' 
        LblExportReportForm.AutoSize = True
        LblExportReportForm.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblExportReportForm.Location = New Point(31, 28)
        LblExportReportForm.Name = "LblExportReportForm"
        LblExportReportForm.Size = New Size(218, 25)
        LblExportReportForm.TabIndex = 110
        LblExportReportForm.Text = "Inventory Export Form"
        ' 
        ' cbExportFormat
        ' 
        cbExportFormat.DropDownStyle = ComboBoxStyle.DropDownList
        cbExportFormat.Font = New Font("Segoe UI", 12.0F)
        cbExportFormat.FormattingEnabled = True
        cbExportFormat.Items.AddRange(New Object() {"CSV", "PDF"})
        cbExportFormat.Location = New Point(158, 220)
        cbExportFormat.Name = "cbExportFormat"
        cbExportFormat.Size = New Size(330, 29)
        cbExportFormat.TabIndex = 123
        ' 
        ' LblExportFormat
        ' 
        LblExportFormat.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblExportFormat.AutoSize = True
        LblExportFormat.BackColor = Color.Transparent
        LblExportFormat.Font = New Font("Verdana", 11.0F)
        LblExportFormat.Location = New Point(31, 225)
        LblExportFormat.Name = "LblExportFormat"
        LblExportFormat.Size = New Size(111, 18)
        LblExportFormat.TabIndex = 122
        LblExportFormat.Text = "Export Format"
        ' 
        ' cbTimePeriod
        ' 
        cbTimePeriod.DropDownStyle = ComboBoxStyle.DropDownList
        cbTimePeriod.Font = New Font("Segoe UI", 12.0F)
        cbTimePeriod.FormattingEnabled = True
        cbTimePeriod.Items.AddRange(New Object() {"All Time", "Custom", "Daily", "Weekly", "Monthly", "Quarterly", "Yearly"})
        cbTimePeriod.Location = New Point(158, 65)
        cbTimePeriod.Name = "cbTimePeriod"
        cbTimePeriod.Size = New Size(330, 29)
        cbTimePeriod.TabIndex = 125
        ' 
        ' LblTimePeriod
        ' 
        LblTimePeriod.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblTimePeriod.AutoSize = True
        LblTimePeriod.BackColor = Color.Transparent
        LblTimePeriod.Font = New Font("Verdana", 11.0F)
        LblTimePeriod.Location = New Point(31, 70)
        LblTimePeriod.Name = "LblTimePeriod"
        LblTimePeriod.Size = New Size(95, 18)
        LblTimePeriod.TabIndex = 124
        LblTimePeriod.Text = "Time Period"
        ' 
        ' SAInventoryExport
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(519, 347)
        Controls.Add(cbTimePeriod)
        Controls.Add(LblTimePeriod)
        Controls.Add(cbExportFormat)
        Controls.Add(LblExportFormat)
        Controls.Add(btnCancel)
        Controls.Add(btnExport)
        Controls.Add(lblEndDate)
        Controls.Add(lblStartDate)
        Controls.Add(DTPEnd)
        Controls.Add(DTPStart)
        Controls.Add(LblDateRange)
        Controls.Add(LblExportReportForm)
        FormBorderStyle = FormBorderStyle.None
        Name = "SAInventoryExport"
        StartPosition = FormStartPosition.CenterScreen
        Text = "SAInventoryExport"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnCancel As ButtonRounded
    Friend WithEvents btnExport As ButtonRounded
    Friend WithEvents lblEndDate As Label
    Friend WithEvents lblStartDate As Label
    Friend WithEvents DTPEnd As DateTimePicker
    Friend WithEvents DTPStart As DateTimePicker
    Friend WithEvents LblDateRange As Label
    Friend WithEvents LblExportReportForm As Label
    Friend WithEvents cbExportFormat As ComboBox
    Friend WithEvents LblExportFormat As Label
    Friend WithEvents cbTimePeriod As ComboBox
    Friend WithEvents LblTimePeriod As Label
End Class