﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class ClientesE
    {
        [Display(Name = "ID del Cliente")]
        public int id_cliente { get; set; }
        [Display(Name = "Nombre del Cliente")]
        public string nombre { get; set; }
        [Display(Name = "Apellido del Cliente")]
        public string apellido { get; set; }
        [Display(Name = "Dirección del Cliente")]
        public string direccion { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public System.DateTime fecha_nacimiento { get; set; }
        [Display(Name = "Telefono")]
        public string telefono { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }

    }
}
