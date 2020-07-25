using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using ViewServices.View.Components;

namespace ViewServices
{
    public interface IStyleableMessageBoxService : IViewService
    {
        MessageBoxResult Show(string text);

        MessageBoxResult Show(string instructionText, string text);

        MessageBoxResult Show(string instructionText, string text, string caption);

        MessageBoxResult Show(string instructionText, string text, string caption, IEnumerable<StyleableMessageBoxButton> buttons);
    }
}
