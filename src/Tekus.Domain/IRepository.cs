// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Linq.Expressions;

namespace Tekus.Domain
{
    /// <summary>
    /// IRepository interface that defines basic CRUD operations for entities of type T.
    /// </summary>
    /// <typeparam name="T">T.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Gets all entities of type T.
        /// </summary>
        /// <returns>List.</returns>
        List<T> GetAll();

        /// <summary>
        /// Gets an entity of type T by its ID.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>t.</returns>
        T? GetByID(int id);

        /// <summary>
        /// Inserts a new entity of type T into the repository.
        /// </summary>
        /// <param name="entity">entity.</param>
        void Insert(T entity);

        /// <summary>
        /// Updates an existing entity of type T in the repository.
        /// </summary>
        /// <param name="entity">t.</param>
        void Update(T entity);

        /// <summary>
        /// Deletes an entity of type T from the repository by its ID.
        /// </summary>
        /// <param name="entity">entity.</param>
        void Delete(T entity);

        /// <summary>
        /// Saves changes to the repository.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Gets an entity by its identifier.
        /// </summary>
        /// <param name="take">take.</param>
        /// <param name="skip">skip.</param>
        /// <param name="include">include.</param>
        /// <param name="filter">filter.</param>
        /// <param name="orderBy">orderBy.</param>
        /// <returns>collection.</returns>
        IQueryable<T>? Get(int take, int skip, string include, Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);

        /// <summary>
        /// Gets an entity by its identifier.
        /// </summary>
        /// <param name="include">include.</param>
        /// <param name="filter">filter.</param>
        /// <param name="orderBy">orderBy.</param>
        /// <returns>collection.</returns>
        IQueryable<T> Get(string include, Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
    }
}