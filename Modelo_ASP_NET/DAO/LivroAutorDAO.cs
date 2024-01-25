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
    public class LivroAutorDAO
    {
        SqlCommand ioQuery;
        //Instanciando o objeto SqlConnection para abrir a conexão com o banco de dados
        SqlConnection ioConexao;

        LivroAutor loLivroAutor;

        public LivroAutor BuscaLivroAutorByLivro(decimal lia_id_livro)
        {
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    //Abrindo conexõa com o servidor
                    ioConexao.Open();

                    //Montando a query que será executada para retornar o autor, caso tenha sido passado um ID.
                    ioQuery = new SqlCommand("SELECT * FROM LIA_LIVRO_AUTOR WHERE LIA_ID_LIVRO = @idLivro", ioConexao);

                    //Criando a variável @idAutor e setando o seu valor com o ID recebido por parâmetro pela função
                    ioQuery.Parameters.Add(new SqlParameter("@idLivro", lia_id_livro));

                    using (SqlDataReader loReader = ioQuery.ExecuteReader())
                    {
                        //Chamando a função de leitura antes de acessar os dados (uma vez para cada linha retornada na consulta)
                        while (loReader.Read())
                        {
                            //Instanciando um objeto do tipo Autor e preenchendo suas propriedades com os valores retornados pela consulta
                            LivroAutor loNovoLivroAutor = new LivroAutor(loReader.GetDecimal(0), loReader.GetDecimal(1), loReader.GetDecimal(2));

                            loLivroAutor = loNovoLivroAutor;
                        }
                        //fechando objeto de leitura
                        loReader.Close();
                    }
                }
                catch
                {
                    throw new Exception("Erro ao tentar buscar o(s) LivroAutor(es)");
                }
            }
            return loLivroAutor;
        }

        public BindingList<LivroAutor> BuscaLivroAutor(decimal? lia_id_autor = null)
        {
            //Criando uma lista de LivroAutor que será retornada pela função
            BindingList<LivroAutor> loListLivroAutor = new BindingList<LivroAutor>();

            //Criando conexão com o banco de daods, utilizando as informações que foram preenchidas
            // no Web.config na tag ConnectionStrings e nome ConnectionString
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    //Abrindo conexõa com o servidor
                    ioConexao.Open();

                    if (lia_id_autor != null)
                    {
                        //Montando a query que será executada para retornar o autor, caso tenha sido passado um ID.
                        ioQuery = new SqlCommand("SELECT * FROM LIA_LIVRO_AUTOR WHERE LIA_ID_AUTOR = @idLivroAutor", ioConexao);

                        //Criando a variável @idAutor e setando o seu valor com o ID recebido por parâmetro pela função
                        ioQuery.Parameters.Add(new SqlParameter("@idLivroAutor", lia_id_autor));
                    }
                    else
                    {
                        //Caso não seja passado nenhum ID, a query deve retornar todos os LivroAutor
                        ioQuery = new SqlCommand("SELECT * FROM LIA_LIVRO_AUTOR", ioConexao);
                    }
                    //Criando o bloco de leitura de dados do SQL server
                    using (SqlDataReader loReader = ioQuery.ExecuteReader())
                    {
                        //Chamando a função de leitura antes de acessar os dados (uma vez para cada linha retornada na consulta)
                        while (loReader.Read())
                        {
                            //Instanciando um objeto do tipo Autor e preenchendo suas propriedades com os valores retornados pela consulta
                            LivroAutor loNovoLivroAutor = new LivroAutor(loReader.GetDecimal(0), loReader.GetDecimal(1), loReader.GetDecimal(2));

                            //Incluindo Autor na lista criada anteriormente
                            loListLivroAutor.Add(loNovoLivroAutor);
                        }
                        //fechando objeto de leitura
                        loReader.Close();
                    }
                }
                catch
                {
                    throw new Exception("Erro ao tentar buscar o(s) LivroAutor(es)");
                }
            }
            return loListLivroAutor;
        }

        public int InsereLivroAutor(LivroAutor aoNovoLivroAutor)
        {
            //Caso o LivroAutor não venha preenchido, é lançada uma exceção do tipo NullReferenceException
            if (aoNovoLivroAutor == null)
                throw new NullReferenceException();

            int liQtdRegistrosInseridos = 0;

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("INSERT INTO LIA_LIVRO_AUTOR (LIA_ID_AUTOR, LIA_ID_LIVRO, LIA_PC_ROYALTY)" +
                        "VALUES(@idAutor, @idLivro, @pcRoyalty)", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idAutor", aoNovoLivroAutor.lia_id_autor));
                    ioQuery.Parameters.Add(new SqlParameter("@idLivro", aoNovoLivroAutor.lia_id_livro));
                    ioQuery.Parameters.Add(new SqlParameter("@pcRoyalty", aoNovoLivroAutor.lia_pc_royalty));

                    //Executando o comando Transact-SQL e retornando a quantidade de linhas afetadas.
                    liQtdRegistrosInseridos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao tentar cadastrar novo LivroAutor");
                }
            }
            return liQtdRegistrosInseridos;
        }

        public int RemoveLivroAutor(LivroAutor aoLivroAutor)
        {
            if (aoLivroAutor == null)
                throw new ArgumentNullException();

            int liQtdRegistrosInseridos = 0;

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("DELETE FROM LIA_LIVRO_AUTOR WHERE LIA_ID_AUTOR = @idAutor", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idAutor", aoLivroAutor.lia_id_autor));

                    //Executando o comando Transact-SQL e retornando a quantidade de linhas afetadas.
                    liQtdRegistrosInseridos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao tentar excluir LivroAutor");
                }
            }
            return liQtdRegistrosInseridos;
        }

        public int AtualizaLivroAutor(LivroAutor aoLivroAutor)
        {
            if (aoLivroAutor == null)
                throw new ArgumentNullException();

            int liQtdRegistrosInseridos = 0;

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("UPDATE FROM LIA_LIVRO_AUTOR SET LIA_PC_ROYALTY = @pcRoyalty WHERE LIA_ID_AUTOR = @idAutor", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idAutor", aoLivroAutor.lia_id_autor));
                    ioQuery.Parameters.Add(new SqlParameter("@pcRoyalty", aoLivroAutor.lia_pc_royalty));

                    //Executando o comando Transact-SQL e retornando a quantidade de linhas afetadas.
                    liQtdRegistrosInseridos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao tentar atualizar as informações do LivroAutor");
                }
            }
            return liQtdRegistrosInseridos;
        }
    }
}