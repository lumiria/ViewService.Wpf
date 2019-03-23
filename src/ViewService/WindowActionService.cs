using System.Windows;

namespace Lumiria.ViewServices
{
    /// <summary>
    /// Represents a view service for operating a window.
    /// </summary>
    public sealed class WindowActionService : ViewService<IWindowActionService>
    {
        private IWindowActionService _serviceImpl;

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

        public override IViewService GetServiceImpl() =>
            _serviceImpl ?? (_serviceImpl = new WindowActionServiceImpl(this));

        protected override Freezable CreateInstanceCore() =>
            new WindowActionService();


        /// <summary>
        /// An implementation of <see cref="IWindowActionService"/> that allows to operate a window.
        /// </summary>
        private sealed class WindowActionServiceImpl : IWindowActionService
        {
            private readonly WindowActionService _parent;

            public WindowActionServiceImpl(WindowActionService parent)
            {
                _parent = parent;
            }

            /// <summary>
            /// Manually closes a <see cref="Window"/>.
            /// </summary>
            void IWindowActionService.Close()
            {
                _parent.Target?.Close();
            }

            /// <summary>
            /// Maximizes a <see cref="Window"/>.
            /// </summary>
            void IWindowActionService.Maximize()
            {
                if (_parent.Target == null) return;

                _parent.Target.WindowState = WindowState.Maximized;
            }

            /// <summary>
            /// Minimizes a <see cref="Window"/>.
            /// </summary>
            void IWindowActionService.Minimize()
            {
                if (_parent.Target == null) return;

                _parent.Target.WindowState = WindowState.Minimized;
            }

            /// <summary>
            /// Restores a <see cref="Window"/> to default size.
            /// </summary>
            void IWindowActionService.Normal()
            {
                if (_parent.Target == null) return;

                _parent.Target.WindowState = WindowState.Normal;
            }
        }
    }
}
