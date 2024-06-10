namespace ERP.DTO
{
    public class ArtikalDTO
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public string Opis { get; set; }

        public decimal Cena { get; set; }

        public int KategorijaId { get; set; }
        
    }
}
