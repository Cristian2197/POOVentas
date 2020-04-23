using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FacturaE
    {
        public int num_factura { get; set; }
        public int id_cliente { get; set; }
        public DateTime fecha { get; set; }
        public int num_pago { get; set; }
    }
}
