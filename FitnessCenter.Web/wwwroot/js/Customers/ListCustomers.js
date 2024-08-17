let table = $('#customerTable').DataTable({
    "language": {
        "url": "https://cdn.datatables.net/plug-ins/1.10.24/i18n/Spanish.json"
    },
    data: [], // Inicialmente la tabla no tiene datos
    columns: [
        {
            data: 'FullName',
            render: function (data, type, row) {
                // Concatenar el nombre completo
                return data || '';
            }

        },
        { data: 'phone' },
        { data: 'email' },
        {
            data: null,
            render: function (data, type, row) {
                return `
                    <div class="actions-btn">
                        <button class="btn btn-primary" onclick="updateCustomer('${row.userID}')">Editar</button>
                    </div>
                    <div class="actions-btn">
                        <button class="btn btn-assign" onclick="deleteCustomer('${row.cedula}')">Eliminar</button>
                    </div>
                `;
            }
        }
    ],
    createdRow: function (row, data, dataIndex) {
        $(row).find('td').css('background-color', '#34495E'); // Color de fondo de las celdas
    }
});

function updateCustomer(userID) {
    window.location.href = `/Customers/UpdateCustomers/${userID}`;
}

function deleteCustomer(cedula) {
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
                url: `${API_URL_BASE}/Account/DeleteUser`,
                type: 'DELETE',
                contentType: 'application/json',
                data: JSON.stringify({ cedula: cedula }),
                success: function () {
                    Swal.fire(
                        '¡Eliminado!',
                        'El cliente ha sido eliminado.',
                        'success'
                    ).then(() => {
                        table.row($(`button[onclick="deleteCustomer('${cedula}')"]`).parents('tr')).remove().draw();
                    });
                },
                error: function () {
                    Swal.fire(
                        'Error',
                        'Hubo un problema al eliminar el cliente.',
                        'error'
                    );
                }
            });
        }
    });
}

$(document).ready(() => {
    $.ajax({
        url: `${API_URL_BASE}/Account/GetAllUsers`,
        type: 'GET'
    })
        .done((result) => {
            prepareTableData(result); 
        })
        .fail((error) => {
            Swal.fire({
                title: "Mensaje",
                text: "Hubo un error al recuperar los clientes",
                icon: "error",
            });
        });
});

const prepareTableData = (data) => {
    
    const filteredData = data.filter(customer => !customer.nombre.startsWith('del.'));

    const preparedData = filteredData.map(customer => {
        return {
            ...customer,
            FullName: `${customer.nombre || ''} ${customer.firstLastName || ''} ${customer.secondLastName || ''}`.trim()
        };
    });
    table.clear().rows.add(preparedData).draw(); // Limpia la tabla y agrega las filas con los datos preparados
}
