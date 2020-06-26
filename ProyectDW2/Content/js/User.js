
listar();
function listar() {
    $.ajax({
        url: "User/List",
        method: "Get",
        success: function (data) {
            data = JSON.parse(data);
            crearlistado(
                ["ID", "Nombre", "Apellido Paterno", "Apellido Materno", "Nacimiento", "Numero", "Correo", "TipoDoc",
                    "Documento", "Sexo", "Distrito", "Usuario", "Contraseña", "Perfil", "Registro", "Estado"]
                , data);
        },
        error: function (err) {
            console.log(err);
        }
    });
}