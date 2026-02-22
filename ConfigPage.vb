Imports System.Configuration

Public Class ConfigurationPage
    Private Sub ConfigurationPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadConnectionSettings()
    End Sub

    Private Sub LoadConnectionSettings()
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("SparxDb").ConnectionString
            If String.IsNullOrEmpty(connectionString) Then
                MessageBox.Show("No connection string found in configuration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Parse the connection string
            Dim parts As String() = connectionString.Split(";"c)
            For Each part As String In parts
                If part.Contains("=") Then
                    Dim keyValue As String() = part.Split("="c)
                    If keyValue.Length = 2 Then
                        Dim key As String = keyValue(0).Trim().ToLower()
                        Dim value As String = keyValue(1).Trim()

                        Select Case key
                            Case "server"
                                txtServer.Text = value
                                txtHost.Text = value ' Host is same as server
                            Case "port"
                                txtPort.Text = value
                            Case "user id", "userid", "user"
                                TxtUN.Text = value
                            Case "password", "pwd"
                                TextBox1.Text = value
                            Case "sslmode"
                                Select Case value.ToLower()
                                    Case "none"
                                        cbProtocol.SelectedIndex = 0
                                    Case "preferred"
                                        cbProtocol.SelectedIndex = 1
                                    Case "required"
                                        cbProtocol.SelectedIndex = 2
                                    Case Else
                                        cbProtocol.SelectedIndex = 1 ' Default to Preferred
                                End Select
                        End Select
                    End If
                End If
            Next

            ' Set default connection timeout if not present
            If String.IsNullOrEmpty(txtConnectionTimeout.Text) Then
                txtConnectionTimeout.Text = "30"
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading connection settings: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            ' Validate inputs
            If String.IsNullOrEmpty(txtServer.Text.Trim()) Then
                MessageBox.Show("Server is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtServer.Focus()
                Return
            End If

            If String.IsNullOrEmpty(txtPort.Text.Trim()) Then
                MessageBox.Show("Port is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPort.Focus()
                Return
            End If

            If String.IsNullOrEmpty(TxtUN.Text.Trim()) Then
                MessageBox.Show("Username is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtUN.Focus()
                Return
            End If

            ' Build new connection string
            Dim server As String = txtServer.Text.Trim()
            Dim port As String = txtPort.Text.Trim()
            Dim username As String = TxtUN.Text.Trim()
            Dim password As String = TextBox1.Text.Trim()
            Dim sslMode As String = cbProtocol.SelectedItem.ToString()

            Dim databaseName As String = "sparx" ' 

            Dim newConnectionString As String = $"server={server};port={3306};database={databaseName};user id={username};sslmode={sslMode}"

            If Not String.IsNullOrEmpty(password) Then
                newConnectionString &= $";password={password}"
            End If

            ' Optional: Add connection timeout if you want the user's input to actually be used
            ' You read txtConnectionTimeout in Load but didn't use it in Update
            If Not String.IsNullOrEmpty(txtConnectionTimeout.Text) Then
                newConnectionString &= $";connection timeout={txtConnectionTimeout.Text.Trim()}"
            End If

            ' Save to config
            Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            config.ConnectionStrings.ConnectionStrings("SparxDb").ConnectionString = newConnectionString
            config.Save(ConfigurationSaveMode.Modified)
            ConfigurationManager.RefreshSection("connectionStrings")

            MessageBox.Show("Configuration updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error saving configuration: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
