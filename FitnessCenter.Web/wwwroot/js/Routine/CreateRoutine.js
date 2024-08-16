$(document).ready(function () {

    let apiUrlCustomers = API_URL_BASE + '/Account/GetCustomers';
    let apiUrlTrainers = API_URL_BASE + '/Account/GetTrainers';
    let apiUrl = API_URL_BASE + '/Routine/CreateRoutine';

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

    $('#createRoutineForm').submit(function (event) {
        event.preventDefault(); // Evita el envío del formulario por defecto

        // Recolectar datos del formulario
        var clienteId = $('#Cliente').val();
        var entrenadorId = $('#Entrenador').val();
        var fechaHora = new Date();

        var ejercicio = $('#Ejercicio').val();
        var tipoEjercicio = $('#TipoEjercicio').val();
        var equipo = $('#Equipo').val();
        var sets = $('#Sets').val();
        var repeticiones = $('#Repeticiones').val();
        var peso = $('#Peso').val();
        var duracion = $('#Duracion').val();
        var dia = $('#dia').val();

        // Construir el objeto en el formato requerido
        var routineData = {
            routine: {
                clientID: clienteId,
                trainerID: entrenadorId,
                createdAt: fechaHora
            },
            exerciseDetails: [
                {
                    exerciseID: ejercicio,
                    equipmentID: equipo,
                    sets: sets,
                    repetitions: repeticiones,
                    weight: peso,
                    durationInSeconds: duracion,
                    amrapTimeLimitInSeconds: 0,
                    amrapRepetitions: 0,
                    dia: dia
                }
            ]
        };

        // Enviar la solicitud AJAX
        $.ajax({
            url: '/api/YourEndpoint', // Cambia esto por la URL de tu API
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(routineData),
            success: function (response) {
                // Mostrar un mensaje de éxito con SweetAlert
                Swal.fire({
                    icon: 'success',
                    title: '¡Rutina asignada!',
                    text: 'La rutina ha sido registrada correctamente.',
                    confirmButtonText: 'OK'
                }).then(() => {
                    window.location.href = '/Trainer/Home'; // Redirigir a la página de inicio
                });
            },
            error: function (xhr, status, error) {
                // Mostrar un mensaje de error con SweetAlert
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'Ocurrió un error al registrar la rutina. Por favor, intenta de nuevo.',
                    confirmButtonText: 'OK'
                });
            }
        });
    });
});
