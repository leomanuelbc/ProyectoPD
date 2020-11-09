Imports System.Data.SqlClient
Public Class frmUsuarios
    Private Sub frmUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call desactivarControles()

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
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Call desactivarControles()
        Call limpiarControles()
    End Sub
End Class