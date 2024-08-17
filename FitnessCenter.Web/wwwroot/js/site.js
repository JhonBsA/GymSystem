// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
    
// Write your JavaScript code.

var API_URL_BASE = "https://localhost:7252/api";

const userID = localStorage.getItem('UserID');
const roleID = localStorage.getItem('RoleID');
const currentPath = window.location.pathname;


//<script src="https://cdn.datatables.net/plug-ins/1.10.24/i18n/Spanish.json"></script> link para los textos en español
$(document).ready(function () {
    $('#routineTable').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.24/i18n/Spanish.json"
        }
    });
});

$('#logoutButton').click(function () {
    localStorage.removeItem('UserID'); // Eliminar el UserID del localStorage
    window.location.href = '/LandingPage'; // Redirigir a la página de inicio
});

document.addEventListener('DOMContentLoaded', function () {

    // Define las rutas permitidas por rol
    const routesByRole = {
        '1':
            [
                //Home
                "/Customers/Home",

                //Login
                "/Account/Login",

                //Vistas generales
                "/Routine/ListRoutines",
                "/Customers/Appointments",
                "/Customers/Classes",
                "/Customers/Trainings",
                "/Customers/Progress",

                //Perfil
                "/Account/Profile",
                "/Account/ForgotPassword",
                "/Account/PasswordReset",
                "/Account/Verify"
            ],
        '2':
            [
                //Home
                "/Receptionist/HomeReceptionist",

                //Login
                "/Account/Login",

                //Citas
                "/Appointment/ListAppointments",
                "/Appointment/CreateAppointment",
                "/Appointment/UpdateAppointment/",

                //Clientes
                "/Customers/CreateCustomers",
                "/Customers/ListCustomers",
                "/Customers/UpdateCustomers/",

                //Clases Grupales
                "/Trainer/CreateGroupClasses",
                "/Trainer/ListGroupClasses",
                "/Trainer/UpdateGroupClasses/",

                //Perfil
                "/Receptionist/Profile",
                "/Account/ForgotPassword",
                "/Account/PasswordReset",
                "/Account/Verify"
            ],
        '3':
            [
                //Home
                "/Trainer/Home",

                //Login
                "/Account/Login",

                //Vistas generales
                "/Routine/CreateRoutine",
                "/Trainer/CreateAppointment",
                "/Trainer/CreateMeasurement",
                "/Trainer/CreateExercise",
                "/Trainer/CreateExerciseType",
                "/Trainer/CreateEquipment",

                //Perfil
                "/Trainer/Profile",
                "/Account/ForgotPassword",
                "/Account/PasswordReset",
                "/Account/Verify"
            ],
        '4':
            [

            ]
            
    };

    function disableLink(link) {
        link.addEventListener('click', function (event) {
            event.preventDefault();
            Swal.fire({
                icon: 'error',
                title: 'Acceso Denegado',
                text: 'No tienes acceso a esta vista.',
                confirmButtonText: 'Entendido'
            });
        });
    }

    // Verifica si la ruta actual está permitida
    const allowedRoutes = routesByRole[roleID] || [];
    if (!allowedRoutes.includes(currentPath)) {
        // Si la ruta no está permitida, redirigir o mostrar un mensaje
        Swal.fire({
            icon: 'error',
            title: 'Acceso Denegado',
            text: 'No tienes acceso a esta vista.',
            confirmButtonText: 'Entendido'
        }).then(() => {
            window.location.href = allowedRoutes[0] || '/'; // Redirige a la primera ruta permitida o a la página de inicio
        });
    } else {
        // Deshabilitar los enlaces a vistas no permitidas
        document.querySelectorAll('a').forEach(link => {
            const href = link.getAttribute('href');
            if (!allowedRoutes.includes(newURL(href, window.location.origin).pathname)) {
                disableLink(link);
            }
        });
    }
});
