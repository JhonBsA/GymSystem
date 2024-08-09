$(document).ready(() => {
    let table = $('#trainingTable').DataTable({
        data: [],
        columns: [
            { data: 'exerciseName' },
            { data: 'exerciseTypeName' },
            { data: 'sets' },
            { data: 'repetitions' },
            { data: 'weight' },
            { data: 'duration' },
            { data: 'date' }
        ]
    });

    const capitalize = (word) => {
        return word.charAt(0).toUpperCase() + word.slice(1);
    }

    const prepareTableData = (result) => {
        result.map(training => {
            training.exerciseName = capitalize(training.exerciseName);
            training.exerciseTypeName = capitalize(training.exerciseTypeName);
        });
        table.clear().rows.add(result).draw();
    }

    let apiUrl = API_URL_BASE + `/Routine/GetAllTraining`; // Ajusta esta URL a la correcta
    $.ajax({
        url: apiUrl,
    })
        .done((result) => {
            prepareTableData(result);
        })
        .fail((error) => {
            Swal.fire({
                title: "Mensaje",
                text: "Hubo un error con la búsqueda: " + error,
                icon: "error",
            });
        });
});