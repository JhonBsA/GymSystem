﻿
let table = $('#groupClassesTable').DataTable({
    "language": {
        "url": "https://cdn.datatables.net/plug-ins/1.10.24/i18n/Spanish.json"
    },
    data: [], // Inicialmente la tabla no tiene datos
    columns: [
        { data: 'ClassName' },
        {
            data: 'schedule',
            render: function (data, type, row) {
                const date = new Date(data);
                const options = {
                    year: 'numeric',
                    month: '2-digit',
                    day: '2-digit',
                    hour: 'numeric',
                    minute: 'numeric',
                    hour12: true
                }
                return date.toLocaleDateString('en-US', options).replace(',', '');
            }
        },
        { data: 'capacity' },
        {
            data: null,
            render: function (data, type, row) {
                return `
                    <div class="actions-btn">
                    <button class="btn btn-primary" onclick="editGrouClass('${row.classID}')">Editar</button>
                    </div>
                    <div class="actions-btn">
                    <button class="btn btn-assign" onclick="cancelGrouClass('${row.classID}')">Cancelar Cita</button>
                    </div>
                `;
            }
        }
    ],
    createdRow: function (row, data, dataIndex) {
        $(row).find('td').css('background-color', '#34495E'); // Color de fondo de las celdas
    }
});
function editGrouClass(classID) {
    window.location.href = `/Trainer/UpdateGroupClasses/${classID}`;
}

function cancelGrouClass(classId) {

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
                url: API_URL_BASE + '/GroupClass/DeleteGroupClass/' + classId,
                type: 'DELETE',
                success: function (response) {
                    Swal.fire(
                        '¡Eliminado!',
                        'La clase grupal ha sido eliminada.',
                        'success'
                    ).then(() => {
                        // Recargar la tabla después de eliminar la cita
                        location.reload();
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

$(document).ready(() => {
    let apiUrl = API_URL_BASE + '/GroupClass/GetAll'; // URL de la API para obtener los datos de las citas

    $.ajax({
        url: apiUrl,
        type: 'GET',
        success: function (result) {
            let filteredResults = result.filter(groupClass => {
                const classDate = new Date(groupClass.schedule);
                const today = new Date();
                today.setHours(0, 0, 0, 0); // Resetear la hora para comparar solo la fecha
                return classDate >= today;
            });
            // Prepara los datos y actualiza la tabla
            prepareTableData(filteredResults);
        },
        error: function (error) {
            Swal.fire({
                title: "Error",
                text: "Hubo un problema al obtener las clases grupales",
                icon: "error",
            });
        }
    });
});

const prepareTableData = (result) => {
    result.forEach(groupClass => {
        groupClass.ClassName = groupClass.className || '';
    })
    table.clear().rows.add(result).draw(); // Limpia la tabla y agrega las filas con los datos preparados
}

function viewDetails(classId) {
    // Implementar lógica para ver detalles de la cita
    console.log('Ver detalles de la clase grupal:', classId);
}