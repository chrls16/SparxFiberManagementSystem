Imports MySqlConnector
Imports System.Configuration

Public Class frmSubscriberUpdate

    Public Property SubscriberID As Integer = -1

    Private ReadOnly Property CONNECTION_STRING As String
        Get
            Return ConfigurationManager.ConnectionStrings("SparxDb").ConnectionString
        End Get
    End Property

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub frmSubscriberUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateDropdowns()
        If SubscriberID > 0 Then
            LoadDataFromDatabase(SubscriberID)
        Else
            MessageBox.Show("No Subscriber ID provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
    End Sub

    Private Sub PopulateDropdowns()
        Me.DropDownPlanType.Items.Clear()
        Me.DropDownPlanType.Items.AddRange(New String() {"Basic 25Mbps", "Standard 50Mbps", "Premium 100Mbps"})
        Me.DropDownStatus.Items.Clear()
        Me.DropDownStatus.Items.AddRange(New String() {"Active", "Suspended", "Cancelled"})
    End Sub

    Private Sub LoadDataFromDatabase(id As Integer)
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                ' --- UPDATED TABLE NAME ---
                Dim query As String = "SELECT * FROM customer_data WHERE customer_id = @id"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", id)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            txtID.Text = reader("customer_id").ToString()
                            txtName.Text = reader("first_name").ToString() & " " & reader("last_name").ToString()

                            txtContactNumber.Text = If(IsDBNull(reader("contact_number")), "", reader("contact_number").ToString())
                            txtEmailAddress.Text = If(IsDBNull(reader("email_address")), "", reader("email_address").ToString())

                            txtLandmark.Text = If(IsDBNull(reader("landmark")), "", reader("landmark").ToString())
                            txtPurok.Text = If(IsDBNull(reader("purok")), "", reader("purok").ToString())
                            txtBarangay.Text = If(IsDBNull(reader("barangay")), "", reader("barangay").ToString())
                            txtMunicipality.Text = If(IsDBNull(reader("municipality")), "", reader("municipality").ToString())
                            txtProvince.Text = If(IsDBNull(reader("province")), "", reader("province").ToString())

                            If Not IsDBNull(reader("date_installed")) Then
                                DateTimePicker1.Value = Convert.ToDateTime(reader("date_installed"))
                            End If

                            Dim dbPlan As String = If(IsDBNull(reader("plan_type")), "", reader("plan_type").ToString())
                            DropDownPlanType.Text = GetDisplayPlanType(dbPlan)

                            Dim dbStatus As String = If(IsDBNull(reader("account_status")), "", reader("account_status").ToString())
                            DropDownStatus.Text = dbStatus

                            If Not IsDBNull(reader("monthly_rate")) Then
                                txtMonthlyRate.Text = Convert.ToDecimal(reader("monthly_rate")).ToString("C2")
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetDisplayPlanType(databasePlan As String) As String
        Select Case databasePlan
            Case "Basic" : Return "Basic 25Mbps"
            Case "Standard" : Return "Standard 50Mbps"
            Case "Premium" : Return "Premium 100Mbps"
            Case Else : Return databasePlan
        End Select
    End Function

    Private Function GetDatabasePlanType(displayPlan As String) As String
        Select Case displayPlan
            Case "Basic 25Mbps" : Return "Basic"
            Case "Standard 50Mbps" : Return "Standard"
            Case "Premium 100Mbps" : Return "Premium"
            Case Else : Return displayPlan
        End Select
    End Function

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                ' --- UPDATED TABLE NAME ---
                Dim query As String = "UPDATE customer_data SET " &
                                      "first_name=@fname, last_name=@lname, " &
                                      "contact_number=@contact, email_address=@email, " &
                                      "landmark=@landmark, purok=@purok, barangay=@brgy, municipality=@muni, province=@prov, " &
                                      "plan_type=@plan, account_status=@status, monthly_rate=@rate, date_installed=@date " &
                                      "WHERE customer_id=@id"

                Using cmd As New MySqlCommand(query, conn)
                    Dim fullName As String = txtName.Text.Trim()
                    Dim spaceIndex As Integer = fullName.LastIndexOf(" "c)
                    Dim fname As String = If(spaceIndex > 0, fullName.Substring(0, spaceIndex), fullName)
                    Dim lname As String = If(spaceIndex > 0, fullName.Substring(spaceIndex + 1), "")

                    cmd.Parameters.AddWithValue("@id", SubscriberID)
                    cmd.Parameters.AddWithValue("@fname", fname)
                    cmd.Parameters.AddWithValue("@lname", lname)
                    cmd.Parameters.AddWithValue("@contact", txtContactNumber.Text)
                    cmd.Parameters.AddWithValue("@email", txtEmailAddress.Text)
                    cmd.Parameters.AddWithValue("@landmark", txtLandmark.Text)
                    cmd.Parameters.AddWithValue("@purok", txtPurok.Text)
                    cmd.Parameters.AddWithValue("@brgy", txtBarangay.Text)
                    cmd.Parameters.AddWithValue("@muni", txtMunicipality.Text)
                    cmd.Parameters.AddWithValue("@prov", txtProvince.Text)
                    cmd.Parameters.AddWithValue("@plan", GetDatabasePlanType(DropDownPlanType.Text))
                    cmd.Parameters.AddWithValue("@status", DropDownStatus.Text)

                    Dim cleanRate As String = txtMonthlyRate.Text.Replace("₱", "").Replace(",", "").Trim()
                    cmd.Parameters.AddWithValue("@rate", Convert.ToDecimal(cleanRate))

                    cmd.Parameters.AddWithValue("@date", DateTimePicker1.Value)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Subscriber updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Update failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DropDownPlanType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownPlanType.SelectedIndexChanged
        Select Case DropDownPlanType.Text
            Case "Basic 25Mbps" : txtMonthlyRate.Text = "700.00"
            Case "Standard 50Mbps" : txtMonthlyRate.Text = "1000.00"
            Case "Premium 100Mbps" : txtMonthlyRate.Text = "1500.00"
        End Select
    End Sub
End Class