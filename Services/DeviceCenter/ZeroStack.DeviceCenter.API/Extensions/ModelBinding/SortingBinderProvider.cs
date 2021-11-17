using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using ZeroStack.DeviceCenter.Application.Services.Generics;

namespace ZeroStack.DeviceCenter.API.Extensions.ModelBinding
{
    public class SortingBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            context = context ?? throw new ArgumentNullException(nameof(context));

            if (context.Metadata.ModelType == typeof(IEnumerable<SortingDescriptor>))
            {
                return new SortingModelBinder();
            }

            return null;
        }
    }
}
