using ERP.DTO;



namespace ERP.Repositories.Interfaces
{
    public interface IKorisnik
    {
        Task<bool> CreateKorisnik(string ime,string prezime, string email, string password);

        Task<KorisnikDTO> GetKorisnik(string email);
        Task<bool> UpdateKorisnik(string email,string? ime, string? prezime,string? password);

        Task<bool> DeleteKorisnik(string email);
        
        Task<List<KorisnikDTO>> GetAllKorisnik();

    }
}
