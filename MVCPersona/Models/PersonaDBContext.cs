using Microsoft.EntityFrameworkCore;

namespace MVCPersona.Models
{
    public class PersonaDBContext: DbContext
    {

        public PersonaDBContext(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }

        public DbSet<Asignacion> Asignaciones { get; set; }

    }
}
