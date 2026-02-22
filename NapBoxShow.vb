Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Reflection
Imports MySqlConnector
Imports System.Drawing
Imports System.Threading.Tasks ' Added for Async/Await

Partial Public Class NapBoxShow
    Inherits System.Windows.Forms.UserControl

    Private currentNapForm As NapBoxShow
    Private NAPBOX As Object
    Private portTextBoxes As TextBox()
    Private portLabels As Label()
    Private isEditMode As Boolean = False

    Public Property ParentNetworkMapView As Object
    Public Property CurrentNAPId As Integer

    Private ReadOnly Property CONNECTION_STRING As String
        Get
            Return "Server=localhost;Database=sparx;Uid=root;Pwd=;"
        End Get
    End Property


    Public Sub New()

        InitializeComponent()


        portTextBoxes = New TextBox() {TextBox3, TextBox4, TextBox5, TextBox6, TextBox7, TextBox8, TextBox9, TextBox10}
        portLabels = New Label() {Label8, Label9, Label11, Label12, Label13, Label14, Label15, Label16}
    End Sub

    Private Sub NapBoxShow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load data if NAP ID is set
        If CurrentNAPId > 0 Then
            ' LoadNAPPorts is now an Async Sub
            LoadNAPPorts(CurrentNAPId)
        End If

        ' Initially set to read-only mode
        SetReadOnlyMode(True)
    End Sub

    Private Sub ButtonRounded1_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub ButtonRounded2_Click(sender As Object, e As EventArgs)
    End Sub


    Private Async Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        If CurrentNAPId <= 0 Then
            MessageBox.Show("No NAP selected.", "Error")
            Return
        End If

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                Await conn.OpenAsync() ' Use Async method

                For portNumber As Integer = 1 To portTextBoxes.Length
                    Dim portName As String = portTextBoxes(portNumber - 1).Text.Trim()

                    ' Update port_name in database
                    Dim updateQuery As String = "UPDATE nap_ports SET port_name = @portName WHERE nap_id = @napId AND port_number = @portNumber"
                    Using cmd As New MySqlCommand(updateQuery, conn)
                        cmd.Parameters.AddWithValue("@portName", If(String.IsNullOrEmpty(portName), CType(DBNull.Value, Object), portName))
                        cmd.Parameters.AddWithValue("@napId", CurrentNAPId)
                        cmd.Parameters.AddWithValue("@portNumber", portNumber)
                        Await cmd.ExecuteNonQueryAsync() ' Use Async method
                    End Using
                Next

                MessageBox.Show("Port names updated successfully.", "Success")
                SetReadOnlyMode(True)
                isEditMode = False
            End Using
        Catch ex As MySqlException ' Specific database error handling
            MessageBox.Show("Database Error saving port names: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error saving port names: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        ' Reload data from database to cancel changes (call is safe since LoadNAPPorts is Async Sub)
        If CurrentNAPId > 0 Then
            LoadNAPPorts(CurrentNAPId)
        End If
        SetReadOnlyMode(True)
        isEditMode = False
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
    End Sub


    Private Async Sub LoadNAPPorts(napId As Integer)
        Dim ports As New Dictionary(Of Integer, String)
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                Await conn.OpenAsync() ' Use Async method
                Dim query As String = "SELECT port_number, port_name, status FROM nap_ports WHERE nap_id = @napId ORDER BY port_number"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@napId", napId)
                    Using reader As MySqlDataReader = Await cmd.ExecuteReaderAsync() ' Use Async method
                        While reader.Read()
                            Dim portNumber As Integer = reader.GetInt32("port_number")
                            Dim portName As String = If(reader.IsDBNull(reader.GetOrdinal("port_name")), "", reader.GetString("port_name"))
                            Dim status As String = reader.GetString("status")

                            ' Set port name in textbox
                            If portNumber >= 1 AndAlso portNumber <= portTextBoxes.Length Then
                                portTextBoxes(portNumber - 1).Text = portName
                            End If

                            ports(portNumber) = status
                        End While
                    End Using
                End Using
            End Using

            ' Update status labels
            SetLCPStatus(ports)
            Me.Refresh()

            ' Update NAPBOX visual status if available
            If NAPBOX IsNot Nothing Then
                Dim napPorts As New Dictionary(Of Integer, String)
                For Each kvp In ports
                    napPorts(kvp.Key - 1) = kvp.Value.ToLower()
                Next
                Try
                    Dim mi As Reflection.MethodInfo = NAPBOX.GetType().GetMethod("SetLCPStatus")
                    If mi IsNot Nothing Then
                        mi.Invoke(NAPBOX, New Object() {napPorts})
                    End If
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("Error updating NAPBOX status: " & ex.Message)
                End Try
            End If

        Catch ex As MySqlException ' Specific database error handling
            MessageBox.Show("Database Error loading NAP ports: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error loading NAP ports: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Sub RefreshNAPData()
        If CurrentNAPId > 0 Then
            LoadNAPPorts(CurrentNAPId)
        End If
    End Sub

    Public Sub EnterEditMode()
        SetReadOnlyMode(False)
        isEditMode = True
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub SetReadOnlyMode(isReadOnly As Boolean)
        For Each tb In portTextBoxes
            tb.ReadOnly = isReadOnly
            tb.BackColor = If(isReadOnly, Color.LightGray, Color.White)
        Next
        ' Ensure the buttons SaveBtn and CancelBtn are properly defined in the designer
        If SaveBtn IsNot Nothing Then SaveBtn.Enabled = Not isReadOnly
        If CancelBtn IsNot Nothing Then CancelBtn.Enabled = Not isReadOnly
    End Sub

    Private Sub SetLCPStatus(ports As Dictionary(Of Integer, String))
        ' This is the previously problematic code. The array is now guaranteed to exist.
        For Each kvp In ports
            Dim portNumber As Integer = kvp.Key
            Dim status As String = kvp.Value

            If portNumber >= 1 AndAlso portNumber <= portLabels.Length Then
                Dim label As Label = portLabels(portNumber - 1)

                ' Keep the defensive null check for the individual control just in case
                If label IsNot Nothing Then
                    label.Text = status.ToUpper()
                    label.ForeColor = If(status.Equals("Available", StringComparison.OrdinalIgnoreCase), Color.Green, Color.Red)
                Else
                    System.Diagnostics.Debug.WriteLine($"Warning: Label for port {portNumber} is not initialized (Nothing).")
                End If
            End If
        Next
    End Sub
End Class