using System.ComponentModel.DataAnnotations.Schema;

namespace Arneg_Server.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public float Score { get; set; }
        public string Comment { get; set; }
    }
}
