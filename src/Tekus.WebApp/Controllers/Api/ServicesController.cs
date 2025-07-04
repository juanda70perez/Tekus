// <copyright file="ServicesController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tekus.WebApp.Controllers.Api
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Tekus.Application;
    using Tekus.Entities;

    /// <summary>
    /// ServicesController class for managing service entities.
    /// </summary>
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        /// <summary>
        /// Application service for handling service operations.
        /// </summary>
        private readonly ServiceApplication _serviceApplication;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServicesController"/> class.
        /// </summary>
        /// <param name="serviceApplication">serviceApplication.</param>
        public ServicesController(ServiceApplication serviceApplication)
        {
            ArgumentNullException.ThrowIfNull(serviceApplication, nameof(serviceApplication));
            this._serviceApplication = serviceApplication;
        }

        /// <summary>
        /// Gets all services.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return this.Ok(this._serviceApplication.GetAll());
        }

        /// <summary>
        /// Gets a service by its ID.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>IactionResult.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var service = this._serviceApplication.GetByID(id);
            if (service == null)
            {
                return this.NotFound();
            }

            return this.Ok(service);
        }

        /// <summary>
        /// Inserts a new service entity.
        /// </summary>
        /// <param name="entity">entity.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Service entity)
        {
            return this.Created(string.Empty, this._serviceApplication.Insert(entity));
        }

        /// <summary>
        /// Updates an existing service entity by its ID.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="entity">entity.</param>
        /// <returns>IActionResult.</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Service entity)
        {
            var service = this._serviceApplication.GetByID(id);
            if (service == null)
            {
                return this.NotFound();
            }

            this._serviceApplication.Update(entity);
            return this.NoContent();
        }

        /// <summary>
        /// Deletes a service entity by its ID.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>IActionResult.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var service = this._serviceApplication.GetByID(id);
            if (service == null)
            {
                return this.NotFound();
            }

            this._serviceApplication.Delete(id);
            return this.NoContent();
        }
    }
}