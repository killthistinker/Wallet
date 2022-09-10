using System.Threading.Tasks;
using Wallet.Models.ViewModels;

namespace Wallet.Services.Abstractions
{
    public interface IUserService
    {
        public Task<UserViewModel> GetUser(int id);
    }
}