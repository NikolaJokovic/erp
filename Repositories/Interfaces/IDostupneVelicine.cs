using ERP.DTO;

namespace ERP.Repositories.Interfaces
{
    public interface IDostupneVelicine
    {
        Task<bool> DeleteDostupnaVelicina(int artikal_id,int velicina_id);
        Task<bool> addDostupnaVelicina(int artikal_id, int velicina_id);
        Task<List <int>> GetDostupnaVelicinaZaA(int artikal_id);
        Task<List <int>> GetArtikliVelicine(int velicina_id);

    }
}
