#nullable enable

using System;

namespace Lumiria.ViewServices.View.Extensions
{
    public static class ViewServiceProviderExtension
    {
        public static void AddService<T>(this IViewServiceProvider self, Func<T> serviceFactory, string? key = null)
            where T : IViewService =>
            ViewService.AddService<T>(self, serviceFactory, key);
    }
}
