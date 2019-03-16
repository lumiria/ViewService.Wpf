using System.Windows;

namespace ViewService.Sample.View
{
    /// <summary>
    /// SubWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SubWindow : Window
    {
        public SubWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as ViewModel.SubWindowViewModel;
            vm.CloseCommand.Execute(null);
        }
    }
}
