const createRegisterUsers = (e) => {
    e.preventDefault();

    const user = {
        cedula: $("#identificacion").val(),
        nombre: $("#nombre").val(),
        firstLastName: $("#primerApellido").val(),
        secondLastName: $("#segundoApellido").val(),
        phone: $("#telefono").val(),
        email: $("#correoElectronico").val()
    };

    const apiUrl = API_URL_BASE + "/Account/CreateUser";

    $.ajax({
        url: apiUrl,
        method: "POST",
        data: JSON.stringify(user),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => {
            console.log(result);
            if (result.success) {
                Swal.fire({
                    title: "Usuario registrado con éxito",
                    icon: "success",
                    background: "#c0d898",
                    customClass: {
                        popup: 'custom-popup',
                        title: 'custom-title',
                        icon: 'custom-title',
                    },
                    confirmButtonText: 'Aceptar',
                    confirmButtonColor: '#3085d6',
                });
            } else {
                // Manejar error si result.success es falso
                Swal.fire({
                    title: "Error",
                    text: result.message || "Se ha presentado un fallo",
                    icon: "error",
                    confirmButtonText: "Aceptar",
                    background: "#f8d7da"
                });
            }
        })
        .fail((response) => {
            console.log("Error en la respuesta del servidor:", response);
            Swal.fire({
                title: "Error",
                text: response.responseText || "Se ha presentado un fallo",
                icon: "error",
                confirmButtonText: "Aceptar",
                background: "#f8d7da"
            });
        });
}

$("#createUserForm").on('submit', createRegisterUsers);
