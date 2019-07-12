function descargar(tipo, target = 'ContentPlaceHolder1_dlListaVentas') {
    $("#" + target).tableHTMLExport({
        type: tipo,
        filename: 'Reporte.' + tipo
    });

}
var final = 0;

function addRowDT(data) {
    tabla = $("#tl-Detalle").DataTable();
    for (var i = 0; i < data.length; i++) {
        tabla.fnAddData([
            data[i].cant,
            data[i].cod,
            data[i].Descripcion,
            data[i].PU,
            data[i].Total,
            
        ]); 
        
    }

    var totalFinal = 0;
    var children = $("tbody")[0].children;
    for(var i = 0; i < children.length; i++) {
        totalFinal += parseFloat(children[i].children[4].innerText)
    }

    $("tbody").append('<tr style="background-color: aliceblue;"><td></td><td></td><td></td><td>TOTAL</td><td>' + "$" + totalFinal + '</td></tr>')
        .append('<tr style="display:none"><td colspan="5" class="text-left"><p>Cliente: <span id="clienteth"></span></p></td></tr>')
        .append('<tr style="display:none"><td colspan="5" class="text-left"><p>Comprobante N° <span>' + algo + '</span></p></td></tr>')
        .append('<tr style="display:none"><td colspan="5" class="text-left"><p>CUIT: <span id="cuitth"></span></p></td></tr>')
        .append('<tr style="display:none"><td colspan="5" class="text-left"><p>Fecha: <span id="fechath"></span></p></td></tr>');
    }





    function sendDataAjax() {
        $.ajax({
            type: "POST",
            url: "GenerarComprobante.aspx/ListarArticulo",
            data: {},
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {                
                addRowDT(data.d);  
                var cliente = data.d[0].cliente;
                var cuit = data.d[0].cuit;
                var fecha = data.d[0].fecha;
                $('#cliente').text(cliente);
                $('#cuit').text(cuit);
                $('#fecha').text(fecha);
                $('#clienteth').text(cliente);
                $('#cuitth').text(cuit);
                $('#fechath').text(fecha);

                $('#tl-Detalle_info').hide();
                $('.dataTables_paginate').hide();
            }

        });
    }

function Listar() {
    var total = 0;

    $("span[id^='ContentPlaceHolder1_dlListaVentas_lblImporte_']").map((index, value) => total += parseFloat(value.innerText))

    $('#total-ventas').text('$' + total);
}

$(document).ready(function () {
    const path = location.pathname;

    switch (path) {
        case '/ListarVentas.aspx':
            $('#ContentPlaceHolder1_btnAceptar').on('click', Listar());
            break;
        case '/GenerarComprobante.aspx':
            sendDataAjax();
            break;
        default:
            break;
    }
});