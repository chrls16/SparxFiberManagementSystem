<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogOutConfirmation
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
        lblConfirm = New Label()
        LblAsk = New Label()
        btnCancel = New ButtonRounded()
        BtnOk = New ButtonRounded()
        SuspendLayout()
        ' 
        ' lblConfirm
        ' 
        lblConfirm.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblConfirm.Font = New Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblConfirm.Location = New Point(1, 38)
        lblConfirm.Name = "lblConfirm"
        lblConfirm.Size = New Size(251, 25)
        lblConfirm.TabIndex = 2
        lblConfirm.Text = "Confirm Logout?"
        lblConfirm.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblAsk
        ' 
        LblAsk.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LblAsk.Font = New Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblAsk.Location = New Point(1, 77)
        LblAsk.Name = "LblAsk"
        LblAsk.Size = New Size(383, 25)
        LblAsk.TabIndex = 3
        LblAsk.Text = "Are you sure you want logout?"
        LblAsk.TextAlign = ContentAlignment.MiddleCenter
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
        btnCancel.Location = New Point(152, 167)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(111, 28)
        btnCancel.TabIndex = 39
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' BtnOk
        ' 
        BtnOk.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        BtnOk.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        BtnOk.CornerRadius = 8
        BtnOk.Cursor = Cursors.Hand
        BtnOk.DialogResult = DialogResult.OK
        BtnOk.FlatAppearance.BorderSize = 0
        BtnOk.FlatStyle = FlatStyle.Flat
        BtnOk.Font = New Font("Segoe UI", 12F)
        BtnOk.ForeColor = Color.White
        BtnOk.ImageAlign = ContentAlignment.MiddleLeft
        BtnOk.Location = New Point(273, 167)
        BtnOk.Name = "BtnOk"
        BtnOk.Size = New Size(111, 28)
        BtnOk.TabIndex = 40
        BtnOk.Text = "Ok"
        BtnOk.UseVisualStyleBackColor = False
        ' 
        ' LogOutConfirmation
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(396, 227)
        Controls.Add(BtnOk)
        Controls.Add(btnCancel)
        Controls.Add(LblAsk)
        Controls.Add(lblConfirm)
        FormBorderStyle = FormBorderStyle.None
        Name = "LogOutConfirmation"
        StartPosition = FormStartPosition.CenterScreen
        Text = "LogOutConfirmation"
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblConfirm As Label
    Friend WithEvents LblAsk As Label
    Friend WithEvents btnCancel As ButtonRounded
    Friend WithEvents BtnOk As ButtonRounded
End Class
