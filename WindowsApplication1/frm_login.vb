Imports System.Data.SqlClient
Public Class frm_login

    Private Sub CadastroClientesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        frm_menu.ShowDialog()
    End Sub



    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_senha.UseSystemPasswordChar = True
        Try
            With Me.cmb_tipo.Items
                .Clear()
                .Add("FUNCIONÁRIO")
                .Add("ADMINISTRADOR")
                .Add("PIZZAIOLO")
            End With
            Me.cmb_tipo.SelectedIndex = 0

        Catch ex As Exception
            Exit Sub
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_entrar.Click

        Dim connection As New SqlConnection("Server= DESKTOP-33BNQC3; Database = ads_va2_si; Integrated Security = true")

        Dim command As New SqlCommand("select * from tb_funcionarios where cpf = @username and senha = @password and tipo = @tipo", connection)

        command.Parameters.Add("@username", SqlDbType.VarChar).Value = txt_cpf.Text
        command.Parameters.Add("@password", SqlDbType.VarChar).Value = txt_senha.Text
        command.Parameters.Add("@tipo", SqlDbType.VarChar).Value = cmb_tipo.Text


        Dim adapter As New SqlDataAdapter(command)

        Dim table As New DataTable()

        adapter.Fill(table)



        If table.Rows.Count() <= 0 Then
            MsgBox("Usuário ou Senha Inválidos !!!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
            Exit Sub
        Else
            If table.Rows.Item(0).ItemArray(6) <> "ATIVO" Then
                MsgBox("Funcionário Bloqueado !!!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "AVISO")
                Exit Sub
            Else
                Call conecta_banco()

                MsgBox("Login realizado com sucesso !!!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")

                If cmb_tipo.SelectedIndex = 0 Then
                    tipo = "FUNCIONARIO"
                ElseIf cmb_tipo.SelectedIndex = 1 Then
                    tipo = "ADMINISTRADOR"
                ElseIf cmb_tipo.SelectedIndex = 2 Then
                    tipo = "PIZZAIOLO"
                End If
            End If
        End If

        Me.Hide()
        frm_menu.ShowDialog()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If txt_senha.UseSystemPasswordChar = True Then
            txt_senha.UseSystemPasswordChar = False
        Else
            txt_senha.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_criar_conta.Click
        Me.Hide()
        frm_contas.ShowDialog()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub txt_cpf_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles txt_cpf.MaskInputRejected

    End Sub

    Private Sub txt_cpf_GotFocus(sender As Object, e As EventArgs) Handles txt_cpf.GotFocus
        txt_cpf.Clear()
        txt_senha.Clear()
    End Sub
End Class
