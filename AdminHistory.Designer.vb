<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminHistory
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
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdminHistory))
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Amount = New DataGridViewTextBoxColumn()
        Status = New DataGridViewTextBoxColumn()
        Reference = New DataGridViewTextBoxColumn()
        PaymentLbl = New Label()
        TotalPaymentsPanel = New PanelRound()
        BlueDollarIcon = New PictureBox()
        NumPaymentsLbl = New Label()
        TotalPaymentsLbl = New Label()
        NumServicesLbl = New Label()
        ServicesCompletedLbl = New Label()
        PanelRound3 = New PanelRound()
        StatusLbl = New Label()
        PaymentMethod = New DataGridViewTextBoxColumn()
        AccountStatusLbl = New Label()
        AmountPaidLbl = New Label()
        TotalPaidLbl = New Label()
        PanelRound2 = New PanelRound()
        PlanTypeLbl = New Label()
        ServiceRequestsPanel = New PanelRound()
        PictureBox1 = New PictureBox()
        NumRequestServiceLbl = New Label()
        ServiceRequestsLbl = New Label()
        CurrentPlanLbl = New Label()
        EmailAddLbl = New Label()
        EmailLbl = New Label()
        NameCustomerLbl = New Label()
        FullNameLbl = New Label()
        NumberLbl = New Label()
        PhoneLbl = New Label()
        AccountAgePanel = New PanelRound()
        PictureBox2 = New PictureBox()
        AccAgeLbl = New Label()
        AccountAgeLbl = New Label()
        IDLbl = New Label()
        CustomerFilterPanel = New PanelRound()
        txtInstallationSearchSA = New TextBox()
        CustomerLbl = New Label()
        SelectCustomerLbl = New Label()
        IconFilter = New PictureBox()
        HeaderHistoryReport = New Label()
        PanelRound1 = New PanelRound()
        CustomerIDLbl = New Label()
        CustomerInfoLbl = New Label()
        DateColumn = New DataGridViewTextBoxColumn()
        PaymentHistoryPanel = New PanelRound()
        btnHistoryPreviousSA = New Button()
        btnNext = New Button()
        PaymentHistoryDVG = New DataGridView()
        Panel4 = New Panel()
        TotalPaymentsPanel.SuspendLayout()
        CType(BlueDollarIcon, ComponentModel.ISupportInitialize).BeginInit()
        PanelRound3.SuspendLayout()
        PanelRound2.SuspendLayout()
        ServiceRequestsPanel.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        AccountAgePanel.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CustomerFilterPanel.SuspendLayout()
        CType(IconFilter, ComponentModel.ISupportInitialize).BeginInit()
        PanelRound1.SuspendLayout()
        PaymentHistoryPanel.SuspendLayout()
        CType(PaymentHistoryDVG, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Amount
        ' 
        Amount.DataPropertyName = "Amount"
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        Amount.DefaultCellStyle = DataGridViewCellStyle1
        Amount.HeaderText = "Amount"
        Amount.Name = "Amount"
        Amount.ReadOnly = True
        Amount.Width = 300
        ' 
        ' Status
        ' 
        Status.DataPropertyName = "Status"
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle2.ForeColor = Color.DarkGreen
        Status.DefaultCellStyle = DataGridViewCellStyle2
        Status.HeaderText = "Status"
        Status.Name = "Status"
        Status.ReadOnly = True
        Status.Width = 300
        ' 
        ' Reference
        ' 
        Reference.DataPropertyName = "Reference"
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.TopCenter
        Reference.DefaultCellStyle = DataGridViewCellStyle3
        Reference.HeaderText = "Reference"
        Reference.Name = "Reference"
        Reference.ReadOnly = True
        Reference.Width = 300
        ' 
        ' PaymentLbl
        ' 
        PaymentLbl.AutoSize = True
        PaymentLbl.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        PaymentLbl.ForeColor = Color.Black
        PaymentLbl.Location = New Point(22, 23)
        PaymentLbl.Name = "PaymentLbl"
        PaymentLbl.Size = New Size(143, 18)
        PaymentLbl.TabIndex = 9
        PaymentLbl.Text = "Payment History"
        ' 
        ' TotalPaymentsPanel
        ' 
        TotalPaymentsPanel.BackColor = Color.White
        TotalPaymentsPanel.Controls.Add(BlueDollarIcon)
        TotalPaymentsPanel.Controls.Add(NumPaymentsLbl)
        TotalPaymentsPanel.Controls.Add(TotalPaymentsLbl)
        TotalPaymentsPanel.CornerRadius = 12
        TotalPaymentsPanel.Location = New Point(21, 1172)
        TotalPaymentsPanel.Name = "TotalPaymentsPanel"
        TotalPaymentsPanel.Size = New Size(466, 125)
        TotalPaymentsPanel.TabIndex = 32
        ' 
        ' BlueDollarIcon
        ' 
        BlueDollarIcon.Image = CType(resources.GetObject("BlueDollarIcon.Image"), Image)
        BlueDollarIcon.Location = New Point(385, 55)
        BlueDollarIcon.Name = "BlueDollarIcon"
        BlueDollarIcon.Size = New Size(48, 50)
        BlueDollarIcon.SizeMode = PictureBoxSizeMode.Zoom
        BlueDollarIcon.TabIndex = 9
        BlueDollarIcon.TabStop = False
        ' 
        ' NumPaymentsLbl
        ' 
        NumPaymentsLbl.AutoSize = True
        NumPaymentsLbl.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        NumPaymentsLbl.ForeColor = Color.LimeGreen
        NumPaymentsLbl.Location = New Point(24, 55)
        NumPaymentsLbl.Name = "NumPaymentsLbl"
        NumPaymentsLbl.Size = New Size(25, 30)
        NumPaymentsLbl.TabIndex = 8
        NumPaymentsLbl.Text = "0"
        ' 
        ' TotalPaymentsLbl
        ' 
        TotalPaymentsLbl.AutoSize = True
        TotalPaymentsLbl.Font = New Font("Verdana", 12F)
        TotalPaymentsLbl.ForeColor = SystemColors.ControlDarkDark
        TotalPaymentsLbl.Location = New Point(24, 25)
        TotalPaymentsLbl.Name = "TotalPaymentsLbl"
        TotalPaymentsLbl.Size = New Size(134, 18)
        TotalPaymentsLbl.TabIndex = 8
        TotalPaymentsLbl.Text = "Total Payments"
        ' 
        ' NumServicesLbl
        ' 
        NumServicesLbl.AutoSize = True
        NumServicesLbl.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        NumServicesLbl.ForeColor = Color.Blue
        NumServicesLbl.Location = New Point(1223, 194)
        NumServicesLbl.Name = "NumServicesLbl"
        NumServicesLbl.Size = New Size(19, 21)
        NumServicesLbl.TabIndex = 20
        NumServicesLbl.Text = "2"
        ' 
        ' ServicesCompletedLbl
        ' 
        ServicesCompletedLbl.AutoSize = True
        ServicesCompletedLbl.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ServicesCompletedLbl.ForeColor = SystemColors.GrayText
        ServicesCompletedLbl.Location = New Point(1222, 163)
        ServicesCompletedLbl.Name = "ServicesCompletedLbl"
        ServicesCompletedLbl.Size = New Size(147, 21)
        ServicesCompletedLbl.TabIndex = 19
        ServicesCompletedLbl.Text = "Services Completed"
        ' 
        ' PanelRound3
        ' 
        PanelRound3.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        PanelRound3.Controls.Add(StatusLbl)
        PanelRound3.Location = New Point(1222, 98)
        PanelRound3.Name = "PanelRound3"
        PanelRound3.Size = New Size(71, 35)
        PanelRound3.TabIndex = 18
        ' 
        ' StatusLbl
        ' 
        StatusLbl.AutoSize = True
        StatusLbl.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        StatusLbl.ForeColor = Color.Green
        StatusLbl.Location = New Point(8, 7)
        StatusLbl.Name = "StatusLbl"
        StatusLbl.Size = New Size(56, 21)
        StatusLbl.TabIndex = 13
        StatusLbl.Text = "Active"
        ' 
        ' PaymentMethod
        ' 
        PaymentMethod.DataPropertyName = "Service Type"
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter
        PaymentMethod.DefaultCellStyle = DataGridViewCellStyle4
        PaymentMethod.HeaderText = "Service Type"
        PaymentMethod.Name = "PaymentMethod"
        PaymentMethod.ReadOnly = True
        PaymentMethod.Width = 370
        ' 
        ' AccountStatusLbl
        ' 
        AccountStatusLbl.AutoSize = True
        AccountStatusLbl.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        AccountStatusLbl.ForeColor = SystemColors.GrayText
        AccountStatusLbl.Location = New Point(1222, 67)
        AccountStatusLbl.Name = "AccountStatusLbl"
        AccountStatusLbl.Size = New Size(116, 21)
        AccountStatusLbl.TabIndex = 17
        AccountStatusLbl.Text = "Account Status "
        ' 
        ' AmountPaidLbl
        ' 
        AmountPaidLbl.AutoSize = True
        AmountPaidLbl.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        AmountPaidLbl.ForeColor = Color.LimeGreen
        AmountPaidLbl.Location = New Point(836, 194)
        AmountPaidLbl.Name = "AmountPaidLbl"
        AmountPaidLbl.Size = New Size(57, 21)
        AmountPaidLbl.TabIndex = 16
        AmountPaidLbl.Text = "?2,800"
        ' 
        ' TotalPaidLbl
        ' 
        TotalPaidLbl.AutoSize = True
        TotalPaidLbl.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TotalPaidLbl.ForeColor = SystemColors.GrayText
        TotalPaidLbl.Location = New Point(835, 163)
        TotalPaidLbl.Name = "TotalPaidLbl"
        TotalPaidLbl.Size = New Size(75, 21)
        TotalPaidLbl.TabIndex = 15
        TotalPaidLbl.Text = "Total Paid"
        ' 
        ' PanelRound2
        ' 
        PanelRound2.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        PanelRound2.Controls.Add(PlanTypeLbl)
        PanelRound2.Location = New Point(835, 98)
        PanelRound2.Name = "PanelRound2"
        PanelRound2.Size = New Size(121, 35)
        PanelRound2.TabIndex = 14
        ' 
        ' PlanTypeLbl
        ' 
        PlanTypeLbl.AutoSize = True
        PlanTypeLbl.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        PlanTypeLbl.ForeColor = Color.DarkBlue
        PlanTypeLbl.Location = New Point(5, 7)
        PlanTypeLbl.Name = "PlanTypeLbl"
        PlanTypeLbl.Size = New Size(111, 21)
        PlanTypeLbl.TabIndex = 13
        PlanTypeLbl.Text = "Basic 25Mbps"
        ' 
        ' ServiceRequestsPanel
        ' 
        ServiceRequestsPanel.BackColor = Color.White
        ServiceRequestsPanel.Controls.Add(PictureBox1)
        ServiceRequestsPanel.Controls.Add(NumRequestServiceLbl)
        ServiceRequestsPanel.Controls.Add(ServiceRequestsLbl)
        ServiceRequestsPanel.CornerRadius = 12
        ServiceRequestsPanel.Location = New Point(584, 1172)
        ServiceRequestsPanel.Name = "ServiceRequestsPanel"
        ServiceRequestsPanel.Size = New Size(466, 125)
        ServiceRequestsPanel.TabIndex = 33
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(385, 55)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(48, 50)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 9
        PictureBox1.TabStop = False
        ' 
        ' NumRequestServiceLbl
        ' 
        NumRequestServiceLbl.AutoSize = True
        NumRequestServiceLbl.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        NumRequestServiceLbl.ForeColor = Color.Blue
        NumRequestServiceLbl.Location = New Point(24, 55)
        NumRequestServiceLbl.Name = "NumRequestServiceLbl"
        NumRequestServiceLbl.Size = New Size(25, 30)
        NumRequestServiceLbl.TabIndex = 8
        NumRequestServiceLbl.Text = "0"
        ' 
        ' ServiceRequestsLbl
        ' 
        ServiceRequestsLbl.AutoSize = True
        ServiceRequestsLbl.Font = New Font("Verdana", 12F)
        ServiceRequestsLbl.ForeColor = SystemColors.ControlDarkDark
        ServiceRequestsLbl.Location = New Point(24, 25)
        ServiceRequestsLbl.Name = "ServiceRequestsLbl"
        ServiceRequestsLbl.Size = New Size(148, 18)
        ServiceRequestsLbl.TabIndex = 8
        ServiceRequestsLbl.Text = "Service Requests"
        ' 
        ' CurrentPlanLbl
        ' 
        CurrentPlanLbl.AutoSize = True
        CurrentPlanLbl.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CurrentPlanLbl.ForeColor = SystemColors.GrayText
        CurrentPlanLbl.Location = New Point(835, 67)
        CurrentPlanLbl.Name = "CurrentPlanLbl"
        CurrentPlanLbl.Size = New Size(101, 21)
        CurrentPlanLbl.TabIndex = 12
        CurrentPlanLbl.Text = "Current Plan "
        ' 
        ' EmailAddLbl
        ' 
        EmailAddLbl.AutoSize = True
        EmailAddLbl.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        EmailAddLbl.ForeColor = Color.Black
        EmailAddLbl.Location = New Point(412, 194)
        EmailAddLbl.Name = "EmailAddLbl"
        EmailAddLbl.Size = New Size(150, 21)
        EmailAddLbl.TabIndex = 11
        EmailAddLbl.Text = "lyzette@gmail.com"
        ' 
        ' EmailLbl
        ' 
        EmailLbl.AutoSize = True
        EmailLbl.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        EmailLbl.ForeColor = SystemColors.GrayText
        EmailLbl.Location = New Point(411, 163)
        EmailLbl.Name = "EmailLbl"
        EmailLbl.Size = New Size(48, 21)
        EmailLbl.TabIndex = 10
        EmailLbl.Text = "Email"
        ' 
        ' NameCustomerLbl
        ' 
        NameCustomerLbl.AutoSize = True
        NameCustomerLbl.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        NameCustomerLbl.ForeColor = Color.Black
        NameCustomerLbl.Location = New Point(412, 98)
        NameCustomerLbl.Name = "NameCustomerLbl"
        NameCustomerLbl.Size = New Size(119, 21)
        NameCustomerLbl.TabIndex = 9
        NameCustomerLbl.Text = "Lyzette Asutilla"
        ' 
        ' FullNameLbl
        ' 
        FullNameLbl.AutoSize = True
        FullNameLbl.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FullNameLbl.ForeColor = SystemColors.GrayText
        FullNameLbl.Location = New Point(411, 67)
        FullNameLbl.Name = "FullNameLbl"
        FullNameLbl.Size = New Size(81, 21)
        FullNameLbl.TabIndex = 8
        FullNameLbl.Text = "Full Name"
        ' 
        ' NumberLbl
        ' 
        NumberLbl.AutoSize = True
        NumberLbl.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        NumberLbl.ForeColor = Color.Black
        NumberLbl.Location = New Point(23, 194)
        NumberLbl.Name = "NumberLbl"
        NumberLbl.Size = New Size(105, 21)
        NumberLbl.TabIndex = 7
        NumberLbl.Text = "0912 123 1231"
        ' 
        ' PhoneLbl
        ' 
        PhoneLbl.AutoSize = True
        PhoneLbl.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        PhoneLbl.ForeColor = SystemColors.GrayText
        PhoneLbl.Location = New Point(22, 163)
        PhoneLbl.Name = "PhoneLbl"
        PhoneLbl.Size = New Size(54, 21)
        PhoneLbl.TabIndex = 6
        PhoneLbl.Text = "Phone"
        ' 
        ' AccountAgePanel
        ' 
        AccountAgePanel.BackColor = Color.White
        AccountAgePanel.Controls.Add(PictureBox2)
        AccountAgePanel.Controls.Add(AccAgeLbl)
        AccountAgePanel.Controls.Add(AccountAgeLbl)
        AccountAgePanel.CornerRadius = 12
        AccountAgePanel.Location = New Point(1152, 1172)
        AccountAgePanel.Name = "AccountAgePanel"
        AccountAgePanel.Size = New Size(466, 125)
        AccountAgePanel.TabIndex = 34
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(385, 55)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(48, 50)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 9
        PictureBox2.TabStop = False
        ' 
        ' AccAgeLbl
        ' 
        AccAgeLbl.AutoSize = True
        AccAgeLbl.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        AccAgeLbl.ForeColor = Color.OrangeRed
        AccAgeLbl.Location = New Point(24, 55)
        AccAgeLbl.Name = "AccAgeLbl"
        AccAgeLbl.Size = New Size(116, 30)
        AccAgeLbl.TabIndex = 8
        AccAgeLbl.Text = "10 Months"
        ' 
        ' AccountAgeLbl
        ' 
        AccountAgeLbl.AutoSize = True
        AccountAgeLbl.Font = New Font("Verdana", 12F)
        AccountAgeLbl.ForeColor = SystemColors.ControlDarkDark
        AccountAgeLbl.Location = New Point(24, 25)
        AccountAgeLbl.Name = "AccountAgeLbl"
        AccountAgeLbl.Size = New Size(109, 18)
        AccountAgeLbl.TabIndex = 8
        AccountAgeLbl.Text = "Account Age"
        ' 
        ' IDLbl
        ' 
        IDLbl.AutoSize = True
        IDLbl.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        IDLbl.ForeColor = Color.Black
        IDLbl.Location = New Point(23, 98)
        IDLbl.Name = "IDLbl"
        IDLbl.Size = New Size(51, 21)
        IDLbl.TabIndex = 5
        IDLbl.Text = "IN001"
        ' 
        ' CustomerFilterPanel
        ' 
        CustomerFilterPanel.Anchor = AnchorStyles.Top
        CustomerFilterPanel.BackColor = Color.White
        CustomerFilterPanel.Controls.Add(txtInstallationSearchSA)
        CustomerFilterPanel.Controls.Add(CustomerLbl)
        CustomerFilterPanel.Controls.Add(SelectCustomerLbl)
        CustomerFilterPanel.Controls.Add(IconFilter)
        CustomerFilterPanel.CornerRadius = 12
        CustomerFilterPanel.Location = New Point(84, 70)
        CustomerFilterPanel.Name = "CustomerFilterPanel"
        CustomerFilterPanel.Size = New Size(1594, 227)
        CustomerFilterPanel.TabIndex = 29
        ' 
        ' txtInstallationSearchSA
        ' 
        txtInstallationSearchSA.Font = New Font("Segoe UI", 13F)
        txtInstallationSearchSA.Location = New Point(26, 107)
        txtInstallationSearchSA.Name = "txtInstallationSearchSA"
        txtInstallationSearchSA.PlaceholderText = "Search name..."
        txtInstallationSearchSA.Size = New Size(469, 31)
        txtInstallationSearchSA.TabIndex = 26
        ' 
        ' CustomerLbl
        ' 
        CustomerLbl.AutoSize = True
        CustomerLbl.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        CustomerLbl.Location = New Point(23, 80)
        CustomerLbl.Name = "CustomerLbl"
        CustomerLbl.Size = New Size(81, 21)
        CustomerLbl.TabIndex = 4
        CustomerLbl.Text = "Customer"
        CustomerLbl.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' SelectCustomerLbl
        ' 
        SelectCustomerLbl.AutoSize = True
        SelectCustomerLbl.Font = New Font("Verdana", 12F)
        SelectCustomerLbl.Location = New Point(51, 23)
        SelectCustomerLbl.Name = "SelectCustomerLbl"
        SelectCustomerLbl.Size = New Size(142, 18)
        SelectCustomerLbl.TabIndex = 1
        SelectCustomerLbl.Text = "Select Customer"
        ' 
        ' IconFilter
        ' 
        IconFilter.Image = CType(resources.GetObject("IconFilter.Image"), Image)
        IconFilter.Location = New Point(22, 19)
        IconFilter.Name = "IconFilter"
        IconFilter.Size = New Size(24, 24)
        IconFilter.SizeMode = PictureBoxSizeMode.Zoom
        IconFilter.TabIndex = 0
        IconFilter.TabStop = False
        ' 
        ' HeaderHistoryReport
        ' 
        HeaderHistoryReport.AutoSize = True
        HeaderHistoryReport.Font = New Font("Segoe UI Semibold", 15F, FontStyle.Bold)
        HeaderHistoryReport.Location = New Point(21, 30)
        HeaderHistoryReport.Name = "HeaderHistoryReport"
        HeaderHistoryReport.Size = New Size(267, 28)
        HeaderHistoryReport.TabIndex = 28
        HeaderHistoryReport.Text = "Individual Customer History"
        ' 
        ' PanelRound1
        ' 
        PanelRound1.BackColor = Color.White
        PanelRound1.Controls.Add(NumServicesLbl)
        PanelRound1.Controls.Add(ServicesCompletedLbl)
        PanelRound1.Controls.Add(PanelRound3)
        PanelRound1.Controls.Add(AccountStatusLbl)
        PanelRound1.Controls.Add(AmountPaidLbl)
        PanelRound1.Controls.Add(TotalPaidLbl)
        PanelRound1.Controls.Add(PanelRound2)
        PanelRound1.Controls.Add(CurrentPlanLbl)
        PanelRound1.Controls.Add(EmailAddLbl)
        PanelRound1.Controls.Add(EmailLbl)
        PanelRound1.Controls.Add(NameCustomerLbl)
        PanelRound1.Controls.Add(FullNameLbl)
        PanelRound1.Controls.Add(NumberLbl)
        PanelRound1.Controls.Add(PhoneLbl)
        PanelRound1.Controls.Add(IDLbl)
        PanelRound1.Controls.Add(CustomerIDLbl)
        PanelRound1.Controls.Add(CustomerInfoLbl)
        PanelRound1.Location = New Point(29, 329)
        PanelRound1.Name = "PanelRound1"
        PanelRound1.Size = New Size(1597, 264)
        PanelRound1.TabIndex = 30
        ' 
        ' CustomerIDLbl
        ' 
        CustomerIDLbl.AutoSize = True
        CustomerIDLbl.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CustomerIDLbl.ForeColor = SystemColors.GrayText
        CustomerIDLbl.Location = New Point(22, 67)
        CustomerIDLbl.Name = "CustomerIDLbl"
        CustomerIDLbl.Size = New Size(97, 21)
        CustomerIDLbl.TabIndex = 4
        CustomerIDLbl.Text = "Customer ID"
        ' 
        ' CustomerInfoLbl
        ' 
        CustomerInfoLbl.AutoSize = True
        CustomerInfoLbl.Font = New Font("Verdana", 12F)
        CustomerInfoLbl.Location = New Point(22, 20)
        CustomerInfoLbl.Name = "CustomerInfoLbl"
        CustomerInfoLbl.Size = New Size(188, 18)
        CustomerInfoLbl.TabIndex = 2
        CustomerInfoLbl.Text = "Customer Information"
        ' 
        ' DateColumn
        ' 
        DateColumn.DataPropertyName = "Date"
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.True
        DateColumn.DefaultCellStyle = DataGridViewCellStyle5
        DateColumn.Frozen = True
        DateColumn.HeaderText = "Date "
        DateColumn.Name = "DateColumn"
        DateColumn.ReadOnly = True
        DateColumn.Width = 300
        ' 
        ' PaymentHistoryPanel
        ' 
        PaymentHistoryPanel.BackColor = Color.White
        PaymentHistoryPanel.Controls.Add(btnHistoryPreviousSA)
        PaymentHistoryPanel.Controls.Add(btnNext)
        PaymentHistoryPanel.Controls.Add(PaymentHistoryDVG)
        PaymentHistoryPanel.Controls.Add(PaymentLbl)
        PaymentHistoryPanel.Location = New Point(29, 643)
        PaymentHistoryPanel.Name = "PaymentHistoryPanel"
        PaymentHistoryPanel.Size = New Size(1597, 494)
        PaymentHistoryPanel.TabIndex = 31
        ' 
        ' btnHistoryPreviousSA
        ' 
        btnHistoryPreviousSA.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnHistoryPreviousSA.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnHistoryPreviousSA.ForeColor = Color.White
        btnHistoryPreviousSA.Location = New Point(1420, 453)
        btnHistoryPreviousSA.Name = "btnHistoryPreviousSA"
        btnHistoryPreviousSA.Size = New Size(75, 23)
        btnHistoryPreviousSA.TabIndex = 26
        btnHistoryPreviousSA.Text = "Previous"
        btnHistoryPreviousSA.UseVisualStyleBackColor = False
        btnHistoryPreviousSA.Visible = False
        ' 
        ' btnNext
        ' 
        btnNext.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnNext.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnNext.ForeColor = Color.White
        btnNext.Location = New Point(1501, 453)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(75, 23)
        btnNext.TabIndex = 25
        btnNext.Text = "Next"
        btnNext.UseVisualStyleBackColor = False
        ' 
        ' PaymentHistoryDVG
        ' 
        PaymentHistoryDVG.AllowUserToAddRows = False
        PaymentHistoryDVG.AllowUserToDeleteRows = False
        PaymentHistoryDVG.AllowUserToResizeColumns = False
        PaymentHistoryDVG.AllowUserToResizeRows = False
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle6.ForeColor = Color.Black
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.True
        PaymentHistoryDVG.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        PaymentHistoryDVG.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PaymentHistoryDVG.BackgroundColor = Color.White
        PaymentHistoryDVG.BorderStyle = BorderStyle.None
        PaymentHistoryDVG.CellBorderStyle = DataGridViewCellBorderStyle.None
        PaymentHistoryDVG.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = Color.White
        DataGridViewCellStyle7.Font = New Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle7.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = DataGridViewTriState.True
        PaymentHistoryDVG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        PaymentHistoryDVG.ColumnHeadersHeight = 45
        PaymentHistoryDVG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        PaymentHistoryDVG.Columns.AddRange(New DataGridViewColumn() {DateColumn, Amount, PaymentMethod, Status, Reference})
        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = SystemColors.Window
        DataGridViewCellStyle8.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle8.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = DataGridViewTriState.True
        PaymentHistoryDVG.DefaultCellStyle = DataGridViewCellStyle8
        PaymentHistoryDVG.EnableHeadersVisualStyles = False
        PaymentHistoryDVG.GridColor = Color.Silver
        PaymentHistoryDVG.Location = New Point(51, 61)
        PaymentHistoryDVG.Name = "PaymentHistoryDVG"
        PaymentHistoryDVG.ReadOnly = True
        PaymentHistoryDVG.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        PaymentHistoryDVG.RowHeadersVisible = False
        DataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle9.ForeColor = Color.Black
        DataGridViewCellStyle9.WrapMode = DataGridViewTriState.True
        PaymentHistoryDVG.RowsDefaultCellStyle = DataGridViewCellStyle9
        PaymentHistoryDVG.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        PaymentHistoryDVG.RowTemplate.DefaultCellStyle.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        PaymentHistoryDVG.RowTemplate.DefaultCellStyle.ForeColor = Color.Black
        PaymentHistoryDVG.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        PaymentHistoryDVG.RowTemplate.Height = 40
        PaymentHistoryDVG.RowTemplate.ReadOnly = True
        PaymentHistoryDVG.ScrollBars = ScrollBars.Vertical
        PaymentHistoryDVG.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        PaymentHistoryDVG.Size = New Size(2925, 779)
        PaymentHistoryDVG.TabIndex = 24
        ' 
        ' Panel4
        ' 
        Panel4.Location = New Point(21, 1332)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(1598, 49)
        Panel4.TabIndex = 51
        ' 
        ' AdminHistory
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ButtonFace
        Controls.Add(Panel4)
        Controls.Add(TotalPaymentsPanel)
        Controls.Add(ServiceRequestsPanel)
        Controls.Add(AccountAgePanel)
        Controls.Add(CustomerFilterPanel)
        Controls.Add(HeaderHistoryReport)
        Controls.Add(PanelRound1)
        Controls.Add(PaymentHistoryPanel)
        Name = "AdminHistory"
        Size = New Size(1923, 1700)
        TotalPaymentsPanel.ResumeLayout(False)
        TotalPaymentsPanel.PerformLayout()
        CType(BlueDollarIcon, ComponentModel.ISupportInitialize).EndInit()
        PanelRound3.ResumeLayout(False)
        PanelRound3.PerformLayout()
        PanelRound2.ResumeLayout(False)
        PanelRound2.PerformLayout()
        ServiceRequestsPanel.ResumeLayout(False)
        ServiceRequestsPanel.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        AccountAgePanel.ResumeLayout(False)
        AccountAgePanel.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CustomerFilterPanel.ResumeLayout(False)
        CustomerFilterPanel.PerformLayout()
        CType(IconFilter, ComponentModel.ISupportInitialize).EndInit()
        PanelRound1.ResumeLayout(False)
        PanelRound1.PerformLayout()
        PaymentHistoryPanel.ResumeLayout(False)
        PaymentHistoryPanel.PerformLayout()
        CType(PaymentHistoryDVG, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Amount As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents Reference As DataGridViewTextBoxColumn
    Friend WithEvents PaymentLbl As Label
    Friend WithEvents TotalPaymentsPanel As PanelRound
    Friend WithEvents BlueDollarIcon As PictureBox
    Friend WithEvents NumPaymentsLbl As Label
    Friend WithEvents TotalPaymentsLbl As Label
    Friend WithEvents NumServicesLbl As Label
    Friend WithEvents ServicesCompletedLbl As Label
    Friend WithEvents PanelRound3 As PanelRound
    Friend WithEvents StatusLbl As Label
    Friend WithEvents PaymentMethod As DataGridViewTextBoxColumn
    Friend WithEvents AccountStatusLbl As Label
    Friend WithEvents AmountPaidLbl As Label
    Friend WithEvents TotalPaidLbl As Label
    Friend WithEvents PanelRound2 As PanelRound
    Friend WithEvents PlanTypeLbl As Label
    Friend WithEvents ServiceRequestsPanel As PanelRound
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents NumRequestServiceLbl As Label
    Friend WithEvents ServiceRequestsLbl As Label
    Friend WithEvents CurrentPlanLbl As Label
    Friend WithEvents EmailAddLbl As Label
    Friend WithEvents EmailLbl As Label
    Friend WithEvents NameCustomerLbl As Label
    Friend WithEvents FullNameLbl As Label
    Friend WithEvents NumberLbl As Label
    Friend WithEvents PhoneLbl As Label
    Friend WithEvents AccountAgePanel As PanelRound
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents AccAgeLbl As Label
    Friend WithEvents AccountAgeLbl As Label
    Friend WithEvents IDLbl As Label
    Friend WithEvents CustomerFilterPanel As PanelRound
    Friend WithEvents txtInstallationSearchSA As TextBox
    Friend WithEvents CustomerLbl As Label
    Friend WithEvents SelectCustomerLbl As Label
    Friend WithEvents IconFilter As PictureBox
    Friend WithEvents HeaderHistoryReport As Label
    Friend WithEvents PanelRound1 As PanelRound
    Friend WithEvents CustomerIDLbl As Label
    Friend WithEvents CustomerInfoLbl As Label
    Friend WithEvents DateColumn As DataGridViewTextBoxColumn
    Friend WithEvents PaymentHistoryPanel As PanelRound
    Friend WithEvents btnHistoryPreviousSA As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents PaymentHistoryDVG As DataGridView
    Friend WithEvents Panel4 As Panel

End Class

