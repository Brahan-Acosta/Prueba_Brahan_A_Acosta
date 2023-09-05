using System.ComponentModel.DataAnnotations;

namespace PRUEBA_BRAHAN_A_ACOSTA.Models
{
    public class PacienteModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo tipo de documento es obligatorio")]
        public string tipoDocumento { get; set; }

        [Required(ErrorMessage = "El campo número de documento es obligatorio")]
        public string numeroDocumento { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string nombres { get; set; }

        [Required(ErrorMessage = "El campo apellido es obligatorio")]
        public string apellidos { get; set; }

        [Required(ErrorMessage = "El campo correo es obligatorio")]
        public string correo { get; set; }

        [Required(ErrorMessage = "El campo telefono es obligatorio")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "El campo fecha de nacimiento es obligatorio")]
        public DateTime fecha_nacimiento { get; set; }

        [Required(ErrorMessage = "El campo estado es obligatorio")]
        public string estado { get; set; }
    }
}
