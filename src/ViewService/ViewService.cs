#nullable enable

using System;
using Lumiria.ViewServices.View.Xaml;

namespace Lumiria.ViewServices
{
    public static class ViewService
    {
        public static IViewServiceProvider CreateProvider() =>
            new ViewServiceProvider();

        public static void AddService<T>(IViewServiceProvider provider, Func<T> serviceFactory, string? key=null)
            where T : IViewService
        {
            var container = provider as IViewServiceContainer;
            if (container == null) throw new InvalidCastException();

            container.AddService<T>(serviceFactory, key);
        }
    }
}
