using System.ComponentModel.DataAnnotations.Schema;

namespace Arneg_Server.Dtos.Review
{
    public class ReviewCreateDto
    {
        public Guid ProductId { get; set; }
        public string Title { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
    }
}
