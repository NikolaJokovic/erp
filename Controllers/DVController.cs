using ERP.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DVController : ControllerBase
    {
        private readonly IDostupneVelicine _repository;

        public DVController(IDostupneVelicine repository)
        {
            _repository = repository;
        }

        [HttpDelete("{artikal_id}/{velicina_id}")]
        public async Task<ActionResult<bool>> DeleteDostupnaVelicina(int artikal_id, int velicina_id)
        {
            try
            {
                var result = await _repository.DeleteDostupnaVelicina(artikal_id, velicina_id);
                if (result)
                    return Ok(true);
                else
                    return NotFound("Dostupna veličina nije pronađena.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{artikal_id}/{velicina_id}")]
        public async Task<ActionResult<bool>> AddDostupnaVelicina(int artikal_id, int velicina_id)
        {
            try
            {
                var result = await _repository.addDostupnaVelicina(artikal_id, velicina_id);
                if (result)
                    return Ok(true);
                else
                    return BadRequest("Dostupna veličina već postoji.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("za-artikal/{artikal_id}")]
        public async Task<ActionResult<List<int>>> GetDostupnaVelicinaZaArtikal(int artikal_id)
        {
            try
            {
                var velicine = await _repository.GetDostupnaVelicinaZaA(artikal_id);
                return Ok(velicine);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("za-velicinu/{velicina_id}")]
        public async Task<ActionResult<List<int>>> GetArtikliVelicine(int velicina_id)
        {
            try
            {
                var artikli = await _repository.GetArtikliVelicine(velicina_id);
                return Ok(artikli);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
