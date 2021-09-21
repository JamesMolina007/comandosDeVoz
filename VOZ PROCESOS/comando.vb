Imports System.IO

Public Class comando
    Private abrir As Boolean

    'ListBox auxiliar que contiene las direcciones de las aplicaciones
    Private _listBoxDireccion As ListBox
    Public Property listBoxDireccion() As ListBox
        Get
            Return _listBoxDireccion
        End Get
        Set(ByVal value As ListBox)
            _listBoxDireccion = value
        End Set
    End Property

    'ListBox que contiene el nombre de las aplicaciones
    Private _listBox As ListBox
    Public Property listBox() As ListBox
        Get
            Return _listBox
        End Get
        Set(ByVal value As ListBox)
            _listBox = value
        End Set
    End Property

    'Property del comando que se leó
    Private _cadenaComando As String
    Public Property cadenaComando() As String
        Get
            Return _cadenaComando
        End Get
        Set(ByVal value As String)
            _cadenaComando = value
        End Set
    End Property

    Public Sub leerComando()
        _cadenaComando = eliminar_Tildes(cadenaComando.ToLower)
        Dim valores = Split(_cadenaComando, " ")
        Dim i = 0, j = 0
        'Primer filtro que ayuda a eliminar las primeras palabras que no sean necesarias -> porfavor abrir aplicacion -> abrir aplicacion
        For index = 0 To valores.Length - 1
            If (valores(index).Contains("abr") Or valores(index).Contains("ejecut") Or valores(index).Contains("bus") Or valores(index).Contains("reprod") Or valores(index).Contains("cre") Or valores(index).Contains("cont") Or valores(index).Contains("cuent") Or valores(index).Contains("ejecut") Or valores(index).Contains("cierr") Or valores(index).Contains("cerra") Or valores(index).Contains("cumpl") Or valores(index).Contains("lee")) Then
                i = index
                Exit For
            End If
        Next
        'Nuevo arreglo con los elementos necesarios del comando
        Dim elementosComando(valores.Length - i) As String
        For index = i To valores.Length - 1
            elementosComando(j) = valores(index)
            j += 1
        Next

        'Filtra los comandos hablados con expresiones que puedan guiar el tipo de comando hablado
        If (elementosComando(0).Contains("abr") Or elementosComando(0).Contains("ejecut")) Then
            abrirAplicacion(valores(1), True)
            abrir = True

        ElseIf (elementosComando(0).Contains("cierr") Or elementosComando(0).Contains("cerra")) Then
            cerrarAplicacion(valores(1), True)
            abrir = False

        ElseIf (elementosComando(0).Contains("bus")) Then
            If (elementosComando.Contains("video")) Then
                web("Video", "Video a Buscar: ")
            ElseIf (elementosComando.Contains("pagina")) Then
                web("Páginas Web", "URL:")
            Else
                web("Busqueda", "Contenido a Buscar:")
            End If

        ElseIf (elementosComando(0).Contains("reprod") And (elementosComando.Contains("musica"))) Then
            musica()

        ElseIf (elementosComando(0).Contains("cre") And elementosComando.Contains("archivo")) Then
            crearArchivo()

        ElseIf ((elementosComando(0).Contains("cont") Or elementosComando(0).Contains("cuent")) And elementosComando.Contains("chiste")) Then
            chiste()

        ElseIf (elementosComando(0).Contains("cumpl") And (elementosComando.Contains("año") Or elementosComando.Contains("años"))) Then
            cumpleAños()

        ElseIf (elementosComando(0).Contains("lee")) Then
            leerTexto()
        End If

    End Sub

    'Funcion que busca el nombre de una aplicación
    'Escribe en el listbox los nombres de las aplicaciones relacionadas
    'Escribe en el listbox direccion la direccion de esas aplicaciones
    Private Function buscarAplicacion(aplicacion As String) As String
        listBox.Items.Clear()
        listBoxDireccion.Items.Clear()
        Dim direccionApp As String
        Dim cantidad As Int16 = 0
        Dim direccionAux As String
        Dim direcciones() As String
        Try
            'Busqueda del archivo en esta dirección
            For Each archivos As String In My.Computer.FileSystem.GetFiles("C:\ProgramData\Microsoft\Windows\Start Menu\Programs", FileIO.SearchOption.SearchAllSubDirectories, "*.lnk")
                If ((archivos.ToString()).ToLower().Contains(aplicacion.ToLower())) Then
                    cantidad += 1
                    direcciones = Split(archivos, "\")
                    direccionApp = direcciones(direcciones.Length - 1)
                    listBox.Items.Add(direccionApp)
                    listBoxDireccion.Items.Add(archivos)
                    direccionAux = archivos
                End If
            Next
        Catch ex As Exception
            MsgBox("No se realizó la operación por: " & ex.Message)
        End Try
        If (cantidad = 1) Then
            Return direccionAux
        End If
        Return "_"
    End Function

    'Metodo para abrir aplicacion
    Private Sub abrirAplicacion(aplicacion As String, buscar As Boolean)
        Dim direccionAccesoDirecto As String
        If (buscar) Then
            direccionAccesoDirecto = buscarAplicacion(aplicacion) 'Se obtiene el acceso directo por falta de permisos del lectura en program files
        Else
            direccionAccesoDirecto = aplicacion 'Permite al usuario que al dar doble click en la lista acceda directamente a la aplicación sin volver a buscarse
        End If
        If (direccionAccesoDirecto <> "_") Then
            Dim direccionExacta = GetTargetPath(direccionAccesoDirecto) 'Se obtiene la dirección real del acceso directo
            Dim PROCESO As New Process
            Try
                PROCESO.Start(direccionExacta) 'Inicia el proceso buscando en program files
            Catch ex As Exception
                direccionExacta = direccionExacta.Replace(" (x86)", "") 'Si falla lo más seguro es porque está en program files (x86)
                PROCESO.Start(direccionExacta)
            End Try
        End If
    End Sub

    Public Sub accion(aplicacion As String, buscar As Boolean)
        If (abrir) Then
            abrirAplicacion(aplicacion, buscar)
        Else
            cerrarAplicacion(aplicacion, buscar)
        End If
    End Sub

    'Metodo para cerrar aplciación
    Private Sub cerrarAplicacion(aplicacion As String, buscar As Boolean)
        Dim direccionAccesoDirecto As String
        If (buscar) Then
            direccionAccesoDirecto = buscarAplicacion(aplicacion) 'Se obtiene el acceso directo por falta de permisos del lectura en program files
        Else
            direccionAccesoDirecto = aplicacion 'Permite al usuario que al dar doble click en la lista acceda directamente a la aplicación sin volver a buscarse
        End If
        If (direccionAccesoDirecto <> "_") Then
            Dim direccionExacta = GetTargetPath(direccionAccesoDirecto) 'Obtiene la dirección real del acceso directo
            Dim rutas = Split(direccionExacta, "\")
            Dim aux = Split(rutas(rutas.Length - 1), ".")
            Dim nombreProceso = aux(0)
            Dim PROCESO As Process() = Process.GetProcessesByName(nombreProceso) 'Obtiene el proceso
            Try
                PROCESO(0).Kill() 'Mata el proceso
            Catch ex As Exception

            End Try
        End If
    End Sub

    'Me entrega la dirección exacta del acceso directo
    Function GetTargetPath(ByVal FileName As String)
        Dim Obj As Object
        Obj = CreateObject("WScript.Shell")
        Dim Shortcut As Object
        Shortcut = Obj.CreateShortcut(FileName)
        GetTargetPath = Shortcut.TargetPath
    End Function

    'Metodo para buscar en página web
    Private Sub web(titulo As String, label As String)
        Dim buscar As New busqueda
        buscar.titulo = label
        buscar.Text = titulo
        buscar.Visible = True
    End Sub

    'Metodo para llamar al reproductor de música
    Private Sub musica()
        Dim mus As New musica
        mus.Visible = True
    End Sub

    'Metodo para crear, borrar, mostrar archivos
    Private Sub crearArchivo()
        Dim openFileDialog1 As New OpenFileDialog
        If (openFileDialog1.ShowDialog() = DialogResult.OK) Then
        End If
    End Sub

    'Metodo para contar chistes
    Private Sub chiste()
        Dim archivo = File.OpenText("../../../chistes.txt") 'Busca el txt con chistes
        Dim chisteLeer As String
        Dim i = 0
        Dim lineas = File.ReadAllLines("../../../chistes.txt").Length
        Dim nRandom = New Random()
        Dim numeroAleatorio = nRandom.Next(1, lineas) 'Genera un número aleatorio para buscar un chiste al azar
        For index = 0 To lineas
            If (index = numeroAleatorio) Then 'Llegar a la linea del número aleatorio
                Dim SAPI As Object
                SAPI = CreateObject("SAPI.spvoice") 'Se crea un objeto sapi que me leerá el chiste
                SAPI.Speak(chisteLeer)
                SAPI.Speak("jajaja")
                Exit For
            Else
                chisteLeer = archivo.ReadLine() 'Siguiente linea
            End If
        Next
    End Sub

    'Canta la canción de feliz cumpleaños
    Private Sub cumpleAños()
        My.Computer.Audio.Play("../../Resources/happyB.wav", AudioPlayMode.WaitToComplete)
        Dim SAPI = CreateObject("SAPI.spvoice")
        SAPI.Speak("Feliz Cumpleaños amigo, te quiero") 'Mensaje de SAPI
    End Sub

    'Llama al lector de texto
    Private Sub leerTexto()
        Dim lectura As New lectura
        lectura.Visible = True
    End Sub

    'Metodo para eliminar tildes de un texto
    Public Function eliminar_Tildes(ByVal accentedStr As String) As String
        Dim tempBytes As Byte()
        tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(accentedStr)
        Return System.Text.Encoding.UTF8.GetString(tempBytes)
    End Function

End Class