using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SyzygyLibrarySystem.Models
{
    public class LoanModel
    {
        [Required(ErrorMessage = "Ingrese el ID del préstamo")]
        [DisplayName("ID del préstamo")]
        public int LoanId { get; set; }

        [Required(ErrorMessage = "Ingrese el código del estudiante")]
        [DisplayName("Código del estudiante")]
        public string StudentCode { get; set; }

        [Required(ErrorMessage = "Ingrese la fecha del préstamo")]
        [DisplayName("Fecha del préstamo")]
        public DateTime LoanDate { get; set; }

        [Required(ErrorMessage = "Ingrese la fecha de devolución del préstamo")]
        [DisplayName("Fecha de devolución del préstamo")]
        public DateTime ReturnDate { get; set; }

        [Required(ErrorMessage = "Ingrese el estado del préstamo")]
        [DisplayName("Estado del préstamo")]
        public string LoanStatus { get; set; }
    }
}
