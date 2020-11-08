<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfiguracion
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIp = New System.Windows.Forms.TextBox()
        Me.btnConectar = New System.Windows.Forms.Button()
        Me.txtBd = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUs = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPa = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "IP / Servidor"
        '
        'txtIp
        '
        Me.txtIp.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIp.Location = New System.Drawing.Point(124, 48)
        Me.txtIp.Name = "txtIp"
        Me.txtIp.Size = New System.Drawing.Size(146, 23)
        Me.txtIp.TabIndex = 1
        '
        'btnConectar
        '
        Me.btnConectar.Location = New System.Drawing.Point(59, 199)
        Me.btnConectar.Name = "btnConectar"
        Me.btnConectar.Size = New System.Drawing.Size(77, 32)
        Me.btnConectar.TabIndex = 2
        Me.btnConectar.Text = "&Conectar"
        Me.btnConectar.UseVisualStyleBackColor = True
        '
        'txtBd
        '
        Me.txtBd.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBd.Location = New System.Drawing.Point(124, 81)
        Me.txtBd.Name = "txtBd"
        Me.txtBd.Size = New System.Drawing.Size(146, 23)
        Me.txtBd.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 19)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Base de Datos"
        '
        'txtUs
        '
        Me.txtUs.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUs.Location = New System.Drawing.Point(124, 114)
        Me.txtUs.Name = "txtUs"
        Me.txtUs.Size = New System.Drawing.Size(146, 23)
        Me.txtUs.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 19)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Usuario"
        '
        'txtPa
        '
        Me.txtPa.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPa.Location = New System.Drawing.Point(124, 147)
        Me.txtPa.Name = "txtPa"
        Me.txtPa.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPa.Size = New System.Drawing.Size(146, 23)
        Me.txtPa.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(27, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 19)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Contraseña"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(156, 199)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(77, 32)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmConfiguracion
        '
        Me.AcceptButton = Me.btnConectar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(311, 246)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.txtPa)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtUs)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnConectar)
        Me.Controls.Add(Me.txtIp)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmConfiguracion"
        Me.Text = "Configuracion Servidor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtIp As TextBox
    Friend WithEvents btnConectar As Button
    Friend WithEvents txtBd As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUs As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPa As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCancelar As Button
End Class
