#nullable enable

using System.Windows;

namespace Lumiria.ViewServices.View
{
    /// <summary>
    /// An implementation of <see cref="IWindowActionService"/> that allows to operate a window.
    /// </summary>
    internal sealed class WindowActionServiceImpl : IWindowActionService
    {
        private readonly Window _target;

        public WindowActionServiceImpl(Window target)
        {
            _target = target;
        }

        /// <summary>
        /// Manually closes a <see cref="Window"/>.
        /// </summary>
        void IWindowActionService.Close()
        {
            _target.Close();
        }

        /// <summary>
        /// Maximizes a <see cref="Window"/>.
        /// </summary>
        void IWindowActionService.Maximize()
        {
            _target.WindowState = WindowState.Maximized;
        }

        /// <summary>
        /// Minimizes a <see cref="Window"/>.
        /// </summary>
        void IWindowActionService.Minimize()
        {
            _target.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Restores a <see cref="Window"/> to default size.
        /// </summary>
        void IWindowActionService.Normal()
        {
            _target.WindowState = WindowState.Normal;
        }
    }
}
