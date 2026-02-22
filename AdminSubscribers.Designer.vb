<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminSubscribers
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdminSubscribers))
        txtSubscriberSearchSA = New TextBox()
        LblSubsByPlan = New Label()
        pnlAccDistri = New PanelRound()
        Panel2 = New Panel()
        LblAccDistri = New Label()
        dgvSubsDeets = New DataGridView()
        colCustomerID = New DataGridViewTextBoxColumn()
        colName = New DataGridViewTextBoxColumn()
        colAddress = New DataGridViewTextBoxColumn()
        colPlanType = New DataGridViewTextBoxColumn()
        colMonthlyRate = New DataGridViewTextBoxColumn()
        colDateInstalled = New DataGridViewTextBoxColumn()
        colStatus = New DataGridViewTextBoxColumn()
        colEditIcon = New DataGridViewImageColumn()
        colDeleteIcon = New DataGridViewImageColumn()
        colSelect = New DataGridViewCheckBoxColumn()
        Panel1 = New Panel()
        PanelRound1 = New PanelRound()
        deleteAll = New PictureBox()
        LblPageInfo = New Label()
        btnSelectSubscriber = New PictureBox()
        btnSubscriberPreviousSA = New Button()
        btnNext = New Button()
        Label1 = New Label()
        btnExport = New ButtonRounded()
        pnlSubsPlan = New PanelRound()
        pnlFilters = New PanelRound()
        ComboBoxDate = New ComboBox()
        DateRangeLbl = New Label()
        CBPlanType = New ComboBox()
        CBAccStat = New ComboBox()
        LblPlanType = New Label()
        LblAccStatus = New Label()
        LblFilters = New Label()
        LblSubsReport = New Label()
        pnlTotalSubs = New PanelRound()
        picTotalSubs = New PictureBox()
        totalSub = New Label()
        LblTotalSubs = New Label()
        LblAvgRevPerSub = New Label()
        pnlActiveSUBS = New PanelRound()
        picActiveSub = New PictureBox()
        ActiveSubs = New Label()
        Label2 = New Label()
        pnlMonthlyRev = New PanelRound()
        picMonthRev = New PictureBox()
        monthlyRevenues = New Label()
        LblMonthlyRevs = New Label()
        pnlAvgSub = New PanelRound()
        picAvgSub = New PictureBox()
        AvgRev = New Label()
        Panel4 = New Panel()
        pnlAccDistri.SuspendLayout()
        CType(dgvSubsDeets, ComponentModel.ISupportInitialize).BeginInit()
        PanelRound1.SuspendLayout()
        CType(deleteAll, ComponentModel.ISupportInitialize).BeginInit()
        CType(btnSelectSubscriber, ComponentModel.ISupportInitialize).BeginInit()
        pnlSubsPlan.SuspendLayout()
        pnlFilters.SuspendLayout()
        pnlTotalSubs.SuspendLayout()
        CType(picTotalSubs, ComponentModel.ISupportInitialize).BeginInit()
        pnlActiveSUBS.SuspendLayout()
        CType(picActiveSub, ComponentModel.ISupportInitialize).BeginInit()
        pnlMonthlyRev.SuspendLayout()
        CType(picMonthRev, ComponentModel.ISupportInitialize).BeginInit()
        pnlAvgSub.SuspendLayout()
        CType(picAvgSub, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtSubscriberSearchSA
        ' 
        txtSubscriberSearchSA.Font = New Font("Segoe UI", 12F)
        txtSubscriberSearchSA.Location = New Point(1241, 14)
        txtSubscriberSearchSA.Name = "txtSubscriberSearchSA"
        txtSubscriberSearchSA.PlaceholderText = "Search..."
        txtSubscriberSearchSA.Size = New Size(259, 29)
        txtSubscriberSearchSA.TabIndex = 26
        ' 
        ' LblSubsByPlan
        ' 
        LblSubsByPlan.AutoSize = True
        LblSubsByPlan.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblSubsByPlan.ImageAlign = ContentAlignment.MiddleLeft
        LblSubsByPlan.Location = New Point(28, 19)
        LblSubsByPlan.Name = "LblSubsByPlan"
        LblSubsByPlan.Size = New Size(210, 18)
        LblSubsByPlan.TabIndex = 5
        LblSubsByPlan.Text = "Subscribers by Plan Type"
        ' 
        ' pnlAccDistri
        ' 
        pnlAccDistri.BackColor = Color.White
        pnlAccDistri.Controls.Add(Panel2)
        pnlAccDistri.Controls.Add(LblAccDistri)
        pnlAccDistri.Location = New Point(847, 398)
        pnlAccDistri.Margin = New Padding(3, 2, 3, 2)
        pnlAccDistri.Name = "pnlAccDistri"
        pnlAccDistri.Size = New Size(778, 405)
        pnlAccDistri.TabIndex = 23
        ' 
        ' Panel2
        ' 
        Panel2.Location = New Point(24, 42)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(729, 292)
        Panel2.TabIndex = 6
        ' 
        ' LblAccDistri
        ' 
        LblAccDistri.AutoSize = True
        LblAccDistri.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblAccDistri.ImageAlign = ContentAlignment.MiddleLeft
        LblAccDistri.Location = New Point(28, 19)
        LblAccDistri.Name = "LblAccDistri"
        LblAccDistri.Size = New Size(233, 18)
        LblAccDistri.TabIndex = 5
        LblAccDistri.Text = "Account Status Distribution"
        ' 
        ' dgvSubsDeets
        ' 
        dgvSubsDeets.AllowUserToAddRows = False
        dgvSubsDeets.AllowUserToDeleteRows = False
        dgvSubsDeets.AllowUserToResizeColumns = False
        dgvSubsDeets.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = Color.Black
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvSubsDeets.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvSubsDeets.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvSubsDeets.BackgroundColor = Color.White
        dgvSubsDeets.BorderStyle = BorderStyle.None
        dgvSubsDeets.CellBorderStyle = DataGridViewCellBorderStyle.None
        dgvSubsDeets.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Verdana", 10F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = Color.White
        DataGridViewCellStyle2.SelectionForeColor = Color.Black
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvSubsDeets.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvSubsDeets.ColumnHeadersHeight = 45
        dgvSubsDeets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvSubsDeets.Columns.AddRange(New DataGridViewColumn() {colCustomerID, colName, colAddress, colPlanType, colMonthlyRate, colDateInstalled, colStatus, colEditIcon, colDeleteIcon, colSelect})
        DataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = SystemColors.Window
        DataGridViewCellStyle10.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle10.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = Color.White
        DataGridViewCellStyle10.SelectionForeColor = Color.Black
        DataGridViewCellStyle10.WrapMode = DataGridViewTriState.False
        dgvSubsDeets.DefaultCellStyle = DataGridViewCellStyle10
        dgvSubsDeets.EnableHeadersVisualStyles = False
        dgvSubsDeets.GridColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        dgvSubsDeets.Location = New Point(26, 55)
        dgvSubsDeets.Margin = New Padding(3, 2, 3, 2)
        dgvSubsDeets.Name = "dgvSubsDeets"
        dgvSubsDeets.ReadOnly = True
        dgvSubsDeets.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = Color.White
        DataGridViewCellStyle11.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle11.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = Color.White
        DataGridViewCellStyle11.SelectionForeColor = Color.Black
        DataGridViewCellStyle11.WrapMode = DataGridViewTriState.True
        dgvSubsDeets.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        dgvSubsDeets.RowHeadersVisible = False
        DataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle12.WrapMode = DataGridViewTriState.True
        dgvSubsDeets.RowsDefaultCellStyle = DataGridViewCellStyle12
        dgvSubsDeets.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvSubsDeets.RowTemplate.DefaultCellStyle.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        dgvSubsDeets.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvSubsDeets.RowTemplate.Height = 40
        dgvSubsDeets.RowTemplate.ReadOnly = True
        dgvSubsDeets.ScrollBars = ScrollBars.Vertical
        dgvSubsDeets.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSubsDeets.Size = New Size(1551, 473)
        dgvSubsDeets.TabIndex = 0
        ' 
        ' colCustomerID
        ' 
        colCustomerID.DataPropertyName = "CustomerID"
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.Padding = New Padding(5, 0, 10, 0)
        colCustomerID.DefaultCellStyle = DataGridViewCellStyle3
        colCustomerID.FillWeight = 90.8002243F
        colCustomerID.HeaderText = "Customer ID"
        colCustomerID.MinimumWidth = 6
        colCustomerID.Name = "colCustomerID"
        colCustomerID.ReadOnly = True
        colCustomerID.Width = 156
        ' 
        ' colName
        ' 
        colName.DataPropertyName = "Name"
        DataGridViewCellStyle4.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle4.Padding = New Padding(10, 0, 10, 0)
        colName.DefaultCellStyle = DataGridViewCellStyle4
        colName.FillWeight = 53.81019F
        colName.HeaderText = "Customer Name"
        colName.MinimumWidth = 100
        colName.Name = "colName"
        colName.ReadOnly = True
        colName.Width = 270
        ' 
        ' colAddress
        ' 
        colAddress.DataPropertyName = "Address"
        DataGridViewCellStyle5.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        colAddress.DefaultCellStyle = DataGridViewCellStyle5
        colAddress.FillWeight = 59.00358F
        colAddress.HeaderText = "Address"
        colAddress.MinimumWidth = 100
        colAddress.Name = "colAddress"
        colAddress.ReadOnly = True
        colAddress.Width = 330
        ' 
        ' colPlanType
        ' 
        colPlanType.DataPropertyName = "PlanType"
        DataGridViewCellStyle6.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle6.Padding = New Padding(10, 0, 10, 0)
        colPlanType.DefaultCellStyle = DataGridViewCellStyle6
        colPlanType.FillWeight = 62.09049F
        colPlanType.HeaderText = "Plan Type"
        colPlanType.MinimumWidth = 6
        colPlanType.Name = "colPlanType"
        colPlanType.ReadOnly = True
        colPlanType.Width = 150
        ' 
        ' colMonthlyRate
        ' 
        colMonthlyRate.DataPropertyName = "MonthlyRate"
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle7.ForeColor = Color.Black
        DataGridViewCellStyle7.Format = "C2"
        DataGridViewCellStyle7.NullValue = Nothing
        DataGridViewCellStyle7.WrapMode = DataGridViewTriState.True
        colMonthlyRate.DefaultCellStyle = DataGridViewCellStyle7
        colMonthlyRate.FillWeight = 79.3092346F
        colMonthlyRate.HeaderText = "Monthly Rate"
        colMonthlyRate.MinimumWidth = 6
        colMonthlyRate.Name = "colMonthlyRate"
        colMonthlyRate.ReadOnly = True
        colMonthlyRate.Width = 200
        ' 
        ' colDateInstalled
        ' 
        colDateInstalled.DataPropertyName = "DateInstalled"
        DataGridViewCellStyle8.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        colDateInstalled.DefaultCellStyle = DataGridViewCellStyle8
        colDateInstalled.FillWeight = 106.250275F
        colDateInstalled.HeaderText = "Date Installed"
        colDateInstalled.MinimumWidth = 6
        colDateInstalled.Name = "colDateInstalled"
        colDateInstalled.ReadOnly = True
        colDateInstalled.Width = 200
        ' 
        ' colStatus
        ' 
        colStatus.DataPropertyName = "Status"
        DataGridViewCellStyle9.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        colStatus.DefaultCellStyle = DataGridViewCellStyle9
        colStatus.FillWeight = 135.081757F
        colStatus.HeaderText = "Status"
        colStatus.MinimumWidth = 6
        colStatus.Name = "colStatus"
        colStatus.ReadOnly = True
        ' 
        ' colEditIcon
        ' 
        colEditIcon.FillWeight = 73.85386F
        colEditIcon.HeaderText = ""
        colEditIcon.Image = My.Resources.Resources.edit
        colEditIcon.MinimumWidth = 6
        colEditIcon.Name = "colEditIcon"
        colEditIcon.ReadOnly = True
        colEditIcon.Width = 40
        ' 
        ' colDeleteIcon
        ' 
        colDeleteIcon.FillWeight = 88.8154F
        colDeleteIcon.HeaderText = ""
        colDeleteIcon.Image = My.Resources.Resources.delete1
        colDeleteIcon.MinimumWidth = 6
        colDeleteIcon.Name = "colDeleteIcon"
        colDeleteIcon.ReadOnly = True
        colDeleteIcon.Width = 40
        ' 
        ' colSelect
        ' 
        colSelect.FillWeight = 106.623955F
        colSelect.HeaderText = ""
        colSelect.MinimumWidth = 6
        colSelect.Name = "colSelect"
        colSelect.ReadOnly = True
        colSelect.Width = 40
        ' 
        ' Panel1
        ' 
        Panel1.Location = New Point(13, 42)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(743, 292)
        Panel1.TabIndex = 6
        ' 
        ' PanelRound1
        ' 
        PanelRound1.BackColor = Color.White
        PanelRound1.Controls.Add(deleteAll)
        PanelRound1.Controls.Add(LblPageInfo)
        PanelRound1.Controls.Add(btnSelectSubscriber)
        PanelRound1.Controls.Add(btnSubscriberPreviousSA)
        PanelRound1.Controls.Add(btnNext)
        PanelRound1.Controls.Add(txtSubscriberSearchSA)
        PanelRound1.Controls.Add(dgvSubsDeets)
        PanelRound1.Controls.Add(Label1)
        PanelRound1.Location = New Point(23, 827)
        PanelRound1.Margin = New Padding(3, 2, 3, 2)
        PanelRound1.Name = "PanelRound1"
        PanelRound1.Size = New Size(1597, 576)
        PanelRound1.TabIndex = 24
        ' 
        ' deleteAll
        ' 
        deleteAll.Image = My.Resources.Resources.delete2
        deleteAll.Location = New Point(1536, 20)
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
        LblPageInfo.Location = New Point(13, 545)
        LblPageInfo.Name = "LblPageInfo"
        LblPageInfo.Size = New Size(18, 18)
        LblPageInfo.TabIndex = 38
        LblPageInfo.Text = "0"
        ' 
        ' btnSelectSubscriber
        ' 
        btnSelectSubscriber.Image = My.Resources.Resources.selectall
        btnSelectSubscriber.Location = New Point(1516, 21)
        btnSelectSubscriber.Name = "btnSelectSubscriber"
        btnSelectSubscriber.Size = New Size(16, 16)
        btnSelectSubscriber.SizeMode = PictureBoxSizeMode.AutoSize
        btnSelectSubscriber.TabIndex = 31
        btnSelectSubscriber.TabStop = False
        ' 
        ' btnSubscriberPreviousSA
        ' 
        btnSubscriberPreviousSA.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnSubscriberPreviousSA.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSubscriberPreviousSA.ForeColor = Color.White
        btnSubscriberPreviousSA.Location = New Point(1407, 540)
        btnSubscriberPreviousSA.Name = "btnSubscriberPreviousSA"
        btnSubscriberPreviousSA.Size = New Size(75, 23)
        btnSubscriberPreviousSA.TabIndex = 28
        btnSubscriberPreviousSA.Text = "Previous"
        btnSubscriberPreviousSA.UseVisualStyleBackColor = False
        btnSubscriberPreviousSA.Visible = False
        ' 
        ' btnNext
        ' 
        btnNext.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnNext.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnNext.ForeColor = Color.White
        btnNext.Location = New Point(1488, 540)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(75, 23)
        btnNext.TabIndex = 27
        btnNext.Text = "Next"
        btnNext.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ImageAlign = ContentAlignment.MiddleLeft
        Label1.Location = New Point(28, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(156, 18)
        Label1.TabIndex = 5
        Label1.Text = "Subscriber Details"
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
        btnExport.Location = New Point(1440, -7)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(0, 41)
        btnExport.TabIndex = 25
        btnExport.Text = "Export Report"
        btnExport.UseVisualStyleBackColor = False
        ' 
        ' pnlSubsPlan
        ' 
        pnlSubsPlan.BackColor = Color.White
        pnlSubsPlan.Controls.Add(Panel1)
        pnlSubsPlan.Controls.Add(LblSubsByPlan)
        pnlSubsPlan.Location = New Point(23, 398)
        pnlSubsPlan.Margin = New Padding(3, 2, 3, 2)
        pnlSubsPlan.Name = "pnlSubsPlan"
        pnlSubsPlan.Size = New Size(778, 405)
        pnlSubsPlan.TabIndex = 22
        ' 
        ' pnlFilters
        ' 
        pnlFilters.BackColor = Color.White
        pnlFilters.Controls.Add(ComboBoxDate)
        pnlFilters.Controls.Add(DateRangeLbl)
        pnlFilters.Controls.Add(CBPlanType)
        pnlFilters.Controls.Add(CBAccStat)
        pnlFilters.Controls.Add(LblPlanType)
        pnlFilters.Controls.Add(LblAccStatus)
        pnlFilters.Controls.Add(LblFilters)
        pnlFilters.Location = New Point(23, 65)
        pnlFilters.Margin = New Padding(3, 2, 3, 2)
        pnlFilters.Name = "pnlFilters"
        pnlFilters.Size = New Size(1597, 165)
        pnlFilters.TabIndex = 17
        ' 
        ' ComboBoxDate
        ' 
        ComboBoxDate.BackColor = SystemColors.ButtonFace
        ComboBoxDate.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxDate.Font = New Font("Segoe UI", 14F)
        ComboBoxDate.ForeColor = SystemColors.WindowText
        ComboBoxDate.FormattingEnabled = True
        ComboBoxDate.Items.AddRange(New Object() {"All Times", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        ComboBoxDate.Location = New Point(29, 91)
        ComboBoxDate.MinimumSize = New Size(193, 0)
        ComboBoxDate.Name = "ComboBoxDate"
        ComboBoxDate.Size = New Size(265, 33)
        ComboBoxDate.TabIndex = 8
        ' 
        ' DateRangeLbl
        ' 
        DateRangeLbl.AutoSize = True
        DateRangeLbl.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        DateRangeLbl.Location = New Point(29, 67)
        DateRangeLbl.Name = "DateRangeLbl"
        DateRangeLbl.Size = New Size(94, 21)
        DateRangeLbl.TabIndex = 7
        DateRangeLbl.Text = "Date Range"
        ' 
        ' CBPlanType
        ' 
        CBPlanType.DropDownStyle = ComboBoxStyle.DropDownList
        CBPlanType.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CBPlanType.FormattingEnabled = True
        CBPlanType.Items.AddRange(New Object() {"All Plans", "Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})
        CBPlanType.Location = New Point(319, 90)
        CBPlanType.Margin = New Padding(3, 2, 3, 2)
        CBPlanType.Name = "CBPlanType"
        CBPlanType.Size = New Size(187, 33)
        CBPlanType.TabIndex = 4
        ' 
        ' CBAccStat
        ' 
        CBAccStat.DropDownStyle = ComboBoxStyle.DropDownList
        CBAccStat.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CBAccStat.FormattingEnabled = True
        CBAccStat.Items.AddRange(New Object() {"All Status", "Active", "Suspended", "Cancelled"})
        CBAccStat.Location = New Point(527, 90)
        CBAccStat.Margin = New Padding(3, 2, 3, 2)
        CBAccStat.Name = "CBAccStat"
        CBAccStat.Size = New Size(151, 33)
        CBAccStat.TabIndex = 3
        ' 
        ' LblPlanType
        ' 
        LblPlanType.AutoSize = True
        LblPlanType.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblPlanType.Location = New Point(321, 67)
        LblPlanType.Name = "LblPlanType"
        LblPlanType.Size = New Size(79, 21)
        LblPlanType.TabIndex = 2
        LblPlanType.Text = "Plan Type"
        ' 
        ' LblAccStatus
        ' 
        LblAccStatus.AutoSize = True
        LblAccStatus.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblAccStatus.Location = New Point(527, 67)
        LblAccStatus.Name = "LblAccStatus"
        LblAccStatus.Size = New Size(120, 21)
        LblAccStatus.TabIndex = 1
        LblAccStatus.Text = "Account Status"
        ' 
        ' LblFilters
        ' 
        LblFilters.AutoSize = True
        LblFilters.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblFilters.Image = CType(resources.GetObject("LblFilters.Image"), Image)
        LblFilters.ImageAlign = ContentAlignment.MiddleLeft
        LblFilters.Location = New Point(26, 33)
        LblFilters.Name = "LblFilters"
        LblFilters.Size = New Size(83, 18)
        LblFilters.TabIndex = 0
        LblFilters.Text = "    Filters"
        ' 
        ' LblSubsReport
        ' 
        LblSubsReport.AutoSize = True
        LblSubsReport.Font = New Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblSubsReport.Location = New Point(23, 23)
        LblSubsReport.Name = "LblSubsReport"
        LblSubsReport.Size = New Size(174, 28)
        LblSubsReport.TabIndex = 16
        LblSubsReport.Text = "Subscriber Report"
        ' 
        ' pnlTotalSubs
        ' 
        pnlTotalSubs.BackColor = Color.White
        pnlTotalSubs.Controls.Add(picTotalSubs)
        pnlTotalSubs.Controls.Add(totalSub)
        pnlTotalSubs.Controls.Add(LblTotalSubs)
        pnlTotalSubs.Location = New Point(23, 258)
        pnlTotalSubs.Margin = New Padding(3, 2, 3, 2)
        pnlTotalSubs.Name = "pnlTotalSubs"
        pnlTotalSubs.Size = New Size(367, 115)
        pnlTotalSubs.TabIndex = 18
        ' 
        ' picTotalSubs
        ' 
        picTotalSubs.Image = CType(resources.GetObject("picTotalSubs.Image"), Image)
        picTotalSubs.Location = New Point(263, 29)
        picTotalSubs.Margin = New Padding(3, 2, 3, 2)
        picTotalSubs.Name = "picTotalSubs"
        picTotalSubs.Size = New Size(48, 50)
        picTotalSubs.TabIndex = 7
        picTotalSubs.TabStop = False
        ' 
        ' totalSub
        ' 
        totalSub.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        totalSub.AutoSize = True
        totalSub.Font = New Font("Verdana", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        totalSub.ForeColor = Color.Black
        totalSub.Location = New Point(29, 54)
        totalSub.Name = "totalSub"
        totalSub.Size = New Size(90, 25)
        totalSub.TabIndex = 6
        totalSub.Text = "999999"
        totalSub.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblTotalSubs
        ' 
        LblTotalSubs.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LblTotalSubs.AutoSize = True
        LblTotalSubs.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblTotalSubs.Location = New Point(26, 14)
        LblTotalSubs.Name = "LblTotalSubs"
        LblTotalSubs.Size = New Size(147, 18)
        LblTotalSubs.TabIndex = 5
        LblTotalSubs.Text = "Total Subscribers"
        ' 
        ' LblAvgRevPerSub
        ' 
        LblAvgRevPerSub.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LblAvgRevPerSub.AutoSize = True
        LblAvgRevPerSub.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblAvgRevPerSub.Location = New Point(26, 14)
        LblAvgRevPerSub.Name = "LblAvgRevPerSub"
        LblAvgRevPerSub.Size = New Size(236, 18)
        LblAvgRevPerSub.TabIndex = 5
        LblAvgRevPerSub.Text = "Avg Revenue per Subscriber"
        LblAvgRevPerSub.TextAlign = ContentAlignment.TopCenter
        ' 
        ' pnlActiveSUBS
        ' 
        pnlActiveSUBS.BackColor = Color.White
        pnlActiveSUBS.Controls.Add(picActiveSub)
        pnlActiveSUBS.Controls.Add(ActiveSubs)
        pnlActiveSUBS.Controls.Add(Label2)
        pnlActiveSUBS.Location = New Point(434, 258)
        pnlActiveSUBS.Margin = New Padding(3, 2, 3, 2)
        pnlActiveSUBS.Name = "pnlActiveSUBS"
        pnlActiveSUBS.Size = New Size(367, 115)
        pnlActiveSUBS.TabIndex = 19
        ' 
        ' picActiveSub
        ' 
        picActiveSub.Location = New Point(271, 29)
        picActiveSub.Margin = New Padding(3, 2, 3, 2)
        picActiveSub.Name = "picActiveSub"
        picActiveSub.Size = New Size(48, 50)
        picActiveSub.TabIndex = 8
        picActiveSub.TabStop = False
        ' 
        ' ActiveSubs
        ' 
        ActiveSubs.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ActiveSubs.AutoSize = True
        ActiveSubs.Font = New Font("Verdana", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ActiveSubs.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        ActiveSubs.Location = New Point(29, 54)
        ActiveSubs.Name = "ActiveSubs"
        ActiveSubs.Size = New Size(90, 25)
        ActiveSubs.TabIndex = 6
        ActiveSubs.Text = "999999"
        ActiveSubs.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Label2.AutoSize = True
        Label2.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(26, 14)
        Label2.Name = "Label2"
        Label2.Size = New Size(157, 18)
        Label2.TabIndex = 5
        Label2.Text = "Active Subscribers"
        ' 
        ' pnlMonthlyRev
        ' 
        pnlMonthlyRev.BackColor = Color.White
        pnlMonthlyRev.Controls.Add(picMonthRev)
        pnlMonthlyRev.Controls.Add(monthlyRevenues)
        pnlMonthlyRev.Controls.Add(LblMonthlyRevs)
        pnlMonthlyRev.Location = New Point(847, 258)
        pnlMonthlyRev.Margin = New Padding(3, 2, 3, 2)
        pnlMonthlyRev.Name = "pnlMonthlyRev"
        pnlMonthlyRev.Size = New Size(367, 115)
        pnlMonthlyRev.TabIndex = 20
        ' 
        ' picMonthRev
        ' 
        picMonthRev.Image = CType(resources.GetObject("picMonthRev.Image"), Image)
        picMonthRev.Location = New Point(273, 29)
        picMonthRev.Margin = New Padding(3, 2, 3, 2)
        picMonthRev.Name = "picMonthRev"
        picMonthRev.Size = New Size(48, 50)
        picMonthRev.TabIndex = 8
        picMonthRev.TabStop = False
        ' 
        ' monthlyRevenues
        ' 
        monthlyRevenues.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        monthlyRevenues.AutoSize = True
        monthlyRevenues.Font = New Font("Verdana", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        monthlyRevenues.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        monthlyRevenues.Location = New Point(29, 54)
        monthlyRevenues.Name = "monthlyRevenues"
        monthlyRevenues.Size = New Size(90, 25)
        monthlyRevenues.TabIndex = 6
        monthlyRevenues.Text = "999999"
        monthlyRevenues.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblMonthlyRevs
        ' 
        LblMonthlyRevs.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LblMonthlyRevs.AutoSize = True
        LblMonthlyRevs.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblMonthlyRevs.Location = New Point(26, 14)
        LblMonthlyRevs.Name = "LblMonthlyRevs"
        LblMonthlyRevs.Size = New Size(157, 18)
        LblMonthlyRevs.TabIndex = 5
        LblMonthlyRevs.Text = "Monthly Revenues"
        LblMonthlyRevs.TextAlign = ContentAlignment.TopCenter
        ' 
        ' pnlAvgSub
        ' 
        pnlAvgSub.BackColor = Color.White
        pnlAvgSub.Controls.Add(picAvgSub)
        pnlAvgSub.Controls.Add(AvgRev)
        pnlAvgSub.Controls.Add(LblAvgRevPerSub)
        pnlAvgSub.Location = New Point(1253, 258)
        pnlAvgSub.Margin = New Padding(3, 2, 3, 2)
        pnlAvgSub.Name = "pnlAvgSub"
        pnlAvgSub.Size = New Size(367, 115)
        pnlAvgSub.TabIndex = 21
        ' 
        ' picAvgSub
        ' 
        picAvgSub.Image = CType(resources.GetObject("picAvgSub.Image"), Image)
        picAvgSub.Location = New Point(269, 29)
        picAvgSub.Margin = New Padding(3, 2, 3, 2)
        picAvgSub.Name = "picAvgSub"
        picAvgSub.Size = New Size(48, 50)
        picAvgSub.TabIndex = 8
        picAvgSub.TabStop = False
        ' 
        ' AvgRev
        ' 
        AvgRev.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        AvgRev.AutoSize = True
        AvgRev.Font = New Font("Verdana", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        AvgRev.ForeColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        AvgRev.Location = New Point(29, 54)
        AvgRev.Name = "AvgRev"
        AvgRev.Size = New Size(90, 25)
        AvgRev.TabIndex = 6
        AvgRev.Text = "999999"
        AvgRev.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel4
        ' 
        Panel4.Location = New Point(23, 1434)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(1598, 49)
        Panel4.TabIndex = 51
        ' 
        ' AdminSubscribers
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ButtonFace
        Controls.Add(Panel4)
        Controls.Add(pnlAccDistri)
        Controls.Add(PanelRound1)
        Controls.Add(btnExport)
        Controls.Add(pnlSubsPlan)
        Controls.Add(pnlFilters)
        Controls.Add(LblSubsReport)
        Controls.Add(pnlTotalSubs)
        Controls.Add(pnlActiveSUBS)
        Controls.Add(pnlMonthlyRev)
        Controls.Add(pnlAvgSub)
        Name = "AdminSubscribers"
        Size = New Size(1940, 1580)
        pnlAccDistri.ResumeLayout(False)
        pnlAccDistri.PerformLayout()
        CType(dgvSubsDeets, ComponentModel.ISupportInitialize).EndInit()
        PanelRound1.ResumeLayout(False)
        PanelRound1.PerformLayout()
        CType(deleteAll, ComponentModel.ISupportInitialize).EndInit()
        CType(btnSelectSubscriber, ComponentModel.ISupportInitialize).EndInit()
        pnlSubsPlan.ResumeLayout(False)
        pnlSubsPlan.PerformLayout()
        pnlFilters.ResumeLayout(False)
        pnlFilters.PerformLayout()
        pnlTotalSubs.ResumeLayout(False)
        pnlTotalSubs.PerformLayout()
        CType(picTotalSubs, ComponentModel.ISupportInitialize).EndInit()
        pnlActiveSUBS.ResumeLayout(False)
        pnlActiveSUBS.PerformLayout()
        CType(picActiveSub, ComponentModel.ISupportInitialize).EndInit()
        pnlMonthlyRev.ResumeLayout(False)
        pnlMonthlyRev.PerformLayout()
        CType(picMonthRev, ComponentModel.ISupportInitialize).EndInit()
        pnlAvgSub.ResumeLayout(False)
        pnlAvgSub.PerformLayout()
        CType(picAvgSub, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtSubscriberSearchSA As TextBox
    Friend WithEvents LblSubsByPlan As Label
    Friend WithEvents pnlAccDistri As PanelRound
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LblAccDistri As Label
    Friend WithEvents dgvSubsDeets As DataGridView
    Friend WithEvents colCustomerID As DataGridViewTextBoxColumn
    Friend WithEvents colName As DataGridViewTextBoxColumn
    Friend WithEvents colAddress As DataGridViewTextBoxColumn
    Friend WithEvents colPlanType As DataGridViewTextBoxColumn
    Friend WithEvents colMonthlyRate As DataGridViewTextBoxColumn
    Friend WithEvents colDateInstalled As DataGridViewTextBoxColumn
    Friend WithEvents colStatus As DataGridViewTextBoxColumn
    Friend WithEvents colEditIcon As DataGridViewImageColumn
    Friend WithEvents colDeleteIcon As DataGridViewImageColumn
    Friend WithEvents colSelect As DataGridViewCheckBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PanelRound1 As PanelRound
    Friend WithEvents deleteAll As PictureBox
    Friend WithEvents LblPageInfo As Label
    Friend WithEvents btnSelectSubscriber As PictureBox
    Friend WithEvents btnSubscriberPreviousSA As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnExport As ButtonRounded
    Friend WithEvents pnlSubsPlan As PanelRound
    Friend WithEvents pnlFilters As PanelRound
    Friend WithEvents ComboBoxDate As ComboBox
    Friend WithEvents DateRangeLbl As Label
    Friend WithEvents CBPlanType As ComboBox
    Friend WithEvents CBAccStat As ComboBox
    Friend WithEvents LblPlanType As Label
    Friend WithEvents LblAccStatus As Label
    Friend WithEvents LblFilters As Label
    Friend WithEvents LblSubsReport As Label
    Friend WithEvents pnlTotalSubs As PanelRound
    Friend WithEvents picTotalSubs As PictureBox
    Friend WithEvents totalSub As Label
    Friend WithEvents LblTotalSubs As Label
    Friend WithEvents LblAvgRevPerSub As Label
    Friend WithEvents pnlActiveSUBS As PanelRound
    Friend WithEvents picActiveSub As PictureBox
    Friend WithEvents ActiveSubs As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlMonthlyRev As PanelRound
    Friend WithEvents picMonthRev As PictureBox
    Friend WithEvents monthlyRevenues As Label
    Friend WithEvents LblMonthlyRevs As Label
    Friend WithEvents pnlAvgSub As PanelRound
    Friend WithEvents picAvgSub As PictureBox
    Friend WithEvents AvgRev As Label
    Friend WithEvents Panel4 As Panel

End Class

