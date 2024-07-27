$(document).ready(function () {

    //var roleId = getParameterByName('roleId'); // Función para obtener parámetros de la URL

    //// Cargar el nombre actual del rol
    //$.ajax({
    //    url: API_URL_BASE + "/Role/GetRoleById?id=" + roleId, // Asegúrate de tener este endpoint en tu API
    //    type: 'GET',
    //    success: function (response) {
    //        $('#oldRoleName').val(response.roleName); // Ajusta según el formato de tu respuesta
    //    },
    //    error: function (xhr, status, error) {
    //        var errorMessage = xhr.responseJSON ? xhr.responseJSON.message : 'Ocurrió un error';
    //        Swal.fire({
    //            icon: 'error',
    //            title: 'Error',
    //            text: errorMessage,
    //            confirmButtonText: 'OK'
    //        });
    //    }
    //});

    $('#saveButton').on('click', function (event) {
        event.preventDefault();

        var oldRoleName = $('#oldRoleName').val(); // Obtener el nombre antiguo del rol
        var newRoleName = $('#newRoleName').val();

            const apiUrl = API_URL_BASE + "/Role/UpdateRoleName";

            $.ajax({
                url: apiUrl,
                type: 'PUT',
                contentType: 'application/json',
                data: JSON.stringify({ OldRoleName: oldRoleName, NewRoleName: newRoleName }),
                success: function (response) {
                    console.log(response)
                    Swal.fire({
                        icon: 'success',
                        title: 'Rol actualizado',
                        text: 'El rol ha sido actualizado exitosamente!',
                        confirmButtonText: 'OK'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            window.location.href = '/roles'; // Redirige a la lista de roles o donde prefieras
                        }
                    });
                },
                error: function (xhr, status, error) {
                    var errorMessage = xhr.responseJSON ? xhr.responseJSON.message : 'Rol no encontrado';
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
        window.location.href = '/roles'; // Redirige a la lista de roles o donde prefieras
    });
});

//function getParameterByName(name) {
//    name = name.replace(/[\[\]]/g, '\\$&');
//    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)')
//    results = regex.exec(window.location.href);
//    if (!results) return null;
//    if (!results[2]) return ''; 
//    return decodeURIComponent(results[2].replace(/\+/g, ' '));
//}