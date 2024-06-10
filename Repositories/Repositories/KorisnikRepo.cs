using ERP.Context;
using ERP.DTO;
using ERP.Models;
using ERP.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ERP.Repositories.Repositories
{
    public class KorisnikRepo:IKorisnik
    {
        private readonly ApplicationDbContext _context;

        public KorisnikRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<KorisnikDTO> GetKorisnik(string email)
        {
            var korisnik = await _context.Korisnik.FirstOrDefaultAsync(k => k.Email == email);
            if (korisnik == null)
            {
                throw new Exception($"Korisnik sa email-om {email} nije pronađen.");
            }
            return new KorisnikDTO
            {
                Id = korisnik.Id,
                Ime = korisnik.Ime,
                Prezime = korisnik.Prezime,
                Email = korisnik.Email
            };
        }
        public async Task<bool> CreateKorisnik(string ime, string prezime, string email, string password)
        {
            var postoji = await _context.Korisnik.FirstOrDefaultAsync(k => k.Email == email);
            if (postoji != null)
            {
                return false;
            }

            Korisnik korisnik = new Korisnik
            {
                Ime = ime,
                Prezime = prezime,
                Email = email,
                Password = password
            };
            _context.Korisnik.Add(korisnik);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> UpdateKorisnik(string email,string? ime, string? prezime, string? password)
        {
            var korisnik =await _context.Korisnik.FirstOrDefaultAsync(k => k.Email == email);

            if (korisnik != null) 
            {
                if(prezime != null) { korisnik.Prezime = prezime; };
                if(ime != null) { korisnik.Ime = ime; };
                if (password != null) { korisnik.Password = password; };
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteKorisnik(string email)
        {
            var korisnik = await _context.Korisnik.FirstOrDefaultAsync(k => k.Email == email);

            if (korisnik != null)
            {
                _context.Korisnik.Remove(korisnik);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<KorisnikDTO>> GetAllKorisnik()
        {
            var korisnici = await _context.Korisnik.ToListAsync();
            var korisniciDTO = new List<KorisnikDTO>();
            foreach (var korisnik in korisnici)
            {
                korisniciDTO.Add(new KorisnikDTO
                {
                    Id = korisnik.Id,
                    Ime = korisnik.Ime,
                    Prezime = korisnik.Prezime,
                    Email = korisnik.Email
                });
            }
            return korisniciDTO;
        }
    }
}
