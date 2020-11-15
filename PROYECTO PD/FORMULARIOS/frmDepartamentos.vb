Imports System.Data.SqlClient
Public Class frmDepartamentos
    Sub desactivarControles()
        btnGuardar.Enabled = False
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        BtnCancelar.Enabled = False

        txtnombre.Enabled = False
        txtdescripcion.Enabled = False


        btnNuevo.Enabled = True
    End Sub
    Sub activarControles()
        btnGuardar.Enabled = True
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        BtnCancelar.Enabled = True

        txtnombre.Enabled = True
        txtdescripcion.Enabled = True

        btnNuevo.Enabled = False
    End Sub
    Sub limpiarControles()
        txtnombre.Text = ""
        txtdescripcion.Text = ""
        txtId.Text = ""
        txtBuscar.Text = ""
    End Sub
    Sub insertar()
        Dim sql As String
        Dim id As Integer
        If MsgBox("Guardar Nuevo Registro", vbQuestion + vbYesNo, "Sistema") = vbNo Then
            Exit Sub


        End If
        adaptador = New SqlDataAdapter("Select * from Departamentos where nombreD ='" & txtnombre.Text & "' ", obtenerconexion)
        tabla.Clear()
        adaptador.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            txtnombre.Text = tabla.Rows(0).Item("NombreD")
            MsgBox("El Registro Ya Existe en la Base de Datos", vbInformation, "Sistema")
            Exit Sub
        End If
        If txtnombre.Text = "" Or txtdescripcion.Text = "" Then
            MsgBox("Existen Campos Vacios", vbInformation, "Sistema")
            Exit Sub
        Else
            sql = "INSERT INTO Departamentos(NombreD,DescripcionD) VALUES('" & txtnombre.Text & "','" & txtdescripcion.Text & " ')"
            Dim conect As New SqlConnection(obtenerconexion)
            conect.Open()
            Using comando As New SqlCommand(sql, conect)
                id = comando.ExecuteScalar()
            End Using
            conect.Close()
            MsgBox("Registro Completado", vbInformation, "Sistema")
        End If
    End Sub
    Sub editar()
        Dim id As Integer
        If txtId.Text = "" Then
            MsgBox("EXISTEN DATOS VACIOS", vbInformation, "Sistema")
        Else
            Dim sql As String
            sql = "UPDATE Departamentos Set NombreD='" & txtnombre.Text & "', DescripcionD='" & txtdescripcion.Text &
                "' WHERE IdDepartamento ='" & txtId.Text & "'"
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
            If MsgBox("Desea Eliminar el Departamento " + Trim(txtnombre.Text) + " De la Base de Datos", vbQuestion + vbYesNo, "Sistema") = vbNo Then
                Call limpiarControles()
                Call desactivarControles()
                Exit Sub
            Else

                Dim sql As String
                sql = "DELETE FROM Departamentos  WHERE IdDepartamento ='" & Trim(txtId.Text) & "'"
                Dim connet As New SqlConnection(obtenerconexion)
                connet.Open()
                Using comando As New SqlCommand(sql, connet)
                    id = comando.ExecuteScalar()
                End Using
                connet.Close()
                MsgBox("Registro Eliminado", vbInformation, "Sistema")
                Call limpiarControles()
            End If
        End If
    End Sub
    Sub llenarDatos()
        Dim sql As String
        sql = "SELECT * FROM Departamentos"
        Try
            Dim tabla As New DataTable
            adaptador = New SqlDataAdapter(sql, obtenerconexion)
            adaptador.Fill(tabla)
            dgvDepartamentos.DataSource = tabla
            lblTotalDepartamentos.Text = tabla.Rows.Count
        Catch ex As Exception
            MsgBox("EL ERROR ES  " + ex.ToString, "SISTEMA")
        End Try
    End Sub
    Sub tamañoFormulario()
        Width = 591
        Height = 191
        Panel1.Visible = False
    End Sub
    Sub tamañoFormulariobuscar()
        Width = 592
        Height = 484
        Panel1.Visible = True
        txtBuscar.Focus()
        'txtBuscar.BackColor=DarkOrange
    End Sub
    Private Sub frmDepartamentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call desactivarControles()
        Call tamañoFormulario()
        Call llenarDatos()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Call activarControles()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Call insertar()
        Call llenarDatos()
        Call desactivarControles()
        Call limpiarControles()

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Call tamañoFormulariobuscar()
        BtnCancelar.Enabled = True
        btnBuscar.Enabled = False
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Call tamañoFormulario()
        Call limpiarControles()
        Call desactivarControles()
        Panel1.Visible = False
        BtnCancelar.Enabled = False
        btnBuscar.Enabled = True
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
        adaptador = New SqlDataAdapter("SELECT * FROM Departamentos where NombreD Like '%" & txtBuscar.Text & "%'", obtenerconexion)
        tabla.Clear()
        adaptador.Fill(tabla)
        If tabla.Rows.Count > 0 Then

            dgvDepartamentos.DataSource = tabla
            lblTotalDepartamentos.Text = tabla.Rows.Count
        Else
            dgvDepartamentos.DataSource = ""
        End If
    End Sub

    Private Sub dgvDepartamentos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDepartamentos.CellDoubleClick
        On Error Resume Next
        txtId.Text = CStr(dgvDepartamentos.Item("IdDepartamento", dgvDepartamentos.CurrentCell.RowIndex).Value)
        txtnombre.Text = CStr(dgvDepartamentos.Item("NombreD", dgvDepartamentos.CurrentCell.RowIndex).Value)
        txtdescripcion.Text = CStr(dgvDepartamentos.Item("DescripcionD", dgvDepartamentos.CurrentCell.RowIndex).Value)

        BtnCancelar.Enabled = True
        btnEditar.Enabled = True
        btnEliminar.Enabled = True
        btnNuevo.Enabled = False

        txtnombre.Enabled = True
        txtdescripcion.Enabled = True
        txtnombre.Focus()
    End Sub


End Class