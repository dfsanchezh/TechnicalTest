using ApiAmarisCore.Core;
using ApiAmarisCore.ICore;
using ApiAmarisRepository.IRepository;
using ApiAmarisRepository.Repository;
using ApiAmarisService.IService;
using ApiAmarisService.Service;
using Microsoft.AspNetCore.Authentication;
using IAuthenticationService = ApiAmarisService.IService.IAuthenticationService;
using AuthenticationService = ApiAmarisService.Service.AuthenticationService;

namespace ApiAmaris.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddSingleton<IConfiguration>(configuration);

            services.AddScoped<IApiRepository, ApiRepository>();
            services.AddScoped<IListEmployeCore, ListEmployeCore>();
            services.AddScoped<IListEmployeService, ListEmployeService>();
            services.AddScoped<IDataEmployeCore, DataEmployeCore>();
            services.AddScoped<IDataEmployeService, DataEmployeService>();
            services.AddScoped<IAuthenticationCore, AuthenticationCore>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
