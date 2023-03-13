using Microsoft.AspNetCore.Authentication.JwtBearer;
using Aspbackend.Models.Settings;
using AspBackend.Utilities;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using AspBackend.Middelwares;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


    var connection = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));

// Чтение секции из appsettings
    var authOptionsConfiguration = builder.Configuration.GetSection("JWTSettings");
    builder.Services.Configure<JWTAuthenticationSettings>(authOptionsConfiguration);

// JWT Authentication
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "Server",
                ValidateAudience = true,
                ValidAudience = "Server",
                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        System.Text.Encoding.ASCII.GetBytes(
                            "b8f20a180332b616356de04d8942736909c26ed1d9fef89989baa6b58c5b0d36")),
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
            };
        });

//Настройка Cors
    builder.Services.AddCors(
        opions => { opions.AddPolicy("CorsPolicy", policy => { policy.WithOrigins("https://localhost:3000"); }); });

//Настройка JSON 
    builder.Services.AddMvc().AddJsonOptions(o =>
    {
        o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        o.JsonSerializerOptions.MaxDepth = 0;
    });

//Настройка сервисов
    builder.Services.AddTransient<IUserServices, UserServices>();
    builder.Services.AddTransient<ITodoServices, TodoServices>();
    builder.Services.AddTransient<IProjectServices, ProjectServices>();

// Mapper service registration
    builder.Services.AddAutoMapper(typeof(AutomapperSettings));

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();

// Настройка Swagger
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Web-Api Todo",
            Description = "WebApi Todo"
        });
    });


    var app = builder.Build();

// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors("CorsPolicy");

    app.UseMiddleware<ExceptionHanlingMiddleware>();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();