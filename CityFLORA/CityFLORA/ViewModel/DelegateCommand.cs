using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace CityFLORA.ViewModel
{
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;         //F12
        private readonly Action<object> _execute;               //F12        

        //public event EventHandler CanExecuteChanged;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        //Konstruktor
        public DelegateCommand(Action<object> execute,
                       Predicate<object> canExecute)
        {
            _execute = execute;                     //_ ist eine Namenskonfention für private
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        //public void RaiseCanExecuteChanged()
        //{
        //    if (CanExecuteChanged != null)
        //    {
        //        CanExecuteChanged(this, EventArgs.Empty);
        //    }
        //}
    }
}
