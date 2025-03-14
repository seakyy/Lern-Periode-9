using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using WebAPI_295.Models;

var builder = WebApplication.CreateBuilder(args);

// 1️ Key aus appsettings.json holen
var keyString = builder.Configuration["JwtSettings:SecretKey"];
if (string.IsNullOrEmpty(keyString))
{
    throw new Exception("JWT SecretKey ist nicht in appsettings.json definiert!");
}

var key = Encoding.UTF8.GetBytes(keyString); // Exakt 32 Zeichen, kein Base64! Da sonst Key nicht funktioniert

// 2️ JWT-Authentifizierung konfigurieren
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// 3️ Datenbank konfigurieren & sicherstellen, dass sie erstellt wird
builder.Services.AddDbContext<WarehouseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 4️ Rollenbasierten Zugriff für WarehouseManager sicherstellen
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireWarehouseManagerRole", policy => policy.RequireRole("WarehouseManager"));
});

// 5️ Controller, Swagger & API-Dokumentation aktivieren
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


var app = builder.Build();

// 6️ Datenbank automatisch erstellen & mit Startdaten füllen
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<WarehouseContext>();
    dbContext.Database.EnsureCreated();
}

// 7️ CORS-Regeln setzen (nur bestimmte Ursprünge erlauben)
app.UseCors(policy =>
    policy.WithOrigins("http://localhost:3000") // Falls man React oder Angular benutzten sollte (In diesem Modul Nein)
          .AllowAnyMethod()
          .AllowAnyHeader()
          .AllowCredentials());

// 8️ Middleware einrichten
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
