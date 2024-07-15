using System.ComponentModel.DataAnnotations;

namespace MVCPersona.Models
{
    public class Empleado
    {

        public int ID { get; set; }

        [StringLength(100)]
        [Required]
        public string NombreEmpleado { get; set; }

        [StringLength(100)]
        [Required]
        public string ApellidoEmpleado { get; set; }

        [Required]
        public DateTime FechaContratacion { get; set; }

        [StringLength(100)]
        [Required]
        public string PuestoEmpleado { get; set; }

        public ICollection<Asignacion> Asignaciones { get; set; }
    }
}
