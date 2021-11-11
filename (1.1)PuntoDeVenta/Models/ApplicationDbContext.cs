using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1_PuntoDeVenta.Models
{
    class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseNpgsql("Host=localhost; Database=postgres; Username=postgres; password=Roman55;").EnableSensitiveDataLogging(true);

            //optionBuilder.UseSqlServer("Data Sources=localhost; Initial Catalog=PuntoDeVenta; Integrated Security=True").EnableSensitiveDataLogging(true);
            //169.254.35.40
            //optionBuilder.UseSqlServer("Data Sources=LAPTOP-UTVJ1CO9;Initial Catalog=Nombre de la base de datos; Persist Security Info = true; ID = sa; Password = TuContraseña");
        }
        //Propiedad la cual le indica a EFC que vamos a tener una tabla Empleados
        public DbSet<Empleados> Empleados { get; set; }    
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Productos> Productos { get; set; }
    }
}
