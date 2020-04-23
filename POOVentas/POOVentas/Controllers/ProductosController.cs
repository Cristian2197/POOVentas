using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ent = Entidades;
using dom = Dominio;


namespace POOVentas.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            var _pedido = new dom.ProductosD().ProductosList();
            return View(_pedido);
        }
        [HttpGet]
        public ActionResult Crear()
        {
            var _productos = new ent.ProductosE();
            return PartialView("Crear", _productos);
        }
        [HttpPost]
        public ActionResult Crear(ent.ProductosE producto)
        {
            new dom.ProductosD().CrearProducto(producto);
            return RedirectToAction("Index");
        }
    }
}