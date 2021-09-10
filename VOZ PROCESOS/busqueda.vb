Public Class busqueda
    Private _titulo As String
    Public Property titulo() As String
        Get
            Return _titulo
        End Get
        Set(ByVal value As String)
            _titulo = value
            lbl_busqueda.Text = value
        End Set
    End Property

    Private Sub busqueda_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        buscar()
    End Sub

    Private Sub buscar()

        Dim tokens = tb_busqueda.Text.Split(" ")
        Dim cadena As String
        If (Me.Text <> "Páginas Web") Then
            If (Me.Text = "Video") Then
                cadena = "https://www.youtube.com/results?search_query="
            ElseIf (Me.Text = "Busqueda") Then
                cadena = "https://www.google.com/search?q="
            End If
            For index = 0 To tokens.Length - 1
                cadena += tokens(index)
                cadena += "+"
            Next
        Else
            cadena = tb_busqueda.Text
        End If
        System.Diagnostics.Process.Start(cadena)
    End Sub

End Class