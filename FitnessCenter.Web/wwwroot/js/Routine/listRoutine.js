$(document).ready(function () {
    const apiUrl = API_URL_BASE + '/Routine/RetrieveRoutineByClient';

    function loadRoutineData() {
        console.log('probando conexion');
        $.ajax({
            url: apiUrl,
            data: { userId:3 },//Preguntar, como obtengo el userid dinamicamente
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
                    // docu de datatables
                    if ($.fn.DataTable.isDataTable('#routineTable')) {//verifica que la tb este inicializada como una instance de datateblas
                        let table = $('#routineTable').DataTable();
                        table.clear().rows.add(tableData).draw();//Esto lo que hace es limpia los datos de la tb, agregar nuevas filas y actualiza la tb
                        console.log('DataTable updated with new data.');
                    } else {
                        $('#routineTable').DataTable({//si la tb no esta initialized tonces la inicializacion con tbd define las colums y sus title 
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
        let apiUrl = API_URL_BASE + '/TrainingLogs/AddTrainingLog?ClientId';

        const clientId = 3;//preguntar, como hago para obtener el id del cliente dinamicamente?? /logi

        //https://localhost:7252/api/Account/GetUserByUserID?UserID=10
        //let apiUrlId = API_URL_BASE + '/Account/GetUserByID?UserID=' + UserID;

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