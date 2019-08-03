using DMSDomainModel.Entities;
using Repository.Interfaces;

namespace UserRepository.Api.Interfaces
{
    public interface IUserRepository
    {
        IRepository<User> UserDbContext { get; }
    }
}
