<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrincipal
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrincipal))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ModulosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EMPLEADOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MARCASToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PUESTDETRABAJOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DEPARTAMENTOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ACTIVOSToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ARTICULOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EMPLEADOSToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActivosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EntregaActivosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DescargosArticulosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CONFIGURACIONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CerrarSeccionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurarServidorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModulosToolStripMenuItem, Me.ViewMenu, Me.ActivosToolStripMenuItem, Me.CONFIGURACIONToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(798, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'ModulosToolStripMenuItem
        '
        Me.ModulosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsuariosToolStripMenuItem, Me.EMPLEADOSToolStripMenuItem, Me.MARCASToolStripMenuItem, Me.PUESTDETRABAJOToolStripMenuItem, Me.DEPARTAMENTOSToolStripMenuItem})
        Me.ModulosToolStripMenuItem.Name = "ModulosToolStripMenuItem"
        Me.ModulosToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.ModulosToolStripMenuItem.Text = "&REGISTROS"
        '
        'UsuariosToolStripMenuItem
        '
        Me.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem"
        Me.UsuariosToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.UsuariosToolStripMenuItem.Text = "Usuarios"
        '
        'EMPLEADOSToolStripMenuItem
        '
        Me.EMPLEADOSToolStripMenuItem.Name = "EMPLEADOSToolStripMenuItem"
        Me.EMPLEADOSToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EMPLEADOSToolStripMenuItem.Text = "EMPLEADOS"
        '
        'MARCASToolStripMenuItem
        '
        Me.MARCASToolStripMenuItem.Name = "MARCASToolStripMenuItem"
        Me.MARCASToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.MARCASToolStripMenuItem.Text = "MARCAS"
        '
        'PUESTDETRABAJOToolStripMenuItem
        '
        Me.PUESTDETRABAJOToolStripMenuItem.Name = "PUESTDETRABAJOToolStripMenuItem"
        Me.PUESTDETRABAJOToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PUESTDETRABAJOToolStripMenuItem.Text = "PUEST. DE TRABAJO"
        '
        'DEPARTAMENTOSToolStripMenuItem
        '
        Me.DEPARTAMENTOSToolStripMenuItem.Name = "DEPARTAMENTOSToolStripMenuItem"
        Me.DEPARTAMENTOSToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DEPARTAMENTOSToolStripMenuItem.Text = "DEPARTAMENTOS"
        '
        'ViewMenu
        '
        Me.ViewMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ACTIVOSToolStripMenuItem1, Me.ARTICULOSToolStripMenuItem, Me.EMPLEADOSToolStripMenuItem1})
        Me.ViewMenu.Name = "ViewMenu"
        Me.ViewMenu.Size = New System.Drawing.Size(63, 20)
        Me.ViewMenu.Text = "&BUSCAR"
        '
        'ACTIVOSToolStripMenuItem1
        '
        Me.ACTIVOSToolStripMenuItem1.Name = "ACTIVOSToolStripMenuItem1"
        Me.ACTIVOSToolStripMenuItem1.Size = New System.Drawing.Size(141, 22)
        Me.ACTIVOSToolStripMenuItem1.Text = "ACTIVOS"
        '
        'ARTICULOSToolStripMenuItem
        '
        Me.ARTICULOSToolStripMenuItem.Name = "ARTICULOSToolStripMenuItem"
        Me.ARTICULOSToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.ARTICULOSToolStripMenuItem.Text = "ARTICULOS"
        '
        'EMPLEADOSToolStripMenuItem1
        '
        Me.EMPLEADOSToolStripMenuItem1.Name = "EMPLEADOSToolStripMenuItem1"
        Me.EMPLEADOSToolStripMenuItem1.Size = New System.Drawing.Size(141, 22)
        Me.EMPLEADOSToolStripMenuItem1.Text = "EMPLEADOS"
        '
        'ActivosToolStripMenuItem
        '
        Me.ActivosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EntregaActivosToolStripMenuItem, Me.DescargosArticulosToolStripMenuItem})
        Me.ActivosToolStripMenuItem.Name = "ActivosToolStripMenuItem"
        Me.ActivosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ActivosToolStripMenuItem.Text = "ACTIVOS"
        '
        'EntregaActivosToolStripMenuItem
        '
        Me.EntregaActivosToolStripMenuItem.Name = "EntregaActivosToolStripMenuItem"
        Me.EntregaActivosToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.EntregaActivosToolStripMenuItem.Text = "Entregar Articulos"
        '
        'DescargosArticulosToolStripMenuItem
        '
        Me.DescargosArticulosToolStripMenuItem.Name = "DescargosArticulosToolStripMenuItem"
        Me.DescargosArticulosToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.DescargosArticulosToolStripMenuItem.Text = "Descargos Articulos"
        '
        'CONFIGURACIONToolStripMenuItem
        '
        Me.CONFIGURACIONToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CerrarSeccionToolStripMenuItem, Me.ConfigurarServidorToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.CONFIGURACIONToolStripMenuItem.Name = "CONFIGURACIONToolStripMenuItem"
        Me.CONFIGURACIONToolStripMenuItem.Size = New System.Drawing.Size(114, 20)
        Me.CONFIGURACIONToolStripMenuItem.Text = "CONFIGURACION"
        '
        'CerrarSeccionToolStripMenuItem
        '
        Me.CerrarSeccionToolStripMenuItem.Name = "CerrarSeccionToolStripMenuItem"
        Me.CerrarSeccionToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.CerrarSeccionToolStripMenuItem.Text = "Cerrar Seccion"
        '
        'ConfigurarServidorToolStripMenuItem
        '
        Me.ConfigurarServidorToolStripMenuItem.Name = "ConfigurarServidorToolStripMenuItem"
        Me.ConfigurarServidorToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ConfigurarServidorToolStripMenuItem.Text = "Configurar Servidor"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 498)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(798, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(110, 17)
        Me.ToolStripStatusLabel.Text = "Nombre Completo:"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(89, 17)
        Me.ToolStripStatusLabel2.Text = "Tipo de Usuario"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel3.Text = "ToolStripStatusLabel3"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(798, 474)
        Me.Panel1.TabIndex = 9
        '
        'FrmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 520)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "FrmPrincipal"
        Me.Text = "Sistema"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ViewMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ModulosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UsuariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ActivosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EntregaActivosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DescargosArticulosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EMPLEADOSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MARCASToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PUESTDETRABAJOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DEPARTAMENTOSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CONFIGURACIONToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CerrarSeccionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfigurarServidorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ACTIVOSToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ARTICULOSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EMPLEADOSToolStripMenuItem1 As ToolStripMenuItem
End Class
