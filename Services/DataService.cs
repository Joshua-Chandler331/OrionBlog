using System.Threading.Tasks;
using Microsoft.Extensions.Hosting; // NEED TO READ
using Microsoft.Extensions.DependencyInjection; // NEED TO READ 
using OrionBlog.Models;
using Microsoft.AspNetCore.Identity;// NEED TO READ

namespace OrionBlog.Services
{
    public static class DataService
    {
        public static async Task ManageDataAsync(IHost host)
        {
            using var svcScope = host.Services.CreateScope();
            var svcProvider = svcScope.ServiceProvider;

            var roleManagerSvc = svcProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var userManagerSvc = svcProvider.GetRequiredService<UserManager<BlogUser>>();

            await SeedRolesAsync(roleManagerSvc);

            await SeedUsersAsync(userManagerSvc);

            await AssignRolesAsync(userManagerSvc);
        }

            private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleSvc)
            {
                // Write the code to seed a few Roles
                await roleSvc.CreateAsync(new IdentityRole("Administrator"));
                await roleSvc.CreateAsync(new IdentityRole("Moderator"));
            }

            private static async Task SeedUsersAsync(UserManager<BlogUser> userManagerSvc)
            {
                // Step 1: Create yourself as a user
                var adminUser = new BlogUser()
                {
                    Email = "Joshua@CoderFoundry.com",
                    UserName = "Joshua@CoderFoundry.com",
                    FirstName = "Joshua",
                    LastName = "Chandler",
                    PhoneNumber = "(888) 555-1212",
                    EmailConfirmed = true
                };

                await userManagerSvc.CreateAsync(adminUser, "Password11!");
                // Step 2: Create some else async a user

                var modUser = new BlogUser()
                {
                    Email = "Joshua@CoderFoundry.com",
                    UserName= "Joshua@CoderFoundry.com",
                    FirstName = "Joshua",
                    LastName = "Chandler",
                    PhoneNumber = "(777) 555-1212",
                    EmailConfirmed = true
                };

                await userManagerSvc.CreateAsync(modUser, "Password11!");
            }

            private static async Task AssignRolesAsync(UserManager<BlogUser> UserManagerSvc)
            {
                // Write the code to assign seeded users
                var adminUser = await UserManagerSvc.FindByEmailAsync("Joshua@CoderFoundry.com");

                // Step 2: Assign the adminUSer to the Administrator role
                await UserManagerSvc.AddToRoleAsync(adminUser, "Administrator");

                // Step 3: Is Step 1 again
                var modUser = await UserManagerSvc.FindByEmailAsync("Joshua@CoderFoundry.com");

                // Step 4: Is step 2 again
                await UserManagerSvc.AddToRoleAsync(modUser, "Moderator");
            }
        
    }
}

