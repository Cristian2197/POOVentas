using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProductosE
    {
        [Display(Name="ID Producto")]
        public int id_producto { get; set; }
        [Display(Name = "Nombre")]
        public String nombre { get; set; }
        [Display(Name = "Precio")]
        public double precio { get; set; }
        [Display(Name = "Cantidad Existente")]
        public int stock { get; set; }
        [Display(Name = "Categoria")]
        public int id_categoria { get; set; }


    }
}
