using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class ArtikalPorudzbina
    {
       
        public int porudzbina_id { get; set; }

      
        public int artikal_id { get; set; }

       
        public Porudzbina Porudzbina { get; set; }

       
        public Artikal Artikal { get; set; }
    }
}
