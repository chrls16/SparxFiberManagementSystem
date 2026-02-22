<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class salesview
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                ' Clean up timer
                If updateTimer IsNot Nothing Then
                    updateTimer.Stop()
                    updateTimer.Dispose()
                End If

                ' Clean up components
                If components IsNot Nothing Then
                    components.Dispose()
                End If
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(salesview))
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        TableLayoutPanel1 = New TableLayoutPanel()
        AvgRev = New Label()
        LblAvgRev = New Label()
        pnlAvgRev = New PanelRound()
        MonthlyRev = New Label()
        LblTotalMonthlyRev = New Label()
        TotalSales = New Label()
        LblTotalNewSales = New Label()
        pnlTotalNewSales = New PanelRound()
        LblMonthlySalesVolume = New Label()
        pnlTotalMonthlyRev = New PanelRound()
        CBPlanType = New ComboBox()
        CBDateRange = New ComboBox()
        LblPlanType = New Label()
        LblDateRange = New Label()
        LblFilters = New Label()
        btnExport = New ButtonRounded()
        pnlMonthlySalesVol = New PanelRound()
        PanelRound1 = New PanelRound()
        PnlFilters = New PanelRound()
        LblSalesReport = New Label()
        PanelRound2 = New PanelRound()
        dgvRecentSales = New DataGridView()
        colCustomerID = New DataGridViewTextBoxColumn()
        colName = New DataGridViewTextBoxColumn()
        colDateInstalled = New DataGridViewTextBoxColumn()
        colPlanType = New DataGridViewTextBoxColumn()
        colMonthlyRate = New DataGridViewTextBoxColumn()
        LblPageInfo = New Label()
        btnSalesPreviousSA = New Button()
        btnNext = New Button()
        txtSalesSearchSA = New TextBox()
        Label1 = New Label()
        Panel4 = New Panel()
        pnlAvgRev.SuspendLayout()
        pnlTotalNewSales.SuspendLayout()
        pnlTotalMonthlyRev.SuspendLayout()
        pnlMonthlySalesVol.SuspendLayout()
        PnlFilters.SuspendLayout()
        PanelRound2.SuspendLayout()
        CType(dgvRecentSales, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 5
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 44.2953033F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 55.7046967F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 281F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 261F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 347F))
        TableLayoutPanel1.Location = New Point(6, 76)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 3
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 128F))
        TableLayoutPanel1.Size = New Size(1325, 416)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' AvgRev
        ' 
        AvgRev.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        AvgRev.Font = New Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        AvgRev.ForeColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        AvgRev.Location = New Point(3, 62)
        AvgRev.Name = "AvgRev"
        AvgRev.Size = New Size(494, 25)
        AvgRev.TabIndex = 8
        AvgRev.Text = "0"
        AvgRev.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblAvgRev
        ' 
        LblAvgRev.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LblAvgRev.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblAvgRev.Location = New Point(3, 25)
        LblAvgRev.Name = "LblAvgRev"
        LblAvgRev.Size = New Size(494, 18)
        LblAvgRev.TabIndex = 8
        LblAvgRev.Text = "Avg Revenue Per Sale"
        LblAvgRev.TextAlign = ContentAlignment.TopCenter
        ' 
        ' pnlAvgRev
        ' 
        pnlAvgRev.BackColor = Color.White
        pnlAvgRev.Controls.Add(AvgRev)
        pnlAvgRev.Controls.Add(LblAvgRev)
        pnlAvgRev.Location = New Point(1127, 247)
        pnlAvgRev.Margin = New Padding(3, 2, 3, 2)
        pnlAvgRev.Name = "pnlAvgRev"
        pnlAvgRev.Size = New Size(500, 142)
        pnlAvgRev.TabIndex = 20
        ' 
        ' MonthlyRev
        ' 
        MonthlyRev.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        MonthlyRev.Font = New Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MonthlyRev.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        MonthlyRev.Location = New Point(3, 62)
        MonthlyRev.Name = "MonthlyRev"
        MonthlyRev.Size = New Size(494, 25)
        MonthlyRev.TabIndex = 7
        MonthlyRev.Text = "0"
        MonthlyRev.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblTotalMonthlyRev
        ' 
        LblTotalMonthlyRev.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LblTotalMonthlyRev.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblTotalMonthlyRev.Location = New Point(3, 25)
        LblTotalMonthlyRev.Name = "LblTotalMonthlyRev"
        LblTotalMonthlyRev.Size = New Size(494, 18)
        LblTotalMonthlyRev.TabIndex = 7
        LblTotalMonthlyRev.Text = "Total Monthly Revenue"
        LblTotalMonthlyRev.TextAlign = ContentAlignment.TopCenter
        ' 
        ' TotalSales
        ' 
        TotalSales.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        TotalSales.Font = New Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TotalSales.ForeColor = Color.Blue
        TotalSales.Location = New Point(3, 60)
        TotalSales.Name = "TotalSales"
        TotalSales.Size = New Size(494, 25)
        TotalSales.TabIndex = 6
        TotalSales.Text = "0"
        TotalSales.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblTotalNewSales
        ' 
        LblTotalNewSales.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LblTotalNewSales.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblTotalNewSales.Location = New Point(4, 23)
        LblTotalNewSales.Name = "LblTotalNewSales"
        LblTotalNewSales.Size = New Size(493, 18)
        LblTotalNewSales.TabIndex = 5
        LblTotalNewSales.Text = "Total New Sales"
        LblTotalNewSales.TextAlign = ContentAlignment.TopCenter
        ' 
        ' pnlTotalNewSales
        ' 
        pnlTotalNewSales.BackColor = Color.White
        pnlTotalNewSales.Controls.Add(TotalSales)
        pnlTotalNewSales.Controls.Add(LblTotalNewSales)
        pnlTotalNewSales.Location = New Point(30, 249)
        pnlTotalNewSales.Margin = New Padding(3, 2, 3, 2)
        pnlTotalNewSales.Name = "pnlTotalNewSales"
        pnlTotalNewSales.Size = New Size(500, 142)
        pnlTotalNewSales.TabIndex = 19
        ' 
        ' LblMonthlySalesVolume
        ' 
        LblMonthlySalesVolume.AutoSize = True
        LblMonthlySalesVolume.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblMonthlySalesVolume.ImageAlign = ContentAlignment.MiddleLeft
        LblMonthlySalesVolume.Location = New Point(28, 19)
        LblMonthlySalesVolume.Name = "LblMonthlySalesVolume"
        LblMonthlySalesVolume.Size = New Size(188, 18)
        LblMonthlySalesVolume.TabIndex = 5
        LblMonthlySalesVolume.Text = "Monthly Sales Volume"
        ' 
        ' pnlTotalMonthlyRev
        ' 
        pnlTotalMonthlyRev.BackColor = Color.White
        pnlTotalMonthlyRev.Controls.Add(MonthlyRev)
        pnlTotalMonthlyRev.Controls.Add(LblTotalMonthlyRev)
        pnlTotalMonthlyRev.Location = New Point(578, 247)
        pnlTotalMonthlyRev.Margin = New Padding(3, 2, 3, 2)
        pnlTotalMonthlyRev.Name = "pnlTotalMonthlyRev"
        pnlTotalMonthlyRev.Size = New Size(500, 142)
        pnlTotalMonthlyRev.TabIndex = 21
        ' 
        ' CBPlanType
        ' 
        CBPlanType.DropDownStyle = ComboBoxStyle.DropDownList
        CBPlanType.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CBPlanType.FormattingEnabled = True
        CBPlanType.Items.AddRange(New Object() {"All Plans", "Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})
        CBPlanType.Location = New Point(228, 100)
        CBPlanType.Margin = New Padding(3, 2, 3, 2)
        CBPlanType.Name = "CBPlanType"
        CBPlanType.Size = New Size(180, 33)
        CBPlanType.TabIndex = 4
        ' 
        ' CBDateRange
        ' 
        CBDateRange.DropDownStyle = ComboBoxStyle.DropDownList
        CBDateRange.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CBDateRange.FormattingEnabled = True
        CBDateRange.Items.AddRange(New Object() {"All Time", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        CBDateRange.Location = New Point(30, 100)
        CBDateRange.Margin = New Padding(3, 2, 3, 2)
        CBDateRange.Name = "CBDateRange"
        CBDateRange.Size = New Size(151, 33)
        CBDateRange.TabIndex = 3
        ' 
        ' LblPlanType
        ' 
        LblPlanType.AutoSize = True
        LblPlanType.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblPlanType.Location = New Point(228, 77)
        LblPlanType.Name = "LblPlanType"
        LblPlanType.Size = New Size(79, 21)
        LblPlanType.TabIndex = 2
        LblPlanType.Text = "Plan Type"
        ' 
        ' LblDateRange
        ' 
        LblDateRange.AutoSize = True
        LblDateRange.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblDateRange.Location = New Point(28, 77)
        LblDateRange.Name = "LblDateRange"
        LblDateRange.Size = New Size(94, 21)
        LblDateRange.TabIndex = 1
        LblDateRange.Text = "Date Range"
        ' 
        ' LblFilters
        ' 
        LblFilters.AutoSize = True
        LblFilters.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblFilters.Image = CType(resources.GetObject("LblFilters.Image"), Image)
        LblFilters.ImageAlign = ContentAlignment.MiddleLeft
        LblFilters.Location = New Point(30, 33)
        LblFilters.Name = "LblFilters"
        LblFilters.Size = New Size(89, 18)
        LblFilters.TabIndex = 0
        LblFilters.Text = "     Filters"
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
        btnExport.Location = New Point(1367, 61)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(223, 34)
        btnExport.TabIndex = 22
        btnExport.Text = "Export Report"
        btnExport.UseVisualStyleBackColor = False
        ' 
        ' pnlMonthlySalesVol
        ' 
        pnlMonthlySalesVol.BackColor = Color.White
        pnlMonthlySalesVol.Controls.Add(PanelRound1)
        pnlMonthlySalesVol.Controls.Add(LblMonthlySalesVolume)
        pnlMonthlySalesVol.Location = New Point(30, 416)
        pnlMonthlySalesVol.Margin = New Padding(3, 2, 3, 2)
        pnlMonthlySalesVol.Name = "pnlMonthlySalesVol"
        pnlMonthlySalesVol.Size = New Size(1597, 459)
        pnlMonthlySalesVol.TabIndex = 17
        ' 
        ' PanelRound1
        ' 
        PanelRound1.Location = New Point(3, 51)
        PanelRound1.Name = "PanelRound1"
        PanelRound1.Size = New Size(1591, 365)
        PanelRound1.TabIndex = 23
        ' 
        ' PnlFilters
        ' 
        PnlFilters.BackColor = Color.White
        PnlFilters.Controls.Add(CBPlanType)
        PnlFilters.Controls.Add(CBDateRange)
        PnlFilters.Controls.Add(LblPlanType)
        PnlFilters.Controls.Add(LblDateRange)
        PnlFilters.Controls.Add(LblFilters)
        PnlFilters.Location = New Point(30, 59)
        PnlFilters.Margin = New Padding(3, 2, 3, 2)
        PnlFilters.Name = "PnlFilters"
        PnlFilters.Size = New Size(1597, 165)
        PnlFilters.TabIndex = 16
        ' 
        ' LblSalesReport
        ' 
        LblSalesReport.AutoSize = True
        LblSalesReport.Font = New Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblSalesReport.Location = New Point(24, 17)
        LblSalesReport.Name = "LblSalesReport"
        LblSalesReport.Size = New Size(125, 28)
        LblSalesReport.TabIndex = 15
        LblSalesReport.Text = "Sales Report"
        ' 
        ' PanelRound2
        ' 
        PanelRound2.BackColor = Color.White
        PanelRound2.Controls.Add(dgvRecentSales)
        PanelRound2.Controls.Add(LblPageInfo)
        PanelRound2.Controls.Add(btnSalesPreviousSA)
        PanelRound2.Controls.Add(btnNext)
        PanelRound2.Controls.Add(txtSalesSearchSA)
        PanelRound2.Controls.Add(Label1)
        PanelRound2.Location = New Point(34, 898)
        PanelRound2.Margin = New Padding(3, 2, 3, 2)
        PanelRound2.Name = "PanelRound2"
        PanelRound2.Size = New Size(1597, 629)
        PanelRound2.TabIndex = 24
        ' 
        ' dgvRecentSales
        ' 
        dgvRecentSales.AllowUserToAddRows = False
        dgvRecentSales.AllowUserToDeleteRows = False
        dgvRecentSales.AllowUserToResizeColumns = False
        dgvRecentSales.AllowUserToResizeRows = False
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvRecentSales.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvRecentSales.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvRecentSales.BackgroundColor = Color.White
        dgvRecentSales.BorderStyle = BorderStyle.None
        dgvRecentSales.CellBorderStyle = DataGridViewCellBorderStyle.None
        dgvRecentSales.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Verdana", 10F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = Color.White
        DataGridViewCellStyle2.SelectionForeColor = Color.Black
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvRecentSales.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvRecentSales.ColumnHeadersHeight = 45
        dgvRecentSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvRecentSales.Columns.AddRange(New DataGridViewColumn() {colCustomerID, colName, colDateInstalled, colPlanType, colMonthlyRate})
        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = SystemColors.Window
        DataGridViewCellStyle8.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle8.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = Color.White
        DataGridViewCellStyle8.SelectionForeColor = Color.Black
        DataGridViewCellStyle8.WrapMode = DataGridViewTriState.True
        dgvRecentSales.DefaultCellStyle = DataGridViewCellStyle8
        dgvRecentSales.EnableHeadersVisualStyles = False
        dgvRecentSales.GridColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        dgvRecentSales.Location = New Point(12, 58)
        dgvRecentSales.Margin = New Padding(3, 2, 3, 2)
        dgvRecentSales.Name = "dgvRecentSales"
        dgvRecentSales.ReadOnly = True
        dgvRecentSales.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = Color.White
        DataGridViewCellStyle9.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle9.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = Color.White
        DataGridViewCellStyle9.SelectionForeColor = Color.Black
        DataGridViewCellStyle9.WrapMode = DataGridViewTriState.True
        dgvRecentSales.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        dgvRecentSales.RowHeadersVisible = False
        dgvRecentSales.RowHeadersWidth = 51
        DataGridViewCellStyle10.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle10.WrapMode = DataGridViewTriState.True
        dgvRecentSales.RowsDefaultCellStyle = DataGridViewCellStyle10
        dgvRecentSales.RowTemplate.DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)
        dgvRecentSales.RowTemplate.Height = 37
        dgvRecentSales.ScrollBars = ScrollBars.Vertical
        dgvRecentSales.Size = New Size(1566, 530)
        dgvRecentSales.TabIndex = 23
        ' 
        ' colCustomerID
        ' 
        colCustomerID.DataPropertyName = "CustomerID"
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.Padding = New Padding(10, 0, 10, 0)
        colCustomerID.DefaultCellStyle = DataGridViewCellStyle3
        colCustomerID.HeaderText = "Customer ID"
        colCustomerID.MinimumWidth = 6
        colCustomerID.Name = "colCustomerID"
        colCustomerID.ReadOnly = True
        colCustomerID.Width = 313
        ' 
        ' colName
        ' 
        colName.DataPropertyName = "Name"
        DataGridViewCellStyle4.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle4.Padding = New Padding(10, 0, 10, 0)
        colName.DefaultCellStyle = DataGridViewCellStyle4
        colName.HeaderText = "Customer Name"
        colName.MinimumWidth = 6
        colName.Name = "colName"
        colName.ReadOnly = True
        colName.Width = 313
        ' 
        ' colDateInstalled
        ' 
        colDateInstalled.DataPropertyName = "DateInstalled"
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        DataGridViewCellStyle5.Padding = New Padding(0, 0, 10, 0)
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.True
        colDateInstalled.DefaultCellStyle = DataGridViewCellStyle5
        colDateInstalled.HeaderText = "Date Installed"
        colDateInstalled.MinimumWidth = 6
        colDateInstalled.Name = "colDateInstalled"
        colDateInstalled.ReadOnly = True
        colDateInstalled.Width = 314
        ' 
        ' colPlanType
        ' 
        colPlanType.DataPropertyName = "PlanType"
        DataGridViewCellStyle6.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle6.Padding = New Padding(10, 0, 10, 0)
        colPlanType.DefaultCellStyle = DataGridViewCellStyle6
        colPlanType.HeaderText = "Plan Type"
        colPlanType.MinimumWidth = 6
        colPlanType.Name = "colPlanType"
        colPlanType.ReadOnly = True
        colPlanType.Width = 313
        ' 
        ' colMonthlyRate
        ' 
        colMonthlyRate.DataPropertyName = "MonthlyRate"
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle7.ForeColor = Color.Black
        DataGridViewCellStyle7.Format = "C2"
        colMonthlyRate.DefaultCellStyle = DataGridViewCellStyle7
        colMonthlyRate.HeaderText = "Monthly Rate"
        colMonthlyRate.MinimumWidth = 6
        colMonthlyRate.Name = "colMonthlyRate"
        colMonthlyRate.ReadOnly = True
        colMonthlyRate.Width = 313
        ' 
        ' LblPageInfo
        ' 
        LblPageInfo.AutoSize = True
        LblPageInfo.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblPageInfo.ImageAlign = ContentAlignment.MiddleLeft
        LblPageInfo.Location = New Point(12, 598)
        LblPageInfo.Name = "LblPageInfo"
        LblPageInfo.Size = New Size(18, 18)
        LblPageInfo.TabIndex = 9
        LblPageInfo.Text = "0"
        ' 
        ' btnSalesPreviousSA
        ' 
        btnSalesPreviousSA.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnSalesPreviousSA.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSalesPreviousSA.ForeColor = Color.White
        btnSalesPreviousSA.Location = New Point(1400, 593)
        btnSalesPreviousSA.Name = "btnSalesPreviousSA"
        btnSalesPreviousSA.Size = New Size(75, 23)
        btnSalesPreviousSA.TabIndex = 8
        btnSalesPreviousSA.Text = "Previous"
        btnSalesPreviousSA.UseVisualStyleBackColor = False
        btnSalesPreviousSA.Visible = False
        ' 
        ' btnNext
        ' 
        btnNext.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnNext.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnNext.ForeColor = Color.White
        btnNext.Location = New Point(1481, 593)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(75, 23)
        btnNext.TabIndex = 7
        btnNext.Text = "Next"
        btnNext.UseVisualStyleBackColor = False
        ' 
        ' txtSalesSearchSA
        ' 
        txtSalesSearchSA.Font = New Font("Segoe UI", 12F)
        txtSalesSearchSA.Location = New Point(1297, 14)
        txtSalesSearchSA.Name = "txtSalesSearchSA"
        txtSalesSearchSA.PlaceholderText = "Search..."
        txtSalesSearchSA.Size = New Size(259, 29)
        txtSalesSearchSA.TabIndex = 6
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ImageAlign = ContentAlignment.MiddleLeft
        Label1.Location = New Point(28, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(178, 18)
        Label1.TabIndex = 5
        Label1.Text = "Recent Sales Details"
        ' 
        ' Panel4
        ' 
        Panel4.Location = New Point(33, 1564)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(1598, 49)
        Panel4.TabIndex = 50
        ' 
        ' salesview
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        AutoSize = True
        BackColor = SystemColors.Control
        Controls.Add(Panel4)
        Controls.Add(PanelRound2)
        Controls.Add(pnlAvgRev)
        Controls.Add(pnlTotalNewSales)
        Controls.Add(pnlTotalMonthlyRev)
        Controls.Add(btnExport)
        Controls.Add(pnlMonthlySalesVol)
        Controls.Add(PnlFilters)
        Controls.Add(LblSalesReport)
        Name = "salesview"
        Size = New Size(1634, 1633)
        pnlAvgRev.ResumeLayout(False)
        pnlTotalNewSales.ResumeLayout(False)
        pnlTotalMonthlyRev.ResumeLayout(False)
        pnlMonthlySalesVol.ResumeLayout(False)
        pnlMonthlySalesVol.PerformLayout()
        PnlFilters.ResumeLayout(False)
        PnlFilters.PerformLayout()
        PanelRound2.ResumeLayout(False)
        PanelRound2.PerformLayout()
        CType(dgvRecentSales, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LblSalesReport As Label
    Friend WithEvents PnlFilters As PanelRound
    Friend WithEvents CBDateRange As ComboBox
    Friend WithEvents LblPlanType As Label
    Friend WithEvents LblDateRange As Label
    Friend WithEvents LblFilters As Label
    Friend WithEvents CBPlanType As ComboBox
    Friend WithEvents pnlMonthlySalesVol As PanelRound
    Friend WithEvents pnlTotalNewSales As PanelRound
    Friend WithEvents pnlTotalMonthlyRev As PanelRound
    Friend WithEvents pnlAvgRev As PanelRound
    Friend WithEvents TotalSales As Label
    Friend WithEvents LblTotalNewSales As Label
    Friend WithEvents MonthlyRev As Label
    Friend WithEvents LblTotalMonthlyRev As Label
    Friend WithEvents AvgRev As Label
    Friend WithEvents LblAvgRev As Label
    Friend WithEvents btnExport As ButtonRounded
    Friend WithEvents LblMonthlySalesVolume As Label
    Friend WithEvents PanelRound1 As PanelRound
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PanelRound2 As PanelRound
    Friend WithEvents Label1 As Label
    Friend WithEvents btnNext As Button
    Friend WithEvents txtSalesSearchSA As TextBox
    Friend WithEvents btnSalesPreviousSA As Button
    Friend WithEvents LblPageInfo As Label
    Friend WithEvents dgvRecentSales As DataGridView
    Friend WithEvents colCustomerID As DataGridViewTextBoxColumn
    Friend WithEvents colName As DataGridViewTextBoxColumn
    Friend WithEvents colDateInstalled As DataGridViewTextBoxColumn
    Friend WithEvents colPlanType As DataGridViewTextBoxColumn
    Friend WithEvents colMonthlyRate As DataGridViewTextBoxColumn
    Friend WithEvents Panel4 As Panel

End Class
