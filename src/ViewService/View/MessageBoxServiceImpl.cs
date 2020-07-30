#nullable enable

using System.Windows;

namespace ViewServices.View
{
    /// <summary>
    /// An implementation of <see cref="IWindowService"/> that allows to show a message box.
    /// </summary>
    internal sealed class MessageBoxServiceImpl : IMessageBoxService
    {
        private readonly Window? _owner;

        public MessageBoxServiceImpl(Window? owner = null)
        {
            _owner = owner;
        }

        public string Caption { get; set; }
            = "";

        public MessageBoxImage Image { get; set; }
            = MessageBoxImage.None;

        public string Text { get; set; }
            = "";

        /// <summary>
        /// Displays a message box that has a message and that returns a result.
        /// </summary>
        /// <param name="messageBoxText">A <see cref="string"/> that specifies the text to display.</param>
        /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
        public MessageBoxResult Show(string messageBoxText) =>
            _owner == null
                ? MessageBox.Show(messageBoxText, Caption, MessageBoxButton.OK, Image)
                : MessageBox.Show(_owner, messageBoxText, Caption, MessageBoxButton.OK, Image);

        /// <summary>
        /// Displays a message box that has a message and title bar caption; and that returns a result.
        /// </summary>
        /// <param name="messageBoxText">A <see cref="string"/> that specifies the text to display.</param>
        /// <param name="caption">A <see cref="string"/> that specifies the title bar caption to display.</param>
        /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
        public MessageBoxResult Show(string messageBoxText, string caption) =>
            _owner == null
                ? MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, Image)
                : MessageBox.Show(_owner, messageBoxText, caption, MessageBoxButton.OK, Image);

        /// <summary>
        /// Displays a message box that has a message, title bar caption, and button; and that returns a result.
        /// </summary>
        /// <param name="messageBoxText">A <see cref="string"/> that specifies the text to display.</param>
        /// <param name="caption">A <see cref="string"/> that specifies the title bar caption to display.</param>
        /// <param name="button">A <see cref="MessageBoxResult"/> value that specifies which button or buttons to display.</param>
        /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
        public MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button) =>
            _owner == null
                ? MessageBox.Show(messageBoxText, caption, button, Image)
                : MessageBox.Show(_owner, messageBoxText, caption, button, Image);

        /// <summary>
        /// Displays a message box that has a message, title bar caption, button, and icon;  and that returns a result.
        /// </summary>
        /// <param name="messageBoxText">A <see cref="string"/> that specifies the text to display.</param>
        /// <param name="caption">A <see cref="string"/> that specifies the title bar caption to display.</param>
        /// <param name="button">A <see cref="MessageBoxResult"/> value that specifies which button or buttons to display.</param>
        /// <param name="icon">A <see cref="MessageBoxImage"/> value that specifies the icon to display.</param>
        /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
        public MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon) =>
            _owner == null
                ? MessageBox.Show(messageBoxText, caption, button, icon)
                : MessageBox.Show(_owner, messageBoxText, caption, button, icon);

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
            _owner == null
                ? MessageBox.Show(messageBoxText, caption, button, icon, defaultResult)
                : MessageBox.Show(_owner, messageBoxText, caption, button, icon, defaultResult);

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
            _owner == null
                ? MessageBox.Show(messageBoxText, caption, button, icon, defaultResult, options)
                : MessageBox.Show(_owner, messageBoxText, caption, button, icon, defaultResult, options);
    }
}
