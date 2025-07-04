// <copyright file="SupplierDomain.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Tekus.Domain
{
    using Tekus.Entities;

    /// <summary>
    /// SupplierDomain class for managing Supplier entities.
    /// </summary>
    /// <param name="repository">repository.</param>
    public class SupplierDomain(IRepository<Supplier> repository)
        : DomainBase<Supplier>(repository)
    {
    }
}
