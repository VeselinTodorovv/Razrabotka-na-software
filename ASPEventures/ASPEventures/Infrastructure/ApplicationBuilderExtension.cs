using System;
using System.Threading.Tasks;
using ASPEventures.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ASPEventures.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app) {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var serviceProvider = scopedServices.ServiceProvider;

            SeedAdministrator(serviceProvider);

            return app;
        }

        private static void SeedAdministrator(IServiceProvider services) {
            var userManager = services.GetRequiredService<UserManager<EventuresUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () => {
                if (await roleManager.RoleExistsAsync("Administrator")) {
                    return;
                }

                var role = new IdentityRole { Name = "Administrator" };
                await roleManager.CreateAsync(role);

                const string adminPassword = "123!@#qweQWE";
                const string adminUsername = "admin";
                const string adminEmail = "admin@admin.com";
                const string adminFirstName = "Admin";
                const string adminLastName = "Admin";

                var usr = new EventuresUser {
                    UserName = adminUsername,
                    Email = adminEmail,
                    FirstName = adminFirstName,
                    LastName = adminLastName
                };

                await userManager.CreateAsync(usr, adminPassword);

                await userManager.AddToRoleAsync(usr, role.Name);
            })
            .GetAwaiter()
            .GetResult();
        }
    }
}