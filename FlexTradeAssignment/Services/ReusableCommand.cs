using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlexTradeAssignment.Services
{
    class ReusableCommand : ICommand
    {
        Func<bool> canExecute;
        Action executeAction;

        public ReusableCommand(Action executeAction)
            : this(executeAction, null)
        {
        }

        public ReusableCommand(Action executeAction, Func<bool> canExecute)
        {
            this.executeAction = executeAction ?? throw new ArgumentNullException(nameof(executeAction));
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute?.Invoke() ?? true;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        public void Execute(object parameter)
        {
            this.executeAction?.Invoke();
        }
    }
}
