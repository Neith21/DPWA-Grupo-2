using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SyzygyLibrarySystem.Models
{
    public class LoanModel
    {
        [Required]
        public int LoanId { get; set; }

        [Required]
        [DisplayName("Códogo del estudiante")]
        public string StudentCode { get; set; }

        [Required]
        [DisplayName("Fecha del préstamo")]
        public DateTime LoanDate { get; set; }

        [Required]
        [DisplayName("Fecha de devolución del préstamo")]
        public DateTime ReturnDate { get; set; }

        [Required]
        [DisplayName("Estado del préstamo")]
        public string LoanStatus { get; set; }
    }
}
