﻿Public Class MessageInfo

    Private Sub MessageInfo_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Timer1.Start()
        Timer1.Interval = 2000
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As System.EventArgs) Handles Timer1.Tick
        Me.Close()
        Me.Dispose()

    End Sub
End Class