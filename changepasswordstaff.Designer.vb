<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangePasswordStaff
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
        Panel1 = New Panel()
        TitleLabel = New Label()
        Label1 = New Label()
        ShowNewPasswordCheck = New CheckBox()
        ShowCurrentPasswordCheck = New CheckBox()
        PasswordRequirementsLabel = New Label()
        CancelBtn = New Button()
        SaveBtn = New Button()
        ConfirmPasswordTxt = New TextBox()
        ConfirmPasswordLabel = New Label()
        NewPasswordTxt = New TextBox()
        NewPasswordLabel = New Label()
        CurrentPasswordTxt = New TextBox()
        CurrentPasswordLabel = New Label()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        Panel1.Controls.Add(TitleLabel)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(-1, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(450, 50)
        Panel1.TabIndex = 0
        ' 
        ' TitleLabel
        ' 
        TitleLabel.AutoSize = True
        TitleLabel.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        TitleLabel.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TitleLabel.ForeColor = Color.White
        TitleLabel.Location = New Point(35, 15)
        TitleLabel.Name = "TitleLabel"
        TitleLabel.Size = New Size(184, 21)
        TitleLabel.TabIndex = 11
        TitleLabel.Text = "Staff Change Password"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(35, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(0, 15)
        Label1.TabIndex = 0
        ' 
        ' ShowNewPasswordCheck
        ' 
        ShowNewPasswordCheck.AutoSize = True
        ShowNewPasswordCheck.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ShowNewPasswordCheck.Location = New Point(352, 163)
        ShowNewPasswordCheck.Name = "ShowNewPasswordCheck"
        ShowNewPasswordCheck.Size = New Size(55, 17)
        ShowNewPasswordCheck.TabIndex = 17
        ShowNewPasswordCheck.Text = "Show"
        ShowNewPasswordCheck.UseVisualStyleBackColor = True
        ' 
        ' ShowCurrentPasswordCheck
        ' 
        ShowCurrentPasswordCheck.AutoSize = True
        ShowCurrentPasswordCheck.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ShowCurrentPasswordCheck.Location = New Point(352, 103)
        ShowCurrentPasswordCheck.Name = "ShowCurrentPasswordCheck"
        ShowCurrentPasswordCheck.Size = New Size(55, 17)
        ShowCurrentPasswordCheck.TabIndex = 14
        ShowCurrentPasswordCheck.Text = "Show"
        ShowCurrentPasswordCheck.UseVisualStyleBackColor = True
        ' 
        ' PasswordRequirementsLabel
        ' 
        PasswordRequirementsLabel.AutoSize = True
        PasswordRequirementsLabel.Font = New Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        PasswordRequirementsLabel.ForeColor = SystemColors.ControlDarkDark
        PasswordRequirementsLabel.Location = New Point(46, 184)
        PasswordRequirementsLabel.Name = "PasswordRequirementsLabel"
        PasswordRequirementsLabel.Size = New Size(214, 13)
        PasswordRequirementsLabel.TabIndex = 22
        PasswordRequirementsLabel.Text = "Password must be at least 6 characters long"
        ' 
        ' CancelBtn
        ' 
        CancelBtn.BackColor = Color.Gray
        CancelBtn.FlatAppearance.BorderSize = 0
        CancelBtn.FlatStyle = FlatStyle.Flat
        CancelBtn.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CancelBtn.ForeColor = Color.White
        CancelBtn.Location = New Point(202, 281)
        CancelBtn.Name = "CancelBtn"
        CancelBtn.Size = New Size(90, 35)
        CancelBtn.TabIndex = 20
        CancelBtn.Text = "Cancel"
        CancelBtn.UseVisualStyleBackColor = False
        ' 
        ' SaveBtn
        ' 
        SaveBtn.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        SaveBtn.FlatAppearance.BorderSize = 0
        SaveBtn.FlatStyle = FlatStyle.Flat
        SaveBtn.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        SaveBtn.ForeColor = Color.White
        SaveBtn.Location = New Point(302, 281)
        SaveBtn.Name = "SaveBtn"
        SaveBtn.Size = New Size(90, 35)
        SaveBtn.TabIndex = 21
        SaveBtn.Text = "Save"
        SaveBtn.UseVisualStyleBackColor = False
        ' 
        ' ConfirmPasswordTxt
        ' 
        ConfirmPasswordTxt.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ConfirmPasswordTxt.Location = New Point(46, 219)
        ConfirmPasswordTxt.Name = "ConfirmPasswordTxt"
        ConfirmPasswordTxt.Size = New Size(300, 25)
        ConfirmPasswordTxt.TabIndex = 19
        ' 
        ' ConfirmPasswordLabel
        ' 
        ConfirmPasswordLabel.AutoSize = True
        ConfirmPasswordLabel.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ConfirmPasswordLabel.Location = New Point(46, 199)
        ConfirmPasswordLabel.Name = "ConfirmPasswordLabel"
        ConfirmPasswordLabel.Size = New Size(114, 17)
        ConfirmPasswordLabel.TabIndex = 18
        ConfirmPasswordLabel.Text = "Confirm Password"
        ' 
        ' NewPasswordTxt
        ' 
        NewPasswordTxt.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        NewPasswordTxt.Location = New Point(46, 159)
        NewPasswordTxt.Name = "NewPasswordTxt"
        NewPasswordTxt.Size = New Size(300, 25)
        NewPasswordTxt.TabIndex = 16
        ' 
        ' NewPasswordLabel
        ' 
        NewPasswordLabel.AutoSize = True
        NewPasswordLabel.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        NewPasswordLabel.Location = New Point(46, 139)
        NewPasswordLabel.Name = "NewPasswordLabel"
        NewPasswordLabel.Size = New Size(94, 17)
        NewPasswordLabel.TabIndex = 15
        NewPasswordLabel.Text = "New Password"
        ' 
        ' CurrentPasswordTxt
        ' 
        CurrentPasswordTxt.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CurrentPasswordTxt.Location = New Point(46, 99)
        CurrentPasswordTxt.Name = "CurrentPasswordTxt"
        CurrentPasswordTxt.Size = New Size(300, 25)
        CurrentPasswordTxt.TabIndex = 13
        ' 
        ' CurrentPasswordLabel
        ' 
        CurrentPasswordLabel.AutoSize = True
        CurrentPasswordLabel.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CurrentPasswordLabel.Location = New Point(46, 79)
        CurrentPasswordLabel.Name = "CurrentPasswordLabel"
        CurrentPasswordLabel.Size = New Size(111, 17)
        CurrentPasswordLabel.TabIndex = 12
        CurrentPasswordLabel.Text = "Current Password"
        ' 
        ' ChangePasswordStaff
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        ClientSize = New Size(434, 337)
        Controls.Add(ShowNewPasswordCheck)
        Controls.Add(ShowCurrentPasswordCheck)
        Controls.Add(PasswordRequirementsLabel)
        Controls.Add(CancelBtn)
        Controls.Add(SaveBtn)
        Controls.Add(ConfirmPasswordTxt)
        Controls.Add(ConfirmPasswordLabel)
        Controls.Add(NewPasswordTxt)
        Controls.Add(NewPasswordLabel)
        Controls.Add(CurrentPasswordTxt)
        Controls.Add(CurrentPasswordLabel)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MinimizeBox = False
        Name = "ChangePasswordStaff"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Staff Change Password"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TitleLabel As Label
    Friend WithEvents ShowNewPasswordCheck As CheckBox
    Friend WithEvents ShowCurrentPasswordCheck As CheckBox
    Friend WithEvents PasswordRequirementsLabel As Label
    Friend WithEvents CancelBtn As Button
    Friend WithEvents SaveBtn As Button
    Friend WithEvents ConfirmPasswordTxt As TextBox
    Friend WithEvents ConfirmPasswordLabel As Label
    Friend WithEvents NewPasswordTxt As TextBox
    Friend WithEvents NewPasswordLabel As Label
    Friend WithEvents CurrentPasswordTxt As TextBox
    Friend WithEvents CurrentPasswordLabel As Label
End Class
