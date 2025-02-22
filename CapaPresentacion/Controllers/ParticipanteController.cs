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
        // GET: Participante
        public ActionResult Index()
        {
            return View();
        }

        // POST: Participante/Create
        [HttpPost]
        public ActionResult Create(Participante participante)
        {
            if (ModelState.IsValid)
            {
                appParticipante.Instancia.InsertarParticipante(participante);
                return RedirectToAction("Index");
            }
            return View(participante);
        }
    }
}