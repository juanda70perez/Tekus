// <copyright file="SuppliersController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Tekus.WebApp.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Tekus.Application;

    /// <summary>
    /// SuppliersController class for managing supplier entities.
    /// </summary>
    [Authorize]
    public class SuppliersController : Controller
    {
        /// <summary>
        /// Application service for handling supplier operations.
        /// </summary>
        private readonly SupplierApplication _supplierApplication;

        /// <summary>
        /// Initializes a new instance of the <see cref="SuppliersController"/> class.
        /// </summary>
        /// <param name="supplierApplication">supplierApplication.</param>
        public SuppliersController(SupplierApplication supplierApplication)
        {
            ArgumentNullException.ThrowIfNull(supplierApplication, nameof(supplierApplication));
            this._supplierApplication = supplierApplication;
        }

        /// <summary>
        /// Index action that returns the main view for suppliers.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Details action that returns the details view for a specific supplier.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Details(int id)
        {
            return this.View();
        }

        /// <summary>
        /// Create action that returns the view for creating a new supplier.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// Create action that handles the form submission for creating a new supplier.
        /// </summary>
        /// <param name="collection">collection.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return this.RedirectToAction(nameof(this.Index));
            }
            catch
            {
                return this.View();
            }
        }

        /// <summary>
        /// Edit action that returns the view for editing a specific supplier.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Edit(int id)
        {
            var supplier = this._supplierApplication.GetByID(id);
            return this.View(supplier);
        }

        /// <summary>
        /// Edit action that handles the form submission for editing a specific supplier.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="collection">collection.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return this.RedirectToAction(nameof(this.Index));
            }
            catch
            {
                return this.View();
            }
        }

        /// <summary>
        /// Delete action that returns the view for deleting a specific supplier.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Delete(int id)
        {
            return this.View();
        }

        /// <summary>
        /// Delete action that handles the form submission for deleting a specific supplier.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="collection">collection.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return this.RedirectToAction(nameof(this.Index));
            }
            catch
            {
                return this.View();
            }
        }
    }
}
