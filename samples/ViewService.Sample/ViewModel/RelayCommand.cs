using System;
using System.Windows.Input;

namespace ViewService.Sample.ViewModel
{
    internal class RelayCommand<T> : ICommand
        where T : class
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        public RelayCommand(Action<T> execute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
            : this(execute)
        {
            _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) =>
            _canExecute?.Invoke(parameter as T) ?? true;

        public void Execute(object parameter)
        {
            _execute?.Invoke(parameter as T);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    internal class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
            : this(execute)
        {
            _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) =>
            _canExecute?.Invoke() ?? true;

        public void Execute(object parameter)
        {
            _execute?.Invoke();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
