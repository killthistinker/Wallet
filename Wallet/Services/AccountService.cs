using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Wallet.Data;
using Wallet.Helpers;
using Wallet.Models;
using Wallet.Models.ViewModels;
using Wallet.Services.Abstractions;
using StatusCodes = Wallet.Enums.StatusCodes;
using IdentityResult = Wallet.DataObjects.IdentityResult;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Wallet.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly WalletContext _db;
        private readonly Random _random;

        public AccountService(SignInManager<User> signInManager, UserManager<User> userManager, WalletContext db)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _db = db;
            _random = new Random();
        }

        public async Task<IdentityResult> Register(RegistrationViewModel model)
        {
            if (model is null) return new IdentityResult
            {
                StatusCodes = StatusCodes.Error, 
                ErrorMessages = new List<string>{"Внутренняя ошибка"},
            };

            User user = model.MapToUser();
            user.AuthorizationId = await GenerateId();
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "user");
                await _signInManager.SignInAsync(user, false);
                return new IdentityResult {StatusCodes = StatusCodes.Success};
            }

            var errors = result.Errors.Select(error => error.Description).ToList();

            return new IdentityResult
            {
                ErrorMessages = errors,
                StatusCodes = StatusCodes.Error
            };
            
        }

        public async Task<IdentityResult> LogIn(LoginViewModel model)
        {
            int.TryParse(model.Email, out int userId);
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null) user = await _userManager.FindByNameAsync(model.Email);
            if (user is null) user = await _db.Users.FirstOrDefaultAsync(u => u.AuthorizationId == userId);
            if (user is not null)
            {
                SignInResult result = await _signInManager.PasswordSignInAsync(
                    user,
                    model.Password,
                    model.RememberMe,
                    false
                );
                if (result.Succeeded)
                    return new IdentityResult {StatusCodes = StatusCodes.Success};
            }
            return new IdentityResult
            {
                StatusCodes = StatusCodes.Error,
                ErrorMessages = new List<string>{"Неправильный логин и (или) пароль"}
            };
        }

        public async Task LogOf()
            => await _signInManager.SignOutAsync();

        public async Task<int> GenerateId()
        {
            while (true)
            {
                int uniqueId = _random.Next(100000, 999999);
                if (!await _db.Users.AnyAsync(u => u.AuthorizationId == uniqueId)) return uniqueId;
            }
        }
    }
}