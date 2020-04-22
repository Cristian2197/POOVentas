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
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            var _clientes = new dom.ClientesD().ClientesList();
            return View(_clientes);
        }
        [HttpGet]
        public ActionResult Crear()
        {
            var _cliente = new ent.ClientesE();
            return PartialView("Crear", _cliente);
        }
        [HttpPost]
        public ActionResult Crear(ent.ClientesE cliente)
        {
            new dom.ClientesD().CrearCliente(cliente);
            return RedirectToAction("Index");
        }
    }
}