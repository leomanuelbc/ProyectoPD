Imports System.Data.SqlClient
Public Class frmCargoActivos
    Private Sub frmCargoActivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call desactivarControles()

        'Auto completar Caja texto con los datos de la base de Datos82.4
        txtcodigo.AutoCompleteMode = AutoCompleteMode.Suggest
        txtcodigo.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtcodigo.AutoCompleteCustomSource = obtenerCodigo()

        txtIdentidad.AutoCompleteMode = AutoCompleteMode.Suggest
        txtIdentidad.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtIdentidad.AutoCompleteCustomSource = obtenerIdentidad()

    End Sub
    Sub desactivarControles()
        btnGuardar.Enabled = False
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        BtnCancelar.Enabled = False
        btnArticulo.Enabled = False
        btnEmpleados.Enabled = False

        txtcodigo.Enabled = False
        txtNombreA.Enabled = False
        txtPrecio.Enabled = False
        txtIdentidad.Enabled = False
        txtNombreE.Enabled = False
        txtDepartamento.Enabled = False
        txtCodigoInventario.Enabled = False
        dtpFechaEntrega.Enabled = False
        cboEstado.Enabled = False
        txtDescripcion.Enabled = False

        btnNuevo.Enabled = True
    End Sub
    Sub activarControles()
        btnGuardar.Enabled = True
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        BtnCancelar.Enabled = True
        btnArticulo.Enabled = True
        btnEmpleados.Enabled = True

        txtcodigo.Enabled = True
        txtNombreA.Enabled = True
        txtPrecio.Enabled = True
        txtIdentidad.Enabled = True
        txtNombreE.Enabled = True
        txtDepartamento.Enabled = True
        txtCodigoInventario.Enabled = True
        dtpFechaEntrega.Enabled = True
        cboEstado.Enabled = True
        txtDescripcion.Enabled = True

        btnNuevo.Enabled = False
    End Sub
    Sub limpiarControles()
        txtcodigo.Text = ""
        txtNombreA.Text = ""
        txtPrecio.Text = ""
        txtIdentidad.Text = ""
        txtNombreE.Text = ""
        txtDepartamento.Text = ""
        txtCodigoInventario.Text = ""
        dtpFechaEntrega.Text = ""
        cboEstado.Text = ""
        txtDescripcion.Text = ""

        txtId.Text = ""
        txtIdArticulo.Text = ""
        txtIdEmpleado.Text = ""

        txtBuscar.Text = ""
    End Sub
    Sub insertar()
        Dim sql As String
        Dim id As Integer
        If MsgBox("Guardar Nuevo Registro", vbQuestion + vbYesNo, "Sistema") = vbNo Then
            Exit Sub
        End If
        adaptador = New SqlDataAdapter("Select * from CargoActivos where CodigoInventario ='" & txtCodigoInventario.Text & "' ", obtenerconexion)
        tabla.Clear()
        adaptador.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            txtIdentidad.Text = tabla.Rows(0).Item("codigoInventario")
            MsgBox("El Registro Ya Existe en la Base de Datos", vbInformation, "Sistema")
            Exit Sub
        End If
        If txtIdArticulo.Text = "" Or txtIdEmpleado.Text = "" Or txtCodigoInventario.Text = "" Or dtpFechaEntrega.Text = "" Then
            MsgBox("Existen Campos Vacios", vbInformation, "Sistema")
            Exit Sub
        Else
            sql = "INSERT INTO CargoActivos(CodigoInventario,FechaAsignacion,EstadoArticulo,Descripcion,IdArticulo,IdEmpleado) 
                    VALUES('" & txtCodigoInventario.Text & "','" & dtpFechaEntrega.Text & "','" & Trim(cboEstado.Text) & "','" & txtDescripcion.Text & "','" & txtIdArticulo.Text & "','" & txtIdEmpleado.Text & "')"
            Dim conect As New SqlConnection(obtenerconexion)
            conect.Open()
            Using comando As New SqlCommand(sql, conect)
                id = comando.ExecuteScalar()
            End Using
            conect.Close()
            modificarArticulo()
            MsgBox("Registro Completado", vbInformation, "Sistema")
        End If
    End Sub
    Sub modificarArticulo()
        Dim id As Integer
        Dim sql As String
        sql = "UPDATE Articulos Set EstadoArticulo='ENTREGADO' WHERE IdArticulo ='" & txtIdArticulo.Text & "';"
        Dim connet As New SqlConnection(obtenerconexion)
            connet.Open()
            Using comando As New SqlCommand(sql, connet)
            id = comando.ExecuteScalar()
        End Using
        connet.Close()
    End Sub
    Private Function obtenerCodigo() As AutoCompleteStringCollection
        adaptador = New SqlDataAdapter("Select CodigoA from Articulos where EstadoArticulo ='PENDIENTE'", obtenerconexion)
        Dim dt As New DataTable("Articulos")
        adaptador.Fill(dt)
        Dim listarDatos As New AutoCompleteStringCollection
        For Each row As DataRow In dt.Rows
            listarDatos.Add(CStr(row(0)))
        Next
        Return listarDatos
    End Function
    Private Function obtenerIdentidad() As AutoCompleteStringCollection
        adaptador = New SqlDataAdapter("Select Identidad from Empleados", obtenerconexion)
        Dim dt As New DataTable("Empleados")
        adaptador.Fill(dt)
        Dim listarDatos As New AutoCompleteStringCollection
        For Each row As DataRow In dt.Rows
            listarDatos.Add(CStr(row(0)))
        Next
        Return listarDatos
    End Function
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Call activarControles()
        Call limpiarControles()
    End Sub
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Call desactivarControles()
        Call limpiarControles()
    End Sub

    Private Sub txtcodigo_TextChanged(sender As Object, e As EventArgs) Handles txtcodigo.TextChanged
        If txtcodigo.Text <> "" Then
            adaptador = New SqlDataAdapter("select IdArticulo,NombreA,PrecioCompra from Articulos Where codigoA ='" & txtcodigo.Text & "'", obtenerconexion)
            Dim tabla As New DataTable
            tabla.Clear()
            adaptador.Fill(tabla)
            If tabla.Rows.Count = 1 Then
                Dim fila As DataRow = tabla.Rows(0)
                txtNombreA.Text = fila("NombreA").ToString
                txtPrecio.Text = fila("PrecioCompra").ToString
                txtIdArticulo.Text = fila("IdArticulo").ToString
            Else
                txtNombreA.Clear()
                txtPrecio.Clear()
                txtcodigo.Focus()
            End If
        End If

    End Sub

    Private Sub txtIdentidad_TextChanged(sender As Object, e As EventArgs) Handles txtIdentidad.TextChanged
        If txtcodigo.Text <> "" Then
            adaptador = New SqlDataAdapter("select Empleados.idEmpleado,Empleados.Nombre,Departamentos.NombreD 
                                            from Departamentos INNER JOIN Empleados ON DEPARTAMENTOS.IdDepartamento= Empleados.IdDepartamento Where Identidad ='" & txtIdentidad.Text & "'", obtenerconexion)
            Dim tabla As New DataTable
            tabla.Clear()
            adaptador.Fill(tabla)
            If tabla.Rows.Count = 1 Then
                Dim fila As DataRow = tabla.Rows(0)
                txtNombreE.Text = fila("Nombre").ToString
                txtDepartamento.Text = fila("NombreD").ToString
                txtIdEmpleado.Text = fila("IdEmpleado").ToString
            Else
                txtNombreE.Clear()
                txtDepartamento.Clear()
                txtIdentidad.Focus()
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Call insertar()
        Call desactivarControles()
        Call limpiarControles()
    End Sub
End Class