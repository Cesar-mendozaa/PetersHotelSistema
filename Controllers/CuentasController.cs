using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaApartados.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class CuentasController : Controller
{
    private readonly PetersHotelContext _context;

    public CuentasController(PetersHotelContext context)
    {
        _context = context;
    }

    // Método para mostrar el formulario de registro (GET)
    public IActionResult Register()
    {
        return View();
    }

    // Método para manejar el envío del formulario de registro (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(Usuario usuario)
    {
        if (ModelState.IsValid)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Login));
        }
        return View(usuario);
    }

    // Método para mostrar el formulario de inicio de sesión (GET)
    public IActionResult Login()
    {
        return View();
    }

    // Método para manejar el envío del formulario de inicio de sesión (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.CorreoElectronico == model.CorreoElectronico && u.Contrasena == model.Contrasena);
            if (usuario != null)
            {
                // Autenticar al usuario
                HttpContext.Session.SetString("UsuarioID", usuario.Id.ToString());
                HttpContext.Session.SetString("UsuarioNombre", usuario.Nombre);
                HttpContext.Session.SetString("UsuarioRol", usuario.Rol); // Asumiendo que tienes un campo "Rol" en tu modelo de usuario

                // Redirigir según el rol del usuario
                if (usuario.Rol == "Administrador")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("UsuarioIndex", "Home");
                }
            }
            ModelState.AddModelError("", "Correo electrónico o contraseña incorrectos.");
        }
        return View(model);
    }

    // Método para cerrar sesión
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction(nameof(Login));
    }
}
