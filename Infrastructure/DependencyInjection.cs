using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Services;
using Application.Services.Authentication;
using Infrastructure.Authentication;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, Microsoft.Extensions.Configuration.ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
    }
}
