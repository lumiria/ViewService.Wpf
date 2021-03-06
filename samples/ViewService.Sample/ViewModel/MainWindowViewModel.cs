﻿using System.Windows.Input;
using ViewServices;

namespace Sample.ViewModel
{
    public sealed class MainWindowViewModel : BaseViewModel
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

        private RelayCommand<IViewServiceProvider> _openFileCommand;
        public ICommand OpenFileCommand =>
            _openFileCommand ?? (_openFileCommand = new RelayCommand<IViewServiceProvider>(
                provider =>
                {
                    var service = provider.Get<IOpenFileDialogService>();
                    service.ShowDialog();
                },
                _ => true));

        private RelayCommand<IViewServiceProvider> _saveFileCommand;
        public ICommand SaveFileCommand =>
            _saveFileCommand ?? (_saveFileCommand = new RelayCommand<IViewServiceProvider>(
                provider =>
                {
                    var service = provider.Get<ISaveFileDialogService>();
                    service.ShowDialog();
                },
                _ => true));

        private RelayCommand<IViewServiceProvider> _folderBrowserDialog;
        public ICommand FolderBrowserCommand =>
            _folderBrowserDialog ?? (_folderBrowserDialog = new RelayCommand<IViewServiceProvider>(
                provider =>
                {
                    var service = provider.Get<IFolderBrowserDialogService>();
                    service.ShowDialog();
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

        private RelayCommand _standardMessageBoxCommand;
        public ICommand StandardMessageBoxCommand =>
            _standardMessageBoxCommand ?? (_standardMessageBoxCommand = new RelayCommand(
                () =>
                {
                    var service = ViewServiceProvider.Get<IMessageBoxService>("StandardMessageBox");
                    service.Show("This is a standard message box.");
                },
                () => true));

        private RelayCommand _defaultStyleableMessageBoxCommand;
        public ICommand DefaultStyleableMessageBoxCommand =>
            _defaultStyleableMessageBoxCommand ?? (_defaultStyleableMessageBoxCommand = new RelayCommand(
                () =>
                {
                    var service = ViewServiceProvider.Get<IStyleableMessageBoxService>("DefaultStyleableMessageBox");
                    service.Show("This is a styleable message box.");
                },
                () => true));

        private RelayCommand _styleableMessageBoxCommand;
        public ICommand StyleableMessageBoxCommand =>
            _styleableMessageBoxCommand ?? (_styleableMessageBoxCommand = new RelayCommand(
                () =>
                {
                    var service = ViewServiceProvider.Get<IStyleableMessageBoxService>("StyleableMessageBox");
                    service.Show("This is a styleable message box.");
                },
                () => true));
    }
}
