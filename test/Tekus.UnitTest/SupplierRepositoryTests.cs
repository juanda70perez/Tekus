// <copyright file="SupplierRepositoryTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Tekus.UnitTest
{
    using Microsoft.EntityFrameworkCore;
    using Tekus.Entities;
    using Tekus.Infrastructure;

    /// <summary>
    /// Unit tests for the SupplierRepository class.
    /// </summary>
    public class SupplierRepositoryTests
    {
        private DataContext GetInMemoryContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return new DataContext(options);
        }

        /// <summary>
        /// Tests that GetAll returns all suppliers when no filters are applied.
        /// </summary>
        [Fact]
        public void Get_WithFilterAndOrderBy_ReturnsExpectedSuppliers()
        {
            using var context = this.GetInMemoryContext("SuppliersDB1");
            context.Suppliers.AddRange(
                new Supplier { SupplierID = 1, Name = "Tekus", Identification = "9001" },
                new Supplier { SupplierID = 2, Name = "Otro", Identification = "9002" },
                new Supplier { SupplierID = 3, Name = "Tekus Corp", Identification = "9003" }
            );
            context.SaveChanges();

            var repo = new SupplierRepository(context);

            var result = repo.Get(
                include: string.Empty, 
                filter: s => s.Name.Contains("Tekus"),
                orderBy: q => q.OrderByDescending(s => s.SupplierID)
            ).ToList();

            Assert.Equal(2, result.Count);
            Assert.Equal("Tekus Corp", result[0].Name);
            Assert.Equal("Tekus", result[1].Name);
        }

        /// <summary>
        /// Tests that Get returns a subset of suppliers with pagination.
        /// </summary>
        [Fact]
        public void Get_WithPagination_ReturnsCorrectSubset()
        {
            using var context = this.GetInMemoryContext("SuppliersDB2");
            for (int i = 1; i <= 10; i++)
            {
                context.Suppliers.Add(new Supplier
                {
                    SupplierID = i,
                    Name = $"Proveedor {i}",
                    Identification = $"ID{i}"
                });
            }
            context.SaveChanges();

            var repo = new SupplierRepository(context);

            var result = repo.Get(
                take: 3,
                skip: 2,
                include: "",
                orderBy: q => q.OrderBy(s => s.SupplierID)
            ).ToList();

            Assert.Equal(3, result.Count);
            Assert.Equal("Proveedor 3", result[0].Name);
            Assert.Equal("Proveedor 5", result[2].Name);
        }
    }
}
