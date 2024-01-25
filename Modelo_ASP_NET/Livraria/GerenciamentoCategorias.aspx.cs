using Modelo_ASP_NET.DAO;
using Modelo_ASP_NET.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modelo_ASP_NET.Livraria
{
    public partial class GerenciamentoCategoria : System.Web.UI.Page
    {
        TipoLivroDAO ioTipoLivroDAO = new TipoLivroDAO();
        public BindingList<TipoLivro> ListaTipoLivro
        {
            get
            {
                if ((BindingList<TipoLivro>)ViewState["ViewStateListaTipoLivro"] == null)
                    this.CarregaDados();

                return (BindingList<TipoLivro>)ViewState["ViewStateListaTipoLivro"];
            }
            set
            {
                ViewState["ViewStateListaTipoLivro"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.CarregaDados();
        }

        private void CarregaDados()
        {
            this.ListaTipoLivro = this.ioTipoLivroDAO.BuscaTipoLivro();

            this.gvGerenciamentoCategorias.DataSource = this.ListaTipoLivro.OrderBy(loTipoLivro => loTipoLivro.til_ds_descricao);

            this.gvGerenciamentoCategorias.DataBind();
        }

        protected void BtnNovaCategoria_Click(Object sender, EventArgs e)
        {
            try
            {
                decimal ldcIdCategoria = this.ListaTipoLivro.OrderByDescending(a => a.til_id_tipo_livro).First().til_id_tipo_livro + 1;

                string lsNomeCategoria = this.tbxCadastroNomeCategoria.Text;

                TipoLivro loTipoLivro = new TipoLivro(ldcIdCategoria, lsNomeCategoria);

                this.ioTipoLivroDAO.InsereTipoLivro(loTipoLivro);

                this.CarregaDados();
                HttpContext.Current.Response.Write("<script>alert('Categoria cadastrada com sucesso!'); </script>");
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Erro no cadastro da Categoria.'); </script>");
            }

            this.tbxCadastroNomeCategoria.Text = String.Empty;

        }

        protected void gvGerenciamentoCategorias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gvGerenciamentoCategorias.EditIndex = e.NewEditIndex;
            this.CarregaDados();
        }

        protected void gvGerenciamentoCategorias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.gvGerenciamentoCategorias.EditIndex = -1;
            this.CarregaDados();
        }

        protected void gvGerenciamentoCategorias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            decimal ldcIdEditor = Convert.ToDecimal((this.gvGerenciamentoCategorias.Rows[e.RowIndex].FindControl("lblEditIdCategoria") as Label).Text);
            string lsNomeCategoria = (this.gvGerenciamentoCategorias.Rows[e.RowIndex].FindControl("tbxEditNomeCategoria") as TextBox).Text;

            if (String.IsNullOrWhiteSpace(lsNomeCategoria))
                HttpContext.Current.Response.Write("<script>alert('Digite o nome da categoria.');</script>");
            else
            {
                try
                {
                    TipoLivro loTipoLivro = new TipoLivro(ldcIdEditor, lsNomeCategoria);

                    this.ioTipoLivroDAO.AtualizaTipoLivro(loTipoLivro);

                    this.gvGerenciamentoCategorias.EditIndex = -1;

                    this.CarregaDados();
                    HttpContext.Current.Response.Write("<script>alert('Categoria atualizada com sucesso!');</script>");
                }
                catch
                {
                    HttpContext.Current.Response.Write("<script>alert('Erro na atualização do cadastro da Categoria.');</script>");
                }
            }
        }

        protected void gvGerenciamentoCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow loRGridViewRow = this.gvGerenciamentoCategorias.Rows[e.RowIndex];
                decimal ldcIdCategoria = Convert.ToDecimal((this.gvGerenciamentoCategorias.Rows[e.RowIndex].FindControl("lblIdCategoria") as Label).Text);
                TipoLivro loTipoLivro = this.ioTipoLivroDAO.BuscaTipoLivro(ldcIdCategoria).FirstOrDefault();
                LivrosDAO loLivrosDAO = new LivrosDAO();

                if(loLivrosDAO.BuscaLivrosCategoria(ldcIdCategoria).Count == 0)
                {
                    if (loTipoLivro != null)
                    {
                        TipoLivroDAO loTipoLivroDAO = new TipoLivroDAO();

                        if (loTipoLivroDAO.BuscaTipoLivro(ldcIdCategoria).Count != 0)
                        {
                            this.ioTipoLivroDAO.RemoveTiopoLivro(loTipoLivro);
                            this.CarregaDados();
                            HttpContext.Current.Response.Write("<script>alert('Categoria removida com sucesso!');</script>");
                        }
                    }
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>alert('Erro na remoção da categoria selecionada. Existe(m) livro(s) associado(s) à categoria');</script>");
                }
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Erro na remoção da categoria selecionada.');</script>");
            }
        }
    }
}