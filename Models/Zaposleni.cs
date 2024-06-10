using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Zaposleni
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Ime { get; set; }

        [Required]
        [StringLength(50)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(50)]
        public string Pozicija { get; set; }
    }
}
