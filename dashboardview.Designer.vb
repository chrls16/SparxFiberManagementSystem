<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dashboardview
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dashboardview))
        LabelSubscribersPlan = New Label()
        PanelRound7 = New PanelRound()
        PercentBasic = New Label()
        BasicTotal = New Label()
        AmountBasic = New Label()
        BasicSubscribers = New Label()
        LabelBasic = New Label()
        PictureBox6 = New PictureBox()
        PanelRound8 = New PanelRound()
        PercentStandard = New Label()
        LabelStandard = New Label()
        TotalStandard = New Label()
        PictureBox4 = New PictureBox()
        AmountStandard = New Label()
        StandardSubscribers = New Label()
        PanelRound9 = New PanelRound()
        PercentPremium = New Label()
        TotalPremium = New Label()
        AmountPremium = New Label()
        PremiumSubscribers = New Label()
        LabelPremium = New Label()
        PictureBox5 = New PictureBox()
        PanelSubscribersPlan = New PanelRound()
        Panel4 = New Panel()
        Label5 = New Label()
        ServiceStatusDistribution = New Label()
        GreenDotComplete = New PictureBox()
        LabelComplete = New Label()
        OrangeDotProgress = New PictureBox()
        LabelProgress = New Label()
        OrangePending = New PictureBox()
        LblRequested = New Label()
        percentCompleted = New Label()
        percentInprogress = New Label()
        percentRequested = New Label()
        PanelRound6 = New PanelRound()
        Panel2 = New Panel()
        SubscribersGrowth = New Label()
        PanelRound5 = New PanelRound()
        Panel1 = New Panel()
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
        LabelMonthlyRevenue = New Label()
        MonthlyRev = New PictureBox()
        AmountMonthlyRev = New Label()
        PercentMonthlyRev = New Label()
        PanelRound2 = New PanelRound()
        LabelTotalSubscribers = New Label()
        TotalSubs = New PictureBox()
        AmountSubscribers = New Label()
        PercentTotalSub = New Label()
        PanelRound1 = New PanelRound()
        PictureBox3 = New PictureBox()
        PictureBox2 = New PictureBox()
        PictureBox1 = New PictureBox()
        Pending = New Label()
        InProgress = New Label()
        LabelCompleted = New Label()
        LabelStatusDistribution = New Label()
        LabelSubscriberGrowth = New Label()
        LblActiveInstallation = New Label()
        ActiveInstallations = New PictureBox()
        LabelActiveInstall = New Label()
        LabelActive = New Label()
        LblPendingServices = New Label()
        PendingServices = New PictureBox()
        LabelPending = New Label()
        LabelPendingServices = New Label()
        LblTotalSubs = New Label()
        TotalSubscribers = New PictureBox()
        LabelTotalSubs = New Label()
        LastMonthSubs = New Label()
        LblMothlyRev = New Label()
        LabelMonthlyRev = New Label()
        LabelMonthlyRevs = New Label()
        MonthlyRevenue = New PictureBox()
        Panel3 = New Panel()
        PanelRound7.SuspendLayout()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
        PanelRound8.SuspendLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        PanelRound9.SuspendLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        PanelSubscribersPlan.SuspendLayout()
        Panel4.SuspendLayout()
        CType(GreenDotComplete, ComponentModel.ISupportInitialize).BeginInit()
        CType(OrangeDotProgress, ComponentModel.ISupportInitialize).BeginInit()
        CType(OrangePending, ComponentModel.ISupportInitialize).BeginInit()
        PanelRound6.SuspendLayout()
        PanelRound5.SuspendLayout()
        CType(PendingService, ComponentModel.ISupportInitialize).BeginInit()
        PanelRound4.SuspendLayout()
        CType(ActiveInstall, ComponentModel.ISupportInitialize).BeginInit()
        PanelRound3.SuspendLayout()
        CType(MonthlyRev, ComponentModel.ISupportInitialize).BeginInit()
        PanelRound2.SuspendLayout()
        CType(TotalSubs, ComponentModel.ISupportInitialize).BeginInit()
        PanelRound1.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(ActiveInstallations, ComponentModel.ISupportInitialize).BeginInit()
        CType(PendingServices, ComponentModel.ISupportInitialize).BeginInit()
        CType(TotalSubscribers, ComponentModel.ISupportInitialize).BeginInit()
        CType(MonthlyRevenue, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LabelSubscribersPlan
        ' 
        LabelSubscribersPlan.Anchor = AnchorStyles.Top
        LabelSubscribersPlan.AutoSize = True
        LabelSubscribersPlan.Font = New Font("Verdana", 13F)
        LabelSubscribersPlan.ForeColor = Color.Black
        LabelSubscribersPlan.Location = New Point(23, 15)
        LabelSubscribersPlan.Name = "LabelSubscribersPlan"
        LabelSubscribersPlan.Size = New Size(158, 22)
        LabelSubscribersPlan.TabIndex = 11
        LabelSubscribersPlan.Text = "Subscribers Plan"
        ' 
        ' PanelRound7
        ' 
        PanelRound7.Anchor = AnchorStyles.Top
        PanelRound7.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(251))
        PanelRound7.Controls.Add(PercentBasic)
        PanelRound7.Controls.Add(BasicTotal)
        PanelRound7.Controls.Add(AmountBasic)
        PanelRound7.Controls.Add(BasicSubscribers)
        PanelRound7.Controls.Add(LabelBasic)
        PanelRound7.Controls.Add(PictureBox6)
        PanelRound7.CornerRadius = 12
        PanelRound7.ForeColor = SystemColors.ControlText
        PanelRound7.Location = New Point(819, 72)
        PanelRound7.Name = "PanelRound7"
        PanelRound7.Size = New Size(739, 76)
        PanelRound7.TabIndex = 12
        ' 
        ' PercentBasic
        ' 
        PercentBasic.Anchor = AnchorStyles.Top
        PercentBasic.AutoSize = True
        PercentBasic.Font = New Font("Segoe UI", 11F)
        PercentBasic.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        PercentBasic.Location = New Point(620, 41)
        PercentBasic.Name = "PercentBasic"
        PercentBasic.Size = New Size(37, 20)
        PercentBasic.TabIndex = 23
        PercentBasic.Text = "00%"
        ' 
        ' BasicTotal
        ' 
        BasicTotal.Anchor = AnchorStyles.Top
        BasicTotal.AutoSize = True
        BasicTotal.Font = New Font("Segoe UI", 11F)
        BasicTotal.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        BasicTotal.Location = New Point(663, 41)
        BasicTotal.Name = "BasicTotal"
        BasicTotal.Size = New Size(58, 20)
        BasicTotal.TabIndex = 20
        BasicTotal.Text = "of total"
        ' 
        ' AmountBasic
        ' 
        AmountBasic.Anchor = AnchorStyles.Top
        AmountBasic.AutoSize = True
        AmountBasic.Font = New Font("Segoe UI", 11F)
        AmountBasic.ForeColor = Color.Black
        AmountBasic.Location = New Point(609, 16)
        AmountBasic.Name = "AmountBasic"
        AmountBasic.Size = New Size(25, 20)
        AmountBasic.TabIndex = 22
        AmountBasic.Text = "00"
        ' 
        ' BasicSubscribers
        ' 
        BasicSubscribers.Anchor = AnchorStyles.Top
        BasicSubscribers.AutoSize = True
        BasicSubscribers.Font = New Font("Segoe UI", 11F)
        BasicSubscribers.ForeColor = Color.Black
        BasicSubscribers.Location = New Point(652, 16)
        BasicSubscribers.Name = "BasicSubscribers"
        BasicSubscribers.Size = New Size(84, 20)
        BasicSubscribers.TabIndex = 15
        BasicSubscribers.Text = "Subscribers"
        ' 
        ' LabelBasic
        ' 
        LabelBasic.Anchor = AnchorStyles.Top
        LabelBasic.AutoSize = True
        LabelBasic.Font = New Font("Segoe UI", 11F)
        LabelBasic.ForeColor = Color.FromArgb(CByte(54), CByte(65), CByte(83))
        LabelBasic.Location = New Point(59, 33)
        LabelBasic.Name = "LabelBasic"
        LabelBasic.Size = New Size(100, 20)
        LabelBasic.TabIndex = 20
        LabelBasic.Text = "Basic 25Mbps"
        ' 
        ' PictureBox6
        ' 
        PictureBox6.Anchor = AnchorStyles.Top
        PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), Image)
        PictureBox6.Location = New Point(28, 41)
        PictureBox6.Name = "PictureBox6"
        PictureBox6.Size = New Size(12, 12)
        PictureBox6.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox6.TabIndex = 21
        PictureBox6.TabStop = False
        ' 
        ' PanelRound8
        ' 
        PanelRound8.Anchor = AnchorStyles.Top
        PanelRound8.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(251))
        PanelRound8.Controls.Add(PercentStandard)
        PanelRound8.Controls.Add(LabelStandard)
        PanelRound8.Controls.Add(TotalStandard)
        PanelRound8.Controls.Add(PictureBox4)
        PanelRound8.Controls.Add(AmountStandard)
        PanelRound8.Controls.Add(StandardSubscribers)
        PanelRound8.CornerRadius = 12
        PanelRound8.ForeColor = SystemColors.ControlText
        PanelRound8.Location = New Point(0, 133)
        PanelRound8.Name = "PanelRound8"
        PanelRound8.Size = New Size(739, 74)
        PanelRound8.TabIndex = 13
        ' 
        ' PercentStandard
        ' 
        PercentStandard.Anchor = AnchorStyles.Top
        PercentStandard.AutoSize = True
        PercentStandard.Font = New Font("Segoe UI", 11F)
        PercentStandard.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        PercentStandard.Location = New Point(620, 44)
        PercentStandard.Name = "PercentStandard"
        PercentStandard.Size = New Size(37, 20)
        PercentStandard.TabIndex = 27
        PercentStandard.Text = "00%"
        ' 
        ' LabelStandard
        ' 
        LabelStandard.Anchor = AnchorStyles.Top
        LabelStandard.AutoSize = True
        LabelStandard.Font = New Font("Segoe UI", 11F)
        LabelStandard.ForeColor = Color.FromArgb(CByte(54), CByte(65), CByte(83))
        LabelStandard.Location = New Point(59, 27)
        LabelStandard.Name = "LabelStandard"
        LabelStandard.Size = New Size(126, 20)
        LabelStandard.TabIndex = 22
        LabelStandard.Text = "Standard 50Mbps"
        ' 
        ' TotalStandard
        ' 
        TotalStandard.Anchor = AnchorStyles.Top
        TotalStandard.AutoSize = True
        TotalStandard.Font = New Font("Segoe UI", 11F)
        TotalStandard.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        TotalStandard.Location = New Point(665, 44)
        TotalStandard.Name = "TotalStandard"
        TotalStandard.Size = New Size(58, 20)
        TotalStandard.TabIndex = 25
        TotalStandard.Text = "of total"
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Anchor = AnchorStyles.Top
        PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), Image)
        PictureBox4.Location = New Point(28, 35)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(12, 12)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 20
        PictureBox4.TabStop = False
        ' 
        ' AmountStandard
        ' 
        AmountStandard.Anchor = AnchorStyles.Top
        AmountStandard.AutoSize = True
        AmountStandard.Font = New Font("Segoe UI", 11F)
        AmountStandard.ForeColor = Color.Black
        AmountStandard.Location = New Point(609, 10)
        AmountStandard.Name = "AmountStandard"
        AmountStandard.Size = New Size(25, 20)
        AmountStandard.TabIndex = 26
        AmountStandard.Text = "00"
        ' 
        ' StandardSubscribers
        ' 
        StandardSubscribers.Anchor = AnchorStyles.Top
        StandardSubscribers.AutoSize = True
        StandardSubscribers.Font = New Font("Segoe UI", 11F)
        StandardSubscribers.ForeColor = Color.Black
        StandardSubscribers.Location = New Point(652, 10)
        StandardSubscribers.Name = "StandardSubscribers"
        StandardSubscribers.Size = New Size(84, 20)
        StandardSubscribers.TabIndex = 24
        StandardSubscribers.Text = "Subscribers"
        ' 
        ' PanelRound9
        ' 
        PanelRound9.Anchor = AnchorStyles.Top
        PanelRound9.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(251))
        PanelRound9.Controls.Add(PercentPremium)
        PanelRound9.Controls.Add(TotalPremium)
        PanelRound9.Controls.Add(AmountPremium)
        PanelRound9.Controls.Add(PremiumSubscribers)
        PanelRound9.Controls.Add(LabelPremium)
        PanelRound9.Controls.Add(PictureBox5)
        PanelRound9.CornerRadius = 12
        PanelRound9.ForeColor = SystemColors.ControlText
        PanelRound9.Location = New Point(0, 263)
        PanelRound9.Name = "PanelRound9"
        PanelRound9.Size = New Size(739, 74)
        PanelRound9.TabIndex = 14
        ' 
        ' PercentPremium
        ' 
        PercentPremium.Anchor = AnchorStyles.Top
        PercentPremium.AutoSize = True
        PercentPremium.Font = New Font("Segoe UI", 11F)
        PercentPremium.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        PercentPremium.Location = New Point(620, 43)
        PercentPremium.Name = "PercentPremium"
        PercentPremium.Size = New Size(37, 20)
        PercentPremium.TabIndex = 27
        PercentPremium.Text = "00%"
        ' 
        ' TotalPremium
        ' 
        TotalPremium.Anchor = AnchorStyles.Top
        TotalPremium.AutoSize = True
        TotalPremium.Font = New Font("Segoe UI", 11F)
        TotalPremium.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        TotalPremium.Location = New Point(665, 43)
        TotalPremium.Name = "TotalPremium"
        TotalPremium.Size = New Size(58, 20)
        TotalPremium.TabIndex = 25
        TotalPremium.Text = "of total"
        ' 
        ' AmountPremium
        ' 
        AmountPremium.Anchor = AnchorStyles.Top
        AmountPremium.AutoSize = True
        AmountPremium.Font = New Font("Segoe UI", 11F)
        AmountPremium.ForeColor = Color.Black
        AmountPremium.Location = New Point(609, 9)
        AmountPremium.Name = "AmountPremium"
        AmountPremium.Size = New Size(25, 20)
        AmountPremium.TabIndex = 26
        AmountPremium.Text = "00"
        ' 
        ' PremiumSubscribers
        ' 
        PremiumSubscribers.Anchor = AnchorStyles.Top
        PremiumSubscribers.AutoSize = True
        PremiumSubscribers.Font = New Font("Segoe UI", 11F)
        PremiumSubscribers.ForeColor = Color.Black
        PremiumSubscribers.Location = New Point(652, 9)
        PremiumSubscribers.Name = "PremiumSubscribers"
        PremiumSubscribers.Size = New Size(84, 20)
        PremiumSubscribers.TabIndex = 24
        PremiumSubscribers.Text = "Subscribers"
        ' 
        ' LabelPremium
        ' 
        LabelPremium.Anchor = AnchorStyles.Top
        LabelPremium.AutoSize = True
        LabelPremium.Font = New Font("Segoe UI", 11F)
        LabelPremium.ForeColor = Color.FromArgb(CByte(54), CByte(65), CByte(83))
        LabelPremium.Location = New Point(59, 18)
        LabelPremium.Name = "LabelPremium"
        LabelPremium.Size = New Size(133, 20)
        LabelPremium.TabIndex = 21
        LabelPremium.Text = "Premium 100Mbps"
        ' 
        ' PictureBox5
        ' 
        PictureBox5.Anchor = AnchorStyles.Top
        PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), Image)
        PictureBox5.Location = New Point(28, 26)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(12, 12)
        PictureBox5.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox5.TabIndex = 20
        PictureBox5.TabStop = False
        ' 
        ' PanelSubscribersPlan
        ' 
        PanelSubscribersPlan.Anchor = AnchorStyles.Top
        PanelSubscribersPlan.BackColor = Color.White
        PanelSubscribersPlan.Controls.Add(PanelRound7)
        PanelSubscribersPlan.Controls.Add(Panel4)
        PanelSubscribersPlan.Controls.Add(Label5)
        PanelSubscribersPlan.CornerRadius = 12
        PanelSubscribersPlan.Location = New Point(200, 644)
        PanelSubscribersPlan.Name = "PanelSubscribersPlan"
        PanelSubscribersPlan.Size = New Size(1597, 481)
        PanelSubscribersPlan.TabIndex = 7
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(PanelRound8)
        Panel4.Controls.Add(PanelRound9)
        Panel4.Location = New Point(819, 42)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(739, 405)
        Panel4.TabIndex = 16
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Top
        Label5.AutoSize = True
        Label5.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.Black
        Label5.Location = New Point(27, 12)
        Label5.Name = "Label5"
        Label5.Size = New Size(158, 18)
        Label5.TabIndex = 12
        Label5.Text = "Subscriber by Plan"
        ' 
        ' ServiceStatusDistribution
        ' 
        ServiceStatusDistribution.Anchor = AnchorStyles.Top
        ServiceStatusDistribution.AutoSize = True
        ServiceStatusDistribution.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ServiceStatusDistribution.ForeColor = Color.Black
        ServiceStatusDistribution.Location = New Point(28, 15)
        ServiceStatusDistribution.Name = "ServiceStatusDistribution"
        ServiceStatusDistribution.Size = New Size(227, 18)
        ServiceStatusDistribution.TabIndex = 11
        ServiceStatusDistribution.Text = "Service Status Distribution"
        ' 
        ' GreenDotComplete
        ' 
        GreenDotComplete.Anchor = AnchorStyles.Top
        GreenDotComplete.Image = CType(resources.GetObject("GreenDotComplete.Image"), Image)
        GreenDotComplete.Location = New Point(41, 364)
        GreenDotComplete.Name = "GreenDotComplete"
        GreenDotComplete.Size = New Size(12, 12)
        GreenDotComplete.SizeMode = PictureBoxSizeMode.Zoom
        GreenDotComplete.TabIndex = 12
        GreenDotComplete.TabStop = False
        ' 
        ' LabelComplete
        ' 
        LabelComplete.Anchor = AnchorStyles.Top
        LabelComplete.AutoSize = True
        LabelComplete.Font = New Font("Segoe UI", 11F)
        LabelComplete.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        LabelComplete.Location = New Point(59, 361)
        LabelComplete.Name = "LabelComplete"
        LabelComplete.Size = New Size(83, 20)
        LabelComplete.TabIndex = 12
        LabelComplete.Text = "Completed"
        ' 
        ' OrangeDotProgress
        ' 
        OrangeDotProgress.Anchor = AnchorStyles.Top
        OrangeDotProgress.Image = CType(resources.GetObject("OrangeDotProgress.Image"), Image)
        OrangeDotProgress.Location = New Point(322, 364)
        OrangeDotProgress.Name = "OrangeDotProgress"
        OrangeDotProgress.Size = New Size(12, 12)
        OrangeDotProgress.SizeMode = PictureBoxSizeMode.Zoom
        OrangeDotProgress.TabIndex = 13
        OrangeDotProgress.TabStop = False
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
        LabelProgress.TabIndex = 14
        LabelProgress.Text = "In Progress"
        ' 
        ' OrangePending
        ' 
        OrangePending.Anchor = AnchorStyles.Top
        OrangePending.Image = CType(resources.GetObject("OrangePending.Image"), Image)
        OrangePending.Location = New Point(609, 364)
        OrangePending.Name = "OrangePending"
        OrangePending.Size = New Size(12, 12)
        OrangePending.SizeMode = PictureBoxSizeMode.Zoom
        OrangePending.TabIndex = 15
        OrangePending.TabStop = False
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
        LblRequested.TabIndex = 16
        LblRequested.Text = "Requested"
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
        percentCompleted.TabIndex = 17
        percentCompleted.Text = "(%)"
        ' 
        ' percentInprogress
        ' 
        percentInprogress.Anchor = AnchorStyles.Top
        percentInprogress.AutoSize = True
        percentInprogress.Font = New Font("Segoe UI", 11F)
        percentInprogress.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        percentInprogress.Location = New Point(432, 361)
        percentInprogress.Name = "percentInprogress"
        percentInprogress.Size = New Size(31, 20)
        percentInprogress.TabIndex = 18
        percentInprogress.Text = "(%)"
        ' 
        ' percentRequested
        ' 
        percentRequested.Anchor = AnchorStyles.Top
        percentRequested.AutoSize = True
        percentRequested.Font = New Font("Segoe UI", 11F)
        percentRequested.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        percentRequested.Location = New Point(705, 361)
        percentRequested.Name = "percentRequested"
        percentRequested.Size = New Size(31, 20)
        percentRequested.TabIndex = 19
        percentRequested.Text = "(%)"
        ' 
        ' PanelRound6
        ' 
        PanelRound6.Anchor = AnchorStyles.Top
        PanelRound6.BackColor = Color.White
        PanelRound6.Controls.Add(Panel2)
        PanelRound6.Controls.Add(percentRequested)
        PanelRound6.Controls.Add(percentInprogress)
        PanelRound6.Controls.Add(percentCompleted)
        PanelRound6.Controls.Add(LblRequested)
        PanelRound6.Controls.Add(OrangePending)
        PanelRound6.Controls.Add(LabelProgress)
        PanelRound6.Controls.Add(OrangeDotProgress)
        PanelRound6.Controls.Add(LabelComplete)
        PanelRound6.Controls.Add(GreenDotComplete)
        PanelRound6.Controls.Add(ServiceStatusDistribution)
        PanelRound6.CornerRadius = 12
        PanelRound6.Location = New Point(1019, 208)
        PanelRound6.Name = "PanelRound6"
        PanelRound6.Size = New Size(778, 405)
        PanelRound6.TabIndex = 6
        ' 
        ' Panel2
        ' 
        Panel2.AutoScroll = True
        Panel2.Location = New Point(0, 45)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(775, 313)
        Panel2.TabIndex = 12
        ' 
        ' SubscribersGrowth
        ' 
        SubscribersGrowth.Anchor = AnchorStyles.Top
        SubscribersGrowth.AutoSize = True
        SubscribersGrowth.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        SubscribersGrowth.ForeColor = Color.Black
        SubscribersGrowth.Location = New Point(27, 15)
        SubscribersGrowth.Name = "SubscribersGrowth"
        SubscribersGrowth.Size = New Size(163, 18)
        SubscribersGrowth.TabIndex = 10
        SubscribersGrowth.Text = "Subscriber Growtth"
        ' 
        ' PanelRound5
        ' 
        PanelRound5.Anchor = AnchorStyles.Top
        PanelRound5.BackColor = Color.White
        PanelRound5.Controls.Add(Panel1)
        PanelRound5.Controls.Add(SubscribersGrowth)
        PanelRound5.CornerRadius = 12
        PanelRound5.Location = New Point(200, 208)
        PanelRound5.Name = "PanelRound5"
        PanelRound5.Size = New Size(778, 405)
        PanelRound5.TabIndex = 5
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.Location = New Point(3, 45)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(775, 313)
        Panel1.TabIndex = 11
        ' 
        ' LabelReqService
        ' 
        LabelReqService.Anchor = AnchorStyles.Top
        LabelReqService.AutoSize = True
        LabelReqService.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelReqService.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        LabelReqService.Location = New Point(19, 12)
        LabelReqService.Name = "LabelReqService"
        LabelReqService.Size = New Size(168, 18)
        LabelReqService.TabIndex = 3
        LabelReqService.Text = "Requested Services"
        ' 
        ' PendingService
        ' 
        PendingService.Anchor = AnchorStyles.Top
        PendingService.Image = CType(resources.GetObject("PendingService.Image"), Image)
        PendingService.Location = New Point(301, 47)
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
        AmountPendingServices.Location = New Point(19, 47)
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
        PercentPendingService.Location = New Point(19, 80)
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
        PanelRound4.Location = New Point(862, 36)
        PanelRound4.Name = "PanelRound4"
        PanelRound4.Size = New Size(367, 142)
        PanelRound4.TabIndex = 4
        ' 
        ' LabelActiveInstallation
        ' 
        LabelActiveInstallation.Anchor = AnchorStyles.Top
        LabelActiveInstallation.AutoSize = True
        LabelActiveInstallation.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelActiveInstallation.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        LabelActiveInstallation.Location = New Point(21, 12)
        LabelActiveInstallation.Name = "LabelActiveInstallation"
        LabelActiveInstallation.Size = New Size(159, 18)
        LabelActiveInstallation.TabIndex = 2
        LabelActiveInstallation.Text = "Active Installation"
        ' 
        ' ActiveInstall
        ' 
        ActiveInstall.Anchor = AnchorStyles.Top
        ActiveInstall.Image = CType(resources.GetObject("ActiveInstall.Image"), Image)
        ActiveInstall.Location = New Point(298, 47)
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
        AmountActiveInstall.Location = New Point(21, 47)
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
        PercentActiveInstall.Location = New Point(21, 80)
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
        PanelRound3.Location = New Point(1273, 36)
        PanelRound3.Name = "PanelRound3"
        PanelRound3.Size = New Size(367, 142)
        PanelRound3.TabIndex = 3
        ' 
        ' LabelMonthlyRevenue
        ' 
        LabelMonthlyRevenue.Anchor = AnchorStyles.Top
        LabelMonthlyRevenue.AutoSize = True
        LabelMonthlyRevenue.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelMonthlyRevenue.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        LabelMonthlyRevenue.Location = New Point(16, 12)
        LabelMonthlyRevenue.Name = "LabelMonthlyRevenue"
        LabelMonthlyRevenue.Size = New Size(148, 18)
        LabelMonthlyRevenue.TabIndex = 1
        LabelMonthlyRevenue.Text = "Monthly Revenue"
        ' 
        ' MonthlyRev
        ' 
        MonthlyRev.Anchor = AnchorStyles.Top
        MonthlyRev.Image = CType(resources.GetObject("MonthlyRev.Image"), Image)
        MonthlyRev.Location = New Point(300, 47)
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
        AmountMonthlyRev.Location = New Point(16, 47)
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
        PercentMonthlyRev.Location = New Point(16, 80)
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
        PanelRound2.Location = New Point(43, 36)
        PanelRound2.Name = "PanelRound2"
        PanelRound2.Size = New Size(367, 142)
        PanelRound2.TabIndex = 2
        ' 
        ' LabelTotalSubscribers
        ' 
        LabelTotalSubscribers.Anchor = AnchorStyles.Top
        LabelTotalSubscribers.AutoSize = True
        LabelTotalSubscribers.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelTotalSubscribers.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        LabelTotalSubscribers.Location = New Point(22, 12)
        LabelTotalSubscribers.Name = "LabelTotalSubscribers"
        LabelTotalSubscribers.Size = New Size(147, 18)
        LabelTotalSubscribers.TabIndex = 0
        LabelTotalSubscribers.Text = "Total Subscribers"
        ' 
        ' TotalSubs
        ' 
        TotalSubs.Anchor = AnchorStyles.Top
        TotalSubs.Image = CType(resources.GetObject("TotalSubs.Image"), Image)
        TotalSubs.Location = New Point(302, 47)
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
        PanelRound1.Location = New Point(454, 36)
        PanelRound1.Name = "PanelRound1"
        PanelRound1.Size = New Size(367, 142)
        PanelRound1.TabIndex = 1
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Anchor = AnchorStyles.Top
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(345, 301)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(8, 8)
        PictureBox3.TabIndex = 11
        PictureBox3.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Anchor = AnchorStyles.Top
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(184, 298)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(10, 11)
        PictureBox2.TabIndex = 10
        PictureBox2.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(32, 298)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(10, 11)
        PictureBox1.TabIndex = 9
        PictureBox1.TabStop = False
        ' 
        ' Pending
        ' 
        Pending.Anchor = AnchorStyles.Top
        Pending.AutoSize = True
        Pending.Font = New Font("Verdana", 11F)
        Pending.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        Pending.Location = New Point(377, 291)
        Pending.Name = "Pending"
        Pending.Size = New Size(89, 18)
        Pending.TabIndex = 8
        Pending.Text = "Completed"
        ' 
        ' InProgress
        ' 
        InProgress.Anchor = AnchorStyles.Top
        InProgress.AutoSize = True
        InProgress.Font = New Font("Verdana", 11F)
        InProgress.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        InProgress.Location = New Point(200, 291)
        InProgress.Name = "InProgress"
        InProgress.Size = New Size(89, 18)
        InProgress.TabIndex = 7
        InProgress.Text = "Completed"
        ' 
        ' LabelCompleted
        ' 
        LabelCompleted.Anchor = AnchorStyles.Top
        LabelCompleted.AutoSize = True
        LabelCompleted.Font = New Font("Verdana", 11F)
        LabelCompleted.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        LabelCompleted.Location = New Point(48, 291)
        LabelCompleted.Name = "LabelCompleted"
        LabelCompleted.Size = New Size(89, 18)
        LabelCompleted.TabIndex = 6
        LabelCompleted.Text = "Completed"
        ' 
        ' LabelStatusDistribution
        ' 
        LabelStatusDistribution.Anchor = AnchorStyles.Top
        LabelStatusDistribution.AutoSize = True
        LabelStatusDistribution.Font = New Font("Verdana", 11F)
        LabelStatusDistribution.Location = New Point(19, 11)
        LabelStatusDistribution.Name = "LabelStatusDistribution"
        LabelStatusDistribution.Size = New Size(203, 18)
        LabelStatusDistribution.TabIndex = 1
        LabelStatusDistribution.Text = "Service Status Distribution"
        ' 
        ' LabelSubscriberGrowth
        ' 
        LabelSubscriberGrowth.Anchor = AnchorStyles.Top
        LabelSubscriberGrowth.AutoSize = True
        LabelSubscriberGrowth.Font = New Font("Verdana", 11F)
        LabelSubscriberGrowth.Location = New Point(20, 11)
        LabelSubscriberGrowth.Name = "LabelSubscriberGrowth"
        LabelSubscriberGrowth.Size = New Size(146, 18)
        LabelSubscriberGrowth.TabIndex = 0
        LabelSubscriberGrowth.Text = "Subscriber Growth"
        ' 
        ' LblActiveInstallation
        ' 
        LblActiveInstallation.Anchor = AnchorStyles.Top
        LblActiveInstallation.AutoSize = True
        LblActiveInstallation.Font = New Font("Verdana", 11F)
        LblActiveInstallation.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        LblActiveInstallation.Location = New Point(19, 9)
        LblActiveInstallation.Name = "LblActiveInstallation"
        LblActiveInstallation.Size = New Size(146, 18)
        LblActiveInstallation.TabIndex = 2
        LblActiveInstallation.Text = "Active Installations"
        ' 
        ' ActiveInstallations
        ' 
        ActiveInstallations.Anchor = AnchorStyles.Top
        ActiveInstallations.Image = CType(resources.GetObject("ActiveInstallations.Image"), Image)
        ActiveInstallations.Location = New Point(183, 50)
        ActiveInstallations.Name = "ActiveInstallations"
        ActiveInstallations.Size = New Size(45, 48)
        ActiveInstallations.SizeMode = PictureBoxSizeMode.Zoom
        ActiveInstallations.TabIndex = 3
        ActiveInstallations.TabStop = False
        ' 
        ' LabelActiveInstall
        ' 
        LabelActiveInstall.Anchor = AnchorStyles.Top
        LabelActiveInstall.AutoSize = True
        LabelActiveInstall.Font = New Font("Verdana", 20F)
        LabelActiveInstall.Location = New Point(19, 50)
        LabelActiveInstall.Name = "LabelActiveInstall"
        LabelActiveInstall.Size = New Size(82, 32)
        LabelActiveInstall.TabIndex = 4
        LabelActiveInstall.Text = "0000"
        ' 
        ' LabelActive
        ' 
        LabelActive.Anchor = AnchorStyles.Top
        LabelActive.AutoSize = True
        LabelActive.Font = New Font("Verdana", 9F)
        LabelActive.ForeColor = Color.FromArgb(CByte(0), CByte(186), CByte(74))
        LabelActive.Location = New Point(19, 86)
        LabelActive.Name = "LabelActive"
        LabelActive.Size = New Size(90, 14)
        LabelActive.TabIndex = 5
        LabelActive.Text = "[Placeholder]"
        ' 
        ' LblPendingServices
        ' 
        LblPendingServices.Anchor = AnchorStyles.Top
        LblPendingServices.AutoSize = True
        LblPendingServices.Font = New Font("Verdana", 11F)
        LblPendingServices.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        LblPendingServices.Location = New Point(19, 9)
        LblPendingServices.Name = "LblPendingServices"
        LblPendingServices.Size = New Size(132, 18)
        LblPendingServices.TabIndex = 3
        LblPendingServices.Text = "Pending Services"
        ' 
        ' PendingServices
        ' 
        PendingServices.Anchor = AnchorStyles.Top
        PendingServices.Image = CType(resources.GetObject("PendingServices.Image"), Image)
        PendingServices.Location = New Point(181, 50)
        PendingServices.Name = "PendingServices"
        PendingServices.Size = New Size(45, 48)
        PendingServices.SizeMode = PictureBoxSizeMode.Zoom
        PendingServices.TabIndex = 4
        PendingServices.TabStop = False
        ' 
        ' LabelPending
        ' 
        LabelPending.Anchor = AnchorStyles.Top
        LabelPending.AutoSize = True
        LabelPending.Font = New Font("Verdana", 20F)
        LabelPending.Location = New Point(19, 50)
        LabelPending.Name = "LabelPending"
        LabelPending.Size = New Size(82, 32)
        LabelPending.TabIndex = 5
        LabelPending.Text = "0000"
        ' 
        ' LabelPendingServices
        ' 
        LabelPendingServices.Anchor = AnchorStyles.Top
        LabelPendingServices.AutoSize = True
        LabelPendingServices.Font = New Font("Verdana", 9F)
        LabelPendingServices.ForeColor = Color.FromArgb(CByte(0), CByte(186), CByte(74))
        LabelPendingServices.Location = New Point(19, 86)
        LabelPendingServices.Name = "LabelPendingServices"
        LabelPendingServices.Size = New Size(90, 14)
        LabelPendingServices.TabIndex = 6
        LabelPendingServices.Text = "[Placeholder]"
        ' 
        ' LblTotalSubs
        ' 
        LblTotalSubs.Anchor = AnchorStyles.Top
        LblTotalSubs.AutoSize = True
        LblTotalSubs.Font = New Font("Verdana", 11F)
        LblTotalSubs.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        LblTotalSubs.Location = New Point(20, 9)
        LblTotalSubs.Name = "LblTotalSubs"
        LblTotalSubs.Size = New Size(133, 18)
        LblTotalSubs.TabIndex = 0
        LblTotalSubs.Text = "Total Subscribers"
        ' 
        ' TotalSubscribers
        ' 
        TotalSubscribers.Anchor = AnchorStyles.Top
        TotalSubscribers.Image = CType(resources.GetObject("TotalSubscribers.Image"), Image)
        TotalSubscribers.Location = New Point(181, 50)
        TotalSubscribers.Name = "TotalSubscribers"
        TotalSubscribers.Size = New Size(45, 50)
        TotalSubscribers.SizeMode = PictureBoxSizeMode.Zoom
        TotalSubscribers.TabIndex = 1
        TotalSubscribers.TabStop = False
        ' 
        ' LabelTotalSubs
        ' 
        LabelTotalSubs.Anchor = AnchorStyles.Top
        LabelTotalSubs.AutoSize = True
        LabelTotalSubs.Font = New Font("Verdana", 20F)
        LabelTotalSubs.Location = New Point(20, 50)
        LabelTotalSubs.Name = "LabelTotalSubs"
        LabelTotalSubs.Size = New Size(82, 32)
        LabelTotalSubs.TabIndex = 2
        LabelTotalSubs.Text = "0000"
        ' 
        ' LastMonthSubs
        ' 
        LastMonthSubs.Anchor = AnchorStyles.Top
        LastMonthSubs.AutoSize = True
        LastMonthSubs.Font = New Font("Verdana", 9F)
        LastMonthSubs.ForeColor = Color.FromArgb(CByte(0), CByte(186), CByte(74))
        LastMonthSubs.Location = New Point(20, 86)
        LastMonthSubs.Name = "LastMonthSubs"
        LastMonthSubs.Size = New Size(90, 14)
        LastMonthSubs.TabIndex = 3
        LastMonthSubs.Text = "[Placeholder]"
        ' 
        ' LblMothlyRev
        ' 
        LblMothlyRev.Anchor = AnchorStyles.Top
        LblMothlyRev.AutoSize = True
        LblMothlyRev.Font = New Font("Verdana", 11F)
        LblMothlyRev.ForeColor = Color.FromArgb(CByte(74), CByte(85), CByte(101))
        LblMothlyRev.Location = New Point(18, 9)
        LblMothlyRev.Name = "LblMothlyRev"
        LblMothlyRev.Size = New Size(136, 18)
        LblMothlyRev.TabIndex = 1
        LblMothlyRev.Text = "Monthly Revenue"
        ' 
        ' LabelMonthlyRev
        ' 
        LabelMonthlyRev.Anchor = AnchorStyles.Top
        LabelMonthlyRev.AutoSize = True
        LabelMonthlyRev.Font = New Font("Verdana", 20F)
        LabelMonthlyRev.Location = New Point(18, 50)
        LabelMonthlyRev.Name = "LabelMonthlyRev"
        LabelMonthlyRev.Size = New Size(82, 32)
        LabelMonthlyRev.TabIndex = 3
        LabelMonthlyRev.Text = "0000"
        ' 
        ' LabelMonthlyRevs
        ' 
        LabelMonthlyRevs.Anchor = AnchorStyles.Top
        LabelMonthlyRevs.AutoSize = True
        LabelMonthlyRevs.Font = New Font("Verdana", 9F)
        LabelMonthlyRevs.ForeColor = Color.FromArgb(CByte(0), CByte(186), CByte(74))
        LabelMonthlyRevs.Location = New Point(18, 86)
        LabelMonthlyRevs.Name = "LabelMonthlyRevs"
        LabelMonthlyRevs.Size = New Size(90, 14)
        LabelMonthlyRevs.TabIndex = 4
        LabelMonthlyRevs.Text = "[Placeholder]"
        ' 
        ' MonthlyRevenue
        ' 
        MonthlyRevenue.Anchor = AnchorStyles.Top
        MonthlyRevenue.Image = CType(resources.GetObject("MonthlyRevenue.Image"), Image)
        MonthlyRevenue.Location = New Point(180, 50)
        MonthlyRevenue.Name = "MonthlyRevenue"
        MonthlyRevenue.Size = New Size(46, 48)
        MonthlyRevenue.SizeMode = PictureBoxSizeMode.Zoom
        MonthlyRevenue.TabIndex = 2
        MonthlyRevenue.TabStop = False
        ' 
        ' Panel3
        ' 
        Panel3.Location = New Point(200, 686)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(667, 405)
        Panel3.TabIndex = 15
        ' 
        ' dashboardview
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.Control
        Controls.Add(Panel3)
        Controls.Add(PanelRound2)
        Controls.Add(PanelRound3)
        Controls.Add(PanelRound1)
        Controls.Add(PanelRound4)
        Controls.Add(PanelSubscribersPlan)
        Controls.Add(PanelRound6)
        Controls.Add(PanelRound5)
        Name = "dashboardview"
        Size = New Size(1980, 1576)
        PanelRound7.ResumeLayout(False)
        PanelRound7.PerformLayout()
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        PanelRound8.ResumeLayout(False)
        PanelRound8.PerformLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        PanelRound9.ResumeLayout(False)
        PanelRound9.PerformLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        PanelSubscribersPlan.ResumeLayout(False)
        PanelSubscribersPlan.PerformLayout()
        Panel4.ResumeLayout(False)
        CType(GreenDotComplete, ComponentModel.ISupportInitialize).EndInit()
        CType(OrangeDotProgress, ComponentModel.ISupportInitialize).EndInit()
        CType(OrangePending, ComponentModel.ISupportInitialize).EndInit()
        PanelRound6.ResumeLayout(False)
        PanelRound6.PerformLayout()
        PanelRound5.ResumeLayout(False)
        PanelRound5.PerformLayout()
        CType(PendingService, ComponentModel.ISupportInitialize).EndInit()
        PanelRound4.ResumeLayout(False)
        PanelRound4.PerformLayout()
        CType(ActiveInstall, ComponentModel.ISupportInitialize).EndInit()
        PanelRound3.ResumeLayout(False)
        PanelRound3.PerformLayout()
        CType(MonthlyRev, ComponentModel.ISupportInitialize).EndInit()
        PanelRound2.ResumeLayout(False)
        PanelRound2.PerformLayout()
        CType(TotalSubs, ComponentModel.ISupportInitialize).EndInit()
        PanelRound1.ResumeLayout(False)
        PanelRound1.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(ActiveInstallations, ComponentModel.ISupportInitialize).EndInit()
        CType(PendingServices, ComponentModel.ISupportInitialize).EndInit()
        CType(TotalSubscribers, ComponentModel.ISupportInitialize).EndInit()
        CType(MonthlyRevenue, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PnaelMonthlyRevenue As PanelRound
    Friend WithEvents PnaelTotalSubscribers As PanelRound
    Friend WithEvents PanelPendingServices As PanelRound
    Friend WithEvents PnaelActiveInstallation As PanelRound
    Friend WithEvents PanelSbscriberGrowth As PanelRound
    Friend WithEvents PanelStatusDistribution As PanelRound
    Friend WithEvents LabelSubscribersPlan As Label
    Friend WithEvents PanelRound7 As PanelRound
    Friend WithEvents PercentBasic As Label
    Friend WithEvents BasicTotal As Label
    Friend WithEvents AmountBasic As Label
    Friend WithEvents BasicSubscribers As Label
    Friend WithEvents LabelBasic As Label
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PanelRound8 As PanelRound
    Friend WithEvents PercentStandard As Label
    Friend WithEvents LabelStandard As Label
    Friend WithEvents TotalStandard As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents AmountStandard As Label
    Friend WithEvents StandardSubscribers As Label
    Friend WithEvents PanelRound9 As PanelRound
    Friend WithEvents PercentPremium As Label
    Friend WithEvents TotalPremium As Label
    Friend WithEvents AmountPremium As Label
    Friend WithEvents PremiumSubscribers As Label
    Friend WithEvents LabelPremium As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PanelSubscribersPlan As PanelRound
    Friend WithEvents ServiceStatusDistribution As Label
    Friend WithEvents GreenDotComplete As PictureBox
    Friend WithEvents LabelComplete As Label
    Friend WithEvents OrangeDotProgress As PictureBox
    Friend WithEvents LabelProgress As Label
    Friend WithEvents OrangePending As PictureBox
    Friend WithEvents LblRequested As Label
    Friend WithEvents percentCompleted As Label
    Friend WithEvents percentInprogress As Label
    Friend WithEvents percentRequested As Label
    Friend WithEvents PanelRound6 As PanelRound
    Friend WithEvents SubscribersGrowth As Label
    Friend WithEvents PanelRound5 As PanelRound
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
    Friend WithEvents LabelMonthlyRevenue As Label
    Friend WithEvents MonthlyRev As PictureBox
    Friend WithEvents AmountMonthlyRev As Label
    Friend WithEvents PercentMonthlyRev As Label
    Friend WithEvents PanelRound2 As PanelRound
    Friend WithEvents LabelTotalSubscribers As Label
    Friend WithEvents TotalSubs As PictureBox
    Friend WithEvents AmountSubscribers As Label
    Friend WithEvents PercentTotalSub As Label
    Friend WithEvents PanelRound1 As PanelRound
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Pending As Label
    Friend WithEvents InProgress As Label
    Friend WithEvents LabelCompleted As Label
    Friend WithEvents LabelStatusDistribution As Label
    Friend WithEvents LabelSubscriberGrowth As Label
    Friend WithEvents LblActiveInstallation As Label
    Friend WithEvents ActiveInstallations As PictureBox
    Friend WithEvents LabelActiveInstall As Label
    Friend WithEvents LabelActive As Label
    Friend WithEvents LblPendingServices As Label
    Friend WithEvents PendingServices As PictureBox
    Friend WithEvents LabelPending As Label
    Friend WithEvents LabelPendingServices As Label
    Friend WithEvents LblTotalSubs As Label
    Friend WithEvents TotalSubscribers As PictureBox
    Friend WithEvents LabelTotalSubs As Label
    Friend WithEvents LastMonthSubs As Label
    Friend WithEvents LblMothlyRev As Label
    Friend WithEvents LabelMonthlyRev As Label
    Friend WithEvents LabelMonthlyRevs As Label
    Friend WithEvents MonthlyRevenue As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel4 As Panel

End Class

