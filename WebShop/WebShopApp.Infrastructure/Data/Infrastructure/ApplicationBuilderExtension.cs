using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using WebShop.Infrastructure.Data;

using WebShopApp.Infrastructure.Data.Domain;

namespace WebShopApp.Infrastructure.Data.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var services = serviceScope.ServiceProvider;

            await RoleSeeder(services);
            await SeedAdministrator(services);

            var dataCategory = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedCategories(dataCategory);

            var dataBrand = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedCategories(dataBrand);

            return app;
        }
        
        private static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roles = { "Administrator", "Client" };

            IdentityResult identityResult;

            foreach (var role in roles)
            {
                var roleExists = await roleManager.RoleExistsAsync(role);
                if (!roleExists) 
                {
                    identityResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        private static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (await userManager.FindByNameAsync("admin") == null)
            {
                ApplicationUser user = new()
                {
                    FirstName = "admin",
                    LastName = "admin",
                    UserName = "admin",
                    Email = "admin@admin.com",
                    Address = "admin address",
                    PhoneNumber = "08888888"
                };

                var result = await userManager.CreateAsync(user, "@Admin123");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }

        private static void SeedCategories(ApplicationDbContext dataCategory)
        {
            if (dataCategory.Categories.Any())
            {
                return;
            }

            dataCategory.Categories.AddRange(new[]
            {
                new Category {CategoryName = "Laptop"},
                new Category {CategoryName = "Computer"},
                new Category {CategoryName = "Monitor"},
                new Category {CategoryName = "Accessory"},
                new Category {CategoryName = "TV"},
                new Category {CategoryName = "Mobile Phone"},
                new Category {CategoryName = "Smart Watch"}
            });

            dataCategory.SaveChanges();
        }

        private static void SeedBrands(ApplicationDbContext dataBrand)
        {
            if (dataBrand.Brands.Any())
            {
                return;
            }

            dataBrand.Brands.AddRange(new[]
            {
                new Brand {BrandName = "Laptop"},
                new Brand {BrandName = "Computer"},
                new Brand {BrandName = "Monitor"},
                new Brand {BrandName = "Accessory"},
                new Brand {BrandName = "TV"},
                new Brand {BrandName = "Mobile Phone"},
                new Brand {BrandName = "Smart Watch"}
            });

            dataBrand.SaveChanges();
        }
    }
}
