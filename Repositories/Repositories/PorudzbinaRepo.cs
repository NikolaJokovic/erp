using ERP.Context;
using ERP.DTO;
using ERP.Models;
using ERP.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ERP.Repositories.Repositories
{
    public class PorudzbinaRepo : IPorudzbina
    {
        private readonly ApplicationDbContext _context;

        public PorudzbinaRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePorudzbina(string Adresa, string Grad, string Drzava, string NacinPlacanja,decimal Iznos, int korisnik_id)
        {
            var porudzbina = new Porudzbina { Adresa = Adresa, Grad = Grad, Drzava = Drzava, NacinPlacanja = NacinPlacanja,Iznos=Iznos,korisnik_id=korisnik_id };

            await _context.Porudzbina.AddAsync(porudzbina);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<PorudzbinaDTO> GetPorudzbina(int id)
        {
            var porudzbina = await _context.Porudzbina.FindAsync(id);
            if (porudzbina == null)
            {
                throw new Exception($"Porudžbina sa ID-jem {id} nije pronađena.");
            }
            return new PorudzbinaDTO
            {
                Adresa=porudzbina.Adresa,
                Drzava=porudzbina.Drzava,
                Grad=porudzbina.Grad,
                NacinPlacanja=porudzbina.NacinPlacanja,
                KorisnikId=porudzbina.korisnik_id
            };
        }

        public async Task<bool> DeletePorudzbina(int id)
        {
            
            var porudzbina = await _context.Porudzbina.FindAsync(id);

            if (porudzbina != null)
            {
                
                _context.Porudzbina.Remove(porudzbina);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> UpdatePorudzbina(int id, string? Adresa, string? Grad, string? Drzava)
        {
            
            var porudzbina = await _context.Porudzbina.FindAsync(id);

            if (porudzbina != null)
            {

                if (Adresa != null) { porudzbina.Adresa = Adresa; };
                if (Grad!=null) { porudzbina.Grad = Grad; }
                if (Drzava != null) { porudzbina.Drzava = Drzava; }

                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
        public async Task<List<PorudzbinaDTO>> GetAllPorudzbina()
        {
            
            var porudzbinaa = await _context.Porudzbina.ToListAsync();
            var porudzbinaDTO= new List<PorudzbinaDTO>();
            foreach(var porudzbina in porudzbinaa)
            {
                porudzbinaDTO.Add(new PorudzbinaDTO
                {
                    Adresa = porudzbina.Adresa,
                    Drzava = porudzbina.Drzava,
                    Grad = porudzbina.Grad,
                    NacinPlacanja = porudzbina.NacinPlacanja,
                    KorisnikId=porudzbina.korisnik_id

                });
            }
            return porudzbinaDTO;
        }

        
    }
}
