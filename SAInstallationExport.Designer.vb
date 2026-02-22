<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SAInstallationExport
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
        btnCancel = New ButtonRounded()
        btnExport = New ButtonRounded()
        lblEndDate = New Label()
        lblStartDate = New Label()
        cbTimePeriod = New ComboBox()
        LblTimePeriod = New Label()
        DTPEnd = New DateTimePicker()
        DTPStart = New DateTimePicker()
        LblDateRange = New Label()
        LblExportReportForm = New Label()
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
        btnCancel.Location = New Point(295, 262)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(83, 36)
        btnCancel.TabIndex = 109
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
        btnExport.Location = New Point(405, 262)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(83, 36)
        btnExport.TabIndex = 108
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
        lblEndDate.Location = New Point(158, 188)
        lblEndDate.Name = "lblEndDate"
        lblEndDate.Size = New Size(42, 18)
        lblEndDate.TabIndex = 107
        lblEndDate.Text = "End:"
        ' 
        ' lblStartDate
        ' 
        lblStartDate.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblStartDate.AutoSize = True
        lblStartDate.BackColor = Color.Transparent
        lblStartDate.Font = New Font("Verdana", 11F)
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
        cbTimePeriod.Font = New Font("Segoe UI", 12F)
        cbTimePeriod.FormattingEnabled = True
        cbTimePeriod.Items.AddRange(New Object() {"Custom", "Weekly", "Monthly", "Quarterly", "Yearly"})
        cbTimePeriod.Location = New Point(158, 80)
        cbTimePeriod.Name = "cbTimePeriod"
        cbTimePeriod.Size = New Size(330, 29)
        cbTimePeriod.TabIndex = 105
        ' 
        ' LblTimePeriod
        ' 
        LblTimePeriod.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblTimePeriod.AutoSize = True
        LblTimePeriod.BackColor = Color.Transparent
        LblTimePeriod.Font = New Font("Verdana", 11F)
        LblTimePeriod.Location = New Point(31, 85)
        LblTimePeriod.Name = "LblTimePeriod"
        LblTimePeriod.Size = New Size(95, 18)
        LblTimePeriod.TabIndex = 104
        LblTimePeriod.Text = "Time Period"
        ' 
        ' DTPEnd
        ' 
        DTPEnd.Font = New Font("Segoe UI", 12F)
        DTPEnd.Format = DateTimePickerFormat.Custom
        DTPEnd.Location = New Point(216, 180)
        DTPEnd.Name = "DTPEnd"
        DTPEnd.Size = New Size(272, 29)
        DTPEnd.TabIndex = 103
        ' 
        ' DTPStart
        ' 
        DTPStart.Font = New Font("Segoe UI", 12F)
        DTPStart.Format = DateTimePickerFormat.Custom
        DTPStart.Location = New Point(216, 145)
        DTPStart.Name = "DTPStart"
        DTPStart.Size = New Size(272, 29)
        DTPStart.TabIndex = 102
        ' 
        ' LblDateRange
        ' 
        LblDateRange.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblDateRange.AutoSize = True
        LblDateRange.BackColor = Color.Transparent
        LblDateRange.Font = New Font("Verdana", 11F)
        LblDateRange.Location = New Point(31, 153)
        LblDateRange.Name = "LblDateRange"
        LblDateRange.Size = New Size(94, 18)
        LblDateRange.TabIndex = 99
        LblDateRange.Text = "Date Range"
        ' 
        ' LblExportReportForm
        ' 
        LblExportReportForm.AutoSize = True
        LblExportReportForm.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblExportReportForm.Location = New Point(31, 34)
        LblExportReportForm.Name = "LblExportReportForm"
        LblExportReportForm.Size = New Size(229, 25)
        LblExportReportForm.TabIndex = 98
        LblExportReportForm.Text = "Installation Export Form"
        ' 
        ' SAInstallationExport
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(519, 339)
        Controls.Add(btnCancel)
        Controls.Add(btnExport)
        Controls.Add(lblEndDate)
        Controls.Add(lblStartDate)
        Controls.Add(cbTimePeriod)
        Controls.Add(LblTimePeriod)
        Controls.Add(DTPEnd)
        Controls.Add(DTPStart)
        Controls.Add(LblDateRange)
        Controls.Add(LblExportReportForm)
        FormBorderStyle = FormBorderStyle.None
        Name = "SAInstallationExport"
        StartPosition = FormStartPosition.CenterScreen
        Text = "SAInstallationExport"
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
    Friend WithEvents LblDateRange As Label
    Friend WithEvents LblExportReportForm As Label
End Class
