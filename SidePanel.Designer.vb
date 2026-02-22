<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SidePanel
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SidePanel))
        MenuPanel = New Panel()
        Panel1 = New Panel()
        Label1 = New Label()
        Button2 = New Button()
        Line2 = New Label()
        HistoryButton = New Button()
        ProfileButton = New Button()
        Line = New Label()
        SparxLogo = New PictureBox()
        MainPanel = New Panel()
        HeaderPanel = New Panel()
        Line3 = New Label()
        HeaderLbl = New Label()
        ContentPanel = New Panel()
        MenuPanel.SuspendLayout()
        Panel1.SuspendLayout()
        CType(SparxLogo, ComponentModel.ISupportInitialize).BeginInit()
        HeaderPanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuPanel
        ' 
        MenuPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        MenuPanel.BackColor = Color.FromArgb(CByte(29), CByte(41), CByte(61))
        MenuPanel.Controls.Add(Panel1)
        MenuPanel.Controls.Add(Line2)
        MenuPanel.Controls.Add(HistoryButton)
        MenuPanel.Controls.Add(ProfileButton)
        MenuPanel.Controls.Add(Line)
        MenuPanel.Controls.Add(SparxLogo)
        MenuPanel.Location = New Point(0, 0)
        MenuPanel.Name = "MenuPanel"
        MenuPanel.Size = New Size(240, 1011)
        MenuPanel.TabIndex = 1
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Button2)
        Panel1.Dock = DockStyle.Bottom
        Panel1.Location = New Point(0, 946)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(240, 65)
        Panel1.TabIndex = 17
        ' 
        ' Label1
        ' 
        Label1.AllowDrop = True
        Label1.AutoSize = True
        Label1.Image = CType(resources.GetObject("Label1.Image"), Image)
        Label1.Location = New Point(188, 31)
        Label1.Name = "Label1"
        Label1.Size = New Size(34, 15)
        Label1.TabIndex = 15
        Label1.Text = "         "
        ' 
        ' Button2
        ' 
        Button2.AllowDrop = True
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.ForeColor = Color.Transparent
        Button2.Image = CType(resources.GetObject("Button2.Image"), Image)
        Button2.ImageAlign = ContentAlignment.MiddleLeft
        Button2.Location = New Point(-9, 19)
        Button2.Margin = New Padding(3, 2, 3, 2)
        Button2.Name = "Button2"
        Button2.Padding = New Padding(18, 0, 0, 0)
        Button2.Size = New Size(231, 39)
        Button2.TabIndex = 14
        Button2.Text = "a@gmail.com"
        Button2.UseCompatibleTextRendering = True
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Line2
        ' 
        Line2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Line2.AutoSize = True
        Line2.ForeColor = Color.FromArgb(CByte(42), CByte(53), CByte(72))
        Line2.Location = New Point(-3, 925)
        Line2.Name = "Line2"
        Line2.Size = New Size(247, 15)
        Line2.TabIndex = 5
        Line2.Text = "________________________________________________"
        ' 
        ' HistoryButton
        ' 
        HistoryButton.FlatAppearance.BorderSize = 0
        HistoryButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(29), CByte(41), CByte(61))
        HistoryButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(24), CByte(93), CByte(252))
        HistoryButton.FlatStyle = FlatStyle.Flat
        HistoryButton.ForeColor = Color.Transparent
        HistoryButton.Image = CType(resources.GetObject("HistoryButton.Image"), Image)
        HistoryButton.ImageAlign = ContentAlignment.MiddleLeft
        HistoryButton.Location = New Point(0, 122)
        HistoryButton.Name = "HistoryButton"
        HistoryButton.Padding = New Padding(18, 0, 0, 0)
        HistoryButton.Size = New Size(240, 39)
        HistoryButton.TabIndex = 4
        HistoryButton.Text = "           History"
        HistoryButton.TextAlign = ContentAlignment.MiddleLeft
        HistoryButton.UseVisualStyleBackColor = True
        ' 
        ' ProfileButton
        ' 
        ProfileButton.FlatAppearance.BorderSize = 0
        ProfileButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(29), CByte(41), CByte(61))
        ProfileButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(24), CByte(93), CByte(252))
        ProfileButton.FlatStyle = FlatStyle.Flat
        ProfileButton.ForeColor = Color.Transparent
        ProfileButton.Image = CType(resources.GetObject("ProfileButton.Image"), Image)
        ProfileButton.ImageAlign = ContentAlignment.MiddleLeft
        ProfileButton.Location = New Point(0, 77)
        ProfileButton.Name = "ProfileButton"
        ProfileButton.Padding = New Padding(18, 0, 0, 0)
        ProfileButton.Size = New Size(240, 39)
        ProfileButton.TabIndex = 3
        ProfileButton.Text = "           Profile"
        ProfileButton.TextAlign = ContentAlignment.MiddleLeft
        ProfileButton.UseVisualStyleBackColor = True
        ' 
        ' Line
        ' 
        Line.AutoSize = True
        Line.ForeColor = Color.FromArgb(CByte(42), CByte(53), CByte(72))
        Line.Location = New Point(-3, 59)
        Line.Name = "Line"
        Line.Size = New Size(247, 15)
        Line.TabIndex = 2
        Line.Text = "________________________________________________"
        ' 
        ' SparxLogo
        ' 
        SparxLogo.Image = CType(resources.GetObject("SparxLogo.Image"), Image)
        SparxLogo.Location = New Point(41, 12)
        SparxLogo.Name = "SparxLogo"
        SparxLogo.Size = New Size(117, 55)
        SparxLogo.SizeMode = PictureBoxSizeMode.Zoom
        SparxLogo.TabIndex = 2
        SparxLogo.TabStop = False
        ' 
        ' MainPanel
        ' 
        MainPanel.Location = New Point(0, 67)
        MainPanel.Name = "MainPanel"
        MainPanel.Size = New Size(1130, 681)
        MainPanel.TabIndex = 2
        ' 
        ' HeaderPanel
        ' 
        HeaderPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        HeaderPanel.BackColor = Color.White
        HeaderPanel.Controls.Add(MainPanel)
        HeaderPanel.Controls.Add(Line3)
        HeaderPanel.Controls.Add(HeaderLbl)
        HeaderPanel.ForeColor = Color.Black
        HeaderPanel.Location = New Point(240, 0)
        HeaderPanel.Name = "HeaderPanel"
        HeaderPanel.Size = New Size(1235, 67)
        HeaderPanel.TabIndex = 2
        ' 
        ' Line3
        ' 
        Line3.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        Line3.AutoSize = True
        Line3.Location = New Point(-4, 52)
        Line3.Name = "Line3"
        Line3.Size = New Size(3487, 15)
        Line3.TabIndex = 3
        Line3.Text = resources.GetString("Line3.Text")
        ' 
        ' HeaderLbl
        ' 
        HeaderLbl.AutoSize = True
        HeaderLbl.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        HeaderLbl.Location = New Point(26, 16)
        HeaderLbl.Name = "HeaderLbl"
        HeaderLbl.Size = New Size(88, 18)
        HeaderLbl.TabIndex = 0
        HeaderLbl.Text = "My Profile"
        HeaderLbl.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ContentPanel
        ' 
        ContentPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ContentPanel.AutoScroll = True
        ContentPanel.Location = New Point(240, 67)
        ContentPanel.Name = "ContentPanel"
        ContentPanel.Size = New Size(1402, 1269)
        ContentPanel.TabIndex = 3
        ' 
        ' SidePanel
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1386, 1009)
        Controls.Add(ContentPanel)
        Controls.Add(HeaderPanel)
        Controls.Add(MenuPanel)
        FormBorderStyle = FormBorderStyle.None
        Name = "SidePanel"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        WindowState = FormWindowState.Maximized
        MenuPanel.ResumeLayout(False)
        MenuPanel.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(SparxLogo, ComponentModel.ISupportInitialize).EndInit()
        HeaderPanel.ResumeLayout(False)
        HeaderPanel.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents MenuPanel As Panel
    Friend WithEvents SparxLogo As PictureBox
    Friend WithEvents Line As Label
    Friend WithEvents HistoryButton As Button
    Friend WithEvents ProfileButton As Button
    Friend WithEvents MainPanel As Panel
    Friend WithEvents Line2 As Label
    Friend WithEvents HeaderPanel As Panel
    Friend WithEvents ContentPanel As Panel
    Friend WithEvents Line3 As Label
    Friend WithEvents HeaderLbl As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button

End Class