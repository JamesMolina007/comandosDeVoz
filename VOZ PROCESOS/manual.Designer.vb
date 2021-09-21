<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class manual
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(manual))
        Me.lbl_aplicaciones = New System.Windows.Forms.LinkLabel()
        Me.lbl_web = New System.Windows.Forms.LinkLabel()
        Me.lbl_dictar = New System.Windows.Forms.LinkLabel()
        Me.lbl_archivos = New System.Windows.Forms.LinkLabel()
        Me.lbl_musica = New System.Windows.Forms.LinkLabel()
        Me.lbl_busqueda = New System.Windows.Forms.LinkLabel()
        Me.lbl_extras = New System.Windows.Forms.LinkLabel()
        Me.tb_tutorial = New System.Windows.Forms.TextBox()
        Me.btn_hablar = New System.Windows.Forms.Button()
        Me.btn_siguiente = New System.Windows.Forms.Button()
        Me.btn_anterior = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbl_repetir = New System.Windows.Forms.Label()
        Me.lbl_hablado = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_aplicaciones
        '
        Me.lbl_aplicaciones.AutoSize = True
        Me.lbl_aplicaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_aplicaciones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbl_aplicaciones.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lbl_aplicaciones.LinkColor = System.Drawing.Color.Black
        Me.lbl_aplicaciones.Location = New System.Drawing.Point(6, 19)
        Me.lbl_aplicaciones.Name = "lbl_aplicaciones"
        Me.lbl_aplicaciones.Size = New System.Drawing.Size(110, 20)
        Me.lbl_aplicaciones.TabIndex = 0
        Me.lbl_aplicaciones.TabStop = True
        Me.lbl_aplicaciones.Text = "Aplicaciones"
        '
        'lbl_web
        '
        Me.lbl_web.AutoSize = True
        Me.lbl_web.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_web.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbl_web.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lbl_web.LinkColor = System.Drawing.Color.Black
        Me.lbl_web.Location = New System.Drawing.Point(6, 49)
        Me.lbl_web.Name = "lbl_web"
        Me.lbl_web.Size = New System.Drawing.Size(45, 20)
        Me.lbl_web.TabIndex = 1
        Me.lbl_web.TabStop = True
        Me.lbl_web.Text = "Web"
        '
        'lbl_dictar
        '
        Me.lbl_dictar.AutoSize = True
        Me.lbl_dictar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_dictar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbl_dictar.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lbl_dictar.LinkColor = System.Drawing.Color.Black
        Me.lbl_dictar.Location = New System.Drawing.Point(6, 80)
        Me.lbl_dictar.Name = "lbl_dictar"
        Me.lbl_dictar.Size = New System.Drawing.Size(57, 20)
        Me.lbl_dictar.TabIndex = 2
        Me.lbl_dictar.TabStop = True
        Me.lbl_dictar.Text = "Dictar"
        '
        'lbl_archivos
        '
        Me.lbl_archivos.AutoSize = True
        Me.lbl_archivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_archivos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbl_archivos.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lbl_archivos.LinkColor = System.Drawing.Color.Black
        Me.lbl_archivos.Location = New System.Drawing.Point(6, 109)
        Me.lbl_archivos.Name = "lbl_archivos"
        Me.lbl_archivos.Size = New System.Drawing.Size(126, 20)
        Me.lbl_archivos.TabIndex = 3
        Me.lbl_archivos.TabStop = True
        Me.lbl_archivos.Text = "Crear Archivos"
        '
        'lbl_musica
        '
        Me.lbl_musica.AutoSize = True
        Me.lbl_musica.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_musica.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbl_musica.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lbl_musica.LinkColor = System.Drawing.Color.Black
        Me.lbl_musica.Location = New System.Drawing.Point(6, 139)
        Me.lbl_musica.Name = "lbl_musica"
        Me.lbl_musica.Size = New System.Drawing.Size(65, 20)
        Me.lbl_musica.TabIndex = 4
        Me.lbl_musica.TabStop = True
        Me.lbl_musica.Text = "Música"
        '
        'lbl_busqueda
        '
        Me.lbl_busqueda.AutoSize = True
        Me.lbl_busqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_busqueda.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbl_busqueda.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lbl_busqueda.LinkColor = System.Drawing.Color.Black
        Me.lbl_busqueda.Location = New System.Drawing.Point(6, 167)
        Me.lbl_busqueda.Name = "lbl_busqueda"
        Me.lbl_busqueda.Size = New System.Drawing.Size(90, 20)
        Me.lbl_busqueda.TabIndex = 5
        Me.lbl_busqueda.TabStop = True
        Me.lbl_busqueda.Text = "Búsqueda"
        '
        'lbl_extras
        '
        Me.lbl_extras.AutoSize = True
        Me.lbl_extras.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_extras.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbl_extras.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lbl_extras.LinkColor = System.Drawing.Color.Black
        Me.lbl_extras.Location = New System.Drawing.Point(6, 197)
        Me.lbl_extras.Name = "lbl_extras"
        Me.lbl_extras.Size = New System.Drawing.Size(60, 20)
        Me.lbl_extras.TabIndex = 6
        Me.lbl_extras.TabStop = True
        Me.lbl_extras.Text = "Extras"
        '
        'tb_tutorial
        '
        Me.tb_tutorial.Enabled = False
        Me.tb_tutorial.Location = New System.Drawing.Point(171, 31)
        Me.tb_tutorial.Multiline = True
        Me.tb_tutorial.Name = "tb_tutorial"
        Me.tb_tutorial.Size = New System.Drawing.Size(256, 184)
        Me.tb_tutorial.TabIndex = 7
        '
        'btn_hablar
        '
        Me.btn_hablar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_hablar.Image = CType(resources.GetObject("btn_hablar.Image"), System.Drawing.Image)
        Me.btn_hablar.Location = New System.Drawing.Point(261, 221)
        Me.btn_hablar.Name = "btn_hablar"
        Me.btn_hablar.Size = New System.Drawing.Size(75, 79)
        Me.btn_hablar.TabIndex = 8
        Me.btn_hablar.Text = "Hablar"
        Me.btn_hablar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_hablar.UseVisualStyleBackColor = True
        '
        'btn_siguiente
        '
        Me.btn_siguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_siguiente.Image = CType(resources.GetObject("btn_siguiente.Image"), System.Drawing.Image)
        Me.btn_siguiente.Location = New System.Drawing.Point(352, 235)
        Me.btn_siguiente.Name = "btn_siguiente"
        Me.btn_siguiente.Size = New System.Drawing.Size(75, 50)
        Me.btn_siguiente.TabIndex = 9
        Me.btn_siguiente.Text = "Siguiente"
        Me.btn_siguiente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_siguiente.UseVisualStyleBackColor = True
        '
        'btn_anterior
        '
        Me.btn_anterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_anterior.Image = CType(resources.GetObject("btn_anterior.Image"), System.Drawing.Image)
        Me.btn_anterior.Location = New System.Drawing.Point(171, 235)
        Me.btn_anterior.Name = "btn_anterior"
        Me.btn_anterior.Size = New System.Drawing.Size(75, 50)
        Me.btn_anterior.TabIndex = 10
        Me.btn_anterior.Text = "Anterior"
        Me.btn_anterior.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_anterior.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GroupBox1.Controls.Add(Me.lbl_web)
        Me.GroupBox1.Controls.Add(Me.lbl_aplicaciones)
        Me.GroupBox1.Controls.Add(Me.lbl_dictar)
        Me.GroupBox1.Controls.Add(Me.lbl_archivos)
        Me.GroupBox1.Controls.Add(Me.lbl_musica)
        Me.GroupBox1.Controls.Add(Me.lbl_extras)
        Me.GroupBox1.Controls.Add(Me.lbl_busqueda)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(153, 288)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'lbl_repetir
        '
        Me.lbl_repetir.AutoSize = True
        Me.lbl_repetir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lbl_repetir.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_repetir.ForeColor = System.Drawing.Color.Red
        Me.lbl_repetir.Location = New System.Drawing.Point(171, 195)
        Me.lbl_repetir.Name = "lbl_repetir"
        Me.lbl_repetir.Size = New System.Drawing.Size(0, 18)
        Me.lbl_repetir.TabIndex = 12
        '
        'lbl_hablado
        '
        Me.lbl_hablado.AutoSize = True
        Me.lbl_hablado.Location = New System.Drawing.Point(171, 12)
        Me.lbl_hablado.Name = "lbl_hablado"
        Me.lbl_hablado.Size = New System.Drawing.Size(25, 13)
        Me.lbl_hablado.TabIndex = 13
        Me.lbl_hablado.Text = "___"
        '
        'manual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(439, 312)
        Me.Controls.Add(Me.lbl_hablado)
        Me.Controls.Add(Me.lbl_repetir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_anterior)
        Me.Controls.Add(Me.btn_siguiente)
        Me.Controls.Add(Me.btn_hablar)
        Me.Controls.Add(Me.tb_tutorial)
        Me.Name = "manual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manual de Usuario"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_aplicaciones As LinkLabel
    Friend WithEvents lbl_web As LinkLabel
    Friend WithEvents lbl_dictar As LinkLabel
    Friend WithEvents lbl_archivos As LinkLabel
    Friend WithEvents lbl_musica As LinkLabel
    Friend WithEvents lbl_busqueda As LinkLabel
    Friend WithEvents lbl_extras As LinkLabel
    Friend WithEvents tb_tutorial As TextBox
    Friend WithEvents btn_hablar As Button
    Friend WithEvents btn_siguiente As Button
    Friend WithEvents btn_anterior As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lbl_repetir As Label
    Friend WithEvents lbl_hablado As Label
End Class
