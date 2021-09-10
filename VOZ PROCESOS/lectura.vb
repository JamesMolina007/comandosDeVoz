Imports System.IO

Public Class lectura
    Private direccion As String
    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        Try
            direccion = obtenerDirectorio()
            Dim archivo = File.OpenText(direccion)
            Dim lineas = File.ReadAllLines(direccion).Length
            For index = 0 To lineas - 1
                tb_lectura.Text += archivo.ReadLine()
                tb_lectura.Text += vbNewLine
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btn_leer_Click(sender As Object, e As EventArgs) Handles btn_leer.Click
        Dim SAPI As Object
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.Speak(tb_lectura.Text)
    End Sub

    Private Function obtenerDirectorio() As String
        Try
            Dim abrirArchivo As New OpenFileDialog With {.Filter = "Archivos de texto (*.txt)|*.txt|Archivos de texto (*.txt)|*.txt"}
            If abrirArchivo.ShowDialog() = DialogResult.OK Then
                Dim direcciones = abrirArchivo.FileName.Split("\")
                Return abrirArchivo.FileName
            End If
        Catch err As Exception
            MsgBox("Error al buscar musica")
        End Try
        Return ""
    End Function

End Class