using FitnessCenter.Core;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS policy
builder.Services.AddCors(options => {
    options.AddPolicy(name: "NocheCorsPolicy",
        policy => {
            policy.WithOrigins("https://localhost:52108"); // Cambiado a tu valor
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        });
});

// Configure EmailService
builder.Services.AddSingleton<IEmailService>(sp =>
    new EmailService(
        builder.Configuration["Smtp:Server"],
        int.Parse(builder.Configuration["Smtp:Port"]),
        builder.Configuration["Smtp:User"],
        builder.Configuration["Smtp:Pass"]
    ));

// Configure UserManager
builder.Services.AddScoped<UserManager>(sp =>
    new UserManager(sp.GetRequiredService<IEmailService>())
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FitnessCenter API V1");
        c.RoutePrefix = string.Empty; // Esto hace que Swagger UI esté disponible en la raíz de la aplicación (por ejemplo, http://localhost:5188/)
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("NocheCorsPolicy"); // Habilitar CORS

app.UseAuthorization();

app.MapControllers();

// Ruta predeterminada para la URL raíz
app.MapGet("/", () => "Welcome to the Fitness Center API");

app.Run();
