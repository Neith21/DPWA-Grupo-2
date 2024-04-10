using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SyzygyLibrarySystem.Models
{
    public class BookModel
    {
        [Required]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Ingrese el título")]
        [DisplayName("Título del libro")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Seleccione un autor")]
        [DisplayName("Autor")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Seleccione una editorial")]
        [DisplayName("Editorial")]
        public int PublisherId { get; set; }

        [DisplayName("Año de publicación")]
        public DateTime? PublicationYear { get; set; }

        [DisplayName("Género")]
        public string? Genre { get; set; }

        [Required(ErrorMessage = "Ingrese la cantidad disponible")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
        [DisplayName("Cantidad disponible")]
        public int Quantity { get; set; }

        public AuthorModel? Author { get; set; }

        public PublisherModel? Publisher { get; set; }
    }
}
