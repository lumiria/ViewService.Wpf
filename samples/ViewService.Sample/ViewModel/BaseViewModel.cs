using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViewServices;

namespace Sample.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IViewServiceProvider _viewServiceProvider;
        public IViewServiceProvider ViewServiceProvider
        {
            get => _viewServiceProvider ?? (_viewServiceProvider = ViewService.CreateProvider());
            set => _viewServiceProvider = value;
        }

        public bool Set<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
