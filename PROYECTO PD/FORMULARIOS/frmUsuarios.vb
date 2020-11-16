Imports System.Data.SqlClient
Public Class frmUsuarios
    Private Sub frmUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call desactivarControles()
        Call llenarDatos()
        dgvUsuarios.AutoGenerateColumns = False 'para que no nos genere el atributos de la consulta cuando la generemos
    End Sub
    Sub desactivarControles()
        btnGuardar.Enabled = False
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        BtnCancelar.Enabled = False

        txtnombre.Enabled = False
        txtContraseña.Enabled = False
        txtUsuario.Enabled = False
        cboTipoUser.Enabled = False
        cboEstado.Enabled = False

        btnNuevo.Enabled = True
    End Sub
    Sub activarControles()
        btnGuardar.Enabled = True
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        BtnCancelar.Enabled = True

        txtnombre.Enabled = True
        txtContraseña.Enabled = True
        txtUsuario.Enabled = True
        cboTipoUser.Enabled = True
        cboEstado.Enabled = True

        btnNuevo.Enabled = False
    End Sub
    Sub limpiarControles()
        txtnombre.Text = ""
        txtUsuario.Text = ""
        'txtContraseña.Text = "" -- es lo mismo el clear lo dejamos para probar funcionalidades
        txtContraseña.Clear()
        cboTipoUser.Text = ""
        cboEstado.Text = ""
        txtId.Text = ""
        txtBuscar.Text = ""
    End Sub
    Sub insertar()
        Dim sql As String
        Dim id As Integer
        If MsgBox("Guardar Nuevo Registro", vbQuestion + vbYesNo, "Sistema") = vbNo Then
            Exit Sub


        End If
        adaptador = New SqlDataAdapter("Select * from Usuarios where usuario ='" & txtUsuario.Text & "' ", obtenerconexion)
        tabla.Clear()
        adaptador.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            txtUsuario.Text = tabla.Rows(0).Item("Usuario")
            MsgBox("El Registro Ya Existe en la Base de Datos", vbInformation, "Sistema")
            Exit Sub
        End If
        If txtnombre.Text = "" Or txtUsuario.Text = "" Or txtContraseña.Text = "" Or cboTipoUser.Text = "" Or cboEstado.Text = "" Then
            MsgBox("Existen Campos Vacios", vbInformation, "Sistema")
            Exit Sub
        Else
            sql = "INSERT INTO Usuarios(NombreCompleto,Usuario,Contraseña,TipoUsuario,Estado) VALUES('" & txtnombre.Text & "','" & txtUsuario.Text & "','" & txtContraseña.Text & "','" & cboTipoUser.Text & "','" & cboEstado.Text & "')"
            Dim conect As New SqlConnection(obtenerconexion)
            conect.Open()
            Using comando As New SqlCommand(sql, conect)
                id = comando.ExecuteScalar()
            End Using
            conect.Close()
            MsgBox("Registro Completado", vbInformation, "Sistema")
        End If
    End Sub
    Sub llenarDatos()
        Dim sql As String
        sql = "SELECT *FROM USUARIOS"
        Try
            Dim tabla As New DataTable
            adaptador = New SqlDataAdapter(sql, obtenerconexion)
            adaptador.Fill(tabla)
            dgvUsuarios.DataSource = tabla
            lblTotalUsuarios.Text = tabla.Rows.Count
        Catch ex As Exception
            MsgBox("EL ERROR ES  " + ex.ToString, "SISTEMA")
        End Try
    End Sub
    Sub editar()
        Dim id As Integer
        If txtId.Text = "" Then
            MsgBox("EXISTEN DATOS VACIOS", vbInformation, "Sistema")
        Else
            Dim sql As String
            sql = "UPDATE Usuarios Set NombreCompleto='" & txtnombre.Text & "', usuario='" & txtUsuario.Text &
                "',Contraseña='" & txtContraseña.Text & "',TipoUsuario='" & cboTipoUser.Text & "',Estado='" &
                cboEstado.Text & "' WHERE IdUsuario ='" & txtId.Text & "'"
            Dim connet As New SqlConnection(obtenerconexion)
            connet.Open()
            Using comando As New SqlCommand(sql, connet)
                id = comando.ExecuteScalar()

            End Using
            connet.Close()
            MsgBox("Cambios Guardados", vbInformation, "Sistema")
            Call limpiarControles()
        End If
    End Sub
    Sub eliminar()
        Dim id As Integer
        If txtId.Text = "" Then
            MsgBox("EXISTEN DATOS VACIOS", vbInformation, "Sistema")
        Else
            If MsgBox("Desea Eliminar a " + Trim(txtnombre.Text) + " De la Base de Datos", vbQuestion + vbYesNo, "Sistema") = vbNo Then
                Call limpiarControles()
                Call desactivarControles()
                Exit Sub
            Else

                Dim sql As String
                sql = "DELETE FROM Usuarios  WHERE IdUsuario ='" & Trim(txtId.Text) & "'"
                Dim connet As New SqlConnection(obtenerconexion)
                connet.Open()
                Using comando As New SqlCommand(sql, connet)
                    id = comando.ExecuteScalar()
                End Using
                connet.Close()
                MsgBox("Cambios Guardados", vbInformation, "Sistema")
                Call limpiarControles()
            End If
        End If
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        'Tambien puedeo solo poner el activar controles y asi llama al proceso no es necesario el call
        'pero lo dejo por que se ve mejor el llamar al proceso  
        Call activarControles()
        Call limpiarControles()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Call insertar()
        Call desactivarControles()
        Call limpiarControles()
        Call llenarDatos()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Call desactivarControles()
        Call limpiarControles()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Call editar()
        Call desactivarControles()
        Call llenarDatos()

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Call eliminar()
        Call desactivarControles()
        Call llenarDatos()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        If txtBuscar.Text = "" Then
            llenarDatos()
        End If
        adaptador = New SqlDataAdapter("SELECT * FROM Usuarios where NombreCompleto Like '%" & txtBuscar.Text & "%'", obtenerconexion)
        tabla.Clear()
        adaptador.Fill(tabla)
        If tabla.Rows.Count > 0 Then

            dgvUsuarios.DataSource = tabla
            lblTotalUsuarios.Text = tabla.Rows.Count
        Else
            dgvUsuarios.DataSource = ""
        End If
    End Sub
    Private Sub dgvUsuarios_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsuarios.CellDoubleClick
        On Error Resume Next
        txtId.Text = CStr(dgvUsuarios.Item("IdUsuario", dgvUsuarios.CurrentCell.RowIndex).Value)
        txtnombre.Text = CStr(dgvUsuarios.Item("NombreCompleto", dgvUsuarios.CurrentCell.RowIndex).Value)
        txtUsuario.Text = CStr(dgvUsuarios.Item("usuario", dgvUsuarios.CurrentCell.RowIndex).Value)
        txtContraseña.Text = CStr(dgvUsuarios.Item("Contraseña", dgvUsuarios.CurrentCell.RowIndex).Value)
        cboTipoUser.Text = CStr(dgvUsuarios.Item("TipoUsuario", dgvUsuarios.CurrentCell.RowIndex).Value)
        cboEstado.Text = CStr(dgvUsuarios.Item("Estado", dgvUsuarios.CurrentCell.RowIndex).Value)

        BtnCancelar.Enabled = True
        btnEditar.Enabled = True
        btnEliminar.Enabled = True
        btnNuevo.Enabled = False

        txtnombre.Enabled = True
        txtUsuario.Enabled = True
        txtContraseña.Enabled = True
        cboEstado.Enabled = True
        cboTipoUser.Enabled = True
        cboEstado.Enabled = True
        txtnombre.Focus()

    End Sub
End Class