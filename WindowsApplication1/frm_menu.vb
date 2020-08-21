Imports MySql.Data.MySqlClient
Public Class frm_menu

    Private Sub img_foto_Click_1(sender As Object, e As EventArgs) Handles img_foto.Click
        Try
            With carregar_fotos
                .Title = "Selecione uma Foto"
                .InitialDirectory = Application.StartupPath & "\Imagens"
                .ShowDialog()
                diretorio = .FileName
                img_foto.Load(diretorio)
            End With
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub frm_cadastro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Call carregar_dados_grid()
        Call carregar_dados_grid_func()
        Call carregar_dados_pizzaiolo()
        Call carrega_tipo()
        Call carregar_cardapio()
        Call Pformatadgv_2()
        Call report()
        contador = 1

        If tipo = "FUNCIONARIO" Then
            form2.TabPages.Remove(TabPage2)
            form2.TabPages.Remove(TabPage5)
            form2.TabPages.Remove(TabPage7)
        ElseIf tipo = "PIZZAIOLO" Then
            form2.TabPages.Remove(TabPage1)
            form2.TabPages.Remove(TabPage2)
            form2.TabPages.Remove(TabPage3)
            form2.TabPages.Remove(TabPage4)
            form2.TabPages.Remove(TabPage5)
            form2.TabPages.Remove(TabPage6)
        ElseIf tipo = "ADMINISTRADOR" Then

        End If
    End Sub


    Private Sub btn_salvar_Click(sender As Object, e As EventArgs)
        Try
            If txt_cpf.Text = "" Or
                txt_nome.Text = "" Or
                txt_data_nasc.Text = "" Or
                txt_cep.Text = "" Or
                txt_endereco.Text = "" Or
                txt_comp.Text = "" Or
                txt_bairro.Text = "" Or
                txt_cidade.Text = "" Or
                txt_uf.Text = "" Or
                txt_foneres.Text = "" Or
                txt_celular.Text = "" Or
                txt_email.Text = "" Then
                MsgBox("Preencha todos os campos!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ATENÇÃO")
                Exit Sub
            Else
                sql = "insert into tb_cadastro values ('" & txt_cpf.Text & "', '" & txt_nome.Text & "', " &
                    "'" & txt_data_nasc.Text & "', '" & txt_cep.Text & "', '" & txt_endereco.Text & "', " &
                    "'" & txt_comp.Text & "', '" & txt_bairro.Text & "', '" & txt_cidade.Text & "', '" & txt_uf.Text & "', " &
                    "'" & txt_foneres.Text & "', '" & txt_celular.Text & "', '" & txt_email.Text & "', '" & diretorio & "')"
                rs = db.Execute(UCase(sql))
                MsgBox("Dados gravados com sucesso!!!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
                Call carregar_dados_grid()
                Call limpar_cadastro()
            End If
        Catch ex As Exception
            MsgBox("Erro de processamento", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
            Exit Sub
        End Try
    End Sub

    Private Sub txt_cpf_GotFocus(sender As Object, e As EventArgs) Handles txt_cpf.GotFocus
        Call limpar_cadastro()
    End Sub

    Private Sub txt_cpf_LostFocus(sender As Object, e As EventArgs) Handles txt_cpf.LostFocus
        Try
            sql = "select * from tb_cadastro where cpf='" & txt_cpf.Text & "'"
            rs = db.Execute(sql)
            If rs.EOF = False Then
                txt_nome.Text = rs.Fields(2).Value
                txt_data_nasc.Text = rs.Fields(1).Value
                txt_cep.Text = rs.Fields(3).Value
                txt_endereco.Text = rs.Fields(4).Value
                txt_comp.Text = rs.Fields(5).Value
                txt_bairro.Text = rs.Fields(6).Value
                txt_cidade.Text = rs.Fields(7).Value
                txt_uf.Text = rs.Fields(8).Value
                txt_foneres.Text = rs.Fields(9).Value
                txt_celular.Text = rs.Fields(10).Value
                txt_email.Text = rs.Fields(11).Value
                img_foto.Load(rs.Fields(13).Value)
            Else
                txt_nome.Focus()
            End If
        Catch ex As Exception
            MsgBox("Erro de processamento", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
            Exit Sub
        End Try

    End Sub

    Private Sub txt_busca_TextChanged(sender As Object, e As EventArgs)
        Try
            sql = "select * from tb_cadastro where " & cmb_tipo.Text & " like '" & txt_busca.Text & "%'"
            rs = db.Execute(sql)
            With dgv_func
                .Rows.Clear()
                cont = 1
                Do While rs.EOF = False
                    .Rows.Add(cont, rs.Fields(0).Value, rs.Fields(1).Value, Nothing, Nothing, Nothing)
                    rs.MoveNext()
                    cont = cont + 1
                Loop
            End With
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub dgv_dados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        Try
            With dgv_func
                If .CurrentRow.Cells(3).Selected = True Then
                    aux_cpf = .CurrentRow.Cells(1).Value.ToString
                    sql = "select * from tb_cadastro where cpf='" & aux_cpf & "'"
                    rs = db.Execute(sql)
                    If rs.EOF = False Then
                        form2.SelectTab(0)
                        txt_cpf.Text = rs.Fields(0).Value
                        txt_nome.Text = rs.Fields(1).Value
                        txt_data_nasc.Text = rs.Fields(2).Value
                        txt_cep.Text = rs.Fields(3).Value
                        txt_endereco.Text = rs.Fields(4).Value
                        txt_comp.Text = rs.Fields(5).Value
                        txt_bairro.Text = rs.Fields(6).Value
                        txt_cidade.Text = rs.Fields(7).Value
                        txt_uf.Text = rs.Fields(8).Value
                        txt_foneres.Text = rs.Fields(9).Value
                        txt_celular.Text = rs.Fields(10).Value
                        txt_email.Text = rs.Fields(11).Value
                        img_foto.Load(rs.Fields(12).Value)
                    End If
                ElseIf .CurrentRow.Cells(4).Selected = True Then
                    aux_cpf = .CurrentRow.Cells(1).Value.ToString
                    sql = "select * from tb_cadastro where cpf='" & aux_cpf & "'"
                    rs = db.Execute(sql)
                    If rs.EOF = False Then
                        form2.SelectTab(0)
                        txt_cpf.Text = rs.Fields(0).Value
                        txt_nome.Text = rs.Fields(1).Value
                        txt_data_nasc.Text = rs.Fields(2).Value
                        txt_cep.Text = rs.Fields(3).Value
                        txt_endereco.Text = rs.Fields(4).Value
                        txt_comp.Text = rs.Fields(5).Value
                        txt_bairro.Text = rs.Fields(6).Value
                        txt_cidade.Text = rs.Fields(7).Value
                        txt_uf.Text = rs.Fields(8).Value
                        txt_foneres.Text = rs.Fields(9).Value
                        txt_celular.Text = rs.Fields(10).Value
                        txt_email.Text = rs.Fields(11).Value
                        img_foto.Load(rs.Fields(12).Value)
                        form2.Enabled = False
                    End If

                ElseIf .CurrentRow.Cells(5).Selected = True Then
                    aux_cpf = .CurrentRow.Cells(1).Value.ToString
                    resp = MsgBox("Deseja realmente excluir o registro" + vbNewLine + "CPF:" & aux_cpf & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ATENÇÂO")
                    If resp = MsgBoxResult.Yes Then
                        sql = "delete * from tb_cadastro where cpf='" & aux_cpf & "'"
                        rs = db.Execute(sql)
                        Call carregar_dados_grid()
                    End If

                Else
                    Exit Sub
                End If
            End With
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub txt_busca_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub ToolStrip2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmb_tipo_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub ToolStripTextBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt_cpf_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles txt_cpf.MaskInputRejected

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If txt_cpf.Text = "" Or
                txt_nome.Text = "" Or
                txt_data_nasc.Text = "" Or
                txt_cep.Text = "" Or
                txt_endereco.Text = "" Or
                txt_comp.Text = "" Or
                txt_bairro.Text = "" Or
                txt_cidade.Text = "" Or
                txt_uf.Text = "" Or
                txt_foneres.Text = "" Or
                txt_celular.Text = "" Or
                txt_email.Text = "" Then
            MsgBox("Preencha todos os campos!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ATENÇÃO")
            Exit Sub
        End If
        Try
            sql = "select * from tb_cadastro where cpf='" & txt_cpf.Text & "'"
            rs = db.Execute(sql)
            If rs.EOF = False Then
                sql = "update tb_cadastro set data_nasc='" & txt_data_nasc.Text & "', " &
                                           "nome='" & txt_nome.Text & "', " &
                                           "cep='" & txt_cep.Text & "', " &
                                           "endereco='" & txt_endereco.Text & "', " &
                                           "comp='" & txt_comp.Text & "', " &
                                           "bairro='" & txt_bairro.Text & "', " &
                                           "cidade='" & txt_cidade.Text & "', " &
                                           "uf='" & txt_uf.Text & "', " &
                                           "fone_res='" & txt_foneres.Text & "', " &
                                           "celular='" & txt_celular.Text & "', " &
                                           "email='" & txt_email.Text & "', " &
                                           "foto='" & diretorio & "' where cpf='" & txt_cpf.Text & "'"
                rs = db.Execute(UCase(sql))
                MsgBox("Dados alterados com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
                Call limpar_cadastro()
            Else
                sql = "insert into tb_cadastro values ('" & txt_cpf.Text & "', '" & txt_data_nasc.Text & "', " &
                "'" & txt_nome.Text & "', '" & txt_cep.Text & "', '" & txt_endereco.Text & "', " &
                "'" & txt_comp.Text & "', '" & txt_bairro.Text & "', '" & txt_cidade.Text & "', '" & txt_uf.Text & "', " &
                "'" & txt_foneres.Text & "', '" & txt_celular.Text & "', '" & txt_email.Text & "', '" & "ATIVO" & "' , '" & diretorio & "')"
                rs = db.Execute(UCase(sql))
                MsgBox("Dados gravados com sucesso!!!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
                Call carregar_dados_grid()
                Call limpar_cadastro()
            End If
        Catch ex As Exception
            MsgBox("Erro de processamento", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
            Exit Sub
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_clientes.CellContentClick
        Try
            With dgv_clientes
                If .CurrentRow.Cells(6).Selected = True Then
                    aux_cpf = .CurrentRow.Cells(1).Value
                    resp = MsgBox("Deseja realmente excluir" + vbNewLine &
                              "O Cliente: " & aux_cpf & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ATENÇÃO")
                    If resp = MsgBoxResult.Yes Then
                        sql = "delete from tb_cadastro where nome ='" & aux_cpf & "'"
                        rs = db.Execute(sql)
                        Call carregar_dados_grid()
                    End If
                Else
                    Exit Sub
                End If

            End With
        Catch ex As Exception
            MsgBox("Erro ao processar", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_fim_Click(sender As Object, e As EventArgs) Handles btn_fim.Click
        If txt_comp_cliente.Text = "" Then
            MsgBox("Preencha todos os campos!!!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "AVISO")
        Else

            Call carregar_dadosnota()
            Call SalvarItens()

            MsgBox("Pedido feito com sucesso!!!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
            txt_cliente.Clear()
            txt_cpf_cliente.Clear()
            txt_cep_cliente.Clear()
            txt_cidade.Clear()
            txt_cep_cliente.Clear()
            txt_fone_cliente.Clear()
            txt_endereco_cliente.Clear()
            txt_comp_cliente.Clear()
            txt_total.Clear()
            img_foto_cliente.Load(Application.StartupPath & "\imagens\foto_padrao.png")
            dgv_item.Rows.Clear()
            Me.cmb_pag.SelectedIndex = 0
            carregar_dados_pizzaiolo()
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub dgv_dados_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_func.CellContentClick
        Try
            With dgv_func
                If .CurrentRow.Cells(7).Selected = True Then
                    aux_cpf = .CurrentRow.Cells(2).Value
                    resp = MsgBox("Deseja realmente excluir" + vbNewLine &
                              "O funcionario: " & aux_cpf & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ATENÇÃO")
                    If resp = MsgBoxResult.Yes Then
                        sql = "delete from tb_funcionarios where nome ='" & aux_cpf & "'"
                        rs = db.Execute(sql)
                        Call carregar_dados_grid_func()
                    End If
                ElseIf .CurrentRow.Cells(6).Selected = True Then
                    aux_cpf = .CurrentRow.Cells(2).Value
                    resp = MsgBox("Deseja realmente bloquear" + vbNewLine &
                              "O funcionario: " & aux_cpf & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ATENÇÃO")
                    If resp = MsgBoxResult.Yes Then
                        sql = "update tb_funcionarios set status = 'BLOQUEADO' where nome ='" & aux_cpf & "'"
                        rs = db.Execute(sql)
                        Call carregar_dados_grid_func()
                    End If
                ElseIf .CurrentRow.Cells(5).Selected = True Then
                    aux_cpf = .CurrentRow.Cells(2).Value
                    resp = MsgBox("Deseja realmente ativar" + vbNewLine &
                              "O funcionario: " & aux_cpf & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ATENÇÃO")
                    If resp = MsgBoxResult.Yes Then
                        sql = "update tb_funcionarios set status = 'ATIVO' where nome ='" & aux_cpf & "'"
                        rs = db.Execute(sql)
                        Call carregar_dados_grid_func()
                    End If
                Else
                    Exit Sub
                End If

            End With
        Catch ex As Exception
            MsgBox("Erro ao processar", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub txt_cep_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles txt_cep.MaskInputRejected

    End Sub

    Private Sub txt_cep_LostFocus(sender As Object, e As EventArgs) Handles txt_cep.LostFocus
        Try
            sql = "select * from tb_cep where cep='" & txt_cep.Text & "'"
            rs = db.Execute(sql)
            If rs.EOF = False Then
                txt_endereco.Text = rs.Fields(1).Value
                txt_cidade.Text = rs.Fields(2).Value
                txt_bairro.Text = rs.Fields(3).Value
                txt_uf.Text = rs.Fields(4).Value
                txt_comp.Focus()
            Else
                MsgBox("Cep nao localizado !!!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "AVISO")
            End If
        Catch
            MsgBox("Erro ao processar a consulta!!!")
        End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles img_foto_cliente.Click

    End Sub

    Private Sub ToolStripLabel3_Click(sender As Object, e As EventArgs) Handles ToolStripLabel3.Click
        Me.Close()
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox9_LostFocus(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt_cpf_cliente_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles txt_cpf_cliente.MaskInputRejected

    End Sub

    Private Sub txt_cpf_cliente_LostFocus(sender As Object, e As EventArgs) Handles txt_cpf_cliente.LostFocus
        Try
            sql = "select * from tb_cadastro where cpf='" & txt_cpf_cliente.Text & "'"
            rs = db.Execute(sql)
            If rs.EOF = False Then
                txt_cliente.Text = rs.Fields(2).Value
                txt_cidade.Text = rs.Fields(7).Value
                txt_cep_cliente.Text = rs.Fields(3).Value
                txt_fone_cliente.Text = rs.Fields(9).Value
                txt_endereco_cliente.Text = rs.Fields(4).Value
                txt_comp_cliente.Text = rs.Fields(5).Value
                img_foto_cliente.Load(rs.Fields(13).Value)
                cmb_item.Focus()

            End If
        Catch
            MsgBox("Erro ao processar a consulta!!!")
        End Try
    End Sub

    Private Sub txt_cpf_cliente_GotFocus(sender As Object, e As EventArgs) Handles txt_cpf_cliente.GotFocus
        txt_cliente.Clear()
        txt_cep_cliente.Clear()
        txt_cidade.Clear()
        txt_cep_cliente.Clear()
        txt_fone_cliente.Clear()
        txt_endereco_cliente.Clear()
        txt_comp_cliente.Clear()
        img_foto_cliente.Load(Application.StartupPath & "\imagens\foto_padrao.png")
    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripStatusLabel2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbl_usuario.Text = UCase(frm_login.cmb_tipo.Text)
        lbl_data.Text = Date.Today
        lbl_hora.Text = TimeOfDay
    End Sub

    Private Sub ToolStripTextBox1_Click_1(sender As Object, e As EventArgs) Handles txt_busca.Click

    End Sub

    Private Sub ToolStripTextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt_busca.TextChanged
        With dgv_func
            cont = 1
            sql = "select * from tb_funcionarios where " & cmb_tipo.Text & " like '" & txt_busca.Text & "%'"
            rs = db.Execute(sql)
            .Rows.Clear()
            Do While rs.EOF = False
                .Rows.Add(cont, rs.Fields(4).Value, rs.Fields(1).Value, rs.Fields(2).Value, rs.Fields(6).Value, Nothing, Nothing)
                cont = cont + 1
                rs.MoveNext()
            Loop
        End With
    End Sub

    Private Sub txt_nome_cliente_Click(sender As Object, e As EventArgs) Handles txt_busca_cliente.Click

    End Sub

    Private Sub txt_nome_cliente_TextChanged(sender As Object, e As EventArgs) Handles txt_busca_cliente.TextChanged
        With dgv_clientes
            cont = 1
            sql = "select * from tb_cadastro where " & cmb_tipo_cliente.Text & " like '" & txt_busca_cliente.Text & "%'"
            rs = db.Execute(sql)
            .Rows.Clear()
            Do While rs.EOF = False
                .Rows.Add(cont, rs.Fields(2).Value, rs.Fields(0).Value, rs.Fields(3).Value, rs.Fields(4).Value, rs.Fields(9).Value, Nothing)
                cont = cont + 1
                rs.MoveNext()
            Loop
        End With
    End Sub

    Private Sub TabPage7_Click(sender As Object, e As EventArgs) Handles TabPage7.Click

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_nota.CellContentClick

    End Sub

    Private Sub cmb_tipos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_tipos.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conecta_banco()
        If txt_item.Text = "" Or txt_preco.Text = "" Then
            MsgBox("Preencha todos os campos!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ATENÇÃO")
            Exit Sub
        Else
            sql = "select nome_item from tb_cardapio where nome_item='" & txt_item.Text & "'"
            rs = db.Execute(UCase(sql))
            If rs.EOF = False Then
                Try
                    sql = "update tb_cardapio set preco='" & txt_preco.Text & "',tipo_item='" & cmb_tipos.SelectedItem & "' where nome_item='" & txt_item.Text & "'"
                    rs = db.Execute(UCase(sql))
                    MsgBox("Cardapio Atualizado com sucesso!!!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
                    carregar_cardapio()
                    Exit Sub
                Catch ex As Exception
                    MsgBox("Erro de processamento", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
                    Exit Sub
                End Try
            Else
                Try
                    sql = "insert into tb_cardapio values( '" & txt_item.Text & "','" & txt_preco.Text & "','" & cmb_tipos.SelectedItem & "' ) "
                    rs = db.Execute(UCase(sql))
                    MsgBox("Item Adicionado com sucesso!!!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
                    txt_item.Text = ""
                    txt_preco.Text = ""
                    cmb_tipos.SelectedIndex = 0
                    carregar_cardapio()
                    Exit Sub
                Catch ex As Exception
                    MsgBox("Erro de processamento", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
                    Exit Sub
                End Try

            End If
        End If
    End Sub

    Private Sub dgv_ctr_cardapio_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_ctr_cardapio.CellContentClick
        Try
            With dgv_ctr_cardapio
                If .CurrentRow.Cells(5).Selected = True Then
                    aux_item = .CurrentRow.Cells(2).Value
                    resp = MsgBox("Deseja realmente excluir" + vbNewLine &
                              "O item: " & aux_item & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ATENÇÃO")
                    If resp = MsgBoxResult.Yes Then
                        sql = "delete from tb_cardapio where nome_item ='" & aux_item & "'"
                        rs = db.Execute(sql)
                        Call carregar_cardapio()
                    End If
                ElseIf .CurrentRow.Cells(4).Selected = True Then

                    txt_item.Text = .CurrentRow.Cells(2).Value
                    txt_preco.Text = .CurrentRow.Cells(3).Value
                    cmb_tipos.SelectedItem = .CurrentRow.Cells(1).Value

                Else
                    Exit Sub
                End If

            End With
        Catch ex As Exception
            MsgBox("Erro ao processar", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try

    End Sub

    Private Sub chk_meia_CheckedChanged(sender As Object, e As EventArgs) Handles chk_meia.CheckedChanged
        cmb_item2.Enabled = Not (cmb_item2.Enabled)
    End Sub

    Private Sub btn_ad_Click(sender As Object, e As EventArgs) Handles btn_ad.Click
        If txt_qtd.Text = "" Then
            MsgBox("Preencha a Quantidade!!!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ATENÇÃO")
            Exit Sub
        Else
            If cmb_item.SelectedItem <> "" Then
                If chk_meia.Checked Then
                    If cmb_item2.SelectedItem <> "" Then
                        sql = "select * from tb_cardapio where nome_item = '" & cmb_item.SelectedItem & "' "
                        rs = db.Execute(sql)
                        it = CDbl(rs.Fields(1).Value)
                        sql = "select * from tb_cardapio where nome_item = '" & cmb_item2.SelectedItem & "' "
                        rs = db.Execute(sql)
                        it2 = CDbl(rs.Fields(1).Value)

                        If it < it2 Then
                            it = it2
                        End If
                        it2 = CDbl(txt_qtd.Text)
                        it = it * it2
                        meia = cmb_item.SelectedItem + "/" + cmb_item2.SelectedItem
                        dgv_item.Rows.Add(txt_qtd.Text, it, meia, Nothing)
                    End If
                Else
                    sql = "select * from tb_cardapio where nome_item = '" & cmb_item.SelectedItem & "'"
                    rs = db.Execute(sql)
                    it = CDbl(rs.Fields(1).Value)
                    it2 = CDbl(txt_qtd.Text)
                    it = it * it2
                    dgv_item.Rows.Add(txt_qtd.Text, it, cmb_item.SelectedItem, Nothing)
                End If
            End If
        End If
        Call PSomaProdutos()
        Call PFormatagdv()
        cmb_item.Text = ""
        cmb_item2.Text = ""
        chk_meia.Enabled = False
        chk_meia.Checked = False
        txt_qtd.Text = ""
        it = 0

    End Sub

    Private Sub cmb_item_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_item.SelectedIndexChanged
        conecta_banco()
        sql = "select tipo_item from tb_cardapio where nome_item = '" & cmb_item.SelectedItem & "'"
        rs = db.Execute(sql)
        If rs.Fields(0).Value = "PIZZA" Then
            chk_meia.Enabled = True
        Else
            chk_meia.Enabled = False
        End If

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

    End Sub

    Private Sub dg_item_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_item.CellContentClick
        Try
            With dgv_item
                If .CurrentRow.Cells(3).Selected = True Then
                    aux_cpf = .CurrentRow.Cells(2).Value
                    resp = MsgBox("Deseja realmente excluir" + vbNewLine &
                              "A Pizza: " & aux_cpf & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ATENÇÃO")
                    If resp = MsgBoxResult.Yes Then
                        dgv_item.Rows.Remove(dgv_item.Rows(dgv_item.CurrentRow.Index))
                        Call carregar_cardapio()
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox("Erro ao processar", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub dgv_pizzaiolo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_pizzaiolo.CellContentClick
        Try
            With dgv_pizzaiolo
                If .CurrentRow.Cells(4).Selected = True Then
                    aux_cpf = .CurrentRow.Cells(0).Value
                    resp = MsgBox("Deseja concluir pedido" + vbNewLine &
                              "Nº: " & aux_cpf & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ATENÇÃO")
                    If resp = MsgBoxResult.Yes Then
                        sql = "delete from tb_pedidos where id ='" & aux_cpf & "'"
                        rs = db.Execute(sql)
                        Call carregar_dados_pizzaiolo()
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox("Erro ao processar", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub txt_total_TextChanged(sender As Object, e As EventArgs) Handles txt_total.TextChanged

    End Sub

    Private Sub cmb_item2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_item2.SelectedIndexChanged

    End Sub

    Private Sub form2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles form2.SelectedIndexChanged

    End Sub

    Private Sub txt_cpf_MouseClick(sender As Object, e As MouseEventArgs) Handles txt_cpf.MouseClick

    End Sub
End Class