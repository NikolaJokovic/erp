using ERP.DTO;

namespace ERP.Repositories.Interfaces
{
    public interface IPorudzbina
    {
        Task<bool> CreatePorudzbina(string Adresa, string Grad, string Drzava, string NacinPlacanja,decimal Iznos,int korisnik_id);

        Task<List<PorudzbinaDTO>> GetAllPorudzbina();

        Task<PorudzbinaDTO> GetPorudzbina(int id);

        Task<bool> DeletePorudzbina(int id);

        Task<bool> UpdatePorudzbina(int id, string Adresa, string Grad, string Drzava);

        
    }
}
