using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VacunDesktop.Models 
{
    public class Tutor:ModeloBase
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Contraseña { get; set; }

        public ICollection<Paciente> Pacientes { get; set; }
        public byte[] Imagen { get; set; }
    }
}
