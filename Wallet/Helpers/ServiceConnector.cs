using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wallet.Repository;
using Wallet.Repository.Interfaces;
using Wallet.Services;
using Wallet.Services.Abstractions;

namespace Wallet.Helpers
{
    public static class ServiceConnector
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IServiceProviderRepository, ServiceProviderRepository>();
            services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            services.AddTransient<ITransactionsService, TransactionsService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBalanceService, BalanceService>();
            services.AddTransient<IPaymentsService, PaymentsService>();
            services.AddTransient<IFiltrationService, FiltrationService>();
            return services;
        }
    }
}