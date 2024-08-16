$(document).ready(() => {

    const userID = localStorage.getItem('UserID');

    if (userID) { 
        let apiUrl = API_URL_BASE + '/Account/GetUserByUserID?userID=' + userID;

        $.ajax({
            url: apiUrl,
            method: "GET",
            dataType: "json",
        })
            .done((result) => {
                console.log("Datos del Usuario", result); 
                if (result) {
                    $("#nombre").text(result.nombre + " " + result.firstLastName);
                    $("#cedula").text('Cédula: ' + result.cedula);
                    $("#telefono").text('Teléfono: ' + result.phone);
                    $("#correo").text('Correo: ' + result.email);
                    $("#mostrarUsuario").show(); 
                }
            })
            .fail((error) => {
                Swal.fire({
                    title: "Error",
                    text: "No se pudo obtener la información del usuario.",
                    icon: "error",
                });
            });
    } else {
        Swal.fire({
            title: "Error",
            text: "No se encontró el ID de usuario en el almacenamiento local.",
            icon: "error",
        });
    }

});
