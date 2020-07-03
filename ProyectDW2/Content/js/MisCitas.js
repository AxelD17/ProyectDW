$.get("../Citas/List", function (data) {
    data = JSON.parse(data);
    var nfilas = data.length;
    var contenido = "";
    contenido += "<table class='table table-bordered' id='tablaG' width='100%' cellspacing='0'>";
    contenido += "<thead>";
    contenido += "<tr>";
    contenido += "<td>Paciente</td>";
    contenido += "<td>Especialdiad</td>";
    contenido += "<td>Doctor</td>";
    contenido += "<td>Fecha y hora</td>";
    contenido += "<td>Precio</td>";
    contenido += "</tr>";
    contenido += "</thead>";
    contenido += "<tbody>";
    for (var i = 0; i < nfilas; i++) {
        contenido += "<tr>";
        contenido += "<td>" + data[i].cliente.PersonFirstName + " " + data[i].cliente.PersonSurName + "</td>";
        contenido += "<td>" + data[i].especialidad.nombreEspecialidad + "</td>";
        contenido += "<td>" + data[i].doctor.PersonFirstName + " " + data[i].doctor.PersonSurName + "</td>";
        contenido += "<td>" + convertDateFormat((data[i].fechaAtencion).substring(0, 9)) + " " + data[i].horaAtencio + "</td>";
        contenido += "<td>" + data[i].precio + "</td>";
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
