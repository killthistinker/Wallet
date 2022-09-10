using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using StatusCodes = Wallet.Enums.StatusCodes;

namespace Wallet.DataObjects
{
    public class IdentityResult
    {
        public List<string> ErrorMessages { get; set; }
        public StatusCodes StatusCodes { get; set; }
    }
}