function QueryCurrentUser(URL) {

    var form = $("#ModificarUsuarios1-form");
    var token = $('input[name="__RequestVerificationToken"]', form).val();
    var nombreUsuario = $('#nombreUsuario').val();

    $.ajax({
        type: "POST",
        url: URL,
        data: {
            __RequestVerificationToken: token,
            nombreUsu: nombreUsuario
        },
        success: function (result) {
            if (result.response === "ERROR") {
                console.log('no retorno data');
            }
            else {
                console.log('retorno data');
                //$('#nombreUsuario').val(result.data["nombreUsuario"]);
                $('#nombreCompleto').val(result.data["nombreCompleto"]);
                $('#documento').val(result.data["documento"]);
                $('#direccion').val(result.data["direccion"]);
                $('#telefono').val(result.data["telefono"]);
                $('#fechaNacimiento').val(result.data["fechaNacimiento"]);
                $('#generoID').val(result.data["generoID"]);
                $('#correo').val(result.data["correo"]);
                $('#pais').val(result.data["pais"]);
                $('#rolID').val(result.data["rolID"]);
                $('#contra').val(result.data["contra"]);
                $('#estado').val(result.data["estado"]);
            }
        }
    });
}

function QueryCurrentRol(URL) {

    var form = $("#ModificarRoles1-form");
    var token = $('input[name="__RequestVerificationToken"]', form).val();
    var rolID = $('#rolID').val();

    $.ajax({
        type: "POST",
        url: URL,
        data: {
            __RequestVerificationToken: token,
            uRol: rolID
        },
        success: function (result) {
            if (result.response === "ERROR") {
                console.log('no retorno data');
            }
            else {
                console.log('retorno data');
                $('#nombreRol').val(result.data["nombreRol"]);
                $('#estadoActivo').val(result.data["estadoActivo"]);
            }
        }
    });
}

function QueryCurrentPermit(URL) {

    var form = $("#ModificarPermisos1-form");
    var token = $('input[name="__RequestVerificationToken"]', form).val();
    var permisoID = $('#permisoID').val();

    $.ajax({
        type: "POST",
        url: URL,
        data: {
            __RequestVerificationToken: token,
            permiso: permisoID
        },
        success: function (result) {
            if (result.response === "ERROR") {
                console.log('no retorno data');
            }
            else {
                console.log('retorno data');
                $('#nombrePermiso').val(result.data["nombrePermiso"]);
                $('#descripcionPermiso').val(result.data["descripcionPermiso"]);
                $('#iconoPermiso').val(result.data["iconoPermiso"]);
                $('#routerPagina').val(result.data["routerPagina"]);
                $('#estadoActivo').val(result.data["estadoActivo"]);
            }
        }
    });
}

function EstateCurrentPermit(URL) {

    var form = $("#AltaBajaPermisos1-form");
    var token = $('input[name="__RequestVerificationToken"]', form).val();
    var permisoID = $('#permisoID').val();

    $.ajax({
        type: "POST",
        url: URL,
        data: {
            __RequestVerificationToken: token,
            permiso: permisoID
        },
        success: function (result) {
            if (result.response === "ERROR") {
                console.log('no retorno data');
            }
            else {
                console.log('retorno data');
                $("#descripcionPermiso").val(result.data["descripcionPermiso"]);
                $('#estadoActivo').val(result.data["estadoActivo"]);
            }
        }
    });
}

function EstateCurrentRol(URL) {

    var form = $("#AltaBajaRoles1-form");
    var token = $('input[name="__RequestVerificationToken"]', form).val();
    var rolID = $('#rolID').val();

    $.ajax({
        type: "POST",
        url: URL,
        data: {
            __RequestVerificationToken: token,
            uRol: rolID
        },
        success: function (result) {
            if (result.response === "ERROR") {
                console.log('no retorno data');
            }
            else {
                console.log('retorno data');
                $('#nombreRol').val(result.data["nombreRol"]);
                $('#estadoActivo').val(result.data["estadoActivo"]);
            }
        }
    });
}

function EstateCurrentUser(URL) {

    var form = $("#AltaBajaUsuarios1-form");
    var token = $('input[name="__RequestVerificationToken"]', form).val();
    var nombreUsuario = $('#nombreUsuario').val();

    $.ajax({
        type: "POST",
        url: URL,
        data: {
            __RequestVerificationToken: token,
            nombreUsu: nombreUsuario
        },
        success: function (result) {
            if (result.response === "ERROR") {
                console.log('no retorno data');
            }
            else {
                console.log('retorno data');
                //$('#nombreUsuario').val(result.data["nombreUsuario"]);
                $('#estado').val(result.data["estado"]);
            }
        }
    });
}