Public Class comando
    Public listBox As New ListBox
    Public listBoxDireccion As New ListBox

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
        Dim valores() As String
        valores = Split(_cadenaComando, " ")
        Select Case valores(0)
            Case "abrir"
                abrirAplicacion(valores(1), True)
            Case "cerrar"
                cerrarAplicacion(valores(1))
        End Select
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

    Public Sub abrirAplicacion(aplicacion As String, buscar As Boolean)
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

    Private Sub cerrarAplicacion(aplicacion As String)
        Dim direccionAccesoDirecto = buscarAplicacion(aplicacion)
        If (direccionAccesoDirecto <> "_") Then
            Dim direccionExacta = GetTargetPath(direccionAccesoDirecto)
            Dim rutas = Split(direccionExacta, "\")
            Dim aux = Split(rutas(rutas.Length - 1), ".")
            Dim nombreProceso = aux(0)
            Dim PROCESO As Process() = Process.GetProcessesByName(nombreProceso)
            'Try
            PROCESO(0).Kill()
            'Catch ex As Exception

            'End Try
        End If
    End Sub

    Function GetTargetPath(ByVal FileName As String)
        Dim Obj As Object
        Obj = CreateObject("WScript.Shell")
        Dim Shortcut As Object
        Shortcut = Obj.CreateShortcut(FileName)
        GetTargetPath = Shortcut.TargetPath
    End Function

End Class
