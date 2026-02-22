<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class payrollview
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(payrollview))
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        HeaderPayrollReport = New Label()
        PanelFilters = New PanelRound()
        btnExport = New ButtonRounded()
        cbDateRange = New ComboBox()
        cbPosition = New ComboBox()
        LblPosition = New Label()
        lblDateRange = New Label()
        Filters = New Label()
        PictureBox1 = New PictureBox()
        PanelTotalDeductions = New PanelRound()
        IconTotalDeductions = New PictureBox()
        ValueTotalDeductions = New Label()
        lblTotalDeductions = New Label()
        PanelGrossPay = New PanelRound()
        IconGrossPay = New PictureBox()
        ValueGrossPay = New Label()
        lblGrossPay = New Label()
        PanelNetPay = New PanelRound()
        IconNetPay = New PictureBox()
        ValueNetPay = New Label()
        LabelRevenuePlan = New Label()
        PanelTotalEmployee = New PanelRound()
        IconTotalEmployee = New PictureBox()
        ValueTotalEmployee = New Label()
        LabelTotalEmployee = New Label()
        PanelMonthlyPayrollTrend = New PanelRound()
        graph = New Panel()
        lblMonthlyPayrollTrend = New Label()
        PanelRound1 = New PanelRound()
        PanelInventoryService = New PanelRound()
        AveragePayrollInventory = New Label()
        LabelAvgInventory = New Label()
        TotalPayrollInventory = New Label()
        NumberOfInventory = New Label()
        LabelInventoryService = New Label()
        PanelCustomerService = New PanelRound()
        AveragePayrollCS = New Label()
        LabelAvgCS = New Label()
        TotalPayrollCS = New Label()
        NumberOfCS = New Label()
        LabelCustomerService = New Label()
        PanelTechnician = New PanelRound()
        AveragePayrollTechnician = New Label()
        LabelAvgTechnician = New Label()
        TotalPayrollTechnician = New Label()
        NumberOfTechnician = New Label()
        LabelTechnician = New Label()
        LblPayrollByPosition = New Label()
        PanelEmployeePayrollDetails = New PanelRound()
        deleteAll = New PictureBox()
        btnSelectSubscriber = New PictureBox()
        txtPayrollSearchSA = New TextBox()
        btnPayrollPreviousSA = New Button()
        btnNextPayrollSA = New Button()
        LblPageInfo = New Label()
        DataGridEm0ployeePayrollDetails = New DataGridView()
        EmployeeID = New DataGridViewTextBoxColumn()
        EmployeeName = New DataGridViewTextBoxColumn()
        Position = New DataGridViewTextBoxColumn()
        DailyRate = New DataGridViewTextBoxColumn()
        DaysWorked = New DataGridViewTextBoxColumn()
        GrossPay = New DataGridViewTextBoxColumn()
        NetPay = New DataGridViewTextBoxColumn()
        colEdit = New DataGridViewImageColumn()
        colDelete = New DataGridViewImageColumn()
        colCheckBox = New DataGridViewCheckBoxColumn()
        LabelEmployeePayrollDetails = New Label()
        PanelRound2 = New PanelRound()
        PanelFilters.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        PanelTotalDeductions.SuspendLayout()
        CType(IconTotalDeductions, ComponentModel.ISupportInitialize).BeginInit()
        PanelGrossPay.SuspendLayout()
        CType(IconGrossPay, ComponentModel.ISupportInitialize).BeginInit()
        PanelNetPay.SuspendLayout()
        CType(IconNetPay, ComponentModel.ISupportInitialize).BeginInit()
        PanelTotalEmployee.SuspendLayout()
        CType(IconTotalEmployee, ComponentModel.ISupportInitialize).BeginInit()
        PanelMonthlyPayrollTrend.SuspendLayout()
        PanelRound1.SuspendLayout()
        PanelInventoryService.SuspendLayout()
        PanelCustomerService.SuspendLayout()
        PanelTechnician.SuspendLayout()
        PanelEmployeePayrollDetails.SuspendLayout()
        CType(deleteAll, ComponentModel.ISupportInitialize).BeginInit()
        CType(btnSelectSubscriber, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridEm0ployeePayrollDetails, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' HeaderPayrollReport
        ' 
        HeaderPayrollReport.AutoSize = True
        HeaderPayrollReport.Font = New Font("Segoe UI Semibold", 15F, FontStyle.Bold)
        HeaderPayrollReport.Location = New Point(42, 16)
        HeaderPayrollReport.Name = "HeaderPayrollReport"
        HeaderPayrollReport.Size = New Size(139, 28)
        HeaderPayrollReport.TabIndex = 48
        HeaderPayrollReport.Text = "Payroll Report"
        ' 
        ' PanelFilters
        ' 
        PanelFilters.BackColor = Color.White
        PanelFilters.Controls.Add(btnExport)
        PanelFilters.Controls.Add(cbDateRange)
        PanelFilters.Controls.Add(cbPosition)
        PanelFilters.Controls.Add(LblPosition)
        PanelFilters.Controls.Add(lblDateRange)
        PanelFilters.Controls.Add(Filters)
        PanelFilters.Controls.Add(PictureBox1)
        PanelFilters.CornerRadius = 12
        PanelFilters.Location = New Point(42, 59)
        PanelFilters.Name = "PanelFilters"
        PanelFilters.Size = New Size(1597, 165)
        PanelFilters.TabIndex = 49
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
        btnExport.Location = New Point(1358, 14)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(223, 34)
        btnExport.TabIndex = 62
        btnExport.Text = "Export Report"
        btnExport.UseVisualStyleBackColor = False
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
        ' LblPosition
        ' 
        LblPosition.AutoSize = True
        LblPosition.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        LblPosition.Location = New Point(366, 69)
        LblPosition.Name = "LblPosition"
        LblPosition.Size = New Size(68, 21)
        LblPosition.TabIndex = 8
        LblPosition.Text = "Position"
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
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(22, 10)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(24, 24)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' PanelTotalDeductions
        ' 
        PanelTotalDeductions.BackColor = Color.White
        PanelTotalDeductions.Controls.Add(IconTotalDeductions)
        PanelTotalDeductions.Controls.Add(ValueTotalDeductions)
        PanelTotalDeductions.Controls.Add(lblTotalDeductions)
        PanelTotalDeductions.CornerRadius = 12
        PanelTotalDeductions.Location = New Point(861, 267)
        PanelTotalDeductions.Name = "PanelTotalDeductions"
        PanelTotalDeductions.Size = New Size(367, 167)
        PanelTotalDeductions.TabIndex = 57
        ' 
        ' IconTotalDeductions
        ' 
        IconTotalDeductions.Image = CType(resources.GetObject("IconTotalDeductions.Image"), Image)
        IconTotalDeductions.Location = New Point(290, 59)
        IconTotalDeductions.Name = "IconTotalDeductions"
        IconTotalDeductions.Size = New Size(48, 50)
        IconTotalDeductions.SizeMode = PictureBoxSizeMode.Zoom
        IconTotalDeductions.TabIndex = 14
        IconTotalDeductions.TabStop = False
        ' 
        ' ValueTotalDeductions
        ' 
        ValueTotalDeductions.AutoSize = True
        ValueTotalDeductions.Font = New Font("Segoe UI Semibold", 22F, FontStyle.Bold)
        ValueTotalDeductions.ForeColor = Color.FromArgb(CByte(245), CByte(73), CByte(0))
        ValueTotalDeductions.Location = New Point(28, 78)
        ValueTotalDeductions.Name = "ValueTotalDeductions"
        ValueTotalDeductions.Size = New Size(78, 41)
        ValueTotalDeductions.TabIndex = 13
        ValueTotalDeductions.Text = "₱ 00"
        ' 
        ' lblTotalDeductions
        ' 
        lblTotalDeductions.AutoSize = True
        lblTotalDeductions.Font = New Font("Verdana", 12F)
        lblTotalDeductions.ForeColor = SystemColors.ControlDarkDark
        lblTotalDeductions.Location = New Point(28, 48)
        lblTotalDeductions.Name = "lblTotalDeductions"
        lblTotalDeductions.Size = New Size(145, 18)
        lblTotalDeductions.TabIndex = 12
        lblTotalDeductions.Text = "Total Deductions"
        ' 
        ' PanelGrossPay
        ' 
        PanelGrossPay.BackColor = Color.White
        PanelGrossPay.Controls.Add(IconGrossPay)
        PanelGrossPay.Controls.Add(ValueGrossPay)
        PanelGrossPay.Controls.Add(lblGrossPay)
        PanelGrossPay.CornerRadius = 12
        PanelGrossPay.Location = New Point(452, 267)
        PanelGrossPay.Name = "PanelGrossPay"
        PanelGrossPay.Size = New Size(367, 167)
        PanelGrossPay.TabIndex = 56
        ' 
        ' IconGrossPay
        ' 
        IconGrossPay.Image = CType(resources.GetObject("IconGrossPay.Image"), Image)
        IconGrossPay.Location = New Point(290, 59)
        IconGrossPay.Name = "IconGrossPay"
        IconGrossPay.Size = New Size(47, 50)
        IconGrossPay.SizeMode = PictureBoxSizeMode.Zoom
        IconGrossPay.TabIndex = 13
        IconGrossPay.TabStop = False
        ' 
        ' ValueGrossPay
        ' 
        ValueGrossPay.AutoSize = True
        ValueGrossPay.Font = New Font("Segoe UI Semibold", 22F, FontStyle.Bold)
        ValueGrossPay.ForeColor = Color.FromArgb(CByte(21), CByte(93), CByte(252))
        ValueGrossPay.Location = New Point(28, 68)
        ValueGrossPay.Name = "ValueGrossPay"
        ValueGrossPay.Size = New Size(78, 41)
        ValueGrossPay.TabIndex = 12
        ValueGrossPay.Text = "₱ 00"
        ' 
        ' lblGrossPay
        ' 
        lblGrossPay.AutoSize = True
        lblGrossPay.Font = New Font("Verdana", 12F)
        lblGrossPay.ForeColor = SystemColors.ControlDarkDark
        lblGrossPay.Location = New Point(28, 48)
        lblGrossPay.Name = "lblGrossPay"
        lblGrossPay.Size = New Size(89, 18)
        lblGrossPay.TabIndex = 11
        lblGrossPay.Text = "Gross Pay"
        ' 
        ' PanelNetPay
        ' 
        PanelNetPay.BackColor = Color.White
        PanelNetPay.Controls.Add(IconNetPay)
        PanelNetPay.Controls.Add(ValueNetPay)
        PanelNetPay.Controls.Add(LabelRevenuePlan)
        PanelNetPay.CornerRadius = 12
        PanelNetPay.Location = New Point(1272, 267)
        PanelNetPay.Name = "PanelNetPay"
        PanelNetPay.Size = New Size(367, 167)
        PanelNetPay.TabIndex = 55
        ' 
        ' IconNetPay
        ' 
        IconNetPay.Image = CType(resources.GetObject("IconNetPay.Image"), Image)
        IconNetPay.Location = New Point(290, 59)
        IconNetPay.Name = "IconNetPay"
        IconNetPay.Size = New Size(48, 50)
        IconNetPay.SizeMode = PictureBoxSizeMode.Zoom
        IconNetPay.TabIndex = 15
        IconNetPay.TabStop = False
        ' 
        ' ValueNetPay
        ' 
        ValueNetPay.AutoSize = True
        ValueNetPay.Font = New Font("Segoe UI Semibold", 22F, FontStyle.Bold)
        ValueNetPay.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        ValueNetPay.Location = New Point(28, 68)
        ValueNetPay.Name = "ValueNetPay"
        ValueNetPay.Size = New Size(78, 41)
        ValueNetPay.TabIndex = 14
        ValueNetPay.Text = "₱ 00"
        ' 
        ' LabelRevenuePlan
        ' 
        LabelRevenuePlan.AutoEllipsis = True
        LabelRevenuePlan.AutoSize = True
        LabelRevenuePlan.Font = New Font("Verdana", 12F)
        LabelRevenuePlan.ForeColor = SystemColors.ControlDarkDark
        LabelRevenuePlan.Location = New Point(28, 48)
        LabelRevenuePlan.Name = "LabelRevenuePlan"
        LabelRevenuePlan.Size = New Size(72, 18)
        LabelRevenuePlan.TabIndex = 13
        LabelRevenuePlan.Text = "Net Pay"
        ' 
        ' PanelTotalEmployee
        ' 
        PanelTotalEmployee.BackColor = Color.White
        PanelTotalEmployee.Controls.Add(IconTotalEmployee)
        PanelTotalEmployee.Controls.Add(ValueTotalEmployee)
        PanelTotalEmployee.Controls.Add(LabelTotalEmployee)
        PanelTotalEmployee.CornerRadius = 12
        PanelTotalEmployee.Location = New Point(42, 267)
        PanelTotalEmployee.Name = "PanelTotalEmployee"
        PanelTotalEmployee.Size = New Size(367, 167)
        PanelTotalEmployee.TabIndex = 54
        ' 
        ' IconTotalEmployee
        ' 
        IconTotalEmployee.Image = My.Resources.Resources.user_2
        IconTotalEmployee.Location = New Point(290, 59)
        IconTotalEmployee.Name = "IconTotalEmployee"
        IconTotalEmployee.Size = New Size(48, 50)
        IconTotalEmployee.SizeMode = PictureBoxSizeMode.Zoom
        IconTotalEmployee.TabIndex = 12
        IconTotalEmployee.TabStop = False
        ' 
        ' ValueTotalEmployee
        ' 
        ValueTotalEmployee.AutoSize = True
        ValueTotalEmployee.Font = New Font("Segoe UI Semibold", 22F, FontStyle.Bold)
        ValueTotalEmployee.Location = New Point(28, 78)
        ValueTotalEmployee.Name = "ValueTotalEmployee"
        ValueTotalEmployee.Size = New Size(52, 41)
        ValueTotalEmployee.TabIndex = 10
        ValueTotalEmployee.Text = "00"
        ' 
        ' LabelTotalEmployee
        ' 
        LabelTotalEmployee.AutoSize = True
        LabelTotalEmployee.Font = New Font("Verdana", 12F)
        LabelTotalEmployee.ForeColor = SystemColors.ControlDarkDark
        LabelTotalEmployee.Location = New Point(28, 48)
        LabelTotalEmployee.Name = "LabelTotalEmployee"
        LabelTotalEmployee.Size = New Size(133, 18)
        LabelTotalEmployee.TabIndex = 11
        LabelTotalEmployee.Text = "Total Employee"
        ' 
        ' PanelMonthlyPayrollTrend
        ' 
        PanelMonthlyPayrollTrend.BackColor = Color.White
        PanelMonthlyPayrollTrend.Controls.Add(graph)
        PanelMonthlyPayrollTrend.Controls.Add(lblMonthlyPayrollTrend)
        PanelMonthlyPayrollTrend.CornerRadius = 12
        PanelMonthlyPayrollTrend.Location = New Point(42, 477)
        PanelMonthlyPayrollTrend.Name = "PanelMonthlyPayrollTrend"
        PanelMonthlyPayrollTrend.Size = New Size(1597, 603)
        PanelMonthlyPayrollTrend.TabIndex = 58
        ' 
        ' graph
        ' 
        graph.Location = New Point(13, 57)
        graph.Name = "graph"
        graph.Size = New Size(1555, 513)
        graph.TabIndex = 36
        ' 
        ' lblMonthlyPayrollTrend
        ' 
        lblMonthlyPayrollTrend.Anchor = AnchorStyles.Top
        lblMonthlyPayrollTrend.AutoSize = True
        lblMonthlyPayrollTrend.Font = New Font("Verdana", 12F)
        lblMonthlyPayrollTrend.ForeColor = Color.Black
        lblMonthlyPayrollTrend.Location = New Point(19, 25)
        lblMonthlyPayrollTrend.Name = "lblMonthlyPayrollTrend"
        lblMonthlyPayrollTrend.Size = New Size(183, 18)
        lblMonthlyPayrollTrend.TabIndex = 35
        lblMonthlyPayrollTrend.Text = "Monthly Payroll Trend"
        ' 
        ' PanelRound1
        ' 
        PanelRound1.BackColor = Color.White
        PanelRound1.Controls.Add(PanelInventoryService)
        PanelRound1.Controls.Add(PanelCustomerService)
        PanelRound1.Controls.Add(PanelTechnician)
        PanelRound1.Controls.Add(LblPayrollByPosition)
        PanelRound1.CornerRadius = 12
        PanelRound1.Location = New Point(42, 1121)
        PanelRound1.Name = "PanelRound1"
        PanelRound1.Size = New Size(1597, 423)
        PanelRound1.TabIndex = 59
        ' 
        ' PanelInventoryService
        ' 
        PanelInventoryService.BackColor = Color.WhiteSmoke
        PanelInventoryService.Controls.Add(AveragePayrollInventory)
        PanelInventoryService.Controls.Add(LabelAvgInventory)
        PanelInventoryService.Controls.Add(TotalPayrollInventory)
        PanelInventoryService.Controls.Add(NumberOfInventory)
        PanelInventoryService.Controls.Add(LabelInventoryService)
        PanelInventoryService.CornerRadius = 12
        PanelInventoryService.Location = New Point(30, 289)
        PanelInventoryService.Name = "PanelInventoryService"
        PanelInventoryService.Size = New Size(1538, 85)
        PanelInventoryService.TabIndex = 37
        ' 
        ' AveragePayrollInventory
        ' 
        AveragePayrollInventory.AutoSize = True
        AveragePayrollInventory.Font = New Font("Segoe UI", 12F)
        AveragePayrollInventory.Location = New Point(1341, 48)
        AveragePayrollInventory.Name = "AveragePayrollInventory"
        AveragePayrollInventory.Size = New Size(41, 21)
        AveragePayrollInventory.TabIndex = 13
        AveragePayrollInventory.Text = "₱ 00"
        ' 
        ' LabelAvgInventory
        ' 
        LabelAvgInventory.AutoSize = True
        LabelAvgInventory.Font = New Font("Segoe UI", 12F)
        LabelAvgInventory.Location = New Point(1295, 48)
        LabelAvgInventory.Name = "LabelAvgInventory"
        LabelAvgInventory.Size = New Size(40, 21)
        LabelAvgInventory.TabIndex = 12
        LabelAvgInventory.Text = "Avg:"
        ' 
        ' TotalPayrollInventory
        ' 
        TotalPayrollInventory.AutoSize = True
        TotalPayrollInventory.Font = New Font("Segoe UI Semibold", 15F, FontStyle.Bold)
        TotalPayrollInventory.Location = New Point(1343, 15)
        TotalPayrollInventory.Name = "TotalPayrollInventory"
        TotalPayrollInventory.Size = New Size(52, 28)
        TotalPayrollInventory.TabIndex = 11
        TotalPayrollInventory.Text = "₱ 00"
        ' 
        ' NumberOfInventory
        ' 
        NumberOfInventory.AutoSize = True
        NumberOfInventory.Font = New Font("Segoe UI", 12F)
        NumberOfInventory.Location = New Point(14, 48)
        NumberOfInventory.Name = "NumberOfInventory"
        NumberOfInventory.Size = New Size(175, 21)
        NumberOfInventory.TabIndex = 10
        NumberOfInventory.Text = "[Number of Employees]"
        ' 
        ' LabelInventoryService
        ' 
        LabelInventoryService.AutoSize = True
        LabelInventoryService.Font = New Font("Segoe UI Semibold", 15F, FontStyle.Bold)
        LabelInventoryService.Location = New Point(14, 15)
        LabelInventoryService.Name = "LabelInventoryService"
        LabelInventoryService.Size = New Size(171, 28)
        LabelInventoryService.TabIndex = 9
        LabelInventoryService.Text = "Inventory Service"
        ' 
        ' PanelCustomerService
        ' 
        PanelCustomerService.BackColor = Color.WhiteSmoke
        PanelCustomerService.Controls.Add(AveragePayrollCS)
        PanelCustomerService.Controls.Add(LabelAvgCS)
        PanelCustomerService.Controls.Add(TotalPayrollCS)
        PanelCustomerService.Controls.Add(NumberOfCS)
        PanelCustomerService.Controls.Add(LabelCustomerService)
        PanelCustomerService.CornerRadius = 12
        PanelCustomerService.Location = New Point(30, 178)
        PanelCustomerService.Name = "PanelCustomerService"
        PanelCustomerService.Size = New Size(1538, 85)
        PanelCustomerService.TabIndex = 37
        ' 
        ' AveragePayrollCS
        ' 
        AveragePayrollCS.AutoSize = True
        AveragePayrollCS.Font = New Font("Segoe UI", 12F)
        AveragePayrollCS.Location = New Point(1341, 48)
        AveragePayrollCS.Name = "AveragePayrollCS"
        AveragePayrollCS.Size = New Size(41, 21)
        AveragePayrollCS.TabIndex = 13
        AveragePayrollCS.Text = "₱ 00"
        ' 
        ' LabelAvgCS
        ' 
        LabelAvgCS.AutoSize = True
        LabelAvgCS.Font = New Font("Segoe UI", 12F)
        LabelAvgCS.Location = New Point(1295, 48)
        LabelAvgCS.Name = "LabelAvgCS"
        LabelAvgCS.Size = New Size(40, 21)
        LabelAvgCS.TabIndex = 12
        LabelAvgCS.Text = "Avg:"
        ' 
        ' TotalPayrollCS
        ' 
        TotalPayrollCS.AutoSize = True
        TotalPayrollCS.Font = New Font("Segoe UI Semibold", 15F, FontStyle.Bold)
        TotalPayrollCS.Location = New Point(1343, 15)
        TotalPayrollCS.Name = "TotalPayrollCS"
        TotalPayrollCS.Size = New Size(52, 28)
        TotalPayrollCS.TabIndex = 11
        TotalPayrollCS.Text = "₱ 00"
        ' 
        ' NumberOfCS
        ' 
        NumberOfCS.AutoSize = True
        NumberOfCS.Font = New Font("Segoe UI", 12F)
        NumberOfCS.Location = New Point(14, 48)
        NumberOfCS.Name = "NumberOfCS"
        NumberOfCS.Size = New Size(175, 21)
        NumberOfCS.TabIndex = 10
        NumberOfCS.Text = "[Number of Employees]"
        ' 
        ' LabelCustomerService
        ' 
        LabelCustomerService.AutoSize = True
        LabelCustomerService.Font = New Font("Segoe UI Semibold", 15F, FontStyle.Bold)
        LabelCustomerService.Location = New Point(14, 15)
        LabelCustomerService.Name = "LabelCustomerService"
        LabelCustomerService.Size = New Size(171, 28)
        LabelCustomerService.TabIndex = 9
        LabelCustomerService.Text = "Customer Service"
        ' 
        ' PanelTechnician
        ' 
        PanelTechnician.BackColor = Color.WhiteSmoke
        PanelTechnician.Controls.Add(AveragePayrollTechnician)
        PanelTechnician.Controls.Add(LabelAvgTechnician)
        PanelTechnician.Controls.Add(TotalPayrollTechnician)
        PanelTechnician.Controls.Add(NumberOfTechnician)
        PanelTechnician.Controls.Add(LabelTechnician)
        PanelTechnician.CornerRadius = 12
        PanelTechnician.Location = New Point(30, 66)
        PanelTechnician.Name = "PanelTechnician"
        PanelTechnician.Size = New Size(1538, 85)
        PanelTechnician.TabIndex = 36
        ' 
        ' AveragePayrollTechnician
        ' 
        AveragePayrollTechnician.AutoSize = True
        AveragePayrollTechnician.Font = New Font("Segoe UI", 12F)
        AveragePayrollTechnician.Location = New Point(1341, 48)
        AveragePayrollTechnician.Name = "AveragePayrollTechnician"
        AveragePayrollTechnician.Size = New Size(41, 21)
        AveragePayrollTechnician.TabIndex = 12
        AveragePayrollTechnician.Text = "₱ 00"
        ' 
        ' LabelAvgTechnician
        ' 
        LabelAvgTechnician.AutoSize = True
        LabelAvgTechnician.Font = New Font("Segoe UI", 12F)
        LabelAvgTechnician.Location = New Point(1295, 48)
        LabelAvgTechnician.Name = "LabelAvgTechnician"
        LabelAvgTechnician.Size = New Size(40, 21)
        LabelAvgTechnician.TabIndex = 11
        LabelAvgTechnician.Text = "Avg:"
        ' 
        ' TotalPayrollTechnician
        ' 
        TotalPayrollTechnician.AutoSize = True
        TotalPayrollTechnician.Font = New Font("Segoe UI Semibold", 15F, FontStyle.Bold)
        TotalPayrollTechnician.Location = New Point(1343, 15)
        TotalPayrollTechnician.Name = "TotalPayrollTechnician"
        TotalPayrollTechnician.Size = New Size(52, 28)
        TotalPayrollTechnician.TabIndex = 10
        TotalPayrollTechnician.Text = "₱ 00"
        ' 
        ' NumberOfTechnician
        ' 
        NumberOfTechnician.AutoSize = True
        NumberOfTechnician.Font = New Font("Segoe UI", 12F)
        NumberOfTechnician.Location = New Point(14, 48)
        NumberOfTechnician.Name = "NumberOfTechnician"
        NumberOfTechnician.Size = New Size(175, 21)
        NumberOfTechnician.TabIndex = 9
        NumberOfTechnician.Text = "[Number of Employees]"
        ' 
        ' LabelTechnician
        ' 
        LabelTechnician.AutoSize = True
        LabelTechnician.Font = New Font("Segoe UI Semibold", 15F, FontStyle.Bold)
        LabelTechnician.Location = New Point(14, 15)
        LabelTechnician.Name = "LabelTechnician"
        LabelTechnician.Size = New Size(106, 28)
        LabelTechnician.TabIndex = 8
        LabelTechnician.Text = "Technician"
        ' 
        ' LblPayrollByPosition
        ' 
        LblPayrollByPosition.Anchor = AnchorStyles.Top
        LblPayrollByPosition.AutoSize = True
        LblPayrollByPosition.Font = New Font("Verdana", 12F)
        LblPayrollByPosition.ForeColor = Color.Black
        LblPayrollByPosition.Location = New Point(28, 22)
        LblPayrollByPosition.Name = "LblPayrollByPosition"
        LblPayrollByPosition.Size = New Size(160, 18)
        LblPayrollByPosition.TabIndex = 35
        LblPayrollByPosition.Text = "Payroll by Position"
        ' 
        ' PanelEmployeePayrollDetails
        ' 
        PanelEmployeePayrollDetails.BackColor = Color.White
        PanelEmployeePayrollDetails.Controls.Add(deleteAll)
        PanelEmployeePayrollDetails.Controls.Add(btnSelectSubscriber)
        PanelEmployeePayrollDetails.Controls.Add(txtPayrollSearchSA)
        PanelEmployeePayrollDetails.Controls.Add(btnPayrollPreviousSA)
        PanelEmployeePayrollDetails.Controls.Add(btnNextPayrollSA)
        PanelEmployeePayrollDetails.Controls.Add(LblPageInfo)
        PanelEmployeePayrollDetails.Controls.Add(DataGridEm0ployeePayrollDetails)
        PanelEmployeePayrollDetails.Controls.Add(LabelEmployeePayrollDetails)
        PanelEmployeePayrollDetails.CornerRadius = 12
        PanelEmployeePayrollDetails.Location = New Point(42, 1589)
        PanelEmployeePayrollDetails.Name = "PanelEmployeePayrollDetails"
        PanelEmployeePayrollDetails.Size = New Size(1597, 603)
        PanelEmployeePayrollDetails.TabIndex = 60
        ' 
        ' deleteAll
        ' 
        deleteAll.Image = My.Resources.Resources.delete2
        deleteAll.Location = New Point(1541, 21)
        deleteAll.Name = "deleteAll"
        deleteAll.Size = New Size(27, 18)
        deleteAll.SizeMode = PictureBoxSizeMode.Zoom
        deleteAll.TabIndex = 62
        deleteAll.TabStop = False
        ' 
        ' btnSelectSubscriber
        ' 
        btnSelectSubscriber.Image = My.Resources.Resources.selectall
        btnSelectSubscriber.Location = New Point(1520, 22)
        btnSelectSubscriber.Name = "btnSelectSubscriber"
        btnSelectSubscriber.Size = New Size(16, 16)
        btnSelectSubscriber.SizeMode = PictureBoxSizeMode.AutoSize
        btnSelectSubscriber.TabIndex = 61
        btnSelectSubscriber.TabStop = False
        ' 
        ' txtPayrollSearchSA
        ' 
        txtPayrollSearchSA.Font = New Font("Segoe UI", 12F)
        txtPayrollSearchSA.Location = New Point(1249, 17)
        txtPayrollSearchSA.Name = "txtPayrollSearchSA"
        txtPayrollSearchSA.PlaceholderText = "Search..."
        txtPayrollSearchSA.Size = New Size(259, 29)
        txtPayrollSearchSA.TabIndex = 59
        ' 
        ' btnPayrollPreviousSA
        ' 
        btnPayrollPreviousSA.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnPayrollPreviousSA.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnPayrollPreviousSA.ForeColor = Color.White
        btnPayrollPreviousSA.Location = New Point(1384, 561)
        btnPayrollPreviousSA.Name = "btnPayrollPreviousSA"
        btnPayrollPreviousSA.Size = New Size(75, 23)
        btnPayrollPreviousSA.TabIndex = 58
        btnPayrollPreviousSA.Text = "Previous"
        btnPayrollPreviousSA.UseVisualStyleBackColor = False
        btnPayrollPreviousSA.Visible = False
        ' 
        ' btnNextPayrollSA
        ' 
        btnNextPayrollSA.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnNextPayrollSA.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnNextPayrollSA.ForeColor = Color.White
        btnNextPayrollSA.Location = New Point(1465, 561)
        btnNextPayrollSA.Name = "btnNextPayrollSA"
        btnNextPayrollSA.Size = New Size(75, 23)
        btnNextPayrollSA.TabIndex = 57
        btnNextPayrollSA.Text = "Next"
        btnNextPayrollSA.UseVisualStyleBackColor = False
        ' 
        ' LblPageInfo
        ' 
        LblPageInfo.AutoSize = True
        LblPageInfo.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblPageInfo.ImageAlign = ContentAlignment.MiddleLeft
        LblPageInfo.Location = New Point(22, 566)
        LblPageInfo.Name = "LblPageInfo"
        LblPageInfo.Size = New Size(18, 18)
        LblPageInfo.TabIndex = 56
        LblPageInfo.Text = "0"
        ' 
        ' DataGridEm0ployeePayrollDetails
        ' 
        DataGridEm0ployeePayrollDetails.AllowUserToAddRows = False
        DataGridEm0ployeePayrollDetails.AllowUserToDeleteRows = False
        DataGridEm0ployeePayrollDetails.AllowUserToResizeColumns = False
        DataGridEm0ployeePayrollDetails.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = Color.Black
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridEm0ployeePayrollDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridEm0ployeePayrollDetails.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridEm0ployeePayrollDetails.BackgroundColor = Color.White
        DataGridEm0ployeePayrollDetails.BorderStyle = BorderStyle.None
        DataGridEm0ployeePayrollDetails.CellBorderStyle = DataGridViewCellBorderStyle.None
        DataGridEm0ployeePayrollDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Verdana", 10F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        DataGridEm0ployeePayrollDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridEm0ployeePayrollDetails.ColumnHeadersHeight = 45
        DataGridEm0ployeePayrollDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridEm0ployeePayrollDetails.Columns.AddRange(New DataGridViewColumn() {EmployeeID, EmployeeName, Position, DailyRate, DaysWorked, GrossPay, NetPay, colEdit, colDelete, colCheckBox})
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = SystemColors.Window
        DataGridViewCellStyle6.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle6.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.True
        DataGridEm0ployeePayrollDetails.DefaultCellStyle = DataGridViewCellStyle6
        DataGridEm0ployeePayrollDetails.EnableHeadersVisualStyles = False
        DataGridEm0ployeePayrollDetails.GridColor = Color.White
        DataGridEm0ployeePayrollDetails.Location = New Point(13, 74)
        DataGridEm0ployeePayrollDetails.Margin = New Padding(3, 2, 3, 2)
        DataGridEm0ployeePayrollDetails.Name = "DataGridEm0ployeePayrollDetails"
        DataGridEm0ployeePayrollDetails.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridEm0ployeePayrollDetails.RowHeadersVisible = False
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle7.ForeColor = Color.Black
        DataGridViewCellStyle7.WrapMode = DataGridViewTriState.True
        DataGridEm0ployeePayrollDetails.RowsDefaultCellStyle = DataGridViewCellStyle7
        DataGridEm0ployeePayrollDetails.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridEm0ployeePayrollDetails.RowTemplate.DefaultCellStyle.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridEm0ployeePayrollDetails.RowTemplate.DefaultCellStyle.ForeColor = Color.Black
        DataGridEm0ployeePayrollDetails.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridEm0ployeePayrollDetails.RowTemplate.Height = 40
        DataGridEm0ployeePayrollDetails.ScrollBars = ScrollBars.Vertical
        DataGridEm0ployeePayrollDetails.Size = New Size(1568, 481)
        DataGridEm0ployeePayrollDetails.TabIndex = 55
        ' 
        ' EmployeeID
        ' 
        EmployeeID.DataPropertyName = "EmployeeID"
        EmployeeID.HeaderText = "Employee ID"
        EmployeeID.Name = "EmployeeID"
        EmployeeID.Width = 175
        ' 
        ' EmployeeName
        ' 
        EmployeeName.DataPropertyName = "EmployeeName"
        EmployeeName.HeaderText = "Employee Name"
        EmployeeName.Name = "EmployeeName"
        EmployeeName.Width = 270
        ' 
        ' Position
        ' 
        Position.DataPropertyName = "Position"
        Position.HeaderText = "Position"
        Position.Name = "Position"
        Position.Width = 200
        ' 
        ' DailyRate
        ' 
        DailyRate.DataPropertyName = "DailyRate"
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        DailyRate.DefaultCellStyle = DataGridViewCellStyle3
        DailyRate.HeaderText = "Daily Rate"
        DailyRate.Name = "DailyRate"
        DailyRate.Width = 200
        ' 
        ' DaysWorked
        ' 
        DaysWorked.DataPropertyName = "DaysWorked"
        DaysWorked.HeaderText = "Days Worked"
        DaysWorked.Name = "DaysWorked"
        DaysWorked.Width = 200
        ' 
        ' GrossPay
        ' 
        GrossPay.DataPropertyName = "GrossPay"
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "C2"
        DataGridViewCellStyle4.NullValue = Nothing
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True
        GrossPay.DefaultCellStyle = DataGridViewCellStyle4
        GrossPay.HeaderText = "Gross Pay"
        GrossPay.Name = "GrossPay"
        GrossPay.Width = 200
        ' 
        ' NetPay
        ' 
        NetPay.DataPropertyName = "NetPay"
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "C2"
        DataGridViewCellStyle5.NullValue = Nothing
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.True
        NetPay.DefaultCellStyle = DataGridViewCellStyle5
        NetPay.HeaderText = "Net Pay"
        NetPay.Name = "NetPay"
        NetPay.Width = 200
        ' 
        ' colEdit
        ' 
        colEdit.HeaderText = ""
        colEdit.Image = My.Resources.Resources.edit
        colEdit.Name = "colEdit"
        colEdit.Width = 40
        ' 
        ' colDelete
        ' 
        colDelete.HeaderText = ""
        colDelete.Image = My.Resources.Resources.delete1
        colDelete.Name = "colDelete"
        colDelete.Width = 40
        ' 
        ' colCheckBox
        ' 
        colCheckBox.HeaderText = ""
        colCheckBox.Name = "colCheckBox"
        colCheckBox.Width = 40
        ' 
        ' LabelEmployeePayrollDetails
        ' 
        LabelEmployeePayrollDetails.Anchor = AnchorStyles.Top
        LabelEmployeePayrollDetails.AutoSize = True
        LabelEmployeePayrollDetails.Font = New Font("Verdana", 12F)
        LabelEmployeePayrollDetails.ForeColor = Color.Black
        LabelEmployeePayrollDetails.Location = New Point(28, 22)
        LabelEmployeePayrollDetails.Name = "LabelEmployeePayrollDetails"
        LabelEmployeePayrollDetails.Size = New Size(212, 18)
        LabelEmployeePayrollDetails.TabIndex = 35
        LabelEmployeePayrollDetails.Text = "Employee Payroll Details"
        ' 
        ' PanelRound2
        ' 
        PanelRound2.Location = New Point(42, 2225)
        PanelRound2.Name = "PanelRound2"
        PanelRound2.Size = New Size(1597, 49)
        PanelRound2.TabIndex = 61
        ' 
        ' payrollview
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.Control
        Controls.Add(PanelRound2)
        Controls.Add(PanelEmployeePayrollDetails)
        Controls.Add(PanelRound1)
        Controls.Add(PanelMonthlyPayrollTrend)
        Controls.Add(PanelTotalDeductions)
        Controls.Add(PanelGrossPay)
        Controls.Add(PanelNetPay)
        Controls.Add(PanelTotalEmployee)
        Controls.Add(PanelFilters)
        Controls.Add(HeaderPayrollReport)
        Name = "payrollview"
        Size = New Size(1940, 2375)
        PanelFilters.ResumeLayout(False)
        PanelFilters.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        PanelTotalDeductions.ResumeLayout(False)
        PanelTotalDeductions.PerformLayout()
        CType(IconTotalDeductions, ComponentModel.ISupportInitialize).EndInit()
        PanelGrossPay.ResumeLayout(False)
        PanelGrossPay.PerformLayout()
        CType(IconGrossPay, ComponentModel.ISupportInitialize).EndInit()
        PanelNetPay.ResumeLayout(False)
        PanelNetPay.PerformLayout()
        CType(IconNetPay, ComponentModel.ISupportInitialize).EndInit()
        PanelTotalEmployee.ResumeLayout(False)
        PanelTotalEmployee.PerformLayout()
        CType(IconTotalEmployee, ComponentModel.ISupportInitialize).EndInit()
        PanelMonthlyPayrollTrend.ResumeLayout(False)
        PanelMonthlyPayrollTrend.PerformLayout()
        PanelRound1.ResumeLayout(False)
        PanelRound1.PerformLayout()
        PanelInventoryService.ResumeLayout(False)
        PanelInventoryService.PerformLayout()
        PanelCustomerService.ResumeLayout(False)
        PanelCustomerService.PerformLayout()
        PanelTechnician.ResumeLayout(False)
        PanelTechnician.PerformLayout()
        PanelEmployeePayrollDetails.ResumeLayout(False)
        PanelEmployeePayrollDetails.PerformLayout()
        CType(deleteAll, ComponentModel.ISupportInitialize).EndInit()
        CType(btnSelectSubscriber, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridEm0ployeePayrollDetails, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents HeaderPayrollReport As Label
    Friend WithEvents PanelFilters As PanelRound
    Friend WithEvents cbDateRange As ComboBox
    Friend WithEvents cbPosition As ComboBox
    Friend WithEvents LblPosition As Label
    Friend WithEvents lblDateRange As Label
    Friend WithEvents Filters As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PanelTotalDeductions As PanelRound
    Friend WithEvents IconTotalDeductions As PictureBox
    Friend WithEvents ValueTotalDeductions As Label
    Friend WithEvents lblTotalDeductions As Label
    Friend WithEvents PanelGrossPay As PanelRound
    Friend WithEvents IconGrossPay As PictureBox
    Friend WithEvents ValueGrossPay As Label
    Friend WithEvents lblGrossPay As Label
    Friend WithEvents PanelNetPay As PanelRound
    Friend WithEvents IconNetPay As PictureBox
    Friend WithEvents ValueNetPay As Label
    Friend WithEvents LabelRevenuePlan As Label
    Friend WithEvents PanelTotalEmployee As PanelRound
    Friend WithEvents IconTotalEmployee As PictureBox
    Friend WithEvents ValueTotalEmployee As Label
    Friend WithEvents LabelTotalEmployee As Label
    Friend WithEvents PanelMonthlyPayrollTrend As PanelRound
    Friend WithEvents lblMonthlyPayrollTrend As Label
    Friend WithEvents PanelRound1 As PanelRound
    Friend WithEvents LblPayrollByPosition As Label
    Friend WithEvents PanelInventoryService As PanelRound
    Friend WithEvents PanelCustomerService As PanelRound
    Friend WithEvents PanelTechnician As PanelRound
    Friend WithEvents LabelTechnician As Label
    Friend WithEvents LabelInventoryService As Label
    Friend WithEvents LabelCustomerService As Label
    Friend WithEvents NumberOfInventory As Label
    Friend WithEvents NumberOfCS As Label
    Friend WithEvents NumberOfTechnician As Label
    Friend WithEvents LabelAvgInventory As Label
    Friend WithEvents TotalPayrollInventory As Label
    Friend WithEvents LabelAvgCS As Label
    Friend WithEvents TotalPayrollCS As Label
    Friend WithEvents LabelAvgTechnician As Label
    Friend WithEvents TotalPayrollTechnician As Label
    Friend WithEvents AveragePayrollInventory As Label
    Friend WithEvents AveragePayrollCS As Label
    Friend WithEvents AveragePayrollTechnician As Label
    Friend WithEvents PanelEmployeePayrollDetails As PanelRound
    Friend WithEvents LabelEmployeePayrollDetails As Label
    Friend WithEvents PanelRound2 As PanelRound
    Friend WithEvents graph As Panel
    Friend WithEvents LblPageInfo As Label
    Friend WithEvents btnNextPayrollSA As Button
    Friend WithEvents btnPayrollPreviousSA As Button
    Friend WithEvents btnExport As ButtonRounded
    Public WithEvents DataGridEm0ployeePayrollDetails As DataGridView
    Friend WithEvents txtPayrollSearchSA As TextBox
    Friend WithEvents btnSelectSubscriber As PictureBox
    Friend WithEvents deleteAll As PictureBox
    Friend WithEvents EmployeeID As DataGridViewTextBoxColumn
    Friend WithEvents EmployeeName As DataGridViewTextBoxColumn
    Friend WithEvents Position As DataGridViewTextBoxColumn
    Friend WithEvents DailyRate As DataGridViewTextBoxColumn
    Friend WithEvents DaysWorked As DataGridViewTextBoxColumn
    Friend WithEvents GrossPay As DataGridViewTextBoxColumn
    Friend WithEvents NetPay As DataGridViewTextBoxColumn
    Friend WithEvents colEdit As DataGridViewImageColumn
    Friend WithEvents colDelete As DataGridViewImageColumn
    Friend WithEvents colCheckBox As DataGridViewCheckBoxColumn

End Class


