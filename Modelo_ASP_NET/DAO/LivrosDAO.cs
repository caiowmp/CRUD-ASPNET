using Modelo_ASP_NET.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Modelo_ASP_NET.DAO
{
    [Serializable]
    public class LivrosDAO
    {
        SqlCommand ioQuery;

        SqlConnection ioConexao;

        public BindingList<Livros> BuscaLivrosAutor(Autores autorRecebido)
        {
            BindingList<Livros> loListLivros = new BindingList<Livros>();

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();

                    ioQuery = new SqlCommand("SELECT LIV_ID_LIVRO, LIV_ID_TIPO_LIVRO, ISNULL(LIV_ID_EDITOR, -1), LIV_NM_TITULO, ISNULL(LIV_VL_PRECO, -1), LIV_PC_ROYALTY, ISNULL(LIV_DS_RESUMO, 'vazio'), LIV_NU_EDICAO, ISNULL(EDI_NM_EDITOR,'editor não informado'), ISNULL(TIL_DS_DESCRICAO, 'categoria não informada') FROM LIV_LIVROS LEFT JOIN TIL_TIPO_LIVRO ON TIL_ID_TIPO_LIVRO = LIV_ID_TIPO_LIVRO LEFT JOIN EDI_EDITORES ON LIV_ID_EDITOR = EDI_ID_EDITOR WHERE LIV_ID_LIVRO IN (SELECT LIA_ID_LIVRO FROM AUT_AUTORES INNER JOIN LIA_LIVRO_AUTOR ON AUT_ID_AUTOR = LIA_ID_AUTOR WHERE AUT_ID_AUTOR = @idAutor)", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idAutor", autorRecebido.aut_id_autor));

                    using (SqlDataReader loReader = ioQuery.ExecuteReader())
                    {
                        while (loReader.Read())
                        {
                            Livros loNovoLivro = new Livros(loReader.GetDecimal(0), loReader.GetDecimal(1), loReader.GetDecimal(2), loReader.GetString(3), loReader.GetDecimal(4),
                                                            loReader.GetDecimal(5), loReader.GetString(6), loReader.GetInt32(7), loReader.GetString(8), loReader.GetString(9));

                            loListLivros.Add(loNovoLivro);
                        }

                        loReader.Close();
                    }
                }
                catch
                {
                    throw new Exception("Erro ao tentar buscar o(s) livro(s) do Autor");
                }
            }
            return loListLivros;
        }

        public BindingList<Livros> BuscaLivrosCategoria(decimal id_categoria)
        {
            BindingList<Livros> loListLivros = new BindingList<Livros>();

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();

                    ioQuery = new SqlCommand("SELECT LIV_ID_LIVRO, LIV_ID_TIPO_LIVRO, ISNULL(LIV_ID_EDITOR, -1), LIV_NM_TITULO, ISNULL(LIV_VL_PRECO, -1), LIV_PC_ROYALTY, ISNULL(LIV_DS_RESUMO, 'vazio'), LIV_NU_EDICAO, ISNULL(EDI_NM_EDITOR,'editor não informado'), ISNULL(TIL_DS_DESCRICAO, 'categoria não informada') FROM LIV_LIVROS LEFT JOIN TIL_TIPO_LIVRO ON TIL_ID_TIPO_LIVRO = LIV_ID_TIPO_LIVRO LEFT JOIN EDI_EDITORES ON LIV_ID_EDITOR = EDI_ID_EDITOR WHERE LIV_ID_TIPO_LIVRO = @idCategoria", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idCategoria", id_categoria));

                    using (SqlDataReader loReader = ioQuery.ExecuteReader())
                    {
                        while (loReader.Read())
                        {
                            Livros loNovoLivro = new Livros(loReader.GetDecimal(0), loReader.GetDecimal(1), loReader.GetDecimal(2), loReader.GetString(3), loReader.GetDecimal(4),
                                                            loReader.GetDecimal(5), loReader.GetString(6), loReader.GetInt32(7), loReader.GetString(8), loReader.GetString(9));

                            loListLivros.Add(loNovoLivro);
                        }

                        loReader.Close();
                    }
                }
                catch
                {
                    throw new Exception("Erro ao tentar buscar o(s) livro(s) da Categoria");
                }
            }
            return loListLivros;
        }
    

        public BindingList<Livros> BuscaLivrosEditor(Editores editor)
        {
            BindingList<Livros> loListLivros = new BindingList<Livros>();

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();

                    ioQuery = new SqlCommand("SELECT LIV_ID_LIVRO, LIV_ID_TIPO_LIVRO, LIV_ID_EDITOR, LIV_NM_TITULO, ISNULL(LIV_VL_PRECO, -1), LIV_PC_ROYALTY, ISNULL(LIV_DS_RESUMO, 'vazio'), LIV_NU_EDICAO, ISNULL(TIL_DS_DESCRICAO, 'categoria não informada'), ISNULL(EDI_NM_EDITOR,'editor não informado') FROM LIV_LIVROS LEFT JOIN TIL_TIPO_LIVRO ON TIL_ID_TIPO_LIVRO = LIV_ID_LIVRO LEFT JOIN EDI_EDITORES ON LIV_ID_EDITOR = EDI_ID_EDITOR WHERE LIV_ID_EDITOR = @idEditor", ioConexao);

                    ioQuery.Parameters.Add(new SqlParameter("@idEditor", editor.edi_id_editores));

                    using (SqlDataReader loReader = ioQuery.ExecuteReader())
                    {
                        while (loReader.Read())
                        {
                            Livros loNovoLivro = new Livros(loReader.GetDecimal(0), loReader.GetDecimal(1), loReader.GetDecimal(2), loReader.GetString(3), loReader.GetDecimal(4),
                                                            loReader.GetDecimal(5), loReader.GetString(6), loReader.GetInt32(7), loReader.GetString(8), loReader.GetString(9));

                            loListLivros.Add(loNovoLivro);
                        }

                        loReader.Close();
                    }
                }
                catch
                {
                    throw new Exception("Erro ao tentar buscar o(s) livro(s) do Editor");
                }
            }
            return loListLivros;
        }
    

        public BindingList<Livros> BuscaLivros(decimal? liv_id_livro = null)
        {
            BindingList<Livros> loListLivros = new BindingList<Livros>();

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();

                    if (liv_id_livro != null)
                    {
                        ioQuery = new SqlCommand("SELECT LIV_ID_LIVRO, LIV_ID_TIPO_LIVRO, ISNULL(LIV_ID_EDITOR, -1), LIV_NM_TITULO, ISNULL(LIV_VL_PRECO, -1), LIV_PC_ROYALTY, ISNULL(LIV_DS_RESUMO, 'vazio'), LIV_NU_EDICAO, ISNULL(EDI_NM_EDITOR,'editor não informado'), ISNULL(TIL_DS_DESCRICAO, 'categoria não informada') FROM LIV_LIVROS LEFT JOIN TIL_TIPO_LIVRO ON TIL_ID_TIPO_LIVRO = LIV_ID_TIPO_LIVRO LEFT JOIN EDI_EDITORES ON LIV_ID_EDITOR = EDI_ID_EDITOR WHERE LIV_ID_LIVRO = @idLivro", ioConexao); 

                        ioQuery.Parameters.Add(new SqlParameter("@idLivro", liv_id_livro));
                    }
                    else
                    {
                        ioQuery = new SqlCommand("SELECT LIV_ID_LIVRO, LIV_ID_TIPO_LIVRO, ISNULL(LIV_ID_EDITOR, -1), LIV_NM_TITULO, ISNULL(LIV_VL_PRECO, -1), LIV_PC_ROYALTY, ISNULL(LIV_DS_RESUMO, 'vazio'), LIV_NU_EDICAO, ISNULL(EDI_NM_EDITOR,'editor não informado'), ISNULL(TIL_DS_DESCRICAO, 'categoria não informada') FROM LIV_LIVROS LEFT JOIN TIL_TIPO_LIVRO ON TIL_ID_TIPO_LIVRO = LIV_ID_TIPO_LIVRO LEFT JOIN EDI_EDITORES ON LIV_ID_EDITOR = EDI_ID_EDITOR", ioConexao);
                    }

                    using (SqlDataReader loReader = ioQuery.ExecuteReader())
                    {
                        //Chamando a função de leitura antes de acessar os dados (uma vez para cada linha retornada na consulta)
                        while (loReader.Read())
                        {
                            //Instanciando um objeto do tipo Livro e preenchendo suas propriedades com os valores retornados pela consulta
                            Livros loNovoLivro = new Livros(loReader.GetDecimal(0), loReader.GetDecimal(1), loReader.GetDecimal(2), loReader.GetString(3), loReader.GetDecimal(4),
                                                            loReader.GetDecimal(5), loReader.GetString(6), loReader.GetInt32(7), loReader.GetString(8), loReader.GetString(9));

                            //Incluindo Livro na lista criada anteriormente
                            loListLivros.Add(loNovoLivro);
                        }
                        //fechando objeto de leitura
                        loReader.Close();
                    }
                }
                catch
                {
                    throw new Exception("Erro ao tentar buscar o(s) livro(s)");
                }
            }
            return loListLivros;
        }

        public int InsereLivro(Livros aoNovoLivro)
        {
            //Caso o Livro não venha preenchido, é lançada uma exceção do tipo NullReferenceException
            if (aoNovoLivro == null)
                throw new NullReferenceException();

            int liQtdRegistrosInseridos = 0;

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("INSERT INTO LIV_LIVROS(LIV_ID_LIVRO, LIV_ID_TIPO_LIVRO, LIV_ID_EDITOR, LIV_NM_TITULO, LIV_VL_PRECO, LIV_PC_ROYALTY, LIV_DS_RESUMO, LIV_NU_EDICAO) VALUES(@idLivro, @idTipoLivro, @idEditor, @nomeTitulo, @valorPreco, @pcRoyalty, @dsResumo, @edicaoLivro)", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idLivro", aoNovoLivro.liv_id_livro));
                    ioQuery.Parameters.Add(new SqlParameter("@idTipoLivro", aoNovoLivro.liv_id_tipo_livro));
                    ioQuery.Parameters.Add(new SqlParameter("@idEditor", aoNovoLivro.liv_id_editor));
                    ioQuery.Parameters.Add(new SqlParameter("@nomeTitulo", aoNovoLivro.liv_nm_titulo));
                    ioQuery.Parameters.Add(new SqlParameter("@valorPreco", aoNovoLivro.liv_vl_preco));
                    ioQuery.Parameters.Add(new SqlParameter("@pcRoyalty", aoNovoLivro.liv_pc_royalty));
                    ioQuery.Parameters.Add(new SqlParameter("@dsResumo", aoNovoLivro.liv_ds_resumo));
                    ioQuery.Parameters.Add(new SqlParameter("@edicaoLivro", aoNovoLivro.liv_nu_edicao));

                    //Executando o comando Transact-SQL e retornando a quantidade de linhas afetadas.
                    liQtdRegistrosInseridos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao tentar cadastrar novo Livro");
                }
            }
            return liQtdRegistrosInseridos;
        }

        public int RemoveLivro(Livros aoLivro)
        {
            if (aoLivro == null)
                throw new ArgumentNullException();

            int liQtdRegistrosInseridos = 0;

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("DELETE FROM LIV_LIVROS WHERE LIV_ID_LIVRO = @idLivro", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idLivro", aoLivro.liv_id_livro));

                    //Executando o comando Transact-SQL e retornando a quantidade de linhas afetadas.
                    liQtdRegistrosInseridos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao tentar excluir Livro");
                }
            }
            return liQtdRegistrosInseridos;
        }

        public int AtualizaLivro(Livros aoLivro)
        {
            if (aoLivro == null)
                throw new ArgumentNullException();

            int liQtdRegistrosInseridos = 0;

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("UPDATE LIV_LIVROS SET LIV_ID_TIPO_LIVRO = @idTipoLivro, LIV_ID_EDITOR = @idEditor, LIV_NM_TITULO = @nomeTitulo, LIV_VL_PRECO = @valorPreco, LIV_PC_ROYALTY = @pcRoyalty, LIV_DS_RESUMO = @dsResumo, LIV_NU_EDICAO = @edicaoLivro WHERE LIV_ID_LIVRO = @idLivro", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idLivro", aoLivro.liv_id_livro));
                    ioQuery.Parameters.Add(new SqlParameter("@idTipoLivro", aoLivro.liv_id_tipo_livro));
                    ioQuery.Parameters.Add(new SqlParameter("@idEditor", aoLivro.liv_id_editor));
                    ioQuery.Parameters.Add(new SqlParameter("@nomeTitulo", aoLivro.liv_nm_titulo));
                    ioQuery.Parameters.Add(new SqlParameter("@valorPreco", aoLivro.liv_vl_preco));
                    ioQuery.Parameters.Add(new SqlParameter("@pcRoyalty", aoLivro.liv_pc_royalty));
                    ioQuery.Parameters.Add(new SqlParameter("@dsResumo", aoLivro.liv_ds_resumo));
                    ioQuery.Parameters.Add(new SqlParameter("@edicaoLivro", aoLivro.liv_nu_edicao));

                    liQtdRegistrosInseridos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao tentar atualizar informações do Livro");
                }
            }
            return liQtdRegistrosInseridos;
        }

        public BindingList<Livros> FindLivrosByAutor(Autores aoAutor)
        {
            //Criando uma lista de Livros que será retornada pela função
            BindingList<Livros> loListLivros = new BindingList<Livros>();

            //Caso o Autor não venha preenchido, é lançada uma exceção do tipo NullReferenceException
            if (aoAutor == null)
                throw new NullReferenceException();

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"]
                .ConnectionString))
            {
                try
                {
                    ioConexao.Open();

                    //Montando a query que será executada para retornar o Livro, caso tenha sido passado um ID.
                    ioQuery = new SqlCommand("SELECT LIV_ID_LIVRO, LIV_ID_TIPO_LIVRO, ISNULL(LIV_ID_EDITOR, -1), LIV_NM_TITULO, ISNULL(LIV_VL_PRECO, -1), LIV_PC_ROYALTY, ISNULL(LIV_DS_RESUMO, 'vazio'), LIV_NU_EDICAO FROM LIV_LIVROS livros INNER JOIN LIA_LIVRO_AUTOR livroAutor ON livros.LIV_ID_LIVRO = livroAutor.LIA_ID_LIVRO INNER JOIN AUT_AUTORES autores ON livroAutor.LIA_ID_AUTOR = autores.AUT_ID_AUTOR WHERE autores.AUT_ID_AUTOR = @idAutor", ioConexao);

                    //Criando a variável @idLivro e setando o seu valor com o ID recebido por parâmetro pela função
                    ioQuery.Parameters.Add(new SqlParameter("@idAutor", aoAutor.aut_id_autor));

                    //Criando o bloco de leitura de dados do SQL server
                    SqlDataReader loReader = ioQuery.ExecuteReader();

                    //Chamando a função de leitura antes de acessar os dados (uma vez para cada linha retornada na consulta)
                    while (loReader.Read())
                    {
                        //Instanciando um objeto do tipo Livro e preenchendo suas propriedades com os valores retornados pela consulta
                        Livros loNovoLivro = new Livros(loReader.GetDecimal(0), loReader.GetDecimal(1), loReader.GetDecimal(2),
                            loReader.GetString(3), loReader.GetDecimal(4), loReader.GetDecimal(5), loReader.GetString(6),
                            loReader.GetInt16(7));

                        //Incluindo Livro na lista criada anteriormente
                        loListLivros.Add(loNovoLivro);
                    }
                    //fechando objeto de leitura
                    loReader.Close();

                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao tentar localizar Livros do Autor");
                }
            }
            return loListLivros;
        }
    }
}