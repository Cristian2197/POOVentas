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
  public class ProductosD
    {
        private Repositorio<bd.Producto> _repositorio = new Repositorio<bd.Producto>(new bd.VentasPOOEntitiesConnection());
        public IEnumerable<ent.ProductosE> ProductosList()
        {
            var _consultaBd = _repositorio.TraerTodo();
            var _clientes = AutoMapper.Mapper.Map<IEnumerable<bd.Producto>, IEnumerable<ent.ProductosE>>(_consultaBd);
            return _clientes;
        }

        public ent.ProductosE ProductoPorID(int id) {
            var _consultaBd = _repositorio.TraerUnoPorID(id);
            var _clientes = AutoMapper.Mapper.Map<bd.Producto, ent.ProductosE>(_consultaBd);
            return _clientes;
        }

        public void CrearProducto(ent.ProductosE _clienteCrear)
        {
            var _adicionarCliente = AutoMapper.Mapper.Map<ent.ProductosE, bd.Producto>(_clienteCrear);
            _repositorio.Adicionar(_adicionarCliente);
            _repositorio.Grabar();
        }

        public void ModificarProducto(ent.ProductosE _clienteModificar)
        {
            var _modificarCliente = AutoMapper.Mapper.Map<ent.ProductosE, bd.Producto>(_clienteModificar);
            _repositorio.Modificar(_modificarCliente);
            _repositorio.Grabar();
        }

        public void EliminarProducto(ent.ProductosE _clienteEliminar)
        {
            var _eliminarCliente = AutoMapper.Mapper.Map<ent.ProductosE, bd.Producto>(_clienteEliminar);
            _repositorio.Eliminar(_eliminarCliente);
            _repositorio.Grabar();
        }

        public IEnumerable<ent.ProductosE> BuscarProducto (Expression<Func<bd.Producto, bool>> PredicadoBusqueda)
        {
            var _consultaBd = _repositorio.Buscar(PredicadoBusqueda);
            var _ClientesEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.Producto>, IEnumerable<ent.ProductosE>>(_consultaBd);
            return _ClientesEncontrados;
        }

        public ent.ProductosE BuscarUnProductos(Expression<Func<bd.Producto, bool>> predicadoBusqueda)
        {
            var _consultaBd = _repositorio.TraerUno(predicadoBusqueda);
            var _ClientesEncontrados = AutoMapper.Mapper.Map<bd.Producto, ent.ProductosE>(_consultaBd);
            return _ClientesEncontrados;
        }
    }
}
