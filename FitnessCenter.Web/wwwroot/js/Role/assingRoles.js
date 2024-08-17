document.addEventListener('DOMContentLoaded', function () {
    let apiUrlUsers = API_URL_BASE + '/Account/GetCustomers'; // URL para obtener usuarios
    let apiUrlRoles = API_URL_BASE + '/Role/RetrievaAllRoles'; // URL para obtener roles
    let apiUrl = API_URL_BASE + '/Role/SetUserRole'; // URL para asignar roles

    // Filtrar usuarios que no comienzan con "del."
    function filterUsers(users) {
        return users.filter(user => !user.nombre.toLowerCase().startsWith('del.'));
    }

    // Cargar usuarios
    $.ajax({
        url: apiUrlUsers,
        method: 'GET',
        success: function (data) {
            var usuarioSelect = $('#Usuario');
            usuarioSelect.empty(); // Limpiar el select actual
            var filteredCustomers = filterUsers(data);
            filteredCustomers.forEach(function (user) {
                usuarioSelect.append(new Option(
                    `${user.nombre} ${user.firstLastName} ${user.secondLastName}`,
                    user.userID
                ));
            });
        },
        error: function (xhr, status, error) {
            console.error('Error al cargar usuarios');
        }
    });

    // Cargar roles
    $.ajax({
        url: apiUrlRoles,
        method: 'GET',
        success: function (data) {
            var rolSelect = $('#Rol');
            rolSelect.empty(); // Limpiar el select actual
            data.forEach(function (role) {
                rolSelect.append(new Option(
                    `${role.name}`,
                    role.name
                ));
            });
        },
        error: function (xhr, status, error) {
            console.error('Error al cargar roles');
        }
    });

    // Enviar Datos del Formulario
    $('#assignRoleForm').submit(function (event) {
        event.preventDefault();

        // Recoger los valores del formulario
        let userID = parseInt($('#Usuario').val());
        let roleName = $('#Rol').val();

        // Objeto de datos para enviar
        let roleAssignmentData = {
            userID,
            roleName
        };

        console.log(roleAssignmentData)

        // Enviar los datos al servidor
        $.ajax({
            url: apiUrl,
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(roleAssignmentData),
            success: function (response) {
                Swal.fire({
                    icon: 'success',
                    title: 'Rol asignado',
                    text: 'Rol asignado correctamente.',
                    confirmButtonText: 'Aceptar'
                }).then(() => {
                    window.location.href = "/Admin/Home";
                });
            },
            error: function (xhr, status, error) {
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'Hubo un problema al asignar el rol.',
                    confirmButtonText: 'Aceptar'
                });
            }
        });
    });
});
