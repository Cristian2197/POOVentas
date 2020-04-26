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
    public class CategoriasController : Controller
    {
        // GET: Categorias
        public ActionResult Index()
        {
            var _categorias = new dom.CategoriasD().CategoriaList();
            return View(_categorias);
        }
        [HttpGet]
        public ActionResult Crear()
        {
            var _categoria = new ent.CategoriaE();
            return PartialView("Crear", _categoria);
        }
        [HttpPost]
        public ActionResult Crear(ent.CategoriaE categoria)
        {
            new dom.CategoriasD().CrearCategoria(categoria);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var _categoria = new dom.CategoriasD().CategoriasPorID(id);
            return PartialView("Editar", _categoria);
        }
        [HttpPost]
        public ActionResult Editar(ent.CategoriaE categoriaEditado)
        {
            new dom.CategoriasD().ModificarCategoria(categoriaEditado);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Detalle(int id)
        {
            var _detalle = new dom.CategoriasD().CategoriasPorID(id);
            return PartialView("Detalle", _detalle);
        }
    }
}
