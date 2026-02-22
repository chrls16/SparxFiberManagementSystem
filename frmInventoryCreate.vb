Imports MySqlConnector
Imports System.Configuration

Public Class frmInventoryCreate

    ' --- 1. CONNECTION CONFIGURATION ---
    Private ReadOnly Property CONNECTION_STRING As String
        Get
            If ConfigurationManager.ConnectionStrings("SparxDb") IsNot Nothing Then
                Return ConfigurationManager.ConnectionStrings("SparxDb").ConnectionString
            End If
            Return String.Empty
        End Get
    End Property

    ' --- 2. FORM LOAD EVENT ---
    Private Sub frmInventoryCreate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configure Item Name AutoComplete
        textItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        textItemName.AutoCompleteSource = AutoCompleteSource.CustomSource
        PopulateItemNameSuggestions()


    End Sub

    ' --- 3. HELPER TO POPULATE SUGGESTIONS ---
    Private Sub PopulateItemNameSuggestions()
        Try
            Dim suggestions As New AutoCompleteStringCollection()
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Dim query As String = "SELECT DISTINCT item_name FROM inventory ORDER BY item_name"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            If Not IsDBNull(reader("item_name")) Then
                                suggestions.Add(reader("item_name").ToString())
                            End If
                        End While
                    End Using
                End Using
            End Using
            textItemName.AutoCompleteCustomSource = suggestions
        Catch ex As Exception
            Console.WriteLine("Error loading suggestions: " & ex.Message)
        End Try
    End Sub

    ' --- 4. CREATE BUTTON LOGIC ---
    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        If Not ValidateForm() Then Return

        If SaveInventoryItem() Then
            MessageBox.Show("New inventory item created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    ' --- 5. VALIDATION LOGIC ---
    Private Function ValidateForm() As Boolean
        If String.IsNullOrWhiteSpace(textItemName.Text) Then
            MessageBox.Show("Please enter an Item Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtBrand.Text) Then
            MessageBox.Show("Please enter a Brand.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtSerialNo.Text) Then
            MessageBox.Show("Please enter a Serial Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtStock.Text) OrElse Not IsNumeric(txtStock.Text) Then
            MessageBox.Show("Please enter a valid numeric Stock quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtUnitCost.Text) OrElse Not IsNumeric(txtUnitCost.Text) Then
            MessageBox.Show("Please enter a valid numeric Unit Cost.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If


        Return True
    End Function

    ' --- 6. SAVE LOGIC (Updated for Status and Date) ---
    Private Function SaveInventoryItem() As Boolean
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                ' 1. REAL LIFE CHECK: Do we already have this item in stock?
                ' We match by Item Name AND Brand to be sure.
                Dim checkQuery As String = "SELECT item_id, current_stock FROM inventory WHERE item_name = @Name AND brand = @Brand AND status = 'In Stock' LIMIT 1"

                Dim existingID As Integer = 0
                Dim currentStock As Integer = 0

                Using cmdCheck As New MySqlCommand(checkQuery, conn)
                    cmdCheck.Parameters.AddWithValue("@Name", textItemName.Text.Trim())
                    cmdCheck.Parameters.AddWithValue("@Brand", txtBrand.Text.Trim())

                    Using reader As MySqlDataReader = cmdCheck.ExecuteReader()
                        If reader.Read() Then
                            existingID = Convert.ToInt32(reader("item_id"))
                            currentStock = Convert.ToInt32(reader("current_stock"))
                        End If
                    End Using
                End Using

                ' 2. DECISION: Update existing pile OR Create new pile
                If existingID > 0 Then
                    ' RESTOCK MODE: The item exists! Just add the new count to the shelf.
                    Dim newStock As Integer = Convert.ToInt32(txtStock.Text.Trim())
                    Dim msgResult As DialogResult = MessageBox.Show($"Item '{textItemName.Text}' already exists with {currentStock} in stock." & vbCrLf &
                                                              $"Do you want to add these {newStock} items to the existing stock?",
                                                              "Restock Detected", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    If msgResult = DialogResult.Yes Then
                        Dim updateQuery As String = "UPDATE inventory SET current_stock = current_stock + @AddedStock WHERE item_id = @ID"
                        Using cmdUpdate As New MySqlCommand(updateQuery, conn)
                            cmdUpdate.Parameters.AddWithValue("@AddedStock", newStock)
                            cmdUpdate.Parameters.AddWithValue("@ID", existingID)
                            cmdUpdate.ExecuteNonQuery()
                        End Using
                        Return True
                    End If
                    ' If they say No, code flows down to INSERT (creating a separate batch)
                End If

                ' 3. INSERT MODE (New Item or separate batch)
                Dim insertQuery As String = "INSERT INTO inventory (item_name, brand, serial_number, current_stock, unit_cost, status) " &
                                        "VALUES (@Name, @Brand, @Serial, @Stock, @Cost, @Status)"

                Using cmd As New MySqlCommand(insertQuery, conn)
                    cmd.Parameters.AddWithValue("@Name", textItemName.Text.Trim())
                    cmd.Parameters.AddWithValue("@Brand", txtBrand.Text.Trim())
                    cmd.Parameters.AddWithValue("@Serial", txtSerialNo.Text.Trim())
                    cmd.Parameters.AddWithValue("@Stock", Convert.ToInt32(txtStock.Text.Trim()))
                    cmd.Parameters.AddWithValue("@Cost", Convert.ToDecimal(txtUnitCost.Text.Trim()))
                    cmd.Parameters.AddWithValue("@Status", "In Stock") ' Always In Stock when created
                    cmd.ExecuteNonQuery()
                End Using

            End Using

            Return True

        Catch ex As Exception
            MessageBox.Show($"Error saving item: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' --- 7. EVENT HANDLERS ---
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtStock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStock.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtUnitCost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUnitCost.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If
        If e.KeyChar = "."c AndAlso (DirectCast(sender, TextBox).Text.IndexOf("."c) > -1) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtStat_TextChanged(sender As Object, e As EventArgs) Handles TxtStat.TextChanged

    End Sub
End Class