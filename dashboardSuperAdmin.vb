Public Class dashboardSuperAdmin
    Public Property CurrentUserName As String
    Public Property CurrentUserRole As String
    Public CurrentEmail As String

    Private Sub SetHeader(title As String, subtitle As String)
        lblDashboardSuperAdmin.Text = title
        overview.Text = subtitle
    End Sub


    Private Sub LoadIntoMain(form As Form)
        Mainexchange.Controls.Clear()
        form.TopLevel = False
        form.FormBorderStyle = FormBorderStyle.None
        form.Dock = DockStyle.Fill
        Mainexchange.Controls.Add(form)
        form.Show()
    End Sub
    Private Sub ShowInMain(ctrl As Control, title As String, subtitle As String)
        Mainexchange.Visible = True

        Mainexchange.SuspendLayout()
        Mainexchange.Controls.Clear()

        If TypeOf ctrl Is Form Then
            Dim frm = DirectCast(ctrl, Form)
            frm.TopLevel = False
            frm.FormBorderStyle = FormBorderStyle.None
            frm.Dock = DockStyle.Fill
            Mainexchange.Controls.Add(frm)
            frm.Show()
        Else
            ctrl.Dock = DockStyle.Fill
            Mainexchange.Controls.Add(ctrl)
            ctrl.BringToFront()
        End If

        Mainexchange.ResumeLayout()

        pnlHeader.Visible = True
        pnlHeader.BringToFront()

        lblDashboardSuperAdmin.Text = title
        overview.Text = subtitle
    End Sub

    Private Sub ShowDashboardCards()
        Mainexchange.Controls.Clear()
        Mainexchange.Visible = True

        pnlHeader.Visible = True
        pnlHeader.BringToFront()
    End Sub

    Private menuDefaultBackColor As Color = Color.FromArgb(29, 41, 61)
    Private activeButton As Button = Nothing


    'kapag na-click na ang button, machange na ang color
    Private Sub Button_Click(sender As Object, e As EventArgs) Handles DashboardBtn.Click, SalesBtn.Click, InstallationBtn.Click, ServiceBtn.Click, InventoryBtn.Click, PayrollBtn.Click, SubscriberBtn.Click, BillingBtn.Click, NetworkMapBtn.Click, HistoryBtn.Click, PlansBtn.Click, StaffBtn.Click
        If activeButton IsNot Nothing Then
            activeButton.BackColor = menuDefaultBackColor
        End If

        Dim clickedButton = TryCast(sender, Button)
        If clickedButton IsNot Nothing Then
            clickedButton.BackColor = Color.FromArgb(24, 93, 252)
            activeButton = clickedButton
        End If
    End Sub

    Private Sub MenuButtons_Click(sender As Object, e As EventArgs) _
    Handles DashboardBtn.Click, SalesBtn.Click, InstallationBtn.Click, ServiceBtn.Click, InventoryBtn.Click, PayrollBtn.Click, SubscriberBtn.Click, BillingBtn.Click, NetworkMapBtn.Click, HistoryBtn.Click, PlansBtn.Click, StaffBtn.Click

        If sender Is DashboardBtn Then
            ShowInMain(New dashboardview, "Dashboard", "Overview of Sparx Fiber Internet System")

        ElseIf sender Is DashboardBtn Then
            ShowInMain(New dashboardview, "Dashboard", "Overview of Sparx Fiber Internet System")

        ElseIf sender Is NetworkMapBtn Then
            ShowInMain(New networkmapview, "Network Map", "Topology, nodes, and link status")

        ElseIf sender Is SalesBtn Then
            ShowInMain(New salesview, "Sales", "Manage sales data and analytics")

        ElseIf sender Is InstallationBtn Then
            ShowInMain(New installationview, "Installation", "Manage installation data and analyti")

        ElseIf sender Is ServiceBtn Then
            ShowInMain(New service, "Service", "Manage service data and analytics")

        ElseIf sender Is InventoryBtn Then
            ShowInMain(New inventoryview, "Inventory", "Manage inventory data and analytics")

        ElseIf sender Is PayrollBtn Then
            ShowInMain(New payrollview, "Payroll", "Employee payroll and compensation")

        ElseIf sender Is SubscriberBtn Then
            ShowInMain(New subscriberview, "Subscriber", "Manage subsriber dets and analytics")

        ElseIf sender Is BillingBtn Then
            ShowInMain(New billingview, "Billing", "Manage billing data and analytics")

        ElseIf sender Is HistoryBtn Then
            ShowInMain(New historyview, "History", "Manage history data and analytics")

        ElseIf sender Is PlansBtn Then
            ShowInMain(New plansview, "Plans", "Manage plans data and analytics")

        ElseIf sender Is StaffBtn Then
            ShowInMain(New staffview, "Staff", "Manage staff data and analytics")
        End If
    End Sub
    Private Sub dashboardSuperAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowInMain(New dashboardview(), "Dashboard", "Overview of Sparx Fiber Internet System")
        If Not String.IsNullOrEmpty(CurrentEmail) Then
            If CurrentEmail.Length > 15 Then
                Button1.Text = CurrentEmail.Substring(0, 12) & "..."
            Else
                Button1.Text = CurrentEmail
            End If
        Else
            Button1.Text = "Logout" ' Fallback text
        End If
    End Sub


    ' Inside dashboardSuperAdmin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using logoutPopUp As New LogOutConfirmation()
            ' ShowDialog stops execution here until the user clicks OK or Cancel
            If logoutPopUp.ShowDialog() = DialogResult.OK Then
                Dim login As New sparxLogin()
                login.Show()

            End If
        End Using
    End Sub

    Private Sub btnConfigPage_Click(sender As Object, e As EventArgs)

        Dim configForm As New ConfigurationPage

        configForm.StartPosition = FormStartPosition.CenterScreen

        configForm.ShowDialog

    End Sub

    Private Sub Mainexchange_Paint(sender As Object, e As PaintEventArgs) Handles Mainexchange.Paint

    End Sub

    Private Sub pnlMenu_Paint(sender As Object, e As PaintEventArgs) Handles pnlMenu.Paint

    End Sub

    Private Sub StaffBtn_Click(sender As Object, e As EventArgs) Handles StaffBtn.Click

    End Sub

    Private Sub pnlHeader_Paint(sender As Object, e As PaintEventArgs) Handles pnlHeader.Paint

    End Sub
End Class
