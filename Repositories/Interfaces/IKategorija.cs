using ERP.DTO;


namespace ERP.Repositories.Interfaces
{
    public interface IKategorija
    {
        Task<bool> CreateKategorija(string naziv);
        Task<KategorijaDTO> GetKategorijaById(int id);
        Task<List<KategorijaDTO>> GetAllKategorije();
        Task<bool> UpdateKategorija(int id, string naziv);
        Task<bool> DeleteKategorija(int id);
    }
}
