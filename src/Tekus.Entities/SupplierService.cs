// <copyright file="SupplierService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Tekus.Entities
{
    /// <summary>
    /// SupplierService class representing the relationship between suppliers and services.
    /// </summary>
    public class SupplierService
    {
        /// <summary>
        /// Gets or sets the unique identifier for the supplier service.
        /// </summary>
        public int SupplierID { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the service.
        /// </summary>
        public int ServiceID { get; set; }

        /// <summary>
        /// Gets or sets the supplier associated with this service.
        /// </summary>
        public Supplier Supplier { get; set; } = null!;

        /// <summary>
        /// Gets or sets the service associated with this supplier.
        /// </summary>
        public Service Service { get; set; } = null!;

        /// <summary>
        /// Gets or sets the countries where the supplier service is available.
        /// </summary>
        public string? Countries { get; set; }
    }
}