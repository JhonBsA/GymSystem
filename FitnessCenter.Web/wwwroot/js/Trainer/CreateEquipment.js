$(document).ready(function () {
    $('#Form').submit(function (event) {
        event.preventDefault();

        const userId = localStorage.getItem('UserID');
        console.log('UserID:', userId);


        var equipmentData = {
            equipmentID: 0,
            name: $("#name").val(),
            type: $("#type").val()
        };

        const apiUrl = API_URL_BASE + '/Equipment/CreateEquipment';
        $.ajax({
            url: apiUrl,
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(equipmentData),
            success: function (response) {
               
                Swal.fire({
                    title: '¡Éxito!',
                    text: 'Equipo creado exitosamente.',
                    icon: 'success',
                    confirmButtonText: 'Aceptar'
                }).then((result) => {
                    if (result.isConfirmed) {
                        $('#Form')[0].reset(); 
                    }
                });
            },
            error: function (xhr, status, error) {

                Swal.fire({
                    title: 'Error',
                    text: 'Hubo un problema al crear el equipo. Por favor, inténtelo de nuevo.',
                    icon: 'error',
                    confirmButtonText: 'Aceptar'
                });
            }
        });
    });
});