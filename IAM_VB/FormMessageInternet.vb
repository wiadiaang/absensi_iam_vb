Imports System.Threading

Public Class FormMessageInternet
    Dim check As Thread
    Public internet As Boolean


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

   

    Private Sub FormMessageInternet_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            
            ''check = New Thread(AddressOf Me.checkConnection)
            ''check.Start()
            'Do

            'Loop Until IsConnectionAvailable() = True

            Timer1.Start()
            Timer1.Interval = 2000

            'Me.Close()
            'Me.Dispose()
            'Exit Sub
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Do


        Loop Until IsConnectionAvailable() = True
        Me.Close()
        Me.Dispose()
        MainForm.Focus()

        'Application.Restart()
        'If IsConnectionAvailable() = True Then
        '    Application.Restart()
        '    'Dim fa As New FormAbsensi
        '    'fa.Refresh()

        '    'fa.txtsmartcard.Focus()
        '    'Me.Close()
        '    'Me.Dispose()
        'Else


        'End If
    End Sub
End Class