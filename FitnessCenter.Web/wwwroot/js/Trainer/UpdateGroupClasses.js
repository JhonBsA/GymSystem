document.addEventListener('DOMContentLoaded', function () {
    let apiUrlTrainers = API_URL_BASE + '/Account/GetTrainers';
    const apiUrl = API_URL_BASE + '/GroupClass/UpdateGroupClass';

    // Cargar entrenadores
    $.ajax({
        url: apiUrlTrainers,
        method: 'GET',
        success: function (data) {
            var entrenadorSelect = $('#Entrenador');
            entrenadorSelect.empty(); // Limpiar el select actual
            data.forEach(function (trainer) {
                entrenadorSelect.append(new Option(
                    `${trainer.nombre} ${trainer.firstLastName} ${trainer.secondLastName}`,
                    trainer.userID
                ));
            });
        },
        error: function (xhr, stats, error) {
            console.error('Error al cargar entrenadores:', error);
        }
    });

    // Obtén el ID de la cita de la URL
    const pathname = window.location.pathname;
    const classID = pathname.split('/').pop();
    const apiUrlId = API_URL_BASE + '/GroupClass/GetById?classID=' + classID;


    if (classID) {
        $.ajax({
            url: apiUrlId,
            method: 'GET',
            success: function (data) {
                $('#idGroupClass').text(`ID: ${data.classID}`);
                $('#Nombre').val(data.className);
                $('#Entrenador').val(data.entrenadorId);
                $('#FechaHora').val(new Date(data.schedule).toISOString().slice(0, 16));
                $('#Cupo').val(data.capacity);
            },
            error: function (error) {
                console.error('Error al obtener los detalles de la clase grupal');
            }
        });
    } else {
        console.error('No se encontró el ID de la clase grupal en la URL');
    }

    // Enviar Datos del Formulario
    $('#updateGroupClassForm').submit(function (event) {
        event.preventDefault();

        const groupClassData = {
            classID,
            className: $('#Nombre').val(),
            capacity: $('#Cupo').val(),
            schedule: $('#FechaHora').val()
        };

        // Enviar los datos al servidor
        $.ajax({
            url: apiUrl,
            method: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(groupClassData),
            success: function (response) {
                Swal.fire({
                    icon: 'success',
                    title: 'Clase Actualizada',
                    text: 'La clase grupal se actualizó correctamente.',
                    confirmButtonText: 'Aceptar'
                }).then(() => {
                    window.location.href = '../ListGroupClasses';
                });
            },
            error: function (xhr, status, error) {
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'Hubo un problema al actualizar la clase grupal.',
                    confirmButtonText: 'Aceptar'
                });
                console.error('Error al actualizar la clase grupal:', xhr.responseText);
            }
        });
    });
});
