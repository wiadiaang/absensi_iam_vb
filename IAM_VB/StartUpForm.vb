Public Class StartUpForm


    Public Sub New()
        MyBase.New()
        InitializeComponent()

        Splash1Setting()
    End Sub

    Private Sub Splash1Setting()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterScreen
        'Me.BackgroundImage = VBWinFormSplashScreen.My.Resources.SplashImage
        axWMP.URL = Application.StartupPath & "\Video\startup.mov"
        axWMP.settings.setMode("loop", True)
        axWMP.stretchToFit = True
        axWMP.uiMode = "none"
    End Sub

    Private Sub StartUpForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Timer1.Start()
        Timer1.Interval = 7000
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
      
        Timer1.Stop()


        Me.Close()

        'Dim f As New FormSignSignout
        'f.txtsmartcard.Focus()
    End Sub
End Class