using System.ComponentModel.DataAnnotations;

namespace Arneg_Server.Dtos.User
{
    public class UserRegisterDto
    {
        [Required]
        [StringLength(20)]
        public string Login { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$")]
        public string Password { get; set; } = string.Empty;
    }
}
