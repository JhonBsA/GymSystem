$(document).ready(function () {
    $('#saveButton').on('click', function (event) {
        event.preventDefault();

        var roleName = $('#RoleName').val();

        const apiUrl = API_URL_BASE + "/Role/CreateRole";

        $.ajax({
            url: apiUrl,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ Name: roleName }),
            success: function (response) {
                console.log(response)
                Swal.fire({
                    icon: 'success',
                    title: 'Rol creado',
                    text: 'El rol ha sido creado exitosamente!',
                    confirmButtonText: 'OK'
                }).then((result) => {
                    if (result.isConfirmed) {
                        window.location.href = 'ListRoles'; // Redirige a la lista de roles o donde prefieras
                    }
                });
            },
            error: function (xhr, status, error) {
                var errorMessage = xhr.responseJSON ? xhr.responseJSON.message : 'Ocurrió un error';
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: errorMessage,
                    confirmButtonText: 'OK'
                });
            }
        });
    });

    $('#cancelButton').on('click', function (event) {
        event.preventDefault();
        window.location.href = 'ListRoles'; // Redirige a la lista de roles o donde prefieras
    });
});
