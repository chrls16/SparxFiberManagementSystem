Imports MySqlConnector
Imports System.Configuration

Public Class frmInventoryUpdate
    ' Property to receive the ID from the main view
    Public Property InventoryID As String

    ' Connection String
    Private ReadOnly Property CONNECTION_STRING As String
        Get
            Return ConfigurationManager.ConnectionStrings("SparxDb")?.ConnectionString
        End Get
    End Property

    Private Sub frmInventoryUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the title
        Me.Text = $"Update Item #{InventoryID}"

        ' 1. First, populate the dropdown lists from the database
        PopulateDropdownLists()

        ' 2. Then, load the specific data for this item
        LoadItemDetails()
    End Sub

    ' New method to fill the ComboBox lists with existing data from the database
    Private Sub PopulateDropdownLists()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                ' Get distinct Item Names
                Dim nameQuery As String = "SELECT DISTINCT item_name FROM inventory ORDER BY item_name"
                Using cmd As New MySqlCommand(nameQuery, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        comboItemName.Items.Clear()
                        While reader.Read()
                            If Not IsDBNull(reader("item_name")) Then
                                comboItemName.Items.Add(reader("item_name").ToString())
                            End If
                        End While
                    End Using
                End Using

                ' Get distinct Service Types
                Dim typeQuery As String = "SELECT DISTINCT service_type FROM inventory ORDER BY service_type"
                Using cmd As New MySqlCommand(typeQuery, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        cbServiceType.Items.Clear()
                        While reader.Read()
                            If Not IsDBNull(reader("service_type")) Then
                                cbServiceType.Items.Add(reader("service_type").ToString())
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Silently fail on dropdown population or log to console
            Console.WriteLine("Error populating dropdowns: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadItemDetails()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Dim query As String = "SELECT * FROM inventory WHERE item_id = @ID"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ID", InventoryID)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Populate ID (Read Only)
                            txtItemID.Text = reader("item_id").ToString()

                            ' Populate Brand
                            If HasColumn(reader, "brand") Then
                                txtBrand.Text = reader("brand").ToString()
                            End If

                            ' Populate Item Name (into the ComboBox Text property)
                            comboItemName.Text = reader("item_name").ToString()

                            ' Populate Serial Number
                            txtSerialNo.Text = reader("serial_number").ToString()

                            ' Populate Service Type
                            ' This ensures we get the value from the database into the box
                            If HasColumn(reader, "service_type") Then
                                cbServiceType.Text = reader("service_type").ToString()
                            End If

                            ' Populate Date (if you want to show it)
                            ' If HasColumn(reader, "date_added") AndAlso Not IsDBNull(reader("date_added")) Then
                            '    DateTimePicker1.Value = Convert.ToDateTime(reader("date_added"))
                            ' End If

                            ' Populate Status
                            If HasColumn(reader, "status") Then
                                comboStatus.Text = reader("status").ToString()
                            End If
                            If HasColumn(reader, "technician") Then
                                txtTechSearch.Text = reader("technician").ToString()
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading item details: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    ' Helper function to safely check for columns
    Private Function HasColumn(reader As MySqlDataReader, columnName As String) As Boolean
        Try
            reader.GetOrdinal(columnName)
            Return True
        Catch
            Return False
        End Try
    End Function

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If Not ValidateInputs() Then Return

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()


                Dim query As String = "UPDATE inventory SET " &
                                  "item_name = @Name, " &
                                  "brand = @Brand, " &
                                  "serial_number = @Serial, " &
                                  "status = @Status, " &
                                  "technician = @Technician " &
                                  "WHERE item_id = @ID"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Name", comboItemName.Text.Trim())
                    cmd.Parameters.AddWithValue("@Brand", txtBrand.Text.Trim())
                    cmd.Parameters.AddWithValue("@Serial", txtSerialNo.Text.Trim())
                    cmd.Parameters.AddWithValue("@Status", comboStatus.Text)
                    cmd.Parameters.AddWithValue("@Technician", txtTechSearch.Text.Trim())
                    cmd.Parameters.AddWithValue("@ID", InventoryID)

                    Dim rows As Integer = cmd.ExecuteNonQuery()

                    If rows > 0 Then
                        MessageBox.Show("Inventory item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' This is where the "Unknown column" error is caught
            MessageBox.Show($"Error updating item: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(comboItemName.Text) Then
            MessageBox.Show("Item Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtTechSearch_TextChanged(sender As Object, e As EventArgs) Handles txtTechSearch.TextChanged
        Dim searchText As String = txtTechSearch.Text.Trim()

        ' Only search if the user has typed at least 2 characters
        If searchText.Length < 2 Then Return

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                ' SQL using CONCAT to allow searching by the full name
                Dim query As String = "SELECT first_name, last_name FROM employees " &
                                 "WHERE (first_name LIKE @search " &
                                 "OR last_name LIKE @search " &
                                 "OR CONCAT(first_name, ' ', last_name) LIKE @search) " &
                                 "AND department = 'Technical'"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@search", "%" & searchText & "%")

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim dataRows As New AutoCompleteStringCollection()

                        While reader.Read()
                            ' Combine the names for the suggestion list
                            Dim fullName As String = reader("first_name").ToString() & " " & reader("last_name").ToString()
                            dataRows.Add(fullName)
                        End While

                        ' Update the TextBox AutoComplete source
                        txtTechSearch.AutoCompleteCustomSource = dataRows
                    End Using
                End Using
            End Using

        Catch ex As Exception
            ' Log error to console for debugging
            Console.WriteLine("Search error: " & ex.Message)
        End Try
    End Sub

    Private Sub comboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboStatus.SelectedIndexChanged
        ' If item is "In Stock", clear and disable the Technician search box
        If comboStatus.Text = "In Stock" Then
            txtTechSearch.Text = ""
            txtTechSearch.Enabled = False
        Else
            ' Enable technician assignment for "Assigned" or "Under Repair"
            txtTechSearch.Enabled = True
        End If
    End Sub
End Class