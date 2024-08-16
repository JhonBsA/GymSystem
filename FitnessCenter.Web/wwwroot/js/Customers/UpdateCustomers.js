document.addEventListener('DOMContentLoaded', function () {
    let apiUrlUpdate = API_URL_BASE + '/Account/UpdateUser';

    // Obtén el ID del cliente de la URL
    const pathname = window.location.pathname;
    const customerID = pathname.split('/').pop();
    let apiUrlId = API_URL_BASE + '/Account/GetUserByUserID?UserID=' + customerID;

    if (customerID) {
        // Llama a la API para obtener los detalles del cliente
        $.ajax({
            url: apiUrlId,
            method: 'GET',
            success: function (data) {
                // Actualiza el HTML con los datos del cliente
                $('#customerID').text(`ID: ${data.userID}`);
                $('#customerID').val(data.userID);
                $('#Nombre').val(`${data.nombre} ${data.firstLastName} ${data.secondLastName}`);
                $('#Telefono').val(data.phone);
                $('#Identificacion').val(data.cedula);
                $('#Email').val(data.email);
            },
            error: function (error) {
                console.error('Error al obtener los detalles del cliente:', error);
            }
        });
    } else {
        console.error('No se encontró el ID del cliente en la URL');
    }

    // Enviar Datos del Formulario
    $('#createCustomerForm').submit(function (event) {
        event.preventDefault();

        // Recoger los valores del formulario
        const userID = $('#customerID').val();
        const fullName = $('#Nombre').val().split(' ');
        const nombre = fullName[0] || '';
        const firstLastName = fullName[1] || '';
        const secondLastName = fullName[2] || '';
        const phone = $('#Telefono').val();
        const cedula = $('#Identificacion').val();
        const email = $('#Email').val();

        // Objeto de datos para enviar
        const customerData = {
            cedula,
            userID,
            nombre,
            firstLastName,
            secondLastName,
            phone,
            email
        };

        // Enviar los datos al servidor
        $.ajax({
            url: apiUrlUpdate,
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(customerData),
            success: function (response) {
                Swal.fire({
                    icon: 'success',
                    title: 'Cliente Actualizado',
                    text: response.Message,
                    confirmButtonText: 'OK'
                })
                    .then(() => {
                        window.location.href = '../ListCustomers'
                    });
            },
            error: function (xhr, status, error) {
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'Hubo un problema al actualizar el cliente.',
                    confirmButtonText: 'OK'
                });
                console.error('Error al actualizar el cliente:', xhr.responseText);
            }
        });
    });
});
