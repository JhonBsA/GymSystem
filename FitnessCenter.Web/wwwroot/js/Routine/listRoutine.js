$(document).ready(function () {
    var apiUrl = API_URL_BASE + '/Routine/RetrieveRoutineByClient';

    function loadRoutineData() {
        console.log('Loading routine data...'); // Mensaje de inicio
        $.ajax({
            url: apiUrl,
            data: { userId: 5 },
            method: 'GET',
            success: function (response) {
                console.log('Response received:', response); // Verifica la estructura de la respuesta
                if (Array.isArray(response) && response.length > 0) {
                    let tableData = [];

                    response.forEach(routine => {
                        if (routine.exerciseDetails && Array.isArray(routine.exerciseDetails)) {
                            routine.exerciseDetails.forEach(exercise => {
                                tableData.push([
                                    exercise.exerciseName || 'N/A',
                                    exercise.exerciseTypeName || 'N/A', // Agrega el nombre del tipo de ejercicio
                                    exercise.equipmentName || 'N/A',
                                    exercise.sets || 'N/A',
                                    exercise.repetitions || 'N/A',
                                    exercise.weight !== null ? exercise.weight : 'N/A',
                                    exercise.durationInSeconds !== null ? exercise.durationInSeconds : 'N/A',
                                    exercise.dia || 'N/A'
                                ]);
                            });
                        } else {
                            console.log("No se encontraron detalles de ejercicios en la rutina.");
                        }
                    });

                    console.log('Table data:', tableData); // Verifica los datos que se van a cargar en la tabla

                    if ($.fn.DataTable.isDataTable('#routineTable')) {
                        let table = $('#routineTable').DataTable();
                        table.clear().rows.add(tableData).draw();
                        console.log('DataTable updated with new data.');
                    } else {
                        $('#routineTable').DataTable({
                            data: tableData,
                            columns: [
                                { title: "Ejercicio" },
                                { title: "Tipo de Ejercicio" },
                                { title: "Equipo" },
                                { title: "Sets" },
                                { title: "Repeticiones" },
                                { title: "Peso" },
                                { title: "Duración (s)" },
                                { title: "Día" }
                            ]
                        });
                        console.log('DataTable initialized with new data.');
                    }
                } else {
                    console.log("No se encontraron rutinas para el usuario.");
                    alert("No se encontraron rutinas para el usuario.");
                }
            },
            error: function (err) {
                console.error('Error fetching routine data:', err);
                alert('Error fetching routine data: ' + err.responseText);
            }
        });
    }

    

    loadRoutineData();
});
$('#trainingRegistrationForm').submit(function (event) {
    event.preventDefault(); // Evitar el envío del formulario por defecto

    // Obtener los datos del formulario
    const trainingData = [{
        ExerciseName: $('#ExerciseName').val(),
        ExerciseTypeName: $("#ExerciseTypeName").val(),
        Sets: $('#Sets').val(),
        Repetitions: $('#Repetitions').val(),
        Weight: $('#Weight').val(),
        DurationInSeconds: $('#Duration').val(),
        Date: $('#Date').val()
    }];

    console.log('Training data to be sent:', trainingData); // Verifica los datos del formulario

    var apiUrl = API_URL_BASE + '/Routine/RegisterTraining';

    // Enviar los datos al servidor mediante AJAX
    $.ajax({
        url: apiUrl, // URL del endpoint para registrar el entrenamiento
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(trainingData), // Enviando una lista de objetos
        success: function () {
            // Manejar la respuesta exitosa del servidor
            Swal.fire({
                icon: 'success',
                title: 'Entrenamiento registrado',
                text: 'El entrenamiento ha sido registrado exitosamente.'
            });

            // Limpiar el formulario después del registro exitoso
            $('#trainingRegistrationForm')[0].reset();
            console.log('Form reset after successful training registration.');
        },
        error: function (xhr, status, error) {
            // Manejar los errores del servidor
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Ocurrió un error al registrar el entrenamiento. Por favor, intenta nuevamente.'
            });
            console.error('Error registering training:', error);
            alert('Error registering training: ' + error);
        }
    });
});
