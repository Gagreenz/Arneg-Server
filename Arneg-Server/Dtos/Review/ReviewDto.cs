using System.ComponentModel.DataAnnotations.Schema;

namespace Arneg_Server.Dtos.Review
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public float Score { get; set; }
        public string Comment { get; set; }
    }
}
