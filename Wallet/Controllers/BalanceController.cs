using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wallet.Models;
using Wallet.Models.ViewModels;
using Wallet.Services.Abstractions;

namespace Wallet.Controllers
{
    public class BalanceController : Controller
    {
        private readonly IBalanceService _balanceService;
        private readonly UserManager<User> _userManager;

        public BalanceController(IBalanceService balanceService, UserManager<User> userManager)
        {
            _balanceService = balanceService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<JsonResult> GetBalance(string userName)
        {
            decimal userBalance = await _balanceService.GetBalance(userName);
            return Json(userBalance);
        }

       
    }
}