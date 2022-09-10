using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Wallet.Data;

namespace Wallet.Controllers
{
    public class AccountValidationController : Controller
    {
        private readonly WalletContext _context;

        public AccountValidationController(WalletContext context)
        {
            _context = context;
        }

        public bool CheckAccountEmail(string email)
        {
            bool validation = !_context.Users.AsEnumerable().Any(p => p.Email.Equals(email));
            return validation;
        }

        public bool CheckAccountName(string userName)
        {
            bool validation = !_context.Users.AsEnumerable().Any(p => p.UserName.Equals(userName));
            return validation;
        }
    }
}