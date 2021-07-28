Imports System.Speech.Recognition

Public Class principal
    Dim hablar As Boolean = False
    Private WithEvents listener As New SpeechRecognizer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listener.LoadGrammar(New DictationGrammar)
    End Sub

    Private Sub listener_SpeechRecognized(sender As Object, e As SpeechRecognizedEventArgs) Handles listener.SpeechRecognized
        If (hablar) Then
            TextBox1.Text = e.Result.Text + " "
            lbl_hablando.Text = ""
        End If
    End Sub

    Private Sub btn_escuchar_Click(sender As Object, e As EventArgs) Handles btn_escuchar.Click
        hablar = True
        lbl_hablando.Text = "Escuchando..."
    End Sub
End Class
