using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaAplicacion;
using CapaEntidades;



namespace CapaPresentacion.Controllers
{
    public class EmpleadoController : Controller
    {
        public ActionResult Index()
        {
            var empleados = AppEmpleados.Instancia.ListarEmpleados();
            return View(empleados);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                AppEmpleados.Instancia.InsertarEmpleado(empleado);
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        public ActionResult Eliminar(int id)
        {
            AppEmpleados.Instancia.EliminarEmpleado(id);
            return RedirectToAction("Index");
        }
    }
}