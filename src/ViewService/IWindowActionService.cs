using System.Windows;

namespace ViewServices
{
    /// <summary>
    /// An interface that provides a service for operating window. 
    /// </summary>
    public interface IWindowActionService : IViewService
    {
        /// <summary>
        /// Manually closes a <see cref="Window"/>.
        /// </summary>
        void Close();

        /// <summary>
        /// Maximizes a <see cref="Window"/>.
        /// </summary>
        void Maximize();

        /// <summary>
        /// Minimizes a <see cref="Window"/>.
        /// </summary>
        void Minimize();

        /// <summary>
        /// Restores a <see cref="Window"/> to default size.
        /// </summary>
        void Normal();
    }
}
