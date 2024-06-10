using ERP.DTO;
using ERP.Repositories.Interfaces;
using ERP.Repositories.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/artikal")]
    [ApiController]
    public class ArtikalController : ControllerBase
    {
        private readonly IArtikal _repository;

        public ArtikalController(IArtikal repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtikal(int id)
        {
            var artikal = await _repository.GetArtikal(id);
            if (artikal == null)
            {
                return NotFound();
            }
            return Ok(artikal);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteArtikal(int id)
        {
            var result = await _repository.DeleteArtikal(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

      

        [HttpPost]
        public async Task<IActionResult> CreateArtikal(string Naziv, string Opis,decimal cena, int kategorija )
        {
            
            var result = await _repository.CreateArtikal(Naziv, Opis, cena, kategorija);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArtikal()
        {
            var artikli = await _repository.GetAllArtikal();
            return Ok(artikli);
        }

    }
}
