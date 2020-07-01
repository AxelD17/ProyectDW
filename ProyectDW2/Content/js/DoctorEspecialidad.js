
list();
function list() {
    $.get("../DoctorEspecialidad/List", function (data) {
        data = JSON.parse(data);
        var nfilas = 0;
        var contenido = "";
        nfilas = data.length;
        contenido += "<table class='table table-bordered' id='tablaG' width='100%' cellspacing='0'>";
        contenido += "<thead>";
        contenido += "<tr>";
        contenido += "<td>Nombre</td>";
        contenido += "<td>Especialidad</td>";
        contenido += "<td>Opciones</td>";
        contenido += "</tr>";
        contenido += "</thead>";
        contenido += "<tbody>";
        for (var i = 0; i < nfilas; i++) {
            contenido += "<tr>";
            contenido += "<td>" + data[i].user.PersonFirstName + " " + data[i].user.PersonSurName + "</td>";
            contenido += "<td>" + data[i].especialidad.nombreEspecialidad + "</td>";
            contenido += "<td>";
            contenido += "<button class='btn btn-warning' onClick='openModal(" + data[i].idDocEspecilidad + ")'><i class='fas fa-edit'></i></button> ";
            contenido += "<button class='btn btn-danger' onClick='deleteModal(" + data[i].idDocEspecilidad + ")'><i class='fas fa-trash'></i></button>";
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

var cboDoctorM = document.getElementById("cboDoctorM");
var cboEspecialidadM = document.getElementById("cboEspecialidadM");
$.get("../User/ListUserPerf/?id=5", function (data) {
    data = JSON.parse(data);
    var contenido = "";
    contenido += "<option value='0'>---Seleccione---</option>"
    var nfilas = data.length;
    for (var i = 0; i < nfilas; i++) {
        contenido += "<option value='" + data[i].idUser + "'>" + data[i].PersonFirstName + " " + data[i].PersonSurName + "</option>"
    }
    cboDoctorM.innerHTML = contenido;
});

function openModal(id) {
    cleanData();
    if (id == 0) {
        cboEspecialidadM.innerHTML = "";
        document.getElementById('modalTitle').innerText = "Asociar Doctor Especialidad";
        cboDoctorM.onchange = function () {
            $.get("../Especialidad/listEspe/?id=" + cboDoctorM.value, function (data) {
                data = JSON.parse(data);
                var contenido = "";
                contenido += "<option value='0'>---Seleccione---</option>"
                var nfilas = data.length;
                for (var i = 0; i < nfilas; i++) {
                    contenido += "<option value='" + data[i].idEspecialidad + "'>" + data[i].nombreEspecialidad + "</option>"
                }
                cboEspecialidadM.innerHTML = contenido;
            });
        }
    } else {
        $.get("../DoctorEspecialidad/Read/?id=" + id, function (data) {
            data = JSON.parse(data);
            document.getElementById('hdID').value = data.idDocEspecilidad;
            document.getElementById('cboDoctorM').value = data.idDoctor;
            cboEspecialidadM.innerHTML = "";
            $.get("../Especialidad/listEspe2/?id=" + data.idDoctor + "&es=" + data.idEspecialidad, function (d) {
                d = JSON.parse(d);
                var contenido = "";
                contenido += "<option value='0'>---Seleccione---</option>"
                var nfilas = d.length;
                for (var i = 0; i < nfilas; i++) {
                    contenido += "<option value='" + d[i].idEspecialidad + "'>" + d[i].nombreEspecialidad + "</option>"
                }
                cboEspecialidadM.innerHTML = contenido;
                document.getElementById('cboEspecialidadM').value = data.idEspecialidad;
            });
            cboDoctorM.onchange = function () {
                $.get("../Especialidad/listEspe2/?id=" + cboDoctorM.value + "&es=" + data.idEspecialidad, function (d) {
                    d = JSON.parse(d);
                    var contenido = "";
                    contenido += "<option value='0'>---Seleccione---</option>"
                    var nfilas = d.length;
                    for (var i = 0; i < nfilas; i++) {
                        contenido += "<option value='" + d[i].idEspecialidad + "'>" + d[i].nombreEspecialidad + "</option>"
                    }
                    cboEspecialidadM.innerHTML = contenido;
                });
            }
            document.getElementById('modalTitle').innerText = "Editar Doctor Especialidad";
        });
    }
    $('#ModalDE').modal('show');
}

function deleteModal(id) {
    $.get("../DoctorEspecialidad/Read/?id=" + id, function (data) {
        data = JSON.parse(data);
        document.getElementById('hdIDD').value = data.idDocEspecilidad;
        document.getElementById('modalTitleD').innerHTML = "¿Seguro que desea desactivar la relación Doctor-Especialidad seleccionada ?";
    });
    $('#ModalMensaje').modal('show');
}

var btnAceptar = document.getElementById("btnAceptar")
var btnCancelar = document.getElementById("btnCancelar")
btnAceptar.onclick = function () {
    if (requiredData() == true) {
        var id = document.getElementById("hdID").value;
        var doctor = document.getElementById("cboDoctorM").value;
        var especialidad = document.getElementById("cboEspecialidadM").value;
        if (id == 0) {
            var frm = new FormData();
            frm.append("idDoctor", doctor);
            frm.append("idEspecialidad", especialidad);
            $.ajax({
                type: "POST",
                url: "DoctorEspecialidad/Create",
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
            frm.append("idDocEspecilidad", id);
            frm.append("idDoctor", doctor);
            frm.append("idEspecialidad", especialidad);
            $.ajax({
                type: "POST",
                url: "DoctorEspecialidad/Update",
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
    $.get("../DoctorEspecialidad/Delete/?id=" + id, function (data) {
        if (data != 0) {
            list();
            btnCancelarD.click();
        } else {
            alert("Ocurrio un error");
        }
    });
}