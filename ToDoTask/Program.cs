using AspBackend.Services;
using AspBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using ToDoTask.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddMvc();

builder.Services.AddEndpointsApiExplorer();

// Настройка политики Cors
builder.Services.AddCors(opions =>
{
    opions.AddPolicy(name: "CorsPolicy", policy =>
        {
            policy.WithOrigins("https://localhost:3000");
        });
});

//Настройка конвертации JSON 
builder.Services.AddMvc().AddJsonOptions(o => {
    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    o.JsonSerializerOptions.MaxDepth = 0;
});

//Создание сервисов
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<ITodoServices, TodoServices>();
builder.Services.AddTransient<IProjectServices, ProjectServices>();


// Настройки Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Web-Api ToDo",
        Description = "WebApi ��� ���������� ToDo"
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.MapControllers();

app.UseAuthorization();

app.Run();
