<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class busqueda
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
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.tb_busqueda = New System.Windows.Forms.TextBox()
        Me.lbl_busqueda = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btn_buscar
        '
        Me.btn_buscar.BackgroundImage = Global.VOZ_PROCESOS.My.Resources.Resources.lupa
        Me.btn_buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_buscar.Location = New System.Drawing.Point(387, 31)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(32, 33)
        Me.btn_buscar.TabIndex = 1
        Me.btn_buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'tb_busqueda
        '
        Me.tb_busqueda.Location = New System.Drawing.Point(12, 31)
        Me.tb_busqueda.Multiline = True
        Me.tb_busqueda.Name = "tb_busqueda"
        Me.tb_busqueda.Size = New System.Drawing.Size(369, 33)
        Me.tb_busqueda.TabIndex = 0
        '
        'lbl_busqueda
        '
        Me.lbl_busqueda.AutoSize = True
        Me.lbl_busqueda.Location = New System.Drawing.Point(12, 12)
        Me.lbl_busqueda.Name = "lbl_busqueda"
        Me.lbl_busqueda.Size = New System.Drawing.Size(39, 13)
        Me.lbl_busqueda.TabIndex = 2
        Me.lbl_busqueda.Text = "Label1"
        '
        'busqueda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(422, 85)
        Me.Controls.Add(Me.lbl_busqueda)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.tb_busqueda)
        Me.Name = "busqueda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_buscar As Button
    Friend WithEvents tb_busqueda As TextBox
    Friend WithEvents lbl_busqueda As Label
End Class
