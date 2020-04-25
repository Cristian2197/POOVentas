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
    public class DetalleD
    {
        private Repositorio<bd.DETALLE> _repositorio = new Repositorio<bd.DETALLE>(new bd.VentasPOOEntitiesConnection());
        public IEnumerable<ent.DetalleE> DetalleList()
        {
            var _consultaBd = _repositorio.TraerTodo();
            var _detalles = AutoMapper.Mapper.Map<IEnumerable<bd.DETALLE>, IEnumerable<ent.DetalleE>>(_consultaBd);
            return _detalles;
        }
        public ent.DetalleE DetallesPorId(int id)
        {
            var _consultaBd = _repositorio.TraerUnoPorID(id);
            var _detalles = AutoMapper.Mapper.Map<bd.DETALLE, ent.DetalleE>(_consultaBd);
            return _detalles;
        }
        public void CrearDetalle(ent.DetalleE _DetalleCrear)
        {
            var _adicionarDetalle = AutoMapper.Mapper.Map<ent.DetalleE, bd.DETALLE>(_DetalleCrear);
            _repositorio.Adicionar(_adicionarDetalle);
            _repositorio.Grabar();
        }
        public void ModificarDetalle(ent.DetalleE _DetalleModificar)
        {
            var _modificarDetalle = AutoMapper.Mapper.Map<ent.DetalleE, bd.DETALLE>(_DetalleModificar);
            _repositorio.Modificar(_modificarDetalle);
            _repositorio.Grabar();
        }
        public void EliminarDetalle(ent.DetalleE _DetalleEliminar)
        {
            var _eliminarDetalle = AutoMapper.Mapper.Map<ent.DetalleE, bd.DETALLE>(_DetalleEliminar);
            _repositorio.Adicionar(_eliminarDetalle);
            _repositorio.Grabar();
        }
        public IEnumerable<ent.DetalleE> BuscarFacturas(Expression<Func<bd.DETALLE, bool>> predicadoBusqueda)
        {
            var _consultaBd = _repositorio.Buscar(predicadoBusqueda);
            var _DetallessEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.DETALLE>, IEnumerable<ent.DetalleE>>(_consultaBd);
            return _DetallessEncontrados;
        }

        public ent.DetalleE BuscarUnFactura(Expression<Func<bd.DETALLE, bool>> predicadoBusqueda)
        {
            var _consultaBd = _repositorio.TraerUno(predicadoBusqueda);
            var _DetalleEncontrado = AutoMapper.Mapper.Map<bd.DETALLE, ent.DetalleE>(_consultaBd);
            return _DetalleEncontrado;
        }
    }
}

