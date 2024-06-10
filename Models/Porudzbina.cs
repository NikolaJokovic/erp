using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Porudzbina
    {
      
        public int Id { get; set; }

        public string Adresa { get; set; }

       
        public string Grad { get; set; }

       
       
        public string Drzava { get; set; }

        
        public string NacinPlacanja { get; set; }

       
        public decimal Iznos { get; set; }

        
        public int korisnik_id { get; set; }

        public Korisnik Korisnik { get; set; }

        public ICollection<ArtikalPorudzbina> ArtikalPorudzbina { get; set; }
    }
}
