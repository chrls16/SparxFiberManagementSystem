<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SASubscriberExport
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


    Private Sub InitializeComponent()
        btnCancel = New ButtonRounded()
        btnExport = New ButtonRounded()
        cbPlanType = New ComboBox()
        LblPlanType = New Label()
        LblExportReportForm = New Label()
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
        btnCancel.Location = New Point(295, 165)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(83, 36)
        btnCancel.TabIndex = 133
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
        btnExport.Location = New Point(405, 165)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(83, 36)
        btnExport.TabIndex = 132
        btnExport.Text = "Export"
        btnExport.UseVisualStyleBackColor = False
        ' 
        ' cbPlanType
        ' 
        cbPlanType.DropDownStyle = ComboBoxStyle.DropDownList
        cbPlanType.Font = New Font("Segoe UI", 12.0F)
        cbPlanType.FormattingEnabled = True
        cbPlanType.Items.AddRange(New Object() {"Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})
        cbPlanType.Location = New Point(158, 85)
        cbPlanType.MaxDropDownItems = 3
        cbPlanType.Name = "cbPlanType"
        cbPlanType.Size = New Size(330, 29)
        cbPlanType.TabIndex = 125
        ' 
        ' LblPlanType
        ' 
        LblPlanType.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblPlanType.AutoSize = True
        LblPlanType.BackColor = Color.Transparent
        LblPlanType.Font = New Font("Verdana", 11.0F)
        LblPlanType.Location = New Point(31, 90)
        LblPlanType.Name = "LblPlanType"
        LblPlanType.Size = New Size(78, 18)
        LblPlanType.TabIndex = 124
        LblPlanType.Text = "Plan Type"
        ' 
        ' LblExportReportForm
        ' 
        LblExportReportForm.AutoSize = True
        LblExportReportForm.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblExportReportForm.Location = New Point(31, 34)
        LblExportReportForm.Name = "LblExportReportForm"
        LblExportReportForm.Size = New Size(225, 25)
        LblExportReportForm.TabIndex = 122
        LblExportReportForm.Text = "Subscriber Export Form"
        ' 
        ' SASubscriberExport
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(519, 239)
        Controls.Add(btnCancel)
        Controls.Add(btnExport)
        Controls.Add(cbPlanType)
        Controls.Add(LblPlanType)
        Controls.Add(LblExportReportForm)
        FormBorderStyle = FormBorderStyle.None
        Name = "SASubscriberExport"
        Text = "SASubscriberExport"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents btnCancel As ButtonRounded
    Friend WithEvents btnExport As ButtonRounded
    Friend WithEvents cbPlanType As ComboBox
    Friend WithEvents LblPlanType As Label
    Friend WithEvents LblExportReportForm As Label
End Class
