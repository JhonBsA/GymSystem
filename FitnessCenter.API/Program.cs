
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
            policy.WithOrigins("https://localhost:7154");
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
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("NocheCorsPolicy");
app.MapControllers();
app.Run();
