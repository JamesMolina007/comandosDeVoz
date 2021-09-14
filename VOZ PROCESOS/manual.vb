Imports System.IO
Imports System.Speech.Recognition

Public Class manual
    Private numManual = 0
    Private manualAplicacion() As String
    Private manualWeb() As String
    Private manualDictar() As String
    Private manualArchivo() As String
    Private manualMusica() As String
    Private manualBusqueda() As String
    Private manualExtra() As String
    Private listaActual() As String
    Private comandoDisponible() As String

    Private _diccionario As Boolean
    Public Property diccionario() As Boolean
        Get
            Return _diccionario
        End Get
        Set(ByVal value As Boolean)
            _diccionario = value
        End Set
    End Property

    Private hablar As Boolean
    'WINDOWS
    Private WithEvents listener As New SpeechRecognizer

    'DICCIONARIO
    Private REC As New SpeechRecognitionEngine
    Private PALABRA As String

    Private comando As New comando

    Private Sub manual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        manualAplicacion = {"Para abrir una aplicación diga:" + vbNewLine + """Abrir *Nombre Aplicacion*""" + vbNewLine + "Por ejemplo: Abrir Paint", "Para cerrar una aplicación diga:" + vbNewLine + """Cerrar *Nombre Aplicacion*""" + vbNewLine + "Por ejemplo: Cerrar Paint"}
        manualWeb = {"Para hacer una busqueda web diga: ""Buscar""", "Para buscar un video diga: ""Buscar video""", "Para buscar una página diga: ""Buscar Página"""}
        manualDictar = {"Para dictar hable al micrófono de su dispositivo (utilice audifonos preferiblemente)"}
        manualArchivo = {"Para crear archivos diga: ""Crear Archivo"""}
        manualMusica = {"Para ingresar al reproductor de música diga: ""Reproducir Música""", "Para ingresar al reproductor de música diga: ""Buscar Música"""}
        manualBusqueda = {"Para hacer una busqueda web diga: ""Buscar""", "Para buscar un video diga: ""Buscar video""", "Para buscar una página diga:""Buscar página """}
        manualExtra = {"Si desea escuchar un chiste diga: ""Cuentame un chiste""", "Si desea que le canten happy birthday diga: ""Estoy cumpliendo años""", "Si desea que se le lea algun texto diga: ""leer"""}

        comando.listBox = New ListBox
        comando.listBoxDireccion = New ListBox
        If (diccionario) Then
            REC.SetInputToDefaultAudioDevice()
            REC.LoadGrammar(New Grammar(New GrammarBuilder(New Choices(File.ReadAllLines("../../../gramatica.txt")))))
            REC.RecognizeAsync(RecognizeMode.Multiple)
            AddHandler REC.SpeechRecognized, AddressOf RECONOCE
            AddHandler REC.SpeechRecognitionRejected, AddressOf NORECONOCE
        Else
            listener.LoadGrammar(New DictationGrammar)
        End If
    End Sub

    Private Sub lbl_aplicaciones_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbl_aplicaciones.LinkClicked
        comandoDisponible = {"abrir paint", "cerrar paint"}
        otraCategoria(manualAplicacion)
    End Sub

    Private Sub lbl_web_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbl_web.LinkClicked
        comandoDisponible = {"buscar", "buscar video", "buscar pagina"}
        otraCategoria(manualWeb)
    End Sub

    Private Sub lbl_dictar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbl_dictar.LinkClicked
        comandoDisponible = {"dictado"}
        otraCategoria(manualDictar)
    End Sub

    Private Sub lbl_archivos_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbl_archivos.LinkClicked
        comandoDisponible = {"crear archivo"}
        otraCategoria(manualArchivo)
    End Sub

    Private Sub lbl_musica_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbl_musica.LinkClicked
        comandoDisponible = {"reproducir musica", "buscar musica"}
        otraCategoria(manualMusica)
    End Sub

    Private Sub lbl_busqueda_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbl_busqueda.LinkClicked
        comandoDisponible = {"buscar", "buscar video", "buscar pagina"}
        otraCategoria(manualBusqueda)
    End Sub

    Private Sub lbl_extras_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbl_extras.LinkClicked
        comandoDisponible = {"cuentame un chiste", "estoy cumpliendo años", "leer"}
        otraCategoria(manualExtra)
    End Sub

    Private Sub btn_siguiente_Click(sender As Object, e As EventArgs) Handles btn_siguiente.Click
        numManual += 1
        cambio()
    End Sub

    Private Sub btn_anterior_Click(sender As Object, e As EventArgs) Handles btn_anterior.Click
        numManual -= 1
        cambio()
    End Sub

    Private Sub cambio()
        If (Not (listaActual Is Nothing)) Then
            tb_tutorial.Text = listaActual(numManual)
            botones(listaActual)
        End If
    End Sub

    Private Sub otraCategoria(lista As String())
        If (Not (lista Is listaActual)) Then
            listaActual = lista
            numManual = 0
        End If
        cambio()
    End Sub

    Private Sub botones(lista As String())
        If (numManual = 0) Then
            btn_anterior.Enabled = False
        Else
            btn_anterior.Enabled = True
        End If
        If ((lista.Length - 1) = numManual) Then
            btn_siguiente.Enabled = False
        Else
            btn_siguiente.Enabled = True
        End If
    End Sub

    Private Sub btn_hablar_Click(sender As Object, e As EventArgs) Handles btn_hablar.Click
        lbl_repetir.Text = ""
        If (hablar) Then
            hablar = False
            btn_hablar.Text = "Hablar"
        Else
            hablar = True
            btn_hablar.Text = "Detener"
        End If
    End Sub

    Public Sub RECONOCE(ByVal sender As Object, ByVal e As SpeechRecognizedEventArgs)
        If (hablar) Then
            Dim RESULTADO As RecognitionResult = e.Result
            If (comandoDisponible(numManual) = RESULTADO.Text) Then
                comando.cadenaComando = comandoDisponible(numManual)
                comando.leerComando()
                lbl_repetir.Text = ""
            Else
                lbl_repetir.Text = "Repita Por Favor"
            End If
        End If
    End Sub


    Public Sub NORECONOCE()
        If (hablar) Then
            lbl_repetir.Text = "Repita Por Favor"
        End If
    End Sub

    Private Sub listener_SpeechRecognized(sender As Object, e As SpeechRecognizedEventArgs) Handles listener.SpeechRecognized
        If (hablar) Then
            Dim resultado = e.Result.Text.ToLower
            resultado = eliminar_Tildes(resultado)
            If (comandoDisponible(numManual) = resultado) Then
                comando.cadenaComando = comandoDisponible(numManual)
                comando.leerComando()
                lbl_repetir.Text = ""
            Else
                lbl_repetir.Text = "Repita Por Favor"
            End If
        End If
    End Sub

    Public Function eliminar_Tildes(ByVal accentedStr As String) As String
        Dim tempBytes As Byte()
        tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(accentedStr)
        Return System.Text.Encoding.UTF8.GetString(tempBytes)
    End Function

End Class