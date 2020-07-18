using System;
using System.Windows;
using Lumiria.ViewServices.View;
using Lumiria.ViewServices.View.Extensions;
using Sample.ViewModel;

namespace Sample.View
{
    /// <summary>
    /// CodeBehindWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class CodeBehindWindow : Window
    {
        public CodeBehindWindow()
        {
            InitializeComponent();

            var provider = ViewModel.ViewServiceProvider;
            provider.AddService(
                () => ViewServiceFactory.CreateWindowAction(this));
            provider.AddService(
                () => ViewServiceFactory.CreateMessageBox(this));
            provider.AddService(
                () => ViewServiceFactory.CreateOpenFileDialog(this));
            provider.AddService(
                () => ViewServiceFactory.CreateSaveFileDialog(this));
            provider.AddService(
                () => ViewServiceFactory.CreateSaveFileDialog(this));
            provider.AddService(
                () => ViewServiceFactory.CreateFolderBrowserDialog(this));
        }

        private CodeBehindWindowViewModel ViewModel =>
            DataContext as CodeBehindWindowViewModel ?? throw new InvalidOperationException();
    }
}
