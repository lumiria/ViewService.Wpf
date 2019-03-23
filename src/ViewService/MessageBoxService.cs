using System.Windows;

namespace Lumiria.ViewServices
{
    /// <summary>
    /// Represents a view service for displaying a message box.
    /// </summary>
    public sealed class MessageBoxService : ViewService<IMessageBoxService>
    {
        private IMessageBoxService _serviceImpl;

        /// <summary>
        /// Gets or sets the <see cref="Window"/> that owns <see cref="MessageBox"/>.
        /// </summary>
        public Window Owner
        {
            get => (Window)GetValue(OwnerProperty);
            set => SetValue(OwnerProperty, value);
        }
        /// <summary>Owner Dependency Property</summary>
        public static readonly DependencyProperty OwnerProperty =
            DependencyProperty.Register("Owner", typeof(Window), typeof(MessageBoxService), new PropertyMetadata(null));

        public override IViewService GetServiceImpl() =>
            _serviceImpl ?? (_serviceImpl = new MessageBoxServiceImpl(this));

        protected override Freezable CreateInstanceCore() =>
            new MessageBoxService();


        /// <summary>
        /// An implementation of <see cref="IWindowService"/> that allows to show a message box.
        /// </summary>
        private sealed class MessageBoxServiceImpl : IMessageBoxService
        {
            private readonly MessageBoxService _parent;

            public MessageBoxServiceImpl(MessageBoxService parent)
            {
                _parent = parent;
            }

            /// <summary>
            /// Displays a message box that has a message and that returns a result.
            /// </summary>
            /// <param name="messageBoxText">A <see cref="string"/> that specifies the text to display.</param>
            /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
            public MessageBoxResult Show(string messageBoxText) =>
                _parent.Owner == null
                    ? MessageBox.Show(messageBoxText)
                    : MessageBox.Show(_parent.Owner, messageBoxText);

            /// <summary>
            /// Displays a message box that has a message and title bar caption; and that returns a result.
            /// </summary>
            /// <param name="messageBoxText">A <see cref="string"/> that specifies the text to display.</param>
            /// <param name="caption">A <see cref="string"/> that specifies the title bar caption to display.</param>
            /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
            public MessageBoxResult Show(string messageBoxText, string caption) =>
                _parent.Owner == null
                    ? MessageBox.Show(messageBoxText, caption)
                    : MessageBox.Show(_parent.Owner, messageBoxText, caption);

            /// <summary>
            /// Displays a message box that has a message, title bar caption, and button; and that returns a result.
            /// </summary>
            /// <param name="messageBoxText">A <see cref="string"/> that specifies the text to display.</param>
            /// <param name="caption">A <see cref="string"/> that specifies the title bar caption to display.</param>
            /// <param name="button">A <see cref="MessageBoxResult"/> value that specifies which button or buttons to display.</param>
            /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
            public MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button) =>
                _parent.Owner == null
                    ? MessageBox.Show(messageBoxText, caption, button)
                    : MessageBox.Show(_parent.Owner, messageBoxText, caption, button);

            /// <summary>
            /// Displays a message box that has a message, title bar caption, button, and icon;  and that returns a result.
            /// </summary>
            /// <param name="messageBoxText">A <see cref="string"/> that specifies the text to display.</param>
            /// <param name="caption">A <see cref="string"/> that specifies the title bar caption to display.</param>
            /// <param name="button">A <see cref="MessageBoxResult"/> value that specifies which button or buttons to display.</param>
            /// <param name="icon">A <see cref="MessageBoxImage"/> value that specifies the icon to display.</param>
            /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
            public MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon) =>
                _parent.Owner == null
                    ? MessageBox.Show(messageBoxText, caption, button, icon)
                    : MessageBox.Show(_parent.Owner, messageBoxText, caption, button, icon);

            /// <summary>
            /// Displays a message box that has a message, title bar caption, button, and icon; and that accepts a default message box result and returns a result.
            /// </summary>
            /// <param name="messageBoxText">A <see cref="string"/> that specifies the text to display.</param>
            /// <param name="caption">A <see cref="string"/> that specifies the title bar caption to display.</param>
            /// <param name="button">A <see cref="MessageBoxResult"/> value that specifies which button or buttons to display.</param>
            /// <param name="icon">A <see cref="MessageBoxImage"/> value that specifies the icon to display.</param>
            /// <param name="defaultResult">A <see cref="MessageBoxResult"/> value that specifies the default result of the message box.</param>
            /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
            public MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult) =>
                _parent.Owner == null
                    ? MessageBox.Show(messageBoxText, caption, button, icon, defaultResult)
                    : MessageBox.Show(_parent.Owner, messageBoxText, caption, button, icon, defaultResult);

            /// <summary>
            /// Displays a message box that has a message, title bar caption, button, and icon; and that accepts a default message box result, complies with the specified options, and returns a result.
            /// </summary>
            /// <param name="messageBoxText">A <see cref="string"/> that specifies the text to display.</param>
            /// <param name="caption">A <see cref="string"/> that specifies the title bar caption to display.</param>
            /// <param name="button">A <see cref="MessageBoxResult"/> value that specifies which button or buttons to display.</param>
            /// <param name="icon">A <see cref="MessageBoxImage"/> value that specifies the icon to display.</param>
            /// <param name="defaultResult">A <see cref="MessageBoxResult"/> value that specifies the default result of the message box.</param>
            /// <param name="options">A <see cref="MessageBoxOptions"/> value object that specifies the options.</param>
            /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
            public MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, MessageBoxOptions options) =>
                _parent.Owner == null
                    ? MessageBox.Show(messageBoxText, caption, button, icon, defaultResult, options)
                    : MessageBox.Show(_parent.Owner, messageBoxText, caption, button, icon, defaultResult, options);
        }
    }
}
