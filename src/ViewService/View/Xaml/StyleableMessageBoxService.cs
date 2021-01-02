#nullable enable

using System.Windows;
using System.Windows.Controls;

namespace ViewServices.View.Xaml
{
    /// <summary>
    /// Provides a service of the <see cref="Components.StyleableMessageBox"/>
    /// </summary>
    public sealed class StyleableMessageBoxService : FreezableViewService<IStyleableMessageBoxService>
        , IOwnerRequirement
    {
        private IStyleableMessageBoxService? _serviceImpl;

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
            DependencyProperty.Register("Owner", typeof(Window), typeof(StyleableMessageBoxService), new PropertyMetadata(null));


        /// <summary>
        /// Gets or sets the position of the window when first shown.
        /// </summary>
        public WindowStartupLocation StartupLocation
        {
            get => (WindowStartupLocation)GetValue(StartupLocationProperty);
            set => SetValue(StartupLocationProperty, value);
        }
        public static readonly DependencyProperty StartupLocationProperty =
            DependencyProperty.Register("StartupLocation", typeof(WindowStartupLocation), typeof(StyleableMessageBoxService), new PropertyMetadata(WindowStartupLocation.CenterScreen));


        /// <summary>
        /// Gets or sets a <see cref="Style"/> that is applied the window.
        /// </summary>
        public Style? WindowStyle
        {
            get => (Style?)GetValue(WindowStyleProperty);
            set => SetValue(WindowStyleProperty, value);
        }
        public static readonly DependencyProperty WindowStyleProperty =
            DependencyProperty.Register("WindowStyle", typeof(Style), typeof(StyleableMessageBoxService), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets a <see cref="Style"/> that is applied the footer element.
        /// </summary>

        public Style? FooterPaneStyle
        {
            get => (Style?)GetValue(FooterPaneStyleProperty);
            set => SetValue(FooterPaneStyleProperty, value);
        }
        public static readonly DependencyProperty FooterPaneStyleProperty =
            DependencyProperty.Register("FooterPaneStyle", typeof(Style), typeof(StyleableMessageBoxService), new PropertyMetadata(null));


        /// <summary>
        /// Gets or sets a <see cref="Style"/> that is applied the instruction text element.
        /// </summary>
        public Style? InstructionTextStyle
        {
            get => (Style?)GetValue(InstructionTextStyleProperty);
            set => SetValue(InstructionTextStyleProperty, value);
        }
        public static readonly DependencyProperty InstructionTextStyleProperty =
            DependencyProperty.Register("InstructionTextStyle", typeof(Style), typeof(StyleableMessageBoxService), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets a <see cref="Style"/> that is applied the text element.
        /// </summary>

        public Style? TextStyle
        {
            get => (Style?)GetValue(TextStyleProperty);
            set => SetValue(TextStyleProperty, value);
        }
        public static readonly DependencyProperty TextStyleProperty =
            DependencyProperty.Register("TextStyle", typeof(Style), typeof(StyleableMessageBoxService), new PropertyMetadata(null));


        /// <summary>
        /// Gets or sets a button control template.
        /// </summary>
        public ControlTemplate? ButtonTemplate
        {
            get => (ControlTemplate?)GetValue(ButtonTemplateProperty);
            set => SetValue(ButtonTemplateProperty, value);
        }
        public static readonly DependencyProperty ButtonTemplateProperty =
            DependencyProperty.Register("ButtonTemplate", typeof(ControlTemplate), typeof(StyleableMessageBoxService), new PropertyMetadata(null));


        /// <summary>
        /// Gets or sets a <see cref="Style"/> that is applied the button element.
        /// </summary>
        public Style? ButtonStyle
        {
            get => (Style?)GetValue(ButtonStyleProperty);
            set => SetValue(ButtonStyleProperty, value);
        }
        public static readonly DependencyProperty ButtonStyleProperty =
            DependencyProperty.Register("ButtonStyle", typeof(Style), typeof(StyleableMessageBoxService), new PropertyMetadata(null));


        /// <summary>
        /// Gets or sets a <see cref="Style"/> that is applied the image element.
        /// </summary>
        public Style? ImageStyle
        {
            get => (Style?)GetValue(ImageStyleProperty);
            set => SetValue(ImageStyleProperty, value);
        }
        public static readonly DependencyProperty ImageStyleProperty =
            DependencyProperty.Register("ImageStyle", typeof(Style), typeof(StyleableMessageBoxService), new PropertyMetadata(null));


        /// <summary>
        /// Gets or sets a <see cref="DataTemplate"/> that specifies the visualization of the data object for the caption bar.
        /// </summary>
        public DataTemplate? CaptionPaneTemplate
        {
            get => (DataTemplate?)GetValue(CaptionPaneTemplateProperty);
            set => SetValue(CaptionPaneTemplateProperty, value);
        }
        public static readonly DependencyProperty CaptionPaneTemplateProperty =
            DependencyProperty.Register("CaptionPaneTemplate", typeof(DataTemplate), typeof(StyleableMessageBoxService), new PropertyMetadata(null));


        /// <summary>
        /// Gets or sets a string that the title bar caption to display.
        /// </summary>
        public string? Caption
        {
            get => (string?)GetValue(CaptionProperty);
            set => SetValue(CaptionProperty, value);
        }
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(StyleableMessageBoxService), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets a <see cref="MessageBoxImage"/> value that specifies the icon to display.
        /// </summary>
        public MessageBoxImage Image
        {
            get => (MessageBoxImage)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(MessageBoxImage), typeof(StyleableMessageBoxService), new PropertyMetadata(MessageBoxImage.None));


        /// <summary>
        /// Gets or sets a string that specifies the instruction text to display.
        /// </summary>
        public string? InstructionText
        {
            get => (string?)GetValue(InstructionTextProperty);
            set => SetValue(InstructionTextProperty, value);
        }
        public static readonly DependencyProperty InstructionTextProperty =
            DependencyProperty.Register("InstructionText", typeof(string), typeof(StyleableMessageBoxService), new PropertyMetadata(null));


        /// <summary>
        /// Gets or sets a string that specifies the text to display.
        /// </summary>
        public string? Text
        {
            get => (string?)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(StyleableMessageBoxService), new PropertyMetadata(null));


        internal override IViewService GetService() =>
            _serviceImpl ??= new StyleableMessageBoxServiceImpl(Owner,
                StartupLocation,
                WindowStyle,
                FooterPaneStyle,
                InstructionTextStyle,
                TextStyle,
                ButtonTemplate,
                ButtonStyle,
                ImageStyle,
                captionPaneTemplate: CaptionPaneTemplate)
            {
                Caption = Caption,
                Image = Image,
                InstructionText = InstructionText,
                Text = Text
            };

        protected override Freezable CreateInstanceCore() =>
            new StyleableMessageBoxService();
    }
}
