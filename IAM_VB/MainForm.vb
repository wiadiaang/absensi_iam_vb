Option Explicit On
Imports System.IO
Imports AForge.Video.DirectShow
Imports AForge.Video
Imports System.Text.RegularExpressions
Imports FlexCodeSDK
Imports MySql.Data.MySqlClient
Imports WinSCP
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Public Class MainForm

    'Dim path As String = My.Application.Info.DirectoryPath
    Dim path As String = Application.StartupPath & "\temppic"
    Private MyConn As New DataAccess.DatabaseConnection
    Private ExistenDispositivos As Boolean = False
    Private DispositivosDeVideo As FilterInfoCollection
    Private WithEvents capturing As VideoCaptureDevice = Nothing
    Delegate Sub SetTextCallback(newString As String)

    Dim WithEvents FPVer As New FlexCodeSDK.FinFPVer

    Dim SerialInput As String
    Dim ID As String
    Dim FpIndex As Byte

    'TODO! initialize config
    Public Sub Terminar()
        Try
            If Not (capturing Is Nothing) Then
                If capturing.IsRunning Then
                    capturing.SignalToStop()
                    capturing = Nothing
                End If
            End If
        Catch ex As Exception
            ex.Message.ToUpper()
        End Try
    End Sub

    'TODO! cek connection internet
    Public Function IsConnectionAvailable() As Boolean
        'Dim objUrl As New System.Uri("http://brighton.starstudents.co.id/")
        Dim objUrl As New System.Uri("http://google.com/")
        Dim objWebReq As System.Net.WebRequest
        objWebReq = System.Net.WebRequest.Create(objUrl)
        Dim objresp As System.Net.WebResponse

        Try
            objresp = objWebReq.GetResponse
            objresp.Close()
            objresp = Nothing
            Return True

        Catch ex As Exception
            objresp = Nothing
            objWebReq = Nothing
            Return False
        End Try
    End Function

    Private Sub MainForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            If IsConnectionAvailable() = True Then
                Me.Clock1.UtcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now)
                Dim todaysdate As String = String.Format("{0:dd-MM-yyyy}", DateTime.Now)
                lbltgl.Text = todaysdate.ToString
                Buscar_Dispositivos()
                If SerialPort1.IsOpen Then
                    SerialPort1.Close()
                End If
                'txtsmartcard.Focus()
                SerialPort1.PortName = "COM11"
                SerialPort1.BaudRate = Convert.ToInt32("9600")
                SerialPort1.Open()
            Else
                Dim f As New FormMessageInternet
                f.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub SerialPort1_DataReceived(sender As System.Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Try
            Dim str As String = Trim(SerialPort1.ReadLine())
            Dim data As String = Regex.Replace(str, "[^\d]", String.Empty)
            SerialPort1.Close()
            SetText(data)
            SerialPort1.Open()
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try


    End Sub

    'TODO! invoke textbox
    Private Sub SetText(ByVal newString As String)
        ' Calling from another thread? -> Use delegate
        If txtsmartcard.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText)
            ' Execute delegate in the UI thread, pass args as an array
            Invoke(d, New Object() {newString})
        Else
            txtsmartcard.Text = newString
            Try
                'TODO! Shutdown PC
                If txtsmartcard.Text = "0698548652" Then
                    System.Diagnostics.Process.Start("shutdown", "-s -t 00")
                    Me.Close()
                    Me.Dispose()

                    'TODO! Restart PC
                ElseIf txtsmartcard.Text = "0452578542" Then
                    System.Diagnostics.Process.Start("shutdown", "-r -t 00")
                    Me.Close()
                    Me.Dispose()
                    'TODO! Restart Application
                    'ElseIf txtsmartcard.Text = "0123456789" Then
                ElseIf txtsmartcard.Text = "0003099610" Then
                    Application.ExitThread()
                    Application.Restart()


                ElseIf txtsmartcard.Text = "" Then
                    Exit Sub
                Else
                    'TODO! Cek koneksi Internet
                    If IsConnectionAvailable() = False Then
                        Dim fi As New FormMessageInternet
                        fi.ShowDialog()
                    Else

                        If lblstatus.Text = "Ready" Then
                            If ExistenDispositivos Then
                                Try
                                    Dim x As Long
                                    x = Convert.ToUInt64(txtsmartcard.Text)
                                    'TODO! Check student to database by smartcard
                                    Dim MyConn As New DataAccess.DatabaseConnection
                                    Dim Ds As New DataSet
                                    Dim Sql As String = "SELECT  student.smartcard_id,student.student_id,student.name,class.name,student.class_id,student.section_id,student.class_routine_id,student.username,student.PASSWORD,student.year,student.student_code FROM student JOIN class ON class.class_id=student.class_id WHERE student.smartcard_id='" & x & "'"

                                    Dim da As New MySqlDataAdapter(Sql, MyConn.open)
                                    da.Fill(Ds, "student")

                                    'if empty row student
                                    If Ds.Tables(0).Rows().Count = 0 Then

                                        txtName.Text = ""
                                        txtclass.Text = ""
                                        txtsmartcard.Text = ""
                                        txtnis.Text = ""
                                        Dim f As New MessageInfo

                                        f.ShowDialog()
                                        MyConn.close()
                                        Exit Sub



                                    Else

                                        'TODO! Cek status login 

                                        Dim Dslogin As New DataSet
                                        'Dim SqlLogin As String = "SELECT date_login,date_logout FROM student WHERE smartcard_id='" & str & "' AND student_id='" & TxtStudentId.Text & "'"
                                        Dim SqlLogin As String = "SELECT date_login,date_logout FROM student WHERE smartcard_id='" & txtsmartcard.Text & "'"
                                        Dim daLogin As New MySqlDataAdapter(SqlLogin, MyConn.open)
                                        daLogin.Fill(Dslogin, "student")

                                        'if empty status login
                                        If Dslogin.Tables(0).Rows().Count = 0 Then
                                            MyConn.close()

                                            Exit Sub

                                        Else

                                            SmartCardID.Text = Ds.Tables(0).Rows(0).Item(0).ToString

                                            TxtStudentId.Text = Ds.Tables(0).Rows(0).Item(1).ToString
                                            txtName.Text = Ds.Tables(0).Rows(0).Item(2).ToString
                                            txtclass.Text = Ds.Tables(0).Rows(0).Item(3).ToString

                                            ClassID.Text = Ds.Tables(0).Rows(0).Item(4).ToString
                                            SectionID.Text = Ds.Tables(0).Rows(0).Item(5).ToString
                                            ClassRoutinID.Text = Ds.Tables(0).Rows(0).Item(6).ToString
                                            Time.Text = Ds.Tables(0).Rows(0).Item(9).ToString
                                            txtnis.Text = Ds.Tables(0).Rows(0).Item(10).ToString

                                            Dim statuslogin As String
                                            Dim statusLogout As String


                                            statuslogin = Dslogin.Tables(0).Rows(0).Item(0).ToString
                                            statusLogout = Dslogin.Tables(0).Rows(0).Item(1).ToString
                                            Dim todaysdate As String = String.Format("{0:dd-MM-yyyy}", DateTime.Now)


                                            'TODO! check attendance login or logout
                                            If statuslogin <> todaysdate.ToString Then
                                                TimerProcess.Start()
                                                TimerProcess.Interval = 5000

                                                Pic.Image = Nothing
                                                Pic.Visible = True
                                                capturing = New VideoCaptureDevice(DispositivosDeVideo(Webcam.SelectedIndex).MonikerString)
                                                AddHandler capturing.NewFrame, New NewFrameEventHandler(AddressOf video)
                                                capturing.Start()
                                                lblstatus.Text = "Wait.."
                                                Webcam.Enabled = False

                                                'REGION IMAGE===========
                                                picture_finger.Visible = True
                                                picture_finger.Image = Nothing
                                                Dim folder As String = Application.StartupPath & "\Images\"
                                                Dim nofoto As String = System.IO.Path.Combine(folder, "scan.gif")
                                                picture_finger.Image = Image.FromFile(nofoto)
                                                picture_finger.SizeMode = PictureBoxSizeMode.StretchImage
                                                '=== END IMAGE ==========

                                                '====REGION Verifikasi finger device =========
                                                Try
                                                    Dim myDB As MySqlConnection
                                                    myDB = New MySqlConnection
                                                    myDB.ConnectionString = (My.Settings.constring)
                                                    myDB.Open()
                                                    If myDB.State = ConnectionState.Open Then
                                                        FPVer = New FlexCodeSDK.FinFPVer
                                                        'FPVer.AddDeviceInfo("G900E030579", "09B-3F1-C1F-361-A73", "NUUA-6172-6A39-EDE2-11AC-FVBY") 'demo
                                                        'FPVer.AddDeviceInfo("GX00E030421", "C64-A21-E29-163-DC7", "FPC6-46F6-7033-2AB7-9ADB-8VGF") 'kotwis
                                                        'FPVer.AddDeviceInfo("H200E017383", "BC0-36C-CE4-940-05E", "KHKB-2AA5-4810-A671-4AE3-7HYK") 'ddn
                                                        FPVer.AddDeviceInfo("G700E009497", "D80-17D-481-58A-994", "5SJ5-0DD7-FF84-100E-FBED-7W2W") 'brighton



                                                        Dim MySqlCommand As New MySqlCommand
                                                        MySqlCommand.Connection = myDB
                                                        MySqlCommand.CommandText = "SELECT student_id,finger_id,finger_data From student WHERE student_id='" & TxtStudentId.Text & "'"
                                                        Dim rd As MySqlDataReader
                                                        rd = MySqlCommand.ExecuteReader
                                                        If rd.Read Then
                                                            FPVer.FPLoad(rd.GetString(0), rd.GetString(1), rd.GetString(2), "SecurityKey")
                                                            FPVer.FPVerificationStart()


                                                            '=== Visible TextBox ======
                                                            'txtnis.Text = "12046676"
                                                            'txtName.Text = "Aang Wiadi"
                                                            'txtclass.Text = "9A"
                                                            lblStudentNis.Visible = True
                                                            lblname.Visible = True
                                                            lblStudentClass.Visible = True
                                                            txtnis.Visible = True
                                                            txtName.Visible = True
                                                            txtclass.Visible = True


                                                        Else


                                                        End If
                                                        rd.Close()
                                                        myDB.Close()


                                                    End If
                                                Catch ex As Exception
                                                    MsgBox(ex.Message.ToString)
                                                End Try
                                                '====== END Region verifikasi finger device ========

                                            ElseIf statusLogout <> todaysdate.ToString And statuslogin = todaysdate.ToString Then
                                                Dim f As New MessageSukses
                                                f.ShowDialog()
                                            ElseIf statusLogout = todaysdate.ToString And statuslogin = todaysdate.ToString Then
                                                Dim f As New MessageSukses
                                                f.ShowDialog()

                                            End If  'end if check attendance login or logout

                                        End If 'End if empty status login


                                    End If 'End if empty row student




                                Catch ex As Exception

                                End Try






                            End If
                            'SerialPort1.Close()
                        Else
                            If capturing.IsRunning Then
                                Terminar()
                                lblstatus.Text = "Wait.."
                                Webcam.Enabled = True
                                'Capturar.Enabled = False
                            End If
                            'SerialPort1.Close()
                        End If

                    End If 'END cek koneksi internet


                End If


            Catch ex As Exception
                ex.Message.ToUpper()
            End Try
        End If
        SerialPort1.Close()
    End Sub
    Public Sub Buscar_Dispositivos()
        Try
            DispositivosDeVideo = New FilterInfoCollection(FilterCategory.VideoInputDevice)
            If DispositivosDeVideo.Count = 0 Then
                ExistenDispositivos = False
            Else
                ExistenDispositivos = True
                Cargar_Dispositivos()
                btnInitialize.Enabled = True
            End If
        Catch ex As Exception
            ex.Message.ToUpper()
        End Try
    End Sub
    Public Sub Cargar_Dispositivos()
        Try
            For i As Integer = 0 To DispositivosDeVideo.Count - 1
                Webcam.Items.Add(DispositivosDeVideo(i).Name.ToString())
            Next
            Webcam.Text = Webcam.Items(0).ToString()
        Catch ex As Exception
            ex.Message.ToUpper()
        End Try
    End Sub
    'Accedemos
    Private Sub video(ByVal sender As Object, ByVal eventArgs As NewFrameEventArgs)
        Try
            Dim Imagen As Bitmap = DirectCast(eventArgs.Frame.Clone(), Bitmap)
            Pic.Image = Imagen
        Catch ex As Exception
            ex.Message.ToUpper()
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        foto.Image = Pic.Image
        foto.Image.Save(path & "\" & txtsmartcard.Text & ".jpg")
        If (btnInitialize.Text = "Wait..") Then
            Terminar()
        End If
        btnInitialize.Text = "ok"
    End Sub


    'TODO! REGION FLEXCODE
    Private Sub FpVer_FPVerificationID(ByVal ID As String, ByVal FingerNr As FlexCodeSDK.FingerNumber) Handles FPVer.FPVerificationID

        ID = ID
    End Sub


    Private Sub FpVer_FPVerificationStatus(ByVal Status As FlexCodeSDK.VerificationStatus) Handles FPVer.FPVerificationStatus
        If Status = FlexCodeSDK.VerificationStatus.v_VerifyCaptureFingerTouch Then
            'TODO! Capture image when finger devices touch...

            'Dim sa As String
            'sa = DateTime.Now.Ticks.ToString("x")
            'foto.Image = Pic.Image
            ''foto.Image.Save(path & "\" & sa & txtsmartcard.Text & ".jpg")
            ''SaveImageCopy(sa & TxtStudentId.Text & txtnis.Text & ".jpg", foto.Image)
            If (lblstatus.Text = "Wait..") Then
                Terminar()
            End If
            TimerProcess.Stop()

            picture_finger.Image = Nothing
            Dim imgFile As System.IO.FileStream = New System.IO.FileStream(My.Application.Info.DirectoryPath & "\finger\FPTemp.BMP", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite)
            Dim fileBytes(imgFile.Length) As Byte
            imgFile.Read(fileBytes, 0, fileBytes.Length)
            imgFile.Close()
            Dim ms As System.IO.MemoryStream = New MemoryStream(fileBytes)
            picture_finger.Image = Image.FromStream(ms)
            picture_finger.SizeMode = PictureBoxSizeMode.StretchImage
            ms.Close()
            ms.Dispose()

        ElseIf Status = FlexCodeSDK.VerificationStatus.v_OK Then
            Try
                'TODO! Random From 

                Dim sa As String
                sa = DateTime.Now.Ticks.ToString("x")
                foto.Image = Pic.Image

                'foto.Image.Save(path & "\" & sa & TxtStudentId.Text & txtnis.Text & txtsmartcard.Text & ".jpg")


                If IsNothing(foto.Image) Then
                    Dim f As New MessageInfo

                    f.ShowDialog()

                    picture_finger.Visible = False
                    Pic.Visible = False
                    lblStudentNis.Visible = False
                    lblname.Visible = False
                    lblStudentClass.Visible = False
                    txtnis.Visible = False
                    txtName.Visible = False
                    txtclass.Visible = False

                    TimerProcess.Stop()
                    If (lblstatus.Text = "Wait..") Then
                        Terminar()
                    End If
                    lblstatus.Text = "Ready"
                    FPVer.FPVerificationStop()
                    Exit Sub

                Else
                    SaveImageCopy(sa & TxtStudentId.Text & txtnis.Text & txtsmartcard.Text & ".jpg", foto.Image)

                End If


                'Dim bmp1 As New Bitmap(path & "\" & sa & TxtStudentId.Text & txtnis.Text & txtsmartcard.Text & ".jpg")


                If (lblstatus.Text = "Wait..") Then
                    Terminar()
                End If


                Dim studentP As New StudentProperty
                Dim StudentAccess As New DataAccess.StudentDataAccess
                studentP.student_id = TxtStudentId.Text
                studentP.nisn = txtnis.Text
                studentP.name = txtName.Text
                studentP.class_id = ClassID.Text
                studentP.section_id = SectionID.Text
                studentP.class_routine_id = ClassRoutinID.Text
                'studentP.smartcard_id = txtsmartcard.Text
                studentP.year = Time.Text
                studentP.images = sa & TxtStudentId.Text & txtnis.Text & txtsmartcard.Text & ".jpg"

                'TODO! Cek koneksi Internet
                If IsConnectionAvailable() = False Then
                    Dim fi As New FormMessageInternet
                    fi.ShowDialog()


                Else
                    'TODO! Save data here
                    StudentAccess.update_login_student(studentP)
                    StudentAccess.saveattendace(studentP)
                    StudentAccess.save_finger(studentP)


                    '==============================================
                    Dim SqliMAGE As String = ""
                    'SqliMAGE = "UPDATE student SET images=@images WHERE student_id= @StudentId  AND  smartcard_id=@Smartcard_Id"
                    SqliMAGE = "UPDATE student SET images=@images WHERE student_id= @StudentId "
                    Dim myCommand As MySqlCommand = New MySqlCommand(SqliMAGE, MyConn.open)
                    myCommand.CommandType = CommandType.Text

                    Dim StudentId As MySqlParameter = New MySqlParameter("@StudentId", MySqlDbType.Int32, 11)
                    StudentId.Value = TxtStudentId.Text
                    'Dim SmartcardId As MySqlParameter = New MySqlParameter("@Smartcard_Id", MySqlDbType.Int32)
                    'SmartcardId.Value = txtsmartcard.Text
                    Dim Name As MySqlParameter = New MySqlParameter("@images", MySqlDbType.VarChar, 225)
                    Name.Value = sa & TxtStudentId.Text & txtnis.Text & txtsmartcard.Text & ".jpg"




                    With myCommand.Parameters
                        .Add(StudentId)
                        .Add(Name)
                        '.Add(SmartcardId)
                    End With
                    Dim rdr As MySqlDataReader = myCommand.ExecuteReader
                    rdr.Close()
                    MyConn.close()

                    FPVer.FPVerificationStop()
                    '=============================================
                    'TODO Upload
                    Dim sessionoption As New SessionOptions
                    With sessionoption
                        .Protocol = Protocol.Sftp
                        .HostName = "119.2.79.125"
                        .UserName = "stars"
                        .Password = "Rembon#100"
                        .SshHostKeyFingerprint = "ecdsa-sha2-nistp256 256 ca:88:de:5d:70:c7:4f:86:b6:e0:cd:d3:e3:e4:67:03"
                    End With
                    Using session As New Session
                        'todo connect
                        session.Open(sessionoption)
                        'todo upload files
                        Dim transferoption As New TransferOptions
                        transferoption.TransferMode = TransferMode.Binary




                        Dim transferresult As TransferOperationResult
                        
                        transferresult = session.PutFiles(path & "\" & sa & TxtStudentId.Text & txtnis.Text & txtsmartcard.Text & ".jpg", "/home/stars/public_html/storage/brighton.starstudents.co.id/uploads/student_image2/", True, transferoption)
                        'transferresult = session.PutFiles(path & "\" & sa & TxtStudentId.Text & txtnis.Text & txtsmartcard.Text & ".jpg", "/home/star/public_html/brighton.starstudents.co.id/uploads/student_image2/", True, transferoption)
                        'transferresult = session.PutFiles(pathfolder & "\" & sa & TxtStudentId.Text.ToString & txtsmartcard.Text & ".jpg", "home/brighton.starstudents.co.id/website/uploads/student_image2/", False, transferoption)
                        transferresult.Check()
                    End Using

                    '=======================================






                    picture_finger.Image = Nothing
                    Dim folder As String = Application.StartupPath & "\Images\"
                    Dim nofoto As String = System.IO.Path.Combine(folder, "access-success.png")
                    picture_finger.Image = Image.FromFile(nofoto)
                    picture_finger.SizeMode = PictureBoxSizeMode.StretchImage



                    Dim f As New ok
                    f.ShowDialog()

                    picture_finger.Visible = False
                    Pic.Visible = False
                    lblStudentNis.Visible = False
                    lblname.Visible = False
                    lblStudentClass.Visible = False
                    txtnis.Visible = False
                    txtName.Visible = False
                    txtclass.Visible = False

                    TimerProcess.Stop()
                    If (lblstatus.Text = "Wait..") Then
                        Terminar()
                    End If
                    lblstatus.Text = "Ready"

                End If
            Catch ex As Exception
                'MessageBox.Show(ex.Message.ToString)
            End Try


            'Dim path As String = Application.StartupPath & "\thumb"
            'Dim directory As New IO.DirectoryInfo(path)
            'For Each file As IO.FileInfo In directory.GetFiles
            '    If file.Extension.Equals(".jpg") AndAlso (Now - file.CreationTime).Days > 7 Then
            '        file.Delete()
            '    End If
            'Next



        ElseIf Status = FlexCodeSDK.VerificationStatus.v_NotMatch Then
        'Dim imgFile As System.IO.FileStream = New System.IO.FileStream(My.Application.Info.DirectoryPath & "\finger\FPTemp.BMP", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite)
        'Dim fileBytes(imgFile.Length) As Byte
        'imgFile.Read(fileBytes, 0, fileBytes.Length)
        'imgFile.Close()
        'Dim ms As System.IO.MemoryStream = New MemoryStream(fileBytes)
        'picture_finger.Image = Image.FromStream(ms)



            picture_finger.Image = Nothing
            Dim folder As String = Application.StartupPath & "\Images\"
            Dim nofoto As String = System.IO.Path.Combine(folder, "access-denied.png")
            picture_finger.Image = Image.FromFile(nofoto)
            picture_finger.SizeMode = PictureBoxSizeMode.StretchImage




           

            'TODO message box Failed

            Dim f As New MessageInfo

            f.ShowDialog()



            picture_finger.Visible = False
            Pic.Visible = False
            lblStudentNis.Visible = False
            lblname.Visible = False
            lblStudentClass.Visible = False
            txtnis.Visible = False
            txtName.Visible = False
            txtclass.Visible = False

            TimerProcess.Stop()
            If (lblstatus.Text = "Wait..") Then
                Terminar()
            End If
            lblstatus.Text = "Ready"

            FPVer.FPVerificationStop()
        End If


    End Sub

    Public Sub SaveImageCopy(filename As String, image As Image)

        Dim pathfolder As String = Application.StartupPath & "\temppic\"
        Dim patho As String = System.IO.Path.Combine(Path, filename)
        Dim dest As New Bitmap(image.Width, image.Height)
        Dim gfx As Graphics = Graphics.FromImage(dest)
        gfx.DrawImageUnscaled(image, Point.Empty)
        gfx.Dispose()

        dest.Save(pathfolder + filename, System.Drawing.Imaging.ImageFormat.Jpeg)
        dest.Dispose()

    End Sub

    Private Sub TimerProcess_Tick(sender As System.Object, e As System.EventArgs) Handles TimerProcess.Tick
        'reset
        If (lblstatus.Text = "Wait..") Then
            Terminar()
        End If

        lblstatus.Text = "Ready"

        'stop verification finger


        'visible all main data

        picture_finger.Visible = False
        Pic.Visible = False
        lblStudentNis.Visible = False
        lblname.Visible = False
        lblStudentClass.Visible = False
        txtnis.Visible = False
        txtName.Visible = False
        txtclass.Visible = False
        'Application.ExitThread()
        TimerProcess.Stop()
        FPVer.FPVerificationStop()

    End Sub

    Public Shared Function ResizeImage(ByVal image As Image, _
   ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Dim newWidth As Integer
        Dim newHeight As Integer
        If preserveAspectRatio Then
            Dim originalWidth As Integer = image.Width
            Dim originalHeight As Integer = image.Height
            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
            Dim percent As Single = If(percentHeight < percentWidth,
        percentHeight, percentWidth)
            newWidth = CInt(originalWidth * percent)
            newHeight = CInt(originalHeight * percent)
        Else
            newWidth = size.Width
            newHeight = size.Height
        End If
        Dim newImage As Image = New Bitmap(newWidth, newHeight)
        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function
    Private Function GetEncoder(ByVal format As ImageFormat) As ImageCodecInfo

        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()

        Dim codec As ImageCodecInfo
        For Each codec In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next codec
        Return Nothing

    End Function
End Class