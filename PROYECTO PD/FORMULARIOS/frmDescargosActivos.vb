Imports System.Data.SqlClient
Public Class frmDescargosActivos
    Private Sub frmDescargosActivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvActivosDescargados.AutoGenerateColumns = False
        Call desactivarControles()
        'Call llenarDatos()

        'Auto completar Caja texto con los datos de la base de Datos
        'txtcodigo.AutoCompleteMode = AutoCompleteMode.Suggest
        'txtcodigo.AutoCompleteSource = AutoCompleteSource.CustomSource
        'txtcodigo.AutoCompleteCustomSource = obtenerCodigo()

        'txtIdentidad.AutoCompleteMode = AutoCompleteMode.Suggest
        'txtIdentidad.AutoCompleteSource = AutoCompleteSource.CustomSource
        'txtIdentidad.AutoCompleteCustomSource = obtenerIdentidad()
    End Sub

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
        txtIdEmpleado.Text = ""
        dtpFechaDescargo.Text = ""

        txtBuscar.Text = ""
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Call activarControles()
        Call limpiarControles()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Call desactivarControles()
        Call limpiarControles()
    End Sub
End Class