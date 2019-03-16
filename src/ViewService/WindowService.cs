using System;
using System.Windows;

namespace Lumiria.ViewServices
{
    /// <summary>
    /// An implementation of <see cref="IWindowService"/> that allows to show a window.
    /// </summary>
    public class WindowService : Freezable
        , IWindowService
    {
        /// <summary>
        /// Gets or sets the key uniquely identifying this service.
        /// </summary>
        public string Key { get; set; }

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

        protected override Freezable CreateInstanceCore() =>
            new WindowService();

        private Window CreateWindow()
        {
            var window = Activator.CreateInstance(WindowType) as Window;
            if (window == null)
            {
                throw new InvalidOperationException($"{WindowType} is not a valid window type.");
            }
            window.Owner = Owner;

            return window;
        }
    }
}
