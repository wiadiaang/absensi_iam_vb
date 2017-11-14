Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Windows.Forms

<ToolboxBitmap(GetType(System.Windows.Forms.Panel))> _
        Public Class Panel
    Inherits System.Windows.Forms.Panel

    Private bMouseIsHover As Boolean = False
    Private btMousePointer As Bitmap = New Bitmap(32, 32, Imaging.PixelFormat.Format32bppArgb)

#Region "Generic component"
    Sub New()
        MyBase.New()
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.Opaque, False)
        SetStyle(ControlStyles.EnableNotifyMessage, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Transparent
    End Sub

    <Browsable(False)> _
    Public ReadOnly Property MouseIsHover() As Boolean
        Get
            Return bMouseIsHover
        End Get
    End Property

    Private Sub Panel_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        PaintBackgoundSurface(Me, e)
        PaintBorder(Me, e)
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        MyBase.WndProc(m)
    End Sub

#End Region

#Region "Mouse Events"

    Private Sub Panel_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        bMouseIsHover = True
        CaptureMousePointerImage()
    End Sub

    Private Sub Panel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        bMouseIsHover = False
        Invalidate()
    End Sub

    Private Sub Panel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Invalidate() 'New Rectangle(e.X - 32, e.Y - 32, 64, 64)
    End Sub

#End Region

#Region "Properties"

    Private bMouseReflection As Boolean = True
    <Category("Glass"), _
    Description("Should the mouse cursor reflects on the glass surface.")> _
    Property MouseReflection() As Boolean
        Get
            Return bMouseReflection
        End Get
        Set(ByVal value As Boolean)
            bMouseReflection = value
            Invalidate()
        End Set
    End Property

    Private iOpacity As Integer = 25
    <Category("Glass"), _
    Description("Sets the opacity of the glass (between 0 [transparent] and 255 [opaque])")> _
    Property Opacity() As Integer
        Get
            Return iOpacity
        End Get
        Set(ByVal value As Integer)
            If value > 255 Then value = 255
            If value < 0 Then value = 0
            iOpacity = value
            Invalidate()
        End Set
    End Property

    Private clGlassColor As Color = Color.WhiteSmoke
    <Category("Glass"), _
    Description("Defines the color of the glass. Among good choices (WhiteSmoke, AliceBlue, MistyRose, AntiqueWhite, Ivory, HoneyDew, Lavender")> _
    Property GlassColor() As Color
        Get
            Return clGlassColor
        End Get
        Set(ByVal value As Color)
            clGlassColor = value
            Invalidate()
        End Set
    End Property

#End Region

#Region "Private Properties"
    <Browsable(False)> _
    ReadOnly Property EffectiveBounds() As RectangleF
        Get
            Return New RectangleF(ClientRectangle.X + 2, ClientRectangle.Y + 2, ClientRectangle.Width - 4, ClientRectangle.Height - 4)
        End Get
    End Property

    <Browsable(False)> _
    ReadOnly Property RoundSurface() As GraphicsPath
        Get
            Return RoundCorners(EffectiveBounds, Radius)
        End Get
    End Property

    <Browsable(False)> _
    ReadOnly Property RoundSurfaceInner() As GraphicsPath
        Get
            Dim rect As RectangleF = EffectiveBounds
            rect.Inflate(-1, -1)
            Return RoundCorners(rect, Radius)
        End Get
    End Property

    <Browsable(False)> _
    ReadOnly Property InnerRegion() As Region
        Get
            Dim rgInnerRegion As New Region(RoundSurface)
            Return rgInnerRegion
        End Get
    End Property

    <Browsable(False)> _
    ReadOnly Property OuterRegion() As Region
        Get
            Dim rgOuterRegion As New Region(RoundSurface)
            rgOuterRegion.Xor(ClientRectangle)
            Return rgOuterRegion
        End Get
    End Property

    Private snRadius As Single = 5
    <Browsable(False)> _
    Property Radius() As Single
        Get
            Return snRadius
        End Get
        Set(ByVal value As Single)
            snRadius = value
        End Set
    End Property

#End Region

#Region "Paintings"
    Sub PaintBackgoundSurface(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        With e.Graphics
            .SmoothingMode = SmoothingMode.HighQuality
            .TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            .CompositingQuality = CompositingQuality.HighQuality
        End With
        Dim brGlass As New SolidBrush(Color.FromArgb(Check(Opacity), GlassColor.R, GlassColor.G, GlassColor.B))
        e.Graphics.FillPath(brGlass, RoundSurface)
        PaintHorizontalSurface(sender, e)
        PaintGlowSurface(sender, e)
        PaintReflectiveBands(sender, e)
        PaintLightSource(sender, e)
        If bMouseIsHover Then PaintMouseCursorReflection(sender, e)
    End Sub

    Sub PaintReflectiveBands(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim brGlassReflect As New SolidBrush(Color.FromArgb(Check(Opacity * 0.5), GlassColor.R, GlassColor.G, GlassColor.B))
        Dim grpBand1 As GraphicsPath = CreateReflectiveBand(0.1!, 0.5!, 0.15!)
        Dim grpBand2 As GraphicsPath = CreateReflectiveBand(0.4!, 0.8!, 0.1!)
        e.Graphics.FillPath(brGlassReflect, grpBand1)
        e.Graphics.FillPath(brGlassReflect, grpBand2)
    End Sub

    Sub PaintHorizontalSurface(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim brGlassDark As New SolidBrush(Color.FromArgb(Opacity * 2.5, DeductMinZero(GlassColor.R, 50), DeductMinZero(GlassColor.G, 50), DeductMinZero(GlassColor.B, 50)))
        e.Graphics.ExcludeClip(New Rectangle(EffectiveBounds.Left, EffectiveBounds.Top, EffectiveBounds.Width, EffectiveBounds.Height * 0.66!))
        e.Graphics.FillPath(brGlassDark, RoundSurface)
        e.Graphics.ResetClip()
    End Sub

    Sub PaintGlowSurface(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim brGlassDarkLinear As New LinearGradientBrush( _
            ClientRectangle, _
            Color.FromArgb(0, DeductMinZero(GlassColor.R, 50), DeductMinZero(GlassColor.G, 50), DeductMinZero(GlassColor.B, 50)), _
            Color.FromArgb(Check(Opacity * 2.5), GlassColor.R, GlassColor.G, GlassColor.B), _
            LinearGradientMode.Vertical)
        e.Graphics.FillPath(brGlassDarkLinear, RoundSurfaceInner)
    End Sub

    Function CreateReflectiveBand(ByVal LeftFactor As Single, ByVal RightFactor As Single, ByVal SizeFactor As Single) As GraphicsPath
        Dim grpBand As New GraphicsPath
        With grpBand
            .StartFigure()
            .AddLine(2 + (EffectiveBounds.Width * LeftFactor), 2, 2 + (EffectiveBounds.Width * LeftFactor) + (EffectiveBounds.Width * SizeFactor), 2)
            .AddLine((2 + (EffectiveBounds.Width * LeftFactor)) + (EffectiveBounds.Width * SizeFactor), 2, (2 + (EffectiveBounds.Width * RightFactor)) + (EffectiveBounds.Width * SizeFactor), EffectiveBounds.Top + EffectiveBounds.Height)
            .AddLine((2 + (EffectiveBounds.Width * RightFactor) + (EffectiveBounds.Width * SizeFactor)), 2 + EffectiveBounds.Height, EffectiveBounds.Left + (EffectiveBounds.Width * RightFactor), EffectiveBounds.Top + EffectiveBounds.Height)
            .AddLine(2 + (EffectiveBounds.Width * RightFactor), 2 + EffectiveBounds.Height, 2 + (EffectiveBounds.Width * LeftFactor), 2)
            .CloseFigure()
        End With
        Return grpBand
    End Function

    Sub PaintLightSource(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim rcLight As RectangleF = GetLightBounds(0.75)
        Dim grpLight As New GraphicsPath
        grpLight.StartFigure()
        grpLight.AddEllipse(rcLight)

        Dim brLight As New PathGradientBrush(grpLight)
        brLight.CenterColor = Color.FromArgb(Check(Opacity * 3), 255, 255, 255)
        brLight.SurroundColors = New Color() {Color.FromArgb(0, 255, 255, 255)}

        e.Graphics.ExcludeClip(OuterRegion)
        e.Graphics.FillEllipse(brLight, rcLight)
        e.Graphics.ResetClip()
    End Sub

    Function GetLightBounds(ByVal Size As Single) As RectangleF
        Return New RectangleF(2 - ((EffectiveBounds.Height * Size) \ 2), 2 - ((EffectiveBounds.Height * Size) \ 2), EffectiveBounds.Height * Size, EffectiveBounds.Height * Size)
    End Function

    Sub PaintBorder(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawPath(New Pen(Color.FromArgb(200, 255, 255, 255), 0.5!), RoundSurface)
        e.Graphics.DrawPath(New Pen(Color.FromArgb(255, 0, 0, 0), 0.5!), RoundSurfaceInner)
    End Sub

    Sub PaintMouseCursorReflection(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim ptMouseLocation As Point = Me.PointToClient(Windows.Forms.Cursor.Position)
        ptMouseLocation.Offset(-30, -30)

        Dim clrMatrix As ColorMatrix
        clrMatrix = New ColorMatrix(New Single()() _
               {New Single() {1, 0, 0, 0, 0}, _
                New Single() {0, 1, 0, 0, 0}, _
                New Single() {0, 0, 1, 0, 0}, _
                New Single() {0, 0, 0, 0.1!, 0}, _
                New Single() {0, 0, 0, 0, 1}})

        Dim imgAttributes As New ImageAttributes()
        imgAttributes.SetColorMatrix(clrMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap)

        e.Graphics.ExcludeClip(OuterRegion)
        e.Graphics.DrawImage(btMousePointer, New Rectangle(ptMouseLocation.X, ptMouseLocation.Y, 32, 32), 0, 0, 32, 32, GraphicsUnit.Pixel, imgAttributes)
        e.Graphics.ResetClip()
    End Sub

    Sub CaptureMousePointerImage()
        Dim grPointer As Graphics = Graphics.FromImage(btMousePointer)
        grPointer.Clear(Color.Transparent)
        Windows.Forms.Cursor.Current.Draw(grPointer, New Rectangle(0, 0, 32, 32))
    End Sub

#End Region

End Class
