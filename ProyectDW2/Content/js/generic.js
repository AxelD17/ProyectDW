
function llenarcombo(data, control, primerElemento) {
    var contenido = "";
    if (primerElemento == true) {
        contenido += "<option value='0'>---Seleccione---</option>"
    }
    var nfilas = data.length;
    for (var i = 0; i < nfilas; i++) {
        contenido += "<option value='" + data[i].IID + "'>" + data[i].NOMBRE + "</option>"
    }
    control.innerHTML = contenido;
}

function crearlistado(arrayColumn, data) {
    var nfilas = 0;
    var contenido = "";
    var llaves = Object.keys(data[0]);
    contenido += "<table id='tablaG' class='table'>";
    contenido += "<thead>";
    contenido += "<tr>";
    nfilas = arrayColumn.length
    for (var i = 0; i < nfilas; i++) {
        contenido += "<td>" + arrayColumn[i] + "</td>";
    }
    contenido += "</tr>";
    contenido += "</thead>";
    contenido += "<tbody>";
    nfilas = data.length;
    for (var i = 0; i < nfilas; i++) {
        contenido += "<tr>";
        for (var j = 0; j < llaves.length; j++) {
            var valorLlave = llaves[j];
            contenido += "<td>" + data[i][valorLlave] + "</td>";
        }
        contenido += "</tr>";
    }
    contenido += "</tbody>";
    contenido += "</table>";

    document.getElementById("divTabla").innerHTML = contenido;

    $('#tablaG').dataTable({
        searching: false
    });
}