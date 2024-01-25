<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GerenciamentoEditores.aspx.cs" Inherits="Modelo_ASP_NET.Livraria.GerenciamentoEditores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row" style="text-align: left;">
        <h2>Cadastro de novo Editor</h2>

        <%--Tabela de cadastro de novo Editor--%>
        <table>
            <tr class="row row-cols-6">
                <%--Cadastro nome Editor--%>
                <td class="col">
                    <asp:Label ID="lblCadastroNomeEditor" runat="server" Font-Size="16pt" Text="Nome: "></asp:Label>
                </td>
                <td class="col">
                    <asp:TextBox ID="tbxCadastroNomeEditor" runat="server" CssClass="form-control" Height="35px"
                        Width="400px" Style="margin: 10px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="tbxCadastroNomeEditor" Style="color: red;" 
                        ErrorMessage="* Digite o nome do editor."></asp:RequiredFieldValidator>
                </td>

                <%--Cadastro Email Editor--%>
                <td class="col">
                    <asp:Label ID="lblCadastroEmailEditor" runat="server" Font-Size="16pt" Text="E-mail: "></asp:Label>
                </td>
                <td class="col">
                    <asp:TextBox ID="tbxCadastroEmailEditor" runat="server" CssClass="form-control" Height="35px"
                        Width="400px" Style="margin: 10px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="tbxCadastroEmailEditor" Style="color: red;" 
                        ErrorMessage="* Digite o E-mail do editor."></asp:RequiredFieldValidator>
                </td>

                <%--Cadastro Url Editor--%>
                <td class="col">
                    <asp:Label ID="lblCadastroUrlEditor" runat="server" Font-Size="16pt" Text="Url: "></asp:Label>
                </td>
                <td class="col">
                    <asp:TextBox ID="tbxCadastroUrlEditor" runat="server" CssClass="form-control" Height="35px"
                        Width="400px" Style="margin: 10px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="tbxCadastroUrlEditor" Style="color: red;" 
                        ErrorMessage="* Digite o Url do editor."></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Button ID="btnNovoEditor" runat="server" CssClass="btn btn-sucess" Style="margin-top: 10px"
                        Text="Salvar" OnClick="BtnNovoEditor_Click" />
                </td>
            </tr>
        </table>
    </div>

    <%-- Listagem de Editores--%>
    <div class="row">
        <h2 style="text-align: center;">Lista de editores cadastrados</h2>

        <asp:GridView ID="gvGerenciamentoEditores" runat="server" Width="100%" AutoGenerateColumns="False" 
            Font-Size="14px" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="gvGerenciamentoEditores_RowCancelingEdit" 
            OnRowEditing="gvGerenciamentoEditores_RowEditing" OnRowUpdating="gvGerenciamentoEditores_RowUpdating" 
            OnRowDeleting="gvGerenciamentoEditores_RowDeleting">

            <Columns>
                <%-- ID Editor--%>
                <asp:TemplateField Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="lblEditIdEditor" runat="server" Text='<%# Eval("edi_id_editores") %>'></asp:Label>
                    </EditItemTemplate>

                    <HeaderTemplate>
                        <asp:Label ID="lblTextoIdEditor" runat="server" Style="width: 100%" Text="ID"></asp:Label>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lblIdEditor" runat="server" Style="text-align: center;"
                            Text='<%# Eval("edi_id_editores") %>'></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <%-- Nome Editor --%>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditNomeEditor" runat="server" CssClass="form-control" Heigh="35px"
                            MaxLength="15" Text='<%# Eval("edi_nm_editor") %>'></asp:TextBox>
                    </EditItemTemplate>

                    <HeaderTemplate>
                        <asp:Label ID="lblTextoNomeEditor" runat="server" Style="text-align: center;"
                            Text="Nome"></asp:Label>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lblNomeEditor" runat="server" Style="text-align: left;"
                        Text='<%# Eval("edi_nm_editor") %>'></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Left" Width="150px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <%-- E-mail Editor --%>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditEmailEditor" runat="server" CssClass="form-control" Heigh="35px"
                            MaxLength="45" Text='<%# Eval("edi_ds_email") %>'></asp:TextBox>
                    </EditItemTemplate>

                    <HeaderTemplate>
                        <asp:Label ID="lblTextoEmailEditor" runat="server" Style="text-align: center;"
                            Text="E-mail"></asp:Label>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lblEmailEditor" runat="server" Style="text-align: center;"
                        Text='<%# Eval("edi_ds_email") %>'></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Left" Width="400px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <%-- Url Editor --%>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditUrlEditor" runat="server" CssClass="form-control" Heigh="35px"
                            MaxLength="50" Text='<%# Eval("edi_ds_url") %>'></asp:TextBox>
                    </EditItemTemplate>

                    <HeaderTemplate>
                        <asp:Label ID="lblTextUrlEditor" runat="server" Style="text-align: center;"
                            Text="Url"></asp:Label>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lblUrlEditor" runat="server" Style="text-align: center;"
                        Text='<%# Eval("edi_ds_url") %>'></asp:Label>
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
                        <asp:Button ID="btnEditarEditor" runat="server" CssClass="btn btn-success" Text="Editar"
                            CommandName="Edit" CausesValidation="false" />
                        <asp:Button ID="btnDeletarEditor" runat="server" CssClass="btn btn-danger" Text="Deletar"
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
