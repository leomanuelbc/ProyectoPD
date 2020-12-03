Imports System.Data.SqlClient
Public Class FrmBusquedaActivos
    Private Sub FrmBusquedaActivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call llenarDatos()
        txtBuscar.Focus()

    End Sub
    Sub llenarDatos()
        Dim sql As String
        sql = "SELECT CargoActivos.idCargo,CargoActivos.CodigoInventario,CargoActivos.FechaAsignacion,CargoActivos.Descripcion,
                      Articulos.NombreA,Articulos.IdArticulo,Articulos.PrecioCompra,Articulos.CodigoA,Articulos.EstadoArticulo,
                      Empleados.Nombre,Empleados.Identidad,Empleados.IdEmpleado,Departamentos.NombreD 
                      From Articulos INNER JOIN CargoActivos ON Articulos.IdArticulo = CargoActivos.IdArticulo
                               INNER JOIN Empleados ON CargoActivos.IdEmpleado = Empleados.IdEmpleado
                               INNER JOIN Departamentos ON empleados.IdDepartamento = Departamentos.IdDepartamento"
        Try
            Dim tabla As New DataTable
            adaptador = New SqlDataAdapter(sql, obtenerconexion)
            adaptador.Fill(tabla)
            dgvCargosActivos.DataSource = tabla
            lblTotalCargosActivos.Text = tabla.Rows.Count
        Catch ex As Exception
            MsgBox("EL ERROR ES  " + ex.ToString, vbInformation, "SISTEMA")
        End Try
    End Sub
    Sub BuscarDatos()
        If rbNombreArticulo.Checked Then
            If txtBuscar.Text = "" Then
                llenarDatos()
            End If
            adaptador = New SqlDataAdapter("SELECT CargoActivos.idCargo,CargoActivos.CodigoInventario,CargoActivos.FechaAsignacion,CargoActivos.Descripcion,Articulos.NombreA,Articulos.IdArticulo,Articulos.PrecioCompra,Empleados.Nombre,Empleados.Identidad,Empleados.IdEmpleado,Departamentos.NombreD
                From Articulos INNER JOIN CargoActivos ON Articulos.IdArticulo = CargoActivos.IdArticulo
                               INNER JOIN Empleados ON CargoActivos.IdEmpleado = Empleados.IdEmpleado
                               INNER JOIN Departamentos ON empleados.IdDepartamento = Departamentos.IdDepartamento 
                                where Articulos.NombreA Like '%" & txtBuscar.Text & "%'", obtenerconexion)
            tabla.Clear()
            adaptador.Fill(tabla)
            If tabla.Rows.Count > 0 Then

                dgvCargosActivos.DataSource = tabla
                lblTotalCargosActivos.Text = tabla.Rows.Count
            Else
                dgvCargosActivos.DataSource = ""
            End If
        End If
        If rbCodigoInventario.Checked Then
            If txtBuscar.Text = "" Then
                llenarDatos()
            End If
            adaptador = New SqlDataAdapter("SELECT CargoActivos.idCargo,CargoActivos.CodigoInventario,CargoActivos.FechaAsignacion,CargoActivos.Descripcion,Articulos.NombreA,Articulos.IdArticulo,Articulos.PrecioCompra,Empleados.Nombre,Empleados.Identidad,Empleados.IdEmpleado,Departamentos.NombreD
                From Articulos INNER JOIN CargoActivos ON Articulos.IdArticulo = CargoActivos.IdArticulo
                               INNER JOIN Empleados ON CargoActivos.IdEmpleado = Empleados.IdEmpleado
                               INNER JOIN Departamentos ON empleados.IdDepartamento = Departamentos.IdDepartamento 
                               where CargoActivos.CodigoInventario Like '%" & txtBuscar.Text & "%'", obtenerconexion)
            tabla.Clear()
            adaptador.Fill(tabla)
            If tabla.Rows.Count > 0 Then

                dgvCargosActivos.DataSource = tabla
                lblTotalCargosActivos.Text = tabla.Rows.Count
            Else
                dgvCargosActivos.DataSource = ""
            End If
        End If
        If rbNombreEmpleado.Checked Then
            If txtBuscar.Text = "" Then
                llenarDatos()
            End If
            adaptador = New SqlDataAdapter("SELECT CargoActivos.idCargo,CargoActivos.CodigoInventario,CargoActivos.FechaAsignacion,CargoActivos.Descripcion,Articulos.NombreA,Articulos.IdArticulo,Articulos.PrecioCompra,Empleados.Nombre,Empleados.Identidad,Empleados.IdEmpleado,Departamentos.NombreD
                From Articulos INNER JOIN CargoActivos ON Articulos.IdArticulo = CargoActivos.IdArticulo
                               INNER JOIN Empleados ON CargoActivos.IdEmpleado = Empleados.IdEmpleado
                               INNER JOIN Departamentos ON empleados.IdDepartamento = Departamentos.IdDepartamento 
                               where Empleados.Nombre Like '%" & txtBuscar.Text & "%'", obtenerconexion)
            tabla.Clear()
            adaptador.Fill(tabla)
            If tabla.Rows.Count > 0 Then

                dgvCargosActivos.DataSource = tabla
                lblTotalCargosActivos.Text = tabla.Rows.Count
            Else
                dgvCargosActivos.DataSource = ""
            End If
        End If
        If rbDepartamento.Checked Then
            If txtBuscar.Text = "" Then
                llenarDatos()
            End If
            adaptador = New SqlDataAdapter("SELECT CargoActivos.idCargo,CargoActivos.CodigoInventario,CargoActivos.FechaAsignacion,CargoActivos.Descripcion,Articulos.NombreA,Articulos.IdArticulo,Articulos.PrecioCompra,Empleados.Nombre,Empleados.Identidad,Empleados.IdEmpleado,Departamentos.NombreD
                From Articulos INNER JOIN CargoActivos ON Articulos.IdArticulo = CargoActivos.IdArticulo
                               INNER JOIN Empleados ON CargoActivos.IdEmpleado = Empleados.IdEmpleado
                               INNER JOIN Departamentos ON empleados.IdDepartamento = Departamentos.IdDepartamento 
                               where Departamentos.NombreD Like '%" & txtBuscar.Text & "%'", obtenerconexion)
            tabla.Clear()
            adaptador.Fill(tabla)
            If tabla.Rows.Count > 0 Then

                dgvCargosActivos.DataSource = tabla
                lblTotalCargosActivos.Text = tabla.Rows.Count
            Else
                dgvCargosActivos.DataSource = ""
            End If
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        BuscarDatos()
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

    Private Sub dgvCargosActivos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCargosActivos.CellDoubleClick
        On Error Resume Next
        frmDescargosActivos.txtIdArticulo.Text = CStr(dgvCargosActivos.Item("IdArticulo", dgvCargosActivos.CurrentCell.RowIndex).Value)
        frmDescargosActivos.txtNombreA.Text = CStr(dgvCargosActivos.Item("NombreA", dgvCargosActivos.CurrentCell.RowIndex).Value)
        frmDescargosActivos.txtcodigoI.Text = CStr(dgvCargosActivos.Item("CodigoInventario", dgvCargosActivos.CurrentCell.RowIndex).Value)
        frmDescargosActivos.txtPrecio.Text = CStr(dgvCargosActivos.Item("PrecioCompra", dgvCargosActivos.CurrentCell.RowIndex).Value)

        frmDescargosActivos.txtIdCargo.Text = CStr(dgvCargosActivos.Item("IdCargo", dgvCargosActivos.CurrentCell.RowIndex).Value)
        frmDescargosActivos.txtNombreE.Text = CStr(dgvCargosActivos.Item("Nombre", dgvCargosActivos.CurrentCell.RowIndex).Value)
        frmDescargosActivos.txtIdentidad.Text = CStr(dgvCargosActivos.Item("Identidad", dgvCargosActivos.CurrentCell.RowIndex).Value)
        frmDescargosActivos.txtDepartamento.Text = CStr(dgvCargosActivos.Item("NombreD", dgvCargosActivos.CurrentCell.RowIndex).Value)


        frmDescargosActivos.dtpFechaEntrega.Text = CStr(dgvCargosActivos.Item("FechaAsignacion", dgvCargosActivos.CurrentCell.RowIndex).Value)
        Me.Close()
    End Sub
End Class