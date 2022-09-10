using Wallet.Models;
using Wallet.Models.ViewModels;

namespace Wallet.Helpers
{
    public static class UserRegistrationMapper
    {
        public static User MapToUser(this RegistrationViewModel self)
        {
            User user = new User()
            {
                Email = self.Email,
                UserName = self.UserName,
                Balance = 10000
            };
            return user;
        }
    }
}