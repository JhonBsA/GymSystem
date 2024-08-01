$(document).ready(function () {
    // Manejo del envío del formulario
    $('#createUserForm').on('submit', function (event) {
        event.preventDefault(); // Evitar el envío del formulario por defecto

        // Obtener los valores de los campos del formulario
        var userDetails = {
            Cedula: $('#Identificacion').val(),
            Nombre: $('#Nombre').val(),
            FirstLastName: $('#PrimerApellido').val(),
            SecondLastName: $('#SegundoApellido').val(),
            Phone: $('#Telefono').val(),
            Email: $('#CorreoElectronico').val(),
        };

        // Validar campos antes de enviar
        if (!userDetails.Cedula || !userDetails.Nombre || !userDetails.FirstLastName || !userDetails.SecondLastName || !userDetails.Phone || !userDetails.Email) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Todos los campos son obligatorios!',
            });
            return;
        }

        // Validar correo electrónico
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailRegex.test(userDetails.Email)) {
            Swal.fire({
                icon: 'error',
                title: 'Correo electrónico inválido',
                text: 'Por favor, ingresa un correo electrónico válido.',
            });
            return;
        }

        const apiUrl = API_URL_BASE + "/Account/CreateUser";

        // Realizar la solicitud AJAX
        $.ajax({
            type: 'POST',
            url: apiUrl,
            contentType: 'application/json',
            data: JSON.stringify(userDetails),
            success: function (response) {
                // Mostrar un mensaje de éxito
                console.log(response)
                Swal.fire({
                    icon: 'success',
                    title: 'Registro exitoso',
                    text: response.Message || 'El usuario ha sido registrado exitosamente.',

                    preConfirm: () => {
                        window.location.href = "Verify";
                    }
                });

                // Limpiar el formulario
                $('#createUserForm')[0].reset();
            },
            error: function (xhr, status, error) {
                Console.log(response)
                // Mostrar un mensaje de error
                let errorMessage = 'No se pudo completar el registro. Intenta nuevamente.';
                if (xhr.responseJSON && xhr.responseJSON.Message) {
                    errorMessage = xhr.responseJSON.Message;
                }
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: errorMessage || 'No se pudo completar el registro. Intenta nuevamente.'
                });
            }
        });
    });
});
