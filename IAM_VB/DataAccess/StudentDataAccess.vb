Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.Threading

Namespace DataAccess
    Public Class StudentDataAccess
        Private MyConn As New DataAccess.DatabaseConnection

#Region "Get data siswa by smarcard"

        Public Function getdata_siswa(ByVal smarcard_id As Integer) As List(Of StudentProperty)
            Dim DataStudent As New List(Of StudentProperty)()
            Try
                Dim StrSQL As String = Nothing
                StrSQL = "SELECT  smartcard_id,student_id,name,class_id,username,password FROM student WHERE smartcard_id=@smarcardID"

                Dim myCommand As New MySqlCommand(StrSQL, MyConn.open)
                myCommand.Parameters.Add("@smarcardID", MySqlDbType.Int32).Value = smarcard_id

                Dim rdr As MySqlDataReader = myCommand.ExecuteReader

                While rdr.Read()
                    Dim dataitem As New StudentProperty
                    dataitem.smartcard_id = CInt(rdr("smartcard_id").ToString)
                    dataitem.student_id = CInt(rdr("student_id").ToString)
                    dataitem.name = rdr("name").ToString()
                    dataitem.class_id = CInt(rdr("class_id").ToString())
                    dataitem.username = rdr("username").ToString()
                    dataitem.password = rdr("password").ToString()
                    DataStudent.Add(dataitem)
                End While
                rdr.Close()
            Catch sqlex As Exception
                Throw New Exception(sqlex.Message.ToString())
            Finally
                MyConn.close()
            End Try
            Return DataStudent
        End Function

#End Region
        Public Function saveattendace(ByVal rfid As StudentProperty) As MySqlDataReader
            Dim enUS As New CultureInfo("id-ID")
            Try
                Dim StrSQL As String = "INSERT INTO attendance (timestamp,date_login,year,class_id,section_id,student_id,class_routine_id,status,image)" & _
                                       "VALUE(@TimeStamp,@TimeLogin,@Year,@ClassId,@SectionID,@StudentId,@classRoutineID,@status,@image_student)"
                Dim myCommand As MySqlCommand = New MySqlCommand(StrSQL, MyConn.open)
                myCommand.CommandType = CommandType.Text

                Dim TimeStamp As MySqlParameter = New MySqlParameter("@TimeStamp", MySqlDbType.VarChar)
                Dim tgl As String = Now.ToString("yyyy-MM-dd")
                'Dim tgl As String = String.Format("{0:dd-MM-yyyy}", DateTime.Now)

                TimeStamp.Value = GetUnixTimestamp(CDate(tgl))

                Dim TimeLogin As MySqlParameter = New MySqlParameter("@TimeLogin", MySqlDbType.VarChar)
                TimeLogin.Value = TimeOfDay.ToString("HH:mm:ss")

                Dim Year As MySqlParameter = New MySqlParameter("@Year", MySqlDbType.VarChar)
                Year.Value = rfid.year

                Dim ClassId As MySqlParameter = New MySqlParameter("@ClassId", MySqlDbType.Int32)
                ClassId.Value = rfid.class_id

                Dim SectionID As MySqlParameter = New MySqlParameter("@SectionID", MySqlDbType.Int32)
                SectionID.Value = rfid.section_id

                Dim StudentId As MySqlParameter = New MySqlParameter("@StudentId", MySqlDbType.Int32)
                StudentId.Value = rfid.student_id

                Dim class_routine_id As MySqlParameter = New MySqlParameter("@classRoutineID", MySqlDbType.Int32)
                class_routine_id.Value = rfid.class_routine_id

                Dim status As MySqlParameter = New MySqlParameter("@status", MySqlDbType.Int32)
                status.Value = 1

                Dim image_absen As MySqlParameter = New MySqlParameter("@image_student", MySqlDbType.VarChar)
                image_absen.Value = rfid.images

                With myCommand.Parameters
                    .Add(TimeStamp)
                    .Add(TimeLogin)
                    .Add(Year)
                    .Add(ClassId)
                    .Add(SectionID)
                    .Add(StudentId)
                    .Add(class_routine_id)
                    .Add(status)
                    .Add(image_absen)

                End With
                Dim rdr As MySqlDataReader = myCommand.ExecuteReader
                rdr.Close()
                MyConn.close()
                Return rdr
            Catch SqlEx As MySqlException
                Throw New Exception(SqlEx.Message.ToString())
            End Try

        End Function
        Public Function save_finger(ByVal datafinger As StudentProperty) As MySqlDataReader
            Try
                Dim StrSQL As String = "INSERT INTO finger_daily (student_id,name,date_login,time_login,date_logout,time_logout,login_status,logout_status,timestamp,year,class_id,section_id,class_routine_id,status)" & _
                                        "VALUE(@StudentId,@Name,@DateLogin,@TimeLogin,'','',@LoginStatus,'',@TimeStamp,@Year,@ClassId,@SectionID,@classRoutineID,@status)"

                Dim myCommand As MySqlCommand = New MySqlCommand(StrSQL, MyConn.open)
                myCommand.CommandType = CommandType.Text

                Dim StudentId As MySqlParameter = New MySqlParameter("@StudentId", MySqlDbType.Int32, 11)
                StudentId.Value = datafinger.student_id

                Dim Name As MySqlParameter = New MySqlParameter("@Name", MySqlDbType.VarChar)
                Name.Value = datafinger.name

                Dim DateLogin As MySqlParameter = New MySqlParameter("@DateLogin", MySqlDbType.VarChar)
                DateLogin.Value = String.Format("{0:dd-MM-yyyy}", DateTime.Now)
                'DateLogin.Value = Now.ToString("d-MM-yyyy")
                Dim TimeLogin As MySqlParameter = New MySqlParameter("@TimeLogin", MySqlDbType.VarChar)
                TimeLogin.Value = TimeOfDay.ToString("HH:mm:ss")

                Dim DateLogout As MySqlParameter = New MySqlParameter("@DateLogout", MySqlDbType.VarChar)
                'DateLogout.Value = Now.ToString("yyyy-MM-dd")
                DateLogout.Value = Now.ToString("d-MM-yyyy")
                Dim TimeLogout As MySqlParameter = New MySqlParameter("@TimeLogout", MySqlDbType.VarChar)
                TimeLogout.Value = TimeOfDay.ToString("h:mm:ss")

                Dim LoginStatus As MySqlParameter = New MySqlParameter("@LoginStatus", MySqlDbType.VarChar)
                'LoginStatus.Value = Now.ToString("yyyy-mm-dd")
                LoginStatus.Value = 1

                Dim LogoutStatus As MySqlParameter = New MySqlParameter("@LogoutStatus", MySqlDbType.VarChar)
                'LogoutStatus.Value = Now.ToString("yyyy-mm-dd")
                LogoutStatus.Value = 1

                Dim TimeStamp As MySqlParameter = New MySqlParameter("@TimeStamp", MySqlDbType.VarChar)
                'Dim tgl As Date = Now.ToString("d-M-yyyy")String.Format("{0:dd-MM-yyyy}", DateTime.Now)
                Dim tgl As String = Now.ToString("yyyy-MM-dd")
                TimeStamp.Value = GetUnixTimestamp(CDate(tgl))
                'Dim tgl As Date = String.Format("{0:dd-MM-yyyy}", DateTime.Now)
                'TimeStamp.Value = GetUnixTimestamp(tgl)

                Dim Year As MySqlParameter = New MySqlParameter("@Year", MySqlDbType.VarChar)
                Year.Value = datafinger.year

                Dim ClassId As MySqlParameter = New MySqlParameter("@ClassId", MySqlDbType.Int32)
                ClassId.Value = datafinger.class_id

                Dim SectionID As MySqlParameter = New MySqlParameter("@SectionID", MySqlDbType.Int32)
                SectionID.Value = datafinger.section_id

                Dim class_routine_id As MySqlParameter = New MySqlParameter("@classRoutineID", MySqlDbType.Int32)
                class_routine_id.Value = datafinger.class_routine_id

                Dim status As MySqlParameter = New MySqlParameter("@status", MySqlDbType.Int32)
                status.Value = datafinger.student_id

                With myCommand.Parameters
                    .Add(StudentId)
                    .Add(Name)
                    .Add(DateLogin)
                    .Add(TimeLogin)
                    .Add(DateLogout)
                    .Add(TimeLogout)
                    .Add(LoginStatus)
                    .Add(LogoutStatus)

                    .Add(TimeStamp)
                    .Add(Year)
                    .Add(ClassId)
                    .Add(SectionID)

                    .Add(class_routine_id)
                    .Add(status)

                End With
                Dim rdr As MySqlDataReader = myCommand.ExecuteReader
                rdr.Close()
                MyConn.close()
                Return rdr
            Catch SqlEx As MySqlException
                Throw New Exception(SqlEx.Message.ToString())
            End Try
        End Function

        Public Function update_finger(ByVal datafinger As StudentProperty) As MySqlDataReader
            Try
                Dim StrSQL As String = "UPDATE finger_daily SET date_logout = @DateLogout,time_logout = @TimeLogout ,logout_status = @LogoutStatus"


                Dim myCommand As MySqlCommand = New MySqlCommand(StrSQL, MyConn.open)
                myCommand.CommandType = CommandType.Text

                Dim StudentId As MySqlParameter = New MySqlParameter("@StudentId", MySqlDbType.Int32, 11)
                StudentId.Value = datafinger.student_id

                Dim Name As MySqlParameter = New MySqlParameter("@Name", MySqlDbType.VarChar)
                Name.Value = datafinger.name

                Dim DateLogin As MySqlParameter = New MySqlParameter("@DateLogin", MySqlDbType.VarChar)
                DateLogin.Value = Now.ToString("d-MM-yyyy")

                Dim TimeLogin As MySqlParameter = New MySqlParameter("@TimeLogin", MySqlDbType.VarChar)
                TimeLogin.Value = TimeOfDay.ToString("h:mm:ss")

                Dim DateLogout As MySqlParameter = New MySqlParameter("@DateLogout", MySqlDbType.VarChar)
                DateLogout.Value = Now.ToString("d-MM-yyyy")

                Dim TimeLogout As MySqlParameter = New MySqlParameter("@TimeLogout", MySqlDbType.VarChar)
                TimeLogout.Value = TimeOfDay.ToString("h:mm:ss")

                Dim LoginStatus As MySqlParameter = New MySqlParameter("@LoginStatus", MySqlDbType.VarChar)
                'LoginStatus.Value = Now.ToString("yyyy-mm-dd")
                LoginStatus.Value = 1

                Dim LogoutStatus As MySqlParameter = New MySqlParameter("@LogoutStatus", MySqlDbType.VarChar)
                'LogoutStatus.Value = Now.ToString("yyyy-mm-dd")
                LogoutStatus.Value = 1

                Dim TimeStamp As MySqlParameter = New MySqlParameter("@TimeStamp", MySqlDbType.VarChar)
                Dim tgl As Date = Now.ToString("d-MM-yyyy")
                TimeStamp.Value = GetUnixTimestamp(tgl)

                Dim Year As MySqlParameter = New MySqlParameter("@Year", MySqlDbType.VarChar)
                Year.Value = datafinger.year

                Dim ClassId As MySqlParameter = New MySqlParameter("@ClassId", MySqlDbType.Int32)
                ClassId.Value = datafinger.class_id

                Dim SectionID As MySqlParameter = New MySqlParameter("@SectionID", MySqlDbType.Int32)
                SectionID.Value = datafinger.section_id

                Dim class_routine_id As MySqlParameter = New MySqlParameter("@classRoutineID", MySqlDbType.Int32)
                class_routine_id.Value = datafinger.class_routine_id

                Dim status As MySqlParameter = New MySqlParameter("@status", MySqlDbType.Int32)
                status.Value = datafinger.student_id

                With myCommand.Parameters
                    .Add(StudentId)
                    .Add(Name)
                    .Add(DateLogin)
                    .Add(TimeLogin)
                    .Add(DateLogout)
                    .Add(TimeLogout)
                    .Add(LoginStatus)
                    .Add(LogoutStatus)

                    .Add(TimeStamp)
                    .Add(Year)
                    .Add(ClassId)
                    .Add(SectionID)

                    .Add(class_routine_id)
                    .Add(status)

                End With
                Dim rdr As MySqlDataReader = myCommand.ExecuteReader
                rdr.Close()
                MyConn.close()
                Return rdr
            Catch SqlEx As MySqlException
                Throw New Exception(SqlEx.Message.ToString())
            End Try
        End Function
        Public Function update_student(ByVal RFID As StudentProperty) As MySqlDataReader
            Try
                Dim StrSQL As String = "UPDATE student SET date_login=@DateLogin,time_login=@TimeLogin,date_logout=@DateLogout,time_logout=@TimeLogout,login_status=@LoginStatus,logout_status=@LogoutStatus,last_logged=@DateLogin,time=@TimeLogin,timestamp=@TimeStamp,id=@id WHERE student_id=@StudentId AND  smartcard_id=@Smartcard_Id"

                Dim myCommand As MySqlCommand = New MySqlCommand(StrSQL, MyConn.open)
                myCommand.CommandType = CommandType.Text

                Dim DateLogin As MySqlParameter = New MySqlParameter("@DateLogin", MySqlDbType.VarChar)
                'DateLogin.Value = Now.ToString("d-MM-yyyy")
                DateLogin.Value = String.Format("{0:dd-MM-yyyy}", DateTime.Now)

                Dim TimeLogin As MySqlParameter = New MySqlParameter("@TimeLogin", MySqlDbType.VarChar)
                TimeLogin.Value = TimeOfDay.ToString("HH:mm:ss")

                Dim DateLogout As MySqlParameter = New MySqlParameter("@DateLogout", MySqlDbType.VarChar)
                DateLogout.Value = Now.ToString("d-MM-yyyy")

                Dim TimeLogout As MySqlParameter = New MySqlParameter("@TimeLogout", MySqlDbType.VarChar)
                TimeLogout.Value = TimeOfDay.ToString("h:mm:ss")

                Dim LoginStatus As MySqlParameter = New MySqlParameter("@LoginStatus", MySqlDbType.VarChar, 11)
                'LoginStatus.Value = Now.ToString("yyyy-MM-dd")
                LoginStatus.Value = 1

                Dim LogoutStatus As MySqlParameter = New MySqlParameter("@LogoutStatus", MySqlDbType.VarChar, 11)
                'LogoutStatus.Value = Now.ToString("yyyy-MM-dd")
                LogoutStatus.Value = 1

                Dim TimeStamp As MySqlParameter = New MySqlParameter("@TimeStamp", MySqlDbType.VarChar)
                TimeStamp.Value = Now.ToString("yyyy-MM-dd h:mm:ss")

                Dim StudentId As MySqlParameter = New MySqlParameter("@StudentId", MySqlDbType.Int32)
                StudentId.Value = RFID.student_id

                Dim Id As MySqlParameter = New MySqlParameter("@Id", MySqlDbType.Int32)
                Id.Value = RFID.student_id

                Dim SmartcardId As MySqlParameter = New MySqlParameter("@Smartcard_Id", MySqlDbType.Int32)
                SmartcardId.Value = RFID.smartcard_id

                With myCommand.Parameters


                    .Add(DateLogin)
                    .Add(TimeLogin)
                    .Add(DateLogout)
                    .Add(TimeLogout)
                    .Add(LoginStatus)
                    .Add(LogoutStatus)
                    .Add(TimeStamp)
                    .Add(StudentId)
                    .Add(SmartcardId)
                    .Add(Id)


                End With
                Dim rdr As MySqlDataReader = myCommand.ExecuteReader
                rdr.Close()
                MyConn.close()
                Return rdr
            Catch SqlEx As MySqlException
                Throw New Exception(SqlEx.Message.ToString())
            End Try

        End Function

        Public Function update_login_student(ByVal login As StudentProperty) As MySqlDataReader
            Try
                'Dim StrSQL As String = "UPDATE student SET date_login=@DateLogin,time_login=@TimeLogin,login_status=@LoginStatus,last_logged=@DateLogin,time=@TimeLogin,timestamp=@TimeStamp,id=@id,attendance_by=@Student,images=@image WHERE student_id=@StudentId AND  smartcard_id=@Smartcard_Id"
                Dim StrSQL As String = "UPDATE student SET date_login=@DateLogin,time_login=@TimeLogin,login_status=@LoginStatus,timestamp=@TimeStamp,id=@id,attendance_by=@Student,images=@image WHERE student_id=@StudentId "
                Dim myCommand As MySqlCommand = New MySqlCommand(StrSQL, MyConn.open)
                myCommand.CommandType = CommandType.Text

                Dim StudentId As MySqlParameter = New MySqlParameter("@StudentId", MySqlDbType.Int32, 11)
                StudentId.Value = login.student_id

                Dim Name As MySqlParameter = New MySqlParameter("@Name", MySqlDbType.VarChar)
                Name.Value = login.name

                Dim DateLogin As MySqlParameter = New MySqlParameter("@DateLogin", MySqlDbType.VarChar)
                'DateLogin.Value = Now.ToString("d-MM-yyyy")
                DateLogin.Value = String.Format("{0:dd-MM-yyyy}", DateTime.Now)

                Dim TimeLogin As MySqlParameter = New MySqlParameter("@TimeLogin", MySqlDbType.VarChar)
                TimeLogin.Value = TimeOfDay.ToString("h:mm:ss")

                Dim LoginStatus As MySqlParameter = New MySqlParameter("@LoginStatus", MySqlDbType.VarChar)
                'LoginStatus.Value = Now.ToString("yyyy-mm-dd")
                LoginStatus.Value = 1

                Dim TimeStamp As MySqlParameter = New MySqlParameter("@TimeStamp", MySqlDbType.VarChar)
                TimeStamp.Value = Now.ToString("yyyy-MM-dd h:mm:ss")

                Dim Year As MySqlParameter = New MySqlParameter("@Year", MySqlDbType.VarChar)
                Year.Value = login.year

                Dim ClassId As MySqlParameter = New MySqlParameter("@ClassId", MySqlDbType.Int32)
                ClassId.Value = login.class_id

                Dim SectionID As MySqlParameter = New MySqlParameter("@SectionID", MySqlDbType.Int32)
                SectionID.Value = login.section_id

                Dim class_routine_id As MySqlParameter = New MySqlParameter("@classRoutineID", MySqlDbType.Int32)
                class_routine_id.Value = login.class_routine_id

                Dim status As MySqlParameter = New MySqlParameter("@status", MySqlDbType.Int32)
                status.Value = login.student_id

                Dim Id As MySqlParameter = New MySqlParameter("@Id", MySqlDbType.Int32)
                Id.Value = login.student_id

                'Dim SmartcardId As MySqlParameter = New MySqlParameter("@Smartcard_Id", MySqlDbType.Int32)
                'SmartcardId.Value = login.smartcard_id

                Dim images As MySqlParameter = New MySqlParameter("@image", MySqlDbType.VarChar)
                images.Value = login.images

                Dim stundent As MySqlParameter = New MySqlParameter("@Student", MySqlDbType.VarChar)
                stundent.Value = "Student"

                With myCommand.Parameters
                    .Add(StudentId)
                    .Add(Name)
                    .Add(DateLogin)
                    .Add(TimeLogin)
                    '.Add(DateLogout)
                    '.Add(TimeLogout)
                    .Add(LoginStatus)
                    '.Add(LogoutStatus)
                    '.Add(SmartcardId)
                    .Add(TimeStamp)
                    .Add(Year)
                    .Add(ClassId)
                    .Add(SectionID)
                    .Add(Id)
                    .Add(class_routine_id)
                    .Add(status)
                    .Add(images)
                    .Add(stundent)

                End With
                Dim rdr As MySqlDataReader = myCommand.ExecuteReader
                rdr.Close()
                MyConn.close()
                Return rdr
            Catch SqlEx As MySqlException
                Throw New Exception(SqlEx.Message.ToString())

            End Try
        End Function

        Public Function Update_logout_student(ByVal logout As StudentProperty) As MySqlDataReader
            Try
                Dim StrSQL As String = "UPDATE student SET date_logout=@DateLogout,time_logout=@TimeLogout,logout_status=@LogoutStatus,timestamp=@TimeStamp WHERE student_id=@StudentId AND  smartcard_id=@Smartcard_Id"

                Dim myCommand As MySqlCommand = New MySqlCommand(StrSQL, MyConn.open)
                myCommand.CommandType = CommandType.Text



                Dim DateLogout As MySqlParameter = New MySqlParameter("@DateLogout", MySqlDbType.VarChar)
                'DateLogout.Value = Now.ToString("d-MM-yyyy")
                DateLogout.Value = String.Format("{0:dd-MM-yyyy}", DateTime.Now)

                Dim TimeLogout As MySqlParameter = New MySqlParameter("@TimeLogout", MySqlDbType.VarChar)
                TimeLogout.Value = TimeOfDay.ToString("h:mm:ss")

                Dim LoginStatus As MySqlParameter = New MySqlParameter("@LoginStatus", MySqlDbType.VarChar, 11)
                LoginStatus.Value = 1

                Dim LogoutStatus As MySqlParameter = New MySqlParameter("@LogoutStatus", MySqlDbType.VarChar, 11)
                'LogoutStatus.Value = Now.ToString("yyyy-MM-dd")
                LogoutStatus.Value = 1

                Dim TimeStamp As MySqlParameter = New MySqlParameter("@TimeStamp", MySqlDbType.VarChar)
                TimeStamp.Value = Now.ToString("yyyy-MM-dd h:mm:ss")

                Dim StudentId As MySqlParameter = New MySqlParameter("@StudentId", MySqlDbType.Int32)
                StudentId.Value = logout.student_id

                Dim SmartcardId As MySqlParameter = New MySqlParameter("@Smartcard_Id", MySqlDbType.Int32)
                SmartcardId.Value = logout.smartcard_id

                With myCommand.Parameters



                    .Add(DateLogout)
                    .Add(TimeLogout)
                    .Add(LoginStatus)
                    .Add(LogoutStatus)
                    .Add(TimeStamp)
                    .Add(StudentId)
                    .Add(SmartcardId)


                End With
                Dim rdr As MySqlDataReader = myCommand.ExecuteReader
                rdr.Close()
                MyConn.close()
                Return rdr
            Catch SqlEx As MySqlException
                Throw New Exception(SqlEx.Message.ToString())
            End Try
        End Function


        Public ReadOnly UnixEpoch As New DateTime(1970, 1, 1)
        ' equivalent to PHP mktime :
        Public Function GetUnixTimestamp(dt As DateTime) As Integer
            Dim span As TimeSpan = dt - UnixEpoch
            Return CInt(span.TotalSeconds)
        End Function
    End Class
End Namespace
