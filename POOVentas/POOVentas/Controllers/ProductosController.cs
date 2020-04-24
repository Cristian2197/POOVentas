using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ent = Entidades;
using dom = Dominio;
using bd = Datos;



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
        //Codigo que crea la lista
        List<SelectListItem> ListaCat;
        private void llenarCat()
        {
            using (var BaseDatos = new bd.VentasPOOEntitiesConnection())
            {
                ListaCat = (from TablaCat in BaseDatos.CATEGORIA
                            select new SelectListItem
                            {
                                Text = TablaCat.nombre,
                                Value = TablaCat.id_categoria.ToString()
                            }).ToList();
                ListaCat.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            }
        }
        [HttpGet]
        public ActionResult Crear()
        {
            
            //Llenar el combobox
            llenarCat();
            ViewBag.lista = ListaCat;
            var _productos = new ent.ProductosE();
            return PartialView("Crear", _productos);
        }
        [HttpPost]
        public ActionResult Crear(ent.ProductosE producto)
        {
            new dom.ProductosD().CrearProducto(producto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            llenarCat();
            ViewBag.lista = ListaCat;
            var _producto = new dom.ProductosD().ProductoPorID(id);
            return PartialView("Editar", _producto);
        }
        [HttpPost]
        public ActionResult Editar(ent.ProductosE productoEditado)
        {
            new dom.ProductosD().ModificarProducto(productoEditado);
            return RedirectToAction("Index");
        }
    }
}