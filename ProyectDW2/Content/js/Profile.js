list();

function list() {
    $.get("../Profile/List", function (data) {
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
            contenido += "<td>" + data[i].idProfile + "</td>";
            contenido += "<td>" + data[i].ProfileName + "</td>";
            contenido += "<td>";
            contenido += "<button class='btn btn-warning' onClick='openModal(" + data[i].idProfile + ")'><i class='fas fa-edit'></i></button> ";
            contenido += "<button class='btn btn-danger' onClick='deleteModal(" + data[i].idProfile + ")'><i class='fas fa-trash'></i></button>";
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
        document.getElementById('modalTitle').innerText = "Nuevo Perfil";
    } else {
        $.get("../Profile/Read/?id=" + id, function (data) {
            data = JSON.parse(data);
            document.getElementById('hdID').value = data.idProfile;
            document.getElementById('txtNombre').value = data.ProfileName;
            document.getElementById('modalTitle').innerText = "Editar Perfil";
        });
    }
    $('#ModalPerfiles').modal('show');
}

function deleteModal(id) {
    $.get("../Profile/Read/?id=" + id, function (data) {
        data = JSON.parse(data); 
        document.getElementById('hdIDD').value = data.idProfile;
        document.getElementById('modalTitleD').innerHTML = "¿Seguro que desea desactivar el perfil <b>" + data.ProfileName + "</b>?";
    });
    $('#ModalPerfilesDelete').modal('show');
}

var btnAceptar = document.getElementById("btnAceptar")
var btnCancelar = document.getElementById("btnCancelar")
btnAceptar.onclick = function () {
    var id = document.getElementById("hdID").value;
    if (requiredData() == true) {
        if (id == 0) {
            var frm = new FormData();
            var nombre = document.getElementById("txtNombre").value;
            frm.append("ProfileName", nombre);
            $.ajax({
                type: "POST",
                url: "../Profile/Create",
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
            frm.append("idProfile", id);
            frm.append("ProfileName", nombre);
            $.ajax({
                type: "POST",
                url: "../Profile/Update",
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
    $.get("../Profile/Delete/?id=" + id, function (data) {
        if (data != 0) {
            list();
            btnCancelarD.click();
        } else {
            alert("Ocurrio un error");
        }
    });
}