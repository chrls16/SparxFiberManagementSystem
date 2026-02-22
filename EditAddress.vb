Imports System.Data
Imports MySqlConnector
Imports System.Configuration

Public Class EditAddress
    ' Properties to hold current values
    Public Property CustomerId As Integer
    Public Property Country As String
    Public Property Province As String
    Public Property Municipality As String
    Public Property Barangay As String
    Public Property Landmark As String
    Public Property Purok As String

    Private connectionString As String = Nothing
    Private isLoadingData As Boolean = False ' Flag to prevent event triggers during load

    Private ReadOnly Property CONNECTION_STRING As String
        Get
            If connectionString Is Nothing Then
                Try
                    connectionString = ConfigurationManager.ConnectionStrings("SparxDb").ConnectionString
                Catch
                    connectionString = "Server=localhost;Database=sparx;Uid=root;Pwd=;"
                End Try
            End If
            Return connectionString
        End Get
    End Property

    Private Sub EditAddress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isLoadingData = True ' Set flag to prevent event triggers

        ' Set default values
        Country = "Philippines"
        Province = "Camarines Norte" ' Always Camarines Norte

        ' Load current address from database
        LoadCurrentAddressFromDatabase()

        ' Set fixed values for Country and Province
        SetFixedFields()

        ' Load municipalities for Camarines Norte
        LoadMunicipalities()

        ' Load purok options (1-9)
        LoadPurokOptions()

        ' Set initial values after loading data
        SetInitialValues()

        isLoadingData = False ' Reset flag
    End Sub

    Private Sub SetFixedFields()
        ' Set country (Philippines by default)
        CountryComboBox.Text = "Philippines"
        CountryComboBox.Enabled = False ' Make it read-only since it's always Philippines
        CountryComboBox.DropDownStyle = ComboBoxStyle.DropDownList

        ' Set province to Camarines Norte (fixed, not changeable) using ComboBox
        ProvinceComboBox.Items.Clear()
        ProvinceComboBox.Items.Add("Camarines Norte") ' Add only one item

        ' Set properties to make it display info but not changeable
        ProvinceComboBox.Text = "Camarines Norte"
        ProvinceComboBox.Enabled = False ' Disable editing
        ProvinceComboBox.DropDownStyle = ComboBoxStyle.DropDownList ' Prevent typing

        ' Optional: Change appearance to indicate it's not editable
        ProvinceComboBox.BackColor = SystemColors.Control
        ProvinceComboBox.ForeColor = SystemColors.ControlText
    End Sub

    Private Sub LoadPurokOptions()
        Try
            ' Add purok numbers 1-9
            ComboBox1.Items.Clear()
            For i As Integer = 1 To 9
                ComboBox1.Items.Add("Purok " & i.ToString())
            Next

            ' Set the dropdown style to DropDownList to prevent typing
            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        Catch ex As Exception
            MessageBox.Show("Error loading purok options: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadCurrentAddressFromDatabase()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                ' Query to get current address data - INCLUDING PUROK
                Dim query As String = "SELECT landmark, purok, barangay, municipality, province " &
                                      "FROM customer_data WHERE customer_id = @id"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", CustomerId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Get all address fields from database
                            Dim municipalityDb As String = reader("municipality").ToString()
                            Dim barangayDb As String = reader("barangay").ToString()
                            Dim purokDb As String = reader("purok").ToString()
                            Dim landmarkDb As String = reader("landmark").ToString()
                            Dim provinceDb As String = reader("province").ToString()

                            ' Only override if database has values
                            If Not String.IsNullOrEmpty(municipalityDb) Then
                                Municipality = municipalityDb
                            End If

                            If Not String.IsNullOrEmpty(barangayDb) Then
                                Barangay = barangayDb
                            End If

                            If Not String.IsNullOrEmpty(purokDb) Then
                                Purok = purokDb
                            End If

                            If Not String.IsNullOrEmpty(landmarkDb) Then
                                Landmark = landmarkDb
                            End If

                            ' Set province from database if available (should be Camarines Norte)
                            If Not String.IsNullOrEmpty(provinceDb) Then
                                Province = provinceDb
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading current address from database: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetInitialValues()
        ' Set municipality if we have it
        If Not String.IsNullOrEmpty(Municipality) Then
            ' Try to find and select the municipality
            Dim found As Boolean = False
            For Each item As Object In MunComboBox.Items
                If item.ToString().Equals(Municipality, StringComparison.OrdinalIgnoreCase) Then
                    MunComboBox.SelectedItem = item
                    found = True
                    Exit For
                End If
            Next

            ' If not found in the list, add it and select it
            If Not found AndAlso Not String.IsNullOrEmpty(Municipality) Then
                MunComboBox.Items.Add(Municipality)
                MunComboBox.SelectedItem = Municipality
            End If

            ' Load barangays for this municipality
            LoadBarangays(Municipality)

            ' Set barangay if we have it
            If Not String.IsNullOrEmpty(Barangay) Then
                ' Try to find and select the barangay
                found = False
                For Each item As Object In BrgyComboBox.Items
                    If item.ToString().Equals(Barangay, StringComparison.OrdinalIgnoreCase) Then
                        BrgyComboBox.SelectedItem = item
                        found = True
                        Exit For
                    End If
                Next

                ' If not found in the list, add it and select it
                If Not found AndAlso Not String.IsNullOrEmpty(Barangay) Then
                    BrgyComboBox.Items.Add(Barangay)
                    BrgyComboBox.SelectedItem = Barangay
                End If
            End If
        Else
            ' Default municipality to Daet if none is set
            If MunComboBox.Items.Count > 0 Then
                MunComboBox.SelectedIndex = 0
                LoadBarangays(MunComboBox.Text)
            End If
        End If

        ' Set landmark
        LMTxtBox.Text = Landmark

        ' Set purok
        If ComboBox1 IsNot Nothing Then
            If Not String.IsNullOrEmpty(Purok) Then
                ' Try to match the purok value
                Dim found As Boolean = False
                For Each item As Object In ComboBox1.Items
                    If item.ToString().Equals(Purok, StringComparison.OrdinalIgnoreCase) Then
                        ComboBox1.SelectedItem = item
                        found = True
                        Exit For
                    End If
                Next

                ' If not found in the list, add it and select it
                If Not found AndAlso Not String.IsNullOrEmpty(Purok) Then
                    ComboBox1.Items.Add(Purok)
                    ComboBox1.SelectedItem = Purok
                End If
            Else
                ' Default to first purok if none is set
                If ComboBox1.Items.Count > 0 Then
                    ComboBox1.SelectedIndex = 0
                End If
            End If
        End If
    End Sub

    Private Sub LoadMunicipalities()
        Try
            ' Clear existing items
            MunComboBox.Items.Clear()
            MunComboBox.Text = ""
            BrgyComboBox.Items.Clear()
            BrgyComboBox.Text = ""

            ' Set dropdown style
            MunComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            BrgyComboBox.DropDownStyle = ComboBoxStyle.DropDownList

            ' Municipalities for Camarines Norte only
            Dim municipalities() As String = {
                "Daet", ' Default municipality first
                "Basud", "Capalonga", "Jose Panganiban", "Labo",
                "Mercedes", "Paracale", "San Lorenzo Ruiz", "San Vicente",
                "Santa Elena", "Talisay", "Vinzons"
            }
            MunComboBox.Items.AddRange(municipalities)

        Catch ex As Exception
            MessageBox.Show("Error loading municipalities: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadBarangays(ByVal municipality As String)
        Try
            ' Clear existing items
            BrgyComboBox.Items.Clear()
            BrgyComboBox.Text = ""

            ' Set dropdown style
            BrgyComboBox.DropDownStyle = ComboBoxStyle.DropDownList

            ' Barangays for municipalities in Camarines Norte
            If municipality = "Daet" Then
                Dim barangays() As String = {
                    "Alawihao", "Awitan", "Bagasbas", "Barangay I", "Barangay II",
                    "Barangay III", "Barangay IV", "Barangay V", "Barangay VI",
                    "Barangay VII", "Barangay VIII", "Cobangbang", "Dogongan",
                    "Gomokal", "Gubat", "Lag-on", "Mambalite", "Mantagbac",
                    "Palanas", "Pamplona", "San Isidro", "San Roque", "Talisay"
                }
                BrgyComboBox.Items.AddRange(barangays)

            ElseIf municipality = "Mercedes" Then
                Dim barangays() As String = {
                    "Apuao", "Barangay I", "Barangay II", "Barangay III",
                    "Barangay IV", "Barangay V", "Barangay VI", "Barangay VII",
                    "Barangay VIII", "Caringo", "Catandunganon", "Cayucyucan",
                    "Colasi", "Del Rosario", "Gaboc", "Hamoraon", "Hinampacan",
                    "Hinipaan", "Lanot", "Mambungalon", "Manguisoc", "Masalongsalong",
                    "Pambuhan", "Quinapaguian", "San Roque", "Sapa", "Siramag",
                    "Tarum"
                }
                BrgyComboBox.Items.AddRange(barangays)

            ElseIf municipality = "Labo" Then
                Dim barangays() As String = {
                    "Anameam", "Awitan", "Bagong Silang", "Bagumbayan", "Bakiad",
                    "Banay-banay", "Banay-banay Poblacion", "Banay-banay Proper",
                    "Baya", "Bayabas", "Bulhao", "Cabatuhan", "Cabuyadan",
                    "Calabaca", "Canapawan", "Daguit", "Dalas", "Dumagmang",
                    "Exciban", "Fabrica", "Guisican", "Gumamela", "J. P. Rizal",
                    "Kalawit", "Lagayas", "Mabilo I", "Mabilo II", "Malangcao Basud",
                    "Malasugui", "Malatap", "Malaya", "Malibago", "Mampurog",
                    "Mantacbac", "Matanggoy", "Napaod", "Pag-Asa", "Punta",
                    "San Antonio", "San Francisco", "Santa Cruz", "Talisay",
                    "Tubigan", "Tulay Na Lupa"
                }
                BrgyComboBox.Items.AddRange(barangays)

            ElseIf municipality = "Basud" Then
                Dim barangays() As String = {
                    "Banay-banay", "Bautista", "Cagbalogo", "Carangcang", "Daguit",
                    "Dandang", "Guinatungan", "Hernandez", "Mampungo", "Mantugawe",
                    "Pagsangahan", "Pinagdapian", "Punta", "San Felipe", "San Isidro",
                    "San Jose", "San Pascual", "Taba-taba", "Tacad", "Talisay"
                }
                BrgyComboBox.Items.AddRange(barangays)

                ' Add more municipalities as needed
            ElseIf municipality = "Paracale" Then
                Dim barangays() As String = {
                    "Bagumbayan", "Bakal", "Batobalani", "Cabusay", "Calaburnay",
                    "Capacuan", "Casalugan", "Dalnac", "Duguid", "Gumaus",
                    "Labnig", "Macolabo Island", "Malacbang", "Malaguit", "Mampungo",
                    "Mangkasay", "Mampurog", "Mapulot", "Palanas", "Poblacion Norte",
                    "Poblacion Sur", "Talusan", "Tawig"
                }
                BrgyComboBox.Items.AddRange(barangays)

                ' Add default options for other municipalities
            Else
                ' Add a default option
                BrgyComboBox.Items.Add("Select barangay")
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading barangays: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MunComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MunComboBox.SelectedIndexChanged
        If MunComboBox.SelectedItem IsNot Nothing AndAlso Not isLoadingData Then
            LoadBarangays(MunComboBox.SelectedItem.ToString())
        End If
    End Sub

    Private Sub UpdateAddressBtn_Click(sender As Object, e As EventArgs) Handles UpdateAddressBtn.Click
        ' Validate input
        If MunComboBox.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a municipality.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MunComboBox.Focus()
            Return
        End If

        If BrgyComboBox.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a barangay.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            BrgyComboBox.Focus()
            Return
        End If

        ' Validate purok
        If ComboBox1 Is Nothing OrElse ComboBox1.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a purok.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ComboBox1.Focus()
            Return
        End If

        ' Update the properties
        Country = "Philippines"
        Province = "Camarines Norte" ' Always fixed
        Municipality = MunComboBox.SelectedItem.ToString()
        Barangay = BrgyComboBox.SelectedItem.ToString()
        Landmark = LMTxtBox.Text
        Purok = ComboBox1.SelectedItem.ToString()

        ' Save to database
        If SaveAddressToDatabase() Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Function SaveAddressToDatabase() As Boolean
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                ' REMOVED: installation_address = @address
                ' We only update the specific columns that exist in customer_data
                Dim query As String = "UPDATE customer_data SET " &
                                  "landmark = @landmark, " &
                                  "purok = @purok, " &
                                  "barangay = @barangay, " &
                                  "municipality = @municipality, " &
                                  "province = @province " &
                                  "WHERE customer_id = @id"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@landmark", Landmark.Trim())
                    cmd.Parameters.AddWithValue("@purok", Purok)
                    cmd.Parameters.AddWithValue("@barangay", Barangay)
                    cmd.Parameters.AddWithValue("@municipality", Municipality)
                    cmd.Parameters.AddWithValue("@province", "Camarines Norte")
                    cmd.Parameters.AddWithValue("@id", CustomerId)

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        Return True
                    Else
                        MessageBox.Show("No records were updated.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saving address: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Sub CancelAddressBtn_Click(sender As Object, e As EventArgs) Handles CancelAddressBtn.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ' Existing paint code
    End Sub

    Private Sub BrgyComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BrgyComboBox.SelectedIndexChanged
        ' Event handler if needed
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Event handler for purok selection
    End Sub

    Private Sub ProvinceComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProvinceComboBox.SelectedIndexChanged
        ' This event will never fire since the ComboBox is disabled
        ' But we keep it for completeness
    End Sub
End Class