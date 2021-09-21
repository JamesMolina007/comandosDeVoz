Imports System.Speech.Recognition 'Libreria para el reconocimiento de voz
Imports System.IO 'Libreria para el manejo de archivos
'Librerias para el manejo de PDF
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
    Private WithEvents listener As New SpeechRecognizer 'Utilizará el reconocedor de windows por defecto

    'DICCIONARIO
    'Utilizará el reconocedor con diccionario
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

        'Cargamos gramatica para el dictado usando el diccionario
        DIC.SetInputToDefaultAudioDevice()
        DIC.LoadGrammar(New Grammar(New GrammarBuilder(New Choices(File.ReadAllLines("../../../palabrasEspañol.txt")))))
        DIC.RecognizeAsync(RecognizeMode.Multiple)
        AddHandler DIC.SpeechRecognized, AddressOf RECONOCEDICTADO
        AddHandler DIC.SpeechRecognitionRejected, AddressOf NORECONOCEDICTADO
    End Sub

    'Si se quiere estar en modo diccionario
    Private Sub rb_diccionario_CheckedChanged(sender As Object, e As EventArgs) Handles rb_diccionario.CheckedChanged
        reconocedorWindows = False
    End Sub

    'Si se quiere estar en modo reconocedor de windows
    Private Sub rb_windows_CheckedChanged(sender As Object, e As EventArgs) Handles rb_windows.CheckedChanged
        reconocedorWindows = True
    End Sub

    'Metodo de reconocimiento de voz
    Private Sub listener_SpeechRecognized(sender As Object, e As SpeechRecognizedEventArgs) Handles listener.SpeechRecognized
        If (hablar And reconocedorWindows) Then
            com.listBox = lb_apps
            com.listBoxDireccion = apuntadorDireccion
            com.cadenaComando = e.Result.Text
            com.leerComando()

            Dim RESULTADO As RecognitionResult = e.Result
            tb_comando.Text = RESULTADO.Text.ToUpper
            lbl_corregir.Text = "No fue lo que dije!"
        ElseIf (dictar And reconocedorWindows) Then
            Dim RESULTADO As RecognitionResult = e.Result
            tb_comando.Text += " " & RESULTADO.Text.ToUpper
        End If
    End Sub

    'Evento click del reconocedor de comandos
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

    'Evento click del dictado
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

    'Metodo reconoce de la implementación del diccionario
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

    'Metodo no reconoce de la implementación del diccionario
    Public Sub NORECONOCE()
        If (hablar) Then
            lbl_hablando.Text = "REPITE, POR FAVOR"
        End If
    End Sub

    'Metodo reconoce dictado de la implementación del diccionario
    Public Sub RECONOCEDICTADO(ByVal sender As Object, ByVal e As SpeechRecognizedEventArgs)
        If (dictar And Not reconocedorWindows) Then
            Dim RESULTADO As RecognitionResult = e.Result
            tb_comando.Text += " " & RESULTADO.Text.ToUpper
        End If
    End Sub

    'Metodo no reconoce dictado de la implementación del diccionario
    Public Sub NORECONOCEDICTADO()
        If (hablar) Then
            lbl_hablando.Text = "REPITE, POR FAVOR"
        End If
    End Sub

    'evento del Linked label que permite agregar palabras
    Private Sub lbl_corregir_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbl_corregir.LinkClicked
        If (lbl_corregir.Text <> "___") Then
            Dim nuevaPalabra As New diccionario
            nuevaPalabra.Visible = True
            ventanas += 1
            Me.Close()
        End If
    End Sub

    'Metodo que se ejecuta cuando se está cerrando
    Private Sub principal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If ventanas <> 0 Then
            e.Cancel = True
            Me.Visible = False
        End If
    End Sub

    'Botón que llama al manual
    Private Sub btn_Manual_Click(sender As Object, e As EventArgs) Handles btn_Manual.Click
        'ventanas += 1
        tb_comando.Enabled = False
        Dim instrucciones As New manual
        instrucciones.diccionario = (Not reconocedorWindows)
        instrucciones.Visible = True
        'Me.Close()
    End Sub

    'Si hacemos doble click en la lista de aplicaciones
    Private Sub lb_apps_DoubleClick(sender As Object, e As EventArgs) Handles lb_apps.DoubleClick
        Dim id = lb_apps.SelectedIndex
        Dim direccion = apuntadorDireccion.Items(id)
        com.accion(direccion, False)
    End Sub

    'Metodo para guardar en PDF
    Private Sub btn_guardarPDF_Click(sender As Object, e As EventArgs) Handles btn_guardarPDF.Click
        'Algoritmo extraído de https://www.lawebdelprogramador.com/foros/Visual-Basic/1724843-Crear-PDF-o-exportar-en-PDF.html
        Dim autor As String = InputBox("Autor")
        If (autor.Length() > 1) Then
            Dim Titulo As String = InputBox("Titulo")
            If (Titulo.Length() > 1) Then
                Dim nombreDocumento As String = InputBox("Nombre del documento")
                Dim ruta = obtenerDirectorio()
                If (ruta.Length() > 1) Then
                    ruta += "/" & nombreDocumento & ".pdf"
                    If (nombreDocumento.Length() > 1) Then
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
                    End If
                End If
            End If
        End If

    End Sub

    'Metodo para guardar en archivo de texto
    Private Sub btn_guardarTXT_Click_1(sender As Object, e As EventArgs) Handles btn_guardarTXT.Click
        Dim obj As New Object
        Dim archivo As New Object
        Dim nombreArchivo As String = InputBox("Nombre del archivo")
        If (nombreArchivo.Length() > 1) Then
            Dim ruta As String = obtenerDirectorio()
            If (ruta.Length() > 1) Then
                ruta += "/" & nombreArchivo & ".txt"
                obj = CreateObject("Scripting.FileSystemObject")
                archivo = obj.CreateTextFile(ruta, True)
                archivo.WriteLine(tb_comando.Text)
                MsgBox("El archivo de texto se ha creado correctamente ")
                archivo.close()
            End If
        End If
    End Sub

    'Metodo para guardar en archivo word
    Private Sub btn_guardarWord_Click(sender As Object, e As EventArgs) Handles btn_guardarWord.Click
        Dim objWord As Object
        Dim objDoc As Object
        Dim objSelection As Object
        Dim nombreDocumento As String = InputBox("Nombre del documento")
        If (nombreDocumento.Length() > 1) Then
            Dim ruta = obtenerDirectorio()
            If (ruta.Length() > 1) Then
                ruta += "/" & nombreDocumento
                objWord = CreateObject("Word.Application")
                objDoc = objWord.Documents.Add

                objWord.Visible = True

                objSelection = objWord.Selection

                objSelection.TypeText(tb_comando.Text)
                objWord.ActiveDocument.SaveAs(ruta)
                MsgBox("El documento word se ha creado correctamente ")
            End If
        End If
    End Sub

    'Funcion para obtener el directorio seleccionado
    Private Function obtenerDirectorio() As String
        Dim folder As New FolderBrowserDialog
        Dim ruta As String = String.Empty

        If folder.ShowDialog = Windows.Forms.DialogResult.OK Then
            ruta = folder.SelectedPath
        End If
        Return ruta
    End Function

End Class
