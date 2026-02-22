<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class History
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(History))
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Panel2 = New Panel()
        FilterPanel = New PanelRound()
        StatusComboBox = New ComboBox()
        ServiceComboBox = New ComboBox()
        DateComboBox = New ComboBox()
        StatusLbl = New Label()
        ServiceLbl = New Label()
        DateRangeLbl = New Label()
        FilterLbl = New Label()
        PictureBox1 = New PictureBox()
        PanelRound2 = New PanelRound()
        btnInstallationPrevious = New Button()
        btnNextInstallationSA = New Button()
        LblPageInfo = New Label()
        lblHistoryDetails = New Label()
        HistoryTable = New DataGridView()
        DateColumn = New DataGridViewTextBoxColumn()
        TransactionColumn = New DataGridViewTextBoxColumn()
        ServiceIDColumn = New DataGridViewTextBoxColumn()
        StartDateColumn = New DataGridViewTextBoxColumn()
        EndDateColumn = New DataGridViewTextBoxColumn()
        MonthlyRateColumn = New DataGridViewTextBoxColumn()
        PaymentMethodColumn = New DataGridViewTextBoxColumn()
        StatusColumn = New DataGridViewTextBoxColumn()
        ColorDialog1 = New ColorDialog()
        Panel2.SuspendLayout()
        FilterPanel.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        PanelRound2.SuspendLayout()
        CType(HistoryTable, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel2.Controls.Add(FilterPanel)
        Panel2.Controls.Add(PanelRound2)
        Panel2.Location = New Point(3, 7)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(2177, 2391)
        Panel2.TabIndex = 9
        ' 
        ' FilterPanel
        ' 
        FilterPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        FilterPanel.BackColor = Color.White
        FilterPanel.Controls.Add(StatusComboBox)
        FilterPanel.Controls.Add(ServiceComboBox)
        FilterPanel.Controls.Add(DateComboBox)
        FilterPanel.Controls.Add(StatusLbl)
        FilterPanel.Controls.Add(ServiceLbl)
        FilterPanel.Controls.Add(DateRangeLbl)
        FilterPanel.Controls.Add(FilterLbl)
        FilterPanel.Controls.Add(PictureBox1)
        FilterPanel.Location = New Point(39, 33)
        FilterPanel.Name = "FilterPanel"
        FilterPanel.Size = New Size(1562, 163)
        FilterPanel.TabIndex = 0
        ' 
        ' StatusComboBox
        ' 
        StatusComboBox.BackColor = Color.WhiteSmoke
        StatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        StatusComboBox.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        StatusComboBox.FormattingEnabled = True
        StatusComboBox.Location = New Point(483, 91)
        StatusComboBox.Name = "StatusComboBox"
        StatusComboBox.Size = New Size(193, 33)
        StatusComboBox.TabIndex = 5
        ' 
        ' ServiceComboBox
        ' 
        ServiceComboBox.BackColor = SystemColors.ButtonFace
        ServiceComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        ServiceComboBox.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ServiceComboBox.FormattingEnabled = True
        ServiceComboBox.Location = New Point(254, 91)
        ServiceComboBox.Name = "ServiceComboBox"
        ServiceComboBox.Size = New Size(193, 33)
        ServiceComboBox.TabIndex = 9
        ' 
        ' DateComboBox
        ' 
        DateComboBox.BackColor = SystemColors.ButtonFace
        DateComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        DateComboBox.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DateComboBox.FormattingEnabled = True
        DateComboBox.Location = New Point(25, 91)
        DateComboBox.Name = "DateComboBox"
        DateComboBox.Size = New Size(193, 33)
        DateComboBox.TabIndex = 8
        ' 
        ' StatusLbl
        ' 
        StatusLbl.AutoSize = True
        StatusLbl.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        StatusLbl.ForeColor = Color.Black
        StatusLbl.Location = New Point(479, 67)
        StatusLbl.Name = "StatusLbl"
        StatusLbl.Size = New Size(55, 21)
        StatusLbl.TabIndex = 7
        StatusLbl.Text = "Status"
        ' 
        ' ServiceLbl
        ' 
        ServiceLbl.AutoSize = True
        ServiceLbl.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ServiceLbl.ForeColor = Color.Black
        ServiceLbl.Location = New Point(250, 67)
        ServiceLbl.Name = "ServiceLbl"
        ServiceLbl.Size = New Size(64, 21)
        ServiceLbl.TabIndex = 6
        ServiceLbl.Text = "Service"
        ' 
        ' DateRangeLbl
        ' 
        DateRangeLbl.AutoSize = True
        DateRangeLbl.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DateRangeLbl.ForeColor = Color.Black
        DateRangeLbl.Location = New Point(22, 67)
        DateRangeLbl.Name = "DateRangeLbl"
        DateRangeLbl.Size = New Size(94, 21)
        DateRangeLbl.TabIndex = 5
        DateRangeLbl.Text = "Date Range"
        ' 
        ' FilterLbl
        ' 
        FilterLbl.AutoSize = True
        FilterLbl.Font = New Font("Verdana", 12F)
        FilterLbl.Location = New Point(51, 16)
        FilterLbl.Name = "FilterLbl"
        FilterLbl.Size = New Size(59, 18)
        FilterLbl.TabIndex = 1
        FilterLbl.Text = "Filters"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(25, 14)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(20, 20)
        PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' PanelRound2
        ' 
        PanelRound2.BackColor = Color.White
        PanelRound2.Controls.Add(btnInstallationPrevious)
        PanelRound2.Controls.Add(btnNextInstallationSA)
        PanelRound2.Controls.Add(LblPageInfo)
        PanelRound2.Controls.Add(lblHistoryDetails)
        PanelRound2.Controls.Add(HistoryTable)
        PanelRound2.Location = New Point(39, 233)
        PanelRound2.Name = "PanelRound2"
        PanelRound2.Size = New Size(1562, 801)
        PanelRound2.TabIndex = 11
        ' 
        ' btnInstallationPrevious
        ' 
        btnInstallationPrevious.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnInstallationPrevious.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnInstallationPrevious.ForeColor = Color.White
        btnInstallationPrevious.Location = New Point(1327, 770)
        btnInstallationPrevious.Name = "btnInstallationPrevious"
        btnInstallationPrevious.Size = New Size(75, 23)
        btnInstallationPrevious.TabIndex = 41
        btnInstallationPrevious.Text = "Previous"
        btnInstallationPrevious.UseVisualStyleBackColor = False
        btnInstallationPrevious.Visible = False
        ' 
        ' btnNextInstallationSA
        ' 
        btnNextInstallationSA.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnNextInstallationSA.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnNextInstallationSA.ForeColor = Color.White
        btnNextInstallationSA.Location = New Point(1408, 770)
        btnNextInstallationSA.Name = "btnNextInstallationSA"
        btnNextInstallationSA.Size = New Size(75, 23)
        btnNextInstallationSA.TabIndex = 40
        btnNextInstallationSA.Text = "Next"
        btnNextInstallationSA.UseVisualStyleBackColor = False
        ' 
        ' LblPageInfo
        ' 
        LblPageInfo.AutoSize = True
        LblPageInfo.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblPageInfo.ImageAlign = ContentAlignment.MiddleLeft
        LblPageInfo.Location = New Point(24, 774)
        LblPageInfo.Name = "LblPageInfo"
        LblPageInfo.Size = New Size(18, 18)
        LblPageInfo.TabIndex = 39
        LblPageInfo.Text = "0"
        ' 
        ' lblHistoryDetails
        ' 
        lblHistoryDetails.AutoSize = True
        lblHistoryDetails.Font = New Font("Verdana", 12F)
        lblHistoryDetails.ForeColor = SystemColors.ControlText
        lblHistoryDetails.Location = New Point(25, 15)
        lblHistoryDetails.Name = "lblHistoryDetails"
        lblHistoryDetails.Size = New Size(130, 18)
        lblHistoryDetails.TabIndex = 2
        lblHistoryDetails.Text = "History Details"
        ' 
        ' HistoryTable
        ' 
        HistoryTable.AllowUserToAddRows = False
        HistoryTable.AllowUserToDeleteRows = False
        HistoryTable.AllowUserToResizeColumns = False
        HistoryTable.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(250), CByte(250), CByte(250))
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        HistoryTable.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        HistoryTable.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        HistoryTable.BackgroundColor = Color.White
        HistoryTable.BorderStyle = BorderStyle.None
        HistoryTable.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        HistoryTable.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(248), CByte(248), CByte(248))
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        HistoryTable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        HistoryTable.ColumnHeadersHeight = 45
        HistoryTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        HistoryTable.Columns.AddRange(New DataGridViewColumn() {DateColumn, TransactionColumn, ServiceIDColumn, StartDateColumn, EndDateColumn, MonthlyRateColumn, PaymentMethodColumn, StatusColumn})
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(230), CByte(240), CByte(255))
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        HistoryTable.DefaultCellStyle = DataGridViewCellStyle3
        HistoryTable.EnableHeadersVisualStyles = False
        HistoryTable.GridColor = Color.White
        HistoryTable.Location = New Point(20, 53)
        HistoryTable.Margin = New Padding(3, 2, 3, 2)
        HistoryTable.Name = "HistoryTable"
        HistoryTable.ReadOnly = True
        HistoryTable.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = SystemColors.Control
        DataGridViewCellStyle4.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle4.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True
        HistoryTable.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        HistoryTable.RowHeadersVisible = False
        HistoryTable.RowHeadersWidth = 51
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.True
        HistoryTable.RowsDefaultCellStyle = DataGridViewCellStyle5
        HistoryTable.ScrollBars = ScrollBars.Vertical
        HistoryTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        HistoryTable.Size = New Size(1463, 702)
        HistoryTable.TabIndex = 23
        ' 
        ' DateColumn
        ' 
        DateColumn.DataPropertyName = "DateColumn"
        DateColumn.Frozen = True
        DateColumn.HeaderText = "Date"
        DateColumn.Name = "DateColumn"
        DateColumn.ReadOnly = True
        DateColumn.Resizable = DataGridViewTriState.False
        DateColumn.Width = 150
        ' 
        ' TransactionColumn
        ' 
        TransactionColumn.DataPropertyName = "TransactionColumn"
        TransactionColumn.HeaderText = "Transaction Type"
        TransactionColumn.Name = "TransactionColumn"
        TransactionColumn.ReadOnly = True
        TransactionColumn.Resizable = DataGridViewTriState.False
        TransactionColumn.Width = 200
        ' 
        ' ServiceIDColumn
        ' 
        ServiceIDColumn.DataPropertyName = "ServiceIDColumn"
        ServiceIDColumn.HeaderText = "Service ID"
        ServiceIDColumn.Name = "ServiceIDColumn"
        ServiceIDColumn.ReadOnly = True
        ServiceIDColumn.Resizable = DataGridViewTriState.False
        ServiceIDColumn.Width = 150
        ' 
        ' StartDateColumn
        ' 
        StartDateColumn.DataPropertyName = "StartDateColumn"
        StartDateColumn.HeaderText = "Start Date"
        StartDateColumn.Name = "StartDateColumn"
        StartDateColumn.ReadOnly = True
        StartDateColumn.Resizable = DataGridViewTriState.False
        StartDateColumn.Width = 150
        ' 
        ' EndDateColumn
        ' 
        EndDateColumn.DataPropertyName = "EndDateColumn"
        EndDateColumn.HeaderText = "End Date"
        EndDateColumn.Name = "EndDateColumn"
        EndDateColumn.ReadOnly = True
        EndDateColumn.Resizable = DataGridViewTriState.False
        EndDateColumn.Width = 150
        ' 
        ' MonthlyRateColumn
        ' 
        MonthlyRateColumn.DataPropertyName = "MonthlyRateColumn"
        MonthlyRateColumn.HeaderText = "Monthly Rate"
        MonthlyRateColumn.Name = "MonthlyRateColumn"
        MonthlyRateColumn.ReadOnly = True
        MonthlyRateColumn.Resizable = DataGridViewTriState.False
        MonthlyRateColumn.Width = 160
        ' 
        ' PaymentMethodColumn
        ' 
        PaymentMethodColumn.DataPropertyName = "PaymentMethodColumn"
        PaymentMethodColumn.HeaderText = "Payment Method"
        PaymentMethodColumn.Name = "PaymentMethodColumn"
        PaymentMethodColumn.ReadOnly = True
        PaymentMethodColumn.Resizable = DataGridViewTriState.False
        PaymentMethodColumn.Width = 200
        ' 
        ' StatusColumn
        ' 
        StatusColumn.DataPropertyName = "StatusColumn"
        StatusColumn.HeaderText = "Status"
        StatusColumn.Name = "StatusColumn"
        StatusColumn.ReadOnly = True
        StatusColumn.Resizable = DataGridViewTriState.False
        StatusColumn.Width = 200
        ' 
        ' History
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        Controls.Add(Panel2)
        Name = "History"
        Size = New Size(1980, 1906)
        Panel2.ResumeLayout(False)
        FilterPanel.ResumeLayout(False)
        FilterPanel.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        PanelRound2.ResumeLayout(False)
        PanelRound2.PerformLayout()
        CType(HistoryTable, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents FilterPanel As PanelRound
    Friend WithEvents FilterPanel_Paint As PanelRound
    Friend WithEvents FilterLbl As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents DateRangeLbl As Label
    Friend WithEvents StatusLbl As Label
    Friend WithEvents ServiceLbl As Label
    Friend WithEvents StatusComboBox As ComboBox
    Friend WithEvents ServiceComboBox As ComboBox
    Friend WithEvents DateComboBox As ComboBox
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents PanelRound2 As PanelRound
    Friend WithEvents HistoryTable As DataGridView
    Friend WithEvents lblHistoryDetails As Label
    Friend WithEvents DateColumn As DataGridViewTextBoxColumn
    Friend WithEvents TransactionColumn As DataGridViewTextBoxColumn
    Friend WithEvents ServiceIDColumn As DataGridViewTextBoxColumn
    Friend WithEvents StartDateColumn As DataGridViewTextBoxColumn
    Friend WithEvents EndDateColumn As DataGridViewTextBoxColumn
    Friend WithEvents MonthlyRateColumn As DataGridViewTextBoxColumn
    Friend WithEvents PaymentMethodColumn As DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As DataGridViewTextBoxColumn
    Friend WithEvents LblPageInfo As Label
    Friend WithEvents btnInstallationPrevious As Button
    Friend WithEvents btnNextInstallationSA As Button

End Class