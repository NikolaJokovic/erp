using ERP.Context;
using ERP.DTO;
using ERP.Models;
using ERP.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ERP.Repositories.Repositories
{
    public class DostupneVelicineRepo:IDostupneVelicine
    {
        private readonly ApplicationDbContext _context;

        public DostupneVelicineRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteDostupnaVelicina(int artikal_id, int velicina_id)
        {
             var dostupnaVelicina = await _context.DostupnaVelicina.FirstOrDefaultAsync(dv => dv.artikal_id == artikal_id && dv.velicina_id == velicina_id);
            if(dostupnaVelicina != null)
            {
                _context.DostupnaVelicina.Remove(dostupnaVelicina);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> addDostupnaVelicina(int artikal_id, int velicina_id)
        {
            var dV= await _context.DostupnaVelicina.FirstOrDefaultAsync(dv => dv.artikal_id == artikal_id && dv.velicina_id == velicina_id);

            if (dV != null) { return false; };

            dV= new DostupnaVelicina { artikal_id = artikal_id,velicina_id = velicina_id };
            
            await _context.DostupnaVelicina.AddAsync(dV);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<int>> GetDostupnaVelicinaZaA(int artikal_id)
        {
            var dostupneVelicine = await _context.DostupnaVelicina
            .Where(dv => dv.artikal_id == artikal_id)
            .Select( dv=> dv.velicina_id )
            .ToListAsync();

            return dostupneVelicine;
        }

        public async Task<List<int>> GetArtikliVelicine(int velicina_id)
        {
            var dostupniArtikli= await _context.DostupnaVelicina
           .Where(dv => dv.velicina_id == velicina_id)
           .Select(dv => dv.artikal_id)
           .ToListAsync();

            return dostupniArtikli;
        }
    }
}
