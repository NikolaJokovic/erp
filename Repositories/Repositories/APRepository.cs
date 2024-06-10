using ERP.Context;
using ERP.DTO;
using ERP.Models;
using ERP.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ERP.Repositories.Repositories
{
    public class APRepository:IAP
    {
        private readonly ApplicationDbContext _context;

        public APRepository(ApplicationDbContext context) { _context = context; }

        public async Task<ArtikalPorudzbinaDTO> GetArtikalPorudzbina(int artikal_id, int porudzbina_id)
        {
            var AP= await _context.ArtikalPorudzbina.FirstOrDefaultAsync(r=>r.artikal_id==artikal_id && r.porudzbina_id==porudzbina_id);
            if (AP==null) { throw new Exception("Ne postoji"); }

            return new ArtikalPorudzbinaDTO { porudzbina_id = porudzbina_id, artikal_id = artikal_id };
        }

        public async Task<List<int>> GetArtikal(int porudzbina_id)
        {
            var ap = await _context.ArtikalPorudzbina.Where(dv => dv.porudzbina_id == porudzbina_id)
            .Select(dv => dv.artikal_id)
            .ToListAsync();

            return ap;
        }

        public async Task<bool> RemoveArtikalPorudzbina(int artikal_id, int porudzbina_id)
        {
            var ap= await _context.ArtikalPorudzbina.FirstOrDefaultAsync(r => r.artikal_id == artikal_id && r.porudzbina_id == porudzbina_id);
            if(ap==null) { throw new Exception("Artikal ne vec ne postoji"); }
            _context.ArtikalPorudzbina.Remove(ap);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PostArtikalPorudzbina(int artikal_id, int porudzbina_id)
        {
            var novi = new ArtikalPorudzbina
            {
                artikal_id = artikal_id,
                porudzbina_id = porudzbina_id
            };
            _context.ArtikalPorudzbina.Add(novi);
            _context.SaveChangesAsync();
            return true;
        }
    }
}
