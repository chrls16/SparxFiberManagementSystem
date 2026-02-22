Imports System.Configuration
Imports System.Data
Imports System.Drawing.Printing
Imports System.Windows.Media
Imports LiveCharts
Imports LiveCharts.WinForms
Imports LiveCharts.Wpf
Imports MySqlConnector
Imports Color = System.Drawing.Color

Public Class inventoryview

    Private stockChart As LiveCharts.WinForms.CartesianChart

    Private _connectionString As String = Nothing
    Private refreshTimer As Timer
    Private searchTimer As Timer

    Private Const PAGE_SIZE As Integer = 25
    Private currentPageIndex As Integer = 0
    Private totalRecords As Integer = 0

    Private selectedInventoryIds As New List(Of String)()

    Private ReadOnly Property CONNECTION_STRING As String
        Get
            If _connectionString Is Nothing Then
                Try
                    Dim isDesignTime As Boolean = (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime)
                    If Not isDesignTime Then
                        _connectionString = ConfigurationManager.ConnectionStrings("SparxDb")?.ConnectionString
                    Else
                        _connectionString = String.Empty
                    End If
                Catch ex As Exception
                    _connectionString = String.Empty
                End Try
            End If
            Return If(_connectionString IsNot Nothing, _connectionString, String.Empty)
        End Get
    End Property

    Private Sub inventoryview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not CheckControlsExist() Then Exit Sub

        Try
            PopulateDropdowns()
            CreateStockChart()
            RefreshFilters()

            refreshTimer = New Timer()
            refreshTimer.Interval = 30000
            AddHandler refreshTimer.Tick, AddressOf RefreshStockData
            refreshTimer.Start()

        Catch ex As Exception
            MessageBox.Show("An error occurred during loading: " & ex.Message)
        End Try
    End Sub

    Private Function CheckControlsExist() As Boolean
        Dim missingControls As New List(Of String)

        If InventoryDetailsDVG Is Nothing Then missingControls.Add("InventoryDetailsDVG (DataGridView)")
        If stock Is Nothing Then missingControls.Add("stock (Panel for Chart)")
        If InventoryDetailsPanel Is Nothing Then missingControls.Add("InventoryDetailsPanel (Panel)")
        If ComboBox1 Is Nothing Then missingControls.Add("ComboBox1 (ComboBox)")
        If txtInventorySearchSA Is Nothing Then missingControls.Add("txtInventorySearchSA (TextBox)")
        If btnDeploy Is Nothing Then missingControls.Add("btnDeploy (Button)")

        If missingControls.Count > 0 Then
            MessageBox.Show("CRITICAL ERROR: The following controls are missing from your Form Design:" & vbCrLf & vbCrLf &
                            String.Join(vbCrLf, missingControls) & vbCrLf & vbCrLf &
                            "Please rename your controls in the Designer properties to match these names.",
                            "Missing Controls", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function

    Private Sub InventoryDetailsPanel_SizeChanged(sender As Object, e As EventArgs) Handles InventoryDetailsPanel.SizeChanged
        If InventoryDetailsDVG IsNot Nothing AndAlso InventoryDetailsPanel IsNot Nothing Then
            InventoryDetailsDVG.Size = New Size(InventoryDetailsPanel.Width - 40, InventoryDetailsPanel.Height - 100)
        End If
    End Sub

    Private Sub InventoryDetailsDVG_SelectionChanged(sender As Object, e As EventArgs) Handles InventoryDetailsDVG.SelectionChanged
        If InventoryDetailsDVG IsNot Nothing Then InventoryDetailsDVG.ClearSelection()
    End Sub

    Private Sub InventoryDetailsDVG_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles InventoryDetailsDVG.CellFormatting
        If InventoryDetailsDVG Is Nothing OrElse e.RowIndex < 0 Then Exit Sub

        Dim colName As String = InventoryDetailsDVG.Columns(e.ColumnIndex).Name

        ' NEW: Format Item ID to 00001
        If colName = "ItemID" Then
            If e.Value IsNot Nothing AndAlso IsNumeric(e.Value) Then
                e.Value = Convert.ToInt32(e.Value).ToString("D5")
                e.FormattingApplied = True
            End If
        End If

        ' Existing Alignment Logic
        If colName = "UnitCost" OrElse colName = "TotalValue" Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' Optional: Format currency here if not already formatted
            If IsNumeric(e.Value) Then
                e.Value = String.Format("₱{0:N2}", e.Value)
                e.FormattingApplied = True
            End If
        End If
    End Sub


    'FOR CHARTS
    Private Sub CreateStockChart()
        If stock Is Nothing Then Exit Sub

        stockChart = New LiveCharts.WinForms.CartesianChart()
        stockChart.Dock = DockStyle.Fill
        stockChart.BackColor = System.Drawing.Color.White
        stockChart.LegendLocation = LegendLocation.None
        stockChart.Zoom = ZoomingOptions.None
        stockChart.Hoverable = True

        stock.Controls.Add(stockChart)
        stockChart.BringToFront()
    End Sub

    Private Sub LoadStockChartData()
        If Not LoadStockChartFromDatabase() Then
            LoadDummyChartData()
        End If
    End Sub

    Private Function LoadStockChartFromDatabase() As Boolean
        If String.IsNullOrEmpty(CONNECTION_STRING) Then Return False
        If stockChart Is Nothing Then Return False

        Try
            Dim fixedStatuses As New List(Of String) From {"In Stock", "Low Stock", "Critical Low", "Out of Stock"}
            Dim statusCounts As New Dictionary(Of String, Double)
            For Each s In fixedStatuses
                statusCounts(s) = 0
            Next

            Dim query As String = "
                SELECT 
                    CASE 
                        WHEN status LIKE 'Deployed%' THEN 'Deployed'
                        WHEN current_stock >= reorder_level * 1.5 THEN 'In Stock'
                        WHEN current_stock > reorder_level AND current_stock < reorder_level * 1.5 THEN 'Low Stock'
                        WHEN current_stock > 0 AND current_stock <= reorder_level THEN 'Critical Low'
                        WHEN current_stock = 0 THEN 'Out of Stock'
                        ELSE 'In Stock'
                    END as status_group,
                    COUNT(*) as count
                FROM inventory
                WHERE is_deleted = 0   
                GROUP BY status_group
            "

            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim status As String = If(reader("status_group")?.ToString(), "In Stock")
                            Dim cnt As Double = 0
                            If Not IsDBNull(reader("count")) Then
                                Double.TryParse(reader("count").ToString(), cnt)
                            End If

                            If statusCounts.ContainsKey(status) Then
                                statusCounts(status) = cnt
                            End If
                        End While
                    End Using
                End Using
            End Using

            Dim labels As New List(Of String)()
            Dim values As New List(Of Double)()

            For Each s In fixedStatuses
                labels.Add(s)
                values.Add(statusCounts(s))
            Next

            If values.All(Function(v) v = 0) Then Return False

            UpdateChartWithData(labels, values)
            Return True

        Catch ex As Exception
            Console.WriteLine($"Error loading stock chart data: {ex.Message}")
            Return False
        End Try
    End Function

    Private Sub UpdateChartWithData(labels As List(Of String), values As List(Of Double))
        If stockChart Is Nothing Then Exit Sub

        stockChart.Series.Clear()
        Dim seriesCollection As New SeriesCollection()
        Dim series As New ColumnSeries() With {
            .Title = "Stock Levels",
            .Values = New ChartValues(Of Double)(values),
            .DataLabels = True,
            .Fill = New SolidColorBrush(System.Windows.Media.Color.FromRgb(33, 150, 243)),
            .Stroke = New SolidColorBrush(System.Windows.Media.Color.FromRgb(21, 101, 192)),
            .StrokeThickness = 1,
            .PointGeometry = DefaultGeometries.None,
            .ColumnPadding = 0.3
        }
        series.LabelPoint = Function(point) point.Y.ToString("N0")
        seriesCollection.Add(series)
        stockChart.Series = seriesCollection

        stockChart.AxisX.Clear()
        stockChart.AxisX.Add(New Axis() With {
            .Title = "Stock Status",
            .Labels = labels.ToArray(),
            .Separator = New LiveCharts.Wpf.Separator() With {.Step = 1},
            .ShowLabels = True,
            .Position = AxisPosition.LeftBottom,
            .Foreground = New SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0))
        })

        stockChart.AxisY.Clear()
        stockChart.AxisY.Add(New Axis() With {
            .Title = "Number of Items",
            .LabelFormatter = Function(value) value.ToString("N0"),
            .MinValue = 0,
            .MaxValue = If(values.Count > 0, If(values.Max() * 1.1 > 0, values.Max() * 1.1, 10), 10),
            .ShowLabels = True,
            .Position = AxisPosition.LeftBottom,
            .Foreground = New SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0))
        })
        stockChart.Update()
    End Sub

    'FOR DATA LABELS
    Private Sub LoadKPIData()
        If String.IsNullOrEmpty(CONNECTION_STRING) Then Return

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim whereConditions As New List(Of String)
                whereConditions.Add("is_deleted = 0")

                If txtInventorySearchSA IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(txtInventorySearchSA.Text) Then
                    whereConditions.Add("(item_name LIKE @Search " &
                        "OR item_id LIKE @Search " &
                        "OR LPAD(item_id, 5, '0') LIKE @Search " & ' Added for zero-padding search
                        "OR serial_number LIKE @Search)")
                End If

                If ComboBox1 IsNot Nothing AndAlso ComboBox1.SelectedIndex > 0 Then
                    Dim selectedStatus As String = ComboBox1.SelectedItem.ToString()
                    Select Case selectedStatus
                        Case "In Stock" : whereConditions.Add("current_stock >= reorder_level * 1.5 AND status NOT LIKE 'Deployed%'")
                        Case "Low Stock" : whereConditions.Add("(current_stock > reorder_level AND current_stock < reorder_level * 1.5)")
                        Case "Critical Low" : whereConditions.Add("(current_stock > 0 AND current_stock <= reorder_level)")
                        Case "Out of Stock" : whereConditions.Add("current_stock = 0")
                        Case "Deployed" : whereConditions.Add("status LIKE 'Deployed%'")
                    End Select
                End If

                Dim filterClause As String = ""
                If whereConditions.Count > 0 Then filterClause = " WHERE " & String.Join(" AND ", whereConditions)

                If NumItemsLbl IsNot Nothing Then
                    Dim totalQuery As String = "SELECT COUNT(*) FROM inventory" & filterClause
                    Using cmd As New MySqlCommand(totalQuery, conn)
                        ApplyInventoryParameters(cmd)
                        NumItemsLbl.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0")
                    End Using
                End If

                If CurrencyLbl IsNot Nothing Then
                    Dim valueQuery As String = "SELECT SUM(unit_cost * current_stock) FROM inventory" & filterClause
                    Using cmd As New MySqlCommand(valueQuery, conn)
                        ApplyInventoryParameters(cmd)
                        Dim result = cmd.ExecuteScalar()
                        Dim totalVal As Decimal = If(IsDBNull(result) OrElse result Is Nothing, 0, Convert.ToDecimal(result))
                        CurrencyLbl.Text = "₱" & totalVal.ToString("N2")
                    End Using
                End If

                If NumLowStockLbl IsNot Nothing Then
                    Dim lowStockQuery As String = "SELECT COUNT(*) FROM inventory WHERE is_deleted = 0 AND current_stock > 0 AND current_stock < (reorder_level * 1.5) AND status NOT LIKE 'Deployed%'"
                    Using cmd As New MySqlCommand(lowStockQuery, conn)
                        NumLowStockLbl.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0")
                    End Using
                End If

                If NumOutStockLbl IsNot Nothing Then
                    Dim outStockQuery As String = "SELECT COUNT(*) FROM inventory WHERE is_deleted = 0 AND current_stock = 0"
                    Using cmd As New MySqlCommand(outStockQuery, conn)
                        NumOutStockLbl.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0")
                    End Using
                End If
            End Using
        Catch ex As Exception
            Console.WriteLine("KPI Error: " & ex.Message)
        End Try
    End Sub

    'FOR DUMMY DATA
    Private Sub LoadDummyChartData()
        If stockChart Is Nothing Then Exit Sub
        Dim labels As String() = {"In Stock", "Low Stock", "Critical Low", "Out of Stock"}
        Dim values As Double() = {8, 6, 4, 2}
        UpdateChartWithData(labels.ToList(), values.ToList())
    End Sub

    Private Sub LoadDummyInventoryData()
        If InventoryDetailsDVG Is Nothing Then Exit Sub
        InventoryDetailsDVG.Rows.Clear()
        ' Dummy data omitted for brevity
    End Sub

    Private Sub LoadInventoryData()
        If InventoryDetailsDVG Is Nothing Then Exit Sub

        If String.IsNullOrEmpty(CONNECTION_STRING) Then
            LoadDummyInventoryData()
            Return
        End If

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                Dim whereConditions As New List(Of String)
                whereConditions.Add("is_deleted = 0")

                If txtInventorySearchSA IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(txtInventorySearchSA.Text) Then
                    whereConditions.Add("(item_name LIKE @Search OR item_id LIKE @Search OR serial_number LIKE @Search OR status LIKE @Search)")
                End If

                If ComboBox1 IsNot Nothing AndAlso ComboBox1.SelectedIndex > 0 Then
                    Dim selectedStatus As String = ComboBox1.SelectedItem.ToString()
                    Select Case selectedStatus
                        Case "In Stock"
                            whereConditions.Add("current_stock >= reorder_level * 1.5 AND status NOT LIKE 'Deployed%'")
                        Case "Low Stock"
                            whereConditions.Add("(current_stock > reorder_level AND current_stock < reorder_level * 1.5) AND status NOT LIKE 'Deployed%'")
                        Case "Critical Low"
                            whereConditions.Add("(current_stock > 0 AND current_stock <= reorder_level) AND status NOT LIKE 'Deployed%'")
                        Case "Out of Stock"
                            whereConditions.Add("current_stock = 0")
                        Case "Deployed"
                            whereConditions.Add("status LIKE 'Deployed%'")
                        Case Else
                            whereConditions.Add("status = @Status")
                    End Select
                End If

                Dim filterClause As String = ""
                If whereConditions.Count > 0 Then
                    filterClause = " WHERE " & String.Join(" AND ", whereConditions)
                End If

                Dim countQuery As String = "SELECT COUNT(*) FROM inventory" & filterClause
                Using cmd As New MySqlCommand(countQuery, conn)
                    ApplyInventoryParameters(cmd)
                    totalRecords = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                Dim offset As Integer = currentPageIndex * PAGE_SIZE

                ' UPDATED QUERY: Prioritize Deployed status string over Stock Calculation
                Dim query As String = "
                    SELECT item_id, item_name, serial_number, unit_cost, current_stock, technician_name,
                           (unit_cost * current_stock) as total_value,
                           CASE 
                               WHEN status = 'Deployed' THEN 'Deployed'
                               WHEN current_stock >= reorder_level * 1.5 THEN 'In Stock'
                               WHEN current_stock > reorder_level AND current_stock < reorder_level * 1.5 THEN 'Low Stock'
                               WHEN current_stock > 0 AND current_stock <= reorder_level THEN 'Critical Low'
                               WHEN current_stock = 0 THEN 'Out of Stock'
                               ELSE status
                           END as computed_status
                    FROM inventory" & filterClause & "
                    ORDER BY item_name LIMIT @Offset, @Limit"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Offset", offset)
                    cmd.Parameters.AddWithValue("@Limit", PAGE_SIZE)
                    ApplyInventoryParameters(cmd)

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        If Me.InvokeRequired Then
                            Me.Invoke(New Action(Sub() PopulateInventoryGrid(dt)))
                        Else
                            PopulateInventoryGrid(dt)
                        End If
                    End Using
                End Using

                If Me.InvokeRequired Then
                    Me.Invoke(New Action(Sub() UpdatePaginationControls()))
                Else
                    UpdatePaginationControls()
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading inventory: " & ex.Message)
        End Try
    End Sub

    Private Sub ApplyInventoryParameters(cmd As MySqlCommand)
        If txtInventorySearchSA IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(txtInventorySearchSA.Text) Then
            cmd.Parameters.AddWithValue("@Search", "%" & txtInventorySearchSA.Text.Trim() & "%")
        End If

        If ComboBox1 IsNot Nothing AndAlso ComboBox1.SelectedIndex > 0 Then
            Dim selectedStatus As String = ComboBox1.SelectedItem.ToString()
            If Not {"In Stock", "Low Stock", "Critical Low", "Out of Stock", "Deployed"}.Contains(selectedStatus) Then
                cmd.Parameters.AddWithValue("@Status", selectedStatus)
            End If
        End If
    End Sub

    Private Sub PopulateInventoryGrid(dt As DataTable)
        If InventoryDetailsDVG Is Nothing Then Exit Sub
        InventoryDetailsDVG.Rows.Clear()

        For Each row As DataRow In dt.Rows
            Dim index As Integer = InventoryDetailsDVG.Rows.Add()
            Dim dgvRow = InventoryDetailsDVG.Rows(index)

            ' 1. Fill basic details
            If Not row.IsNull("item_id") Then
                ' Convert the database integer to a 5-digit padded string
                dgvRow.Cells("ItemID").Value = Convert.ToInt32(row("item_id")).ToString("D5")
            End If
            dgvRow.Cells("ItemName").Value = row("item_name")
            dgvRow.Cells("SerialNum").Value = row("serial_number")
            dgvRow.Cells("UnitCost").Value = Convert.ToDecimal(row("unit_cost"))
            dgvRow.Cells("CurrentStock").Value = row("current_stock")
            dgvRow.Cells("TotalValue").Value = Convert.ToDecimal(row("total_value"))

            ' 2. ETO YUNG BINAGO: Clean Logic for Status and Technician
            Dim finalStatus As String = row("computed_status").ToString()
            dgvRow.Cells("Status").Value = finalStatus

            ' I-check kung may column na 'Technician' sa DataGridView mo
            If InventoryDetailsDVG.Columns.Contains("Technician") Then
                If finalStatus = "Deployed" Then
                    ' Rekta nating kunin sa database column na 'technician_name'
                    dgvRow.Cells("Technician").Value = If(row("technician_name") IsNot DBNull.Value, row("technician_name").ToString(), "")
                Else
                    ' Linisin ang cell kung hindi naman deployed
                    dgvRow.Cells("Technician").Value = ""
                End If
            End If

            ' 3. Fill buttons/checkboxes
            dgvRow.Cells("colEdit").Value = My.Resources.Resources.edit
            dgvRow.Cells("colDelete").Value = My.Resources.Resources.delete1
            dgvRow.Cells("colCheckBox").Value = False
        Next
    End Sub

    Private Sub RefreshStockData(sender As Object, e As EventArgs)
        RefreshFilters()
    End Sub

    Private Sub RefreshFilters()
        currentPageIndex = 0
        LoadInventoryData()
        LoadKPIData()
        LoadStockChartData()
    End Sub

    'FOR SEARCH
    Private Sub txtInventorySearchSA_TextChanged(sender As Object, e As EventArgs) Handles txtInventorySearchSA.TextChanged
        If searchTimer Is Nothing Then
            searchTimer = New Timer()
            searchTimer.Interval = 500
            AddHandler searchTimer.Tick, AddressOf OnSearchTimerTick
        End If
        searchTimer.Stop()
        searchTimer.Start()
    End Sub

    Private Sub OnSearchTimerTick(sender As Object, e As EventArgs)
        searchTimer.Stop()
        RefreshFilters()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        RefreshFilters()
    End Sub

    Private Sub InventoryDetailsDVG_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles InventoryDetailsDVG.CellClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        Dim dgv As DataGridView = CType(sender, DataGridView)
        Dim selectedRow As DataGridViewRow = dgv.Rows(e.RowIndex)
        Dim columnName As String = dgv.Columns(e.ColumnIndex).Name

        Dim itemId As String = If(selectedRow.Cells("ItemID").Value IsNot Nothing, selectedRow.Cells("ItemID").Value.ToString(), String.Empty)
        Dim itemName As String = If(selectedRow.Cells("ItemName").Value IsNot Nothing, selectedRow.Cells("ItemName").Value.ToString(), "Unknown Item")

        If String.IsNullOrEmpty(itemId) Then
            MessageBox.Show("Invalid Item ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If columnName = "colDelete" Then
            DeleteInventoryItem(itemId, itemName)

        ElseIf columnName = "colEdit" Then
            Using frm As New frmInventoryUpdate()
                frm.InventoryID = itemId
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    RefreshFilters()
                End If
            End Using

        ElseIf columnName = "colCheckBox" Then
            Dim cell As DataGridViewCheckBoxCell = TryCast(selectedRow.Cells("colCheckBox"), DataGridViewCheckBoxCell)
            If cell IsNot Nothing Then
                cell.Value = Not Convert.ToBoolean(cell.Value)
                dgv.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
        End If
    End Sub

    Private Sub EditInventoryItem(itemId As String)
        Try
            MessageBox.Show($"Would edit item ID: {itemId}", "Edit Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RefreshStockData(Nothing, Nothing)
        Catch ex As Exception
            MessageBox.Show($"Error editing item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DeleteInventoryItem(itemId As String, itemName As String)
        Dim result As DialogResult = MessageBox.Show(
        $"Are you sure you want to delete item '{itemName}'?",
        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                Using conn As New MySqlConnection(CONNECTION_STRING)
                    conn.Open()
                    Dim query As String = "UPDATE inventory SET is_deleted = 1 WHERE item_id = @ItemID"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@ItemID", itemId)
                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show($"Item '{itemName}' deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            RefreshFilters()
                        Else
                            MessageBox.Show("Item not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error deleting item: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub HandleItemSelection(row As DataGridViewRow)
        If row.Cells("colCheckBox").Value Is Nothing Then
            row.Cells("colCheckBox").Value = False
        End If
        row.Cells("colCheckBox").Value = Not Convert.ToBoolean(row.Cells("colCheckBox").Value)
    End Sub

    Private Sub btnSelectInventory_Click(sender As Object, e As EventArgs) Handles btnSelectInventory.Click
        If InventoryDetailsDVG Is Nothing Then Exit Sub

        Dim shouldSelect As Boolean = False
        For Each row As DataGridViewRow In InventoryDetailsDVG.Rows
            If Not row.IsNewRow Then
                Dim isChecked As Boolean = False
                If row.Cells("colCheckBox").Value IsNot Nothing Then
                    isChecked = CBool(row.Cells("colCheckBox").Value)
                End If
                If Not isChecked Then
                    shouldSelect = True
                    Exit For
                End If
            End If
        Next

        RemoveHandler InventoryDetailsDVG.CellValueChanged, AddressOf InventoryDetailsDVG_CellValueChanged
        selectedInventoryIds.Clear()

        For Each row As DataGridViewRow In InventoryDetailsDVG.Rows
            If Not row.IsNewRow Then
                row.Cells("colCheckBox").Value = shouldSelect
                If shouldSelect Then
                    Dim idStr As String = If(row.Cells("ItemID").Value IsNot Nothing, row.Cells("ItemID").Value.ToString(), "")
                    If Not String.IsNullOrEmpty(idStr) Then
                        selectedInventoryIds.Add(idStr)
                    End If
                End If
            End If
        Next
        AddHandler InventoryDetailsDVG.CellValueChanged, AddressOf InventoryDetailsDVG_CellValueChanged
    End Sub

    Private Sub InventoryDetailsDVG_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles InventoryDetailsDVG.CurrentCellDirtyStateChanged
        If InventoryDetailsDVG.IsCurrentCellDirty Then
            InventoryDetailsDVG.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub InventoryDetailsDVG_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles InventoryDetailsDVG.CellValueChanged
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        If InventoryDetailsDVG.Columns(e.ColumnIndex).Name = "colCheckBox" Then
            Dim row As DataGridViewRow = InventoryDetailsDVG.Rows(e.RowIndex)
            Dim idStr As String = ""
            If row.Cells("ItemID").Value IsNot Nothing Then
                idStr = row.Cells("ItemID").Value.ToString()
            End If

            Dim isChecked As Boolean = False
            If row.Cells("colCheckBox").Value IsNot Nothing Then
                isChecked = CBool(row.Cells("colCheckBox").Value)
            End If

            If isChecked Then
                If Not String.IsNullOrEmpty(idStr) AndAlso Not selectedInventoryIds.Contains(idStr) Then
                    selectedInventoryIds.Add(idStr)
                End If
            Else
                selectedInventoryIds.Remove(idStr)
            End If
        End If
    End Sub

    Private Sub ForceRefreshAllData()
        InventoryDetailsDVG.Rows.Clear()
        currentPageIndex = 0
        LoadInventoryData()
        LoadStockChartData()
        LoadStockChartFromDatabase()
        LoadKPIData()
        If InventoryDetailsDVG.Rows.Count > 0 Then
            InventoryDetailsDVG.FirstDisplayedScrollingRowIndex = 0
        End If
        InventoryDetailsDVG.Refresh()
    End Sub

    Private Sub btnAddInventory_Click(sender As Object, e As EventArgs) Handles btnAddInventory.Click
        Using frmInventoryCreate As New frmInventoryCreate()
            Dim result As DialogResult = frmInventoryCreate.ShowDialog()
            If result = DialogResult.OK Then
                ForceRefreshAllData()
                MessageBox.Show("Service created successfully! The new service will appear at the top of the list.",
                              "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    'FOR PAGING
    Private Sub btnNextInventSA_Click(sender As Object, e As EventArgs) Handles btnNextInventSA.Click
        Dim totalPages As Integer = CInt(Math.Ceiling(totalRecords / PAGE_SIZE))
        If currentPageIndex < totalPages - 1 Then
            currentPageIndex += 1
            LoadInventoryData()
        End If
    End Sub

    Private Sub btnInventPreviousSA_Click(sender As Object, e As EventArgs) Handles btnInventPreviousSA.Click
        If currentPageIndex > 0 Then
            currentPageIndex -= 1
            LoadInventoryData()
        End If
    End Sub

    Private Sub UpdatePaginationControls()
        If btnInventPreviousSA Is Nothing Or btnNextInventSA Is Nothing Then Exit Sub
        Dim totalPages As Integer = CInt(Math.Ceiling(totalRecords / PAGE_SIZE))
        btnInventPreviousSA.Enabled = currentPageIndex > 0
        btnInventPreviousSA.Visible = currentPageIndex > 0
        btnNextInventSA.Enabled = currentPageIndex < totalPages - 1

        If LblPageInfo IsNot Nothing Then
            If totalRecords > 0 Then
                LblPageInfo.Text = $"Page {currentPageIndex + 1} of {totalPages} (Total: {totalRecords})"
            Else
                LblPageInfo.Text = "No Records Found"
            End If
        End If
    End Sub

    'FOR FILTERS
    Private Sub PopulateDropdowns()
        If ComboBox1 Is Nothing Then Exit Sub
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("All Status")
        ComboBox1.Items.AddRange(New String() {"In Stock", "Low Stock", "Critical Low", "Out of Stock", "Deployed"})
        ComboBox1.SelectedIndex = 0
    End Sub

    Protected Overrides Sub OnHandleDestroyed(e As EventArgs)
        If refreshTimer IsNot Nothing Then
            refreshTimer.Stop()
            refreshTimer.Dispose()
        End If
        If searchTimer IsNot Nothing Then
            searchTimer.Stop()
            searchTimer.Dispose()
        End If
        MyBase.OnHandleDestroyed(e)
    End Sub

    'FOR EXPORT
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim exportForm As New SAInventoryExport()
        exportForm.ShowDialog()
    End Sub

    'FOR BULK DELETE
    Private Sub deleteAll_Click(sender As Object, e As EventArgs) Handles deleteAll.Click
        If selectedInventoryIds.Count = 0 Then
            MessageBox.Show("Please select at least one item to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete the {selectedInventoryIds.Count} selected item(s)?" & vbCrLf &
                                                 "These items will be moved to the archive.",
                                                 "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Using conn As New MySqlConnection(CONNECTION_STRING)
                Try
                    conn.Open()
                    Dim paramNames As New List(Of String)
                    For i As Integer = 0 To selectedInventoryIds.Count - 1
                        paramNames.Add("@id" & i)
                    Next
                    Dim inClause As String = String.Join(",", paramNames)
                    Dim query As String = $"UPDATE inventory SET is_deleted = 1 WHERE item_id IN ({inClause})"

                    Using cmd As New MySqlCommand(query, conn)
                        For i As Integer = 0 To selectedInventoryIds.Count - 1
                            cmd.Parameters.AddWithValue("@id" & i, selectedInventoryIds(i))
                        Next
                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                        MessageBox.Show($"{rowsAffected} item(s) successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        selectedInventoryIds.Clear()
                        ForceRefreshAllData()
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error deleting records: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End If
    End Sub

    ' --- CONNECT TO frmDeploy (Corrected Logic) ---
    Private Sub btnDeploy_Click(sender As Object, e As EventArgs) Handles btnDeploy.Click
        ' 1. Gather Selected IDs
        Dim itemsToProcess As List(Of String) = selectedInventoryIds.ToList()

        If itemsToProcess.Count = 0 AndAlso InventoryDetailsDVG.SelectedRows.Count > 0 Then
            Dim id As String = InventoryDetailsDVG.SelectedRows(0).Cells("ItemID").Value.ToString()
            itemsToProcess.Add(id)
        End If

        If itemsToProcess.Count = 0 Then
            MessageBox.Show("Please select items to deploy.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ' 2. Open the Deployment Form
        Using frm As New frmDeploy()
            ' Pass the IDs to the form property
            frm.ItemIDsToDeploy = itemsToProcess

            ' Show the form and wait for result
            If frm.ShowDialog() = DialogResult.OK Then
                ' 3. Refresh Grid if successful
                selectedInventoryIds.Clear()
                RefreshFilters()
            End If
        End Using
    End Sub

End Class