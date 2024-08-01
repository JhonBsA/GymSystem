console.log("probando conexión");

let table = $('#appointmentTable').DataTable({
    data: [], // Inicialmente la tabla no tiene datos
    columns: [
        { data: 'cliente' },
        { data: 'entrenador' },
        { data: 'fechaHora' },
        { data: 'estado' },
        {
            data: null,
            render: function (data, type, row) {
                return `
                                            <div class="actions-btn">
                                                <button class="btn btn-assign" onclick="viewDetails('${row.cliente}')">Detalles</button>
                                            </div>
                                        `;
            }
        }
    ],
    createdRow: function (row, data, dataIndex) {
        $(row).find('td').css('background-color', '#34495E'); // Color de fondo de las celdas
    }
});

const prepareTableData = (result) => {
    result.map(appointment => {
        appointment.cliente = appointment.cliente ? appointment.cliente.charAt(0).toUpperCase() + appointment.cliente.slice(1) : '';
        appointment.entrenador = appointment.entrenador ? appointment.entrenador.charAt(0).toUpperCase() + appointment.entrenador.slice(1) : '';
        appointment.fechaHora = appointment.fechaHora || '';
        appointment.estado = appointment.estado ? appointment.estado.charAt(0).toUpperCase() + appointment.estado.slice(1) : '';
    });
    table.clear().rows.add(result).draw(); // Limpia la tabla y agrega las filas con los datos preparados
}

$(document).ready(() => {
    let apiUrl = API_URL_BASE + '/Appointment/GetAllAppointments'; // URL de la API para obtener los datos de las citas
    $.ajax({
        url: apiUrl,
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

function viewDetails(appointmentId) {
    // Implementar lógica para ver detalles de la cita
    console.log('Ver detalles de la cita:', appointmentId);
}