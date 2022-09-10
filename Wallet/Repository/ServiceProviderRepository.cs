using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.Data;
using Wallet.Models;
using Wallet.Repository.Interfaces;

namespace Wallet.Repository
{
    public class ServiceProviderRepository : IServiceProviderRepository
    {
        private readonly WalletContext _db;

        public ServiceProviderRepository(WalletContext db)
        {
            _db = db;
        }

        public IEnumerable<ServiceProvider> GetAll() => _db.ServiceProviders;

        public void Create(ServiceProvider item) => _db.ServiceProviders.Add(item);

        public void Update(ServiceProvider item) => _db.ServiceProviders.Update(item);

        public void Remove(ServiceProvider item) => _db.ServiceProviders.Remove(item);

        public async Task SaveAsync() => await _db.SaveChangesAsync();

        public async Task<ServiceProvider> GetProviderFirsOrDefaultFromIdAsync(int providerId) =>
         await _db.ServiceProviders.Include(p => p.UsersInfos).FirstOrDefaultAsync(p => p.Id == providerId);
    }
}