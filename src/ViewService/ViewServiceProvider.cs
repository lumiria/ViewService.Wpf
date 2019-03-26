using System;
using System.Linq;
using System.Windows;
using System.Windows.Markup;

namespace Lumiria.ViewServices
{
    /// <summary>
    /// Represents a mechanism for retrieving a service object for the view.
    /// </summary>
    [ContentProperty(nameof(Services))]
    public sealed class ViewServiceProvider : Freezable
        , IViewServiceProvider
    {
        /// <summary>
        /// Initializes a new insrtance of the <see cref="ViewServiceProvider"/> class.
        /// </summary>
        public ViewServiceProvider()
        {
            Services = new FreezableCollection<ViewService>();
        }

        /// <summary>
        /// Gets the collection of services.
        /// </summary>
        public FreezableCollection<ViewService> Services
        {
            get => (FreezableCollection<ViewService>)GetValue(ServicesProperty);
            private set => SetValue(ServicesPropertyKey, value);
        }
        private static readonly DependencyPropertyKey ServicesPropertyKey =
            DependencyProperty.RegisterReadOnly("Services", typeof(FreezableCollection<ViewService>), typeof(ViewServiceProvider), new PropertyMetadata(null));
        /// <summary>Services Dependency Property</summary>
        public static readonly DependencyProperty ServicesProperty =
            ServicesPropertyKey.DependencyProperty;

        
        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the service object.</typeparam>
        /// <param name="key">The key that identifies the service object.</param>
        /// <returns>A service object of type T.</returns>
        T IViewServiceProvider.Get<T>(string key)
        {
            var service = Services
                .Where(x => typeof(T).IsAssignableFrom(x.ServiceType))
                .FirstOrDefault(x => x.Key == key);

            if (service == null)
            {
                throw new ArgumentException("The key does not exist in the view services.");
            }

            return service.GetService() as T;
        }

        protected override Freezable CreateInstanceCore() =>
            new ViewServiceProvider();
    }
}
