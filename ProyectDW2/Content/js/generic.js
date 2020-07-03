
var user = []

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

function crearlistado(arrayColumn, data, modal) {
    var nfilas = 0;
    var contenido = "";
    var llaves = Object.keys(data[0]);
    contenido += "<table class='table table-bordered' id='tablaG' width='100%' cellspacing='0'>";
    contenido += "<thead>";
    contenido += "<tr>";
    nfilas = arrayColumn.length
    for (var i = 0; i < nfilas; i++) {
        contenido += "<td>" + arrayColumn[i] + "</td>";
    }
    contenido += "<td>Opciones</td>";
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
        var llaveID = llaves[0];
        contenido += "<td>";
        contenido += "<button class='btn btn-warning' onClick='EditModal(" + data[i][llaveID] + ")' data-toggle='modal' data-target='#" + modal + "'><i class='fas fa-edit'></i></button> ";
        contenido += "<button class='btn btn-danger'><i class='fas fa-trash'></i></button>";
        contenido += "</td>";
        contenido += "</tr>";
    }
    contenido += "</tbody>";
    contenido += "</table>";

    document.getElementById("divTabla").innerHTML = contenido;

    $('#tablaG').dataTable({
        searching: false,
        language: {
            "url": "//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json"
        }
    });
}

function cleanData() {
    var controls = document.getElementsByClassName("clean-input");
    var ncontrol = controls.length;
    for (var i = 0; i < ncontrol; i++) {
        controls[i].value = "";
        controls[i].parentNode.classList.remove("rq");
    }
    controls = document.getElementsByClassName("clean-select");
    ncontrol = controls.length;
    for (var i = 0; i < ncontrol; i++) {
        controls[i].value = 0;
        controls[i].parentNode.classList.remove("rq");
    }
}

function requiredData() {
    var exito = true;
    var controls = document.getElementsByClassName("required");
    var ncontrol = controls.length;
    for (var i = 0; i < ncontrol; i++) {
        if (controls[i].value == "" || controls[i].value == 0) {
            controls[i].parentNode.classList.add("rq");
            exito = false;
        } else {
            controls[i].parentNode.classList.remove("rq");
        }
    }
    return exito
}

function formatMoney(cant) {
    const formatterSoles = new Intl.NumberFormat('es-PE', {
        style: 'currency',
        currency: 'PEN',
        minimumFractionDigits: 2
    })
    return formatterSoles.format(cant);
}

function convertDateFormat(string) {
    var info = string.split('-').reverse().join('/');
    return info;
}