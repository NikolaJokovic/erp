using ERP.Models;
using ERP.Repositories.Interfaces;
using ERP.Repositories.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/korisnici")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {

        private readonly IKorisnik _repository;

        public KorisnikController(IKorisnik repository)
        {
            _repository = repository;
        }


        [HttpGet("{email}")]
        
        public async Task<ActionResult<Korisnik>> GetKorisnikByid(string email)
        {
            try
            {
                var korisnik = await _repository.GetKorisnik(email);
                return Ok(korisnik);
            }
            catch (Exception ex) 
            {  
                return  StatusCode(500, "Internal server error: " + ex.Message);  
            }

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Korisnik>>> GetAllKorisnik()
        {
            try
            {
                var korisnici = await _repository.GetAllKorisnik();
                return Ok(korisnici);
            }
            catch(Exception ex)
            {
                return  StatusCode(500, "Internal server error: " + ex.Message); 
            }
        }
        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteKorisnik(string email)
        {
            try
            {
                var korisnik =  await _repository.DeleteKorisnik(email);
                if (korisnik) { return Ok($"Korisnik sa email-om {email} je obrisan"); }
                return NotFound($"Korisni sa email-om {email} nije pronadjen");
                
                
            }
            catch (Exception ex) { return StatusCode(500, "Internal server error: " + ex.Message); }
        }


        [HttpPost("post")]
        public async Task<ActionResult> CreateKorisnik([FromQuery] string ime, string prezime, string email, string password)
        {
            try
            {
                var korisnik = await _repository.CreateKorisnik(ime,prezime,email,password);
                if (korisnik) { return Ok($"Korisnik je kreiran"); }
                return NotFound($"Email {email} vec u upotrebi");
            }
            catch(Exception ex) {
                if (ex.InnerException != null)
                {
                    return StatusCode(500, "Internal server error: " + ex.InnerException.Message);
                }
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
            
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateKorisnik(string email, string? ime, string? prezime, string? password)
        {
            try
            {
                var update = await _repository.UpdateKorisnik(email, ime, prezime, password);
                if (update) { return Ok("Uspesna izmena"); }
                return NotFound("Nije moguce vrsiti izmenu");
            }
            catch (Exception ex) { return StatusCode(500, "Internal server error: " + ex.Message); };

        }
    }
}
