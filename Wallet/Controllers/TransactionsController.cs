using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wallet.Models;
using Wallet.Models.ViewModels;
using Wallet.Services.Abstractions;

namespace Wallet.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ITransactionsService _service;
        private readonly IFiltrationService _filtrationService;

        public TransactionsController(UserManager<User> userManager, ITransactionsService service, IFiltrationService filtrationService)
        {
            _service = service;
            _filtrationService = filtrationService;
            _userManager = userManager;
        }

        public IActionResult Index(FiltrationViewModel model = null)
        {    
            int.TryParse(_userManager.GetUserId(User), out int userId);
            TransactionsViewModel transactions = _service.GetUserTransactionById(userId);
            if (!model.DateTo.ToString().Contains("01.01.0001 0:00:00"))
            {
                var filtratedModel = _filtrationService.Filtration(model);
                transactions.Transactions = filtratedModel;
                return View(transactions);
            }
            
            return View(transactions);
        }
    }
}