using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SyzygyLibrarySystem.Models
{
    public class LoanDetailModel
    {
        [Required(ErrorMessage = "Ingrese el ID del detalle")]
        [DisplayName("ID del detalle")]
        public int DetailId { get; set; }

        [Required(ErrorMessage = "Ingrese el ID del préstamo")]
        [DisplayName("ID del préstamo")]
        public int LoanId { get; set; }

        [Required(ErrorMessage = "Seleccione un libro")]
        [DisplayName("Libro")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Ingrese la cantidad de libros")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
        [DisplayName("Cantidad de libros")]
        public int Quantity { get; set; }

        public BookModel? Book { get; set; }
    }
}
