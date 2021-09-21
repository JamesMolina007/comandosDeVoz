Imports System.IO

Public Class lectura
    Private direccion As String

    'Meotod que permite leer un archivo de texto y escribir su contenido en el text box tb_lectura
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

    'Metodo para que el objeto SAPI me lea el texto
    Private Sub btn_leer_Click(sender As Object, e As EventArgs) Handles btn_leer.Click
        Dim SAPI As Object
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.Speak(tb_lectura.Text)
    End Sub

    'Funcion para obtener el directorio del archivo de texto a leer
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

    Private Sub lectura_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class