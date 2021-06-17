using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VacunDesktop.Models
{
    //AGREGAMOS LA HERENCIA DEL MODELO BASE
    public class Calendario : ModeloBase
    {
        [Required]
        public SexoEnum SexoPaciente  { get; set; }
        [Required]
        public bool PrematuroPaciente { get; set; }
        public ICollection<Paciente> Pacientes { get; set; }
    }
}
