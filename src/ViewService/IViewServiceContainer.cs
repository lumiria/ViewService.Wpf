#nullable enable

using System;
using System.Collections.Generic;
using System.Text;

namespace ViewServices
{
    public interface IViewServiceContainer : IViewServiceProvider
    {
        void AddService<T>(Func<T> serviceFactory, string? key = null) where T : IViewService;
    }
}
