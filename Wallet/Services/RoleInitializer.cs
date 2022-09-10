using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Wallet.Models;

namespace Wallet.Services
{
    public class RoleInitializer
    {
        public static async Task SeedARoleUser(RoleManager<Role> roleManager)
        {
            var roles = new[] { "user", "admin" };

            foreach (var role in roles)     
            {
                if (await roleManager.FindByNameAsync(role) is null)
                {
                    await roleManager.CreateAsync(new Role{Name = role});
                }
            }
        }
    }
}