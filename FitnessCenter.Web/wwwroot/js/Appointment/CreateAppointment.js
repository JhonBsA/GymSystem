document.addEventListener('DOMContentLoaded', function () {
    let apiUrlCustomers = API_URL_BASE + '/Account/GetCustomers';
    let apiUrlTrainers = API_URL_BASE + '/Account/GetTrainers';
    let apiUrl = API_URL_BASE + '/Appointment/CreateAppointment';

    // Filtrar usuarios que no comienzan con "del."
    function filterUsers(users) {
        return users.filter(user => !user.nombre.toLowerCase().startsWith('del.'));
    }

    // Cargar clientes
    $.ajax({
        url: apiUrlCustomers,
        method: 'GET',
        success: function (data) {
            var clienteSelect = $('#Cliente');
            clienteSelect.empty(); // Limpiar el select actual
            var filteredCustomers = filterUsers(data);
            filteredCustomers.forEach(function (customer) {
                clienteSelect.append(new Option(
                    `${customer.nombre} ${customer.firstLastName} ${customer.secondLastName}`,
                    customer.userID
                ));
            });
        },
        error: function (xhr, status, error) {
            console.error('Error al cargar clientes');
        }
    });

    // Cargar entrenadores
    $.ajax({
        url: apiUrlTrainers,
        method: 'GET',
        success: function (data) {
            var entrenadorSelect = $('#Entrenador');
            entrenadorSelect.empty(); // Limpiar el select actual
            data.forEach(function (trainer) {
                entrenadorSelect.append(new Option(
                    `${trainer.nombre} ${trainer.firstLastName} ${trainer.secondLastName}`,
                    trainer.userID
                ));
            });
        },
        error: function (xhr, stats, error) {
            console.error('Error al cargar entrenadores.');
        }
    });

    // Enviar Datos del Formulario
    $('#createAppointmentForm').submit(function (event) {
        event.preventDefault();

        // Recoger los valores del formulario
        ClientID = $('#Cliente').val();
        TrainerID = $('#Entrenador').val();
        AppointmentDate = $('#FechaHora').val();
        DurationInMinutes = $('#DurationInMinutes').val();
        CreatedAt = new Date();
        Notes = 'Cita de Medición';
        ClientName = $('#Cliente option:selected').text();
        TrainerName = $('#Entrenador option:selected').text();
        CalendarID = "0";

        // objeto de datos para enviar
        var appointmentData = {
            ClientID,
            TrainerID,
            AppointmentDate,
            DurationInMinutes,
            CreatedAt,
            Notes,
            CalendarID,
            ClientName,
            TrainerName
        };

        // Enviar los datos al servidor
        $.ajax({
            url: apiUrl,
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(appointmentData),
            success: function (response) {
                Swal.fire({
                    icon: 'success',
                    title: 'Cita creada',
                    text: 'Cita creada correctamente.',
                    confirmButtonText: 'Aceptar'
                }).then(() => {
                    window.location.href = 'ListAppointments'; // Redirigir a la lista de citas
                });
            },
            error: function (xhr, status, error) {
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'Hubo un problema al crear la cita.',
                    confirmButtonText: 'Aceptar'
                });
            }
        });
    });
});