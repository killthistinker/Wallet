using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Data;
using Wallet.Models;
using Wallet.Repository.Interfaces;

namespace Wallet.Repository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly WalletContext _db;

        public UserInfoRepository(WalletContext db)
        {
            _db = db;
        }

        public IEnumerable<UserInfo> GetAll() => _db.UserInfos;

        public void Create(UserInfo item) => _db.UserInfos.Add(item);

        public void Update(UserInfo item) => _db.UserInfos.Update(item);

        public void Remove(UserInfo item) => _db.UserInfos.Remove(item);

        public async Task SaveAsync() => await _db.SaveChangesAsync();
    }
}