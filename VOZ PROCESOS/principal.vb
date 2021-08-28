Imports System.Speech.Recognition
Imports System.IO
Imports System.Security
Imports System.Security.Principal

Public Class principal
    Public ventanas As Int16
    Dim hablar As Boolean = False
    Dim dictar As Boolean = False
    Private WithEvents listener As New SpeechRecognizer

    Dim REC As New SpeechRecognitionEngine
    Dim PALABRA As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listener.LoadGrammar(New DictationGrammar)
        REC.SetInputToDefaultAudioDevice()
        REC.LoadGrammar(New Grammar(New GrammarBuilder(New Choices(File.ReadAllLines("../../../gramatica.txt")))))
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
                TextBox1.Text = ""
                hablar = False
            End If
        End If
    End Sub

    Private Sub btn_dictar_Click(sender As Object, e As EventArgs) Handles btn_dictar.Click
        If (hablar = False) Then
            If (dictar = False) Then
                lbl_corregir.Text = ""
                TextBox1.Text = ""
                lbl_hablando.Text = "Comience a Dictar.."
                btn_dictar.Text = "Detener"
                dictar = True
            Else
                dictar = False
            End If
        End If
    End Sub

    Function GetTargetPath(ByVal FileName As String)
        Dim Obj As Object
        Obj = CreateObject("WScript.Shell")
        Dim Shortcut As Object
        Shortcut = Obj.CreateShortcut(FileName)
        GetTargetPath = Shortcut.TargetPath
    End Function

    Public Sub RECONOCE(ByVal sender As Object, ByVal e As SpeechRecognizedEventArgs)
        If (hablar) Then
            Dim RESULTADO As RecognitionResult = e.Result
            TextBox1.Text = TextBox1.Text + " " + RESULTADO.Text.ToUpper
            Dim PROCESO As New Process
            'Dim c As String = "C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Word.lnk"
            '' Obtain file information in a string.
            'Dim fileInfoText As String = GetTextForOutput(c)

            '' Show the file information.
            'MessageBox.Show(fileInfoText)
            MsgBox(GetTargetPath("C:\ProgramData\Microsoft\Windows\Start Menu\Programs\TeXstudio.lnk"))
            'Select Case RESULTADO.Text
            '    Case "abrir arduino"
            '        PROCESO.StartInfo.FileName = "C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Word.lnk"
            '        PROCESO.Start()
            '    Case "abrir word"
            '        PROCESO.StartInfo.FileName = "C:\Program Files\Windows NT\Accessories\wordpad.exe"
            '        PROCESO.Start()
            '    Case "abrir paint"
            '        PROCESO.StartInfo.FileName = "C:\Windows\System32/mspaint.exe"
            '        PROCESO.Start()
            'End Select
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


End Class
