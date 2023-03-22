using Arneg_Server.Dtos.Review;
using Arneg_Server.Models;
using Arneg_Server.Models.DB;
using Arneg_Server.Services.ReviewService.Interfaces;
using Arneg_Server.Services.TokenService.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arneg_Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
           _reviewService = reviewService;
        }

        [HttpPost("Create")]
        [Authorize]
        public IActionResult Create([FromBody]ReviewCreateDto reviewDto)
        {
            Guid userId = Guid.Parse(HttpContext.Items["UserId"].ToString());
            var serviceResponse = _reviewService.Create(userId, reviewDto);

            if (!serviceResponse.IsSuccess)
            {
                return BadRequest(serviceResponse.Message);
            }

            return Ok(serviceResponse.Data);
        }

        [HttpPut("Update")]
        [Authorize]
        public IActionResult Update([FromBody]ReviewUpdateDto reviewDto)
        {
            Guid userId = Guid.Parse(HttpContext.Items["UserId"].ToString());
            var serviceResponse = _reviewService.Update(userId, reviewDto);

            if (!serviceResponse.IsSuccess)
            {
                return BadRequest(serviceResponse.Message);
            }

            return Ok();
        }

        [HttpGet("GetByProductId")]
        public ActionResult<IEnumerable<ReviewDto>> GetByProductId([FromQuery] Guid id) 
        {
            var serviceResponse = _reviewService.GetByProductId(id);

            if (!serviceResponse.IsSuccess)
            {
                return BadRequest(serviceResponse.Message);
            }

            return Ok(serviceResponse.Data);
        }
    }
}
