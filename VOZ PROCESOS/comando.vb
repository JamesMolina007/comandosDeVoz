Imports System.IO

Public Class comando
    Private abrir As Boolean
    Private _listBoxDireccion As ListBox
    Public Property listBoxDireccion() As ListBox
        Get
            Return _listBoxDireccion
        End Get
        Set(ByVal value As ListBox)
            _listBoxDireccion = value
        End Set
    End Property

    Private _listBox As ListBox
    Public Property listBox() As ListBox
        Get
            Return _listBox
        End Get
        Set(ByVal value As ListBox)
            _listBox = value
        End Set
    End Property


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
        Dim valores = Split(_cadenaComando, " ")
        Dim i = 0, j = 0
        For index = 0 To valores.Length - 1
            If (valores(index).Contains("abr") Or valores(index).Contains("bus") Or valores(index).Contains("reprod") Or valores(index).Contains("cre") Or valores(index).Contains("cont") Or valores(index).Contains("cuent") Or valores(index).Contains("ejecut") Or valores(index).Contains("cierr") Or valores(index).Contains("cerra")) Then
                i = index
                Exit For
            End If
        Next
        Dim elementosComando(valores.Length - i) As String
        For index = i To valores.Length - 1
            elementosComando(j) = valores(index)
            j += 1
        Next

        If (elementosComando(0).Contains("abr") Or elementosComando(0).Contains("ejecut")) Then
            abrirAplicacion(valores(1), True)
            abrir = True
        ElseIf (elementosComando(0).Contains("cierr") Or elementosComando(0).Contains("cerra")) Then
            cerrarAplicacion(valores(1), True)
            abrir = False
        ElseIf (elementosComando(0).Contains("bus")) Then
            web("Busqueda", "Contenido a Buscar:")
        ElseIf (elementosComando(0).Contains("reprod")) Then
            web("Música", "Canción a Buscar: ")
        ElseIf (elementosComando(0).Contains("cre")) Then
            If (elementosComando.Contains("archivo")) Then
                crearArchivo()
            End If
        ElseIf (elementosComando(0).Contains("cont") Or elementosComando(0).Contains("cuent")) Then
            If (elementosComando.Contains("chiste")) Then
                chiste()
            End If
        End If

    End Sub

    Private Function buscarAplicacion(aplicacion As String) As String
        listBox.Items.Clear()
        listBoxDireccion.Items.Clear()
        Dim direccionApp As String
        Dim cantidad As Int16 = 0
        Dim direccionAux As String
        Dim direcciones() As String
        Try
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

    Private Sub abrirAplicacion(aplicacion As String, buscar As Boolean)
        Dim direccionAccesoDirecto As String
        If (buscar) Then
            direccionAccesoDirecto = buscarAplicacion(aplicacion)
        Else
            direccionAccesoDirecto = aplicacion
        End If
        If (direccionAccesoDirecto <> "_") Then
            Dim direccionExacta = GetTargetPath(direccionAccesoDirecto)
            Dim PROCESO As New Process
            Try
                PROCESO.Start(direccionExacta)
            Catch ex As Exception
                direccionExacta = direccionExacta.Replace(" (x86)", "")
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

    Private Sub cerrarAplicacion(aplicacion As String, buscar As Boolean)
        Dim direccionAccesoDirecto As String
        If (buscar) Then
            direccionAccesoDirecto = buscarAplicacion(aplicacion)
        Else
            direccionAccesoDirecto = aplicacion
        End If
        If (direccionAccesoDirecto <> "_") Then
            Dim direccionExacta = GetTargetPath(direccionAccesoDirecto)
            Dim rutas = Split(direccionExacta, "\")
            Dim aux = Split(rutas(rutas.Length - 1), ".")
            Dim nombreProceso = aux(0)
            Dim PROCESO As Process() = Process.GetProcessesByName(nombreProceso)
            Try
                PROCESO(0).Kill()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Function GetTargetPath(ByVal FileName As String)
        Dim Obj As Object
        Obj = CreateObject("WScript.Shell")
        Dim Shortcut As Object
        Shortcut = Obj.CreateShortcut(FileName)
        GetTargetPath = Shortcut.TargetPath
    End Function

    Private Sub web(titulo As String, label As String)
        Dim buscar As New busqueda
        buscar.titulo = label
        buscar.Text = titulo
        buscar.Visible = True
    End Sub

    Private Sub crearArchivo()
        Dim openFileDialog1 As New OpenFileDialog
        If (openFileDialog1.ShowDialog() = DialogResult.OK) Then
        End If
    End Sub

    Private Sub chiste()
        Dim archivo = File.OpenText("../../../chistes.txt")
        Dim chisteLeer As String
        Dim i = 0
        Dim lineas = File.ReadAllLines("../../../chistes.txt").Length
        Dim nRandom = New Random()
        Dim numeroAleatorio = nRandom.Next(1, lineas)
        For index = 0 To lineas
            If (index = numeroAleatorio) Then
                Dim SAPI As Object
                SAPI = CreateObject("SAPI.spvoice")
                SAPI.Speak(chisteLeer)
                SAPI.Speak("jajaja")
                Exit For
            Else
                chisteLeer = archivo.ReadLine()
            End If
        Next
    End Sub

End Class
