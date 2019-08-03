using DMSDomainModel.Entities;
using Repository.Interfaces;
using UserRepository.Api.Interfaces;

namespace UserRepository.Api
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
