#nullable enable

using System;
using System.Linq;
using System.Windows;
using System.Windows.Markup;

namespace Lumiria.ViewServices.View.Xaml
{
    /// <summary>
    /// Represents a mechanism for retrieving a service object for the view.
    /// </summary>
    [ContentProperty(nameof(Services))]
    public sealed class ViewServiceProvider : Freezable
        , IViewServiceContainer
    {
        /// <summary>
        /// Initializes a new insrtance of the <see cref="ViewServiceProvider"/> class.
        /// </summary>
        public ViewServiceProvider()
        {
            Services = new FreezableCollection<FreezableViewService>();
        }

        public ViewServiceProvider(Window owner)
        {
            Owner = owner;
        }

        /// <summary>
        /// Gets or sets the <see cref="Window"/> that owns this.
        /// </summary>
        public Window? Owner
        {
            get => (Window?)GetValue(OwnerProperty);
            set => SetValue(OwnerProperty, value);
        }
        /// <summary>Owner Dependency Property</summary>
        public static readonly DependencyProperty OwnerProperty =
            DependencyProperty.Register("Owner", typeof(Window), typeof(ViewServiceProvider), new PropertyMetadata(null));


        /// <summary>
        /// Gets the collection of services.
        /// </summary>
        public FreezableCollection<FreezableViewService> Services
        {
            get => (FreezableCollection<FreezableViewService>)GetValue(ServicesProperty);
            private set => SetValue(ServicesPropertyKey, value);
        }
        private static readonly DependencyPropertyKey ServicesPropertyKey =
            DependencyProperty.RegisterReadOnly("Services", typeof(FreezableCollection<FreezableViewService>), typeof(ViewServiceProvider), new PropertyMetadata(null));
        /// <summary>Services Dependency Property</summary>
        public static readonly DependencyProperty ServicesProperty =
            ServicesPropertyKey.DependencyProperty;

        
        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the service object.</typeparam>
        /// <param name="key">The key that identifies the service object.</param>
        /// <returns>A service object of type T.</returns>
        T IViewServiceProvider.Get<T>(string? key)
        {
            var service = Services
                .Where(x => typeof(T).IsAssignableFrom(x.ServiceType))
                .FirstOrDefault(x => x.Key == key);

            if (service == null)
            {
                throw new ArgumentException("The key does not exist in the view services.");
            }

            return (T)service.GetService();
        }

        void IViewServiceContainer.AddService<T>(Func<T> serviceFactory, string? key)
        {
            Services.Add(new AnonymousViewService<T>(serviceFactory, key));
        }

        protected override Freezable CreateInstanceCore() =>
            new ViewServiceProvider();

    }
}
