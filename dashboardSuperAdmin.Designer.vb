<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dashboardSuperAdmin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dashboardSuperAdmin))
        pnlHeader = New Panel()
        PictureBox4 = New PictureBox()
        PictureBox1 = New PictureBox()
        overview = New Label()
        lblDashboardSuperAdmin = New Label()
        systemOnline = New Label()
        pnlMenu = New Panel()
        StaffBtn = New Button()
        Panel1 = New Panel()
        Label1 = New Label()
        Button1 = New Button()
        PlansBtn = New Button()
        HistoryBtn = New Button()
        NetworkMapBtn = New Button()
        BillingBtn = New Button()
        SubscriberBtn = New Button()
        PayrollBtn = New Button()
        InventoryBtn = New Button()
        ServiceBtn = New Button()
        InstallationBtn = New Button()
        SalesBtn = New Button()
        DashboardBtn = New Button()
        line = New Label()
        PictureBox2 = New PictureBox()
        Mainexchange = New Panel()
        pnlHeader.SuspendLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        pnlMenu.SuspendLayout()
        Panel1.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.White
        pnlHeader.Controls.Add(PictureBox4)
        pnlHeader.Controls.Add(PictureBox1)
        pnlHeader.Controls.Add(overview)
        pnlHeader.Controls.Add(lblDashboardSuperAdmin)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1386, 67)
        pnlHeader.TabIndex = 0
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Anchor = AnchorStyles.Top
        PictureBox4.Image = My.Resources.Resources.redDot
        PictureBox4.Location = New Point(1295, 22)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(12, 10)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 7
        PictureBox4.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top
        PictureBox1.Image = My.Resources.Resources.notificationBell
        PictureBox1.Location = New Point(1283, 22)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(24, 24)
        PictureBox1.TabIndex = 4
        PictureBox1.TabStop = False
        ' 
        ' overview
        ' 
        overview.AutoSize = True
        overview.ForeColor = SystemColors.ControlDarkDark
        overview.Location = New Point(26, 36)
        overview.Name = "overview"
        overview.Size = New Size(215, 15)
        overview.TabIndex = 2
        overview.Text = "Overview of Sparx Fiber Internet System"
        ' 
        ' lblDashboardSuperAdmin
        ' 
        lblDashboardSuperAdmin.AutoSize = True
        lblDashboardSuperAdmin.Font = New Font("Verdana", 12F)
        lblDashboardSuperAdmin.Location = New Point(26, 16)
        lblDashboardSuperAdmin.Name = "lblDashboardSuperAdmin"
        lblDashboardSuperAdmin.Size = New Size(95, 18)
        lblDashboardSuperAdmin.TabIndex = 0
        lblDashboardSuperAdmin.Text = "Dashboard"
        ' 
        ' systemOnline
        ' 
        systemOnline.AutoSize = True
        systemOnline.Font = New Font("Verdana", 9F)
        systemOnline.Location = New Point(26, 10)
        systemOnline.Name = "systemOnline"
        systemOnline.Size = New Size(97, 14)
        systemOnline.TabIndex = 0
        systemOnline.Text = "System Online"
        ' 
        ' pnlMenu
        ' 
        pnlMenu.BackColor = Color.FromArgb(CByte(29), CByte(41), CByte(61))
        pnlMenu.Controls.Add(StaffBtn)
        pnlMenu.Controls.Add(Panel1)
        pnlMenu.Controls.Add(PlansBtn)
        pnlMenu.Controls.Add(HistoryBtn)
        pnlMenu.Controls.Add(NetworkMapBtn)
        pnlMenu.Controls.Add(BillingBtn)
        pnlMenu.Controls.Add(SubscriberBtn)
        pnlMenu.Controls.Add(PayrollBtn)
        pnlMenu.Controls.Add(InventoryBtn)
        pnlMenu.Controls.Add(ServiceBtn)
        pnlMenu.Controls.Add(InstallationBtn)
        pnlMenu.Controls.Add(SalesBtn)
        pnlMenu.Controls.Add(DashboardBtn)
        pnlMenu.Controls.Add(line)
        pnlMenu.Controls.Add(PictureBox2)
        pnlMenu.Dock = DockStyle.Left
        pnlMenu.Location = New Point(0, 67)
        pnlMenu.Name = "pnlMenu"
        pnlMenu.Size = New Size(240, 942)
        pnlMenu.TabIndex = 1
        ' 
        ' StaffBtn
        ' 
        StaffBtn.AllowDrop = True
        StaffBtn.FlatAppearance.BorderSize = 0
        StaffBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(24), CByte(93), CByte(252))
        StaffBtn.FlatStyle = FlatStyle.Flat
        StaffBtn.ForeColor = Color.Transparent
        StaffBtn.Image = My.Resources.Resources.group
        StaffBtn.ImageAlign = ContentAlignment.MiddleLeft
        StaffBtn.Location = New Point(0, 557)
        StaffBtn.Margin = New Padding(3, 2, 3, 2)
        StaffBtn.Name = "StaffBtn"
        StaffBtn.Padding = New Padding(18, 0, 0, 0)
        StaffBtn.Size = New Size(240, 39)
        StaffBtn.TabIndex = 17
        StaffBtn.Text = "           Staff"
        StaffBtn.TextAlign = ContentAlignment.MiddleLeft
        StaffBtn.UseCompatibleTextRendering = True
        StaffBtn.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Button1)
        Panel1.Dock = DockStyle.Bottom
        Panel1.Location = New Point(0, 877)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(240, 65)
        Panel1.TabIndex = 16
        ' 
        ' Label1
        ' 
        Label1.AllowDrop = True
        Label1.AutoSize = True
        Label1.Image = CType(resources.GetObject("Label1.Image"), Image)
        Label1.Location = New Point(188, 26)
        Label1.Name = "Label1"
        Label1.Size = New Size(34, 15)
        Label1.TabIndex = 15
        Label1.Text = "         "
        ' 
        ' Button1
        ' 
        Button1.AllowDrop = True
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.ForeColor = Color.Transparent
        Button1.Image = CType(resources.GetObject("Button1.Image"), Image)
        Button1.ImageAlign = ContentAlignment.MiddleLeft
        Button1.Location = New Point(-9, 14)
        Button1.Margin = New Padding(3, 2, 3, 2)
        Button1.Name = "Button1"
        Button1.Padding = New Padding(18, 0, 0, 0)
        Button1.Size = New Size(231, 39)
        Button1.TabIndex = 14
        Button1.Text = "superadmin@gmail.com"
        Button1.UseCompatibleTextRendering = True
        Button1.UseVisualStyleBackColor = True
        ' 
        ' PlansBtn
        ' 
        PlansBtn.AllowDrop = True
        PlansBtn.FlatAppearance.BorderSize = 0
        PlansBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(24), CByte(93), CByte(252))
        PlansBtn.FlatStyle = FlatStyle.Flat
        PlansBtn.ForeColor = Color.Transparent
        PlansBtn.Image = My.Resources.Resources.plan
        PlansBtn.ImageAlign = ContentAlignment.MiddleLeft
        PlansBtn.Location = New Point(0, 514)
        PlansBtn.Margin = New Padding(3, 2, 3, 2)
        PlansBtn.Name = "PlansBtn"
        PlansBtn.Padding = New Padding(18, 0, 0, 0)
        PlansBtn.Size = New Size(240, 39)
        PlansBtn.TabIndex = 13
        PlansBtn.Text = "           Plans"
        PlansBtn.TextAlign = ContentAlignment.MiddleLeft
        PlansBtn.UseCompatibleTextRendering = True
        PlansBtn.UseVisualStyleBackColor = True
        ' 
        ' HistoryBtn
        ' 
        HistoryBtn.AllowDrop = True
        HistoryBtn.FlatAppearance.BorderSize = 0
        HistoryBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(24), CByte(93), CByte(252))
        HistoryBtn.FlatStyle = FlatStyle.Flat
        HistoryBtn.ForeColor = Color.Transparent
        HistoryBtn.Image = My.Resources.Resources.history
        HistoryBtn.ImageAlign = ContentAlignment.MiddleLeft
        HistoryBtn.Location = New Point(-3, 471)
        HistoryBtn.Margin = New Padding(3, 2, 3, 2)
        HistoryBtn.Name = "HistoryBtn"
        HistoryBtn.Padding = New Padding(18, 0, 0, 0)
        HistoryBtn.Size = New Size(240, 39)
        HistoryBtn.TabIndex = 12
        HistoryBtn.Text = "           History"
        HistoryBtn.TextAlign = ContentAlignment.MiddleLeft
        HistoryBtn.UseCompatibleTextRendering = True
        HistoryBtn.UseVisualStyleBackColor = True
        ' 
        ' NetworkMapBtn
        ' 
        NetworkMapBtn.AllowDrop = True
        NetworkMapBtn.FlatAppearance.BorderSize = 0
        NetworkMapBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(24), CByte(93), CByte(252))
        NetworkMapBtn.FlatStyle = FlatStyle.Flat
        NetworkMapBtn.ForeColor = Color.Transparent
        NetworkMapBtn.Image = My.Resources.Resources.networkMap
        NetworkMapBtn.ImageAlign = ContentAlignment.MiddleLeft
        NetworkMapBtn.Location = New Point(0, 428)
        NetworkMapBtn.Margin = New Padding(3, 2, 3, 2)
        NetworkMapBtn.Name = "NetworkMapBtn"
        NetworkMapBtn.Padding = New Padding(18, 0, 0, 0)
        NetworkMapBtn.Size = New Size(240, 39)
        NetworkMapBtn.TabIndex = 11
        NetworkMapBtn.Text = "           NetworkMap"
        NetworkMapBtn.TextAlign = ContentAlignment.MiddleLeft
        NetworkMapBtn.UseCompatibleTextRendering = True
        NetworkMapBtn.UseVisualStyleBackColor = True
        ' 
        ' BillingBtn
        ' 
        BillingBtn.AllowDrop = True
        BillingBtn.FlatAppearance.BorderSize = 0
        BillingBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(24), CByte(93), CByte(252))
        BillingBtn.FlatStyle = FlatStyle.Flat
        BillingBtn.ForeColor = Color.Transparent
        BillingBtn.Image = My.Resources.Resources.billing
        BillingBtn.ImageAlign = ContentAlignment.MiddleLeft
        BillingBtn.Location = New Point(0, 384)
        BillingBtn.Margin = New Padding(3, 2, 3, 2)
        BillingBtn.Name = "BillingBtn"
        BillingBtn.Padding = New Padding(18, 0, 0, 0)
        BillingBtn.Size = New Size(240, 39)
        BillingBtn.TabIndex = 10
        BillingBtn.Text = "           Billing"
        BillingBtn.TextAlign = ContentAlignment.MiddleLeft
        BillingBtn.UseCompatibleTextRendering = True
        BillingBtn.UseVisualStyleBackColor = True
        ' 
        ' SubscriberBtn
        ' 
        SubscriberBtn.AllowDrop = True
        SubscriberBtn.FlatAppearance.BorderSize = 0
        SubscriberBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(24), CByte(93), CByte(252))
        SubscriberBtn.FlatStyle = FlatStyle.Flat
        SubscriberBtn.ForeColor = Color.Transparent
        SubscriberBtn.Image = My.Resources.Resources.subscriber
        SubscriberBtn.ImageAlign = ContentAlignment.MiddleLeft
        SubscriberBtn.Location = New Point(0, 340)
        SubscriberBtn.Margin = New Padding(3, 2, 3, 2)
        SubscriberBtn.Name = "SubscriberBtn"
        SubscriberBtn.Padding = New Padding(18, 0, 0, 0)
        SubscriberBtn.Size = New Size(240, 39)
        SubscriberBtn.TabIndex = 9
        SubscriberBtn.Text = "           Subscriber"
        SubscriberBtn.TextAlign = ContentAlignment.MiddleLeft
        SubscriberBtn.UseCompatibleTextRendering = True
        SubscriberBtn.UseVisualStyleBackColor = True
        ' 
        ' PayrollBtn
        ' 
        PayrollBtn.AllowDrop = True
        PayrollBtn.FlatAppearance.BorderSize = 0
        PayrollBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(24), CByte(93), CByte(252))
        PayrollBtn.FlatStyle = FlatStyle.Flat
        PayrollBtn.ForeColor = Color.Transparent
        PayrollBtn.Image = My.Resources.Resources.payroll
        PayrollBtn.ImageAlign = ContentAlignment.MiddleLeft
        PayrollBtn.Location = New Point(0, 290)
        PayrollBtn.Margin = New Padding(3, 2, 3, 2)
        PayrollBtn.Name = "PayrollBtn"
        PayrollBtn.Padding = New Padding(18, 0, 0, 0)
        PayrollBtn.Size = New Size(240, 39)
        PayrollBtn.TabIndex = 8
        PayrollBtn.Text = "           Payroll"
        PayrollBtn.TextAlign = ContentAlignment.MiddleLeft
        PayrollBtn.UseCompatibleTextRendering = True
        PayrollBtn.UseVisualStyleBackColor = True
        ' 
        ' InventoryBtn
        ' 
        InventoryBtn.AllowDrop = True
        InventoryBtn.FlatAppearance.BorderSize = 0
        InventoryBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(24), CByte(93), CByte(252))
        InventoryBtn.FlatStyle = FlatStyle.Flat
        InventoryBtn.ForeColor = Color.Transparent
        InventoryBtn.Image = My.Resources.Resources.inventory
        InventoryBtn.ImageAlign = ContentAlignment.MiddleLeft
        InventoryBtn.Location = New Point(0, 246)
        InventoryBtn.Margin = New Padding(3, 2, 3, 2)
        InventoryBtn.Name = "InventoryBtn"
        InventoryBtn.Padding = New Padding(18, 0, 0, 0)
        InventoryBtn.Size = New Size(240, 39)
        InventoryBtn.TabIndex = 7
        InventoryBtn.Text = "           Inventory"
        InventoryBtn.TextAlign = ContentAlignment.MiddleLeft
        InventoryBtn.UseCompatibleTextRendering = True
        InventoryBtn.UseVisualStyleBackColor = True
        ' 
        ' ServiceBtn
        ' 
        ServiceBtn.AllowDrop = True
        ServiceBtn.FlatAppearance.BorderSize = 0
        ServiceBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(24), CByte(93), CByte(252))
        ServiceBtn.FlatStyle = FlatStyle.Flat
        ServiceBtn.ForeColor = Color.Transparent
        ServiceBtn.Image = My.Resources.Resources.service
        ServiceBtn.ImageAlign = ContentAlignment.MiddleLeft
        ServiceBtn.Location = New Point(0, 202)
        ServiceBtn.Margin = New Padding(3, 2, 3, 2)
        ServiceBtn.Name = "ServiceBtn"
        ServiceBtn.Padding = New Padding(18, 0, 0, 0)
        ServiceBtn.Size = New Size(240, 39)
        ServiceBtn.TabIndex = 6
        ServiceBtn.Text = "           Service"
        ServiceBtn.TextAlign = ContentAlignment.MiddleLeft
        ServiceBtn.UseCompatibleTextRendering = True
        ServiceBtn.UseVisualStyleBackColor = True
        ' 
        ' InstallationBtn
        ' 
        InstallationBtn.AllowDrop = True
        InstallationBtn.FlatAppearance.BorderSize = 0
        InstallationBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(24), CByte(93), CByte(252))
        InstallationBtn.FlatStyle = FlatStyle.Flat
        InstallationBtn.ForeColor = Color.Transparent
        InstallationBtn.Image = My.Resources.Resources.installation
        InstallationBtn.ImageAlign = ContentAlignment.MiddleLeft
        InstallationBtn.Location = New Point(0, 159)
        InstallationBtn.Margin = New Padding(3, 2, 3, 2)
        InstallationBtn.Name = "InstallationBtn"
        InstallationBtn.Padding = New Padding(18, 0, 0, 0)
        InstallationBtn.Size = New Size(240, 39)
        InstallationBtn.TabIndex = 5
        InstallationBtn.Text = "           Installation"
        InstallationBtn.TextAlign = ContentAlignment.MiddleLeft
        InstallationBtn.UseCompatibleTextRendering = True
        InstallationBtn.UseVisualStyleBackColor = True
        ' 
        ' SalesBtn
        ' 
        SalesBtn.FlatAppearance.BorderSize = 0
        SalesBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(24), CByte(93), CByte(252))
        SalesBtn.FlatStyle = FlatStyle.Flat
        SalesBtn.ForeColor = Color.Transparent
        SalesBtn.Image = My.Resources.Resources.sales
        SalesBtn.ImageAlign = ContentAlignment.MiddleLeft
        SalesBtn.Location = New Point(0, 116)
        SalesBtn.Margin = New Padding(3, 2, 3, 2)
        SalesBtn.Name = "SalesBtn"
        SalesBtn.Padding = New Padding(18, 0, 0, 0)
        SalesBtn.Size = New Size(240, 39)
        SalesBtn.TabIndex = 4
        SalesBtn.Text = "           Sales"
        SalesBtn.TextAlign = ContentAlignment.MiddleLeft
        SalesBtn.UseVisualStyleBackColor = True
        ' 
        ' DashboardBtn
        ' 
        DashboardBtn.FlatAppearance.BorderSize = 0
        DashboardBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(24), CByte(93), CByte(252))
        DashboardBtn.FlatStyle = FlatStyle.Flat
        DashboardBtn.ForeColor = Color.Transparent
        DashboardBtn.Image = My.Resources.Resources.dashboard
        DashboardBtn.ImageAlign = ContentAlignment.MiddleLeft
        DashboardBtn.Location = New Point(0, 72)
        DashboardBtn.Margin = New Padding(3, 2, 3, 2)
        DashboardBtn.Name = "DashboardBtn"
        DashboardBtn.Padding = New Padding(18, 0, 0, 0)
        DashboardBtn.Size = New Size(240, 39)
        DashboardBtn.TabIndex = 3
        DashboardBtn.Text = "           Dashboard"
        DashboardBtn.TextAlign = ContentAlignment.MiddleLeft
        DashboardBtn.UseVisualStyleBackColor = True
        ' 
        ' line
        ' 
        line.AutoSize = True
        line.BackColor = Color.Transparent
        line.ForeColor = Color.FromArgb(CByte(42), CByte(53), CByte(72))
        line.Location = New Point(-3, 59)
        line.Name = "line"
        line.Size = New Size(247, 15)
        line.TabIndex = 2
        line.Text = "________________________________________________"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.SparxFiber
        PictureBox2.Location = New Point(41, 12)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(117, 55)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 2
        PictureBox2.TabStop = False
        ' 
        ' Mainexchange
        ' 
        Mainexchange.AutoScroll = True
        Mainexchange.BackColor = Color.White
        Mainexchange.Location = New Point(240, 67)
        Mainexchange.Name = "Mainexchange"
        Mainexchange.Size = New Size(1684, 1053)
        Mainexchange.TabIndex = 6
        Mainexchange.Visible = False
        ' 
        ' dashboardSuperAdmin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1386, 1009)
        Controls.Add(Mainexchange)
        Controls.Add(pnlMenu)
        Controls.Add(pnlHeader)
        FormBorderStyle = FormBorderStyle.None
        Name = "dashboardSuperAdmin"
        ShowIcon = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "dashbordSuperAdmin"
        WindowState = FormWindowState.Maximized
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        pnlMenu.ResumeLayout(False)
        pnlMenu.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblDashboardSuperAdmin As Label
    Friend WithEvents pnlMenu As Panel
    Friend WithEvents overview As Label
    Friend WithEvents pnlSystemOnline As PanelRound
    Friend WithEvents systemOnline As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents line As Label
    Friend WithEvents DashboardBtn As Button
    Friend WithEvents SalesBtn As Button
    Friend WithEvents ServiceBtn As Button
    Friend WithEvents InstallationBtn As Button
    Friend WithEvents PayrollBtn As Button
    Friend WithEvents InventoryBtn As Button
    Friend WithEvents PlansBtn As Button
    Friend WithEvents HistoryBtn As Button
    Friend WithEvents NetworkMapBtn As Button
    Friend WithEvents BillingBtn As Button
    Friend WithEvents SubscriberBtn As Button
    Friend WithEvents Mainexchange As Panel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents StaffBtn As Button
End Class

