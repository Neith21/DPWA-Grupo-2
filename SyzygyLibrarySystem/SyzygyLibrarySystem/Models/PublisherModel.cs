using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SyzygyLibrarySystem.Models
{
    public class PublisherModel
    {
        [Required]
        public int PublisherId { get; set; }

        [Required]
        [DisplayName("Nombre de la editorial")]
        public string PublisherName { get; set; }

        [DisplayName("País de la editorial")]
        public string? Country { get; set; }
    }
}
