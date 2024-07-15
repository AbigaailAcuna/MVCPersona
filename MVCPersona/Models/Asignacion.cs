using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCPersona.Models
{
    public class Asignacion
    {
        public int ID { get; set; }

        [Required]

        public DateTime FechaAsignacion { get; set; }

        [StringLength(50)]
        [Required]
        public string RolAsignacion { get; set; }

        //llaves foráneas
        [Required]
        [ForeignKey("Empleado")]

        public int? EmpleadoId { get; set; }

        [Required]
        [ForeignKey("Proyecto")]

        public int? ProyectoId { get; set; }

        //propiedad navegación

        public Empleado Empleado { get; set; }
        public Proyecto Proyecto { get; set; }
    }
}
