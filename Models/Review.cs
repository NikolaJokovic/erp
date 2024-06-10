using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int artikal_id { get; set; }

       
        public int korisnik_id { get; set; }

        public int Ocena { get; set; }

       
        public string Komentar { get; set; }

        
        public  Artikal Artikal { get; set; }

        
        public Korisnik Korisnik { get; set; }
    }
}
