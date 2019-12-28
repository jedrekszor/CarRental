using GUI.Helper;
using GUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModels
{
    public class WindowViewModel : PropertyMonitor
    {
        //views
        private object _loginView = new LoginView();
        private object _mainView = new MainView();
        private object _newUserView = new NewUserView();
        private object _accountView = new AccountView();
        private object _carListView = new CarListView();
        private object _carRentView = new RentCarView();
        private object _returnCarView = new ReturnCarView();

        private object _currentView;

        public WindowViewModel()
        {
            Mediator.Register("toLogin", LoadLoginView);
            Mediator.Register("toHome", LoadHomeView);
            Mediator.Register("toNewUser", LoadNewUserView);
            Mediator.Register("toAccount", LoadAccountView);
            Mediator.Register("toCarList", LoadCarListView);
            Mediator.Register("toRent", LoadRentCarView);
            Mediator.Register("toReturn", LoadReturnCarView);

            Mediator.NotifyColleagues("toLogin", true);
        }

        public object CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        //methods changing current view
        private void LoadHomeView(object o)
        {
            CurrentView = _mainView;
        }
        private void LoadLoginView(object o)
        {
            CurrentView = _loginView;
        }
        private void LoadNewUserView(object o)
        {
            CurrentView = _newUserView;
        }
        private void LoadAccountView(object o)
        {
            CurrentView = _accountView;
        }
        private void LoadCarListView(object o)
        {
            CurrentView = _carListView;
        }
        private void LoadRentCarView(object o)
        {
            CurrentView = _carRentView;
        }
        private void LoadReturnCarView(object o)
        {
            CurrentView = _returnCarView;
        }
    }
}
