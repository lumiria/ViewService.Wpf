#nullable enable

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ViewServices.Components;
using ViewServices.View.Xaml;

namespace ViewServices.View.Components
{
    public partial class StyleableMessageBox : Window
    {
        private MessageBoxResult _result;

        public StyleableMessageBox()
        {
            InitializeComponent();
        }

        public string? Caption
        {
            get => (string?)GetValue(CaptionProperty);
            set => SetValue(CaptionProperty, value);
        }
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(StyleableMessageBox),
                new PropertyMetadata(null));

        public MessageBoxImage Image
        {
            get => (MessageBoxImage)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(MessageBoxImage), typeof(StyleableMessageBox),
                new PropertyMetadata(MessageBoxImage.None, (d, e) =>
                {
                    if (!(d is StyleableMessageBox self)) return;

                    var value = (MessageBoxImage)e.NewValue;
                    self.InnerImage = ConvertToImageSource(value);
                }));
        private static ImageSource? ConvertToImageSource(MessageBoxImage image)
        {
            var icon = (int)image switch
            {
                (int)MessageBoxImage.None => null,
                (int)MessageBoxImage.Asterisk => SystemIcons.Asterisk,
                (int)MessageBoxImage.Error => SystemIcons.Error,
                (int)MessageBoxImage.Exclamation => SystemIcons.Exclamation,
                //(int)MessageBoxImage.Hand => SystemIcons.Hand,
                //(int)MessageBoxImage.Information => SystemIcons.Information,
                (int)MessageBoxImage.Question => SystemIcons.Question,
                //(int)MessageBoxImage.Stop => SystemIcons.Shield,
                //(int)MessageBoxImage.Warning => SystemIcons.Warning
                _ => null
            };

            if (icon == null) return null;

            var source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            icon.Dispose();

            return source;
        }


        public string? InstructionText
        {
            get => (string?)GetValue(InstructionTextProperty);
            set => SetValue(InstructionTextProperty, value);
        }
        public static readonly DependencyProperty InstructionTextProperty =
            DependencyProperty.Register("InstructionText", typeof(string), typeof(StyleableMessageBox),
                new PropertyMetadata(null, (d, e) =>
                {
                    var self = d as StyleableMessageBox;
                    if (self == null) return;

                    self.InstructionTextVisibility = string.IsNullOrEmpty((string)e.NewValue)
                        ? Visibility.Collapsed : Visibility.Visible;
                }));

        public string? Text
        {
            get => (string?)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(StyleableMessageBox),
                new PropertyMetadata(null, (d, e) =>
                {
                    var self = d as StyleableMessageBox;
                    if (self == null) return;

                    self.TextVisibility = string.IsNullOrEmpty((string)e.NewValue)
                        ? Visibility.Collapsed : Visibility.Visible;
                }));

        public IEnumerable<StyleableMessageBoxButton> Buttons
        {
            get => (IEnumerable<StyleableMessageBoxButton>)GetValue(ButtonsProperty);
            set => SetValue(ButtonsProperty, value);
        }
        public static readonly DependencyProperty ButtonsProperty =
            DependencyProperty.Register("Buttons", typeof(IEnumerable<StyleableMessageBoxButton>), typeof(StyleableMessageBox),
                new PropertyMetadata(Enumerable.Empty<StyleableMessageBoxButton>(), (d, e) =>
                {
                    var self = d as StyleableMessageBox;
                    if (self == null) return;

                    self.InnerButtons = new ReadOnlyObservableCollection<StyleableMessageBoxButton>(
                        e.NewValue != null
                        ? new ObservableCollection<StyleableMessageBoxButton>((IEnumerable<StyleableMessageBoxButton>)e.NewValue)
                        : new ObservableCollection<StyleableMessageBoxButton>(StyleableMessageBoxButtons.OK));
                }));


        public Style? FooterPaneStyle
        {
            get => (Style?)GetValue(FooterPaneStyleProperty)
                ?? (Style?)FindResource("MessageBox.FooterPaneStyle");
            set => SetValue(FooterPaneStyleProperty, value);
        }
        public static readonly DependencyProperty FooterPaneStyleProperty =
            DependencyProperty.Register("FooterPaneStyle", typeof(Style), typeof(StyleableMessageBox),
                new PropertyMetadata(null));


        public Style? ImageStyle
        {
            get => (Style?)GetValue(ImageStyleProperty)
                ?? (Style?)FindResource("MessageBox.ImageStyle");
            set => SetValue(ImageStyleProperty, value);
        }
        public static readonly DependencyProperty ImageStyleProperty =
            DependencyProperty.Register("ImageStyle", typeof(Style), typeof(StyleableMessageBox), new PropertyMetadata(null));


        public Style? InstructionTextStyle
        {
            get => (Style?)GetValue(InstructionTextStyleProperty)
                ?? (Style?)FindResource("MessageBox.InstructionTextStyle");
            set => SetValue(InstructionTextStyleProperty, value);
        }
        public static readonly DependencyProperty InstructionTextStyleProperty =
            DependencyProperty.Register("InstructionTextStyle", typeof(Style), typeof(StyleableMessageBox),
                new PropertyMetadata(null));


        //public ControlTemplate? TextTemplate
        //{
        //    get => (ControlTemplate?)GetValue(TextTemplateProperty);
        //    set => SetValue(TextTemplateProperty, value);
        //}
        //public static readonly DependencyProperty TextTemplateProperty =
        //    DependencyProperty.Register("TextTemplate", typeof(ControlTemplate), typeof(StyleableMessageBox),
        //        new PropertyMetadata(null));

        public Style? TextStyle
        {
            get => (Style?)GetValue(TextStyleProperty)
                ?? (Style?)FindResource("MessageBox.TextStyle");
            set => SetValue(TextStyleProperty, value);
        }
        public static readonly DependencyProperty TextStyleProperty =
            DependencyProperty.Register("TextStyle", typeof(Style), typeof(StyleableMessageBox),
                new PropertyMetadata(null));


        public ControlTemplate? ButtonTemplate
        {
            get => (ControlTemplate?)GetValue(ButtonTemplateProperty);
            set => SetValue(ButtonTemplateProperty, value);
        }
        public static readonly DependencyProperty ButtonTemplateProperty =
            DependencyProperty.Register("ButtonTemplate", typeof(ControlTemplate), typeof(StyleableMessageBox),
                new PropertyMetadata(null));


        public Style? ButtonStyle
        {
            get => (Style?)GetValue(ButtonStyleProperty)
                ?? (Style?)FindResource("MessageBox.ButtonStyle");
            set => SetValue(ButtonStyleProperty, value);
        }
        public static readonly DependencyProperty ButtonStyleProperty =
            DependencyProperty.Register("ButtonStyle", typeof(Style), typeof(StyleableMessageBox), new PropertyMetadata(null));


        public DataTemplate? CaptionPaneTemplate
        {
            get => (DataTemplate?)GetValue(CaptionPaneTemplateProperty);
            set => SetValue(CaptionPaneTemplateProperty, value);
        }
        public static readonly DependencyProperty CaptionPaneTemplateProperty =
            DependencyProperty.Register("CaptionPaneTemplate", typeof(DataTemplate), typeof(StyleableMessageBox), new PropertyMetadata(null));


        internal IEnumerable<StyleableMessageBoxButton> InnerButtons
        {
            get => (IEnumerable<StyleableMessageBoxButton>)GetValue(InnerButtonsProperty);
            set => SetValue(InnerButtonsProperty, value);
        }
        public static readonly DependencyProperty InnerButtonsProperty =
            DependencyProperty.Register("InnerButtons", typeof(IEnumerable<StyleableMessageBoxButton>), typeof(StyleableMessageBox),
                new PropertyMetadata(StyleableMessageBoxButtons.OK));

        private ImageSource? InnerImage
        {
            get => (ImageSource?)GetValue(InnerImageProperty);
            set => SetValue(InnerImageProperty, value);
        }
        private static readonly DependencyProperty InnerImageProperty =
            DependencyProperty.Register("InnerImage", typeof(ImageSource), typeof(StyleableMessageBox),
                new PropertyMetadata(null, (d, e) =>
                {
                    if (!(d is StyleableMessageBox self)) return;
                    self.ImageVisibility = e.NewValue != null
                        ? Visibility.Visible
                        : Visibility.Collapsed;
                }));


        private Visibility InstructionTextVisibility
        {
            get => (Visibility)GetValue(InstructionTextVisibilityProperty);
            set => SetValue(InstructionTextVisibilityProperty, value);
        }
        private static readonly DependencyProperty InstructionTextVisibilityProperty =
            DependencyProperty.Register("InstructionTextVisibility", typeof(Visibility), typeof(StyleableMessageBox), new PropertyMetadata(Visibility.Collapsed));

        private Visibility TextVisibility
        {
            get => (Visibility)GetValue(TextVisibilityProperty);
            set => SetValue(TextVisibilityProperty, value);
        }
        private static readonly DependencyProperty TextVisibilityProperty =
            DependencyProperty.Register("TextVisibility", typeof(Visibility), typeof(StyleableMessageBox), new PropertyMetadata(Visibility.Collapsed));



        private Visibility ImageVisibility
        {
            get => (Visibility)GetValue(ImageVisibilityProperty);
            set => SetValue(ImageVisibilityProperty, value);
        }
        private static readonly DependencyProperty ImageVisibilityProperty =
            DependencyProperty.Register("ImageVisibility", typeof(Visibility), typeof(StyleableMessageBox), new PropertyMetadata(Visibility.Collapsed));



        public new MessageBoxResult Show()
        {
            ShowDialog();

            return _result;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var data = button?.DataContext as StyleableMessageBoxButton;

            if (data != null)
            {
                _result = data.Result;
            }

            Close();
        }

        private void CommandBinding_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }


        private void CommandBinding_Minimize_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void CommandBinding_Restore_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            SystemCommands.RestoreWindow(this);
        }

        private void CommandBinding_Maximize_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            SystemCommands.MaximizeWindow(this);
        }

        private void CommandBinding_Close_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }
    }
}
