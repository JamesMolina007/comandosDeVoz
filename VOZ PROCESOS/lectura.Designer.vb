<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class lectura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(lectura))
        Me.tb_lectura = New System.Windows.Forms.TextBox()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.btn_leer = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tb_lectura
        '
        Me.tb_lectura.Location = New System.Drawing.Point(13, 13)
        Me.tb_lectura.Multiline = True
        Me.tb_lectura.Name = "tb_lectura"
        Me.tb_lectura.Size = New System.Drawing.Size(439, 320)
        Me.tb_lectura.TabIndex = 0
        '
        'btn_buscar
        '
        Me.btn_buscar.BackgroundImage = CType(resources.GetObject("btn_buscar.BackgroundImage"), System.Drawing.Image)
        Me.btn_buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_buscar.Location = New System.Drawing.Point(13, 340)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(46, 41)
        Me.btn_buscar.TabIndex = 1
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'btn_leer
        '
        Me.btn_leer.BackgroundImage = CType(resources.GetObject("btn_leer.BackgroundImage"), System.Drawing.Image)
        Me.btn_leer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_leer.Location = New System.Drawing.Point(65, 339)
        Me.btn_leer.Name = "btn_leer"
        Me.btn_leer.Size = New System.Drawing.Size(61, 41)
        Me.btn_leer.TabIndex = 2
        Me.btn_leer.UseVisualStyleBackColor = True
        '
        'lectura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 393)
        Me.Controls.Add(Me.btn_leer)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.tb_lectura)
        Me.Name = "lectura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Leer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tb_lectura As TextBox
    Friend WithEvents btn_buscar As Button
    Friend WithEvents btn_leer As Button
End Class
