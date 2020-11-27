Imports System.Data.SqlClient
Public Class frmMarcas
    Sub desactivarControles()
        btnGuardar.Enabled = False
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        BtnCancelar.Enabled = False

        txtMarca.Enabled = False
        txtdescripcionM.Enabled = False


        btnNuevo.Enabled = True
    End Sub
    Sub activarControles()
        btnGuardar.Enabled = True
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        BtnCancelar.Enabled = True

        txtMarca.Enabled = True
        txtdescripcionM.Enabled = True

        btnNuevo.Enabled = False
    End Sub
    Sub limpiarControles()
        txtMarca.Text = ""
        txtdescripcionM.Text = ""
        txtId.Text = ""
        txtBuscar.Text = ""
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
    Sub insertar()
        Dim sql As String
        Dim id As Integer
        If MsgBox("Guardar Nuevo Registro", vbQuestion + vbYesNo, "Sistema") = vbNo Then
            Exit Sub


        End If
        adaptador = New SqlDataAdapter("Select * from Marca where nombreM ='" & txtMarca.Text & "' ", obtenerconexion)
        tabla.Clear()
        adaptador.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            txtMarca.Text = tabla.Rows(0).Item("NombreM")
            MsgBox("El Registro Ya Existe en la Base de Datos", vbInformation, "Sistema")
            Exit Sub
        End If
        If txtMarca.Text = "" Then
            MsgBox("Existen Campos Vacios", vbInformation, "Sistema")
            Exit Sub
        Else
            sql = "INSERT INTO Marca(NombreM,DescripcionM) VALUES('" & txtMarca.Text & "','" & txtdescripcionM.Text & " ')"
            Dim conect As New SqlConnection(obtenerconexion)
            conect.Open()
            Using comando As New SqlCommand(sql, conect)
                id = comando.ExecuteScalar()
            End Using
            conect.Close()
            MsgBox("Registro Completado", vbInformation, "Sistema")
        End If
    End Sub
    Sub llenardatos()
        Dim sql As String
        sql = "SELECT * FROM Marca"
        Try
            Dim tabla As New DataTable
            adaptador = New SqlDataAdapter(sql, obtenerconexion)
            adaptador.Fill(tabla)
            dgvMarcas.DataSource = tabla
            lblTotalMarcas.Text = tabla.Rows.Count
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
            sql = "UPDATE Marcas Set NombreM='" & txtMarca.Text & "', DescripcionM='" & txtdescripcionM.Text &
                "' WHERE IdMarca ='" & txtId.Text & "'"
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
            If MsgBox("Desea Eliminar La Marca " + Trim(txtMarca.Text) + " De la Base de Datos", vbQuestion + vbYesNo, "Sistema") = vbNo Then
                Call limpiarControles()
                Call desactivarControles()
                Exit Sub
            Else

                Dim sql As String
                sql = "DELETE FROM Marca  WHERE IdMarca ='" & Trim(txtId.Text) & "'"
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
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Call tamañoFormulariobuscar()
        BtnCancelar.Enabled = True
        btnBuscar.Enabled = False
    End Sub
    Private Sub frmMarcas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call desactivarControles()
        Call tamañoFormulario()
        Call llenardatos()
        dgvMarcas.AutoGenerateColumns = False
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Call activarControles()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Call insertar()
        Call llenardatos()
        Call desactivarControles()
        Call limpiarControles()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Call editar()
        Call desactivarControles()
        Call llenardatos()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Call eliminar()
        Call desactivarControles()
        Call llenardatos()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Call tamañoFormulario()
        Call limpiarControles()
        Call desactivarControles()
        Panel1.Visible = False
        BtnCancelar.Enabled = False
        btnBuscar.Enabled = True
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        If txtBuscar.Text = "" Then
            llenardatos()
        End If
        adaptador = New SqlDataAdapter("SELECT * FROM Marca where NombreM Like '%" & txtBuscar.Text & "%'", obtenerconexion)
        tabla.Clear()
        adaptador.Fill(tabla)
        If tabla.Rows.Count > 0 Then

            dgvMarcas.DataSource = tabla
            lblTotalMarcas.Text = tabla.Rows.Count
        Else
            dgvMarcas.DataSource.clear()
        End If
    End Sub

    Private Sub dgvMarcas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMarcas.CellDoubleClick
        On Error Resume Next
        txtId.Text = CStr(dgvMarcas.Item("IdMarca", dgvMarcas.CurrentCell.RowIndex).Value)
        txtMarca.Text = CStr(dgvMarcas.Item("NombreM", dgvMarcas.CurrentCell.RowIndex).Value)
        txtdescripcionM.Text = CStr(dgvMarcas.Item("DescripcionM", dgvMarcas.CurrentCell.RowIndex).Value)

        BtnCancelar.Enabled = True
        btnEditar.Enabled = True
        btnEliminar.Enabled = True
        btnNuevo.Enabled = False

        txtMarca.Enabled = True
        txtdescripcionM.Enabled = True
        txtMarca.Focus()
    End Sub
End Class