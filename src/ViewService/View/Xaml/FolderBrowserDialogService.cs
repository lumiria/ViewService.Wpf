#nullable enable

using System.Windows;

namespace ViewServices.View.Xaml
{
    /// <summary>
    /// Provides a service of the <see cref="Components.FolderBrowserDialog"/>
    /// </summary>
    public sealed class FolderBrowserDialogService : FreezableViewService<IFolderBrowserDialogService>
        , IOwnerRequirement
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

        /// <summary>
        /// Gets or sets the text that appears in the title bar of a folder browser dialog.
        /// </summary>
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
