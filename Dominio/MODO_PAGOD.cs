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
    public class MODO_PAGOD
    {
        private Repositorio<bd.MODO_PAGO> _repositorio = new Repositorio<bd.MODO_PAGO>(new bd.VentasPOOEntitiesConnection());
        public IEnumerable<ent.MODO_PAGOE> ModoPagoList()
        {
            var _consultaBd = _repositorio.TraerTodo();
            var _modo_pago = AutoMapper.Mapper.Map<IEnumerable<bd.MODO_PAGO>, IEnumerable<ent.MODO_PAGOE>>(_consultaBd);
            return _modo_pago;
        }
        public ent.MODO_PAGOE ModoPagoPorId(int id)
        {
            var _consultaBd = _repositorio.TraerUnoPorID(id);
            var _detalles = AutoMapper.Mapper.Map<bd.MODO_PAGO, ent.MODO_PAGOE>(_consultaBd);
            return _detalles;
        }
        public void CrearModoPago(ent.MODO_PAGOE _ModoPagoCrear)
        {
            var _adicionarModoPago = AutoMapper.Mapper.Map<ent.MODO_PAGOE, bd.MODO_PAGO>(_ModoPagoCrear);
            _repositorio.Adicionar(_adicionarModoPago);
            _repositorio.Grabar();
        }
        public void ModificarCliente(ent.MODO_PAGOE _ModoPagoModificar)
        {
            var _modificarModoPago = AutoMapper.Mapper.Map<ent.MODO_PAGOE, bd.MODO_PAGO>(_ModoPagoModificar);
            _repositorio.Modificar(_modificarModoPago);
            _repositorio.Grabar();
        }
        public void EliminarCliente(ent.MODO_PAGOE _ModoPagoEliminar)
        {
            var _eliminarModoPago = AutoMapper.Mapper.Map<ent.MODO_PAGOE, bd.MODO_PAGO>(_ModoPagoEliminar);
            _repositorio.Adicionar(_eliminarModoPago);
            _repositorio.Grabar();
        }
        public IEnumerable<ent.MODO_PAGOE> BuscarFacturas(Expression<Func<bd.MODO_PAGO, bool>> predicadoBusqueda)
        {
            var _consultaBd = _repositorio.Buscar(predicadoBusqueda);
            var _ModoPagosEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.MODO_PAGO>, IEnumerable<ent.MODO_PAGOE>>(_consultaBd);
            return _ModoPagosEncontrados;
        }

        public ent.MODO_PAGOE BuscarUnFactura(Expression<Func<bd.MODO_PAGO, bool>> predicadoBusqueda)
        {
            var _consultaBd = _repositorio.TraerUno(predicadoBusqueda);
            var _ModoPagoEncontrado = AutoMapper.Mapper.Map<bd.MODO_PAGO, ent.MODO_PAGOE>(_consultaBd);
            return _ModoPagoEncontrado;
        }
    }
}
