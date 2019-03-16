using System.Windows;

namespace Lumiria.ViewServices
{
    /// <summary>
    /// An implementation of <see cref="IWindowActionService"/> that allows to operate a window.
    /// </summary>
    public sealed class WindowActionService : Freezable
        , IWindowActionService
    {
        /// <summary>
        /// Gets or sets the key uniquely identifying this service.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the target window.
        /// </summary>
        public Window Target
        {
            get { return (Window)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }
        /// <summary>Target Dependency Property</summary>
        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("Target", typeof(Window), typeof(WindowActionService), new PropertyMetadata(null));

        /// <summary>
        /// Manually closes a <see cref="Window"/>.
        /// </summary>
        void IWindowActionService.Close()
        {
            Target?.Close();
        }

        /// <summary>
        /// Maximizes a <see cref="Window"/>.
        /// </summary>
        void IWindowActionService.Maximize()
        {
            if (Target == null) return;

            Target.WindowState = WindowState.Maximized;
        }

        /// <summary>
        /// Minimizes a <see cref="Window"/>.
        /// </summary>
        void IWindowActionService.Minimize()
        {
            if (Target == null) return;

            Target.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Restores a <see cref="Window"/> to default size.
        /// </summary>
        void IWindowActionService.Normal()
        {
            if (Target == null) return;

            Target.WindowState = WindowState.Normal;
        }

        protected override Freezable CreateInstanceCore() =>
            new WindowActionService();
    }
}
