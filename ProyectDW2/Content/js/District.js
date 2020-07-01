list();

function list() {
    $.get("../District/List", function (data) {
        data = JSON.parse(data);
        var nfilas = 0;
        var contenido = "";
        nfilas = data.length;
        contenido += "<table class='table table-bordered' id='tablaG' width='100%' cellspacing='0'>";
        contenido += "<thead>";
        contenido += "<tr>";
        contenido += "<td>ID</td>";
        contenido += "<td>Nombre</td>";
        contenido += "<td>Opciones</td>";
        contenido += "</tr>";
        contenido += "</thead>";
        contenido += "<tbody>";
        for (var i = 0; i < nfilas; i++) {
            contenido += "<tr>";
            contenido += "<td>" + data[i].idDistrict + "</td>";
            contenido += "<td>" + data[i].DistrictName + "</td>";
            contenido += "<td>";
            contenido += "<button class='btn btn-warning' onClick='openModal(" + data[i].idDistrict + ")'><i class='fas fa-edit'></i></button> ";
            contenido += "<button class='btn btn-danger' onClick='deleteModal(" + data[i].idDistrict + ")'><i class='fas fa-trash'></i></button>";
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
    });
}

function openModal(id) {
    cleanData();
    if (id == 0) {
        document.getElementById('modalTitle').innerText = "Nuevo Distrito";
    } else {
        $.get("../District/Read/?id=" + id, function (data) {
            data = JSON.parse(data);
            document.getElementById('hdID').value = data.idDistrict;
            document.getElementById('txtNombre').value = data.DistrictName;
            document.getElementById('modalTitle').innerText = "Editar Distrito";
        });
    }
    $('#ModalDistritos').modal('show');
}

function deleteModal(id) {
    $.get("../District/Read/?id=" + id, function (data) {
        data = JSON.parse(data);
        document.getElementById('hdIDD').value = data.idDistrict;
        document.getElementById('modalTitleD').innerHTML = "¿Seguro que desea desactivar el distrito <b>" + data.DistrictName + "</b>?";
    });
    $('#ModalMensaje').modal('show');
}

var btnAceptar = document.getElementById("btnAceptar")
var btnCancelar = document.getElementById("btnCancelar")
btnAceptar.onclick = function () {
    if (requiredData() == true) {
        var id = document.getElementById("hdID").value;
        var nombre = document.getElementById("txtNombre").value;
        if (id == 0) {
            var frm = new FormData();
            frm.append("DistrictName", nombre);
            $.ajax({
                type: "POST",
                url: "../District/Create",
                data: frm,
                contentType: false,
                processData: false,
                success: function (data) {
                    if (data != 0) {
                        list();
                        btnCancelar.click();
                    } else {
                        alert("Ocurrio un error");
                    }
                }
            });
        } else {
            var frm = new FormData();
            frm.append("idDistrict", id);
            frm.append("DistrictName", nombre);
            $.ajax({
                type: "POST",
                url: "../District/Update",
                data: frm,
                contentType: false,
                processData: false,
                success: function (data) {
                    if (data != 0) {
                        list();
                        btnCancelar.click();
                    } else {
                        alert("Ocurrio un error");
                    }
                }
            });
        }
    } else {
        alert("Complete todos los campos");
    }
}

var btnAceptarD = document.getElementById("btnAceptarD")
var btnCancelarD = document.getElementById("btnCancelarD")
btnAceptarD.onclick = function () {
    var id = document.getElementById("hdIDD").value;
    $.get("../District/Delete/?id=" + id, function (data) {
        if (data != 0) {
            list();
            btnCancelarD.click();
        } else {
            alert("Ocurrio un error");
        }
    });
}