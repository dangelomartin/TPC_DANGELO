<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EditarUsuario.aspx.cs" Inherits="WebComercio.EditarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
            <div class="mx-auto" style="width: 170px;">
                 <table>
                    <tr>
                        <td>                              
                            <asp:Label ID="lbl1" runat="server" Text="Usuario :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblUsuario" runat="server" Text="Label"></asp:Label>
                            
                        </td>
                       
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>                              
                            <asp:Label ID="Lbl2" runat="server" Text="Contraseña: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Tntentos: "></asp:Label>
                        </td>
                         <td>
                           <asp:TextBox ID="txtIntentos" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
