using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    /// <summary>
    /// CRUD operations interface on a Generic type.
    /// </summary>
    /// <typeparam name="TEntity">Target generic type</typeparam>
    public interface IRepository<TEntity> : IUnitOfWork, IDisposable where TEntity : class
    {
        /// <summary>
        /// Adds new entity object.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <returns>Returns the entity object.</returns>
        TEntity Add(TEntity entity);
        /// <summary>
        /// Adds new entity object asynchronously.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <returns>Returns the entity object.</returns>
        Task AddAsync(TEntity entity);
        /// <summary>
        /// Edits existing entity. You have to call SaveChanges() explicitly after to post new changes to the database.
        /// </summary>
        /// <param name="entity">Target entity with the new changes.</param>
        void Edit(TEntity entity);
        /// <summary>
        /// Deletes specific entity. You have to call SaveChanges() explicitly after to physically delete entity.
        /// </summary>
        /// <param name="entity">Target entity.</param>
        void Delete(TEntity entity);
        /// <summary>
        /// Finds specific entity.
        /// </summary>
        /// <param name="id">Entity Id.</param>
        /// <returns>Returns deleted entity.</returns>
        TEntity Find(int id);
        /// <summary>
        /// Finds specific entity.
        /// </summary>
        /// <param name="ids">Array of Ids.</param>
        /// <returns>Returns the target entity or null.</returns>
        TEntity Find(params object[] ids);
        /// <summary>
        /// Finds specific object using Func delegate.
        /// </summary>
        /// <param name="predicate">Entity predicate.</param>
        /// <returns>Returns entity.</returns>
        TEntity Find(Func<TEntity, bool> predicate);
        /// <summary>
        /// Gets collection of determined entity.
        /// </summary>
        /// <returns>Returns collection of target entity.</returns>
        ICollection<TEntity> GetAll();
    }
}
