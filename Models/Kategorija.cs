using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Kategorija
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string kategorija { get; set; }
    }
}
