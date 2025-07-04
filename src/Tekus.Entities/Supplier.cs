// <copyright file="Supplier.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Tekus.Entities
{
    /// <summary>
    /// Supplier class representing a supplier entity in the system.
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Gets or sets the unique identifier for the supplier. 
        /// </summary>
        public int SupplierID { get; set; }

        /// <summary>
        /// Gets or sets the identification number of the supplier.
        /// </summary>
        public string Identification { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the supplier.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number of the supplier.
        /// </summary>
        public string EmailAddress { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number of the supplier.
        /// </summary>
        public List<SupplierService> SupplierServices { get; set; } = [];
    }
}
