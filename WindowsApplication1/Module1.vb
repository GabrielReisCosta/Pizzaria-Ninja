Imports System.Data.SqlClient
Module Module1
    Public db As New ADODB.Connection
    Public rs As New ADODB.Recordset
    Public sql, aux_cpf, aux_item As String
    Public it, it2 As Double
    Public resp, diretorio, tipo, status, meia As String
    Public cont, contador As Integer
    Public aux As Integer
    Public conexao = Application.StartupPath & "\Banco_Dados\cadastro.mdb"

    Sub conecta_banco()
        Try


            db = CreateObject("ADODB.Connection")
            db.Open("Provider=SQLOLEDB;Data Source=DESKTOP-33BNQC3;Initial Catalog=ads_va2_si;trusted_connection=yes;")



        Catch ex As Exception
            MsgBox("Falha ao conectar!!!")
        End Try


    End Sub

    Sub PSomaProdutos()
        Dim linha As DataGridViewRow
        Dim valor As Double

        For Each linha In frm_menu.dgv_item.Rows
            valor = valor + linha.Cells(1).Value
        Next
        frm_menu.txt_total.Text = FormatCurrency(valor)
    End Sub
    Sub limpar_cadastro()
        With frm_menu
            .txt_cpf.Clear()
            .txt_nome.Clear()
            .txt_data_nasc.Clear()
            .txt_cep.Clear()
            .txt_endereco.Clear()
            .txt_comp.Clear()
            .txt_bairro.Clear()
            .txt_cidade.Clear()
            .txt_uf.Clear()
            .txt_foneres.Clear()
            .txt_celular.Clear()
            .txt_email.Clear()
            .img_foto.Load(Application.StartupPath & "\imagens\foto_padrao.png")
            .txt_cpf.Focus()
        End With

        With frm_contas
            .txt_email.Clear()
            .txt_cpf.Clear()
            .txt_nome.Clear()
            .txt_rsenha.Clear()
            .txt_senha.Clear()
            .img_foto_func.Load(Application.StartupPath & "\imagens\foto_padrao.png")
        End With
    End Sub


    Sub tipo_funcionario()

    End Sub

    Sub carregar_dados_grid()
        Try
            sql = "select * from tb_cadastro order by nome asc"
            rs = db.Execute(sql)
            With frm_menu.dgv_clientes
                .Rows.Clear()
                cont = 1
                Do While rs.EOF = False
                    .Rows.Add(cont, rs.Fields(2).Value, rs.Fields(0).Value, rs.Fields(3).Value, rs.Fields(4).Value, rs.Fields(9).Value, Nothing)
                    rs.MoveNext()
                    cont = cont + 1
                Loop
            End With
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub

    Sub carregar_dados_pizzaiolo()
        Try
            sql = "select * from tb_pedidos"
            rs = db.Execute(sql)
            With frm_menu.dgv_pizzaiolo
                .Rows.Clear()
                cont = 1
                aux = 1000
                Do While rs.EOF = False
                    .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, "EM PREPARO", Nothing)
                    rs.MoveNext()
                    cont = cont + 1
                    aux = aux + 1
                Loop
            End With
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Sub carregar_dados_grid_func()
        Try
            sql = "select * from tb_funcionarios order by tipo asc"
            rs = db.Execute(sql)
            With frm_menu.dgv_func
                .Rows.Clear()
                cont = 1
                Do While rs.EOF = False
                    .Rows.Add(cont, rs.Fields(4).Value, rs.Fields(1).Value, rs.Fields(2).Value, rs.Fields(6).Value, Nothing, Nothing)
                    rs.MoveNext()
                    cont = cont + 1
                Loop
            End With
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Sub carregar_dados()
        With frm_menu.dgv_func
            cont = 1
            sql = "select * from tb_funcionarios order by nome asc"
            rs = db.Execute(sql)
            .Rows.Clear()
            Do While rs.EOF = False
                .Rows.Add(cont, rs.Fields(0).Value, rs.Fields(2).Value, rs.Fields(10).Value, Nothing, Nothing)
                cont = cont + 1
                rs.MoveNext()
            Loop
        End With
    End Sub

    Sub carregar_dadosnota()
        With frm_menu.dgv_nota
            .Rows.Add(contador, frm_menu.txt_fone_cliente.Text, frm_menu.txt_cliente.Text, frm_menu.txt_endereco_cliente.Text, frm_menu.cmb_pag.Text, frm_menu.txt_total.Text)
            contador = contador + 1
        End With
    End Sub

    Sub report()
        Try
            With frm_menu.cmb_report.Items
                .Clear()
                .Add("MENSAL")
                .Add("ANUAL")
            End With
            frm_menu.cmb_report.SelectedIndex = 0

        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Sub carregar_dadospizzaiolo()
        With frm_menu.dgv_pizzaiolo
            .Rows.Add(contador, "EM PREPARO", Nothing)
            contador = contador + 1
        End With
    End Sub
    Sub carrega_tipo()
        Try
            With frm_menu.cmb_tipo.Items
                .Clear()
                .Add("EMAIL")
                .Add("NOME")
            End With
            With frm_menu.cmb_tipo_cliente.Items
                .Clear()
                .Add("NOME")
                .Add("CPF")
                .Add("ENDERECO")
            End With
            With frm_menu.cmb_tipos.Items
                .Clear()
                .Add("PIZZA")
                .Add("BEBIDAS")
            End With
            frm_menu.cmb_tipo.SelectedIndex = 1
            frm_menu.cmb_tipo_cliente.SelectedIndex = 0
            frm_menu.cmb_tipos.SelectedIndex = 0
            frm_menu.cmb_pag.SelectedIndex = 0
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Sub carregar_cardapio()
        With frm_menu.dgv_ctr_cardapio
            cont = 1
            sql = "select * from tb_cardapio order by tipo_item asc "
            rs = db.Execute(sql)
            .Rows.Clear()
            Do While rs.EOF = False
                .Rows.Add(cont, rs.Fields(2).Value, rs.Fields(0).Value, rs.Fields(1).Value, Nothing, Nothing)
                cont = cont + 1
                rs.MoveNext()
            Loop
        End With
        With frm_menu.cmb_item.Items
            .Clear()
            conecta_banco()
            sql = "select * from tb_cardapio order by tipo_item asc "
            rs = db.Execute(sql)
            Do While rs.EOF = False
                .Add(rs.Fields(0).Value)
                rs.MoveNext()
            Loop
        End With
        With frm_menu.cmb_item2.Items
            .Clear()
            conecta_banco()
            sql = "select * from tb_cardapio where tipo_item='PIZZA' order by NOME_item asc "
            rs = db.Execute(sql)
            Do While rs.EOF = False
                .Add(rs.Fields(0).Value)
                rs.MoveNext()
            Loop
        End With

    End Sub

    Sub PFormatagdv()
        With frm_menu.dgv_item
            .Columns(1).DefaultCellStyle.Format = "c"
        End With
    End Sub

    Sub Pformatadgv_2()
        With frm_menu.dgv_ctr_cardapio
            .Columns(3).DefaultCellStyle.Format = "c"
        End With
    End Sub

    Public Function SalvarItens()
        Dim connection As New Data.SqlClient.SqlConnection
        Dim dataAdapter As New Data.SqlClient.SqlDataAdapter
        Dim command As New Data.SqlClient.SqlCommand
        Dim dataSet As New Data.DataSet

        connection.ConnectionString = "Server= DESKTOP-33BNQC3; Database = ads_va2_si; Integrated Security = true"
        command.CommandText = "INSERT INTO tb_pedidos (id,nome_pedido, qtde_pedido) VALUES (@id, @nome, @qtde)"

        command.Parameters.Add("@id", SqlDbType.VarChar)
        command.Parameters.Add("@nome", SqlDbType.VarChar)
        command.Parameters.Add("@qtde", SqlDbType.VarChar)
        connection.Open()
        command.Connection = connection

        For i As Integer = 0 To frm_menu.dgv_item.Rows.Count - 1
            command.Parameters(0).Value = aux
            command.Parameters(1).Value = frm_menu.dgv_item.Rows(i).Cells(2).Value
            command.Parameters(2).Value = frm_menu.dgv_item.Rows(i).Cells(0).Value
            command.ExecuteNonQuery()
            aux = aux + 1
        Next
    End Function

End Module
