<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChangePassword
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
        Panel1 = New Panel()
        TitleLabel = New Label()
        CurrentPasswordLabel = New Label()
        CurrentPasswordTxt = New TextBox()
        NewPasswordLabel = New Label()
        NewPasswordTxt = New TextBox()
        ConfirmPasswordLabel = New Label()
        ConfirmPasswordTxt = New TextBox()
        SaveBtn = New Button()
        CancelBtn = New Button()
        PasswordRequirementsLabel = New Label()
        ShowCurrentPasswordCheck = New CheckBox()
        ShowNewPasswordCheck = New CheckBox()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        Panel1.Controls.Add(TitleLabel)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(450, 50)
        Panel1.TabIndex = 0
        ' 
        ' TitleLabel
        ' 
        TitleLabel.AutoSize = True
        TitleLabel.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TitleLabel.ForeColor = Color.White
        TitleLabel.Location = New Point(12, 14)
        TitleLabel.Name = "TitleLabel"
        TitleLabel.Size = New Size(144, 21)
        TitleLabel.TabIndex = 0
        TitleLabel.Text = "Change Password"
        ' 
        ' CurrentPasswordLabel
        ' 
        CurrentPasswordLabel.AutoSize = True
        CurrentPasswordLabel.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CurrentPasswordLabel.Location = New Point(30, 80)
        CurrentPasswordLabel.Name = "CurrentPasswordLabel"
        CurrentPasswordLabel.Size = New Size(111, 17)
        CurrentPasswordLabel.TabIndex = 1
        CurrentPasswordLabel.Text = "Current Password"
        ' 
        ' CurrentPasswordTxt
        ' 
        CurrentPasswordTxt.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CurrentPasswordTxt.Location = New Point(30, 100)
        CurrentPasswordTxt.Name = "CurrentPasswordTxt"
        CurrentPasswordTxt.PasswordChar = "•"c
        CurrentPasswordTxt.Size = New Size(300, 25)
        CurrentPasswordTxt.TabIndex = 2
        ' 
        ' NewPasswordLabel
        ' 
        NewPasswordLabel.AutoSize = True
        NewPasswordLabel.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        NewPasswordLabel.Location = New Point(30, 140)
        NewPasswordLabel.Name = "NewPasswordLabel"
        NewPasswordLabel.Size = New Size(94, 17)
        NewPasswordLabel.TabIndex = 3
        NewPasswordLabel.Text = "New Password"
        ' 
        ' NewPasswordTxt
        ' 
        NewPasswordTxt.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        NewPasswordTxt.Location = New Point(30, 160)
        NewPasswordTxt.Name = "NewPasswordTxt"
        NewPasswordTxt.PasswordChar = "•"c
        NewPasswordTxt.Size = New Size(300, 25)
        NewPasswordTxt.TabIndex = 4
        ' 
        ' ConfirmPasswordLabel
        ' 
        ConfirmPasswordLabel.AutoSize = True
        ConfirmPasswordLabel.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ConfirmPasswordLabel.Location = New Point(30, 200)
        ConfirmPasswordLabel.Name = "ConfirmPasswordLabel"
        ConfirmPasswordLabel.Size = New Size(114, 17)
        ConfirmPasswordLabel.TabIndex = 5
        ConfirmPasswordLabel.Text = "Confirm Password"
        ' 
        ' ConfirmPasswordTxt
        ' 
        ConfirmPasswordTxt.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ConfirmPasswordTxt.Location = New Point(30, 220)
        ConfirmPasswordTxt.Name = "ConfirmPasswordTxt"
        ConfirmPasswordTxt.PasswordChar = "•"c
        ConfirmPasswordTxt.Size = New Size(300, 25)
        ConfirmPasswordTxt.TabIndex = 6
        ' 
        ' SaveBtn
        ' 
        SaveBtn.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        SaveBtn.FlatAppearance.BorderSize = 0
        SaveBtn.FlatStyle = FlatStyle.Flat
        SaveBtn.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        SaveBtn.ForeColor = Color.White
        SaveBtn.Location = New Point(250, 290)
        SaveBtn.Name = "SaveBtn"
        SaveBtn.Size = New Size(90, 35)
        SaveBtn.TabIndex = 9
        SaveBtn.Text = "Save"
        SaveBtn.UseVisualStyleBackColor = False
        ' 
        ' CancelBtn
        ' 
        CancelBtn.BackColor = Color.Gray
        CancelBtn.FlatAppearance.BorderSize = 0
        CancelBtn.FlatStyle = FlatStyle.Flat
        CancelBtn.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CancelBtn.ForeColor = Color.White
        CancelBtn.Location = New Point(150, 290)
        CancelBtn.Name = "CancelBtn"
        CancelBtn.Size = New Size(90, 35)
        CancelBtn.TabIndex = 8
        CancelBtn.Text = "Cancel"
        CancelBtn.UseVisualStyleBackColor = False
        ' 
        ' PasswordRequirementsLabel
        ' 
        PasswordRequirementsLabel.AutoSize = True
        PasswordRequirementsLabel.Font = New Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        PasswordRequirementsLabel.ForeColor = SystemColors.ControlDarkDark
        PasswordRequirementsLabel.Location = New Point(30, 185)
        PasswordRequirementsLabel.Name = "PasswordRequirementsLabel"
        PasswordRequirementsLabel.Size = New Size(214, 13)
        PasswordRequirementsLabel.TabIndex = 10
        PasswordRequirementsLabel.Text = "Password must be at least 6 characters long"
        ' 
        ' ShowCurrentPasswordCheck
        ' 
        ShowCurrentPasswordCheck.AutoSize = True
        ShowCurrentPasswordCheck.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ShowCurrentPasswordCheck.Location = New Point(336, 104)
        ShowCurrentPasswordCheck.Name = "ShowCurrentPasswordCheck"
        ShowCurrentPasswordCheck.Size = New Size(55, 17)
        ShowCurrentPasswordCheck.TabIndex = 3
        ShowCurrentPasswordCheck.Text = "Show"
        ShowCurrentPasswordCheck.UseVisualStyleBackColor = True
        ' 
        ' ShowNewPasswordCheck
        ' 
        ShowNewPasswordCheck.AutoSize = True
        ShowNewPasswordCheck.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ShowNewPasswordCheck.Location = New Point(336, 164)
        ShowNewPasswordCheck.Name = "ShowNewPasswordCheck"
        ShowNewPasswordCheck.Size = New Size(55, 17)
        ShowNewPasswordCheck.TabIndex = 5
        ShowNewPasswordCheck.Text = "Show"
        ShowNewPasswordCheck.UseVisualStyleBackColor = True
        ' 
        ' ChangePassword
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        ClientSize = New Size(450, 340)
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
        Name = "ChangePassword"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Change Password"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents TitleLabel As Label
    Friend WithEvents CurrentPasswordLabel As Label
    Friend WithEvents CurrentPasswordTxt As TextBox
    Friend WithEvents NewPasswordLabel As Label
    Friend WithEvents NewPasswordTxt As TextBox
    Friend WithEvents ConfirmPasswordLabel As Label
    Friend WithEvents ConfirmPasswordTxt As TextBox
    Friend WithEvents SaveBtn As Button
    Friend WithEvents CancelBtn As Button
    Friend WithEvents PasswordRequirementsLabel As Label
    Friend WithEvents ShowCurrentPasswordCheck As CheckBox
    Friend WithEvents ShowNewPasswordCheck As CheckBox
End Class