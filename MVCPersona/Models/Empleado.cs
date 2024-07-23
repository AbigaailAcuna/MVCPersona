using System.ComponentModel.DataAnnotations;

namespace MVCPersona.Models
{
    public class Empleado
    {

        public int ID { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "El nombre del empleado es requerido")]
        [Display(Name = "Nombre del Empleado")]
        public string NombreEmpleado { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "El apellido del empleado es requerido")]
        [Display(Name = "Apellido del Empleado")]
        public string ApellidoEmpleado { get; set; }

        [Required(ErrorMessage = "La fecha de contratación es requerida")]
        [Display(Name = "Fecha de Contratación")]
        [DataType(DataType.Date)]
        public DateTime FechaContratacion { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "El puesto del empleado es requerido")]
        [Display(Name = "Puesto del Empleado")]
        public string PuestoEmpleado { get; set; }

        public ICollection<Asignacion> Asignaciones { get; set; }
    }
}
