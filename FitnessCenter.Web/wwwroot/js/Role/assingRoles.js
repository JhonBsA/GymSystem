console.log("probando conexión");

let table = $('#userTable').DataTable({
    data: [], 
    columns: [
        { data: 'cedula' },
        { data: 'nombre' },
        { data: 'firstLastName' },
        { data: 'secondLastName' },
        { data: 'phone' },
        { data: 'email' },
        { data: 'roleName' },
        {
            data: null,
            render: function (data, type, row) {
                return `
                       <div class="actions-btn">
                       <button class="btn btn-assign" onclick="assignRole('${row.cedula}')">Asignar</button>
                       <button class="btn btn-cancel" onclick="cancelAssignment('${row.cedula}')">Cancelar</button>
                        </div>
                     `;
            }
        }
    ],
    createdRow: function (row, data, dataIndex) {
        $(row).find('td').css('background-color', '#34495E'); //color de la celdas
    }
});

const prepareTableData = (result) => {
    result.map(user => {
        user.nombre = user.nombre ? user.nombre.charAt(0).toUpperCase() + user.nombre.slice(1) : '';
        user.firstLastName = user.firstLastName ? user.firstLastName.charAt(0).toUpperCase() + user.firstLastName.slice(1) : '';
        user.secondLastName = user.secondLastName ? user.secondLastName.charAt(0).toUpperCase() + user.secondLastName.slice(1) : '';
        user.phone = user.phone || '';
        user.email = user.email || '';
        user.roleName = user.roleName ? user.roleName.charAt(0).toUpperCase() + user.roleName.slice(1) : '';
    });
    table.clear().rows.add(result).draw(); // Limpia la tabla y agrega las filas con los datos preparados
}

$(document).ready(() => {
    let apiUrl = API_URL_BASE + '/Account/GetAllUsers'; 
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

function assignRole(userId) {
    // Implementar lógica para asignar rol
    console.log('Asignar rol al usuario:', userId);
}

function cancelAssignment(userId) {
    // Implementar lógica para cancelar asignación
    console.log('Cancelar asignación del usuario:', userId);
}