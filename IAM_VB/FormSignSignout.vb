Imports System
Imports System.IO
Imports System.Collections
Imports System.ComponentModel
Imports System.IO.Ports
Imports System.Threading
Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.Reflection
Imports WebCam_Capture
Imports Microsoft.VisualBasic.Compatibility
Imports System.Drawing.Imaging
Imports Microsoft.VisualBasic.ApplicationServices
Imports WinSCP

Public Class FormSignSignout

    Private webcam As WebCam
    Private MyConn As New DataAccess.DatabaseConnection
    Dim WithEvents FPVer As New FlexCodeSDK.FinFPVer
    Private DataStudent As New DataAccess.StudentDataAccess
    Dim tick As Integer = 270
    Private DispString As String
    Dim receivedData As String = ""
    Dim tick2 As Integer = 270

    Private Sub FormSignSignout_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Private Sub FormSignSignout_Load(sender As System.Object, New System.EventArgs) Handles MyBase.Load
     
        If IsConnectionAvailable() = True Then
            Dim f As New StartUpForm
            f.ShowDialog()
            txtsmartcard.Focus()
            webcam = New WebCam()
            webcam.InitializeWebCam(PictureBox1)


            webcam.Start()


            Me.Clock1.UtcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now)
            Dim todaysdate As String = String.Format("{0:dd-MM-yyyy}", DateTime.Now)
            lbltgl.Text = todaysdate.ToString



            Dim versionNumber As Version
            versionNumber = Assembly.GetExecutingAssembly().GetName().Version


            Dim dset As New DataSet
            Dim sqlset As String = "SELECT description FROM settings WHERE settings_id = '21'"
            Dim daset As New MySqlDataAdapter(sqlset, MyConn.open)
            daset.Fill(dset, "settings")
            If dset.Tables(0).Rows.Count = 0 Then
                Exit Sub
                Me.Close()
            Else
                lblTA.Text = dset.Tables(0).Rows(0).Item(0).ToString
            End If

            Try
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            clear()
        Else
            txtsmartcard.Enabled = False
            Me.Refresh()
            Me.FormSignSignout_Load(sender, e)

            Me.Show()
            txtsmartcard.Enabled = True
            clear()
        End If


    End Sub

    Public Function IsConnectionAvailable() As Boolean
        Dim objUrl As New System.Uri("http://www.youtube.com")
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

    'Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
    '    clear()

    'End Sub
    'Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
    '    clear()

    'End Sub

    'Private Sub btnSignIn_Click(sender As System.Object, e As System.EventArgs) Handles btnSignIn.Click
    '    Try
    '        Dim studentP As New StudentProperty
    '        Dim StudentAccess As New DataAccess.StudentDataAccess
    '        studentP.student_id = txtstudentid.Text
    '        studentP.name = txtName.Text
    '        studentP.class_id = class_id.Text
    '        studentP.class_routine_id = class_routin_id.Text
    '        studentP.smartcard_id = smartcard_id.Text
    '        studentP.year = Time.Text
    '        Dim f As New FormImageFingerPrint
    '        f.Label1.Text = txtstudentid.Text
    '        f.Label2.Text = txtName.Text
    '        f.Label3.Text = class_id.Text
    '        f.Label4.Text = class_routin_id.Text
    '        f.Label5.Text = smartcard_id.Text
    '        f.lblTA.Text = lblTA.Text
    '        f.ShowDialog()
    '    Catch SqlEx As MySqlException
    '        Throw New Exception(SqlEx.Message.ToString())
    '    End Try
    '    clear()
    'End Sub



    Sub clear()
        txtstudentid.Text = ""
        txtsmartcard.Text = ""
        txtName.Text = ""
        txtclass.Text = ""
        class_id.Text = ""
        class_routin_id.Text = ""
        smartcard_id.Text = ""
        section_id.Text = ""
        Time.Text = ""
        txtnis.Text = ""

        PictureBox1.Image = Nothing
        PictureBox4.Image = Nothing

        PanelImage.Visible = False
        lblStudentid.Visible = False
        lblname.Visible = False
        lblStudentClass.Visible = False
        txtstudentid.Visible = False
        txtName.Visible = False
        txtclass.Visible = False
        txtnis.Visible = False
        PictureBox1.Visible = False
        PictureBox4.Visible = False

        txtsmartcard.Focus()
    End Sub

    'Private Sub btnSignOut_Click(sender As System.Object, e As System.EventArgs) Handles btnSignOut.Click
    '    Try
    '        Dim studentP As New StudentProperty
    '        Dim StudentAccess As New DataAccess.StudentDataAccess
    '        studentP.student_id = txtstudentid.Text
    '        studentP.name = txtName.Text
    '        studentP.class_id = class_id.Text
    '        studentP.class_routine_id = class_routin_id.Text
    '        studentP.smartcard_id = smartcard_id.Text
    '        studentP.year = Time.Text
    '        Dim f As New FormImageFingerOut
    '        f.Label1.Text = txtstudentid.Text
    '        f.Label2.Text = txtName.Text
    '        f.Label3.Text = class_id.Text
    '        f.Label4.Text = class_routin_id.Text
    '        f.Label5.Text = smartcard_id.Text
    '        f.lblTA.Text = lblTA.Text
    '        f.ShowDialog()
    '    Catch SqlEx As MySqlException
    '        Throw New Exception(SqlEx.Message.ToString())
    '    End Try
    '    clear()
    'End Sub








    Private Sub txtsmartcard_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtsmartcard.KeyDown
        If e.KeyCode = Keys.Enter Then



            'MessageBox.Show("Enter key pressed")
            If txtsmartcard.Text = "" Then
                Exit Sub
            ElseIf txtsmartcard.Text = "0698548652" Then

                System.Diagnostics.Process.Start("shutdown", "-s -t 00")
                Me.Close()
                Me.Dispose()
                ' Shell("shutdown -s")
            ElseIf txtsmartcard.Text = "0452578542" Then

                System.Diagnostics.Process.Start("shutdown", "-r -t 00")
                Me.Close()
                Me.Dispose()
                ' Shell("shutdown -r")
            Else
                webcam.Start()

                PictureBox1.Visible = True
                PictureBox4.Visible = True
                'PictureBox1.Capture = True
                PictureBox1.BringToFront()
                PictureBox4.SendToBack()
                Button1_Click_1(sender, e)
                Dim str As String = ""

                str = txtsmartcard.Text
                'TextBox1.Text = str
                Try
                    Dim MyConn As New DataAccess.DatabaseConnection
                    Dim Ds As New DataSet
                    Dim Sql As String = "SELECT  student.smartcard_id,student.student_id,student.name,class.name,student.class_id,student.section_id,student.class_routine_id,student.username,student.PASSWORD,student.year,student.student_code FROM student JOIN class ON class.class_id=student.class_id WHERE student.smartcard_id='" & str & "'"

                    Dim da As New MySqlDataAdapter(Sql, MyConn.open)
                    da.Fill(Ds, "student")


                    If Ds.Tables(0).Rows().Count = 0 Then
                        txtstudentid.Text = ""
                        txtName.Text = ""
                        txtclass.Text = ""
                        txtsmartcard.Text = ""
                        txtnis.Text = ""
                        Dim f As New MessageInfo

                        f.ShowDialog()
                        'PictureBox1.Image = Nothing

                        'PictureBox4.Image = Nothing
                        clear()
                    Else

                        Dim todaysdate As String = String.Format("{0:dd-MM-yyyy}", DateTime.Now)
                        'TODO! Fill Text Boxt dengan data yang di dapat dari RFID
                        smartcard_id.Text = Ds.Tables(0).Rows(0).Item(0).ToString

                        txtstudentid.Text = Ds.Tables(0).Rows(0).Item(1).ToString
                        txtName.Text = Ds.Tables(0).Rows(0).Item(2).ToString
                        txtclass.Text = Ds.Tables(0).Rows(0).Item(3).ToString

                        class_id.Text = Ds.Tables(0).Rows(0).Item(4).ToString
                        section_id.Text = Ds.Tables(0).Rows(0).Item(5).ToString
                        class_routin_id.Text = Ds.Tables(0).Rows(0).Item(6).ToString
                        Time.Text = Ds.Tables(0).Rows(0).Item(9).ToString
                        txtnis.Text = Ds.Tables(0).Rows(0).Item(10).ToString


                        Dim id As String = txtstudentid.Text


                        Dim folder As String = Application.StartupPath & "\thumb\"
                        'Dim path As Image = webDownloadImage("http://labpupil.com/intranet/uploads/student_image/" & id & ".jpg", True, Application.StartupPath & "\thumb\" & id & ".jpg")



                        Dim filename As String = System.IO.Path.Combine(folder, id & ".jpg")


                        'If File.Exists(filename) Then
                        '    'imgVideo.Image = Image.FromFile(filename)




                        '    'PictureBox1.ImageLocation = "http://labpupil.com/intranet/uploads/student_image/" & id & ".jpg"
                        'Else
                        '    Dim nofoto As String = System.IO.Path.Combine(folder, "nopoto.png")
                        '    'imgVideo.Image = Image.FromFile(nofoto)
                        '    PictureBox1.Image = Image.FromFile(nofoto)
                        'End If
                        txtsmartcard.Text = ""


                        'TODO! Cek status login  
                        Dim Dslogin As New DataSet
                        Dim SqlLogin As String = "SELECT date_login,date_logout FROM student WHERE smartcard_id='" & str & "' AND student_id='" & txtstudentid.Text & "'"
                        Dim daLogin As New MySqlDataAdapter(SqlLogin, MyConn.open)
                        daLogin.Fill(Dslogin, "student")

                        If Dslogin.Tables(0).Rows().Count = 0 Then
                            Exit Sub
                        Else
                            Dim statuslogin As String
                            Dim statusLogout As String


                            statuslogin = Dslogin.Tables(0).Rows(0).Item(0).ToString
                            statusLogout = Dslogin.Tables(0).Rows(0).Item(1).ToString

                            If statuslogin <> todaysdate.ToString Then

                                PanelImage.Visible = True
                                lblStudentid.Visible = True
                                lblname.Visible = True
                                lblStudentClass.Visible = True
                                txtstudentid.Visible = False
                                txtName.Visible = True
                                txtclass.Visible = True
                                txtnis.Visible = True
                                Try
                                    Dim studentP As New StudentProperty
                                    Dim StudentAccess As New DataAccess.StudentDataAccess
                                    studentP.student_id = txtstudentid.Text
                                    studentP.name = txtName.Text
                                    studentP.class_id = class_id.Text
                                    studentP.section_id = section_id.Text
                                    studentP.class_routine_id = class_routin_id.Text
                                    studentP.smartcard_id = smartcard_id.Text
                                    studentP.year = Time.Text

                                    Dim f As New FormImageFingerPrint
                                    f.Label1.Text = txtstudentid.Text
                                    f.Label2.Text = txtName.Text
                                    f.Label3.Text = class_id.Text
                                    f.Label4.Text = section_id.Text

                                    f.Label5.Text = smartcard_id.Text
                                    f.Label6.Text = class_routin_id.Text
                                    f.lblimage.Text = str
                                    f.lblTA.Text = lblTA.Text

                                    'imgVideo.Visible = True
                                    'PictureBox1.Visible = True

                                    'Dim pathfolder As String = Application.StartupPath & "\video\"








                                    'Dim FileSize As UInt32
                                    'Dim mstream As New System.IO.MemoryStream()
                                    'Dim arrImage() As Byte = mstream.GetBuffer()
                                    'FileSize = mstream.Length
                                    'mstream.Close()

                                    Dim SqliMAGE As String = ""
                                    SqliMAGE = "UPDATE student SET images=@images WHERE student_id= @StudentId  AND  smartcard_id=@Smartcard_Id"
                                    Dim myCommand As MySqlCommand = New MySqlCommand(SqliMAGE, MyConn.open)
                                    myCommand.CommandType = CommandType.Text

                                    Dim StudentId As MySqlParameter = New MySqlParameter("@StudentId", MySqlDbType.Int32, 11)
                                    StudentId.Value = txtstudentid.Text
                                    Dim SmartcardId As MySqlParameter = New MySqlParameter("@Smartcard_Id", MySqlDbType.Int32)
                                    SmartcardId.Value = smartcard_id.Text
                                    Dim Name As MySqlParameter = New MySqlParameter("@images", MySqlDbType.VarChar, 225)
                                    Name.Value = txtstudentid.Text & str & ".jpg"




                                    With myCommand.Parameters
                                        .Add(StudentId)
                                        .Add(Name)
                                        .Add(SmartcardId)
                                    End With
                                    Dim rdr As MySqlDataReader = myCommand.ExecuteReader
                                    rdr.Close()
                                    MyConn.close()


                                    f.ShowDialog()
                                Catch SqlEx As MySqlException
                                    Throw New Exception(SqlEx.Message.ToString())
                                End Try
                                SaveImageCopy(txtstudentid.Text & str & ".jpg", PictureBox4.Image)
                                'webcam.Stop()




                                'todo upload image 
                                'Try
                                Dim sessionoption As New SessionOptions
                                With sessionoption
                                    .Protocol = Protocol.Sftp
                                    '.HostName = "http://brighton.starstudents.co.id"
                                    .HostName = "119.2.79.117"
                                    .UserName = "aang"
                                    .Password = "aang04_2017"
                                    .SshHostKeyFingerprint = "ecdsa-sha2-nistp256 256 c1:ee:e8:fc:1d:f5:05:ac:46:19:98:bb:70:d1:69:2e"
                                End With
                                Using session As New Session
                                    'todo connect
                                    session.Open(sessionoption)
                                    'todo upload files
                                    Dim transferoption As New TransferOptions
                                    transferoption.TransferMode = TransferMode.Binary

                                    Dim pathfolder As String = Application.StartupPath

                                    Dim transferresult As TransferOperationResult
                                    transferresult = session.PutFiles(pathfolder & "\" & txtstudentid.Text.ToString & str & ".jpg", "home/brighton.starstudents.co.id/website/uploads/student_image2/", False, transferoption)

                                    'transferresult.Check()
                                    'For Each transfer In transferresult.Transfers
                                    '    MsgBox("Upload of {0} succeeded", transfer.FileName)
                                    'Next

                                End Using
                                'Return 0
                                'Catch ex As Exception
                                '    MsgBox("Error: {0}", ex.Message.ToString)
                                'End Try


                                'PictureBox1.Image = Nothing

                                'PictureBox4.Image = Nothing
                                clear()
                            ElseIf statusLogout <> todaysdate.ToString And statuslogin = todaysdate.ToString Then
                                'btnSignIn.Visible = False
                                'btnSignOut.Visible = True
                                'btnCancel.Visible = True
                                'btnSignIn.Visible = False
                                'btnSignOut.Visible = False
                                'btnCancel.Visible = False

                                'btnRefresh.Visible = False
                                'PictureBox1.Visible = True
                                'lblStudentId.Visible = True
                                'lblname.Visible = True
                                'lblStudentClass.Visible = True
                                'txtstudentid.Visible = True
                                'txtName.Visible = True
                                'txtclass.Visible = True
                                'Try
                                '    Dim studentP As New StudentProperty
                                '    Dim StudentAccess As New DataAccess.StudentDataAccess
                                '    studentP.student_id = txtstudentid.Text
                                '    studentP.name = txtName.Text
                                '    studentP.class_id = class_id.Text
                                '    studentP.class_routine_id = class_routin_id.Text
                                '    studentP.smartcard_id = smartcard_id.Text
                                '    studentP.year = Time.Text
                                '    Dim f As New FormImageFingerOut
                                '    f.Label1.Text = txtstudentid.Text
                                '    f.Label2.Text = txtName.Text
                                '    f.Label3.Text = class_id.Text
                                '    f.Label4.Text = class_routin_id.Text
                                '    f.Label5.Text = smartcard_id.Text
                                '    f.lblTA.Text = lblTA.Text


                                '    f.ShowDialog()
                                'Catch SqlEx As MySqlException
                                '    Throw New Exception(SqlEx.Message.ToString())
                                'End Try
                                'clear()
                                'imgVideo.Visible = True
                                txtstudentid.Visible = False
                                'PanelImage.Visible = True
                                lblStudentid.Visible = True
                                lblname.Visible = True
                                lblStudentClass.Visible = True

                                txtName.Visible = True
                                txtclass.Visible = True
                                txtnis.Visible = True
                                Dim f As New MessageSukses

                                f.ShowDialog()
                                clear()



                            ElseIf statusLogout = todaysdate.ToString And statuslogin = todaysdate.ToString Then


                                lblStudentid.Visible = False
                                lblname.Visible = True
                                lblStudentClass.Visible = True
                                txtstudentid.Visible = True
                                txtName.Visible = True
                                txtclass.Visible = True
                                txtnis.Visible = True

                                Dim f As New MessageSukses

                                f.ShowDialog()

                                clear()

                            End If
                        End If



                    End If



                Catch ex As Exception
                    MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try
            End If
        End If
    End Sub



    'Public Function webDownloadImage(ByVal Url As String, Optional ByVal saveFile As Boolean = False, Optional ByVal location As String = "") As Image

    '    Dim webClient As New System.Net.WebClient
    '    Dim bytes() As Byte = webClient.DownloadData(Url)
    '    Dim stream As New IO.MemoryStream(bytes)

    '    If saveFile Then My.Computer.FileSystem.WriteAllBytes(location, bytes, False)

    '    Return New System.Drawing.Bitmap(stream)

    'End Function

    'Public Function 

    '        Sql = "UPDATE student SET images=@images WHERE id"
    '                                     = New MySqlClient.MySqlCommand(Sql, sql_connection)
    '        sql_command.Parameters.AddWithValue("@image_id", Nothing)
    '        sql_command.Parameters.AddWithValue("@image_data", images)
    '        sql_command.ExecuteNonQuery()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Exit Function
    '    End Try
    'End Function
    Private Sub updateimage(ByVal id As Integer, ByVal images As Array)



        Try
            Dim Sql As String
            Sql = "UPDATE student SET images=@images WHERE student_id= @StudentId"
            Dim myCommand As MySqlCommand = New MySqlCommand(Sql, MyConn.open)
            myCommand.CommandType = CommandType.Text

            Dim StudentId As MySqlParameter = New MySqlParameter("@StudentId", MySqlDbType.Int32, 11)
            StudentId.Value = id

            Dim Name As MySqlParameter = New MySqlParameter("@images", MySqlDbType.Blob)
            Name.Value = images

            With myCommand.Parameters
                .Add(StudentId)
                .Add(Name)
            End With
            'MyConn.ExecuteNonQuery()
            MyConn.close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub
    'Public Shared Function ImgToByteArray(img As Image, imgFormat As ImageFormat) As Byte()
    '    Dim tmpData As Byte()
    '    Using ms As New MemoryStream()
    '        img.Save(ms, imgFormat)

    '        tmpData = ms.ToArray
    '    End Using              ' dispose of memstream
    '    Return tmpData
    'End Function




    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PictureBox4.Image = PictureBox1.Image

    End Sub
    Public Sub SaveImageCopy(filename As String, image As Image)
        Dim pathfolder As String = Application.StartupPath & "\temppic\"
        Dim path As String = System.IO.Path.Combine(pathfolder, filename & ".jpg")
        Dim dest As New Bitmap(image.Width, image.Height)
        Dim gfx As Graphics = Graphics.FromImage(dest)
        gfx.DrawImageUnscaled(image, Point.Empty)
        gfx.Dispose()

        dest.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg)
        dest.Dispose()

    End Sub
End Class