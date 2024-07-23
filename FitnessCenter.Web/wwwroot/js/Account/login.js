import Swal from 'sweetalert2';

const initializeLoginForm = () => {
    $('#loginForm').on('submit', function (e) {
        e.preventDefault(); // Previene el envío del formulario

        const email = $('#email').val().trim();
        const password = $('#password').val().trim();

        if (email === '' || password === '') {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Todos los campos son obligatorios!',
            });
        } else {
            this.submit(); // Enviar el formulario si todos los campos están llenos
        }
    });
};

$(document).ready(initializeLoginForm);
