Imports MySql.Data.MySqlClient
Namespace DataAccess
    Public Class DataControl
        Private MyConn As DataAccess.DatabaseConnection

        'TODO! declare get dataset
        Public Function GetDataSet(ByVal SQL As String) As DataSet
            Dim Adapter As New MySqlDataAdapter(SQL, MyConn.open)
            Dim MyData As New DataSet
            Adapter.Fill(MyData, "Data")
            Return MyData
        End Function
    End Class
End Namespace
