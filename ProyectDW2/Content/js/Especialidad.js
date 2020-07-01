list();

function list() {
    $.get("../Especialidad/List", function (data) {
        data = JSON.parse(data);
        var nfilas = 0;
        var contenido = "";
        nfilas = data.length;
        contenido += "<table class='table table-bordered' id='tablaG' width='100%' cellspacing='0'>";
        contenido += "<thead>";
        contenido += "<tr>";
        contenido += "<td>ID</td>";
        contenido += "<td>Nombre</td>";
        contenido += "<td>Descripcion</td>";
        contenido += "<td>Precio</td>";
        contenido += "<td>Duración</td>";
        contenido += "<td>Opciones</td>";
        contenido += "</tr>";
        contenido += "</thead>";
        contenido += "<tbody>";
        for (var i = 0; i < nfilas; i++) {
            contenido += "<tr>";
            contenido += "<td>" + data[i].idEspecialidad + "</td>";
            contenido += "<td>" + data[i].nombreEspecialidad + "</td>";
            contenido += "<td>" + data[i].descripcionEspecialidad + "</td>";
            contenido += "<td>" + data[i].precioEspecialidad + "</td>";
            contenido += "<td>" + data[i].duracionEspecialidad + "</td>";
            contenido += "<td>";
            contenido += "<button class='btn btn-warning' onClick='openModal(" + data[i].idEspecialidad + ")'><i class='fas fa-edit'></i></button> ";
            contenido += "<button class='btn btn-danger' onClick='deleteModal(" + data[i].idEspecialidad + ")'><i class='fas fa-trash'></i></button>";
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
        document.getElementById('modalTitle').innerText = "Nueva Especialidad";
    } else {
        $.get("../Especialidad/Read/?id=" + id, function (data) {
            data = JSON.parse(data);
            document.getElementById('hdID').value = data.idEspecialidad;
            document.getElementById('txtNombre').value = data.nombreEspecialidad;
            document.getElementById('txtDescripcion').value = data.descripcionEspecialidad;
            document.getElementById('txtPrecio').value = data.precioEspecialidad;
            document.getElementById('txtDuracion').value = data.duracionEspecialidad;
            document.getElementById('modalTitle').innerText = "Editar Especialidad";
        });
    }
    $('#ModalEspecialidad').modal('show');
}

function deleteModal(id) {
    $.get("../Especialidad/Read/?id=" + id, function (data) {
        data = JSON.parse(data);
        document.getElementById('hdIDD').value = data.idEspecialidad;
        document.getElementById('modalTitleD').innerHTML = "¿Seguro que desea desactivar la especialidad <b>" + data.nombreEspecialidad + "</b>?";
    });
    $('#ModalMensaje').modal('show');
}

var btnAceptar = document.getElementById("btnAceptar")
var btnCancelar = document.getElementById("btnCancelar")
btnAceptar.onclick = function () {
    if (requiredData() == true) {
        var id = document.getElementById("hdID").value;
        var nombre = document.getElementById("txtNombre").value;
        var descripcion = document.getElementById("txtDescripcion").value;
        var precio = document.getElementById("txtPrecio").value;
        var duracion = document.getElementById("txtDuracion").value;
        if (id == 0) {
            var frm = new FormData();
            frm.append("nombreEspecialidad", nombre);
            frm.append("descripcionEspecialidad", descripcion);
            frm.append("precioEspecialidad", precio);
            frm.append("duracionEspecialidad", duracion);
            $.ajax({
                type: "POST",
                url: "../Especialidad/Create",
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
            var nombre = document.getElementById("txtNombre").value;
            frm.append("idEspecialidad", id);
            frm.append("nombreEspecialidad", nombre);
            frm.append("descripcionEspecialidad", descripcion);
            frm.append("precioEspecialidad", precio);
            frm.append("duracionEspecialidad", duracion);
            $.ajax({
                type: "POST",
                url: "../Especialidad/Update",
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
    $.get("../Especialidad/Delete/?id=" + id, function (data) {
        if (data != 0) {
            list();
            btnCancelarD.click();
        } else {
            alert("Ocurrio un error");
        }
    });
}