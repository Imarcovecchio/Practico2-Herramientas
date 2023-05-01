using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Practico_2.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Curso> Curso { get; set; } = default!;
        public DbSet<Estatus> Estatus{get;set;}= default!;
        public DbSet<Profesor> Profesores {get;set;}= default!;
        public DbSet<Estudiante> Estudiantes{get;set;}= default!;
        public DbSet<CursosEstudiantes> CursosEstudiantes{get;set;}= default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<CursosEstudiantes>().HasKey(p=> new {p.CursoId,p.EstudiantesId});
            modelBuilder.Entity<CursosEstudiantes>().HasOne<Curso>(p => p.Curso).WithMany(p=>p.CursosEstudiantes).HasForeignKey(p=>p.CursoId);
            modelBuilder.Entity<CursosEstudiantes>().HasOne<Estudiante>(p=>p.Estudiante).WithMany(p=>p.CursosEstudiantes).HasForeignKey(p=>p.EstudiantesId);
            modelBuilder.Entity<Curso>().HasOne<Profesor>(p=>p.Profesor).WithMany(p=>p.Cursos).HasForeignKey(p=>p.ProfesorId);

        }
    }
}
