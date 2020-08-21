<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_contas
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_contas))
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmb_conta = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_rsenha = New System.Windows.Forms.TextBox()
        Me.txt_nome = New System.Windows.Forms.TextBox()
        Me.txt_email = New System.Windows.Forms.TextBox()
        Me.txt_senha = New System.Windows.Forms.TextBox()
        Me.btn_voltar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btn_criar = New System.Windows.Forms.Button()
        Me.img_foto_func = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_cpf = New System.Windows.Forms.MaskedTextBox()
        Me.carregar_fotos = New System.Windows.Forms.OpenFileDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.img_foto_func, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Brown
        Me.CheckBox1.ForeColor = System.Drawing.Color.MistyRose
        Me.CheckBox1.Location = New System.Drawing.Point(306, 238)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(70, 17)
        Me.CheckBox1.TabIndex = 5
        Me.CheckBox1.Text = "Visualizar"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Brown
        Me.Label17.ForeColor = System.Drawing.Color.MistyRose
        Me.Label17.Location = New System.Drawing.Point(123, 258)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(90, 13)
        Me.Label17.TabIndex = 34
        Me.Label17.Text = "TIPO DA CONTA"
        '
        'cmb_conta
        '
        Me.cmb_conta.ForeColor = System.Drawing.Color.Brown
        Me.cmb_conta.FormattingEnabled = True
        Me.cmb_conta.Location = New System.Drawing.Point(126, 274)
        Me.cmb_conta.Name = "cmb_conta"
        Me.cmb_conta.Size = New System.Drawing.Size(175, 21)
        Me.cmb_conta.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Brown
        Me.Label13.ForeColor = System.Drawing.Color.MistyRose
        Me.Label13.Location = New System.Drawing.Point(125, 219)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(111, 13)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "CONFIRMAR SENHA"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Brown
        Me.Label14.ForeColor = System.Drawing.Color.MistyRose
        Me.Label14.Location = New System.Drawing.Point(123, 180)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 13)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "SENHA"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Brown
        Me.Label15.ForeColor = System.Drawing.Color.MistyRose
        Me.Label15.Location = New System.Drawing.Point(124, 141)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 13)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "EMAIL"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Brown
        Me.Label16.ForeColor = System.Drawing.Color.MistyRose
        Me.Label16.Location = New System.Drawing.Point(123, 102)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 13)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "NOME"
        '
        'txt_rsenha
        '
        Me.txt_rsenha.ForeColor = System.Drawing.Color.Brown
        Me.txt_rsenha.Location = New System.Drawing.Point(126, 235)
        Me.txt_rsenha.Name = "txt_rsenha"
        Me.txt_rsenha.Size = New System.Drawing.Size(175, 20)
        Me.txt_rsenha.TabIndex = 4
        '
        'txt_nome
        '
        Me.txt_nome.ForeColor = System.Drawing.Color.Brown
        Me.txt_nome.Location = New System.Drawing.Point(126, 118)
        Me.txt_nome.Name = "txt_nome"
        Me.txt_nome.Size = New System.Drawing.Size(250, 20)
        Me.txt_nome.TabIndex = 1
        '
        'txt_email
        '
        Me.txt_email.ForeColor = System.Drawing.Color.Brown
        Me.txt_email.Location = New System.Drawing.Point(126, 157)
        Me.txt_email.Name = "txt_email"
        Me.txt_email.Size = New System.Drawing.Size(250, 20)
        Me.txt_email.TabIndex = 2
        '
        'txt_senha
        '
        Me.txt_senha.ForeColor = System.Drawing.Color.Brown
        Me.txt_senha.Location = New System.Drawing.Point(126, 196)
        Me.txt_senha.Name = "txt_senha"
        Me.txt_senha.Size = New System.Drawing.Size(175, 20)
        Me.txt_senha.TabIndex = 3
        '
        'btn_voltar
        '
        Me.btn_voltar.BackColor = System.Drawing.Color.Brown
        Me.btn_voltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_voltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_voltar.ForeColor = System.Drawing.Color.MistyRose
        Me.btn_voltar.Image = CType(resources.GetObject("btn_voltar.Image"), System.Drawing.Image)
        Me.btn_voltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_voltar.Location = New System.Drawing.Point(126, 300)
        Me.btn_voltar.Name = "btn_voltar"
        Me.btn_voltar.Size = New System.Drawing.Size(76, 25)
        Me.btn_voltar.TabIndex = 8
        Me.btn_voltar.Text = "&VOLTAR"
        Me.btn_voltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_voltar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.MistyRose
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(123, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 16)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Sistema de Segurança"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.MistyRose
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(151, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Criação de Conta"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.MistyRose
        Me.PictureBox2.Location = New System.Drawing.Point(-3, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(404, 49)
        Me.PictureBox2.TabIndex = 41
        Me.PictureBox2.TabStop = False
        '
        'btn_criar
        '
        Me.btn_criar.BackColor = System.Drawing.Color.MistyRose
        Me.btn_criar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_criar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_criar.ForeColor = System.Drawing.Color.Brown
        Me.btn_criar.Image = CType(resources.GetObject("btn_criar.Image"), System.Drawing.Image)
        Me.btn_criar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_criar.Location = New System.Drawing.Point(233, 301)
        Me.btn_criar.Name = "btn_criar"
        Me.btn_criar.Size = New System.Drawing.Size(68, 25)
        Me.btn_criar.TabIndex = 7
        Me.btn_criar.Text = "&CRIAR"
        Me.btn_criar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_criar.UseVisualStyleBackColor = False
        '
        'img_foto_func
        '
        Me.img_foto_func.BackColor = System.Drawing.Color.RosyBrown
        Me.img_foto_func.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.img_foto_func.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.img_foto_func.Image = CType(resources.GetObject("img_foto_func.Image"), System.Drawing.Image)
        Me.img_foto_func.Location = New System.Drawing.Point(17, 77)
        Me.img_foto_func.Name = "img_foto_func"
        Me.img_foto_func.Size = New System.Drawing.Size(101, 100)
        Me.img_foto_func.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.img_foto_func.TabIndex = 43
        Me.img_foto_func.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Brown
        Me.Label2.ForeColor = System.Drawing.Color.MistyRose
        Me.Label2.Location = New System.Drawing.Point(125, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "CPF"
        '
        'txt_cpf
        '
        Me.txt_cpf.ForeColor = System.Drawing.Color.Brown
        Me.txt_cpf.Location = New System.Drawing.Point(126, 77)
        Me.txt_cpf.Mask = "999,999,999-99"
        Me.txt_cpf.Name = "txt_cpf"
        Me.txt_cpf.Size = New System.Drawing.Size(85, 20)
        Me.txt_cpf.TabIndex = 0
        '
        'carregar_fotos
        '
        Me.carregar_fotos.FileName = "carregar_fotos"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(12, 55)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(370, 284)
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(23, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Dados"
        '
        'frm_contas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Brown
        Me.ClientSize = New System.Drawing.Size(395, 345)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_cpf)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.img_foto_func)
        Me.Controls.Add(Me.btn_criar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cmb_conta)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.btn_voltar)
        Me.Controls.Add(Me.txt_rsenha)
        Me.Controls.Add(Me.txt_nome)
        Me.Controls.Add(Me.txt_email)
        Me.Controls.Add(Me.txt_senha)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_contas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Criar conta - Pizzaria Ninja"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.img_foto_func, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label17 As Label
    Friend WithEvents cmb_conta As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents btn_voltar As Button
    Friend WithEvents txt_rsenha As TextBox
    Friend WithEvents txt_nome As TextBox
    Friend WithEvents txt_email As TextBox
    Friend WithEvents txt_senha As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btn_criar As Button
    Friend WithEvents img_foto_func As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_cpf As MaskedTextBox
    Friend WithEvents carregar_fotos As OpenFileDialog
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
End Class
