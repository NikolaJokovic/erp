using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Artikal
    {
   
        public int Id { get; set; }

        
        public string Naziv { get; set; }

        public string Opis { get; set; }

       
        public decimal Cena { get; set; }

        
        public int kategorija_id { get; set; }

        public ICollection<ArtikalPorudzbina> ArtikalPorudzbina { get; set; }

        public ICollection<Review> Review { get; set; }

        public ICollection<DostupnaVelicina> DostupneVelicine { get; set; }
    }
}
