using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProductosE
    {
        public int id_producto { get; set; }
        public String nombre { get; set; }
        public double precio { get; set; }
        public int stock { get; set; }
        public int id_categoria { get; set; }
    }
}
