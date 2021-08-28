<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class diccionario
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
        Me.cb_categoria = New System.Windows.Forms.ComboBox()
        Me.tb_palabra = New System.Windows.Forms.TextBox()
        Me.btn_agregar = New System.Windows.Forms.Button()
        Me.lbl_palabra = New System.Windows.Forms.Label()
        Me.lbl_categoria = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cb_categoria
        '
        Me.cb_categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_categoria.FormattingEnabled = True
        Me.cb_categoria.Items.AddRange(New Object() {"Aplicaciones", "Palabra"})
        Me.cb_categoria.Location = New System.Drawing.Point(12, 78)
        Me.cb_categoria.Name = "cb_categoria"
        Me.cb_categoria.Size = New System.Drawing.Size(260, 21)
        Me.cb_categoria.TabIndex = 0
        '
        'tb_palabra
        '
        Me.tb_palabra.Enabled = False
        Me.tb_palabra.Location = New System.Drawing.Point(12, 26)
        Me.tb_palabra.Name = "tb_palabra"
        Me.tb_palabra.Size = New System.Drawing.Size(260, 20)
        Me.tb_palabra.TabIndex = 1
        '
        'btn_agregar
        '
        Me.btn_agregar.Location = New System.Drawing.Point(107, 105)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(75, 23)
        Me.btn_agregar.TabIndex = 2
        Me.btn_agregar.Text = "Agregar"
        Me.btn_agregar.UseVisualStyleBackColor = True
        '
        'lbl_palabra
        '
        Me.lbl_palabra.AutoSize = True
        Me.lbl_palabra.Location = New System.Drawing.Point(13, 8)
        Me.lbl_palabra.Name = "lbl_palabra"
        Me.lbl_palabra.Size = New System.Drawing.Size(19, 13)
        Me.lbl_palabra.TabIndex = 3
        Me.lbl_palabra.Text = "__"
        '
        'lbl_categoria
        '
        Me.lbl_categoria.AutoSize = True
        Me.lbl_categoria.Location = New System.Drawing.Point(13, 62)
        Me.lbl_categoria.Name = "lbl_categoria"
        Me.lbl_categoria.Size = New System.Drawing.Size(52, 13)
        Me.lbl_categoria.TabIndex = 4
        Me.lbl_categoria.Text = "Categoria"
        '
        'diccionario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 139)
        Me.Controls.Add(Me.lbl_categoria)
        Me.Controls.Add(Me.lbl_palabra)
        Me.Controls.Add(Me.btn_agregar)
        Me.Controls.Add(Me.tb_palabra)
        Me.Controls.Add(Me.cb_categoria)
        Me.Name = "diccionario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar al Diccionario"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cb_categoria As ComboBox
    Friend WithEvents tb_palabra As TextBox
    Friend WithEvents btn_agregar As Button
    Friend WithEvents lbl_palabra As Label
    Friend WithEvents lbl_categoria As Label
End Class
