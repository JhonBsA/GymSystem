$(document).ready(function () {
    const apiUrl = API_URL_BASE + '/Routine/RetrieveRoutineByClient';

    function loadRoutineData() {
        console.log('Loading routine data...'); // Mensaje de inicio
        $.ajax({
            url: apiUrl,
            data: { userId: 3 },
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
                alert('Error fetching routine data: ' + (err.responseJSON ? err.responseJSON.message : err.statusText));
            }
        });
    }

    loadRoutineData(); 

    
    $('#trainingLogForm').on('submit', function (e) {
        e.preventDefault();
        let apiUrl = API_URL_BASE + '/TrainingLogs/AddTrainingLog';
        const clientId = 3;

        const trainingLog = {
            ClientID: clientId,
            ExcerciseName: $('#exerciseName').val(),
            DateLogged: new Date($('#dateLogged').val()).toISOString(),
            SetsCompleted: $('#setsCompleted').val(),
            RepetitionsCompleted: $('#repetitionsCompleted').val(),
            WeightUsed: $('#weightUsed').val(),
            DurationInSeconds: $('#durationInSeconds').val(),
        };

        $.ajax({
            url: apiUrl,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(trainingLog),
            success: function (response) {
                Swal.fire({
                    icon: 'success',
                    title: 'Éxito',
                    text: 'Training log created successfully.'
                });
            },

            error: function (jqXHR, textStatus, errorThrown) {
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'An error occurred: ' + (jqXHR.responseText || errorThrown)
                });
            }

        });
    });
});