Public Class SidePanel

    Public CurrentCustomerId As Integer
    Public CurrentFirstName As String
    Public CurrentLastName As String
    Public CurrentEmail As String

    Sub childControl(ByVal panelControl As UserControl)
        ContentPanel.Controls.Clear()
        panelControl.Dock = DockStyle.Fill
        ContentPanel.Controls.Add(panelControl)
        panelControl.BringToFront()
    End Sub

    Private Sub SetHeader(title As String)
        HeaderLbl.Text = title
    End Sub



    ' default color of button kapag di pa naki-click
    Private menuDefaultBackColor As Color = Color.FromArgb(29, 41, 61)
    Private activeButton As Button = Nothing


    'kapag na-click na ang button, machange na ang color
    Private Sub Button_Click(sender As Object, e As EventArgs) Handles ProfileButton.Click, HistoryButton.Click
        If activeButton IsNot Nothing Then
            activeButton.BackColor = menuDefaultBackColor
        End If

        Dim clickedButton = TryCast(sender, Button)
        If clickedButton IsNot Nothing Then
            clickedButton.BackColor = Color.FromArgb(24, 93, 252)
            activeButton = clickedButton
        End If
    End Sub

    Private Sub ProfileButton_Click(sender As Object, e As EventArgs) Handles ProfileButton.Click
        Dim profile As New Profile()
        profile.CurrentCustomerId = CurrentCustomerId
        profile.CurrentFirstName = CurrentFirstName
        profile.CurrentLastName = CurrentLastName
        profile.CurrentEmail = CurrentEmail
        childControl(profile)
        HeaderPanel.Visible = True
        SetHeader("My Profile")
    End Sub

    Private Sub HistoryButton_Click(sender As Object, e As EventArgs) Handles HistoryButton.Click
        Dim history As New History()
        history.CurrentCustomerId = CurrentCustomerId
        childControl(history)
        HeaderPanel.Visible = True
        SetHeader("History")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Using logoutPopUp As New LogOutConfirmation()
            If logoutPopUp.ShowDialog() = DialogResult.OK Then
                Dim login As New sparxLogin()
                login.Show()
            End If
        End Using
    End Sub

    Private Sub SidePanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Update the button text with the email stored in the property
        If CurrentEmail.Length > 15 Then
            Button2.Text = CurrentEmail.Substring(0, 12) & "..."
        Else
            Button2.Text = CurrentEmail
        End If
    End Sub
End Class
