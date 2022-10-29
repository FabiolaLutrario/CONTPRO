Module Module1

    Public conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=Anual.accdb;Persist Security Info=False;")
    Public cmd As New OleDb.OleDbCommand
    Public sql As String = ""
    Public dr As OleDb.OleDbDataReader
    Public sql3 As String = ""
    Public dr3 As OleDb.OleDbDataReader
    Public cmd3 As New OleDb.OleDbCommand
    Public sql4 As String = ""
    Public cmd4 As New OleDb.OleDbCommand
    Public sql5 As String = ""
    Public cmd5 As New OleDb.OleDbCommand
    Public da As New OleDb.OleDbDataAdapter
    Public dt As New DataTable
    Public sql6 As String = ""
    Public cmd6 As New OleDb.OleDbCommand
    Public cmd7 As New OleDb.OleDbCommand
    Public sql7 As String = ""

    Public Sub conectarse()
        Try
            conn.Open()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub llenarGrid1()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim strSql As String = "SELECT [EQUIPO OCUPADO], [HORA ENTRADA], [HORA SALIDA], [AULA], [USUARIO], [AUXILIAR RESPONSABLE] FROM EQUIPOSOCUPADOS  "
        Dim adp As New OleDb.OleDbDataAdapter(strSql, conn)
        ds.Tables.Add("tabla")
        adp.Fill(ds.Tables("tabla"))
        Form1.DataGridView1.DataSource = ds.Tables("tabla")
    End Sub

    Public Sub llenarGrid3()
        Dim ds3 As New DataSet
        Dim dt3 As New DataTable
        Dim strSql3 As String = "SELECT [EQUIPO OCUPADO], [HORA ENTRADA], [HORA SALIDA], [AULA], [USUARIO], [AUXILIAR RESPONSABLE] FROM EQUIPOSOCUPADOS  "
        Dim adp3 As New OleDb.OleDbDataAdapter(strSql3, conn)
        ds3.Tables.Add("tabla")
        adp3.Fill(ds3.Tables("tabla"))
        Regresar_equipo.DataGridView1.DataSource = ds3.Tables("tabla")
    End Sub

    Public Sub llenarGrid2()
        Dim ds2 As New DataSet
        Dim dt2 As New DataTable
        Dim strSql2 As String = "SELECT [EQUIPODISPONIBLE] FROM CONSULTAEQUIPODISPONIBLE "
        Dim adp2 As New OleDb.OleDbDataAdapter(strSql2, conn)
        ds2.Tables.Add("tabla")
        adp2.Fill(ds2.Tables("tabla"))
        Form1.DataGridView2.DataSource = ds2.Tables("tabla")
    End Sub
End Module
