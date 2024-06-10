using ERP.DTO;

namespace ERP.Repositories.Interfaces
{
    public interface IVelicine
    {
        Task<List<VelicineDTO>> getAllVelicine();
        Task<VelicineDTO> GetVelicina(int id);
        Task<bool> AddVelicina(int id);
        Task<bool> DeleteVelicina(int id);
    }
}
