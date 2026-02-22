<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditInfo
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
        EditLbl = New Label()
        Line3 = New Label()
        Panel1 = New Panel()
        EditFNLbl = New Label()
        EditLNLbl = New Label()
        EditPhoneLbl = New Label()
        EditEmailLbl = New Label()
        EditPassLbl = New Label()
        FNTxtBox = New TextBox()
        LNTxtBox = New TextBox()
        PhoneTxtBox = New TextBox()
        EmailTxtBox = New TextBox()
        CancelBtn = New ButtonRounded()
        UpdateBtn = New ButtonRounded()
        ChangePassBtn = New Button()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' EditLbl
        ' 
        EditLbl.AutoSize = True
        EditLbl.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        EditLbl.Location = New Point(12, 9)
        EditLbl.Name = "EditLbl"
        EditLbl.Size = New Size(206, 21)
        EditLbl.TabIndex = 2
        EditLbl.Text = "Edit Personal Information"
        EditLbl.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Line3
        ' 
        Line3.AutoSize = True
        Line3.Location = New Point(-3, 28)
        Line3.Name = "Line3"
        Line3.Size = New Size(517, 15)
        Line3.TabIndex = 4
        Line3.Text = "______________________________________________________________________________________________________"
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Line3)
        Panel1.Controls.Add(EditLbl)
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(509, 43)
        Panel1.TabIndex = 5
        ' 
        ' EditFNLbl
        ' 
        EditFNLbl.AutoSize = True
        EditFNLbl.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        EditFNLbl.Location = New Point(12, 55)
        EditFNLbl.Name = "EditFNLbl"
        EditFNLbl.Size = New Size(75, 17)
        EditFNLbl.TabIndex = 6
        EditFNLbl.Text = "First Name"
        EditFNLbl.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' EditLNLbl
        ' 
        EditLNLbl.AutoSize = True
        EditLNLbl.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        EditLNLbl.Location = New Point(12, 89)
        EditLNLbl.Name = "EditLNLbl"
        EditLNLbl.Size = New Size(73, 17)
        EditLNLbl.TabIndex = 7
        EditLNLbl.Text = "Last Name"
        EditLNLbl.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' EditPhoneLbl
        ' 
        EditPhoneLbl.AutoSize = True
        EditPhoneLbl.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        EditPhoneLbl.Location = New Point(12, 124)
        EditPhoneLbl.Name = "EditPhoneLbl"
        EditPhoneLbl.Size = New Size(47, 17)
        EditPhoneLbl.TabIndex = 8
        EditPhoneLbl.Text = "Phone"
        EditPhoneLbl.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' EditEmailLbl
        ' 
        EditEmailLbl.AutoSize = True
        EditEmailLbl.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        EditEmailLbl.Location = New Point(12, 157)
        EditEmailLbl.Name = "EditEmailLbl"
        EditEmailLbl.Size = New Size(95, 17)
        EditEmailLbl.TabIndex = 9
        EditEmailLbl.Text = "Email Address"
        EditEmailLbl.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' EditPassLbl
        ' 
        EditPassLbl.AutoSize = True
        EditPassLbl.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        EditPassLbl.Location = New Point(12, 192)
        EditPassLbl.Name = "EditPassLbl"
        EditPassLbl.Size = New Size(66, 17)
        EditPassLbl.TabIndex = 10
        EditPassLbl.Text = "Password"
        EditPassLbl.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' FNTxtBox
        ' 
        FNTxtBox.Location = New Point(125, 51)
        FNTxtBox.Name = "FNTxtBox"
        FNTxtBox.Size = New Size(214, 23)
        FNTxtBox.TabIndex = 11
        ' 
        ' LNTxtBox
        ' 
        LNTxtBox.Location = New Point(125, 88)
        LNTxtBox.Name = "LNTxtBox"
        LNTxtBox.Size = New Size(214, 23)
        LNTxtBox.TabIndex = 12
        ' 
        ' PhoneTxtBox
        ' 
        PhoneTxtBox.Location = New Point(125, 123)
        PhoneTxtBox.Name = "PhoneTxtBox"
        PhoneTxtBox.Size = New Size(214, 23)
        PhoneTxtBox.TabIndex = 13
        ' 
        ' EmailTxtBox
        ' 
        EmailTxtBox.Location = New Point(125, 157)
        EmailTxtBox.Name = "EmailTxtBox"
        EmailTxtBox.Size = New Size(214, 23)
        EmailTxtBox.TabIndex = 14
        ' 
        ' CancelBtn
        ' 
        CancelBtn.BackColor = Color.Red
        CancelBtn.DialogResult = DialogResult.Cancel
        CancelBtn.FlatAppearance.BorderSize = 0
        CancelBtn.FlatStyle = FlatStyle.Flat
        CancelBtn.ForeColor = Color.White
        CancelBtn.Location = New Point(157, 220)
        CancelBtn.Name = "CancelBtn"
        CancelBtn.Size = New Size(88, 31)
        CancelBtn.TabIndex = 16
        CancelBtn.Text = "Cancel"
        CancelBtn.UseVisualStyleBackColor = False
        ' 
        ' UpdateBtn
        ' 
        UpdateBtn.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        UpdateBtn.DialogResult = DialogResult.OK
        UpdateBtn.FlatAppearance.BorderSize = 0
        UpdateBtn.FlatStyle = FlatStyle.Flat
        UpdateBtn.ForeColor = Color.White
        UpdateBtn.Location = New Point(251, 220)
        UpdateBtn.Name = "UpdateBtn"
        UpdateBtn.Size = New Size(88, 31)
        UpdateBtn.TabIndex = 17
        UpdateBtn.Text = "Update"
        UpdateBtn.UseVisualStyleBackColor = False
        ' 
        ' ChangePassBtn
        ' 
        ChangePassBtn.FlatAppearance.BorderSize = 0
        ChangePassBtn.FlatStyle = FlatStyle.Flat
        ChangePassBtn.Font = New Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        ChangePassBtn.ForeColor = SystemColors.Highlight
        ChangePassBtn.Location = New Point(119, 191)
        ChangePassBtn.Name = "ChangePassBtn"
        ChangePassBtn.Size = New Size(111, 23)
        ChangePassBtn.TabIndex = 18
        ChangePassBtn.Text = "Change Password"
        ChangePassBtn.UseVisualStyleBackColor = True
        ' 
        ' EditInfo
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        ClientSize = New Size(373, 263)
        Controls.Add(ChangePassBtn)
        Controls.Add(UpdateBtn)
        Controls.Add(CancelBtn)
        Controls.Add(EmailTxtBox)
        Controls.Add(PhoneTxtBox)
        Controls.Add(LNTxtBox)
        Controls.Add(FNTxtBox)
        Controls.Add(EditPassLbl)
        Controls.Add(EditEmailLbl)
        Controls.Add(EditPhoneLbl)
        Controls.Add(EditLNLbl)
        Controls.Add(EditFNLbl)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "EditInfo"
        Text = "EditInfo"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents EditLbl As Label
    Friend WithEvents Line3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents EditFNLbl As Label
    Friend WithEvents EditLNLbl As Label
    Friend WithEvents EditPhoneLbl As Label
    Friend WithEvents EditEmailLbl As Label
    Friend WithEvents EditPassLbl As Label
    Friend WithEvents FNTxtBox As TextBox
    Friend WithEvents LNTxtBox As TextBox
    Friend WithEvents PhoneTxtBox As TextBox
    Friend WithEvents EmailTxtBox As TextBox
    Friend WithEvents CancelBtn As ButtonRounded
    Friend WithEvents UpdateBtn As ButtonRounded
    Friend WithEvents ChangePassBtn As Button
End Class

