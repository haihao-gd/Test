using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ZeroStack.DeviceCenter.Application;
using ZeroStack.DeviceCenter.Domain;
using ZeroStack.DeviceCenter.Infrastructure;
using ZeroStack.DeviceCenter.Infrastructure.ConnectionStrings;

[assembly: HostingStartup(typeof(ZeroStack.DeviceCenter.API.Extensions.Hosting.CustomHostingStartup))]
namespace ZeroStack.DeviceCenter.API.Extensions.Hosting
{
    public class CustomHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDomainLayer().AddInfrastructureLayer(context.Configuration).AddApplicationLayer().AddWebApiLayer();

                JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.TryAdd(nameof(ClaimTypes.Name).ToLower(), ClaimTypes.Name);

                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                }).AddJwtBearer(options =>
                {
                    options.Authority = context.Configuration.GetValue<string>("IdentityServer:AuthorizationUrl");
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters.ValidateAudience = false;
                    options.TokenValidationParameters.NameClaimType = ClaimTypes.Name;
                });

                services.Configure<TenantStoreOptions>(context.Configuration);

                services.Configure<Microsoft.AspNetCore.Mvc.MvcOptions>(options =>
                {
                    options.ModelBinderProviders.Add(new ModelBinding.SortingBinderProvider());
                });
            });
        }
    }
}
