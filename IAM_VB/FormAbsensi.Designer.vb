<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAbsensi
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAbsensi))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.JamAnalog = New AnalogClock.Clock()
        Me.picture_finger = New System.Windows.Forms.PictureBox()
        Me.PictureCapture = New System.Windows.Forms.PictureBox()
        Me.PictureVideo = New System.Windows.Forms.PictureBox()
        Me.txtnis = New System.Windows.Forms.Label()
        Me.txtclass = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.Label()
        Me.lblStudentClass = New System.Windows.Forms.Label()
        Me.lblname = New System.Windows.Forms.Label()
        Me.lblStudentNis = New System.Windows.Forms.Label()
        Me.lbltgl = New System.Windows.Forms.Label()
        Me.txtsmartcard = New System.Windows.Forms.TextBox()
        Me.TimerFinger = New System.Windows.Forms.Timer(Me.components)
        Me.SmartCardID = New System.Windows.Forms.Label()
        Me.TxtStudentId = New System.Windows.Forms.Label()
        Me.ClassID = New System.Windows.Forms.Label()
        Me.SectionID = New System.Windows.Forms.Label()
        Me.ClassRoutinID = New System.Windows.Forms.Label()
        Me.Time = New System.Windows.Forms.Label()
        Me.TimerCam = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picture_finger, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureCapture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureVideo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1222, 139)
        Me.Panel1.TabIndex = 58
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(121, 47)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(161, 37)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 1
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(15, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 94)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 139)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1222, 20)
        Me.Panel2.TabIndex = 60
        '
        'JamAnalog
        '
        Me.JamAnalog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.JamAnalog.BackColor = System.Drawing.Color.Transparent
        Me.JamAnalog.BackgroundImage = CType(resources.GetObject("JamAnalog.BackgroundImage"), System.Drawing.Image)
        Me.JamAnalog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.JamAnalog.BigMarkers = New AnalogClock.Marker() {New AnalogClock.Marker("BigMarker90", 90.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("BigMarker60", 60.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("BigMarker30", 30.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("BigMarker0", 0.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("BigMarker330", 330.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("BigMarker300", 300.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("BigMarker270", 270.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("BigMarker240", 240.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("BigMarker210", 210.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("BigMarker180", 180.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("BigMarker150", 150.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("BigMarker120", 120.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing)}
        Me.JamAnalog.BorderStyle = AnalogClock.BorderStyles.Round
        Me.JamAnalog.CenterPoint.PaintAttributes = New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!)
        Me.JamAnalog.CenterPoint.RelativeRadius = 0.03!
        Me.JamAnalog.CenterPoint.Tag = Nothing
        Me.JamAnalog.HourHand.PaintAttributes = New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!)
        Me.JamAnalog.HourHand.RelativeRadius = 0.65!
        Me.JamAnalog.HourHand.Tag = Nothing
        Me.JamAnalog.HourHand.Width = 5.0!
        Me.JamAnalog.Location = New System.Drawing.Point(940, 177)
        Me.JamAnalog.MinuteHand.PaintAttributes = New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!)
        Me.JamAnalog.MinuteHand.RelativeRadius = 0.8!
        Me.JamAnalog.MinuteHand.Tag = Nothing
        Me.JamAnalog.MinuteHand.Width = 5.0!
        Me.JamAnalog.Name = "JamAnalog"
        Me.JamAnalog.SecondHand.PaintAttributes = New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!)
        Me.JamAnalog.SecondHand.RelativeRadius = 0.9!
        Me.JamAnalog.SecondHand.Tag = Nothing
        Me.JamAnalog.SecondHand.Width = 1.0!
        Me.JamAnalog.Size = New System.Drawing.Size(260, 263)
        Me.JamAnalog.SmallMarkers = New AnalogClock.Marker() {New AnalogClock.Marker("SmallMarker90", 90.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker84", 84.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker78", 78.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker72", 72.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker66", 66.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker60", 60.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker54", 54.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker48", 48.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker42", 42.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker36", 36.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker30", 30.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker24", 24.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker18", 18.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker12", 12.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker6", 6.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker0", 0.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker354", 354.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker348", 348.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker342", 342.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker336", 336.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker330", 330.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker324", 324.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker318", 318.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker312", 312.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker306", 306.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker300", 300.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker294", 294.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker288", 288.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker282", 282.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker276", 276.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker270", 270.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker264", 264.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker258", 258.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker252", 252.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker246", 246.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker240", 240.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker234", 234.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker228", 228.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker222", 222.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker216", 216.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker210", 210.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker204", 204.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker198", 198.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker192", 192.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker186", 186.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker180", 180.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker174", 174.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker168", 168.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker162", 162.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker156", 156.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker150", 150.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker144", 144.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker138", 138.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker132", 132.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker126", 126.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker120", 120.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker114", 114.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker108", 108.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker102", 102.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing), New AnalogClock.Marker("SmallMarker96", 96.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 130.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias, Nothing)}
        Me.JamAnalog.Symbols = New AnalogClock.Symbol() {New AnalogClock.Symbol("Symbol90", 90.0!, "12", New System.Drawing.Font("Engravers MT", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 0, True, True, AnalogClock.SymbolStyle.Numeric, 130.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault, Nothing), New AnalogClock.Symbol("Symbol60", 60.0!, "1", New System.Drawing.Font("Engravers MT", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 1, True, True, AnalogClock.SymbolStyle.Numeric, 130.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault, Nothing), New AnalogClock.Symbol("Symbol30", 30.0!, "2", New System.Drawing.Font("Engravers MT", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 2, True, True, AnalogClock.SymbolStyle.Numeric, 130.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault, Nothing), New AnalogClock.Symbol("Symbol0", 0.0!, "3", New System.Drawing.Font("Engravers MT", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 3, True, True, AnalogClock.SymbolStyle.Numeric, 130.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault, Nothing), New AnalogClock.Symbol("Symbol330", 330.0!, "4", New System.Drawing.Font("Engravers MT", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 4, True, True, AnalogClock.SymbolStyle.Numeric, 130.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault, Nothing), New AnalogClock.Symbol("Symbol300", 300.0!, "5", New System.Drawing.Font("Engravers MT", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 5, True, True, AnalogClock.SymbolStyle.Numeric, 130.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault, Nothing), New AnalogClock.Symbol("Symbol270", 270.0!, "6", New System.Drawing.Font("Engravers MT", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 6, True, True, AnalogClock.SymbolStyle.Numeric, 130.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault, Nothing), New AnalogClock.Symbol("Symbol240", 240.0!, "7", New System.Drawing.Font("Engravers MT", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 7, True, True, AnalogClock.SymbolStyle.Numeric, 130.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault, Nothing), New AnalogClock.Symbol("Symbol210", 210.0!, "8", New System.Drawing.Font("Engravers MT", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 8, True, True, AnalogClock.SymbolStyle.Numeric, 130.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault, Nothing), New AnalogClock.Symbol("Symbol180", 180.0!, "9", New System.Drawing.Font("Engravers MT", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 9, True, True, AnalogClock.SymbolStyle.Numeric, 130.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault, Nothing), New AnalogClock.Symbol("Symbol150", 150.0!, "10", New System.Drawing.Font("Engravers MT", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 10, True, True, AnalogClock.SymbolStyle.Numeric, 130.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault, Nothing), New AnalogClock.Symbol("Symbol120", 120.0!, "11", New System.Drawing.Font("Engravers MT", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 11, True, True, AnalogClock.SymbolStyle.Numeric, 130.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault, Nothing)}
        Me.JamAnalog.TabIndex = 61
        '
        'picture_finger
        '
        Me.picture_finger.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picture_finger.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picture_finger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picture_finger.Location = New System.Drawing.Point(972, 453)
        Me.picture_finger.Name = "picture_finger"
        Me.picture_finger.Size = New System.Drawing.Size(228, 243)
        Me.picture_finger.TabIndex = 62
        Me.picture_finger.TabStop = False
        Me.picture_finger.Visible = False
        '
        'PictureCapture
        '
        Me.PictureCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureCapture.Location = New System.Drawing.Point(15, 181)
        Me.PictureCapture.Name = "PictureCapture"
        Me.PictureCapture.Size = New System.Drawing.Size(646, 389)
        Me.PictureCapture.TabIndex = 63
        Me.PictureCapture.TabStop = False
        Me.PictureCapture.Visible = False
        '
        'PictureVideo
        '
        Me.PictureVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureVideo.Location = New System.Drawing.Point(15, 181)
        Me.PictureVideo.Name = "PictureVideo"
        Me.PictureVideo.Size = New System.Drawing.Size(646, 389)
        Me.PictureVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureVideo.TabIndex = 64
        Me.PictureVideo.TabStop = False
        Me.PictureVideo.Visible = False
        '
        'txtnis
        '
        Me.txtnis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtnis.AutoSize = True
        Me.txtnis.BackColor = System.Drawing.Color.Transparent
        Me.txtnis.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnis.ForeColor = System.Drawing.Color.White
        Me.txtnis.Location = New System.Drawing.Point(165, 532)
        Me.txtnis.Name = "txtnis"
        Me.txtnis.Size = New System.Drawing.Size(67, 29)
        Me.txtnis.TabIndex = 126
        Me.txtnis.Text = "Name"
        Me.txtnis.Visible = False
        '
        'txtclass
        '
        Me.txtclass.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtclass.AutoSize = True
        Me.txtclass.BackColor = System.Drawing.Color.Transparent
        Me.txtclass.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtclass.ForeColor = System.Drawing.Color.White
        Me.txtclass.Location = New System.Drawing.Point(164, 667)
        Me.txtclass.Name = "txtclass"
        Me.txtclass.Size = New System.Drawing.Size(67, 29)
        Me.txtclass.TabIndex = 125
        Me.txtclass.Text = "Name"
        Me.txtclass.Visible = False
        '
        'txtName
        '
        Me.txtName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtName.AutoSize = True
        Me.txtName.BackColor = System.Drawing.Color.Transparent
        Me.txtName.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.ForeColor = System.Drawing.Color.White
        Me.txtName.Location = New System.Drawing.Point(164, 598)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(67, 29)
        Me.txtName.TabIndex = 124
        Me.txtName.Text = "Name"
        Me.txtName.Visible = False
        '
        'lblStudentClass
        '
        Me.lblStudentClass.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStudentClass.AutoSize = True
        Me.lblStudentClass.BackColor = System.Drawing.Color.Transparent
        Me.lblStudentClass.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStudentClass.ForeColor = System.Drawing.Color.White
        Me.lblStudentClass.Location = New System.Drawing.Point(46, 667)
        Me.lblStudentClass.Name = "lblStudentClass"
        Me.lblStudentClass.Size = New System.Drawing.Size(120, 29)
        Me.lblStudentClass.TabIndex = 123
        Me.lblStudentClass.Text = "GRADE      :"
        Me.lblStudentClass.Visible = False
        '
        'lblname
        '
        Me.lblname.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblname.AutoSize = True
        Me.lblname.BackColor = System.Drawing.Color.Transparent
        Me.lblname.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.Color.White
        Me.lblname.Location = New System.Drawing.Point(46, 598)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(122, 29)
        Me.lblname.TabIndex = 122
        Me.lblname.Text = "NAME         :"
        Me.lblname.Visible = False
        '
        'lblStudentNis
        '
        Me.lblStudentNis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStudentNis.AutoSize = True
        Me.lblStudentNis.BackColor = System.Drawing.Color.Transparent
        Me.lblStudentNis.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStudentNis.ForeColor = System.Drawing.Color.White
        Me.lblStudentNis.Location = New System.Drawing.Point(46, 532)
        Me.lblStudentNis.Name = "lblStudentNis"
        Me.lblStudentNis.Size = New System.Drawing.Size(122, 29)
        Me.lblStudentNis.TabIndex = 121
        Me.lblStudentNis.Text = "NIS              :"
        Me.lblStudentNis.Visible = False
        '
        'lbltgl
        '
        Me.lbltgl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltgl.AutoSize = True
        Me.lbltgl.BackColor = System.Drawing.Color.Transparent
        Me.lbltgl.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltgl.ForeColor = System.Drawing.Color.White
        Me.lbltgl.Location = New System.Drawing.Point(1019, 443)
        Me.lbltgl.Name = "lbltgl"
        Me.lbltgl.Size = New System.Drawing.Size(115, 29)
        Me.lbltgl.TabIndex = 127
        Me.lbltgl.Text = "0000-00-00"
        '
        'txtsmartcard
        '
        Me.txtsmartcard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtsmartcard.Location = New System.Drawing.Point(972, 309)
        Me.txtsmartcard.Name = "txtsmartcard"
        Me.txtsmartcard.Size = New System.Drawing.Size(199, 20)
        Me.txtsmartcard.TabIndex = 1
        '
        'TimerFinger
        '
        '
        'SmartCardID
        '
        Me.SmartCardID.AutoSize = True
        Me.SmartCardID.Location = New System.Drawing.Point(594, 598)
        Me.SmartCardID.Name = "SmartCardID"
        Me.SmartCardID.Size = New System.Drawing.Size(67, 13)
        Me.SmartCardID.TabIndex = 129
        Me.SmartCardID.Text = "SmartCardID"
        Me.SmartCardID.Visible = False
        '
        'TxtStudentId
        '
        Me.TxtStudentId.AutoSize = True
        Me.TxtStudentId.Location = New System.Drawing.Point(594, 614)
        Me.TxtStudentId.Name = "TxtStudentId"
        Me.TxtStudentId.Size = New System.Drawing.Size(68, 13)
        Me.TxtStudentId.TabIndex = 130
        Me.TxtStudentId.Text = "TxtStudentId"
        Me.TxtStudentId.Visible = False
        '
        'ClassID
        '
        Me.ClassID.AutoSize = True
        Me.ClassID.Location = New System.Drawing.Point(594, 636)
        Me.ClassID.Name = "ClassID"
        Me.ClassID.Size = New System.Drawing.Size(43, 13)
        Me.ClassID.TabIndex = 131
        Me.ClassID.Text = "ClassID"
        Me.ClassID.Visible = False
        '
        'SectionID
        '
        Me.SectionID.AutoSize = True
        Me.SectionID.Location = New System.Drawing.Point(594, 649)
        Me.SectionID.Name = "SectionID"
        Me.SectionID.Size = New System.Drawing.Size(54, 13)
        Me.SectionID.TabIndex = 132
        Me.SectionID.Text = "SectionID"
        Me.SectionID.Visible = False
        '
        'ClassRoutinID
        '
        Me.ClassRoutinID.AutoSize = True
        Me.ClassRoutinID.Location = New System.Drawing.Point(594, 667)
        Me.ClassRoutinID.Name = "ClassRoutinID"
        Me.ClassRoutinID.Size = New System.Drawing.Size(74, 13)
        Me.ClassRoutinID.TabIndex = 133
        Me.ClassRoutinID.Text = "ClassRoutinID"
        Me.ClassRoutinID.Visible = False
        '
        'Time
        '
        Me.Time.AutoSize = True
        Me.Time.Location = New System.Drawing.Point(594, 693)
        Me.Time.Name = "Time"
        Me.Time.Size = New System.Drawing.Size(30, 13)
        Me.Time.TabIndex = 134
        Me.Time.Text = "Time"
        Me.Time.Visible = False
        '
        'TimerCam
        '
        '
        'SerialPort1
        '
        '
        'FormAbsensi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1222, 718)
        Me.ControlBox = False
        Me.Controls.Add(Me.JamAnalog)
        Me.Controls.Add(Me.Time)
        Me.Controls.Add(Me.ClassRoutinID)
        Me.Controls.Add(Me.SectionID)
        Me.Controls.Add(Me.ClassID)
        Me.Controls.Add(Me.TxtStudentId)
        Me.Controls.Add(Me.SmartCardID)
        Me.Controls.Add(Me.lbltgl)
        Me.Controls.Add(Me.txtnis)
        Me.Controls.Add(Me.txtclass)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblStudentClass)
        Me.Controls.Add(Me.lblname)
        Me.Controls.Add(Me.lblStudentNis)
        Me.Controls.Add(Me.PictureVideo)
        Me.Controls.Add(Me.PictureCapture)
        Me.Controls.Add(Me.picture_finger)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtsmartcard)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormAbsensi"
        Me.Text = "FormAbsensi"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picture_finger, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureCapture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureVideo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents JamAnalog As AnalogClock.Clock
    Friend WithEvents picture_finger As System.Windows.Forms.PictureBox
    Friend WithEvents PictureCapture As System.Windows.Forms.PictureBox
    Friend WithEvents PictureVideo As System.Windows.Forms.PictureBox
    Friend WithEvents txtnis As System.Windows.Forms.Label
    Friend WithEvents txtclass As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.Label
    Friend WithEvents lblStudentClass As System.Windows.Forms.Label
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents lblStudentNis As System.Windows.Forms.Label
    Friend WithEvents lbltgl As System.Windows.Forms.Label
    Friend WithEvents txtsmartcard As System.Windows.Forms.TextBox
    Friend WithEvents TimerFinger As System.Windows.Forms.Timer
    Friend WithEvents SmartCardID As System.Windows.Forms.Label
    Friend WithEvents TxtStudentId As System.Windows.Forms.Label
    Friend WithEvents ClassID As System.Windows.Forms.Label
    Friend WithEvents SectionID As System.Windows.Forms.Label
    Friend WithEvents ClassRoutinID As System.Windows.Forms.Label
    Friend WithEvents Time As System.Windows.Forms.Label
    Friend WithEvents TimerCam As System.Windows.Forms.Timer
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
End Class
