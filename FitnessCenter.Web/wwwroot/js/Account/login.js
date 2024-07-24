
const loginUser = (e) => {
    e.preventDefault();

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
            console.log(result);
            Swal.fire({
                title: "Logeo exitoso",
                icon: "success",
                confirmButtonText: "Aceptar",
            });
        })
        .fail((jqXHR, textStatus, errorThrown) => {
            console.error("Error en la solicitud:", textStatus, errorThrown);
            Swal.fire({
                title: "Error",
                text: "Hubo un problema con el inicio de sesión. Por favor, intente nuevamente.",
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
                title: 'Oops...',
                text: 'Todos los campos son obligatorios!',
            });
            return;

        } 

        loginUser(e); // Llama a la función loginUser después de la validación
    });
});
