using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MercDevs_ej2.Models;
using System.Diagnostics;

namespace MercDevs_ej2.Controllers
{
    public class LoginController : Controller
    {
        private readonly MercydevsEjercicio2Context _context;
        public LoginController(MercydevsEjercicio2Context context) {
            _context = context;
        }

        //GET USUARIO
        [HttpGet]
        public IActionResult Ingresar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ingresar(UsuarioLogin usuarioLogin)
        {
            //busca un solo usuario que coincida el correo y password ingresada por el login

            Debug.WriteLine("Ingresar controlador");
            Debug.Write("Ingresar ---------------------------");
            var usuario = await _context.Usuarios.
                Where(u =>
                    u.Correo == usuarioLogin.Correo &&
                    u.Password == usuarioLogin.Password
                ).FirstOrDefaultAsync();

                Console.Write(usuario);
            
            if(usuario == null)
            {
                ViewData["Mensaje"] = "Ingrese datos correctos";
                return View();
            }
            return RedirectToAction("Index", "Home");

        }
    }
}
