using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SyzygyLibrarySystem.Models
{
    public class LoanDetailModel
    {
        [Required]
        public int DetailId { get; set; }

        [Required]
        public int LoanId { get; set; }

        [Required]
        [DisplayName("Libro")]
        public int BookId { get; set; }

        [Required]
        [DisplayName("Cantidad de libros")]
        public int Quantity { get; set; }

        public BookModel? Book { get; set; }
    }
}
