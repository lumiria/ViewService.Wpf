#nullable enable

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ViewServices.View.Components;

namespace ViewServices.View
{
    public sealed class StyleableMessageBoxServiceImpl : IStyleableMessageBoxService
    {
        private readonly Window? _owner;
        private readonly WindowStartupLocation _startupLocation;
        private readonly Style? _windowStyle;
        private readonly Style? _instructionTextStyle;
        private readonly ControlTemplate? _textTemplate;
        private readonly Style? _textStyle;
        private readonly ControlTemplate? _buttonTemplate;
        private readonly Style? _buttonStyle;

        public StyleableMessageBoxServiceImpl(Window? owner,
            WindowStartupLocation startupLocation = WindowStartupLocation.CenterScreen,
            Style? windowStyle = null,
            Style? instructionTextStyle = null,
            ControlTemplate? textTemplate = null,
            Style? textStyle = null,
            ControlTemplate? buttonTemplate = null,
            Style? buttonStyle = null
            )
        {
            _owner = owner;
            _startupLocation = startupLocation;
            _windowStyle = windowStyle;
            _instructionTextStyle = instructionTextStyle;
            _textTemplate = textTemplate;
            _textStyle = textStyle;
            _buttonTemplate = buttonTemplate;
            _buttonStyle = buttonStyle;
        }

        public MessageBoxResult Show(string text)
        {
            var dialog = new StyleableMessageBox
            {
                Text = text
            };
            Initialize(dialog);
            return dialog.Show();
        }

        public MessageBoxResult Show(string instructionText, string text)
        {
            var dialog = new StyleableMessageBox
            {
                InstructionText = instructionText,
                Text = text
            };
            Initialize(dialog);
            return dialog.Show();
        }

        public MessageBoxResult Show(string instructionText, string text, string caption)
        {
            var dialog = new StyleableMessageBox
            {
                InstructionText = instructionText,
                Text = text,
                Caption = caption
            };
            Initialize(dialog);
            return dialog.Show();
        }

        public MessageBoxResult Show(string instructionText, string text, string caption, IEnumerable<StyleableMessageBoxButton> buttons)
        {
            var dialog = new StyleableMessageBox
            {
                InstructionText = instructionText,
                Text = text,
                Caption = caption,
                Buttons = buttons
            };
            Initialize(dialog);
            return dialog.Show();
        }

        private void Initialize(StyleableMessageBox dialog)
        {
            dialog.Owner = _owner;
            dialog.WindowStartupLocation = _startupLocation;
            dialog.Style = _windowStyle;
            dialog.InstructionTextStyle = _instructionTextStyle;
            dialog.TextTemplate = _textTemplate;
            dialog.TextStyle = _textStyle;
            dialog.ButtonTemplate = _buttonTemplate;
            dialog.ButtonStyle = _buttonStyle;
        }
    }
}
