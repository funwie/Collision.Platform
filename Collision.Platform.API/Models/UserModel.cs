using System.ComponentModel.DataAnnotations;

namespace Collision.Platform.API.Models
{
    public class UserModel : BaseModel
    {

        [Required, MinLength(3), MaxLength(255)]
        public string Username { get; set; }
    }
}
