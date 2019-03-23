using System;
using System.Windows;

namespace Lumiria.ViewServices
{
    public abstract class ViewService<T> : ViewService
        where T : class, IViewService
    {
        public override Type ServiceType => typeof(T);
    }

    public abstract class ViewService : Freezable
    {
        public abstract Type ServiceType { get; }

        /// <summary>
        /// Gets or sets the key uniquely identifying this service.
        /// </summary>
        public string Key { get; set; }

        public abstract IViewService GetServiceImpl();
    }
}
