const dataTableConfig = {
    columns: [
        { data: 'roleID' },
        { data: 'name' },
        {
            data: null,
            render: (data, type, row) => {
                return `
                        <div class="actions-btn">
                        <a href="/Role/AssignRole?roleId=${row.roleID}" class="btn btn-primary">Asignar</a>
                        <a href="/Role/EditRole?roleId=${row.roleID}" class="btn btn-primary">Editar</a>
                        <a href="/Role/DeleteRole?roleId=${row.roleID}" class="btn btn-primary">Eliminar</a>
                       </div>`;
            }
        }
    ],
    createdRow: (row, data, dataIndex) => {
        $(row).find('td').css('background-color', '#34495E');
    }
};


$(document).ready(() => {
    let apiUrl = API_URL_BASE + '/Role/RetrievaAllRoles';
    $.ajax({
        url: apiUrl,
        method: 'GET',
        success: (result) => {
            dataTableConfig.data = result;
            $('#rolesTable').DataTable(dataTableConfig);
        },
        error: (error) => {
            Swal.fire({
                title: "Mensaje",
                text: "Hubo un error al obtener los datos: " + error.statusText,
                icon: "error",
            });
        }
    });
});