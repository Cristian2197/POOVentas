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
    public class DetsFacturaD
    {
        private Repositorio<bd.DETALLE> _repositorio = new Repositorio<bd.DETALLE>(new bd.VentasPOOEntitiesConnection());
        public IEnumerable<ent.DetsFacturaE> DetsFacturasList()
        {
            var _consultaBd = _repositorio.TraerTodo();
            var _categorias = AutoMapper.Mapper.Map<IEnumerable<bd.DETALLE>, IEnumerable<ent.DetsFacturaE>>(_consultaBd);
            return _categorias;
        }

        public ent.DetsFacturaE DetsFacturasPorID(int id)
        {
            var _consultaBd = _repositorio.TraerUnoPorID(id);
            var _categorias = AutoMapper.Mapper.Map<bd.DETALLE, ent.DetsFacturaE>(_consultaBd);
            return _categorias;
        }

        public void CrearDetsFactura(ent.DetsFacturaE _DetsFacturaCrear)
        {
            var _adicionarDetsFactura = AutoMapper.Mapper.Map<ent.DetsFacturaE, bd.DETALLE>(_DetsFacturaCrear);
            _repositorio.Adicionar(_adicionarDetsFactura);
            _repositorio.Grabar();
        }
        public void ModificarDetsFactura(ent.DetsFacturaE _DetsFacturaModificar)
        {
            var _modificarDetsFactura = AutoMapper.Mapper.Map<ent.DetsFacturaE, bd.DETALLE>(_DetsFacturaModificar);
            _repositorio.Modificar(_modificarDetsFactura);
            _repositorio.Grabar();
        }

        public IEnumerable<ent.DetsFacturaE> BuscarDetsFactura(Expression<Func<bd.DETALLE, bool>> predicadoBusqueda)
        {
            var _consultaBd = _repositorio.Buscar(predicadoBusqueda);
            var _DetsFacturaEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.DETALLE>, IEnumerable<ent.DetsFacturaE>>(_consultaBd);
            return _DetsFacturaEncontrados;
        }
    }
}
