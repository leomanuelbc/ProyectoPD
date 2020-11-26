Imports System.Data.SqlClient
Public Class frmEmpleados
    'AUTOCOMPLETE MODE  SuggestAppend 
    'AUTOCOMPLETE SOURS    ListItems
    'Para Filtrar Datos Cuando tenga Mucha Informacion Linea 3 y 4 Cbo y txt
    Private tabla_Departamentos As New DataTable
    Private tabla_Puestos As New DataTable
    Public Function DepartamentoListar(activo As Integer) As DataTable
        Dim tabla As New DataTable
        Dim sql As String
        sql = "SELECT IdDepartamento,NombreD from Departamentos"
        Using adaptador = New SqlDataAdapter(sql, obtenerconexion)
            tabla.Rows.Clear()
            adaptador.Fill(tabla)
        End Using
        Return tabla
    End Function
    Private Sub MostrarDepartamentos()
        tabla_Departamentos = DepartamentoListar(True)
        cboDepartamento.DataSource = tabla_Departamentos
        cboDepartamento.DisplayMember = "NombreD"
        cboDepartamento.ValueMember = "idDepartamento"
    End Sub
    Public Function PuestoListar(activo As Integer) As DataTable
        Dim tabla As New DataTable
        Dim sql As String
        sql = "SELECT IdPuestos,NombreP from Puestos"
        Using adaptador = New SqlDataAdapter(sql, obtenerconexion)
            tabla.Rows.Clear()
            adaptador.Fill(tabla)
        End Using
        Return tabla
    End Function
    Private Sub MostrarPuestos()
        tabla_Puestos = PuestoListar(True)
        cboPuesto.DataSource = tabla_Puestos
        cboPuesto.DisplayMember = "NombreP"
        cboPuesto.ValueMember = "IdPuestos"
    End Sub
    Sub BuscarDatos()
        If rbNombreEmpleado.Checked Then
            If txtBuscar.Text = "" Then
                llenarDatos()
            End If
            adaptador = New SqlDataAdapter("SELECT Empleados.IdEmpleado, Empleados.Nombre, Empleados.Identidad, 
            Empleados.Genero,Empleados.Telefono,Empleados.Correo, Empleados.Direccion, Departamentos.NombreD,Puestos.NombreP 
            FROM Departamentos INNER JOIN Empleados ON Departamentos.IdDepartamento = Empleados.IdDepartamento
            INNER JOIN Puestos ON Empleados.IdPuesto = Puestos.IdPuestos where Empleados.Nombre Like '%" & txtBuscar.Text & "%'", obtenerconexion)
            tabla.Clear()
            adaptador.Fill(tabla)
            If tabla.Rows.Count > 0 Then

                dgvEmpleados.DataSource = tabla
                lblTotalEmpleados.Text = tabla.Rows.Count
            Else
                dgvEmpleados.DataSource = ""
            End If
        End If
        If rbIdentidad.Checked Then
            If txtBuscar.Text = "" Then
                llenarDatos()
            End If
            adaptador = New SqlDataAdapter("SELECT Empleados.IdEmpleado, Empleados.Nombre, Empleados.Identidad, 
            Empleados.Genero,Empleados.Telefono,Empleados.Correo, Empleados.Direccion, Departamentos.NombreD,Puestos.NombreP 
            FROM Departamentos INNER JOIN Empleados ON Departamentos.IdDepartamento = Empleados.IdDepartamento
            INNER JOIN Puestos ON Empleados.IdPuesto = Puestos.IdPuestos where Empleados.Identidad Like '%" & txtBuscar.Text & "%'", obtenerconexion)
            tabla.Clear()
            adaptador.Fill(tabla)
            If tabla.Rows.Count > 0 Then

                dgvEmpleados.DataSource = tabla
                lblTotalEmpleados.Text = tabla.Rows.Count
            Else
                dgvEmpleados.DataSource = ""
            End If
        End If
        If rbDepartamento.Checked Then
            If txtBuscar.Text = "" Then
                llenarDatos()
            End If
            adaptador = New SqlDataAdapter("SELECT Empleados.IdEmpleado, Empleados.Nombre, Empleados.Identidad, 
            Empleados.Genero,Empleados.Telefono,Empleados.Correo, Empleados.Direccion, Departamentos.NombreD,Puestos.NombreP 
            FROM Departamentos INNER JOIN Empleados ON Departamentos.IdDepartamento = Empleados.IdDepartamento
            INNER JOIN Puestos ON Empleados.IdPuesto = Puestos.IdPuestos where Departamentos.NombreD Like '%" & txtBuscar.Text & "%'", obtenerconexion)
            tabla.Clear()
            adaptador.Fill(tabla)
            If tabla.Rows.Count > 0 Then

                dgvEmpleados.DataSource = tabla
                lblTotalEmpleados.Text = tabla.Rows.Count
            Else
                dgvEmpleados.DataSource = ""
            End If
        End If

    End Sub
    Sub desactivarControles()
        btnGuardar.Enabled = False
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        BtnCancelar.Enabled = False

        txtNombreE.Enabled = False
        txtIdentidad.Enabled = False
        txtCorreo.Enabled = False
        txtTelefono.Enabled = False
        txtDireccion.Enabled = False
        cboGenero.Enabled = False
        cboDepartamento.Enabled = False
        cboPuesto.Enabled = False

        btnNuevo.Enabled = True
    End Sub
    Sub activarControles()
        btnGuardar.Enabled = True
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        BtnCancelar.Enabled = True

        txtNombreE.Enabled = True
        txtIdentidad.Enabled = True
        txtCorreo.Enabled = True
        txtTelefono.Enabled = True
        txtDireccion.Enabled = True
        cboGenero.Enabled = True
        cboDepartamento.Enabled = True
        cboPuesto.Enabled = True

        btnNuevo.Enabled = False
    End Sub
    Sub limpiarControles()
        txtNombreE.Text = ""
        txtIdentidad.Text = ""
        txtCorreo.Text = ""
        txtTelefono.Text = ""
        txtDireccion.Text = ""
        cboGenero.Text = ""
        cboDepartamento.Text = ""
        cboPuesto.Text = ""

        txtId.Text = ""
        txtBuscar.Text = ""
    End Sub
    Sub insertar()
        Dim sql As String
        Dim id As Integer
        If MsgBox("Guardar Nuevo Registro", vbQuestion + vbYesNo, "Sistema") = vbNo Then
            Exit Sub
        End If
        adaptador = New SqlDataAdapter("Select * from Empleados where Identidad ='" & txtIdentidad.Text & "' ", obtenerconexion)
        tabla.Clear()
        adaptador.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            txtIdentidad.Text = tabla.Rows(0).Item("Identidad")
            MsgBox("El Registro Ya Existe en la Base de Datos", vbInformation, "Sistema")
            Exit Sub
        End If
        If txtNombreE.Text = "" Or txtIdentidad.Text = "" Or cboGenero.Text = "" Or cboDepartamento.Text = "" Or cboPuesto.Text = "" Then
            MsgBox("Existen Campos Vacios", vbInformation, "Sistema")
            Exit Sub
        Else
            sql = "INSERT INTO Empleados(Nombre,Identidad,Genero,Telefono,Correo,Direccion,IdPuesto,IdDepartamento) VALUES('" & txtNombreE.Text & "','" & txtIdentidad.Text & "','" & cboGenero.Text & "','" & txtTelefono.Text & "','" & txtCorreo.Text & "','" & txtDireccion.Text & "','" & Trim(cboPuesto.SelectedValue) & "','" & Trim(cboDepartamento.SelectedValue) & "')"
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
        sql = "SELECT Empleados.IdEmpleado, Empleados.Nombre, Empleados.Identidad, 
            Empleados.Genero,Empleados.Telefono,Empleados.Correo, Empleados.Direccion, Departamentos.NombreD,Puestos.NombreP 
            FROM Departamentos INNER JOIN Empleados ON Departamentos.IdDepartamento = Empleados.IdDepartamento
            INNER JOIN Puestos ON Empleados.IdPuesto = Puestos.IdPuestos"
        Try
            Dim tabla As New DataTable
            adaptador = New SqlDataAdapter(sql, obtenerconexion)
            adaptador.Fill(tabla)
            dgvEmpleados.DataSource = tabla
            lblTotalEmpleados.Text = tabla.Rows.Count
        Catch ex As Exception
            MsgBox("EL ERROR ES  " + ex.ToString, vbInformation, "SISTEMA")
        End Try
    End Sub
    Sub editar()
        Dim id As Integer
        If txtId.Text = "" Then
            MsgBox("EXISTEN DATOS VACIOS", vbInformation, "Sistema")
        Else
            Dim sql As String
            sql = "UPDATE Empleados Set Nombre='" & txtNombreE.Text & "', Identidad='" & txtIdentidad.Text &
                                     "',Genero='" & cboGenero.Text & "',Telefono='" & txtTelefono.Text &
                                     "',Correo='" & txtCorreo.Text & "',Direccion='" & txtDireccion.Text &
                                     "',IdDepartamento='" & Trim(cboDepartamento.SelectedValue) &
                                     "',idPuesto='" & Trim(cboPuesto.SelectedValue) &
                                     "' WHERE IdUsuario ='" & txtId.Text & "'"
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
    Sub Eliminar()
        Dim id As Integer
        If txtId.Text = "" Then
            MsgBox("EXISTEN DATOS VACIOS", vbInformation, "Sistema")
        Else
            If MsgBox("Desea Eliminar a " + Trim(txtNombreE.Text) + " De la Base de Datos", vbQuestion + vbYesNo, "Sistema") = vbNo Then
                Call limpiarControles()
                Call desactivarControles()
                Exit Sub
            Else

                Dim sql As String
                sql = "DELETE FROM Empleados  WHERE IdEmpleado ='" & Trim(txtId.Text) & "'"
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
    Private Sub frmEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call desactivarControles()
        Call llenarDatos()
        dgvEmpleados.AutoGenerateColumns = False 'para que no nos genere el atributos de la consulta cuando la generemos
        MostrarDepartamentos()
        cboDepartamento.SelectedIndex = -1
        MostrarPuestos()
        cboPuesto.SelectedIndex = -1
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Call activarControles()
        Call limpiarControles()
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Call insertar()
        Call llenarDatos()
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

    Private Sub rbNombreEmpleado_CheckedChanged(sender As Object, e As EventArgs) Handles rbNombreEmpleado.CheckedChanged
        txtBuscar.Focus()
    End Sub

    Private Sub rbIdentidad_CheckedChanged(sender As Object, e As EventArgs) Handles rbIdentidad.CheckedChanged
        txtBuscar.Focus()
    End Sub

    Private Sub rbDepartamento_CheckedChanged(sender As Object, e As EventArgs) Handles rbDepartamento.CheckedChanged
        txtBuscar.Focus() ' seleciona el txt objeto para Comenzar a escribir en el
    End Sub

    Private Sub dgvEmpleados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmpleados.CellDoubleClick
        On Error Resume Next
        txtId.Text = CStr(dgvEmpleados.Item("IdEmpleado", dgvEmpleados.CurrentCell.RowIndex).Value)
        txtNombreE.Text = CStr(dgvEmpleados.Item("Nombre", dgvEmpleados.CurrentCell.RowIndex).Value)
        txtIdentidad.Text = CStr(dgvEmpleados.Item("Identidad", dgvEmpleados.CurrentCell.RowIndex).Value)
        cboGenero.Text = CStr(dgvEmpleados.Item("Genero", dgvEmpleados.CurrentCell.RowIndex).Value)
        txtTelefono.Text = CStr(dgvEmpleados.Item("Telefono", dgvEmpleados.CurrentCell.RowIndex).Value)
        txtCorreo.Text = CStr(dgvEmpleados.Item("Correo", dgvEmpleados.CurrentCell.RowIndex).Value)
        txtDireccion.Text = CStr(dgvEmpleados.Item("Direccion", dgvEmpleados.CurrentCell.RowIndex).Value)
        cboDepartamento.Text = CStr(dgvEmpleados.Item("NombreD", dgvEmpleados.CurrentCell.RowIndex).Value)
        cboPuesto.Text = CStr(dgvEmpleados.Item("NombreP", dgvEmpleados.CurrentCell.RowIndex).Value)

        BtnCancelar.Enabled = True
        btnEditar.Enabled = True
        btnEliminar.Enabled = True
        btnNuevo.Enabled = False

        txtNombreE.Enabled = True
        txtIdentidad.Enabled = True
        cboGenero.Enabled = True
        txtTelefono.Enabled = True
        txtCorreo.Enabled = True
        txtDireccion.Enabled = True
        cboDepartamento.Enabled = True
        cboPuesto.Enabled = True
        txtNombreE.Focus()

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Call editar()
        Call desactivarControles()
        Call llenarDatos()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Call Eliminar()
        Call desactivarControles()
        Call llenarDatos()
    End Sub

    Private Sub btnDepartamento_Click(sender As Object, e As EventArgs) Handles btnDepartamento.Click
        frmDepartamentos.ShowDialog() 'Abre el Formulario y hasta que no se Cierre no dejara usar el Frm Anterior
    End Sub
    Private Sub btnPuesto_Click(sender As Object, e As EventArgs) Handles btnPuesto.Click
        frmPuestosTrabajo.ShowDialog() 'Abre el Formulario y hasta que no se Cierre no dejara usar el Frm Anterior
    End Sub
End Class