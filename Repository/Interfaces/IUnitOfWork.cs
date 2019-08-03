using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    /// <summary>
    /// Unit of Work interface.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Save entity changes to database.
        /// </summary>
        /// <returns>Returns entity Id.</returns>
        int SaveChanges();
        /// <summary>
        /// Save entity changes to database asynchronously.
        /// </summary>
        /// <returns>Returns task object.</returns>
        Task<int> SaveChangesAsync();
        /// <summary>
        /// Database context transaction object.
        /// </summary>
        IDbContextTransaction DbContextTransaction { get; }
    }
}
