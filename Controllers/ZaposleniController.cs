using ERP.DTO;
using ERP.Repositories.Interfaces;
using ERP.Repositories.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZaposleniController : ControllerBase
    {
        private readonly IZaposleni _repository;

        public ZaposleniController(IZaposleni repository) { _repository = repository; }

        [HttpGet("{id}")]
        public async Task<ActionResult<ZaposleniDTO>> GetZaposleni(int id)
        {
            var zaposleni = await _repository.GetZaposleni(id);
            if (zaposleni == null)
            {
                return NotFound();
            }
            return zaposleni;
        }

        [HttpGet]
        public async Task<ActionResult<List<ZaposleniDTO>>> GetAllZaposleni()
        {
            var zaposleniList = await _repository.GetAllZaposleni();
            return zaposleniList;
        }

        [HttpPost]
        public async Task<ActionResult> CreateZaposleni(ZaposleniDTO zaposleniDTO)
        {
            await _repository.CreateZaposleni(zaposleniDTO.Ime, zaposleniDTO.Prezime, zaposleniDTO.Pozicija);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateZaposleni(int id, ZaposleniDTO zaposleniDTO)
        {
            var success = await _repository.UpdateZaposleni(id, zaposleniDTO.Ime, zaposleniDTO.Prezime, zaposleniDTO.Pozicija);
            if (!success)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteZaposleni(int id)
        {
            await _repository.DeleteZaposleni(id);
            return Ok();
        }
    }
}
