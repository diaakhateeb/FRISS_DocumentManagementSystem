using DMSDomainModel.Entities;
using Repository.Interfaces;
using UserManagement.UserRepository.Interfaces;

namespace UserManagement.UserRepository
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(IRepository<User> userDbContext)
        {
            UserDbContext = userDbContext;
        }

        public IRepository<User> UserDbContext { get; }
    }
}
