using System;
using System.Windows;

namespace Lumiria.ViewServices
{
    /// <summary>
    /// Base class for services defined in views.
    /// </summary>
    public abstract class ViewService<T> : ViewService
        where T : class, IViewService
    {
        /// <summary>
        /// Gets the type of service.
        /// </summary>
        public override Type ServiceType => typeof(T);
    }

    /// <summary>
    /// Base class for services defined in views.
    /// </summary>
    public abstract class ViewService : Freezable
    {
        /// <summary>
        /// Gets the type of service.
        /// </summary>
        public abstract Type ServiceType { get; }

        /// <summary>
        /// Gets or sets the key uniquely identifying this service.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Returns the service entity.
        /// </summary>
        /// <returns>A service object.</returns>
        public abstract IViewService GetService();
    }
}
