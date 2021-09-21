Imports System.IO

Public Class diccionario

    'Cambia si se selecciona la categoria palabra o aplicación
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

    'Boton de agregar
    Private Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        If (tb_palabra.Text.Length > 1) Then
            Dim escribir As New StreamWriter("../../../gramatica.txt", True) 'Se agregará al de gramatica
            Try
                If (cb_categoria.SelectedIndex = 0) Then
                    Dim resultado = tb_palabra.Text.ToLower
                    resultado = eliminar_Tildes(resultado) 'Se eliminan las tildes
                    escribir.WriteLine("abrir " + resultado) 'Se crea el comando abrir aplicacion
                    escribir.WriteLine("ejecuta " + resultado) 'Se crea el comando ejecuta aplicacion
                    escribir.WriteLine("cerrar " + resultado) 'Se crea el comando cerrar aplicacion
                Else
                    escribir.WriteLine(tb_palabra.Text) 'Sino solo escribe la palabra
                End If
                escribir.Close()
                MsgBox("Correccion guardada correctamente", MsgBoxStyle.Information, "Guardado")
                Me.Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    'Funcion para eliminar tildes de una cadena
    Public Function eliminar_Tildes(ByVal accentedStr As String) As String
        Dim tempBytes As Byte()
        tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(accentedStr)
        Return System.Text.Encoding.UTF8.GetString(tempBytes)
    End Function

    'Metodo para cerrar el diccionario
    Private Sub diccionario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim p As New principal
        p.Visible = True
    End Sub
End Class