Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.Reflection
Imports WebCam_Capture

Imports Microsoft.VisualBasic.Compatibility
Imports System.Drawing.Imaging
Imports Microsoft.VisualBasic.ApplicationServices

Imports MySql.Data.MySqlClient
Imports FlexCodeSDK
Imports System.Collections.Generic
Imports System.IO
Imports System.Threading
Imports System.IO.Ports
Imports WinSCP
Imports System.Text.RegularExpressions

Public Class FormAbsensi
    'Inherits MarshalByRefObject
    Dim path As String = Application.StartupPath & "\temppic\"
    Private webcam As New WebCam
    Private MyConn As New DataAccess.DatabaseConnection
    Dim WithEvents FPVer As New FlexCodeSDK.FinFPVer
    Private DataStudent As New DataAccess.StudentDataAccess
    Dim SerialInput As String
    Dim ID As String
    Dim FpIndex As Byte
    Dim fdata As String
    Delegate Sub SetTextCallback(newString As String)

    Public Overrides Function InitializeLifetimeService() As Object
        Return Nothing
    End Function
    'TODO! check  internet connection
    Public Function IsConnectionAvailable() As Boolean
        Dim objUrl As New System.Uri("http://brighton.starstudents.co.id/")
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

    Public Sub FormAbsensi_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            If IsConnectionAvailable() = True Then
                Me.JamAnalog.UtcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now)
                Dim todaysdate As String = String.Format("{0:dd-MM-yyyy}", DateTime.Now)
                lbltgl.Text = todaysdate.ToString

                'txtsmartcard.Focus()
                SerialPort1.PortName = "COM3"
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



    'Private Sub txtsmartcard_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsmartcard.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        If txtsmartcard.Text = "" Then
    '            Exit Sub
    '        ElseIf txtsmartcard.Text = "0698548652" Then

    '            System.Diagnostics.Process.Start("shutdown", "-s -t 00")
    '            Me.Close()
    '            Me.Dispose()
    '            ' Shell("shutdown -s")
    '        ElseIf txtsmartcard.Text = "0452578542" Then

    '            System.Diagnostics.Process.Start("shutdown", "-r -t 00")
    '            Me.Close()
    '            Me.Dispose()
    '            ' Shell("shutdown -r")
    '        ElseIf txtsmartcard.Text = "0123456789" Then
    '            Application.Restart()
    '        Else
    '            If IsConnectionAvailable() = False Then
    '                Dim fi As New FormMessageInternet
    '                fi.ShowDialog()
    '            Else
    '                Dim str As String = ""
    '                str = txtsmartcard.Text

    '                Try
    '                    Dim MyConn As New DataAccess.DatabaseConnection
    '                    Dim Ds As New DataSet
    '                    Dim Sql As String = "SELECT  student.smartcard_id,student.student_id,student.name,class.name,student.class_id,student.section_id,student.class_routine_id,student.username,student.PASSWORD,student.year,student.student_code FROM student JOIN class ON class.class_id=student.class_id WHERE student.smartcard_id='" & txtsmartcard.Text & "'"

    '                    Dim da As New MySqlDataAdapter(Sql, MyConn.open)
    '                    da.Fill(Ds, "student")

    '                    If Ds.Tables(0).Rows().Count = 0 Then

    '                        txtName.Text = ""
    '                        txtclass.Text = ""
    '                        txtsmartcard.Text = ""
    '                        txtnis.Text = ""
    '                        Dim f As New MessageInfo

    '                        f.ShowDialog()
    '                        MyConn.close()
    '                        Exit Sub
    '                        clear()


    '                    Else

    '                        'TODO! Cek status login  
    '                        Dim Dslogin As New DataSet
    '                        'Dim SqlLogin As String = "SELECT date_login,date_logout FROM student WHERE smartcard_id='" & str & "' AND student_id='" & TxtStudentId.Text & "'"
    '                        Dim SqlLogin As String = "SELECT date_login,date_logout FROM student WHERE smartcard_id='" & str & "'"
    '                        Dim daLogin As New MySqlDataAdapter(SqlLogin, MyConn.open)
    '                        daLogin.Fill(Dslogin, "student")
    '                        If Dslogin.Tables(0).Rows().Count = 0 Then
    '                            MyConn.close()
    '                            'clear()
    '                            Exit Sub

    '                        Else
    '                            SmartCardID.Text = Ds.Tables(0).Rows(0).Item(0).ToString

    '                            TxtStudentId.Text = Ds.Tables(0).Rows(0).Item(1).ToString
    '                            txtName.Text = Ds.Tables(0).Rows(0).Item(2).ToString
    '                            txtclass.Text = Ds.Tables(0).Rows(0).Item(3).ToString

    '                            ClassID.Text = Ds.Tables(0).Rows(0).Item(4).ToString
    '                            SectionID.Text = Ds.Tables(0).Rows(0).Item(5).ToString
    '                            ClassRoutinID.Text = Ds.Tables(0).Rows(0).Item(6).ToString
    '                            Time.Text = Ds.Tables(0).Rows(0).Item(9).ToString
    '                            txtnis.Text = Ds.Tables(0).Rows(0).Item(10).ToString

    '                            Dim statuslogin As String
    '                            Dim statusLogout As String


    '                            statuslogin = Dslogin.Tables(0).Rows(0).Item(0).ToString
    '                            statusLogout = Dslogin.Tables(0).Rows(0).Item(1).ToString
    '                            Dim todaysdate As String = String.Format("{0:dd-MM-yyyy}", DateTime.Now)
    '                            If statuslogin <> todaysdate.ToString Then




    '                                'INITIALIZE web came
    '                                webcam.InitializeWebCam(PictureVideo)
    '                                webcam.Start()


    '                                'TODO! Fill Text Boxt dengan data yang di dapat dari RFID

    '                                Try


    '                                    tampil()
    '                                    PictureVideo.BringToFront()
    '                                    PictureCapture.SendToBack()
    '                                    PictureVideo.Show()



    '                                    TimerFinger.Start()
    '                                    TimerFinger.Interval = 10000

    '                                    TimerCam.Start()
    '                                    TimerCam.Interval = 5000

    '                                    Dim folder As String = Application.StartupPath & "\Images\"
    '                                    Dim nofoto As String = System.IO.Path.Combine(folder, "scan.gif")
    '                                    picture_finger.Image = Image.FromFile(nofoto)
    '                                    Try
    '                                        Dim myDB As MySqlConnection
    '                                        myDB = New MySqlConnection
    '                                        myDB.ConnectionString = (My.Settings.constring)
    '                                        myDB.Open()
    '                                        If myDB.State = ConnectionState.Open Then
    '                                            FPVer = New FlexCodeSDK.FinFPVer
    '                                            'FPVer.AddDeviceInfo("G900E030579", "09B-3F1-C1F-361-A73", "NUUA-6172-6A39-EDE2-11AC-FVBY")
    '                                            FPVer.AddDeviceInfo("G700E009497", "D80-17D-481-58A-994", "5SJ5-0DD7-FF84-100E-FBED-7W2W")


    '                                            Dim MySqlCommand As New MySqlCommand
    '                                            MySqlCommand.Connection = myDB
    '                                            MySqlCommand.CommandText = "SELECT student_id,finger_id,finger_data From student WHERE student_id='" & TxtStudentId.Text & "'"
    '                                            Dim rd As MySqlDataReader
    '                                            rd = MySqlCommand.ExecuteReader
    '                                            If rd.Read Then
    '                                                FPVer.FPLoad(rd.GetString(0), rd.GetString(1), rd.GetString(2), "SecurityKey")
    '                                                FPVer.FPVerificationStart()
    '                                            Else


    '                                            End If
    '                                            rd.Close()
    '                                            myDB.Close()


    '                                        End If
    '                                    Catch ex As Exception
    '                                        MsgBox(ex.Message.ToArray)
    '                                    End Try

    '                                Catch ex As Exception

    '                                End Try

    '                            ElseIf statusLogout <> todaysdate.ToString And statuslogin = todaysdate.ToString Then
    '                                Dim id As String
    '                                id = TxtStudentId.Text
    '                                'Dim folder As String = Application.StartupPath & "\thumb\"
    '                                Dim folder As String = Application.StartupPath
    '                                Dim filename As String = System.IO.Path.Combine(folder, TxtStudentId.Text & txtsmartcard.Text & ".jpg")
    '                                If File.Exists(filename) Then
    '                                    PictureCapture.Image = Image.FromFile(filename)
    '                                    PictureCapture.SizeMode = PictureBoxSizeMode.StretchImage
    '                                Else
    '                                    Dim nofoto As String = System.IO.Path.Combine(folder, "nopoto.png")
    '                                    PictureCapture.Image = Image.FromFile(nofoto)
    '                                    PictureCapture.SizeMode = PictureBoxSizeMode.StretchImage
    '                                End If

    '                                lblStudentNis.Visible = True
    '                                lblname.Visible = True
    '                                lblStudentClass.Visible = True

    '                                txtName.Text.ToUpper()
    '                                txtclass.Text.ToUpper()
    '                                txtnis.Text.ToUpper()
    '                                txtName.Visible = True
    '                                txtclass.Visible = True
    '                                txtnis.Visible = True
    '                                PictureCapture.Visible = True
    '                                Dim f As New MessageSukses

    '                                f.ShowDialog()

    '                                clear()

    '                            ElseIf statusLogout = todaysdate.ToString And statuslogin = todaysdate.ToString Then
    '                                Dim id As String
    '                                id = TxtStudentId.Text
    '                                Dim folder As String = Application.StartupPath
    '                                Dim filename As String = System.IO.Path.Combine(folder, TxtStudentId.Text & txtsmartcard.Text & ".jpg")
    '                                If File.Exists(filename) Then
    '                                    PictureCapture.Image = Image.FromFile(filename)
    '                                    PictureCapture.SizeMode = PictureBoxSizeMode.StretchImage
    '                                Else
    '                                    Dim nofoto As String = System.IO.Path.Combine(folder, "nopoto.png")
    '                                    PictureCapture.Image = Image.FromFile(nofoto)
    '                                    PictureCapture.SizeMode = PictureBoxSizeMode.StretchImage
    '                                End If


    '                                lblStudentNis.Visible = True
    '                                lblname.Visible = True
    '                                lblStudentClass.Visible = True

    '                                txtName.Visible = True
    '                                txtclass.Visible = True
    '                                txtnis.Visible = True
    '                                txtName.Text.ToUpper()
    '                                txtclass.Text.ToUpper()
    '                                txtnis.Text.ToUpper()
    '                                PictureCapture.Visible = True
    '                                Dim f As New MessageSukses

    '                                f.ShowDialog()

    '                                clear()

    '                            End If
    '                        End If



    '                    End If


    '                Catch ex As Exception
    '                    MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Finally

    '                End Try
    '                'end if connectiom
    '            End If



    '            'END IF Key code
    '        End If
    '        'END IF KEY CODE
    '    End If

    'End Sub
    Sub clear()

        txtsmartcard.Text = ""
        txtName.Text = ""
        txtclass.Text = ""
        txtnis.Text = ""

        PictureCapture.Visible = False
        PictureCapture.Image = Nothing
        PictureVideo.Visible = False
        PictureVideo.Image = Nothing
        picture_finger.Visible = False
        picture_finger.Image = Nothing

        lblStudentNis.Visible = False
        lblname.Visible = False
        lblStudentClass.Visible = False
        txtName.Visible = False
        txtclass.Visible = False
        txtnis.Visible = False

  




    End Sub

    Sub tampil()
        lblStudentNis.Visible = True
        lblname.Visible = True
        lblStudentClass.Visible = True
        TxtStudentId.Visible = False
        txtName.Visible = True
        txtclass.Visible = True
        txtnis.Visible = True
        picture_finger.Visible = True
        txtName.Text.ToUpper()
        txtclass.Text.ToUpper()
        txtnis.Text.ToUpper()

    End Sub

    Private Sub TimerFinger_Tick(sender As Object, e As System.EventArgs) Handles TimerFinger.Tick

        clear()
        'txtsmartcard.Text = ""
        'txtName.Text = ""
        'txtclass.Text = ""
        'txtnis.Text = ""

        'PictureCapture.Visible = False
        ''PictureCapture.Image = Nothing
        'PictureVideo.Visible = False
        ''PictureVideo.Image = Nothing
        'picture_finger.Visible = False
        'picture_finger.Image = Nothing


        'lblStudentNis.Visible = False
        'lblname.Visible = False
        'lblStudentClass.Visible = False
        'txtName.Visible = False
        'txtclass.Visible = False
        'txtnis.Visible = False
        webcam.Stop()
        Application.Restart()





    End Sub



    'TODO! verification
    Private Sub FpVer_FPVerificationID(ByVal ID As String, ByVal FingerNr As FlexCodeSDK.FingerNumber) Handles FPVer.FPVerificationID

        ID = ID
    End Sub


    Private Sub FpVer_FPVerificationStatus(ByVal Status As FlexCodeSDK.VerificationStatus) Handles FPVer.FPVerificationStatus
        If Status = FlexCodeSDK.VerificationStatus.v_OK Then
            Try
                'TODO! Random From 

                Dim sa As String
                sa = DateTime.Now.Ticks.ToString("x")


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
                studentP.images = sa & TxtStudentId.Text & txtnis.Text & ".jpg"


                'TODO! Save data here
                StudentAccess.update_login_student(studentP)
                StudentAccess.saveattendace(studentP)
                StudentAccess.save_finger(studentP)


                PictureCapture = PictureVideo

                PictureVideo.SendToBack()
                PictureCapture.BringToFront()

                'Dim number As Integer

              

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
                Name.Value = sa & TxtStudentId.Text & txtnis.Text & ".jpg"




                With myCommand.Parameters
                    .Add(StudentId)
                    .Add(Name)
                    '.Add(SmartcardId)
                End With
                Dim rdr As MySqlDataReader = myCommand.ExecuteReader
                rdr.Close()
                MyConn.close()

                SaveImageCopy(sa & TxtStudentId.Text & txtnis.Text & ".jpg", PictureCapture.Image)
                '=============================================
                'TODO Upload
                Dim SessionOptions As New SessionOptions
                'With sessionoption
                '    .Protocol = Protocol.Sftp
                '    '.HostName = "http://brighton.starstudents.co.id"
                '    .HostName = "119.2.79.117"
                '    .UserName = "aang"
                '    .Password = "aang04_2017"
                '    .SshHostKeyFingerprint = "ecdsa-sha2-nistp256 256 c1:ee:e8:fc:1d:f5:05:ac:46:19:98:bb:70:d1:69:2e"
                'End With
                With SessionOptions
                    .Protocol = Protocol.Sftp
                    .HostName = "119.2.79.123"
                    .UserName = "stars"
                    .Password = "RKDserver123"
                    .SshHostKeyFingerprint = "ssh-rsa 2048 92:d7:43:0a:9b:4f:b2:9d:57:33:d7:aa:1b:ee:a6:9f"
                End With
                Using session As New Session
                    'todo connect
                    session.Open(SessionOptions)
                    'todo upload files
                    Dim transferoption As New TransferOptions
                    transferoption.TransferMode = TransferMode.Binary

                    Dim pathfolder As String = Application.StartupPath

                    Dim transferresult As TransferOperationResult
                    
                    transferresult = session.PutFiles(path & "\" & sa & TxtStudentId.Text & txtsmartcard.Text & ".jpg", "/home/stars/app-website/subdomain/brighton.starstudents.co.id/uploads/student_image2/", False, transferoption)
                    'transferresult = session.PutFiles(pathfolder & "\" & sa & TxtStudentId.Text.ToString & txtsmartcard.Text & ".jpg", "home/brighton.starstudents.co.id/website/uploads/student_image2/", False, transferoption)
                    transferresult.Check()
                End Using

                '=======================================





                picture_finger.Image = Nothing
                Dim folder As String = Application.StartupPath & "\Images\"
                Dim nofoto As String = System.IO.Path.Combine(folder, "access-success.png")
                picture_finger.Image = Image.FromFile(nofoto)
                picture_finger.SizeMode = PictureBoxSizeMode.StretchImage

            
            
               

                FPVer.FPVerificationStop()

                Dim f As New ok
                f.ShowDialog()



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
            Dim imgFile As System.IO.FileStream = New System.IO.FileStream(My.Application.Info.DirectoryPath & "\finger\FPTemp.BMP", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite)
            Dim fileBytes(imgFile.Length) As Byte
            imgFile.Read(fileBytes, 0, fileBytes.Length)
            imgFile.Close()
            Dim ms As System.IO.MemoryStream = New MemoryStream(fileBytes)
            picture_finger.Image = Image.FromStream(ms)

            picture_finger.Image = Nothing
            Dim folder As String = Application.StartupPath & "\Images\"
            Dim nofoto As String = System.IO.Path.Combine(folder, "access-denied.png")
            picture_finger.Image = Image.FromFile(nofoto)
            picture_finger.SizeMode = PictureBoxSizeMode.StretchImage


            FPVer.FPVerificationStop()
            webcam.Stop()

            'TODO message box Failed
            Dim f As New SuccessOK

            f.ShowDialog()
            clear()

        ElseIf Status = FlexCodeSDK.VerificationStatus.v_VerifyCaptureFingerTouch Then

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


        End If


    End Sub

    Public Sub SaveImageCopy(filename As String, image As Image)
        'Dim pathfolder As String = Application.StartupPath
        'Dim path As String = System.IO.Path.Combine(pathfolder, filename & ".jpg")
        'Dim dest As New Bitmap(image.Width, image.Height)
        'Dim gfx As Graphics = Graphics.FromImage(dest)
        'gfx.DrawImageUnscaled(image, Point.Empty)
        'gfx.Dispose()

        'dest.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg)
        'dest.Dispose()
        Dim pathfolder As String = Application.StartupPath & "\temppic\"
        Dim patho As String = System.IO.Path.Combine(Path, filename)
        Dim dest As New Bitmap(image.Width, image.Height)
        Dim gfx As Graphics = Graphics.FromImage(dest)
        gfx.DrawImageUnscaled(image, Point.Empty)
        gfx.Dispose()

        dest.Save(pathfolder + filename, System.Drawing.Imaging.ImageFormat.Jpeg)
        dest.Dispose()

    End Sub

    Public Sub TimerCam_Tick(sender As System.Object, e As System.EventArgs) Handles TimerCam.Tick
        webcam.Stop()

    End Sub

    Public ReadOnly UnixEpoch As New DateTime(1970, 1, 1)
    ' equivalent to PHP mktime :
    Public Function GetUnixTimestamp(dt As DateTime) As Integer
        Dim span As TimeSpan = dt - UnixEpoch
        Return CInt(span.TotalSeconds)
    End Function

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
        Else ' Same thread, assign string to the textbox
            txtsmartcard.Text = newString

            If txtsmartcard.Text = "" Then
                Exit Sub
            ElseIf txtsmartcard.Text = "0698548652" Then
                System.Diagnostics.Process.Start("shutdown", "-s -t 00")
                Me.Close()
                Me.Dispose()
            ElseIf txtsmartcard.Text = "0452578542" Then
                System.Diagnostics.Process.Start("shutdown", "-r -t 00")
                Me.Close()
                Me.Dispose()
                ' Shell("shutdown -r")
            ElseIf txtsmartcard.Text = "0123456789" Then

                Exit Sub
                Application.Restart()

            Else
                If IsConnectionAvailable() = False Then
                    Dim fi As New FormMessageInternet
                    fi.ShowDialog()
                Else

                    Try
                        Dim MyConn As New DataAccess.DatabaseConnection
                        Dim Ds As New DataSet
                        Dim Sql As String = "SELECT  student.smartcard_id,student.student_id,student.name,class.name,student.class_id,student.section_id,student.class_routine_id,student.username,student.PASSWORD,student.year,student.student_code FROM student JOIN class ON class.class_id=student.class_id WHERE student.smartcard_id='" & txtsmartcard.Text & "'"

                        Dim da As New MySqlDataAdapter(Sql, MyConn.open)
                        da.Fill(Ds, "student")

                        If Ds.Tables(0).Rows().Count = 0 Then

                            txtName.Text = ""
                            txtclass.Text = ""
                            txtsmartcard.Text = ""
                            txtnis.Text = ""
                            Dim f As New MessageInfo

                            f.ShowDialog()
                            MyConn.close()
                            Exit Sub
                           
                            Application.Restart()

                        Else
                            'TODO! Cek status login  
                            Dim Dslogin As New DataSet
                            'Dim SqlLogin As String = "SELECT date_login,date_logout FROM student WHERE smartcard_id='" & str & "' AND student_id='" & TxtStudentId.Text & "'"
                            Dim SqlLogin As String = "SELECT date_login,date_logout FROM student WHERE smartcard_id='" & txtsmartcard.Text & "'"
                            Dim daLogin As New MySqlDataAdapter(SqlLogin, MyConn.open)
                            daLogin.Fill(Dslogin, "student")
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
                                If statuslogin <> todaysdate.ToString Then




                                    'INITIALIZE web came
                                    webcam.InitializeWebCam(PictureVideo)
                                    webcam.Start()

                                    SerialPort1.DtrEnable = False

                                    'TODO! Fill Text Boxt dengan data yang di dapat dari RFID

                                    Try


                                        tampil()
                                        PictureVideo.BringToFront()
                                        PictureCapture.SendToBack()
                                        PictureVideo.Show()
                                        PictureCapture.Show()



                                        TimerFinger.Start()
                                        TimerFinger.Interval = 7000

                                        TimerCam.Start()
                                        TimerCam.Interval = 5000

                                        Dim folder As String = Application.StartupPath & "\Images\"
                                        Dim nofoto As String = System.IO.Path.Combine(folder, "scan.gif")
                                        picture_finger.Image = Image.FromFile(nofoto)
                                        Try
                                            Dim myDB As MySqlConnection
                                            myDB = New MySqlConnection
                                            myDB.ConnectionString = (My.Settings.constring)
                                            myDB.Open()
                                            If myDB.State = ConnectionState.Open Then
                                                FPVer = New FlexCodeSDK.FinFPVer
                                                FPVer.AddDeviceInfo("G900E030579", "09B-3F1-C1F-361-A73", "NUUA-6172-6A39-EDE2-11AC-FVBY")
                                                'FPVer.AddDeviceInfo("G700E009497", "D80-17D-481-58A-994", "5SJ5-0DD7-FF84-100E-FBED-7W2W")


                                                Dim MySqlCommand As New MySqlCommand
                                                MySqlCommand.Connection = myDB
                                                MySqlCommand.CommandText = "SELECT student_id,finger_id,finger_data From student WHERE student_id='" & TxtStudentId.Text & "'"
                                                Dim rd As MySqlDataReader
                                                rd = MySqlCommand.ExecuteReader
                                                If rd.Read Then
                                                    FPVer.FPLoad(rd.GetString(0), rd.GetString(1), rd.GetString(2), "SecurityKey")
                                                    FPVer.FPVerificationStart()
                                                Else


                                                End If
                                                rd.Close()
                                                myDB.Close()


                                            End If
                                        Catch ex As Exception
                                            MsgBox(ex.Message.ToString)
                                        End Try

                                    Catch ex As Exception
                                        MsgBox(ex.Message.ToString)
                                    End Try

                                ElseIf statusLogout <> todaysdate.ToString And statuslogin = todaysdate.ToString Then
                                    Dim id As String
                                    id = TxtStudentId.Text
                                    'Dim folder As String = Application.StartupPath & "\thumb\"
                                    Dim folder As String = Application.StartupPath
                                    Dim filename As String = System.IO.Path.Combine(folder, TxtStudentId.Text & txtsmartcard.Text & ".jpg")
                                    If File.Exists(filename) Then
                                        PictureCapture.Image = Image.FromFile(filename)
                                        PictureCapture.SizeMode = PictureBoxSizeMode.StretchImage
                                    Else
                                        Dim nofoto As String = System.IO.Path.Combine(folder, "nopoto.png")
                                        PictureCapture.Image = Image.FromFile(nofoto)
                                        PictureCapture.SizeMode = PictureBoxSizeMode.StretchImage
                                    End If

                                    lblStudentNis.Visible = True
                                    lblname.Visible = True
                                    lblStudentClass.Visible = True

                                    txtName.Text.ToUpper()
                                    txtclass.Text.ToUpper()
                                    txtnis.Text.ToUpper()
                                    txtName.Visible = True
                                    txtclass.Visible = True
                                    txtnis.Visible = True
                                    PictureCapture.Visible = True
                                    Dim f As New MessageSukses

                                    f.ShowDialog()

                                    clear()

                                ElseIf statusLogout = todaysdate.ToString And statuslogin = todaysdate.ToString Then
                                    Dim id As String
                                    id = TxtStudentId.Text
                                    Dim folder As String = Application.StartupPath
                                    Dim filename As String = System.IO.Path.Combine(folder, TxtStudentId.Text & txtsmartcard.Text & ".jpg")
                                    If File.Exists(filename) Then
                                        PictureCapture.Image = Image.FromFile(filename)
                                        PictureCapture.SizeMode = PictureBoxSizeMode.StretchImage
                                    Else
                                        Dim nofoto As String = System.IO.Path.Combine(folder, "nopoto.png")
                                        PictureCapture.Image = Image.FromFile(nofoto)
                                        PictureCapture.SizeMode = PictureBoxSizeMode.StretchImage
                                    End If


                                    lblStudentNis.Visible = True
                                    lblname.Visible = True
                                    lblStudentClass.Visible = True

                                    txtName.Visible = True
                                    txtclass.Visible = True
                                    txtnis.Visible = True
                                    txtName.Text.ToUpper()
                                    txtclass.Text.ToUpper()
                                    txtnis.Text.ToUpper()
                                    PictureCapture.Visible = True
                                    Dim f As New MessageSukses

                                    f.ShowDialog()

                                    clear()

                                End If
                            End If
                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message.ToString)
                    End Try
                    'SerialPort1.Open()
                End If

            End If




        End If

    End Sub

  
    Private Sub FormAbsensi_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        System.Windows.Forms.Application.ExitThread()
        System.Windows.Forms.Application.Exit()
      
    End Sub


End Class