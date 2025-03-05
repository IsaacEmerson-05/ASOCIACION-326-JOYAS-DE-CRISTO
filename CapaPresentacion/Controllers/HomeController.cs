using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace CapaPresentacion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult InicioSesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InicioSesion(string usuario, string contrasena)
        {
            // Aquí puedes agregar la lógica para validar el usuario y la contraseña
            // Por ahora, solo validamos con un usuario y contraseña predefinidos
            if (usuario == "admin" && contrasena == "admin123")
            {
                // Credenciales correctas, redirigir al menú principal
                return RedirectToAction("MenuPrincipal");
            }

            // Credenciales incorrectas, mostrar mensaje de error
            ViewBag.Message = "Usuario o contraseña incorrecta.";
            return View();
        }

        public ActionResult MenuPrincipal()
        {
            return View();
        }
    }
}