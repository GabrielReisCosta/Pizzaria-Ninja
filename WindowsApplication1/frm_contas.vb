Public Class frm_contas
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Me.cmb_conta.Items
            .Clear()
            .Add("FUNCIONÁRIO")
            .Add("ADMINISTRADOR")
            .Add("PIZZAIOLO")
        End With
        Me.cmb_conta.SelectedIndex = 0
        txt_senha.UseSystemPasswordChar = True
        txt_rsenha.UseSystemPasswordChar = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_voltar.Click
        Me.Hide()
        frm_login.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_criar.Click
        If txt_nome.Text = "" Or
            txt_cpf.Text = "" Or
            txt_senha.Text = "" Or
            txt_rsenha.Text = "" Or
            txt_email.Text = "" Then
            MsgBox("Preencha todos os campos!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ATENÇÃO")
            Exit Sub
        ElseIf txt_senha.Text <> txt_rsenha.Text Then
            MsgBox("Senhas Diferentes!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ATENÇÃO")
        Else

            Call conecta_banco()
            Try
                sql = "insert into tb_funcionarios values ('" & txt_cpf.Text & "','" & txt_nome.Text & "', '" & txt_email.Text & "', " &
                "'" & txt_senha.Text & "','" & cmb_conta.Text & "' , '" & diretorio & "', 'ativo' )"
                rs = db.Execute(UCase(sql))
                MsgBox("Dados gravados com sucesso!!!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
                Call limpar_cadastro()
            Catch ex As Exception
                MsgBox("Erro de processamento", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub img_foto_func_Click(sender As Object, e As EventArgs) Handles img_foto_func.Click
        Try
            With carregar_fotos
                .Title = "Selecione uma Foto"
                .InitialDirectory = Application.StartupPath & "\Imagens"
                .ShowDialog()
                diretorio = .FileName
                img_foto_func.Load(diretorio)
            End With
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If txt_senha.UseSystemPasswordChar = True Then
            txt_senha.UseSystemPasswordChar = False
            txt_rsenha.UseSystemPasswordChar = False
        Else
            txt_senha.UseSystemPasswordChar = True
            txt_rsenha.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles carregar_fotos.FileOk

    End Sub

    Private Sub cmb_conta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_conta.SelectedIndexChanged

    End Sub

    Private Sub txt_cpf_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles txt_cpf.MaskInputRejected

    End Sub

    Private Sub txt_cpf_LostFocus(sender As Object, e As EventArgs) Handles txt_cpf.LostFocus
    End Sub
End Class