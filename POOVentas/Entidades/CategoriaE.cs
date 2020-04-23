using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CategoriaE
    {
        [Display(Name ="ID Categoria")]
        public int id_categoria { get; set; }
        [Display(Name = "Nombre Categoria")]
        public string nombre { get; set; }
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }
    }
}
