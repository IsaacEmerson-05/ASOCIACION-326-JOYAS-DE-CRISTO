using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaAplicacion;
using CapaEntidades;



namespace CapaPresentacion.Controllers
{
    public class ParticipanteController : Controller
    {
        public ActionResult Index()
        {
            var participantes = AppParticipante.Instancia.ListarParticipante();
            return View(participantes);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Participante participante)
        {
            if (ModelState.IsValid)
            {
                AppParticipante.Instancia.InsertarParticipante(participante);
                return RedirectToAction("Index");
            }
            return View(participante);
        }

        public ActionResult Eliminar(int id)
        {
            AppParticipante.Instancia.EliminarParticipante(id);
            return RedirectToAction("Index");
        }
    }
}