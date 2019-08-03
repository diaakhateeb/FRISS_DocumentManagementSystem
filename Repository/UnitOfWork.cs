using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repository.Interfaces;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// Unit of Work class.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        /// <summary>
        /// Creates Unit of Work instance.
        /// </summary>
        /// <param name="dbContext">Database context object.</param>
        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Save entity changes to database.
        /// </summary>
        /// <returns>Returns entity Id.</returns>
        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
        /// <summary>
        /// Save entity changes to database asynchronously.
        /// </summary>
        /// <returns>Returns task object.</returns>
        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
        /// <summary>
        /// Database context transaction object.
        /// </summary>
        public IDbContextTransaction DbContextTransaction => _dbContext.Database.BeginTransaction();
    }
}
