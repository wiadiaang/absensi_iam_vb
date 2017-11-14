Public Class ok

    Private Sub ok_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
        Timer1.Interval = 2000
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Me.Close()
        Me.Dispose()
    End Sub
End Class