$(document).ready(function () {
    $('#form').submit(function (event) {
        event.preventDefault();

        var exerciseTypeData = {
            exerciseTypeID: 0,
            typeName: $("#typeName").val()
        };

        const apiUrl = API_URL_BASE + '/ExerciseTypes/CreateExerciseType';
        $.ajax({
            url: apiUrl,
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(exerciseTypeData),
            success: function (response) {
              
                Swal.fire({
                    title: '¡Éxito!',
                    text: 'Tipo de ejercicio creado exitosamente.',
                    icon: 'success',
                    confirmButtonText: 'Aceptar'
                }).then((result) => {
                    if (result.isConfirmed) {
                        $('#form')[0].reset(); 
                    }
                });
            },
            error: function (xhr, status, error) {

                Swal.fire({
                    title: 'Error',
                    text: 'Hubo un problema al crear el tipo de ejercicio. Por favor, inténtelo de nuevo.',
                    icon: 'error',
                    confirmButtonText: 'Aceptar'
                });
            }
        });
    });
});