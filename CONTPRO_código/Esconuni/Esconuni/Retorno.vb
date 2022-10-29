Public Class Regresar_equipo
    Private Sub Regresar_equipo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarGrid3()
        DataGridView1.Columns.Item(1).ReadOnly = True
        DataGridView1.Columns.Item(2).ReadOnly = True
        DataGridView1.Columns.Item(3).ReadOnly = True
        DataGridView1.Columns.Item(4).ReadOnly = True
        DataGridView1.Columns.Item(5).ReadOnly = True
        DataGridView1.Columns.Item(6).ReadOnly = True
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cmd5.CommandType = CommandType.Text
        cmd5.Connection = conn
        For Each fila As DataGridViewRow In DataGridView1.Rows
            If fila.Cells("Column1").Value <> Nothing Then
                Dim equipo As String = fila.Cells("EQUIPO OCUPADO").Value.ToString
                sql5 = "INSERT INTO EQUIPOSDISPONIBLES ([EQUIPODISPONIBLE])"
                sql5 += "VALUES('" & equipo & "')"

                cmd5.CommandText = sql5
                cmd5.ExecuteNonQuery()
            End If
        Next
        cmd6.CommandType = CommandType.Text
        cmd6.Connection = conn
        For Each fila As DataGridViewRow In DataGridView1.Rows
            If fila.Cells("Column1").Value <> Nothing Then
                Dim equipo As String = fila.Cells("EQUIPO OCUPADO").Value.ToString
                sql6 = "DELETE FROM EQUIPOSOCUPADOS WHERE [EQUIPO OCUPADO]='" & equipo & "'"
                cmd6.CommandText = sql6
                cmd6.ExecuteNonQuery()
            End If
        Next


        'Try
        'cmd5.ExecuteNonQuery()
        'MsgBox("Los equipos seleccionados ahora se encuentran disponibles", MsgBoxStyle.Information, "CONTPRO")
        'llenarGrid1()
        'llenarGrid2()
        'llenarGrid3()
        'Me.Close()
        'Catch ex As Exception
        'MsgBox("Debe seleccionar al menos un equipo a retronar", MsgBoxStyle.Critical, "Atención")
        'End Try

        Try
            'cmd6.ExecuteNonQuery()
            'MsgBox("Los equipos seleccionados ahora se encuentran disponibles", MsgBoxStyle.Information, "CONTPRO")
            llenarGrid1()
            llenarGrid2()
            llenarGrid3()
            'Me.Close()

        Catch ex As Exception
            'MsgBox("Debe seleccionar al menos un equipo a retronar", MsgBoxStyle.Critical, "Atención")
        End Try

    End Sub
End Class