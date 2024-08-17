
let table = $('#appointmentTable').DataTable({
    "language": {
        "url": "https://cdn.datatables.net/plug-ins/1.10.24/i18n/Spanish.json"
    },
    data: [], // Inicialmente la tabla no tiene datos
    columns: [
        { data: 'ClientName' },
        { data: 'TrainerName' },
        {
            data: 'AppointmentDate',
            render: function (data, type, row) {
                const date = new Date(data);
                const options = { year: 'numeric', month: '2-digit', day: '2-digit', hour: 'numeric', minute: 'numeric', hour12: true }
                return date.toLocaleDateString('en-US', options).replace(',', '');
            }
        },
    ],
    createdRow: function (row, data, dataIndex) {
        $(row).find('td').css('background-color', '#34495E'); // Color de fondo de las celdas
    }
});

const getTodayDate = () => {
    let today = new Date();
    let day = String(today.getDate()).padStart(2, '0');
    let month = String(today.getMonth() + 1).padStart(2, '0'); // Enero es 0
    let year = today.getFullYear();
    return `${year}-${month}-${day}`;
}

$(document).ready(() => {
    let apiUrl = API_URL_BASE + '/Appointment/RetrieveByDateRange'; // URL de la API para obtener los datos de las citas
    let today = getTodayDate();

    // Primero, obtener la última fecha de cita
    $.ajax({
        url: API_URL_BASE + '/Appointment/GetLastAppointmentDate',
        type: 'GET'
    })
        .done((response) => {

            let lastAppointmentDate = response;

            if (lastAppointmentDate) {
                // Extraer solo la fecha de lastAppointmentDate
                let lastDate = new Date(lastAppointmentDate).toISOString().split('T')[0];
                console.log(response);
                // Luego, usar esa fecha para buscar citas en el rango de hoy hasta la última fecha
                $.ajax({
                    url: apiUrl,
                    type: 'GET',
                    data: {
                        StartDate: today + 'T00:00:00',
                        EndDate: lastDate + 'T23:59:59'
                    }
                })
                    .done((result) => {
                        prepareTableData(result); // Si la solicitud es exitosa, prepara los datos y actualiza la tabla
                    })
                    .fail((error) => {
                        Swal.fire({
                            title: "Mensaje",
                            text: "There was an error with the search: " + error.statusText,
                            icon: "error",
                        });
                    });
            } else {
                console.error("lastAppointmentDate is undefined or null");
                Swal.fire({
                    title: "Mensaje",
                    text: "There was an error retrieving the last appointment date.",
                    icon: "error",
                });
            }
        })
        .fail((error) => {
            Swal.fire({
                title: "Mensaje",
                text: "There was an error retrieving the last appointment date: " + error.statusText,
                icon: "error",
            });
        });
});

const prepareTableData = (result) => {
    result.forEach(appointment => {
        appointment.ClientName = appointment.clientName || '';
        appointment.TrainerName = appointment.trainerName || '';
        appointment.AppointmentDate = appointment.appointmentDate || '';

    });
    table.clear().rows.add(result).draw(); // Limpia la tabla y agrega las filas con los datos preparados
}
