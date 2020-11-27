<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMarcas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTotalMarcas = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.dgvMarcas = New System.Windows.Forms.DataGridView()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.txtdescripcionM = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.IdMaca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvMarcas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Adobe Gothic Std B", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(12, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(214, 34)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Registro Marcas"
        '
        'txtId
        '
        Me.txtId.BackColor = System.Drawing.SystemColors.Window
        Me.txtId.Location = New System.Drawing.Point(43, 108)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(10, 20)
        Me.txtId.TabIndex = 35
        Me.txtId.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lblTotalMarcas)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtBuscar)
        Me.Panel1.Controls.Add(Me.dgvMarcas)
        Me.Panel1.Location = New System.Drawing.Point(29, 153)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(540, 284)
        Me.Panel1.TabIndex = 34
        '
        'lblTotalMarcas
        '
        Me.lblTotalMarcas.AutoSize = True
        Me.lblTotalMarcas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalMarcas.Location = New System.Drawing.Point(120, 257)
        Me.lblTotalMarcas.Name = "lblTotalMarcas"
        Me.lblTotalMarcas.Size = New System.Drawing.Size(44, 16)
        Me.lblTotalMarcas.TabIndex = 4
        Me.lblTotalMarcas.Text = "Total"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 259)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Usuarios Registrados :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Buscar"
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(62, 17)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(456, 20)
        Me.txtBuscar.TabIndex = 1
        '
        'dgvMarcas
        '
        Me.dgvMarcas.AllowUserToAddRows = False
        Me.dgvMarcas.AllowUserToDeleteRows = False
        Me.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMarcas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdMaca, Me.NombreM, Me.DescripcionM})
        Me.dgvMarcas.Location = New System.Drawing.Point(19, 53)
        Me.dgvMarcas.Name = "dgvMarcas"
        Me.dgvMarcas.ReadOnly = True
        Me.dgvMarcas.RowHeadersVisible = False
        Me.dgvMarcas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMarcas.Size = New System.Drawing.Size(507, 201)
        Me.dgvMarcas.TabIndex = 0
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnBuscar.FlatAppearance.BorderSize = 8
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscar.ForeColor = System.Drawing.Color.White
        Me.btnBuscar.Location = New System.Drawing.Point(395, 118)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(85, 24)
        Me.btnBuscar.TabIndex = 33
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnCancelar.FlatAppearance.BorderSize = 8
        Me.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCancelar.ForeColor = System.Drawing.Color.White
        Me.BtnCancelar.Location = New System.Drawing.Point(486, 118)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(85, 24)
        Me.BtnCancelar.TabIndex = 32
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = False
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnEliminar.FlatAppearance.BorderSize = 8
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEliminar.ForeColor = System.Drawing.Color.White
        Me.btnEliminar.Location = New System.Drawing.Point(486, 82)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(85, 24)
        Me.btnEliminar.TabIndex = 31
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'btnEditar
        '
        Me.btnEditar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnEditar.FlatAppearance.BorderSize = 8
        Me.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEditar.ForeColor = System.Drawing.Color.White
        Me.btnEditar.Location = New System.Drawing.Point(395, 82)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(85, 24)
        Me.btnEditar.TabIndex = 30
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnGuardar.FlatAppearance.BorderSize = 8
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Location = New System.Drawing.Point(486, 44)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(85, 24)
        Me.btnGuardar.TabIndex = 29
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnNuevo.FlatAppearance.BorderSize = 8
        Me.btnNuevo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNuevo.ForeColor = System.Drawing.Color.White
        Me.btnNuevo.Location = New System.Drawing.Point(395, 44)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(85, 24)
        Me.btnNuevo.TabIndex = 28
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = False
        '
        'txtdescripcionM
        '
        Me.txtdescripcionM.Location = New System.Drawing.Point(91, 82)
        Me.txtdescripcionM.Multiline = True
        Me.txtdescripcionM.Name = "txtdescripcionM"
        Me.txtdescripcionM.Size = New System.Drawing.Size(286, 60)
        Me.txtdescripcionM.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(22, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Descripcion"
        '
        'txtMarca
        '
        Me.txtMarca.Location = New System.Drawing.Point(91, 47)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.Size = New System.Drawing.Size(286, 20)
        Me.txtMarca.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(15, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Nombre Marca"
        '
        'IdMaca
        '
        Me.IdMaca.DataPropertyName = "IdMaca"
        Me.IdMaca.HeaderText = "ID"
        Me.IdMaca.Name = "IdMaca"
        Me.IdMaca.ReadOnly = True
        Me.IdMaca.Visible = False
        Me.IdMaca.Width = 5
        '
        'NombreM
        '
        Me.NombreM.DataPropertyName = "NombreM"
        Me.NombreM.HeaderText = "NOMBRE DE MARCA"
        Me.NombreM.Name = "NombreM"
        Me.NombreM.ReadOnly = True
        Me.NombreM.Width = 200
        '
        'DescripcionM
        '
        Me.DescripcionM.DataPropertyName = "DescripcionM"
        Me.DescripcionM.HeaderText = "DESCRIPCION"
        Me.DescripcionM.Name = "DescripcionM"
        Me.DescripcionM.ReadOnly = True
        Me.DescripcionM.Width = 303
        '
        'frmMarcas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Desktop
        Me.ClientSize = New System.Drawing.Size(579, 450)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.txtdescripcionM)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMarca)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMarcas"
        Me.Text = "Registro de Marcas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvMarcas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label8 As Label
    Friend WithEvents txtId As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTotalMarcas As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents dgvMarcas As DataGridView
    Friend WithEvents btnBuscar As Button
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents txtdescripcionM As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtMarca As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents IdMaca As DataGridViewTextBoxColumn
    Friend WithEvents NombreM As DataGridViewTextBoxColumn
    Friend WithEvents DescripcionM As DataGridViewTextBoxColumn
End Class
