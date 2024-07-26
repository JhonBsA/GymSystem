const createRegisterUsers = (e) => {
    e.preventDefault();

    const user = {
        Cedula: $("#identificacion").val(),
        Nombre: $("#nombre").val(),
        FirstLastName: $("#primerApellido").val(),
        SecondLastName: $("#segundoApellido").val(),
        Phone: $("#telefono").val(),
        Email: $("#correoElectronico").val()
    };

    const apiUrl = API_URL_BASE + "/Account/CreateUser";

   

}