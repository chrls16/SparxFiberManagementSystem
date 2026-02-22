<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeploy
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        LblDeploy = New Label()
        EnterTechInstruct = New Label()
        txtTechSearch = New TextBox()
        lstItems = New ListBox()
        numQty = New NumericUpDown()
        LblItems = New Label()
        numQtyLbl = New Label()
        LblCuurentStock = New Label()
        btnRemove = New ButtonRounded()
        btnOk = New ButtonRounded()
        btnCancel = New ButtonRounded()
        CType(numQty, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LblDeploy
        ' 
        LblDeploy.AutoSize = True
        LblDeploy.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblDeploy.Location = New Point(12, 22)
        LblDeploy.Name = "LblDeploy"
        LblDeploy.Size = New Size(75, 25)
        LblDeploy.TabIndex = 61
        LblDeploy.Text = "Deploy"
        ' 
        ' EnterTechInstruct
        ' 
        EnterTechInstruct.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        EnterTechInstruct.AutoSize = True
        EnterTechInstruct.BackColor = Color.Transparent
        EnterTechInstruct.Font = New Font("Verdana", 11F)
        EnterTechInstruct.Location = New Point(12, 71)
        EnterTechInstruct.Name = "EnterTechInstruct"
        EnterTechInstruct.Size = New Size(162, 18)
        EnterTechInstruct.TabIndex = 62
        EnterTechInstruct.Text = "Assign to Technician:"
        ' 
        ' txtTechSearch
        ' 
        txtTechSearch.Font = New Font("Segoe UI", 13F)
        txtTechSearch.Location = New Point(12, 102)
        txtTechSearch.Name = "txtTechSearch"
        txtTechSearch.PlaceholderText = "Search technician..."
        txtTechSearch.Size = New Size(267, 31)
        txtTechSearch.TabIndex = 81
        ' 
        ' lstItems
        ' 
        lstItems.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lstItems.FormattingEnabled = True
        lstItems.ItemHeight = 20
        lstItems.Location = New Point(12, 197)
        lstItems.Name = "lstItems"
        lstItems.Size = New Size(262, 284)
        lstItems.TabIndex = 88
        ' 
        ' numQty
        ' 
        numQty.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        numQty.Location = New Point(302, 197)
        numQty.Name = "numQty"
        numQty.Size = New Size(133, 29)
        numQty.TabIndex = 89
        ' 
        ' LblItems
        ' 
        LblItems.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblItems.AutoSize = True
        LblItems.BackColor = Color.Transparent
        LblItems.Font = New Font("Verdana", 11F)
        LblItems.Location = New Point(12, 162)
        LblItems.Name = "LblItems"
        LblItems.Size = New Size(126, 18)
        LblItems.TabIndex = 94
        LblItems.Text = "Selected Items:"
        ' 
        ' numQtyLbl
        ' 
        numQtyLbl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        numQtyLbl.AutoSize = True
        numQtyLbl.BackColor = Color.Transparent
        numQtyLbl.Font = New Font("Verdana", 11F)
        numQtyLbl.Location = New Point(301, 162)
        numQtyLbl.Name = "numQtyLbl"
        numQtyLbl.Size = New Size(130, 18)
        numQtyLbl.TabIndex = 95
        numQtyLbl.Text = "Adjust Quantity:"
        ' 
        ' LblCuurentStock
        ' 
        LblCuurentStock.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblCuurentStock.AutoSize = True
        LblCuurentStock.BackColor = Color.Transparent
        LblCuurentStock.Font = New Font("Verdana", 11F)
        LblCuurentStock.Location = New Point(302, 243)
        LblCuurentStock.Name = "LblCuurentStock"
        LblCuurentStock.Size = New Size(144, 18)
        LblCuurentStock.TabIndex = 96
        LblCuurentStock.Text = "Max Stock:          "
        ' 
        ' btnRemove
        ' 
        btnRemove.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        btnRemove.BackColor = Color.Red
        btnRemove.CornerRadius = 8
        btnRemove.Cursor = Cursors.Hand
        btnRemove.FlatAppearance.BorderSize = 0
        btnRemove.FlatStyle = FlatStyle.Flat
        btnRemove.Font = New Font("Segoe UI", 12F)
        btnRemove.ForeColor = Color.White
        btnRemove.ImageAlign = ContentAlignment.MiddleLeft
        btnRemove.Location = New Point(302, 288)
        btnRemove.Name = "btnRemove"
        btnRemove.Size = New Size(129, 28)
        btnRemove.TabIndex = 98
        btnRemove.Text = "Remove Item"
        btnRemove.UseVisualStyleBackColor = False
        ' 
        ' btnOk
        ' 
        btnOk.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        btnOk.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(255))
        btnOk.CornerRadius = 8
        btnOk.Cursor = Cursors.Hand
        btnOk.FlatAppearance.BorderSize = 0
        btnOk.FlatStyle = FlatStyle.Flat
        btnOk.Font = New Font("Segoe UI", 12F)
        btnOk.ForeColor = Color.White
        btnOk.ImageAlign = ContentAlignment.MiddleLeft
        btnOk.Location = New Point(324, 501)
        btnOk.Name = "btnOk"
        btnOk.Size = New Size(122, 28)
        btnOk.TabIndex = 102
        btnOk.Text = "Ok"
        btnOk.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        btnCancel.BackColor = Color.Red
        btnCancel.CornerRadius = 8
        btnCancel.Cursor = Cursors.Hand
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 12F)
        btnCancel.ForeColor = Color.White
        btnCancel.ImageAlign = ContentAlignment.MiddleLeft
        btnCancel.Location = New Point(195, 501)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(122, 28)
        btnCancel.TabIndex = 101
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' frmDeploy
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(465, 541)
        Controls.Add(btnOk)
        Controls.Add(btnCancel)
        Controls.Add(btnRemove)
        Controls.Add(LblCuurentStock)
        Controls.Add(numQtyLbl)
        Controls.Add(LblItems)
        Controls.Add(numQty)
        Controls.Add(lstItems)
        Controls.Add(txtTechSearch)
        Controls.Add(EnterTechInstruct)
        Controls.Add(LblDeploy)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmDeploy"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmDeploy"
        CType(numQty, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LblDeploy As Label
    Friend WithEvents EnterTechInstruct As Label
    Friend WithEvents txtTechSearch As TextBox
    Friend WithEvents lstItems As ListBox
    Friend WithEvents numQty As NumericUpDown
    Friend WithEvents LblItems As Label
    Friend WithEvents numQtyLbl As Label
    Friend WithEvents LblCuurentStock As Label
    Friend WithEvents btnRemove As ButtonRounded
    Friend WithEvents btnOk As ButtonRounded
    Friend WithEvents btnCancel As ButtonRounded
End Class
