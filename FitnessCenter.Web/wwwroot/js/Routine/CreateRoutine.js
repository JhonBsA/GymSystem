$(document).ready(function () {
    let apiUrlTrainers = API_URL_BASE + '/Account/GetTrainers';
    let apiUrlCustomers = API_URL_BASE + '/Account/GetCustomers';


    // Cargar clientes
    $.ajax({
        url: apiUrlCustomers,
        method: 'GET',
        success: function (data) {
            var clienteSelect = $('#Cliente');
            clienteSelect.empty();

            
            data.forEach(function (customer) {
                clienteSelect.append(new Option(
                    `${customer.nombre} ${customer.firstLastName} ${customer.secondLastName}`, // Concatenar nombre y apellidos
                    customer.userID 
                ));
            });
        },
        error: function (xhr, status, error) {
            console.error('Error al cargar clientes:', error);
        }
    });


    //Entrenadores
    $.ajax({
        url: apiUrlTrainers,
        method: 'GET',
        success: function (data) {
            var entrenadorSelect = $('#Entrenador');
            entrenadorSelect.empty(); 
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

    // Cargar tipos de ejercicio
    $.ajax({
        url: API_URL_BASE + '/ExerciseTypes/GetAllExerciseTypes',
        type: 'GET',
        success: function (data) {
            var tipoEjercicioSelect = $('#TipoEjercicio');
            tipoEjercicioSelect.empty();
            data.forEach(function (tipo) {
                tipoEjercicioSelect.append(
                    $('<option></option>')
                        .attr('value', tipo.exerciseTypeID)
                        .text(tipo.typeName)
                );
            });
        },
        error: function (xhr, status, error) {
            console.error('Error al cargar tipos de ejercicio:', error);
        }
    });

    // Cargar equipos
    $.ajax({
        url: API_URL_BASE + '/Equipment/GetAllEquipments',
        type: 'GET',
        success: function (data) {
            var equipoSelect = $('#Equipo');
            equipoSelect.empty();
            data.forEach(function (equipo) {
                equipoSelect.append(
                    $('<option></option>')
                        .attr('value', equipo.equipmentID) 
                        .text(equipo.name) 
                );
            });
        },
        error: function (xhr, status, error) {
            console.error('Error al cargar equipos:', error);
        }
    });
    // Cargar ejercicios
    $.ajax({
        url: API_URL_BASE + '/Exercise/GetAllExercises', 
        type: 'GET',
        success: function (data) {
            console.log(data)
            var ejercicioSelect = $('#Ejercicio');
            ejercicioSelect.empty();
            data.forEach(function (ejercicio) {
                ejercicioSelect.append(
                    $('<option></option>')
                        .attr('value', ejercicio.exerciseID) 
                        .text(ejercicio.name)
                );
            });
        },
        error: function (xhr, status, error) {
            console.error('Error al cargar ejercicios:', error);
        }
    });


    $('#createRoutineForm').submit(function (event) {
        event.preventDefault();

        var routineData = {
            routine: {
                clientID: $('#Cliente').val(),
                trainerID: $('#Entrenador').val(),
                createdAt: new Date().toISOString()
            },
            exerciseDetails: [
                {
                    exerciseID: $('#Ejercicio').val(),
                    equipmentID: $('#Equipo').val(),
                    sets: parseInt($('#Sets').val()), 
                    repetitions: parseInt($('#Repeticiones').val()), 
                    weight: parseFloat($('#Peso').val()), 
                    durationInSeconds: parseInt($('#Duracion').val()) || null,
                    amrapTimeLimitInSeconds: null,  
                    amrapRepetitions: null,  
                    dia: parseInt($('#Dia').val()) || null
                }
            ]
        };

        console.log('Datos a enviar:', routineData);

        $.ajax({
            url: API_URL_BASE + '/Routine/CreateRoutine',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(routineData),
            success: function (response) {
                Swal.fire('Éxito', 'La rutina ha sido registrada correctamente', 'success');
            },
            error: function (xhr, status, error) {
                console.error('Error al registrar rutina:', error);
                Swal.fire('Error', 'No se pudo registrar la rutina', 'error');
            }
        });
    });
});