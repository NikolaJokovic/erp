using ERP.Context;
using ERP.DTO;
using ERP.Models;
using ERP.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ERP.Repositories.Repositories
{
    public class ReviewRepository :IReview
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ReviewDTO> GetReview(int Id)
        {
            var review = await _context.Review.FirstOrDefaultAsync(r => r.Id == Id );
            if (review == null)
            {
                throw new Exception($"Review  ID: {Id}  nije pronadjen.");
            }
            return new ReviewDTO
            {
                ArtikalId = review.artikal_id,
                KorisnikId = review.korisnik_id,
                Ocena = review.Ocena,
                Komentar = review.Komentar
            };
        }

        public async Task<bool> AddReview(int artikalId, int korisnikId, int ocena, string komentar)
        {
            var existingReview = await _context.Review.FirstOrDefaultAsync(r => r.artikal_id == artikalId && r.korisnik_id == korisnikId);
            if (existingReview != null)
            {
                return false; // Review already exists
            }

            var review = new Review
            {
                artikal_id = artikalId,
                korisnik_id = korisnikId,
                Ocena = ocena,
                Komentar = komentar
            };

            _context.Review.Add(review);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateReview(int artikalId, int korisnikId, int? ocena, string? komentar)
        {
            var review = await _context.Review.FirstOrDefaultAsync(r => r.artikal_id == artikalId && r.korisnik_id == korisnikId);
            if (review == null)
            {
                return false; // Review not found
            }

            if (ocena != null)
            {
                review.Ocena = ocena.Value;
            }
            if (komentar != null)
            {
                review.Komentar = komentar;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteReview(int Id)
        {
            var review = await _context.Review.FirstOrDefaultAsync(r => r.Id == Id);
            if (review == null)
            {
                return false; // Review not found
            }

            _context.Review.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ReviewDTO>> GetAllReviews()
        {
            var reviews = await _context.Review.ToListAsync();
            return reviews.Select(r => new ReviewDTO
            {
                ArtikalId = r.artikal_id,
                KorisnikId = r.korisnik_id,
                Ocena = r.Ocena,
                Komentar = r.Komentar
            });
        }
    }
}
