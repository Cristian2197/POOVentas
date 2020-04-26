using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bd = Datos;
using ent = Entidades;
using Repositorio;
using System.Linq.Expressions;


namespace Dominio
{
    public class FacturaD
    {
        private Repositorio<bd.Factura> _repositorio = new Repositorio<bd.Factura>(new bd.VentasPOOEntitiesConnection());
        public IEnumerable<ent.FacturaE> FacturasList()
        {
            var _consultaBd = _repositorio.TraerTodo();
            var _facturas = AutoMapper.Mapper.Map<IEnumerable<bd.Factura>, IEnumerable<ent.FacturaE>>(_consultaBd);
            return _facturas;
        }
        public ent.FacturaE FacturasPorId(int id)
        {
            var _consultaBd = _repositorio.TraerUnoPorID(id);
            var _facturas = AutoMapper.Mapper.Map<bd.Factura, ent.FacturaE>(_consultaBd);
            return _facturas;
        }
        public void CrearFactura(ent.FacturaE _FacturaCrear)
        {
            var _adicionarFactura = AutoMapper.Mapper.Map<ent.FacturaE, bd.Factura>(_FacturaCrear);
            _repositorio.Adicionar(_adicionarFactura);
            _repositorio.Grabar();
        }
        public void ModificarFactura(ent.FacturaE _FacturaModificar)
        {
            var _modificarFactura = AutoMapper.Mapper.Map<ent.FacturaE, bd.Factura>(_FacturaModificar);
            _repositorio.Modificar(_modificarFactura);
            _repositorio.Grabar();
        }
        public void EliminarCliente(ent.FacturaE _FacturaEliminar)
        {
            var _eliminarFactura = AutoMapper.Mapper.Map<ent.FacturaE, bd.Factura>(_FacturaEliminar);
            _repositorio.Adicionar(_eliminarFactura);
            _repositorio.Grabar();
        }
        public IEnumerable<ent.FacturaE> BuscarFacturas(Expression<Func<bd.Factura, bool>> predicadoBusqueda)
        {
            var _consultaBd = _repositorio.Buscar(predicadoBusqueda);
            var _FacturasEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.Factura>, IEnumerable<ent.FacturaE>>(_consultaBd);
            return _FacturasEncontrados;
        }

        public ent.FacturaE BuscarUnFactura(Expression<Func<bd.Factura, bool>> predicadoBusqueda)
        {
            var _consultaBd = _repositorio.TraerUno(predicadoBusqueda);
            var _FacturaEncontrado = AutoMapper.Mapper.Map<bd.Factura, ent.FacturaE>(_consultaBd);
            return _FacturaEncontrado;
        }
    }
}
