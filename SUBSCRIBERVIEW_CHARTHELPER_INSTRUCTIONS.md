# Step-by-Step Instructions: Adding Charts to subscriberview.vb using ChartHelper

## Overview
You will add:
1. **Pie Chart 1**: "Subscribers by Plan Type" (in Panel1, which is inside pnlSubsPlan)
2. **Pie Chart 2**: "Account Status Distribution" (in Panel2, which is inside pnlAccDistri)
3. **Configure DataGridView**: Make dgvSubsDeets scrollable and properly configured

---

## STEP 1: Check Your Current Code

Your `subscriberview.vb` currently looks like this:
```vb
Imports LiveCharts
Imports LiveCharts.Wpf
Imports System.Configuration
Imports MySqlConnector
Imports System.Drawing
Imports System.Windows.Media
Imports System.Collections.Generic
Imports LiveCharts.WinForms

Public Class subscriberview
    Inherits UserControl
    Private ReadOnly CONNECTION_STRING As String =
        ConfigurationManager.ConnectionStrings("SparxDb").ConnectionString

    Private ChartServiceStatus As LiveCharts.WinForms.PieChart
    Private ChartSubscribersByPlan As LiveCharts.WinForms.PieChart
    
    Private Sub subscriberview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the view
    End Sub
End Class
```

**Good!** You already have:
- ✅ All necessary imports
- ✅ Chart variables declared
- ✅ Connection string ready

---

## STEP 2: Create a Function to Initialize Charts

**Add this function AFTER the `subscriberview_Load` function:**

```vb
Private Sub CreateCharts()
    ' Create Pie Chart 1: Subscribers by Plan Type
    ' Panel1 is inside pnlSubsPlan
    ChartSubscribersByPlan = ChartHelper.CreatePieChart(
        Panel1, 
        LegendLocation.Bottom)
    
    ' Create Pie Chart 2: Account Status Distribution
    ' Panel2 is inside pnlAccDistri
    ChartServiceStatus = ChartHelper.CreatePieChart(
        Panel2, 
        LegendLocation.Bottom)
    
    ' Configure the DataGridView to be scrollable
    ChartHelper.ConfigureDataGridView(
        dgvSubsDeets, 
        enableScrolling:=True, 
        readOnly:=True)
End Sub
```

**What this does:**
- Creates 2 pie charts using ChartHelper (much simpler than manual creation!)
- Configures your DataGridView to be scrollable
- All in just 3 function calls!

---

## STEP 3: Create Function to Load "Subscribers by Plan" Chart Data

**Add this function AFTER `CreateCharts`:**

```vb
Private Sub LoadSubscribersByPlanChart()
    Try
        Using conn As New MySqlConnection(CONNECTION_STRING)
            conn.Open()
            
            ' Query to get count of subscribers by plan type
            Dim query As String = "SELECT plan_type, COUNT(*) AS count " &
                                  "FROM customer " &
                                  "GROUP BY plan_type"
            
            Using cmd As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    ' Create dictionary to store plan data
                    Dim planData As New Dictionary(Of String, Integer)()
                    
                    ' Read data from database
                    While reader.Read()
                        Dim planType As String = reader("plan_type").ToString()
                        Dim count As Integer = Convert.ToInt32(reader("count"))
                        planData(planType) = count
                    End While
                    
                    ' Update chart using ChartHelper (ONE LINE!)
                    ChartHelper.UpdatePieChart(
                        ChartSubscribersByPlan, 
                        planData, 
                        showPercentages:=True)
                End Using
            End Using
        End Using
    Catch ex As Exception
        MessageBox.Show("Error loading subscribers by plan chart: " & ex.Message)
    End Try
End Sub
```

**What this does:**
- Queries database for plan type counts
- Stores in a Dictionary
- Uses ChartHelper to update the chart (instead of 20+ lines of manual code!)

---

## STEP 4: Create Function to Load "Account Status" Chart Data

**Add this function AFTER `LoadSubscribersByPlanChart`:**

```vb
Private Sub LoadAccountStatusChart()
    Try
        Using conn As New MySqlConnection(CONNECTION_STRING)
            conn.Open()
            
            ' Query to get count of subscribers by account status
            Dim query As String = "SELECT account_status, COUNT(*) AS count " &
                                  "FROM customer " &
                                  "GROUP BY account_status"
            
            Using cmd As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    ' Create dictionary to store status data
                    Dim statusData As New Dictionary(Of String, Integer)()
                    
                    ' Read data from database
                    While reader.Read()
                        Dim status As String = reader("account_status").ToString()
                        Dim count As Integer = Convert.ToInt32(reader("count"))
                        statusData(status) = count
                    End While
                    
                    ' Optional: Create custom color map for status
                    Dim colorMap As New Dictionary(Of String, System.Windows.Media.Color)()
                    colorMap("Active") = System.Windows.Media.Color.FromRgb(34, 197, 94)    ' Green
                    colorMap("Suspended") = System.Windows.Media.Color.FromRgb(249, 115, 22) ' Orange
                    colorMap("Cancelled") = System.Windows.Media.Color.FromRgb(239, 68, 68)  ' Red
                    
                    ' Update chart using ChartHelper with custom colors
                    ChartHelper.UpdatePieChart(
                        ChartServiceStatus, 
                        statusData, 
                        showPercentages:=True,
                        colorMap:=colorMap)
                End Using
            End Using
        End Using
    Catch ex As Exception
        MessageBox.Show("Error loading account status chart: " & ex.Message)
    End Try
End Sub
```

**What this does:**
- Queries database for account status counts
- Creates custom colors (Green for Active, Orange for Suspended, Red for Cancelled)
- Uses ChartHelper to update chart with custom colors

---

## STEP 5: Create Function to Load DataGridView Data

**Add this function AFTER `LoadAccountStatusChart`:**

```vb
Private Sub LoadSubscriberDetails()
    Try
        Using conn As New MySqlConnection(CONNECTION_STRING)
            conn.Open()
            
            ' Query to get all subscriber details
            Dim query As String = "SELECT customer_id, first_name, last_name, " &
                                  "address, plan_type, monthly_rate, " &
                                  "date_installed, account_status " &
                                  "FROM customer " &
                                  "ORDER BY customer_id"
            
            Using cmd As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    ' Create list to store subscriber records
                    Dim subscribers As New List(Of SubscriberRecord)()
                    
                    ' Read data from database
                    While reader.Read()
                        Dim subscriber As New SubscriberRecord()
                        
                        ' Format Customer ID (e.g., 1 -> IN001)
                        Dim customerId As Integer = Convert.ToInt32(reader("customer_id"))
                        subscriber.CustomerID = "IN" & customerId.ToString().PadLeft(3, "0"c)
                        
                        ' Combine first and last name
                        Dim firstName As String = If(reader("first_name") IsNot DBNull.Value, reader("first_name").ToString(), "")
                        Dim lastName As String = If(reader("last_name") IsNot DBNull.Value, reader("last_name").ToString(), "")
                        subscriber.Name = (firstName & " " & lastName).Trim()
                        
                        ' Address
                        subscriber.Address = If(reader("address") IsNot DBNull.Value, reader("address").ToString(), "")
                        
                        ' Plan Type (convert enum to display format)
                        Dim planType As String = If(reader("plan_type") IsNot DBNull.Value, reader("plan_type").ToString(), "")
                        Select Case planType
                            Case "Basic"
                                subscriber.PlanType = "Basic 25Mbps"
                            Case "Standard"
                                subscriber.PlanType = "Standard 50Mbps"
                            Case "Premium"
                                subscriber.PlanType = "Premium 100Mbps"
                            Case Else
                                subscriber.PlanType = planType
                        End Select
                        
                        ' Monthly Rate
                        subscriber.MonthlyRate = If(reader("monthly_rate") IsNot DBNull.Value, Convert.ToDecimal(reader("monthly_rate")), 0)
                        
                        ' Date Installed
                        If reader("date_installed") IsNot DBNull.Value Then
                            subscriber.DateInstalled = Convert.ToDateTime(reader("date_installed"))
                        Else
                            subscriber.DateInstalled = DateTime.Now
                        End If
                        
                        ' Account Status
                        subscriber.Status = If(reader("account_status") IsNot DBNull.Value, reader("account_status").ToString(), "")
                        
                        subscribers.Add(subscriber)
                    End While
                    
                    ' Bind data to DataGridView using ChartHelper (ONE LINE!)
                    ChartHelper.BindDataToGridView(dgvSubsDeets, subscribers)
                End Using
            End Using
        End Using
    Catch ex As Exception
        MessageBox.Show("Error loading subscriber details: " & ex.Message)
    End Try
End Sub
```

**Note:** You'll need to create a `SubscriberRecord` class. See Step 6.

---

## STEP 6: Create SubscriberRecord Class

**Add this class at the END of the file (after `End Class` for subscriberview):**

```vb
Public Class SubscriberRecord
    Public Property CustomerID As String
    Public Property Name As String
    Public Property Address As String
    Public Property PlanType As String
    Public Property MonthlyRate As Decimal
    Public Property DateInstalled As DateTime
    Public Property Status As String
End Class
```

**What this does:**
- Creates a simple class to hold subscriber data
- Properties match your DataGridView column names (CustomerID, Name, Address, etc.)

---

## STEP 7: Update the Load Event

**Replace your current `subscriberview_Load` function with this:**

```vb
Private Sub subscriberview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    ' Step 1: Create the charts
    CreateCharts()
    
    ' Step 2: Load data into charts
    LoadSubscribersByPlanChart()
    LoadAccountStatusChart()
    
    ' Step 3: Load data into table
    LoadSubscriberDetails()
End Sub
```

**What this does:**
- Calls all your functions in the right order
- Creates charts first, then loads data

---

## STEP 8: Optional - Add Timer for Auto-Refresh

**If you want charts to update automatically every 30 seconds, add this:**

**At the top of the class (with other variables):**
```vb
Private updateTimer As Timer
```

**In `subscriberview_Load`, add at the end:**
```vb
' Setup timer for auto-refresh (every 30 seconds)
updateTimer = New Timer()
updateTimer.Interval = 30000  ' 30 seconds
AddHandler updateTimer.Tick, AddressOf Timer_Tick
updateTimer.Start()
```

**Add this function:**
```vb
Private Sub Timer_Tick(sender As Object, e As EventArgs)
    LoadSubscribersByPlanChart()
    LoadAccountStatusChart()
    LoadSubscriberDetails()
End Sub
```

---

## Summary: What You're Replacing

### ❌ BEFORE (Manual Chart Creation - 15+ lines):
```vb
ChartSubscribersByPlan = New LiveCharts.WinForms.PieChart()
ChartSubscribersByPlan.Dock = DockStyle.Fill
ChartSubscribersByPlan.BackColor = System.Drawing.Color.White
ChartSubscribersByPlan.LegendLocation = LegendLocation.Bottom
Panel1.Controls.Add(ChartSubscribersByPlan)
ChartSubscribersByPlan.BringToFront()
' ... more code ...
```

### ✅ AFTER (Using ChartHelper - 1 line):
```vb
ChartSubscribersByPlan = ChartHelper.CreatePieChart(Panel1, LegendLocation.Bottom)
```

---

## Final Code Structure

Your `subscriberview.vb` should have this structure:

```vb
Public Class subscriberview
    ' Variables
    Private ReadOnly CONNECTION_STRING As String = ...
    Private ChartServiceStatus As LiveCharts.WinForms.PieChart
    Private ChartSubscribersByPlan As LiveCharts.WinForms.PieChart
    Private updateTimer As Timer  ' Optional
    
    ' Load event
    Private Sub subscriberview_Load(...)
        CreateCharts()
        LoadSubscribersByPlanChart()
        LoadAccountStatusChart()
        LoadSubscriberDetails()
        ' Optional: Setup timer
    End Sub
    
    ' Chart creation
    Private Sub CreateCharts()
        ' Uses ChartHelper
    End Sub
    
    ' Data loading functions
    Private Sub LoadSubscribersByPlanChart()
        ' Query database, use ChartHelper.UpdatePieChart
    End Sub
    
    Private Sub LoadAccountStatusChart()
        ' Query database, use ChartHelper.UpdatePieChart
    End Sub
    
    Private Sub LoadSubscriberDetails()
        ' Query database, use ChartHelper.BindDataToGridView
    End Sub
    
    ' Optional timer
    Private Sub Timer_Tick(...)
        ' Refresh all data
    End Sub
End Class

' SubscriberRecord class
Public Class SubscriberRecord
    ' Properties
End Class
```

---

## Benefits You Get

1. **Less Code**: 70-80% reduction in chart creation code
2. **Consistency**: All charts look the same
3. **Easy to Maintain**: Change styling in ChartHelper.vb
4. **Reusable**: Use same helper in other views

---

## Testing

1. Build your project (F6)
2. Run it (F5)
3. Navigate to Subscriber view
4. You should see:
   - ✅ Two pie charts with data
   - ✅ Scrollable DataGridView with all subscribers
   - ✅ Charts update automatically (if you added timer)

---

## Troubleshooting

**Problem**: Charts don't show
- **Solution**: Make sure `Panel1` and `Panel2` exist in your Designer file

**Problem**: DataGridView is empty
- **Solution**: Check your database query and make sure `SubscriberRecord` properties match your DataGridView column `DataPropertyName` values

**Problem**: Compile errors
- **Solution**: Make sure `ChartHelper.vb` is in your project and all imports are correct

---

## Next Steps

Once this works, you can:
1. Use the same pattern in other views (Installation, Service, etc.)
2. Customize colors in ChartHelper.vb
3. Add more chart types (bar charts, line charts, etc.)


