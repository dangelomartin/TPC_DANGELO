<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionUsuarios.aspx.cs" Inherits="WebComercio.GestionUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="content-header">
        <h1 style="text-align: center">Ventas</h1>
    </section>
    <section class="content">
        <div class="row">
            <div class="col">
                <div class="box box-primary">
                        <asp:GridView ID="dlUsuarios" runat="server" CssClass="table table-active " EmptyDataText="No Existen Registros"
                            GridLines="Horizontal" AutoGenerateColumns="false" >
                            <HeaderStyle CssClass="" Font-Size="12px" />
                            <AlternatingRowStyle CssClass="" Font-Size="12px" />
                            <RowStyle Font-Size="12px" />
                            <Columns>
                                <asp:TemplateField HeaderText="Usuario" HeaderStyle-Width="30px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblUsuario" Text='<%# Eval("usuario")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Contraseña" HeaderStyle-Width="30px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPasss" Text='<%# Eval("pass")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Intentos" HeaderStyle-Width="30px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblIntentos" Text='<%# Eval("intentos")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Tipo" HeaderStyle-Width="30px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblTipo" Text='<%# Eval("tipo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Tipo" HeaderStyle-Width="30px">
                                    <ItemTemplate>
                                    <a href="EditarUsuario.aspx?usuario=<%# Eval("usuario") %>" class="btn btn-primary text-white">Editar</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                           
                            </Columns>
                        </asp:GridView>
                   
                </div>
            </div>
        </div>
        <div class="row">
            <div class="mx-auto" style="width: 170px;">
                <table>
                    <tr>
                        <td>                              
                   
                        </td>
                        <td>
                            
                        </td>
                    </tr>
                </table>
            </div>
            </div>
        <div class="row">
            <div class="mx-auto" style="width: 170px;">
                <table>
                    <tr>
                        <td>                              
                            <asp:Button ID="btnAceptar" Text="Aceptar" runat="server" CssClass="btn btn-primary"  />
                        </td>
                        <td>
                            <asp:Button ID="Cancelar" Text="Cancelar" runat="server" CssClass="btn btn-primary" />
                        </td>
                        <td>
                            <asp:Button ID="Button1" Text="Cancelar" runat="server" CssClass="btn btn-primary" />
                        </td>
                    </tr>
                </table>
            </div>
            </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">

</asp:Content>
