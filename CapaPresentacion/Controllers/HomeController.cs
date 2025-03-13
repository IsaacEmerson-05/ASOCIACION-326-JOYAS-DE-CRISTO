using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaPresentacion.Models;

namespace CapaPresentacion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Aquí deberías obtener la lista de participantes desde la base de datos o cualquier otra fuente
            var participantes = new List<ParticipanteModel>
            {
                new ParticipanteModel { IdParticipante = 1, Nombre = "Juan Perez" },
                new ParticipanteModel { IdParticipante = 2, Nombre = "Maria Gomez" }
            };

            return View(participantes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Página de descripción de la aplicación.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Página de contacto.";
            return View();
        }

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