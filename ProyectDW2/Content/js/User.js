
voz("Bienvenido al sistema");
$('.datepicker').datepicker({
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true
});

function voz(mensaje) {
    var vozHablar = new SpeechSynthesisUtterance(mensaje);
    window.speechSynthesis.speak(vozHablar);
}
listar();
function listar() {
    $.get("../User/List", function (data) {
        data = JSON.parse(data);
        var nfilas = 0;
        var contenido = "";
        nfilas = data.length;
        contenido += "<table class='table table-bordered' id='tablaG' width='100%' cellspacing='0'>";
        contenido += "<thead>";
        contenido += "<tr>";
        contenido += "<td>Nombre</td>";
        contenido += "<td>Usuario</td>";
        contenido += "<td>Perfil</td>";
        contenido += "<td>Telefono</td>";
        contenido += "<td>Correo</td>";
        contenido += "<td>Opciones</td>";
        contenido += "</tr>";
        contenido += "</thead>";
        contenido += "<tbody>";
        for (var i = 0; i < nfilas; i++) {
            contenido += "<tr>";
            contenido += "<td>" + data[i].PersonFirstName + " " + data[i].PersonSurName + " " + data[i].PersonLastName + "</td>";
            contenido += "<td>" + data[i].userName + "</td>";
            contenido += "<td>" + data[i].profile.ProfileName + "</td>";
            contenido += "<td>" + data[i].PersonNumber + "</td>";
            contenido += "<td>" + data[i].PersonEmail + "</td>";
            contenido += "<td>";
            contenido += "<button class='btn btn-warning' onClick='openModal(" + data[i].idUser + ")'><i class='fas fa-edit'></i></button> ";
            contenido += "<button class='btn btn-danger' onClick='deleteModal(" + data[i].idUser + ")'><i class='fas fa-trash'></i></button>";
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

$.get("../Genero/List", function (data) {
    data = JSON.parse(data);
    var cbo = document.getElementById("cboGeneroM");
    var contenido = "";
    contenido += "<option value='0'>---Seleccione---</option>"
    var nfilas = data.length;
    for (var i = 0; i < nfilas; i++) {
        contenido += "<option value='" + data[i].idSex + "'>" + data[i].SexName + "</option>"
    }
    cbo.innerHTML = contenido;
});

$.get("../UserDoc/List", function (data) {
    data = JSON.parse(data);
    var cbo = document.getElementById("cboTipoDocM");
    var contenido = "";
    contenido += "<option value='0'>---Seleccione---</option>"
    var nfilas = data.length;
    for (var i = 0; i < nfilas; i++) {
        contenido += "<option value='" + data[i].idUserDoc + "'>" + data[i].DocName + "</option>"
    }
    cbo.innerHTML = contenido;
});

$.get("../District/List", function (data) {
    data = JSON.parse(data);
    var cbo = document.getElementById("cboDistritoM");
    var contenido = "";
    contenido += "<option value='0'>---Seleccione---</option>"
    var nfilas = data.length;
    for (var i = 0; i < nfilas; i++) {
        contenido += "<option value='" + data[i].idDistrict + "'>" + data[i].DistrictName + "</option>"
    }
    cbo.innerHTML = contenido;
});

$.get("../Profile/List", function (data) {
    data = JSON.parse(data);
    var cbo = document.getElementById("cboPerfilM");
    var contenido = "";
    contenido += "<option value='0'>---Seleccione---</option>"
    var nfilas = data.length;
    for (var i = 0; i < nfilas; i++) {
        contenido += "<option value='" + data[i].idProfile + "'>" + data[i].ProfileName + "</option>"
    }
    cbo.innerHTML = contenido;
});

function openModal(id) {
    cleanData();
    if (id == 0) {
        document.getElementById("modalTitle").innerText = "Nuevo Usuario";
    } else {
        $.get("../User/Read/?id=" + id, function (data) {
            data = JSON.parse(data);
            document.getElementById("hdID").value = data.idUser;
            document.getElementById("txtNombre").value = data.PersonFirstName;
            document.getElementById("txtApePaterno").value = data.PersonSurName;
            document.getElementById("txtApeMaterno").value = data.PersonLastName;
            document.getElementById("cboGeneroM").value = data.idPersonSex;
            document.getElementById("txtFecNacimiento").value = data.PersonBirthday;
            document.getElementById("txtTelefono").value = data.PersonNumber;
            document.getElementById("txtEmail").value = data.PersonEmail;
            document.getElementById("cboTipoDocM").value = data.idPersonDoc;
            document.getElementById("txtDocumento").value = data.NumberDoc;
            document.getElementById("cboDistritoM").value = data.idDistrict;
            document.getElementById("txtUsuario").value = data.userName;
            document.getElementById("txtContraseña").value = data.userPass;
            document.getElementById("txtConfirmarContraseña").value = data.userPass;
            document.getElementById("cboPerfilM").value = data.idProfile;
            document.getElementById("modalTitle").innerText = "Editar Usuario";
        });
    }
    $('#ModalUser').modal('show');
}

function deleteModal(id) {
    $.get("../User/Read/?id=" + id, function (data) {
        data = JSON.parse(data);
        document.getElementById('hdIDD').value = data.idUser;
        document.getElementById('modalTitleD').innerHTML = "¿Seguro que desea desactivar el usuario <b>" + data.userName + "</b>?";
    });
    $('#ModalMensaje').modal('show');
}

var btnAceptar = document.getElementById("btnAceptar")
var btnCancelar = document.getElementById("btnCancelar")
btnAceptar.onclick = function () {
    if (requiredData() == true) {

        var id = document.getElementById("hdID").value;
        var PersonFirstName = document.getElementById("txtNombre").value;
        var PersonSurName = document.getElementById("txtApePaterno").value;
        var PersonLastName = document.getElementById("txtApeMaterno").value;
        var idPersonSex = document.getElementById("cboGeneroM").value;
        var PersonBirthday = document.getElementById("txtFecNacimiento").value;
        var PersonNumber = document.getElementById("txtTelefono").value;
        var PersonEmail = document.getElementById("txtEmail").value;
        var idPersonDoc = document.getElementById("cboTipoDocM").value;
        var NumberDoc = document.getElementById("txtDocumento").value;
        var idDistrict = document.getElementById("cboDistritoM").value;
        var userName = document.getElementById("txtUsuario").value;
        var userPass = document.getElementById("txtContraseña").value;
        var userPassConfirm = document.getElementById("txtConfirmarContraseña").value;
        var idProfile = document.getElementById("cboPerfilM").value;
        if (userPass != userPassConfirm) {
            alert("Los campos de contraseña no coinciden.");
            return;
        }
        if (id == 0) {
            var frm = new FormData();
            frm.append("idUser", id);
            frm.append("userName", userName);
            frm.append("userPass", userPass);
            frm.append("PersonFirstName", PersonFirstName);
            frm.append("PersonSurName", PersonSurName);
            frm.append("PersonLastName", PersonLastName);
            frm.append("PersonBirthday", PersonBirthday);
            frm.append("PersonNumber", PersonNumber);
            frm.append("PersonEmail", PersonEmail);
            frm.append("idPersonDoc", idPersonDoc);
            frm.append("NumberDoc", NumberDoc);
            frm.append("idPersonSex", idPersonSex);
            frm.append("idDistrict", idDistrict);
            frm.append("idProfile", idProfile);
            $.ajax({
                type: "POST",
                url: "../User/Create",
                data: frm,
                contentType: false,
                processData: false,
                success: function (data) {
                    if (data != 0) {
                        listar();
                        btnCancelar.click();
                    } else {
                        alert("Ocurrio un error");
                    }
                }
            });
        } else {
            var frm = new FormData();
            frm.append("idUser", id);
            frm.append("userName", userName);
            frm.append("userPass", userPass);
            frm.append("PersonFirstName", PersonFirstName);
            frm.append("PersonSurName", PersonSurName);
            frm.append("PersonLastName", PersonLastName);
            frm.append("PersonBirthday", PersonBirthday);
            frm.append("PersonNumber", PersonNumber);
            frm.append("PersonEmail", PersonEmail);
            frm.append("idPersonDoc", idPersonDoc);
            frm.append("NumberDoc", NumberDoc);
            frm.append("idPersonSex", idPersonSex);
            frm.append("idDistrict", idDistrict);
            frm.append("idProfile", idProfile);
            $.ajax({
                type: "POST",
                url: "../User/Update",
                data: frm,
                contentType: false,
                processData: false,
                success: function (data) {
                    if (data != 0) {
                        listar();
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
    $.get("../User/Delete/?id=" + id, function (data) {
        if (data != 0) {
            list();
            btnCancelarD.click();
        } else {
            alert("Ocurrio un error");
        }
    });
}