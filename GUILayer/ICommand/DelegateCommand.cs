using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUILayer
{
    public class DelegateCommand : ICommand
    {
        // Action to be performed when this command is executed
        private readonly Action<object> executionAction;
        // Predicate to determine if the command is valid for execution
        private readonly Predicate<object> canExecutePredicate;

        /// <summary>
        /// Initializes a new instance of the DelegateCommand class.
        /// The command will always be valid for execution.
        /// </summary>
        /// <param name="execute">The delegate to call on execution</param>
        public DelegateCommand(Action<object> execute) : this(execute, null) { }

        /// <summary>
        /// Initializes a new instance of the DelegateCommand class.
        /// </summary>
        /// <param name="execute">The delegate to call on execution</param>
        /// <param name="canExecute">The predicate to determine if command is valid for execution</param>
        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.executionAction = execute ?? throw new ArgumentNullException("execute");
            this.canExecutePredicate = canExecute;
        }

        // Raised when CanExecute is changed
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Executes the delegate backing this DelegateCommand
        /// </summary>
        /// <param name="parameter">parameter to pass to predicate</param>
        /// <returns>True if command is valid for execution</returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecutePredicate == null ? true : this.canExecutePredicate(parameter);
        }

        /// <summary>
        /// Executes the delegate backing this DelegateCommand
        /// </summary>
        /// <param name="parameter">parameter to pass to delegate</param>
        /// <exception cref="InvalidOperationException">Thrown if CanExecute returns false</exception>
        public void Execute(object parameter)
        {
            if (!this.CanExecute(parameter))
            {
                throw new InvalidOperationException("The command is not valid for execution, check the CanExecute method before attempting to execute.");
            }
            this.executionAction(parameter);
        }
    }
}
