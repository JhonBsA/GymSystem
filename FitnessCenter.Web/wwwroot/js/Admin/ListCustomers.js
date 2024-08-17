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
    ],
    createdRow: function (row, data, dataIndex) {
        $(row).find('td').css('background-color', '#34495E'); // Color de fondo de las celdas
    }
});

$(document).ready(() => {
    $.ajax({
        url: `${API_URL_BASE}/Account/GetAllUsers`,
        type: 'GET'
    })
        .done((result) => {
            prepareTableData(result); // Si la solicitud es exitosa, prepara los datos y actualiza la tabla
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
    // Filtra los datos para excluir usuarios con nombre 'del.'
    const filteredData = data.filter(customer => !customer.nombre.startsWith('del.'));

    const preparedData = filteredData.map(customer => {
        return {
            ...customer,
            FullName: `${customer.nombre || ''} ${customer.firstLastName || ''} ${customer.secondLastName || ''}`.trim()
        };
    });
    table.clear().rows.add(preparedData).draw(); // Limpia la tabla y agrega las filas con los datos preparados
}
