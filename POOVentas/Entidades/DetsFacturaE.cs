using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class DetsFacturaE
    {

        public int id_detFact { get; set; }
        public int num_factura { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }

        public FacturaE FACTURAS { get; set; }

        //public virtual FacturasE FACTURAS { get; set; }
        public virtual ProductosE PRODUCTOS { get; set; }
    }
}
