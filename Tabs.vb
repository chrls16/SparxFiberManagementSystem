Public Class Tabs
    Private Sub MenuButtons_Click(sender As Object, e As EventArgs) _
    Handles DashboardBtn.Click, SalesBtn.Click, InstallationBtn.Click,
            ServiceBtn.Click, InventoryBtn.Click, SubscriberBtn.Click,
            BillingBtn.Click, HistoryBtn.Click

        If sender Is DashboardBtn Then
            ShowInMain(New AdminDashboard(), "Dashboard", "Overview of Sparx Fiber Internet System")

        ElseIf sender Is SalesBtn Then
            ShowInMain(New AdminSales(), "Sales", "Manage sales data and analytics")

        ElseIf sender Is InstallationBtn Then
            ShowInMain(New AdminInstallation(), "Installation", "Manage installation data and analytics")

        ElseIf sender Is ServiceBtn Then
            ShowInMain(New AdminService(), "Service", "Manage service data and analytics")

        ElseIf sender Is InventoryBtn Then
            ShowInMain(New AdminInventory(), "Inventory", "Manage inventory data and analytics")

        ElseIf sender Is SubscriberBtn Then
            ShowInMain(New AdminSubscribers(), "Subscriber", "Manage subsriber data and analytics")

        ElseIf sender Is BillingBtn Then
            ShowInMain(New AdminBilling(), "Billing", "Manage billing and data analytics")

        ElseIf sender Is HistoryBtn Then
            ShowInMain(New AdminHistory(), "History", "Manage history data and analytics")

        End If
    End Sub

    Private Sub ShowInMain(content As UserControl, title As String, subtitle As String)
        ' Replace the content of Mainexchange with the provided UserControl
        Mainexchange.SuspendLayout()
        Try
            Mainexchange.Controls.Clear()
            content.Dock = DockStyle.Fill
            Mainexchange.Controls.Add(content)
            lblDashboardSuperAdmin.Text = title
            overview.Text = subtitle
        Finally
            Mainexchange.ResumeLayout()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim login As New sparxLogin()
        Me.Hide()
        login.Show()
        AddHandler login.FormClosed, Sub() Me.Close()
    End Sub

    Private Sub Mainexchange_Paint(sender As Object, e As PaintEventArgs) Handles Mainexchange.Paint

    End Sub
End Class
