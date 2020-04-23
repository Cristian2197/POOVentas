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
        }
    }
}
