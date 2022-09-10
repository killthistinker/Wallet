using Microsoft.Extensions.DependencyInjection;

namespace Wallet.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public int PropsId { get; set; }
        public decimal Balance { get; set; }
        public int ServiceProviderId { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
    }
}