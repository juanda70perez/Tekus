// <copyright file="HomeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Tekus.WebApp.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Tekus.WebApp.Models;

    /// <summary>
    /// HomeController class for managing the home page and privacy policy.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Logger for the HomeController.
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">logger.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// Index action that returns the home page view.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Privacy action that returns the privacy policy view.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Privacy()
        {
            return this.View();
        }

        /// <summary>
        /// Error action that returns the error view with the request ID.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
