<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class staffview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(staffview))
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As DataGridViewCellStyle = New DataGridViewCellStyle()
        LblStaffReport = New Label()
        pnlFilters = New PanelRound()
        cbPosition = New ComboBox()
        pnlTotalStaff = New PanelRound()
        picTotalSubs = New PictureBox()
        totalStaff = New Label()
        LblTotalStaff = New Label()
        lblStaff = New Label()
        LblFilters = New Label()
        PanelRound1 = New PanelRound()
        deleteAll = New PictureBox()
        btnAddStaff = New PictureBox()
        LblPageInfo = New Label()
        btnSelectStaff = New PictureBox()
        btnSubscriberPreviousSA = New Button()
        btnNext = New Button()
        txtStaffSearch = New TextBox()
        DataGridStaffDetails = New DataGridView()
        Label1 = New Label()
        colEmployeeID = New DataGridViewTextBoxColumn()
        colEmployeeName = New DataGridViewTextBoxColumn()
        BirthDate = New DataGridViewTextBoxColumn()
        ContactNumber = New DataGridViewTextBoxColumn()
        colAddress = New DataGridViewTextBoxColumn()
        Username = New DataGridViewTextBoxColumn()
        EmailAddress = New DataGridViewTextBoxColumn()
        colDateHired = New DataGridViewTextBoxColumn()
        colPosition = New DataGridViewTextBoxColumn()
        Department = New DataGridViewTextBoxColumn()
        colDailyRate = New DataGridViewTextBoxColumn()
        colStatus = New DataGridViewTextBoxColumn()
        colEditIcon = New DataGridViewImageColumn()
        colDeleteIcon = New DataGridViewImageColumn()
        colSelect = New DataGridViewCheckBoxColumn()
        pnlFilters.SuspendLayout()
        pnlTotalStaff.SuspendLayout()
        CType(picTotalSubs, ComponentModel.ISupportInitialize).BeginInit()
        PanelRound1.SuspendLayout()
        CType(deleteAll, ComponentModel.ISupportInitialize).BeginInit()
        CType(btnAddStaff, ComponentModel.ISupportInitialize).BeginInit()
        CType(btnSelectStaff, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridStaffDetails, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LblStaffReport
        ' 
        LblStaffReport.AutoSize = True
        LblStaffReport.Font = New Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblStaffReport.Location = New Point(30, 18)
        LblStaffReport.Name = "LblStaffReport"
        LblStaffReport.Size = New Size(120, 28)
        LblStaffReport.TabIndex = 2
        LblStaffReport.Text = "Staff Report"
        ' 
        ' pnlFilters
        ' 
        pnlFilters.BackColor = Color.White
        pnlFilters.Controls.Add(cbPosition)
        pnlFilters.Controls.Add(pnlTotalStaff)
        pnlFilters.Controls.Add(lblStaff)
        pnlFilters.Controls.Add(LblFilters)
        pnlFilters.Location = New Point(30, 72)
        pnlFilters.Margin = New Padding(3, 2, 3, 2)
        pnlFilters.Name = "pnlFilters"
        pnlFilters.Size = New Size(1597, 165)
        pnlFilters.TabIndex = 3
        ' 
        ' cbPosition
        ' 
        cbPosition.BackColor = SystemColors.ButtonFace
        cbPosition.DropDownStyle = ComboBoxStyle.DropDownList
        cbPosition.Font = New Font("Segoe UI", 14F)
        cbPosition.ForeColor = SystemColors.WindowText
        cbPosition.FormattingEnabled = True
        cbPosition.Items.AddRange(New Object() {"All Staff", "Customer Service", "Inventory Staff", "Technician"})
        cbPosition.Location = New Point(29, 91)
        cbPosition.MinimumSize = New Size(193, 0)
        cbPosition.Name = "cbPosition"
        cbPosition.Size = New Size(193, 33)
        cbPosition.TabIndex = 8
        ' 
        ' pnlTotalStaff
        ' 
        pnlTotalStaff.BackColor = Color.White
        pnlTotalStaff.Controls.Add(picTotalSubs)
        pnlTotalStaff.Controls.Add(totalStaff)
        pnlTotalStaff.Controls.Add(LblTotalStaff)
        pnlTotalStaff.Location = New Point(394, 33)
        pnlTotalStaff.Margin = New Padding(3, 2, 3, 2)
        pnlTotalStaff.Name = "pnlTotalStaff"
        pnlTotalStaff.Size = New Size(367, 115)
        pnlTotalStaff.TabIndex = 7
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
        ' totalStaff
        ' 
        totalStaff.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        totalStaff.AutoSize = True
        totalStaff.Font = New Font("Verdana", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        totalStaff.ForeColor = Color.Black
        totalStaff.Location = New Point(29, 54)
        totalStaff.Name = "totalStaff"
        totalStaff.Size = New Size(90, 25)
        totalStaff.TabIndex = 6
        totalStaff.Text = "999999"
        totalStaff.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblTotalStaff
        ' 
        LblTotalStaff.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LblTotalStaff.AutoSize = True
        LblTotalStaff.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblTotalStaff.Location = New Point(26, 14)
        LblTotalStaff.Name = "LblTotalStaff"
        LblTotalStaff.Size = New Size(93, 18)
        LblTotalStaff.TabIndex = 5
        LblTotalStaff.Text = "Total Staff"
        ' 
        ' lblStaff
        ' 
        lblStaff.AutoSize = True
        lblStaff.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        lblStaff.Location = New Point(29, 67)
        lblStaff.Name = "lblStaff"
        lblStaff.Size = New Size(68, 21)
        lblStaff.TabIndex = 7
        lblStaff.Text = "Position"
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
        ' PanelRound1
        ' 
        PanelRound1.BackColor = Color.White
        PanelRound1.Controls.Add(deleteAll)
        PanelRound1.Controls.Add(btnAddStaff)
        PanelRound1.Controls.Add(LblPageInfo)
        PanelRound1.Controls.Add(btnSelectStaff)
        PanelRound1.Controls.Add(btnSubscriberPreviousSA)
        PanelRound1.Controls.Add(btnNext)
        PanelRound1.Controls.Add(txtStaffSearch)
        PanelRound1.Controls.Add(DataGridStaffDetails)
        PanelRound1.Controls.Add(Label1)
        PanelRound1.Location = New Point(30, 271)
        PanelRound1.Margin = New Padding(3, 2, 3, 2)
        PanelRound1.Name = "PanelRound1"
        PanelRound1.Size = New Size(1597, 723)
        PanelRound1.TabIndex = 10
        ' 
        ' deleteAll
        ' 
        deleteAll.Image = My.Resources.Resources.delete2
        deleteAll.Location = New Point(1560, 21)
        deleteAll.Name = "deleteAll"
        deleteAll.Size = New Size(27, 18)
        deleteAll.SizeMode = PictureBoxSizeMode.Zoom
        deleteAll.TabIndex = 41
        deleteAll.TabStop = False
        ' 
        ' btnAddStaff
        ' 
        btnAddStaff.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btnAddStaff.Image = My.Resources.Resources.Add
        btnAddStaff.Location = New Point(1512, 21)
        btnAddStaff.Name = "btnAddStaff"
        btnAddStaff.Size = New Size(19, 19)
        btnAddStaff.SizeMode = PictureBoxSizeMode.AutoSize
        btnAddStaff.TabIndex = 39
        btnAddStaff.TabStop = False
        ' 
        ' LblPageInfo
        ' 
        LblPageInfo.AutoSize = True
        LblPageInfo.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblPageInfo.ImageAlign = ContentAlignment.MiddleLeft
        LblPageInfo.Location = New Point(22, 687)
        LblPageInfo.Name = "LblPageInfo"
        LblPageInfo.Size = New Size(18, 18)
        LblPageInfo.TabIndex = 38
        LblPageInfo.Text = "0"
        ' 
        ' btnSelectStaff
        ' 
        btnSelectStaff.Image = My.Resources.Resources.selectall
        btnSelectStaff.Location = New Point(1539, 22)
        btnSelectStaff.Name = "btnSelectStaff"
        btnSelectStaff.Size = New Size(16, 16)
        btnSelectStaff.SizeMode = PictureBoxSizeMode.AutoSize
        btnSelectStaff.TabIndex = 31
        btnSelectStaff.TabStop = False
        ' 
        ' btnSubscriberPreviousSA
        ' 
        btnSubscriberPreviousSA.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnSubscriberPreviousSA.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSubscriberPreviousSA.ForeColor = Color.White
        btnSubscriberPreviousSA.Location = New Point(1401, 679)
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
        btnNext.Location = New Point(1482, 679)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(75, 23)
        btnNext.TabIndex = 27
        btnNext.Text = "Next"
        btnNext.UseVisualStyleBackColor = False
        ' 
        ' txtStaffSearch
        ' 
        txtStaffSearch.Font = New Font("Segoe UI", 12F)
        txtStaffSearch.Location = New Point(1241, 14)
        txtStaffSearch.Name = "txtStaffSearch"
        txtStaffSearch.PlaceholderText = "Search..."
        txtStaffSearch.Size = New Size(259, 29)
        txtStaffSearch.TabIndex = 26
        ' 
        ' DataGridStaffDetails
        ' 
        DataGridStaffDetails.AllowUserToAddRows = False
        DataGridStaffDetails.AllowUserToDeleteRows = False
        DataGridStaffDetails.AllowUserToResizeColumns = False
        DataGridStaffDetails.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = Color.Black
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridStaffDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridStaffDetails.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridStaffDetails.BackgroundColor = Color.White
        DataGridStaffDetails.BorderStyle = BorderStyle.None
        DataGridStaffDetails.CellBorderStyle = DataGridViewCellBorderStyle.None
        DataGridStaffDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Verdana", 10F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = Color.White
        DataGridViewCellStyle2.SelectionForeColor = Color.Black
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        DataGridStaffDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridStaffDetails.ColumnHeadersHeight = 45
        DataGridStaffDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridStaffDetails.Columns.AddRange(New DataGridViewColumn() {colEmployeeID, colEmployeeName, BirthDate, ContactNumber, colAddress, Username, EmailAddress, colDateHired, colPosition, Department, colDailyRate, colStatus, colEditIcon, colDeleteIcon, colSelect})
        DataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = SystemColors.Window
        DataGridViewCellStyle11.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle11.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = Color.White
        DataGridViewCellStyle11.SelectionForeColor = Color.Black
        DataGridViewCellStyle11.WrapMode = DataGridViewTriState.False
        DataGridStaffDetails.DefaultCellStyle = DataGridViewCellStyle11
        DataGridStaffDetails.EnableHeadersVisualStyles = False
        DataGridStaffDetails.GridColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        DataGridStaffDetails.Location = New Point(26, 55)
        DataGridStaffDetails.Margin = New Padding(3, 2, 3, 2)
        DataGridStaffDetails.Name = "DataGridStaffDetails"
        DataGridStaffDetails.ReadOnly = True
        DataGridStaffDetails.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = Color.White
        DataGridViewCellStyle12.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle12.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = Color.White
        DataGridViewCellStyle12.SelectionForeColor = Color.Black
        DataGridViewCellStyle12.WrapMode = DataGridViewTriState.True
        DataGridStaffDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        DataGridStaffDetails.RowHeadersVisible = False
        DataGridStaffDetails.RowHeadersWidth = 51
        DataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle13.WrapMode = DataGridViewTriState.True
        DataGridStaffDetails.RowsDefaultCellStyle = DataGridViewCellStyle13
        DataGridStaffDetails.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridStaffDetails.RowTemplate.DefaultCellStyle.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridStaffDetails.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridStaffDetails.RowTemplate.Height = 40
        DataGridStaffDetails.RowTemplate.ReadOnly = True
        DataGridStaffDetails.ScrollBars = ScrollBars.Vertical
        DataGridStaffDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridStaffDetails.Size = New Size(1561, 619)
        DataGridStaffDetails.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ImageAlign = ContentAlignment.MiddleLeft
        Label1.Location = New Point(28, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(111, 18)
        Label1.TabIndex = 5
        Label1.Text = "Staff Details"
        ' 
        ' colEmployeeID
        ' 
        colEmployeeID.DataPropertyName = "staff_id"
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.Padding = New Padding(5, 0, 10, 0)
        colEmployeeID.DefaultCellStyle = DataGridViewCellStyle3
        colEmployeeID.FillWeight = 90.8002243F
        colEmployeeID.HeaderText = "Employee ID"
        colEmployeeID.MinimumWidth = 6
        colEmployeeID.Name = "colEmployeeID"
        colEmployeeID.ReadOnly = True
        colEmployeeID.Width = 90
        ' 
        ' colEmployeeName
        ' 
        colEmployeeName.DataPropertyName = "EmployeeName"
        DataGridViewCellStyle4.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle4.Padding = New Padding(10, 0, 10, 0)
        colEmployeeName.DefaultCellStyle = DataGridViewCellStyle4
        colEmployeeName.FillWeight = 53.81019F
        colEmployeeName.HeaderText = "Employee Name"
        colEmployeeName.MinimumWidth = 100
        colEmployeeName.Name = "colEmployeeName"
        colEmployeeName.ReadOnly = True
        colEmployeeName.Width = 150
        ' 
        ' BirthDate
        ' 
        BirthDate.DataPropertyName = "BirthDate"
        BirthDate.HeaderText = "Birthdate"
        BirthDate.Name = "BirthDate"
        BirthDate.ReadOnly = True
        ' 
        ' ContactNumber
        ' 
        ContactNumber.DataPropertyName = "contact_number"
        ContactNumber.HeaderText = "Contact Numer"
        ContactNumber.Name = "ContactNumber"
        ContactNumber.ReadOnly = True
        ' 
        ' colAddress
        ' 
        colAddress.DataPropertyName = "address"
        DataGridViewCellStyle5.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        colAddress.DefaultCellStyle = DataGridViewCellStyle5
        colAddress.FillWeight = 59.00358F
        colAddress.HeaderText = "Address"
        colAddress.MinimumWidth = 50
        colAddress.Name = "colAddress"
        colAddress.ReadOnly = True
        colAddress.Resizable = DataGridViewTriState.False
        colAddress.Width = 190
        ' 
        ' Username
        ' 
        Username.DataPropertyName = "Username"
        Username.HeaderText = "Username"
        Username.Name = "Username"
        Username.ReadOnly = True
        ' 
        ' EmailAddress
        ' 
        EmailAddress.DataPropertyName = "EmailAddress"
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.True
        EmailAddress.DefaultCellStyle = DataGridViewCellStyle6
        EmailAddress.HeaderText = "Email Address"
        EmailAddress.Name = "EmailAddress"
        EmailAddress.ReadOnly = True
        EmailAddress.Width = 150
        ' 
        ' colDateHired
        ' 
        colDateHired.DataPropertyName = "date_hired"
        DataGridViewCellStyle7.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        colDateHired.DefaultCellStyle = DataGridViewCellStyle7
        colDateHired.FillWeight = 106.250275F
        colDateHired.HeaderText = "Date Hired"
        colDateHired.MinimumWidth = 6
        colDateHired.Name = "colDateHired"
        colDateHired.ReadOnly = True
        colDateHired.Width = 130
        ' 
        ' colPosition
        ' 
        colPosition.DataPropertyName = "position"
        DataGridViewCellStyle8.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        colPosition.DefaultCellStyle = DataGridViewCellStyle8
        colPosition.FillWeight = 62.09049F
        colPosition.HeaderText = "Position"
        colPosition.MinimumWidth = 6
        colPosition.Name = "colPosition"
        colPosition.ReadOnly = True
        ' 
        ' Department
        ' 
        Department.DataPropertyName = "Department"
        Department.HeaderText = "Department"
        Department.Name = "Department"
        Department.ReadOnly = True
        Department.Width = 110
        ' 
        ' colDailyRate
        ' 
        colDailyRate.DataPropertyName = "daily_rate"
        DataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle9.ForeColor = Color.Black
        DataGridViewCellStyle9.Format = "C2"
        DataGridViewCellStyle9.NullValue = Nothing
        DataGridViewCellStyle9.WrapMode = DataGridViewTriState.True
        colDailyRate.DefaultCellStyle = DataGridViewCellStyle9
        colDailyRate.FillWeight = 79.3092346F
        colDailyRate.HeaderText = "Daily Rate"
        colDailyRate.MinimumWidth = 6
        colDailyRate.Name = "colDailyRate"
        colDailyRate.ReadOnly = True
        colDailyRate.Width = 120
        ' 
        ' colStatus
        ' 
        colStatus.DataPropertyName = "status"
        DataGridViewCellStyle10.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        colStatus.DefaultCellStyle = DataGridViewCellStyle10
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
        ' staffview
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = Color.WhiteSmoke
        Controls.Add(PanelRound1)
        Controls.Add(pnlFilters)
        Controls.Add(LblStaffReport)
        Name = "staffview"
        Size = New Size(1700, 1542)
        pnlFilters.ResumeLayout(False)
        pnlFilters.PerformLayout()
        pnlTotalStaff.ResumeLayout(False)
        pnlTotalStaff.PerformLayout()
        CType(picTotalSubs, ComponentModel.ISupportInitialize).EndInit()
        PanelRound1.ResumeLayout(False)
        PanelRound1.PerformLayout()
        CType(deleteAll, ComponentModel.ISupportInitialize).EndInit()
        CType(btnAddStaff, ComponentModel.ISupportInitialize).EndInit()
        CType(btnSelectStaff, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridStaffDetails, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LblStaffReport As Label
    Friend WithEvents pnlFilters As PanelRound
    Friend WithEvents cbPosition As ComboBox
    Friend WithEvents lblStaff As Label
    Friend WithEvents LblFilters As Label
    Friend WithEvents pnlTotalStaff As PanelRound
    Friend WithEvents picTotalSubs As PictureBox
    Friend WithEvents totalStaff As Label
    Friend WithEvents LblTotalStaff As Label
    Friend WithEvents PanelRound1 As PanelRound
    Friend WithEvents LblPageInfo As Label
    Friend WithEvents btnSelectStaff As PictureBox
    Friend WithEvents btnSubscriberPreviousSA As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents txtStaffSearch As TextBox
    Friend WithEvents DataGridStaffDetails As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAddStaff As PictureBox
    Friend WithEvents deleteAll As PictureBox
    Friend WithEvents colEmployeeID As DataGridViewTextBoxColumn
    Friend WithEvents colEmployeeName As DataGridViewTextBoxColumn
    Friend WithEvents BirthDate As DataGridViewTextBoxColumn
    Friend WithEvents ContactNumber As DataGridViewTextBoxColumn
    Friend WithEvents colAddress As DataGridViewTextBoxColumn
    Friend WithEvents Username As DataGridViewTextBoxColumn
    Friend WithEvents EmailAddress As DataGridViewTextBoxColumn
    Friend WithEvents colDateHired As DataGridViewTextBoxColumn
    Friend WithEvents colPosition As DataGridViewTextBoxColumn
    Friend WithEvents Department As DataGridViewTextBoxColumn
    Friend WithEvents colDailyRate As DataGridViewTextBoxColumn
    Friend WithEvents colStatus As DataGridViewTextBoxColumn
    Friend WithEvents colEditIcon As DataGridViewImageColumn
    Friend WithEvents colDeleteIcon As DataGridViewImageColumn
    Friend WithEvents colSelect As DataGridViewCheckBoxColumn

End Class
