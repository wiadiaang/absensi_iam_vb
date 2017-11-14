Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design

Public Module RoundedCorners

    Public Function RoundCorners(ByVal Rectangle As RectangleF, Optional ByVal Radius As Integer = 5, Optional ByVal Corners As Corner = Corner.All) As Drawing2D.GraphicsPath
        Dim p As New Drawing2D.GraphicsPath
        Dim x As Single = Rectangle.X
        Dim y As Single = Rectangle.Y
        Dim w As Single = Rectangle.Width
        Dim h As Single = Rectangle.Height
        Dim r As Integer = Radius

        p.StartFigure()
        'top left arc
        If CBool(Corners And Corner.TopLeft) Then
            p.AddArc(New RectangleF(x, y, 2 * r, 2 * r), 180, 90)
        Else
            p.AddLine(New PointF(x, y + r), New PointF(x, y))
            p.AddLine(New PointF(x, y), New PointF(x + r, y))
        End If

        'top line
        p.AddLine(New PointF(x + r, y), New PointF(x + w - r, y))

        'top right arc
        If CBool(Corners And Corner.TopRight) Then
            p.AddArc(New RectangleF(x + w - 2 * r, y, 2 * r, 2 * r), 270, 90)
        Else
            p.AddLine(New PointF(x + w - r, y), New PointF(x + w, y))
            p.AddLine(New PointF(x + w, y), New PointF(x + w, y + r))
        End If

        'right line
        p.AddLine(New PointF(x + w, y + r), New PointF(x + w, y + h - r))

        'bottom right arc
        If CBool(Corners And Corner.BottomRight) Then
            p.AddArc(New RectangleF(x + w - 2 * r, y + h - 2 * r, 2 * r, 2 * r), 0, 90)
        Else
            p.AddLine(New PointF(x + w, y + h - r), New PointF(x + w, y + h))
            p.AddLine(New PointF(x + w, y + h), New PointF(x + w - r, y + h))
        End If

        'bottom line
        p.AddLine(New PointF(x + w - r, y + h), New PointF(x + r, y + h))

        'bottom left arc
        If CBool(Corners And Corner.BottomLeft) Then
            p.AddArc(New RectangleF(x, y + h - 2 * r, 2 * r, 2 * r), 90, 90)
        Else
            p.AddLine(New PointF(x + r, y + h), New PointF(x, y + h))
            p.AddLine(New PointF(x, y + h), New PointF(x, y + h - r))
        End If

        'left line
        p.AddLine(New PointF(x, y + h - r), New PointF(x, y + r))

        'close figure...
        p.CloseFigure()

        Return p
    End Function

    <Flags()> _
    Public Enum Corner
        None = 0
        TopLeft = 1
        TopRight = 2
        BottomLeft = 4
        BottomRight = 8
        All = TopLeft Or TopRight Or BottomLeft Or BottomRight
        AllTop = TopLeft Or TopRight
        AllLeft = TopLeft Or BottomLeft
        AllRight = TopRight Or BottomRight
        AllBottom = BottomLeft Or BottomRight
    End Enum

End Module


