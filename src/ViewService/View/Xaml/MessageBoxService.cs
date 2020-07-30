#nullable enable

using System.Windows;

namespace ViewServices.View.Xaml
{
    /// <summary>
    /// Represents a view service for displaying a message box.
    /// </summary>
    public sealed class MessageBoxService : FreezableViewService<IMessageBoxService>
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

        public string Caption
        {
            get => (string)GetValue(CaptionProperty);
            set => SetValue(CaptionProperty, value);
        }
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(MessageBoxService), new PropertyMetadata(""));

        public MessageBoxImage Image
        {
            get => (MessageBoxImage)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(MessageBoxImage), typeof(MessageBoxService), new PropertyMetadata(MessageBoxImage.None));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MessageBoxService), new PropertyMetadata(""));

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
