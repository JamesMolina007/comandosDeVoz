Imports System.Speech.Recognition
Imports System.IO
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf



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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles dlGuardar.Click
        Dim autor = "Gabriel"
        Dim Titulo = "Dictar"


        Dim pdfDoc As New Document()
        Dim pdf As PdfWriter = PdfWriter.GetInstance(pdfDoc, New IO.FileStream("Documento.pdf", FileMode.Create))
        'Formtos para distintos tamaños de letras
        Dim bf As iTextSharp.text.Font = FontFactory.GetFont("C:\Windows\Arial Monospaced for SAP", 9)
        Dim bf1 As iTextSharp.text.Font = FontFactory.GetFont("C:\Windows\Arial Monospaced for SAP", 12)
        Dim bf2 As iTextSharp.text.Font = FontFactory.GetFont("C:\Windows\Arial Monospaced for SAP", 5)
        Dim fFont = New iTextSharp.text.Font(bf)
        Dim fFont1 = New iTextSharp.text.Font(bf1)
        Dim fFont2 = New iTextSharp.text.Font(bf2)
        'abrimos el pdf para comenzar a escribir en el, al terminar cerramos
        pdfDoc.Open()
        pdfDoc.Add(New Paragraph("   ", fFont1))
        pdfDoc.Add(New Paragraph("                                                                                  ", fFont2))
        pdfDoc.Add(New Paragraph("       " + tb_comando.Text, fFont1))
        pdfDoc.Close()

        MsgBox("El fichero PDF se ha generado")


    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim obj As New Object

        Dim archivo As New Object

        Dim ruta As String = "C:\Users\Gabriel Alvarado\OneDrive\Escritorio\comandosDeVoz\VOZ PROCESOS\bin\Debug\archivo.txt" 'Ej: Documentos\archivo1.txt

        obj = CreateObject("Scripting.FileSystemObject")

        archivo = obj.CreateTextFile(ruta, True)



        archivo.WriteLine(tb_comando.Text)
        MsgBox("El archivo se ha creado correctamente ")


        archivo.close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim objWord As Object
        Dim objDoc As Object
        Dim objSelection As Object

        'Se establece el objeto (word)
        objWord = CreateObject("Word.Application")
        objDoc = objWord.Documents.Add

        objWord.Visible = True 'se muestra la aplicación

        objSelection = objWord.Selection

        objSelection.TypeText(tb_comando.Text)

    End Sub


End Class
