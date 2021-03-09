using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ZeroStack.DeviceCenter.API.Constants;
using ZeroStack.DeviceCenter.Domain.Repositories;

namespace ZeroStack.DeviceCenter.API.Extensions.Hosting
{
    public class CustomStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                string[] supportedCultures = new[] { "zh-CN", "en-US" };
                RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions
                {
                    ApplyCurrentCultureToResponseHeaders = false
                };
                localizationOptions.SetDefaultCulture(supportedCultures.First()).AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures);
                app.UseRequestLocalization(localizationOptions);

                app.UseTenantMiddleware();

                IStringLocalizerFactory? localizerFactory = app.ApplicationServices.GetService<IStringLocalizerFactory>();

                FluentValidation.ValidatorOptions.Global.DisplayNameResolver = (type, memberInfo, lambdaExpression) =>
                {
                    string? displayName = string.Empty;

                    DisplayAttribute? displayColumnAttribute = memberInfo.GetCustomAttributes(true).OfType<DisplayAttribute>().FirstOrDefault();

                    if (displayColumnAttribute is not null)
                    {
                        displayName = displayColumnAttribute.Name;
                    }

                    DisplayNameAttribute? displayNameAttribute = memberInfo.GetCustomAttributes(true).OfType<DisplayNameAttribute>().FirstOrDefault();

                    if (displayNameAttribute is not null)
                    {
                        displayName = displayNameAttribute.DisplayName;
                    }

                    if (!string.IsNullOrWhiteSpace(displayName) && localizerFactory is not null)
                    {
                        return localizerFactory.Create(type)[displayName];
                    }

                    if (!string.IsNullOrWhiteSpace(displayName))
                    {
                        return displayName;
                    }

                    return memberInfo.Name;
                };

                using IServiceScope serviceScope = app.ApplicationServices.CreateScope();

                var dataSeedProviders = serviceScope.ServiceProvider.GetServices<IDataSeedProvider>();

                foreach (IDataSeedProvider dataSeedProvider in dataSeedProviders)
                {
                    dataSeedProvider.SeedAsync(serviceScope.ServiceProvider).Wait();
                }

                next(app);
            };
        }
    }
}
