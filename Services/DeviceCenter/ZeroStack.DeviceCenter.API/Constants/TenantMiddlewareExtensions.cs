using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ZeroStack.DeviceCenter.API.Extensions.Tenants;

namespace ZeroStack.DeviceCenter.API.Constants
{
    public static class TenantMiddlewareExtensions
    {
        public static IServiceCollection AddTenantMiddleware(this IServiceCollection services)
        {
            return services.AddTransient<TenantMiddleware>();
        }

        public static IApplicationBuilder UseTenantMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TenantMiddleware>();
        }
    }
}
