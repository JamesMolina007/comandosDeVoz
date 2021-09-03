Imports System.Speech.Recognition
Imports System.IO

Public Class principal
    Private ventanas As Int16
    Private com As New comando
    Private hablar As Boolean = False
    Private dictar As Boolean = False
    Private corriendo As Boolean = False

    'WINDOWS
    Private WithEvents listener As New SpeechRecognizer

    'DICCIONARIO
    Private REC As New SpeechRecognitionEngine
    Private PALABRA As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'WINDOWS
        listener.LoadGrammar(New DictationGrammar)


        'DICCIONARIO
        REC.SetInputToDefaultAudioDevice()
        REC.LoadGrammar(New Grammar(New GrammarBuilder(New Choices(File.ReadAllLines("../../../gramatica.txt")))))
        REC.RecognizeAsync(RecognizeMode.Multiple)
        AddHandler REC.SpeechRecognized, AddressOf RECONOCE
        AddHandler REC.SpeechRecognitionRejected, AddressOf NORECONOCE


    End Sub

    Private Sub listener_SpeechRecognized(sender As Object, e As SpeechRecognizedEventArgs) Handles listener.SpeechRecognized
        If (dictar) Then
            tb_comando.Text += e.Result.Text + " "
        End If
    End Sub

    Private Sub btn_escuchar_Click(sender As Object, e As EventArgs) Handles btn_escuchar.Click
        If (dictar = False) Then
            If (hablar = False) Then
                hablar = True
                lbl_hablando.Text = "Escuchando..."
                btn_escuchar.Text = "Detener"
                lbl_corregir.Text = ""
            Else
                btn_escuchar.Text = "Hablar"
                lbl_hablando.Text = ""
                hablar = False
                corriendo = False
            End If
        End If
    End Sub

    Private Sub btn_dictar_Click(sender As Object, e As EventArgs) Handles btn_dictar.Click
        If (hablar = False) Then
            lb_apps.Items.Clear()
            apuntadorDireccion.Items.Clear()
            If (dictar = False) Then
                lbl_corregir.Text = ""
                tb_comando.Text = ""
                lbl_hablando.Text = "Comience a Dictar.."
                btn_dictar.Text = "Detener"
                dictar = True
            Else
                btn_dictar.Text = "Dictar"
                lbl_hablando.Text = "___"
                dictar = False
            End If
        End If
    End Sub


    Public Sub RECONOCE(ByVal sender As Object, ByVal e As SpeechRecognizedEventArgs)
        If (hablar) Then
            If (Not corriendo) Then
                corriendo = True
                Dim RESULTADO As RecognitionResult = e.Result
                tb_comando.Text = RESULTADO.Text.ToUpper
                lbl_corregir.Text = "No fue lo que dije!"
                com.listBox = lb_apps
                com.listBoxDireccion = apuntadorDireccion
                com.cadenaComando = e.Result.Text
                com.leerComando()
            End If
        End If
    End Sub


    Public Sub NORECONOCE()
        If (hablar) Then
            lbl_hablando.Text = "REPITE, POR FAVOR"
        End If
    End Sub

    Private Sub lbl_corregir_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbl_corregir.LinkClicked
        If (lbl_corregir.Text <> "___") Then
            Dim nuevaPalabra As New diccionario
            nuevaPalabra.Visible = True
            ventanas += 1
            Me.Close()
        End If
    End Sub

    Private Sub principal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If ventanas <> 0 Then
            e.Cancel = True
            Me.Visible = False
        End If
    End Sub

    Private Sub btn_Manual_Click(sender As Object, e As EventArgs) Handles btn_Manual.Click
        ventanas += 1
        Dim instrucciones As New manual
        instrucciones.Visible = True
        Me.Close()
    End Sub

    Private Sub lb_apps_DoubleClick(sender As Object, e As EventArgs) Handles lb_apps.DoubleClick
        Dim id = lb_apps.SelectedIndex
        Dim direccion = apuntadorDireccion.Items(id)
        com.accion(direccion, False)
    End Sub

End Class
