using Arneg_Server.Dtos.Review;
using Arneg_Server.Models;
using Arneg_Server.Models.Data;
using Arneg_Server.Models.DB;
using Arneg_Server.Services.ReviewService.Interfaces;
using AutoMapper;

namespace Arneg_Server.Services.ReviewService
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public ReviewService(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public ServiceResponse<Review> Create(Guid userId, ReviewCreateDto reviewDto)
        {
            ServiceResponse<Review> response = new ServiceResponse<Review>();

            var review = _context.Reviews
               .FirstOrDefault(r =>
               (r.UserId == userId) && (r.ProductId == reviewDto.ProductId));

            if (review != null)
            {
                var temp = _mapper.Map<ReviewCreateDto, ReviewUpdateDto>(reviewDto);
                temp.Id = review.Id;

                return Update(userId, temp);
                //response.IsSuccess = false;
                //response.Data = null;
                //response.Message = "Review already exist's";

                //return response;
            }

            review = _mapper.Map<ReviewCreateDto, Review>(reviewDto);
            review.UserId = userId;

            _context.Reviews.Add(review);
            _context.SaveChanges();

            changeRating(review.ProductId);

            response.Data = review;

            return response;
        }
        public ServiceResponse<Review> Update(Guid userId, ReviewUpdateDto reviewDto)
        {
            ServiceResponse<Review> response = new ServiceResponse<Review>();

            var review = _context.Reviews
               .FirstOrDefault(r =>
               (r.Id == reviewDto.Id) && (r.UserId == userId));

            if (review == null)
            {
                response.IsSuccess = false;
                response.Data = null;
                response.Message = "Review not exist's";

                return response;
            }

            _mapper.Map(reviewDto, review);
            _context.SaveChanges();

            changeRating(review.ProductId);

            response.Data = review;

            return response;
        }
        public ServiceResponse<Review> Delete(Guid id)
        {
            ServiceResponse<Review> response = new ServiceResponse<Review>();
            var review = _context.Reviews
               .FirstOrDefault(r => (r.Id == id));

            if(review == null)
            {
                response.IsSuccess = false;
                response.Data = null;
                response.Message = "Review not found";

                return response;
            }

            _context.Reviews.Remove(review);
            _context.SaveChanges();

            changeRating(review.ProductId);

            response.Data = review;

            return response;
        }
        public ServiceResponse<IEnumerable<ReviewDto>> GetByProductId(Guid proudctId)
        {
            ServiceResponse<IEnumerable<ReviewDto>> response = new ServiceResponse<IEnumerable<ReviewDto>>();

            IEnumerable<Review> reviews = _context.Reviews.Where(r => r.ProductId == proudctId).ToArray();
            IEnumerable<ReviewDto> result = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewDto>>(reviews);

            if(result == null)
            {
                response.IsSuccess = false;
                response.Data = null;
                response.Message = "Review not exist's";

                return response;
            }

            response.Data = result;

            return response;
        }
        private void changeRating(Guid productId)
        {
            var avgRating = _context.Reviews.Where(r => r.ProductId == productId).Average(r => r.Score);
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);

            product.Rating = (int)avgRating;
            _context.SaveChanges();
        }
    }
}
