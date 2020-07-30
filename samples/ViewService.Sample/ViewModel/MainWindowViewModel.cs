using System.ComponentModel;
using System.Windows.Input;
using ViewServices;

namespace Sample.ViewModel
{
    public sealed class MainWindowViewModel : INotifyPropertyChanged
    {
        private RelayCommand<IViewServiceProvider> _subWindowCommand;
        public ICommand SubWindowCommand =>
            _subWindowCommand ?? (_subWindowCommand = new RelayCommand<IViewServiceProvider>(
                provider =>
                {
                    var windowService = provider.Get<IWindowService>("Sub");
                    windowService.ShowDialog();
                },
                _ => true));

        private RelayCommand<IViewServiceProvider> _messageBoxCommand;
        public ICommand MessageBoxCommand =>
            _messageBoxCommand ?? (_messageBoxCommand = new RelayCommand<IViewServiceProvider>(
                provider =>
                {
                    var messageBoxService = provider.Get<IMessageBoxService>();
                    messageBoxService.Show("Hello");
                },
                _ => true));

        private RelayCommand<IViewServiceProvider> _codeBehindWindowCommand;
        public ICommand CodeBehindWindowCommand =>
            _codeBehindWindowCommand ?? (_codeBehindWindowCommand = new RelayCommand<IViewServiceProvider>(
                provider =>
                {
                    var windowService = provider.Get<IWindowService>("CodeBehind");
                    windowService.ShowDialog();
                },
                _ => true));

        private RelayCommand<IViewServiceProvider> _standardMessageBoxCommand;
        public ICommand StandardMessageBoxCommand =>
            _standardMessageBoxCommand ?? (_standardMessageBoxCommand = new RelayCommand<IViewServiceProvider>(
                provider =>
                {
                    var service = provider.Get<IMessageBoxService>("StandardMessageBox");
                    service.Show("This is a standard message box.");
                },
                _ => true));

        private RelayCommand<IViewServiceProvider> _styleableMessageBoxCommand;
        public ICommand StyleableMessageBoxCommand =>
            _styleableMessageBoxCommand ?? (_styleableMessageBoxCommand = new RelayCommand<IViewServiceProvider>(
                provider =>
                {
                    var service = provider.Get<IStyleableMessageBoxService>("StyleableMessageBox");
                    service.Show("This is a styleable message box.");
                },
                _ => true));


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
