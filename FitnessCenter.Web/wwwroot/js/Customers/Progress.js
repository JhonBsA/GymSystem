$(document).ready(function () {

    const userId = localStorage.getItem('UserID');
    console.log(localStorage.getItem('UserID'));

    const apiUrl = API_URL_BASE + '/Measurement/GetByUser?userId=' + userId;

    console.log('Fetching data from:', apiUrl);

    $.ajax({
        url: apiUrl,
        method: 'GET',
        success: function (data) {
            console.log('Data fetched successfully:', data);

            const weights = data.map(m => m.weight);
            const bodyFatPercentages = data.map(m => m.bodyFatPercentage);
            const measuredAtDates = data.map(m => new Date(m.measuredAt).toLocaleDateString());

            console.log('Weights:', weights);
            console.log('Body Fat Percentages:', bodyFatPercentages);
            console.log('Measured Dates:', measuredAtDates);

            // Llamar a la función para renderizar el gráfico
            renderMeasurementChart(weights, bodyFatPercentages, measuredAtDates);
        },
        error: function (err) {
            console.error('Error fetching measurements:', err);
        }
    });
});

function renderMeasurementChart(weights, bodyFatPercentages, dates) {
    const ctx = document.getElementById('measurementChart').getContext('2d');
    const chart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: dates, // Las fechas de las mediciones
            datasets: [{
                label: 'Peso (kg)',
                data: weights, // Los pesos correspondientes
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 2,
                fill: false
            }, {
                label: 'Porcentaje de Grasa Corporal (%)',
                data: bodyFatPercentages, // Porcentajes de grasa corporal
                borderColor: 'rgba(153, 102, 255, 1)',
                borderWidth: 2,
                fill: false
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true,
                    title: {
                        display: true,
                        text: 'Valor'
                    }
                },
                x: {
                    title: {
                        display: true,
                        text: 'Fecha'
                    }
                }
            }
        }
    });
}