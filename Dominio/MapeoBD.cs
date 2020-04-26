using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using bd = Datos;
using ent = Entidades;

namespace Dominio
{
    public class MapeoBD : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "MapeoBD";
            }
        }
        public MapeoBD()
        {
            //BD hacia entidades
            CreateMap<bd.CLIENTE, ent.ClientesE>();

            //Entidades hacia BD
            CreateMap<ent.ClientesE, bd.CLIENTE>();

            //BD hacia entidades Productos
            CreateMap<bd.Producto, ent.ProductosE>();

            //Entidades hacia BD Producto
            CreateMap<ent.ProductosE, bd.Producto>();

            CreateMap<bd.CATEGORIA, ent.CategoriaE>();

            CreateMap<ent.CategoriaE, bd.CATEGORIA>();

            CreateMap<bd.Factura, ent.FacturaE>();

            CreateMap<ent.FacturaE, bd.Factura>();

            CreateMap<bd.DETALLE, ent.DetalleE>();

            CreateMap<ent.DetalleE, bd.DETALLE>();

            CreateMap<bd.MODO_PAGO, ent.MODO_PAGOE>();

            CreateMap<ent.MODO_PAGOE, bd.MODO_PAGO>();
        }
    }
}
