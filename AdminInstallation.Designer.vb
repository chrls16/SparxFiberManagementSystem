<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminInstallation
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdminInstallation))
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
        Pending = New Label()
        PnlInProgress = New PanelRound()
        PercentInProgress = New Label()
        InProgress = New Label()
        PictureBox4 = New PictureBox()
        PnlCompleted = New PanelRound()
        PercentComplete = New Label()
        Completed = New Label()
        PictureBox6 = New PictureBox()
        DataGridInstallationDetails = New DataGridView()
        ServiceID = New DataGridViewTextBoxColumn()
        Customer = New DataGridViewTextBoxColumn()
        ContactNo = New DataGridViewTextBoxColumn()
        DateRequested = New DataGridViewTextBoxColumn()
        Technician = New DataGridViewTextBoxColumn()
        Address = New DataGridViewTextBoxColumn()
        Status = New DataGridViewTextBoxColumn()
        EditIcon = New DataGridViewImageColumn()
        DeleteIcon = New DataGridViewImageColumn()
        checkbox = New DataGridViewCheckBoxColumn()
        txtInstallationSearchSA = New TextBox()
        ResourceLoaderBindingSource = New BindingSource(components)
        PanelInstallationDetails = New PanelRound()
        deleteAll = New PictureBox()
        LblPageInfo = New Label()
        btnSelectInstallation = New PictureBox()
        btnInstallationPrevious = New Button()
        btnNextInstallationSA = New Button()
        LabelInstallationDetails = New Label()
        PanelRound1 = New PanelRound()
        ComboBox3 = New ComboBox()
        ComboBox1 = New ComboBox()
        LabelStatus = New Label()
        LabelDateRange = New Label()
        LabelFilters = New Label()
        IconFilter = New PictureBox()
        HeaderInstallationReport = New Label()
        PanelTotalInstallations = New PanelRound()
        IconTotalInstallations = New PictureBox()
        NumTotalInstallations = New Label()
        LabelTotalInstallations = New Label()
        PanelCompleted = New PanelRound()
        IconComplete = New PictureBox()
        NumCompleted = New Label()
        LabelCompleted = New Label()
        PnlPending = New PanelRound()
        PercentRequested = New Label()
        PictureBox5 = New PictureBox()
        PanelInProgress = New PanelRound()
        IconInProgress = New PictureBox()
        NumInProgress = New Label()
        LabelInProgress = New Label()
        PanelPending = New PanelRound()
        IconPending = New PictureBox()
        NumPending = New Label()
        LabelRequested = New Label()
        PanelSubscribersPlan = New PanelRound()
        Panel1 = New Panel()
        LabelInstallationStatusDistribution = New Label()
        Panel4 = New Panel()
        PnlInProgress.SuspendLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        PnlCompleted.SuspendLayout()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridInstallationDetails, ComponentModel.ISupportInitialize).BeginInit()
        CType(ResourceLoaderBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        PanelInstallationDetails.SuspendLayout()
        CType(deleteAll, ComponentModel.ISupportInitialize).BeginInit()
        CType(btnSelectInstallation, ComponentModel.ISupportInitialize).BeginInit()
        PanelRound1.SuspendLayout()
        CType(IconFilter, ComponentModel.ISupportInitialize).BeginInit()
        PanelTotalInstallations.SuspendLayout()
        CType(IconTotalInstallations, ComponentModel.ISupportInitialize).BeginInit()
        PanelCompleted.SuspendLayout()
        CType(IconComplete, ComponentModel.ISupportInitialize).BeginInit()
        PnlPending.SuspendLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        PanelInProgress.SuspendLayout()
        CType(IconInProgress, ComponentModel.ISupportInitialize).BeginInit()
        PanelPending.SuspendLayout()
        CType(IconPending, ComponentModel.ISupportInitialize).BeginInit()
        PanelSubscribersPlan.SuspendLayout()
        SuspendLayout()
        ' 
        ' Pending
        ' 
        Pending.Anchor = AnchorStyles.Top
        Pending.AutoSize = True
        Pending.Font = New Font("Segoe UI", 11F)
        Pending.ForeColor = Color.FromArgb(CByte(54), CByte(65), CByte(83))
        Pending.Location = New Point(53, 28)
        Pending.Name = "Pending"
        Pending.Size = New Size(79, 20)
        Pending.TabIndex = 21
        Pending.Text = "Requested"
        ' 
        ' PnlInProgress
        ' 
        PnlInProgress.Anchor = AnchorStyles.Top
        PnlInProgress.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(251))
        PnlInProgress.Controls.Add(PercentInProgress)
        PnlInProgress.Controls.Add(InProgress)
        PnlInProgress.Controls.Add(PictureBox4)
        PnlInProgress.CornerRadius = 12
        PnlInProgress.ForeColor = SystemColors.ControlText
        PnlInProgress.Location = New Point(703, 236)
        PnlInProgress.Name = "PnlInProgress"
        PnlInProgress.Size = New Size(861, 74)
        PnlInProgress.TabIndex = 13
        ' 
        ' PercentInProgress
        ' 
        PercentInProgress.Anchor = AnchorStyles.Top
        PercentInProgress.AutoSize = True
        PercentInProgress.Font = New Font("Segoe UI Semibold", 12F)
        PercentInProgress.ForeColor = Color.Black
        PercentInProgress.Location = New Point(786, 31)
        PercentInProgress.Name = "PercentInProgress"
        PercentInProgress.Size = New Size(41, 21)
        PercentInProgress.TabIndex = 27
        PercentInProgress.Text = "00%"
        ' 
        ' InProgress
        ' 
        InProgress.Anchor = AnchorStyles.Top
        InProgress.AutoSize = True
        InProgress.Font = New Font("Segoe UI", 11F)
        InProgress.ForeColor = Color.FromArgb(CByte(54), CByte(65), CByte(83))
        InProgress.Location = New Point(51, 27)
        InProgress.Name = "InProgress"
        InProgress.Size = New Size(81, 20)
        InProgress.TabIndex = 22
        InProgress.Text = "In Progress"
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Anchor = AnchorStyles.Top
        PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), Image)
        PictureBox4.Location = New Point(33, 31)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(12, 12)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 20
        PictureBox4.TabStop = False
        ' 
        ' PnlCompleted
        ' 
        PnlCompleted.Anchor = AnchorStyles.Top
        PnlCompleted.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(251))
        PnlCompleted.Controls.Add(PercentComplete)
        PnlCompleted.Controls.Add(Completed)
        PnlCompleted.Controls.Add(PictureBox6)
        PnlCompleted.CornerRadius = 12
        PnlCompleted.ForeColor = SystemColors.ControlText
        PnlCompleted.Location = New Point(703, 139)
        PnlCompleted.Name = "PnlCompleted"
        PnlCompleted.Size = New Size(861, 74)
        PnlCompleted.TabIndex = 12
        ' 
        ' PercentComplete
        ' 
        PercentComplete.Anchor = AnchorStyles.Top
        PercentComplete.AutoSize = True
        PercentComplete.Font = New Font("Segoe UI Semibold", 12F)
        PercentComplete.ForeColor = Color.Black
        PercentComplete.Location = New Point(786, 27)
        PercentComplete.Name = "PercentComplete"
        PercentComplete.Size = New Size(41, 21)
        PercentComplete.TabIndex = 23
        PercentComplete.Text = "00%"
        ' 
        ' Completed
        ' 
        Completed.Anchor = AnchorStyles.Top
        Completed.AutoSize = True
        Completed.Font = New Font("Segoe UI", 11F)
        Completed.ForeColor = Color.FromArgb(CByte(54), CByte(65), CByte(83))
        Completed.Location = New Point(51, 27)
        Completed.Name = "Completed"
        Completed.Size = New Size(83, 20)
        Completed.TabIndex = 20
        Completed.Text = "Completed"
        ' 
        ' PictureBox6
        ' 
        PictureBox6.Anchor = AnchorStyles.Top
        PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), Image)
        PictureBox6.Location = New Point(33, 31)
        PictureBox6.Name = "PictureBox6"
        PictureBox6.Size = New Size(12, 12)
        PictureBox6.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox6.TabIndex = 21
        PictureBox6.TabStop = False
        ' 
        ' DataGridInstallationDetails
        ' 
        DataGridInstallationDetails.AllowUserToAddRows = False
        DataGridInstallationDetails.AllowUserToDeleteRows = False
        DataGridInstallationDetails.AllowUserToResizeColumns = False
        DataGridInstallationDetails.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(250), CByte(250), CByte(250))
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridInstallationDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridInstallationDetails.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridInstallationDetails.BackgroundColor = Color.White
        DataGridInstallationDetails.BorderStyle = BorderStyle.None
        DataGridInstallationDetails.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridInstallationDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Verdana", 10F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(248), CByte(248), CByte(248))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        DataGridInstallationDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridInstallationDetails.ColumnHeadersHeight = 45
        DataGridInstallationDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridInstallationDetails.Columns.AddRange(New DataGridViewColumn() {ServiceID, Customer, ContactNo, DateRequested, Technician, Address, Status, EditIcon, DeleteIcon, checkbox})
        DataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = Color.White
        DataGridViewCellStyle10.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle10.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        DataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(CByte(230), CByte(240), CByte(255))
        DataGridViewCellStyle10.SelectionForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        DataGridViewCellStyle10.WrapMode = DataGridViewTriState.True
        DataGridInstallationDetails.DefaultCellStyle = DataGridViewCellStyle10
        DataGridInstallationDetails.EnableHeadersVisualStyles = False
        DataGridInstallationDetails.GridColor = Color.White
        DataGridInstallationDetails.Location = New Point(25, 48)
        DataGridInstallationDetails.Margin = New Padding(3, 2, 3, 2)
        DataGridInstallationDetails.Name = "DataGridInstallationDetails"
        DataGridInstallationDetails.ReadOnly = True
        DataGridInstallationDetails.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridInstallationDetails.RowHeadersVisible = False
        DataGridInstallationDetails.RowHeadersWidth = 51
        DataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle11.ForeColor = Color.Black
        DataGridViewCellStyle11.WrapMode = DataGridViewTriState.True
        DataGridInstallationDetails.RowsDefaultCellStyle = DataGridViewCellStyle11
        DataGridInstallationDetails.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridInstallationDetails.RowTemplate.DefaultCellStyle.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridInstallationDetails.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridInstallationDetails.RowTemplate.Height = 45
        DataGridInstallationDetails.ScrollBars = ScrollBars.Vertical
        DataGridInstallationDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridInstallationDetails.Size = New Size(1553, 413)
        DataGridInstallationDetails.TabIndex = 23
        ' 
        ' ServiceID
        ' 
        ServiceID.DataPropertyName = "ServiceID"
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = Color.Black
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        ServiceID.DefaultCellStyle = DataGridViewCellStyle3
        ServiceID.HeaderText = "Service ID"
        ServiceID.Name = "ServiceID"
        ServiceID.ReadOnly = True
        ServiceID.Resizable = DataGridViewTriState.False
        ServiceID.Width = 146
        ' 
        ' Customer
        ' 
        Customer.DataPropertyName = "Customer"
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle4.ForeColor = Color.Black
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True
        Customer.DefaultCellStyle = DataGridViewCellStyle4
        Customer.HeaderText = "Customer Name"
        Customer.Name = "Customer"
        Customer.ReadOnly = True
        Customer.Resizable = DataGridViewTriState.False
        Customer.Width = 200
        ' 
        ' ContactNo
        ' 
        ContactNo.DataPropertyName = "ContactNo"
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle5.ForeColor = Color.Black
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.True
        ContactNo.DefaultCellStyle = DataGridViewCellStyle5
        ContactNo.HeaderText = "Contact No."
        ContactNo.Name = "ContactNo"
        ContactNo.ReadOnly = True
        ContactNo.Resizable = DataGridViewTriState.False
        ContactNo.Width = 160
        ' 
        ' DateRequested
        ' 
        DateRequested.DataPropertyName = "DateRequested"
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle6.ForeColor = Color.Black
        DataGridViewCellStyle6.Format = "d"
        DataGridViewCellStyle6.NullValue = Nothing
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.True
        DateRequested.DefaultCellStyle = DataGridViewCellStyle6
        DateRequested.HeaderText = "Date Requested"
        DateRequested.Name = "DateRequested"
        DateRequested.ReadOnly = True
        DateRequested.Resizable = DataGridViewTriState.False
        DateRequested.Width = 200
        ' 
        ' Technician
        ' 
        Technician.DataPropertyName = "Technician"
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle7.ForeColor = Color.Black
        DataGridViewCellStyle7.WrapMode = DataGridViewTriState.True
        Technician.DefaultCellStyle = DataGridViewCellStyle7
        Technician.HeaderText = "Technician"
        Technician.Name = "Technician"
        Technician.ReadOnly = True
        Technician.Resizable = DataGridViewTriState.False
        Technician.Width = 200
        ' 
        ' Address
        ' 
        Address.DataPropertyName = "Address"
        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = Color.White
        DataGridViewCellStyle8.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle8.ForeColor = Color.Black
        DataGridViewCellStyle8.WrapMode = DataGridViewTriState.True
        Address.DefaultCellStyle = DataGridViewCellStyle8
        Address.HeaderText = "Address"
        Address.Name = "Address"
        Address.ReadOnly = True
        Address.Resizable = DataGridViewTriState.False
        Address.Width = 360
        ' 
        ' Status
        ' 
        Status.DataPropertyName = "Status"
        DataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle9.ForeColor = Color.Black
        DataGridViewCellStyle9.WrapMode = DataGridViewTriState.True
        Status.DefaultCellStyle = DataGridViewCellStyle9
        Status.HeaderText = "Status"
        Status.Name = "Status"
        Status.ReadOnly = True
        Status.Resizable = DataGridViewTriState.False
        Status.Width = 156
        ' 
        ' EditIcon
        ' 
        EditIcon.HeaderText = ""
        EditIcon.Image = My.Resources.Resources.edit
        EditIcon.Name = "EditIcon"
        EditIcon.ReadOnly = True
        EditIcon.Width = 40
        ' 
        ' DeleteIcon
        ' 
        DeleteIcon.HeaderText = ""
        DeleteIcon.Image = My.Resources.Resources.delete1
        DeleteIcon.Name = "DeleteIcon"
        DeleteIcon.ReadOnly = True
        DeleteIcon.Width = 40
        ' 
        ' checkbox
        ' 
        checkbox.HeaderText = ""
        checkbox.Name = "checkbox"
        checkbox.ReadOnly = True
        checkbox.Width = 40
        ' 
        ' txtInstallationSearchSA
        ' 
        txtInstallationSearchSA.Font = New Font("Segoe UI", 12F)
        txtInstallationSearchSA.Location = New Point(1241, 14)
        txtInstallationSearchSA.Name = "txtInstallationSearchSA"
        txtInstallationSearchSA.PlaceholderText = "Search..."
        txtInstallationSearchSA.Size = New Size(259, 29)
        txtInstallationSearchSA.TabIndex = 25
        ' 
        ' ResourceLoaderBindingSource
        ' 
        ResourceLoaderBindingSource.DataSource = GetType(ResourceLoader)
        ' 
        ' PanelInstallationDetails
        ' 
        PanelInstallationDetails.AutoScroll = True
        PanelInstallationDetails.BackColor = Color.White
        PanelInstallationDetails.Controls.Add(deleteAll)
        PanelInstallationDetails.Controls.Add(LblPageInfo)
        PanelInstallationDetails.Controls.Add(btnSelectInstallation)
        PanelInstallationDetails.Controls.Add(btnInstallationPrevious)
        PanelInstallationDetails.Controls.Add(btnNextInstallationSA)
        PanelInstallationDetails.Controls.Add(txtInstallationSearchSA)
        PanelInstallationDetails.Controls.Add(LabelInstallationDetails)
        PanelInstallationDetails.Controls.Add(DataGridInstallationDetails)
        PanelInstallationDetails.CornerRadius = 12
        PanelInstallationDetails.Location = New Point(34, 956)
        PanelInstallationDetails.Name = "PanelInstallationDetails"
        PanelInstallationDetails.Size = New Size(1595, 504)
        PanelInstallationDetails.TabIndex = 25
        ' 
        ' deleteAll
        ' 
        deleteAll.Image = My.Resources.Resources.delete2
        deleteAll.Location = New Point(1534, 24)
        deleteAll.Name = "deleteAll"
        deleteAll.Size = New Size(27, 18)
        deleteAll.SizeMode = PictureBoxSizeMode.Zoom
        deleteAll.TabIndex = 39
        deleteAll.TabStop = False
        ' 
        ' LblPageInfo
        ' 
        LblPageInfo.AutoSize = True
        LblPageInfo.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblPageInfo.ImageAlign = ContentAlignment.MiddleLeft
        LblPageInfo.Location = New Point(23, 468)
        LblPageInfo.Name = "LblPageInfo"
        LblPageInfo.Size = New Size(18, 18)
        LblPageInfo.TabIndex = 38
        LblPageInfo.Text = "0"
        ' 
        ' btnSelectInstallation
        ' 
        btnSelectInstallation.Image = My.Resources.Resources.selectall
        btnSelectInstallation.Location = New Point(1512, 25)
        btnSelectInstallation.Name = "btnSelectInstallation"
        btnSelectInstallation.Size = New Size(16, 16)
        btnSelectInstallation.SizeMode = PictureBoxSizeMode.AutoSize
        btnSelectInstallation.TabIndex = 29
        btnSelectInstallation.TabStop = False
        ' 
        ' btnInstallationPrevious
        ' 
        btnInstallationPrevious.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnInstallationPrevious.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnInstallationPrevious.ForeColor = Color.White
        btnInstallationPrevious.Location = New Point(1411, 466)
        btnInstallationPrevious.Name = "btnInstallationPrevious"
        btnInstallationPrevious.Size = New Size(75, 23)
        btnInstallationPrevious.TabIndex = 27
        btnInstallationPrevious.Text = "Previous"
        btnInstallationPrevious.UseVisualStyleBackColor = False
        btnInstallationPrevious.Visible = False
        ' 
        ' btnNextInstallationSA
        ' 
        btnNextInstallationSA.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnNextInstallationSA.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnNextInstallationSA.ForeColor = Color.White
        btnNextInstallationSA.Location = New Point(1492, 466)
        btnNextInstallationSA.Name = "btnNextInstallationSA"
        btnNextInstallationSA.Size = New Size(75, 23)
        btnNextInstallationSA.TabIndex = 26
        btnNextInstallationSA.Text = "Next"
        btnNextInstallationSA.UseVisualStyleBackColor = False
        ' 
        ' LabelInstallationDetails
        ' 
        LabelInstallationDetails.AutoSize = True
        LabelInstallationDetails.Font = New Font("Verdana", 12F)
        LabelInstallationDetails.ForeColor = SystemColors.ControlDarkDark
        LabelInstallationDetails.Location = New Point(24, 25)
        LabelInstallationDetails.Name = "LabelInstallationDetails"
        LabelInstallationDetails.Size = New Size(167, 18)
        LabelInstallationDetails.TabIndex = 24
        LabelInstallationDetails.Text = "Installation Details"
        ' 
        ' PanelRound1
        ' 
        PanelRound1.Anchor = AnchorStyles.Top
        PanelRound1.BackColor = Color.White
        PanelRound1.Controls.Add(ComboBox3)
        PanelRound1.Controls.Add(ComboBox1)
        PanelRound1.Controls.Add(LabelStatus)
        PanelRound1.Controls.Add(LabelDateRange)
        PanelRound1.Controls.Add(LabelFilters)
        PanelRound1.Controls.Add(IconFilter)
        PanelRound1.CornerRadius = 12
        PanelRound1.Location = New Point(91, 63)
        PanelRound1.Name = "PanelRound1"
        PanelRound1.Size = New Size(1595, 165)
        PanelRound1.TabIndex = 19
        ' 
        ' ComboBox3
        ' 
        ComboBox3.BackColor = SystemColors.ButtonFace
        ComboBox3.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox3.Font = New Font("Segoe UI", 14F)
        ComboBox3.ForeColor = SystemColors.WindowText
        ComboBox3.FormattingEnabled = True
        ComboBox3.Items.AddRange(New Object() {"All Status", "Completed", "In Progress", "Requested"})
        ComboBox3.Location = New Point(243, 104)
        ComboBox3.MinimumSize = New Size(193, 0)
        ComboBox3.Name = "ComboBox3"
        ComboBox3.Size = New Size(193, 33)
        ComboBox3.TabIndex = 7
        ' 
        ' ComboBox1
        ' 
        ComboBox1.BackColor = SystemColors.ButtonFace
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.Font = New Font("Segoe UI", 14F)
        ComboBox1.ForeColor = SystemColors.WindowText
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"All Times", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        ComboBox1.Location = New Point(24, 104)
        ComboBox1.MinimumSize = New Size(193, 0)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(193, 33)
        ComboBox1.TabIndex = 5
        ' 
        ' LabelStatus
        ' 
        LabelStatus.AutoSize = True
        LabelStatus.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        LabelStatus.Location = New Point(243, 80)
        LabelStatus.Name = "LabelStatus"
        LabelStatus.Size = New Size(55, 21)
        LabelStatus.TabIndex = 4
        LabelStatus.Text = "Status"
        ' 
        ' LabelDateRange
        ' 
        LabelDateRange.AutoSize = True
        LabelDateRange.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        LabelDateRange.Location = New Point(22, 80)
        LabelDateRange.Name = "LabelDateRange"
        LabelDateRange.Size = New Size(94, 21)
        LabelDateRange.TabIndex = 2
        LabelDateRange.Text = "Date Range"
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
        ' HeaderInstallationReport
        ' 
        HeaderInstallationReport.AutoSize = True
        HeaderInstallationReport.Font = New Font("Segoe UI Semibold", 15F, FontStyle.Bold)
        HeaderInstallationReport.Location = New Point(19, 20)
        HeaderInstallationReport.Name = "HeaderInstallationReport"
        HeaderInstallationReport.Size = New Size(179, 28)
        HeaderInstallationReport.TabIndex = 18
        HeaderInstallationReport.Text = "Installation Report"
        ' 
        ' PanelTotalInstallations
        ' 
        PanelTotalInstallations.BackColor = Color.White
        PanelTotalInstallations.Controls.Add(IconTotalInstallations)
        PanelTotalInstallations.Controls.Add(NumTotalInstallations)
        PanelTotalInstallations.Controls.Add(LabelTotalInstallations)
        PanelTotalInstallations.CornerRadius = 12
        PanelTotalInstallations.Location = New Point(31, 258)
        PanelTotalInstallations.Name = "PanelTotalInstallations"
        PanelTotalInstallations.Size = New Size(367, 115)
        PanelTotalInstallations.TabIndex = 21
        ' 
        ' IconTotalInstallations
        ' 
        IconTotalInstallations.Image = CType(resources.GetObject("IconTotalInstallations.Image"), Image)
        IconTotalInstallations.Location = New Point(286, 36)
        IconTotalInstallations.Name = "IconTotalInstallations"
        IconTotalInstallations.Size = New Size(48, 50)
        IconTotalInstallations.SizeMode = PictureBoxSizeMode.Zoom
        IconTotalInstallations.TabIndex = 9
        IconTotalInstallations.TabStop = False
        ' 
        ' NumTotalInstallations
        ' 
        NumTotalInstallations.AutoSize = True
        NumTotalInstallations.Font = New Font("Segoe UI Semibold", 16F, FontStyle.Bold)
        NumTotalInstallations.Location = New Point(24, 66)
        NumTotalInstallations.Name = "NumTotalInstallations"
        NumTotalInstallations.Size = New Size(37, 30)
        NumTotalInstallations.TabIndex = 8
        NumTotalInstallations.Text = "00"
        ' 
        ' LabelTotalInstallations
        ' 
        LabelTotalInstallations.AutoSize = True
        LabelTotalInstallations.Font = New Font("Verdana", 12F)
        LabelTotalInstallations.ForeColor = SystemColors.ControlDarkDark
        LabelTotalInstallations.Location = New Point(24, 25)
        LabelTotalInstallations.Name = "LabelTotalInstallations"
        LabelTotalInstallations.Size = New Size(158, 18)
        LabelTotalInstallations.TabIndex = 8
        LabelTotalInstallations.Text = "Total Installations"
        ' 
        ' PanelCompleted
        ' 
        PanelCompleted.BackColor = Color.White
        PanelCompleted.Controls.Add(IconComplete)
        PanelCompleted.Controls.Add(NumCompleted)
        PanelCompleted.Controls.Add(LabelCompleted)
        PanelCompleted.CornerRadius = 12
        PanelCompleted.Location = New Point(443, 258)
        PanelCompleted.Name = "PanelCompleted"
        PanelCompleted.Size = New Size(367, 115)
        PanelCompleted.TabIndex = 22
        ' 
        ' IconComplete
        ' 
        IconComplete.Image = CType(resources.GetObject("IconComplete.Image"), Image)
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
        ' PnlPending
        ' 
        PnlPending.Anchor = AnchorStyles.Top
        PnlPending.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(251))
        PnlPending.Controls.Add(PercentRequested)
        PnlPending.Controls.Add(Pending)
        PnlPending.Controls.Add(PictureBox5)
        PnlPending.CornerRadius = 12
        PnlPending.ForeColor = SystemColors.ControlText
        PnlPending.Location = New Point(703, 332)
        PnlPending.Name = "PnlPending"
        PnlPending.Size = New Size(861, 74)
        PnlPending.TabIndex = 14
        ' 
        ' PercentRequested
        ' 
        PercentRequested.Anchor = AnchorStyles.Top
        PercentRequested.AutoSize = True
        PercentRequested.Font = New Font("Segoe UI Semibold", 12F)
        PercentRequested.ForeColor = Color.Black
        PercentRequested.Location = New Point(786, 27)
        PercentRequested.Name = "PercentRequested"
        PercentRequested.Size = New Size(41, 21)
        PercentRequested.TabIndex = 27
        PercentRequested.Text = "00%"
        ' 
        ' PictureBox5
        ' 
        PictureBox5.Anchor = AnchorStyles.Top
        PictureBox5.Image = My.Resources.Resources.BlueDot
        PictureBox5.Location = New Point(35, 32)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(12, 12)
        PictureBox5.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox5.TabIndex = 20
        PictureBox5.TabStop = False
        ' 
        ' PanelInProgress
        ' 
        PanelInProgress.BackColor = Color.White
        PanelInProgress.Controls.Add(IconInProgress)
        PanelInProgress.Controls.Add(NumInProgress)
        PanelInProgress.Controls.Add(LabelInProgress)
        PanelInProgress.CornerRadius = 12
        PanelInProgress.Location = New Point(851, 258)
        PanelInProgress.Name = "PanelInProgress"
        PanelInProgress.Size = New Size(367, 115)
        PanelInProgress.TabIndex = 23
        ' 
        ' IconInProgress
        ' 
        IconInProgress.Image = CType(resources.GetObject("IconInProgress.Image"), Image)
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
        ' PanelPending
        ' 
        PanelPending.BackColor = Color.White
        PanelPending.Controls.Add(IconPending)
        PanelPending.Controls.Add(NumPending)
        PanelPending.Controls.Add(LabelRequested)
        PanelPending.CornerRadius = 12
        PanelPending.Location = New Point(1262, 258)
        PanelPending.Name = "PanelPending"
        PanelPending.Size = New Size(367, 115)
        PanelPending.TabIndex = 24
        ' 
        ' IconPending
        ' 
        IconPending.Image = CType(resources.GetObject("IconPending.Image"), Image)
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
        ' PanelSubscribersPlan
        ' 
        PanelSubscribersPlan.Anchor = AnchorStyles.Top
        PanelSubscribersPlan.BackColor = Color.White
        PanelSubscribersPlan.Controls.Add(Panel1)
        PanelSubscribersPlan.Controls.Add(LabelInstallationStatusDistribution)
        PanelSubscribersPlan.Controls.Add(PnlPending)
        PanelSubscribersPlan.Controls.Add(PnlInProgress)
        PanelSubscribersPlan.Controls.Add(PnlCompleted)
        PanelSubscribersPlan.CornerRadius = 12
        PanelSubscribersPlan.Location = New Point(90, 410)
        PanelSubscribersPlan.Name = "PanelSubscribersPlan"
        PanelSubscribersPlan.Size = New Size(1595, 504)
        PanelSubscribersPlan.TabIndex = 20
        ' 
        ' Panel1
        ' 
        Panel1.Location = New Point(24, 47)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(634, 434)
        Panel1.TabIndex = 23
        ' 
        ' LabelInstallationStatusDistribution
        ' 
        LabelInstallationStatusDistribution.AutoSize = True
        LabelInstallationStatusDistribution.Font = New Font("Verdana", 12F)
        LabelInstallationStatusDistribution.ForeColor = SystemColors.ControlDarkDark
        LabelInstallationStatusDistribution.Location = New Point(24, 25)
        LabelInstallationStatusDistribution.Name = "LabelInstallationStatusDistribution"
        LabelInstallationStatusDistribution.Size = New Size(264, 18)
        LabelInstallationStatusDistribution.TabIndex = 10
        LabelInstallationStatusDistribution.Text = "Installation Status Distribution"
        ' 
        ' Panel4
        ' 
        Panel4.Location = New Point(34, 1508)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(1598, 49)
        Panel4.TabIndex = 51
        ' 
        ' AdminInstallation
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ButtonFace
        Controls.Add(Panel4)
        Controls.Add(PanelInstallationDetails)
        Controls.Add(PanelRound1)
        Controls.Add(HeaderInstallationReport)
        Controls.Add(PanelTotalInstallations)
        Controls.Add(PanelCompleted)
        Controls.Add(PanelInProgress)
        Controls.Add(PanelPending)
        Controls.Add(PanelSubscribersPlan)
        Name = "AdminInstallation"
        Size = New Size(1940, 1773)
        PnlInProgress.ResumeLayout(False)
        PnlInProgress.PerformLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        PnlCompleted.ResumeLayout(False)
        PnlCompleted.PerformLayout()
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridInstallationDetails, ComponentModel.ISupportInitialize).EndInit()
        CType(ResourceLoaderBindingSource, ComponentModel.ISupportInitialize).EndInit()
        PanelInstallationDetails.ResumeLayout(False)
        PanelInstallationDetails.PerformLayout()
        CType(deleteAll, ComponentModel.ISupportInitialize).EndInit()
        CType(btnSelectInstallation, ComponentModel.ISupportInitialize).EndInit()
        PanelRound1.ResumeLayout(False)
        PanelRound1.PerformLayout()
        CType(IconFilter, ComponentModel.ISupportInitialize).EndInit()
        PanelTotalInstallations.ResumeLayout(False)
        PanelTotalInstallations.PerformLayout()
        CType(IconTotalInstallations, ComponentModel.ISupportInitialize).EndInit()
        PanelCompleted.ResumeLayout(False)
        PanelCompleted.PerformLayout()
        CType(IconComplete, ComponentModel.ISupportInitialize).EndInit()
        PnlPending.ResumeLayout(False)
        PnlPending.PerformLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        PanelInProgress.ResumeLayout(False)
        PanelInProgress.PerformLayout()
        CType(IconInProgress, ComponentModel.ISupportInitialize).EndInit()
        PanelPending.ResumeLayout(False)
        PanelPending.PerformLayout()
        CType(IconPending, ComponentModel.ISupportInitialize).EndInit()
        PanelSubscribersPlan.ResumeLayout(False)
        PanelSubscribersPlan.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Pending As Label
    Friend WithEvents PnlInProgress As PanelRound
    Friend WithEvents InProgress As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PnlCompleted As PanelRound
    Friend WithEvents Completed As Label
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents DataGridInstallationDetails As DataGridView
    Friend WithEvents ServiceID As DataGridViewTextBoxColumn
    Friend WithEvents Customer As DataGridViewTextBoxColumn
    Friend WithEvents ContactNo As DataGridViewTextBoxColumn
    Friend WithEvents DateRequested As DataGridViewTextBoxColumn
    Friend WithEvents Technician As DataGridViewTextBoxColumn
    Friend WithEvents Address As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents EditIcon As DataGridViewImageColumn
    Friend WithEvents DeleteIcon As DataGridViewImageColumn
    Friend WithEvents checkbox As DataGridViewCheckBoxColumn
    Friend WithEvents txtInstallationSearchSA As TextBox
    Friend WithEvents ResourceLoaderBindingSource As BindingSource
    Friend WithEvents PanelInstallationDetails As PanelRound
    Friend WithEvents deleteAll As PictureBox
    Friend WithEvents LblPageInfo As Label
    Friend WithEvents btnSelectInstallation As PictureBox
    Friend WithEvents btnInstallationPrevious As Button
    Friend WithEvents btnNextInstallationSA As Button
    Friend WithEvents LabelInstallationDetails As Label
    Friend WithEvents PanelRound1 As PanelRound
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents LabelStatus As Label
    Friend WithEvents LabelDateRange As Label
    Friend WithEvents LabelFilters As Label
    Friend WithEvents IconFilter As PictureBox
    Friend WithEvents HeaderInstallationReport As Label
    Friend WithEvents PanelTotalInstallations As PanelRound
    Friend WithEvents IconTotalInstallations As PictureBox
    Friend WithEvents NumTotalInstallations As Label
    Friend WithEvents LabelTotalInstallations As Label
    Friend WithEvents PanelCompleted As PanelRound
    Friend WithEvents IconComplete As PictureBox
    Friend WithEvents NumCompleted As Label
    Friend WithEvents LabelCompleted As Label
    Friend WithEvents PnlPending As PanelRound
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PanelInProgress As PanelRound
    Friend WithEvents IconInProgress As PictureBox
    Friend WithEvents NumInProgress As Label
    Friend WithEvents LabelInProgress As Label
    Friend WithEvents PanelPending As PanelRound
    Friend WithEvents IconPending As PictureBox
    Friend WithEvents NumPending As Label
    Friend WithEvents LabelRequested As Label
    Friend WithEvents PanelSubscribersPlan As PanelRound
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LabelInstallationStatusDistribution As Label
    Friend WithEvents PercentComplete As Label
    Friend WithEvents PercentInProgress As Label
    Friend WithEvents PercentRequested As Label
    Friend WithEvents Panel4 As Panel

End Class
