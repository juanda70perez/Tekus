// <copyright file="IDomainBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Tekus.Domain
{
    /// <summary>
    /// IDomainBase interface that defines basic CRUD operations for entities of type T.
    /// </summary>
    /// <typeparam name="T">T.</typeparam>
    public interface IDomainBase<T>
    {
        /// <summary>
        /// Gets all entities of type T.
        /// </summary>
        /// <returns>list.</returns>
        List<T> GetAll();

        /// <summary>
        /// Gets an entity of type T by its ID.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>T.</returns>
        T? GetByID(int id);

        /// <summary>
        /// Inserts a new entity of type T into the repository.
        /// </summary>
        /// <param name="entity">entity.</param>
        /// <returns>T.</returns>
        T Insert(T entity);

        /// <summary>
        /// Updates an existing entity of type T in the repository.
        /// </summary>
        /// <param name="entity">entity.</param>
        /// <returns>T.</returns>
        T Update(T entity);

        /// <summary>
        /// Deletes an entity of type T from the repository.
        /// </summary>
        /// <param name="id">id.</param>
        void Delete(int id);
    }
}