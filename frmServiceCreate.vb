Imports System.Configuration
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Windows.Forms
Imports MySqlConnector

Public Class frmServiceCreate

    Private _connectionString As String = Nothing
    Private selectedCustomerId As Integer = -1
    Private selectedCustomerPhone As String = ""

    ' Debounce timer for customer search
    Private searchTimer As Timer

    ' Semaphore API Configuration
    Private ReadOnly SEMAPHORE_API_KEY As String = "3d81194ec2cf0d9b33c8221724d35887"
    Private ReadOnly SEMAPHORE_API_URL As String = "https://api.semaphore.co/api/v4/messages"

    Private ReadOnly Property CONNECTION_STRING As String
        Get
            If _connectionString Is Nothing AndAlso Not DesignMode Then
                Try
                    _connectionString = ConfigurationManager.ConnectionStrings("SparxDb").ConnectionString
                Catch
                    _connectionString = String.Empty
                    Console.WriteLine("Error: Could not retrieve connection string 'SparxDb'.")
                End Try
            End If
            Return If(_connectionString IsNot Nothing, _connectionString, String.Empty)
        End Get
    End Property

    Private Class CustomerInfo
        Public Property CustomerId As Integer
        Public Property FullName As String
        Public Property Phone As String
        Public Property Email As String
        Public Property Address As String
        Public Property PlanType As String

        Public Sub New(customerId As Integer, fullName As String, phone As String, email As String, address As String, planType As String)
            Me.CustomerId = customerId
            Me.FullName = fullName
            Me.Phone = phone
            Me.Email = email
            Me.Address = address
            Me.PlanType = planType
        End Sub
    End Class

    Private Sub frmServiceCreate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the search panel FIRST
        InitializeSearchPanel()

        ' Set default values
        dtpService.Value = DateTime.Now
        dtpTime.Value = DateTime.Now
        cbStatus.SelectedIndex = 0 ' Requested

        ' Load Data
        LoadServiceTypes()
        LoadTechnicians()

        ' Set default service fee and make it editable
        UpdateServiceFee()
        txtServiceFee.ReadOnly = False ' Make fee editable
        txtServiceFee.BackColor = Color.White ' Ensure it looks editable

        ' Initialize search timer
        InitializeSearchTimer()

        ' Add click handlers for customer search
        AddHandler txtCustomer.Click, AddressOf txtCustomer_Click
        AddHandler TxtBoxAddress.Click, AddressOf txtCustomer_Click

        ' Show panel initially for customer search
        PanelCustomerSearch.Visible = True
        PanelCustomerSearch.BringToFront()  ' Ensure it's on top

        ' Ensure form click handler is set to hide search panel
        AddHandler Me.Click, AddressOf frmServiceCreate_Click

        ' Ensure service items exist in inventory
        EnsureServiceItemsExist()
    End Sub

    Private Sub EnsureServiceItemsExist()
        If String.IsNullOrEmpty(CONNECTION_STRING) Then Return

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                ' First, check what columns exist in the inventory table
                Dim columnsQuery As String = "SHOW COLUMNS FROM inventory"
                Dim availableColumns As New List(Of String)
                Using cmdColumns As New MySqlCommand(columnsQuery, conn)
                    Using reader As MySqlDataReader = cmdColumns.ExecuteReader()
                        While reader.Read()
                            availableColumns.Add(reader.GetString(0).ToLower())
                        End While
                    End Using
                End Using

                ' List of common service items
                Dim serviceTypes As String() = {"Installation", "Repair", "Relocation", "Maintenance"}

                For Each serviceType As String In serviceTypes
                    ' Check if service item exists
                    Dim checkQuery As String = "SELECT COUNT(*) FROM inventory WHERE item_name = @itemName AND item_type = 'Service'"
                    Using cmdCheck As New MySqlCommand(checkQuery, conn)
                        cmdCheck.Parameters.AddWithValue("@itemName", $"{serviceType} Service Charge")
                        Dim count As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())

                        If count = 0 Then
                            ' Build INSERT query based on available columns
                            Dim insertQuery As New StringBuilder()
                            insertQuery.Append("INSERT INTO inventory (")

                            ' Add columns that exist
                            Dim columnList As New List(Of String)
                            Dim valueList As New List(Of String)

                            columnList.Add("item_name")
                            valueList.Add("@item_name")

                            columnList.Add("item_type")
                            valueList.Add("@item_type")

                            ' Add price column based on what's available
                            If availableColumns.Contains("unit_price") Then
                                columnList.Add("unit_price")
                                valueList.Add("@unit_price")
                            ElseIf availableColumns.Contains("price") Then
                                columnList.Add("price")
                                valueList.Add("@price")
                            ElseIf availableColumns.Contains("service_price") Then
                                columnList.Add("service_price")
                                valueList.Add("@service_price")
                            ElseIf availableColumns.Contains("cost") Then
                                columnList.Add("cost")
                                valueList.Add("@cost")
                            End If

                            ' Add stock/quantity column
                            If availableColumns.Contains("stock_quantity") Then
                                columnList.Add("stock_quantity")
                                valueList.Add("@stock_quantity")
                            ElseIf availableColumns.Contains("quantity") Then
                                columnList.Add("quantity")
                                valueList.Add("@quantity")
                            ElseIf availableColumns.Contains("stock") Then
                                columnList.Add("stock")
                                valueList.Add("@stock")
                            End If

                            ' Add description column
                            If availableColumns.Contains("description") Then
                                columnList.Add("description")
                                valueList.Add("@description")
                            End If

                            ' Add category column
                            If availableColumns.Contains("category") Then
                                columnList.Add("category")
                                valueList.Add("@category")
                            End If

                            ' Add date column
                            If availableColumns.Contains("created_date") Then
                                columnList.Add("created_date")
                                valueList.Add("@created_date")
                            ElseIf availableColumns.Contains("date_added") Then
                                columnList.Add("date_added")
                                valueList.Add("@date_added")
                            ElseIf availableColumns.Contains("created_at") Then
                                columnList.Add("created_at")
                                valueList.Add("@created_at")
                            End If

                            insertQuery.Append(String.Join(", ", columnList))
                            insertQuery.Append(") VALUES (")
                            insertQuery.Append(String.Join(", ", valueList))
                            insertQuery.Append(")")

                            ' Create the service item
                            Using cmdInsert As New MySqlCommand(insertQuery.ToString(), conn)
                                Dim defaultFee As Decimal = 0D
                                Select Case serviceType
                                    Case "Installation" : defaultFee = 1500D
                                    Case "Repair" : defaultFee = 500D
                                    Case "Relocation" : defaultFee = 800D
                                    Case "Maintenance" : defaultFee = 300D
                                End Select

                                cmdInsert.Parameters.AddWithValue("@item_name", $"{serviceType} Service Charge")
                                cmdInsert.Parameters.AddWithValue("@item_type", "Service")

                                ' Add price parameter
                                If availableColumns.Contains("unit_price") Then
                                    cmdInsert.Parameters.AddWithValue("@unit_price", defaultFee)
                                ElseIf availableColumns.Contains("price") Then
                                    cmdInsert.Parameters.AddWithValue("@price", defaultFee)
                                ElseIf availableColumns.Contains("service_price") Then
                                    cmdInsert.Parameters.AddWithValue("@service_price", defaultFee)
                                ElseIf availableColumns.Contains("cost") Then
                                    cmdInsert.Parameters.AddWithValue("@cost", defaultFee)
                                End If

                                ' Add stock/quantity parameter
                                If availableColumns.Contains("stock_quantity") Then
                                    cmdInsert.Parameters.AddWithValue("@stock_quantity", 9999)
                                ElseIf availableColumns.Contains("quantity") Then
                                    cmdInsert.Parameters.AddWithValue("@quantity", 9999)
                                ElseIf availableColumns.Contains("stock") Then
                                    cmdInsert.Parameters.AddWithValue("@stock", 9999)
                                End If

                                ' Add description parameter
                                If availableColumns.Contains("description") Then
                                    cmdInsert.Parameters.AddWithValue("@description", $"Service fee for {serviceType} service")
                                End If

                                ' Add category parameter
                                If availableColumns.Contains("category") Then
                                    cmdInsert.Parameters.AddWithValue("@category", "Services")
                                End If

                                ' Add date parameter
                                Dim currentDate As DateTime = DateTime.Now
                                If availableColumns.Contains("created_date") Then
                                    cmdInsert.Parameters.AddWithValue("@created_date", currentDate)
                                ElseIf availableColumns.Contains("date_added") Then
                                    cmdInsert.Parameters.AddWithValue("@date_added", currentDate)
                                ElseIf availableColumns.Contains("created_at") Then
                                    cmdInsert.Parameters.AddWithValue("@created_at", currentDate)
                                End If

                                cmdInsert.ExecuteNonQuery()
                            End Using
                        End If
                    End Using
                Next

            End Using
        Catch ex As Exception
            Debug.WriteLine($"Error ensuring service items exist: {ex.Message}")
        End Try
    End Sub
    Private Sub CheckPanelControls()
        If PanelCustomerSearch Is Nothing Then
            MessageBox.Show("PanelCustomerSearch is null!")
            Return
        End If

        Debug.WriteLine($"PanelCustomerSearch Controls Count: {PanelCustomerSearch.Controls.Count}")

        For Each ctrl As Control In PanelCustomerSearch.Controls
            Debug.WriteLine($"Control: {ctrl.Name}, Type: {ctrl.GetType().Name}, Visible: {ctrl.Visible}")
        Next
    End Sub

    Private Sub InitializeSearchPanel()
        ' Ensure panel is properly initialized
        If PanelCustomerSearch IsNot Nothing Then
            PanelCustomerSearch.SuspendLayout()

            ' Set properties explicitly - position on the right side
            PanelCustomerSearch.Location = New Point(503, txtCustomer.Bottom + 5)
            PanelCustomerSearch.Width = Math.Max(txtCustomer.Width, 400)
            PanelCustomerSearch.Height = 250
            PanelCustomerSearch.BackColor = Color.White
            PanelCustomerSearch.BorderStyle = BorderStyle.FixedSingle
            PanelCustomerSearch.BringToFront()

            ' Ensure child controls are visible and properly sized
            If txtSearchCustomer IsNot Nothing Then
                txtSearchCustomer.Visible = True
                txtSearchCustomer.Width = PanelCustomerSearch.Width - 110
            End If

            If btnSearchCustomer IsNot Nothing Then
                btnSearchCustomer.Visible = True
                btnSearchCustomer.Location = New Point(PanelCustomerSearch.Width - 100, 10)
            End If

            If lvCustomers IsNot Nothing Then
                lvCustomers.Visible = True
                lvCustomers.Width = PanelCustomerSearch.Width - 20
                lvCustomers.Height = PanelCustomerSearch.Height - 55
                lvCustomers.Location = New Point(10, 45)
            End If

            PanelCustomerSearch.ResumeLayout(True)
            PanelCustomerSearch.PerformLayout()
        End If
    End Sub

    Private Sub InitializeSearchTimer()
        searchTimer = New Timer()
        searchTimer.Interval = 450 ' debounce interval in ms
        AddHandler searchTimer.Tick, AddressOf SearchTimer_Tick
    End Sub

    Private Sub txtCustomer_Click(sender As Object, e As EventArgs)
        ' Show and position the search panel
        InitializeSearchPanel() ' Re-initialize to ensure proper positioning
        PanelCustomerSearch.Visible = True
        PanelCustomerSearch.BringToFront()
        txtSearchCustomer.Focus()
        txtSearchCustomer.SelectAll()
    End Sub

    Private Sub SearchTimer_Tick(sender As Object, e As EventArgs)
        searchTimer.Stop()
        SearchCustomers()
    End Sub

    Private Sub LoadServiceTypes()
        cbServiceType.Items.Clear()
        cbServiceType.Items.AddRange({"Installation", "Repair", "Relocation", "Maintenance"})
        cbServiceType.SelectedIndex = 0
    End Sub

    Private Sub LoadTechnicians()
        If String.IsNullOrEmpty(CONNECTION_STRING) Then Return

        cbTechnician.Items.Clear()
        cbTechnician.Items.Add("Select Technician")

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Dim query As String = "SELECT staff_id, CONCAT(first_name, ' ', last_name) as full_name FROM staff WHERE position = 'Technician' ORDER BY last_name, first_name"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim techId As Integer = reader.GetInt32("staff_id")
                            Dim techName As String = reader.GetString("full_name")
                            cbTechnician.Items.Add(New KeyValuePair(Of String, Integer)(techName, techId))
                        End While
                    End Using
                End Using
            End Using

            cbTechnician.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show($"Error loading technicians: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearchCustomer_Click(sender As Object, e As EventArgs) Handles btnSearchCustomer.Click
        SearchCustomers()
    End Sub

    Private Sub txtSearchCustomer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearchCustomer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If searchTimer IsNot Nothing AndAlso searchTimer.Enabled Then
                searchTimer.Stop()
            End If
            SearchCustomers()
            e.Handled = True
        End If
    End Sub

    Private Sub txtSearchCustomer_TextChanged(sender As Object, e As EventArgs) Handles txtSearchCustomer.TextChanged
        If searchTimer Is Nothing Then
            InitializeSearchTimer()
        End If

        searchTimer.Stop()

        If String.IsNullOrWhiteSpace(txtSearchCustomer.Text) Then
            lvCustomers.Items.Clear()
            Return
        End If

        searchTimer.Start()
    End Sub

    Private Sub SearchCustomers()
        Dim searchText As String = txtSearchCustomer.Text.Trim()

        If String.IsNullOrEmpty(searchText) Then
            lvCustomers.Items.Clear()
            Return
        End If

        If String.IsNullOrEmpty(CONNECTION_STRING) Then
            MessageBox.Show("Cannot connect to database", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        lvCustomers.Items.Clear()

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim query As String = "
                    SELECT 
                        customer_id,
                        CONCAT(first_name, ' ', last_name) as full_name,
                        contact_number,
                        email_address,
                        installation_address,
                        plan_type
                    FROM customer 
                    WHERE 
                        first_name LIKE @search OR 
                        last_name LIKE @search OR 
                        contact_number LIKE @search OR
                        email_address LIKE @search
                    ORDER BY last_name, first_name
                    LIMIT 20"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@search", $"%{searchText}%")

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim item As New ListViewItem(reader.GetString("full_name"))
                            item.SubItems.Add(If(reader.IsDBNull(reader.GetOrdinal("contact_number")), String.Empty, reader.GetString("contact_number")))
                            item.SubItems.Add(If(reader.IsDBNull(reader.GetOrdinal("email_address")), String.Empty, reader.GetString("email_address")))
                            item.Tag = New CustomerInfo(
                                reader.GetInt32("customer_id"),
                                reader.GetString("full_name"),
                                If(reader.IsDBNull(reader.GetOrdinal("contact_number")), String.Empty, reader.GetString("contact_number")),
                                If(reader.IsDBNull(reader.GetOrdinal("email_address")), String.Empty, reader.GetString("email_address")),
                                If(reader.IsDBNull(reader.GetOrdinal("installation_address")), String.Empty, reader.GetString("installation_address")),
                                If(reader.IsDBNull(reader.GetOrdinal("plan_type")), String.Empty, reader.GetString("plan_type"))
                            )
                            lvCustomers.Items.Add(item)
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show($"Error searching customers: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lvCustomers_DoubleClick(sender As Object, e As EventArgs) Handles lvCustomers.DoubleClick
        If lvCustomers.SelectedItems.Count > 0 Then
            SelectCustomer(lvCustomers.SelectedItems(0))
        End If
    End Sub

    Private Sub lvCustomers_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lvCustomers.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) AndAlso lvCustomers.SelectedItems.Count > 0 Then
            SelectCustomer(lvCustomers.SelectedItems(0))
            e.Handled = True
        End If
    End Sub

    Private Sub SelectCustomer(item As ListViewItem)
        Dim customerInfo As CustomerInfo = DirectCast(item.Tag, CustomerInfo)

        selectedCustomerId = customerInfo.CustomerId
        selectedCustomerPhone = customerInfo.Phone

        txtCustomer.Text = customerInfo.FullName
        txtCustomerPhone.Text = customerInfo.Phone
        TxtBoxAddress.Text = customerInfo.Address
        lblSelectedCustomer.Text = $"Selected: {customerInfo.FullName}"
        lblSelectedCustomer.ForeColor = Color.Green

        ' Keep search panel visible even after customer selection
        ' PanelCustomerSearch.Visible = False

        cbServiceType.Enabled = True
        txtServiceDescription.Enabled = True
        cbTechnician.Enabled = True

        ShowSMSPreviewPrompt(customerInfo.FullName)
    End Sub

    Private Sub ShowSMSPreviewPrompt(customerName As String)
        Dim previewMessage As String = GetSMSPreview(customerName, "", "")
        txtServiceDescription.Text = previewMessage
    End Sub

    Private Sub cbServiceType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbServiceType.SelectedIndexChanged
        UpdateServiceFee()
    End Sub

    Private Function GetSMSPreview(customerName As String, serviceType As String, scheduledDate As String) As String
        If String.IsNullOrEmpty(serviceType) Then
            serviceType = "Service"
        End If

        If String.IsNullOrEmpty(scheduledDate) Then
            scheduledDate = DateTime.Now.ToString("MMM dd, yyyy")
        End If

        Return $"Hi {customerName}! You are scheduled for {serviceType} on {scheduledDate}. Our technician will contact you for confirmation."
    End Function
    Private Sub SendUpdateSMS(customerId As Integer, customerName As String, phoneNumber As String)
        Try
            ' Remove any non-numeric characters from phone number
            phoneNumber = New String(phoneNumber.Where(Function(c) Char.IsDigit(c)).ToArray())

            ' Validate phone number (Philippines format: 09XXXXXXXXX or +639XXXXXXXXX)
            If phoneNumber.Length < 10 Or Not phoneNumber.StartsWith("09") Then
                Debug.WriteLine($"Invalid phone number format: {phoneNumber}")
                Return
            End If

            ' Try different sender names (common approved names in PH)
            Dim senderNames() As String = {"SPARX", "ALERT", "NOTIFY", "INFO", "UPDATE"}

            For Each senderName In senderNames
                Try
                    SendSMSToProvider(phoneNumber, customerName, customerId, senderName)
                    Exit For ' Success, stop trying other names
                Catch ex As Exception
                    Debug.WriteLine($"Failed with sender '{senderName}': {ex.Message}")
                    Continue For ' Try next sender name
                End Try
            Next

        Catch ex As Exception
            Debug.WriteLine($"SMS error: {ex.Message}")
        End Try
    End Sub

    Private Sub SendSMSToProvider(phoneNumber As String, customerName As String, customerId As Integer, senderName As String)
        ' Example using Semaphore SMS API (popular in PH)
        Dim apiUrl As String = "https://api.semaphore.co/api/v4/messages"
        Dim apiKey As String = "YOUR_SEMAPHORE_API_KEY"

        ' Format the message
        Dim message As String = $"Hello {customerName}, your Sparx account (ID: {customerId}) has been updated. Thank you!"

        ' Create the request
        Using client As New Net.WebClient()
            client.Headers(Net.HttpRequestHeader.ContentType) = "application/x-www-form-urlencoded"

            Dim postData As String = $"apikey={apiKey}&number={phoneNumber}&message={Uri.EscapeDataString(message)}&sendername={senderName}"
            Dim responseBytes As Byte() = client.UploadData(apiUrl, "POST", System.Text.Encoding.UTF8.GetBytes(postData))
            Dim response As String = System.Text.Encoding.UTF8.GetString(responseBytes)

            ' Check response
            If response.Contains("""status"":""queued""") Or response.Contains("""status"":""sent""") Then
                Debug.WriteLine($"SMS sent successfully using sender '{senderName}'")
            Else
                Throw New Exception($"API Error: {response}")
            End If
        End Using
    End Sub
    Private Sub UpdateServiceFee()
        ' Set default fee based on service type, but keep textbox editable
        Dim defaultFee As Decimal = 0D

        Select Case cbServiceType.Text
            Case "Installation"
                defaultFee = 1500D
            Case "Repair"
                defaultFee = 500D
            Case "Relocation"
                defaultFee = 800D
            Case "Maintenance"
                defaultFee = 300D
            Case Else
                defaultFee = 0D
        End Select

        ' Only update if the current textbox value is empty or matches a default value
        ' This allows users to manually enter their own fee
        Dim currentFee As Decimal
        If Decimal.TryParse(txtServiceFee.Text, currentFee) Then
            ' Check if current fee matches any default fee
            Dim isDefaultFee As Boolean = False
            Dim defaultFees As Decimal() = {0D, 1500D, 500D, 800D, 300D}
            For Each df As Decimal In defaultFees
                If currentFee = df Then
                    isDefaultFee = True
                    Exit For
                End If
            Next

            If isDefaultFee Then
                txtServiceFee.Text = defaultFee.ToString("N2")
            End If
        Else
            ' If textbox is empty or invalid, set default
            txtServiceFee.Text = defaultFee.ToString("N2")
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If Not ValidateForm() Then Return

        Dim finalConfirmation As String = GetFinalConfirmation()
        Dim result As DialogResult = MessageBox.Show($"Confirm Service Request:{vbCrLf}{vbCrLf}{finalConfirmation}{vbCrLf}{vbCrLf}Do you want to proceed?",
                                                    "Confirm Service Request",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question)

        If result = DialogResult.No Then
            Return
        End If

        Dim serviceId As Integer = SaveServiceRequest()

        If serviceId > 0 Then
            If chkSendSMS.Checked AndAlso Not String.IsNullOrEmpty(selectedCustomerPhone) Then
                SendSMSNotification(serviceId)
            End If

            MessageBox.Show($"Service request created successfully!{vbCrLf}Service ID: {serviceId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Function GetFinalConfirmation() As String
        Dim confirmation As String = $"Customer: {txtCustomer.Text}{vbCrLf}"
        confirmation &= $"Service Type: {cbServiceType.Text}{vbCrLf}"
        confirmation &= $"Date: {dtpService.Value.ToString("MMM dd, yyyy")}{vbCrLf}"
        confirmation &= $"Time: {dtpTime.Value.ToString("hh:mm tt")}{vbCrLf}"
        confirmation &= $"Fee: PHP {txtServiceFee.Text}{vbCrLf}"
        confirmation &= $"Technician: {If(cbTechnician.SelectedIndex > 0, cbTechnician.Text, "Not Selected")}{vbCrLf}"
        confirmation &= $"SMS Notification: {(If(chkSendSMS.Checked, "YES", "NO"))}"

        Return confirmation
    End Function

    Private Function ValidateForm() As Boolean
        If selectedCustomerId <= 0 Then
            MessageBox.Show("Please select a customer", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            PanelCustomerSearch.Visible = True
            PanelCustomerSearch.BringToFront()
            Return False
        End If

        If cbServiceType.SelectedIndex < 0 Then
            MessageBox.Show("Please select a service type", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cbTechnician.SelectedIndex <= 0 Then
            MessageBox.Show("Please select a technician", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate service fee
        Dim serviceFee As Decimal
        If Not Decimal.TryParse(txtServiceFee.Text, serviceFee) Then
            MessageBox.Show("Please enter a valid service fee", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtServiceFee.Focus()
            txtServiceFee.SelectAll()
            Return False
        End If

        If serviceFee < 0 Then
            MessageBox.Show("Service fee cannot be negative", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtServiceFee.Focus()
            txtServiceFee.SelectAll()
            Return False
        End If

        If String.IsNullOrEmpty(txtServiceDescription.Text.Trim()) Then
            MessageBox.Show("Please enter service description", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Function SaveServiceRequest() As Integer
        If String.IsNullOrEmpty(CONNECTION_STRING) Then
            MessageBox.Show("Database connection error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End If

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim technicianId As Integer = -1
                If cbTechnician.SelectedItem IsNot Nothing AndAlso TypeOf cbTechnician.SelectedItem Is KeyValuePair(Of String, Integer) Then
                    technicianId = DirectCast(cbTechnician.SelectedItem, KeyValuePair(Of String, Integer)).Value
                Else
                    Dim techName As String = cbTechnician.Text
                    If Not String.IsNullOrEmpty(techName) AndAlso techName <> "Select Technician" Then
                        Dim queryTech As String = "SELECT staff_id FROM staff WHERE CONCAT(first_name, ' ', last_name) = @techName AND position = 'Technician' LIMIT 1"
                        Using cmdTech As New MySqlCommand(queryTech, conn)
                            cmdTech.Parameters.AddWithValue("@techName", techName)
                            Dim result As Object = cmdTech.ExecuteScalar()
                            If result IsNot Nothing Then
                                technicianId = Convert.ToInt32(result)
                            End If
                        End Using
                    End If
                End If

                If technicianId <= 0 Then
                    MessageBox.Show("Invalid technician selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return -1
                End If

                Dim serviceFee As Decimal = Decimal.Parse(txtServiceFee.Text)

                ' Get or create an inventory item for this service
                Dim itemId As Integer = GetOrCreateServiceItem(conn, cbServiceType.Text, serviceFee)

                If itemId <= 0 Then
                    MessageBox.Show("Could not create or find inventory item for this service. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return -1
                End If

                ' Full INSERT query including all required fields
                Dim query As String = "
                    INSERT INTO service (
                        customer_id, 
                        staff_id, 
                        service_type, 
                        date_requested, 
                        time_requested, 
                        date_completed, 
                        service_description, 
                        notes, 
                        status, 
                        service_cost, 
                        payment_method, 
                        technician_notes, 
                        customer_rating,
                        item_id
                    ) VALUES (
                        @customer_id, 
                        @staff_id, 
                        @service_type, 
                        @date_requested, 
                        @time_requested, 
                        @date_completed, 
                        @service_description, 
                        @notes, 
                        @status, 
                        @service_cost, 
                        @payment_method, 
                        @technician_notes, 
                        @customer_rating,
                        @item_id
                    );
                    SELECT LAST_INSERT_ID();"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@customer_id", selectedCustomerId)
                    cmd.Parameters.AddWithValue("@staff_id", technicianId)
                    cmd.Parameters.AddWithValue("@service_type", cbServiceType.Text)
                    cmd.Parameters.AddWithValue("@date_requested", dtpService.Value.Date)
                    cmd.Parameters.AddWithValue("@time_requested", dtpTime.Value.ToString("HH:mm:ss"))

                    If cbStatus.Text = "Completed" Then
                        cmd.Parameters.AddWithValue("@date_completed", DateTime.Now.Date)
                    Else
                        cmd.Parameters.AddWithValue("@date_completed", DBNull.Value)
                    End If

                    cmd.Parameters.AddWithValue("@service_description", txtServiceDescription.Text)
                    cmd.Parameters.AddWithValue("@notes", "")
                    cmd.Parameters.AddWithValue("@status", cbStatus.Text)
                    cmd.Parameters.AddWithValue("@service_cost", serviceFee)
                    cmd.Parameters.AddWithValue("@payment_method", "To be collected")
                    cmd.Parameters.AddWithValue("@technician_notes", "")
                    cmd.Parameters.AddWithValue("@customer_rating", DBNull.Value)
                    cmd.Parameters.AddWithValue("@item_id", itemId)

                    Dim serviceId As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return serviceId
                End Using
            End Using

        Catch ex As MySqlException
            MessageBox.Show($"Database Error saving service: {ex.Message}{vbCrLf}Error Number: {ex.Number}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        Catch ex As Exception
            MessageBox.Show($"Error saving service: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Private Function GetOrCreateServiceItem(conn As MySqlConnection, serviceType As String, serviceFee As Decimal) As Integer
        Try
            ' First, try to find an existing service item
            Dim findQuery As String = "
            SELECT item_id FROM inventory 
            WHERE item_type = 'Service' 
            AND LOWER(item_name) LIKE LOWER(@serviceType)
            LIMIT 1"

            Using cmdFind As New MySqlCommand(findQuery, conn)
                cmdFind.Parameters.AddWithValue("@serviceType", $"%{serviceType}%")
                Dim existingId As Object = cmdFind.ExecuteScalar()

                If existingId IsNot Nothing AndAlso Not IsDBNull(existingId) Then
                    Return Convert.ToInt32(existingId)
                End If
            End Using

            ' If not found, create a new one
            ' First, let's check what columns exist in the inventory table
            Dim columnsQuery As String = "SHOW COLUMNS FROM inventory"
            Dim availableColumns As New List(Of String)
            Using cmdColumns As New MySqlCommand(columnsQuery, conn)
                Using reader As MySqlDataReader = cmdColumns.ExecuteReader()
                    While reader.Read()
                        availableColumns.Add(reader.GetString(0).ToLower())
                    End While
                End Using
            End Using

            ' Build INSERT query based on available columns
            Dim insertQuery As New StringBuilder()
            insertQuery.Append("INSERT INTO inventory (")

            ' Add columns that exist
            Dim columnList As New List(Of String)
            Dim valueList As New List(Of String)

            ' Always include item_name and item_type
            columnList.Add("item_name")
            valueList.Add("@item_name")

            columnList.Add("item_type")
            valueList.Add("@item_type")

            ' Check for price-related columns
            If availableColumns.Contains("unit_price") Then
                columnList.Add("unit_price")
                valueList.Add("@unit_price")
            ElseIf availableColumns.Contains("price") Then
                columnList.Add("price")
                valueList.Add("@price")
            ElseIf availableColumns.Contains("service_price") Then
                columnList.Add("service_price")
                valueList.Add("@service_price")
            ElseIf availableColumns.Contains("cost") Then
                columnList.Add("cost")
                valueList.Add("@cost")
            End If

            ' Check for stock/quantity columns
            If availableColumns.Contains("stock_quantity") Then
                columnList.Add("stock_quantity")
                valueList.Add("@stock_quantity")
            ElseIf availableColumns.Contains("quantity") Then
                columnList.Add("quantity")
                valueList.Add("@quantity")
            ElseIf availableColumns.Contains("stock") Then
                columnList.Add("stock")
                valueList.Add("@stock")
            End If

            ' Check for description column
            If availableColumns.Contains("description") Then
                columnList.Add("description")
                valueList.Add("@description")
            End If

            ' Check for category column
            If availableColumns.Contains("category") Then
                columnList.Add("category")
                valueList.Add("@category")
            End If

            ' Check for created_date or date_added columns
            If availableColumns.Contains("created_date") Then
                columnList.Add("created_date")
                valueList.Add("@created_date")
            ElseIf availableColumns.Contains("date_added") Then
                columnList.Add("date_added")
                valueList.Add("@date_added")
            ElseIf availableColumns.Contains("created_at") Then
                columnList.Add("created_at")
                valueList.Add("@created_at")
            End If

            insertQuery.Append(String.Join(", ", columnList))
            insertQuery.Append(") VALUES (")
            insertQuery.Append(String.Join(", ", valueList))
            insertQuery.Append("); SELECT LAST_INSERT_ID();")

            Using cmdInsert As New MySqlCommand(insertQuery.ToString(), conn)
                ' Create a descriptive item name
                Dim itemName As String = $"{serviceType} Service Charge"

                cmdInsert.Parameters.AddWithValue("@item_name", itemName)
                cmdInsert.Parameters.AddWithValue("@item_type", "Service")

                ' Add price parameter based on available column
                If availableColumns.Contains("unit_price") Then
                    cmdInsert.Parameters.AddWithValue("@unit_price", serviceFee)
                ElseIf availableColumns.Contains("price") Then
                    cmdInsert.Parameters.AddWithValue("@price", serviceFee)
                ElseIf availableColumns.Contains("service_price") Then
                    cmdInsert.Parameters.AddWithValue("@service_price", serviceFee)
                ElseIf availableColumns.Contains("cost") Then
                    cmdInsert.Parameters.AddWithValue("@cost", serviceFee)
                End If

                ' Add stock/quantity parameter
                If availableColumns.Contains("stock_quantity") Then
                    cmdInsert.Parameters.AddWithValue("@stock_quantity", 9999)
                ElseIf availableColumns.Contains("quantity") Then
                    cmdInsert.Parameters.AddWithValue("@quantity", 9999)
                ElseIf availableColumns.Contains("stock") Then
                    cmdInsert.Parameters.AddWithValue("@stock", 9999)
                End If

                ' Add description parameter
                If availableColumns.Contains("description") Then
                    cmdInsert.Parameters.AddWithValue("@description", $"Service fee for {serviceType} service")
                End If

                ' Add category parameter
                If availableColumns.Contains("category") Then
                    cmdInsert.Parameters.AddWithValue("@category", "Services")
                End If

                ' Add date parameter
                Dim currentDate As DateTime = DateTime.Now
                If availableColumns.Contains("created_date") Then
                    cmdInsert.Parameters.AddWithValue("@created_date", currentDate)
                ElseIf availableColumns.Contains("date_added") Then
                    cmdInsert.Parameters.AddWithValue("@date_added", currentDate)
                ElseIf availableColumns.Contains("created_at") Then
                    cmdInsert.Parameters.AddWithValue("@created_at", currentDate)
                End If

                Dim newId As Object = cmdInsert.ExecuteScalar()
                If newId IsNot Nothing AndAlso Not IsDBNull(newId) Then
                    Return Convert.ToInt32(newId)
                Else
                    Return 0
                End If
            End Using

        Catch ex As MySqlException
            ' Try alternative approach if the first one fails
            Try
                ' Get any existing service item as fallback
                Dim fallbackQuery As String = "SELECT item_id FROM inventory WHERE item_type = 'Service' LIMIT 1"
                Using cmdFallback As New MySqlCommand(fallbackQuery, conn)
                    Dim fallbackId As Object = cmdFallback.ExecuteScalar()
                    If fallbackId IsNot Nothing AndAlso Not IsDBNull(fallbackId) Then
                        Return Convert.ToInt32(fallbackId)
                    End If
                End Using
            Catch ex2 As Exception
                ' Ignore fallback error
            End Try

            MessageBox.Show($"Error creating service item: {ex.Message}{vbCrLf}Please ensure there is at least one 'Service' type item in the inventory.",
                       "Inventory Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        Catch ex As Exception
            MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function
    Private Sub SendSMSNotification(serviceId As Integer)
        Try
            Dim message As String = GenerateSMSMessage(serviceId)

            Dim cleanPhone As String = New String(selectedCustomerPhone.Where(Function(c) Char.IsDigit(c)).ToArray())

            If cleanPhone.StartsWith("09") AndAlso cleanPhone.Length >= 10 Then
                cleanPhone = "63" & cleanPhone.Substring(1)
            ElseIf cleanPhone.StartsWith("9") AndAlso cleanPhone.Length >= 9 Then
                cleanPhone = "63" & cleanPhone
            ElseIf cleanPhone.Length < 10 Then
                MessageBox.Show("Invalid phone number format", "SMS Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim postData As String = $"apikey={SEMAPHORE_API_KEY}&number={cleanPhone}&message={Uri.EscapeDataString(message)}&sendername=SPARXNET"

            Using client As New WebClient()
                client.Headers(HttpRequestHeader.ContentType) = "application/x-www-form-urlencoded"
                Dim responseBytes As Byte() = client.UploadData(SEMAPHORE_API_URL, "POST", Encoding.UTF8.GetBytes(postData))
                Dim response As String = Encoding.UTF8.GetString(responseBytes)

                ' Check Semaphore API response
                If response.Contains("""status""") AndAlso response.Contains("""success""") Then
                    MessageBox.Show("SMS notification sent successfully!", "SMS Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show($"SMS API returned an unexpected response: {response}", "SMS Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Using

        Catch ex As WebException
            Dim errorMessage As String = "Network error sending SMS."
            Try
                Using reader As New StreamReader(DirectCast(ex.Response, HttpWebResponse).GetResponseStream())
                    errorMessage = reader.ReadToEnd()
                End Using
            Catch
                ' Use default error message
            End Try
            MessageBox.Show($"Error sending SMS: {errorMessage}", "SMS Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Catch ex As Exception
            MessageBox.Show($"Error sending SMS: {ex.Message}", "SMS Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Function GenerateSMSMessage(serviceId As Integer) As String
        Dim customerName As String = txtCustomer.Text
        Dim serviceType As String = cbServiceType.Text
        Dim requestedDate As String = dtpService.Value.ToString("MMM dd, yyyy")
        Dim requestedTime As String = dtpTime.Value.ToString("hh:mm tt")
        Dim serviceFee As Decimal = Decimal.Parse(txtServiceFee.Text)

        Dim message As String = ""

        Select Case serviceType.ToLower()
            Case "repair"
                message = $"Hi {customerName}! You are scheduled for Repair on {requestedDate} at {requestedTime}. " &
                         $"Service ID: {serviceId}. Service Fee: PHP {serviceFee:N2}. " &
                         $"Our technician will contact you for confirmation. " &
                         $"Thank you for choosing SPARXNET!"
            Case "installation"
                message = $"Hi {customerName}! You are scheduled for Installation on {requestedDate} at {requestedTime}. " &
                         $"Service ID: {serviceId}. Service Fee: PHP {serviceFee:N2}. " &
                         $"Please ensure someone is available at the installation address. " &
                         $"Thank you for choosing SPARXNET!"
            Case "relocation"
                message = $"Hi {customerName}! You are scheduled for Relocation on {requestedDate} at {requestedTime}. " &
                         $"Service ID: {serviceId}. Service Fee: PHP {serviceFee:N2}. " &
                         $"We will contact you for further details. " &
                         $"Thank you for choosing SPARXNET!"
            Case "maintenance"
                message = $"Hi {customerName}! You are scheduled for Maintenance on {requestedDate} at {requestedTime}. " &
                         $"Service ID: {serviceId}. Service Fee: PHP {serviceFee:N2}. " &
                         $"Our technician will arrive during the scheduled time. " &
                         $"Thank you for choosing SPARXNET!"
            Case Else
                message = $"Hi {customerName}! You are scheduled for {serviceType} on {requestedDate} at {requestedTime}. " &
                         $"Service ID: {serviceId}. Service Fee: PHP {serviceFee:N2}. " &
                         $"We will contact you shortly. " &
                         $"Thank you for choosing SPARXNET!"
        End Select

        Return message
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmServiceCreate_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        ' Hide panel when clicking anywhere on the form (except panel itself)
        If PanelCustomerSearch.Visible Then
            Dim mousePos As Point = Me.PointToClient(Cursor.Position)
            If Not PanelCustomerSearch.Bounds.Contains(mousePos) Then
                PanelCustomerSearch.Visible = False
            End If
        End If
    End Sub

    Private Sub dtpService_ValueChanged(sender As Object, e As EventArgs) Handles dtpService.ValueChanged
        ' Optional: Update any preview if needed
    End Sub

    Private Sub btnSMSPreview_Click(sender As Object, e As EventArgs) Handles btnSMSPreview.Click
        If String.IsNullOrEmpty(txtCustomer.Text.Trim()) Then
            MessageBox.Show("Please select a customer first.", "Customer Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim customerName As String = txtCustomer.Text.Trim()
        Dim serviceType As String = If(cbServiceType.SelectedIndex >= 0, cbServiceType.Text, "")
        Dim scheduledDate As String = dtpService.Value.ToString("MMM dd, yyyy")
        Dim serviceFee As Decimal
        If Not Decimal.TryParse(txtServiceFee.Text, serviceFee) Then
            serviceFee = 0D
        End If

        Dim previewMessage As String = $"Hi {customerName}! You are scheduled for {serviceType} on {scheduledDate}. " &
                                      $"Estimated Fee: PHP {serviceFee:N2}. " &
                                      $"Our technician will contact you for confirmation. " &
                                      $"Thank you for choosing SPARXNET!"

        MessageBox.Show($"SMS Preview:{vbCrLf}{vbCrLf}{previewMessage}", "SMS Preview", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub txtServiceFee_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtServiceFee.KeyPress
        ' Allow numbers, decimal point, and control keys
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True
        End If

        ' Allow only one decimal point
        If e.KeyChar = "." AndAlso txtServiceFee.Text.IndexOf(".") > -1 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtServiceFee_TextChanged(sender As Object, e As EventArgs) Handles txtServiceFee.TextChanged
        ' Optional: Add any formatting or validation as needed
    End Sub

    Private Sub txtServiceFee_Leave(sender As Object, e As EventArgs) Handles txtServiceFee.Leave
        ' Format the textbox value when it loses focus
        Dim value As Decimal
        If Decimal.TryParse(txtServiceFee.Text, value) Then
            txtServiceFee.Text = value.ToString("N2")
        End If
    End Sub

End Class
' ====== SMS SERVICE CLASS ======
Public Class SMSService
    ' Semaphore API Configuration
    Private Shared ReadOnly SEMAPHORE_API_KEY As String = "3d81194ec2cf0d9b33c8221724d35887"
    Private Shared ReadOnly SEMAPHORE_API_URL As String = "https://api.semaphore.co/api/v4/messages"

    ' Different sender names to try (common approved names in PH)
    Private Shared ReadOnly SENDER_NAMES() As String = {"SPARX", "ALERT", "NOTIFY", "INFO", "UPDATE"}

    ' Send update notification for subscriber changes
    Public Shared Sub SendUpdateNotification(customerId As Integer, customerName As String, phoneNumber As String)
        Try
            ' Clean the phone number
            phoneNumber = CleanPhoneNumber(phoneNumber)

            ' Validate phone number
            If Not IsValidPhoneNumber(phoneNumber) Then
                Debug.WriteLine($"Invalid phone number format: {phoneNumber}")
                Return
            End If

            ' Format the message for subscriber update
            Dim message As String = FormatUpdateMessage(customerId, customerName)

            ' Format for international SMS
            Dim internationalNumber As String = FormatForInternationalSMS(phoneNumber)

            ' Try different sender names until one works
            Dim success As Boolean = False
            For Each senderName As String In SENDER_NAMES
                Try
                    success = SendSMSToSemaphore(internationalNumber, message, senderName)
                    If success Then
                        Debug.WriteLine($"SMS update sent successfully using sender '{senderName}'")
                        Exit For
                    End If
                Catch ex As Exception
                    Debug.WriteLine($"Failed with sender '{senderName}': {ex.Message}")
                    Continue For
                End Try
            Next

            If Not success Then
                Debug.WriteLine("Failed to send SMS with all sender names")
            End If

        Catch ex As Exception
            Debug.WriteLine($"SMS error in SendUpdateNotification: {ex.Message}")
        End Try
    End Sub

    ' Send SMS for service notifications (reusing your existing logic)
    Public Shared Sub SendServiceNotification(customerName As String, phoneNumber As String,
                                              serviceType As String, scheduledDate As String,
                                              serviceFee As Decimal, serviceId As Integer)
        Try
            ' Clean the phone number
            phoneNumber = CleanPhoneNumber(phoneNumber)

            ' Validate phone number
            If Not IsValidPhoneNumber(phoneNumber) Then
                Debug.WriteLine($"Invalid phone number format: {phoneNumber}")
                Return
            End If

            ' Format the message for service notification
            Dim message As String = FormatServiceMessage(customerName, serviceType, scheduledDate, serviceFee, serviceId)

            ' Format for international SMS
            Dim internationalNumber As String = FormatForInternationalSMS(phoneNumber)

            ' Try different sender names
            Dim success As Boolean = False
            For Each senderName As String In SENDER_NAMES
                Try
                    success = SendSMSToSemaphore(internationalNumber, message, senderName)
                    If success Then
                        Debug.WriteLine($"Service SMS sent successfully using sender '{senderName}'")
                        Exit For
                    End If
                Catch ex As Exception
                    Debug.WriteLine($"Failed with sender '{senderName}': {ex.Message}")
                    Continue For
                End Try
            Next

        Catch ex As Exception
            Debug.WriteLine($"SMS error in SendServiceNotification: {ex.Message}")
        End Try
    End Sub

    ' Private helper methods
    Private Shared Function CleanPhoneNumber(phoneNumber As String) As String
        Return New String(phoneNumber.Where(Function(c) Char.IsDigit(c)).ToArray())
    End Function

    Private Shared Function IsValidPhoneNumber(phoneNumber As String) As Boolean
        ' Validate Philippines format: 09XXXXXXXXX or 9XXXXXXXX
        Return (phoneNumber.Length >= 10 AndAlso phoneNumber.StartsWith("09")) OrElse
               (phoneNumber.Length >= 9 AndAlso phoneNumber.StartsWith("9"))
    End Function

    Private Shared Function FormatForInternationalSMS(phoneNumber As String) As String
        If phoneNumber.StartsWith("09") AndAlso phoneNumber.Length >= 10 Then
            Return "63" & phoneNumber.Substring(1)
        ElseIf phoneNumber.StartsWith("9") AndAlso phoneNumber.Length >= 9 Then
            Return "63" & phoneNumber
        Else
            Return phoneNumber
        End If
    End Function

    Private Shared Function FormatUpdateMessage(customerId As Integer, customerName As String) As String
        Return $"Hello {customerName}, your Sparx account (ID: {customerId}) has been successfully updated. " &
               $"If you have any questions, please contact our support. Thank you for choosing SPARXNET!"
    End Function

    Private Shared Function FormatServiceMessage(customerName As String, serviceType As String,
                                                 scheduledDate As String, serviceFee As Decimal,
                                                 serviceId As Integer) As String
        Select Case serviceType.ToLower()
            Case "repair"
                Return $"Hi {customerName}! You are scheduled for Repair on {scheduledDate}. " &
                       $"Service ID: {serviceId}. Service Fee: PHP {serviceFee:N2}. " &
                       $"Our technician will contact you for confirmation. Thank you for choosing SPARXNET!"
            Case "installation"
                Return $"Hi {customerName}! You are scheduled for Installation on {scheduledDate}. " &
                       $"Service ID: {serviceId}. Service Fee: PHP {serviceFee:N2}. " &
                       $"Please ensure someone is available. Thank you for choosing SPARXNET!"
            Case "relocation"
                Return $"Hi {customerName}! You are scheduled for Relocation on {scheduledDate}. " &
                       $"Service ID: {serviceId}. Service Fee: PHP {serviceFee:N2}. " &
                       $"We will contact you for details. Thank you for choosing SPARXNET!"
            Case "maintenance"
                Return $"Hi {customerName}! You are scheduled for Maintenance on {scheduledDate}. " &
                       $"Service ID: {serviceId}. Service Fee: PHP {serviceFee:N2}. " &
                       $"Our technician will arrive during scheduled time. Thank you for choosing SPARXNET!"
            Case Else
                Return $"Hi {customerName}! You are scheduled for {serviceType} on {scheduledDate}. " &
                       $"Service ID: {serviceId}. Service Fee: PHP {serviceFee:N2}. " &
                       $"We will contact you shortly. Thank you for choosing SPARXNET!"
        End Select
    End Function

    Private Shared Function SendSMSToSemaphore(phoneNumber As String, message As String, senderName As String) As Boolean
        Using client As New WebClient()
            client.Headers(HttpRequestHeader.ContentType) = "application/x-www-form-urlencoded"

            Dim postData As String = $"apikey={SEMAPHORE_API_KEY}&number={phoneNumber}&message={Uri.EscapeDataString(message)}&sendername={senderName}"
            Dim responseBytes As Byte() = client.UploadData(SEMAPHORE_API_URL, "POST", Encoding.UTF8.GetBytes(postData))
            Dim response As String = Encoding.UTF8.GetString(responseBytes)

            ' Check if successful
            Return response.Contains("""status"":""queued""") OrElse
                   response.Contains("""status"":""sent""") OrElse
                   response.Contains("""status""") AndAlso response.Contains("""success""")
        End Using
    End Function
End Class
' ====== END SMS SERVICE CLASS ======