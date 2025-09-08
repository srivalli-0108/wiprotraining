using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using DoConnectBackend.Data;

using Microsoft.EntityFrameworkCore;
using DoConnectBackend.Services;
using System.Reflection;
using DoConnectBackend.Models;




var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5067");

// 🔐 JWT Configuration
var jwtSettings = builder.Configuration.GetSection("Jwt");
var secretKey = jwtSettings["Key"];

if (string.IsNullOrEmpty(secretKey))
{
    throw new InvalidOperationException("JWT secret key is missing in appsettings.json.");
}

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

// 🔧 Add Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// 🔧 Dependency Injection
builder.Services.AddScoped<IUserService, UserService>();


// 📦 Database Configuration
var connectionString = builder.Configuration.GetConnectionString("DoConnectDb");
builder.Services.AddDbContext<DoConnectContext>(options =>
    options.UseSqlServer(connectionString));

// 🔐 Swagger + JWT Bearer support
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DoConnect API", Version = "v1", Description = "A Q&A platform API for DoConnect" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    // Add JWT Bearer definition
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.  
                        Enter 'Bearer' [space] and then your token in the text input below.  
                        Example: 'Bearer eyJhbGciOiJI...'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // Add global JWT security requirement
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});
var app = builder.Build();

// 🌐 Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DoConnect API V1");
        c.RoutePrefix = string.Empty; // Swagger at root
    });
}

//app.UseHttpsRedirection();

app.UseAuthentication(); // 🔐 JWT must come before Authorization
app.UseCors("AllowAngularApp");
app.MapGet("/api/users", () =>
    new List<UserDto> {
        new UserDto { Id = 1, Name = "Srivalli" },
        new UserDto { Id = 2, Name = "Asmi" }
    });
    
app.UseRouting();
app.UseStaticFiles();
app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapFallbackToFile("index.html"); // send unknown paths to Angular
});


app.MapControllers();

app.Run();
