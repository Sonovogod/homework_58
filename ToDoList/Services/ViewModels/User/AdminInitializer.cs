using Microsoft.AspNetCore.Identity;
using ToDoList.Models;
using Task = System.Threading.Tasks.Task;

public class AdminInitializer
{
    public static async Task SeedAdminUser(
        RoleManager<IdentityRole> roleManager,
        UserManager<User> userManager)
    {
        string adminName = "SuperAdmin";
        string adminEmail = "admin@admin.com";
        string adminPassword = "1234567A";

        var roles = new string[] { "admin", "user" };
        foreach (var role in roles)
        {
            if (await roleManager.FindByNameAsync(role) is null)
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        if (await userManager.FindByEmailAsync(adminEmail) == null)
        {
            User admin = new User
            {
                Email = adminEmail,
                UserName = adminName
            };

            var result = await userManager.CreateAsync(admin, adminPassword);

            if (result.Succeeded)
                await userManager.AddToRoleAsync(admin, "admin");
        }
    }
}