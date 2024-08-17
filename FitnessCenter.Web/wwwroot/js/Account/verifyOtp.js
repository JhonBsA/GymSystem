const verifyOTP = (e) => {
    e.preventDefault();

    const data = {
        otp: $("#otp").val().trim(),
        newPassword: $("#password").val().trim()
    };
    const confirmPassword = $("#confirmPassword").val().trim();

    if (!data.otp || !data.newPassword || !confirmPassword) {
        Swal.fire({
            title: "Error",
            text: "Todos los campos son obligatorios",
            icon: "error",
            confirmButtonText: "Aceptar",
            background: "#f8d7da"
        });
        return;
    }

    if (data.newPassword !== confirmPassword) {
        Swal.fire({
            title: "Error",
            text: "Las contraseñas no coinciden",
            icon: "error",
            confirmButtonText: "Aceptar",
            background: "#f8d7da"
        });
        return;
    }

    const apiUrl = API_URL_BASE + "/Account/PasswordResetOTP";
    $.ajax({
        url: apiUrl,
        method: "POST",
        data: JSON.stringify(data),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    })
        .done((result) => {
            console.log(result);
            Swal.fire({
                title: "Contraseña actualizada con éxito",
                icon: "success",
                 text: '',
                confirmButtonText: 'Aceptar'
               
            });
        }).fail((response) => {
            console.log(response.responseText);
            Swal.fire({
                title: "Error",
                text: "Se ha presentado un fallo",
                icon: "error",
                confirmButtonText: "Aceptar",
               
            });
        });
}

$("#verifyOtpForm").on('submit', verifyOTP);
