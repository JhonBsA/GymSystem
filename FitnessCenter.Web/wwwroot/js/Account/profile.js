const getUser = () => {
    let apiUrl = API_URL_BASE + '/Account/GetAllUsers'; 

    $.ajax({
        url: apiUrl,
        method: "GET",
        dataType: "json",
    })
        .done((result) => {
            console.log("Datos del Usuario", result); // Imprime en la consola los datos obtenidos exitosamente de la DB
            if (result) {
                $("#nombre").text(result.nombre + " " + result.firstLastName);
                $("#cedula").text('Cedula: ' + result.cedula);
                $("#telefono").text('Telefono: ' + result.phone);
                $("#correo").text('Correo: ' + result.email);
                $("#mostrarUsuario").show(); // Muestra los datos del usuario
            }
        })
        .fail((error) => {
            Swal.fire({
                title: "Error",
                text: "No se pudo obtener la información del usuario.",
                icon: "error",
            });
        });
};


$(document).ready(() => {
    getUser();
});
