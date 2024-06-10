using ERP.DTO;
using ERP.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorijaController : ControllerBase
    {
        private readonly IKategorija _repository;

        public KategorijaController(IKategorija kategorijaRepo)
        {
            _repository = kategorijaRepo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KategorijaDTO>> GetKategorija(int id)
        {
            try
            {
                var kategorija = await _repository.GetKategorijaById(id);
                return kategorija;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<KategorijaDTO>>> GetAllKategorije()
        {
            var kategorije = await _repository.GetAllKategorije();
            return kategorije;
        }

        [HttpPost]
        public async Task<ActionResult> CreateKategorija(string naziv)
        {
            await _repository.CreateKategorija(naziv);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateKategorija(int id, string naziv)
        {
            var success = await _repository.UpdateKategorija(id, naziv);
            if (!success)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteKategorija(int id)
        {
            var success = await _repository.DeleteKategorija(id);
            if (!success)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
