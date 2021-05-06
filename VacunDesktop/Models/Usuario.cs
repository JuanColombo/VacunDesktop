using System;
using System.Collections.Generic;
using System.Text;

namespace VacunDesktop.Models
{
    class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }
    }
}
