var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "NocheCorsPolicy",
        policy =>
        {
            policy.WithOrigins("https://localhost:52108"); // Cambiado a tu valor
            policy.AllowAnyHeader(); // application/json, application/xml, application/text
            policy.AllowAnyMethod(); // GET, POST, PUT, DELETE
        });
});

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

app.UseCors("NocheCorsPolicy");

app.UseAuthorization();

app.MapControllers();

// Ruta predeterminada para la URL raíz
app.MapGet("/", () => "Welcome to the Fitness Center API");

app.Run();
