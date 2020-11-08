Imports System.Data.SqlClient
Public Class frmLogin
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If UsernameTextBox.Text = "" Or PasswordTextBox.Text = "" Then
            MsgBox("Falta Ingresar Datos", vbExclamation, "Operacion Cancelada")
        Else
            Try
                conexion.Open()
                adaptador = New SqlDataAdapter("Select * from Usuarios where Usuario='" & UsernameTextBox.Text & "' AND Contraseña ='" & PasswordTextBox.Text & "' ", conexion)
                tabla.Clear()
                adaptador.Fill(tabla)
                If tabla.Rows.Count = 1 Then
                    Dim fila As DataRow = tabla.Rows(0)
                    nombre = Trim(fila("NombreCompleto").ToString)
                    Tipousuario = Trim(fila("TipoUsuario").ToString)

                    FrmPrincipal.ToolStripStatusLabel1.Text = nombre
                    FrmPrincipal.ToolStripStatusLabel3.Text = Tipousuario
                    MsgBox("Datos Verificados", vbInformation, "Operacion Completada")
                    UsernameTextBox.Text = ""
                    PasswordTextBox.Text = ""
                    Me.Hide()
                    FrmPrincipal.Show()
                Else
                    MsgBox("Nombre de Usuario o Contraseña No Validos", vbExclamation, "Operacion Cancelada")
                    UsernameTextBox.Text = ""
                    PasswordTextBox.Text = ""
                End If
                conexion.Close()
            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "Error")
            End Try
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LogoPictureBox_Click(sender As Object, e As EventArgs) Handles LogoPictureBox.Click
        frmConfiguracion.Show()
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        establecerConexion()
    End Sub
End Class
