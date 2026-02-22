Imports MySqlConnector
Imports System.Configuration

Public Class frmPayrollUpdate
    ' Private variables for internal state
    Private _connectionString As String = Nothing
    Private _staffId As Integer = 0
    Private _currentDailyRate As Decimal = 0
    Private Const STANDARD_DAYS As Integer = 15 ' Defined standard work days

    ' Property to retrieve connection string from App.config
    Private ReadOnly Property CONNECTION_STRING As String
        Get
            If _connectionString Is Nothing AndAlso Not DesignMode Then
                Try
                    _connectionString = ConfigurationManager.ConnectionStrings("SparxDb").ConnectionString
                Catch
                    _connectionString = String.Empty
                End Try
            End If
            Return If(_connectionString IsNot Nothing, _connectionString, String.Empty)
        End Get
    End Property

    Private Sub frmPayrollUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        LoadPositionOptions()

        ' If ID is passed, load existing data
        If _staffId > 0 Then
            LoadStaffData(_staffId)
            LoadCurrentMonthAttendance()
            CalculatePayroll()
        End If
    End Sub

    Private Sub InitializeForm()
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Setup Positions
        cbPosition.Items.Clear()
        cbPosition.Items.AddRange({"Technician", "Customer Service", "Inventory"})

        ' Setup Daily Rates
        DropDownDailyRate.Items.Clear()
        DropDownDailyRate.Items.AddRange({"365.00", "500.00", "550.00", "600.00", "650.00", "700.00", "750.00", "800.00", "850.00", "900.00", "950.00", "1000.00"})

        ' --- FIELD PERMISSIONS ---
        ' Enable editing for Days Worked
        TxtDaysWorked.ReadOnly = False
        TxtDaysWorked.Enabled = True
        TxtDaysWorked.BackColor = Color.White

        ' Display-only fields
        txtNetPay.ReadOnly = True
        txtNetPay.BackColor = SystemColors.Control
        txtEmployeeID.ReadOnly = True
        txtName.ReadOnly = True
        txtAddress.ReadOnly = True
        txtAttendanceSummary.ReadOnly = True
        txtGrosPay.ReadOnly = True
        txtDeductions.ReadOnly = True
    End Sub

    ' Fetches existing data from the 'staff' table
    Private Sub LoadStaffData(staffId As Integer)
        If String.IsNullOrEmpty(CONNECTION_STRING) Then Return
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Dim query As String = "SELECT first_name, last_name, address, position, daily_rate FROM staff WHERE staff_id = @staffId"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@staffId", staffId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            txtName.Text = $"{If(reader.IsDBNull(0), "", reader.GetString(0))} {If(reader.IsDBNull(1), "", reader.GetString(1))}".Trim()
                            txtAddress.Text = If(reader.IsDBNull(2), "", reader.GetString(2))
                            cbPosition.Text = If(reader.IsDBNull(3), "", reader.GetString(3))
                            If Not reader.IsDBNull(4) Then
                                _currentDailyRate = reader.GetDecimal(4)
                                DropDownDailyRate.Text = _currentDailyRate.ToString("N2")
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading staff: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadCurrentMonthAttendance()
        TxtDaysWorked.Text = STANDARD_DAYS.ToString() ' Default to 15
        txtAttendanceSummary.Text = "Standard: 15 days required"
    End Sub

    ' EVENT HANDLERS FOR DYNAMIC UPDATES
    Private Sub TxtDaysWorked_TextChanged(sender As Object, e As EventArgs) Handles TxtDaysWorked.TextChanged
        CalculatePayroll()
    End Sub

    Private Sub DropDownDailyRate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownDailyRate.SelectedIndexChanged
        CalculatePayroll()
    End Sub

    ' CALCULATION LOGIC
    Private Sub CalculatePayroll()
        Try
            ' 1. Get Base Values
            Dim dailyRate As Decimal = 0
            Decimal.TryParse(DropDownDailyRate.Text, dailyRate)

            Dim daysWorked As Integer = 0
            Integer.TryParse(TxtDaysWorked.Text, daysWorked)

            ' 2. Calculate Gross (Actual Days * Rate)
            ' Note: If they work 15 days, they get 15 * Rate. 
            ' If they work 14 days, they get 14 * Rate.
            Dim totalGross As Decimal = dailyRate * daysWorked
            txtGrosPay.Text = totalGross.ToString("N2")

            ' 3. Calculate Deductions (Absence Deduction)
            ' If daysWorked is 15, deduction is 0.
            ' If daysWorked < 15, deduct the Daily Rate for every missing day.
            Dim absenceDeduction As Decimal = 0

            If daysWorked < STANDARD_DAYS Then
                Dim daysAbsent As Integer = STANDARD_DAYS - daysWorked
                absenceDeduction = daysAbsent * dailyRate
            Else
                absenceDeduction = 0
            End If

            ' Optional: If you still want the 10% statutory tax, keep it here.
            ' Otherwise, if the Daily Rate is the ONLY deduction, use the line below:
            Dim totalDeductions As Decimal = absenceDeduction

            txtDeductions.Text = totalDeductions.ToString("N2")

            ' 4. Calculate Final Net Pay
            ' This results in: (Days Worked * Rate) - (Days Absent * Rate)
            Dim netPay As Decimal = totalGross - totalDeductions

            ' Ensure Net Pay doesn't go below zero
            If netPay < 0 Then netPay = 0

            txtNetPay.Text = netPay.ToString("N2")

        Catch ex As Exception
            ' Error handling
            Console.WriteLine("Calculation Error: " & ex.Message)
        End Try
    End Sub


    Private Function UpdateStaffRecord() As Boolean
        If _staffId <= 0 Then Return False

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                Using trans = conn.BeginTransaction()
                    Try
                        ' 1. Update Staff Table (Position and Rate)
                        Dim staffQuery As String = "UPDATE staff SET position = @pos, daily_rate = @rate WHERE staff_id = @id"
                        Using cmdStaff As New MySqlCommand(staffQuery, conn, trans)
                            cmdStaff.Parameters.AddWithValue("@pos", cbPosition.Text)
                            cmdStaff.Parameters.AddWithValue("@rate", Decimal.Parse(DropDownDailyRate.Text))
                            cmdStaff.Parameters.AddWithValue("@id", _staffId)
                            cmdStaff.ExecuteNonQuery()
                        End Using

                        ' 2. Update or Insert Payroll Table
                        ' We use REPLACE INTO or a cleaner INSERT...ON DUPLICATE KEY UPDATE
                        ' This requires staff_id to be a PRIMARY KEY or UNIQUE in the payroll table
                        Dim payrollQuery As String = "INSERT INTO payroll (staff_id, days_worked, gross_pay, deductions, net_pay) " &
                                               "VALUES (@id, @days, @gross, @ded, @net) " &
                                               "ON DUPLICATE KEY UPDATE " &
                                               "days_worked = VALUES(days_worked), " &
                                               "gross_pay = VALUES(gross_pay), " &
                                               "deductions = VALUES(deductions), " &
                                               "net_pay = VALUES(net_pay)"

                        Using cmdPayroll As New MySqlCommand(payrollQuery, conn, trans)
                            cmdPayroll.Parameters.AddWithValue("@id", _staffId)
                            cmdPayroll.Parameters.AddWithValue("@days", TxtDaysWorked.Text)
                            cmdPayroll.Parameters.AddWithValue("@gross", Decimal.Parse(txtGrosPay.Text))
                            cmdPayroll.Parameters.AddWithValue("@ded", Decimal.Parse(txtDeductions.Text))
                            cmdPayroll.Parameters.AddWithValue("@net", Decimal.Parse(txtNetPay.Text))
                            cmdPayroll.ExecuteNonQuery()
                        End Using

                        trans.Commit()
                        Return True
                    Catch ex As Exception
                        trans.Rollback()
                        Throw ex
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to update database: " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' Call the new dual-table update function
        If UpdateStaffRecord() Then
            MessageBox.Show("Employee Record and Payroll Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            ' This message shows if the function returned False
            MessageBox.Show("Update failed. Please check the database connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' PUBLIC METHODS CALLED BY PAYROLLVIEW
    Public Sub SetStaffId(ByVal staffId As Integer)
        _staffId = staffId
        txtEmployeeID.Text = staffId.ToString()
    End Sub

    Public Sub SetEmployeeName(ByVal name As String)
        txtName.Text = name
    End Sub

    Public Sub SetPosition(ByVal position As String)
        cbPosition.Text = position
    End Sub

    Public Sub SetDailyRate(ByVal dailyRate As String)
        DropDownDailyRate.Text = dailyRate
    End Sub

    Private Sub LoadPositionOptions()
        ' Implementation to load unique positions from DB
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnMarkAttendance_Click(sender As Object, e As EventArgs) Handles btnMarkAttendance.Click
        If _staffId <= 0 Then Return

        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()

                ' 1. Check current attendance status
                Dim checkQuery As String = "SELECT days_worked, last_attended FROM payroll WHERE staff_id = @id"
                Dim currentDays As Integer = 0
                Dim lastDate As Date = Date.MinValue

                Using cmdCheck As New MySqlCommand(checkQuery, conn)
                    cmdCheck.Parameters.AddWithValue("@id", _staffId)
                    Using reader = cmdCheck.ExecuteReader()
                        If reader.Read() Then
                            currentDays = If(reader.IsDBNull(0), 0, reader.GetInt32(0))
                            lastDate = If(reader.IsDBNull(1), Date.MinValue, reader.GetDateTime(1))
                        End If
                    End Using
                End Using

                ' 2. Determine if we should reset
                Dim today As Date = Date.Today
                Dim shouldReset As Boolean = False

                ' Reset logic: 
                ' If last attendance was in a previous month OR
                ' If today is >= 16th and last attendance was < 16th OR
                ' If today is < 16th and last attendance was >= 16th (new month start)
                If lastDate = Date.MinValue Then
                    shouldReset = True
                ElseIf today.Month <> lastDate.Month OrElse today.Year <> lastDate.Year Then
                    shouldReset = True
                ElseIf today.Day >= 16 And lastDate.Day < 16 Then
                    shouldReset = True
                ElseIf today.Day < 16 And lastDate.Day >= 16 Then
                    ' This handles the crossover from the end of a month to the start of a new one
                    shouldReset = True
                End If

                ' 3. Calculate new value
                Dim newDaysWorked As Integer = If(shouldReset, 1, currentDays + 1)

                ' 4. Prevent marking attendance twice in one day (Optional safety)
                If lastDate.Date = today.Date Then
                    MessageBox.Show("Attendance already marked for today!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                ' 5. Update Database
                Dim updateQuery As String = "INSERT INTO payroll (staff_id, days_worked, last_attended) " &
                                      "VALUES (@id, @days, @today) " &
                                      "ON DUPLICATE KEY UPDATE days_worked = @days, last_attended = @today"

                Using cmdUpdate As New MySqlCommand(updateQuery, conn)
                    cmdUpdate.Parameters.AddWithValue("@id", _staffId)
                    cmdUpdate.Parameters.AddWithValue("@days", newDaysWorked)
                    cmdUpdate.Parameters.AddWithValue("@today", today)
                    cmdUpdate.ExecuteNonQuery()
                End Using

                ' Update UI
                TxtDaysWorked.Text = newDaysWorked.ToString()
                CalculatePayroll() ' Recalculate salary immediately

                MessageBox.Show($"Attendance marked! Days worked this period: {newDaysWorked}", "Success")

            End Using
        Catch ex As Exception
            MessageBox.Show("Error marking attendance: " & ex.Message)
        End Try
    End Sub
End Class