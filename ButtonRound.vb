Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class ButtonRounded
    Inherits Button

    ' Backing field for the designer-visible property
    Private _cornerRadius As Integer = 20

    <Description("The radius for the button's rounded corners.")>
    <Category("Appearance")>
    <DefaultValue(20)>
    Public Property CornerRadius As Integer
        Get
            Return _cornerRadius
        End Get
        Set(value As Integer)
            If value < 0 Then value = 0
            If _cornerRadius <> value Then
                _cornerRadius = value
                Me.Invalidate()
                ' Update Region immediately so designer reflects change
                If Me.Width > 0 AndAlso Me.Height > 0 Then
                    Using path As GraphicsPath = GetRoundedRect(New Rectangle(0, 0, Me.Width, Me.Height), _cornerRadius)
                        Me.Region = New Region(path)
                    End Using
                End If
            End If
        End Set
    End Property

    Private Function GetRoundedRect(ByVal rect As Rectangle, ByVal radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim r As Integer = Math.Max(0, radius * 2)
        If rect.Width <= 0 OrElse rect.Height <= 0 Then
            Return path
        End If
        path.AddArc(rect.X, rect.Y, r, r, 180, 90) ' Top-left
        path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90) ' Top-right
        path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90) ' Bottom-right
        path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90) ' Bottom-left
        path.CloseFigure()
        Return path
    End Function

    Public Sub New()
        MyBase.New()
        Me.FlatStyle = FlatStyle.Flat
        Me.FlatAppearance.BorderSize = 0
        Me.BackColor = Color.FromArgb(70, 130, 255)
        Me.ForeColor = Color.White
    End Sub

    Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
        Dim g As Graphics = pevent.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        ' Safe fallback when Parent is Nothing (designer)
        Dim parentBack As Color = If(Me.Parent IsNot Nothing, Me.Parent.BackColor, SystemColors.Control)
        g.Clear(parentBack)

        Dim rect As New Rectangle(0, 0, Me.Width, Me.Height)
        If rect.Width <= 0 OrElse rect.Height <= 0 Then Return

        Using path As GraphicsPath = GetRoundedRect(rect, _cornerRadius)
            Dim fillColor As Color

            If Not Me.Enabled Then
                fillColor = Color.Gray
            ElseIf Not Me.DesignMode AndAlso Me.Capture AndAlso Me.ClientRectangle.Contains(Me.PointToClient(MousePosition)) Then
                fillColor = If(Me.FlatAppearance.MouseDownBackColor = Color.Empty,
                               ControlPaint.Dark(Me.BackColor, 0.1),
                               Me.FlatAppearance.MouseDownBackColor)
            ElseIf Not Me.DesignMode AndAlso Me.ClientRectangle.Contains(Me.PointToClient(MousePosition)) Then
                fillColor = If(Me.FlatAppearance.MouseOverBackColor = Color.Empty,
                               ControlPaint.Light(Me.BackColor, 0.1),
                               Me.FlatAppearance.MouseOverBackColor)
            Else
                fillColor = Me.BackColor
            End If

            Using brush As New SolidBrush(fillColor)
                g.FillPath(brush, path)
            End Using

            If Me.FlatAppearance.BorderSize > 0 Then
                Using pen As New Pen(Me.FlatAppearance.BorderColor, Me.FlatAppearance.BorderSize)
                    Dim borderRect As New Rectangle(rect.X + CInt(Math.Floor(Me.FlatAppearance.BorderSize / 2.0)),
                                                   rect.Y + CInt(Math.Floor(Me.FlatAppearance.BorderSize / 2.0)),
                                                   rect.Width - Me.FlatAppearance.BorderSize,
                                                   rect.Height - Me.FlatAppearance.BorderSize)
                    Using borderPath As GraphicsPath = GetRoundedRect(borderRect, _cornerRadius)
                        g.DrawPath(pen, borderPath)
                    End Using
                End Using
            End If

            TextRenderer.DrawText(g, Me.Text, Me.Font, rect, Me.ForeColor,
                                  TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
        End Using
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        If Me.Width <= 0 OrElse Me.Height <= 0 Then Return
        Using path As GraphicsPath = GetRoundedRect(New Rectangle(0, 0, Me.Width, Me.Height), _cornerRadius)
            Me.Region = New Region(path)
        End Using
    End Sub
End Class