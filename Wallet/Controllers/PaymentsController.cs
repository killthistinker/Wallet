using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wallet.Models;
using Wallet.Models.ViewModels;
using Wallet.Services.Abstractions;

namespace Wallet.Controllers
{
    [Authorize]
    public class PaymentsController : Controller
    {
        private readonly IPaymentsService _service;
        private readonly UserManager<User> _userManager;
        
        public PaymentsController(IPaymentsService service, UserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var serviceProviders = _service.GetAll();
            return View(serviceProviders);
        }
        
        [HttpPost]
        public async Task<IActionResult> NewPayment([FromBody]AddPaymentViewModel model)
        {
            int.TryParse(_userManager.GetUserId(User), out int userId);
            int statusCode = await _service.AddPayment(model,userId);
            return Ok(statusCode);
        }
    }
}