using System.Windows;
using Sample.ViewModel;
using ViewServices;

namespace Sample.View
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!(DataContext is MainWindowViewModel vm)) return;

            vm.ViewServiceProvider = (IViewServiceProvider)FindResource("ViewServiceProvider");
        }
    }
}
