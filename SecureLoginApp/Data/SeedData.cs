using Microsoft.AspNetCore.Identity;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

        string[] roles = { "Admin", "User" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        var admin = new IdentityUser { UserName = "admin", Email = "srivallip004@gmail.com", EmailConfirmed = true };
        var user = new IdentityUser { UserName = "user1", Email = "user1@example.com", EmailConfirmed = true };

        if (await userManager.FindByNameAsync("admin") == null)
        {
            await userManager.CreateAsync(admin, "Srivalli@01");
            await userManager.AddToRoleAsync(admin, "Admin");
        }

        if (await userManager.FindByNameAsync("user1") == null)
        {
            await userManager.CreateAsync(user, "User@123");
            await userManager.AddToRoleAsync(user, "User");
        }
    }
}
