Imports System.Windows.Forms
Imports GMap.NET ' <--- THIS LINE MUST BE AT THE VERY TOP
' Imports GMap.NET.MapProviders ' You might need this if using other GMap components here
' Imports GMap.NET.WindowsForms ' You might need this too

Partial Class Addnap
    Inherits System.Windows.Forms.UserControl

    ' -------------------------------------------------------------
    ' >> NEW: Location Storage
    ' -------------------------------------------------------------
    Private SelectedLatitude As Double
    Private SelectedLongitude As Double

    ' The Public property to expose the selected location data (optional, but good practice)
    Public ReadOnly Property NAP_Location As PointLatLng
        Get
            ' The PointLatLng type is now recognized because of the Imports statement above.
            Return New PointLatLng(SelectedLatitude, SelectedLongitude)
        End Get
    End Property

    ' ... (The rest of your existing Designer Generated code) ...

    ' -------------------------------------------------------------
    ' >> NEW: Location Selection Logic
    ' -------------------------------------------------------------
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' 1. Create and show the Location Picker Form
        Dim pickerForm As New LocationPickerForm()

        ' 2. Handle the LocationSelected event from the picker form
        AddHandler pickerForm.LocationSelected, AddressOf HandleLocationSelection

        ' 3. Show the form modally
        pickerForm.ShowDialog()

        ' Remove the handler after closing to prevent memory leaks
        RemoveHandler pickerForm.LocationSelected, AddressOf HandleLocationSelection
    End Sub

    ' The handler method that receives the location data back
    Private Sub HandleLocationSelection(ByVal lat As Double, ByVal lng As Double)
        SelectedLatitude = lat
        SelectedLongitude = lng

        ' Update the text of Button1 to show the selected coordinates
        Button1.Text = String.Format("Lat: {0:F6}, Lng: {1:F6}", lat, lng)
    End Sub

    ' -------------------------------------------------------------
    ' >> EXISTING EVENT HANDLERS (for Save and Cancel)
    ' -------------------------------------------------------------
    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        ' For example, if you wanted to check the data before letting the parent close the form:
        If SelectedLatitude = 0 And SelectedLongitude = 0 Then
            ' Add logic here if you want to enforce selection
        End If

        ' This is where the parent form's Save handler will typically do the saving.
        ' The parent form (networkmapview) is already set up to listen to this click.
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click

    End Sub

    ' ... (Your InitializeComponent code, Designer Generated Code, and Friend WithEvents declarations follow) ...

End Class