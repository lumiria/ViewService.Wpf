#nullable enable

using System;
using System.Windows;

namespace ViewServices.View.Xaml
{
    /// <summary>
    /// Represents a view service for operating a window.
    /// </summary>
    public sealed class WindowActionService : FreezableViewService<IWindowActionService>
    {
        private IWindowActionService? _serviceImpl;

        public WindowActionService()
        {
        }

        /// <summary>
        /// Gets or sets the target window.
        /// </summary>
        public Window Target
        {
            get => (Window)GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }
        /// <summary>Target Dependency Property</summary>
        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("Target", typeof(Window), typeof(WindowActionService), new PropertyMetadata(null));

        internal override IViewService GetService() =>
            _serviceImpl ??= (Target != null ? new WindowActionServiceImpl(Target)
                : throw new NullReferenceException($"{nameof(Target)} property is null."));

        protected override Freezable CreateInstanceCore() =>
            new WindowActionService();
    }
}
