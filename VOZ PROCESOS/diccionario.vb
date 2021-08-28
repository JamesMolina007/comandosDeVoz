Imports System.IO

Public Class diccionario
    Private Sub cb_categoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_categoria.SelectedIndexChanged
        If (cb_categoria.SelectedIndex = 0) Then
            lbl_palabra.Text = "Ingrese el nombre de la aplicación:"
        Else
            lbl_palabra.Text = "Ingrese la palabra:"
        End If
        tb_palabra.Enabled = True
    End Sub

    Private Sub diccionario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        If (tb_palabra.Text.Length > 1) Then
            Dim escribir As New StreamWriter("../../../gramatica.txt", True)
            Try
                If (cb_categoria.SelectedIndex = 0) Then
                    escribir.WriteLine("abrir " + tb_palabra.Text)
                    escribir.WriteLine("cerrar " + tb_palabra.Text)
                Else
                    escribir.WriteLine(tb_palabra.Text)
                End If
                escribir.Close()
                MsgBox("Correccion guardada correctamente", MsgBoxStyle.Information, "Guardado")
                Me.Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub diccionario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim p As New principal
        p.Visible = True
    End Sub
End Class