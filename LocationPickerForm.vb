Imports GMap.NET
Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports System.Windows.Forms

Public Class LocationPickerForm
    Inherits Form
    ' Define a delegate to pass the selected location back to the calling form/control
    Public Delegate Sub LocationSelectedHandler(ByVal latitude As Double, ByVal longitude As Double)

    ' Define the event that the calling control (Addnap) will handle
    Public Event LocationSelected As LocationSelectedHandler

    Private mapControl As GMapControl
    Private markersOverlay As GMapOverlay
    Private selectedMarker As GMapMarker

    ' Coordinates for Daet, Camarines Norte (as default center)
    Private Const DAET_LAT As Double = 14.1167
    Private Const DAET_LNG As Double = 122.95

    Public Sub New()
        ' Initialize the form
        Me.Text = "Select Location"
        Me.Size = New Size(800, 600)
        Me.StartPosition = FormStartPosition.CenterParent

        ' Add a GMapControl to the form
        mapControl = New GMapControl With {
            .Dock = DockStyle.Fill,
            .CanDragMap = True,
            .DragButton = MouseButtons.Left,
            .MinZoom = 2,
            .MaxZoom = 18,
            .Zoom = 13
        }

        Me.Controls.Add(mapControl) ' Add map to the form

        ' Add a Button for confirming the location
        Dim confirmButton As New Button With {
            .Text = "Confirm Location",
            .Dock = DockStyle.Bottom,
            .Height = 35
        }
        Me.Controls.Add(confirmButton)
        Me.Controls.SetChildIndex(confirmButton, 0) ' Bring button to front

        AddHandler confirmButton.Click, AddressOf ConfirmButton_Click

        InitializeMap()
    End Sub

    Private Sub InitializeMap()
        GMaps.Instance.Mode = AccessMode.ServerAndCache
        mapControl.MapProvider = GMapProviders.OpenStreetMap
        mapControl.Position = New PointLatLng(DAET_LAT, DAET_LNG)

        markersOverlay = New GMapOverlay("selection")
        mapControl.Overlays.Add(markersOverlay)

        AddHandler mapControl.MouseDown, AddressOf MapControl_MouseDown
    End Sub

    ' Event handler for map click/mousedown to place a temporary marker
    Private Sub MapControl_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            ' Convert screen coordinates to map coordinates
            Dim p As PointLatLng = mapControl.FromLocalToLatLng(e.X, e.Y)

            markersOverlay.Markers.Clear() ' Clear previous marker

            selectedMarker = New GMarkerGoogle(p, GMarkerGoogleType.red_dot)
            markersOverlay.Markers.Add(selectedMarker)

            ' Update button text immediately
            Me.Text = $"Lat: {p.Lat:F6}, Lng: {p.Lng:F6}"
        End If
    End Sub

    ' Event handler for the Confirm button
    Private Sub ConfirmButton_Click(sender As Object, e As EventArgs)
        If selectedMarker IsNot Nothing Then
            ' Raise the event to send the data back to the Addnap control
            RaiseEvent LocationSelected(selectedMarker.Position.Lat, selectedMarker.Position.Lng)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Please click on the map to select a location.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class
