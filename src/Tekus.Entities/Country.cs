// <copyright file="Country.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Tekus.Entities
{
    /// <summary>
    /// Country class representing a country entity.
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Gets or sets the unique identifier for the country.
        /// </summary>
        public string CountryID { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
