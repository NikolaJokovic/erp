using ERP.DTO;
using ERP.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VelicineController : ControllerBase
    {
        private readonly IVelicine _repository;

        public VelicineController(IVelicine repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VelicineDTO>>> GetAllVelicine()
        {
            try
            {
                var velicine = await _repository.getAllVelicine();
                return Ok(velicine);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VelicineDTO>> GetVelicina(int id)
        {
            try
            {
                var velicina = await _repository.GetVelicina(id);
                if (velicina == null)
                    return NotFound("Velicina nije pronadjena.");
                return Ok(velicina);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<bool>> AddVelicina(int id)
        {
            try
            {
                var result = await _repository.AddVelicina(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteVelicina(int id)
        {
            try
            {
                var result = await _repository.DeleteVelicina(id);
                if (!result)
                    return NotFound("Velicina nije pronadjena.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
