using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ent = Entidades;
using dom = Dominio;
using bd = Datos;
namespace POOVentas.Controllers
{
    public class FacturasController : Controller
    {
        //GET: Facturas
        public ActionResult Index()
        {
            var _facturas = new dom.FacturaD().FacturasList();
            return View(_facturas);
        }
        List<SelectListItem> ListaCli;
        private void llenarCli()
        {
            using (var BaseDatos = new bd.VentasPOOEntitiesConnection())
            {
                ListaCli = (from TablaCli in BaseDatos.CLIENTE
                            select new SelectListItem
                            {
                                Text = TablaCli.nombre + " " + TablaCli.apellido,
                                Value = TablaCli.id_cliente.ToString()
                            }).ToList();
                ListaCli.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            }
        }

        List<SelectListItem> ListaModoPago;
        private void llenarModoPago()
        {
            using (var BaseDatos = new bd.VentasPOOEntitiesConnection())
            {
                ListaModoPago = (from TablaModoPago in BaseDatos.MODO_PAGO
                                 select new SelectListItem
                                 {
                                     Text = TablaModoPago.nombre,
                                     Value = TablaModoPago.num_pago.ToString()
                                 }).ToList();
                ListaModoPago.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            }
        }
        [HttpGet]
        public ActionResult Crear()
        {
            llenarCli();
            ViewBag.lista = ListaCli;
            llenarModoPago();
            ViewBag.lista2 = ListaModoPago;
            var _factura = new ent.FacturaE();
            return PartialView("Crear", _factura);
        }

        [HttpPost]
        public ActionResult Crear(ent.FacturaE factura)
        {
            new dom.FacturaD().CrearFactura(factura);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult VerDetallesFact(int id)
        {
            var DetallesFact = new dom.FacturaD().FacturasPorId(id);
            return PartialView(DetallesFact);
        }

        [HttpPost]
        public ActionResult VerDetallesFact(ent.DetsFacturaE DetsFacturaE)
        {
            new dom.DetsFacturaD().CrearDetsFactura(DetsFacturaE);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult VerDetsFact(int id)
        {
            var DetallesDeFactura = new ent.DetsFacturaE();
            DetallesDeFactura.FACTURAS = new dom.FacturaD().FacturasPorId(id);
            //var DetallesFact = new dom.FacturasD().FacturasPorID(id);

            return View(DetallesDeFactura);
        }

        [HttpPost]
        public ActionResult VerDetsFact(ent.DetsFacturaE DetsFacturaE)
        {
            var detalle = new ent.DetsFacturaE();
            var producto = new dom.ProductosD().ProductoPorID(DetsFacturaE.id_producto);

            //Llena el total del detalle
            DetsFacturaE.precio = (decimal)(producto.precio * DetsFacturaE.cantidad);

            //Lleno la entidad que se enviará como parametro para crear el detalle
            detalle.num_factura = DetsFacturaE.FACTURAS.num_factura;
            detalle.precio = DetsFacturaE.precio;
            detalle.id_producto = DetsFacturaE.id_producto;
            detalle.cantidad = DetsFacturaE.cantidad;
            detalle.id_detFact = DetsFacturaE.id_detFact;

            new dom.DetsFacturaD().CrearDetsFactura(detalle);
            return RedirectToAction("VerDetsFact");
        }

       
        //[HttpGet]
        //public ActionResult Crear()
        //{
        //    var _facturas = new ent.FacturaE();
        //    return PartialView("Crear", _facturas);
        //}
        //[HttpPost]
        //public ActionResult Crear(ent.FacturaE factura)
        //{
        //    new dom.FacturaD().CrearFactura(factura);
        //    return RedirectToAction("Index");
        //}
        //[HttpGet]
        //public ActionResult Editar(int id)
        //{
        //    var _factura = new dom.FacturaD().FacturasPorId(id);
        //    return PartialView("Editar", _factura);
        //}
        //[HttpPost]
        //public ActionResult Editar(ent.FacturaE FacturaEditado)
        //{
        //    new dom.FacturaD().ModificarFactura(FacturaEditado);
        //    return RedirectToAction("Index");
        //}
    }
}