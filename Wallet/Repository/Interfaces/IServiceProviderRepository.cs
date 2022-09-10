using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Models;

namespace Wallet.Repository.Interfaces
{
    public interface IServiceProviderRepository : IRepository<ServiceProvider>
    {
        public Task<ServiceProvider> GetProviderFirsOrDefaultFromIdAsync(int providerId);
    }
}