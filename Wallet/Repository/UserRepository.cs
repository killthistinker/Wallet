using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.Data;
using Wallet.Models;
using Wallet.Repository.Interfaces;

namespace Wallet.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly WalletContext _db;

        public UserRepository(WalletContext db)
        {
            _db = db;
        }

        public IEnumerable<User> GetAll()
        {
            var users = _db.Users;
            return users;
        }

        public async Task<User> GetFirstOrDefaultByIdAsync(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<User> GetFirstOrDefaultByNameAsync(string name)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.UserName == name);
        }

        public async Task<User> GetFirstOrDefaultByUserIdAsync(int id) =>
          await _db.Users.FirstOrDefaultAsync(u => u.AuthorizationId == id);

        public void Create(User item) => _db.Add(item);
        public void Update(User item) => _db.Update(item);
        public void Remove(User item) => _db.Remove(item);
        public async Task SaveAsync() => await _db.SaveChangesAsync();
    }
}