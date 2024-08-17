$(document).ready(function () {
    
    $.ajax({
        url: API_URL_BASE + '/ExerciseTypes/GetAllExerciseTypes', 
        type: "GET",
        success: function (data) {
            var exerciseTypeSelect = $("#exerciseType");
            exerciseTypeSelect.empty(); 
            data.forEach(function (type) {
                exerciseTypeSelect.append(
                    $("<option></option>")
                        .attr("value", type.exerciseTypeID)
                        .text(type.typeName)
                );
            });
        },
        error: function (xhr, status, error) {
            console.error("Error al cargar los tipos de ejercicio:", error);
        }
    });

    $('#form').submit(function (event) {
        event.preventDefault();

        var exerciseData = {
            exerciseID: 0, 
            exerciseTypeID: $("#exerciseType").val(), 
            name: $("#name").val() 
        };

      
        console.log("Datos a enviar:", exerciseData);

        const apiUrl = API_URL_BASE + '/Exercise/CreateExercise'; 

        $.ajax({
            url: apiUrl,
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(exerciseData),
            success: function (response) {
               
                Swal.fire({
                    title: '¡Éxito!',
                    text: 'Ejercicio creado exitosamente.',
                    icon: 'success',
                    confirmButtonText: 'Aceptar'
                });
            },
            error: function (xhr, status, error) {
               
                Swal.fire({
                    title: 'Error',
                    text: 'Hubo un problema al crear el ejercicio. Por favor, inténtelo de nuevo.',
                    icon: 'error',
                    confirmButtonText: 'Aceptar'
                });
            }
        });
    });
});
