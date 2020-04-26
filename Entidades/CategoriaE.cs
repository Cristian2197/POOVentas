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
        [Required(ErrorMessage ="Es obligatorio poner el ID")]
        [Display(Name ="ID Categoria")]
        public int id_categoria { get; set; }
        [Required(ErrorMessage = "Es obligatorio poner el Nombre de la Categoria")]
        [Display(Name = "Nombre Categoria")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Es obligatorio poner la descripcion")]
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }
    }
}
