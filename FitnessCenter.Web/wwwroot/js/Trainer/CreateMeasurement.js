document.addEventListener('DOMContentLoaded', function () {
    let apiUrlTrainers = API_URL_BASE + '/Account/GetTrainers';
    let apiUrl = API_URL_BASE + '/Measurement/PostMeasurement';

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
            console.error('Error al cargar entrenadores.');
        }
    });

    // Enviar Datos del Formulario
    $('#createMeasurementForm').submit(function (event) {
        event.preventDefault();

        var data = {
            email: $('#Email').val(),
            trainerID: parseInt($('#Entrenador').val()),
            weight: parseFloat($('#weight').val()),
            height: parseFloat($('#height').val()),
            bodyFatPercentage: parseFloat($('#bodyFatPercentage').val()),
            age: parseInt($('#age').val()),
            gender: $('#gender').val(),
            measuredAt: new Date().toISOString()
        };

        $.ajax({
            url: apiUrl,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (response) {
                Swal.fire({
                    title: 'Éxito',
                    text: 'La cita de medición se ha creado correctamente.',
                    icon: 'success'
                }).then(() => {
                    window.location.href = '/Trainer/Home';
                });
            },
            error: function (xhr, status, error) {
                // Manejo de errores, muestra un mensaje de error
                Swal.fire({
                    title: 'Error',
                    text: 'Ocurrió un error al crear la cita de medición',
                    icon: 'error'
                });
            }
        });
    });
});