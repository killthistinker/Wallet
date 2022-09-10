using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Models;
using Wallet.Models.ViewModels;
using Wallet.Repository.Interfaces;
using Wallet.Services.Abstractions;

namespace Wallet.Services
{
    public class FiltrationService: IFiltrationService
    {
        private readonly ITransactionRepository _repository;

        public FiltrationService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Transaction> Filtration(FiltrationViewModel model)
        {
            var transactions = _repository.GetAll();
            var dateFiltration = transactions.Where(t => t.TransactionDate >= model.DateTo && t.TransactionDate <= model.DateTo);
            return dateFiltration;
        }
    }
}