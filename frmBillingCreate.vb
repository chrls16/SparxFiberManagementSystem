Imports MySqlConnector
Imports System.Configuration

Public Class frmBillingCreate
    Private _connectionString As String = Nothing
    Private ReadOnly Property CONNECTION_STRING As String
        Get
            If _connectionString Is Nothing AndAlso Not DesignMode Then
                Try
                    _connectionString = ConfigurationManager.ConnectionStrings("SparxDb").ConnectionString
                Catch
                    _connectionString = String.Empty
                End Try
            End If
            Return If(_connectionString IsNot Nothing, _connectionString, String.Empty)
        End Get
    End Property

    Private Sub frmBillingCreate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CreateDummyPayment()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                ' Get a random active customer
                Dim customerQuery As String = "SELECT customer_id FROM customer WHERE account_status = 'Active' ORDER BY RAND() LIMIT 1"
                Dim customerId As Integer = 0
                Using cmd As New MySqlCommand(customerQuery, conn)
                    customerId = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                If customerId > 0 Then
                    Dim query As String = "INSERT INTO payment (customer_id, staff_id, billing_type) 
                                          VALUES (@CustomerId, 1, 'plan_type')"

                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@CustomerId", customerId)
                        cmd.ExecuteNonQuery()

                        MessageBox.Show("New billing record created for customer ID: " & customerId,
                                      "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.DialogResult = DialogResult.OK
                    End Using
                Else
                    MessageBox.Show("No active customers found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.DialogResult = DialogResult.Cancel
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error creating billing record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = DialogResult.Cancel
        End Try

        Me.Close()
    End Sub
End Class