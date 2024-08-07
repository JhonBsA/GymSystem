
let table = $('#appointmentTable').DataTable({
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
        //{ data: 'States' },
        {
            data: null,
            render: function (data, type, row) {
                return `
                    <div class="actions-btn">
                    <button class="btn btn-assign" onclick="List()">Detalles</button>
                    </div>
                `;
            }
        }
    ],
    createdRow: function (row, data, dataIndex) {
        $(row).find('td').css('background-color', '#34495E'); // Color de fondo de las celdas
    }
});

function List() {
    console.log("llegue")
    window.location.href = `ListAppointments`;
}

const getTodayDate = () => {
    let today = new Date();
    let day = String(today.getDate()).padStart(2, '0');
    let month = String(today.getMonth() + 1).padStart(2, '0'); // Enero es 0
    let year = today.getFullYear();
    return `${year}-${day}-${month}`;
}

const getTomorrowDate = () => {
    let today = new Date();
    today.setDate(today.getDate() + 1); // Sumar un día
    let day = String(today.getDate()).padStart(2, '0');
    let month = String(today.getMonth() + 1).padStart(2, '0'); // Enero es 0
    let year = today.getFullYear();
    return `${year}-${day}-${month}`;
}

$(document).ready(() => {
    let apiUrl = API_URL_BASE + '/Appointment/RetrieveByDateRange'; // URL de la API para obtener los datos de las citas
    let today = getTodayDate();
    let tomorrow = getTomorrowDate();

    $.ajax({
        url: apiUrl,
        type: 'GET',
        data: {
            StartDate: today + 'T00:00:00',
            EndDate: tomorrow + 'T00:00:00'
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
});

const prepareTableData = (result) => {
    result.forEach(appointment => {
        appointment.ClientName = appointment.clientName || '';
        appointment.TrainerName = appointment.trainerName || '';
        appointment.AppointmentDate = appointment.appointmentDate || '';

    });
    table.clear().rows.add(result).draw(); // Limpia la tabla y agrega las filas con los datos preparados
}

function viewDetails(appointmentId) {
    // Implementar lógica para ver detalles de la cita
    console.log('Ver detalles de la cita:', appointmentId);
}