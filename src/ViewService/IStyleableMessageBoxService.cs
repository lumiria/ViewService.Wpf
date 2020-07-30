#nullable enable

using System.Collections.Generic;
using System.Windows;
using ViewServices.View.Components;

namespace ViewServices
{
    public interface IStyleableMessageBoxService : IViewService
    {
        string? Caption { get; set; }

        MessageBoxImage Image { get; set; }

        string? InstructionText { get; set; }

        string? Text { get; set; }

        IEnumerable<StyleableMessageBoxButton> Buttons { get; set; }

        MessageBoxResult Show(string text);

        MessageBoxResult Show(string instructionText, string text);

        MessageBoxResult Show(string instructionText, string text, string caption);

        MessageBoxResult Show(string instructionText, string text, string caption, IEnumerable<StyleableMessageBoxButton> buttons);
    }
}
