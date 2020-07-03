var btnCarrito = document.getElementById('btnCarrito');
var btnLimpiar = document.getElementById('btnLimpiar');
var btnAgregar = document.getElementById('btnAgregar');
var btnRetroceder = document.getElementById('btnRetroceder');
var btnCancelar = document.getElementById('btnCancelar');
var btnComprar = document.getElementById('btnComprar');
var btnAceptarD = document.getElementById('btnAceptarD');
var btnCancelarD = document.getElementById('btnCancelarD');

var divCita = document.getElementById('SolicitarCita');
var divCarrito = document.getElementById('CarritoCita');
var divTabla = document.getElementById('divTabla');

var cboCliente = document.getElementById('cboCliente');
var cboEspecialidad = document.getElementById('cboEspecialidad');
var cboDoctor = document.getElementById('cboDoctor');

var txtFechaCita = document.getElementById('txtFechaCita');
var txtHoraCita = document.getElementById('txtHoraCita');
var txtPrecio = document.getElementById('txtPrecio');
var txtPrecioHI = document.getElementById('txtPrecioHI');
var txtIdDocHI = document.getElementById('txtIdDocHI');
var modalTitleD = document.getElementById('modalTitleD');
txtIdDocHI.value = 0;

$('.datepicker').datepicker({
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true
});

btnLimpiar.onclick = function () {
    cleanData();
    txtPrecioHI.value = null;
    txtPrecio.innerHTML = "";
}

btnCarrito.onclick = function () {
    btnLimpiar.click();
    let id = txtIdDocHI.value;
    if (id == 0) {
        alert('El carrito se encuentra vacio, Ingrese al menos una cita.');
        return;
    }
    listarCarrito(id);
    divCita.style.display = 'none'
    divCarrito.style.display = 'block'
}

btnRetroceder.onclick = function () {
    divCarrito.style.display = 'none'
    divCita.style.display = 'block'
}

btnCancelar.onclick = function () {
    btnLimpiar.click();
    btnRetroceder.click();
    txtIdDocHI.value = 0;
}

$.get("../User/ListUserPerf/?id=2", function (data) {
    data = JSON.parse(data);
    var contenido = "";
    contenido += "<option value='0'>---Seleccione---</option>"
    var nfilas = data.length;
    for (var i = 0; i < nfilas; i++) {
        contenido += "<option value='" + data[i].idUser + "'>" + data[i].PersonFirstName + " " + data[i].PersonSurName + "</option>"
    }
    cboCliente.innerHTML = contenido;
});

$.get("../Especialidad/List", function (data) {
    data = JSON.parse(data);
    var contenido = "";
    contenido += "<option value='0'>---Seleccione---</option>"
    var nfilas = data.length;
    for (var i = 0; i < nfilas; i++) {
        contenido += "<option value='" + data[i].idEspecialidad + "'>" + data[i].nombreEspecialidad + "</option>"
    }
    cboEspecialidad.innerHTML = contenido;
});

cboEspecialidad.onchange = function () {
    let id = cboEspecialidad.value;
    $.get("../User/listDocEspecialidad/?id=" + id, function (data) {
        data = JSON.parse(data);
        var contenido = "";
        contenido += "<option value='0'>---Seleccione---</option>"
        var nfilas = data.length;
        for (var i = 0; i < nfilas; i++) {
            contenido += "<option value='" + data[i].idUser + "'>" + data[i].PersonFirstName + " " + data[i].PersonSurName + "</option>"
        }
        cboDoctor.innerHTML = contenido;
        $.get("../Especialidad/Read/?id=" + id, function (data) {
            data = JSON.parse(data);
            txtPrecio.innerHTML = formatMoney(data.precioEspecialidad);
            txtPrecioHI.value = data.precioEspecialidad;
        });
    });
}

btnAgregar.onclick = function () {
    if (requiredData() == true) {
        var id = txtIdDocHI.value;
        var idCliente = cboCliente.value;
        var idEspecialidad = cboEspecialidad.value;
        var idDoctor = cboDoctor.value;
        var fechaAtencion = txtFechaCita.value;
        var horaAtencio = txtHoraCita.value;
        var precio = txtPrecioHI.value;

        if (id == 0) {
            var frm = new FormData();
            frm.append("idCliente", idCliente);
            frm.append("idEspecialidad", idEspecialidad);
            frm.append("idDoctor", idDoctor);
            frm.append("fechaAtencion", fechaAtencion);
            frm.append("horaAtencio", horaAtencio);
            frm.append("precio", precio);
            $.ajax({
                type: "POST",
                url: "../Citas/Create",
                data: frm,
                contentType: false,
                processData: false,
                success: function (data) {
                    if (data != 0) {
                        btnLimpiar.click();
                        alert("Se añadio a carrito");
                        txtIdDocHI.value = data;
                    } else {
                        alert("Ocurrio un error");
                    }
                }
            });
        } else {
            var frm = new FormData();
            frm.append("idDocumento", id);
            frm.append("idCliente", idCliente);
            frm.append("idEspecialidad", idEspecialidad);
            frm.append("idDoctor", idDoctor);
            frm.append("fechaAtencion", fechaAtencion);
            frm.append("horaAtencio", horaAtencio);
            frm.append("precio", precio);
            $.ajax({
                type: "POST",
                url: "../Citas/Update",
                data: frm,
                contentType: false,
                processData: false,
                success: function (data) {
                    if (data != 0) {
                        alert("Se añadio a carrito");
                        txtIdDocHI.value = data;
                        btnLimpiar.click();
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

btnComprar.onclick = function () {
    var id = txtIdDocHI.value;
    $.get("../Citas/Comprar/?id=" + id, function (data) {
        //data = JSON.parse(data);
        if (data != 0) {
            btnCancelar.click();
            alert("Compra Exitosa. Verificar información en Mis Citas");
        } else {
            alert("Ocurrio un error");
        }
    });
}

function listarCarrito(id) {
    $.get("../Citas/ListCarrito/?id=" + id, function (data) {
        data = JSON.parse(data);
        var nfilas = data.length;
        var contenido = "";
        contenido += "<table class='table table-bordered' id='tablaG' width='100%' cellspacing='0'>";
        contenido += "<thead>";
        contenido += "<tr>";
        contenido += "<td>Especialdiad</td>";
        contenido += "<td>Doctor</td>";
        contenido += "<td>Fecha y hora</td>";
        contenido += "<td>Precio</td>";
        contenido += "<td>Opciones</td>";
        contenido += "</tr>";
        contenido += "</thead>";
        contenido += "<tbody>";
        for (var i = 0; i < nfilas; i++) {
            contenido += "<tr>";
            contenido += "<td>" + data[i].especialidad.nombreEspecialidad + "</td>";
            contenido += "<td>" + data[i].doctor.PersonFirstName + " " + data[i].doctor.PersonSurName + "</td>";
            contenido += "<td>" + convertDateFormat((data[i].fechaAtencion).substring(0, 9)) + " " + data[i].horaAtencio + "</td>";
            contenido += "<td>" + data[i].precio + "</td>";
            contenido += "<td>";
            contenido += "<button class='btn btn-danger' onClick='deleteModal(" + data[i].idDetalleDoc + ")'><i class='fas fa-trash'></i></button>";
            contenido += "</td>";
            contenido += "</tr>";
        }
        contenido += "</tbody>";
        contenido += "</table>";

        divTabla.innerHTML = contenido;
    });
}








