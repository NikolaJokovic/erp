using ERP.Context;
using ERP.DTO;
using ERP.Models;
using ERP.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ERP.Repositories.Repositories
{
    public class KategorijaRepo:IKategorija
    {
        private readonly ApplicationDbContext _context;

        public KategorijaRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateKategorija(string kategorija)
        {
            var novaKategorija = new Kategorija { kategorija = kategorija };

            _context.Kategorija.Add(novaKategorija);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<KategorijaDTO> GetKategorijaById(int id)
        {
            var kategorija= await _context.Kategorija.FindAsync(id);
            if(kategorija==null)
            {
                throw new Exception($"Zaposleni sa ID-jem {id} nije pronadjen");

            }
            return new KategorijaDTO
            {
                Id = kategorija.Id,
                kategorija = kategorija.kategorija
            };
        }

        public async Task<List<KategorijaDTO>> GetAllKategorije()
        {
            var kategorijaa = await _context.Kategorija.ToListAsync();
            var kategorijaDTO= new List<KategorijaDTO>();
            foreach(var kategorija in kategorijaa)
            {
                kategorijaDTO.Add(new KategorijaDTO
                {
                    Id = kategorija.Id,
                    kategorija = kategorija.kategorija
                });
            }
            return kategorijaDTO;
        }

        public async Task<bool> UpdateKategorija(int id, string naziv)
        {
            var kategorija = await _context.Kategorija.FindAsync(id);

            if (kategorija == null)
                return false;

            kategorija.kategorija = naziv;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteKategorija(int id)
        {
            var kategorija = await _context.Kategorija.FindAsync(id);

            if (kategorija == null)
                return false;

            _context.Kategorija.Remove(kategorija);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
