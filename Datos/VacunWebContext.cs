using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class VacunWebContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database = VacunWebContext; Trusted_Connection = True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){

        }
        //public DbSet<Calendario> Calendarios { get; set; }
       // public DbSet<Vacuna> Vacunas { get; set; }
       // public DbSet<Paciente> Pacientes { get; set; }
          public DbSet<Tutor> Tutores { get; set; }
      //  public DbSet<DetalleCalendario> DetalleCalendarios { get; set; }
      //  public DbSet<VacunaColocada> VacunasColocadas { get; set; }

        public VacunWebContext(DbContextOptions<VacunWebContext> options) : base(options)
        {
            
        }

       
    }
}
