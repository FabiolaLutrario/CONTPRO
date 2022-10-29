Public Class Registros
    Public Sub llenarGrid4()
        Dim ds4 As New DataSet
        Dim dt4 As New DataTable
        Dim strSql4 As String = "SELECT [FECHA], [EQUIPO], [HORA ENTRADA], [HORA SALIDA], [AULA], [USUARIO], [AUXILIAR RESPONSABLE] FROM CONSULTAREGISTROANUAL"
        Dim adp4 As New OleDb.OleDbDataAdapter(strSql4, conn)
        ds4.Tables.Add("tabla")
        adp4.Fill(ds4.Tables("tabla"))
        Me.DataGridView1.DataSource = ds4.Tables("tabla")
    End Sub

    Private Sub Registros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarGrid4()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim ask As MsgBoxResult
        ask = MsgBox("¿Desea eliminar todos los registros hasta la fecha?", MsgBoxStyle.YesNo, "CONTPRO")
        If (ask = MsgBoxResult.Yes) Then
            cmd7.CommandType = CommandType.Text
            cmd7.Connection = conn
            sql7 = "DELETE FROM REGISTROANUAL WHERE [FECHA]"
            cmd7.CommandText = sql7
            Try
                cmd7.ExecuteNonQuery()
                llenarGrid4()
                MsgBox("Se han eliminado todos los registros")
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        ElseIf (ask = MsgBoxResult.No) Then
        End If

    End Sub
End Class