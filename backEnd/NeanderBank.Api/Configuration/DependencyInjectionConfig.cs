using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NeanderBank.Business.Interfaces.Repositories;
using NeanderBank.Business.Interfaces.Services;
using NeanderBank.Business.Services;
using NeanderBank.Data.Repositories;

namespace NeanderBank.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ITransactionRepository, TransactionRepository>();
            
            services.AddScoped<IResponseService, ResponseService>();
            services.AddScoped<ITransactionService, TransactionService>();
            

            return services;
        }
    }
}