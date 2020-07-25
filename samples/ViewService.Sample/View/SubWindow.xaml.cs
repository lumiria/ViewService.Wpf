using System.Windows;
using ViewServices.Components;
using ViewServices.View.Components;

namespace Sample.View
{
    /// <summary>
    /// SubWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SubWindow : Window
    {
        public SubWindow()
        {
            InitializeComponent();

            var messageBox = new StyleableMessageBox();
            messageBox.InstructionText = "sample";
            messageBox.Text = "This is a sample message box.";
            messageBox.Buttons = StyleableMessageBoxButtons.OK;
            messageBox.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as ViewModel.SubWindowViewModel;
            vm.CloseCommand.Execute(null);
        }
    }
}
