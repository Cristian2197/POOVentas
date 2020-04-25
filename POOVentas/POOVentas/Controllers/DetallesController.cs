using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ent = Entidades;
using dom = Dominio;

namespace POOVentas.Controllers
{
    public class DetallesController : Controller
    {
        // GET: Detalles
        public ActionResult Index()
        {
            var _detalles = new dom.DetalleD().DetalleList();
            return View(_detalles);
        }
        [HttpGet]
        public ActionResult Crear()
        {
            var _detalles = new ent.DetalleE();
            return PartialView("Crear", _detalles);
        }
        [HttpPost]
        public ActionResult Crear(ent.DetalleE factura)
        {
            new dom.DetalleD().CrearDetalle(factura);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var _detalle = new dom.DetalleD().DetallesPorId(id);
            return PartialView("Editar", _detalle);
        }
        [HttpPost]
        public ActionResult Editar(ent.DetalleE FacturaEditado)
        {
            new dom.DetalleD().ModificarDetalle(FacturaEditado);
            return RedirectToAction("Index");
        }
    }
}