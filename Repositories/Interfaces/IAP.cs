using ERP.DTO;

namespace ERP.Repositories.Interfaces
{
    public interface IAP
    {
        Task<ArtikalPorudzbinaDTO> GetArtikalPorudzbina(int artikal_id,int porudzbina_id);
        Task<List<int>> GetArtikal(int porudzbina_id);

        Task<bool> RemoveArtikalPorudzbina(int artikal_id,int porudzbina_id);

        Task<bool> PostArtikalPorudzbina(int artikal_id, int porudzbina_id);
    }
}
