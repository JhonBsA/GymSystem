$(document).ready(function () {

    const userId = localStorage.getItem('UserID');

    function loadRoutineData() {
        const apiUrl = API_URL_BASE + '/Routine/RetrieveRoutineByClient?userId=' + userId;

        $.ajax({
            url: apiUrl,
            method: 'GET',
            success: function (response) {
                console.log('Response received:', response);
                if (Array.isArray(response) && response.length > 0) {
                    let tableData = [];

                    response.forEach(routine => {
                        if (routine.exerciseDetails && Array.isArray(routine.exerciseDetails)) {
                            routine.exerciseDetails.forEach(exercise => {
                                tableData.push([
                                    exercise.exerciseName || 'N/A',
                                    exercise.exerciseTypeName || 'N/A',
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

                    console.log('Table data:', tableData);
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
                  
                }
            },
            error: function (err) {
                console.error('Error fetching routine data:', err);
               
            }
        });
    }

    
    loadRoutineData();

   
    $('#trainingLogForm').on('submit', function (e) {
        e.preventDefault();
        const apiUrl = API_URL_BASE + '/TrainingLogs/AddTrainingLog?userId=' + userId;

        const trainingLog = {
            ClientID: userId, 
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
        })
            .done((result) => {
                Swal.fire({
                    title: "Registro de entrenamiento exitoso",
                    icon: "success",
                    confirmButtonText: "Aceptar",
                });
            })
            .fail((jqXHR, textStatus, errorThrown) => {
                let errorMessage = "Registro incorrecto. Intente nuevamente";

                if (jqXHR.responseJSON && jqXHR.responseJSON.Message) {
                    errorMessage = jqXHR.responseJSON.Message;
                }

                Swal.fire({
                    title: "Error",
                    text: errorMessage,
                    icon: "error",
                    confirmButtonText: "Aceptar",
                });
            });
    });
});
