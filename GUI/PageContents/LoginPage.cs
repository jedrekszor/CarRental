using GUI.Helper;
using GUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.PageContents
{
    public class LoginPage : PropertyMonitor
    {
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private ICommand _goToMainCommand;
        public ICommand GoToMainCommand
        {
            get
            {
                return _goToMainCommand;
            }
        }
    }
}
