using System;
using System.Windows;

namespace ViewServices.View.Xaml
{
    /// <summary>
    /// Represents a view service for displaying a window.
    /// </summary>
    public sealed class WindowService : FreezableViewService<IWindowService>
    {
        private IWindowService _serviceImpl;

        public WindowService()
        {
        }

        /// <summary>
        /// Gets or sets the type of the window that this service is targeting.
        /// </summary>
        public Type WindowType { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Window"/> that owns this <see cref="WindowService"/>.
        /// </summary>
        public Window Owner
        {
            get => (Window)GetValue(OwnerProperty);
            set => SetValue(OwnerProperty, value);
        }
        /// <summary>Owner Dependency Property</summary>
        public static readonly DependencyProperty OwnerProperty =
            DependencyProperty.Register("Owner", typeof(Window), typeof(WindowService), new PropertyMetadata(null));



        public WindowStartupLocation StartupLocation
        {
            get => (WindowStartupLocation)GetValue(StartupLocationProperty);
            set => SetValue(StartupLocationProperty, value);
        }
        public static readonly DependencyProperty StartupLocationProperty =
            DependencyProperty.Register("StartupLocation", typeof(WindowStartupLocation), typeof(WindowService), new PropertyMetadata(WindowStartupLocation.Manual));


        internal override IViewService GetService() =>
            _serviceImpl ??= new WindowServiceImpl(WindowType, Owner, StartupLocation);

        protected override Freezable CreateInstanceCore() =>
            new WindowService();
    }
}
