Imports System.Drawing

Module Colors

    Public Function Darken(ByVal Color As Color) As Color
        Return Drawing.Color.FromArgb(Color.A, DeductMinZero(Color.R, 20), DeductMinZero(Color.G, 20), DeductMinZero(Color.B, 20))
    End Function

    Public Function Lighten(ByVal Color As Color) As Color
        Return Drawing.Color.FromArgb(Color.A, AddMax255(Color.R, 20), AddMax255(Color.G, 20), AddMax255(Color.B, 20))
    End Function

    Public Function DeductMinZero(ByVal Value As Integer, ByVal Deduction As Integer) As Integer
        If Value - Deduction < 0 Then
            Return 0
        Else
            Return Value - Deduction
        End If
    End Function

    Public Function AddMax255(ByVal Value As Integer, ByVal Addition As Integer) As Integer
        If Value + Addition > 255 Then
            Return 255
        Else
            Return Value + Addition
        End If
    End Function


End Module
