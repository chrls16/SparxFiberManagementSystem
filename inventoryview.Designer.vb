<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class inventoryview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(inventoryview))
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
        HeaderInventoryReport = New Label()
        InventoryFilterPanel = New PanelRound()
        btnDeploy = New ButtonRounded()
        btnExport = New ButtonRounded()
        ComboBox1 = New ComboBox()
        StatusLbl = New Label()
        LabelFilters = New Label()
        IconFilter = New PictureBox()
        TotalItemsPanel = New PanelRound()
        ItemIcon = New PictureBox()
        NumItemsLbl = New Label()
        TotalItemLbl = New Label()
        TotalValuePanel = New PanelRound()
        PictureBox1 = New PictureBox()
        CurrencyLbl = New Label()
        TotalValueLbl = New Label()
        LowStockPanel = New PanelRound()
        PictureBox2 = New PictureBox()
        NumLowStockLbl = New Label()
        LowStockLbl = New Label()
        OutofStockPanel = New PanelRound()
        PictureBox3 = New PictureBox()
        NumOutStockLbl = New Label()
        OutOfStockLbl = New Label()
        StockLevelDisLbl = New PanelRound()
        stock = New PanelRound()
        Label11 = New Label()
        InventoryDetailsPanel = New PanelRound()
        deleteAll = New PictureBox()
        LblPageInfo = New Label()
        btnInventPreviousSA = New Button()
        btnNextInventSA = New Button()
        btnSelectInventory = New PictureBox()
        btnAddInventory = New PictureBox()
        txtInventorySearchSA = New TextBox()
        InventoryDetailsDVG = New DataGridView()
        InventoryDetailsLbl = New Label()
        ItemID = New DataGridViewTextBoxColumn()
        ItemName = New DataGridViewTextBoxColumn()
        Technician = New DataGridViewTextBoxColumn()
        SerialNum = New DataGridViewTextBoxColumn()
        UnitCost = New DataGridViewTextBoxColumn()
        CurrentStock = New DataGridViewTextBoxColumn()
        TotalValue = New DataGridViewTextBoxColumn()
        Status = New DataGridViewTextBoxColumn()
        colEdit = New DataGridViewImageColumn()
        colDelete = New DataGridViewImageColumn()
        colCheckBox = New DataGridViewCheckBoxColumn()
        InventoryFilterPanel.SuspendLayout()
        CType(IconFilter, ComponentModel.ISupportInitialize).BeginInit()
        TotalItemsPanel.SuspendLayout()
        CType(ItemIcon, ComponentModel.ISupportInitialize).BeginInit()
        TotalValuePanel.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        LowStockPanel.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        OutofStockPanel.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        StockLevelDisLbl.SuspendLayout()
        InventoryDetailsPanel.SuspendLayout()
        CType(deleteAll, ComponentModel.ISupportInitialize).BeginInit()
        CType(btnSelectInventory, ComponentModel.ISupportInitialize).BeginInit()
        CType(btnAddInventory, ComponentModel.ISupportInitialize).BeginInit()
        CType(InventoryDetailsDVG, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' HeaderInventoryReport
        ' 
        HeaderInventoryReport.AutoSize = True
        HeaderInventoryReport.Font = New Font("Segoe UI Semibold", 15F, FontStyle.Bold)
        HeaderInventoryReport.Location = New Point(43, 18)
        HeaderInventoryReport.Name = "HeaderInventoryReport"
        HeaderInventoryReport.Size = New Size(167, 28)
        HeaderInventoryReport.TabIndex = 1
        HeaderInventoryReport.Text = "Inventory Report"
        ' 
        ' InventoryFilterPanel
        ' 
        InventoryFilterPanel.BackColor = Color.White
        InventoryFilterPanel.Controls.Add(btnDeploy)
        InventoryFilterPanel.Controls.Add(btnExport)
        InventoryFilterPanel.Controls.Add(ComboBox1)
        InventoryFilterPanel.Controls.Add(StatusLbl)
        InventoryFilterPanel.Controls.Add(LabelFilters)
        InventoryFilterPanel.Controls.Add(IconFilter)
        InventoryFilterPanel.CornerRadius = 12
        InventoryFilterPanel.Location = New Point(43, 72)
        InventoryFilterPanel.Name = "InventoryFilterPanel"
        InventoryFilterPanel.Size = New Size(1597, 188)
        InventoryFilterPanel.TabIndex = 2
        ' 
        ' btnDeploy
        ' 
        btnDeploy.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnDeploy.CornerRadius = 8
        btnDeploy.FlatAppearance.BorderSize = 0
        btnDeploy.FlatStyle = FlatStyle.Flat
        btnDeploy.ForeColor = Color.White
        btnDeploy.Location = New Point(310, 115)
        btnDeploy.Name = "btnDeploy"
        btnDeploy.Size = New Size(225, 35)
        btnDeploy.TabIndex = 25
        btnDeploy.Text = "Deploy"
        btnDeploy.UseVisualStyleBackColor = False
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
        btnExport.Location = New Point(1351, 9)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(223, 34)
        btnExport.TabIndex = 24
        btnExport.Text = "Export Report"
        btnExport.UseVisualStyleBackColor = False
        ' 
        ' ComboBox1
        ' 
        ComboBox1.BackColor = SystemColors.ButtonFace
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.Font = New Font("Segoe UI", 14F)
        ComboBox1.ForeColor = SystemColors.WindowText
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"In Stock", "Low Stock", "Critical low", "Out of Stock", "Deployed"})
        ComboBox1.Location = New Point(24, 115)
        ComboBox1.MinimumSize = New Size(193, 0)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(265, 33)
        ComboBox1.TabIndex = 5
        ' 
        ' StatusLbl
        ' 
        StatusLbl.AutoSize = True
        StatusLbl.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        StatusLbl.Location = New Point(22, 91)
        StatusLbl.Name = "StatusLbl"
        StatusLbl.Size = New Size(55, 21)
        StatusLbl.TabIndex = 3
        StatusLbl.Text = "Status"
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
        IconFilter.Image = My.Resources.Resources.filter
        IconFilter.Location = New Point(22, 19)
        IconFilter.Name = "IconFilter"
        IconFilter.Size = New Size(24, 24)
        IconFilter.SizeMode = PictureBoxSizeMode.Zoom
        IconFilter.TabIndex = 0
        IconFilter.TabStop = False
        ' 
        ' TotalItemsPanel
        ' 
        TotalItemsPanel.BackColor = Color.White
        TotalItemsPanel.Controls.Add(ItemIcon)
        TotalItemsPanel.Controls.Add(NumItemsLbl)
        TotalItemsPanel.Controls.Add(TotalItemLbl)
        TotalItemsPanel.CornerRadius = 12
        TotalItemsPanel.Location = New Point(43, 280)
        TotalItemsPanel.Name = "TotalItemsPanel"
        TotalItemsPanel.Size = New Size(367, 115)
        TotalItemsPanel.TabIndex = 14
        ' 
        ' ItemIcon
        ' 
        ItemIcon.Image = CType(resources.GetObject("ItemIcon.Image"), Image)
        ItemIcon.Location = New Point(286, 36)
        ItemIcon.Name = "ItemIcon"
        ItemIcon.Size = New Size(48, 50)
        ItemIcon.SizeMode = PictureBoxSizeMode.Zoom
        ItemIcon.TabIndex = 9
        ItemIcon.TabStop = False
        ' 
        ' NumItemsLbl
        ' 
        NumItemsLbl.AutoSize = True
        NumItemsLbl.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        NumItemsLbl.Location = New Point(24, 66)
        NumItemsLbl.Name = "NumItemsLbl"
        NumItemsLbl.Size = New Size(49, 30)
        NumItemsLbl.TabIndex = 8
        NumItemsLbl.Text = "000"
        ' 
        ' TotalItemLbl
        ' 
        TotalItemLbl.AutoSize = True
        TotalItemLbl.Font = New Font("Verdana", 12F)
        TotalItemLbl.ForeColor = SystemColors.ControlDarkDark
        TotalItemLbl.Location = New Point(24, 25)
        TotalItemLbl.Name = "TotalItemLbl"
        TotalItemLbl.Size = New Size(102, 18)
        TotalItemLbl.TabIndex = 8
        TotalItemLbl.Text = "Total Items"
        ' 
        ' TotalValuePanel
        ' 
        TotalValuePanel.BackColor = Color.White
        TotalValuePanel.Controls.Add(PictureBox1)
        TotalValuePanel.Controls.Add(CurrencyLbl)
        TotalValuePanel.Controls.Add(TotalValueLbl)
        TotalValuePanel.CornerRadius = 12
        TotalValuePanel.Location = New Point(455, 280)
        TotalValuePanel.Name = "TotalValuePanel"
        TotalValuePanel.Size = New Size(367, 115)
        TotalValuePanel.TabIndex = 15
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(286, 36)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(48, 50)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 9
        PictureBox1.TabStop = False
        ' 
        ' CurrencyLbl
        ' 
        CurrencyLbl.AutoSize = True
        CurrencyLbl.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        CurrencyLbl.ForeColor = Color.Green
        CurrencyLbl.Location = New Point(24, 66)
        CurrencyLbl.Name = "CurrencyLbl"
        CurrencyLbl.Size = New Size(49, 30)
        CurrencyLbl.TabIndex = 8
        CurrencyLbl.Text = "000"
        ' 
        ' TotalValueLbl
        ' 
        TotalValueLbl.AutoSize = True
        TotalValueLbl.Font = New Font("Verdana", 12F)
        TotalValueLbl.ForeColor = SystemColors.ControlDarkDark
        TotalValueLbl.Location = New Point(24, 25)
        TotalValueLbl.Name = "TotalValueLbl"
        TotalValueLbl.Size = New Size(99, 18)
        TotalValueLbl.TabIndex = 8
        TotalValueLbl.Text = "Total Value"
        ' 
        ' LowStockPanel
        ' 
        LowStockPanel.BackColor = Color.White
        LowStockPanel.Controls.Add(PictureBox2)
        LowStockPanel.Controls.Add(NumLowStockLbl)
        LowStockPanel.Controls.Add(LowStockLbl)
        LowStockPanel.CornerRadius = 12
        LowStockPanel.Location = New Point(864, 280)
        LowStockPanel.Name = "LowStockPanel"
        LowStockPanel.Size = New Size(367, 115)
        LowStockPanel.TabIndex = 16
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(286, 36)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(48, 50)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 9
        PictureBox2.TabStop = False
        ' 
        ' NumLowStockLbl
        ' 
        NumLowStockLbl.AutoSize = True
        NumLowStockLbl.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        NumLowStockLbl.ForeColor = Color.OrangeRed
        NumLowStockLbl.Location = New Point(24, 66)
        NumLowStockLbl.Name = "NumLowStockLbl"
        NumLowStockLbl.Size = New Size(25, 30)
        NumLowStockLbl.TabIndex = 8
        NumLowStockLbl.Text = "0"
        ' 
        ' LowStockLbl
        ' 
        LowStockLbl.AutoSize = True
        LowStockLbl.Font = New Font("Verdana", 12F)
        LowStockLbl.ForeColor = SystemColors.ControlDarkDark
        LowStockLbl.Location = New Point(24, 25)
        LowStockLbl.Name = "LowStockLbl"
        LowStockLbl.Size = New Size(148, 18)
        LowStockLbl.TabIndex = 8
        LowStockLbl.Text = "Items to Reorder"
        ' 
        ' OutofStockPanel
        ' 
        OutofStockPanel.BackColor = Color.White
        OutofStockPanel.Controls.Add(PictureBox3)
        OutofStockPanel.Controls.Add(NumOutStockLbl)
        OutofStockPanel.Controls.Add(OutOfStockLbl)
        OutofStockPanel.CornerRadius = 12
        OutofStockPanel.Location = New Point(1273, 280)
        OutofStockPanel.Name = "OutofStockPanel"
        OutofStockPanel.Size = New Size(367, 115)
        OutofStockPanel.TabIndex = 17
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(286, 36)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(48, 50)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 9
        PictureBox3.TabStop = False
        ' 
        ' NumOutStockLbl
        ' 
        NumOutStockLbl.AutoSize = True
        NumOutStockLbl.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        NumOutStockLbl.ForeColor = Color.Red
        NumOutStockLbl.Location = New Point(24, 66)
        NumOutStockLbl.Name = "NumOutStockLbl"
        NumOutStockLbl.Size = New Size(25, 30)
        NumOutStockLbl.TabIndex = 8
        NumOutStockLbl.Text = "0"
        ' 
        ' OutOfStockLbl
        ' 
        OutOfStockLbl.AutoSize = True
        OutOfStockLbl.Font = New Font("Verdana", 12F)
        OutOfStockLbl.ForeColor = SystemColors.ControlDarkDark
        OutOfStockLbl.Location = New Point(24, 25)
        OutOfStockLbl.Name = "OutOfStockLbl"
        OutOfStockLbl.Size = New Size(110, 18)
        OutOfStockLbl.TabIndex = 8
        OutOfStockLbl.Text = "Out of Stock"
        ' 
        ' StockLevelDisLbl
        ' 
        StockLevelDisLbl.BackColor = Color.White
        StockLevelDisLbl.Controls.Add(stock)
        StockLevelDisLbl.Controls.Add(Label11)
        StockLevelDisLbl.Location = New Point(43, 424)
        StockLevelDisLbl.Name = "StockLevelDisLbl"
        StockLevelDisLbl.Size = New Size(1597, 494)
        StockLevelDisLbl.TabIndex = 18
        ' 
        ' stock
        ' 
        stock.Location = New Point(22, 60)
        stock.Name = "stock"
        stock.Size = New Size(1552, 401)
        stock.TabIndex = 20
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.Black
        Label11.Location = New Point(22, 23)
        Label11.Name = "Label11"
        Label11.Size = New Size(203, 18)
        Label11.TabIndex = 9
        Label11.Text = "Stock Level Distribution"
        ' 
        ' InventoryDetailsPanel
        ' 
        InventoryDetailsPanel.BackColor = Color.White
        InventoryDetailsPanel.Controls.Add(deleteAll)
        InventoryDetailsPanel.Controls.Add(LblPageInfo)
        InventoryDetailsPanel.Controls.Add(btnInventPreviousSA)
        InventoryDetailsPanel.Controls.Add(btnNextInventSA)
        InventoryDetailsPanel.Controls.Add(btnSelectInventory)
        InventoryDetailsPanel.Controls.Add(btnAddInventory)
        InventoryDetailsPanel.Controls.Add(txtInventorySearchSA)
        InventoryDetailsPanel.Controls.Add(InventoryDetailsDVG)
        InventoryDetailsPanel.Controls.Add(InventoryDetailsLbl)
        InventoryDetailsPanel.Location = New Point(43, 949)
        InventoryDetailsPanel.Name = "InventoryDetailsPanel"
        InventoryDetailsPanel.Size = New Size(1597, 601)
        InventoryDetailsPanel.TabIndex = 19
        ' 
        ' deleteAll
        ' 
        deleteAll.Image = My.Resources.Resources.delete2
        deleteAll.Location = New Point(1554, 26)
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
        LblPageInfo.Location = New Point(28, 559)
        LblPageInfo.Name = "LblPageInfo"
        LblPageInfo.Size = New Size(18, 18)
        LblPageInfo.TabIndex = 39
        LblPageInfo.Text = "0"
        ' 
        ' btnInventPreviousSA
        ' 
        btnInventPreviousSA.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnInventPreviousSA.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnInventPreviousSA.ForeColor = Color.White
        btnInventPreviousSA.Location = New Point(1382, 557)
        btnInventPreviousSA.Name = "btnInventPreviousSA"
        btnInventPreviousSA.Size = New Size(75, 23)
        btnInventPreviousSA.TabIndex = 33
        btnInventPreviousSA.Text = "Previous"
        btnInventPreviousSA.UseVisualStyleBackColor = False
        btnInventPreviousSA.Visible = False
        ' 
        ' btnNextInventSA
        ' 
        btnNextInventSA.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnNextInventSA.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnNextInventSA.ForeColor = Color.White
        btnNextInventSA.Location = New Point(1461, 557)
        btnNextInventSA.Name = "btnNextInventSA"
        btnNextInventSA.Size = New Size(75, 23)
        btnNextInventSA.TabIndex = 32
        btnNextInventSA.Text = "Next"
        btnNextInventSA.UseVisualStyleBackColor = False
        ' 
        ' btnSelectInventory
        ' 
        btnSelectInventory.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btnSelectInventory.Image = My.Resources.Resources.selectall
        btnSelectInventory.Location = New Point(1535, 28)
        btnSelectInventory.Name = "btnSelectInventory"
        btnSelectInventory.Size = New Size(16, 16)
        btnSelectInventory.SizeMode = PictureBoxSizeMode.AutoSize
        btnSelectInventory.TabIndex = 31
        btnSelectInventory.TabStop = False
        ' 
        ' btnAddInventory
        ' 
        btnAddInventory.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btnAddInventory.Image = My.Resources.Resources.Add
        btnAddInventory.Location = New Point(1509, 28)
        btnAddInventory.Name = "btnAddInventory"
        btnAddInventory.Size = New Size(19, 19)
        btnAddInventory.SizeMode = PictureBoxSizeMode.AutoSize
        btnAddInventory.TabIndex = 30
        btnAddInventory.TabStop = False
        ' 
        ' txtInventorySearchSA
        ' 
        txtInventorySearchSA.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtInventorySearchSA.Font = New Font("Segoe UI", 12F)
        txtInventorySearchSA.Location = New Point(1225, 22)
        txtInventorySearchSA.Name = "txtInventorySearchSA"
        txtInventorySearchSA.PlaceholderText = "Search..."
        txtInventorySearchSA.Size = New Size(259, 29)
        txtInventorySearchSA.TabIndex = 25
        ' 
        ' InventoryDetailsDVG
        ' 
        InventoryDetailsDVG.AllowUserToAddRows = False
        InventoryDetailsDVG.AllowUserToDeleteRows = False
        InventoryDetailsDVG.AllowUserToResizeColumns = False
        InventoryDetailsDVG.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = Color.Black
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        InventoryDetailsDVG.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        InventoryDetailsDVG.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        InventoryDetailsDVG.BackgroundColor = Color.White
        InventoryDetailsDVG.BorderStyle = BorderStyle.None
        InventoryDetailsDVG.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        InventoryDetailsDVG.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Verdana", 10F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        InventoryDetailsDVG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        InventoryDetailsDVG.ColumnHeadersHeight = 45
        InventoryDetailsDVG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        InventoryDetailsDVG.Columns.AddRange(New DataGridViewColumn() {ItemID, ItemName, Technician, SerialNum, UnitCost, CurrentStock, TotalValue, Status, colEdit, colDelete, colCheckBox})
        DataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = Color.White
        DataGridViewCellStyle10.Font = New Font("Segoe UI", 11.25F)
        DataGridViewCellStyle10.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = DataGridViewTriState.True
        InventoryDetailsDVG.DefaultCellStyle = DataGridViewCellStyle10
        InventoryDetailsDVG.EnableHeadersVisualStyles = False
        InventoryDetailsDVG.GridColor = Color.White
        InventoryDetailsDVG.Location = New Point(14, 74)
        InventoryDetailsDVG.Margin = New Padding(3, 2, 3, 2)
        InventoryDetailsDVG.Name = "InventoryDetailsDVG"
        InventoryDetailsDVG.ReadOnly = True
        InventoryDetailsDVG.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = SystemColors.Control
        DataGridViewCellStyle11.Font = New Font("Segoe UI", 11F)
        DataGridViewCellStyle11.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = DataGridViewTriState.True
        InventoryDetailsDVG.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        InventoryDetailsDVG.RowHeadersVisible = False
        DataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle12.WrapMode = DataGridViewTriState.True
        InventoryDetailsDVG.RowsDefaultCellStyle = DataGridViewCellStyle12
        InventoryDetailsDVG.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        InventoryDetailsDVG.RowTemplate.DefaultCellStyle.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        InventoryDetailsDVG.RowTemplate.DefaultCellStyle.ForeColor = Color.Black
        InventoryDetailsDVG.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        InventoryDetailsDVG.RowTemplate.Height = 40
        InventoryDetailsDVG.ScrollBars = ScrollBars.Vertical
        InventoryDetailsDVG.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        InventoryDetailsDVG.Size = New Size(1567, 468)
        InventoryDetailsDVG.TabIndex = 23
        ' 
        ' InventoryDetailsLbl
        ' 
        InventoryDetailsLbl.AutoSize = True
        InventoryDetailsLbl.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        InventoryDetailsLbl.ForeColor = Color.Black
        InventoryDetailsLbl.Location = New Point(22, 23)
        InventoryDetailsLbl.Name = "InventoryDetailsLbl"
        InventoryDetailsLbl.Size = New Size(150, 18)
        InventoryDetailsLbl.TabIndex = 9
        InventoryDetailsLbl.Text = "Inventory Details"
        ' 
        ' ItemID
        ' 
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        ItemID.DefaultCellStyle = DataGridViewCellStyle3
        ItemID.Frozen = True
        ItemID.HeaderText = "Item ID"
        ItemID.Name = "ItemID"
        ItemID.ReadOnly = True
        ItemID.Width = 150
        ' 
        ' ItemName
        ' 
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft
        ItemName.DefaultCellStyle = DataGridViewCellStyle4
        ItemName.HeaderText = "Item Name"
        ItemName.Name = "ItemName"
        ItemName.ReadOnly = True
        ItemName.Width = 320
        ' 
        ' Technician
        ' 
        Technician.HeaderText = "Tech Assigned"
        Technician.Name = "Technician"
        Technician.ReadOnly = True
        Technician.Width = 130
        ' 
        ' SerialNum
        ' 
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft
        SerialNum.DefaultCellStyle = DataGridViewCellStyle5
        SerialNum.HeaderText = "Serial Number"
        SerialNum.Name = "SerialNum"
        SerialNum.ReadOnly = True
        SerialNum.Width = 170
        ' 
        ' UnitCost
        ' 
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "C2"
        DataGridViewCellStyle6.NullValue = Nothing
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.True
        UnitCost.DefaultCellStyle = DataGridViewCellStyle6
        UnitCost.HeaderText = "Unit Cost"
        UnitCost.Name = "UnitCost"
        UnitCost.ReadOnly = True
        UnitCost.Width = 170
        ' 
        ' CurrentStock
        ' 
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.WrapMode = DataGridViewTriState.True
        CurrentStock.DefaultCellStyle = DataGridViewCellStyle7
        CurrentStock.HeaderText = "Current Stock"
        CurrentStock.Name = "CurrentStock"
        CurrentStock.ReadOnly = True
        CurrentStock.Width = 160
        ' 
        ' TotalValue
        ' 
        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Format = "C2"
        DataGridViewCellStyle8.NullValue = Nothing
        DataGridViewCellStyle8.WrapMode = DataGridViewTriState.True
        TotalValue.DefaultCellStyle = DataGridViewCellStyle8
        TotalValue.HeaderText = "Total Value"
        TotalValue.Name = "TotalValue"
        TotalValue.ReadOnly = True
        TotalValue.Width = 200
        ' 
        ' Status
        ' 
        DataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft
        Status.DefaultCellStyle = DataGridViewCellStyle9
        Status.HeaderText = "Status"
        Status.Name = "Status"
        Status.ReadOnly = True
        Status.Width = 140
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
        colCheckBox.HeaderText = ""
        colCheckBox.Name = "colCheckBox"
        colCheckBox.ReadOnly = True
        colCheckBox.Width = 40
        ' 
        ' inventoryview
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        AutoSize = True
        BackColor = SystemColors.Control
        Controls.Add(InventoryDetailsPanel)
        Controls.Add(StockLevelDisLbl)
        Controls.Add(OutofStockPanel)
        Controls.Add(LowStockPanel)
        Controls.Add(TotalValuePanel)
        Controls.Add(TotalItemsPanel)
        Controls.Add(InventoryFilterPanel)
        Controls.Add(HeaderInventoryReport)
        Name = "inventoryview"
        Size = New Size(1793, 1800)
        InventoryFilterPanel.ResumeLayout(False)
        InventoryFilterPanel.PerformLayout()
        CType(IconFilter, ComponentModel.ISupportInitialize).EndInit()
        TotalItemsPanel.ResumeLayout(False)
        TotalItemsPanel.PerformLayout()
        CType(ItemIcon, ComponentModel.ISupportInitialize).EndInit()
        TotalValuePanel.ResumeLayout(False)
        TotalValuePanel.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        LowStockPanel.ResumeLayout(False)
        LowStockPanel.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        OutofStockPanel.ResumeLayout(False)
        OutofStockPanel.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        StockLevelDisLbl.ResumeLayout(False)
        StockLevelDisLbl.PerformLayout()
        InventoryDetailsPanel.ResumeLayout(False)
        InventoryDetailsPanel.PerformLayout()
        CType(deleteAll, ComponentModel.ISupportInitialize).EndInit()
        CType(btnSelectInventory, ComponentModel.ISupportInitialize).EndInit()
        CType(btnAddInventory, ComponentModel.ISupportInitialize).EndInit()
        CType(InventoryDetailsDVG, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents HeaderInventoryReport As Label
    Friend WithEvents InventoryFilterPanel As PanelRound
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents StatusLbl As Label
    Friend WithEvents LabelFilters As Label
    Friend WithEvents IconFilter As PictureBox
    Friend WithEvents TotalItemsPanel As PanelRound
    Friend WithEvents ItemIcon As PictureBox
    Friend WithEvents NumItemsLbl As Label
    Friend WithEvents TotalItemLbl As Label
    Friend WithEvents TotalValuePanel As PanelRound
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CurrencyLbl As Label
    Friend WithEvents TotalValueLbl As Label
    Friend WithEvents LowStockPanel As PanelRound
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents NumLowStockLbl As Label
    Friend WithEvents LowStockLbl As Label
    Friend WithEvents OutofStockPanel As PanelRound
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents NumOutStockLbl As Label
    Friend WithEvents OutOfStockLbl As Label
    Friend WithEvents StockLevelDisLbl As PanelRound
    Friend WithEvents Label11 As Label
    Friend WithEvents InventoryDetailsPanel As PanelRound
    Friend WithEvents InventoryDetailsLbl As Label
    Friend WithEvents InventoryDetailsDVG As DataGridView
    Friend WithEvents txtInventorySearchSA As TextBox
    Friend WithEvents btnSelectInventory As PictureBox
    Friend WithEvents btnAddInventory As PictureBox
    Friend WithEvents btnInventPreviousSA As Button
    Friend WithEvents btnNextInventSA As Button
    Friend WithEvents stock As PanelRound
    Friend WithEvents LblPageInfo As Label
    Friend WithEvents btnExport As ButtonRounded
    Friend WithEvents deleteAll As PictureBox
    Friend WithEvents btnDeploy As ButtonRounded
    Friend WithEvents ItemID As DataGridViewTextBoxColumn
    Friend WithEvents ItemName As DataGridViewTextBoxColumn
    Friend WithEvents Technician As DataGridViewTextBoxColumn
    Friend WithEvents SerialNum As DataGridViewTextBoxColumn
    Friend WithEvents UnitCost As DataGridViewTextBoxColumn
    Friend WithEvents CurrentStock As DataGridViewTextBoxColumn
    Friend WithEvents TotalValue As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents colEdit As DataGridViewImageColumn
    Friend WithEvents colDelete As DataGridViewImageColumn
    Friend WithEvents colCheckBox As DataGridViewCheckBoxColumn

End Class

