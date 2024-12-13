using Microsoft.EntityFrameworkCore;
using SistemaApartados.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PetersHotelContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection"));
});

// Configurar la sesión
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Configurar HttpClient
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

// Habilitar el uso de sesiones
app.UseSession();

app.UseAuthorization();

// Configurar la ruta predeterminada para que apunte al controlador de cuentas y la acción de inicio de sesión
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cuentas}/{action=Login}/{id?}");

app.Run();
