Imports System.Data
Imports System.Data.SqlClient

Module Conexion

    Public conexionGeneral As SqlConnection
    Public conexionUsiario As SqlConnection


    Public baseDeDatos As String = "bd-chat"
    Public usuarioID As String
    Public usuarioContraseña As String
    Public tabla As String

    Public comandoSQL As SqlCommand
    Public lectorSQL As SqlDataReader
    Public sentenciaSQL As String
    Public respuestaSQL As String

    Public adaptadorSQL As SqlDataAdapter
    Public tablaSQL As DataTable

    Public Sub conectar()
        conexionGeneral = New SqlConnection
        conexionGeneral.ConnectionString = "Data Source=34.135.156.122;Initial Catalog=bd-chat;User ID=sqlserver;Password=-$ltPpN+,)Eu:8E<"
        'conexionGeneral.ConnectionString = "server=PC-MAU; database = master; integrated security = true"
        conexionGeneral.Open()
    End Sub

End Module
