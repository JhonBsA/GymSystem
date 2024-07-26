$(document).ready(function () {
    $('#forgotPasswordForm').on('submit', function (event) {
        event.preventDefault(); // Evitar el envío del formulario por defecto

        // Obtener el valor del campo de correo electrónico
        var email = $('#Email').val().trim();

        // Validar el campo de correo electrónico
        if (!email) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'El campo de correo electrónico es obligatorio!',
            });
            return;
        }

        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailRegex.test(email)) {
            Swal.fire({
                icon: 'error',
                title: 'Correo electrónico inválido',
                text: 'Por favor, ingresa un correo electrónico válido.',
            });
            return;
        }

        sendForgotPasswordRequest(email); // Llama a la función para enviar la solicitud
    });
});

// Función para enviar la solicitud de recuperación de contraseña
function sendForgotPasswordRequest(email) {

    const apiUrl = API_URL_BASE + "/Account/PasswordReset";

    $.ajax({
        type: 'GET',
        url: apiUrl,
        contentType: 'application/json',
        data: {Email: email},
        success: function (response) {
            // Mostrar un mensaje de éxito
            Swal.fire({
                icon: 'success',
                title: 'Correo Enviado',
                text: response.Message || 'Se ha enviado un correo para restablecer la contraseña.',
                timer: 3000,
                timerProgressBar: true,
            }).then(() => {
                window.location.href = 'Verify';
            });

            // Limpiar el campo del formulario
            $('#forgotPasswordForm')[0].reset();
        },
        error: function (xhr, status, error) {
            // Mostrar un mensaje de error
            let errorMessage = 'No se pudo completar la solicitud. Intenta nuevamente.';
            if (xhr.responseJSON && xhr.responseJSON.Message) {
                errorMessage = xhr.responseJSON.Message;
            }
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: errorMessage
            });
        }
    });
}
