// <copyright file="SuppliersController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Tekus.WebApp.Controllers.Api
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Tekus.Application;
    using Tekus.Entities;

    /// <summary>
    /// SuppliersController class for managing supplier entities.
    /// </summary>
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        /// <summary>
        /// Application service for handling supplier operations.
        /// </summary>
        private readonly SupplierApplication _supplierApplication;

        /// <summary>
        /// Initializes a new instance of the <see cref="SuppliersController"/> class.
        /// </summary>
        /// <param name="supplierApplication">supplierApplication.</param>
        public SuppliersController(SupplierApplication supplierApplication)
        {
            ArgumentNullException.ThrowIfNull(supplierApplication, nameof(supplierApplication));
            this._supplierApplication = supplierApplication;
        }

        /// <summary>
        /// Gets all suppliers.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this._supplierApplication.GetAll());
        }

        /// <summary>
        /// Gets a supplier by its ID.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>IAction.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var supplier = this._supplierApplication.GetByID(id);
            if (supplier == null)
            {
                return this.NotFound();
            }

            return this.Ok(supplier);
        }

        /// <summary>
        /// Inserts a new supplier entity.
        /// </summary>
        /// <param name="entity">entity.</param>
        /// <returns>IAction.</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Supplier entity)
        {
            return this.Created(string.Empty, this._supplierApplication.Insert(entity));
        }

        /// <summary>
        /// Updates an existing supplier entity by its ID.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="entity">entity.</param>
        /// <returns>IActionResult.</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Supplier entity)
        {
            var supplier = this._supplierApplication.GetByID(id);
            if (supplier == null)
            {
                return this.NotFound();
            }

            this._supplierApplication.Update(entity);
            return this.NoContent();
        }

        /// <summary>
        /// Deletes a supplier entity by its ID.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>IactionResult.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var supplier = this._supplierApplication.GetByID(id);
            if (supplier == null)
            {
                return this.NotFound();
            }

            this._supplierApplication.Delete(id);
            return this.NoContent();
        }
    }
}