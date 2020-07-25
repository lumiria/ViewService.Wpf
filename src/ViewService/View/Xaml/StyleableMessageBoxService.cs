#nullable enable

using System.Windows;

namespace ViewServices.View.Xaml
{
    public sealed class StyleableMessageBoxService : FreezableViewService<IStyleableMessageBoxService>
    {
        private IMessageBoxService? _serviceImpl;

        /// <summary>
        /// Gets or sets the <see cref="Window"/> that owns <see cref="MessageBox"/>.
        /// </summary>
        public Window? Owner
        {
            get => (Window?)GetValue(OwnerProperty);
            set => SetValue(OwnerProperty, value);
        }
        /// <summary>Owner Dependency Property</summary>
        public static readonly DependencyProperty OwnerProperty =
            DependencyProperty.Register("Owner", typeof(Window), typeof(MessageBoxService), new PropertyMetadata(null));

        internal override IViewService GetService() =>
            _serviceImpl ??= new MessageBoxServiceImpl(Owner);

        protected override Freezable CreateInstanceCore() =>
            new StyleableMessageBoxService();
    }
}
