﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VacunDesktop.Models
{
    public class Vacuna : ModeloBase
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Vacuna")]
        public string Nombre { get; set; }
        [Required]
        public int PeriodoAplicacion { get; set; }
        [Required]
        public string Beneficios { get; set; }
    }
}
