using System.Windows;

namespace Lumiria.ViewServices
{
    public sealed class MessageBoxService : Freezable
        , IMessageBoxService
    {
        /// <summary>
        /// Gets or sets the key uniquely identifying this service.
        /// </summary>
        public string Key { get; set; }

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

        /// <summary>
        /// Displays a message box that has a message and that returns a result.
        /// </summary>
        /// <param name="messageBoxText">A <see cref="string"/> that specifies the text to display.</param>
        /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
        public MessageBoxResult Show(string messageBoxText) =>
            Owner == null
                ? MessageBox.Show(messageBoxText)
                : MessageBox.Show(Owner, messageBoxText);

        /// <summary>
        /// Displays a message box that has a message and title bar caption; and that returns a result.
        /// </summary>
        /// <param name="messageBoxText">A <see cref="string"/> that specifies the text to display.</param>
        /// <param name="caption">A <see cref="string"/> that specifies the title bar caption to display.</param>
        /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
        public MessageBoxResult Show(string messageBoxText, string caption) =>
            Owner == null
                ? MessageBox.Show(messageBoxText, caption)
                : MessageBox.Show(Owner, messageBoxText, caption);

        /// <summary>
        /// Displays a message box that has a message, title bar caption, and button; and that returns a result.
        /// </summary>
        /// <param name="messageBoxText">A <see cref="string"/> that specifies the text to display.</param>
        /// <param name="caption">A <see cref="string"/> that specifies the title bar caption to display.</param>
        /// <param name="button">A <see cref="MessageBoxResult"/> value that specifies which button or buttons to display.</param>
        /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
        public MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button) =>
            Owner == null
                ? MessageBox.Show(messageBoxText, caption, button)
                : MessageBox.Show(Owner, messageBoxText, caption, button);

        /// <summary>
        /// Displays a message box that has a message, title bar caption, button, and icon;  and that returns a result.
        /// </summary>
        /// <param name="messageBoxText">A <see cref="string"/> that specifies the text to display.</param>
        /// <param name="caption">A <see cref="string"/> that specifies the title bar caption to display.</param>
        /// <param name="button">A <see cref="MessageBoxResult"/> value that specifies which button or buttons to display.</param>
        /// <param name="icon">A <see cref="MessageBoxImage"/> value that specifies the icon to display.</param>
        /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
        public MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon) =>
            Owner == null
                ? MessageBox.Show(messageBoxText, caption, button, icon)
                : MessageBox.Show(Owner, messageBoxText, caption, button, icon);

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
            Owner == null
                ? MessageBox.Show(messageBoxText, caption, button, icon, defaultResult)
                : MessageBox.Show(Owner, messageBoxText, caption, button, icon, defaultResult);

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
            Owner == null
                ? MessageBox.Show(messageBoxText, caption, button, icon, defaultResult, options)
                : MessageBox.Show(Owner, messageBoxText, caption, button, icon, defaultResult, options);

        protected override Freezable CreateInstanceCore() =>
            new MessageBoxService();
    }
}
