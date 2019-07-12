<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ListarVentas.aspx.cs" Inherits="WebComercio.ListarVentas" %>

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
                    <div class="box-header">
                        <div class="mx-auto" style="width: 500px;">
                            <div class="row">
                                <div class="mx-auto" style="width: 100px;">
                                    <table>
                                        <tr>

                                            <td>
                                                <asp:Button ID="btnTodo" Text="Ver Todo" runat="server" CssClass="btn btn-primary" OnClick="btnTodo_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <table id="Calendarios" class="text-centered">
                                <tr>
                                    <td>
                                        <asp:Calendar ID="CalDesde" runat="server"></asp:Calendar>
                                    </td>
                                    <td>
                                        <asp:Calendar ID="CalHasta" runat="server"></asp:Calendar>
                                    </td>
                                </tr>
                            </table>

                        </div>

                        <div style="margin-left: auto; margin-right: auto; text-align: center">
                            <h3>Filtrar Por Cliente & Fechas</h3>
                            </style="margin-left:>
                                  
                        </div>

                        <div class="row">
                            <div class="mx-auto" style="width: 170px;">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtCliente" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnAceptar" Text="Aceptar" runat="server" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                                        </td>
                                    </tr>

                                </table>
                            </div>
                        </div>
                        <div class="row">
                        </div>
                        <div style="margin-left: auto; margin-right: auto; text-align: center">
                            <h3>Buscar Por Numero de Factura</h3>
                        </div>

                        <div class="row">
                            <div class="mx-auto" style="width: 170px;">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtNumFactura" type="number" runat="server"></asp:TextBox>
                                        </td>
                                        <td>

                                            <asp:Button ID="btnNumFact" Text="Aceptar" runat="server" CssClass="btn btn-primary" OnClick="btnNumFact_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <div class="col-2">
                                    <button type="button" class="btn btn-danger" onclick="descargar('pdf')">Exportar PDF</button>
                                </div>
                                <div class="col-2">
                                    <button type="button" class="btn btn-success" onclick="descargar('csv')">Exportar Excel</button>
                                </div>
                            </div>
                        </div>
                        <asp:GridView ID="dlListaVentas" runat="server" CssClass="table table-active " EmptyDataText="No Existen Registros"
                            GridLines="Horizontal" AutoGenerateColumns="false" OnSelectedIndexChanged="dlListaVentas_SelectedIndexChanged">
                            <HeaderStyle CssClass="" Font-Size="12px" />
                            <AlternatingRowStyle CssClass="" Font-Size="12px" />
                            <RowStyle Font-Size="12px" />
                            <Columns>
                                <asp:TemplateField HeaderText="FACTURA" HeaderStyle-Width="30px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblNumFact" Text='<%# Eval("NumFactura")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Cliente" HeaderStyle-Width="30px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCliente" Text='<%# Eval("Cliente")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Fecha" HeaderStyle-Width="30px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblFecha" Text='<%# Eval("Fecha")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Importe" HeaderStyle-Width="30px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblImporte" Text='<%# Eval("Importe")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="30px">
                                    <ItemTemplate>
                                        <a href="GenerarComprobante.aspx?Comprobante=<%# Eval("NumFactura") %>" class="btn btn-primary text-white">Generar Comprobante</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <div class="row bg-success text-white">
                            <div class="col-10">TOTAL</div>
                            <div class="col-2" id="total-ventas">$0</div>
                        </div>
                </div>
            </div>
        </div>
        </div>

    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server"></asp:Content>




