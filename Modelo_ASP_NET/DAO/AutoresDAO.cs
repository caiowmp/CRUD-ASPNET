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
    public class AutoresDAO
    {
        SqlCommand ioQuery;
        //Instanciando o objeto SqlConnection para abrir a conexão com o banco de dados
        SqlConnection ioConexao;

        public Autores BuscaAutoresNome(string nomeAutor)
        {
            Autores loAutor = new Autores(-1, "vazio", "vazio", "vazio");

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();

                    ioQuery = new SqlCommand("SELECT * FROM AUT_AUTORES WHERE AUT_NM_NOME = @nomeAutor", ioConexao);

                    ioQuery.Parameters.Add(new SqlParameter("@nomeAutor", nomeAutor));
                    
                    using (SqlDataReader loReader = ioQuery.ExecuteReader())
                    {
                        while (loReader.Read())
                        {
                            Autores loNovoAutor = new Autores(loReader.GetDecimal(0), loReader.GetString(1), loReader.GetString(2), loReader.GetString(3));

                            loAutor = loNovoAutor;
                        }

                        loReader.Close();
                    }
                }
                catch
                {
                    throw new Exception("Erro ao tentar buscar o autor");
                }
            }
            return loAutor;
        }
    

        public BindingList<Autores> BuscaAutores(decimal? aut_id_autor = null)
        {
            //Criando uma lista de autores que será retornada pela função
            BindingList<Autores> loListAutores = new BindingList<Autores>();

            //Criando conexão com o banco de daods, utilizando as informações que foram preenchidas
            // no Web.config na tag ConnectionStrings e nome ConnectionString
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    //Abrindo conexõa com o servidor
                    ioConexao.Open();

                    if (aut_id_autor != null)
                    {
                        //Montando a query que será executada para retornar o autor, caso tenha sido passado um ID.
                        ioQuery = new SqlCommand("SELECT * FROM AUT_AUTORES WHERE AUT_ID_AUTOR = @idAutor", ioConexao);

                        //Criando a variável @idAutor e setando o seu valor com o ID recebido por parâmetro pela função
                        ioQuery.Parameters.Add(new SqlParameter("@idAutor", aut_id_autor));
                    }
                    else
                    {
                        //Caso não seja passado nenhum ID, a query deve retornar todos os autores
                        ioQuery = new SqlCommand("SELECT * FROM AUT_AUTORES", ioConexao);
                    }
                    //Criando o bloco de leitura de dados do SQL server
                    using (SqlDataReader loReader = ioQuery.ExecuteReader())
                    {
                        //Chamando a função de leitura antes de acessar os dados (uma vez para cada linha retornada na consulta)
                        while (loReader.Read())
                        {
                            //Instanciando um objeto do tipo Autor e preenchendo suas propriedades com os valores retornados pela consulta
                            Autores loNovoAutor = new Autores(loReader.GetDecimal(0), loReader.GetString(1), loReader.GetString(2), loReader.GetString(3));

                            //Incluindo Autor na lista criada anteriormente
                            loListAutores.Add(loNovoAutor);
                        }
                        //fechando objeto de leitura
                        loReader.Close();
                    }
                }
                catch
                {
                    throw new Exception("Erro ao tentar buscar o(s) autor(es)");
                }
            }
            return loListAutores;
        }

        public int InsereAutor(Autores aoNovoAutor)
        {
            //Caso o Autor não venha preenchido, é lançada uma exceção do tipo NullReferenceException
            if (aoNovoAutor == null)
                throw new NullReferenceException();

            int liQtdRegistrosInseridos = 0;

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("INSERT INTO AUT_AUTORES(AUT_ID_AUTOR, AUT_NM_NOME, AUT_NM_SOBRENOME, AUT_DS_EMAIL) VALUES(@idAutor, @nomeAutor, @sobrenomeAutor, @emailAutor)", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idAutor", aoNovoAutor.aut_id_autor));
                    ioQuery.Parameters.Add(new SqlParameter("@nomeAutor", aoNovoAutor.aut_nm_nome));
                    ioQuery.Parameters.Add(new SqlParameter("@sobrenomeAutor", aoNovoAutor.aut_nm_sobrenome));
                    ioQuery.Parameters.Add(new SqlParameter("@emailAutor", aoNovoAutor.aut_ds_email));

                    //Executando o comando Transact-SQL e retornando a quantidade de linhas afetadas.
                    liQtdRegistrosInseridos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao tentar cadastrar novo Autor");
                }
            }
            return liQtdRegistrosInseridos;
        }

        public int RemoveAutor(Autores aoAutor)
        {
            if (aoAutor == null)
                throw new ArgumentNullException();

            int liQtdRegistrosInseridos = 0;

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("DELETE FROM AUT_AUTORES WHERE AUT_ID_AUTOR = @idAutor", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idAutor", aoAutor.aut_id_autor));

                    //Executando o comando Transact-SQL e retornando a quantidade de linhas afetadas.
                    liQtdRegistrosInseridos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao tentar excluir Autor");
                }
            }
            HttpContext.Current.Response.Write("<script>alert('Autor removido com sucesso.');</script>");
            return liQtdRegistrosInseridos;
        }

        public int AtualizaAutor(Autores aoAutor)
        {
            if (aoAutor == null)
                throw new ArgumentNullException();

            int liQtdRegistrosInseridos = 0;

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("UPDATE AUT_AUTORES SET AUT_NM_NOME = @nomeAutor, AUT_NM_SOBRENOME = @sobrenomeAutor, AUT_DS_EMAIL = @emailAutor WHERE AUT_ID_AUTOR = @idAutor", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idAutor", aoAutor.aut_id_autor));
                    ioQuery.Parameters.Add(new SqlParameter("@nomeAutor", aoAutor.aut_nm_nome));
                    ioQuery.Parameters.Add(new SqlParameter("@sobrenomeAutor", aoAutor.aut_nm_sobrenome));
                    ioQuery.Parameters.Add(new SqlParameter("@emailAutor", aoAutor.aut_ds_email));

                    //Executando o comando Transact-SQL e retornando a quantidade de linhas afetadas.
                    liQtdRegistrosInseridos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao tentar atualiza informações do Autor");
                }
            }
            return liQtdRegistrosInseridos;
        }
    }
}