Imports System.Data.SqlClient
Public Class frmPuestosTrabajo
    Private Sub frmPuestosTrabajo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call desactivarControles()
        Call tamañoFormulario()
        Call llenarDatos()
    End Sub
    Sub desactivarControles()
        btnGuardar.Enabled = False
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        BtnCancelar.Enabled = False

        txtnombreP.Enabled = False
        txtdescripcionP.Enabled = False
        btnNuevo.Enabled = True
    End Sub
    Sub activarControles()
        btnGuardar.Enabled = True
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        BtnCancelar.Enabled = True
        txtnombreP.Enabled = True
        txtdescripcionP.Enabled = True
        btnNuevo.Enabled = False
    End Sub
    Sub limpiarControles()
        txtnombreP.Text = ""
        txtdescripcionP.Text = ""
        txtId.Text = ""
        txtBuscar.Text = ""
    End Sub
    Sub insertar()
        Dim sql As String
        Dim id As Integer
        If MsgBox("Guardar Nuevo Registro", vbQuestion + vbYesNo, "Sistema") = vbNo Then
            Exit Sub
        End If
        adaptador = New SqlDataAdapter("Select * from Puestos where nombreP ='" & txtnombreP.Text & "' ", obtenerconexion)
        tabla.Clear()
        adaptador.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            txtnombreP.Text = tabla.Rows(0).Item("NombreP")
            MsgBox("El Registro Ya Existe en la Base de Datos", vbInformation, "Sistema")
            Exit Sub
        End If
        If txtnombreP.Text = "" Or txtdescripcionP.Text = "" Then
            MsgBox("Existen Campos Vacios", vbInformation, "Sistema")
            Exit Sub
        Else
            sql = "INSERT INTO Puestos(NombreP,DescripcionP) VALUES('" & txtnombreP.Text & "','" & txtdescripcionP.Text & " ')"
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
        sql = "SELECT * FROM Puestos"
        Try
            Dim tabla As New DataTable
            adaptador = New SqlDataAdapter(sql, obtenerconexion)
            adaptador.Fill(tabla)
            dgvPuestos.DataSource = tabla
            lblTotalPuestos.Text = tabla.Rows.Count
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
            sql = "UPDATE Puestos Set NombreP='" & txtnombreP.Text & "', DescripcionP='" & txtdescripcionP.Text &
                "' WHERE IdPuestos ='" & txtId.Text & "'"
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
            If MsgBox("Desea Eliminar el Puesto " + Trim(txtnombreP.Text) + " De la Base de Datos", vbQuestion + vbYesNo, "Sistema") = vbNo Then
                Call limpiarControles()
                Call desactivarControles()
                Exit Sub
            Else

                Dim sql As String
                sql = "DELETE FROM Puestos  WHERE Idpuestos ='" & Trim(txtId.Text) & "'"
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
        adaptador = New SqlDataAdapter("SELECT * FROM Puestos where NombreP Like '%" & txtBuscar.Text & "%'", obtenerconexion)
        tabla.Clear()
        adaptador.Fill(tabla)
        If tabla.Rows.Count > 0 Then

            dgvPuestos.DataSource = tabla
            lblTotalPuestos.Text = tabla.Rows.Count
        Else
            dgvPuestos.DataSource.Clear()
        End If
    End Sub

    Private Sub dgvPuestos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPuestos.CellDoubleClick
        On Error Resume Next
        txtId.Text = CStr(dgvPuestos.Item("IdPuestos", dgvPuestos.CurrentCell.RowIndex).Value)
        txtnombreP.Text = CStr(dgvPuestos.Item("NombreP", dgvPuestos.CurrentCell.RowIndex).Value)
        txtdescripcionP.Text = CStr(dgvPuestos.Item("DescripcionP", dgvPuestos.CurrentCell.RowIndex).Value)

        BtnCancelar.Enabled = True
        btnEditar.Enabled = True
        btnEliminar.Enabled = True
        btnNuevo.Enabled = False

        txtnombreP.Enabled = True
        txtdescripcionP.Enabled = True
        txtnombreP.Focus()
    End Sub
End Class