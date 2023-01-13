using System;
using System.Windows.Input;

namespace TestApp_Intermodular.Core
{
    internal class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;
        private Action<object> value;

        public RelayCommand(Action<object> execute)
        {
            _execute = execute;
        }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);   
        }

        public void Execute(object parameter) 
        {
            _execute(parameter);        
        }
    }
}
