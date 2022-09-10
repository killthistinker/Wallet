using System.Threading.Tasks;
using Wallet.Models.ViewModels;
using Wallet.Repository.Interfaces;
using Wallet.Services.Abstractions;

namespace Wallet.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserViewModel> GetUser(int id)
        {
            var user = await _repository.GetFirstOrDefaultByIdAsync(id);
            if (user is null) return null;
            
            UserViewModel model = new UserViewModel
            {
                UserBalance = user.Balance,
                UserName = user.UserName
            };

            return model;
        }
    }
}