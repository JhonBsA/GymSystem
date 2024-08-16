document.addEventListener('DOMContentLoaded', function () {
    let apiUrlTrainers = API_URL_BASE + '/Account/GetTrainers';
    let apiUrlCreateClass = API_URL_BASE + '/GroupClass/CreateGroupClass';

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
        error: function (xhr, status, error) {
            console.error('Error al cargar entrenadores:', error);
        }
    });

    // Enviar Datos del Formulario
    $('#createGroupClassesForm').submit(function (event) {
        event.preventDefault();

        // Recoger los valores del formulario
        var className = $('#Nombre').val();
        var trainerID = $('#Entrenador').val();
        var schedule = $('#FechaHora').val();
        var capacity = $('#Cupo').val();

        // objeto de datos para enviar
        var classData = {
            ClassName: className,
            TrainerID: trainerID,
            Schedule: schedule,
            Capacity: capacity
        };

        // Enviar los datos al servidor
        $.ajax({
            url: apiUrlCreateClass,
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(classData),
            success: function (response) {
                Swal.fire({
                    icon: 'success',
                    title: 'Clase Creada',
                    text: 'Clase Grupal Creada con Éxito.',
                    confirmButtonText: 'OK'
                }).then(() => {
                    window.location.href = 'ListGroupClasses';
                });
            },
            error: function (xhr, status, error) {
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'Hubo un problema al crear la clase grupal.',
                    confirmButtonText: 'OK'
                });
            }
        });
    });
});
