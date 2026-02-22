Public Class customerservicetab

    ' 1. Property to receive the Role from the Login form
    Public Property CurrentUserRole As String

    Private Sub MenuButtons_Click(sender As Object, e As EventArgs) _
    Handles DashboardBtn.Click, SalesBtn.Click, InstallationBtn.Click,
            ServiceBtn.Click, InventoryBtn.Click, SubscriberBtn.Click,
            BillingBtn.Click, HistoryBtn.Click


        ' 2. LOGIC: Determine if the view should be Read-Only based on the Matrix
        Dim isReadOnly As Boolean = True ' Default to Restricted/Read-Only for safety

        If CurrentUserRole = "Inventory" Then
            If sender Is InventoryBtn Then
                isReadOnly = False
            End If

        ElseIf CurrentUserRole = "Customer Service" Then
            ' Matrix: Customer Service can Manage Profiles (Subscriber), Update Status (Service), and Generate Bills (Billing).
            ' Inventory is "No access" (which implies Read-Only based on your request).
            If sender Is SubscriberBtn OrElse sender Is ServiceBtn OrElse sender Is BillingBtn Then
                isReadOnly = False
            End If
        End If

        ' 3. NAVIGATION: Open views and pass the restriction
        If sender Is DashboardBtn Then
            ShowInMain(New AdminDashboard(), "Dashboard", "Overview of Sparx Fiber Internet System")

        ElseIf sender Is SalesBtn Then
            Dim view As New AdminSales()
            ShowInMain(view, "Sales", "Manage sales data and analytics")

        ElseIf sender Is InstallationBtn Then
            Dim view As New AdminInstallation()
            view.IsReadOnly = isReadOnly
            ShowInMain(view, "Installation", "Manage installation data and analytics")

        ElseIf sender Is ServiceBtn Then
            Dim view As New AdminService()
            view.IsReadOnly = isReadOnly
            ShowInMain(view, "Service", "Manage service data and analytics")

        ElseIf sender Is InventoryBtn Then
            Dim view As New AdminInventory()
            view.IsReadOnly = isReadOnly
            ShowInMain(view, "Inventory", "Manage inventory data and analytics")

        ElseIf sender Is SubscriberBtn Then
            Dim view As New AdminSubscribers()
            view.IsReadOnly = isReadOnly
            ShowInMain(view, "Subscriber", "Manage subscriber details and analytics")

        ElseIf sender Is BillingBtn Then
            Dim view As New AdminBilling()
            view.IsReadOnly = isReadOnly
            ShowInMain(view, "Billing", "Manage billing and data analytics")

        ElseIf sender Is HistoryBtn Then
            Dim view As New AdminHistory()
            ShowInMain(view, "History", "Manage history data and analytics")

        End If
    End Sub

    Private Sub customerservicetab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load the dashboardview UserControl on startup
        ShowInMain(New dashboardview(), "Dashboard", "Overview of Sparx Fiber Internet System")
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

    Private Sub Mainexchange_Paint(sender As Object, e As PaintEventArgs) Handles Mainexchange.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Using logoutPopUp As New LogOutConfirmation()
            ' ShowDialog stops execution here until the user clicks OK or Cancel
            If logoutPopUp.ShowDialog() = DialogResult.OK Then
                Dim login As New sparxLogin()
                login.Show()

            End If
        End Using
    End Sub
End Class