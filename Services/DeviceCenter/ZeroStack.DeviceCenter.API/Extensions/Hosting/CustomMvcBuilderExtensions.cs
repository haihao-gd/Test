using FluentValidation.AspNetCore;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CustomMvcBuilderExtensions
    {
        public static IMvcBuilder AddCustomExtensions(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())).AddDataAnnotationsLocalization();

            return builder;
        }
    }
}
