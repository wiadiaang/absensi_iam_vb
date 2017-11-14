Public Class MessageSukses



    Private Sub MessageSukses_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Timer1.Start()
        Timer1.Interval = 2000

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As System.EventArgs) Handles Timer1.Tick
        Me.Close()
        Me.Dispose()
        'Application.Restart()
    End Sub
End Class