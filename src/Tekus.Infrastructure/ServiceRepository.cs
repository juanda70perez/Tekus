// <copyright file="ServiceRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Tekus.Infrastructure
{
    using System.Linq.Expressions;
    using Microsoft.EntityFrameworkCore;
    using Tekus.Domain;
    using Tekus.Entities;

    /// <summary>
    /// ServiceRepository class for managing Service entities in the database.
    /// </summary>
    public class ServiceRepository : IRepository<Service>
    {
        /// <summary>
        /// DataContext instance for database operations.
        /// </summary>
        private readonly DataContext _dataContext;

        /// <summary>
        /// Database set for Service entities.
        /// </summary>
        private readonly DbSet<Service> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRepository"/> class.
        /// </summary>
        /// <param name="dataContext">dataContext.</param>
        public ServiceRepository(DataContext dataContext)
        {
            ArgumentNullException.ThrowIfNull(dataContext, nameof(dataContext));
            this._dataContext = dataContext;
            this._dbSet = dataContext.Set<Service>();
        }

        /// <summary>
        /// Gets all Service entities from the database.
        /// </summary>
        /// <returns>list.</returns>
        public List<Service> GetAll()
        {
            return this._dataContext.Services
                .AsNoTracking()
                .Include(s => s.SupplierServices).ToList();
        }

        /// <summary>
        /// Gets a Service entity by its ID.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>service.</returns>
        public Service? GetByID(int id)
        {
            return this._dataContext.Services
                .AsNoTracking()
                .Include(s => s.SupplierServices)
                .SingleOrDefault(x => x.ServiceID == id);
        }

        /// <summary>
        /// Inserts a new Service entity into the database.
        /// </summary>
        /// <param name="entity">entity.</param>
        public void Insert(Service entity)
        {
            this._dataContext.Services.Add(entity);
        }

        /// <summary>
        /// Updates an existing Service entity in the database.
        /// </summary>
        /// <param name="entity">entity.</param>
        public void Update(Service entity)
        {
            this._dataContext.Services.Update(entity);
        }

        /// <summary>
        /// Deletes a Service entity from the database.
        /// </summary>
        /// <param name="entity">entity.</param>
        public void Delete(Service entity)
        {
            this._dataContext.Services.Remove(entity);
        }

        /// <summary>
        /// Saves changes to the database.
        /// </summary>
        public void SaveChanges()
        {
            this._dataContext.SaveChanges();
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="include">
        ///     entities to include.
        /// </param>
        /// <param name="filter">
        ///     The filter.
        /// </param>
        /// <param name="orderBy">
        ///     The order by.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<Service> Get(
        string include,
        Expression<Func<Service, bool>>? filter = null,
        Func<IQueryable<Service>, IOrderedQueryable<Service>>? orderBy = null)
        {
            var query = this._dbSet.AsQueryable();
            query = include.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty.Trim()));

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return orderBy == null ? query.AsQueryable() : orderBy.Invoke(query).AsQueryable();
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="take">
        /// The take.
        /// </param>
        /// <param name="skip">
        /// The skip.
        /// </param>
        /// <param name="include">
        /// The include.
        /// </param>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <param name="orderBy">
        /// The order by.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<Service>? Get(
            int take,
            int skip,
            string include,
            Expression<Func<Service, bool>>? filter = null,
            Func<IQueryable<Service>, IOrderedQueryable<Service>>? orderBy = null)
        {
            var query = this._dbSet.AsQueryable();
            query = include.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty.Trim()));

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return orderBy == null ? query.Skip(skip).Take(take).AsQueryable() : orderBy.Invoke(query).Skip(skip).Take(take).AsQueryable();
        }
    }
}