using System.ComponentModel.DataAnnotations;

namespace MVCPersona.Models
{
    public class Proyecto
    {

        public int ID { get; set; }

        [StringLength(200)]
        [Required]
        public string NombreProyecto { get; set; }

        [StringLength(300)]
        [Required]
        public string DescripcionProyecto { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        public ICollection<Asignacion> Asignaciones { get; set; }
    }
}
