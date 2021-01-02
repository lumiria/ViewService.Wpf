#nullable enable

using System.Windows;

namespace ViewServices.View.Xaml
{
    /// <summary>
    /// Represents a view service for displaying a message box.
    /// </summary>
    public sealed class MessageBoxService : FreezableViewService<IMessageBoxService>
        , IOwnerRequirement
    {
        private IMessageBoxService? _serviceImpl;

        /// <summary>
        /// Gets or sets the <see cref="Window"/> that owns <see cref="MessageBox"/>.
        /// </summary>
        public Window? Owner
        {
            get => (Window?)GetValue(OwnerProperty);
            set => SetValue(OwnerProperty, value);
        }
        /// <summary>Owner Dependency Property</summary>
        public static readonly DependencyProperty OwnerProperty =
            DependencyProperty.Register("Owner", typeof(Window), typeof(MessageBoxService), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets a string that specifies the title bar caption to display.
        /// </summary>
        public string Caption
        {
            get => (string)GetValue(CaptionProperty);
            set => SetValue(CaptionProperty, value);
        }
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(MessageBoxService), new PropertyMetadata(""));

        /// <summary>
        /// Gets or sets a <see cref="MessageBoxImage"/> value that specifies the icon to display.
        /// </summary>
        public MessageBoxImage Image
        {
            get => (MessageBoxImage)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(MessageBoxImage), typeof(MessageBoxService), new PropertyMetadata(MessageBoxImage.None));

        /// <summary>
        /// Gets or sets a string that specifies the text to display.
        /// </summary>
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MessageBoxService), new PropertyMetadata(""));


        /// <summary>
        /// Gets or sets a <see cref="MessageBoxButton"/> value that specifies which button or buttons to display.
        /// </summary>
        public MessageBoxButton Button
        {
            get => (MessageBoxButton)GetValue(ButtonProperty);
            set => SetValue(ButtonProperty, value);
        }
        public static readonly DependencyProperty ButtonProperty =
            DependencyProperty.Register("Button", typeof(MessageBoxButton), typeof(MessageBoxService), new PropertyMetadata(MessageBoxButton.OK));


        internal override IViewService GetService() =>
            _serviceImpl ??= new MessageBoxServiceImpl(Owner)
            {
                Caption = Caption,
                Image = Image,
                Text = Text
            };

        protected override Freezable CreateInstanceCore() =>
            new MessageBoxService();
    }
}
