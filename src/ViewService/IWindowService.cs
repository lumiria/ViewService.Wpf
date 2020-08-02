using System;
using System.Windows;

namespace ViewServices
{
    /// <summary>
    /// An interface that provides a service for displaying window.
    /// </summary>
    public interface IWindowService : IViewService
    {
        /// <summary>
        /// Opens a window and resturns without waiting for the newly opened window to close.
        /// </summary>
        void Show();

        /// <summary>
        /// Opens a window and resturns without waiting for the newly opened window to close.
        /// </summary>
        /// <param name="dataContext">Window data context.</param>
        void Show(object dataContext);

        /// <summary>
        /// Opens a window and resturns only when the newly opened window is closed.
        /// </summary>
        /// <returns>
        /// A <see cref="Nullable{Boolean}" /> that specifies whether the activity was accepted ( true ) or canceled ( false ).
        /// The return value is the value the DialogResult property before a window closes.
        /// </returns>
        bool? ShowDialog();

        /// <summary>
        /// Opens a window and resturns only when the newly opened window is closed.
        /// </summary>
        /// <param name="dataContext">Window data context.</param>
        /// <returns>
        /// A <see cref="Nullable{Boolean}" /> that specifies whether the activity was accepted ( true ) or canceled ( false ).
        /// The return value is the value the DialogResult property before a window closes.
        /// </returns>
        bool? ShowDialog(object dataContext);
    }
}
