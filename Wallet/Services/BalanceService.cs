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
public async Task<bool> UpBalance(SetBalanceViewModel setBalance)
        {
            try
            {
                if (setBalance.Balance <= 0) return false;
                var user = await _repository.GetFirstOrDefaultByUserIdAsync(setBalance.UserId);
                if (user is null) return false;
                user.Balance += setBalance.Balance;
                _repository.Update(user);
                await _repository.SaveAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

      
        
    }
}