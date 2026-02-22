<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class plansview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(plansview))
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        BtnPlansExport = New Button()
        PanelFilters = New PanelRound()
        cbDateRange = New ComboBox()
        cbAccountStatus = New ComboBox()
        lblAccountStatus = New Label()
        lblDateRange = New Label()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        HeaderPlanSummaryReport = New Label()
        PanelActivePlans = New PanelRound()
        IconActivePlans = New PictureBox()
        ValueMonthlyRevenueActivePlans = New Label()
        lblActivePlans = New Label()
        PanelMonthlyRevenue = New PanelRound()
        IconMonthlyRevenue = New PictureBox()
        ValueMonthlyRevenue = New Label()
        lblMonthlyRevenue = New Label()
        PanelAvgRevenuePerPlan = New PanelRound()
        IconAvgRevenue = New PictureBox()
        ValueRevenuePlan = New Label()
        LabelRevenuePlan = New Label()
        PanelTotalSubscribers = New PanelRound()
        IconTotalSubscribers = New PictureBox()
        ValueTotalSubscribers = New Label()
        LabelTotalSubscribers = New Label()
        PanelMonthlySubscriberGrowth = New PanelRound()
        Panel2 = New Panel()
        MonthlySubscriberGrowth = New Label()
        PanelPlanSummaryDetails = New PanelRound()
        DataGridPlanSummaryDetails = New DataGridView()
        lblPlanSummaryDetails = New Label()
        PanelTopPerformingShool = New PanelRound()
        PanelPremium = New PanelRound()
        MonthlyRevenue3rd = New Label()
        TotalSubscribers3rd = New Label()
        PlantType3rd = New Label()
        PanelNumber3 = New PanelRound()
        LabelNumber3 = New Label()
        PanelStandard = New PanelRound()
        MonthlyRevenue2nd = New Label()
        TotalSubscribers2nd = New Label()
        PlantType2nd = New Label()
        PanelNumber2 = New PanelRound()
        LabelNumber2 = New Label()
        Panelbasic = New PanelRound()
        MonthlyRevenue1st = New Label()
        TotalSubscribers1st = New Label()
        PlanType1st = New Label()
        PanelNumber1 = New PanelRound()
        labelNumber1 = New Label()
        LabelTopPerformingPlans = New Label()
        PanelRound2 = New PanelRound()
        PanelPlanMetrics = New PanelRound()
        PanelRound4 = New PanelRound()
        AverageARPU = New Label()
        LabelAverageARPU = New Label()
        PanelRound5 = New PanelRound()
        RetentionRate = New Label()
        LabelRetentionRate = New Label()
        PanelRound3 = New PanelRound()
        HighestRevenue = New Label()
        LabelHighestRevenue = New Label()
        PanelRound1 = New PanelRound()
        MostPopularPlan = New Label()
        LabelMostPopularPlan = New Label()
        PlanMetrics = New Label()
        lblSubscriberDistributionbyPlan = New Label()
        Panel1 = New Panel()
        PanelSubsPlanType = New PanelRound()
        PlanType = New DataGridViewTextBoxColumn()
        MonthlyRate = New DataGridViewTextBoxColumn()
        TotalSusbcribers = New DataGridViewTextBoxColumn()
        Active = New DataGridViewTextBoxColumn()
        Suspended = New DataGridViewTextBoxColumn()
        MonthlyRevenue = New DataGridViewTextBoxColumn()
        MarketShare = New DataGridViewTextBoxColumn()
        PanelFilters.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        PanelActivePlans.SuspendLayout()
        CType(IconActivePlans, ComponentModel.ISupportInitialize).BeginInit()
        PanelMonthlyRevenue.SuspendLayout()
        CType(IconMonthlyRevenue, ComponentModel.ISupportInitialize).BeginInit()
        PanelAvgRevenuePerPlan.SuspendLayout()
        CType(IconAvgRevenue, ComponentModel.ISupportInitialize).BeginInit()
        PanelTotalSubscribers.SuspendLayout()
        CType(IconTotalSubscribers, ComponentModel.ISupportInitialize).BeginInit()
        PanelMonthlySubscriberGrowth.SuspendLayout()
        PanelPlanSummaryDetails.SuspendLayout()
        CType(DataGridPlanSummaryDetails, ComponentModel.ISupportInitialize).BeginInit()
        PanelTopPerformingShool.SuspendLayout()
        PanelPremium.SuspendLayout()
        PanelNumber3.SuspendLayout()
        PanelStandard.SuspendLayout()
        PanelNumber2.SuspendLayout()
        Panelbasic.SuspendLayout()
        PanelNumber1.SuspendLayout()
        PanelPlanMetrics.SuspendLayout()
        PanelRound4.SuspendLayout()
        PanelRound5.SuspendLayout()
        PanelRound3.SuspendLayout()
        PanelRound1.SuspendLayout()
        PanelSubsPlanType.SuspendLayout()
        SuspendLayout()
        ' 
        ' BtnPlansExport
        ' 
        BtnPlansExport.BackColor = Color.FromArgb(CByte(21), CByte(93), CByte(252))
        BtnPlansExport.FlatAppearance.BorderSize = 0
        BtnPlansExport.FlatStyle = FlatStyle.Flat
        BtnPlansExport.Font = New Font("Segoe UI", 12F)
        BtnPlansExport.ForeColor = Color.Transparent
        BtnPlansExport.ImageAlign = ContentAlignment.MiddleLeft
        BtnPlansExport.Location = New Point(1477, 13)
        BtnPlansExport.Margin = New Padding(3, 2, 3, 2)
        BtnPlansExport.Name = "BtnPlansExport"
        BtnPlansExport.Padding = New Padding(18, 0, 0, 0)
        BtnPlansExport.Size = New Size(161, 31)
        BtnPlansExport.TabIndex = 49
        BtnPlansExport.Text = "Export Report"
        BtnPlansExport.TextAlign = ContentAlignment.MiddleRight
        BtnPlansExport.UseVisualStyleBackColor = False
        ' 
        ' PanelFilters
        ' 
        PanelFilters.BackColor = Color.White
        PanelFilters.Controls.Add(cbDateRange)
        PanelFilters.Controls.Add(cbAccountStatus)
        PanelFilters.Controls.Add(lblAccountStatus)
        PanelFilters.Controls.Add(lblDateRange)
        PanelFilters.Controls.Add(Label1)
        PanelFilters.Controls.Add(PictureBox1)
        PanelFilters.CornerRadius = 12
        PanelFilters.Location = New Point(42, 58)
        PanelFilters.Name = "PanelFilters"
        PanelFilters.Size = New Size(1597, 165)
        PanelFilters.TabIndex = 48
        ' 
        ' cbDateRange
        ' 
        cbDateRange.BackColor = Color.WhiteSmoke
        cbDateRange.DropDownStyle = ComboBoxStyle.DropDownList
        cbDateRange.Font = New Font("Segoe UI", 14F)
        cbDateRange.ForeColor = SystemColors.WindowText
        cbDateRange.FormattingEnabled = True
        cbDateRange.Location = New Point(22, 93)
        cbDateRange.MinimumSize = New Size(193, 0)
        cbDateRange.Name = "cbDateRange"
        cbDateRange.Size = New Size(308, 33)
        cbDateRange.TabIndex = 15
        ' 
        ' cbAccountStatus
        ' 
        cbAccountStatus.BackColor = Color.WhiteSmoke
        cbAccountStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cbAccountStatus.Font = New Font("Segoe UI", 14F)
        cbAccountStatus.ForeColor = SystemColors.WindowText
        cbAccountStatus.FormattingEnabled = True
        cbAccountStatus.Location = New Point(367, 93)
        cbAccountStatus.MinimumSize = New Size(193, 0)
        cbAccountStatus.Name = "cbAccountStatus"
        cbAccountStatus.Size = New Size(308, 33)
        cbAccountStatus.TabIndex = 14
        ' 
        ' lblAccountStatus
        ' 
        lblAccountStatus.AutoSize = True
        lblAccountStatus.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        lblAccountStatus.Location = New Point(367, 69)
        lblAccountStatus.Name = "lblAccountStatus"
        lblAccountStatus.Size = New Size(120, 21)
        lblAccountStatus.TabIndex = 13
        lblAccountStatus.Text = "Account Status"
        ' 
        ' lblDateRange
        ' 
        lblDateRange.AutoSize = True
        lblDateRange.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        lblDateRange.Location = New Point(22, 69)
        lblDateRange.Name = "lblDateRange"
        lblDateRange.Size = New Size(94, 21)
        lblDateRange.TabIndex = 7
        lblDateRange.Text = "Date Range"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Verdana", 12F)
        Label1.Location = New Point(51, 14)
        Label1.Name = "Label1"
        Label1.Size = New Size(59, 18)
        Label1.TabIndex = 3
        Label1.Text = "Filters"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(22, 10)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(24, 24)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' HeaderPlanSummaryReport
        ' 
        HeaderPlanSummaryReport.AutoSize = True
        HeaderPlanSummaryReport.Font = New Font("Segoe UI Semibold", 15F, FontStyle.Bold)
        HeaderPlanSummaryReport.Location = New Point(42, 16)
        HeaderPlanSummaryReport.Name = "HeaderPlanSummaryReport"
        HeaderPlanSummaryReport.Size = New Size(220, 28)
        HeaderPlanSummaryReport.TabIndex = 47
        HeaderPlanSummaryReport.Text = "Plans Summary Report"
        ' 
        ' PanelActivePlans
        ' 
        PanelActivePlans.BackColor = Color.White
        PanelActivePlans.Controls.Add(IconActivePlans)
        PanelActivePlans.Controls.Add(ValueMonthlyRevenueActivePlans)
        PanelActivePlans.Controls.Add(lblActivePlans)
        PanelActivePlans.CornerRadius = 12
        PanelActivePlans.Location = New Point(861, 259)
        PanelActivePlans.Name = "PanelActivePlans"
        PanelActivePlans.Size = New Size(367, 167)
        PanelActivePlans.TabIndex = 53
        ' 
        ' IconActivePlans
        ' 
        IconActivePlans.Location = New Point(290, 59)
        IconActivePlans.Name = "IconActivePlans"
        IconActivePlans.Size = New Size(48, 50)
        IconActivePlans.SizeMode = PictureBoxSizeMode.Zoom
        IconActivePlans.TabIndex = 14
        IconActivePlans.TabStop = False
        ' 
        ' ValueMonthlyRevenueActivePlans
        ' 
        ValueMonthlyRevenueActivePlans.AutoSize = True
        ValueMonthlyRevenueActivePlans.Font = New Font("Segoe UI Semibold", 22F, FontStyle.Bold)
        ValueMonthlyRevenueActivePlans.ForeColor = Color.FromArgb(CByte(245), CByte(73), CByte(0))
        ValueMonthlyRevenueActivePlans.Location = New Point(28, 89)
        ValueMonthlyRevenueActivePlans.Name = "ValueMonthlyRevenueActivePlans"
        ValueMonthlyRevenueActivePlans.Size = New Size(52, 41)
        ValueMonthlyRevenueActivePlans.TabIndex = 13
        ValueMonthlyRevenueActivePlans.Text = "00"
        ' 
        ' lblActivePlans
        ' 
        lblActivePlans.AutoSize = True
        lblActivePlans.Font = New Font("Verdana", 12F)
        lblActivePlans.ForeColor = SystemColors.ControlDarkDark
        lblActivePlans.Location = New Point(28, 48)
        lblActivePlans.Name = "lblActivePlans"
        lblActivePlans.Size = New Size(108, 18)
        lblActivePlans.TabIndex = 12
        lblActivePlans.Text = "Active Plans"
        ' 
        ' PanelMonthlyRevenue
        ' 
        PanelMonthlyRevenue.BackColor = Color.White
        PanelMonthlyRevenue.Controls.Add(IconMonthlyRevenue)
        PanelMonthlyRevenue.Controls.Add(ValueMonthlyRevenue)
        PanelMonthlyRevenue.Controls.Add(lblMonthlyRevenue)
        PanelMonthlyRevenue.CornerRadius = 12
        PanelMonthlyRevenue.Location = New Point(452, 259)
        PanelMonthlyRevenue.Name = "PanelMonthlyRevenue"
        PanelMonthlyRevenue.Size = New Size(367, 167)
        PanelMonthlyRevenue.TabIndex = 52
        ' 
        ' IconMonthlyRevenue
        ' 
        IconMonthlyRevenue.Location = New Point(290, 59)
        IconMonthlyRevenue.Name = "IconMonthlyRevenue"
        IconMonthlyRevenue.Size = New Size(48, 50)
        IconMonthlyRevenue.SizeMode = PictureBoxSizeMode.Zoom
        IconMonthlyRevenue.TabIndex = 13
        IconMonthlyRevenue.TabStop = False
        ' 
        ' ValueMonthlyRevenue
        ' 
        ValueMonthlyRevenue.AutoSize = True
        ValueMonthlyRevenue.Font = New Font("Segoe UI Semibold", 22F, FontStyle.Bold)
        ValueMonthlyRevenue.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        ValueMonthlyRevenue.Location = New Point(28, 89)
        ValueMonthlyRevenue.Name = "ValueMonthlyRevenue"
        ValueMonthlyRevenue.Size = New Size(78, 41)
        ValueMonthlyRevenue.TabIndex = 12
        ValueMonthlyRevenue.Text = "₱ 00"
        ' 
        ' lblMonthlyRevenue
        ' 
        lblMonthlyRevenue.AutoSize = True
        lblMonthlyRevenue.Font = New Font("Verdana", 12F)
        lblMonthlyRevenue.ForeColor = SystemColors.ControlDarkDark
        lblMonthlyRevenue.Location = New Point(28, 48)
        lblMonthlyRevenue.Name = "lblMonthlyRevenue"
        lblMonthlyRevenue.Size = New Size(148, 18)
        lblMonthlyRevenue.TabIndex = 11
        lblMonthlyRevenue.Text = "Monthly Revenue"
        ' 
        ' PanelAvgRevenuePerPlan
        ' 
        PanelAvgRevenuePerPlan.BackColor = Color.White
        PanelAvgRevenuePerPlan.Controls.Add(IconAvgRevenue)
        PanelAvgRevenuePerPlan.Controls.Add(ValueRevenuePlan)
        PanelAvgRevenuePerPlan.Controls.Add(LabelRevenuePlan)
        PanelAvgRevenuePerPlan.CornerRadius = 12
        PanelAvgRevenuePerPlan.Location = New Point(1272, 259)
        PanelAvgRevenuePerPlan.Name = "PanelAvgRevenuePerPlan"
        PanelAvgRevenuePerPlan.Size = New Size(367, 167)
        PanelAvgRevenuePerPlan.TabIndex = 51
        ' 
        ' IconAvgRevenue
        ' 
        IconAvgRevenue.Location = New Point(290, 59)
        IconAvgRevenue.Name = "IconAvgRevenue"
        IconAvgRevenue.Size = New Size(48, 50)
        IconAvgRevenue.SizeMode = PictureBoxSizeMode.Zoom
        IconAvgRevenue.TabIndex = 15
        IconAvgRevenue.TabStop = False
        ' 
        ' ValueRevenuePlan
        ' 
        ValueRevenuePlan.AutoSize = True
        ValueRevenuePlan.Font = New Font("Segoe UI Semibold", 22F, FontStyle.Bold)
        ValueRevenuePlan.ForeColor = Color.FromArgb(CByte(152), CByte(26), CByte(250))
        ValueRevenuePlan.Location = New Point(28, 89)
        ValueRevenuePlan.Name = "ValueRevenuePlan"
        ValueRevenuePlan.Size = New Size(78, 41)
        ValueRevenuePlan.TabIndex = 14
        ValueRevenuePlan.Text = "₱ 00"
        ' 
        ' LabelRevenuePlan
        ' 
        LabelRevenuePlan.AutoEllipsis = True
        LabelRevenuePlan.AutoSize = True
        LabelRevenuePlan.Font = New Font("Verdana", 12F)
        LabelRevenuePlan.ForeColor = SystemColors.ControlDarkDark
        LabelRevenuePlan.Location = New Point(28, 48)
        LabelRevenuePlan.Name = "LabelRevenuePlan"
        LabelRevenuePlan.Size = New Size(187, 18)
        LabelRevenuePlan.TabIndex = 13
        LabelRevenuePlan.Text = "Avg Revenue per Plan"
        ' 
        ' PanelTotalSubscribers
        ' 
        PanelTotalSubscribers.BackColor = Color.White
        PanelTotalSubscribers.Controls.Add(IconTotalSubscribers)
        PanelTotalSubscribers.Controls.Add(ValueTotalSubscribers)
        PanelTotalSubscribers.Controls.Add(LabelTotalSubscribers)
        PanelTotalSubscribers.CornerRadius = 12
        PanelTotalSubscribers.Location = New Point(42, 259)
        PanelTotalSubscribers.Name = "PanelTotalSubscribers"
        PanelTotalSubscribers.Size = New Size(367, 167)
        PanelTotalSubscribers.TabIndex = 50
        ' 
        ' IconTotalSubscribers
        ' 
        IconTotalSubscribers.Location = New Point(290, 59)
        IconTotalSubscribers.Name = "IconTotalSubscribers"
        IconTotalSubscribers.Size = New Size(48, 50)
        IconTotalSubscribers.SizeMode = PictureBoxSizeMode.Zoom
        IconTotalSubscribers.TabIndex = 12
        IconTotalSubscribers.TabStop = False
        ' 
        ' ValueTotalSubscribers
        ' 
        ValueTotalSubscribers.AutoSize = True
        ValueTotalSubscribers.Font = New Font("Segoe UI Semibold", 22F, FontStyle.Bold)
        ValueTotalSubscribers.Location = New Point(28, 89)
        ValueTotalSubscribers.Name = "ValueTotalSubscribers"
        ValueTotalSubscribers.Size = New Size(52, 41)
        ValueTotalSubscribers.TabIndex = 10
        ValueTotalSubscribers.Text = "00"
        ' 
        ' LabelTotalSubscribers
        ' 
        LabelTotalSubscribers.AutoSize = True
        LabelTotalSubscribers.Font = New Font("Verdana", 12F)
        LabelTotalSubscribers.ForeColor = SystemColors.ControlDarkDark
        LabelTotalSubscribers.Location = New Point(28, 48)
        LabelTotalSubscribers.Name = "LabelTotalSubscribers"
        LabelTotalSubscribers.Size = New Size(147, 18)
        LabelTotalSubscribers.TabIndex = 11
        LabelTotalSubscribers.Text = "Total Subscribers"
        ' 
        ' PanelMonthlySubscriberGrowth
        ' 
        PanelMonthlySubscriberGrowth.BackColor = Color.White
        PanelMonthlySubscriberGrowth.Controls.Add(Panel2)
        PanelMonthlySubscriberGrowth.Controls.Add(MonthlySubscriberGrowth)
        PanelMonthlySubscriberGrowth.CornerRadius = 12
        PanelMonthlySubscriberGrowth.Location = New Point(861, 466)
        PanelMonthlySubscriberGrowth.Name = "PanelMonthlySubscriberGrowth"
        PanelMonthlySubscriberGrowth.Size = New Size(778, 517)
        PanelMonthlySubscriberGrowth.TabIndex = 55
        ' 
        ' Panel2
        ' 
        Panel2.Location = New Point(28, 60)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(721, 300)
        Panel2.TabIndex = 37
        ' 
        ' MonthlySubscriberGrowth
        ' 
        MonthlySubscriberGrowth.Anchor = AnchorStyles.Top
        MonthlySubscriberGrowth.AutoSize = True
        MonthlySubscriberGrowth.Font = New Font("Verdana", 12F)
        MonthlySubscriberGrowth.ForeColor = Color.Black
        MonthlySubscriberGrowth.Location = New Point(26, 27)
        MonthlySubscriberGrowth.Name = "MonthlySubscriberGrowth"
        MonthlySubscriberGrowth.Size = New Size(226, 18)
        MonthlySubscriberGrowth.TabIndex = 36
        MonthlySubscriberGrowth.Text = "Monthly Subscriber Growth"
        ' 
        ' PanelPlanSummaryDetails
        ' 
        PanelPlanSummaryDetails.BackColor = Color.White
        PanelPlanSummaryDetails.Controls.Add(DataGridPlanSummaryDetails)
        PanelPlanSummaryDetails.Controls.Add(lblPlanSummaryDetails)
        PanelPlanSummaryDetails.CornerRadius = 12
        PanelPlanSummaryDetails.Location = New Point(42, 1021)
        PanelPlanSummaryDetails.Name = "PanelPlanSummaryDetails"
        PanelPlanSummaryDetails.Size = New Size(1597, 464)
        PanelPlanSummaryDetails.TabIndex = 56
        ' 
        ' DataGridPlanSummaryDetails
        ' 
        DataGridPlanSummaryDetails.AllowUserToAddRows = False
        DataGridPlanSummaryDetails.AllowUserToDeleteRows = False
        DataGridPlanSummaryDetails.AllowUserToResizeColumns = False
        DataGridPlanSummaryDetails.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = Color.Black
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridPlanSummaryDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridPlanSummaryDetails.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridPlanSummaryDetails.BackgroundColor = Color.White
        DataGridPlanSummaryDetails.BorderStyle = BorderStyle.None
        DataGridPlanSummaryDetails.CellBorderStyle = DataGridViewCellBorderStyle.None
        DataGridPlanSummaryDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Verdana", 10F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        DataGridPlanSummaryDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridPlanSummaryDetails.ColumnHeadersHeight = 45
        DataGridPlanSummaryDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridPlanSummaryDetails.Columns.AddRange(New DataGridViewColumn() {PlanType, MonthlyRate, TotalSusbcribers, Active, Suspended, MonthlyRevenue, MarketShare})
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = SystemColors.Window
        DataGridViewCellStyle6.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle6.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.True
        DataGridPlanSummaryDetails.DefaultCellStyle = DataGridViewCellStyle6
        DataGridPlanSummaryDetails.EnableHeadersVisualStyles = False
        DataGridPlanSummaryDetails.GridColor = Color.White
        DataGridPlanSummaryDetails.Location = New Point(16, 58)
        DataGridPlanSummaryDetails.Margin = New Padding(3, 2, 3, 2)
        DataGridPlanSummaryDetails.Name = "DataGridPlanSummaryDetails"
        DataGridPlanSummaryDetails.ReadOnly = True
        DataGridPlanSummaryDetails.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridPlanSummaryDetails.RowHeadersVisible = False
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle7.ForeColor = Color.Black
        DataGridViewCellStyle7.WrapMode = DataGridViewTriState.True
        DataGridPlanSummaryDetails.RowsDefaultCellStyle = DataGridViewCellStyle7
        DataGridPlanSummaryDetails.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridPlanSummaryDetails.RowTemplate.DefaultCellStyle.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridPlanSummaryDetails.RowTemplate.DefaultCellStyle.ForeColor = Color.Black
        DataGridPlanSummaryDetails.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridPlanSummaryDetails.RowTemplate.Height = 40
        DataGridPlanSummaryDetails.RowTemplate.ReadOnly = True
        DataGridPlanSummaryDetails.ScrollBars = ScrollBars.Vertical
        DataGridPlanSummaryDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridPlanSummaryDetails.Size = New Size(1568, 349)
        DataGridPlanSummaryDetails.TabIndex = 54
        ' 
        ' lblPlanSummaryDetails
        ' 
        lblPlanSummaryDetails.Anchor = AnchorStyles.Top
        lblPlanSummaryDetails.AutoSize = True
        lblPlanSummaryDetails.Font = New Font("Verdana", 12F)
        lblPlanSummaryDetails.ForeColor = Color.Black
        lblPlanSummaryDetails.Location = New Point(28, 26)
        lblPlanSummaryDetails.Name = "lblPlanSummaryDetails"
        lblPlanSummaryDetails.Size = New Size(188, 18)
        lblPlanSummaryDetails.TabIndex = 53
        lblPlanSummaryDetails.Text = "Plan Summary Details"
        ' 
        ' PanelTopPerformingShool
        ' 
        PanelTopPerformingShool.BackColor = Color.White
        PanelTopPerformingShool.Controls.Add(PanelPremium)
        PanelTopPerformingShool.Controls.Add(PanelStandard)
        PanelTopPerformingShool.Controls.Add(Panelbasic)
        PanelTopPerformingShool.Controls.Add(LabelTopPerformingPlans)
        PanelTopPerformingShool.CornerRadius = 12
        PanelTopPerformingShool.Location = New Point(41, 1525)
        PanelTopPerformingShool.Name = "PanelTopPerformingShool"
        PanelTopPerformingShool.Size = New Size(778, 429)
        PanelTopPerformingShool.TabIndex = 57
        ' 
        ' PanelPremium
        ' 
        PanelPremium.BackColor = Color.WhiteSmoke
        PanelPremium.Controls.Add(MonthlyRevenue3rd)
        PanelPremium.Controls.Add(TotalSubscribers3rd)
        PanelPremium.Controls.Add(PlantType3rd)
        PanelPremium.Controls.Add(PanelNumber3)
        PanelPremium.CornerRadius = 12
        PanelPremium.Location = New Point(29, 291)
        PanelPremium.Name = "PanelPremium"
        PanelPremium.Size = New Size(720, 76)
        PanelPremium.TabIndex = 61
        ' 
        ' MonthlyRevenue3rd
        ' 
        MonthlyRevenue3rd.AutoSize = True
        MonthlyRevenue3rd.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
        MonthlyRevenue3rd.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        MonthlyRevenue3rd.Location = New Point(588, 22)
        MonthlyRevenue3rd.Name = "MonthlyRevenue3rd"
        MonthlyRevenue3rd.Size = New Size(38, 20)
        MonthlyRevenue3rd.TabIndex = 65
        MonthlyRevenue3rd.Text = "₱ 00"
        ' 
        ' TotalSubscribers3rd
        ' 
        TotalSubscribers3rd.Anchor = AnchorStyles.Top
        TotalSubscribers3rd.AutoSize = True
        TotalSubscribers3rd.Font = New Font("Segoe UI", 11F)
        TotalSubscribers3rd.ForeColor = Color.Black
        TotalSubscribers3rd.Location = New Point(69, 40)
        TotalSubscribers3rd.Name = "TotalSubscribers3rd"
        TotalSubscribers3rd.Size = New Size(131, 20)
        TotalSubscribers3rd.TabIndex = 64
        TotalSubscribers3rd.Text = "[Total Subscribers]"
        ' 
        ' PlantType3rd
        ' 
        PlantType3rd.Anchor = AnchorStyles.Top
        PlantType3rd.AutoSize = True
        PlantType3rd.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        PlantType3rd.ForeColor = Color.Black
        PlantType3rd.Location = New Point(69, 16)
        PlantType3rd.Name = "PlantType3rd"
        PlantType3rd.Size = New Size(95, 21)
        PlantType3rd.TabIndex = 56
        PlantType3rd.Text = "[Plant Type]"
        ' 
        ' PanelNumber3
        ' 
        PanelNumber3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        PanelNumber3.Controls.Add(LabelNumber3)
        PanelNumber3.CornerRadius = 8
        PanelNumber3.Location = New Point(24, 22)
        PanelNumber3.Name = "PanelNumber3"
        PanelNumber3.Size = New Size(39, 36)
        PanelNumber3.TabIndex = 2
        ' 
        ' LabelNumber3
        ' 
        LabelNumber3.AutoSize = True
        LabelNumber3.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        LabelNumber3.ForeColor = Color.DarkGoldenrod
        LabelNumber3.Location = New Point(0, 4)
        LabelNumber3.Name = "LabelNumber3"
        LabelNumber3.Size = New Size(38, 30)
        LabelNumber3.TabIndex = 13
        LabelNumber3.Text = "#3"
        ' 
        ' PanelStandard
        ' 
        PanelStandard.BackColor = Color.WhiteSmoke
        PanelStandard.Controls.Add(MonthlyRevenue2nd)
        PanelStandard.Controls.Add(TotalSubscribers2nd)
        PanelStandard.Controls.Add(PlantType2nd)
        PanelStandard.Controls.Add(PanelNumber2)
        PanelStandard.CornerRadius = 12
        PanelStandard.Location = New Point(29, 181)
        PanelStandard.Name = "PanelStandard"
        PanelStandard.Size = New Size(720, 76)
        PanelStandard.TabIndex = 60
        ' 
        ' MonthlyRevenue2nd
        ' 
        MonthlyRevenue2nd.AutoSize = True
        MonthlyRevenue2nd.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
        MonthlyRevenue2nd.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        MonthlyRevenue2nd.Location = New Point(588, 16)
        MonthlyRevenue2nd.Name = "MonthlyRevenue2nd"
        MonthlyRevenue2nd.Size = New Size(38, 20)
        MonthlyRevenue2nd.TabIndex = 64
        MonthlyRevenue2nd.Text = "₱ 00"
        ' 
        ' TotalSubscribers2nd
        ' 
        TotalSubscribers2nd.Anchor = AnchorStyles.Top
        TotalSubscribers2nd.AutoSize = True
        TotalSubscribers2nd.Font = New Font("Segoe UI", 11F)
        TotalSubscribers2nd.ForeColor = Color.Black
        TotalSubscribers2nd.Location = New Point(69, 40)
        TotalSubscribers2nd.Name = "TotalSubscribers2nd"
        TotalSubscribers2nd.Size = New Size(131, 20)
        TotalSubscribers2nd.TabIndex = 63
        TotalSubscribers2nd.Text = "[Total Subscribers]"
        ' 
        ' PlantType2nd
        ' 
        PlantType2nd.Anchor = AnchorStyles.Top
        PlantType2nd.AutoSize = True
        PlantType2nd.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        PlantType2nd.ForeColor = Color.Black
        PlantType2nd.Location = New Point(69, 16)
        PlantType2nd.Name = "PlantType2nd"
        PlantType2nd.Size = New Size(95, 21)
        PlantType2nd.TabIndex = 55
        PlantType2nd.Text = "[Plant Type]"
        ' 
        ' PanelNumber2
        ' 
        PanelNumber2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        PanelNumber2.Controls.Add(LabelNumber2)
        PanelNumber2.CornerRadius = 8
        PanelNumber2.Location = New Point(23, 22)
        PanelNumber2.Name = "PanelNumber2"
        PanelNumber2.Size = New Size(39, 36)
        PanelNumber2.TabIndex = 1
        ' 
        ' LabelNumber2
        ' 
        LabelNumber2.AutoSize = True
        LabelNumber2.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        LabelNumber2.ForeColor = Color.DarkGoldenrod
        LabelNumber2.Location = New Point(0, 4)
        LabelNumber2.Name = "LabelNumber2"
        LabelNumber2.Size = New Size(38, 30)
        LabelNumber2.TabIndex = 12
        LabelNumber2.Text = "#2"
        ' 
        ' Panelbasic
        ' 
        Panelbasic.BackColor = Color.WhiteSmoke
        Panelbasic.Controls.Add(MonthlyRevenue1st)
        Panelbasic.Controls.Add(TotalSubscribers1st)
        Panelbasic.Controls.Add(PlanType1st)
        Panelbasic.Controls.Add(PanelNumber1)
        Panelbasic.CornerRadius = 12
        Panelbasic.Location = New Point(29, 76)
        Panelbasic.Name = "Panelbasic"
        Panelbasic.Size = New Size(720, 76)
        Panelbasic.TabIndex = 59
        ' 
        ' MonthlyRevenue1st
        ' 
        MonthlyRevenue1st.AutoSize = True
        MonthlyRevenue1st.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
        MonthlyRevenue1st.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        MonthlyRevenue1st.Location = New Point(588, 16)
        MonthlyRevenue1st.Name = "MonthlyRevenue1st"
        MonthlyRevenue1st.Size = New Size(38, 20)
        MonthlyRevenue1st.TabIndex = 63
        MonthlyRevenue1st.Text = "₱ 00"
        ' 
        ' TotalSubscribers1st
        ' 
        TotalSubscribers1st.Anchor = AnchorStyles.Top
        TotalSubscribers1st.AutoSize = True
        TotalSubscribers1st.Font = New Font("Segoe UI", 11F)
        TotalSubscribers1st.ForeColor = Color.Black
        TotalSubscribers1st.Location = New Point(67, 39)
        TotalSubscribers1st.Name = "TotalSubscribers1st"
        TotalSubscribers1st.Size = New Size(131, 20)
        TotalSubscribers1st.TabIndex = 62
        TotalSubscribers1st.Text = "[Total Subscribers]"
        ' 
        ' PlanType1st
        ' 
        PlanType1st.Anchor = AnchorStyles.Top
        PlanType1st.AutoSize = True
        PlanType1st.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        PlanType1st.ForeColor = Color.Black
        PlanType1st.Location = New Point(69, 15)
        PlanType1st.Name = "PlanType1st"
        PlanType1st.Size = New Size(95, 21)
        PlanType1st.TabIndex = 54
        PlanType1st.Text = "[Plant Type]"
        ' 
        ' PanelNumber1
        ' 
        PanelNumber1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        PanelNumber1.Controls.Add(labelNumber1)
        PanelNumber1.CornerRadius = 8
        PanelNumber1.Location = New Point(24, 21)
        PanelNumber1.Name = "PanelNumber1"
        PanelNumber1.Size = New Size(39, 36)
        PanelNumber1.TabIndex = 0
        ' 
        ' labelNumber1
        ' 
        labelNumber1.AutoSize = True
        labelNumber1.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        labelNumber1.ForeColor = Color.DarkGoldenrod
        labelNumber1.Location = New Point(2, 3)
        labelNumber1.Name = "labelNumber1"
        labelNumber1.Size = New Size(35, 30)
        labelNumber1.TabIndex = 11
        labelNumber1.Text = "#1"
        ' 
        ' LabelTopPerformingPlans
        ' 
        LabelTopPerformingPlans.Anchor = AnchorStyles.Top
        LabelTopPerformingPlans.AutoSize = True
        LabelTopPerformingPlans.Font = New Font("Verdana", 12F)
        LabelTopPerformingPlans.ForeColor = Color.Black
        LabelTopPerformingPlans.Location = New Point(26, 22)
        LabelTopPerformingPlans.Name = "LabelTopPerformingPlans"
        LabelTopPerformingPlans.Size = New Size(180, 18)
        LabelTopPerformingPlans.TabIndex = 53
        LabelTopPerformingPlans.Text = "Top Performing Plans"
        ' 
        ' PanelRound2
        ' 
        PanelRound2.Location = New Point(41, 2022)
        PanelRound2.Name = "PanelRound2"
        PanelRound2.Size = New Size(1597, 49)
        PanelRound2.TabIndex = 58
        ' 
        ' PanelPlanMetrics
        ' 
        PanelPlanMetrics.BackColor = Color.White
        PanelPlanMetrics.Controls.Add(PanelRound4)
        PanelPlanMetrics.Controls.Add(PanelRound5)
        PanelPlanMetrics.Controls.Add(PanelRound3)
        PanelPlanMetrics.Controls.Add(PanelRound1)
        PanelPlanMetrics.Controls.Add(PlanMetrics)
        PanelPlanMetrics.CornerRadius = 12
        PanelPlanMetrics.Location = New Point(861, 1524)
        PanelPlanMetrics.Name = "PanelPlanMetrics"
        PanelPlanMetrics.Size = New Size(778, 429)
        PanelPlanMetrics.TabIndex = 58
        ' 
        ' PanelRound4
        ' 
        PanelRound4.BackColor = Color.WhiteSmoke
        PanelRound4.Controls.Add(AverageARPU)
        PanelRound4.Controls.Add(LabelAverageARPU)
        PanelRound4.CornerRadius = 12
        PanelRound4.Location = New Point(36, 177)
        PanelRound4.Name = "PanelRound4"
        PanelRound4.Size = New Size(336, 80)
        PanelRound4.TabIndex = 55
        ' 
        ' AverageARPU
        ' 
        AverageARPU.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        AverageARPU.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
        AverageARPU.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        AverageARPU.Location = New Point(3, 40)
        AverageARPU.Name = "AverageARPU"
        AverageARPU.Size = New Size(330, 28)
        AverageARPU.TabIndex = 66
        AverageARPU.Text = "[Average ARPU]"
        AverageARPU.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelAverageARPU
        ' 
        LabelAverageARPU.Anchor = AnchorStyles.Top
        LabelAverageARPU.AutoSize = True
        LabelAverageARPU.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        LabelAverageARPU.ForeColor = Color.Red
        LabelAverageARPU.Location = New Point(105, 13)
        LabelAverageARPU.Name = "LabelAverageARPU"
        LabelAverageARPU.Size = New Size(116, 21)
        LabelAverageARPU.TabIndex = 65
        LabelAverageARPU.Text = "Average ARPU"
        ' 
        ' PanelRound5
        ' 
        PanelRound5.BackColor = Color.WhiteSmoke
        PanelRound5.Controls.Add(RetentionRate)
        PanelRound5.Controls.Add(LabelRetentionRate)
        PanelRound5.CornerRadius = 12
        PanelRound5.Location = New Point(411, 177)
        PanelRound5.Name = "PanelRound5"
        PanelRound5.Size = New Size(336, 80)
        PanelRound5.TabIndex = 55
        ' 
        ' RetentionRate
        ' 
        RetentionRate.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        RetentionRate.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
        RetentionRate.ForeColor = Color.Purple
        RetentionRate.Location = New Point(3, 40)
        RetentionRate.Name = "RetentionRate"
        RetentionRate.Size = New Size(330, 28)
        RetentionRate.TabIndex = 68
        RetentionRate.Text = "[Retention Rate]"
        RetentionRate.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelRetentionRate
        ' 
        LabelRetentionRate.Anchor = AnchorStyles.Top
        LabelRetentionRate.AutoSize = True
        LabelRetentionRate.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        LabelRetentionRate.ForeColor = Color.FromArgb(CByte(152), CByte(26), CByte(250))
        LabelRetentionRate.Location = New Point(112, 13)
        LabelRetentionRate.Name = "LabelRetentionRate"
        LabelRetentionRate.Size = New Size(119, 21)
        LabelRetentionRate.TabIndex = 67
        LabelRetentionRate.Text = "Retention Rate"
        ' 
        ' PanelRound3
        ' 
        PanelRound3.BackColor = Color.FromArgb(CByte(240), CByte(253), CByte(244))
        PanelRound3.Controls.Add(HighestRevenue)
        PanelRound3.Controls.Add(LabelHighestRevenue)
        PanelRound3.CornerRadius = 12
        PanelRound3.Location = New Point(411, 61)
        PanelRound3.Name = "PanelRound3"
        PanelRound3.Size = New Size(336, 80)
        PanelRound3.TabIndex = 55
        ' 
        ' HighestRevenue
        ' 
        HighestRevenue.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        HighestRevenue.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
        HighestRevenue.ForeColor = Color.Green
        HighestRevenue.Location = New Point(3, 39)
        HighestRevenue.Name = "HighestRevenue"
        HighestRevenue.Size = New Size(330, 28)
        HighestRevenue.TabIndex = 67
        HighestRevenue.Text = "[Highest Revenue]"
        HighestRevenue.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelHighestRevenue
        ' 
        LabelHighestRevenue.Anchor = AnchorStyles.Top
        LabelHighestRevenue.AutoSize = True
        LabelHighestRevenue.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        LabelHighestRevenue.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        LabelHighestRevenue.Location = New Point(103, 15)
        LabelHighestRevenue.Name = "LabelHighestRevenue"
        LabelHighestRevenue.Size = New Size(134, 21)
        LabelHighestRevenue.TabIndex = 66
        LabelHighestRevenue.Text = "Highest Revenue"
        ' 
        ' PanelRound1
        ' 
        PanelRound1.BackColor = Color.FromArgb(CByte(240), CByte(253), CByte(244))
        PanelRound1.Controls.Add(MostPopularPlan)
        PanelRound1.Controls.Add(LabelMostPopularPlan)
        PanelRound1.CornerRadius = 12
        PanelRound1.Location = New Point(36, 61)
        PanelRound1.Name = "PanelRound1"
        PanelRound1.Size = New Size(336, 80)
        PanelRound1.TabIndex = 54
        ' 
        ' MostPopularPlan
        ' 
        MostPopularPlan.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        MostPopularPlan.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
        MostPopularPlan.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(192))
        MostPopularPlan.Location = New Point(3, 39)
        MostPopularPlan.Name = "MostPopularPlan"
        MostPopularPlan.Size = New Size(330, 28)
        MostPopularPlan.TabIndex = 65
        MostPopularPlan.Text = "[Most Popular Plan]"
        MostPopularPlan.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LabelMostPopularPlan
        ' 
        LabelMostPopularPlan.Anchor = AnchorStyles.Top
        LabelMostPopularPlan.AutoSize = True
        LabelMostPopularPlan.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        LabelMostPopularPlan.ForeColor = Color.Blue
        LabelMostPopularPlan.Location = New Point(101, 15)
        LabelMostPopularPlan.Name = "LabelMostPopularPlan"
        LabelMostPopularPlan.Size = New Size(141, 21)
        LabelMostPopularPlan.TabIndex = 64
        LabelMostPopularPlan.Text = "Most Popular Plan"
        ' 
        ' PlanMetrics
        ' 
        PlanMetrics.Anchor = AnchorStyles.Top
        PlanMetrics.AutoSize = True
        PlanMetrics.Font = New Font("Verdana", 12F)
        PlanMetrics.ForeColor = Color.Black
        PlanMetrics.Location = New Point(28, 22)
        PlanMetrics.Name = "PlanMetrics"
        PlanMetrics.Size = New Size(107, 18)
        PlanMetrics.TabIndex = 53
        PlanMetrics.Text = "Plan Metrics"
        ' 
        ' lblSubscriberDistributionbyPlan
        ' 
        lblSubscriberDistributionbyPlan.Anchor = AnchorStyles.Top
        lblSubscriberDistributionbyPlan.AutoSize = True
        lblSubscriberDistributionbyPlan.Font = New Font("Verdana", 12F)
        lblSubscriberDistributionbyPlan.ForeColor = Color.Black
        lblSubscriberDistributionbyPlan.Location = New Point(25, 24)
        lblSubscriberDistributionbyPlan.Name = "lblSubscriberDistributionbyPlan"
        lblSubscriberDistributionbyPlan.Size = New Size(260, 18)
        lblSubscriberDistributionbyPlan.TabIndex = 35
        lblSubscriberDistributionbyPlan.Text = "Subscriber Distribution by Plan"
        ' 
        ' Panel1
        ' 
        Panel1.Location = New Point(28, 60)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(722, 423)
        Panel1.TabIndex = 53
        ' 
        ' PanelSubsPlanType
        ' 
        PanelSubsPlanType.BackColor = Color.White
        PanelSubsPlanType.Controls.Add(Panel1)
        PanelSubsPlanType.Controls.Add(lblSubscriberDistributionbyPlan)
        PanelSubsPlanType.CornerRadius = 12
        PanelSubsPlanType.Location = New Point(42, 466)
        PanelSubsPlanType.Name = "PanelSubsPlanType"
        PanelSubsPlanType.Size = New Size(778, 517)
        PanelSubsPlanType.TabIndex = 54
        ' 
        ' PlanType
        ' 
        PlanType.DataPropertyName = "PlanType"
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = Color.Black
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        PlanType.DefaultCellStyle = DataGridViewCellStyle3
        PlanType.HeaderText = "Plan Type"
        PlanType.Name = "PlanType"
        PlanType.ReadOnly = True
        PlanType.Width = 300
        ' 
        ' MonthlyRate
        ' 
        MonthlyRate.DataPropertyName = "MonthlyRate"
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True
        MonthlyRate.DefaultCellStyle = DataGridViewCellStyle4
        MonthlyRate.HeaderText = "Monthly Rate"
        MonthlyRate.Name = "MonthlyRate"
        MonthlyRate.ReadOnly = True
        MonthlyRate.Width = 250
        ' 
        ' TotalSusbcribers
        ' 
        TotalSusbcribers.DataPropertyName = "TotalSubscribers"
        TotalSusbcribers.HeaderText = "Total Susbcribers"
        TotalSusbcribers.Name = "TotalSusbcribers"
        TotalSusbcribers.ReadOnly = True
        TotalSusbcribers.Width = 230
        ' 
        ' Active
        ' 
        Active.DataPropertyName = "Active"
        Active.HeaderText = "Active"
        Active.Name = "Active"
        Active.ReadOnly = True
        Active.Width = 150
        ' 
        ' Suspended
        ' 
        Suspended.DataPropertyName = "Suspended"
        Suspended.HeaderText = "Suspended"
        Suspended.Name = "Suspended"
        Suspended.ReadOnly = True
        Suspended.Width = 180
        ' 
        ' MonthlyRevenue
        ' 
        MonthlyRevenue.DataPropertyName = "MonthlyRevenue"
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.True
        MonthlyRevenue.DefaultCellStyle = DataGridViewCellStyle5
        MonthlyRevenue.HeaderText = "Monthly Revenue"
        MonthlyRevenue.Name = "MonthlyRevenue"
        MonthlyRevenue.ReadOnly = True
        MonthlyRevenue.Width = 230
        ' 
        ' MarketShare
        ' 
        MarketShare.DataPropertyName = "MarketShare"
        MarketShare.HeaderText = "Market Share"
        MarketShare.Name = "MarketShare"
        MarketShare.ReadOnly = True
        MarketShare.Width = 200
        ' 
        ' plansview
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.Control
        Controls.Add(PanelPlanMetrics)
        Controls.Add(PanelRound2)
        Controls.Add(PanelTopPerformingShool)
        Controls.Add(PanelPlanSummaryDetails)
        Controls.Add(PanelMonthlySubscriberGrowth)
        Controls.Add(PanelSubsPlanType)
        Controls.Add(PanelActivePlans)
        Controls.Add(PanelMonthlyRevenue)
        Controls.Add(PanelAvgRevenuePerPlan)
        Controls.Add(PanelTotalSubscribers)
        Controls.Add(BtnPlansExport)
        Controls.Add(PanelFilters)
        Controls.Add(HeaderPlanSummaryReport)
        Name = "plansview"
        Size = New Size(1940, 2110)
        PanelFilters.ResumeLayout(False)
        PanelFilters.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        PanelActivePlans.ResumeLayout(False)
        PanelActivePlans.PerformLayout()
        CType(IconActivePlans, ComponentModel.ISupportInitialize).EndInit()
        PanelMonthlyRevenue.ResumeLayout(False)
        PanelMonthlyRevenue.PerformLayout()
        CType(IconMonthlyRevenue, ComponentModel.ISupportInitialize).EndInit()
        PanelAvgRevenuePerPlan.ResumeLayout(False)
        PanelAvgRevenuePerPlan.PerformLayout()
        CType(IconAvgRevenue, ComponentModel.ISupportInitialize).EndInit()
        PanelTotalSubscribers.ResumeLayout(False)
        PanelTotalSubscribers.PerformLayout()
        CType(IconTotalSubscribers, ComponentModel.ISupportInitialize).EndInit()
        PanelMonthlySubscriberGrowth.ResumeLayout(False)
        PanelMonthlySubscriberGrowth.PerformLayout()
        PanelPlanSummaryDetails.ResumeLayout(False)
        PanelPlanSummaryDetails.PerformLayout()
        CType(DataGridPlanSummaryDetails, ComponentModel.ISupportInitialize).EndInit()
        PanelTopPerformingShool.ResumeLayout(False)
        PanelTopPerformingShool.PerformLayout()
        PanelPremium.ResumeLayout(False)
        PanelPremium.PerformLayout()
        PanelNumber3.ResumeLayout(False)
        PanelNumber3.PerformLayout()
        PanelStandard.ResumeLayout(False)
        PanelStandard.PerformLayout()
        PanelNumber2.ResumeLayout(False)
        PanelNumber2.PerformLayout()
        Panelbasic.ResumeLayout(False)
        Panelbasic.PerformLayout()
        PanelNumber1.ResumeLayout(False)
        PanelNumber1.PerformLayout()
        PanelPlanMetrics.ResumeLayout(False)
        PanelPlanMetrics.PerformLayout()
        PanelRound4.ResumeLayout(False)
        PanelRound4.PerformLayout()
        PanelRound5.ResumeLayout(False)
        PanelRound5.PerformLayout()
        PanelRound3.ResumeLayout(False)
        PanelRound3.PerformLayout()
        PanelRound1.ResumeLayout(False)
        PanelRound1.PerformLayout()
        PanelSubsPlanType.ResumeLayout(False)
        PanelSubsPlanType.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents BtnPlansExport As Button
    Friend WithEvents PanelFilters As PanelRound
    Friend WithEvents cbAccountStatus As ComboBox
    Friend WithEvents lblAccountStatus As Label
    Friend WithEvents lblDateRange As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents HeaderPlanSummaryReport As Label
    Friend WithEvents cbDateRange As ComboBox
    Friend WithEvents PanelActivePlans As PanelRound
    Friend WithEvents IconActivePlans As PictureBox
    Friend WithEvents ValueMonthlyRevenueActivePlans As Label
    Friend WithEvents lblActivePlans As Label
    Friend WithEvents PanelMonthlyRevenue As PanelRound
    Friend WithEvents IconMonthlyRevenue As PictureBox
    Friend WithEvents ValueMonthlyRevenue As Label
    Friend WithEvents lblMonthlyRevenue As Label
    Friend WithEvents PanelAvgRevenuePerPlan As PanelRound
    Friend WithEvents IconAvgRevenue As PictureBox
    Friend WithEvents ValueRevenuePlan As Label
    Friend WithEvents LabelRevenuePlan As Label
    Friend WithEvents PanelTotalSubscribers As PanelRound
    Friend WithEvents IconTotalSubscribers As PictureBox
    Friend WithEvents ValueTotalSubscribers As Label
    Friend WithEvents LabelTotalSubscribers As Label
    Friend WithEvents PanelMonthlySubscriberGrowth As PanelRound
    Friend WithEvents STDPercentUpgrade As Label
    Friend WithEvents ASDGreenDot As PictureBox
    Friend WithEvents ASDActive As Label
    Friend WithEvents STDPercentRelocation As Label
    Friend WithEvents ASDCancelled As Label
    Friend WithEvents MonthlySubscriberGrowth As Label
    Friend WithEvents STDPercentRepair As Label
    Friend WithEvents ASDRedDot As PictureBox
    Friend WithEvents ASDSuspended As Label
    Friend WithEvents ASDOrangeDot As PictureBox
    Friend WithEvents PanelPlanSummaryDetails As PanelRound
    Friend WithEvents lblPlanSummaryDetails As Label
    Friend WithEvents DataGridPlanSummaryDetails As DataGridView
    Friend WithEvents PanelTopPerformingShool As PanelRound
    Friend WithEvents LabelTopPerformingPlans As Label
    Friend WithEvents PanelRound2 As PanelRound
    Friend WithEvents PanelPlanMetrics As PanelRound
    Friend WithEvents PlanMetrics As Label
    Friend WithEvents Panelbasic As PanelRound
    Friend WithEvents PanelPremium As PanelRound
    Friend WithEvents PanelStandard As PanelRound
    Friend WithEvents PanelNumber3 As PanelRound
    Friend WithEvents PanelNumber2 As PanelRound
    Friend WithEvents PanelNumber1 As PanelRound
    Friend WithEvents PlantType3rd As Label
    Friend WithEvents LabelNumber3 As Label
    Friend WithEvents PlantType2nd As Label
    Friend WithEvents LabelNumber2 As Label
    Friend WithEvents PlanType1st As Label
    Friend WithEvents labelNumber1 As Label
    Friend WithEvents MonthlyRevenue3rd As Label
    Friend WithEvents TotalSubscribers3rd As Label
    Friend WithEvents MonthlyRevenue2nd As Label
    Friend WithEvents TotalSubscribers2nd As Label
    Friend WithEvents MonthlyRevenue1st As Label
    Friend WithEvents TotalSubscribers1st As Label
    Friend WithEvents PanelRound5 As PanelRound
    Friend WithEvents PanelRound4 As PanelRound
    Friend WithEvents PanelRound3 As PanelRound
    Friend WithEvents PanelRound1 As PanelRound
    Friend WithEvents MostPopularPlan As Label
    Friend WithEvents LabelMostPopularPlan As Label
    Friend WithEvents HighestRevenue As Label
    Friend WithEvents LabelHighestRevenue As Label
    Friend WithEvents AverageARPU As Label
    Friend WithEvents LabelAverageARPU As Label
    Friend WithEvents RetentionRate As Label
    Friend WithEvents LabelRetentionRate As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblSubscriberDistributionbyPlan As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PanelSubsPlanType As PanelRound
    Friend WithEvents PlanType As DataGridViewTextBoxColumn
    Friend WithEvents MonthlyRate As DataGridViewTextBoxColumn
    Friend WithEvents TotalSusbcribers As DataGridViewTextBoxColumn
    Friend WithEvents Active As DataGridViewTextBoxColumn
    Friend WithEvents Suspended As DataGridViewTextBoxColumn
    Friend WithEvents MonthlyRevenue As DataGridViewTextBoxColumn
    Friend WithEvents MarketShare As DataGridViewTextBoxColumn

End Class

