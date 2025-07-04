// <copyright file="SupplierRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Tekus.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Linq.Expressions;
    using Tekus.Domain;
    using Tekus.Entities;

    /// <summary>
    /// SupplierRepository class for managing Supplier entities in the database.
    /// </summary>
    public class SupplierRepository : IRepository<Supplier>
    {
        /// <summary>
        /// DataContext instance for database operations.
        /// </summary>
        private readonly DataContext _dataContext;

        /// <summary>
        /// Database set for Supplier entities.
        /// </summary>
        private readonly DbSet<Supplier> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierRepository"/> class.
        /// </summary>
        /// <param name="dataContext">dataContext.</param>
        public SupplierRepository(DataContext dataContext)
        {
            ArgumentNullException.ThrowIfNull(dataContext, nameof(dataContext));
            this._dataContext = dataContext;
            this._dbSet = dataContext.Set<Supplier>();
        }

        /// <summary>
        /// Gets all Supplier entities from the database.
        /// </summary>
        /// <returns>list.</returns>
        public List<Supplier> GetAll()
        {
            return this._dataContext.Suppliers
                    .AsTracking()
                    .Include(s => s.SupplierServices)
                    .ToList();
        }

        /// <summary>
        /// Gets a Supplier entity by its ID.
        /// </summary>
        /// <param name="id">.</param>
        /// <returns>supplier.</returns>
        public Supplier? GetByID(int id)
        {
            return this._dataContext.Suppliers
                .AsNoTracking()
                .Include(s => s.SupplierServices)
                .SingleOrDefault(x => x.SupplierID == id);
        }

        /// <summary>
        /// Inserts a new Supplier entity into the database.
        /// </summary>
        /// <param name="entity">entity.</param>
        public void Insert(Supplier entity)
        {
           this._dataContext.Suppliers.Add(entity);
        }

        /// <summary>
        /// Updates an existing Supplier entity in the database.
        /// </summary>
        /// <param name="entity">entity.</param>
        public void Update(Supplier entity)
        {
            this._dataContext.Suppliers.Update(entity);
        }

        /// <summary>
        /// Deletes a Supplier entity from the database.
        /// </summary>
        /// <param name="entity">entity.</param>
        public void Delete(Supplier entity)
        {
            this._dataContext.Suppliers.Remove(entity);
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
        public IQueryable<Supplier> Get(
        string include,
        Expression<Func<Supplier, bool>>? filter = null,
        Func<IQueryable<Supplier>, IOrderedQueryable<Supplier>>? orderBy = null)
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
        public IQueryable<Supplier>? Get(
            int take,
            int skip,
            string include,
            Expression<Func<Supplier, bool>>? filter = null,
            Func<IQueryable<Supplier>, IOrderedQueryable<Supplier>>? orderBy = null)
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