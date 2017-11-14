Module Checks

    Public Function Check(ByVal Value As Integer) As Integer
        If Value > 255 Then
            Return 255
        ElseIf Value < 0 Then
            Return 0
        Else
            Return Value
        End If
    End Function

End Module
