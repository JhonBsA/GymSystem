document.addEventListener('DOMContentLoaded', function () {
    let apiUrlCustomers = API_URL_BASE + '/Account/GetCustomers';
    let apiUrl = API_URL_BASE + '/Payment/PostPayment';

    const PaymentMethod = {
        PAYPAL: 'PayPal',
        CREDIT_CARD: 'Credit Card',
        EFECTIVO: 'Efectivo'
    };

    // Cargar clientes
    $.ajax({
        url: apiUrlCustomers,
        method: 'GET',
        success: function (data) {
            var clienteSelect = $('#Cliente');
            clienteSelect.empty(); // Limpiar el select actual
            data.forEach(function (customer) {
                clienteSelect.append(new Option(
                    `${customer.nombre} ${customer.firstLastName} ${customer.secondLastName}`,
                    customer.userID
                ));
            });
        },
        error: function (xhr, status, error) {
            console.error('Error al cargar clientes:', error);
        }
    });

    // Cargar métodos de pago
    const paymentSelect = $('#MetodoPago');
    paymentSelect.empty(); // Limpiar el select actual
    Object.values(PaymentMethod).forEach(method => {
        paymentSelect.append(new Option(method, method));
    });

    // Enviar Datos del Formulario
    $('#createPaymentForm').submit(function (event) {
        event.preventDefault();

        // Recoger los valores del formulario
        let paymentData = {
            userID: $('#Cliente').val(),
            paymentDate: $('#FechaHora').val(),
            displayPaymentMethod: $('#MetodoPago').val(),
            amount: $('#Monto').val()
        };

        console.log(paymentData)

        // Enviar los datos al servidor
        $.ajax({
            url: apiUrl,
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(paymentData),
            success: function (response) {
                Swal.fire({
                    icon: 'success',
                    title: 'Pago registrado',
                    text: response.Message,
                    confirmButtonText: 'OK'
                }).then(() => {
                    window.location.href = 'ListPayments';
                });
            },
            error: function (xhr, status, error) {
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'Hubo un problema al registrar el pago.',
                    confirmButtonText: 'OK'
                });
            }
        });
    });
});
