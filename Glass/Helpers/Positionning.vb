Imports System.Drawing

Module Positionning

    Public Function GetImageDrawingPoint(ByVal ImageSize As Size, ByVal Alignment As ContentAlignment, ByVal ControlSize As Size) As Point
        Dim iHorizPosition As Integer = 0
        Dim iVertPosition As Integer = 0
        Select Case Alignment
            Case ContentAlignment.BottomCenter, ContentAlignment.MiddleCenter, ContentAlignment.TopCenter
                iHorizPosition = ControlSize.Width * 0.5 - ImageSize.Width * 0.5
            Case ContentAlignment.BottomLeft, ContentAlignment.MiddleLeft, ContentAlignment.TopLeft
                iHorizPosition = 2
            Case ContentAlignment.BottomRight, ContentAlignment.MiddleRight, ContentAlignment.TopRight
                iHorizPosition = ControlSize.Width - 2 - ImageSize.Width
        End Select
        Select Case Alignment
            Case ContentAlignment.BottomCenter, ContentAlignment.BottomLeft, ContentAlignment.BottomRight
                iVertPosition = ControlSize.Height - 2 - ImageSize.Height
            Case ContentAlignment.MiddleCenter, ContentAlignment.MiddleLeft, ContentAlignment.MiddleRight
                iVertPosition = ControlSize.Height * 0.5 - ImageSize.Height * 0.5
            Case ContentAlignment.TopCenter, ContentAlignment.TopLeft, ContentAlignment.TopRight
                iVertPosition = 2
        End Select
        Return New Point(iHorizPosition, iVertPosition)
    End Function

End Module
