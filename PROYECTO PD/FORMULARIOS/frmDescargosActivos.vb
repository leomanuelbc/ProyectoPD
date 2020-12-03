Imports System.Data.SqlClient
Public Class frmDescargosActivos
    Private Sub frmDescargosActivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvActivosDescargados.AutoGenerateColumns = False
        Call desactivarControles()
        Call llenarDatos()

        'Auto completar Caja texto con los datos de la base de Datos
        txtcodigoI.AutoCompleteMode = AutoCompleteMode.Suggest
        txtcodigoI.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtcodigoI.AutoCompleteCustomSource = obtenerCodigoInventario()


    End Sub
    Private Function obtenerCodigoInventario() As AutoCompleteStringCollection
        adaptador = New SqlDataAdapter("Select CodigoInventario from CargoActivos where EstadoArticulo <> 'ELIMINADO'", obtenerconexion)
        Dim dt As New DataTable("CargoActivos")
        adaptador.Fill(dt)
        Dim listarDatos As New AutoCompleteStringCollection
        For Each row As DataRow In dt.Rows
            listarDatos.Add(CStr(row(0)))
        Next
        Return listarDatos
    End Function
    Sub desactivarControles()
        btnGuardar.Enabled = False
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        BtnCancelar.Enabled = False
        btnCargos.Enabled = False


        txtcodigoI.Enabled = False
        txtNombreA.Enabled = False
        txtPrecio.Enabled = False
        txtIdentidad.Enabled = False
        txtNombreE.Enabled = False
        txtDepartamento.Enabled = False

        dtpFechaEntrega.Enabled = False
        cboMotivo.Enabled = False
        txtDescripcion.Enabled = False
        dtpFechaDescargo.Enabled = False

        btnNuevo.Enabled = True
    End Sub
    Sub activarControles()
        btnGuardar.Enabled = True
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        BtnCancelar.Enabled = True
        btnCargos.Enabled = True


        txtcodigoI.Enabled = True
        txtNombreA.Enabled = True
        txtPrecio.Enabled = True
        txtIdentidad.Enabled = True
        txtNombreE.Enabled = True
        txtDepartamento.Enabled = True

        dtpFechaEntrega.Enabled = False
        cboMotivo.Enabled = True
        txtDescripcion.Enabled = True
        dtpFechaDescargo.Enabled = True

        btnNuevo.Enabled = False
    End Sub
    Sub limpiarControles()
        txtcodigoI.Text = ""
        txtNombreA.Text = ""
        txtPrecio.Text = ""
        txtIdentidad.Text = ""
        txtNombreE.Text = ""
        txtDepartamento.Text = ""

        dtpFechaEntrega.Text = ""
        cboMotivo.Text = ""
        txtDescripcion.Text = ""

        txtId.Text = ""
        txtIdArticulo.Text = ""
        txtIdCargo.Text = ""
        dtpFechaDescargo.Text = ""

        txtBuscar.Text = ""
    End Sub
    Sub insertar()
        Dim sql As String
        Dim id As Integer
        If MsgBox("Guardar Nuevo Registro", vbQuestion + vbYesNo, "Sistema") = vbNo Then
            Exit Sub
        End If
        adaptador = New SqlDataAdapter("Select CargoActivos.codigoInventario from CargoActivos 
                                       INNER JOIN Descargos ON CargoActivos.IdCargo = descargos.idCargoActivo
                                        where CargoActivos.codigoInventario ='" & txtcodigoI.Text & "' ", obtenerconexion)
        tabla.Clear()
        adaptador.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            txtcodigoI.Text = tabla.Rows(0).Item("codigoInventario")
            MsgBox("El Registro Ya Existe en la Base de Datos", vbInformation, "Sistema")
            Exit Sub
        End If
        If txtIdArticulo.Text = "" Or txtIdCargo.Text = "" Or dtpFechaDescargo.Text = "" Or cboMotivo.Text = "" Then
            MsgBox("Existen Campos Vacios", vbInformation, "Sistema")
            Exit Sub
        Else
            sql = "INSERT INTO descargos(FechaDescargo,Descripcion,MotivoDescargo,idCargoActivo) 
                    VALUES('" & dtpFechaDescargo.Text & "','" & txtDescripcion.Text & "','" & Trim(cboMotivo.Text) & "','" & txtIdCargo.Text & "')"
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
        sql = "SELECT CargoActivos.idCargo,CargoActivos.CodigoInventario,
                      Articulos.NombreA,Articulos.IdArticulo,Articulos.PrecioCompra,
                      Empleados.Nombre,Empleados.Identidad,Departamentos.NombreD,Departamentos.NombreD,
                      Descargos.IdDescargo,Descargos.FechaDescargo,Descargos.MotivoDescargo,Descargos.Descripcion
                      From Articulos INNER JOIN CargoActivos ON Articulos.IdArticulo = CargoActivos.IdArticulo
                               INNER JOIN Empleados ON CargoActivos.IdEmpleado = Empleados.IdEmpleado
                               INNER JOIN Departamentos ON empleados.IdDepartamento = Departamentos.IdDepartamento
                               INNER JOIN Descargos ON CargoActivos.IdCargo = Descargos.IdCargoActivo"
        Try
            Dim tabla As New DataTable
            adaptador = New SqlDataAdapter(sql, obtenerconexion)
            adaptador.Fill(tabla)
            dgvActivosDescargados.DataSource = tabla
            lblTotalActivosDescargados.Text = tabla.Rows.Count
        Catch ex As Exception
            MsgBox("EL ERROR ES  " + ex.ToString, vbInformation, "SISTEMA")
        End Try
    End Sub
    Sub eliminarCargo()
        Dim id As Integer
        Dim sql As String
        sql = "Update Cargoactivos set EstadoArticulo= 'ELIMINADO' WHERE IdCargo ='" & Trim(txtIdCargo.Text) & "'"
        Dim connet As New SqlConnection(obtenerconexion)
        connet.Open()
        Using comando As New SqlCommand(sql, connet)
            id = comando.ExecuteScalar()
        End Using
        connet.Close()
    End Sub
    Sub BuscarDatos()
        If rbNombreArticulo.Checked Then
            If txtBuscar.Text = "" Then
                llenarDatos()
            End If
            adaptador = New SqlDataAdapter("SELECT CargoActivos.idCargo,CargoActivos.CodigoInventario,
                      Articulos.NombreA,Articulos.IdArticulo,Articulos.PrecioCompra,
                      Empleados.Nombre,Empleados.Identidad,Departamentos.NombreD,Departamentos.NombreD,
                      Descargos.IdDescargo,Descargos.FechaDescargo,Descargos.MotivoDescargo,Descargos.Descripcion
                      From Articulos INNER JOIN CargoActivos ON Articulos.IdArticulo = CargoActivos.IdArticulo
                               INNER JOIN Empleados ON CargoActivos.IdEmpleado = Empleados.IdEmpleado
                               INNER JOIN Departamentos ON empleados.IdDepartamento = Departamentos.IdDepartamento
                               INNER JOIN Descargos ON CargoActivos.IdCargo = Descargos.IdCargoActivo
                                where Articulos.NombreA Like '%" & txtBuscar.Text & "%'", obtenerconexion)
            tabla.Clear()
            adaptador.Fill(tabla)
            If tabla.Rows.Count > 0 Then

                dgvActivosDescargados.DataSource = tabla
                lblTotalActivosDescargados.Text = tabla.Rows.Count
            Else
                dgvActivosDescargados.DataSource = ""
            End If
        End If
        If rbCodigoInventario.Checked Then
            If txtBuscar.Text = "" Then
                llenarDatos()
            End If
            adaptador = New SqlDataAdapter("SELECT CargoActivos.idCargo,CargoActivos.CodigoInventario,
                      Articulos.NombreA,Articulos.IdArticulo,Articulos.PrecioCompra,
                      Empleados.Nombre,Empleados.Identidad,Departamentos.NombreD,Departamentos.NombreD,
                      Descargos.IdDescargo,Descargos.FechaDescargo,Descargos.MotivoDescargo,Descargos.Descripcion
                      From Articulos INNER JOIN CargoActivos ON Articulos.IdArticulo = CargoActivos.IdArticulo
                               INNER JOIN Empleados ON CargoActivos.IdEmpleado = Empleados.IdEmpleado
                               INNER JOIN Departamentos ON empleados.IdDepartamento = Departamentos.IdDepartamento
                               INNER JOIN Descargos ON CargoActivos.IdCargo = Descargos.IdCargoActivo
                               where CargoActivos.CodigoInventario Like '%" & txtBuscar.Text & "%'", obtenerconexion)
            tabla.Clear()
            adaptador.Fill(tabla)
            If tabla.Rows.Count > 0 Then

                dgvActivosDescargados.DataSource = tabla
                lblTotalActivosDescargados.Text = tabla.Rows.Count
            Else
                dgvActivosDescargados.DataSource = ""
            End If
        End If
        If rbNombreEmpleado.Checked Then
            If txtBuscar.Text = "" Then
                llenarDatos()
            End If
            adaptador = New SqlDataAdapter("SELECT CargoActivos.idCargo,CargoActivos.CodigoInventario,
                      Articulos.NombreA,Articulos.IdArticulo,Articulos.PrecioCompra,
                      Empleados.Nombre,Empleados.Identidad,Departamentos.NombreD,Departamentos.NombreD,
                      Descargos.IdDescargo,Descargos.FechaDescargo,Descargos.MotivoDescargo,Descargos.Descripcion
                      From Articulos INNER JOIN CargoActivos ON Articulos.IdArticulo = CargoActivos.IdArticulo
                               INNER JOIN Empleados ON CargoActivos.IdEmpleado = Empleados.IdEmpleado
                               INNER JOIN Departamentos ON empleados.IdDepartamento = Departamentos.IdDepartamento
                               INNER JOIN Descargos ON CargoActivos.IdCargo = Descargos.IdCargoActivo
                               where Empleados.Nombre Like '%" & txtBuscar.Text & "%'", obtenerconexion)
            tabla.Clear()
            adaptador.Fill(tabla)
            If tabla.Rows.Count > 0 Then

                dgvActivosDescargados.DataSource = tabla
                lblTotalActivosDescargados.Text = tabla.Rows.Count
            Else
                dgvActivosDescargados.DataSource = ""
            End If
        End If
        If rbDepartamento.Checked Then
            If txtBuscar.Text = "" Then
                llenarDatos()
            End If
            adaptador = New SqlDataAdapter("SELECT CargoActivos.idCargo,CargoActivos.CodigoInventario,
                      Articulos.NombreA,Articulos.IdArticulo,Articulos.PrecioCompra,
                      Empleados.Nombre,Empleados.Identidad,Departamentos.NombreD,Departamentos.NombreD,
                      Descargos.IdDescargo,Descargos.FechaDescargo,Descargos.MotivoDescargo,Descargos.Descripcion
                      From Articulos INNER JOIN CargoActivos ON Articulos.IdArticulo = CargoActivos.IdArticulo
                               INNER JOIN Empleados ON CargoActivos.IdEmpleado = Empleados.IdEmpleado
                               INNER JOIN Departamentos ON empleados.IdDepartamento = Departamentos.IdDepartamento
                               INNER JOIN Descargos ON CargoActivos.IdCargo = Descargos.IdCargoActivo
                               where Departamentos.NombreD Like '%" & txtBuscar.Text & "%'", obtenerconexion)
            tabla.Clear()
            adaptador.Fill(tabla)
            If tabla.Rows.Count > 0 Then

                dgvActivosDescargados.DataSource = tabla
                lblTotalActivosDescargados.Text = tabla.Rows.Count
            Else
                dgvActivosDescargados.DataSource = ""
            End If
        End If
    End Sub
    Sub modificarArticuloPendiente()
        Dim id As Integer
        Dim sql As String
        sql = "UPDATE Articulos Set EstadoArticulo='PENDIENTE' WHERE IdArticulo ='" & txtIdArticulo.Text & "';"
        Dim connet As New SqlConnection(obtenerconexion)
        connet.Open()
        Using comando As New SqlCommand(sql, connet)
            id = comando.ExecuteScalar()
        End Using
        connet.Close()
    End Sub
    Sub modificarArticuloDEFECTUOSO()
        Dim id As Integer
        Dim sql As String
        sql = "UPDATE Articulos Set EstadoArticulo='NO FUNCIONA' WHERE IdArticulo ='" & txtIdArticulo.Text & "';"
        Dim connet As New SqlConnection(obtenerconexion)
        connet.Open()
        Using comando As New SqlCommand(sql, connet)
            id = comando.ExecuteScalar()
        End Using
        connet.Close()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Call activarControles()
        Call limpiarControles()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Call desactivarControles()
        Call limpiarControles()
    End Sub

    Private Sub txtcodigoI_TextChanged(sender As Object, e As EventArgs) Handles txtcodigoI.TextChanged
        If txtcodigoI.Text <> "" Then
            adaptador = New SqlDataAdapter("select CargoActivos.idCargo,Cargoactivos.FechaAsignacion,Articulos.IdArticulo,Articulos.NombreA,Articulos.PrecioCompra,
                                            Empleados.Nombre,Empleados.Identidad,Departamentos.NombreD
                                            from Articulos INNER JOIN CargoActivos ON Articulos.Idarticulo = CargoActivos.idArticulo
                                            INNER JOIN Empleados ON CargoActivos.IdEmpleado = Empleados.IdEmpleado
                                            INNER JOIN Departamentos ON Empleados.idDepartamento = Departamentos.IdDepartamento
                                            Where CargoActivos.CodigoInventario ='" & txtcodigoI.Text & "'", obtenerconexion)

            Dim tabla As New DataTable
            tabla.Clear()
            adaptador.Fill(tabla)
            If tabla.Rows.Count = 1 Then
                Dim fila As DataRow = tabla.Rows(0)
                txtNombreA.Text = fila("NombreA").ToString
                txtPrecio.Text = fila("PrecioCompra").ToString
                txtIdArticulo.Text = fila("IdArticulo").ToString
                txtIdentidad.Text = fila("Identidad").ToString
                txtNombreE.Text = fila("Nombre").ToString
                txtDepartamento.Text = fila("NombreD").ToString
                txtIdCargo.Text = fila("idCargo").ToString

                dtpFechaEntrega.Text = fila("FechaAsignacion").ToString

            Else
                txtNombreA.Clear()
                txtPrecio.Clear()
                txtIdArticulo.Clear()
                txtIdentidad.Clear()
                txtIdCargo.Clear()
                txtDepartamento.Clear()
                txtIdCargo.Clear()


                dtpFechaEntrega.Text = ""

                txtcodigoI.Focus()
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If cboMotivo.Text = "Obsoleto" Then
            Call insertar()
            Call eliminarCargo()
            Call modificarArticuloDEFECTUOSO()
            Call llenarDatos()
            Call desactivarControles()
            Call limpiarControles()
        Else
            Call insertar()
            Call eliminarCargo()
            Call modificarArticuloPendiente()
            Call llenarDatos()
            Call desactivarControles()
            Call limpiarControles()

        End If
    End Sub

    Private Sub btnCargos_Click(sender As Object, e As EventArgs) Handles btnCargos.Click
        FrmBusquedaActivos.ShowDialog()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Call BuscarDatos()
    End Sub

    Private Sub rbNombreArticulo_CheckedChanged(sender As Object, e As EventArgs) Handles rbNombreArticulo.CheckedChanged
        txtBuscar.Focus()
    End Sub

    Private Sub rbCodigoInventario_CheckedChanged(sender As Object, e As EventArgs) Handles rbCodigoInventario.CheckedChanged
        txtBuscar.Focus()
    End Sub

    Private Sub rbNombreEmpleado_CheckedChanged(sender As Object, e As EventArgs) Handles rbNombreEmpleado.CheckedChanged
        txtBuscar.Focus()
    End Sub

    Private Sub rbDepartamento_CheckedChanged(sender As Object, e As EventArgs) Handles rbDepartamento.CheckedChanged
        txtBuscar.Focus()
    End Sub

    Private Sub dgvActivosDescargados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvActivosDescargados.CellDoubleClick
        On Error Resume Next
        txtIdArticulo.Text = CStr(dgvActivosDescargados.Item("IdArticulo", dgvActivosDescargados.CurrentCell.RowIndex).Value)
        txtNombreA.Text = CStr(dgvActivosDescargados.Item("NombreA", dgvActivosDescargados.CurrentCell.RowIndex).Value)
        txtcodigoI.Text = CStr(dgvActivosDescargados.Item("CodigoInventario", dgvActivosDescargados.CurrentCell.RowIndex).Value)
        txtPrecio.Text = CStr(dgvActivosDescargados.Item("PrecioCompra", dgvActivosDescargados.CurrentCell.RowIndex).Value)

        txtIdCargo.Text = CStr(dgvActivosDescargados.Item("IdCargo", dgvActivosDescargados.CurrentCell.RowIndex).Value)
        txtNombreE.Text = CStr(dgvActivosDescargados.Item("Nombre", dgvActivosDescargados.CurrentCell.RowIndex).Value)
        txtIdentidad.Text = CStr(dgvActivosDescargados.Item("Identidad", dgvActivosDescargados.CurrentCell.RowIndex).Value)
        txtDepartamento.Text = CStr(dgvActivosDescargados.Item("NombreD", dgvActivosDescargados.CurrentCell.RowIndex).Value)

        txtId.Text = CStr(dgvActivosDescargados.Item("IdDescargo", dgvActivosDescargados.CurrentCell.RowIndex).Value)
        dtpFechaEntrega.Text = CStr(dgvActivosDescargados.Item("FechaAsignacion", dgvActivosDescargados.CurrentCell.RowIndex).Value)
        dtpFechaDescargo.Text = CStr(dgvActivosDescargados.Item("FechaDescargo", dgvActivosDescargados.CurrentCell.RowIndex).Value)
        cboMotivo.Text = CStr(dgvActivosDescargados.Item("MotivoDescargo", dgvActivosDescargados.CurrentCell.RowIndex).Value)
        txtDescripcion.Text = CStr(dgvActivosDescargados.Item("Descripcion", dgvActivosDescargados.CurrentCell.RowIndex).Value)

        BtnCancelar.Enabled = True
        btnEditar.Enabled = True
        btnEliminar.Enabled = True
        btnNuevo.Enabled = False
        btnCargos.Enabled = False


        txtcodigoI.Enabled = True
        dtpFechaDescargo.Enabled = True
        cboMotivo.Enabled = True
        txtDescripcion.Enabled = True

        txtNombreA.Focus()
    End Sub
End Class