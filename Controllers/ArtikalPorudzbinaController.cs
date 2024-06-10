using ERP.DTO;
using ERP.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtikalPorudzbinaController : ControllerBase
    {
        private readonly IAP _repository;

        public ArtikalPorudzbinaController(IAP repository)
        {
            _repository = repository;
        }

        
        [HttpGet("{artikal_id}/{porudzbina_id}")]
        public async Task<ActionResult<ArtikalPorudzbinaDTO>> GetArtikalPorudzbina(int artikal_id, int porudzbina_id)
        {
            try
            {
                var ap = await _repository.GetArtikalPorudzbina(artikal_id, porudzbina_id);
                return Ok(ap);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        
        [HttpGet("porudzbina/{porudzbina_id}")]
        public async Task<ActionResult<List<int>>> GetArtikal(int porudzbina_id)
        {
            try
            {
                var artikli = await _repository.GetArtikal(porudzbina_id);
                return Ok(artikli);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        
        [HttpPost]
        public async Task<ActionResult<bool>> PostArtikalPorudzbina(int artikal_id, int porudzbina_id)
        {
            try
            {
                var result = await _repository.PostArtikalPorudzbina(artikal_id, porudzbina_id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
        [HttpDelete("{artikal_id}/{porudzbina_id}")]
        public async Task<ActionResult<bool>> RemoveArtikalPorudzbina(int artikal_id, int porudzbina_id)
        {
            try
            {
                var result = await _repository.RemoveArtikalPorudzbina(artikal_id, porudzbina_id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
