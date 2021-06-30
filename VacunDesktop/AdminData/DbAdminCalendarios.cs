using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VacunDesktop.Models;
using VacunDesktop.Presentation;

namespace VacunDesktop.AdminData
{
   public static class DbAdminCalendarios
    {
        public static IEnumerable<Calendario> ObtenerTodos()
        {
            using VacunWebContext db = new VacunWebContext();
            return db.Calendarios.ToList();
        }

        internal static void Eliminar(int idSeleccionado)
        {
            using VacunWebContext db = new VacunWebContext();
                var calendario = db.Calendarios.Find(idSeleccionado);
                //db.Calendarios.Remove(Calendario);
                //REALIZAMOS TODA LA MECANICA PARA QUE MODIFIQUE EN LA BASE DE DATOS AL CALENDARIO
                calendario.Eliminado = true;
                calendario.FechaHoraEliminacion = DateTime.Now;
                calendario.Usuario = FrmMenuPrincipal.Usuario;
                db.Entry(calendario).State = EntityState.Modified;
                db.SaveChanges();

        }

        internal static IEnumerable<object> ObtenerTodos(string cadenaBuscada)
        {
            //instanciamos nuestro objeto db Context
            using VacunWebContext db = new VacunWebContext();
                var listaCalendarios = from Calendario in db.Calendarios
                                       select new { Id = Calendario.Id, Nombre = Calendario.Nombre.Trim(), Sexo = Calendario.SexoPaciente };
                //consultamos en el txtBusqueda si el nombre apellido o email contiene la expresion escrita en la grilla.
                return listaCalendarios.Where(c => c.Nombre.Contains(cadenaBuscada)).ToList();
        }
    }
}
