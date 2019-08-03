using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// CRUD operations repository on a Generic type.
    /// </summary>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        /// <summary>
        /// Creates generics repository class instance.
        /// </summary>
        /// <param name="dbContext">Database context object.</param>
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Save changes to the entity to the database.
        /// </summary>
        /// <returns>Returns entity Id.</returns>
        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
        /// <summary>
        /// Save changes to the entity to the database asynchronously.
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
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        /// <summary>
        /// Adds new entity object.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <returns>Returns the entity object.</returns>
        public TEntity Add(TEntity entity)
        {
            return _dbContext.Set<TEntity>().Add(entity).Entity;
        }
        /// <summary>
        /// Adds new entity object asynchronously.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <returns>Returns the entity object.</returns>
        public Task AddAsync(TEntity entity)
        {
            return _dbContext.Set<TEntity>().AddAsync(entity);
        }
        /// <summary>
        /// Updates entity.
        /// </summary>
        /// <param name="entity">Entity with new values.</param>
        public void Edit(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }
        /// <summary>
        /// Deletes specific entity. You have to call SaveChanges() explicitly after to physically delete entity.
        /// </summary>
        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }
        /// <summary>
        /// Finds specific entity.
        /// </summary>
        /// <param name="id">Entity Id.</param>
        /// <returns>Returns entity.</returns>
        public TEntity Find(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }
        /// <summary>
        /// Finds specific entity.
        /// </summary>
        /// <param name="ids">Array of Ids.</param>
        /// <returns>Returns the target entity or null.</returns>
        public TEntity Find(params object[] ids)
        {
            return _dbContext.Set<TEntity>().Find(ids);
        }
        /// <summary>
        /// Finds specific object using Func delegate.
        /// </summary>
        /// <param name="predicate">Entity predicate.</param>
        /// <returns>Returns entity.</returns>
        public TEntity Find(Func<TEntity, bool> predicate)
        {
            return _dbContext.Set<TEntity>().Find(predicate);
        }
        /// <summary>
        /// Gets collection of determined entity.
        /// </summary>
        /// <returns>Returns collection of target entity.</returns>
        public ICollection<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }
    }
}
