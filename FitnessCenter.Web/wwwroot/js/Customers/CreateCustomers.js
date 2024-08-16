$(document).ready(function () {
    // Manejo del envío del formulario
    $('#createCustomerForm').on('submit', function (event) {
        event.preventDefault(); // Evitar el envío del formulario por defecto

        // Obtener los valores de los campos del formulario
        var fullName = $('#Nombre').val().trim();
        var nameParts = fullName.split(' ');

        // Dividir el nombre completo en nombre, primer apellido y segundo apellido
        var firstName = nameParts.shift();
        var firstLastName = nameParts.shift() || '';
        var secondLastName = nameParts.join(' ') || '';

        console.log(firstName)

        // Obtener los valores de los campos del formulario
        var customerDetails = {
            Cedula: $('#Identificacion').val(),
            Nombre: firstName,
            FirstLastName: firstLastName,
            SecondLastName: secondLastName,
            Phone: $('#Telefono').val(),
            Email: $('#Email').val(),
            RoleName: "Cliente"
        };

        // Validar campos antes de enviar
        if (!customerDetails.Nombre || !customerDetails.Phone || !customerDetails.Cedula || !customerDetails.Email) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Todos los campos son obligatorios!',
            });
            return;
        }

        // Validar correo electrónico
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailRegex.test(customerDetails.Email)) {
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
            data: JSON.stringify(customerDetails),
            success: function (response) {
                // Mostrar un mensaje de éxito
                Swal.fire({
                    icon: 'success',
                    title: 'Registro exitoso',
                    text: response.Message || 'El usuario ha sido registrado exitosamente.',
                    preConfirm: () => {
                        window.location.href = "ListCustomers";
                    }
                });

                // Limpiar el formulario
                $('#createCustomerForm')[0].reset();
            },
            error: function (xhr, status, error) {
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
