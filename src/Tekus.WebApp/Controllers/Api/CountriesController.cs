// <copyright file="CountriesController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Tekus.WebApp.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;
    using Tekus.Application;
    using Tekus.Entities;

    /// <summary>
    /// CountriesController class for managing country entities.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        /// <summary>
        /// Application service for handling country operations.
        /// </summary>
        private readonly CountryApplication _countryApplication;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountriesController"/> class.
        /// </summary>
        /// <param name="countryApplication">countryApplication.</param>
        public CountriesController(CountryApplication countryApplication)
        {
            ArgumentNullException.ThrowIfNull(countryApplication, nameof(countryApplication));
            this._countryApplication = countryApplication;
        }

        /// <summary>
        /// Gets all countries.
        /// </summary>
        /// <returns>IactionResult.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return this.Ok(this._countryApplication.GetAll());
        }

        /// <summary>
        /// Gets a country by its ID.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>IactionResult.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var country = this._countryApplication.GetByID(id);
            if (country == null)
            {
                return this.NotFound();
            }

            return this.Ok(country);
        }
    }
}