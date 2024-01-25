<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GerenciamentoCategorias.aspx.cs" Inherits="Modelo_ASP_NET.Livraria.GerenciamentoCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row" style="text-align: left;">
        <h2>Cadastro de nova Categoria</h2>

        <%--Tabela de cadastro de nova Categoria--%>
        <table>
            <tr style="display: grid;">
                <%--Cadastro nome Categoria--%>
                <td>
                    <asp:Label ID="lblCadastroNomeCategoria" runat="server" Font-Size="16pt" Text="Nome: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbxCadastroNomeCategoria" runat="server" CssClass="form-control" Height="35px"
                        Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="tbxCadastroNomeCategoria" Style="color: red;" 
                        ErrorMessage="* Digite o nome da categoria."></asp:RequiredFieldValidator>
                </td>

                <td>
                    <asp:Button ID="btnNovaCategoria" runat="server" CssClass="btn btn-sucess" Style="margin-top: 10px"
                        Text="Salvar" OnClick="BtnNovaCategoria_Click" />
                </td>
            </tr>
        </table>
    </div>

    <%-- Listagem de Categorias--%>
    <div class="row">
        <h2 style="text-align: center;">Lista de categorias cadastradas</h2>

        <asp:GridView ID="gvGerenciamentoCategorias" runat="server" Width="100%" AutoGenerateColumns="False" 
            Font-Size="14px" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="gvGerenciamentoCategorias_RowCancelingEdit" 
            OnRowEditing="gvGerenciamentoCategorias_RowEditing" OnRowUpdating="gvGerenciamentoCategorias_RowUpdating" 
            OnRowDeleting="gvGerenciamentoCategorias_RowDeleting">

            <Columns>
                <%-- ID Categoria--%>
                <asp:TemplateField Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="lblEditIdCategoria" runat="server" Text='<%# Eval("til_id_tipo_livro") %>'></asp:Label>
                    </EditItemTemplate>

                    <HeaderTemplate>
                        <asp:Label ID="lblTextoIdCategoria" runat="server" Style="width: 100%" Text="ID"></asp:Label>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lblIdCategoria" runat="server" Style="text-align: center;"
                            Text='<%# Eval("til_id_tipo_livro") %>'></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <%-- Nome Categoria--%>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditNomeCategoria" runat="server" CssClass="form-control" Heigh="35px"
                            MaxLength="15" Text='<%# Eval("til_ds_descricao") %>'></asp:TextBox>
                    </EditItemTemplate>

                    <HeaderTemplate>
                        <asp:Label ID="lblTextoNomeCategoria" runat="server" Style="text-align: center;"
                            Text="Nome"></asp:Label>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lblNomeCategoria" runat="server" Style="text-align: left;"
                        Text='<%# Eval("til_ds_descricao") %>'></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Left" Width="150px" />
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
                        <asp:Button ID="btnEditarCategoria" runat="server" CssClass="btn btn-success" Text="Editar"
                            CommandName="Edit" CausesValidation="false" />
                        <asp:Button ID="btnDeletarCategoria" runat="server" CssClass="btn btn-danger" Text="Deletar"
                            CommandName="Delete" CausesValidation="false" />
                    
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="center" Width="250px" />
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
