using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VacunDesktop.Models 
{
    public class Tutor:ModeloBase
    {

        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Email { get; set; }

        public ICollection<Paciente> Pacientes { get; set; }
    }
}
