<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminDashboard
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdminDashboard))
        LabelReqService = New Label()
        PendingService = New PictureBox()
        AmountPendingServices = New Label()
        PercentPendingService = New Label()
        PanelRound4 = New PanelRound()
        LabelActiveInstallation = New Label()
        ActiveInstall = New PictureBox()
        AmountActiveInstall = New Label()
        PercentActiveInstall = New Label()
        PanelRound3 = New PanelRound()
        LabelTotalSubscribers = New Label()
        TotalSubs = New PictureBox()
        AmountSubscribers = New Label()
        PercentTotalSub = New Label()
        PanelRound1 = New PanelRound()
        Panel3 = New Panel()
        PanelRound12 = New PanelRound()
        PanelBasic = New PanelRound()
        PercentBasic = New Label()
        BasicTotal = New Label()
        AmountBasic = New Label()
        BasicSubscribers = New Label()
        LabelBasic = New Label()
        PictureBox6 = New PictureBox()
        PanelStandard = New PanelRound()
        PercentStandard = New Label()
        LabelStandard = New Label()
        TotalStandard = New Label()
        PictureBox4 = New PictureBox()
        AmountStandard = New Label()
        StandardSubscribers = New Label()
        PanelPremium = New PanelRound()
        PercentPremium = New Label()
        TotalPremium = New Label()
        AmountPremium = New Label()
        PremiumSubscribers = New Label()
        LabelPremium = New Label()
        PictureBox5 = New PictureBox()
        LabelSubscribersByPlan = New Label()
        PanelSubscribersByPlan = New PanelRound()
        LabelProgress = New Label()
        OrangePending = New PictureBox()
        OrangeDotProgress = New PictureBox()
        LblRequested = New Label()
        GreenDotComplete = New PictureBox()
        percentCompleted = New Label()
        ServiceStatusDistribution = New Label()
        percentInProgress = New Label()
        LabelCompleted = New Label()
        percentRequested = New Label()
        Panel2 = New Panel()
        PanelRound6 = New PanelRound()
        SubscribersGrowth = New Label()
        Panel1 = New Panel()
        PanelRound5 = New PanelRound()
        LabelMonthlyRevenue = New Label()
        MonthlyRev = New PictureBox()
        AmountMonthlyRev = New Label()
        PercentMonthlyRev = New Label()
        PanelRound2 = New PanelRound()
        CType(PendingService, ComponentModel.ISupportInitialize).BeginInit()
        PanelRound4.SuspendLayout()
        CType(ActiveInstall, ComponentModel.ISupportInitialize).BeginInit()
        PanelRound3.SuspendLayout()
        CType(TotalSubs, ComponentModel.ISupportInitialize).BeginInit()
        PanelRound1.SuspendLayout()
        PanelBasic.SuspendLayout()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
        PanelStandard.SuspendLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        PanelPremium.SuspendLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        PanelSubscribersByPlan.SuspendLayout()
        CType(OrangePending, ComponentModel.ISupportInitialize).BeginInit()
        CType(OrangeDotProgress, ComponentModel.ISupportInitialize).BeginInit()
        CType(GreenDotComplete, ComponentModel.ISupportInitialize).BeginInit()
        PanelRound6.SuspendLayout()
        PanelRound5.SuspendLayout()
        CType(MonthlyRev, ComponentModel.ISupportInitialize).BeginInit()
        PanelRound2.SuspendLayout()
        SuspendLayout()
        ' 
        ' LabelReqService
        ' 
        LabelReqService.Anchor = AnchorStyles.Top
        LabelReqService.AutoSize = True
        LabelReqService.Font = New Font("Verdana", 11F)
        LabelReqService.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        LabelReqService.Location = New Point(27, 12)
        LabelReqService.Name = "LabelReqService"
        LabelReqService.Size = New Size(153, 18)
        LabelReqService.TabIndex = 3
        LabelReqService.Text = "Requested Services"
        ' 
        ' PendingService
        ' 
        PendingService.Anchor = AnchorStyles.Top
        PendingService.Image = CType(resources.GetObject("PendingService.Image"), Image)
        PendingService.Location = New Point(384, 47)
        PendingService.Name = "PendingService"
        PendingService.Size = New Size(45, 48)
        PendingService.SizeMode = PictureBoxSizeMode.Zoom
        PendingService.TabIndex = 8
        PendingService.TabStop = False
        ' 
        ' AmountPendingServices
        ' 
        AmountPendingServices.Anchor = AnchorStyles.Top
        AmountPendingServices.AutoSize = True
        AmountPendingServices.Font = New Font("Verdana", 16F)
        AmountPendingServices.Location = New Point(27, 47)
        AmountPendingServices.Name = "AmountPendingServices"
        AmountPendingServices.Size = New Size(68, 26)
        AmountPendingServices.TabIndex = 10
        AmountPendingServices.Text = "0000"
        ' 
        ' PercentPendingService
        ' 
        PercentPendingService.Anchor = AnchorStyles.Top
        PercentPendingService.AutoSize = True
        PercentPendingService.Font = New Font("Segoe UI", 10F)
        PercentPendingService.ForeColor = Color.FromArgb(CByte(0), CByte(201), CByte(80))
        PercentPendingService.Location = New Point(27, 80)
        PercentPendingService.Name = "PercentPendingService"
        PercentPendingService.Size = New Size(87, 19)
        PercentPendingService.TabIndex = 12
        PercentPendingService.Text = "[Placeholder]"
        ' 
        ' PanelRound4
        ' 
        PanelRound4.BackColor = Color.White
        PanelRound4.Controls.Add(PercentPendingService)
        PanelRound4.Controls.Add(AmountPendingServices)
        PanelRound4.Controls.Add(PendingService)
        PanelRound4.Controls.Add(LabelReqService)
        PanelRound4.CornerRadius = 12
        PanelRound4.Font = New Font("Segoe UI", 8.25F)
        PanelRound4.Location = New Point(857, 26)
        PanelRound4.Name = "PanelRound4"
        PanelRound4.Size = New Size(367, 142)
        PanelRound4.TabIndex = 48
        ' 
        ' LabelActiveInstallation
        ' 
        LabelActiveInstallation.Anchor = AnchorStyles.Top
        LabelActiveInstallation.AutoSize = True
        LabelActiveInstallation.Font = New Font("Verdana", 11F)
        LabelActiveInstallation.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        LabelActiveInstallation.Location = New Point(35, 12)
        LabelActiveInstallation.Name = "LabelActiveInstallation"
        LabelActiveInstallation.Size = New Size(138, 18)
        LabelActiveInstallation.TabIndex = 2
        LabelActiveInstallation.Text = "Active Installation"
        ' 
        ' ActiveInstall
        ' 
        ActiveInstall.Anchor = AnchorStyles.Top
        ActiveInstall.Image = CType(resources.GetObject("ActiveInstall.Image"), Image)
        ActiveInstall.Location = New Point(381, 47)
        ActiveInstall.Name = "ActiveInstall"
        ActiveInstall.Size = New Size(45, 48)
        ActiveInstall.SizeMode = PictureBoxSizeMode.Zoom
        ActiveInstall.TabIndex = 7
        ActiveInstall.TabStop = False
        ' 
        ' AmountActiveInstall
        ' 
        AmountActiveInstall.Anchor = AnchorStyles.Top
        AmountActiveInstall.AutoSize = True
        AmountActiveInstall.Font = New Font("Verdana", 16F)
        AmountActiveInstall.Location = New Point(35, 47)
        AmountActiveInstall.Name = "AmountActiveInstall"
        AmountActiveInstall.Size = New Size(68, 26)
        AmountActiveInstall.TabIndex = 9
        AmountActiveInstall.Text = "0000"
        ' 
        ' PercentActiveInstall
        ' 
        PercentActiveInstall.Anchor = AnchorStyles.Top
        PercentActiveInstall.AutoSize = True
        PercentActiveInstall.Font = New Font("Segoe UI", 10F)
        PercentActiveInstall.ForeColor = Color.FromArgb(CByte(0), CByte(201), CByte(80))
        PercentActiveInstall.Location = New Point(35, 80)
        PercentActiveInstall.Name = "PercentActiveInstall"
        PercentActiveInstall.Size = New Size(87, 19)
        PercentActiveInstall.TabIndex = 11
        PercentActiveInstall.Text = "[Placeholder]"
        ' 
        ' PanelRound3
        ' 
        PanelRound3.BackColor = Color.White
        PanelRound3.Controls.Add(PercentActiveInstall)
        PanelRound3.Controls.Add(AmountActiveInstall)
        PanelRound3.Controls.Add(ActiveInstall)
        PanelRound3.Controls.Add(LabelActiveInstallation)
        PanelRound3.CornerRadius = 12
        PanelRound3.Location = New Point(1268, 26)
        PanelRound3.Name = "PanelRound3"
        PanelRound3.Size = New Size(367, 142)
        PanelRound3.TabIndex = 47
        ' 
        ' LabelTotalSubscribers
        ' 
        LabelTotalSubscribers.Anchor = AnchorStyles.Top
        LabelTotalSubscribers.AutoSize = True
        LabelTotalSubscribers.Font = New Font("Verdana", 11F)
        LabelTotalSubscribers.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        LabelTotalSubscribers.Location = New Point(22, 12)
        LabelTotalSubscribers.Name = "LabelTotalSubscribers"
        LabelTotalSubscribers.Size = New Size(133, 18)
        LabelTotalSubscribers.TabIndex = 0
        LabelTotalSubscribers.Text = "Total Subscribers"
        ' 
        ' TotalSubs
        ' 
        TotalSubs.Anchor = AnchorStyles.Top
        TotalSubs.Image = CType(resources.GetObject("TotalSubs.Image"), Image)
        TotalSubs.Location = New Point(385, 47)
        TotalSubs.Name = "TotalSubs"
        TotalSubs.Size = New Size(45, 48)
        TotalSubs.SizeMode = PictureBoxSizeMode.Zoom
        TotalSubs.TabIndex = 5
        TotalSubs.TabStop = False
        ' 
        ' AmountSubscribers
        ' 
        AmountSubscribers.Anchor = AnchorStyles.Top
        AmountSubscribers.AutoSize = True
        AmountSubscribers.Font = New Font("Verdana", 16F)
        AmountSubscribers.Location = New Point(22, 47)
        AmountSubscribers.Name = "AmountSubscribers"
        AmountSubscribers.Size = New Size(68, 26)
        AmountSubscribers.TabIndex = 7
        AmountSubscribers.Text = "0000"
        ' 
        ' PercentTotalSub
        ' 
        PercentTotalSub.Anchor = AnchorStyles.Top
        PercentTotalSub.AutoSize = True
        PercentTotalSub.Font = New Font("Segoe UI", 10F)
        PercentTotalSub.ForeColor = Color.FromArgb(CByte(0), CByte(201), CByte(80))
        PercentTotalSub.Location = New Point(22, 80)
        PercentTotalSub.Name = "PercentTotalSub"
        PercentTotalSub.Size = New Size(87, 19)
        PercentTotalSub.TabIndex = 9
        PercentTotalSub.Text = "[Placeholder]"
        ' 
        ' PanelRound1
        ' 
        PanelRound1.BackColor = Color.White
        PanelRound1.Controls.Add(PercentTotalSub)
        PanelRound1.Controls.Add(AmountSubscribers)
        PanelRound1.Controls.Add(TotalSubs)
        PanelRound1.Controls.Add(LabelTotalSubscribers)
        PanelRound1.CornerRadius = 12
        PanelRound1.Location = New Point(449, 26)
        PanelRound1.Name = "PanelRound1"
        PanelRound1.Size = New Size(367, 142)
        PanelRound1.TabIndex = 45
        ' 
        ' Panel3
        ' 
        Panel3.Location = New Point(38, 682)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(667, 405)
        Panel3.TabIndex = 17
        ' 
        ' PanelRound12
        ' 
        PanelRound12.Location = New Point(40, 1150)
        PanelRound12.Name = "PanelRound12"
        PanelRound12.Size = New Size(1597, 58)
        PanelRound12.TabIndex = 44
        ' 
        ' PanelBasic
        ' 
        PanelBasic.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(251))
        PanelBasic.Controls.Add(PercentBasic)
        PanelBasic.Controls.Add(BasicTotal)
        PanelBasic.Controls.Add(AmountBasic)
        PanelBasic.Controls.Add(BasicSubscribers)
        PanelBasic.Controls.Add(LabelBasic)
        PanelBasic.Controls.Add(PictureBox6)
        PanelBasic.CornerRadius = 12
        PanelBasic.Location = New Point(697, 99)
        PanelBasic.Name = "PanelBasic"
        PanelBasic.Size = New Size(861, 74)
        PanelBasic.TabIndex = 0
        ' 
        ' PercentBasic
        ' 
        PercentBasic.Anchor = AnchorStyles.Top
        PercentBasic.AutoSize = True
        PercentBasic.Font = New Font("Segoe UI", 11F)
        PercentBasic.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        PercentBasic.Location = New Point(747, 40)
        PercentBasic.Name = "PercentBasic"
        PercentBasic.Size = New Size(37, 20)
        PercentBasic.TabIndex = 29
        PercentBasic.Text = "00%"
        ' 
        ' BasicTotal
        ' 
        BasicTotal.Anchor = AnchorStyles.Top
        BasicTotal.AutoSize = True
        BasicTotal.Font = New Font("Segoe UI", 11F)
        BasicTotal.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        BasicTotal.Location = New Point(787, 40)
        BasicTotal.Name = "BasicTotal"
        BasicTotal.Size = New Size(58, 20)
        BasicTotal.TabIndex = 25
        BasicTotal.Text = "of total"
        ' 
        ' AmountBasic
        ' 
        AmountBasic.Anchor = AnchorStyles.Top
        AmountBasic.AutoSize = True
        AmountBasic.Font = New Font("Segoe UI", 11F)
        AmountBasic.ForeColor = Color.Black
        AmountBasic.Location = New Point(718, 15)
        AmountBasic.Name = "AmountBasic"
        AmountBasic.Size = New Size(25, 20)
        AmountBasic.TabIndex = 28
        AmountBasic.Text = "00"
        ' 
        ' BasicSubscribers
        ' 
        BasicSubscribers.Anchor = AnchorStyles.Top
        BasicSubscribers.AutoSize = True
        BasicSubscribers.Font = New Font("Segoe UI", 11F)
        BasicSubscribers.ForeColor = Color.Black
        BasicSubscribers.Location = New Point(762, 15)
        BasicSubscribers.Name = "BasicSubscribers"
        BasicSubscribers.Size = New Size(84, 20)
        BasicSubscribers.TabIndex = 24
        BasicSubscribers.Text = "Subscribers"
        ' 
        ' LabelBasic
        ' 
        LabelBasic.Anchor = AnchorStyles.Top
        LabelBasic.AutoSize = True
        LabelBasic.Font = New Font("Segoe UI", 11F)
        LabelBasic.ForeColor = Color.FromArgb(CByte(54), CByte(65), CByte(83))
        LabelBasic.Location = New Point(32, 28)
        LabelBasic.Name = "LabelBasic"
        LabelBasic.Size = New Size(100, 20)
        LabelBasic.TabIndex = 26
        LabelBasic.Text = "Basic 25Mbps"
        ' 
        ' PictureBox6
        ' 
        PictureBox6.Anchor = AnchorStyles.Top
        PictureBox6.Image = My.Resources.Resources.BlueDot
        PictureBox6.Location = New Point(14, 32)
        PictureBox6.Name = "PictureBox6"
        PictureBox6.Size = New Size(12, 12)
        PictureBox6.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox6.TabIndex = 27
        PictureBox6.TabStop = False
        ' 
        ' PanelStandard
        ' 
        PanelStandard.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(251))
        PanelStandard.Controls.Add(PercentStandard)
        PanelStandard.Controls.Add(LabelStandard)
        PanelStandard.Controls.Add(TotalStandard)
        PanelStandard.Controls.Add(PictureBox4)
        PanelStandard.Controls.Add(AmountStandard)
        PanelStandard.Controls.Add(StandardSubscribers)
        PanelStandard.CornerRadius = 12
        PanelStandard.Location = New Point(697, 196)
        PanelStandard.Name = "PanelStandard"
        PanelStandard.Size = New Size(861, 74)
        PanelStandard.TabIndex = 1
        ' 
        ' PercentStandard
        ' 
        PercentStandard.Anchor = AnchorStyles.Top
        PercentStandard.AutoSize = True
        PercentStandard.Font = New Font("Segoe UI", 11F)
        PercentStandard.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        PercentStandard.Location = New Point(743, 40)
        PercentStandard.Name = "PercentStandard"
        PercentStandard.Size = New Size(37, 20)
        PercentStandard.TabIndex = 33
        PercentStandard.Text = "00%"
        ' 
        ' LabelStandard
        ' 
        LabelStandard.Anchor = AnchorStyles.Top
        LabelStandard.AutoSize = True
        LabelStandard.Font = New Font("Segoe UI", 11F)
        LabelStandard.ForeColor = Color.FromArgb(CByte(54), CByte(65), CByte(83))
        LabelStandard.Location = New Point(32, 24)
        LabelStandard.Name = "LabelStandard"
        LabelStandard.Size = New Size(126, 20)
        LabelStandard.TabIndex = 29
        LabelStandard.Text = "Standard 50Mbps"
        ' 
        ' TotalStandard
        ' 
        TotalStandard.Anchor = AnchorStyles.Top
        TotalStandard.AutoSize = True
        TotalStandard.Font = New Font("Segoe UI", 11F)
        TotalStandard.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        TotalStandard.Location = New Point(787, 40)
        TotalStandard.Name = "TotalStandard"
        TotalStandard.Size = New Size(58, 20)
        TotalStandard.TabIndex = 31
        TotalStandard.Text = "of total"
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Anchor = AnchorStyles.Top
        PictureBox4.Image = My.Resources.Resources.EcstacyDot
        PictureBox4.Location = New Point(14, 28)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(12, 12)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 28
        PictureBox4.TabStop = False
        ' 
        ' AmountStandard
        ' 
        AmountStandard.Anchor = AnchorStyles.Top
        AmountStandard.AutoSize = True
        AmountStandard.Font = New Font("Segoe UI", 11F)
        AmountStandard.ForeColor = Color.Black
        AmountStandard.Location = New Point(718, 15)
        AmountStandard.Name = "AmountStandard"
        AmountStandard.Size = New Size(25, 20)
        AmountStandard.TabIndex = 32
        AmountStandard.Text = "00"
        ' 
        ' StandardSubscribers
        ' 
        StandardSubscribers.Anchor = AnchorStyles.Top
        StandardSubscribers.AutoSize = True
        StandardSubscribers.Font = New Font("Segoe UI", 11F)
        StandardSubscribers.ForeColor = Color.Black
        StandardSubscribers.Location = New Point(762, 15)
        StandardSubscribers.Name = "StandardSubscribers"
        StandardSubscribers.Size = New Size(84, 20)
        StandardSubscribers.TabIndex = 30
        StandardSubscribers.Text = "Subscribers"
        ' 
        ' PanelPremium
        ' 
        PanelPremium.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(251))
        PanelPremium.Controls.Add(PercentPremium)
        PanelPremium.Controls.Add(TotalPremium)
        PanelPremium.Controls.Add(AmountPremium)
        PanelPremium.Controls.Add(PremiumSubscribers)
        PanelPremium.Controls.Add(LabelPremium)
        PanelPremium.Controls.Add(PictureBox5)
        PanelPremium.CornerRadius = 12
        PanelPremium.Location = New Point(697, 292)
        PanelPremium.Name = "PanelPremium"
        PanelPremium.Size = New Size(861, 74)
        PanelPremium.TabIndex = 2
        ' 
        ' PercentPremium
        ' 
        PercentPremium.Anchor = AnchorStyles.Top
        PercentPremium.AutoSize = True
        PercentPremium.Font = New Font("Segoe UI", 11F)
        PercentPremium.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        PercentPremium.Location = New Point(747, 40)
        PercentPremium.Name = "PercentPremium"
        PercentPremium.Size = New Size(37, 20)
        PercentPremium.TabIndex = 33
        PercentPremium.Text = "00%"
        ' 
        ' TotalPremium
        ' 
        TotalPremium.Anchor = AnchorStyles.Top
        TotalPremium.AutoSize = True
        TotalPremium.Font = New Font("Segoe UI", 11F)
        TotalPremium.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        TotalPremium.Location = New Point(787, 40)
        TotalPremium.Name = "TotalPremium"
        TotalPremium.Size = New Size(58, 20)
        TotalPremium.TabIndex = 31
        TotalPremium.Text = "of total"
        ' 
        ' AmountPremium
        ' 
        AmountPremium.Anchor = AnchorStyles.Top
        AmountPremium.AutoSize = True
        AmountPremium.Font = New Font("Segoe UI", 11F)
        AmountPremium.ForeColor = Color.Black
        AmountPremium.Location = New Point(718, 15)
        AmountPremium.Name = "AmountPremium"
        AmountPremium.Size = New Size(25, 20)
        AmountPremium.TabIndex = 32
        AmountPremium.Text = "00"
        ' 
        ' PremiumSubscribers
        ' 
        PremiumSubscribers.Anchor = AnchorStyles.Top
        PremiumSubscribers.AutoSize = True
        PremiumSubscribers.Font = New Font("Segoe UI", 11F)
        PremiumSubscribers.ForeColor = Color.Black
        PremiumSubscribers.Location = New Point(762, 15)
        PremiumSubscribers.Name = "PremiumSubscribers"
        PremiumSubscribers.Size = New Size(84, 20)
        PremiumSubscribers.TabIndex = 30
        PremiumSubscribers.Text = "Subscribers"
        ' 
        ' LabelPremium
        ' 
        LabelPremium.Anchor = AnchorStyles.Top
        LabelPremium.AutoSize = True
        LabelPremium.Font = New Font("Segoe UI", 11F)
        LabelPremium.ForeColor = Color.FromArgb(CByte(54), CByte(65), CByte(83))
        LabelPremium.Location = New Point(32, 24)
        LabelPremium.Name = "LabelPremium"
        LabelPremium.Size = New Size(133, 20)
        LabelPremium.TabIndex = 29
        LabelPremium.Text = "Premium 100Mbps"
        ' 
        ' PictureBox5
        ' 
        PictureBox5.Anchor = AnchorStyles.Top
        PictureBox5.Image = My.Resources.Resources.greenDot
        PictureBox5.Location = New Point(14, 28)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(12, 12)
        PictureBox5.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox5.TabIndex = 28
        PictureBox5.TabStop = False
        ' 
        ' LabelSubscribersByPlan
        ' 
        LabelSubscribersByPlan.Anchor = AnchorStyles.Top
        LabelSubscribersByPlan.AutoSize = True
        LabelSubscribersByPlan.Font = New Font("Verdana", 11F)
        LabelSubscribersByPlan.ForeColor = Color.Black
        LabelSubscribersByPlan.Location = New Point(27, 20)
        LabelSubscribersByPlan.Name = "LabelSubscribersByPlan"
        LabelSubscribersByPlan.Size = New Size(143, 18)
        LabelSubscribersByPlan.TabIndex = 16
        LabelSubscribersByPlan.Text = "Subscriber by Plan"
        ' 
        ' PanelSubscribersByPlan
        ' 
        PanelSubscribersByPlan.BackColor = Color.White
        PanelSubscribersByPlan.Controls.Add(LabelSubscribersByPlan)
        PanelSubscribersByPlan.Controls.Add(PanelPremium)
        PanelSubscribersByPlan.Controls.Add(PanelStandard)
        PanelSubscribersByPlan.Controls.Add(PanelBasic)
        PanelSubscribersByPlan.Location = New Point(38, 632)
        PanelSubscribersByPlan.Name = "PanelSubscribersByPlan"
        PanelSubscribersByPlan.Size = New Size(1597, 481)
        PanelSubscribersByPlan.TabIndex = 35
        ' 
        ' LabelProgress
        ' 
        LabelProgress.Anchor = AnchorStyles.Top
        LabelProgress.AutoSize = True
        LabelProgress.Font = New Font("Segoe UI", 11F)
        LabelProgress.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        LabelProgress.Location = New Point(340, 361)
        LabelProgress.Name = "LabelProgress"
        LabelProgress.Size = New Size(81, 20)
        LabelProgress.TabIndex = 40
        LabelProgress.Text = "In Progress"
        ' 
        ' OrangePending
        ' 
        OrangePending.Anchor = AnchorStyles.Top
        OrangePending.Image = My.Resources.Resources.ButtercupDot
        OrangePending.Location = New Point(609, 364)
        OrangePending.Name = "OrangePending"
        OrangePending.Size = New Size(12, 12)
        OrangePending.SizeMode = PictureBoxSizeMode.Zoom
        OrangePending.TabIndex = 41
        OrangePending.TabStop = False
        ' 
        ' OrangeDotProgress
        ' 
        OrangeDotProgress.Anchor = AnchorStyles.Top
        OrangeDotProgress.Image = My.Resources.Resources.EcstacyDot
        OrangeDotProgress.Location = New Point(322, 364)
        OrangeDotProgress.Name = "OrangeDotProgress"
        OrangeDotProgress.Size = New Size(12, 12)
        OrangeDotProgress.SizeMode = PictureBoxSizeMode.Zoom
        OrangeDotProgress.TabIndex = 39
        OrangeDotProgress.TabStop = False
        ' 
        ' LblRequested
        ' 
        LblRequested.Anchor = AnchorStyles.Top
        LblRequested.AutoSize = True
        LblRequested.Font = New Font("Segoe UI", 11F)
        LblRequested.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        LblRequested.Location = New Point(627, 361)
        LblRequested.Name = "LblRequested"
        LblRequested.Size = New Size(79, 20)
        LblRequested.TabIndex = 42
        LblRequested.Text = "Requested"
        ' 
        ' GreenDotComplete
        ' 
        GreenDotComplete.Anchor = AnchorStyles.Top
        GreenDotComplete.Image = My.Resources.Resources.greenDot
        GreenDotComplete.Location = New Point(41, 364)
        GreenDotComplete.Name = "GreenDotComplete"
        GreenDotComplete.Size = New Size(12, 12)
        GreenDotComplete.SizeMode = PictureBoxSizeMode.Zoom
        GreenDotComplete.TabIndex = 38
        GreenDotComplete.TabStop = False
        ' 
        ' percentCompleted
        ' 
        percentCompleted.Anchor = AnchorStyles.Top
        percentCompleted.AutoSize = True
        percentCompleted.Font = New Font("Segoe UI", 11F)
        percentCompleted.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        percentCompleted.Location = New Point(139, 361)
        percentCompleted.Name = "percentCompleted"
        percentCompleted.Size = New Size(31, 20)
        percentCompleted.TabIndex = 43
        percentCompleted.Text = "(%)"
        ' 
        ' ServiceStatusDistribution
        ' 
        ServiceStatusDistribution.Anchor = AnchorStyles.Top
        ServiceStatusDistribution.AutoSize = True
        ServiceStatusDistribution.Font = New Font("Verdana", 11F)
        ServiceStatusDistribution.ForeColor = Color.Black
        ServiceStatusDistribution.Location = New Point(27, 15)
        ServiceStatusDistribution.Name = "ServiceStatusDistribution"
        ServiceStatusDistribution.Size = New Size(203, 18)
        ServiceStatusDistribution.TabIndex = 36
        ServiceStatusDistribution.Text = "Service Status Distribution"
        ' 
        ' percentInProgress
        ' 
        percentInProgress.Anchor = AnchorStyles.Top
        percentInProgress.AutoSize = True
        percentInProgress.Font = New Font("Segoe UI", 11F)
        percentInProgress.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        percentInProgress.Location = New Point(432, 361)
        percentInProgress.Name = "percentInProgress"
        percentInProgress.Size = New Size(31, 20)
        percentInProgress.TabIndex = 44
        percentInProgress.Text = "(%)"
        ' 
        ' LabelCompleted
        ' 
        LabelCompleted.Anchor = AnchorStyles.Top
        LabelCompleted.AutoSize = True
        LabelCompleted.Font = New Font("Segoe UI", 11F)
        LabelCompleted.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        LabelCompleted.Location = New Point(59, 361)
        LabelCompleted.Name = "LabelCompleted"
        LabelCompleted.Size = New Size(83, 20)
        LabelCompleted.TabIndex = 37
        LabelCompleted.Text = "Completed"
        ' 
        ' percentRequested
        ' 
        percentRequested.Anchor = AnchorStyles.Top
        percentRequested.AutoSize = True
        percentRequested.Font = New Font("Segoe UI", 11F)
        percentRequested.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        percentRequested.Location = New Point(708, 361)
        percentRequested.Name = "percentRequested"
        percentRequested.Size = New Size(31, 20)
        percentRequested.TabIndex = 35
        percentRequested.Text = "(%)"
        ' 
        ' Panel2
        ' 
        Panel2.AutoScroll = True
        Panel2.Location = New Point(2, 46)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(775, 313)
        Panel2.TabIndex = 45
        ' 
        ' PanelRound6
        ' 
        PanelRound6.BackColor = Color.White
        PanelRound6.Controls.Add(Panel2)
        PanelRound6.Controls.Add(percentRequested)
        PanelRound6.Controls.Add(LabelCompleted)
        PanelRound6.Controls.Add(percentInProgress)
        PanelRound6.Controls.Add(ServiceStatusDistribution)
        PanelRound6.Controls.Add(percentCompleted)
        PanelRound6.Controls.Add(GreenDotComplete)
        PanelRound6.Controls.Add(LblRequested)
        PanelRound6.Controls.Add(OrangeDotProgress)
        PanelRound6.Controls.Add(OrangePending)
        PanelRound6.Controls.Add(LabelProgress)
        PanelRound6.CornerRadius = 12
        PanelRound6.Location = New Point(857, 195)
        PanelRound6.Name = "PanelRound6"
        PanelRound6.Size = New Size(778, 405)
        PanelRound6.TabIndex = 34
        ' 
        ' SubscribersGrowth
        ' 
        SubscribersGrowth.Anchor = AnchorStyles.Top
        SubscribersGrowth.AutoSize = True
        SubscribersGrowth.Font = New Font("Verdana", 11F)
        SubscribersGrowth.ForeColor = Color.Black
        SubscribersGrowth.Location = New Point(27, 15)
        SubscribersGrowth.Name = "SubscribersGrowth"
        SubscribersGrowth.Size = New Size(154, 18)
        SubscribersGrowth.TabIndex = 35
        SubscribersGrowth.Text = "Subscribers Growth"
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.Location = New Point(2, 46)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(775, 313)
        Panel1.TabIndex = 36
        ' 
        ' PanelRound5
        ' 
        PanelRound5.BackColor = Color.White
        PanelRound5.Controls.Add(Panel1)
        PanelRound5.Controls.Add(SubscribersGrowth)
        PanelRound5.CornerRadius = 12
        PanelRound5.Location = New Point(38, 195)
        PanelRound5.Name = "PanelRound5"
        PanelRound5.Size = New Size(778, 405)
        PanelRound5.TabIndex = 33
        ' 
        ' LabelMonthlyRevenue
        ' 
        LabelMonthlyRevenue.Anchor = AnchorStyles.Top
        LabelMonthlyRevenue.AutoSize = True
        LabelMonthlyRevenue.Font = New Font("Verdana", 11F)
        LabelMonthlyRevenue.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        LabelMonthlyRevenue.Location = New Point(27, 12)
        LabelMonthlyRevenue.Name = "LabelMonthlyRevenue"
        LabelMonthlyRevenue.Size = New Size(136, 18)
        LabelMonthlyRevenue.TabIndex = 1
        LabelMonthlyRevenue.Text = "Monthly Revenue"
        ' 
        ' MonthlyRev
        ' 
        MonthlyRev.Anchor = AnchorStyles.Top
        MonthlyRev.Image = CType(resources.GetObject("MonthlyRev.Image"), Image)
        MonthlyRev.Location = New Point(383, 47)
        MonthlyRev.Name = "MonthlyRev"
        MonthlyRev.Size = New Size(45, 48)
        MonthlyRev.SizeMode = PictureBoxSizeMode.Zoom
        MonthlyRev.TabIndex = 6
        MonthlyRev.TabStop = False
        ' 
        ' AmountMonthlyRev
        ' 
        AmountMonthlyRev.Anchor = AnchorStyles.Top
        AmountMonthlyRev.AutoSize = True
        AmountMonthlyRev.Font = New Font("Verdana", 16F)
        AmountMonthlyRev.Location = New Point(27, 47)
        AmountMonthlyRev.Name = "AmountMonthlyRev"
        AmountMonthlyRev.Size = New Size(68, 26)
        AmountMonthlyRev.TabIndex = 8
        AmountMonthlyRev.Text = "0000"
        ' 
        ' PercentMonthlyRev
        ' 
        PercentMonthlyRev.Anchor = AnchorStyles.Top
        PercentMonthlyRev.AutoSize = True
        PercentMonthlyRev.Font = New Font("Segoe UI", 10F)
        PercentMonthlyRev.ForeColor = Color.FromArgb(CByte(0), CByte(201), CByte(80))
        PercentMonthlyRev.Location = New Point(27, 80)
        PercentMonthlyRev.Name = "PercentMonthlyRev"
        PercentMonthlyRev.Size = New Size(87, 19)
        PercentMonthlyRev.TabIndex = 10
        PercentMonthlyRev.Text = "[Placeholder]"
        ' 
        ' PanelRound2
        ' 
        PanelRound2.BackColor = Color.White
        PanelRound2.Controls.Add(PercentMonthlyRev)
        PanelRound2.Controls.Add(AmountMonthlyRev)
        PanelRound2.Controls.Add(MonthlyRev)
        PanelRound2.Controls.Add(LabelMonthlyRevenue)
        PanelRound2.CornerRadius = 12
        PanelRound2.Location = New Point(38, 26)
        PanelRound2.Name = "PanelRound2"
        PanelRound2.Size = New Size(367, 142)
        PanelRound2.TabIndex = 46
        ' 
        ' AdminDashboard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ButtonFace
        Controls.Add(PanelRound3)
        Controls.Add(PanelRound4)
        Controls.Add(PanelRound2)
        Controls.Add(PanelRound1)
        Controls.Add(Panel3)
        Controls.Add(PanelRound12)
        Controls.Add(PanelSubscribersByPlan)
        Controls.Add(PanelRound6)
        Controls.Add(PanelRound5)
        Name = "AdminDashboard"
        Size = New Size(1980, 1886)
        CType(PendingService, ComponentModel.ISupportInitialize).EndInit()
        PanelRound4.ResumeLayout(False)
        PanelRound4.PerformLayout()
        CType(ActiveInstall, ComponentModel.ISupportInitialize).EndInit()
        PanelRound3.ResumeLayout(False)
        PanelRound3.PerformLayout()
        CType(TotalSubs, ComponentModel.ISupportInitialize).EndInit()
        PanelRound1.ResumeLayout(False)
        PanelRound1.PerformLayout()
        PanelBasic.ResumeLayout(False)
        PanelBasic.PerformLayout()
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        PanelStandard.ResumeLayout(False)
        PanelStandard.PerformLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        PanelPremium.ResumeLayout(False)
        PanelPremium.PerformLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        PanelSubscribersByPlan.ResumeLayout(False)
        PanelSubscribersByPlan.PerformLayout()
        CType(OrangePending, ComponentModel.ISupportInitialize).EndInit()
        CType(OrangeDotProgress, ComponentModel.ISupportInitialize).EndInit()
        CType(GreenDotComplete, ComponentModel.ISupportInitialize).EndInit()
        PanelRound6.ResumeLayout(False)
        PanelRound6.PerformLayout()
        PanelRound5.ResumeLayout(False)
        PanelRound5.PerformLayout()
        CType(MonthlyRev, ComponentModel.ISupportInitialize).EndInit()
        PanelRound2.ResumeLayout(False)
        PanelRound2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents LabelReqService As Label
    Friend WithEvents PendingService As PictureBox
    Friend WithEvents AmountPendingServices As Label
    Friend WithEvents PercentPendingService As Label
    Friend WithEvents PanelRound4 As PanelRound
    Friend WithEvents LabelActiveInstallation As Label
    Friend WithEvents ActiveInstall As PictureBox
    Friend WithEvents AmountActiveInstall As Label
    Friend WithEvents PercentActiveInstall As Label
    Friend WithEvents PanelRound3 As PanelRound
    Friend WithEvents LabelTotalSubscribers As Label
    Friend WithEvents TotalSubs As PictureBox
    Friend WithEvents AmountSubscribers As Label
    Friend WithEvents PercentTotalSub As Label
    Friend WithEvents PanelRound1 As PanelRound
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PanelRound12 As PanelRound
    Friend WithEvents PanelBasic As PanelRound
    Friend WithEvents PercentBasic As Label
    Friend WithEvents BasicTotal As Label
    Friend WithEvents AmountBasic As Label
    Friend WithEvents BasicSubscribers As Label
    Friend WithEvents LabelBasic As Label
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PanelStandard As PanelRound
    Friend WithEvents PercentStandard As Label
    Friend WithEvents LabelStandard As Label
    Friend WithEvents TotalStandard As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents AmountStandard As Label
    Friend WithEvents StandardSubscribers As Label
    Friend WithEvents PanelPremium As PanelRound
    Friend WithEvents PercentPremium As Label
    Friend WithEvents TotalPremium As Label
    Friend WithEvents AmountPremium As Label
    Friend WithEvents PremiumSubscribers As Label
    Friend WithEvents LabelPremium As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents LabelSubscribersByPlan As Label
    Friend WithEvents PanelSubscribersByPlan As PanelRound
    Friend WithEvents LabelProgress As Label
    Friend WithEvents OrangePending As PictureBox
    Friend WithEvents OrangeDotProgress As PictureBox
    Friend WithEvents LblRequested As Label
    Friend WithEvents GreenDotComplete As PictureBox
    Friend WithEvents percentCompleted As Label
    Friend WithEvents ServiceStatusDistribution As Label
    Friend WithEvents percentInProgress As Label
    Friend WithEvents LabelCompleted As Label
    Friend WithEvents percentRequested As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PanelRound6 As PanelRound
    Friend WithEvents SubscribersGrowth As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PanelRound5 As PanelRound
    Friend WithEvents LabelMonthlyRevenue As Label
    Friend WithEvents MonthlyRev As PictureBox
    Friend WithEvents AmountMonthlyRev As Label
    Friend WithEvents PercentMonthlyRev As Label
    Friend WithEvents PanelRound2 As PanelRound

End Class
