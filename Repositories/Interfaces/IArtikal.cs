using ERP.Models;
using ERP.DTO;

namespace ERP.Repositories.Interfaces
{
    public interface IArtikal
    {
        Task<ArtikalDTO> GetArtikal(int id);

        Task<bool> UpdateArtikal(int id, string naziv,string opis,decimal cena);

        Task<bool> DeleteArtikal(int id);

        Task<bool> CreateArtikal(string naziv, string opis, decimal cena, int kategorija);

        Task<List<ArtikalDTO>> GetAllArtikal();
    }
}
