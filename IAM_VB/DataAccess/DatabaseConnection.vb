Imports MySql.Data.MySqlClient
Namespace DataAccess
    Public Class DatabaseConnection
        'TODO! get connection
        Dim conn As New MySqlConnection(My.Settings.constring)

        'TODO! Open Connection
        Public Function open() As MySqlConnection

            'TODO! Cek koneksi Internet
            If IsConnectionAvailable() = False Then
                Dim fi As New FormMessageInternet
                fi.ShowDialog()
            Else
                If conn.State <> ConnectionState.Open Then
                    conn.Open()

                End If
                Return conn
            End If
        End Function

        'TODO! Close Connection
        Public Function close() As MySqlConnection
            conn.Close()
            Return conn
        End Function

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
    End Class
End Namespace
