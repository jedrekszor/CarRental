using System;
using System.Windows.Input;

namespace PresentationLayer.viewModel.commands
{
    public class ChangeTextCommand : ICommand
    {
        private ViewModelMain ViewModelMain { get; set; }

        public ChangeTextCommand(ViewModelMain viewModelMain)
        {
            ViewModelMain = viewModelMain;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.ViewModelMain.ChangeTextMethod(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}