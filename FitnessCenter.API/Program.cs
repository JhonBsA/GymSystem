
/*var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();*/

var NocheCorsPolicy = "NocheCorsPolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: NocheCorsPolicy,
        policy =>
        {
            policy.WithOrigins("https://localhost:52108",
                               "https://localhost:7252"); //URLs permitidas en el CORS
            policy.AllowAnyHeader(); //application/json  application/xml application/text
            policy.AllowAnyMethod(); //GET, POST, PUT, DELETE
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(NocheCorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.UseCors("NocheCorsPolicy");

app.Run();

/*var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: "NocheCorsPolicy",
//        policy =>
//        {
//            policy.WithOrigins("https://localhost:52109");
//            policy.AllowAnyHeader(); // application/json, application/xml, application/text
//            policy.AllowAnyMethod(); // GET, POST, PUT, DELETE
//        });
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FitnessCenter API V1");
//        c.RoutePrefix = string.Empty; // This makes Swagger UI available at the app's root (e.g. http://localhost:5188/)
//    });
//}

//app.UseHttpsRedirection();

//app.UseRouting();

//app.UseCors("NocheCorsPolicy");

//app.UseAuthorization();

//app.MapControllers();

//// Default route for root URL
//app.MapGet("/", () => "Welcome to the Fitness Center API");

//app.Run();

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
            policy.WithOrigins("https://localhost:52108");
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