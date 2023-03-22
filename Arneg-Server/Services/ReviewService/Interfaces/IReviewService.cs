using Arneg_Server.Dtos.Review;
using Arneg_Server.Models;
using Arneg_Server.Models.Data;

namespace Arneg_Server.Services.ReviewService.Interfaces
{
    public interface IReviewService
    {
        public ServiceResponse<Review> Update(Guid userId, ReviewUpdateDto reviewDto);
        public ServiceResponse<Review> Create(Guid userId, ReviewCreateDto reviewDto);
        public ServiceResponse<Review> Delete(Guid id);
        public ServiceResponse<IEnumerable<ReviewDto>> GetByProductId(Guid proudctId);
    }
}

