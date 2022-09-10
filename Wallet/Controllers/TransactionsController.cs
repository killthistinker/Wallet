using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wallet.Models;
using Wallet.Models.ViewModels;
using Wallet.Services.Abstractions;

namespace Wallet.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ITransactionsService _service;

        public TransactionsController(UserManager<User> userManager, ITransactionsService service)
        {
            _service = service;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            int.TryParse(_userManager.GetUserId(User), out int userId);
            TransactionsViewModel transactions = _service.GetUserTransactionById(userId);
            return View(transactions);
        }
    }
}