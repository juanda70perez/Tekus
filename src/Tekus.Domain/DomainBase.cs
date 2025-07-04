// <copyright file="DomainBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Linq.Expressions;

namespace Tekus.Domain
{
    /// <summary>
    /// DomainBase class that provides basic CRUD operations for entities of type T.
    /// </summary>
    /// <typeparam name="T">T.</typeparam>
    public class DomainBase<T> : IDomainBase<T>
    {
        /// <summary>
        /// The repository used for data access operations.
        /// </summary>
        private readonly IRepository<T> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainBase{T}"/> class.
        /// </summary>
        /// <param name="repository">repository.</param>
        public DomainBase(IRepository<T> repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));
            this._repository = repository;
        }

        /// <summary>
        /// Gets all entities of type T from the repository.
        /// </summary>
        /// <returns>t.</returns>
        public List<T> GetAll()
        {
            return this._repository.GetAll();
        }

        /// <summary>
        /// Gets an entity of type T by its ID.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>t.</returns>
        public T? GetByID(int id)
        {
            return this._repository.GetByID(id);
        }

        /// <summary>
        /// Inserts a new entity of type T into the repository.
        /// </summary>
        /// <param name="entity">entity.</param>
        /// <returns>T.</returns>
        public T Insert(T entity)
        {
            this._repository.Insert(entity);
            this._repository.SaveChanges();

            return entity;
        }

        /// <summary>
        /// Updates an existing entity of type T in the repository.
        /// </summary>
        /// <param name="entity">entity.</param>
        /// <returns>T.</returns>
        public T Update(T entity)
        {
            this._repository.Update(entity);
            this._repository.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Deletes an entity of type T by its ID from the repository.
        /// </summary>
        /// <param name="id">id.</param>
        /// <exception cref="ArgumentException">ArgumentException.</exception>
        public void Delete(int id)
        {
            var entity = this._repository.GetByID(id);
            if (entity == null)
            {
                throw new ArgumentException($"Entity with ID {id} not found.");
            }

            this._repository.Delete(entity);
            this._repository.SaveChanges();
        }
    }
}