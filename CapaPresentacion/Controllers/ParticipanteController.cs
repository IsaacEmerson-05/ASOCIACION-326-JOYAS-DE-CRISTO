using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaAplicacion;
using CapaEntidades;
using CapaPresentacion.Models;



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
        public ActionResult Crear(ParticipanteModel participanteModel)
        {
            if (ModelState.IsValid)
            {
                // Convertir de ParticipanteModel a Participante
                var participante = new CapaEntidades.Participante
                {
                    IdParticipante = participanteModel.IdParticipante,
                    Nombres = participanteModel.Nombre
                    // Agrega más propiedades si es necesario
                };

                // Pasar el objeto correcto
                AppParticipante.Instancia.InsertarParticipante(participante);
                return RedirectToAction("Index");
            }

            return View(participanteModel);
        }


        [HttpPost, ActionName("Eliminar")]
        public ActionResult ConfirmarEliminar(int id)
        {
            var participante = AppParticipante.Instancia.ListarParticipante()
                                  .FirstOrDefault(p => p.IdParticipante == id);

            if (participante == null)
            {
                return HttpNotFound("Participante no encontrado");
            }

            AppParticipante.Instancia.EliminarParticipante(id);
            return RedirectToAction("Index");
        }
    }
}
