using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ent = Entidades;
using dom = Dominio;

namespace POOVentas.Controllers
{
    public class FacturasController : Controller
    {
        // GET: Facturas
        public ActionResult Index()
        {
            var _facturas = new dom.FacturaD().FacturasList();
            return View(_facturas);
        }
        [HttpGet]
        public ActionResult Crear()
        {
            var _facturas = new ent.FacturaE();
            return PartialView("Crear", _facturas);
        }
        [HttpPost]
        public ActionResult Crear(ent.FacturaE factura)
        {
            new dom.FacturaD().CrearFactura(factura);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var _factura = new dom.FacturaD().FacturasPorId(id);
            return PartialView("Editar", _factura);
        }
        [HttpPost]
        public ActionResult Editar(ent.FacturaE FacturaEditado)
        {
            new dom.FacturaD().ModificarFactura(FacturaEditado);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult VerDetsFact(int id)
        {
            var DetallesDeFactura = new ent.DetalleE();
            DetallesDeFactura.Facturas = new dom.FacturaD().FacturasPorId(id);
            return View(DetallesDeFactura);
        }

        [HttpPost]
        public ActionResult VerDetsFact(ent.DetalleE DetsFacturaE)
        {
            var detalle = new ent.DetalleE();
            var producto = new dom.ProductosD().ProductoPorID(DetsFacturaE.id_producto);

            //Llena el total del detalle
            DetsFacturaE.precio = producto.precio * DetsFacturaE.cantidad;

            //Lleno la entidad que se enviará como parametro para crear el detalle
            detalle.id_factura = DetsFacturaE.Facturas.num_factura;
            detalle.precio = DetsFacturaE.precio;
            detalle.id_producto = DetsFacturaE.id_producto;
            detalle.cantidad = DetsFacturaE.cantidad;
            detalle.num_detalle = DetsFacturaE.num_detalle;

            new dom.DetalleD().CrearDetalle(detalle);
            return RedirectToAction("VerDetsFact");
        }
    }
}