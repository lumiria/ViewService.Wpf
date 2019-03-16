﻿using System.ComponentModel;
using System.Windows.Input;
using Lumiria.ViewServices;

namespace ViewService.Sample.ViewModel
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

        public event PropertyChangedEventHandler PropertyChanged;
    }
}