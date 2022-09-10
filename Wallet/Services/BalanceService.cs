using System;
using System.Threading.Tasks;
using Wallet.Enums;
using Wallet.Models;
using Wallet.Models.ViewModels;
using Wallet.Repository.Interfaces;
using Wallet.Services.Abstractions;

namespace Wallet.Services
{
    public class BalanceService : IBalanceService
    {
       private readonly IUserRepository _repository;

        public BalanceService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<decimal> GetBalance(string userName)
        {
            var user = await _repository.GetFirstOrDefaultByNameAsync(userName);
            if (user is null) return -1;
            return user.Balance;
        }

        
    }
}