const createRegisterUsers = (e) => {
    e.preventDefault();

    const user = {}
    user.cedula = $("#identificacion").val(),
        user.nombre = $("#nombre").val(),
        user.firstLastName = $("#primerApellido").val(),
        user.secondLastName = $("#segundoApellido").val(),
        user.phone = $("#telefono").val(),
        user.email = $("#correoElectronico").val()


    const apiUrl = API_URL_BASE + "/Account/CreateUser";

    $.ajax({
        url: apiUrl,
        method: "POST",
        hasContent: true,
        data: JSON.stringify(user),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => {
            console.log(result);
            Swal.fire({
                title: "Usuario registrado con éxito",
                icon: "success",
                confirmButtonText: "Aceptar",
                background: "#c0d898", // Color de fondo similar al de la imagen
                customClass: {
                    popup: 'custom-popup',
                    title: 'custom-title',
                    icon: 'custom-title',
                    confirmButton: 'custom-button'
             
                }
                
            })
        }).fail((response) => {
            console.log(response.responseText)
            Swal.fire({
                title: "Usuario",
                text: "Se ha presentado un fallo",
                icon: "error",
                confirmButtonText: "Aceptar",
                background: "#f8d7da"
            })
        });

}


$("#createUserForm").on('submit', createRegisterUsers)





