Imports System.Speech.Recognition
Imports System.IO
Imports System.Security
Imports System.Security.Principal

Public Class principal
    Public ventanas As Int16
    Dim com As New comando
    Dim hablar As Boolean = False
    Dim dictar As Boolean = False

    'WINDOWS
    Private WithEvents listener As New SpeechRecognizer

    'DICCIONARIO
    Dim REC As New SpeechRecognitionEngine
    Dim PALABRA As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'WINDOWS
        listener.LoadGrammar(New DictationGrammar)


        'DICCIONARIO
        REC.SetInputToDefaultAudioDevice()
        REC.LoadGrammar(New Grammar(New GrammarBuilder(New Choices(File.ReadAllLines("../../../gramatica.txt")))
        REC.RecognizeAsync(RecognizeMode.Multiple)
        AddHandler REC.SpeechRecognized, AddressOf RECONOCE
        AddHandler REC.SpeechRecognitionRejected, AddressOf NORECONOCE


    End Sub

    Private Sub listener_SpeechRecognized(sender As Object, e As SpeechRecognizedEventArgs) Handles listener.SpeechRecognized
        If (dictar) Then
            TextBox1.Text += e.Result.Text + " "
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
            End If
        End If
    End Sub

    Private Sub btn_dictar_Click(sender As Object, e As EventArgs) Handles btn_dictar.Click
        If (hablar = False) Then
            lb_apps.Items.Clear()
            apuntadorDireccion.Items.Clear()
            If (dictar = False) Then
                lbl_corregir.Text = ""
                TextBox1.Text = ""
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
            com.listBox = lb_apps
            com.listBoxDireccion = apuntadorDireccion
            com.cadenaComando = e.Result.Text
            com.leerComando()

            Dim RESULTADO As RecognitionResult = e.Result
            TextBox1.Text = RESULTADO.Text.ToUpper
            Dim PROCESO As New Process
            lbl_corregir.Text = "No fue lo que dije!"
        End If
    End Sub


    Public Sub NORECONOCE()
        If (hablar) Then
            lbl_hablando.Text = "REPITE, POR FAVOR"
        End If
    End Sub

    Private Sub lbl_corregir_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbl_corregir.LinkClicked
        Dim nuevaPalabra As New diccionario
        nuevaPalabra.Visible = True
        ventanas += 1
        Me.Close()
    End Sub

    Private Sub principal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If ventanas <> 0 Then
            e.Cancel = True
            Me.Visible = False
        End If
    End Sub

    Private Sub btn_Manual_Click(sender As Object, e As EventArgs) Handles btn_Manual.Click
        ventanas += 1
    End Sub

    Private Sub lb_apps_DoubleClick(sender As Object, e As EventArgs) Handles lb_apps.DoubleClick
        Dim id = lb_apps.SelectedIndex
        Dim direccion = apuntadorDireccion.Items(id)
        com.abrirAplicacion(direccion, False)
    End Sub

End Class
