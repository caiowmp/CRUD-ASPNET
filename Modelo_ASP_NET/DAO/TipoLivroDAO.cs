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
    public class TipoLivroDAO
    {
        SqlCommand ioQuery;
        //Instanciando o objeto SqlConnection para abrir a conexão com o banco de dados
        SqlConnection ioConexao;

        public TipoLivro BuscaTipoLivroPorNome(string til_ds_descricao)
        {
            TipoLivro loTipoLivro = new TipoLivro(-1, "vazio");

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();

                    ioQuery = new SqlCommand("SELECT * FROM TIL_TIPO_LIVRO WHERE TIL_DS_DESCRICAO = @descricaoTipoLivro", ioConexao);

                    ioQuery.Parameters.Add(new SqlParameter("@descricaoTipoLivro", til_ds_descricao));

                    using (SqlDataReader loReader = ioQuery.ExecuteReader())
                    {
                        while (loReader.Read())
                        {
                            TipoLivro loNovoTipoLivro = new TipoLivro(loReader.GetDecimal(0), loReader.GetString(1));
                            loTipoLivro = loNovoTipoLivro;
                        }
                        //fechando objeto de leitura
                        loReader.Close();
                    }
                }
                catch
                {
                    throw new Exception("Erro ao tentar buscar o TipoLivro");
                }
            }
            return loTipoLivro;
        }

        public BindingList<TipoLivro> BuscaTipoLivro(decimal? til_id_tipo_livro = null)
        {
            //Criando uma lista de TipoLivro que será retornada pela função
            BindingList<TipoLivro> loListTipoLivro = new BindingList<TipoLivro>();

            //Criando conexão com o banco de daods, utilizando as informações que foram preenchidas
            // no Web.config na tag ConnectionStrings e nome ConnectionString
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    //Abrindo conexõa com o servidor
                    ioConexao.Open();

                    if (til_id_tipo_livro != null)
                    {
                        //Montando a query que será executada para retornar o autor, caso tenha sido passado um ID.
                        ioQuery = new SqlCommand("SELECT * FROM TIL_TIPO_LIVRO WHERE TIL_ID_TIPO_LIVRO = @idTipoLivro", ioConexao);

                        //Criando a variável @idAutor e setando o seu valor com o ID recebido por parâmetro pela função
                        ioQuery.Parameters.Add(new SqlParameter("@idTipoLivro", til_id_tipo_livro));
                    }
                    else
                    {
                        //Caso não seja passado nenhum ID, a query deve retornar todos os TipoLivro
                        ioQuery = new SqlCommand("SELECT * FROM TIL_TIPO_LIVRO", ioConexao);
                    }
                    //Criando o bloco de leitura de dados do SQL server
                    using (SqlDataReader loReader = ioQuery.ExecuteReader())
                    {
                        //Chamando a função de leitura antes de acessar os dados (uma vez para cada linha retornada na consulta)
                        while (loReader.Read())
                        {
                            //Instanciando um objeto do tipo Autor e preenchendo suas propriedades com os valores retornados pela consulta
                            TipoLivro loNovoEditor = new TipoLivro(loReader.GetDecimal(0), loReader.GetString(1));

                            //Incluindo Autor na lista criada anteriormente
                            loListTipoLivro.Add(loNovoEditor);
                        }
                        //fechando objeto de leitura
                        loReader.Close();
                    }
                }
                catch
                {
                    throw new Exception("Erro ao tentar buscar o(s) TipoLivro(es)");
                }
            }
            return loListTipoLivro;
        }

        public int InsereTipoLivro(TipoLivro aoNovoTipoLivro)
        {
            //Caso o TipoLivro não venha preenchido, é lançada uma exceção do tipo NullReferenceException
            if (aoNovoTipoLivro == null)
                throw new NullReferenceException();

            int liQtdRegistrosInseridos = 0;

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("INSERT INTO TIL_TIPO_LIVRO (TIL_ID_TIPO_LIVRO, TIL_DS_DESCRICAO)" +
                        "VALUES(@idTipoLivro, @dsDescricao)", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idTipoLivro", aoNovoTipoLivro.til_id_tipo_livro));
                    ioQuery.Parameters.Add(new SqlParameter("@dsDescricao", aoNovoTipoLivro.til_ds_descricao));

                    //Executando o comando Transact-SQL e retornando a quantidade de linhas afetadas.
                    liQtdRegistrosInseridos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao tentar cadastrar novo TipoLivro");
                }
            }
            return liQtdRegistrosInseridos;
        }

        public int RemoveTiopoLivro(TipoLivro aoTipoLivro)
        {
            if (aoTipoLivro == null)
                throw new ArgumentNullException();

            int liQtdRegistrosInseridos = 0;

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("DELETE FROM TIL_TIPO_LIVRO WHERE TIL_ID_TIPO_LIVRO = @idTipoLivro", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idTipoLivro", aoTipoLivro.til_id_tipo_livro));

                    //Executando o comando Transact-SQL e retornando a quantidade de linhas afetadas.
                    liQtdRegistrosInseridos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao tentar excluir TipoLivro");
                }
            }
            return liQtdRegistrosInseridos;
        }

        public int AtualizaTipoLivro(TipoLivro aoTipoLivro)
        {
            if (aoTipoLivro == null)
                throw new ArgumentNullException();

            int liQtdRegistrosInseridos = 0;

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                //try
                //{
                    ioConexao.Open();
                    ioQuery = new SqlCommand("UPDATE TIL_TIPO_LIVRO SET TIL_DS_DESCRICAO = @dsDescricao WHERE TIL_ID_TIPO_LIVRO = @idTipoLivro", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idTipoLivro", aoTipoLivro.til_id_tipo_livro));
                    ioQuery.Parameters.Add(new SqlParameter("@dsDescricao", aoTipoLivro.til_ds_descricao));

                    liQtdRegistrosInseridos = ioQuery.ExecuteNonQuery();
                /*}
                catch (Exception e)
                {
                    throw new Exception("Erro ao tentar atualizar as informações do TipoLivro");
                }*/
            }
            return liQtdRegistrosInseridos;
        }
    }
}