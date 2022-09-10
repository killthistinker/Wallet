using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wallet.Models;

namespace Wallet.Data
{
    public class WalletContext : IdentityDbContext<User, Role, int>
    {
      
        public WalletContext(DbContextOptions<WalletContext> options) : base(options)
        {
            
        }
    }
}