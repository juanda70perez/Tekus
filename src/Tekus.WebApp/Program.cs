// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Tekus.WebApp
{
    using System.Net;
    using System.Net.Http.Json;
    using System.Text.Json.Serialization;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Tekus.Application;
    using Tekus.Domain;
    using Tekus.Entities;
    using Tekus.Infrastructure;
    using Tekus.WebApp.Data;

    /// <summary>
    /// Program class that serves as the entry point for the Tekus Web Application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method that initializes and runs the web application.
        /// </summary>
        /// <param name="args">args.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("Tekus-Security"));

            builder.Services.AddDbContext<DataContext>(options =>
                options.UseInMemoryDatabase("Tekus-App"));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddControllersWithViews()
                .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


            builder.Services.AddScoped<IDomainBase<Service>, ServiceDomain>();
            builder.Services.AddScoped<IRepository<Service>, ServiceRepository>();
            builder.Services.AddScoped<ServiceApplication>();

            builder.Services.AddScoped<IDomainBase<Supplier>, SupplierDomain>();
            builder.Services.AddScoped<IRepository<Supplier>, SupplierRepository>();
            builder.Services.AddScoped<SupplierApplication>();

            builder.Services.AddScoped<CountryApplication>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var securityContext = services.GetRequiredService<ApplicationDbContext>();
                var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

                if (!securityContext.Users.Any())
                {
                    var user = new IdentityUser { UserName = "admin@tekus.co", Email = "admin@tekus.co", EmailConfirmed = true };
                    securityContext.Users.Add(user);
                    securityContext.SaveChanges();

                    userManager.AddPasswordAsync(user, "Admin123!").GetAwaiter().GetResult();
                }

                var dataContext = services.GetRequiredService<DataContext>();
                if (!dataContext.Suppliers.Any())
                {
                    var service01 = new Service() { Name = "Servicio 01", Price = 1000 };
                    var service02 = new Service() { Name = "Servicio 02", Price = 2000 };
                    var service03 = new Service() { Name = "Servicio 03", Price = 3000 };
                    var service04 = new Service() { Name = "Servicio 04", Price = 4000 };
                    var service05 = new Service() { Name = "Servicio 05", Price = 5000 };
                    var service06 = new Service() { Name = "Servicio 06", Price = 6000 };
                    var service07 = new Service() { Name = "Servicio 07", Price = 7000 };
                    var service08 = new Service() { Name = "Servicio 08", Price = 8000 };
                    var service09 = new Service() { Name = "Servicio 09", Price = 9000 };

                    dataContext.Services.Add(service01);
                    dataContext.Services.Add(service02);
                    dataContext.Services.Add(service03);
                    dataContext.Services.Add(service04);
                    dataContext.Services.Add(service05);
                    dataContext.Services.Add(service06);
                    dataContext.Services.Add(service07);
                    dataContext.Services.Add(service08);
                    dataContext.Services.Add(service09);
                    dataContext.SaveChanges();

                    var supplier01 = new Supplier() { Identification = "111111111-1", Name = "Proveedor 01", EmailAddress = "proveedor01@tekus.co" };
                    var supplier02 = new Supplier() { Identification = "222222222-2", Name = "Proveedor 02", EmailAddress = "proveedor02@tekus.co" };
                    var supplier03 = new Supplier() { Identification = "333333333-3", Name = "Proveedor 03", EmailAddress = "proveedor03@tekus.co" };
                    var supplier04 = new Supplier() { Identification = "444444444-4", Name = "Proveedor 04", EmailAddress = "proveedor04@tekus.co" };
                    var supplier05 = new Supplier() { Identification = "555555555-5", Name = "Proveedor 05", EmailAddress = "proveedor05@tekus.co" };
                    var supplier06 = new Supplier() { Identification = "666666666-6", Name = "Proveedor 06", EmailAddress = "proveedor06@tekus.co" };
                    var supplier07 = new Supplier() { Identification = "777777777-7", Name = "Proveedor 07", EmailAddress = "proveedor07@tekus.co" };
                    var supplier08 = new Supplier() { Identification = "888888888-8", Name = "Proveedor 08", EmailAddress = "proveedor08@tekus.co" };
                    var supplier09 = new Supplier() { Identification = "999999999-9", Name = "Proveedor 09", EmailAddress = "proveedor09@tekus.co" };

                    dataContext.Suppliers.Add(supplier01);
                    dataContext.Suppliers.Add(supplier02);
                    dataContext.Suppliers.Add(supplier03);
                    dataContext.Suppliers.Add(supplier04);
                    dataContext.Suppliers.Add(supplier05);
                    dataContext.Suppliers.Add(supplier06);
                    dataContext.Suppliers.Add(supplier07);
                    dataContext.Suppliers.Add(supplier08);
                    dataContext.Suppliers.Add(supplier09);
                    dataContext.SaveChanges();

                    var supplierService01 = new SupplierService() { SupplierID = supplier01.SupplierID, ServiceID = service01.ServiceID, Countries = "CO" };
                    var supplierService02 = new SupplierService() { SupplierID = supplier02.SupplierID, ServiceID = service02.ServiceID, Countries = "CO,US" };
                    var supplierService03 = new SupplierService() { SupplierID = supplier03.SupplierID, ServiceID = service03.ServiceID, Countries = "CO,CA" };
                    var supplierService04 = new SupplierService() { SupplierID = supplier04.SupplierID, ServiceID = service04.ServiceID, Countries = "CO" };
                    var supplierService05 = new SupplierService() { SupplierID = supplier05.SupplierID, ServiceID = service05.ServiceID, Countries = "CO,US" };
                    var supplierService06 = new SupplierService() { SupplierID = supplier06.SupplierID, ServiceID = service06.ServiceID, Countries = "CO,CA" };
                    var supplierService07 = new SupplierService() { SupplierID = supplier07.SupplierID, ServiceID = service07.ServiceID, Countries = "CO" };
                    var supplierService08 = new SupplierService() { SupplierID = supplier08.SupplierID, ServiceID = service08.ServiceID, Countries = "CO,US,CA" };
                    var supplierService09 = new SupplierService() { SupplierID = supplier09.SupplierID, ServiceID = service09.ServiceID, Countries = "CO" };
                    var supplierService10 = new SupplierService() { SupplierID = supplier01.SupplierID, ServiceID = service09.ServiceID, Countries = "US,CA" };

                    dataContext.SupplierServices.Add(supplierService01);
                    dataContext.SupplierServices.Add(supplierService02);
                    dataContext.SupplierServices.Add(supplierService03);
                    dataContext.SupplierServices.Add(supplierService04);
                    dataContext.SupplierServices.Add(supplierService05);
                    dataContext.SupplierServices.Add(supplierService06);
                    dataContext.SupplierServices.Add(supplierService07);
                    dataContext.SupplierServices.Add(supplierService08);
                    dataContext.SupplierServices.Add(supplierService09);
                    dataContext.SupplierServices.Add(supplierService10);
                    dataContext.SaveChanges();
                }
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseExceptionHandler(
                appError =>
                {
                    appError.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            context.Response.ContentType = "application/json";

                            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                            var errors = new List<string>();
                            var error = contextFeature?.Error;

                            while (error != null)
                            {
                                errors.Add(error.Message);
                                RegisterLog(error);
                                error = error.InnerException;
                            }

                            if (!app.Environment.IsDevelopment())
                            {
                                errors.Clear();
                                errors.Add("Servicios no disponibles");
                            }

                        });
                }
            );
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.MapControllers();

            app.Run();
        }

        /// <summary>
        /// The register service handler exception.
        /// </summary>
        /// <param name="error">The error.</param>
        private static void RegisterLog(Exception error)
        {
            Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), @"TEKUSAS"));
            var path = Path.Combine(Path.GetTempPath(), @"TEKUSAS", @"TEKUSASAPI.txt");

            using (var writer = new StreamWriter(File.Open(path, FileMode.Append)))
            {
                writer.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
                writer.WriteLine(DateTime.Now);
                writer.WriteLine($"Fecha: {DateTime.Now}");
                writer.WriteLine($"Mensaje: {error.Message}");
                writer.WriteLine($"Stack: {error.StackTrace}");
                writer.WriteLine($"InnerExecption: {error.InnerException}");
                writer.WriteLine($"Source: {error.Source}");
            }
        }
    }
}
