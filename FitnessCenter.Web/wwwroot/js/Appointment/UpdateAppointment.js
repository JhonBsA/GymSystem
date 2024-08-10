
document.addEventListener('DOMContentLoaded', function ()/*$(document).ready(function ()*/ {
    let apiUrlTrainers = API_URL_BASE + '/Account/GetTrainers';
    let apiUrl = API_URL_BASE + '/Appointment/UpdateAppointment';

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
    appointmentID = pathname.split('/').pop();
    let apiUrlId = API_URL_BASE + '/Appointment/GetAppointmentById?appointmentID=' + appointmentID;

    if (appointmentID) {
        // Llama a la API para obtener los detalles de la cita
        $.ajax({
            url: apiUrlId,
            method: 'GET',
            success: function (data) {
                // Actualiza el HTML con los datos de la cita
                $('#appointmentID').text(`ID: ${data.appointmentID}`);
                $('#AppointmentID').val(data.appointmentID);
                $('#ClientName').val(data.clientName);
                $('#ClientID').val(data.clientID); //Esta oculto
                $('#Entrenador').val(data.trainerID);
                $('#FechaHora').val(new Date(data.appointmentDate).toISOString().slice(0, 16));
                $('#DurationInMinutes').val(data.durationInMinutes);
            },
            error: function (error) {
                console.error('Error al obtener los detalles de la cita:', error);
            }
        });
    } else {
        console.error('No se encontró el ID de la cita en la URL');
    }

    //Enviar Datos del Formulario
    $('#updateAppointmentForm').submit(function (event) {
        event.preventDefault();

        // Recoger los valores del formulario
        ClientID = $('#ClientID').val();
        TrainerID = $('#Entrenador').val();
        AppointmentDate = $('#FechaHora').val();
        DurationInMinutes = $('#DurationInMinutes').val();
        Notes = 'Cita de Medición';
        ClientName = $('#Cliente option:selected').text();
        TrainerName = $('#Entrenador option:selected').text();

        // objeto de datos para enviar
        var appointmentData = {
            appointmentID,
            ClientID,
            TrainerID,
            AppointmentDate,
            DurationInMinutes,
            Notes,
            ClientName,
            TrainerName
        };

        // Enviar los datos al servidor
        console.log(appointmentData);

        $.ajax({
            url: apiUrl,
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(appointmentData),
            success: function (response) {
                Swal.fire({
                    icon: 'success',
                    title: 'Cita Actualizada',
                    text: response.Message,
                    confirmButtonText: 'OK'
                })
            },
            error: function (xhr, status, error) {
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'Hubo un problema al actualizar la cita.',
                    confirmButtonText: 'OK'
                });
                console.error('Error al actualizar la cita:', xhr.responseText);
            }
        });
    });
});
