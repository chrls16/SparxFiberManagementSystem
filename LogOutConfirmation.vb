Public Class LogOutConfirmation

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Simply setting this will close the form and return "Cancel" to the caller
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        ' Simply setting this will close the form and return "OK" to the caller
        Me.DialogResult = DialogResult.OK
    End Sub

End Class