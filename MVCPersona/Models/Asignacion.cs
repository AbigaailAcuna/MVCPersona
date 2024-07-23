using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCPersona.Models
{
    public class Asignacion
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "La fecha de asignación es requerida")]
        [Display(Name = "Fecha de Asignación")]
        [DataType(DataType.Date)]

        public DateTime FechaAsignacion { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "El rol de asignación es requerido")]
        [Display(Name = "Rol de Asignación")]
        public string RolAsignacion { get; set; }

        //llaves foráneas
        [Required]
        [ForeignKey("Empleado")]
        [Display(Name = "Empleado en la asignación")]

        public int? EmpleadoId { get; set; }

        [Required]
        [ForeignKey("Proyecto")]
        [Display(Name = "Proyecto de Asignación")]

        public int? ProyectoId { get; set; }

        //propiedad navegación

        public Empleado Empleado { get; set; }
        public Proyecto Proyecto { get; set; }
    }
}
