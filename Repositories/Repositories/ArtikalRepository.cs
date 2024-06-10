using ERP.Context;
using ERP.DTO;
using ERP.Models;
using ERP.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ERP.Repositories.Repositories
{
    public class ArtikalRepository : IArtikal
    {
        private readonly ApplicationDbContext _context;

        public ArtikalRepository(ApplicationDbContext context) { _context = context; }

        public async Task<ArtikalDTO> GetArtikal(int id)
        {
            var artikal = await _context.Artikal.FindAsync(id);
            if (artikal == null) { throw new Exception($"Artikal sa id-jem {id} ne postoji"); }
            return new ArtikalDTO
            {
                Id = id,
                Cena = artikal.Cena,
                Opis = artikal.Opis,
                Naziv = artikal.Naziv,
                KategorijaId = artikal.kategorija_id
            };
            
        }

        public async Task<bool> UpdateArtikal(int id, string naziv, string opis, decimal cena)
        {
            var artikal = await _context.Artikal.FindAsync(id);
            if (artikal != null)
            {
                artikal.Naziv = naziv;
                artikal.Opis = opis;
                artikal.Cena = cena;
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteArtikal(int id)
        {
            var artikal = await _context.Artikal.FindAsync(id);

            if (artikal != null)
            {
                _context.Artikal.Remove(artikal);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> CreateArtikal(string naziv, string opis, decimal cena, int kategorija)
        {
            var noviArtikal = new Artikal
            {
                Naziv = naziv,
                Opis = opis,
                Cena = cena,
                kategorija_id = kategorija
            };
            _context.Artikal.Add(noviArtikal);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ArtikalDTO>> GetAllArtikal()
        {
            var artikali = await _context.Artikal.ToListAsync();
            var artikliDTO= new List<ArtikalDTO>();
            foreach (var artikal in artikali)
            {
                artikliDTO.Add(new ArtikalDTO
                {
                    Naziv=artikal.Naziv,
                    Cena=artikal.Cena,
                    Opis=artikal.Opis,
                    KategorijaId=artikal.kategorija_id,


                });
            }
            return artikliDTO;
        }
    }
}
