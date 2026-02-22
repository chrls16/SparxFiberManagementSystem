Imports MySqlConnector
Imports System.Configuration

Public Class frmDeploy

    ' --- CUSTOM CLASS TO HOLD DATA IN MEMORY ---
    Private Class DeployItem
        Public Property ItemID As String
        Public Property Name As String
        Public Property MaxStock As Integer
        Public Property DeployQty As Integer

        Public Overrides Function ToString() As String
            Return $"{Name} (Qty: {DeployQty})"
        End Function
    End Class

    ' --- PROPERTIES ---
    Public Property ItemIDsToDeploy As List(Of String)
    Public Property SelectedTechnician As String = ""
    Private DeploymentList As New List(Of DeployItem)

    Private ReadOnly Property CONNECTION_STRING As String
        Get
            Return ConfigurationManager.ConnectionStrings("SparxDb")?.ConnectionString
        End Get
    End Property

    ' --- 1. SETUP ---
    Private Sub frmDeploy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupTechnicianSearch()
        LoadItemsToMemory()
        numQty.Enabled = False
        btnRemove.Enabled = False
        LblCuurentStock.Text = "Max Stock: -"
    End Sub

    Private Sub SetupTechnicianSearch()
        txtTechSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtTechSearch.AutoCompleteSource = AutoCompleteSource.CustomSource
        Dim suggestions As New AutoCompleteStringCollection()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT CONCAT(first_name, ' ', last_name) as fullname FROM staff WHERE is_deleted = 0", conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            suggestions.Add(reader("fullname").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
        End Try
        txtTechSearch.AutoCompleteCustomSource = suggestions
    End Sub

    Private Sub LoadItemsToMemory()
        If ItemIDsToDeploy Is Nothing OrElse ItemIDsToDeploy.Count = 0 Then Return
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Dim ids As String = String.Join("','", ItemIDsToDeploy)
                Dim query As String = $"SELECT item_id, item_name, current_stock FROM inventory WHERE item_id IN ('{ids}')"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim item As New DeployItem With {
                                .ItemID = reader("item_id").ToString(),
                                .Name = reader("item_name").ToString(),
                                .MaxStock = Convert.ToInt32(reader("current_stock")),
                                .DeployQty = 1
                            }
                            DeploymentList.Add(item)
                        End While
                    End Using
                End Using
            End Using
            RefreshListBox()
        Catch ex As Exception
            MessageBox.Show("Error loading items: " & ex.Message)
        End Try
    End Sub

    Private Sub RefreshListBox()
        lstItems.Items.Clear()
        For Each item In DeploymentList
            lstItems.Items.Add(item)
        Next
    End Sub

    ' --- 2. INTERACTION ---
    Private Sub lstItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstItems.SelectedIndexChanged
        If lstItems.SelectedIndex = -1 Then
            numQty.Enabled = False
            btnRemove.Enabled = False
            LblCuurentStock.Text = "Max Stock: -"
            Return
        End If
        numQty.Enabled = True
        btnRemove.Enabled = True
        Dim selectedItem As DeployItem = CType(lstItems.SelectedItem, DeployItem)
        LblCuurentStock.Text = $"Max Stock: {selectedItem.MaxStock}"
        numQty.Maximum = If(selectedItem.MaxStock > 0, selectedItem.MaxStock, 1)
        numQty.Minimum = 1
        numQty.Value = selectedItem.DeployQty
    End Sub

    Private Sub numQty_ValueChanged(sender As Object, e As EventArgs) Handles numQty.ValueChanged
        If lstItems.SelectedIndex = -1 Then Return
        Dim selectedItem As DeployItem = CType(lstItems.SelectedItem, DeployItem)
        selectedItem.DeployQty = CInt(numQty.Value)
        Dim index As Integer = lstItems.SelectedIndex
        lstItems.Items(index) = lstItems.Items(index)
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If lstItems.SelectedIndex = -1 Then Return
        Dim selectedItem As DeployItem = CType(lstItems.SelectedItem, DeployItem)
        DeploymentList.Remove(selectedItem)
        RefreshListBox()
        numQty.Enabled = False
        btnRemove.Enabled = False
    End Sub

    ' --- 3. EXECUTE DEPLOYMENT (THE FIX IS HERE) ---
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If String.IsNullOrWhiteSpace(txtTechSearch.Text) Then
            MessageBox.Show("Please enter a Technician Name.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If DeploymentList.Count = 0 Then
            MessageBox.Show("No items to deploy.", "Empty List")
            Return
        End If

        SelectedTechnician = txtTechSearch.Text.Trim()
        ProcessDeployment()
    End Sub

    Private Sub ProcessDeployment()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                For Each item As DeployItem In DeploymentList
                    If item.DeployQty > 0 Then
                        If item.DeployQty >= item.MaxStock Then
                            ' SCENARIO A: FULL MOVE - I-update ang status at tech name
                            Dim moveSql As String = "UPDATE inventory SET status = 'Deployed', technician_name = @Tech, current_stock = @Qty WHERE item_id = @ID"
                            Using cmdMove As New MySqlCommand(moveSql, conn)
                                cmdMove.Parameters.AddWithValue("@Tech", SelectedTechnician)
                                cmdMove.Parameters.AddWithValue("@Qty", item.DeployQty)
                                cmdMove.Parameters.AddWithValue("@ID", item.ItemID)
                                cmdMove.ExecuteNonQuery()
                            End Using
                        Else
                            ' SCENARIO B: PARTIAL SPLIT
                            ' 1. Bawasan ang warehouse stock (itira ang hindi deployed)
                            Dim updateSql As String = "UPDATE inventory SET current_stock = current_stock - @Qty WHERE item_id = @ID"
                            Using cmdUpdate As New MySqlCommand(updateSql, conn)
                                cmdUpdate.Parameters.AddWithValue("@Qty", item.DeployQty)
                                cmdUpdate.Parameters.AddWithValue("@ID", item.ItemID)
                                cmdUpdate.ExecuteNonQuery()
                            End Using

                            ' 2. Mag-insert ng bagong row para sa Deployed part
                            Dim insertSql As String = "INSERT INTO inventory (item_name, brand, serial_number, current_stock, unit_cost, status, technician_name) " &
                                                 "SELECT item_name, brand, CONCAT(serial_number, '-DEP-', FLOOR(RAND()*10000)), @Qty, unit_cost, 'Deployed', @Tech " &
                                                 "FROM inventory WHERE item_id = @ID"
                            Using cmdInsert As New MySqlCommand(insertSql, conn)
                                cmdInsert.Parameters.AddWithValue("@Qty", item.DeployQty)
                                cmdInsert.Parameters.AddWithValue("@Tech", SelectedTechnician)
                                cmdInsert.Parameters.AddWithValue("@ID", item.ItemID)
                                cmdInsert.ExecuteNonQuery()
                            End Using
                        End If
                    End If
                Next
            End Using

            MessageBox.Show($"Successfully deployed items!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ' Unused Stubs
    Private Sub txtTechSearch_TextChanged(sender As Object, e As EventArgs) Handles txtTechSearch.TextChanged
    End Sub
    Private Sub LblCuurentStock_Click(sender As Object, e As EventArgs) Handles LblCuurentStock.Click
    End Sub

End Class