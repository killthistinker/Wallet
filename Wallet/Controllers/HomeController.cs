using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wallet.Models;
using Wallet.Repository.Interfaces;
using Wallet.Services.Abstractions;

namespace Wallet.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _service;
        public HomeController( UserManager<User> userManager, IUserService service)
        {
            _userManager = userManager;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            int.TryParse(_userManager.GetUserId(User), out int userId);
            var model = await _service.GetUser(userId);
            return View(model);
        }
    }
}