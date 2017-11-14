Imports System.Drawing

Module Formatting

    Public Function GetStringFormat(ByVal Alignment As ContentAlignment) As StringFormat
        Dim sfText As New StringFormat
        Select Case Alignment
            Case ContentAlignment.BottomCenter, ContentAlignment.MiddleCenter, ContentAlignment.TopCenter
                sfText.Alignment = StringAlignment.Center
            Case ContentAlignment.BottomLeft, ContentAlignment.MiddleLeft, ContentAlignment.TopLeft
                sfText.Alignment = StringAlignment.Near
            Case ContentAlignment.BottomRight, ContentAlignment.MiddleRight, ContentAlignment.TopRight
                sfText.Alignment = StringAlignment.Far
        End Select
        Select Case Alignment
            Case ContentAlignment.BottomCenter, ContentAlignment.BottomLeft, ContentAlignment.BottomRight
                sfText.LineAlignment = StringAlignment.Far
            Case ContentAlignment.MiddleCenter, ContentAlignment.MiddleLeft, ContentAlignment.MiddleRight
                sfText.LineAlignment = StringAlignment.Center
            Case ContentAlignment.TopCenter, ContentAlignment.TopLeft, ContentAlignment.TopRight
                sfText.LineAlignment = StringAlignment.Near
        End Select
        Return sfText
    End Function

    Public Function RemoveAmpersand(ByVal Text As String) As String
        Return Text.Replace("&", "")
    End Function

End Module
