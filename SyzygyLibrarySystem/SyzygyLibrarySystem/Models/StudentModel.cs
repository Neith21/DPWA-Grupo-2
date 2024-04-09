using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SyzygyLibrarySystem.Models
{
    public class StudentModel
    {
        [Required(ErrorMessage = "Ingrese el código del estudiante.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del estudiante.")]
        [DisplayName("Nombre del estudiante")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Ingrese un apellido.")]
        [DisplayName("Apellido del estudiante")]
        public string LastName { get; set; }

        [DisplayName("Dirección")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Ingrese el correo electrónico.")]
        [EmailAddress(ErrorMessage = "Correo electrónico válido.")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "El formato del teléfono debe ser ####-####.")]
        [DisplayName("Teléfono")]
        public string Phone { get; set; }
    }
}
