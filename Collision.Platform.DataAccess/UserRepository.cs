using Collision.Platform.Domain;

namespace Collision.Platform.DataAccess
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(AppDbContext context) : base(context) {}
    }
}
