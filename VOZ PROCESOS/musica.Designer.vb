<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class musica
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(musica))
        Me.btn_Anterior = New System.Windows.Forms.Button()
        Me.btn_reproducir = New System.Windows.Forms.Button()
        Me.btn_Siguiente = New System.Windows.Forms.Button()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.lb_cola = New System.Windows.Forms.ListBox()
        Me.btn_agregarCola = New System.Windows.Forms.Button()
        Me.btn_limpiarCola = New System.Windows.Forms.Button()
        Me.btn_quitarDeCola = New System.Windows.Forms.Button()
        Me.lb_direcciones = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_anterior = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_siguiente = New System.Windows.Forms.Label()
        Me.Reproduciendo = New System.Windows.Forms.Label()
        Me.lbl_reproduciendo = New System.Windows.Forms.Label()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Anterior
        '
        Me.btn_Anterior.BackgroundImage = CType(resources.GetObject("btn_Anterior.BackgroundImage"), System.Drawing.Image)
        Me.btn_Anterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Anterior.Location = New System.Drawing.Point(206, -1)
        Me.btn_Anterior.Name = "btn_Anterior"
        Me.btn_Anterior.Size = New System.Drawing.Size(75, 52)
        Me.btn_Anterior.TabIndex = 0
        Me.btn_Anterior.UseVisualStyleBackColor = True
        '
        'btn_reproducir
        '
        Me.btn_reproducir.BackgroundImage = CType(resources.GetObject("btn_reproducir.BackgroundImage"), System.Drawing.Image)
        Me.btn_reproducir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_reproducir.Location = New System.Drawing.Point(280, -1)
        Me.btn_reproducir.Name = "btn_reproducir"
        Me.btn_reproducir.Size = New System.Drawing.Size(56, 52)
        Me.btn_reproducir.TabIndex = 1
        Me.btn_reproducir.UseVisualStyleBackColor = True
        '
        'btn_Siguiente
        '
        Me.btn_Siguiente.BackgroundImage = CType(resources.GetObject("btn_Siguiente.BackgroundImage"), System.Drawing.Image)
        Me.btn_Siguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Siguiente.Location = New System.Drawing.Point(335, -1)
        Me.btn_Siguiente.Name = "btn_Siguiente"
        Me.btn_Siguiente.Size = New System.Drawing.Size(75, 52)
        Me.btn_Siguiente.TabIndex = 2
        Me.btn_Siguiente.UseVisualStyleBackColor = True
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(0, 268)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(409, 49)
        Me.AxWindowsMediaPlayer1.TabIndex = 8
        '
        'lb_cola
        '
        Me.lb_cola.FormattingEnabled = True
        Me.lb_cola.Location = New System.Drawing.Point(0, 48)
        Me.lb_cola.Name = "lb_cola"
        Me.lb_cola.Size = New System.Drawing.Size(410, 134)
        Me.lb_cola.TabIndex = 9
        '
        'btn_agregarCola
        '
        Me.btn_agregarCola.BackgroundImage = CType(resources.GetObject("btn_agregarCola.BackgroundImage"), System.Drawing.Image)
        Me.btn_agregarCola.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_agregarCola.Location = New System.Drawing.Point(1, -1)
        Me.btn_agregarCola.Name = "btn_agregarCola"
        Me.btn_agregarCola.Size = New System.Drawing.Size(63, 52)
        Me.btn_agregarCola.TabIndex = 10
        Me.btn_agregarCola.UseVisualStyleBackColor = True
        '
        'btn_limpiarCola
        '
        Me.btn_limpiarCola.BackgroundImage = CType(resources.GetObject("btn_limpiarCola.BackgroundImage"), System.Drawing.Image)
        Me.btn_limpiarCola.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_limpiarCola.Location = New System.Drawing.Point(62, -1)
        Me.btn_limpiarCola.Name = "btn_limpiarCola"
        Me.btn_limpiarCola.Size = New System.Drawing.Size(76, 52)
        Me.btn_limpiarCola.TabIndex = 11
        Me.btn_limpiarCola.UseVisualStyleBackColor = True
        '
        'btn_quitarDeCola
        '
        Me.btn_quitarDeCola.BackgroundImage = CType(resources.GetObject("btn_quitarDeCola.BackgroundImage"), System.Drawing.Image)
        Me.btn_quitarDeCola.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_quitarDeCola.Location = New System.Drawing.Point(136, -1)
        Me.btn_quitarDeCola.Name = "btn_quitarDeCola"
        Me.btn_quitarDeCola.Size = New System.Drawing.Size(72, 52)
        Me.btn_quitarDeCola.TabIndex = 12
        Me.btn_quitarDeCola.UseVisualStyleBackColor = True
        '
        'lb_direcciones
        '
        Me.lb_direcciones.FormattingEnabled = True
        Me.lb_direcciones.Location = New System.Drawing.Point(0, 48)
        Me.lb_direcciones.Name = "lb_direcciones"
        Me.lb_direcciones.Size = New System.Drawing.Size(410, 4)
        Me.lb_direcciones.TabIndex = 13
        Me.lb_direcciones.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 193)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Anterior:"
        '
        'lbl_anterior
        '
        Me.lbl_anterior.AutoSize = True
        Me.lbl_anterior.Location = New System.Drawing.Point(64, 193)
        Me.lbl_anterior.Name = "lbl_anterior"
        Me.lbl_anterior.Size = New System.Drawing.Size(25, 13)
        Me.lbl_anterior.TabIndex = 15
        Me.lbl_anterior.Text = "___"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 217)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Siguiente:"
        '
        'lbl_siguiente
        '
        Me.lbl_siguiente.AutoSize = True
        Me.lbl_siguiente.Location = New System.Drawing.Point(64, 217)
        Me.lbl_siguiente.Name = "lbl_siguiente"
        Me.lbl_siguiente.Size = New System.Drawing.Size(25, 13)
        Me.lbl_siguiente.TabIndex = 17
        Me.lbl_siguiente.Text = "___"
        '
        'Reproduciendo
        '
        Me.Reproduciendo.AutoSize = True
        Me.Reproduciendo.Location = New System.Drawing.Point(12, 241)
        Me.Reproduciendo.Name = "Reproduciendo"
        Me.Reproduciendo.Size = New System.Drawing.Size(83, 13)
        Me.Reproduciendo.TabIndex = 18
        Me.Reproduciendo.Text = "Reproduciendo:"
        '
        'lbl_reproduciendo
        '
        Me.lbl_reproduciendo.AutoSize = True
        Me.lbl_reproduciendo.Location = New System.Drawing.Point(102, 241)
        Me.lbl_reproduciendo.Name = "lbl_reproduciendo"
        Me.lbl_reproduciendo.Size = New System.Drawing.Size(25, 13)
        Me.lbl_reproduciendo.TabIndex = 19
        Me.lbl_reproduciendo.Text = "___"
        '
        'musica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 317)
        Me.Controls.Add(Me.lbl_reproduciendo)
        Me.Controls.Add(Me.Reproduciendo)
        Me.Controls.Add(Me.lbl_siguiente)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbl_anterior)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lb_direcciones)
        Me.Controls.Add(Me.btn_quitarDeCola)
        Me.Controls.Add(Me.btn_limpiarCola)
        Me.Controls.Add(Me.btn_agregarCola)
        Me.Controls.Add(Me.lb_cola)
        Me.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.Controls.Add(Me.btn_Siguiente)
        Me.Controls.Add(Me.btn_reproducir)
        Me.Controls.Add(Me.btn_Anterior)
        Me.Name = "musica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reproductor de Música"
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_Anterior As Button
    Friend WithEvents btn_reproducir As Button
    Friend WithEvents btn_Siguiente As Button
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents lb_cola As ListBox
    Friend WithEvents btn_agregarCola As Button
    Friend WithEvents btn_limpiarCola As Button
    Friend WithEvents btn_quitarDeCola As Button
    Friend WithEvents lb_direcciones As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lbl_anterior As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lbl_siguiente As Label
    Friend WithEvents Reproduciendo As Label
    Friend WithEvents lbl_reproduciendo As Label
End Class
