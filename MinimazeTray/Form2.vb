Imports System.Globalization
Imports System.Threading

Public Class Form2

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Thread.CurrentThread.CurrentCulture = New CultureInfo("id-ID", False)
        Try
            Dim enUS As New CultureInfo("id-ID")

            'Dim timeZoneInfo__1 As TimeZoneInfo
            'Dim dateTime__2 As DateTime

            'timeZoneInfo__1 = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time")

            'dateTime__2 = TimeZoneInfo.ConvertTime(Date.Now, timeZoneInfo__1)

            'MsgBox(GetUnixTimestamp(dateTime__2.ToString("d-M-yyyy")))
            Dim sa As String
            sa = DateTime.Now.Ticks.ToString("x")
            MessageBox.Show(sa.ToString)
            Dim strtotime As String = Now.ToString("dd-M-yyyy HH:mm tt")

            Dim s As String = Date.Today.ToShortDateString
            Dim origDate As DateTime = DateTime.Now
            MsgBox(origDate.ToString)

            Dim timeStamp As String = Now.ToString("d-M-yyyy", enUS)
            MsgBox(timeStamp)
            MsgBox(GetUnixTimestamp(timeStamp))
            'Dim dt As DateTime = DateTime.TryParseExact(strtotime, "dd-MM-YYY", Nulla)
            'MsgBox(dt.ToString)
            Dim dz As DateTime = DateTime.Parse(origDate)
            MsgBox(dz.ToString)
            ' Display the name of the current thread culture.

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try




        'TimeStamp.Value = Date.TryParseExact(DateString, "d-m-Y", enUS, DateTimeStyles.AllowLeadingWhite, dateValue)
    End Sub
    Public ReadOnly UnixEpoch As New Date(1970, 1, 1)
    'Public UnixEpoch As DateTime = New DateTime(1970, 1, 1)

    Public Function GetUnixTimestamp(dt As DateTime) As Integer
        Dim span As TimeSpan = dt - UnixEpoch
        Return CInt(span.TotalSeconds)
    End Function
End Class