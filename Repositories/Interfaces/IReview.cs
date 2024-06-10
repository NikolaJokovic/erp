using ERP.DTO;
using ERP.Models;

namespace ERP.Repositories.Interfaces
{
    public interface IReview
    {
        Task<IEnumerable<ReviewDTO>> GetAllReviews();
        Task<ReviewDTO> GetReview(int id);
        Task<bool> AddReview(int artikalId,int korisnikId,int ocena, string komentar);
        Task<bool> UpdateReview(int artikalId, int korisnikId, int? ocena, string? komentar);
        Task<bool> DeleteReview(int id);
    }
}
