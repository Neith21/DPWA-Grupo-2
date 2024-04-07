using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SyzygyLibrarySystem.Models
{
    public class AuthorModel
    {
        [Required]
        public int AuthorId { get; set; }

        [Required]
        [DisplayName("Nombre del autor")]
        public string AuthorName { get; set; }

        [DisplayName("Nacionalidad del autor")]
        public string? Nationality { get; set; }

        [DisplayName("Fecha de nacimiento del autor")]
        public DateTime BirthDate { get; set; }
    }
}
