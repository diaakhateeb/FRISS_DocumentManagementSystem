using DMSDomainModel.Entities;
using Repository.Interfaces;

namespace UserManagement.UserRepository.Interfaces
{
    public interface IUserRepository
    {
        IRepository<User> UserDbContext { get; }
    }
}
