using System.ComponentModel.DataAnnotations;

namespace Collision.Platform.API.Models
{
    public abstract class BaseModel
    {
        [Key]
        public virtual int Id { get; set; }
    }
}
