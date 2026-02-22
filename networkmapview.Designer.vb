<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class networkmapview
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
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        PanelFilters = New PanelRound()
        ComboBox3 = New ComboBox()
        cbDateRange = New ComboBox()
        LCP1 = New Label()
        cbPosition = New ComboBox()
        Nap1 = New Label()
        Loc1 = New Label()
        Filters = New Label()
        PictureBox1 = New PictureBox()
        HeaderPayrollReport = New Label()
        pnlAvgRev = New PanelRound()
        PictureBox4 = New PictureBox()
        AvgRev = New Label()
        LblAvgRev = New Label()
        pnlTotalNewSales = New PanelRound()
        PictureBox2 = New PictureBox()
        TotalSales = New Label()
        LblTotalNewSales = New Label()
        pnlTotalMonthlyRev = New PanelRound()
        PictureBox3 = New PictureBox()
        MonthlyRev = New Label()
        LblTotalMonthlyRev = New Label()
        PanelMonthlyPayrollTrend = New PanelRound()
        PanelRound1 = New PanelRound()
        ComboBox4 = New ComboBox()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        Label12 = New Label()
        lblMonthlyPayrollTrend = New Label()
        BillingDetailsPanel = New PanelRound()
        TableLayoutPanel1 = New TableLayoutPanel()
        BillingDetailsDGV = New DataGridView()
        PaymentID = New DataGridViewTextBoxColumn()
        CustomerName = New DataGridViewTextBoxColumn()
        PlanType = New DataGridViewTextBoxColumn()
        MonthlyRate = New DataGridViewTextBoxColumn()
        AmountPaid = New DataGridViewTextBoxColumn()
        PaymentDate = New DataGridViewTextBoxColumn()
        BillingDetailsLbl = New Label()
        OustandingPanel = New PanelRound()
        PanelRound4 = New PanelRound()
        PanelRound5 = New PanelRound()
        Label11 = New Label()
        Label8 = New Label()
        Label3 = New Label()
        Label5 = New Label()
        PanelRound2 = New PanelRound()
        Label7 = New Label()
        Label1 = New Label()
        Label2 = New Label()
        PanelRound3 = New PanelRound()
        Label10 = New Label()
        Label4 = New Label()
        OverduePanel = New PanelRound()
        PanelRound6 = New PanelRound()
        Label9 = New Label()
        Label6 = New Label()
        PlanAmountLbl = New Label()
        NameOfCustomerLbl = New Label()
        PaymentAlertsLbl = New Label()
        btnExport = New ButtonRounded()
        PanelFilters.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        pnlAvgRev.SuspendLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        pnlTotalNewSales.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        pnlTotalMonthlyRev.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        PanelMonthlyPayrollTrend.SuspendLayout()
        BillingDetailsPanel.SuspendLayout()
        CType(BillingDetailsDGV, ComponentModel.ISupportInitialize).BeginInit()
        OustandingPanel.SuspendLayout()
        PanelRound4.SuspendLayout()
        PanelRound5.SuspendLayout()
        PanelRound2.SuspendLayout()
        PanelRound3.SuspendLayout()
        OverduePanel.SuspendLayout()
        PanelRound6.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelFilters
        ' 
        PanelFilters.BackColor = Color.White
        PanelFilters.Controls.Add(ComboBox3)
        PanelFilters.Controls.Add(cbDateRange)
        PanelFilters.Controls.Add(LCP1)
        PanelFilters.Controls.Add(cbPosition)
        PanelFilters.Controls.Add(Nap1)
        PanelFilters.Controls.Add(Loc1)
        PanelFilters.Controls.Add(Filters)
        PanelFilters.Controls.Add(PictureBox1)
        PanelFilters.CornerRadius = 12
        PanelFilters.Location = New Point(28, 75)
        PanelFilters.Name = "PanelFilters"
        PanelFilters.Size = New Size(1615, 175)
        PanelFilters.TabIndex = 50
        ' 
        ' ComboBox3
        ' 
        ComboBox3.BackColor = Color.WhiteSmoke
        ComboBox3.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox3.Font = New Font("Segoe UI", 14F)
        ComboBox3.ForeColor = SystemColors.WindowText
        ComboBox3.FormattingEnabled = True
        ComboBox3.Location = New Point(714, 93)
        ComboBox3.MinimumSize = New Size(193, 0)
        ComboBox3.Name = "ComboBox3"
        ComboBox3.Size = New Size(308, 33)
        ComboBox3.TabIndex = 16
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
        ' LCP1
        ' 
        LCP1.AutoSize = True
        LCP1.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        LCP1.Location = New Point(714, 69)
        LCP1.Name = "LCP1"
        LCP1.Size = New Size(37, 21)
        LCP1.TabIndex = 13
        LCP1.Text = "LCP"
        ' 
        ' cbPosition
        ' 
        cbPosition.BackColor = Color.WhiteSmoke
        cbPosition.DropDownStyle = ComboBoxStyle.DropDownList
        cbPosition.Font = New Font("Segoe UI", 14F)
        cbPosition.ForeColor = SystemColors.WindowText
        cbPosition.FormattingEnabled = True
        cbPosition.Location = New Point(366, 93)
        cbPosition.MinimumSize = New Size(193, 0)
        cbPosition.Name = "cbPosition"
        cbPosition.Size = New Size(308, 33)
        cbPosition.TabIndex = 10
        ' 
        ' Nap1
        ' 
        Nap1.AutoSize = True
        Nap1.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Nap1.Location = New Point(366, 69)
        Nap1.Name = "Nap1"
        Nap1.Size = New Size(42, 21)
        Nap1.TabIndex = 8
        Nap1.Text = "NAP"
        ' 
        ' Loc1
        ' 
        Loc1.AutoSize = True
        Loc1.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Loc1.Location = New Point(22, 69)
        Loc1.Name = "Loc1"
        Loc1.Size = New Size(73, 21)
        Loc1.TabIndex = 7
        Loc1.Text = "Location"
        ' 
        ' Filters
        ' 
        Filters.AutoSize = True
        Filters.Font = New Font("Verdana", 12F)
        Filters.Location = New Point(51, 14)
        Filters.Name = "Filters"
        Filters.Size = New Size(59, 18)
        Filters.TabIndex = 3
        Filters.Text = "Filters"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Location = New Point(22, 10)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(24, 24)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' HeaderPayrollReport
        ' 
        HeaderPayrollReport.AutoSize = True
        HeaderPayrollReport.Font = New Font("Segoe UI Semibold", 15F, FontStyle.Bold)
        HeaderPayrollReport.Location = New Point(28, 22)
        HeaderPayrollReport.Name = "HeaderPayrollReport"
        HeaderPayrollReport.Size = New Size(136, 28)
        HeaderPayrollReport.TabIndex = 63
        HeaderPayrollReport.Text = "Netwrok Map"
        ' 
        ' pnlAvgRev
        ' 
        pnlAvgRev.BackColor = Color.White
        pnlAvgRev.Controls.Add(PictureBox4)
        pnlAvgRev.Controls.Add(AvgRev)
        pnlAvgRev.Controls.Add(LblAvgRev)
        pnlAvgRev.Location = New Point(1091, 300)
        pnlAvgRev.Margin = New Padding(3, 2, 3, 2)
        pnlAvgRev.Name = "pnlAvgRev"
        pnlAvgRev.Size = New Size(288, 112)
        pnlAvgRev.TabIndex = 66
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Location = New Point(143, 42)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(100, 50)
        PictureBox4.TabIndex = 70
        PictureBox4.TabStop = False
        ' 
        ' AvgRev
        ' 
        AvgRev.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        AvgRev.AutoSize = True
        AvgRev.Font = New Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        AvgRev.ForeColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        AvgRev.Location = New Point(44, 52)
        AvgRev.Name = "AvgRev"
        AvgRev.Size = New Size(17, 20)
        AvgRev.TabIndex = 8
        AvgRev.Text = "1"
        AvgRev.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblAvgRev
        ' 
        LblAvgRev.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LblAvgRev.AutoSize = True
        LblAvgRev.Location = New Point(44, 12)
        LblAvgRev.Name = "LblAvgRev"
        LblAvgRev.Size = New Size(126, 15)
        LblAvgRev.TabIndex = 8
        LblAvgRev.Text = "Maintenance Required"
        LblAvgRev.TextAlign = ContentAlignment.TopCenter
        ' 
        ' pnlTotalNewSales
        ' 
        pnlTotalNewSales.BackColor = Color.White
        pnlTotalNewSales.Controls.Add(PictureBox2)
        pnlTotalNewSales.Controls.Add(TotalSales)
        pnlTotalNewSales.Controls.Add(LblTotalNewSales)
        pnlTotalNewSales.Location = New Point(227, 300)
        pnlTotalNewSales.Margin = New Padding(3, 2, 3, 2)
        pnlTotalNewSales.Name = "pnlTotalNewSales"
        pnlTotalNewSales.Size = New Size(288, 112)
        pnlTotalNewSales.TabIndex = 65
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Location = New Point(157, 42)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(100, 50)
        PictureBox2.TabIndex = 68
        PictureBox2.TabStop = False
        ' 
        ' TotalSales
        ' 
        TotalSales.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TotalSales.AutoSize = True
        TotalSales.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TotalSales.ForeColor = Color.Blue
        TotalSales.Location = New Point(22, 52)
        TotalSales.Name = "TotalSales"
        TotalSales.Size = New Size(28, 21)
        TotalSales.TabIndex = 6
        TotalSales.Text = "10"
        TotalSales.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblTotalNewSales
        ' 
        LblTotalNewSales.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LblTotalNewSales.AutoSize = True
        LblTotalNewSales.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblTotalNewSales.Location = New Point(22, 12)
        LblTotalNewSales.Name = "LblTotalNewSales"
        LblTotalNewSales.Size = New Size(121, 21)
        LblTotalNewSales.TabIndex = 5
        LblTotalNewSales.Text = "Total Customers"
        LblTotalNewSales.TextAlign = ContentAlignment.TopCenter
        ' 
        ' pnlTotalMonthlyRev
        ' 
        pnlTotalMonthlyRev.BackColor = Color.White
        pnlTotalMonthlyRev.Controls.Add(PictureBox3)
        pnlTotalMonthlyRev.Controls.Add(MonthlyRev)
        pnlTotalMonthlyRev.Controls.Add(LblTotalMonthlyRev)
        pnlTotalMonthlyRev.Location = New Point(648, 300)
        pnlTotalMonthlyRev.Margin = New Padding(3, 2, 3, 2)
        pnlTotalMonthlyRev.Name = "pnlTotalMonthlyRev"
        pnlTotalMonthlyRev.Size = New Size(288, 112)
        pnlTotalMonthlyRev.TabIndex = 67
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Location = New Point(120, 42)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(100, 50)
        PictureBox3.TabIndex = 69
        PictureBox3.TabStop = False
        ' 
        ' MonthlyRev
        ' 
        MonthlyRev.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        MonthlyRev.AutoSize = True
        MonthlyRev.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MonthlyRev.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        MonthlyRev.Location = New Point(29, 52)
        MonthlyRev.Name = "MonthlyRev"
        MonthlyRev.Size = New Size(19, 21)
        MonthlyRev.TabIndex = 7
        MonthlyRev.Text = "4"
        MonthlyRev.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblTotalMonthlyRev
        ' 
        LblTotalMonthlyRev.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LblTotalMonthlyRev.AutoSize = True
        LblTotalMonthlyRev.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblTotalMonthlyRev.Location = New Point(29, 12)
        LblTotalMonthlyRev.Name = "LblTotalMonthlyRev"
        LblTotalMonthlyRev.Size = New Size(94, 21)
        LblTotalMonthlyRev.TabIndex = 7
        LblTotalMonthlyRev.Text = "Active NAPs"
        LblTotalMonthlyRev.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PanelMonthlyPayrollTrend
        ' 
        PanelMonthlyPayrollTrend.BackColor = Color.White
        PanelMonthlyPayrollTrend.Controls.Add(PanelRound1)
        PanelMonthlyPayrollTrend.Controls.Add(ComboBox4)
        PanelMonthlyPayrollTrend.Controls.Add(Button3)
        PanelMonthlyPayrollTrend.Controls.Add(Button2)
        PanelMonthlyPayrollTrend.Controls.Add(Button1)
        PanelMonthlyPayrollTrend.Controls.Add(Label12)
        PanelMonthlyPayrollTrend.Controls.Add(lblMonthlyPayrollTrend)
        PanelMonthlyPayrollTrend.CornerRadius = 12
        PanelMonthlyPayrollTrend.Location = New Point(28, 458)
        PanelMonthlyPayrollTrend.Name = "PanelMonthlyPayrollTrend"
        PanelMonthlyPayrollTrend.Size = New Size(1615, 603)
        PanelMonthlyPayrollTrend.TabIndex = 68
        ' 
        ' PanelRound1
        ' 
        PanelRound1.Location = New Point(27, 74)
        PanelRound1.Name = "PanelRound1"
        PanelRound1.Size = New Size(1551, 498)
        PanelRound1.TabIndex = 36
        ' 
        ' ComboBox4
        ' 
        ComboBox4.BackColor = Color.WhiteSmoke
        ComboBox4.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox4.Font = New Font("Segoe UI", 14F)
        ComboBox4.ForeColor = SystemColors.WindowText
        ComboBox4.FormattingEnabled = True
        ComboBox4.Location = New Point(782, 15)
        ComboBox4.MinimumSize = New Size(193, 0)
        ComboBox4.Name = "ComboBox4"
        ComboBox4.Size = New Size(308, 33)
        ComboBox4.TabIndex = 17
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button3.ForeColor = Color.OrangeRed
        Button3.Image = My.Resources.Resources.RedDanger
        Button3.ImageAlign = ContentAlignment.BottomLeft
        Button3.Location = New Point(1416, 10)
        Button3.Name = "Button3"
        Button3.Size = New Size(156, 42)
        Button3.TabIndex = 40
        Button3.Text = "      Delete  NAP"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = Color.Blue
        Button2.Image = My.Resources.Resources.BLueWrench
        Button2.ImageAlign = ContentAlignment.TopLeft
        Button2.Location = New Point(1258, 10)
        Button2.Name = "Button2"
        Button2.Size = New Size(127, 42)
        Button2.TabIndex = 39
        Button2.Text = "      Edit  NAP"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.Green
        Button1.ImageAlign = ContentAlignment.BottomLeft
        Button1.Location = New Point(1096, 10)
        Button1.Name = "Button1"
        Button1.Size = New Size(127, 42)
        Button1.TabIndex = 1
        Button1.Text = "      Add NAP"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label12
        ' 
        Label12.Anchor = AnchorStyles.Top
        Label12.AutoSize = True
        Label12.Font = New Font("Verdana", 12F)
        Label12.ForeColor = Color.Black
        Label12.Location = New Point(331, 23)
        Label12.Name = "Label12"
        Label12.Size = New Size(335, 18)
        Label12.TabIndex = 37
        Label12.Text = "Sparx Location : Daet, Camarines Norte"
        ' 
        ' lblMonthlyPayrollTrend
        ' 
        lblMonthlyPayrollTrend.Anchor = AnchorStyles.Top
        lblMonthlyPayrollTrend.AutoSize = True
        lblMonthlyPayrollTrend.Font = New Font("Verdana", 12F)
        lblMonthlyPayrollTrend.ForeColor = Color.Black
        lblMonthlyPayrollTrend.Location = New Point(22, 23)
        lblMonthlyPayrollTrend.Name = "lblMonthlyPayrollTrend"
        lblMonthlyPayrollTrend.Size = New Size(196, 18)
        lblMonthlyPayrollTrend.TabIndex = 35
        lblMonthlyPayrollTrend.Text = "Network Coverage Map"
        ' 
        ' BillingDetailsPanel
        ' 
        BillingDetailsPanel.BackColor = Color.White
        BillingDetailsPanel.Controls.Add(TableLayoutPanel1)
        BillingDetailsPanel.Controls.Add(BillingDetailsDGV)
        BillingDetailsPanel.Controls.Add(BillingDetailsLbl)
        BillingDetailsPanel.Location = New Point(28, 1801)
        BillingDetailsPanel.Name = "BillingDetailsPanel"
        BillingDetailsPanel.Size = New Size(1615, 494)
        BillingDetailsPanel.TabIndex = 69
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 6
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 47.2027969F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 52.7972031F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 160F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 200F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 200F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 632F))
        TableLayoutPanel1.Location = New Point(27, 136)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(1479, 316)
        TableLayoutPanel1.TabIndex = 25
        ' 
        ' BillingDetailsDGV
        ' 
        BillingDetailsDGV.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BillingDetailsDGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        BillingDetailsDGV.BackgroundColor = Color.White
        BillingDetailsDGV.BorderStyle = BorderStyle.None
        BillingDetailsDGV.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal
        BillingDetailsDGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Verdana", 10F)
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        BillingDetailsDGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        BillingDetailsDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        BillingDetailsDGV.Columns.AddRange(New DataGridViewColumn() {PaymentID, CustomerName, PlanType, MonthlyRate, AmountPaid, PaymentDate})
        BillingDetailsDGV.GridColor = Color.Silver
        BillingDetailsDGV.Location = New Point(21, 74)
        BillingDetailsDGV.Name = "BillingDetailsDGV"
        BillingDetailsDGV.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        BillingDetailsDGV.RowHeadersVisible = False
        BillingDetailsDGV.RowTemplate.Height = 40
        BillingDetailsDGV.ScrollBars = ScrollBars.Vertical
        BillingDetailsDGV.Size = New Size(1734, 393)
        BillingDetailsDGV.TabIndex = 24
        ' 
        ' PaymentID
        ' 
        PaymentID.Frozen = True
        PaymentID.HeaderText = "Customer"
        PaymentID.Name = "PaymentID"
        PaymentID.ReadOnly = True
        PaymentID.Width = 150
        ' 
        ' CustomerName
        ' 
        CustomerName.HeaderText = "Address"
        CustomerName.Name = "CustomerName"
        CustomerName.ReadOnly = True
        CustomerName.Width = 150
        ' 
        ' PlanType
        ' 
        PlanType.HeaderText = "LCP Address"
        PlanType.Name = "PlanType"
        PlanType.ReadOnly = True
        PlanType.Width = 150
        ' 
        ' MonthlyRate
        ' 
        MonthlyRate.HeaderText = "NAP ID"
        MonthlyRate.Name = "MonthlyRate"
        MonthlyRate.ReadOnly = True
        MonthlyRate.Width = 200
        ' 
        ' AmountPaid
        ' 
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = Color.DarkGreen
        AmountPaid.DefaultCellStyle = DataGridViewCellStyle3
        AmountPaid.HeaderText = "Occupied"
        AmountPaid.Name = "AmountPaid"
        AmountPaid.ReadOnly = True
        AmountPaid.Width = 200
        ' 
        ' PaymentDate
        ' 
        PaymentDate.HeaderText = "Available"
        PaymentDate.Name = "PaymentDate"
        PaymentDate.ReadOnly = True
        PaymentDate.Width = 350
        ' 
        ' BillingDetailsLbl
        ' 
        BillingDetailsLbl.AutoSize = True
        BillingDetailsLbl.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BillingDetailsLbl.ForeColor = Color.Black
        BillingDetailsLbl.Location = New Point(22, 23)
        BillingDetailsLbl.Name = "BillingDetailsLbl"
        BillingDetailsLbl.Size = New Size(233, 18)
        BillingDetailsLbl.TabIndex = 9
        BillingDetailsLbl.Text = "Customer Network Mapping"
        ' 
        ' OustandingPanel
        ' 
        OustandingPanel.BackColor = Color.White
        OustandingPanel.Controls.Add(PanelRound4)
        OustandingPanel.Controls.Add(PanelRound2)
        OustandingPanel.Controls.Add(Label4)
        OustandingPanel.Controls.Add(OverduePanel)
        OustandingPanel.Controls.Add(PaymentAlertsLbl)
        OustandingPanel.Location = New Point(28, 1099)
        OustandingPanel.Name = "OustandingPanel"
        OustandingPanel.Size = New Size(1615, 642)
        OustandingPanel.TabIndex = 70
        ' 
        ' PanelRound4
        ' 
        PanelRound4.BackColor = Color.Gainsboro
        PanelRound4.Controls.Add(PanelRound5)
        PanelRound4.Controls.Add(Label8)
        PanelRound4.Controls.Add(Label3)
        PanelRound4.Controls.Add(Label5)
        PanelRound4.Location = New Point(22, 400)
        PanelRound4.Name = "PanelRound4"
        PanelRound4.Size = New Size(1515, 106)
        PanelRound4.TabIndex = 16
        ' 
        ' PanelRound5
        ' 
        PanelRound5.AutoSizeMode = AutoSizeMode.GrowAndShrink
        PanelRound5.BackColor = Color.LightGreen
        PanelRound5.Controls.Add(Label11)
        PanelRound5.CornerRadius = 50
        PanelRound5.Location = New Point(1394, 27)
        PanelRound5.Name = "PanelRound5"
        PanelRound5.Size = New Size(102, 35)
        PanelRound5.TabIndex = 15
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Label11.Location = New Point(30, 10)
        Label11.Name = "Label11"
        Label11.Size = New Size(43, 15)
        Label11.TabIndex = 17
        Label11.Text = "Active"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Label8.Location = New Point(15, 73)
        Label8.Name = "Label8"
        Label8.Size = New Size(73, 15)
        Label8.TabIndex = 18
        Label8.Text = "3 Customers"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.Black
        Label3.Location = New Point(12, 47)
        Label3.Name = "Label3"
        Label3.Size = New Size(145, 15)
        Label3.TabIndex = 17
        Label3.Text = "Purok 9, Barangay IV, Daet"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.Black
        Label5.Location = New Point(12, 17)
        Label5.Name = "Label5"
        Label5.Size = New Size(79, 21)
        Label5.TabIndex = 16
        Label5.Text = "NAP -003"
        ' 
        ' PanelRound2
        ' 
        PanelRound2.BackColor = Color.Gainsboro
        PanelRound2.Controls.Add(Label7)
        PanelRound2.Controls.Add(Label1)
        PanelRound2.Controls.Add(Label2)
        PanelRound2.Controls.Add(PanelRound3)
        PanelRound2.Location = New Point(22, 257)
        PanelRound2.Name = "PanelRound2"
        PanelRound2.Size = New Size(1515, 106)
        PanelRound2.TabIndex = 15
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Label7.Location = New Point(12, 72)
        Label7.Name = "Label7"
        Label7.Size = New Size(73, 15)
        Label7.TabIndex = 17
        Label7.Text = "3 Customers"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(12, 47)
        Label1.Name = "Label1"
        Label1.Size = New Size(145, 15)
        Label1.TabIndex = 16
        Label1.Text = "Purok 9, Barangay IV, Daet"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(12, 17)
        Label2.Name = "Label2"
        Label2.Size = New Size(79, 21)
        Label2.TabIndex = 15
        Label2.Text = "NAP -002"
        ' 
        ' PanelRound3
        ' 
        PanelRound3.AutoSizeMode = AutoSizeMode.GrowAndShrink
        PanelRound3.BackColor = Color.LightGreen
        PanelRound3.Controls.Add(Label10)
        PanelRound3.CornerRadius = 50
        PanelRound3.Location = New Point(1394, 36)
        PanelRound3.Name = "PanelRound3"
        PanelRound3.Size = New Size(102, 35)
        PanelRound3.TabIndex = 14
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Label10.Location = New Point(30, 10)
        Label10.Name = "Label10"
        Label10.Size = New Size(43, 15)
        Label10.TabIndex = 17
        Label10.Text = "Active"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = SystemColors.Window
        Label4.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.Black
        Label4.Location = New Point(72, 62)
        Label4.Name = "Label4"
        Label4.Size = New Size(241, 21)
        Label4.TabIndex = 14
        Label4.Text = "Network Access Points (NAPS)"
        ' 
        ' OverduePanel
        ' 
        OverduePanel.BackColor = Color.Gainsboro
        OverduePanel.Controls.Add(PanelRound6)
        OverduePanel.Controls.Add(Label6)
        OverduePanel.Controls.Add(PlanAmountLbl)
        OverduePanel.Controls.Add(NameOfCustomerLbl)
        OverduePanel.Location = New Point(22, 115)
        OverduePanel.Name = "OverduePanel"
        OverduePanel.Size = New Size(1515, 106)
        OverduePanel.TabIndex = 12
        ' 
        ' PanelRound6
        ' 
        PanelRound6.AutoSizeMode = AutoSizeMode.GrowAndShrink
        PanelRound6.BackColor = Color.LightGreen
        PanelRound6.Controls.Add(Label9)
        PanelRound6.CornerRadius = 50
        PanelRound6.Location = New Point(1394, 27)
        PanelRound6.Name = "PanelRound6"
        PanelRound6.Size = New Size(102, 35)
        PanelRound6.TabIndex = 16
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Label9.Location = New Point(29, 11)
        Label9.Name = "Label9"
        Label9.Size = New Size(43, 15)
        Label9.TabIndex = 16
        Label9.Text = "Active"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Label6.Location = New Point(12, 64)
        Label6.Name = "Label6"
        Label6.Size = New Size(73, 15)
        Label6.TabIndex = 15
        Label6.Text = "3 Customers"
        ' 
        ' PlanAmountLbl
        ' 
        PlanAmountLbl.AutoSize = True
        PlanAmountLbl.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        PlanAmountLbl.ForeColor = Color.Black
        PlanAmountLbl.Location = New Point(12, 38)
        PlanAmountLbl.Name = "PlanAmountLbl"
        PlanAmountLbl.Size = New Size(145, 15)
        PlanAmountLbl.TabIndex = 13
        PlanAmountLbl.Text = "Purok 9, Barangay IV, Daet"
        ' 
        ' NameOfCustomerLbl
        ' 
        NameOfCustomerLbl.AutoSize = True
        NameOfCustomerLbl.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        NameOfCustomerLbl.ForeColor = Color.Black
        NameOfCustomerLbl.Location = New Point(12, 13)
        NameOfCustomerLbl.Name = "NameOfCustomerLbl"
        NameOfCustomerLbl.Size = New Size(76, 21)
        NameOfCustomerLbl.TabIndex = 12
        NameOfCustomerLbl.Text = "NAP -001"
        ' 
        ' PaymentAlertsLbl
        ' 
        PaymentAlertsLbl.AutoSize = True
        PaymentAlertsLbl.BackColor = SystemColors.Window
        PaymentAlertsLbl.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        PaymentAlertsLbl.ForeColor = Color.Black
        PaymentAlertsLbl.Location = New Point(27, 18)
        PaymentAlertsLbl.Name = "PaymentAlertsLbl"
        PaymentAlertsLbl.Size = New Size(185, 18)
        PaymentAlertsLbl.TabIndex = 11
        PaymentAlertsLbl.Text = "Infrastructure  Status"
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
        btnExport.Location = New Point(1428, 43)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(215, 26)
        btnExport.TabIndex = 71
        btnExport.Text = "Export Report"
        btnExport.UseVisualStyleBackColor = False
        ' 
        ' networkmapview
        ' 
        AutoScroll = True
        BackColor = SystemColors.Control
        Controls.Add(btnExport)
        Controls.Add(OustandingPanel)
        Controls.Add(BillingDetailsPanel)
        Controls.Add(PanelMonthlyPayrollTrend)
        Controls.Add(pnlAvgRev)
        Controls.Add(pnlTotalNewSales)
        Controls.Add(pnlTotalMonthlyRev)
        Controls.Add(HeaderPayrollReport)
        Controls.Add(PanelFilters)
        Name = "networkmapview"
        Size = New Size(1684, 2355)
        PanelFilters.ResumeLayout(False)
        PanelFilters.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        pnlAvgRev.ResumeLayout(False)
        pnlAvgRev.PerformLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        pnlTotalNewSales.ResumeLayout(False)
        pnlTotalNewSales.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        pnlTotalMonthlyRev.ResumeLayout(False)
        pnlTotalMonthlyRev.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        PanelMonthlyPayrollTrend.ResumeLayout(False)
        PanelMonthlyPayrollTrend.PerformLayout()
        BillingDetailsPanel.ResumeLayout(False)
        BillingDetailsPanel.PerformLayout()
        CType(BillingDetailsDGV, ComponentModel.ISupportInitialize).EndInit()
        OustandingPanel.ResumeLayout(False)
        OustandingPanel.PerformLayout()
        PanelRound4.ResumeLayout(False)
        PanelRound4.PerformLayout()
        PanelRound5.ResumeLayout(False)
        PanelRound5.PerformLayout()
        PanelRound2.ResumeLayout(False)
        PanelRound2.PerformLayout()
        PanelRound3.ResumeLayout(False)
        PanelRound3.PerformLayout()
        OverduePanel.ResumeLayout(False)
        OverduePanel.PerformLayout()
        PanelRound6.ResumeLayout(False)
        PanelRound6.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Friend WithEvents InventoryFilterPanel As PanelRound
    Friend WithEvents ItemSearchTxtBox As TextBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ReorderLbl As Label
    Friend WithEvents StatusLbl As Label
    Friend WithEvents LocationLbl As Label
    Friend WithEvents LabelFilters As Label
    Friend WithEvents IconFilter As PictureBox
    Friend WithEvents btnExport As ButtonRounded
    Friend WithEvents LblSalesReport As Label
    Friend WithEvents PanelFilters As PanelRound
    Friend WithEvents cbDateRange As ComboBox
    Friend WithEvents LCP1 As Label
    Friend WithEvents Nap1 As Label
    Friend WithEvents Loc1 As Label
    Friend WithEvents Filters As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents HeaderPayrollReport As Label
    Friend WithEvents pnlAvgRev As PanelRound
    Friend WithEvents AvgRev As Label
    Friend WithEvents LblAvgRev As Label
    Friend WithEvents pnlTotalNewSales As PanelRound
    Friend WithEvents TotalSales As Label
    Friend WithEvents LblTotalNewSales As Label
    Friend WithEvents pnlTotalMonthlyRev As PanelRound
    Friend WithEvents MonthlyRev As Label
    Friend WithEvents LblTotalMonthlyRev As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PanelMonthlyPayrollTrend As PanelRound
    Friend WithEvents lblMonthlyPayrollTrend As Label
    Friend WithEvents BillingDetailsPanel As PanelRound
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents BillingDetailsDGV As DataGridView
    Friend WithEvents BillingDetailsLbl As Label
    Friend WithEvents PaymentID As DataGridViewTextBoxColumn
    Friend WithEvents CustomerName As DataGridViewTextBoxColumn
    Friend WithEvents PlanType As DataGridViewTextBoxColumn
    Friend WithEvents MonthlyRate As DataGridViewTextBoxColumn
    Friend WithEvents AmountPaid As DataGridViewTextBoxColumn
    Friend WithEvents PaymentDate As DataGridViewTextBoxColumn
    Friend WithEvents PanelRound1 As PanelRound
    Friend WithEvents OustandingPanel As PanelRound
    Friend WithEvents OverduePanel As PanelRound
    Friend WithEvents PlanAmountLbl As Label
    Friend WithEvents NameOfCustomerLbl As Label
    Friend WithEvents PaymentAlertsLbl As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PanelRound4 As PanelRound
    Friend WithEvents PanelRound2 As PanelRound
    Friend WithEvents PanelRound3 As PanelRound
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents PanelRound5 As PanelRound
    Friend WithEvents PanelRound6 As PanelRound
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ButtonRounded1 As ButtonRounded
    Friend WithEvents cbPosition As ComboBox
    Friend WithEvents ComboBox4 As ComboBox


End Class

