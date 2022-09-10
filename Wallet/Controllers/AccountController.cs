using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wallet.Helpers;
using Wallet.Models.ViewModels;
using Wallet.Services.Abstractions;
using StatusCodes = Wallet.Enums.StatusCodes;


namespace Wallet.Controllers
{
     public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
       

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _accountService.Register(model);
            if (result.StatusCodes == StatusCodes.Success)
                return RedirectToAction("Index", "Home");
            
            if(result.ErrorMessages.Any())
                ModelState.AddErrors(result.ErrorMessages);

            return View(model);
        }
        
        [HttpGet]
        public IActionResult LogIn(string returnUrl = null)
        {
            return View(new LoginViewModel {ReturnUrl = returnUrl});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _accountService.LogIn(model);
            if (result.StatusCodes == StatusCodes.Success)
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    return Redirect(model.ReturnUrl);
                return RedirectToAction("Index", "Home");
            }
            
            if (result.ErrorMessages.Any())
                ModelState.AddErrors(result.ErrorMessages);
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _accountService.LogOf();
            return RedirectToAction("Index", "Home");
        }
    }
}