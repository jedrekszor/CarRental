using GUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.ViewModels
{
    public class MainViewModel : PropertyMonitor
    {
        private string _title;

        public MainViewModel()
        {
            Title = "Main screen";
            GoToLoginCommand = new RelayCommand(o => GoLogin(o));
            GoToAccountCommand = new RelayCommand(o => GoAccount(o));
            GoToCarListCommand = new RelayCommand(o => GoCarList(o));
            GoToRentCommand = new RelayCommand(o => GoToRent(o));
            GoToReturnCommand = new RelayCommand(o => GoToReturn(o));
        }

        public ICommand GoToLoginCommand { get; }
        public ICommand GoToAccountCommand { get; }
        public ICommand GoToCarListCommand { get; }
        public ICommand GoToRentCommand { get; }
        public ICommand GoToReturnCommand { get; }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private void GoLogin(object o)
        {
            Mediator.NotifyColleagues("toLogin", true);
        } 
        private void GoAccount(object o)
        {
            Mediator.NotifyColleagues("toAccount", true);
        }
        private void GoCarList(object o)
        {
            Mediator.NotifyColleagues("toCarList", true);
        }
        private void GoToRent(object o)
        {
            Mediator.NotifyColleagues("toRent", true);
        }
        private void GoToReturn(object o)
        {
            Mediator.NotifyColleagues("toReturn", true);
        }
    }
}
