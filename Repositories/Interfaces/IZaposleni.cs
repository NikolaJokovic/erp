using ERP.DTO;




namespace ERP.Repositories.Interfaces
{
    public interface IZaposleni
    {
        Task<ZaposleniDTO> GetZaposleni(int id);

        Task<bool> CreateZaposleni(string ime, string prezime, string pozicija);

        Task<bool> UpdateZaposleni(int id,string? ime, string? prezime, string? pozicija);

        Task DeleteZaposleni(int id);

        Task<List<ZaposleniDTO>> GetAllZaposleni();
    }
}
