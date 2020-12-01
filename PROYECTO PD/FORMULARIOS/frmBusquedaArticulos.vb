Imports System.Data.SqlClient
Public Class frmBusquedaArticulos
    Private Sub frmBusquedaArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call llenardatos()

    End Sub
    Sub llenardatos()
        Dim sql As String
        sql = "SELECT Articulos.IdArticulo,Articulos.NombreA, Articulos.NumeroSerie, Articulos.codigoA, 
            Marca.NombreM,Articulos.Modelo,Articulos.PrecioCompra, Articulos.FechaCompra, 
            Articulos.EstadoArticulo,Articulos.Descripcion FROM Articulos
            INNER JOIN Marca ON Articulos.IdMarca = Marca.IdMarca Where articulos.EstadoArticulo='PENDIENTE'"
        Try
            Dim tabla As New DataTable
            adaptador = New SqlDataAdapter(sql, obtenerconexion)
            adaptador.Fill(tabla)
            dgvArticulos.DataSource = tabla
            lblTotalArticulos.Text = tabla.Rows.Count
        Catch ex As Exception
            MsgBox("EL ERROR ES  " + ex.ToString, vbInformation, "SISTEMA")
        End Try
    End Sub
    Sub BuscarDatos()
        If rbNombreArticulo.Checked Then
            If txtBuscar.Text = "" Then
                llenardatos()
            End If
            adaptador = New SqlDataAdapter("SELECT Articulos.NombreA, Articulos.NumeroSerie, Articulos.codigoA, 
            Marca.NombreM,Articulos.Modelo,Articulos.PrecioCompra, Articulos.FechaCompra, 
            Articulos.EstadoArticulo,Articulos.Descripcion FROM Articulos
            INNER JOIN Marca ON Articulos.IdMarca = Marca.IdMarca where Articulos.NombreA Like '%" & txtBuscar.Text & "%' AND articulos.EstadoArticulo='PENDIENTE'", obtenerconexion)
            tabla.Clear()
            adaptador.Fill(tabla)
            If tabla.Rows.Count > 0 Then

                dgvArticulos.DataSource = tabla
                lblTotalArticulos.Text = tabla.Rows.Count
            Else
                dgvArticulos.DataSource = ""
            End If
        End If
        If rbCodigo.Checked Then
            If txtBuscar.Text = "" Then
                llenardatos()
            End If
            adaptador = New SqlDataAdapter("SELECT Articulos.NombreA, Articulos.NumeroSerie, Articulos.codigoA, 
            Marca.NombreM,Articulos.Modelo,Articulos.PrecioCompra, Articulos.FechaCompra, 
            Articulos.EstadoArticulo,Articulos.Descripcion FROM Articulos
            INNER JOIN Marca ON Articulos.IdMarca = Marca.IdMarca where Articulos.CodigoA Like '%" & txtBuscar.Text & "%' AND articulos.EstadoArticulo='PENDIENTE'", obtenerconexion)
            tabla.Clear()
            adaptador.Fill(tabla)
            If tabla.Rows.Count > 0 Then

                dgvArticulos.DataSource = tabla
                lblTotalArticulos.Text = tabla.Rows.Count
            Else
                dgvArticulos.DataSource = ""
            End If
        End If
        If rbMarca.Checked Then
            If txtBuscar.Text = "" Then
                llenardatos()
            End If
            adaptador = New SqlDataAdapter("SELECT Articulos.NombreA, Articulos.NumeroSerie, Articulos.codigoA, 
            Marca.NombreM,Articulos.Modelo,Articulos.PrecioCompra, Articulos.FechaCompra, 
            Articulos.EstadoArticulo,Articulos.Descripcion FROM Articulos
            INNER JOIN Marca ON Articulos.IdMarca = Marca.IdMarca where marca.NombreM Like '%" & txtBuscar.Text & "%' AND articulos.EstadoArticulo='PENDIENTE'", obtenerconexion)
            tabla.Clear()
            adaptador.Fill(tabla)
            If tabla.Rows.Count > 0 Then

                dgvArticulos.DataSource = tabla
                lblTotalArticulos.Text = tabla.Rows.Count
            Else
                dgvArticulos.DataSource = ""
            End If
        End If

    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Call BuscarDatos()
    End Sub

    Private Sub dgvArticulos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulos.CellDoubleClick
        On Error Resume Next
        frmCargoActivos.txtIdArticulo.Text = CStr(dgvArticulos.Item("idArticulo", dgvArticulos.CurrentCell.RowIndex).Value)
        frmCargoActivos.txtNombreA.Text = CStr(dgvArticulos.Item("NombreA", dgvArticulos.CurrentCell.RowIndex).Value)

        frmCargoActivos.txtPrecio.Text = CStr(dgvArticulos.Item("PrecioCompra", dgvArticulos.CurrentCell.RowIndex).Value)

        frmCargoActivos.txtcodigo.Text = CStr(dgvArticulos.Item("CodigoA", dgvArticulos.CurrentCell.RowIndex).Value)
        Me.Close()
    End Sub
End Class