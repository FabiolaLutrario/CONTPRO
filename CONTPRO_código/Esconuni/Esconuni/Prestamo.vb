Public Class Prestamo
    Private Sub Prestamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarcombo()


        TextBox2.Visible = False
        TextBox2.Enabled = False
        LinkLabel2.Enabled = False
        LinkLabel2.Visible = False

    End Sub
    Public Sub llenarcombo()
        Me.ComboBox1.Items.Clear()

        sql = "SELECT [HORA ENTRADA] FROM HORAENTRADA"
        cmd.CommandType = CommandType.Text
        cmd.Connection = conn
        cmd.CommandText = sql
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()
                Me.ComboBox1.Items.Add(dr.GetValue(0))
            End While
        End If
        dr.Close()
        Me.ComboBox2.Items.Clear()
        sql = "SELECT [HORA SALIDA] FROM HORASALIDA"
        cmd.CommandType = CommandType.Text
        cmd.Connection = conn
        cmd.CommandText = sql
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()
                Me.ComboBox2.Items.Add(dr.GetValue(0))
            End While
        End If
        dr.Close()
        Me.ComboBox3.Items.Clear()
        sql = "SELECT [AULA] FROM AULA"
        cmd.CommandType = CommandType.Text
        cmd.Connection = conn
        cmd.CommandText = sql
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()
                Me.ComboBox3.Items.Add(dr.GetValue(0))
            End While
        End If
        dr.Close()
        Me.ComboBox4.Items.Clear()
        sql = "SELECT [AUXILIAR RESPONSABLE] FROM AUXILIARRESPONSABLE"
        cmd.CommandType = CommandType.Text
        cmd.Connection = conn
        cmd.CommandText = sql
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()
                Me.ComboBox4.Items.Add(dr.GetValue(0))
            End While
        End If
        dr.Close()
        Me.ComboBox5.Items.Clear()
        sql = "SELECT [EQUIPODISPONIBLE] FROM CONSULTAEQUIPODISPONIBLE"
        cmd.CommandType = CommandType.Text
        cmd.Connection = conn
        cmd.CommandText = sql
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()
                Me.ComboBox5.Items.Add(dr.GetValue(0))
            End While
        End If
        dr.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (Me.ComboBox5.Text = "" And TextBox2.Text = "") Then
            MsgBox("Debe seleccionar un equipo", MsgBoxStyle.Critical, "Atención")
            Me.ComboBox5.Select()
        ElseIf (Me.ComboBox1.Text = "Seleccione...") Then
            MsgBox("Debe seleccionar una hora de entrada", MsgBoxStyle.Critical, "Atención")
            Me.ComboBox1.Select()
        ElseIf (Me.ComboBox3.Text = "Seleccione...") Then
            MsgBox("Debe seleccionar un aula", MsgBoxStyle.Critical, "Atención")
            Me.ComboBox3.Select()
        ElseIf (Me.TextBox1.Text = "") Then
            MsgBox("Debe indicar algún usuario", MsgBoxStyle.Critical, "Atención")
            Me.TextBox1.Select()
        ElseIf (Me.ComboBox4.Text = "Seleccione...") Then
            MsgBox("Debe seleccionar algún axiliar responsable", MsgBoxStyle.Critical, "Atención")
            Me.ComboBox4.Select()
        Else
            Dim fecha As String = ""
            Dim equipo As String = ""
            Dim horaentrada As String = ""
            Dim horasalida As String = ""
            Dim aula As String = ""
            Dim usuario As String = ""
            Dim auxiliar As String = ""


            fecha = Form1.Label3.Text
            equipo = Me.ComboBox5.Text
            horaentrada = Me.ComboBox1.Text
            horasalida = Me.ComboBox2.Text
            aula = Me.ComboBox3.Text
            usuario = Me.TextBox1.Text
            auxiliar = Me.ComboBox4.Text

            If Me.ComboBox5.Enabled = False Then
                equipo = Me.TextBox2.Text
            End If


        cmd.CommandType = CommandType.Text
        cmd.Connection = conn
        sql = "INSERT INTO REGISTROANUAL (FECHA, EQUIPO, [HORA ENTRADA], [HORA SALIDA], AULA, USUARIO,  [AUXILIAR RESPONSABLE])"
        sql += "VALUES ('" & fecha & "','" & equipo & "','" & horaentrada & "','" & horasalida & "','" & aula & "','" & usuario & "','" & auxiliar & "')"
        cmd.CommandText = sql

        cmd3.CommandType = CommandType.Text
        cmd3.Connection = conn
        sql3 = "INSERT INTO EQUIPOSOCUPADOS ([EQUIPO OCUPADO], [HORA ENTRADA], [HORA SALIDA], AULA, USUARIO,  [AUXILIAR RESPONSABLE])"
        sql3 += "VALUES ('" & equipo & "','" & horaentrada & "','" & horasalida & "','" & aula & "','" & usuario & "','" & auxiliar & "')"
        cmd3.CommandText = sql3

        cmd4.CommandType = CommandType.Text
        cmd4.Connection = conn
        sql4 = "DELETE FROM EQUIPOSDISPONIBLES WHERE [EQUIPODISPONIBLE] ='" & equipo & "'"
            cmd4.CommandText = sql4


            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try


        Try
            cmd4.ExecuteNonQuery()
            llenarGrid2()
            llenarcombo()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            cmd3.ExecuteNonQuery()
            llenarGrid1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            cmd.ExecuteNonQuery()

            Dim ask As MsgBoxResult
            ask = MsgBox("¿Desea realizar otro préstamo al mismo usuario?", MsgBoxStyle.YesNo, "CONTPRO")
            If (ask = MsgBoxResult.Yes) Then
                Me.TextBox2.Enabled = False
                Me.TextBox2.Visible = False
                Me.ComboBox5.Enabled = True
                Me.ComboBox5.Focus()
            ElseIf (ask = MsgBoxResult.No) Then
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        End If
    End Sub
    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.ComboBox5.Items.Clear()
        Me.ComboBox5.Enabled = False
        Me.TextBox2.Visible = True
        Me.TextBox2.Enabled = True
        LinkLabel1.Enabled = False
        LinkLabel1.Visible = False
        LinkLabel2.Enabled = True
        LinkLabel2.Visible = True
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.ComboBox5.Enabled = True
        Me.TextBox2.Visible = False
        Me.TextBox2.Enabled = False
        LinkLabel1.Enabled = True
        LinkLabel1.Visible = True
        LinkLabel2.Enabled = False
        LinkLabel2.Visible = False
        TextBox2.Text = ""
        llenarcombo()
        Me.ComboBox5.Focus()
    End Sub
End Class