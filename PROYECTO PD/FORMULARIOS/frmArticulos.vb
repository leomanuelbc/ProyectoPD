Imports System.Data.SqlClient
Public Class frmArticulos
    Private tabla_marcas As New DataTable
    Private Sub frmArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call desactivarControles()
        Call llenardatos()
        Call mostrar_Marcas()
        cboMarca.SelectedIndex = -1
        dgvArticulos.AutoGenerateColumns = False
        ' Aliniear al centro en la propiedad Alignment del Data DGV
        dgvArticulos.Columns("PrecioCompra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'Asignarle Un formato "N2" 2 Decimales y con coma despues de los miles "N3" ara lo mismo con 3 decimales
        dgvArticulos.Columns("PrecioCompra").DefaultCellStyle.Format = "N2"
    End Sub
    Sub desactivarControles()
        btnGuardar.Enabled = False
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        BtnCancelar.Enabled = False
        btnMarcas.Enabled = False

        txtNombreA.Enabled = False
        txtcodigo.Enabled = False
        txtSerie.Enabled = False
        txtModelo.Enabled = False
        cboMarca.Enabled = False
        dtpFechaCompra.Enabled = False
        txtPrecio.Enabled = False
        txtDescripcion.Enabled = False


        btnNuevo.Enabled = True
    End Sub
    Sub activarControles()
        btnGuardar.Enabled = True
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        BtnCancelar.Enabled = True
        btnMarcas.Enabled = True

        txtNombreA.Enabled = True
        txtcodigo.Enabled = True
        txtSerie.Enabled = True
        txtModelo.Enabled = True
        cboMarca.Enabled = True
        dtpFechaCompra.Enabled = True
        txtPrecio.Enabled = True
        txtDescripcion.Enabled = True

        btnNuevo.Enabled = False
    End Sub
    Sub limpiarControles()
        txtNombreA.Text = ""
        txtcodigo.Text = ""
        txtSerie.Text = ""
        txtModelo.Text = ""
        cboMarca.Text = ""
        dtpFechaCompra.Text = ""
        txtPrecio.Text = ""
        txtDescripcion.Text = ""

        txtId.Text = ""
        txtBuscar.Text = ""
    End Sub
    Sub insertar()
        Dim sql As String
        Dim id As Integer
        If MsgBox("Guardar Nuevo Registro", vbQuestion + vbYesNo, "Sistema") = vbNo Then
            Exit Sub
        End If
        adaptador = New SqlDataAdapter("Select * from Articulos where CodigoA ='" & txtcodigo.Text & "' ", obtenerconexion)
        tabla.Clear()
        adaptador.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            txtcodigo.Text = tabla.Rows(0).Item("codigoA")
            MsgBox("El Registro Ya Existe en la Base de Datos", vbInformation, "Sistema")
            Exit Sub
        End If
        If txtNombreA.Text = "" Or txtcodigo.Text = "" Then
            MsgBox("Existen Campos Vacios", vbInformation, "Sistema")
            Exit Sub
        Else
            sql = "INSERT INTO Articulos(NombreA,NumeroSerie,CodigoA,IdMarca,Modelo,PrecioCOmpra,FechaCompra,EstadoArticulo,Descripcion) " &
                                        "VALUES('" & txtNombreA.Text & "','" & txtSerie.Text & "','" & txtcodigo.Text & "','" & Trim(cboMarca.SelectedValue) &
                                        "','" & txtModelo.Text & "','" & txtPrecio.Text & "','" & dtpFechaCompra.Text & "','PENDIENTE','" & txtDescripcion.Text & "')"
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
        sql = "SELECT Articulos.IdArticulo,Articulos.NombreA, Articulos.NumeroSerie, Articulos.codigoA, 
            Marca.NombreM,Articulos.Modelo,Articulos.PrecioCompra, Articulos.FechaCompra, 
            Articulos.EstadoArticulo,Articulos.Descripcion FROM Articulos
            INNER JOIN Marca ON Articulos.IdMarca = Marca.IdMarca"
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
            INNER JOIN Marca ON Articulos.IdMarca = Marca.IdMarca where Articulos.NombreA Like '%" & txtBuscar.Text & "%'", obtenerconexion)
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
            INNER JOIN Marca ON Articulos.IdMarca = Marca.IdMarca where Articulos.CodigoA Like '%" & txtBuscar.Text & "%'", obtenerconexion)
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
            INNER JOIN Marca ON Articulos.IdMarca = Marca.IdMarca where marca.NombreM Like '%" & txtBuscar.Text & "%'", obtenerconexion)
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
    Sub editar()
        Dim id As Integer
        If txtId.Text = "" Then
            MsgBox("EXISTEN DATOS VACIOS", vbInformation, "Sistema")
        Else
            Dim sql As String
            sql = "UPDATE Articulos Set NombreA='" & txtNombreA.Text & "', Numeroserie='" & txtSerie.Text &
                                     "',CodigoA='" & txtcodigo.Text & "',IdMarca='" & Trim(cboMarca.SelectedValue) &
                                     "',Modelo='" & txtModelo.Text & "',PrecioCompra='" & txtPrecio.Text &
                                     "',FechaCompra='" & Trim(dtpFechaCompra.Text) &
                                     "',Descripcion='" & txtDescripcion.Text &
                                     "' WHERE IdArticulo ='" & txtId.Text & "';"
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
            If MsgBox("Desea Eliminar a " + Trim(txtNombreA.Text) + " De la Base de Datos", vbQuestion + vbYesNo, "Sistema") = vbNo Then
                Call limpiarControles()
                Call desactivarControles()
                Exit Sub
            Else

                Dim sql As String
                sql = "DELETE FROM Articulos  WHERE IdArticulo ='" & Trim(txtId.Text) & "'"
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
    Public Function marcas_listar(activo As Integer) As DataTable
        Dim tabla As New DataTable
        Dim sql As String
        sql = "SELECT IdMarca,NombreM from Marca"
        Using adaptador = New SqlDataAdapter(sql, obtenerconexion)
            tabla.Rows.Clear()
            adaptador.Fill(tabla)
        End Using
        Return tabla
    End Function
    Private Sub mostrar_Marcas()
        tabla_marcas = marcas_listar(True)
        cboMarca.DataSource = tabla_marcas
        cboMarca.DisplayMember = "NombreM"
        cboMarca.ValueMember = "IdMarca"
    End Sub
    Private Sub btnDepartamento_Click(sender As Object, e As EventArgs) Handles btnMarcas.Click
        frmMarcas.ShowDialog()
    End Sub
    Private Sub cboMarca_Click(sender As Object, e As EventArgs) Handles cboMarca.Click
        Call mostrar_Marcas()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Call activarControles()
        Call limpiarControles()
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Call insertar()
        Call llenardatos()
        Call desactivarControles()
        Call limpiarControles()
    End Sub
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Call desactivarControles()
        Call limpiarControles()
    End Sub
    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Call BuscarDatos()
    End Sub
    Private Sub rbNombreArticulo_CheckedChanged(sender As Object, e As EventArgs) Handles rbNombreArticulo.CheckedChanged
        txtBuscar.Focus()
    End Sub
    Private Sub rbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rbCodigo.CheckedChanged
        txtBuscar.Focus()
    End Sub
    Private Sub rbMarca_CheckedChanged(sender As Object, e As EventArgs) Handles rbMarca.CheckedChanged
        txtBuscar.Focus()
    End Sub
    Private Sub dgvArticulos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulos.CellDoubleClick
        On Error Resume Next
        txtId.Text = CStr(dgvArticulos.Item("idArticulo", dgvArticulos.CurrentCell.RowIndex).Value)
        txtNombreA.Text = CStr(dgvArticulos.Item("NombreA", dgvArticulos.CurrentCell.RowIndex).Value)
        txtSerie.Text = CStr(dgvArticulos.Item("NumeroSerie", dgvArticulos.CurrentCell.RowIndex).Value)
        txtcodigo.Text = CStr(dgvArticulos.Item("CodigoA", dgvArticulos.CurrentCell.RowIndex).Value)
        cboMarca.Text = CStr(dgvArticulos.Item("NombreM", dgvArticulos.CurrentCell.RowIndex).Value)
        txtModelo.Text = CStr(dgvArticulos.Item("Modelo", dgvArticulos.CurrentCell.RowIndex).Value)
        txtPrecio.Text = CStr(dgvArticulos.Item("PrecioCompra", dgvArticulos.CurrentCell.RowIndex).Value)
        dtpFechaCompra.Text = CStr(dgvArticulos.Item("FechaCompra", dgvArticulos.CurrentCell.RowIndex).Value)
        txtDescripcion.Text = CStr(dgvArticulos.Item("Descripcion", dgvArticulos.CurrentCell.RowIndex).Value)

        BtnCancelar.Enabled = True
        btnEditar.Enabled = True
        btnEliminar.Enabled = True
        btnNuevo.Enabled = False

        txtNombreA.Enabled = True
        txtcodigo.Enabled = True
        txtSerie.Enabled = True
        cboMarca.Enabled = True
        txtModelo.Enabled = True
        txtPrecio.Enabled = True
        dtpFechaCompra.Enabled = True
        txtDescripcion.Enabled = True
        txtNombreA.Focus()

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
End Class