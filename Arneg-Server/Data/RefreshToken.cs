using System.ComponentModel.DataAnnotations.Schema;

namespace Arneg_Server.Models.Data
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
