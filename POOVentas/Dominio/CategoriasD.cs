using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bd = Datos;
using ent = Entidades;
using System.Linq.Expressions;

namespace Dominio
{
   public class CategoriasD
    {
        private Repositorio<bd.CATEGORIA> _repositorio = new Repositorio<bd.CATEGORIA>(new bd.VentasPOOEntitiesConnection());
        public IEnumerable<ent.CategoriaE> CategoriaList()
        {
            var _consultaBd = _repositorio.TraerTodo();
            var _categorias = AutoMapper.Mapper.Map<IEnumerable<bd.CATEGORIA>, IEnumerable<ent.CategoriaE>>(_consultaBd);
            return _categorias;
        }
        public ent.CategoriaE CategoriasPorID(int id)
        {
            var _consultaBd = _repositorio.TraerUnoPorID(id);
            var _categorias = AutoMapper.Mapper.Map<bd.CATEGORIA, ent.CategoriaE>(_consultaBd);
            return _categorias;
        }
        public void CrearCategoria(ent.CategoriaE _CategoriaCrear)
        {
            var _adicionarCategoria = AutoMapper.Mapper.Map<ent.CategoriaE, bd.CATEGORIA>(_CategoriaCrear);
            _repositorio.Adicionar(_adicionarCategoria);
            _repositorio.Grabar();
        }
        public void ModificarCategoria(ent.CategoriaE _CategoriaModificar)
        {
            var _modificarCategoria = AutoMapper.Mapper.Map<ent.CategoriaE, bd.CATEGORIA>(_CategoriaModificar);
            _repositorio.Modificar(_modificarCategoria);
            _repositorio.Grabar();
        }
        public void EliminarCliente(ent.CategoriaE _CategoriaEliminar)
        {
            var _eliminarCategoria = AutoMapper.Mapper.Map<ent.CategoriaE, bd.CATEGORIA>(_CategoriaEliminar);
            _repositorio.Adicionar(_eliminarCategoria);
            _repositorio.Grabar();
        }
        public IEnumerable<ent.CategoriaE> BuscarCategoria(Expression<Func<bd.CATEGORIA, bool>> predicadoBusqueda)
        {
            var _consultaBd = _repositorio.Buscar(predicadoBusqueda);
            var _CategoriasEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.CATEGORIA>, IEnumerable<ent.CategoriaE>>(_consultaBd);
            return _CategoriasEncontrados;
        }

        public ent.CategoriaE BuscarUnaCategoria(Expression<Func<bd.CATEGORIA, bool>> predicadoBusqueda)
        {
            var _consultaBd = _repositorio.TraerUno(predicadoBusqueda);
            var _CategoriasEncontrado = AutoMapper.Mapper.Map<bd.CATEGORIA, ent.CategoriaE>(_consultaBd);
            return _CategoriasEncontrado;
        }
    }
}
