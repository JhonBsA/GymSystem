function updateAppointment() {
    var appointment = {
        ClienteId: $('#Cliente').val(),
        FechaHora: $('#FechaHora').val(),
        EntrenadorId: $('#Entrenador').val(),
        DurationInMinutes: $('#DurationInMinutes').val()
    };

    $.ajax({
        url: '/Appointment/UpdateAppointment',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(appointment),
        success: function (response) {
            window.location.href = '/Appointment/IndexAppointments';
        },
        error: function (error) {
            console.log(error);
            alert('Error al actualizar la cita.');
        }
    });
}