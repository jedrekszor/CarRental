using System;
using System.Windows.Input;

namespace PresentationLayer.viewModel.commands
{
    public class LogInCommand : ICommand
    {
        //private ViewModelMain VMmain { get; set; }
        
        public LogInCommand()
        {
            //VMmain = vmm;
        }
        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           //this.VMmain.LogInMethod(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}