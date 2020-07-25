#nullable enable

using System;
using System.Windows;

namespace ViewServices.View
{
    /// <summary>
    /// An implementation of <see cref="IWindowService"/> that allows to show a window.
    /// </summary>
    internal sealed class WindowServiceImpl : IWindowService
    {
        private readonly Type _windowType;
        private readonly Window? _owner;

        public WindowServiceImpl(Type windowType, Window? owner)
        {
            _windowType = windowType;
            _owner = owner;
        }

        ///// <summary>
        ///// Gets or sets the key uniquely identifying this service.
        ///// </summary>
        //public string Key { get; set; }

        /// <summary>
        /// Opens a window and resturns without waiting for the newly opened window to close.
        /// </summary>
        void IWindowService.Show()
        {
            var window = CreateWindow();
            window.Show();
        }

        /// <summary>
        /// Opens a window and resturns without waiting for the newly opened window to close.
        /// </summary>
        /// <param name="dataContext">Window data context.</param>
        void IWindowService.Show(object dataContext)
        {
            var window = CreateWindow();
            window.DataContext = dataContext;

            window.Show();
        }

        /// <summary>
        /// Opens a window and resturns only when the newly opened window is closed.
        /// </summary>
        /// <returns>
        /// A <see cref="Nullable{Boolean}" /> that specifies whether the activity was accepted ( true ) or canceled ( false ).
        /// The return value is the value the DialogResult property before a window closes.
        /// </returns>
        bool? IWindowService.ShowDialog()
        {
            var window = CreateWindow();

            return window.ShowDialog();
        }

        /// <summary>
        /// Opens a window and resturns only when the newly opened window is closed.
        /// </summary>
        /// <param name="dataContext">Window data context.</param>
        /// <returns>
        /// A <see cref="Nullable{Boolean}" /> that specifies whether the activity was accepted ( true ) or canceled ( false ).
        /// The return value is the value the DialogResult property before a window closes.
        /// </returns>
        bool? IWindowService.ShowDialog(object dataContext)
        {
            var window = CreateWindow();
            window.DataContext = dataContext;

            return window.ShowDialog();
        }

        private Window CreateWindow()
        {
            if (!(Activator.CreateInstance(_windowType) is Window window))
            {
                throw new InvalidOperationException($"{_windowType} is not a valid window type.");
            }
            window.Owner = _owner;

            return window;
        }
    }
}
