$(document).ready(() => {
    let table = $('#trainingTable').DataTable({
        data: [],
        columns: [
            { data: 'exerciseName'},
            { data: 'dateLogged'},
            { data: 'setsCompleted'},
            { data: 'repetitionsCompleted'},
            { data: 'weightUsed'},
            { data: 'durationInSeconds'}
        ]
    });

    const capitalize = (word) => {
        return word.charAt(0).toUpperCase() + word.slice(1);
    }

    const prepareTableData = (result) => {
        
        const formattedData = result.map(training => ({
            exerciseName: capitalize(training.excerciseName),
            dateLogged: new Date(training.dateLogged).toLocaleDateString('es-ES'), //pendiente revisar esto
            setsCompleted: training.setsCompleted,
            repetitionsCompleted: training.repetitionsCompleted,
            weightUsed: training.weightUsed,
            durationInSeconds: training.durationInSeconds
        }));

        table.clear().rows.add(formattedData).draw();
    }

    let apiUrl = API_URL_BASE + '/TrainingLogs/UserTrainingLogs'; 
    $.ajax({
        url: apiUrl,
        method: 'GET',
        data: { userId: 3 }, //Preguntar como se obtiene el userid dinamicamente 
        dataType: 'json' 
    })
        .done((result) => {
            prepareTableData(result);
        })
        .fail((error) => {
            Swal.fire({
                title: 'Mensaje',
                text: 'Hubo un error con la búsqueda: ' + error.statusText,
                icon: 'error'
            });
        });
});
