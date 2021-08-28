<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class principal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btn_escuchar = New System.Windows.Forms.Button()
        Me.lbl_hablando = New System.Windows.Forms.Label()
        Me.btn_dictar = New System.Windows.Forms.Button()
        Me.btn_Manual = New System.Windows.Forms.Button()
        Me.lbl_corregir = New System.Windows.Forms.LinkLabel()
        Me.lb_apps = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 29)
        Me.Label1.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(12, 45)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(349, 157)
        Me.TextBox1.TabIndex = 1
        '
        'btn_escuchar
        '
        Me.btn_escuchar.Location = New System.Drawing.Point(146, 289)
        Me.btn_escuchar.Name = "btn_escuchar"
        Me.btn_escuchar.Size = New System.Drawing.Size(75, 23)
        Me.btn_escuchar.TabIndex = 2
        Me.btn_escuchar.Text = "Hablar"
        Me.btn_escuchar.UseVisualStyleBackColor = True
        '
        'lbl_hablando
        '
        Me.lbl_hablando.AutoSize = True
        Me.lbl_hablando.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lbl_hablando.Location = New System.Drawing.Point(15, 228)
        Me.lbl_hablando.Name = "lbl_hablando"
        Me.lbl_hablando.Size = New System.Drawing.Size(0, 16)
        Me.lbl_hablando.TabIndex = 3
        '
        'btn_dictar
        '
        Me.btn_dictar.Location = New System.Drawing.Point(36, 289)
        Me.btn_dictar.Name = "btn_dictar"
        Me.btn_dictar.Size = New System.Drawing.Size(75, 23)
        Me.btn_dictar.TabIndex = 5
        Me.btn_dictar.Text = "Dictar"
        Me.btn_dictar.UseVisualStyleBackColor = True
        '
        'btn_Manual
        '
        Me.btn_Manual.Location = New System.Drawing.Point(260, 289)
        Me.btn_Manual.Name = "btn_Manual"
        Me.btn_Manual.Size = New System.Drawing.Size(75, 23)
        Me.btn_Manual.TabIndex = 6
        Me.btn_Manual.Text = "Manual"
        Me.btn_Manual.UseVisualStyleBackColor = True
        '
        'lbl_corregir
        '
        Me.lbl_corregir.AutoSize = True
        Me.lbl_corregir.LinkColor = System.Drawing.Color.White
        Me.lbl_corregir.Location = New System.Drawing.Point(11, 28)
        Me.lbl_corregir.Name = "lbl_corregir"
        Me.lbl_corregir.Size = New System.Drawing.Size(32, 16)
        Me.lbl_corregir.TabIndex = 7
        Me.lbl_corregir.TabStop = True
        Me.lbl_corregir.Text = "___"
        '
        'lb_apps
        '
        Me.lb_apps.FormattingEnabled = True
        Me.lb_apps.ItemHeight = 16
        Me.lb_apps.Location = New System.Drawing.Point(12, 209)
        Me.lb_apps.Name = "lb_apps"
        Me.lb_apps.Size = New System.Drawing.Size(349, 68)
        Me.lb_apps.TabIndex = 8
        '
        'principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(382, 338)
        Me.Controls.Add(Me.lb_apps)
        Me.Controls.Add(Me.lbl_corregir)
        Me.Controls.Add(Me.btn_Manual)
        Me.Controls.Add(Me.btn_dictar)
        Me.Controls.Add(Me.lbl_hablando)
        Me.Controls.Add(Me.btn_escuchar)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comandos de Voz"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btn_escuchar As Button
    Friend WithEvents lbl_hablando As Label
    Friend WithEvents btn_dictar As Button
    Friend WithEvents btn_Manual As Button
    Friend WithEvents lbl_corregir As LinkLabel
    Friend WithEvents lb_apps As ListBox
End Class
