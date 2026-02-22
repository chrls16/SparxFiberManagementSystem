<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class service
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
        Dim DataGridViewCellStyle13 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As DataGridViewCellStyle = New DataGridViewCellStyle()
        HeaderServiceReport = New Label()
        PanelFilters = New PanelRound()
        btnExport = New ButtonRounded()
        cbStatus = New ComboBox()
        lblStatus = New Label()
        ComboServiceType = New ComboBox()
        ComboDateRange = New ComboBox()
        LabelStatus = New Label()
        LabelDateRange = New Label()
        LabelFilters = New Label()
        IconFilter = New PictureBox()
        PanelPending = New PanelRound()
        IconPending = New PictureBox()
        NumPending = New Label()
        LabelRequested = New Label()
        PanelInProgress = New PanelRound()
        IconInProgress = New PictureBox()
        NumInProgress = New Label()
        LabelInProgress = New Label()
        PanelCompleted = New PanelRound()
        IconComplete = New PictureBox()
        NumCompleted = New Label()
        LabelCompleted = New Label()
        PanelTotalRequest = New PanelRound()
        IconTotalRequest = New PictureBox()
        NumTotalInstalRequest = New Label()
        LabelTotalInstallations = New Label()
        PanelServiceStatusDistribution = New PanelRound()
        PanelRound1 = New PanelRound()
        SubscribersGrowth = New Label()
        ServiceStatusDistribution = New Label()
        PanelServiceTypeDistribution = New PanelRound()
        PanelRound2 = New PanelRound()
        LabelServiceRequestDetails = New Label()
        DataGridServiceRequestDetails = New DataGridView()
        ServiceID = New DataGridViewTextBoxColumn()
        Customer = New DataGridViewTextBoxColumn()
        ServiceType = New DataGridViewTextBoxColumn()
        colTimeRequested = New DataGridViewTextBoxColumn()
        DateRequested = New DataGridViewTextBoxColumn()
        colDateCompleted = New DataGridViewTextBoxColumn()
        ServiceCost = New DataGridViewTextBoxColumn()
        Technician = New DataGridViewTextBoxColumn()
        colServiceDescription = New DataGridViewTextBoxColumn()
        Status = New DataGridViewTextBoxColumn()
        ColTechNotes = New DataGridViewTextBoxColumn()
        colEdit = New DataGridViewImageColumn()
        colDelete = New DataGridViewImageColumn()
        colCheckBox = New DataGridViewCheckBoxColumn()
        PanelInstallationDetails = New PanelRound()
        deleteAll = New PictureBox()
        LblPageInfo = New Label()
        btnSalesPreviousSA = New Button()
        btnNextInstallationSA = New Button()
        btnSelectInventory = New PictureBox()
        btnAddInventory = New PictureBox()
        txtInventorySearchSA = New TextBox()
        PanelFilters.SuspendLayout()
        CType(IconFilter, ComponentModel.ISupportInitialize).BeginInit()
        PanelPending.SuspendLayout()
        CType(IconPending, ComponentModel.ISupportInitialize).BeginInit()
        PanelInProgress.SuspendLayout()
        CType(IconInProgress, ComponentModel.ISupportInitialize).BeginInit()
        PanelCompleted.SuspendLayout()
        CType(IconComplete, ComponentModel.ISupportInitialize).BeginInit()
        PanelTotalRequest.SuspendLayout()
        CType(IconTotalRequest, ComponentModel.ISupportInitialize).BeginInit()
        PanelServiceStatusDistribution.SuspendLayout()
        PanelServiceTypeDistribution.SuspendLayout()
        CType(DataGridServiceRequestDetails, ComponentModel.ISupportInitialize).BeginInit()
        PanelInstallationDetails.SuspendLayout()
        CType(deleteAll, ComponentModel.ISupportInitialize).BeginInit()
        CType(btnSelectInventory, ComponentModel.ISupportInitialize).BeginInit()
        CType(btnAddInventory, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' HeaderServiceReport
        ' 
        HeaderServiceReport.AutoSize = True
        HeaderServiceReport.Font = New Font("Segoe UI Semibold", 15F, FontStyle.Bold)
        HeaderServiceReport.Location = New Point(43, 18)
        HeaderServiceReport.Name = "HeaderServiceReport"
        HeaderServiceReport.Size = New Size(144, 28)
        HeaderServiceReport.TabIndex = 6
        HeaderServiceReport.Text = "Service Report"
        ' 
        ' PanelFilters
        ' 
        PanelFilters.BackColor = Color.White
        PanelFilters.Controls.Add(btnExport)
        PanelFilters.Controls.Add(cbStatus)
        PanelFilters.Controls.Add(lblStatus)
        PanelFilters.Controls.Add(ComboServiceType)
        PanelFilters.Controls.Add(ComboDateRange)
        PanelFilters.Controls.Add(LabelStatus)
        PanelFilters.Controls.Add(LabelDateRange)
        PanelFilters.Controls.Add(LabelFilters)
        PanelFilters.Controls.Add(IconFilter)
        PanelFilters.CornerRadius = 12
        PanelFilters.Location = New Point(47, 62)
        PanelFilters.Name = "PanelFilters"
        PanelFilters.Size = New Size(1597, 165)
        PanelFilters.TabIndex = 5
        ' 
        ' btnExport
        ' 
        btnExport.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        btnExport.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnExport.CornerRadius = 8
        btnExport.Cursor = Cursors.Hand
        btnExport.FlatAppearance.BorderSize = 0
        btnExport.FlatStyle = FlatStyle.Flat
        btnExport.Font = New Font("Segoe UI", 12F)
        btnExport.ForeColor = Color.White
        btnExport.ImageAlign = ContentAlignment.MiddleLeft
        btnExport.Location = New Point(1350, 15)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(223, 34)
        btnExport.TabIndex = 24
        btnExport.Text = "Export Report"
        btnExport.UseVisualStyleBackColor = False
        ' 
        ' cbStatus
        ' 
        cbStatus.BackColor = SystemColors.ButtonFace
        cbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cbStatus.Font = New Font("Segoe UI", 14F)
        cbStatus.ForeColor = SystemColors.WindowText
        cbStatus.FormattingEnabled = True
        cbStatus.Items.AddRange(New Object() {"All Status", "Completed", "In Progress", "Requested"})
        cbStatus.Location = New Point(450, 107)
        cbStatus.MinimumSize = New Size(193, 0)
        cbStatus.Name = "cbStatus"
        cbStatus.Size = New Size(193, 33)
        cbStatus.TabIndex = 30
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        lblStatus.Location = New Point(450, 83)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(55, 21)
        lblStatus.TabIndex = 29
        lblStatus.Text = "Status"
        ' 
        ' ComboServiceType
        ' 
        ComboServiceType.BackColor = SystemColors.ButtonFace
        ComboServiceType.DropDownStyle = ComboBoxStyle.DropDownList
        ComboServiceType.Font = New Font("Segoe UI", 14F)
        ComboServiceType.ForeColor = SystemColors.WindowText
        ComboServiceType.FormattingEnabled = True
        ComboServiceType.Items.AddRange(New Object() {"All Type", "Installation", "Repair", "Relocation"})
        ComboServiceType.Location = New Point(231, 107)
        ComboServiceType.MinimumSize = New Size(193, 0)
        ComboServiceType.Name = "ComboServiceType"
        ComboServiceType.Size = New Size(193, 33)
        ComboServiceType.TabIndex = 13
        ' 
        ' ComboDateRange
        ' 
        ComboDateRange.BackColor = SystemColors.ButtonFace
        ComboDateRange.DropDownStyle = ComboBoxStyle.DropDownList
        ComboDateRange.Font = New Font("Segoe UI", 14F)
        ComboDateRange.ForeColor = SystemColors.WindowText
        ComboDateRange.FormattingEnabled = True
        ComboDateRange.Items.AddRange(New Object() {"All Times", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        ComboDateRange.Location = New Point(20, 107)
        ComboDateRange.MinimumSize = New Size(193, 0)
        ComboDateRange.Name = "ComboDateRange"
        ComboDateRange.Size = New Size(193, 33)
        ComboDateRange.TabIndex = 11
        ' 
        ' LabelStatus
        ' 
        LabelStatus.AutoSize = True
        LabelStatus.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        LabelStatus.Location = New Point(231, 83)
        LabelStatus.Name = "LabelStatus"
        LabelStatus.Size = New Size(103, 21)
        LabelStatus.TabIndex = 10
        LabelStatus.Text = "Service Type"
        ' 
        ' LabelDateRange
        ' 
        LabelDateRange.AutoSize = True
        LabelDateRange.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        LabelDateRange.Location = New Point(18, 83)
        LabelDateRange.Name = "LabelDateRange"
        LabelDateRange.Size = New Size(94, 21)
        LabelDateRange.TabIndex = 8
        LabelDateRange.Text = "Date Range"
        ' 
        ' LabelFilters
        ' 
        LabelFilters.AutoSize = True
        LabelFilters.Font = New Font("Verdana", 12F)
        LabelFilters.Location = New Point(49, 24)
        LabelFilters.Name = "LabelFilters"
        LabelFilters.Size = New Size(59, 18)
        LabelFilters.TabIndex = 3
        LabelFilters.Text = "Filters"
        ' 
        ' IconFilter
        ' 
        IconFilter.Image = My.Resources.Resources.filter
        IconFilter.Location = New Point(20, 20)
        IconFilter.Name = "IconFilter"
        IconFilter.Size = New Size(24, 24)
        IconFilter.SizeMode = PictureBoxSizeMode.Zoom
        IconFilter.TabIndex = 2
        IconFilter.TabStop = False
        ' 
        ' PanelPending
        ' 
        PanelPending.BackColor = Color.White
        PanelPending.Controls.Add(IconPending)
        PanelPending.Controls.Add(NumPending)
        PanelPending.Controls.Add(LabelRequested)
        PanelPending.CornerRadius = 12
        PanelPending.Location = New Point(1278, 271)
        PanelPending.Name = "PanelPending"
        PanelPending.Size = New Size(367, 115)
        PanelPending.TabIndex = 20
        ' 
        ' IconPending
        ' 
        IconPending.Image = My.Resources.Resources.PendingServices
        IconPending.Location = New Point(286, 36)
        IconPending.Name = "IconPending"
        IconPending.Size = New Size(48, 50)
        IconPending.SizeMode = PictureBoxSizeMode.Zoom
        IconPending.TabIndex = 12
        IconPending.TabStop = False
        ' 
        ' NumPending
        ' 
        NumPending.AutoSize = True
        NumPending.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        NumPending.ForeColor = Color.FromArgb(CByte(192), CByte(192), CByte(0))
        NumPending.Location = New Point(24, 66)
        NumPending.Name = "NumPending"
        NumPending.Size = New Size(37, 30)
        NumPending.TabIndex = 11
        NumPending.Text = "00"
        ' 
        ' LabelRequested
        ' 
        LabelRequested.AutoSize = True
        LabelRequested.Font = New Font("Verdana", 12F)
        LabelRequested.ForeColor = SystemColors.ControlDarkDark
        LabelRequested.Location = New Point(24, 25)
        LabelRequested.Name = "LabelRequested"
        LabelRequested.Size = New Size(95, 18)
        LabelRequested.TabIndex = 8
        LabelRequested.Text = "Requested"
        ' 
        ' PanelInProgress
        ' 
        PanelInProgress.BackColor = Color.White
        PanelInProgress.Controls.Add(IconInProgress)
        PanelInProgress.Controls.Add(NumInProgress)
        PanelInProgress.Controls.Add(LabelInProgress)
        PanelInProgress.CornerRadius = 12
        PanelInProgress.Location = New Point(867, 271)
        PanelInProgress.Name = "PanelInProgress"
        PanelInProgress.Size = New Size(367, 115)
        PanelInProgress.TabIndex = 19
        ' 
        ' IconInProgress
        ' 
        IconInProgress.Image = My.Resources.Resources.redInProgress
        IconInProgress.Location = New Point(286, 36)
        IconInProgress.Name = "IconInProgress"
        IconInProgress.Size = New Size(48, 50)
        IconInProgress.SizeMode = PictureBoxSizeMode.Zoom
        IconInProgress.TabIndex = 11
        IconInProgress.TabStop = False
        ' 
        ' NumInProgress
        ' 
        NumInProgress.AutoSize = True
        NumInProgress.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        NumInProgress.ForeColor = Color.FromArgb(CByte(192), CByte(64), CByte(0))
        NumInProgress.Location = New Point(24, 66)
        NumInProgress.Name = "NumInProgress"
        NumInProgress.Size = New Size(37, 30)
        NumInProgress.TabIndex = 10
        NumInProgress.Text = "00"
        ' 
        ' LabelInProgress
        ' 
        LabelInProgress.AutoSize = True
        LabelInProgress.Font = New Font("Verdana", 12F)
        LabelInProgress.ForeColor = SystemColors.ControlDarkDark
        LabelInProgress.Location = New Point(24, 25)
        LabelInProgress.Name = "LabelInProgress"
        LabelInProgress.Size = New Size(101, 18)
        LabelInProgress.TabIndex = 8
        LabelInProgress.Text = "In Progress"
        ' 
        ' PanelCompleted
        ' 
        PanelCompleted.BackColor = Color.White
        PanelCompleted.Controls.Add(IconComplete)
        PanelCompleted.Controls.Add(NumCompleted)
        PanelCompleted.Controls.Add(LabelCompleted)
        PanelCompleted.CornerRadius = 12
        PanelCompleted.Location = New Point(459, 271)
        PanelCompleted.Name = "PanelCompleted"
        PanelCompleted.Size = New Size(367, 115)
        PanelCompleted.TabIndex = 18
        ' 
        ' IconComplete
        ' 
        IconComplete.Image = My.Resources.Resources.greenCompleted
        IconComplete.Location = New Point(286, 36)
        IconComplete.Name = "IconComplete"
        IconComplete.Size = New Size(48, 50)
        IconComplete.SizeMode = PictureBoxSizeMode.Zoom
        IconComplete.TabIndex = 10
        IconComplete.TabStop = False
        ' 
        ' NumCompleted
        ' 
        NumCompleted.AutoSize = True
        NumCompleted.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        NumCompleted.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        NumCompleted.Location = New Point(24, 66)
        NumCompleted.Name = "NumCompleted"
        NumCompleted.Size = New Size(37, 30)
        NumCompleted.TabIndex = 9
        NumCompleted.Text = "00"
        ' 
        ' LabelCompleted
        ' 
        LabelCompleted.AutoSize = True
        LabelCompleted.Font = New Font("Verdana", 12F)
        LabelCompleted.ForeColor = SystemColors.ControlDarkDark
        LabelCompleted.Location = New Point(24, 25)
        LabelCompleted.Name = "LabelCompleted"
        LabelCompleted.Size = New Size(96, 18)
        LabelCompleted.TabIndex = 8
        LabelCompleted.Text = "Completed"
        ' 
        ' PanelTotalRequest
        ' 
        PanelTotalRequest.BackColor = Color.White
        PanelTotalRequest.Controls.Add(IconTotalRequest)
        PanelTotalRequest.Controls.Add(NumTotalInstalRequest)
        PanelTotalRequest.Controls.Add(LabelTotalInstallations)
        PanelTotalRequest.CornerRadius = 12
        PanelTotalRequest.Location = New Point(47, 271)
        PanelTotalRequest.Name = "PanelTotalRequest"
        PanelTotalRequest.Size = New Size(367, 115)
        PanelTotalRequest.TabIndex = 17
        ' 
        ' IconTotalRequest
        ' 
        IconTotalRequest.Image = My.Resources.Resources.BLueWrench
        IconTotalRequest.Location = New Point(286, 36)
        IconTotalRequest.Name = "IconTotalRequest"
        IconTotalRequest.Size = New Size(48, 50)
        IconTotalRequest.SizeMode = PictureBoxSizeMode.Zoom
        IconTotalRequest.TabIndex = 9
        IconTotalRequest.TabStop = False
        ' 
        ' NumTotalInstalRequest
        ' 
        NumTotalInstalRequest.AutoSize = True
        NumTotalInstalRequest.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        NumTotalInstalRequest.Location = New Point(24, 66)
        NumTotalInstalRequest.Name = "NumTotalInstalRequest"
        NumTotalInstalRequest.Size = New Size(37, 30)
        NumTotalInstalRequest.TabIndex = 8
        NumTotalInstalRequest.Text = "00"
        ' 
        ' LabelTotalInstallations
        ' 
        LabelTotalInstallations.AutoSize = True
        LabelTotalInstallations.Font = New Font("Verdana", 12F)
        LabelTotalInstallations.ForeColor = SystemColors.ControlDarkDark
        LabelTotalInstallations.Location = New Point(24, 25)
        LabelTotalInstallations.Name = "LabelTotalInstallations"
        LabelTotalInstallations.Size = New Size(116, 18)
        LabelTotalInstallations.TabIndex = 8
        LabelTotalInstallations.Text = "Total request"
        ' 
        ' PanelServiceStatusDistribution
        ' 
        PanelServiceStatusDistribution.Anchor = AnchorStyles.Top
        PanelServiceStatusDistribution.BackColor = Color.White
        PanelServiceStatusDistribution.Controls.Add(PanelRound1)
        PanelServiceStatusDistribution.Controls.Add(SubscribersGrowth)
        PanelServiceStatusDistribution.CornerRadius = 12
        PanelServiceStatusDistribution.Location = New Point(173, 429)
        PanelServiceStatusDistribution.Name = "PanelServiceStatusDistribution"
        PanelServiceStatusDistribution.Size = New Size(778, 405)
        PanelServiceStatusDistribution.TabIndex = 21
        ' 
        ' PanelRound1
        ' 
        PanelRound1.Location = New Point(2, 35)
        PanelRound1.Name = "PanelRound1"
        PanelRound1.Size = New Size(775, 353)
        PanelRound1.TabIndex = 32
        ' 
        ' SubscribersGrowth
        ' 
        SubscribersGrowth.Anchor = AnchorStyles.Top
        SubscribersGrowth.AutoSize = True
        SubscribersGrowth.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        SubscribersGrowth.ForeColor = Color.Black
        SubscribersGrowth.Location = New Point(268, 12)
        SubscribersGrowth.Name = "SubscribersGrowth"
        SubscribersGrowth.Size = New Size(227, 18)
        SubscribersGrowth.TabIndex = 10
        SubscribersGrowth.Text = "Service Status Distribution"
        ' 
        ' ServiceStatusDistribution
        ' 
        ServiceStatusDistribution.Anchor = AnchorStyles.Top
        ServiceStatusDistribution.AutoSize = True
        ServiceStatusDistribution.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ServiceStatusDistribution.ForeColor = Color.Black
        ServiceStatusDistribution.Location = New Point(290, 12)
        ServiceStatusDistribution.Name = "ServiceStatusDistribution"
        ServiceStatusDistribution.Size = New Size(211, 18)
        ServiceStatusDistribution.TabIndex = 11
        ServiceStatusDistribution.Text = "Service Type Distribution"
        ' 
        ' PanelServiceTypeDistribution
        ' 
        PanelServiceTypeDistribution.Anchor = AnchorStyles.Top
        PanelServiceTypeDistribution.BackColor = Color.White
        PanelServiceTypeDistribution.Controls.Add(PanelRound2)
        PanelServiceTypeDistribution.Controls.Add(ServiceStatusDistribution)
        PanelServiceTypeDistribution.CornerRadius = 12
        PanelServiceTypeDistribution.Location = New Point(997, 429)
        PanelServiceTypeDistribution.Name = "PanelServiceTypeDistribution"
        PanelServiceTypeDistribution.Size = New Size(778, 405)
        PanelServiceTypeDistribution.TabIndex = 22
        ' 
        ' PanelRound2
        ' 
        PanelRound2.Location = New Point(3, 35)
        PanelRound2.Name = "PanelRound2"
        PanelRound2.Size = New Size(775, 353)
        PanelRound2.TabIndex = 33
        ' 
        ' LabelServiceRequestDetails
        ' 
        LabelServiceRequestDetails.AutoSize = True
        LabelServiceRequestDetails.Font = New Font("Verdana", 12F)
        LabelServiceRequestDetails.ForeColor = SystemColors.ControlText
        LabelServiceRequestDetails.Location = New Point(24, 25)
        LabelServiceRequestDetails.Name = "LabelServiceRequestDetails"
        LabelServiceRequestDetails.Size = New Size(203, 18)
        LabelServiceRequestDetails.TabIndex = 24
        LabelServiceRequestDetails.Text = "Service Request Details"
        ' 
        ' DataGridServiceRequestDetails
        ' 
        DataGridServiceRequestDetails.AllowUserToAddRows = False
        DataGridServiceRequestDetails.AllowUserToDeleteRows = False
        DataGridServiceRequestDetails.AllowUserToResizeColumns = False
        DataGridServiceRequestDetails.AllowUserToResizeRows = False
        DataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle13.WrapMode = DataGridViewTriState.True
        DataGridServiceRequestDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        DataGridServiceRequestDetails.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridServiceRequestDetails.BackgroundColor = Color.White
        DataGridServiceRequestDetails.BorderStyle = BorderStyle.None
        DataGridServiceRequestDetails.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridServiceRequestDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = Color.White
        DataGridViewCellStyle14.Font = New Font("Verdana", 10F, FontStyle.Bold)
        DataGridViewCellStyle14.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = DataGridViewTriState.True
        DataGridServiceRequestDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        DataGridServiceRequestDetails.ColumnHeadersHeight = 45
        DataGridServiceRequestDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridServiceRequestDetails.Columns.AddRange(New DataGridViewColumn() {ServiceID, Customer, ServiceType, colTimeRequested, DateRequested, colDateCompleted, ServiceCost, Technician, colServiceDescription, Status, ColTechNotes, colEdit, colDelete, colCheckBox})
        DataGridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = SystemColors.Window
        DataGridViewCellStyle22.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle22.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle22.SelectionBackColor = Color.White
        DataGridViewCellStyle22.SelectionForeColor = Color.Black
        DataGridViewCellStyle22.WrapMode = DataGridViewTriState.True
        DataGridServiceRequestDetails.DefaultCellStyle = DataGridViewCellStyle22
        DataGridServiceRequestDetails.EnableHeadersVisualStyles = False
        DataGridServiceRequestDetails.GridColor = Color.White
        DataGridServiceRequestDetails.Location = New Point(11, 74)
        DataGridServiceRequestDetails.Margin = New Padding(3, 2, 3, 2)
        DataGridServiceRequestDetails.Name = "DataGridServiceRequestDetails"
        DataGridServiceRequestDetails.ReadOnly = True
        DataGridServiceRequestDetails.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle23.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = SystemColors.Control
        DataGridViewCellStyle23.Font = New Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle23.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle23.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = DataGridViewTriState.True
        DataGridServiceRequestDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle23
        DataGridServiceRequestDetails.RowHeadersVisible = False
        DataGridServiceRequestDetails.RowHeadersWidth = 51
        DataGridViewCellStyle24.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle24.WrapMode = DataGridViewTriState.True
        DataGridServiceRequestDetails.RowsDefaultCellStyle = DataGridViewCellStyle24
        DataGridServiceRequestDetails.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridServiceRequestDetails.RowTemplate.DefaultCellStyle.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridServiceRequestDetails.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridServiceRequestDetails.RowTemplate.Height = 45
        DataGridServiceRequestDetails.ScrollBars = ScrollBars.Vertical
        DataGridServiceRequestDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridServiceRequestDetails.Size = New Size(1569, 503)
        DataGridServiceRequestDetails.TabIndex = 23
        ' 
        ' ServiceID
        ' 
        ServiceID.HeaderText = "Service ID"
        ServiceID.Name = "ServiceID"
        ServiceID.ReadOnly = True
        ' 
        ' Customer
        ' 
        Customer.HeaderText = "Customer Name"
        Customer.Name = "Customer"
        Customer.ReadOnly = True
        Customer.Width = 150
        ' 
        ' ServiceType
        ' 
        ServiceType.HeaderText = "Service Type"
        ServiceType.Name = "ServiceType"
        ServiceType.ReadOnly = True
        ServiceType.Width = 120
        ' 
        ' colTimeRequested
        ' 
        DataGridViewCellStyle15.Format = "t"
        DataGridViewCellStyle15.NullValue = Nothing
        DataGridViewCellStyle15.WrapMode = DataGridViewTriState.False
        colTimeRequested.DefaultCellStyle = DataGridViewCellStyle15
        colTimeRequested.HeaderText = "Time Requested"
        colTimeRequested.Name = "colTimeRequested"
        colTimeRequested.ReadOnly = True
        colTimeRequested.Width = 120
        ' 
        ' DateRequested
        ' 
        DataGridViewCellStyle16.Format = "d"
        DataGridViewCellStyle16.NullValue = Nothing
        DataGridViewCellStyle16.WrapMode = DataGridViewTriState.True
        DateRequested.DefaultCellStyle = DataGridViewCellStyle16
        DateRequested.HeaderText = "Date Requested"
        DateRequested.Name = "DateRequested"
        DateRequested.ReadOnly = True
        DateRequested.Width = 120
        ' 
        ' colDateCompleted
        ' 
        DataGridViewCellStyle17.Format = "d"
        DataGridViewCellStyle17.NullValue = Nothing
        DataGridViewCellStyle17.WrapMode = DataGridViewTriState.True
        colDateCompleted.DefaultCellStyle = DataGridViewCellStyle17
        colDateCompleted.HeaderText = "Date Completed"
        colDateCompleted.Name = "colDateCompleted"
        colDateCompleted.ReadOnly = True
        colDateCompleted.Width = 120
        ' 
        ' ServiceCost
        ' 
        DataGridViewCellStyle18.Padding = New Padding(35, 0, 0, 0)
        ServiceCost.DefaultCellStyle = DataGridViewCellStyle18
        ServiceCost.HeaderText = "Service Cost"
        ServiceCost.Name = "ServiceCost"
        ServiceCost.ReadOnly = True
        ServiceCost.Width = 120
        ' 
        ' Technician
        ' 
        Technician.HeaderText = "Technician"
        Technician.Name = "Technician"
        Technician.ReadOnly = True
        Technician.Width = 130
        ' 
        ' colServiceDescription
        ' 
        colServiceDescription.HeaderText = "Service Description"
        colServiceDescription.Name = "colServiceDescription"
        colServiceDescription.ReadOnly = True
        colServiceDescription.Width = 170
        ' 
        ' Status
        ' 
        DataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle19.ForeColor = Color.Black
        DataGridViewCellStyle19.WrapMode = DataGridViewTriState.True
        Status.DefaultCellStyle = DataGridViewCellStyle19
        Status.HeaderText = "Status"
        Status.Name = "Status"
        Status.ReadOnly = True
        ' 
        ' ColTechNotes
        ' 
        DataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.WrapMode = DataGridViewTriState.True
        ColTechNotes.DefaultCellStyle = DataGridViewCellStyle20
        ColTechNotes.HeaderText = "Technician Notes"
        ColTechNotes.Name = "ColTechNotes"
        ColTechNotes.ReadOnly = True
        ColTechNotes.Width = 180
        ' 
        ' colEdit
        ' 
        colEdit.HeaderText = ""
        colEdit.Image = My.Resources.Resources.edit
        colEdit.Name = "colEdit"
        colEdit.ReadOnly = True
        colEdit.Width = 40
        ' 
        ' colDelete
        ' 
        colDelete.HeaderText = ""
        colDelete.Image = My.Resources.Resources.delete1
        colDelete.Name = "colDelete"
        colDelete.ReadOnly = True
        colDelete.Width = 40
        ' 
        ' colCheckBox
        ' 
        colCheckBox.DefaultCellStyle = DataGridViewCellStyle21
        colCheckBox.HeaderText = ""
        colCheckBox.Name = "colCheckBox"
        colCheckBox.ReadOnly = True
        colCheckBox.Width = 40
        ' 
        ' PanelInstallationDetails
        ' 
        PanelInstallationDetails.BackColor = Color.White
        PanelInstallationDetails.Controls.Add(deleteAll)
        PanelInstallationDetails.Controls.Add(LblPageInfo)
        PanelInstallationDetails.Controls.Add(btnSalesPreviousSA)
        PanelInstallationDetails.Controls.Add(btnNextInstallationSA)
        PanelInstallationDetails.Controls.Add(btnSelectInventory)
        PanelInstallationDetails.Controls.Add(btnAddInventory)
        PanelInstallationDetails.Controls.Add(txtInventorySearchSA)
        PanelInstallationDetails.Controls.Add(LabelServiceRequestDetails)
        PanelInstallationDetails.Controls.Add(DataGridServiceRequestDetails)
        PanelInstallationDetails.CornerRadius = 12
        PanelInstallationDetails.Location = New Point(47, 880)
        PanelInstallationDetails.Name = "PanelInstallationDetails"
        PanelInstallationDetails.Size = New Size(1583, 624)
        PanelInstallationDetails.TabIndex = 23
        ' 
        ' deleteAll
        ' 
        deleteAll.Image = My.Resources.Resources.delete2
        deleteAll.Location = New Point(1546, 30)
        deleteAll.Name = "deleteAll"
        deleteAll.Size = New Size(27, 18)
        deleteAll.SizeMode = PictureBoxSizeMode.Zoom
        deleteAll.TabIndex = 40
        deleteAll.TabStop = False
        ' 
        ' LblPageInfo
        ' 
        LblPageInfo.AutoSize = True
        LblPageInfo.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblPageInfo.ImageAlign = ContentAlignment.MiddleLeft
        LblPageInfo.Location = New Point(18, 588)
        LblPageInfo.Name = "LblPageInfo"
        LblPageInfo.Size = New Size(18, 18)
        LblPageInfo.TabIndex = 37
        LblPageInfo.Text = "0"
        ' 
        ' btnSalesPreviousSA
        ' 
        btnSalesPreviousSA.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnSalesPreviousSA.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSalesPreviousSA.ForeColor = Color.White
        btnSalesPreviousSA.Location = New Point(1398, 583)
        btnSalesPreviousSA.Name = "btnSalesPreviousSA"
        btnSalesPreviousSA.Size = New Size(75, 23)
        btnSalesPreviousSA.TabIndex = 36
        btnSalesPreviousSA.Text = "Previous"
        btnSalesPreviousSA.UseVisualStyleBackColor = False
        btnSalesPreviousSA.Visible = False
        ' 
        ' btnNextInstallationSA
        ' 
        btnNextInstallationSA.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnNextInstallationSA.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnNextInstallationSA.ForeColor = Color.White
        btnNextInstallationSA.Location = New Point(1479, 583)
        btnNextInstallationSA.Name = "btnNextInstallationSA"
        btnNextInstallationSA.Size = New Size(75, 23)
        btnNextInstallationSA.TabIndex = 35
        btnNextInstallationSA.Text = "Next"
        btnNextInstallationSA.UseVisualStyleBackColor = False
        ' 
        ' btnSelectInventory
        ' 
        btnSelectInventory.Image = My.Resources.Resources.selectall
        btnSelectInventory.Location = New Point(1524, 31)
        btnSelectInventory.Name = "btnSelectInventory"
        btnSelectInventory.Size = New Size(16, 16)
        btnSelectInventory.SizeMode = PictureBoxSizeMode.AutoSize
        btnSelectInventory.TabIndex = 34
        btnSelectInventory.TabStop = False
        ' 
        ' btnAddInventory
        ' 
        btnAddInventory.Image = My.Resources.Resources.Add
        btnAddInventory.Location = New Point(1494, 30)
        btnAddInventory.Name = "btnAddInventory"
        btnAddInventory.Size = New Size(19, 19)
        btnAddInventory.SizeMode = PictureBoxSizeMode.AutoSize
        btnAddInventory.TabIndex = 33
        btnAddInventory.TabStop = False
        ' 
        ' txtInventorySearchSA
        ' 
        txtInventorySearchSA.Font = New Font("Segoe UI", 12F)
        txtInventorySearchSA.Location = New Point(1214, 20)
        txtInventorySearchSA.Name = "txtInventorySearchSA"
        txtInventorySearchSA.PlaceholderText = "Search..."
        txtInventorySearchSA.Size = New Size(259, 29)
        txtInventorySearchSA.TabIndex = 32
        ' 
        ' service
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ButtonFace
        Controls.Add(PanelInstallationDetails)
        Controls.Add(PanelServiceStatusDistribution)
        Controls.Add(PanelServiceTypeDistribution)
        Controls.Add(PanelPending)
        Controls.Add(PanelInProgress)
        Controls.Add(PanelCompleted)
        Controls.Add(PanelTotalRequest)
        Controls.Add(HeaderServiceReport)
        Controls.Add(PanelFilters)
        Name = "service"
        Size = New Size(1940, 1912)
        PanelFilters.ResumeLayout(False)
        PanelFilters.PerformLayout()
        CType(IconFilter, ComponentModel.ISupportInitialize).EndInit()
        PanelPending.ResumeLayout(False)
        PanelPending.PerformLayout()
        CType(IconPending, ComponentModel.ISupportInitialize).EndInit()
        PanelInProgress.ResumeLayout(False)
        PanelInProgress.PerformLayout()
        CType(IconInProgress, ComponentModel.ISupportInitialize).EndInit()
        PanelCompleted.ResumeLayout(False)
        PanelCompleted.PerformLayout()
        CType(IconComplete, ComponentModel.ISupportInitialize).EndInit()
        PanelTotalRequest.ResumeLayout(False)
        PanelTotalRequest.PerformLayout()
        CType(IconTotalRequest, ComponentModel.ISupportInitialize).EndInit()
        PanelServiceStatusDistribution.ResumeLayout(False)
        PanelServiceStatusDistribution.PerformLayout()
        PanelServiceTypeDistribution.ResumeLayout(False)
        PanelServiceTypeDistribution.PerformLayout()
        CType(DataGridServiceRequestDetails, ComponentModel.ISupportInitialize).EndInit()
        PanelInstallationDetails.ResumeLayout(False)
        PanelInstallationDetails.PerformLayout()
        CType(deleteAll, ComponentModel.ISupportInitialize).EndInit()
        CType(btnSelectInventory, ComponentModel.ISupportInitialize).EndInit()
        CType(btnAddInventory, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents HeaderServiceReport As Label
    Friend WithEvents PanelFilters As PanelRound
    Friend WithEvents PanelExportReport As PanelRound
    Friend WithEvents LabelFilters As Label
    Friend WithEvents IconFilter As PictureBox
    Friend WithEvents ComboServiceType As ComboBox
    Friend WithEvents ComboDateRange As ComboBox
    Friend WithEvents LabelStatus As Label
    Friend WithEvents LabelDateRange As Label
    Friend WithEvents PanelPending As PanelRound
    Friend WithEvents IconPending As PictureBox
    Friend WithEvents NumPending As Label
    Friend WithEvents LabelRequested As Label
    Friend WithEvents PanelInProgress As PanelRound
    Friend WithEvents IconInProgress As PictureBox
    Friend WithEvents NumInProgress As Label
    Friend WithEvents LabelInProgress As Label
    Friend WithEvents PanelCompleted As PanelRound
    Friend WithEvents IconComplete As PictureBox
    Friend WithEvents NumCompleted As Label
    Friend WithEvents LabelCompleted As Label
    Friend WithEvents PanelTotalRequest As PanelRound
    Friend WithEvents IconTotalRequest As PictureBox
    Friend WithEvents NumTotalInstalRequest As Label
    Friend WithEvents LabelTotalInstallations As Label
    Friend WithEvents PanelServiceStatusDistribution As PanelRound
    Friend WithEvents SubscribersGrowth As Label
    Friend WithEvents ServiceStatusDistribution As Label
    Friend WithEvents PanelServiceTypeDistribution As PanelRound
    Friend WithEvents Label4 As Label
    Friend WithEvents LabelServiceRequestDetails As Label
    Friend WithEvents DataGridServiceRequestDetails As DataGridView
    Friend WithEvents PanelInstallationDetails As PanelRound
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnSelectInventory As PictureBox
    Friend WithEvents btnAddInventory As PictureBox
    Friend WithEvents txtInventorySearchSA As TextBox
    Friend WithEvents btnSalesPreviousSA As Button
    Friend WithEvents btnNextInstallationSA As Button
    Friend WithEvents PanelRound1 As PanelRound
    Friend WithEvents PanelRound2 As PanelRound
    Friend WithEvents LblPageInfo As Label
    Friend WithEvents ServiceID As DataGridViewTextBoxColumn
    Friend WithEvents Customer As DataGridViewTextBoxColumn
    Friend WithEvents ServiceType As DataGridViewTextBoxColumn
    Friend WithEvents colTimeRequested As DataGridViewTextBoxColumn
    Friend WithEvents DateRequested As DataGridViewTextBoxColumn
    Friend WithEvents colDateCompleted As DataGridViewTextBoxColumn
    Friend WithEvents ServiceCost As DataGridViewTextBoxColumn
    Friend WithEvents Technician As DataGridViewTextBoxColumn
    Friend WithEvents colServiceDescription As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents ColTechNotes As DataGridViewTextBoxColumn
    Friend WithEvents colEdit As DataGridViewImageColumn
    Friend WithEvents colDelete As DataGridViewImageColumn
    Friend WithEvents colCheckBox As DataGridViewCheckBoxColumn
    Friend WithEvents cbStatus As ComboBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents deleteAll As PictureBox
    Friend WithEvents btnExport As ButtonRounded

End Class
