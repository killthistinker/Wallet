using System.Threading.Tasks;
using Wallet.Models.ViewModels;
using IdentityResult = Wallet.DataObjects.IdentityResult;

namespace Wallet.Services.Abstractions
{
    public interface IAccountService
    {
        public Task<IdentityResult> Register(RegistrationViewModel model);
        public Task<IdentityResult> LogIn(LoginViewModel model);
        public Task LogOf();
        public Task<int> GenerateId();
    }
}