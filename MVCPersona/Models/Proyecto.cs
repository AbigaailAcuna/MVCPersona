using System.ComponentModel.DataAnnotations;

namespace MVCPersona.Models
{
    public class Proyecto
    {

        public int ID { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "El nombre del proyecto es requerido")]
        [Display(Name = "Nombre del Proyecto")]
        public string NombreProyecto { get; set; }

        [StringLength(300)]
        [Required(ErrorMessage = "La descripción del proyecto es requerida")]
        [Display(Name = "Descripción del Proyecto")]
        public string DescripcionProyecto { get; set; }

        [Required(ErrorMessage = "La fecha del proyecto es requerida")]
        [DataType(DataType.Date)]   
        [Display(Name = "Fecha de incio del Proyecto")]
        public DateTime FechaInicio { get; set; }

        public ICollection<Asignacion> Asignaciones { get; set; }
    }
}
