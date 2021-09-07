Public Class musica
    Private numeroCancion = -1

    Private Sub btn_reproducir_Click(sender As Object, e As EventArgs) Handles btn_reproducir.Click
        Try
            AxWindowsMediaPlayer1.URL = lb_direcciones.Items(lb_cola.SelectedIndex)
            siguienteAnterior(lb_cola.SelectedIndex)
            numeroCancion = lb_cola.SelectedIndex
        Catch err As Exception
            MessageBox.Show("Debe agregar al menos una canción a la cola o Seleccionarla")
        End Try
    End Sub

    Private Sub musica_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_Siguiente_Click(sender As Object, e As EventArgs) Handles btn_Siguiente.Click
        Try
            numeroCancion += 1
            AxWindowsMediaPlayer1.URL = lb_direcciones.Items(numeroCancion)
            lb_cola.SetSelected(numeroCancion, True)
            siguienteAnterior(numeroCancion)
        Catch ex As Exception
            numeroCancion -= 1
        End Try
    End Sub

    Private Sub btn_Anterior_Click(sender As Object, e As EventArgs) Handles btn_Anterior.Click
        Try
            numeroCancion -= 1
            AxWindowsMediaPlayer1.URL = lb_direcciones.Items(numeroCancion)
            lb_cola.SetSelected(numeroCancion, True)
            siguienteAnterior(numeroCancion)
        Catch ex As Exception
            numeroCancion += 1
        End Try
    End Sub

    Private Sub btn_agregarCola_Click(sender As Object, e As EventArgs) Handles btn_agregarCola.Click
        Try
            Dim abrirArchivo As New OpenFileDialog With {.Filter = "Archivos Mpeg Layer 3 (*.mp3)|*.mp3|Listas de canciones (*.m3u)|*.m3u"}
            If abrirArchivo.ShowDialog() = DialogResult.OK Then
                Dim direcciones = abrirArchivo.FileName.Split("\")
                lb_direcciones.Items.Add(abrirArchivo.FileName)
                lb_cola.Items.Add(direcciones(direcciones.Length - 1))
                siguienteAnterior(numeroCancion)
            End If
        Catch err As Exception
            MsgBox("Error al buscar musica")
        End Try
    End Sub

    Private Sub btn_limpiarCola_Click(sender As Object, e As EventArgs) Handles btn_limpiarCola.Click
        Try
            lb_direcciones.Items.Clear()
            lb_cola.Items.Clear()
            lbl_siguiente.Text = "___"
            lbl_anterior.Text = "___"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_quitarDeCola_Click(sender As Object, e As EventArgs) Handles btn_quitarDeCola.Click
        Try
            lb_direcciones.Items.RemoveAt(lb_cola.SelectedIndex)
            lb_cola.Items.RemoveAt(lb_cola.SelectedIndex)
            siguienteAnterior(numeroCancion)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub siguienteAnterior(numero As Int16)
        Try
            If (numero > 0) Then
                lbl_anterior.Text = lb_cola.Items(numero - 1)
            Else
                lbl_anterior.Text = "___"
            End If
            If (numero < lb_cola.Items.Count - 1) Then
                lbl_siguiente.Text = lb_cola.Items(numero + 1)
            Else
                lbl_siguiente.Text = "___"
            End If
            lbl_reproduciendo.Text = lb_cola.Items(numero)
        Catch ex As Exception

        End Try
    End Sub
End Class