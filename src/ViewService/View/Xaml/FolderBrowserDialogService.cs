#nullable enable

using System.Windows;

namespace ViewServices.View.Xaml
{
    public sealed class FolderBrowserDialogService : FreezableViewService<IFolderBrowserDialogService>
    {
        private IFolderBrowserDialogService? _serviceImpl;

        /// <summary>
        /// Gets or sets the <see cref="Window"/> that owns <see cref="FolderBrowserDialog"/>.
        /// </summary>
        public Window? Owner
        {
            get => (Window?)GetValue(OwnerProperty);
            set => SetValue(OwnerProperty, value);
        }
        /// <summary>Owner Dependency Property</summary>
        public static readonly DependencyProperty OwnerProperty =
            DependencyProperty.Register("Owner", typeof(Window), typeof(FolderBrowserDialogService), new PropertyMetadata(null));

        public string? Title
        {
            get => (string?)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(FolderBrowserDialogService), new PropertyMetadata(null));

        internal override IViewService GetService() =>
            _serviceImpl ??= new FolderBrowserDialogServiceImpl(Owner)
            {
                Title = Title
            };

        protected override Freezable CreateInstanceCore() =>
            new FolderBrowserDialogService();
    }
}
