using System.Threading.Tasks;
using Wallet.Models;

namespace Wallet.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    { 
        public Task<User> GetFirstOrDefaultByIdAsync(int id);
        public Task<User> GetFirstOrDefaultByNameAsync(string name);
        public Task<User> GetFirstOrDefaultByUserIdAsync(int id);
    }
}