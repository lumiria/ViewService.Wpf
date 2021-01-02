#nullable enable

using System.Collections.Generic;
using System.Windows;
using ViewServices.View.Components;

namespace ViewServices
{
    /// <summary>
    /// Provides a service of the <see cref="Components.StyleableMessageBox"/>
    /// </summary>
    public interface IStyleableMessageBoxService : IViewService
    {
        /// <summary>
        /// Gets or sets a string that specifies the title bar caption to display.
        /// </summary>
        string? Caption { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="MessageBoxImage"/> value that specifies the icon to display.
        /// </summary>
        MessageBoxImage Image { get; set; }

        /// <summary>
        /// Gets or sets a string that specifies the instruction text to display.
        /// </summary>
        string? InstructionText { get; set; }

        /// <summary>
        /// Gets or sets a string that specifies the text to display.
        /// </summary>
        string? Text { get; set; }

        IEnumerable<StyleableMessageBoxButton> Buttons { get; set; }

        /// <summary>
        /// Displays a message box that has a message and that returns a result.
        /// </summary>
        /// <param name="text">A <see cref="string"/> that specifies the text to display.</param>
        /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
        MessageBoxResult Show(string text);

        /// <summary>
        /// Displays a message box that has a message and title bar caption; and that returns a result.
        /// </summary>
        /// <param name="instructionText">A <see cref="string"/> that specifies the instruction text to display.</param>
        /// <param name="text">A <see cref="string"/> that specifies the text to display.</param>
        /// <param name="caption">A <see cref="string"/> that specifies the title bar caption to display.</param>
        /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
        MessageBoxResult Show(string instructionText, string text);

        /// <summary>
        /// Displays a message box that has a message and title bar caption; and that returns a result.
        /// </summary>
        /// <param name="text">A <see cref="string"/> that specifies the text to display.</param>
        /// <param name="caption">A <see cref="string"/> that specifies the title bar caption to display.</param>
        /// <returns>A <see cref="MessageBoxResult"/> value that specifies which message box button is clicked by the user.</returns>
        MessageBoxResult Show(string instructionText, string text, string caption);

        MessageBoxResult Show(string instructionText, string text, string caption, IEnumerable<StyleableMessageBoxButton> buttons);
    }
}
