<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Gestion de Clientes.aspx.cs" Inherits="WebComercio.Gestion_de_Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1 style="text-align: center">Registro de Clientes</h1>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>NOMBRE</label>
                            <asp:TextBox ID="txtNombre" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>DIRECCION</label>
                            <asp:TextBox ID="txtDireccion" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>CP</label>
                            <asp:TextBox ID="txtCP" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Provincia</label>
                            <asp:DropDownList ID="ListProvincia" runat="server" CssClass="form-control" OnSelectedIndexChanged="ListProvincia_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <div class="form-group">
                                <label>TELEFONO</label>
                                <asp:TextBox ID="txtTelefono" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>EMAIL</label>
                                <asp:TextBox ID="txtEmail" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>CONTRIBUYENTE</label>
                                <asp:DropDownList ID="ListContri" runat="server" CssClass="form-control" OnSelectedIndexChanged="ListContri_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label>Observaciones</label>
                                <asp:TextBox ID="txtObs" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="mx-auto" style="width: 170px;">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnAceptar" Text="Aceptar" runat="server" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Cancelar" Text="Cancelar" runat="server" CssClass="btn btn-primary" />
                        </td>
                    </tr>
                </table>

            </div>
        </div>
        </section>
        <section class="content">
        <div class="row">
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-body">
                    <div class="form-group">
                        <div class="form-group">
                            <label>Buscar Cliente Para Modificar</label>
                            <asp:TextBox ID="txtClienteABuscar" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                            <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-body">
                    <div class="form-group">
                        <div class="form-group">
                            <label>Buscar Cliente Para Modificar</label>
                            <asp:DropDownList ID="ListaCliente" runat="server" CssClass="form-control" OnSelectedIndexChanged="ListContri_SelectedIndexChanged"></asp:DropDownList>
                            <asp:Button ID="btnSeleccionar" Text="Seleccionar Cliente" runat="server" CssClass="btn btn-primary" OnClick="btnSeleccionar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
            </div>
    </section>
    
</asp:Content>
