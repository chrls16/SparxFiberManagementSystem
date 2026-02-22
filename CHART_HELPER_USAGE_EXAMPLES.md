# ChartHelper Usage Examples

This document shows you how to use the `ChartHelper` class to easily create charts and tables without repeating code.

## 1. Creating a Bar Chart (CartesianChart)

### Before (Repeating Code):
```vb
Private Sub CreateSalesChart()
    ChartMonthlySales = New LiveCharts.WinForms.CartesianChart()
    ChartMonthlySales.Dock = DockStyle.Fill
    ChartMonthlySales.BackColor = System.Drawing.Color.White
    ChartMonthlySales.Location = New Point(0, 40)
    ChartMonthlySales.Size = New Size(pnlMonthlySalesVol.Width, pnlMonthlySalesVol.Height - 50)
    PanelRound1.Controls.Add(ChartMonthlySales)
    ChartMonthlySales.BringToFront()
End Sub
```

### After (Using ChartHelper):
```vb
Private Sub CreateSalesChart()
    ChartMonthlySales = ChartHelper.CreateBarChart(
        PanelRound1, 
        xAxisTitle:="Month", 
        yAxisTitle:="Sales Volume",
        enableScrolling:=True)
End Sub
```

## 2. Updating a Bar Chart with Data

### Before:
```vb
Private Sub UpdateSalesChart(values As ChartValues(Of Double), labels As List(Of String))
    If ChartMonthlySales.Series.Count = 0 Then
        Dim axisX As New Axis()
        axisX.Title = "Month"
        axisX.Labels = labels
        ' ... lots of code ...
    End If
End Sub
```

### After:
```vb
Private Sub UpdateSalesChart(values As ChartValues(Of Double), labels As List(Of String))
    ChartHelper.UpdateBarChart(
        ChartMonthlySales,
        values,
        labels,
        seriesTitle:="Sales",
        enableScrolling:=True)
End Sub
```

## 3. Creating a Pie Chart

### Before:
```vb
ChartServiceStatus = New LiveCharts.WinForms.PieChart()
ChartServiceStatus.Dock = DockStyle.Fill
ChartServiceStatus.BackColor = System.Drawing.Color.White
ChartServiceStatus.LegendLocation = LegendLocation.Bottom
Panel2.Controls.Add(ChartServiceStatus)
ChartServiceStatus.BringToFront()
```

### After:
```vb
ChartServiceStatus = ChartHelper.CreatePieChart(Panel2, LegendLocation.Bottom)
```

## 4. Updating a Pie Chart with Data

### Before:
```vb
Dim pieSeries As New SeriesCollection()
For Each kvp In planData
    Dim percentage As Double = If(total > 0, (kvp.Value / total) * 100, 0)
    Dim displayText As String = String.Format("{0}: {1} ({2:F0}%)", kvp.Key, kvp.Value, percentage)
    Dim pieSeriesItem As New PieSeries()
    ' ... lots of code ...
Next
```

### After:
```vb
ChartHelper.UpdatePieChart(ChartServiceStatus, planData, showPercentages:=True)
```

## 5. Configuring a DataGridView

### Before:
```vb
dgvRecentSales.ReadOnly = True
dgvRecentSales.AllowUserToAddRows = False
dgvRecentSales.ScrollBars = ScrollBars.Vertical
dgvRecentSales.BackgroundColor = System.Drawing.Color.White
' ... more configuration ...
```

### After:
```vb
ChartHelper.ConfigureDataGridView(dgvRecentSales, enableScrolling:=True, readOnly:=True)
```

## 6. Binding Data to DataGridView

### Before:
```vb
dgvRecentSales.DataSource = Nothing
Application.DoEvents()
Dim bindingSource As New BindingSource()
bindingSource.DataSource = salesRecords
dgvRecentSales.DataSource = bindingSource
dgvRecentSales.Refresh()
' ... more code ...
```

### After:
```vb
ChartHelper.BindDataToGridView(dgvRecentSales, salesRecords)
```

## Complete Example: Refactored salesview.vb

```vb
Imports System.Configuration
Imports MySqlConnector

Public Class salesview
    Private ReadOnly CONNECTION_STRING As String =
        ConfigurationManager.ConnectionStrings("SparxDb").ConnectionString
    
    Private ChartMonthlySales As LiveCharts.WinForms.CartesianChart
    Private updateTimer As Timer

    Private Sub salesview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Create chart using helper
        ChartMonthlySales = ChartHelper.CreateBarChart(
            PanelRound1,
            xAxisTitle:="Month",
            yAxisTitle:="Sales Volume",
            enableScrolling:=True)
        
        ' Configure DataGridView using helper
        ChartHelper.ConfigureDataGridView(dgvRecentSales, enableScrolling:=True)
        
        ' Load data
        LoadMonthlySalesChart()
        LoadRecentSales()
        
        ' Setup timer
        updateTimer = New Timer()
        updateTimer.Interval = 30000
        AddHandler updateTimer.Tick, AddressOf Timer_Tick
        updateTimer.Start()
    End Sub

    Private Sub LoadMonthlySalesChart()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                ' ... query database ...
                Dim values As New ChartValues(Of Double)()
                Dim labels As New List(Of String)()
                ' ... populate values and labels ...
                
                ' Update chart using helper
                ChartHelper.UpdateBarChart(
                    ChartMonthlySales,
                    values,
                    labels,
                    seriesTitle:="Sales",
                    enableScrolling:=True)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadRecentSales()
        Try
            Using conn As New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                ' ... query database ...
                Dim salesRecords As New List(Of SalesRecord)()
                ' ... populate salesRecords ...
                
                ' Bind data using helper
                ChartHelper.BindDataToGridView(dgvRecentSales, salesRecords)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
End Class
```

## Benefits

1. **Less Code**: Reduces chart/table creation code by 70-80%
2. **Consistency**: All charts look and behave the same way
3. **Easy to Maintain**: Change chart styling in one place (ChartHelper)
4. **Reusable**: Use the same helper across all views
5. **Type-Safe**: Uses generics for DataGridView binding


