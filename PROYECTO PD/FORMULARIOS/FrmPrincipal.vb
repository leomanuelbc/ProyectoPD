Imports System.Windows.Forms
Public Class FrmPrincipal
    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        On Error Resume Next
        Dim salir As String
        salir = MsgBox("Desea Salir del Sistema", vbQuestion + vbYesNo, "Sistema")
        If salir = vbYes Then
            Global.System.Windows.Forms.Application.Exit()
        Else
            Me.ShowDialog()
        End If
    End Sub
    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub
    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub
    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub
    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub
    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Cierre todos los formularios secundarios del principal.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub
    Private m_ChildFormNumber As Integer
    Private Sub UsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsuariosToolStripMenuItem.Click
        If UCase(Tipousuario) = "ADMINISTRADOR" Then
            frmUsuarios.Show()
        Else
            MsgBox("No Tiene Los Privilegios Para el Modulo Correspondiente", vbInformation, "Operacion Cancelada")
        End If
    End Sub

    Private Sub EntregaActivosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntregaActivosToolStripMenuItem.Click
        frmCargoActivos.Show()
    End Sub

    Private Sub RegistrarArticulosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        frmArticulos.Show()
    End Sub

    Private Sub DescargosArticulosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DescargosArticulosToolStripMenuItem.Click
        If UCase(Tipousuario) = "ADMINISTRADOR" Then
            frmDescargosActivos.Show()
        Else
            MsgBox("No Tiene Los Privilegios Para el Modulo Correspondiente", vbInformation, "Operacion Cancelada")
        End If
    End Sub

    Private Sub CerrarSeccionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSeccionToolStripMenuItem.Click
        Me.Hide()
        frmLogin.Show()
    End Sub

    Private Sub ConfigurarServidorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigurarServidorToolStripMenuItem.Click
        frmConfiguracion.ShowDialog()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        On Error Resume Next
        Dim salir As String
        salir = MsgBox("Desea Salir del Sistema", vbQuestion + vbYesNo, "Sistema")
        If salir = vbYes Then
            Global.System.Windows.Forms.Application.Exit()
        Else
            Me.ShowDialog()
        End If
    End Sub

    Private Sub EMPLEADOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EMPLEADOSToolStripMenuItem.Click
        frmEmpleados.ShowDialog()
    End Sub

    Private Sub MARCASToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MARCASToolStripMenuItem.Click
        frmMarcas.ShowDialog()
    End Sub

    Private Sub PUESTDETRABAJOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PUESTDETRABAJOToolStripMenuItem.Click
        frmPuestosTrabajo.ShowDialog()
    End Sub

    Private Sub ACTIVOSToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ACTIVOSToolStripMenuItem1.Click
        FrmBusquedaActivos.ShowDialog()
    End Sub

    Private Sub ARTICULOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ARTICULOSToolStripMenuItem.Click
        frmBusquedaArticulos.ShowDialog()
    End Sub

    Private Sub EMPLEADOSToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EMPLEADOSToolStripMenuItem1.Click
        frmBusquedaEmpleados.ShowDialog()
    End Sub

    Private Sub DEPARTAMENTOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DEPARTAMENTOSToolStripMenuItem.Click
        frmDepartamentos.ShowDialog()
    End Sub

End Class
