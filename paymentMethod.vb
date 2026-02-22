Imports MySqlConnector

Public Class paymentMethod

    ' Database Connection String
    Private ReadOnly CONNECTION_STRING As String = "Server=127.0.0.1;Port=3306;Database=sparx;User ID=root;Password=;SslMode=Preferred;"

    ' Properties from BillingView
    Public Property PayID As Integer
    Public Property CustName As String
    Public Property PlanType As String
    Public Property MonthlyRate As String
    Public Property AmountToPay As String
    Public Property BillStatus As String
    Public Property PaymentDate As String
    Public Property PaymentMethod As String

    Private Sub paymentMethod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Populate existing TextBoxes
        txtPaymentID.Text = PayID.ToString()
        txtName.Text = CustName
        txtPlanType.Text = PlanType
        txtMonthlyRate.Text = MonthlyRate
        txtAmountPaid.Text = AmountToPay
        txtStatus.Text = BillStatus

        ' 2. --- NEW: FETCH ADDRESS FROM DATABASE ---
        ' Since BillingView doesn't have the address, we query it here using the PayID or Name.
        FetchAndShowAddress()

        ' 3. Set Date
        If Not String.IsNullOrEmpty(PaymentDate) AndAlso IsDate(PaymentDate) Then
            DateTimePicker1.Value = Date.Parse(PaymentDate)
        Else
            DateTimePicker1.Value = Date.Now
        End If

        ' 4. Populate Dropdown
        cbModeofPayment.Items.Clear()
        cbModeofPayment.Items.AddRange(New String() {"Gcash", "Walk-in"})

        If Not String.IsNullOrEmpty(PaymentMethod) AndAlso cbModeofPayment.Items.Contains(PaymentMethod) Then
            cbModeofPayment.SelectedItem = PaymentMethod
        Else
            cbModeofPayment.SelectedIndex = 0
        End If
    End Sub

    ' --- HELPER SUB TO GET ADDRESS ---

    Private Sub FetchAndShowAddress()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                ' UPDATED QUERY: Uses 'customer_data' table
                ' Assumes both tables are linked by 'customer_id'
                Dim query As String = "SELECT c.purok, c.barangay, c.municipality, c.province " &
                                      "FROM customer_data c " &
                                      "JOIN payment p ON c.customer_id = p.customer_id " &
                                      "WHERE p.payment_id = @pid"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@pid", PayID)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Use .ToString() to handle potential NULL values safely
                            Dim purok As String = reader("purok").ToString()
                            Dim brgy As String = reader("barangay").ToString()
                            Dim muni As String = reader("municipality").ToString()
                            Dim prov As String = reader("province").ToString()

                            ' Concatenate
                            TxtBoxAddress.Text = $"{purok}, {brgy}, {muni}, {prov}"
                        Else
                            TxtBoxAddress.Text = "Address not found in database"
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' If it still fails, this MessageBox will tell you EXACTLY why (e.g. "Unknown column 'customer_id'")
            MessageBox.Show("Error details: " & ex.Message)
            TxtBoxAddress.Text = "Error loading address"
        End Try
    End Sub

    ' This is the "Pay" or "Update" button logic
    Private Sub LblUpdate_Click(sender As Object, e As EventArgs) Handles LblPayment.Click
        ' 1. Validate Input
        If String.IsNullOrWhiteSpace(cbModeofPayment.Text) Then
            MessageBox.Show("Please select a Mode of Payment.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 2. Confirm Payment
        If MessageBox.Show("Are you sure you want to mark this record as PAID?", "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Using conn As New MySqlConnection(CONNECTION_STRING)
                    conn.Open()

                    ' Update Query: Sets Date to NOW and updates Payment Method
                    Dim query As String = "UPDATE payment SET date_of_payment = @date, payment_method = @method WHERE payment_id = @id"

                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@date", DateTimePicker1.Value) ' Use selected date
                        cmd.Parameters.AddWithValue("@method", cbModeofPayment.Text)
                        cmd.Parameters.AddWithValue("@id", PayID)

                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show("Payment successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.DialogResult = DialogResult.OK ' Tell parent form update was successful
                            Me.Close()
                        Else
                            MessageBox.Show("Payment record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' 1. Validation
        If String.IsNullOrWhiteSpace(cbModeofPayment.Text) Then
            MessageBox.Show("Please select a Mode of Payment.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 2. Convert "Walk-in" to "walk_in" for the database
        Dim methodToSave As String = cbModeofPayment.Text

        ' FIX: Check if we need to convert the string format
        If methodToSave = "Walk-in" Then
            methodToSave = "walk_in"
        End If

        If MessageBox.Show("Save changes to this payment?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Using conn As New MySqlConnection(CONNECTION_STRING)
                    conn.Open()

                    ' Update Query
                    Dim query As String = "UPDATE payment SET date_of_payment = @payDate, payment_method = @method WHERE payment_id = @id"

                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@payDate", DateTimePicker1.Value)

                        ' Use the converted variable 'methodToSave', NOT cbModeofPayment.Text
                        cmd.Parameters.AddWithValue("@method", methodToSave)

                        cmd.Parameters.AddWithValue("@id", PayID)

                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.DialogResult = DialogResult.OK
                            Me.Close()
                        Else
                            MessageBox.Show("Error: Payment ID not found.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' --- CANCEL BUTTON ---
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Just close the form. No changes saved.
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TxtBoxAddress_TextChanged(sender As Object, e As EventArgs) Handles TxtBoxAddress.TextChanged

    End Sub
End Class