using System.ComponentModel;
using System.Windows.Input;
using Lumiria.ViewServices;

namespace Sample.ViewModel
{
    public sealed class SubWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IViewServiceProvider ServiceProvider { get; set; }

        private RelayCommand _closeCommand;
        public ICommand CloseCommand =>
            _closeCommand ?? (_closeCommand = new RelayCommand(
                () => ServiceProvider?.Get<IWindowActionService>().Close(),
                () => true));

        private RelayCommand _maximizeCommand;
        public ICommand MaximizeCommand =>
            _maximizeCommand ?? (_maximizeCommand = new RelayCommand(
                () => ServiceProvider?.Get<IWindowActionService>().Maximize(),
                () => true));

        private RelayCommand _minimizeCommand;
        public ICommand MinimizeCommand =>
            _minimizeCommand ?? (_minimizeCommand = new RelayCommand(
                () => ServiceProvider?.Get<IWindowActionService>().Minimize(),
                () => true));

        private RelayCommand _normalCommand;
        public ICommand NormalCommand =>
            _normalCommand ?? (_normalCommand = new RelayCommand(
                () => ServiceProvider?.Get<IWindowActionService>().Normal(),
                () => true));
    }
}
