
const loginUser = (e) => {
    e.preventDefault();

    //ENVIO POR MEDIO DE OBJETO JSON
    const login = {
        email: $("#email").val().trim(),
        password: $("#password").val().trim()
    }

    const apiUrl = API_URL_BASE + "/Account/Login";

    $.ajax({
        url: apiUrl,
        method: "POST",
        data: JSON.stringify(login),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => {
            localStorage.setItem('RoleID', result.RoleID);
            localStorage.setItem('UserID', result.UserID);

            let redirectToHome = '';

            switch (result.RoleID) {
                case '1': // Cliente
                    redirectToHome = customerHomeUrl;
                    break;
                case '2': // Recepcionista
                    redirectToHome = receptionistHomeUrl;
                    break;
                case '3': // Entrenador
                    redirectToHome = trainerHomeUrl;
                    break;
                case '4': // Administrador
                    redirectToHome = adminHomeUrl;
                    break;
                default:
                    redirectToHome = loginUrl; // Redirigir a la página de login si no se reconoce el RoleID
                    break;
            }

            Swal.fire({
                title: "Inicio de sesión exitoso",
                icon: "success",
                confirmButtonText: "Aceptar",
            }).then(() => {
                window.location.href = redirectToHome;
            });
        })
        .fail((jqXHR, textStatus, errorThrown) => {
            let errorMessage = "Correo electrónico o contraseña incorrecto. Por favor, intente nuevamente.";

            if (jqXHR.responseJSON && jqXHR.responseJSON.Message) {
                errorMessage = jqXHR.responseJSON.Message;
            }

            Swal.fire({
                title: "Error",
                text: errorMessage,
                icon: "error",
                confirmButtonText: "Aceptar",
            });
        });
}

$(document).ready(function () {
    $('#loginForm').on('submit', function (e) {
        e.preventDefault(); // Previene el envío del formulario

        var email = $('#email').val().trim();
        var password = $('#password').val().trim();

        if (email === '' || password === '') {
            Swal.fire({
                icon: 'error',
                title: 'Atención...',
                text: 'Todos los campos son obligatorios!',
            });
            return;

        } 

        loginUser(e); // Llama a la función loginUser después de la validación
    });
});
