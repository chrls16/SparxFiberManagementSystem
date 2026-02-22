<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminBilling
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdminBilling))
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        PictureBox4 = New PictureBox()
        DefaultRatePanel = New PanelRound()
        DefaultRateLbl = New Label()
        DefaultPercentLbl = New Label()
        CollectionRatePanel = New PanelRound()
        CollectionRateLbl = New Label()
        CollectionPercentLbl = New Label()
        PaymentSummaryLbl = New Label()
        BillingDetailsPanel = New PanelRound()
        LblPageInfo = New Label()
        btnAddBilling = New PictureBox()
        txtBillingSearchSA = New TextBox()
        btnBillingPreviousSA = New Button()
        btnNext = New Button()
        BillingDetailsDGV = New DataGridView()
        PaymentID = New DataGridViewTextBoxColumn()
        CustomerName = New DataGridViewTextBoxColumn()
        colBillingType = New DataGridViewTextBoxColumn()
        PlanType = New DataGridViewTextBoxColumn()
        MonthlyRate = New DataGridViewTextBoxColumn()
        colBillingStart = New DataGridViewTextBoxColumn()
        colBillingEnd = New DataGridViewTextBoxColumn()
        colServiceType = New DataGridViewTextBoxColumn()
        AmountPaid = New DataGridViewTextBoxColumn()
        PaymentDate = New DataGridViewTextBoxColumn()
        Status = New DataGridViewTextBoxColumn()
        ModeOfPayment = New DataGridViewTextBoxColumn()
        paidBtn = New DataGridViewButtonColumn()
        BillingDetailsLbl = New Label()
        PaymentsummaryPanel = New PanelRound()
        NumUnpaidLbl = New Label()
        InventoryFilterPanel = New PanelRound()
        LblBillingType = New Label()
        CBBillingType = New ComboBox()
        btnExport = New ButtonRounded()
        ComboBoxDate = New ComboBox()
        ComboBoxStat = New ComboBox()
        DateRangeLbl = New Label()
        PaymentStatusLbl = New Label()
        LabelFilters = New Label()
        IconFilter = New PictureBox()
        HeaderBillingReport = New Label()
        TotalExpectedPanel = New PanelRound()
        BlueDollarIcon = New PictureBox()
        AmountExpectedLbl = New Label()
        TotalExpectedLbl = New Label()
        TotalReceivedPanel = New PanelRound()
        PictureBox1 = New PictureBox()
        AmoundReceivedLbl = New Label()
        TotalReceivedLbl = New Label()
        OutstandingPanel = New PanelRound()
        PictureBox2 = New PictureBox()
        AmountOutstandingLbl = New Label()
        OutsandingLbl = New Label()
        PaidBillsPanel = New PanelRound()
        PictureBox3 = New PictureBox()
        NumPaidLbl = New Label()
        PaidBillsLbl = New Label()
        UnpaidBillsPanel = New PanelRound()
        UnpaidBillsLbl = New Label()
        Panel4 = New Panel()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        DefaultRatePanel.SuspendLayout()
        CollectionRatePanel.SuspendLayout()
        BillingDetailsPanel.SuspendLayout()
        CType(btnAddBilling, ComponentModel.ISupportInitialize).BeginInit()
        CType(BillingDetailsDGV, ComponentModel.ISupportInitialize).BeginInit()
        PaymentsummaryPanel.SuspendLayout()
        InventoryFilterPanel.SuspendLayout()
        CType(IconFilter, ComponentModel.ISupportInitialize).BeginInit()
        TotalExpectedPanel.SuspendLayout()
        CType(BlueDollarIcon, ComponentModel.ISupportInitialize).BeginInit()
        TotalReceivedPanel.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        OutstandingPanel.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        PaidBillsPanel.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        UnpaidBillsPanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), Image)
        PictureBox4.Location = New Point(243, 35)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(48, 50)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 9
        PictureBox4.TabStop = False
        ' 
        ' DefaultRatePanel
        ' 
        DefaultRatePanel.BackColor = Color.FromArgb(CByte(255), CByte(216), CByte(216))
        DefaultRatePanel.Controls.Add(DefaultRateLbl)
        DefaultRatePanel.Controls.Add(DefaultPercentLbl)
        DefaultRatePanel.ImeMode = ImeMode.NoControl
        DefaultRatePanel.Location = New Point(840, 59)
        DefaultRatePanel.Name = "DefaultRatePanel"
        DefaultRatePanel.Size = New Size(521, 145)
        DefaultRatePanel.TabIndex = 12
        ' 
        ' DefaultRateLbl
        ' 
        DefaultRateLbl.AutoSize = True
        DefaultRateLbl.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DefaultRateLbl.ForeColor = Color.Red
        DefaultRateLbl.Location = New Point(219, 36)
        DefaultRateLbl.Name = "DefaultRateLbl"
        DefaultRateLbl.Size = New Size(95, 21)
        DefaultRateLbl.TabIndex = 12
        DefaultRateLbl.Text = "Default Rate"
        ' 
        ' DefaultPercentLbl
        ' 
        DefaultPercentLbl.AutoSize = True
        DefaultPercentLbl.Font = New Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DefaultPercentLbl.ForeColor = Color.Red
        DefaultPercentLbl.Location = New Point(224, 63)
        DefaultPercentLbl.Name = "DefaultPercentLbl"
        DefaultPercentLbl.Size = New Size(93, 45)
        DefaultPercentLbl.TabIndex = 11
        DefaultPercentLbl.Text = "0.0%"
        ' 
        ' CollectionRatePanel
        ' 
        CollectionRatePanel.BackColor = Color.Ivory
        CollectionRatePanel.Controls.Add(CollectionRateLbl)
        CollectionRatePanel.Controls.Add(CollectionPercentLbl)
        CollectionRatePanel.ImeMode = ImeMode.NoControl
        CollectionRatePanel.Location = New Point(249, 59)
        CollectionRatePanel.Name = "CollectionRatePanel"
        CollectionRatePanel.Size = New Size(521, 145)
        CollectionRatePanel.TabIndex = 11
        ' 
        ' CollectionRateLbl
        ' 
        CollectionRateLbl.AutoSize = True
        CollectionRateLbl.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CollectionRateLbl.ForeColor = Color.Green
        CollectionRateLbl.Location = New Point(196, 36)
        CollectionRateLbl.Name = "CollectionRateLbl"
        CollectionRateLbl.Size = New Size(114, 21)
        CollectionRateLbl.TabIndex = 10
        CollectionRateLbl.Text = "Collection Rate"
        ' 
        ' CollectionPercentLbl
        ' 
        CollectionPercentLbl.AutoSize = True
        CollectionPercentLbl.Font = New Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        CollectionPercentLbl.ForeColor = Color.Green
        CollectionPercentLbl.Location = New Point(210, 63)
        CollectionPercentLbl.Name = "CollectionPercentLbl"
        CollectionPercentLbl.Size = New Size(93, 45)
        CollectionPercentLbl.TabIndex = 9
        CollectionPercentLbl.Text = "0.0%"
        ' 
        ' PaymentSummaryLbl
        ' 
        PaymentSummaryLbl.AutoSize = True
        PaymentSummaryLbl.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        PaymentSummaryLbl.ForeColor = Color.Black
        PaymentSummaryLbl.Location = New Point(22, 15)
        PaymentSummaryLbl.Name = "PaymentSummaryLbl"
        PaymentSummaryLbl.Size = New Size(247, 18)
        PaymentSummaryLbl.TabIndex = 10
        PaymentSummaryLbl.Text = "Payment Collection Summary"
        ' 
        ' BillingDetailsPanel
        ' 
        BillingDetailsPanel.BackColor = Color.White
        BillingDetailsPanel.Controls.Add(LblPageInfo)
        BillingDetailsPanel.Controls.Add(btnAddBilling)
        BillingDetailsPanel.Controls.Add(txtBillingSearchSA)
        BillingDetailsPanel.Controls.Add(btnBillingPreviousSA)
        BillingDetailsPanel.Controls.Add(btnNext)
        BillingDetailsPanel.Controls.Add(BillingDetailsDGV)
        BillingDetailsPanel.Controls.Add(BillingDetailsLbl)
        BillingDetailsPanel.Location = New Point(25, 689)
        BillingDetailsPanel.Name = "BillingDetailsPanel"
        BillingDetailsPanel.Size = New Size(1597, 568)
        BillingDetailsPanel.TabIndex = 31
        ' 
        ' LblPageInfo
        ' 
        LblPageInfo.AutoSize = True
        LblPageInfo.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblPageInfo.ImageAlign = ContentAlignment.MiddleLeft
        LblPageInfo.Location = New Point(24, 525)
        LblPageInfo.Name = "LblPageInfo"
        LblPageInfo.Size = New Size(18, 18)
        LblPageInfo.TabIndex = 38
        LblPageInfo.Text = "0"
        ' 
        ' btnAddBilling
        ' 
        btnAddBilling.Image = My.Resources.Resources.Add
        btnAddBilling.Location = New Point(1508, 23)
        btnAddBilling.Name = "btnAddBilling"
        btnAddBilling.Size = New Size(19, 19)
        btnAddBilling.SizeMode = PictureBoxSizeMode.AutoSize
        btnAddBilling.TabIndex = 30
        btnAddBilling.TabStop = False
        ' 
        ' txtBillingSearchSA
        ' 
        txtBillingSearchSA.Font = New Font("Segoe UI", 12F)
        txtBillingSearchSA.Location = New Point(1242, 16)
        txtBillingSearchSA.Name = "txtBillingSearchSA"
        txtBillingSearchSA.PlaceholderText = "Search..."
        txtBillingSearchSA.Size = New Size(259, 29)
        txtBillingSearchSA.TabIndex = 27
        ' 
        ' btnBillingPreviousSA
        ' 
        btnBillingPreviousSA.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnBillingPreviousSA.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnBillingPreviousSA.ForeColor = Color.White
        btnBillingPreviousSA.Location = New Point(1427, 520)
        btnBillingPreviousSA.Name = "btnBillingPreviousSA"
        btnBillingPreviousSA.Size = New Size(75, 23)
        btnBillingPreviousSA.TabIndex = 26
        btnBillingPreviousSA.Text = "Previous"
        btnBillingPreviousSA.UseVisualStyleBackColor = False
        btnBillingPreviousSA.Visible = False
        ' 
        ' btnNext
        ' 
        btnNext.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnNext.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnNext.ForeColor = Color.White
        btnNext.Location = New Point(1508, 520)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(75, 23)
        btnNext.TabIndex = 25
        btnNext.Text = "Next"
        btnNext.UseVisualStyleBackColor = False
        ' 
        ' BillingDetailsDGV
        ' 
        BillingDetailsDGV.AllowUserToAddRows = False
        BillingDetailsDGV.AllowUserToDeleteRows = False
        BillingDetailsDGV.AllowUserToResizeColumns = False
        BillingDetailsDGV.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        BillingDetailsDGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        BillingDetailsDGV.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        BillingDetailsDGV.BackgroundColor = Color.White
        BillingDetailsDGV.BorderStyle = BorderStyle.None
        BillingDetailsDGV.CellBorderStyle = DataGridViewCellBorderStyle.None
        BillingDetailsDGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Verdana", 10F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        BillingDetailsDGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        BillingDetailsDGV.ColumnHeadersHeight = 45
        BillingDetailsDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        BillingDetailsDGV.Columns.AddRange(New DataGridViewColumn() {PaymentID, CustomerName, colBillingType, PlanType, MonthlyRate, colBillingStart, colBillingEnd, colServiceType, AmountPaid, PaymentDate, Status, ModeOfPayment, paidBtn})
        DataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = SystemColors.Window
        DataGridViewCellStyle10.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle10.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = DataGridViewTriState.True
        BillingDetailsDGV.DefaultCellStyle = DataGridViewCellStyle10
        BillingDetailsDGV.EnableHeadersVisualStyles = False
        BillingDetailsDGV.GridColor = Color.Silver
        BillingDetailsDGV.Location = New Point(13, 74)
        BillingDetailsDGV.Margin = New Padding(3, 2, 3, 2)
        BillingDetailsDGV.Name = "BillingDetailsDGV"
        BillingDetailsDGV.ReadOnly = True
        BillingDetailsDGV.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        BillingDetailsDGV.RowHeadersVisible = False
        DataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle11.WrapMode = DataGridViewTriState.True
        BillingDetailsDGV.RowsDefaultCellStyle = DataGridViewCellStyle11
        BillingDetailsDGV.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        BillingDetailsDGV.RowTemplate.DefaultCellStyle.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BillingDetailsDGV.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        BillingDetailsDGV.RowTemplate.Height = 40
        BillingDetailsDGV.RowTemplate.ReadOnly = True
        BillingDetailsDGV.ScrollBars = ScrollBars.Vertical
        BillingDetailsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        BillingDetailsDGV.Size = New Size(1570, 433)
        BillingDetailsDGV.TabIndex = 24
        ' 
        ' PaymentID
        ' 
        PaymentID.Frozen = True
        PaymentID.HeaderText = "Payment ID "
        PaymentID.Name = "PaymentID"
        PaymentID.ReadOnly = True
        ' 
        ' CustomerName
        ' 
        CustomerName.HeaderText = "Customer Name"
        CustomerName.Name = "CustomerName"
        CustomerName.ReadOnly = True
        CustomerName.Width = 155
        ' 
        ' colBillingType
        ' 
        colBillingType.HeaderText = "Billing Type"
        colBillingType.Name = "colBillingType"
        colBillingType.ReadOnly = True
        colBillingType.Width = 110
        ' 
        ' PlanType
        ' 
        PlanType.HeaderText = "Plan Type"
        PlanType.Name = "PlanType"
        PlanType.ReadOnly = True
        ' 
        ' MonthlyRate
        ' 
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        MonthlyRate.DefaultCellStyle = DataGridViewCellStyle3
        MonthlyRate.HeaderText = "Monthly Rate"
        MonthlyRate.Name = "MonthlyRate"
        MonthlyRate.ReadOnly = True
        MonthlyRate.Width = 110
        ' 
        ' colBillingStart
        ' 
        DataGridViewCellStyle4.Format = "d"
        DataGridViewCellStyle4.NullValue = Nothing
        colBillingStart.DefaultCellStyle = DataGridViewCellStyle4
        colBillingStart.HeaderText = "Billing Start Date"
        colBillingStart.Name = "colBillingStart"
        colBillingStart.ReadOnly = True
        colBillingStart.Width = 150
        ' 
        ' colBillingEnd
        ' 
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        colBillingEnd.DefaultCellStyle = DataGridViewCellStyle5
        colBillingEnd.HeaderText = "Billing End Date"
        colBillingEnd.Name = "colBillingEnd"
        colBillingEnd.ReadOnly = True
        colBillingEnd.Width = 150
        ' 
        ' colServiceType
        ' 
        colServiceType.HeaderText = "Service Type"
        colServiceType.Name = "colServiceType"
        colServiceType.ReadOnly = True
        colServiceType.Width = 120
        ' 
        ' AmountPaid
        ' 
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = Color.White
        DataGridViewCellStyle6.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle6.ForeColor = Color.Black
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.True
        AmountPaid.DefaultCellStyle = DataGridViewCellStyle6
        AmountPaid.HeaderText = "Amount Paid"
        AmountPaid.Name = "AmountPaid"
        AmountPaid.ReadOnly = True
        AmountPaid.Width = 120
        ' 
        ' PaymentDate
        ' 
        DataGridViewCellStyle7.Format = "d"
        DataGridViewCellStyle7.NullValue = Nothing
        PaymentDate.DefaultCellStyle = DataGridViewCellStyle7
        PaymentDate.HeaderText = "Payment Date"
        PaymentDate.Name = "PaymentDate"
        PaymentDate.ReadOnly = True
        ' 
        ' Status
        ' 
        DataGridViewCellStyle8.BackColor = Color.White
        DataGridViewCellStyle8.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle8.ForeColor = Color.DarkGreen
        Status.DefaultCellStyle = DataGridViewCellStyle8
        Status.HeaderText = "Status"
        Status.Name = "Status"
        Status.ReadOnly = True
        Status.Width = 95
        ' 
        ' ModeOfPayment
        ' 
        ModeOfPayment.HeaderText = "Mode of Payment"
        ModeOfPayment.Name = "ModeOfPayment"
        ModeOfPayment.ReadOnly = True
        ' 
        ' paidBtn
        ' 
        DataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = Color.Lime
        DataGridViewCellStyle9.Font = New Font("Segoe UI", 11F)
        DataGridViewCellStyle9.ForeColor = Color.Green
        DataGridViewCellStyle9.WrapMode = DataGridViewTriState.True
        paidBtn.DefaultCellStyle = DataGridViewCellStyle9
        paidBtn.HeaderText = ""
        paidBtn.Name = "paidBtn"
        paidBtn.ReadOnly = True
        paidBtn.Text = "Paid"
        paidBtn.UseColumnTextForButtonValue = True
        paidBtn.Width = 70
        ' 
        ' BillingDetailsLbl
        ' 
        BillingDetailsLbl.AutoSize = True
        BillingDetailsLbl.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BillingDetailsLbl.ForeColor = Color.Black
        BillingDetailsLbl.Location = New Point(22, 23)
        BillingDetailsLbl.Name = "BillingDetailsLbl"
        BillingDetailsLbl.Size = New Size(123, 18)
        BillingDetailsLbl.TabIndex = 9
        BillingDetailsLbl.Text = "Billing Details"
        ' 
        ' PaymentsummaryPanel
        ' 
        PaymentsummaryPanel.BackColor = Color.White
        PaymentsummaryPanel.Controls.Add(DefaultRatePanel)
        PaymentsummaryPanel.Controls.Add(CollectionRatePanel)
        PaymentsummaryPanel.Controls.Add(PaymentSummaryLbl)
        PaymentsummaryPanel.Location = New Point(25, 425)
        PaymentsummaryPanel.Name = "PaymentsummaryPanel"
        PaymentsummaryPanel.Size = New Size(1595, 219)
        PaymentsummaryPanel.TabIndex = 30
        ' 
        ' NumUnpaidLbl
        ' 
        NumUnpaidLbl.AutoSize = True
        NumUnpaidLbl.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        NumUnpaidLbl.ForeColor = Color.Red
        NumUnpaidLbl.Location = New Point(24, 55)
        NumUnpaidLbl.Name = "NumUnpaidLbl"
        NumUnpaidLbl.Size = New Size(25, 30)
        NumUnpaidLbl.TabIndex = 8
        NumUnpaidLbl.Text = "0"
        ' 
        ' InventoryFilterPanel
        ' 
        InventoryFilterPanel.Anchor = AnchorStyles.Top
        InventoryFilterPanel.BackColor = Color.White
        InventoryFilterPanel.Controls.Add(LblBillingType)
        InventoryFilterPanel.Controls.Add(CBBillingType)
        InventoryFilterPanel.Controls.Add(btnExport)
        InventoryFilterPanel.Controls.Add(ComboBoxDate)
        InventoryFilterPanel.Controls.Add(ComboBoxStat)
        InventoryFilterPanel.Controls.Add(DateRangeLbl)
        InventoryFilterPanel.Controls.Add(PaymentStatusLbl)
        InventoryFilterPanel.Controls.Add(LabelFilters)
        InventoryFilterPanel.Controls.Add(IconFilter)
        InventoryFilterPanel.CornerRadius = 12
        InventoryFilterPanel.Location = New Point(113, 64)
        InventoryFilterPanel.Name = "InventoryFilterPanel"
        InventoryFilterPanel.Size = New Size(1597, 165)
        InventoryFilterPanel.TabIndex = 24
        ' 
        ' LblBillingType
        ' 
        LblBillingType.AutoSize = True
        LblBillingType.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblBillingType.Location = New Point(698, 80)
        LblBillingType.Name = "LblBillingType"
        LblBillingType.Size = New Size(94, 21)
        LblBillingType.TabIndex = 26
        LblBillingType.Text = "Billing Type"
        ' 
        ' CBBillingType
        ' 
        CBBillingType.DropDownStyle = ComboBoxStyle.DropDownList
        CBBillingType.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CBBillingType.FormattingEnabled = True
        CBBillingType.Items.AddRange(New Object() {"All Type", "Plan Type", "Service Type"})
        CBBillingType.Location = New Point(698, 105)
        CBBillingType.Margin = New Padding(3, 2, 3, 2)
        CBBillingType.Name = "CBBillingType"
        CBBillingType.Size = New Size(180, 33)
        CBBillingType.TabIndex = 25
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
        btnExport.Location = New Point(1335, 9)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(250, 34)
        btnExport.TabIndex = 24
        btnExport.Text = "Export Report"
        btnExport.UseVisualStyleBackColor = False
        ' 
        ' ComboBoxDate
        ' 
        ComboBoxDate.BackColor = SystemColors.ButtonFace
        ComboBoxDate.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxDate.Font = New Font("Segoe UI", 14F)
        ComboBoxDate.ForeColor = SystemColors.WindowText
        ComboBoxDate.FormattingEnabled = True
        ComboBoxDate.Items.AddRange(New Object() {"All Times", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        ComboBoxDate.Location = New Point(23, 104)
        ComboBoxDate.MinimumSize = New Size(193, 0)
        ComboBoxDate.Name = "ComboBoxDate"
        ComboBoxDate.Size = New Size(265, 33)
        ComboBoxDate.TabIndex = 6
        ' 
        ' ComboBoxStat
        ' 
        ComboBoxStat.BackColor = SystemColors.ButtonFace
        ComboBoxStat.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxStat.Font = New Font("Segoe UI", 14F)
        ComboBoxStat.ForeColor = SystemColors.WindowText
        ComboBoxStat.FormattingEnabled = True
        ComboBoxStat.Items.AddRange(New Object() {"All Status", "Paid", "Unpaid"})
        ComboBoxStat.Location = New Point(364, 104)
        ComboBoxStat.MinimumSize = New Size(193, 0)
        ComboBoxStat.Name = "ComboBoxStat"
        ComboBoxStat.Size = New Size(265, 33)
        ComboBoxStat.TabIndex = 5
        ' 
        ' DateRangeLbl
        ' 
        DateRangeLbl.AutoSize = True
        DateRangeLbl.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        DateRangeLbl.Location = New Point(23, 80)
        DateRangeLbl.Name = "DateRangeLbl"
        DateRangeLbl.Size = New Size(94, 21)
        DateRangeLbl.TabIndex = 4
        DateRangeLbl.Text = "Date Range"
        ' 
        ' PaymentStatusLbl
        ' 
        PaymentStatusLbl.AutoSize = True
        PaymentStatusLbl.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        PaymentStatusLbl.Location = New Point(364, 80)
        PaymentStatusLbl.Name = "PaymentStatusLbl"
        PaymentStatusLbl.Size = New Size(122, 21)
        PaymentStatusLbl.TabIndex = 3
        PaymentStatusLbl.Text = "Payment Status"
        ' 
        ' LabelFilters
        ' 
        LabelFilters.AutoSize = True
        LabelFilters.Font = New Font("Verdana", 12F)
        LabelFilters.Location = New Point(51, 23)
        LabelFilters.Name = "LabelFilters"
        LabelFilters.Size = New Size(59, 18)
        LabelFilters.TabIndex = 1
        LabelFilters.Text = "Filters"
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
        ' HeaderBillingReport
        ' 
        HeaderBillingReport.AutoSize = True
        HeaderBillingReport.Font = New Font("Segoe UI Semibold", 15F, FontStyle.Bold)
        HeaderBillingReport.Location = New Point(21, 22)
        HeaderBillingReport.Name = "HeaderBillingReport"
        HeaderBillingReport.Size = New Size(135, 28)
        HeaderBillingReport.TabIndex = 23
        HeaderBillingReport.Text = "Billing Report"
        ' 
        ' TotalExpectedPanel
        ' 
        TotalExpectedPanel.BackColor = Color.White
        TotalExpectedPanel.Controls.Add(BlueDollarIcon)
        TotalExpectedPanel.Controls.Add(AmountExpectedLbl)
        TotalExpectedPanel.Controls.Add(TotalExpectedLbl)
        TotalExpectedPanel.CornerRadius = 12
        TotalExpectedPanel.Location = New Point(25, 260)
        TotalExpectedPanel.Name = "TotalExpectedPanel"
        TotalExpectedPanel.Size = New Size(303, 115)
        TotalExpectedPanel.TabIndex = 25
        ' 
        ' BlueDollarIcon
        ' 
        BlueDollarIcon.Image = CType(resources.GetObject("BlueDollarIcon.Image"), Image)
        BlueDollarIcon.Location = New Point(232, 35)
        BlueDollarIcon.Name = "BlueDollarIcon"
        BlueDollarIcon.Size = New Size(48, 50)
        BlueDollarIcon.SizeMode = PictureBoxSizeMode.Zoom
        BlueDollarIcon.TabIndex = 9
        BlueDollarIcon.TabStop = False
        ' 
        ' AmountExpectedLbl
        ' 
        AmountExpectedLbl.AutoSize = True
        AmountExpectedLbl.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        AmountExpectedLbl.ForeColor = Color.Blue
        AmountExpectedLbl.Location = New Point(24, 55)
        AmountExpectedLbl.Name = "AmountExpectedLbl"
        AmountExpectedLbl.Size = New Size(49, 30)
        AmountExpectedLbl.TabIndex = 8
        AmountExpectedLbl.Text = "000"
        ' 
        ' TotalExpectedLbl
        ' 
        TotalExpectedLbl.AutoSize = True
        TotalExpectedLbl.Font = New Font("Verdana", 12F)
        TotalExpectedLbl.ForeColor = SystemColors.ControlDarkDark
        TotalExpectedLbl.Location = New Point(24, 25)
        TotalExpectedLbl.Name = "TotalExpectedLbl"
        TotalExpectedLbl.Size = New Size(128, 18)
        TotalExpectedLbl.TabIndex = 8
        TotalExpectedLbl.Text = "Total Expected"
        ' 
        ' TotalReceivedPanel
        ' 
        TotalReceivedPanel.BackColor = Color.White
        TotalReceivedPanel.Controls.Add(PictureBox1)
        TotalReceivedPanel.Controls.Add(AmoundReceivedLbl)
        TotalReceivedPanel.Controls.Add(TotalReceivedLbl)
        TotalReceivedPanel.CornerRadius = 12
        TotalReceivedPanel.Location = New Point(347, 260)
        TotalReceivedPanel.Name = "TotalReceivedPanel"
        TotalReceivedPanel.Size = New Size(303, 115)
        TotalReceivedPanel.TabIndex = 26
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(239, 35)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(48, 50)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 9
        PictureBox1.TabStop = False
        ' 
        ' AmoundReceivedLbl
        ' 
        AmoundReceivedLbl.AutoSize = True
        AmoundReceivedLbl.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        AmoundReceivedLbl.ForeColor = Color.LimeGreen
        AmoundReceivedLbl.Location = New Point(24, 55)
        AmoundReceivedLbl.Name = "AmoundReceivedLbl"
        AmoundReceivedLbl.Size = New Size(49, 30)
        AmoundReceivedLbl.TabIndex = 8
        AmoundReceivedLbl.Text = "000"
        ' 
        ' TotalReceivedLbl
        ' 
        TotalReceivedLbl.AutoSize = True
        TotalReceivedLbl.Font = New Font("Verdana", 12F)
        TotalReceivedLbl.ForeColor = SystemColors.ControlDarkDark
        TotalReceivedLbl.Location = New Point(24, 25)
        TotalReceivedLbl.Name = "TotalReceivedLbl"
        TotalReceivedLbl.Size = New Size(127, 18)
        TotalReceivedLbl.TabIndex = 8
        TotalReceivedLbl.Text = "Total Received"
        ' 
        ' OutstandingPanel
        ' 
        OutstandingPanel.BackColor = Color.White
        OutstandingPanel.Controls.Add(PictureBox2)
        OutstandingPanel.Controls.Add(AmountOutstandingLbl)
        OutstandingPanel.Controls.Add(OutsandingLbl)
        OutstandingPanel.CornerRadius = 12
        OutstandingPanel.Location = New Point(671, 260)
        OutstandingPanel.Name = "OutstandingPanel"
        OutstandingPanel.Size = New Size(303, 115)
        OutstandingPanel.TabIndex = 27
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(240, 35)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(48, 50)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 9
        PictureBox2.TabStop = False
        ' 
        ' AmountOutstandingLbl
        ' 
        AmountOutstandingLbl.AutoSize = True
        AmountOutstandingLbl.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        AmountOutstandingLbl.ForeColor = Color.Red
        AmountOutstandingLbl.Location = New Point(24, 55)
        AmountOutstandingLbl.Name = "AmountOutstandingLbl"
        AmountOutstandingLbl.Size = New Size(49, 30)
        AmountOutstandingLbl.TabIndex = 8
        AmountOutstandingLbl.Text = "000"
        ' 
        ' OutsandingLbl
        ' 
        OutsandingLbl.AutoSize = True
        OutsandingLbl.Font = New Font("Verdana", 12F)
        OutsandingLbl.ForeColor = SystemColors.ControlDarkDark
        OutsandingLbl.Location = New Point(24, 25)
        OutsandingLbl.Name = "OutsandingLbl"
        OutsandingLbl.Size = New Size(115, 18)
        OutsandingLbl.TabIndex = 8
        OutsandingLbl.Text = "Outstanding "
        ' 
        ' PaidBillsPanel
        ' 
        PaidBillsPanel.BackColor = Color.White
        PaidBillsPanel.Controls.Add(PictureBox3)
        PaidBillsPanel.Controls.Add(NumPaidLbl)
        PaidBillsPanel.Controls.Add(PaidBillsLbl)
        PaidBillsPanel.CornerRadius = 12
        PaidBillsPanel.Location = New Point(996, 260)
        PaidBillsPanel.Name = "PaidBillsPanel"
        PaidBillsPanel.RightToLeft = RightToLeft.No
        PaidBillsPanel.Size = New Size(303, 115)
        PaidBillsPanel.TabIndex = 28
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(237, 35)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(48, 50)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 9
        PictureBox3.TabStop = False
        ' 
        ' NumPaidLbl
        ' 
        NumPaidLbl.AutoSize = True
        NumPaidLbl.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        NumPaidLbl.ForeColor = Color.LimeGreen
        NumPaidLbl.Location = New Point(24, 55)
        NumPaidLbl.Name = "NumPaidLbl"
        NumPaidLbl.Size = New Size(25, 30)
        NumPaidLbl.TabIndex = 8
        NumPaidLbl.Text = "0"
        ' 
        ' PaidBillsLbl
        ' 
        PaidBillsLbl.AutoSize = True
        PaidBillsLbl.Font = New Font("Verdana", 12F)
        PaidBillsLbl.ForeColor = SystemColors.ControlDarkDark
        PaidBillsLbl.Location = New Point(24, 25)
        PaidBillsLbl.Name = "PaidBillsLbl"
        PaidBillsLbl.Size = New Size(84, 18)
        PaidBillsLbl.TabIndex = 8
        PaidBillsLbl.Text = "Paid Bills"
        ' 
        ' UnpaidBillsPanel
        ' 
        UnpaidBillsPanel.BackColor = Color.White
        UnpaidBillsPanel.Controls.Add(PictureBox4)
        UnpaidBillsPanel.Controls.Add(NumUnpaidLbl)
        UnpaidBillsPanel.Controls.Add(UnpaidBillsLbl)
        UnpaidBillsPanel.CornerRadius = 12
        UnpaidBillsPanel.Location = New Point(1317, 260)
        UnpaidBillsPanel.Name = "UnpaidBillsPanel"
        UnpaidBillsPanel.Size = New Size(303, 115)
        UnpaidBillsPanel.TabIndex = 29
        ' 
        ' UnpaidBillsLbl
        ' 
        UnpaidBillsLbl.AutoSize = True
        UnpaidBillsLbl.Font = New Font("Verdana", 12F)
        UnpaidBillsLbl.ForeColor = SystemColors.ControlDarkDark
        UnpaidBillsLbl.Location = New Point(24, 25)
        UnpaidBillsLbl.Name = "UnpaidBillsLbl"
        UnpaidBillsLbl.Size = New Size(106, 18)
        UnpaidBillsLbl.TabIndex = 8
        UnpaidBillsLbl.Text = "Unpaid Bills"
        ' 
        ' Panel4
        ' 
        Panel4.Location = New Point(25, 1289)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(1598, 49)
        Panel4.TabIndex = 51
        ' 
        ' AdminBilling
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ButtonFace
        Controls.Add(Panel4)
        Controls.Add(BillingDetailsPanel)
        Controls.Add(PaymentsummaryPanel)
        Controls.Add(InventoryFilterPanel)
        Controls.Add(HeaderBillingReport)
        Controls.Add(TotalExpectedPanel)
        Controls.Add(TotalReceivedPanel)
        Controls.Add(OutstandingPanel)
        Controls.Add(PaidBillsPanel)
        Controls.Add(UnpaidBillsPanel)
        Name = "AdminBilling"
        Size = New Size(1980, 1712)
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        DefaultRatePanel.ResumeLayout(False)
        DefaultRatePanel.PerformLayout()
        CollectionRatePanel.ResumeLayout(False)
        CollectionRatePanel.PerformLayout()
        BillingDetailsPanel.ResumeLayout(False)
        BillingDetailsPanel.PerformLayout()
        CType(btnAddBilling, ComponentModel.ISupportInitialize).EndInit()
        CType(BillingDetailsDGV, ComponentModel.ISupportInitialize).EndInit()
        PaymentsummaryPanel.ResumeLayout(False)
        PaymentsummaryPanel.PerformLayout()
        InventoryFilterPanel.ResumeLayout(False)
        InventoryFilterPanel.PerformLayout()
        CType(IconFilter, ComponentModel.ISupportInitialize).EndInit()
        TotalExpectedPanel.ResumeLayout(False)
        TotalExpectedPanel.PerformLayout()
        CType(BlueDollarIcon, ComponentModel.ISupportInitialize).EndInit()
        TotalReceivedPanel.ResumeLayout(False)
        TotalReceivedPanel.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        OutstandingPanel.ResumeLayout(False)
        OutstandingPanel.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        PaidBillsPanel.ResumeLayout(False)
        PaidBillsPanel.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        UnpaidBillsPanel.ResumeLayout(False)
        UnpaidBillsPanel.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents DefaultRatePanel As PanelRound
    Friend WithEvents DefaultRateLbl As Label
    Friend WithEvents DefaultPercentLbl As Label
    Friend WithEvents CollectionRatePanel As PanelRound
    Friend WithEvents CollectionRateLbl As Label
    Friend WithEvents CollectionPercentLbl As Label
    Friend WithEvents PaymentSummaryLbl As Label
    Friend WithEvents BillingDetailsPanel As PanelRound
    Friend WithEvents LblPageInfo As Label
    Friend WithEvents btnAddBilling As PictureBox
    Friend WithEvents txtBillingSearchSA As TextBox
    Friend WithEvents btnBillingPreviousSA As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents BillingDetailsDGV As DataGridView
    Friend WithEvents PaymentID As DataGridViewTextBoxColumn
    Friend WithEvents CustomerName As DataGridViewTextBoxColumn
    Friend WithEvents colBillingType As DataGridViewTextBoxColumn
    Friend WithEvents PlanType As DataGridViewTextBoxColumn
    Friend WithEvents MonthlyRate As DataGridViewTextBoxColumn
    Friend WithEvents colBillingStart As DataGridViewTextBoxColumn
    Friend WithEvents colBillingEnd As DataGridViewTextBoxColumn
    Friend WithEvents colServiceType As DataGridViewTextBoxColumn
    Friend WithEvents AmountPaid As DataGridViewTextBoxColumn
    Friend WithEvents PaymentDate As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents ModeOfPayment As DataGridViewTextBoxColumn
    Friend WithEvents paidBtn As DataGridViewButtonColumn
    Friend WithEvents BillingDetailsLbl As Label
    Friend WithEvents PaymentsummaryPanel As PanelRound
    Friend WithEvents NumUnpaidLbl As Label
    Friend WithEvents InventoryFilterPanel As PanelRound
    Friend WithEvents LblBillingType As Label
    Friend WithEvents CBBillingType As ComboBox
    Friend WithEvents btnExport As ButtonRounded
    Friend WithEvents ComboBoxDate As ComboBox
    Friend WithEvents ComboBoxStat As ComboBox
    Friend WithEvents DateRangeLbl As Label
    Friend WithEvents PaymentStatusLbl As Label
    Friend WithEvents LabelFilters As Label
    Friend WithEvents IconFilter As PictureBox
    Friend WithEvents HeaderBillingReport As Label
    Friend WithEvents TotalExpectedPanel As PanelRound
    Friend WithEvents BlueDollarIcon As PictureBox
    Friend WithEvents AmountExpectedLbl As Label
    Friend WithEvents TotalExpectedLbl As Label
    Friend WithEvents TotalReceivedPanel As PanelRound
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents AmoundReceivedLbl As Label
    Friend WithEvents TotalReceivedLbl As Label
    Friend WithEvents OutstandingPanel As PanelRound
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents AmountOutstandingLbl As Label
    Friend WithEvents OutsandingLbl As Label
    Friend WithEvents PaidBillsPanel As PanelRound
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents NumPaidLbl As Label
    Friend WithEvents PaidBillsLbl As Label
    Friend WithEvents UnpaidBillsPanel As PanelRound
    Friend WithEvents UnpaidBillsLbl As Label
    Friend WithEvents Panel4 As Panel

End Class
