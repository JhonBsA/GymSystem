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
        // Ajusta los nombres de las propiedades del JSON para que coincidan con las columnas de la tabla
        const formattedData = result.map(training => ({
            exerciseName: capitalize(training.excerciseName),
            dateLogged: new Date(training.dateLogged).toLocaleDateString('es-ES'), // Ajusta el formato de la fecha según tu necesidad
            setsCompleted: training.setsCompleted,
            repetitionsCompleted: training.repetitionsCompleted,
            weightUsed: training.weightUsed,
            durationInSeconds: training.durationInSeconds
        }));

        table.clear().rows.add(formattedData).draw();
    }

    let apiUrl = API_URL_BASE + '/TrainingLogs/UserTrainingLogs'; // Ajusta esta URL a la correcta
    $.ajax({
        url: apiUrl,
        method: 'GET',
        data: { userId: 3 },// Asegúrate de que el método sea el correcto
        dataType: 'json' // Especifica el tipo de datos que esperas recibir
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
