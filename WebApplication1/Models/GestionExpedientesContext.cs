using GestionExpedientes.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace GestionExpedientes.Data
{
    public class GestionExpedientesContext : DbContext
    {
        public GestionExpedientesContext(DbContextOptions<GestionExpedientesContext> options)
            : base(options)
        {
        }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Expediente> Expedientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Expediente>()
                .HasOne(e => e.Alumno)
                .WithMany(a => a.Expedientes)
                .HasForeignKey(e => e.AlumnoId);

            modelBuilder.Entity<Expediente>()
                .HasOne(e => e.Materia)
                .WithMany(m => m.Expedientes)
                .HasForeignKey(e => e.MateriaId);
        }
    }
}