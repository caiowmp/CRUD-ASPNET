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
    public partial class GerenciamentoEditores : System.Web.UI.Page
    {
        EditoresDAO ioEditoresDAO = new EditoresDAO();
        public BindingList<Editores> ListaEditores
        {
            get
            {
                if ((BindingList<Editores>)ViewState["ViewStateListaEditores"] == null)
                    this.CarregaDados();

                return (BindingList<Editores>)ViewState["ViewStateListaEditores"];
            }
            set
            {
                ViewState["ViewStateListaEditores"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.CarregaDados();
        }

        private void CarregaDados()
        {
            this.ListaEditores = this.ioEditoresDAO.BuscaEditores();

            this.gvGerenciamentoEditores.DataSource = this.ListaEditores.OrderBy(loEditor => loEditor.edi_nm_editor);

            this.gvGerenciamentoEditores.DataBind();
        }

        protected void BtnNovoEditor_Click(Object sender, EventArgs e)
        {
            try
            {
                decimal ldcIdEditor = this.ListaEditores.OrderByDescending(a => a.edi_id_editores).First().edi_id_editores + 1;

                string lsNomeEditor = this.tbxCadastroNomeEditor.Text;
                string lsEmailEditor = this.tbxCadastroEmailEditor.Text;
                string lsUrlEditor = this.tbxCadastroUrlEditor.Text;

                Editores loEditor = new Editores(ldcIdEditor, lsNomeEditor, lsEmailEditor, lsUrlEditor);

                this.ioEditoresDAO.InsereEditor(loEditor);

                this.CarregaDados();
                HttpContext.Current.Response.Write("<script>alert('Editor cadastrado com sucesso!'); </script>");
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Erro no cadastro do Editor.'); </script>");
            }

            this.tbxCadastroNomeEditor.Text = String.Empty;
            this.tbxCadastroEmailEditor.Text = String.Empty;
            this.tbxCadastroUrlEditor.Text = String.Empty;
        }

        protected void gvGerenciamentoEditores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gvGerenciamentoEditores.EditIndex = e.NewEditIndex;
            this.CarregaDados();
        }

        protected void gvGerenciamentoEditores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.gvGerenciamentoEditores.EditIndex = -1;
            this.CarregaDados();
        }

        protected void gvGerenciamentoEditores_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            decimal ldcIdEditor = Convert.ToDecimal((this.gvGerenciamentoEditores.Rows[e.RowIndex]
                .FindControl("lblEditIdEditor") as Label).Text);
            string lsNomeEditor = (this.gvGerenciamentoEditores.Rows[e.RowIndex].FindControl("tbxEditNomeEditor") as TextBox).Text;
            string lsUrlEditor= (this.gvGerenciamentoEditores.Rows[e.RowIndex].FindControl("tbxEditUrlEditor") as TextBox).Text;
            string lsEmailEditor = (this.gvGerenciamentoEditores.Rows[e.RowIndex].FindControl("tbxEditEmailEditor") as TextBox).Text;

            if (String.IsNullOrWhiteSpace(lsNomeEditor))
                HttpContext.Current.Response.Write("<script>alert('Digite o nome do editor.');</script>");
            else if (String.IsNullOrWhiteSpace(lsEmailEditor))
                HttpContext.Current.Response.Write("<script>alert('Digite o Email do editor.');</script>");
            else if (String.IsNullOrWhiteSpace(lsUrlEditor))
                HttpContext.Current.Response.Write("<script>alert('Digite o a Url do editor.');</script>");
            else
            {
                try
                {
                    Editores loEditor = new Editores(ldcIdEditor, lsNomeEditor, lsEmailEditor, lsUrlEditor);

                    this.ioEditoresDAO.AtualizaEditor(loEditor);

                    this.gvGerenciamentoEditores.EditIndex = -1;

                    this.CarregaDados();
                    HttpContext.Current.Response.Write("<script>alert('Editor atualizado com sucesso!');</script>");
                }
                catch
                {
                    HttpContext.Current.Response.Write("<script>alert('Erro na atualização do cadastro do Editor.');</script>");
                }
            }
        }

        protected void gvGerenciamentoEditores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow loRGridViewRow = this.gvGerenciamentoEditores.Rows[e.RowIndex];
                decimal ldcIdEditor = Convert.ToDecimal((this.gvGerenciamentoEditores.Rows[e.RowIndex].FindControl("lblIdEditor") as Label).Text);
                Editores loEditor = this.ioEditoresDAO.BuscaEditores(ldcIdEditor).FirstOrDefault();

                if (loEditor != null)
                {
                    LivrosDAO loLivrosDAO = new LivrosDAO();

                    if(loLivrosDAO.BuscaLivrosEditor(loEditor).Count == 0)
                    {
                        EditoresDAO loEditoresDAO = new EditoresDAO();

                        if (loEditoresDAO.BuscaEditores(ldcIdEditor).Count != 0)
                        {
                            this.ioEditoresDAO.RemoveEditor(loEditor);
                            this.CarregaDados();
                            HttpContext.Current.Response.Write("<script>alert('Editor removido com sucesso!');</script>");
                        }
                    }
                    else
                    {
                        HttpContext.Current.Response.Write("<script>alert('Erro na remoção do editor selecionado. Existem livros associados a ele');</script>");
                    }
                }
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Erro na remoção do editor selecionado.');</script>");
            }
        }
    }
}