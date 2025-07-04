// <copyright file="SupplierDomainTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Tekus.UnitTest
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using Tekus.Domain;
    using Tekus.Entities;
    using Xunit;

    /// <summary>
    /// SupplierDomainTests class for testing
    /// </summary>
    public class SupplierDomainTests
    {
        private readonly Mock<IRepository<Supplier>> _mockRepo;
        private readonly DomainBase<Supplier> _domain;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierDomainTests"/> class.
        /// </summary>
        public SupplierDomainTests()
        {
            this._mockRepo = new Mock<IRepository<Supplier>>();
            this._domain = new DomainBase<Supplier>(this._mockRepo.Object);
        }

        /// <summary>
        /// GetAll_ShouldReturnAllSuppliers
        /// </summary>
        [Fact]
        public void GetAll_ShouldReturnAllSuppliers()
        {
            var suppliers = new List<Supplier>
            {
                new Supplier { SupplierID = 1, Name = "Importaciones Tekus", Identification = "900123456", EmailAddress = "info@tekus.com" }
            };

            this._mockRepo.Setup(r => r.GetAll()).Returns(suppliers);

            var result = _domain.GetAll();

            // Assert
            Assert.Single(result);
            Assert.Equal("Importaciones Tekus", result[0].Name);
        }

        /// <summary>
        /// GetByID_ShouldReturnSupplier_IfExists.
        /// </summary>
        [Fact]
        public void GetByID_ShouldReturnSupplier_IfExists()
        {
            var supplier = new Supplier { SupplierID = 2, Name = "Tekus 2" };
            this._mockRepo.Setup(r => r.GetByID(2)).Returns(supplier);

            var result = this._domain.GetByID(2);

            Assert.NotNull(result);
            Assert.Equal("Tekus 2", result?.Name);
        }

        /// <summary>
        /// GetByID_ShouldReturnNull_IfNotExists.
        /// </summary>
        [Fact]
        public void Insert_ShouldCallInsertAndSave()
        {
            var supplier = new Supplier { SupplierID = 3, Name = "Nuevo Proveedor" };

            var result = _domain.Insert(supplier);

            this._mockRepo.Verify(r => r.Insert(supplier), Times.Once);
            this._mockRepo.Verify(r => r.SaveChanges(), Times.Once);
            Assert.Equal("Nuevo Proveedor", result.Name);
        }

        /// <summary>
        /// Update_ShouldCallUpdateAndSave.
        /// </summary>
        [Fact]
        public void Update_ShouldCallUpdateAndSave()
        {
            var supplier = new Supplier { SupplierID = 4, Name = "Actualizado" };

            var result = this._domain.Update(supplier);

            this._mockRepo.Verify(r => r.Update(supplier), Times.Once);
            this._mockRepo.Verify(r => r.SaveChanges(), Times.Once);
        }

        /// <summary>
        /// Delete_ShouldCallDelete_WhenSupplierExists.
        /// </summary>
        [Fact]
        public void Delete_ShouldCallDelete_WhenSupplierExists()
        {
            var supplier = new Supplier { SupplierID = 5, Name = "A eliminar" };
            this._mockRepo.Setup(r => r.GetByID(5)).Returns(supplier);

            this._domain.Delete(5);

            this._mockRepo.Verify(r => r.Delete(supplier), Times.Once);
            this._mockRepo.Verify(r => r.SaveChanges(), Times.Once);
        }

        /// <summary>
        /// Delete_ShouldThrow_WhenSupplierNotFound.
        /// </summary>
        [Fact]
        public void Delete_ShouldThrow_WhenSupplierNotFound()
        {
            this._mockRepo.Setup(r => r.GetByID(99)).Returns((Supplier?)null);

            var ex = Assert.Throws<ArgumentException>(() => this._domain.Delete(99));
            Assert.Equal("Entity with ID 99 not found.", ex.Message);
        }
    }
}
