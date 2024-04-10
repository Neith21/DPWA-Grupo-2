using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SyzygyLibrarySystem.Models
{
    public class PublisherModel
    {
        [Required(ErrorMessage = "Ingrese el ID de la editorial")]
        [DisplayName("ID de la editorial")]
        public int PublisherId { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre de la editorial")]
        [DisplayName("Nombre de la editorial")]
        public string PublisherName { get; set; }

        [DisplayName("País de la editorial")]
        public string? Country { get; set; }
    }
}
