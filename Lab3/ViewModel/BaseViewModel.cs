using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab3.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ReplayCommand : ICommand
    {
        private readonly Predicate<object> _canExcute;

        private readonly Action<object> _execute;

        public ReplayCommand(Predicate<object> canExcute, Action<object> execute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
            _canExcute = canExcute;
            _execute = execute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            try
            {
                return _canExcute == null ? true : _canExcute(parameter);
            }
            catch
            {
                return true;
            }
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
