using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamoLisbrosAPI.Models
{
    public class DatabaseContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibAut>()
                .HasKey(c => new { c.IdAutor, c.IdLibro });
            modelBuilder.Entity<Prestamo>()
                .HasKey(c => new { c.IdLector, c.IdLibro, c.FechaPrestamo });
           SeedDatabase(modelBuilder);
        }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            
            //Llenando la tabla de Autore
            modelBuilder.Entity<Autor>()
                .HasData(
                new Autor
                {
                    IdAutor = 1,
                    Nombre = "Mario Benedetti",
                    Nacionalidad = "USA"
                },
                 new Autor
                 {
                     IdAutor = 2,
                     Nombre = "Justino Aragon",
                     Nacionalidad = "Francia"
                 },
                 new Autor
                 {
                     IdAutor = 3,
                     Nombre = "Jefferson Jhonson",
                     Nacionalidad = "USA"
                 }
                );
            //Llenando la tabla de Estudiante
            modelBuilder.Entity<Estudiante>()
                  .HasData(
                new Estudiante
                {
                    IdLector = 1,
                    Nombre = "Felipe Loayza Beramendi",
                    Carrera = "Informática",
                    CI = "294568",
                    Dierccion = "Calle Masaya Residencial Mayales Casa B-22",
                    Edad = 19
                },
                 new Estudiante
                 {
                     IdLector = 2,
                     Nombre = "Daniel Gonzales",
                     Carrera = "Informática",
                     CI = "294568",
                     Dierccion = "Calle Masaya Residencial Mayales Casa B-22",
                     Edad = 20
                 },
                 new Estudiante
                 {
                     IdLector = 3,
                     Nombre = "Josefina Gomez",
                     Carrera = "Quimica",
                     CI = "897867",
                     Dierccion = "Calle Granada Residencial Mayales Casa B-92",
                     Edad = 18
                 }
            );
            //Llenando la tabla de Libro
            modelBuilder.Entity<Libro>()
                  .HasData(
                new Libro
                {
                    IdLibro=1,
                    Titulo= "Visual Studio Net",
                    Area= "Internet",
                    Editorial= "Alfa"
                },
                 new Libro
                 {
                     IdLibro = 2,
                     Titulo = "Base de Datos",
                     Area = "Base de Datos",
                     Editorial = "Omega"
                 },
                 new Libro
                 {
                     IdLibro = 3,
                     Titulo = "Hacking",
                     Area = "Internet",
                     Editorial = "Alfa"
                 }
                );
            //Llenar la tabla LibAut
            modelBuilder.Entity<LibAut>()
                 .HasData(
                new LibAut
                {
                    IdLibro=1,
                    IdAutor=1
                },
                 new LibAut
                 {
                     IdLibro = 2,
                     IdAutor = 1
                 },
                 new LibAut
                 {
                     IdLibro = 3,
                     IdAutor = 2
                 }
                );
            //Llenar la tabla Prestamo
            modelBuilder.Entity<Prestamo>()
               .HasData(
                new Prestamo
                {
                    IdLector=1,
                    IdLibro=1,
                    FechaPrestamo=new DateTime(2007,05,23),
                    FechaDevolucion = new DateTime(2007, 05, 30),
                    Devuelto =false
                },
                new Prestamo
                {
                    IdLector = 1,
                    IdLibro = 1,
                    FechaPrestamo = new DateTime(2007, 01, 10),
                    FechaDevolucion = new DateTime(2007, 02, 15),
                    Devuelto = false
                },
                new Prestamo
                {
                    IdLector = 2,
                    IdLibro = 2,
                    FechaPrestamo = new DateTime(2007, 05, 23),
                    FechaDevolucion = new DateTime(2007, 05, 28),
                    Devuelto = false
                },
                new Prestamo
                {
                    IdLector = 3,
                    IdLibro = 2,
                    FechaPrestamo = new DateTime(2007, 03, 01),
                    FechaDevolucion = new DateTime(2007, 04, 10),
                    Devuelto = false
                }
                );
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
{ }
public DbSet<Autor> Autor { get; set; }
public DbSet<Estudiante> Estudiante { get; set; }
public DbSet<LibAut> LibAut { get; set; }
public DbSet<Libro> Libro { get; set; }
public DbSet<Prestamo> Prestamo { get; set; }
    }
}
