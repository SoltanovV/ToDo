using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ToDoTask.Models;
var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));


builder.Services.AddMvc();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Настройка информации Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Web-Api ToDo",
        Description = "WebApi для приложения ToDo"
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
app.UseHttpsRedirection();

app.MapControllers();

app.UseAuthorization();

app.Run();
