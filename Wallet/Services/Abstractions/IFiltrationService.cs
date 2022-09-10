using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Models;
using Wallet.Models.ViewModels;

namespace Wallet.Services.Abstractions
{
    public interface IFiltrationService
    {
        public IEnumerable<Transaction> Filtration(FiltrationViewModel model);
    }
}