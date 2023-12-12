using System;
using System.Windows.Input;

namespace LoginForm.ViewModels
{
    public class ViewModelCommand : ICommand
    {
        //fields
        private readonly Action<object> _executeAction;
        private readonly Predicate<object> _canExecuteAction;
        
        // constructors
        public ViewModelCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }
        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

       
        public bool CanExecute(object parameter)
        {
            return _canExecuteAction == null ? true : _canExecuteAction(parameter);
        }

        //events
        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value;}
            remove { CommandManager.RequerySuggested -= value;}
        }
    }
}