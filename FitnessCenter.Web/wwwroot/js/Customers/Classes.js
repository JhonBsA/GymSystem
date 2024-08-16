$(document).ready(function () {
    const userId = localStorage.getItem('UserID');
    console.log('UserID:', userId);

    const apiUrl = 'https://localhost:7252/api/GroupClass/GetAll';
    console.log('API URL:', apiUrl);

    $.ajax({
        url: apiUrl,
        method: 'GET',
        dataType: "json",
        contentType: 'application/json',
        success: function (data) {
            console.log('Datos recibidos:', data); 
            var classesContainer = $('#clasesGrupales');
            classesContainer.empty();

            if (Array.isArray(data)) {
                console.log('Datos en array:', data);
                data.forEach(function (groupClass) {
                    console.log('Procesando clase:', groupClass);

                   
                    var scheduleDate = new Date(groupClass.schedule);
                    var formattedTime = scheduleDate.toLocaleTimeString([], {
                        hour: '2-digit',
                        minute: '2-digit',
                        hour12: true
                    });

                    var classCard = `
                        <div class="col-md-4 mb-4">
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title">${groupClass.className || 'Nombre no disponible'}</h5>
                                    <p class="card-text">Capacidad: ${groupClass.capacity || 'No disponible'}</p>
                                    <p class="card-text">Hora: ${formattedTime || 'No disponible'}</p>
                                </div>
                            </div>    
                        </div>`;
                    console.log('Tarjeta de clase:', classCard); 
                    classesContainer.append(classCard);
                });
            } else {
                console.error('Los datos recibidos no son un array.');
            }
        },
        error: function (xhr, status, error) {
            console.error('Error al obtener las clases grupales:', error);
        }
    });
});
