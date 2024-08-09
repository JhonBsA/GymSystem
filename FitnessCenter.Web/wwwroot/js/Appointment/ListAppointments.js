
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
                    <button class="btn btn-primary" onclick="editAppointment('${row.appointmentID}')">Editar</button>
                    </div>
                    <div class="actions-btn">
                    <button class="btn btn-assign" onclick="cancelAppointment('${row.appointmentID}')">Cancelar Cita</button>
                    </div>
                `;
            }
        }
    ],
    createdRow: function (row, data, dataIndex) {
        $(row).find('td').css('background-color', '#34495E'); // Color de fondo de las celdas
    }
});
function editAppointment(appointmentID) {
    window.location.href = `/Appointment/Edit/${appointmentID}`;
}

function cancelAppointment(appointmentId) {

    console.log('Deleting appointment with ID:', appointmentId);

    Swal.fire({
        title: '¿Estás seguro?',
        text: "¡No podrás revertir esto!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sí, eliminarlo!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: API_URL_BASE + '/Appointment/DeleteAppointment?appointmentID='+appointmentId,
                type: 'DELETE',
                success: function (response) {
                    Swal.fire(
                        '¡Eliminado!',
                        'La cita ha sido eliminada.',
                        'success'
                    ).then(() => {
                        // Recargar la tabla después de eliminar la cita
                        table.row($(`button[onclick="cancelAppointment('${appointmentID}')"]`).parents('tr')).remove().draw();
                    });
                },
                error: function (error) {
                    Swal.fire(
                        'Error',
                        'Hubo un problema al eliminar la cita.',
                        'error'
                    );
                }
            });
        }
    });
}

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

function viewDetails(appointmentId) {
    // Implementar lógica para ver detalles de la cita
    console.log('Ver detalles de la cita:', appointmentId);
}