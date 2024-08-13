// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
    
// Write your JavaScript code.

var API_URL_BASE = "https://localhost:7252/api";



//<script src="https://cdn.datatables.net/plug-ins/1.10.24/i18n/Spanish.json"></script> link para los textos en español
$(document).ready(function () {
    $('#routineTable').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.24/i18n/Spanish.json"
        }
    });
});