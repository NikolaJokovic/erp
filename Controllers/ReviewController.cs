using ERP.DTO;
using ERP.Models;
using ERP.Repositories.Interfaces;
using ERP.Repositories.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReview _repository;

        public ReviewController(IReview repository)
        {
            _repository = repository;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ReviewDTO>> GetReview(int Id)
        {
            try
            {
                var review = await _repository.GetReview(Id);
                return Ok(review);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddReview(ReviewDTO reviewDTO)
        {
            try
            {
                var result = await _repository.AddReview(reviewDTO.ArtikalId, reviewDTO.KorisnikId, reviewDTO.Ocena, reviewDTO.Komentar);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{artikalId}/{korisnikId}")]
        public async Task<ActionResult<bool>> UpdateReview(int artikalId, int korisnikId, ReviewDTO reviewDTO)
        {
            try
            {
                var result = await _repository.UpdateReview(artikalId, korisnikId, reviewDTO.Ocena, reviewDTO.Komentar);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<bool>> DeleteReview(int Id)
        {
            try
            {
                var result = await _repository.DeleteReview(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetAllReviews()
        {
            try
            {
                var reviews = await _repository.GetAllReviews();
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
