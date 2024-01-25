<%@ Page Title="Gerenciamento de Livros" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="GerenciamentoLivros.aspx.cs" Inherits="Modelo_ASP_NET.Livraria.GerenciamentoLivros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row" style="text-align: left;">
        <h2>Cadastro de novo Livro</h2>

        <%--Tabela de cadastro de novo Livro--%>
        <table>
            <tr class="row row-cols-6">
                <%--Cadastro título Livro--%>
                <td class="col">
                    <asp:Label ID="lblCadastroTituiloLivro" runat="server" Font-Size="14pt" Text="Título: "></asp:Label>
                </td>
                <td class="col">
                    <asp:TextBox ID="tbxCadastroTituiloLivro" runat="server" CssClass="form-control" Height="35px"
                        Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="tbxCadastroTituiloLivro" Style="color: red;" 
                        ErrorMessage="* Digite o título do livro."></asp:RequiredFieldValidator>
                </td>

                <%--Cadastro Categoria Livro--%>
                <td class="col">
                    <asp:Label ID="lblCadastroCategoriaLivro" runat="server" Font-Size="14pt" Text="Categoria: "></asp:Label>
                </td>
                <td class="col">
                    <asp:DropDownList ID="ddlCadastroCategoriaLivro" runat="server" SelectionMode="Single" Font-Size="14pt" Height="35px" Width="400px" AutoPostBack="true" OnSelectedIndexChanged="ddlCadastroCategoriaLivro_SelectedIndexChanged"/>
                    <asp:TextBox ID="tbxCadastroNomeNovaCategoria" runat="server" Visible="false" CssClass="form-control" Height="35px" Width="400px"></asp:TextBox>               
                </td>

                <%--Cadastro Autor Livro--%>
                <td class="col">
                    <asp:Label ID="lblCadastroNomeAutorLivro" runat="server" Font-Size="14pt" Text="Autor: "></asp:Label>
                </td>
                <td class="col">
                    <asp:DropDownList ID="ddlCadastroNomeAutorLivro" runat="server" SelectionMode="Single" Font-Size="14pt" Height="35px" Width="400px" AutoPostBack="true" OnSelectedIndexChanged="ddlCadastroNomeAutorLivro_SelectedIndexChanged"/>
                    <asp:TextBox ID="tbxCadastroNomeNovoAutor" runat="server" Visible="false" CssClass="form-control" Height="35px" Width="400px"></asp:TextBox>
                </td>
            </tr>

            <tr class="row row-cols-6">
                <%--Cadastro Editor Livro--%>
                <td class="col">
                    <asp:Label ID="lblCadastroEditorLivro" runat="server" Font-Size="14pt" Text="Editor: "></asp:Label>
                </td>
                <td class="col">
                    <asp:DropDownList ID="ddlCadastroEditorLivro" runat="server" SelectionMode="Single" Font-Size="14pt" Height="35px" Width="400px" AutoPostBack="true" OnSelectedIndexChanged="ddlCadastroEditorLivro_SelectedIndexChanged"/>
                    <asp:TextBox ID="tbxCadastroNomeNovoEditor" runat="server" Visible="false" CssClass="form-control" Height="35px" Width="400px"></asp:TextBox>
                </td>

                <%--Cadastro Preço Livro--%>
                <td class="col">
                    <asp:Label ID="lblCadastroPrecoLivro" runat="server" Font-Size="14pt" Text="Preço: "></asp:Label>
                </td>
                <td class="col">
                    <asp:TextBox ID="tbxCadastroPrecoLivro" runat="server" CssClass="form-control" Height="35px"
                        Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="tbxCadastroPrecoLivro" Style="color: red;" 
                        ErrorMessage="* Digite o preço do livro."></asp:RequiredFieldValidator>
                </td>

                <%--Cadastro Royalty Livro--%>
                <td class="col">
                    <asp:Label ID="lblCadastroRoyaltyLivro" runat="server" Font-Size="14pt" Text="Royalty: "></asp:Label>
                </td>
                <td class="col">
                    <asp:TextBox ID="tbxCadastroRoyaltyLivro" runat="server" CssClass="form-control" Height="35px"
                        Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="tbxCadastroRoyaltyLivro" Style="color: red;" 
                        ErrorMessage="* Digite o royalty do livro."></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr class="row row-cols-6">
                <%--Cadastro Resumo Livro--%>
                <td class="col">
                    <asp:Label ID="lblCadastroResumoLivro" runat="server" Font-Size="14pt" Text="Resumo: "></asp:Label>
                </td>
                <td class="col">
                    <asp:TextBox ID="tbxCadastroResumoLivro" runat="server" CssClass="form-control" Height="35px"
                        Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="tbxCadastroResumoLivro" Style="color: red;" 
                        ErrorMessage="* Digite o resumo do livro."></asp:RequiredFieldValidator>
                </td>

                <%--Cadastro Num Edição Livro--%>
                <td class="col">
                    <asp:Label ID="lblNuEdicaoLivro" runat="server" Font-Size="14pt" Text="Nº Edição:"></asp:Label>
                </td>
                <td class="col">
                    <asp:TextBox ID="tbxCadastroNuEdicaoLivro" runat="server" CssClass="form-control" Height="35px"
                        Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="tbxCadastroNuEdicaoLivro" Style="color: red;" 
                        ErrorMessage="* Digite o número de edição do livro."></asp:RequiredFieldValidator>
                </td>
           
                <td class ="col"></td>
                <td>
                    <asp:Button ID="btnNovoLivro" runat="server" CssClass="btn btn-sucess" Style="margin-top: 10px"
                        Text="Salvar" OnClick="BtnNovoLivro_Click" />
                </td>
            </tr>
        </table>
    </div>

    <%-- Listagem de Livros--%>
    <div class="row">
        <h2 style="text-align: center;">Lista de livros cadastrados</h2>

        <asp:GridView ID="gvGerenciamentoLivros" runat="server" Width="100%" AutoGenerateColumns="False" 
            Font-Size="14px" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="gvGerenciamentoLivros_RowCancelingEdit" 
            OnRowEditing="gvGerenciamentoLivros_RowEditing" OnRowUpdating="gvGerenciamentoLivros_RowUpdating" 
            OnRowDeleting="gvGerenciamentoLivros_RowDeleting" OnRowDataBound="gvGerenciamentoLivros_RowDataBound">

            <Columns>
                <%-- ID Livro--%>
                <asp:TemplateField Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="lblEditIdLivro" runat="server" Text='<%# Eval("liv_id_livro") %>'></asp:Label>
                    </EditItemTemplate>

                    <HeaderTemplate>
                        <asp:Label ID="lblTextoIdLivro" runat="server" Style="width: 100%" Text="ID"></asp:Label>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lblIdLivro" runat="server" Style="text-align: center;"
                            Text='<%# Eval("liv_id_livro") %>'></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <%-- ID Categoria Livro --%>
                <asp:TemplateField Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditIDCategoriaLivro" runat="server" CssClass="form-control" Heigh="35px"
                            MaxLength="45" Text='<%# Eval("liv_id_tipo_livro") %>'></asp:TextBox>
                    </EditItemTemplate>

                    <HeaderTemplate>
                        <asp:Label ID="lblTextoIDCategoriaLivro" runat="server" Style="text-align: center;"
                            Text="ID Categoria"></asp:Label>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lblIDCategoriaLivro" runat="server" Style="text-align: center;"
                        Text='<%# Eval("liv_id_tipo_livro") %>'></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Left" Width="400px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <%-- ID Editor Livro--%>
                <asp:TemplateField Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditIDEditorLivro" runat="server" CssClass="form-control" Heigh="35px"
                            MaxLength="50" Text='<%# Eval("liv_id_editor") %>'></asp:TextBox>
                    </EditItemTemplate>

                    <HeaderTemplate>
                        <asp:Label ID="lblTextIDEditorLivro" runat="server" Style="text-align: center;"
                            Text="ID Editor"></asp:Label>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lblIDEditorLivro" runat="server" Style="text-align: center;"
                        Text='<%# Eval("liv_id_editor") %>'></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Left" Width="450px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <%-- Título Livro --%>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditTituloLivro" runat="server" CssClass="form-control" Heigh="35px"
                            MaxLength="15" Text='<%# Eval("liv_nm_titulo") %>'></asp:TextBox>
                    </EditItemTemplate>

                    <HeaderTemplate>
                        <asp:Label ID="lblTextoTituiloLivro" runat="server" Style="text-align: center;"
                            Text="Tituilo"></asp:Label>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lblTituiloLivro" runat="server" Style="text-align: left;"
                        Text='<%# Eval("liv_nm_titulo") %>'></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Left" Width="150px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <%-- Categoria Livro --%>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlEditCategoriaLivro" runat="server" CssClass="form-control" Heigh="35px"
                            MaxLength="50" SelectionMode="Single" AutoPostBack="true" ></asp:DropDownList>
                    </EditItemTemplate>

                    <HeaderTemplate>
                        <asp:Label ID="lblTextoCategoriaLivro" runat="server" Style="text-align: center;"
                            Text="Categoria"></asp:Label>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lblCategoriaLivro" runat="server" Style="text-align: center;"
                        Text='<%# Eval("liv_nm_categoria") %>'></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Left" Width="400px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <%-- Editor Livro--%>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlEditEditorLivro" runat="server" CssClass="form-control" Heigh="35px"
                            MaxLength="50" SelectionMode="Single" AutoPostBack="true" ></asp:DropDownList>
                    </EditItemTemplate>

                    <HeaderTemplate>
                        <asp:Label ID="lblTextEditorLivro" runat="server" Style="text-align: center;"
                            Text="Editor"></asp:Label>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lblEditorLivro" runat="server" Style="text-align: center;"
                        Text='<%# Eval("liv_nm_editor") %>'></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Left" Width="450px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <%-- Resumo Livro --%>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditResumoLivro" runat="server" CssClass="form-control" Heigh="35px"
                            MaxLength="50" Text='<%# Eval("liv_ds_resumo") %>'></asp:TextBox>
                    </EditItemTemplate>

                    <HeaderTemplate>
                        <asp:Label ID="lblTextResumoLivro" runat="server" Style="text-align: center;"
                            Text="Resumo"></asp:Label>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lblResumoLivro" runat="server" Style="text-align: center;"
                        Text='<%# Eval("liv_ds_resumo") %>'></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Left" Width="450px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <%-- Preço Livro --%>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditPrecoLivro" runat="server" CssClass="form-control" Heigh="35px"
                            MaxLength="50" Text='<%# Eval("liv_vl_preco") %>'></asp:TextBox>
                    </EditItemTemplate>

                    <HeaderTemplate>
                        <asp:Label ID="lblTextPrecoLivro" runat="server" Style="text-align: center;"
                            Text="Preço"></asp:Label>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lblPrecoLivro" runat="server" Style="text-align: center;"
                        Text='<%# Eval("liv_vl_preco") %>'></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Left" Width="450px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <%-- Royalty Livro --%>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditRoyaltyLivro" runat="server" CssClass="form-control" Heigh="35px"
                            MaxLength="50" Text='<%# Eval("liv_pc_royalty") %>'></asp:TextBox>
                    </EditItemTemplate>

                    <HeaderTemplate>
                        <asp:Label ID="lblTextRoyaltyLivro" runat="server" Style="text-align: center;"
                            Text="Royalty"></asp:Label>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lblRoyaltyLivro" runat="server" Style="text-align: center;"
                        Text='<%# Eval("liv_pc_royalty") %>'></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Left" Width="450px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <%-- Nu Edição Livro --%>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditNuEdicaoLivro" runat="server" CssClass="form-control" Heigh="35px"
                            MaxLength="50" Text='<%# Eval("liv_nu_edicao") %>'></asp:TextBox>
                    </EditItemTemplate>

                    <HeaderTemplate>
                        <asp:Label ID="lblTextNuEdicaoLivro" runat="server" Style="text-align: center;"
                            Text="Nu Edição"></asp:Label>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lblNuEdicaoLivro" runat="server" Style="text-align: center;"
                        Text='<%# Eval("liv_nu_edicao") %>'></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Left" Width="450px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <%-- Buttons --%>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-success" Text="Atualizar"
                            CommandName="Update" CausesValidation="false" />
                        <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar"
                            CommandName="Cancel" CausesValidation="false" />
                    </EditItemTemplate>
                    
                    <ItemTemplate>
                        <asp:Button ID="btnEditarLivro" runat="server" CssClass="btn btn-success" Text="Editar"
                            CommandName="Edit" CausesValidation="false" Width="150px" />
                        <asp:Button ID="btnDeletarLivro" runat="server" CssClass="btn btn-danger" Text="Deletar"
                            CommandName="Delete" CausesValidation="false" Width="150px" />                   
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="center" Width="250px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
            </Columns>
            
            <AlternatingRowStyle BackCOlor="White" />
            <EditRowStyle BackColor="#2461BF" Font-Size="14px" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle HorizontalAlign="Center" Wrap="True" BackColor="#507CD1" Font-Bold="True"
                ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Size="14px" />
            <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>
            <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>
            <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>
            <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
        </asp:GridView>
    </div>
</asp:Content>