function descargar(tipo) {
    $("#ContentPlaceHolder1_dlListaVentas").tableHTMLExport({
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
    $("#totalFinal").html("$" + totalFinal);
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
                var totalFinal = 0;
                $("tbody")[0].children.map(producto => {
                    totalFinal += parseFloat(producto.children[4])
                });
                $("#totalFinal").html("$" + totalFinal);
                
            }

        });
    }

function Listar() {
    var total = 0;

    $("span[id^='ContentPlaceHolder1_dlListaVentas_lblImporte_']").map((index, value) => total += parseFloat(value.innerText))

    $('#total-ventas').text('$' + total);
}

$('#ContentPlaceHolder1_btnAceptar').on('click', Listar());
    sendDataAjax();