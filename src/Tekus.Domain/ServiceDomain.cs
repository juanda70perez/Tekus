// <copyright file="ServiceDomain.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Tekus.Domain
{
    using Tekus.Entities;

    /// <summary>
    /// ServiceDomain class for managing Service entities.
    /// </summary>
    /// <param name="repository">repository.</param>
    public class ServiceDomain(IRepository<Service> repository)
        : DomainBase<Service>(repository)
    {
    }
}
