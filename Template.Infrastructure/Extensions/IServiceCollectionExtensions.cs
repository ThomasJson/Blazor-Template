using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Template.Application.Interfaces.Services;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Template.Infrastructure.Services.Authentication;
using Microsoft.Extensions.Configuration;

namespace Template.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediator();
            services.AddTransient();
            services.AddScoped();
        }

        private static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }

        private static void AddTransient(this IServiceCollection services)
        {
            services
                .AddTransient<IAuthService, AuthService>();
        }

        private static void AddScoped(this IServiceCollection services)
        {
            services
                .AddScoped<ProtectedSessionStorage>()
                .AddScoped<AuthenticationStateProvider, AuthStateProvider>();
        }
    }
}