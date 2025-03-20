﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaAplicacion;
using CapaEntidades;


namespace CapaPresentacion.Controllers
{
    public class ActividadController : Controller
    {
        public ActionResult Lista()
        {
            var actividades = AppActividad.Instancia.ListarActividades();
            return View(actividades);
        }

        public ActionResult Insertar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insertar(Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                AppActividad.Instancia.InsertarActividad(actividad);
                return RedirectToAction("Lista");
            }
            return View(actividad);
        }

        public ActionResult Editar(int id)
        {
            var actividad = AppActividad.Instancia.ListarActividades().FirstOrDefault(a => a.IdActividad == id);
            return View(actividad);
        }

        [HttpPost]
        public ActionResult Editar(Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                AppActividad.Instancia.ActualizarActividad(actividad);
                return RedirectToAction("Lista");
            }
            return View(actividad);
        }

        public ActionResult Eliminar(int id)
        {
            var actividad = AppActividad.Instancia.ListarActividades().FirstOrDefault(a => a.IdActividad == id);
            return View(actividad);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult ConfirmarEliminar(int id)
        {
            AppActividad.Instancia.EliminarActividad(id);
            return RedirectToAction("Lista");
        }
    }
}
