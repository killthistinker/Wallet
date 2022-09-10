using System.Collections.Generic;

namespace Wallet.Models
{
    public class ServiceProvider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public List<UserInfo> UsersInfos { get; set; }

        public ServiceProvider()
        {
            UsersInfos = new List<UserInfo>();
        }
    }
}