namespace ERP.DTO
{
    public class PorudzbinaDTO
    {
        public int Id { get; set; }

        public string Adresa { get; set; }

        public string Grad { get; set; }

        public string Drzava { get; set; }

        public string NacinPlacanja { get; set; }

        public decimal Iznos { get; set; }

        public int KorisnikId { get; set; }
    }
}
