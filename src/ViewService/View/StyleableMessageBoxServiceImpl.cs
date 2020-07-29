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
        private readonly Style? _footerPaneStyle;
        private readonly Style? _instructionTextStyle;
        private readonly Style? _textStyle;
        private readonly ControlTemplate? _buttonTemplate;
        private readonly Style? _buttonStyle;
        private readonly Style? _imageStyle;
        private readonly DataTemplate? _captionPaneTemaplate;

        public StyleableMessageBoxServiceImpl(Window? owner,
            WindowStartupLocation startupLocation = WindowStartupLocation.CenterScreen,
            Style? windowStyle = null,
            Style? footerPaneStyle = null,
            Style? instructionTextStyle = null,
            Style? textStyle = null,
            ControlTemplate? buttonTemplate = null,
            Style? buttonStyle = null,
            Style? imageStyle = null,
            DataTemplate? captionPaneTemplate = null
            )
        {
            _owner = owner;
            _startupLocation = startupLocation;
            _windowStyle = windowStyle;
            _footerPaneStyle = footerPaneStyle;
            _instructionTextStyle = instructionTextStyle;
            _textStyle = textStyle;
            _buttonTemplate = buttonTemplate;
            _buttonStyle = buttonStyle;
            _imageStyle = imageStyle;
            _captionPaneTemaplate = captionPaneTemplate;
        }

        public string? Caption { get; set; }

        public MessageBoxImage Image { get; set; }

        public string? InstructionText { get; set; }

        public string? Text { get; set; }

        public MessageBoxResult Show(string text)
        {
            var dialog = new StyleableMessageBox
            {
                Caption = Caption,
                Image = Image,
                InstructionText = InstructionText,
                Text = text,
            };
            Initialize(dialog);
            return dialog.Show();
        }

        public MessageBoxResult Show(string instructionText, string text)
        {
            var dialog = new StyleableMessageBox
            {
                Caption = Caption,
                Image = Image,
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
                Caption = caption,
                Image = Image,
                InstructionText = instructionText,
                Text = text
            };
            Initialize(dialog);
            return dialog.Show();
        }

        public MessageBoxResult Show(string instructionText, string text, string caption, IEnumerable<StyleableMessageBoxButton> buttons)
        {
            var dialog = new StyleableMessageBox
            {
                Caption = caption,
                Image = Image,
                InstructionText = instructionText,
                Text = text,
                Buttons = buttons
            };
            Initialize(dialog);
            return dialog.Show();
        }
        public MessageBoxResult Show(string instructionText, string text, string caption, IEnumerable<StyleableMessageBoxButton> buttons, MessageBoxImage image)
        {
            var dialog = new StyleableMessageBox
            {
                Caption = caption,
                Image = image,
                InstructionText = instructionText,
                Text = text,
                Buttons = buttons
            };
            Initialize(dialog);
            return dialog.Show();
        }


        private void Initialize(StyleableMessageBox dialog)
        {
            dialog.Owner = _owner;
            dialog.WindowStartupLocation = _startupLocation;
            if (_windowStyle != null)
            {
                dialog.Style = _windowStyle;
            }
            dialog.FooterPaneStyle = _footerPaneStyle;
            dialog.InstructionTextStyle = _instructionTextStyle;
            dialog.TextStyle = _textStyle;
            dialog.ButtonTemplate = _buttonTemplate;
            dialog.ButtonStyle = _buttonStyle;
            dialog.ImageStyle = _imageStyle;

            dialog.CaptionPaneTemplate = _captionPaneTemaplate;
        }
    }
}
