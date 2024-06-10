using ERP.Context;
using ERP.DTO;
using ERP.Models;
using ERP.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ERP.Repositories.Repositories
{
    public class VelicineRepository : IVelicine
    {   
        private readonly ApplicationDbContext _context;

        public VelicineRepository(ApplicationDbContext context) { _context = context; }


        public async Task<List<VelicineDTO>> getAllVelicine()
        {
            var velicinaa = await _context.Velicine.ToListAsync();
            var velicinaDTO = new List<VelicineDTO>();
            foreach (var item in velicinaa)
            {
                velicinaDTO.Add(new VelicineDTO
                {

                    broj=item.broj,
                    id=item.id
                });
            }
            return velicinaDTO;
            
        }

        public async Task<VelicineDTO> GetVelicina(int id)
        {
            var velicina= await _context.Velicine.FindAsync(id);
            if (velicina == null)
            {
                throw new Exception("Nema velicine");

            }
            return new VelicineDTO
            {
                id=velicina.id,
                broj = velicina.broj
            };
        }

        public async Task<bool> AddVelicina(int id)
        {
            var velicina = new Velicine { id = id, broj = id };

            await _context.Velicine.AddAsync(velicina);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteVelicina(int id)
        {
            var velicina = await _context.Velicine.FindAsync(id);
            if(velicina != null)
            {
                _context.Velicine.Remove(velicina);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
