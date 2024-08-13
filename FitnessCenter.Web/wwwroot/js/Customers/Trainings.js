$(document).ready(function () {
    const apiUrl = API_URL_BASE + '/Appointment/GetAppointmentById';

    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        locale: 'es',
        events: function (info, successCallback, failureCallback) {
            $.ajax({
                url: apiUrl,
                type: 'GET',
                data: {
                    appointmentID: 9
                },
                success: function (response) {
                    console.log('Respuesta del servidor:', response);

                    var events = [];
                    if (response && typeof response === 'object') {
                        if (response.appointmentID) {
                            events.push({
                                title: "Cita",
                                start: new Date(response.appointmentDate).toISOString(), //convierte a formato iso
                                backgroundColor: '#28a745',
                                textColor: '#fff',
                                extendedProps: {
                                    trainerName: response.trainerName,
                                    clientName: response.clientName,
                                    notes: response.notes,
                                    appointmentDate: response.appointmentDate
                                }
                            });
                        } else {
                            console.error('No se encontró appointmentID en la respuesta:', response);
                        }
                    } else {
                        console.error('Se esperaba un objeto pero se recibió:', response);
                    }
                    console.log('Eventos para FullCalendar:', events);

                    successCallback(events);
                },
                error: function (xhr, status, error) {
                    console.error('Error al recuperar citas:', error);
                    alert('Error retrieving appointments');
                }
            });
        },
        eventClick: function (info) {
            mostrarDetallesCita(info.event);
        },
        dateClick: function (info) {
            manejarClickEnFecha(info.dateStr);
        },
        editable: false,
        droppable: false,
        selectable: true,
        eventContent: function (arg) {
            return {
                html: `<div class="fc-event-title" style="padding: 5px; border: 1px solid #ccc; border-radius: 3px; background-color: #28a745; color: #fff;">
                                                    Cita Personal
                                        </div>` };
        }
    });

    calendar.render();

    function mostrarDetallesCita(event) {
        var appointmentDate = new Date(event.extendedProps.appointmentDate);
        var options = { year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric', hour12: true };
        var formattedDate = appointmentDate.toLocaleString('es-ES', options);

        $('#appointment-details').show();
        $('#title').text('Cita de entrenamiento personal con el entrenador ' + event.extendedProps.trainerName);
        $('#hora').text('El ' + formattedDate);

        $('#book-appointment').show();
        $('#cancel-appointment').show();
    }

    function mostrarMensajeNoDisponibilidad(dateStr) {
        var options = { year: 'numeric', month: 'long', day: 'numeric' };
        var date = new Date(dateStr);
        var formattedDate = date.toLocaleDateString('es-ES', options);

        $('#appointment-details').show();
        $('#title').text('');
        $('#hora').html('<span class="texto-rojo">No se han registrado horas de disponibilidad para ' + formattedDate + '</span>');


        $('#book-appointment').hide();
        $('#cancel-appointment').show();
    }

    function manejarClickEnFecha(dateStr) {
        var eventsOnDate = calendar.getEvents().filter(event => {
            return event.startStr === dateStr;
        });

        if (eventsOnDate.length > 0) {
            mostrarDetallesCita(eventsOnDate[0]);
        } else {
            mostrarMensajeNoDisponibilidad(dateStr);
        }
    }

    $('#cancel-appointment').click(function () {
        $('#appointment-details').hide();
    });

    $('#appointment-details').hide();
});