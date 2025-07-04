// <copyright file="Service.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Tekus.Entities
{
    /// <summary>
    /// Service class representing a service entity.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Gets or sets the unique identifier for the service.
        /// </summary>
        public int ServiceID { get; set; }

        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price of the service.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the list of supplier services associated with this service.
        /// </summary>
        public List<SupplierService> SupplierServices { get; set; } = [];
    }
}
