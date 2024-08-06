$(document).ready(function () {
    var apiUrl = API_URL_BASE + '/Routine/RetrieveRoutineByClient';

    function loadRoutineData() {
        $.ajax({
            url: apiUrl,
            data: { userId: 5 },
            method: 'GET',
            success: function (response) {
                console.log(response); // Verifica la estructura de la respuesta
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

                    if ($.fn.DataTable.isDataTable('#routineTable')) {
                        let table = $('#routineTable').DataTable();
                        table.clear().rows.add(tableData).draw();
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
                    }
                } else {
                    console.log("No se encontraron rutinas para el usuario.");
                }
            },
            error: function (err) {
                console.error('Error fetching routine data:', err);
            }
        });
    }

    $('#saveButton').on('click', function () {
        var routineData = $('#routineTable').DataTable().rows().data().toArray();
        var apiUrl = API_URL_BASE + '/Routine/SaveRoutine';

        // Imprimir los datos que se van a enviar
        console.log('Datos a enviar:', routineData);

        $.ajax({
            url: apiUrl,
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(routineData),
            success: function (response) {
                Swal.fire('Guardado', 'La rutina ha sido guardada exitosamente.', 'success');
            },
            error: function (err) {
                console.error('Error saving routine data:', err);
                Swal.fire('Error', 'Hubo un error al guardar la rutina.', 'error');
            }
        });
    });



    loadRoutineData();
});
