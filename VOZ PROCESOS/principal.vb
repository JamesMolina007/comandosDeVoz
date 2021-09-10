Imports System.Speech.Recognition
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf



Public Class principal
    Private ventanas As Int16
    Private com As New comando
    Private hablar As Boolean = False
    Private dictar As Boolean = False
    Private corriendo As Boolean = False
    Private reconocedorWindows As Boolean = False

    'WINDOWS
    Private WithEvents listener As New SpeechRecognizer

    'DICCIONARIO
    Private REC As New SpeechRecognitionEngine
    Private PALABRA As String
    Private DIC As New SpeechRecognitionEngine

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'WINDOWS
        listener.LoadGrammar(New DictationGrammar)


        'DICCIONARIO
        REC.SetInputToDefaultAudioDevice()
        REC.LoadGrammar(New Grammar(New GrammarBuilder(New Choices(File.ReadAllLines("../../../gramatica.txt")))))
        REC.RecognizeAsync(RecognizeMode.Multiple)
        AddHandler REC.SpeechRecognized, AddressOf RECONOCE
        AddHandler REC.SpeechRecognitionRejected, AddressOf NORECONOCE

        DIC.SetInputToDefaultAudioDevice()
        DIC.LoadGrammar(New Grammar(New GrammarBuilder(New Choices(File.ReadAllLines("../../../palabrasEspañol.txt")))))
        DIC.RecognizeAsync(RecognizeMode.Multiple)
        AddHandler DIC.SpeechRecognized, AddressOf RECONOCEDICTADO
        AddHandler DIC.SpeechRecognitionRejected, AddressOf NORECONOCEDICTADO
    End Sub

    Private Sub rb_diccionario_CheckedChanged(sender As Object, e As EventArgs) Handles rb_diccionario.CheckedChanged
        reconocedorWindows = False
    End Sub

    Private Sub rb_windows_CheckedChanged(sender As Object, e As EventArgs) Handles rb_windows.CheckedChanged
        reconocedorWindows = True
    End Sub

    Private Sub listener_SpeechRecognized(sender As Object, e As SpeechRecognizedEventArgs) Handles listener.SpeechRecognized
        If (hablar And reconocedorWindows) Then
            com.listBox = lb_apps
            com.listBoxDireccion = apuntadorDireccion
            com.cadenaComando = e.Result.Text
            com.leerComando()

            Dim RESULTADO As RecognitionResult = e.Result
            tb_comando.Text = RESULTADO.Text.ToUpper
            Dim PROCESO As New Process
            lbl_corregir.Text = "No fue lo que dije!"
        ElseIf (dictar And reconocedorWindows) Then
            Dim RESULTADO As RecognitionResult = e.Result
            tb_comando.Text += " " & RESULTADO.Text.ToUpper
        End If
    End Sub

    Private Sub btn_escuchar_Click(sender As Object, e As EventArgs) Handles btn_escuchar.Click
        tb_comando.Enabled = False
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
                tb_comando.Enabled = True
                lbl_corregir.Text = ""
                tb_comando.Text = ""
                lbl_hablando.Text = "Comience a Dictar.."
                btn_dictar.Text = "Detener"
                dictar = True
            Else
                tb_comando.Enabled = True
                btn_dictar.Text = "Dictar"
                lbl_hablando.Text = "___"
                dictar = False
            End If
        End If
    End Sub


    Public Sub RECONOCE(ByVal sender As Object, ByVal e As SpeechRecognizedEventArgs)
        If (hablar And Not reconocedorWindows) Then
            com.listBox = lb_apps
            com.listBoxDireccion = apuntadorDireccion
            com.cadenaComando = e.Result.Text
            com.leerComando()

            Dim RESULTADO As RecognitionResult = e.Result
            tb_comando.Text = RESULTADO.Text.ToUpper
            Dim PROCESO As New Process
            lbl_corregir.Text = "No fue lo que dije!"
        End If
    End Sub


    Public Sub NORECONOCE()
        If (hablar) Then
            lbl_hablando.Text = "REPITE, POR FAVOR"
        End If
    End Sub

    Public Sub RECONOCEDICTADO(ByVal sender As Object, ByVal e As SpeechRecognizedEventArgs)
        If (dictar And Not reconocedorWindows) Then
            Dim RESULTADO As RecognitionResult = e.Result
            tb_comando.Text += " " & RESULTADO.Text.ToUpper
        End If
    End Sub


    Public Sub NORECONOCEDICTADO()
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
        'ventanas += 1
        tb_comando.Enabled = False
        Dim instrucciones As New manual
        instrucciones.diccionario = (Not reconocedorWindows)
        instrucciones.Visible = True
        'Me.Close()
    End Sub

    Private Sub lb_apps_DoubleClick(sender As Object, e As EventArgs) Handles lb_apps.DoubleClick
        Dim id = lb_apps.SelectedIndex
        Dim direccion = apuntadorDireccion.Items(id)
        com.accion(direccion, False)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles dlGuardar.Click
        'Algoritmo extraído de https://www.lawebdelprogramador.com/foros/Visual-Basic/1724843-Crear-PDF-o-exportar-en-PDF.html

        Dim autor As String = InputBox("Autor")
        Dim Titulo As String = InputBox("Titulo")
        Dim nombreDocumento As String = InputBox("Nombre del documento")
        Dim ruta = obtenerDirectorio()
        ruta += "/" & nombreDocumento & ".pdf"
        Dim pdfDoc As New Document()
        Dim pdf As PdfWriter = PdfWriter.GetInstance(pdfDoc, New IO.FileStream(ruta, FileMode.Create))

        Dim bf As iTextSharp.text.Font = FontFactory.GetFont("C:\Windows\Arial Monospaced for SAP", 9)
        Dim bf1 As iTextSharp.text.Font = FontFactory.GetFont("C:\Windows\Arial Monospaced for SAP", 12)
        Dim bf2 As iTextSharp.text.Font = FontFactory.GetFont("C:\Windows\Arial Monospaced for SAP", 5)
        Dim fFont = New iTextSharp.text.Font(bf)
        Dim fFont1 = New iTextSharp.text.Font(bf1)
        Dim fFont2 = New iTextSharp.text.Font(bf2)

        pdfDoc.Open()
        pdfDoc.Add(New Paragraph("   ", fFont1))
        pdfDoc.Add(New Paragraph("                                                                                  ", fFont2))
        pdfDoc.Add(New Paragraph("       " + tb_comando.Text, fFont1))
        pdfDoc.Close()
        MsgBox("El PDF se ha generado correctamente")
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim obj As New Object
        Dim archivo As New Object
        Dim nombreArchivo As String = InputBox("Nombre del archivo")
        Dim ruta As String = obtenerDirectorio()
        ruta += "/" & nombreArchivo & ".txt"
        obj = CreateObject("Scripting.FileSystemObject")
        archivo = obj.CreateTextFile(ruta, True)
        archivo.WriteLine(tb_comando.Text)
        MsgBox("El archivo de texto se ha creado correctamente ")
        archivo.close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim objWord As Object
        Dim objDoc As Object
        Dim objSelection As Object
        Dim nombreDocumento As String = InputBox("Nombre del documento")
        Dim ruta = obtenerDirectorio()
        ruta += "/" & nombreDocumento
        objWord = CreateObject("Word.Application")
        objDoc = objWord.Documents.Add

        objWord.Visible = True

        objSelection = objWord.Selection

        objSelection.TypeText(tb_comando.Text)
        objWord.ActiveDocument.SaveAs(ruta)
        MsgBox("El documento word se ha creado correctamente ")
    End Sub

    Private Function obtenerDirectorio() As String
        Dim folder As New FolderBrowserDialog
        Dim ruta As String = String.Empty

        If folder.ShowDialog = Windows.Forms.DialogResult.OK Then
            ruta = folder.SelectedPath
        End If
        Return ruta
    End Function

End Class
