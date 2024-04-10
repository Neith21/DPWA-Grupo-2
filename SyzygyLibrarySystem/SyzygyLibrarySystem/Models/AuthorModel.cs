using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SyzygyLibrarySystem.Models
{
    public class AuthorModel
    {
        [Required(ErrorMessage = "El ID del autor es requerido.")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "El nombre del autor es requerido.")]
        [DisplayName("Nombre del autor")]
        public string AuthorName { get; set; }

        [DisplayName("Nacionalidad del autor")]
        public string? Nationality { get; set; }

        [DisplayName("Fecha de nacimiento del autor")]
        [Required(ErrorMessage = "La fecha de nacimiento del autor es requerida.")]
        public DateTime BirthDate { get; set; }
    }
}
