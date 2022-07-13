using Microsoft.AspNetCore.Identity;
using TestApplicationInforce.Data;

namespace TestApplicationInforce.Areas.Identity.Data
{
    public class AdminAccount
    {
        public async static Task SetupAdminAccounts(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<TestApplicationInforceContext>();

                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<TestApplicationInforceUser>>();

                if (!roleManager.RoleExistsAsync("Admin").Result)
                {
                    roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
                }

                if (userManager.FindByEmailAsync("admin@admin.com").Result == null)
                {
                    var adminUser = new TestApplicationInforceUser();
                    adminUser.UserName = "admin@admin.com";
                    adminUser.Email = "admin@admin.com";

                    string adminPassword = "123456";

                    IdentityResult result = userManager.CreateAsync(adminUser, adminPassword).Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(adminUser, "Admin").Wait();
                    }
                }
            }
        }
    }
}
