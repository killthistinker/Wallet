using System.Collections.Generic;

namespace Wallet.Models.ViewModels
{
    public class PaymentViewModel
    {
        public IEnumerable<ServiceProvider> ServiceProviders { get; set; }
    }
}