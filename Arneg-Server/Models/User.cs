using Arneg_Server.Models.Data;

namespace Arneg_Server.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Login { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = default!;
        public byte[] PasswordSalt { get; set; } = default!;
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
