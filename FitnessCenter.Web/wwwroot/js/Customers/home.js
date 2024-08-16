$(document).ready(() => {
    let userId = localStorage.getItem('UserID'); // Obtener el UserID desde localStorage // revisar esto
    console.log(localStorage.getItem('UserID'));

    if (!userId) {
        Swal.fire({
            title: 'Error',
            text: 'No se encontró el ID de usuario. Por favor, inicia sesión de nuevo.',
            icon: 'error'
        });
        return;
    }

    let table = $('#trainingTable').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.24/i18n/Spanish.json"
        },
        data: [],
        columns: [
            { data: 'exerciseName' },
            { data: 'dateLogged' },
            { data: 'setsCompleted' },
            { data: 'repetitionsCompleted' },
            { data: 'weightUsed' },
            { data: 'durationInSeconds' }
        ]
    });

    const capitalize = (word) => {
        return word.charAt(0).toUpperCase() + word.slice(1);
    }

    const prepareTableData = (result) => {
        const formattedData = result.map(training => ({
            exerciseName: capitalize(training.excerciseName),
            dateLogged: new Date(training.dateLogged).toLocaleDateString('es-ES'),
            setsCompleted: training.setsCompleted,
            repetitionsCompleted: training.repetitionsCompleted,
            weightUsed: training.weightUsed,
            durationInSeconds: training.durationInSeconds
        }));

        table.clear().rows.add(formattedData).draw();
    }

    let apiUrl = API_URL_BASE + '/TrainingLogs/UserTrainingLogs?userId=' + userId;
    console.log(apiUrl); 
    $.ajax({
        url: apiUrl,
        method: 'GET',
        data: { userId: userId }, 
        dataType: 'json'
    })
        .done((result) => {
            console.log(result);
            prepareTableData(result);
        })
        .fail((error) => {
            console.error('Hubo un error con la búsqueda:', error.statusText);
        });

    
    
});
