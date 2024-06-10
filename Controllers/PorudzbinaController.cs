using ERP.DTO;
using ERP.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PorudzbinaController : ControllerBase
    {
        private readonly IPorudzbina _repository;

        public PorudzbinaController(IPorudzbina repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PorudzbinaDTO>> GetPorudzbina(int id)
        {
            try
            {
                var porudzbina = await _repository.GetPorudzbina(id);
                return Ok(porudzbina);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreatePorudzbina([FromBody] PorudzbinaDTO porudzbinaDTO)
        {
            try
            {
                var result = await _repository.CreatePorudzbina(porudzbinaDTO.Adresa, porudzbinaDTO.Grad, porudzbinaDTO.Drzava, porudzbinaDTO.NacinPlacanja,porudzbinaDTO.Iznos,porudzbinaDTO.KorisnikId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdatePorudzbina(int id, [FromBody] PorudzbinaDTO porudzbinaDTO)
        {
            try
            {
                var result = await _repository.UpdatePorudzbina(id, porudzbinaDTO.Adresa, porudzbinaDTO.Grad, porudzbinaDTO.Drzava);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeletePorudzbina(int id)
        {
            try
            {
                var result = await _repository.DeletePorudzbina(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<PorudzbinaDTO>>> GetAllPorudzbina()
        {
            try
            {
                var porudzbine = await _repository.GetAllPorudzbina();
                return Ok(porudzbine);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
