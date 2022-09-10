using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wallet.Models;

namespace Wallet.Data
{
    public class WalletContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }
        public WalletContext(DbContextOptions<WalletContext> options) : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ServiceProvider>().HasData(new ServiceProvider
                {
                    Id = 1,
                    Name = "Tele2"
                },
                new ServiceProvider
                {
                    Id = 2,
                    Name = "Beeline"
                });
            builder.Entity<UserInfo>().HasData(new UserInfo
                {
                    Id = 1,
                    Balance = 0,
                    PropsId = 12345,
                    ServiceProviderId = 1
                },
                new UserInfo
                {
                    Id = 2,
                    Balance = 0,
                    PropsId = 54321,
                    ServiceProviderId = 2
                });

        }
    }
}