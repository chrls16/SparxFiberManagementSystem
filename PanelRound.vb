Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class PanelRound
    Inherits Panel

    ' This new property will show up in the designer
    <Description("The radius for the panel's rounded corners.")>
    <Category("Appearance")>
    <DefaultValue(20)>
    Public Property CornerRadius As Integer = 20

    ' This is the magic function that creates the rounded shape
    Private Function GetRoundedRect(ByVal rect As Rectangle, ByVal radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim r As Integer = radius * 2
        path.AddArc(rect.X, rect.Y, r, r, 180, 90) ' Top-left
        path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90) ' Top-right
        path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90) ' Bottom-right
        path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90) ' Bottom-left
        path.CloseFigure()
        Return path
    End Function

    ' This is where we override the panel's drawing behavior
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e) ' Call the base OnPaint first

        ' Make the corners smooth
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        ' Get the rectangle for the panel's area
        Dim rect As New Rectangle(0, 0, Me.Width, Me.Height)

        ' Create the rounded shape
        Using path As GraphicsPath = GetRoundedRect(rect, CornerRadius)
            ' Fill the panel's background
            Using brush As New SolidBrush(Me.BackColor)
                e.Graphics.FillPath(brush, path)
            End Using

            ' NO BORDER: The DrawPath line has been removed to remove the border.
            ' If you ever want a border again, uncomment the following:
            ' Using pen As New Pen(Me.ForeColor, 1)
            '     e.Graphics.DrawPath(pen, path)
            ' End Using
        End Using
    End Sub

    ' Add this new override to set the region of the control
    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        
        ' Skip region setting in design mode to avoid errors
        If Not DesignMode AndAlso Me.Width > 0 AndAlso Me.Height > 0 Then
            Using path As GraphicsPath = GetRoundedRect(New Rectangle(0, 0, Me.Width, Me.Height), CornerRadius)
                Me.Region = New Region(path)
            End Using
        End If
    End Sub

End Class