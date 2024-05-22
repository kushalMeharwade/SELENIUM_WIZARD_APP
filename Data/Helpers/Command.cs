using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Selenium_Wizard.Data.Helpers
{
    public class Command : ICommand
    {
        private Action<object> _action;
        private Func<object, bool> _canExecute;
        public Command(Func<object,bool> canExecute, Action<object> action)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action(parameter);
        }



    }
}
