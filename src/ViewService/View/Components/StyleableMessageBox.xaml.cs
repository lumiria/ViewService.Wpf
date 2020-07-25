#nullable enable

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ViewServices.View.Components
{
    public partial class StyleableMessageBox : Window
    {
        private MessageBoxResult _result;

        public StyleableMessageBox()
        {
            InitializeComponent();
        }

        public string Caption
        {
            get => (string)GetValue(CaptionProperty);
            set => SetValue(CaptionProperty, value);
        }
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(StyleableMessageBox),
                new PropertyMetadata(null));

        public string InstructionText
        {
            get => (string)GetValue(InstructionTextProperty);
            set => SetValue(InstructionTextProperty, value);
        }
        public static readonly DependencyProperty InstructionTextProperty =
            DependencyProperty.Register("InstructionText", typeof(string), typeof(StyleableMessageBox),
                new PropertyMetadata(null, (d, e) =>
                {
                    var self = d as StyleableMessageBox;
                    if (self == null) return;

                    self.InstructionTextVisibility = string.IsNullOrEmpty((string)e.NewValue)
                        ? Visibility.Visible : Visibility.Collapsed;
                }));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(StyleableMessageBox),
                new PropertyMetadata(null, (d, e) =>
                {
                    var self = d as StyleableMessageBox;
                    if (self == null) return;

                    self.TextVisibility = string.IsNullOrEmpty((string)e.NewValue)
                        ? Visibility.Visible : Visibility.Collapsed;
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
                        : new ObservableCollection<StyleableMessageBoxButton>());
                }));



        public Style? FooterPaneStyle
        {
            get => (Style?)GetValue(FooterPaneStyleProperty)
                ?? (Style?)FindResource("MessageBox.FooterPaneStyle");
            set => SetValue(FooterPaneStyleProperty, value);
        }
        public static readonly DependencyProperty FooterPaneStyleProperty =
            DependencyProperty.Register("FooterPaneStyle", typeof(Style), typeof(StyleableMessageBox), new PropertyMetadata(null));


        public Style? InstructionTextStyle
        {
            get => (Style?)GetValue(InstructionTextStyleProperty)
                ?? (Style?)FindResource("MessageBox.InstructionTextStyle");
            set => SetValue(InstructionTextStyleProperty, value);
        }
        public static readonly DependencyProperty InstructionTextStyleProperty =
            DependencyProperty.Register("InstructionTextStyle", typeof(Style), typeof(StyleableMessageBox), new PropertyMetadata(null));


        public ControlTemplate? TextTemplate
        {
            get => (ControlTemplate?)GetValue(TextTemplateProperty);
            set => SetValue(TextTemplateProperty, value);
        }
        public static readonly DependencyProperty TextTemplateProperty =
            DependencyProperty.Register("TextTemplate", typeof(ControlTemplate), typeof(StyleableMessageBox), new PropertyMetadata(null));

        public Style? TextStyle
        {
            get => (Style?)GetValue(TextStyleProperty)
                ?? (Style?)FindResource("MessageBox.TextStyle");
            set => SetValue(TextStyleProperty, value);
        }
        public static readonly DependencyProperty TextStyleProperty =
            DependencyProperty.Register("TextStyle", typeof(Style), typeof(StyleableMessageBox), new PropertyMetadata(null));


        public ControlTemplate? ButtonTemplate
        {
            get => (ControlTemplate?)GetValue(ButtonTemplateProperty);
            set => SetValue(ButtonTemplateProperty, value);
        }
        public static readonly DependencyProperty ButtonTemplateProperty =
            DependencyProperty.Register("ButtonTemplate", typeof(ControlTemplate), typeof(StyleableMessageBox), new PropertyMetadata(null));


        public Style? ButtonStyle
        {
            get => (Style?)GetValue(ButtonStyleProperty);
            set => SetValue(ButtonStyleProperty, value);
        }
        public static readonly DependencyProperty ButtonStyleProperty =
            DependencyProperty.Register("ButtonStyle", typeof(Style), typeof(StyleableMessageBox), new PropertyMetadata(null));


        internal IEnumerable<StyleableMessageBoxButton> InnerButtons { get; set; } =
            Enumerable.Empty<StyleableMessageBoxButton>();

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


        public new MessageBoxResult Show()
        {
            WindowStartupLocation = Owner != null
                ? WindowStartupLocation.CenterOwner
                : WindowStartupLocation.CenterScreen;

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
    }
}
