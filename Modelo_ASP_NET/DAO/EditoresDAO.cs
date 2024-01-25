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
    public class EditoresDAO
    {
        SqlCommand ioQuery;

        SqlConnection ioConexao;

        public Editores BuscaEditorNome(string edi_nm_editor)
        {
            Editores loEditor = new Editores(-1, "vazio", "vazio", "vazio");

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();

                    ioQuery = new SqlCommand("SELECT * FROM EDI_EDITORES WHERE EDI_NM_EDITOR = @nomeEditor", ioConexao);

                    ioQuery.Parameters.Add(new SqlParameter("@nomeEditor", edi_nm_editor));


                    using (SqlDataReader loReader = ioQuery.ExecuteReader())
                    {
                        while (loReader.Read())
                        {
                            Editores loNovoEditor = new Editores(loReader.GetDecimal(0), loReader.GetString(1), loReader.GetString(2), loReader.GetString(3));

                            loEditor = loNovoEditor;
                        }
                        loReader.Close();
                    }
                }
                catch
                {
                    throw new Exception("Erro ao tentar buscar o(s) editor(es)");
                }
            }
            return loEditor;
        }
    

        public BindingList<Editores> BuscaEditores(decimal? edi_id_editor = null)
        {
            BindingList<Editores> loListEditores = new BindingList<Editores>();

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();

                    if (edi_id_editor != null)
                    {
                        ioQuery = new SqlCommand("SELECT * FROM EDI_EDITORES WHERE EDI_ID_EDITOR = @idEditor", ioConexao);

                        ioQuery.Parameters.Add(new SqlParameter("@idEditor", edi_id_editor));
                    }
                    else
                    {
                        ioQuery = new SqlCommand("SELECT * FROM EDI_EDITORES", ioConexao);
                    }

                    using (SqlDataReader loReader = ioQuery.ExecuteReader())
                    {
                        while (loReader.Read())
                        {
                            Editores loNovoEditor = new Editores(loReader.GetDecimal(0), loReader.GetString(1), loReader.GetString(2), loReader.GetString(3));

                            loListEditores.Add(loNovoEditor);
                        }
                        loReader.Close();
                    }
                }
                catch
                {
                    throw new Exception("Erro ao tentar buscar o(s) editor(es)");
                }
            }
            return loListEditores;
        }

        public int InsereEditor(Editores aoNovoEditor)
        {
            if (aoNovoEditor == null)
                throw new NullReferenceException();

            int liQtdRegistrosInseridos = 0;

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("INSERT INTO EDI_EDITORES(EDI_ID_EDITOR, EDI_NM_EDITOR, EDI_DS_EMAIL, EDI_DS_URL) VALUES(@idEditor, @nomeEditor, @emailEditor, @urlEditor)", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idEditor", aoNovoEditor.edi_id_editores));
                    ioQuery.Parameters.Add(new SqlParameter("@nomeEditor", aoNovoEditor.edi_nm_editor));
                    ioQuery.Parameters.Add(new SqlParameter("@emailEditor", aoNovoEditor.edi_ds_email));
                    ioQuery.Parameters.Add(new SqlParameter("@urlEditor", aoNovoEditor.edi_ds_url));

                    //Executando o comando Transact-SQL e retornando a quantidade de linhas afetadas.
                    liQtdRegistrosInseridos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao tentar cadastrar novo Editor");
                }
            }
            return liQtdRegistrosInseridos;
        }

        public int RemoveEditor(Editores aoEditor)
        {
            if (aoEditor == null)
                throw new ArgumentNullException();

            int liQtdRegistrosInseridos = 0;

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("DELETE FROM EDI_EDITORES WHERE EDI_ID_EDITOR = @idEditor", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idEditor", aoEditor.edi_id_editores));

                    liQtdRegistrosInseridos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao tentar excluir Editor");
                }
            }
            return liQtdRegistrosInseridos;
        }

        public int AtualizaEditor(Editores aoEditor)
        {
            if (aoEditor == null)
                throw new ArgumentNullException();

            int liQtdRegistrosInseridos = 0;

            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("UPDATE EDI_EDITORES SET EDI_NM_EDITOR = @nomeEditor, EDI_DS_EMAIL = @emailEditor, EDI_DS_URL = @urlEditor WHERE EDI_ID_EDITOR = @idEditor", ioConexao);
                    ioQuery.Parameters.Add(new SqlParameter("@idEditor", aoEditor.edi_id_editores));
                    ioQuery.Parameters.Add(new SqlParameter("@nomeEditor", aoEditor.edi_nm_editor));
                    ioQuery.Parameters.Add(new SqlParameter("@emailEditor", aoEditor.edi_ds_email));
                    ioQuery.Parameters.Add(new SqlParameter("@urlEditor", aoEditor.edi_ds_url));

                    //Executando o comando Transact-SQL e retornando a quantidade de linhas afetadas.
                    liQtdRegistrosInseridos = ioQuery.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao tentar atualizar as informações do Editor");
                }
            }
            return liQtdRegistrosInseridos;
        }
    }
}