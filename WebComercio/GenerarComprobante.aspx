<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GenerarComprobante.aspx.cs" Inherits="WebComercio.GenerarComprobante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-12">
            <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title">Detalle Comprobante</h3>
                </div>
                <div class="row">
                    <div class="col-2"><a href="ListarVentas.aspx" class="btn btn-success">Volver</a></div>
                    <div class="col-2">N° de Comprobante: <span><%=comprobante%></span></div>
                    <div class="col-2">Cliente: <span id="cliente"></span></div>
                    <div class="col-2">CUIT: <span id="cuit"></span></div>
                    <div class="col-2">Fecha: <span id="fecha"></span></div>
                </div>
                <div class="box-body table-responsive">
                    <table id="tl-Detalle" class="table table-bordered table-hover text-center">
                        <thead>
                            <tr>
                                <th>Cant</th>
                                <th>Cod</th>
                                <th>Descripcion</th>
                                <th>P.U.</th>
                                <th>Total</th>
                            </tr>
                        </thead>
                    </table>
                </div>

                <button type="button" class="btn btn-danger" onclick="descargar('pdf', 'tl-Detalle')">Exportar PDF</button>

            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script>const algo = <%= comprobante %></script>
</asp:Content>
