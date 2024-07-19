console.log("conectando js");

function previewImage(event) {
    var reader = new FileReader();
    reader.onload = function () {
        var output = document.getElementById('preview');
        output.src = reader.result;
        output.style.display = 'block';
    }
    reader.readAsDataURL(event.target.files[0]);
}

const createUserDetails = (e) => {
    e.preventDefault();
    
    // Crear un objeto FormData
    const formData = new FormData();

    // Crear un objeto de usuario con los datos del formulario
    const user = {
        cedula: $("#identificacion").val(),
        nombre: $("#nombre").val(),
        firstLastName: $("#primerApellido").val(),
        secondLastName: $("#segundoApellido").val(),
        telefono: $("#telefono").val(),
        correo: $("#correoElectronico").val()
    };

    // Añadir los datos del usuario al FormData
    formData.append("user", JSON.stringify(user));

    // Añadir la imagen al FormData si existe
    const file = document.getElementById("fotoPerfil").files[0];
    if (file) {
        formData.append("fotoPerfil", file);
    }

    const apiUrl = API_URL_BASE + "/api/Account/CreateUserDetails";

    $.ajax({
        url: apiUrl,
        method: "POST",
        data: formData,
        processData: false,
        contentType: false,
        success: (result) => {
            console.log(result);
            Swal.fire({
                title: "Registro",
                text: "Usuario registrado con éxito",
                icon: "success",
            });
        },
        error: (response) => {
            console.log(response.responseText);
            Swal.fire({
                title: "Registro",
                text: "Se ha presentado un fallo",
                icon: "error",
            });
        }
    });
};

// Corregir el ID del formulario en el selector
$("#createUserForm").on('submit', createUserDetails);
