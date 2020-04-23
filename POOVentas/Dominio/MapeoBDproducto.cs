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
    public class MapeoBDproducto : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "MapeoBDproducto";
            }
        }
        public MapeoBDproducto()
        {
            CreateMap<bd.Producto, ent.ProductosE>();
            CreateMap<ent.ProductosE, bd.Producto >();
        }
    }
}
