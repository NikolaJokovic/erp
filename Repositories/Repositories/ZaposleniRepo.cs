using ERP.Context;
using ERP.DTO;
using ERP.Models;
using ERP.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ERP.Repositories.Repositories
{
    public class ZaposleniRepo: IZaposleni
    {
        private readonly ApplicationDbContext _context;

        public ZaposleniRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ZaposleniDTO> GetZaposleni(int id)
        {
            var zaposleni = await _context.Zaposleni.FindAsync(id);
            if (zaposleni == null)
            {
                throw new Exception($"Zaposleni sa ID-jem {id} nije pronađen.");
            }
            return new ZaposleniDTO
            {
                Id = zaposleni.Id,
                Ime = zaposleni.Ime,
                Prezime = zaposleni.Prezime,
                Pozicija = zaposleni.Pozicija
                
            };
        }
        public async Task<bool> CreateZaposleni(string ime, string prezime, string pozicija)
        {
           
            var noviZaposleni = new Zaposleni
            {
                Ime = ime,
                Prezime = prezime,
                Pozicija = pozicija
            };

            
            _context.Zaposleni.Add(noviZaposleni);

            
            await _context.SaveChangesAsync();

            return true; 
        }

        public async Task<bool> UpdateZaposleni(int id, string? ime, string? prezime, string? pozicija)
        {
            
            var zaposleni = await _context.Zaposleni.FindAsync(id);

            if (zaposleni != null)
            {
               
                if (ime != null)
                    zaposleni.Ime = ime;

                if (prezime != null)
                    zaposleni.Prezime = prezime;

                if (pozicija != null)
                    zaposleni.Pozicija = pozicija;

                
                await _context.SaveChangesAsync();
                return true; 
            }

            return false; 
        }

        public async Task DeleteZaposleni(int id)
        {
           
            var zaposleni = await _context.Zaposleni.FindAsync(id);

            if (zaposleni != null)
            {
                
                _context.Zaposleni.Remove(zaposleni);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ZaposleniDTO>> GetAllZaposleni()
        {

            var zaposlenii = await _context.Zaposleni.ToListAsync();
            var zaposleniDTO = new List<ZaposleniDTO>();
            foreach (var zaposleni in zaposlenii)
            {
                zaposleniDTO.Add(new ZaposleniDTO
                {
                    Id = zaposleni.Id,
                    Ime = zaposleni.Ime,
                    Prezime = zaposleni.Prezime,
                    Pozicija = zaposleni.Pozicija
                });
            }
            return zaposleniDTO;
        }
    }

}

