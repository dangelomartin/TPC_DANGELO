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
                            <tfoot>
                                <tr>
                                    <th colspan="4" style="text-align: right">Total:</th>
                                    <th id="totalFinal"></th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
              
       
        
                </div>
            </div>
        </div>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
