Imports System.Windows.Forms
Public Class FrmPrincipal
    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        On Error Resume Next
        Dim salir As String
        salir = MsgBox("Desea Salir del Sistema", vbQuestion + vbYesNo, "Sistema")
        If salir = vbYes Then
            Global.System.Windows.Forms.Application.Exit()
        Else
            Me.ShowDialog()
        End If
    End Sub
    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub
    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub
    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub
    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub
    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub
    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub
    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
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

    Private Sub RegistrarArticulosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarArticulosToolStripMenuItem.Click
        frmArticulos.Show()
    End Sub

    Private Sub DescargosArticulosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DescargosArticulosToolStripMenuItem.Click
        If UCase(Tipousuario) = "ADMINISTRADOR" Then
            frmDescargosActivos.Show()
        Else
            MsgBox("No Tiene Los Privilegios Para el Modulo Correspondiente", vbInformation, "Operacion Cancelada")
        End If
    End Sub
End Class
