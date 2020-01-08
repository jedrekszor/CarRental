using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DataLayer.Database;
using GUI.Controller;
using GUI.Helper;
using LogicLayer;

namespace GUI.ViewModels
{
    public class LoginViewModel : PropertyMonitor
    {
        private string _title;
        private string _alert;

        public LoginViewModel()
        {
            Title = "Login screen";
            Alert = "";

            CheckData check = CheckData.GetInstance();

            GoToMainCommand = new RelayCommand(o => Login(o), o => check.CheckParametersArray(o));
            GoToMainCommandAdmin = new RelayCommand(o => AdminAccess(o));
            GoToNewUserCommand = new RelayCommand(o => GotoNewUser(o));
        }

        public void Login(object o)
        {
            var values = (object[])o;
            if (CheckData.CheckObjectArray(values))
            {
                var name = (string)values[0];
                var surname = (string)values[1];

                if (Authenticator.Authenticate(name, surname))
                {
                    Alert = "";
                    CurrentUserConfig.CurrentUser = DatabaseManager.GetClient(name, surname);
                    
                    OrderConfig.CurrOrder = Authenticator.GetClientsOrder();
                    Mediator.NotifyColleagues("toHome", true);
                }
                else
                {
                    Alert = "Name or Surname are incorrect!";
                }
            }
        }

        public void AdminAccess(object o)
        {
            Authenticator.AdminAccess();
            OrderConfig.CurrOrder = Authenticator.GetClientsOrder();

            Mediator.NotifyColleagues("toHome", true);
        }

        public void GotoNewUser(object o)
        {
            Mediator.NotifyColleagues("toNewUser", true);
        }

        public ICommand GoToMainCommand { get; }
        public ICommand GoToMainCommandAdmin { get; }
        public ICommand GoToNewUserCommand { get; }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string Alert
        {
            get => _alert;
            set
            {
                _alert = value;
                OnPropertyChanged(nameof(Alert));
            }
        }
    }
}

