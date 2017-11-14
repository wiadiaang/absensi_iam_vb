Imports MySql.Data.MySqlClient
Imports FlexCodeSDK
Imports System.Collections.Generic
Imports System.IO
Imports WinSCP



Imports System.Net

Public Class FormImageFingerPrint
    Dim myDB As MySqlConnection
    Private MyConn As New DataAccess.DatabaseConnection
    Private DataStudent As New DataAccess.StudentDataAccess
    Dim WithEvents FPVer As FlexCodeSDK.FinFPVer
    Dim ID As String
    Dim FpIndex As Byte
    Dim fdata As String


    Private Sub FormImageFingerPrint_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Timer2.Start()
        Timer2.Interval = 5000

        Dim folder As String = Application.StartupPath & "\Images\"
        Dim nofoto As String = System.IO.Path.Combine(folder, "scan.gif")
        PictureBox1.Image = Image.FromFile(nofoto)
        Try
            myDB = New MySqlConnection
            myDB.ConnectionString = (My.Settings.constring)
            myDB.Open()
            If myDB.State = ConnectionState.Open Then
                FPVer = New FlexCodeSDK.FinFPVer
                FPVer.AddDeviceInfo("G900E030579", "09B-3F1-C1F-361-A73", "NUUA-6172-6A39-EDE2-11AC-FVBY")
                'FPVer.AddDeviceInfo("G700E009497", "D80-17D-481-58A-994", "5SJ5-0DD7-FF84-100E-FBED-7W2W")


                Dim MySqlCommand As New MySqlCommand
                MySqlCommand.Connection = myDB
                MySqlCommand.CommandText = "SELECT student_id,finger_id,finger_data From student WHERE student_id='" & Label1.Text & "'"
                Dim rd As MySqlDataReader
                rd = MySqlCommand.ExecuteReader
                If rd.Read Then
                    FPVer.FPLoad(rd.GetString(0), rd.GetString(1), rd.GetString(2), "SecurityKey")
                    FPVer.FPVerificationStart()
                Else
                    'MessageBox.Show("Please scan your registrasi finger !")

                End If
                rd.Close()


            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToArray)
        End Try


    End Sub

    'TODO! verification
    Private Sub FpVer_FPVerificationID(ByVal ID As String, ByVal FingerNr As FlexCodeSDK.FingerNumber) Handles FPVer.FPVerificationID

        ID = ID
    End Sub


    Private Sub FpVer_FPVerificationStatus(ByVal Status As FlexCodeSDK.VerificationStatus) Handles FPVer.FPVerificationStatus
        If Status = FlexCodeSDK.VerificationStatus.v_OK Then
            Dim studentP As New StudentProperty

            Dim StudentAccess As New DataAccess.StudentDataAccess
            studentP.student_id = Label1.Text
            studentP.name = Label2.Text
            studentP.class_id = Label3.Text
            studentP.section_id = Label4.Text
            studentP.smartcard_id = Label5.Text
            studentP.class_routine_id = Label6.Text
            studentP.year = lblTA.Text
            studentP.id = Label1.Text

            StudentAccess.update_login_student(studentP)
            StudentAccess.saveattendace(studentP)
            StudentAccess.save_finger(studentP)
            'StudentAccess.update_login_student(studentP)
            'StudentAccess.saveattendace(studentP)
            'StudentAccess.save_finger(studentP)


            PictureBox1.Image = Nothing
            Dim folder As String = Application.StartupPath & "\Images\"
            Dim nofoto As String = System.IO.Path.Combine(folder, "access-success.png")
            PictureBox1.Image = Image.FromFile(nofoto)
            Timer1.Start()
            Timer1.Interval = 2000

            FPVer.FPVerificationStop()

            'TODO message box sukses
            Dim f As New MessageSuksesAbsen
            f.ShowDialog()
           

        ElseIf Status = FlexCodeSDK.VerificationStatus.v_NotMatch Then
            Dim imgFile As System.IO.FileStream = New System.IO.FileStream(My.Application.Info.DirectoryPath & "\finger\FPTemp.BMP", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite)
            Dim fileBytes(imgFile.Length) As Byte
            imgFile.Read(fileBytes, 0, fileBytes.Length)
            imgFile.Close()
            Dim ms As System.IO.MemoryStream = New MemoryStream(fileBytes)
            PictureBox1.Image = Image.FromStream(ms)

            PictureBox1.Image = Nothing
            Dim folder As String = Application.StartupPath & "\Images\"
            Dim nofoto As String = System.IO.Path.Combine(folder, "access-denied.png")
            PictureBox1.Image = Image.FromFile(nofoto)

            Timer1.Start()
            Timer1.Interval = 2000
            FPVer.FPVerificationStop()

            'TODO message box Failed
            Dim f As New SuccessOK

            f.ShowDialog()
        ElseIf Status = FlexCodeSDK.VerificationStatus.v_VerifyCaptureFingerTouch Then

            PictureBox1.Image = Nothing
            Dim imgFile As System.IO.FileStream = New System.IO.FileStream(My.Application.Info.DirectoryPath & "\finger\FPTemp.BMP", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite)
            Dim fileBytes(imgFile.Length) As Byte
            imgFile.Read(fileBytes, 0, fileBytes.Length)
            imgFile.Close()
            Dim ms As System.IO.MemoryStream = New MemoryStream(fileBytes)
            PictureBox1.Image = Image.FromStream(ms)
            ms.Close()
            ms.Dispose()
            'Dim f As New FormSignSignout
            'f.PictureBox4.Image = f.PictureBox1.Image
            'SaveImageCopy(f.txtstudentid.Text & f.txtnis.Text & ".jpg", f.PictureBox4.Image)
        End If


    End Sub
    Private Sub Timer1_Tick(sender As Object, e As System.EventArgs) Handles Timer1.Tick
        Me.Close()
        Me.Dispose()
        PictureBox1.Image = Nothing
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As System.EventArgs) Handles Timer2.Tick
        Me.Close()
        Me.Dispose()
        PictureBox1.Image = Nothing
    End Sub

    'Public Sub SaveImageCopy(filename As String, image As Image)
    '    'Dim path As String = 
    '    Dim pathfolder As String = Application.StartupPath & "\temppic\"
    '    Dim path As String = System.IO.Path.Combine(pathfolder, filename & ".jpg")
    '    Dim dest As New Bitmap(image.Width, image.Height)
    '    Dim gfx As Graphics = Graphics.FromImage(dest)
    '    gfx.DrawImageUnscaled(image, Point.Empty)
    '    gfx.Dispose()
    '    dest.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg)
    '    dest.Dispose()
    'End Sub

    'Public Shared Sub UploadSFTPFile(ByVal host As String, ByVal username As String, ByVal password As String, ByVal sourcefile As String, ByVal destinationpath As String, ByVal port As Integer)
    '    Dim client As SftpClient = New SftpClient(host, port, username, password)
    '    client.Connect()
    '    client.ChangeDirectory(destinationpath)
    '    Dim fs As FileStream = New FileStream(sourcefile, FileMode.Open)
    '    client.BufferSize = (4 * 1024)
    '    client.UploadFile(fs, Path.GetFileName(sourcefile))
    'End Sub
End Class