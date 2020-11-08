Imports System.IO
Public Class frmConfiguracion
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub btnConectar_Click(sender As Object, e As EventArgs) Handles btnConectar.Click
        If txtIp.Text = "" Or txtUs.Text = "" Or txtPa.Text = "" Or txtBd.Text = "" Then
            MsgBox("Completar Todos los Campos", vbCritical, "Operacion Cancelada")

        End If
        'pertenece a la biblioteca IO StreamWriter
        Dim archivo As StreamWriter
        Try
            archivo = New StreamWriter(Application.StartupPath + "\IP.txt ")
            archivo.WriteLine(txtIp.Text.Trim)
            archivo.Flush()
            archivo.Close()
            archivo = New StreamWriter(Application.StartupPath + "\BD.txt ")
            archivo.WriteLine(txtBd.Text.Trim)
            archivo.Flush()
            archivo.Close()
            archivo = New StreamWriter(Application.StartupPath + "\USER.txt ")
            archivo.WriteLine(txtUs.Text.Trim)
            archivo.Flush()
            archivo.Close()
            archivo = New StreamWriter(Application.StartupPath + "\PASS.txt ")
            archivo.WriteLine(txtPa.Text.Trim)
            archivo.Flush()
            archivo.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        btnCancelar.PerformClick()
    End Sub

    Private Sub frmConfiguracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If File.Exists(Application.StartupPath + "\IP.txt ") Then
                txtIp.Text = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\IP.txt ")
            End If
            If File.Exists(Application.StartupPath + "\USER.txt ") Then
                txtUs.Text = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\USER.txt ")
            End If
            If File.Exists(Application.StartupPath + "\PASS.txt ") Then
                txtPa.Text = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\PASS.txt ")
            End If
            If File.Exists(Application.StartupPath + "\BD.txt ") Then
                txtBd.Text = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\BD.txt ")
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class
