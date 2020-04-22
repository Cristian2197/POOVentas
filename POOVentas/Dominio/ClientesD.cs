using Repositorio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using bd = Datos;
using ent = Entidades;
using System.Linq;
using System.Linq.Expressions;
namespace Dominio
{
    public class ClientesD
    {
        private Repositorio<bd.CLIENTE> _repositorio = new Repositorio<bd.CLIENTE>(new bd.VentasPOOEntitiesConnection());
        public IEnumerable<ent.ClientesE> ClientesList()
        {
            var _consultaBd = _repositorio.TraerTodo();
            var _clientes = AutoMapper.Mapper.Map<IEnumerable<bd.CLIENTE>, IEnumerable<ent.ClientesE>>(_consultaBd);
            return _clientes;
        }
        public ent.ClientesE ClientesPorID(int id)
        {
            var _consultaBd = _repositorio.TraerUnoPorID(id);
            var _clientes = AutoMapper.Mapper.Map<bd.CLIENTE,ent.ClientesE>(_consultaBd);
            return _clientes;
        }
        public void CrearCliente(ent.ClientesE _ClienteCrear)
        {
            var _adicionarCliente = AutoMapper.Mapper.Map<ent.ClientesE, bd.CLIENTE>(_ClienteCrear);
            _repositorio.Adicionar(_adicionarCliente);
            _repositorio.Grabar();
        }
        public void ModificarCliente(ent.ClientesE _ClienteModificar)
        {
            var _modificarCliente = AutoMapper.Mapper.Map<ent.ClientesE, bd.CLIENTE>(_ClienteModificar);
            _repositorio.Modificar(_modificarCliente);
            _repositorio.Grabar();
        }
        public void EliminarCliente(ent.ClientesE _ClienteEliminar)
        {
            var _eliminarCliente = AutoMapper.Mapper.Map<ent.ClientesE, bd.CLIENTE>(_ClienteEliminar);
            _repositorio.Adicionar(_eliminarCliente);
            _repositorio.Grabar();
        }
        public IEnumerable<ent.ClientesE> BuscarClientes(Expression<Func<bd.CLIENTE, bool>> predicadoBusqueda)
        {
            var _consultaBd = _repositorio.Buscar(predicadoBusqueda);
            var _ClientesEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.CLIENTE>, IEnumerable<ent.ClientesE>>(_consultaBd);
            return _ClientesEncontrados;
        }

        public ent.ClientesE BuscarUnCliente(Expression<Func<bd.CLIENTE, bool>> predicadoBusqueda)
        {
            var _consultaBd = _repositorio.TraerUno(predicadoBusqueda);
            var _ClientesEncontrado = AutoMapper.Mapper.Map<bd.CLIENTE, ent.ClientesE>(_consultaBd);
            return _ClientesEncontrado;
        }
    }
}
